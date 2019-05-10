using System;
using System.Collections.Generic;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronDataStore;

namespace HSIB_Tools
{
    public class C_HSIB_DataStore
    {
        public delegate void CDSStringUpdateHandler(object o, string _tag, string _value);
        public CDSStringUpdateHandler OnStringUpdateEvent;
        
        public C_HSIB_DataStore()
        {
            //onStringUpdateEvent = new CDSStringUpdateHandler();
        }
        
        public void OnStringUpdate(string _tag, string _value)
        {
            //C_MyStringEventArgs stuff = new C_MyStringEventArgs(_tag, _value);
            OnStringUpdateEvent.Invoke(this, _tag, _value);
        }

        public void setStringData(string _tag, string _value)
        {
            /*
            string value;
            if (CrestronDataStoreStatic.GetLocalStringValue(_tag, out value) == CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {

            }
            CrestronConsole.PrintLine("CDS - storing to string  {0}:  {1}", _tag, _value);
            CrestronDataStoreStatic.SetLocalStringValue(_tag, _value);
            */
        }
        public void getStringData(string _tag)
        {
            /*
            string value;
            CrestronConsole.PrintLine("CDS - fetching string  {0}:  {1}", _tag);
            CrestronDataStoreStatic.GetLocalStringValue(_tag, out value);

            */
        }

    }
}
