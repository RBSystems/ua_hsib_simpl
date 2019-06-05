using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace L3_HSIB_Front_Pro3
{
    public class Global_Data
    {
        public Dictionary<MTRX_ListType, gMTRXList> gMTRX;
        public Dictionary<ushort, gRoom> gRooms;
        public Dictionary<ushort, ushort> gCams;
        public Dictionary<ushort, ushort> gDisplays;
        public ControlSystem CS;

        public Global_Data(ControlSystem _controlSystem)
        {
            CS = _controlSystem;
            gMTRX = new Dictionary<MTRX_ListType, gMTRXList>();
            gRooms = new Dictionary<ushort, gRoom>();
            gCams = new Dictionary<ushort,ushort>();
            gDisplays = new Dictionary<ushort, ushort>();
        }

        public void InitData(string _filename, string _filedata)
        {
            string filename = _filename;
            string[] filedata = _filedata.Split("\n".ToCharArray());

            Dictionary<string, string> kvpairs = new Dictionary<string, string>();

            foreach (var line in filedata)
            {
                if (line.Contains("//")) continue;
                line.Trim();
                if (line.Length > 0)
                {
                    kvpairs = GetKVPairs(line.Split(",".ToCharArray()));
                    if (kvpairs.Count() > 0)
                    {
                        if (filename.Contains("Rooms")) ParseData_Rooms.Parse(kvpairs, this);
                        else if (filename.Contains("MTRX")) ParseData_MTRX.Parse(kvpairs, this);
                        //else if (filename.Contains("DSP_POINTS")) ParseData_DSP.Parse(kvpairs, this);
                        //else if (filename.Contains("FILTER")) ParseData_Filters.Parse(kvpairs, this);
                        //else if (filename.Contains("Macro")) ParseData_Macros.Parse(filename, kvpairs, this);
                    }
                }
            }
        }

        public Dictionary<string, string> GetKVPairs(string[] data)
        {
            Dictionary<string, string> tempdict = new Dictionary<string, string>();
            string[] kv = new string[2];
            foreach (var item in data)
            {
                if (item.Contains("="))
                {
                    kv = item.Split("=".ToCharArray());
                    tempdict[kv[0].Trim()] = kv[1].Trim(); 
                }
            }
            return (tempdict);
        }

        public ushort TryParse(string _temp)
        {
            ushort n = 0;
            try { n = ushort.Parse(_temp); }
            catch { CrestronConsole.PrintLine("ERR.Global_Data.TryParse: Didn't parse to ushort. '{0}'", _temp); }
            return (n);
        }
    }

    public static class ParseData_Rooms
    {
        public static Dictionary<string, string> data;
        public static Global_Data caller;
        public static ushort guid;
        public static string name;
        public static ushort rm_num = 0;
        public static bool macro_mode = false;
        public static ushort rc_guid;

        public static void Parse(Dictionary<string, string> _data, Global_Data _caller)
        {
            data = _data;
            caller = _caller;

            foreach (var kv in data)
            {
                if (kv.Key.Contains("room_guid")) guid = caller.TryParse(kv.Value);
                else if (kv.Key.Contains("room_name")) name = kv.Value.Trim();
                else if (kv.Key.Contains("bldg_rm_num")) rm_num = caller.TryParse(kv.Value);
                else if (kv.Key.Contains("discrete")) macro_mode = Convert.ToBoolean(caller.TryParse(kv.Value));
                else if (kv.Key.Contains("rc_guid")) rc_guid = caller.TryParse(kv.Value);
            }
            if (guid > 0)
            {
                caller.gRooms[guid] = new gRoom();
                if (name.Length > 0) caller.gRooms[guid].RoomName = name;
                if (rm_num > 0) caller.gRooms[guid].BldgRoomNum = rm_num;
                if (macro_mode) caller.gRooms[guid].RouteType = Room_RouteType.SrcToMacro1Press;
                else caller.gRooms[guid].RouteType = Room_RouteType.SrcToMacro2PressAuto;
                if (rc_guid > 0)
                {
                    caller.gRooms[guid].IsRCRoom = true;
                    caller.gRooms[guid].RCPairedRoomIndex = rc_guid;
                }
                CrestronConsole.PrintLine("IsRCRoom={0}, RCPairedRoomIndex={1}", caller.gRooms[guid].IsRCRoom, caller.gRooms[guid].RCPairedRoomIndex);
            }
        }
    }
    public static class ParseData_MTRX
    {
        public static Dictionary<string, string> data;
        public static Global_Data caller;
        public static ushort guid;
        

        public static void Parse(Dictionary<string, string> _data, Global_Data _caller)
        {
            data = _data;
            caller = _caller;

            foreach (var kv in data)
            {
                if (kv.Key.Contains("room_guid")) guid = caller.TryParse(kv.Value);
                else if (kv.Key.Contains("room_name")) name = kv.Value.Trim();
                else if (kv.Key.Contains("bldg_rm_num")) rm_num = caller.TryParse(kv.Value);
                else if (kv.Key.Contains("discrete")) macro_mode = Convert.ToBoolean(caller.TryParse(kv.Value));
                else if (kv.Key.Contains("rc_guid")) rc_guid = caller.TryParse(kv.Value);
            }
            if (!(guid == null) && guid > 0)
            {

            }
        }
    }

    public class gMTRXList
    {
        public ushort NumOfItems;
        public Dictionary<ushort, gMTRXItem> List;
    }
    public class gRoom
    {
        public bool ItemActive;

        public gListItem ListItem;

        public bool IsRCRoom;
        public ushort RCPairedRoomIndex;
        
        public string RoomName = "";
        public string RoomNameShort;
        public ushort BldgRoomNum;  //e.g. 567

        public Room_RouteType RouteType;
        //public bool UseAdminSrcList;    //if True, use the adminVSrc list for the source 2 or 3 press routing
        //Instead of this, always allow adminVSrc list to propagate to the main list? Does this interfere with classroom logic?

        public ushort VTCAssignment;
        public lCamsList Cams;
        public lDisplaysList Displays;

        public Dictionary<MTRX_ListType, lRoomList> MTRX;
    }
    public class lCamsList
    {
        public Dictionary<ushort, ushort> CamsList;
    }
    public class lDisplaysList
    {
        public Dictionary<ushort, ushort> DisplaysList;
    }
    public class lRoomList
    {
        public Dictionary<ushort, ushort> MTRX;
    }
    public class gListItem
    {
        public bool ListFB;
        public bool ListVis;
        public Dictionary<string, string> ListText;
    }
    public class gMTRXItem
    {
        public bool ItemActive;

        public gListItem ListItem;
        
        public string gloName;
        public string locName;

        public ushort[] gloToListIndex;
        public ushort[] listToGlobalIndex;

        public ushort SysPreset;

        public ushort RoomAss;
        public ushort RoomListIndex;
        public ushort FunctionID;
        public ushort FilterID;
        public ushort GroupID;

        public bool IsVirtual;
        public ushort VirtualID;
        public ushort VirtualLink;

        public gDevice Dev;

        public ushort gloRoutedSrc;
        public ushort locRoutedSrc;

        public ushort LastRouteReq;
    }
    public class gDevice
    {
        public HSIB_DevType DevType;
        public HSIB_DPLYType DPLYType;

        public ushort gloDevIndex;
        public ushort rmDevIndex;

        public string IPAddress;
        public ushort ComPort;
        public ushort ProcIndex;

        public ushort SubIONum;

        public ushort iCmdData;
        public string sCmdData;

        public bool IsUSB;
        public string USBAddr;

        public gRelay[] RlyOn;
        public gRelay[] RlyOff;
    }
    public class gRelay
    {
        public ushort RlyIndex;
        public string IPAddress;
        public bool IsInitIndex;
        public ushort RlyProcIndex;
    }

    public enum HSIB_DevType { Camera, Display, VTC }
    public enum HSIB_DPLYType { sony_lcd, sony_proj, barco_proj, christie_proj, lg_lcd }
    public enum MTRX_ListType { VSRC, VDST, ASRC, ADST }
    public enum Room_RouteType { SrcToMacro1Press, SrcToMacro2PressAuto, SrcToMacro2PressWithTake }

}