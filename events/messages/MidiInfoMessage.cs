﻿using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public class MidiInfoMessage : IMessage
    {
    }

    public class MidiPlayerUpdatedMessage : MidiInfoMessage
    {
        public MidiFilePlayer player
        {
            get; set;
        }
    }
   
}