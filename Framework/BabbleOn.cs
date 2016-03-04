using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace BOG.Framework
{
    internal class EavesDropper
    {
        public DateTime StartedOn = DateTime.MinValue;
        public Thread Worker = null;
        public DateTime TimeoutOn = DateTime.MinValue;
        public TcpClient TcpClient = null;
        public NetworkStream ClientStream = null;
        public Queue<string> Messages = new Queue<string>();
        public bool Running = true;
        public bool StopRequested = false;
        public int KeepAliveRequests = 0;
    }

    /// <summary>
    /// This class is intended to be integrated into a windows/web service, but can be used in console
    /// or windows form applications.  It establishes a TCP listener on a port, and allows one or more 
    /// simple TCP clients (including telnet clients) to connect and eavesdrop about the code's 
    /// activity/inactivity. It is intended for debugging/troubleshooting a service's activity, 
    /// without permanent logging.
    /// TCP listener low port defaults to 65200, and the high port defaults to 65299.  The can be 
    /// overridden by creating appSettings in a config file of BabbleOn.LowPort and BabbleOn.HighPort.
    /// The ports available for monitoring can be determined with the Babbler console application.
    /// </summary>
    public class BabbleOn
    {
        private string _appSignature = string.Empty;
        private int _LowListenPort = 65200;
        private int _HighListenPort = 65299;
        private int _ListeningPort = 0;
        private int _MaxListeners = 5;
        private int _TimeoutSeconds = 900;

        private TcpListener MyTcpListener;
        private Thread MyListenThread;
        private Dictionary<Guid, EavesDropper> Listeners = new Dictionary<Guid, EavesDropper>();
        private DateTime StartTime = DateTime.Now;
        private bool Running = false;
        private bool Listening = false;

        public int MaxListeners
        {
            get { return _MaxListeners; }
        }

        /// <summary>
        /// The number of seconds after a connection, without keep alives, before it is forcibly 
        /// disconnected.
        /// </summary>
        public int TimeoutSeconds
        {
            get { return _TimeoutSeconds; }
        }

        /// <summary>
        /// The port assigned to this listener.
        /// </summary>
        public int ListeningPort
        {
            get { return _ListeningPort; }
        }

        public int LowListenPort
        {
            get { return _LowListenPort; }
        }

        public int HighListenPort
        {
            get { return _HighListenPort; }
        }

        public BabbleOn()
        {
            LoadPortRange();
        }

        public BabbleOn(int maxListeners, int timeoutSeconds)
        {
            _MaxListeners = maxListeners;
            if (timeoutSeconds >= 0)
            {
                _TimeoutSeconds = timeoutSeconds;
            }
            LoadPortRange();
        }

        ~BabbleOn()
        {
            Stop();
        }

        private void LoadPortRange()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["BabbleOn.LowPort"] != null)
            {
                string LowValue = System.Configuration.ConfigurationManager.AppSettings["BabbleOn.LowPort"];
                try
                {
                    _LowListenPort = int.Parse(LowValue);
                }
                catch
                {
                    throw new Exception(string.Format("The appSeting for BabbleOn.LowPort is not a parsable integer: {0}", LowValue));
                }
                if (_LowListenPort < 1 || _LowListenPort > 65534)
                {
                    throw new Exception(string.Format("The appSeting for BabbleOn.LowPort is not in the range 1 <= n <= 65534: {0}", LowValue));
                }
            }
            if (System.Configuration.ConfigurationManager.AppSettings["BabbleOn.HighPort"] != null)
            {
                string HighValue = System.Configuration.ConfigurationManager.AppSettings["BabbleOn.HighPort"];
                try
                {
                    _HighListenPort = int.Parse(HighValue);
                }
                catch
                {
                    throw new Exception(string.Format("The appSeting for BabbleOn.HighPort is not a parsable integer: {0}", HighValue));
                }
                if (_HighListenPort < 1 || _HighListenPort > 65534)
                {
                    throw new Exception(string.Format("The appSeting for BabbleOn.HighPort is not in the range 1 <= n <= 65534: {0}", HighValue));
                }
            }
        }

        public void Start()
        {
            if (Running == false)
            {
                EstablishListener();
                StartTime = DateTime.Now;
            }
        }

        public void Stop()
        {
            if (Running)
            {
                Running = false;
                while (Listening)
                {
                    Thread.Sleep(100);
                }
                if (MyListenThread.ThreadState == ThreadState.Running || MyListenThread.ThreadState == ThreadState.Suspended)
                {
                    MyListenThread.Abort();
                }
                MyListenThread = null;
                while (Listeners.Count > 0)
                {
                    Guid g = Listeners.Keys.ElementAt(0);
                    DropListener(g);
                }
            }
        }

        private void EstablishListener()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["BabbleOn.LowPort"] != null)
            {
                if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["BabbleOn.LowPort"], out _LowListenPort) == false)
                {
                    throw new Exception("The value for AppSettings key \"BabbleOn.LowPort\" does not contain a valid integer value.");
                }
                if (_LowListenPort < 1 || _LowListenPort >= 65535)
                {
                    throw new Exception("The port number in AppSettings key \"BabbleOn.LowPort\" is not in the range 1 < x < 65535");
                }
                if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["BabbleOn.HighPort"], out _HighListenPort) == false)
                {
                    throw new Exception("The value for AppSettings key \"BabbleOn.HighPort\" does not contain a valid integer value.");
                }
                if (_HighListenPort < 1 || _HighListenPort >= 65535)
                {
                    throw new Exception("The port number in AppSettings key \"BabbleOn.HighPort\" is not in the range 1 < x < 65535");
                }
                if (_LowListenPort > _HighListenPort)
                {
                    int t = _LowListenPort;
                    _LowListenPort = _HighListenPort;
                    _HighListenPort = t;
                }
            }
            for (_ListeningPort = _LowListenPort; _ListeningPort <= _HighListenPort; _ListeningPort++)
            {
                try
                {
                    this.MyTcpListener = new TcpListener(IPAddress.Any, _ListeningPort);
                    this.MyTcpListener.ExclusiveAddressUse = true;
                    this.MyTcpListener.Start();
                    this.MyTcpListener.Stop();
                    this.MyListenThread = new Thread(new ThreadStart(ListenForClients));
                    this.MyListenThread.Start();
                    Running = true;
                    break;
                }
                catch (SocketException)
                {
                    // this is the only error we trap and ignore.
                }
            }
            if (Running == false)
            {
                throw new Exception(string.Format(
                    "BabbleOn was not able to find an available port for the listener in the range {0} .. {1}",
                    _LowListenPort,
                    _HighListenPort));
            }
            AssemblyVersion a = new AssemblyVersion(true);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            // build a signal string, which is $/App Signature/Process ID/Base Priority/MaxConnections/$
            // E.g.
            // $/MyDomain.MyApp.MyService/2380/80/5/$
            // This is used by the BabbleFinder app to build a list of available babble channels, when it is not
            // given a specific port to connect to.
            _appSignature = string.Format(
                "#APP: $/{0}/{1}/{2}/{3}/{4:u}/$\r\n",
                a.Name, p.Id, p.BasePriority, _MaxListeners, StartTime);
        }

        private void DropListener(Guid g)
        {
            if (this.Listeners.ContainsKey(g))
            {
                try
                {
                    DateTime ForceDropTime = DateTime.Now.AddSeconds(2);
                    this.Listeners[g].StopRequested = true;
                    while (this.Listeners[g].TcpClient != null && this.Listeners[g].TcpClient.Connected && this.Listeners[g].Running && DateTime.Now < ForceDropTime)
                    {
                        Thread.Sleep(20);
                    }
                    // We assume that all TCP connections and Client Streams are flushed, closed, etc, by the members own code.
                    if (this.Listeners[g].Worker.ThreadState == ThreadState.Running || this.Listeners[g].Worker.ThreadState == ThreadState.Suspended)
                    {
                        this.Listeners[g].Worker.Abort();
                    }
                    //this.Listeners[g].Worker = null;
                    this.Listeners[g].Messages.Clear();
                    this.Listeners[g].ClientStream.Flush();
                    this.Listeners[g].ClientStream.Close();
                    this.Listeners[g].ClientStream.Dispose();
                    this.Listeners[g].TcpClient.Close();
                    //this.Listeners[g].TcpClient = null;
                    this.Listeners.Remove(g);
                }
                catch
                {
                }
            }
        }

        private void ListenForClients()
        {
            this.MyTcpListener.Start();
            Listening = true;
            Guid key = Guid.NewGuid();
            bool NeedCleanup = false;

            while (Running)
            {
                if (this.MyTcpListener.Pending())
                {
                    EavesDropper NewGuy = new EavesDropper();
                    NewGuy.StartedOn = DateTime.Now;
                    NewGuy.TimeoutOn = _TimeoutSeconds <= 0 ? DateTime.MaxValue : NewGuy.StartedOn.AddSeconds(_TimeoutSeconds);
                    NewGuy.TcpClient = this.MyTcpListener.AcceptTcpClient();
                    // create a thread to handle communication with connected client.
                    NewGuy.Worker = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    NewGuy.Running = true;
                    Guid g = Guid.NewGuid();
                    Listeners.Add(g, NewGuy);
                    this.Listeners[g].Worker.Start(g);
                    continue;
                }
                NeedCleanup = false;
                foreach (Guid g in this.Listeners.Keys)
                {
                    if (this.Listeners[g].Running == false)
                    {
                        NeedCleanup = true;
                        key = g;
                        break;
                    }
                    if (this.Listeners[g].TimeoutOn <= DateTime.Now && this.Listeners[g].StopRequested == false)
                    {
                        this.Listeners[g].Messages.Enqueue(string.Format("# Time limit of {0} seconds has been reached, disconnecting **", _TimeoutSeconds));
                        this.Listeners[g].StopRequested = true;
                        break;
                    }
                }
                if (NeedCleanup)
                {
                    DropListener(key);
                    continue;
                }
                Thread.Sleep(250);
            }
            this.MyTcpListener.Stop();
            this.MyTcpListener = null;
            Listening = false;
        }

        private void HandleClientComm(object client)
        {
            Guid myListener = (Guid)client;
            this.Listeners[myListener].ClientStream = this.Listeners[myListener].TcpClient.GetStream();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            // send the signal string as the first line, in case the caller is BabbleFinder building a list of available
            // connections.
            this.Listeners[myListener].Messages.Enqueue(_appSignature);
            if (this.Listeners.Count > _MaxListeners)
            {
                this.Listeners[myListener].Messages.Enqueue("** Sorry, maximum number of listeners has been reached. Try later. **\r\n");
                this.Listeners[myListener].StopRequested = true;
            }
            else
            {
                // now send a list of current connections, which are not the current connection.  Again, BabbleFinder will use
                // it to build a list of clients connected.
                foreach (Guid g in this.Listeners.Keys)
                {
                    if (this.Listeners[g].TcpClient != null && this.Listeners[g].TcpClient.Connected)
                    {
                        this.Listeners[myListener].Messages.Enqueue(
                            string.Format("#LISTENER: {0},ConnectTime={1:u},KeepAliveRequest={2},Timeout={3:u},{4}\r\n",
                            this.Listeners[g].TcpClient.Client.RemoteEndPoint.ToString(),
                            this.Listeners[g].StartedOn,
                            this.Listeners[g].KeepAliveRequests,
                            this.Listeners[g].TimeoutOn,
                            g != myListener ? "(remote)" : "(me)"
                            ));
                    }
                }
                this.Listeners[myListener].Messages.Enqueue(string.Format("# Activity follows\r\n", this.Listeners[myListener].TcpClient.Client.RemoteEndPoint.ToString()));
            }
            while (this.Listeners.ContainsKey(myListener) && this.Listeners[myListener].TcpClient.Connected && this.Listeners[myListener].Running)
            {
                while (this.Listeners[myListener].TcpClient.Connected && this.Listeners[myListener].Messages.Count > 0)
                {
                    try
                    {
                        Byte[] bytes = encoding.GetBytes(this.Listeners[myListener].Messages.Dequeue());
                        this.Listeners[myListener].ClientStream.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                    }
                }
                if (this.Listeners[myListener].TcpClient.Connected && this.Listeners[myListener].ClientStream.DataAvailable == true)
                {
                    // A keypress of X will break the connection.
                    // Any other keypress will extend the timeout period.
                    int keyPressed = this.Listeners[myListener].ClientStream.ReadByte();
                    if (keyPressed == 0x58 || keyPressed == 0x78)
                    {
                        string ConnectionEntry = string.Format("# Disconnecting (operator keypress)\r\n", this.Listeners[myListener].TcpClient.Client.RemoteEndPoint.ToString());
                        Byte[] bytes = encoding.GetBytes(ConnectionEntry);
                        this.Listeners[myListener].ClientStream.Write(bytes, 0, bytes.Length);
                        break;
                    }
                    else // reset the timeout period.
                    {
                        this.Listeners[myListener].TimeoutOn = _TimeoutSeconds <= 0 ? DateTime.MaxValue : DateTime.Now.AddSeconds(_TimeoutSeconds);
                        this.Listeners[myListener].Messages.Enqueue("# Keep alive\r\n");
                        this.Listeners[myListener].KeepAliveRequests++;
                    }
                }
                if (this.Listeners[myListener].StopRequested)
                {
                    break;
                }
                Thread.Sleep(250);
            }
            if (this.Listeners.ContainsKey(myListener)) this.Listeners[myListener].TcpClient.Close();
            DropListener(myListener);
        }

        public void Write(string message)
        {
            if (this.Listeners.Count == 0) return;

            List<Guid> DeadConnections = new List<Guid>();
            foreach (Guid g in Listeners.Keys)
            {
                if (this.Listeners[g].TcpClient.Connected)
                {
                    this.Listeners[g].Messages.Enqueue(message);
                }
                else // connection is no longer listed as active.
                {
                    DeadConnections.Add(g);
                    break;
                }
            }
            foreach (Guid g in DeadConnections)
            {
                DropListener(g);
            }
        }

        public void WriteLine(string message)
        {
            Write(message + "\r\n");
        }
    }

    public class ScannedPort
    {
        public int Port = 0;
        public bool Error = false;
        public bool Found = false;
        public string AppSignature = "*none*";
        public int PID = 0;
        public int BasePriority = 0;
        public int MaxConnections = 0;
        public int ActiveConnections = 0;
        public DateTime StartTime = DateTime.MinValue;
    }

    public class BabbleFinder
    {
        private static string _Host = "localhost";
        private int _LowListenPort = 65200;
        private int _HighListenPort = 65299;

        private static Dictionary<int, ScannedPort> _Answers = new Dictionary<int, ScannedPort>();

        public BabbleFinder()
        {
        }

        public BabbleFinder(string host)
        {
            _Host = host;
        }

        public BabbleFinder(int lowPort, int highPort)
        {
            _LowListenPort = lowPort;
            _HighListenPort = highPort;
        }

        public BabbleFinder(string host, int lowPort, int highPort)
        {
            _Host = host;
            _LowListenPort = lowPort;
            _HighListenPort = highPort;
        }

        /// <summary>
        /// Scan the ports for listeners and return details.
        /// </summary>
        /// <returns></returns>
        public List<ScannedPort> ScanPorts(bool includeNotFound)
        {
            List<ScannedPort> result = new List<ScannedPort>();
            _Answers.Clear();
            Dictionary<int, Thread> workers = new Dictionary<int, Thread>();
            for (int portNumber = _LowListenPort; portNumber <= _HighListenPort; portNumber++)
            {
                workers.Add(portNumber, new Thread(PollPort));
                workers[portNumber].Start(portNumber);
            }
            while (workers.Count > _Answers.Count) Thread.Sleep(100);
            for (int portNumber = _LowListenPort; portNumber <= _HighListenPort; portNumber++)
            {
                workers[portNumber] = null;
                workers.Remove(portNumber);
            }
            for (int portNumber = _LowListenPort; portNumber <= _HighListenPort; portNumber++)
            {
                if (includeNotFound || _Answers[portNumber].Found) result.Add(_Answers[portNumber]);
            }
            return result;
        }

        // thread safe
        public static void PollPort(object PortNumberObject)
        {
            int portNumber = (int)PortNumberObject;
            TcpClient c = new TcpClient();
            ScannedPort p = new ScannedPort();

            p.Port = portNumber;
            c.ReceiveTimeout = 5;
            c.NoDelay = true;
            c.Client.ReceiveBufferSize = 2048;
            try
            {
                c.Client.LingerState = new LingerOption(false, 2);
                c.Connect(_Host, portNumber);
                DateTime Timeout = DateTime.Now.AddSeconds(4);
                while (DateTime.Now <= Timeout && c.Client.Connected == false) ;  // wait for connection or timeout.
                if (c.Client.Connected)
                {
                    bool HaveFrame = false;
                    StringBuilder lines = new StringBuilder();
                    byte[] RecvBuffer = new byte[2048];
                    while (lines.Length < 500)
                    {
                        Timeout = DateTime.Now.AddSeconds(2);
                        while (c.Client.Available == 0 && DateTime.Now <= Timeout) ;
                        if (c.Client.Available == 0) break;  // no recv data in 2 seconds?  Give up.
                        int ByteCount = c.Client.Receive(RecvBuffer);
                        int ByteIndex = 0;
                        for (ByteIndex = 0; ByteIndex < ByteCount; ByteIndex++)
                        {
                            lines.Append((char)RecvBuffer[ByteIndex]);
                        }
                        if (lines.ToString().IndexOf("# Activity follows") >= 0 && lines.ToString().IndexOf("\r\n") > 0)
                        {
                            HaveFrame = true;
                            break;
                        }
                    }
                    if (HaveFrame)
                    {
                        string[] LineSet = lines.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        int ClientCount = 0;
                        foreach (string s in LineSet)
                        {
                            if (s.IndexOf("#APP: $") == 0)
                            {
                                string[] AppSig = LineSet[0].Split(new string[] { "/" }, StringSplitOptions.None);
                                //  APP: $/com.mydomain.mywebservice/2380/80/5/{starttime}$
                                if (AppSig.Length == 7 && AppSig[0] == "#APP: $" && AppSig[6] == "$")
                                {
                                    p.AppSignature = AppSig[1];
                                    p.PID = int.Parse(AppSig[2]);
                                    p.BasePriority = int.Parse(AppSig[3]);
                                    p.MaxConnections = int.Parse(AppSig[4]);
                                    p.StartTime = DateTime.Parse(AppSig[5]);
                                    p.Found = true;
                                }
                            }
                            else if (s.IndexOf("#LISTENER: ") == 0)
                            {
                                ClientCount++;
                            }
                        }
                        p.ActiveConnections = ClientCount - 1;  // don't count the finder in the total.
                    }
                }
            }
            catch
            {
                p.Error = true;
            }
            finally
            {
                try
                {
                    c.Close();
                    c = null;
                }
                catch { }
            }
            lock (_Answers)
            {
                _Answers.Add(portNumber, p);
            }
        }
    }
}
