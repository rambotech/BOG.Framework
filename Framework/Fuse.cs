using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace BOG.Framework
{
    /// <summary>
    /// An event passed to a fuse object, to represent a volume passing through a fuse at a specific point in time.
    /// </summary>
    [Serializable]
    public class FuseEvent : ISerializable
    {
        private DateTime _Occurred_On = DateTime.MinValue;
        private float _Volume = 0.0F;

        /// <summary>
        /// Create the event with default property values.  Needed for serialization.
        /// </summary>
        public FuseEvent()
        {

        }

        /// <summary>
        /// Create the event with a specific time and volume.
        /// </summary>
        /// <param name="p_Occurred_On">The time of the fuse pass-thru.</param>
        /// <param name="p_Volume">The volume which passed through the fuse.</param>
        public FuseEvent(DateTime p_Occurred_On, float p_Volume)
        {
            this._Occurred_On = p_Occurred_On;
            this._Volume = p_Volume;
        }

        /// <summary>
        /// Create a new fuse event from an existing one.
        /// </summary>
        /// <param name="p_obj">The existing event</param>
        public FuseEvent(FuseEvent p_obj)
        {
            Load(p_obj);
        }

        /// <summary>
        /// Create a new fuse event from an object array of DateTime, float
        /// </summary>
        /// <param name="p_obj">the time and volume property values.</param>
        public FuseEvent(object[] p_obj)
        {
            this._Occurred_On = (DateTime)p_obj[0];
            this._Volume = (float)p_obj[1];
        }

        /// <summary>
        /// Load the event from an existing one.  Allows an existing FuseEvent class to be recycled.
        /// </summary>
        /// <param name="p_obj"></param>
        public void Load(FuseEvent p_obj)
        {
            this._Occurred_On = p_obj.Occurred_On;
            this._Volume = p_obj.Volume;
        }

        /// <summary>
        /// Returns the time the fuse pass-thru occurred.
        /// </summary>
        public DateTime Occurred_On
        {
            get { return _Occurred_On; }
            set { _Occurred_On = value; }
        }

        /// <summary>
        /// Returns the volume of the event.
        /// </summary>
        public float Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Occurred_On", _Occurred_On);
            info.AddValue("Volume", _Volume);
        }
    }

    /// <summary>
    /// A class modeling a real world fuse.  It records events (specific points in time, or "hits") and the volume
    /// associated with that time.  The fuse can be set to trigger when a specific total volume over a timeframe has been exceeded,
    /// a specific number of hits has been exceeded over the timeframe, either hits of volume is exceeded or both.
    /// The fuse is a measure only.  It is used to determine if thresholds are being exceeding requirement the caller to
    /// make adjustments to behavior and/or trigger alerts.
    /// </summary>
    [Serializable]
    public class Fuse : ISerializable
    {
        /// <summary>
        /// What thresholds being exceeded will cause the fuse to trip.
        /// </summary>
        public enum FuseBehavior : byte
        {
            Hits_Only = 0,
            Volume_Only = 1,
            Hits_OR_Volume = 2,
            Hits_AND_Volume = 3
        }

        /// <summary>
        /// After a fuse event is recorded, describes what thresholds were triggered.
        /// </summary>
        public enum FuseTrip : byte
        {
            None = 0,
            Hits = 1,
            Volume = 2,
            HitsAndVolume = 3
        }

        // properties
        private FuseBehavior _Fuse_Trigger_Rule = FuseBehavior.Hits_Only;
        private int _Hit_Threshold = 100;
        private float _Volume_Threshold = 100;
        private TimeSpan _Time_Frame = TimeSpan.Parse("0.00:01:00.000");
        private bool _Auto_Reset_On_Trigger = false;

        // internal
        private int _Hits = 0;
        private float _Volume = 0.0F;
        private Queue<FuseEvent> _Triggers = new Queue<FuseEvent>();

        /// <summary>
        /// Instantiate with defaults.
        /// </summary>
        public Fuse()
        {
        }

        /// <summary>
        /// Instantiate with specific values.
        /// </summary>
        /// <param name="p_Fuse_Trigger_Rule">The FuseBehavior value</param>
        /// <param name="p_Hit_Threshold">Hit threshold: the number of hits within the time frame</param>
        /// <param name="p_Volume_Threshold">Volume threshold: the sum of the volume received in the timeframe</param>
        /// <param name="p_Time_Frame">A TimeSpan from the present time to the past representing the time frame.</param>
        /// <param name="p_Auto_Reset_On_Trigger">Whether the fuse should zero the hits and volume when the fuse triggers.</param>
        public Fuse(FuseBehavior p_Fuse_Trigger_Rule, int p_Hit_Threshold, float p_Volume_Threshold, TimeSpan p_Time_Frame, bool p_Auto_Reset_On_Trigger)
        {
            this._Fuse_Trigger_Rule = p_Fuse_Trigger_Rule;
            this._Hit_Threshold = p_Hit_Threshold;
            this._Volume_Threshold = p_Volume_Threshold;
            this._Time_Frame = p_Time_Frame;
            this._Auto_Reset_On_Trigger = p_Auto_Reset_On_Trigger;
        }

        /// <summary>
        /// Instantiate an new Fuse object from an existing one.
        /// </summary>
        /// <param name="p_obj">The existing Fuse object.</param>
        /// <param name="Copy_State">when true, the existing hits and volume of the fuse's state are copied.</param>
        public Fuse(Fuse p_obj, bool Copy_State)
        {
            Load(p_obj, Copy_State);
        }

        /// <summary>
        /// Instantiate an new Fuse object from an array of properties.
        /// Does NOT copy the hits and volume values from activity.
        /// </summary>
        /// <param name="p_obj">The array containing the properties.</param>
        public Fuse(object[] p_obj)
        {
            this._Fuse_Trigger_Rule = (FuseBehavior)p_obj[0];
            this._Hit_Threshold = (int)p_obj[1];
            this._Volume_Threshold = (float)p_obj[2];
            this._Time_Frame = (TimeSpan)p_obj[3];
            this._Auto_Reset_On_Trigger = (bool)p_obj[4];
        }

        /// <summary>
        /// Instantiate an new Fuse object from an array of properties.
        /// Can copy the hits and volume values from activity.
        /// </summary>
        /// <param name="p_obj">The array containing the properties.</param>
        /// <param name="Copy_State">when true, the existing hits and volume of the fuse's state are copied.</param>
        public Fuse(object[] p_obj, bool Copy_State)
        {
            this._Fuse_Trigger_Rule = (FuseBehavior)p_obj[0];
            this._Hit_Threshold = (int)p_obj[1];
            this._Volume_Threshold = (float)p_obj[2];
            this._Time_Frame = (TimeSpan)p_obj[3];
            this._Auto_Reset_On_Trigger = (bool)p_obj[4];
            if (Copy_State)
            {
                this._Hits = (int)p_obj[5];
                this._Volume = (float)p_obj[6];
                this._Triggers = (Queue<FuseEvent>)p_obj[7];
            }
        }

        /// <summary>
        /// Load the event from an existing one.  Allows an existing Fuse class to be recycled.
        /// </summary>
        /// <param name="p_obj">The existing Fuse object for the source.</param>
        public void Load(Fuse p_obj)
        {
            Load(p_obj, false);
        }

        /// <summary>
        /// Load the event from an existing one.  Allows an existing Fuse class to be recycled.
        /// </summary>
        /// <param name="p_obj">The existing Fuse object for the source.</param>
        /// <param name="Copy_State">when true, the existing hits and volume of the fuse's state are copied.</param>
        public void Load(Fuse p_obj, bool Copy_State)
        {
            this._Fuse_Trigger_Rule = p_obj.Fuse_Trigger_Rule;
            this._Hit_Threshold = p_obj.Hit_Threshold;
            this._Volume_Threshold = p_obj.Volume_Threshold;
            this._Time_Frame = p_obj.Time_Frame;
            this._Auto_Reset_On_Trigger = p_obj.Auto_Reset_On_Trigger;
            if (Copy_State)
            {
                this._Hits = p_obj.Hits;
                this._Volume = p_obj.Volume;
                this.Triggers = p_obj.Triggers;
            }
        }

        /// <summary>
        /// Returns the behavior defined for the fuse.
        /// </summary>
        public FuseBehavior Fuse_Trigger_Rule
        {
            get { return _Fuse_Trigger_Rule; }
            set { _Fuse_Trigger_Rule = value; }
        }

        /// <summary>
        /// Returns the number of hits required in the timeframe to "trip" the fuse.
        /// </summary>
        public int Hit_Threshold
        {
            get { return _Hit_Threshold; }
            set { _Hit_Threshold = value; }
        }

        /// <summary>
        /// Returns the sum of volume in the timeframe to "trip" the fuse.
        /// </summary>
        public float Volume_Threshold
        {
            get { return _Volume_Threshold; }
            set { _Volume_Threshold = value; }
        }

        /// <summary>
        /// Specifies the timeframe to evaluate hits and volume for thresholds.
        /// Timeframe is always a point in the past to the present time.
        /// </summary>
        public TimeSpan Time_Frame
        {
            get { return _Time_Frame; }
            set { _Time_Frame = value; }
        }

        /// <summary>
        /// Returns the auto-reset: when true, hits and volume are cleared when the fuse is
        /// tripped.
        /// </summary>
        public bool Auto_Reset_On_Trigger
        {
            get { return _Auto_Reset_On_Trigger; }
            set { _Auto_Reset_On_Trigger = value; }
        }

        /// <summary>
        /// The number of hits occurring in the timeframe.
        /// </summary>
        public int Hits
        {
            get { return _Hits; }
        }

        /// <summary>
        /// Returns the percentage of the hits threshold consumed within the timeframe.
        /// </summary>
        public float HitPercentage
        {
            get { return (float)_Hits / (float)_Hit_Threshold; }
        }

        /// <summary>
        /// The amount of volume occurring in the timeframe.
        /// </summary>
        public float Volume
        {
            get { return _Volume; }
        }

        /// <summary>
        /// Returns the percentage of the volume threshold consumed within the timeframe.
        /// </summary>
        public float VolumePercentage
        {
            get { return _Volume / _Volume_Threshold; }
        }

        /// <summary>
        /// The fuse events recorded for the timeframe.  Normally only used when 
        /// cloning the fuse object.  This code translates the queue object to and from a
        /// SerializableDictionary to facilitate XML serialization.
        /// </summary>
        public List<FuseEvent> Triggers
        {
            get
            {
                List<FuseEvent> result = new List<FuseEvent>();
                lock (_Triggers)
                {
                    // dequeue items to keep the order in the resulting dictionary.
                    while (_Triggers.Count > 0)
                    {
                        result.Add(new FuseEvent(_Triggers.Dequeue()));
                    }
                    int count = result.Count;
                    // restore the value back to the queue, in order.
                    for (int index = 0; index < count; index++)
                    {
                        _Triggers.Enqueue(result[index]);
                    }
                }
                return result;
            }

            set
            {
                lock (_Triggers)
                {
                    _Triggers.Clear();
                    for (int index = 0; index < value.Count; index++)
                    {
                        _Triggers.Enqueue(value[index]);
                    }
                }
            }
        }

        /// <summary>
        /// Enables the client to reset the fuse
        /// </summary>
        public void Reset()
        {
            _Hits = 0;
            _Volume = 0.0F;
            _Triggers.Clear();
        }

        /// <summary>
        /// Records a fuse activity.
        /// </summary>
        /// <param name="volume">(float) the amount of volume (activity) to record.</param>
        /// <returns>Enumeration describing what tripped the fuse: nothing, or any combination of hits and volume</returns>
        public FuseTrip RecordFuseEvent(float volume)
        {
            return RecordFuseEvent(volume, DateTime.Now);
        }

        /// <summary>
        /// Records a fuse activity.
        /// </summary>
        /// <param name="timestamp">The time associated with the volume passing through the fuse.</param>
        /// <param name="volume">(float) the amount of volume (activity) to record.</param>
        /// <returns>Enumeration describing what tripped the fuse: nothing, or any combination of hits and volume</returns>
        public FuseTrip RecordFuseEvent(float volume, DateTime timestamp)
        {
            FuseTrip result = FuseTrip.None;
            DateTime now = timestamp;   // fixes a point in time over several evals
            DateTime oldestTrigger = now.Add(-_Time_Frame);
            // remove and clear any activity outside the timeframe we analyse.
            while (_Triggers.Count > 0 && _Triggers.Peek().Occurred_On < oldestTrigger)
            {
                FuseEvent f = _Triggers.Dequeue();
                _Hits--;
                _Volume -= f.Volume;
            }
            _Triggers.Enqueue(new FuseEvent(now, volume));
            _Hits++;
            _Volume += volume;
            switch (_Fuse_Trigger_Rule)
            {
                case FuseBehavior.Hits_Only:
                    result = _Hits > _Hit_Threshold ? FuseTrip.Hits : FuseTrip.None;
                    break;
                case FuseBehavior.Volume_Only:
                    result = _Volume > _Volume_Threshold ? FuseTrip.Volume : FuseTrip.None;
                    break;
                case FuseBehavior.Hits_OR_Volume:
                    result = (_Hits > _Hit_Threshold && _Volume > _Volume_Threshold)
                        ? FuseTrip.HitsAndVolume :
                        (_Hits > Hit_Threshold ? FuseTrip.Hits :
                        (_Volume >= _Volume_Threshold ? FuseTrip.Volume : FuseTrip.None));
                    break;
                case FuseBehavior.Hits_AND_Volume:
                    result = (_Hits > _Hit_Threshold && _Volume > _Volume_Threshold)
                        ? FuseTrip.HitsAndVolume : FuseTrip.None;
                    break;
            }
            if (result != FuseTrip.None && _Auto_Reset_On_Trigger)
            {
                Reset();
            }
            return result;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Fuse_Trigger_Rule", _Fuse_Trigger_Rule);
            info.AddValue("Hit_Threshold", _Hit_Threshold);
            info.AddValue("Volume_Threshold", _Volume_Threshold);
            info.AddValue("Time_Frame", _Time_Frame);
            info.AddValue("Auto_Reset_On_Trigger", _Auto_Reset_On_Trigger);
            info.AddValue("Triggers", Triggers);  // use the accessor, since it is changing the type.
        }
    }
}
