using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using CDS = Crestron.SimplSharp.CrestronDataStore.CrestronDataStore;
using CDSS = Crestron.SimplSharp.CrestronDataStore.CrestronDataStoreStatic;

namespace HSIB_Tools
{
    public class CDSGetStringArgs
    {
        CDS.CDS_ERROR cdsErr;
        SimplSharpString data = new SimplSharpString();

        public CDSGetStringArgs(CDS.CDS_ERROR _err, string _data)
        {
            cdsErr = _err;
            data.AppendToString(_data);
        }
    }
}