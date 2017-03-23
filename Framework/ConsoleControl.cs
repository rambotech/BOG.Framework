using System;
using System.Runtime.InteropServices;

namespace BOG.Framework
{
	/// <summary>
	/// A handler for keyboard control sequences, used in console applications. Usage:
	/// 
	///       bool ExitRequested = false;
	///       ...
	///       static void ExitHandler(ConsoleCtrl.ConsoleEvent ConsoleEvent)
	///       {
	///           if (ConsoleEvent == ConsoleCtrl.ConsoleEvent.CTRL_BREAK)
	///           {
	///               System.Environment.Exit(0);
	///           }
	///           ExitRequested = true;
	///           Console.WriteLine("Exit requested: waiting for this item to complete");
	///       }
	///       static void main(string[] args)
	///       {
	///           ConsoleCtrl oExitHandler = new ConsoleCtrl();
	///           oExitHandler.ControlEvent += new ConsoleCtrl.ControlEventHandler(ExitHandler);
	///           ...
	///           while (! ExitRequested)
	///           {
	///             // continue work
	///           }
	///           ...
	///       }
	/// </summary>
	public class ConsoleCtrl
	{
		/// <summary>
		/// The type of console keyboard events which can be trapped.
		/// </summary>
		public enum ConsoleEvent
		{
			/// <summary>
			/// From wincom.h
			/// </summary>
			CTRL_C = 0,
			/// <summary>
			/// From wincom.h
			/// </summary>
			CTRL_BREAK = 1,
			/// <summary>
			/// From wincom.h
			/// </summary>
			CTRL_CLOSE = 2,
			/// <summary>
			/// From wincom.h
			/// </summary>
			CTRL_LOGOFF = 5,
			/// <summary>
			/// From wincom.h
			/// </summary>
			CTRL_SHUTDOWN = 6
		}

		/// <summary>
		/// The handler method for the ConsoleEvent.
		/// </summary>
		/// <param name="consoleEvent"></param>
		public delegate void ControlEventHandler(ConsoleEvent consoleEvent);

		/// <summary>
		/// The event definition.
		/// </summary>
		public event ControlEventHandler ControlEvent;

		ControlEventHandler eventHandler;

		/// <summary>
		/// Intstantiate the class.
		/// </summary>
		public ConsoleCtrl()
		{
			// save this to a private var so the GC doesn't collect it...
			eventHandler = new ControlEventHandler(Handler);
			SetConsoleCtrlHandler(eventHandler, true);
		}

		/// <summary>
		/// Transfer to the delegate, if one is established.
		/// </summary>
		/// <param name="consoleEvent"></param>
		private void Handler(ConsoleEvent consoleEvent)
		{
			if (ControlEvent != null)
				ControlEvent(consoleEvent);
		}

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetConsoleCtrlHandler(ControlEventHandler e, [MarshalAs(UnmanagedType.Bool)] bool add);
	}
}