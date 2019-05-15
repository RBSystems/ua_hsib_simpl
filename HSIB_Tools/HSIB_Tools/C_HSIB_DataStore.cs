using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
using CDS = Crestron.SimplSharp.CrestronDataStore.CrestronDataStore;
using CDSS = Crestron.SimplSharp.CrestronDataStore.CrestronDataStoreStatic;

namespace HSIB_Tools
{
    public class C_HSIB_DataStore
    {
        public delegate void CDSStringUpdateHandler(SimplSharpString _tag, SimplSharpString _value);
        public CDSStringUpdateHandler OnStringUpdateEvent { get; set; }
        
        public C_HSIB_DataStore()
        {
            //onStringUpdateEvent = new CDSStringUpdateHandler();
        }
        
        public void OnStringUpdate(string _tag, string _value)
        {
            //C_MyStringEventArgs stuff = new C_MyStringEventArgs(_tag, _value);
            OnStringUpdateEvent(_tag, _value);
        }

        public void SetStringData(string _tag, string _value)
        {
            CDSS.SetLocalStringValue(_tag, _value);
        }
        public CDS.CDS_ERROR GetStringData(string _tag)
        {  
            string value;
            CrestronConsole.PrintLine("CDS - fetching string  {0}:  {1}", _tag);
            return(CDSS.GetLocalStringValue(_tag, out value));
        }
    }
}
