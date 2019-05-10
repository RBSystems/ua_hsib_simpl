using System;
using System.Collections.Generic;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronDataStore;

namespace HSIB_Tools
{
    public class C_MyStringEventArgs : EventArgs
    {
        public SimplSharpString tag;
        public SimplSharpString value;
        public ushort iInt = new ushort();

        public C_MyStringEventArgs(string _s1, string _s2)
        {
            tag = _s1;
            value = _s2;
            iInt = 5;
        }
    }
}