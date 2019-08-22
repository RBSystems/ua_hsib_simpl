using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_L3_UA_HSIB_GLOBALDSP_V1_0_80
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALDSP_V1_0_80 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CTRL_MUTE_IN;
        Crestron.Logos.SplusObjects.BufferInput DATAINIT_RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> FROM_ROOM_RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LIST_ITEMCLICKED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CTRL_VOL_IN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> CTRL_MUTE_OUT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LISTFB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_ROOM_TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIST_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CTRL_VOL_OUT;
        STLIST [] LIST;
        STROOM [] ROOM;
        ushort [] DSP_XREF;
        CrestronString STRASH;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 163;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 163;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 164;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 173;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 173;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 175;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 176;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 177;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 179;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 179;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 180;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 177;
                } 
            
            __context__.SourceCodeLine = 182;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 183;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 183;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 185;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 186;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 187;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 189;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 189;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 190;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 191;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 192;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 187;
                } 
            
            __context__.SourceCodeLine = 195;
            return ( SDATA ) ; 
            
            }
            
        private ushort FHIGHESTLISTINDEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 201;
            LIST [ IINDEX] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( LIST[ IINDEX ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
            __context__.SourceCodeLine = 202;
            return (ushort)( LIST[ IINDEX ].IHIGHESTLISTINDEX) ; 
            
            }
            
        private CrestronString FGETDATAHEADER (  SplusExecutionContext __context__, ushort ITYPE ) 
            { 
            
            __context__.SourceCodeLine = 207;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 209;
                        return ( "DSP_POINTS;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 210;
                        return ( "DSP_PRESET;" ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            return ""; // default return value (none specified in module)
            }
            
        object CTRL_VOL_IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IINDEX = 0;
                ushort IVAL = 0;
                
                
                __context__.SourceCodeLine = 225;
                IINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 226;
                IVAL = (ushort) ( CTRL_VOL_IN[ IINDEX ] .UshortValue ) ; 
                __context__.SourceCodeLine = 228;
                if ( Functions.TestForTrue  ( ( DSP_XREF[ IINDEX ])  ) ) 
                    {
                    __context__.SourceCodeLine = 228;
                    CTRL_VOL_OUT [ DSP_XREF[ IINDEX ]]  .Value = (ushort) ( IVAL ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 229;
                    Trace( "GlobalDSP - CHANGE Ctrl_Vol_In - DSP_XRef[iIndex]==0, iIndex=={0:d}, iVal=={1:d}", (ushort)IINDEX, (ushort)IVAL) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CTRL_MUTE_IN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort IINDEX = 0;
            ushort IVAL = 0;
            
            
            __context__.SourceCodeLine = 235;
            IINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 236;
            IVAL = (ushort) ( CTRL_MUTE_IN[ IINDEX ] .Value ) ; 
            __context__.SourceCodeLine = 238;
            if ( Functions.TestForTrue  ( ( DSP_XREF[ IINDEX ])  ) ) 
                {
                __context__.SourceCodeLine = 238;
                CTRL_MUTE_OUT [ DSP_XREF[ IINDEX ]]  .Value = (ushort) ( IVAL ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 239;
                Trace( "GlobalDSP - CHANGE Ctrl_Mute_In - DSP_XRef[iIndex]==0, iIndex=={0:d}, iVal=={1:d}", (ushort)IINDEX, (ushort)IVAL) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
private void FPROCESSROOMDATA (  SplusExecutionContext __context__, ushort IROOM , CrestronString STEMP ) 
    { 
    ushort I = 0;
    ushort IGUIDSRC = 0;
    ushort IGUIDDST = 0;
    
    CrestronString STEMPDATA;
    CrestronString STEMPHEADER;
    CrestronString STEMP1;
    CrestronString STEMP2;
    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    STEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    
    }
    
object FROM_ROOM_RX__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        CrestronString STEMPDATA;
        STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        
        __context__.SourceCodeLine = 263;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 265;
        STEMPDATA  .UpdateValue ( Functions.Gather ( Functions.Length( FROM_ROOM_RX__DOLLAR__[ IROOM ] ), FROM_ROOM_RX__DOLLAR__ [ IROOM ] )  ) ; 
        __context__.SourceCodeLine = 266;
        FPROCESSROOMDATA (  __context__ , (ushort)( IROOM ), STEMPDATA) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private ushort FPROCESSLIST (  SplusExecutionContext __context__, ushort ILIST ) 
    { 
    ushort I = 0;
    ushort J = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 286;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)30; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 288;
        MakeString ( TO_ROOM_TX__DOLLAR__ [ I] , "{0}COMPLETE|}}", FGETDATAHEADER (  __context__ , (ushort)( ILIST )) ) ; 
        __context__.SourceCodeLine = 289;
        Functions.Delay (  (int) ( 150 ) ) ; 
        __context__.SourceCodeLine = 286;
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
private void FPROCESSPRESET (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    
    
    }
    
private void FPROCESSLINE (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort I = 0;
    ushort IERR = 0;
    
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    CrestronString STEMPPAIR;
    CrestronString STEMPLINE;
    CrestronString STEMPHEADER;
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 151, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 308;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 310;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 312;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 313;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 314;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 316;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 316;
            LIST [ IINDEX] . SGLOBALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 317;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 317;
                LIST [ IINDEX] . SLOCALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 319;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_ass" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 319;
                    LIST [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 320;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_index" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 320;
                        LIST [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 321;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "fixed_id" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 321;
                            LIST [ IINDEX] . IFIXEDID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 322;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "group" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 322;
                                LIST [ IINDEX] . IGROUPID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 323;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "point_type" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 323;
                                    LIST [ IINDEX] . IPOINTTYPE = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 325;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 325;
                                        LIST [ IINDEX] . IFUNCTION = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 327;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "tag_gain" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 327;
                                            LIST [ IINDEX] . SGAINCMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 328;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "tag_mute" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 328;
                                                LIST [ IINDEX] . SMUTECMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 329;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "tag_rte" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 329;
                                                    LIST [ IINDEX] . SRTECMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 331;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "dsp_system" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 331;
                                                        LIST [ IINDEX] . IDSPSYSTEM = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 333;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 333;
                                                            LIST [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 334;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_max" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 334;
                                                                LIST [ IINDEX] . SIRANGEMAX = (short) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 335;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_min" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 335;
                                                                    LIST [ IINDEX] . SIRANGEMIN = (short) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 336;
                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol_default" , STEMPKEY ))  ) ) 
                                                                        {
                                                                        __context__.SourceCodeLine = 336;
                                                                        LIST [ IINDEX] . SIDEFAULTVOL = (short) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                        }
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 337;
                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute_default" , STEMPKEY ))  ) ) 
                                                                            {
                                                                            __context__.SourceCodeLine = 337;
                                                                            LIST [ IINDEX] . IDEFAULTMUTE = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                            }
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 338;
                                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol_disabled" , STEMPKEY ))  ) ) 
                                                                                {
                                                                                __context__.SourceCodeLine = 338;
                                                                                LIST [ IINDEX] . IVOLDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                }
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 339;
                                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute_disabled" , STEMPKEY ))  ) ) 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 339;
                                                                                    LIST [ IINDEX] . IMUTEDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                    }
                                                                                
                                                                                else 
                                                                                    { 
                                                                                    __context__.SourceCodeLine = 343;
                                                                                    Trace( "GlobalDSP - fProcessLine error - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                                                                    } 
                                                                                
                                                                                }
                                                                            
                                                                            }
                                                                        
                                                                        }
                                                                    
                                                                    }
                                                                
                                                                }
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 310;
        } 
    
    __context__.SourceCodeLine = 348;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 350;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ IINDEX ].IRMASS ) && Functions.TestForTrue ( LIST[ IINDEX ].IPOINTTYPE )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 354;
            MakeString ( LIST [ IINDEX] . SGLOBALNAME , "{0:d} {1}", (ushort)ROOM[ LIST[ IINDEX ].IRMASS ].IROOMNUM, LIST [ IINDEX] . SLOCALNAME ) ; 
            __context__.SourceCodeLine = 356;
            DSP_XREF [ (((LIST[ IINDEX ].IRMASS - 1) * 50) + LIST[ IINDEX ].ILOCALID)] = (ushort) ( IINDEX ) ; 
            } 
        
        __context__.SourceCodeLine = 359;
        LIST [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 360;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 361;
        if ( Functions.TestForTrue  ( ( LIST[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 363;
            STEMPHEADER  .UpdateValue ( FGETDATAHEADER (  __context__ , (ushort)( ITYPE ))  ) ; 
            __context__.SourceCodeLine = 364;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ IINDEX ].IRMASS] , "{{{0} LOCALID={1:d}: GUID={2:d}, global_name={3}, local_name={4}, fixed_id={5:d}, group_id={6:d}, is_virtual={7:d}, range_max={8:d}, range_min={9:d}, default_vol={10:d}, default_mute={11:d}, vol_disabled={12:d}, mute_disabled={13:d}, point_type={14:d}, function={15:d},|}}", STEMPHEADER , (ushort)LIST[ IINDEX ].ILOCALID, (ushort)IINDEX, LIST [ IINDEX] . SGLOBALNAME , LIST [ IINDEX] . SLOCALNAME , (ushort)LIST[ IINDEX ].IFIXEDID, (ushort)LIST[ IINDEX ].IGROUPID, (ushort)LIST[ IINDEX ].IISVIRTUAL, (short)LIST[ IINDEX ].SIRANGEMAX, (short)LIST[ IINDEX ].SIRANGEMIN, (short)LIST[ IINDEX ].SIDEFAULTVOL, (ushort)LIST[ IINDEX ].IDEFAULTMUTE, (ushort)LIST[ IINDEX ].IVOLDISABLED, (ushort)LIST[ IINDEX ].IMUTEDISABLED, (ushort)LIST[ IINDEX ].IPOINTTYPE, (ushort)LIST[ IINDEX ].IFUNCTION) ; 
            } 
        
        } 
    
    
    }
    
private void FPROCESSROOMS (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINE ) 
    { 
    ushort I = 0;
    ushort IROOMNUM = 0;
    
    CrestronString STEMPKV;
    CrestronString STEMPKEY;
    CrestronString SDATA;
    STEMPKV  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 401;
    if ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 403;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 404;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 406;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 407;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 410;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 410;
                ROOM [ IINDEX] . SROOMNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) ))  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 411;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bldg_rm_num" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 411;
                    ROOM [ IINDEX] . IROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                    }
                
                else 
                    { 
                    } 
                
                }
            
            __context__.SourceCodeLine = 404;
            } 
        
        } 
    
    
    }
    
private void FPROCESSINIT (  SplusExecutionContext __context__, CrestronString STEMPINITDATA ) 
    { 
    ushort I = 0;
    ushort J = 0;
    ushort IINDEX = 0;
    ushort ITYPE = 0;
    
    CrestronString STEMPDATA;
    CrestronString STEMPHEADER;
    CrestronString STEMPGUID;
    CrestronString STEMPLINE;
    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPGUID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    
    
    __context__.SourceCodeLine = 433;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 434;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 436;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_POINTS" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 436;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 437;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_PRESETS" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 437;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 438;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 438;
                ITYPE = (ushort) ( 13 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 439;
                Trace( "GlobalDSP - in fProcessInit - didn't catch header type - {0}", STEMPHEADER ) ; 
                }
            
            }
        
        }
    
    __context__.SourceCodeLine = 441;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 443;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 444;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 446;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 447;
            FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 451;
            STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
            __context__.SourceCodeLine = 452;
            IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 454;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 456;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)ITYPE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 460;
                            LIST [ IINDEX] . SIRANGEMAX = (short) ( 6 ) ; 
                            __context__.SourceCodeLine = 461;
                            LIST [ IINDEX] . SIRANGEMIN = (short) ( Functions.ToInteger( -( 20 ) ) ) ; 
                            __context__.SourceCodeLine = 462;
                            LIST [ IINDEX] . IRANGETOTAL = (ushort) ( 26 ) ; 
                            __context__.SourceCodeLine = 463;
                            LIST [ IINDEX] . IDEFAULTMUTE = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 464;
                            LIST [ IINDEX] . SIDEFAULTVOL = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 466;
                            FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 468;
                            FPROCESSPRESET (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 13) ) ) ) 
                            {
                            __context__.SourceCodeLine = 469;
                            FPROCESSROOMS (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 472;
                Trace( "GlobalDSP - fProcessInit error, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 441;
        } 
    
    
    }
    
object DATAINIT_RX__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50000, this );
        
        
        __context__.SourceCodeLine = 490;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 492;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 493;
            FPROCESSINIT (  __context__ , STEMP) ; 
            __context__.SourceCodeLine = 490;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    ushort J = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 511;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    DSP_XREF  = new ushort[ 1201 ];
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    LIST  = new STLIST[ 401 ];
    for( uint i = 0; i < 401; i++ )
    {
        LIST [i] = new STLIST( this, true );
        LIST [i].PopulateCustomAttributeList( false );
        
    }
    ROOM  = new STROOM[ 31 ];
    for( uint i = 0; i < 31; i++ )
    {
        ROOM [i] = new STROOM( this, true );
        ROOM [i].PopulateCustomAttributeList( false );
        
    }
    
    CTRL_MUTE_IN = new InOutArray<DigitalInput>( 1200, this );
    for( uint i = 0; i < 1200; i++ )
    {
        CTRL_MUTE_IN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CTRL_MUTE_IN__DigitalInput__ + i, CTRL_MUTE_IN__DigitalInput__, this );
        m_DigitalInputList.Add( CTRL_MUTE_IN__DigitalInput__ + i, CTRL_MUTE_IN[i+1] );
    }
    
    CTRL_MUTE_OUT = new InOutArray<DigitalOutput>( 499, this );
    for( uint i = 0; i < 499; i++ )
    {
        CTRL_MUTE_OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( CTRL_MUTE_OUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( CTRL_MUTE_OUT__DigitalOutput__ + i, CTRL_MUTE_OUT[i+1] );
    }
    
    LIST_ITEMCLICKED = new InOutArray<AnalogInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        LIST_ITEMCLICKED[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LIST_ITEMCLICKED__AnalogSerialInput__ + i, LIST_ITEMCLICKED__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LIST_ITEMCLICKED__AnalogSerialInput__ + i, LIST_ITEMCLICKED[i+1] );
    }
    
    CTRL_VOL_IN = new InOutArray<AnalogInput>( 1200, this );
    for( uint i = 0; i < 1200; i++ )
    {
        CTRL_VOL_IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CTRL_VOL_IN__AnalogSerialInput__ + i, CTRL_VOL_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CTRL_VOL_IN__AnalogSerialInput__ + i, CTRL_VOL_IN[i+1] );
    }
    
    LIST_NUMOFITEMS = new InOutArray<AnalogOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        LIST_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, LIST_NUMOFITEMS[i+1] );
    }
    
    CTRL_VOL_OUT = new InOutArray<AnalogOutput>( 499, this );
    for( uint i = 0; i < 499; i++ )
    {
        CTRL_VOL_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CTRL_VOL_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CTRL_VOL_OUT__AnalogSerialOutput__ + i, CTRL_VOL_OUT[i+1] );
    }
    
    FROM_ROOM_RX__DOLLAR__ = new InOutArray<StringInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        FROM_ROOM_RX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ + i, FROM_ROOM_RX__DOLLAR____AnalogSerialInput__, 1000, this );
        m_StringInputList.Add( FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ + i, FROM_ROOM_RX__DOLLAR__[i+1] );
    }
    
    LISTFB__DOLLAR__ = new InOutArray<StringOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        LISTFB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LISTFB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LISTFB__DOLLAR____AnalogSerialOutput__ + i, LISTFB__DOLLAR__[i+1] );
    }
    
    TO_ROOM_TX__DOLLAR__ = new InOutArray<StringOutput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        TO_ROOM_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, TO_ROOM_TX__DOLLAR__[i+1] );
    }
    
    DATAINIT_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( DATAINIT_RX__DOLLAR____AnalogSerialInput__, 5000, this );
    m_StringInputList.Add( DATAINIT_RX__DOLLAR____AnalogSerialInput__, DATAINIT_RX__DOLLAR__ );
    
    
    for( uint i = 0; i < 1200; i++ )
        CTRL_VOL_IN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( CTRL_VOL_IN_OnChange_0, false ) );
        
    for( uint i = 0; i < 1200; i++ )
        CTRL_MUTE_IN[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( CTRL_MUTE_IN_OnChange_1, false ) );
        
    for( uint i = 0; i < 30; i++ )
        FROM_ROOM_RX__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_ROOM_RX__DOLLAR___OnChange_2, false ) );
        
    DATAINIT_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR___OnChange_3, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_UA_HSIB_GLOBALDSP_V1_0_80 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CTRL_MUTE_IN__DigitalInput__ = 0;
const uint DATAINIT_RX__DOLLAR____AnalogSerialInput__ = 0;
const uint FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ = 1;
const uint LIST_ITEMCLICKED__AnalogSerialInput__ = 31;
const uint CTRL_VOL_IN__AnalogSerialInput__ = 43;
const uint CTRL_MUTE_OUT__DigitalOutput__ = 0;
const uint LISTFB__DOLLAR____AnalogSerialOutput__ = 0;
const uint TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ = 12;
const uint LIST_NUMOFITEMS__AnalogSerialOutput__ = 42;
const uint CTRL_VOL_OUT__AnalogSerialOutput__ = 54;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}

[SplusStructAttribute(-1, true, false)]
public class STLIST : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IITEMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SGLOBALNAME;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SLOCALNAME;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IGLOBALTOLIST = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  ILISTTOGLOBAL = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IRMASS = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  ILOCALID = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IFIXEDID = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IGROUPID = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IPOINTTYPE = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IFUNCTION = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  IISVIRTUAL = 0;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  IVLINK = 0;
    
    [SplusStructAttribute(13, false, false)]
    public CrestronString  SGAINCMDDATA;
    
    [SplusStructAttribute(14, false, false)]
    public CrestronString  SMUTECMDDATA;
    
    [SplusStructAttribute(15, false, false)]
    public CrestronString  SRTECMDDATA;
    
    [SplusStructAttribute(16, false, false)]
    public short  SIRANGEMAX = 0;
    
    [SplusStructAttribute(17, false, false)]
    public short  SIRANGEMIN = 0;
    
    [SplusStructAttribute(18, false, false)]
    public ushort  IRANGETOTAL = 0;
    
    [SplusStructAttribute(19, false, false)]
    public short  SIDEFAULTVOL = 0;
    
    [SplusStructAttribute(20, false, false)]
    public ushort  IDEFAULTMUTE = 0;
    
    [SplusStructAttribute(21, false, false)]
    public ushort  IVOLDISABLED = 0;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  IMUTEDISABLED = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IHIGHESTLISTINDEX = 0;
    
    [SplusStructAttribute(24, false, false)]
    public ushort  INUMOFTEXTCOLUMNS = 0;
    
    [SplusStructAttribute(25, false, false)]
    public ushort  IDSPSYSTEM = 0;
    
    
    public STLIST( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SGAINCMDDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SMUTECMDDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SRTECMDDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STROOM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IROOMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SROOMNAME;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SROOMNAMESHORT;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IROOMNUM = 0;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SROOMNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SROOMNAMESHORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        
        
    }
    
}

}