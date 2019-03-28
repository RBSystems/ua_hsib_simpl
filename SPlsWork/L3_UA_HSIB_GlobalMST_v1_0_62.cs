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

namespace UserModule_L3_UA_HSIB_GLOBALMST_V1_0_62
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_62 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput MTRX_TAKE_ALL;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_TAKE_VIDEO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_TAKE_AUDIO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_DESELECT_ALL;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_DESELECT_VIDEO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_DESELECT_AUDIO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_SELECT_ALL;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_SELECT_ALL_VIDEO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_SELECT_ALL_AUDIO;
        Crestron.Logos.SplusObjects.DigitalInput MTRX_CLEAR_ROUTE_ALL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> UI_PAGE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> UI_SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_SENDTOVTC;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_SAVE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VTC_CTRL_SEL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VTC_DISPLAYSINGLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VTC_DISPLAYDUAL;
        Crestron.Logos.SplusObjects.AnalogInput CAM_FOLDEDCTRL;
        Crestron.Logos.SplusObjects.StringInput CAM_PRESETTEXT__DOLLAR___IN;
        Crestron.Logos.SplusObjects.BufferInput DATAINIT_RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> FROM_ROOM_RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LIST_ITEMCLICKED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_V_IN;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_A_IN;
        Crestron.Logos.SplusObjects.DigitalOutput CAM_POWERON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput CAM_POWEROFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput CAM_SAVE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput VTC_ROOMRES_POPRESET;
        Crestron.Logos.SplusObjects.DigitalOutput VTC_CAMSEL_POPRESET;
        Crestron.Logos.SplusObjects.DigitalOutput VTC_CONTENT_POPRESET;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VTC_CTRL_SEL_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VTC_ENDALLCALLS;
        Crestron.Logos.SplusObjects.StringOutput VTC_CTRL_SEL_UNITNAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput USB_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CAM_PRESETTEXT__DOLLAR___OUT;
        Crestron.Logos.SplusObjects.StringOutput CAM_LIST_SELECTEDCAM__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput ROOMS_LIST_SELECTEDROOM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_ROOMRES_NAME__DOLLAR___SEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_ROOMRES_NAME__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_CAMSELECT_NAME__DOLLAR___SEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_CAMSELECT_NAME__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_CONTENTSHARE_NAME__DOLLAR___SEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VTC_CONTENTSHARE_NAME__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LISTFB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CAM_DATAINIT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DISPLAY_DATAINIT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> RELAY_DATAINIT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_ROOM_TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIST_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_V_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_A_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CAM_FOLDEDCMD;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DISPLAY_FOLDEDCMD;
        STLIST [] LIST;
        STFILTER [] FILTER;
        STROOM [] ROOM;
        STSYSTEM SYS;
        CrestronString STRASH;
        uint LIUSB_CMDINDEX = 0;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 332;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 332;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 333;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 342;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 342;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 344;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 345;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 346;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 348;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 348;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 349;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 346;
                } 
            
            __context__.SourceCodeLine = 351;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 352;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 352;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 354;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 355;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 356;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 358;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 358;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 359;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 360;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 361;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 356;
                } 
            
            __context__.SourceCodeLine = 364;
            return ( SDATA ) ; 
            
            }
            
        private ushort FHIGHESTLISTINDEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 370;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 372;
                LIST [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( LIST[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                __context__.SourceCodeLine = 373;
                return (ushort)( LIST[ ILIST ].IHIGHESTLISTINDEX) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 375;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 377;
                    FILTER [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( FILTER[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                    __context__.SourceCodeLine = 378;
                    return (ushort)( FILTER[ ILIST ].IHIGHESTLISTINDEX) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 380;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 11))  ) ) 
                        {
                        __context__.SourceCodeLine = 380;
                        return (ushort)( SYS.INUMOFROOMS) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 381;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 12))  ) ) 
                            {
                            __context__.SourceCodeLine = 381;
                            return (ushort)( SYS.CAM.INUMOFCAMS) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 382;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 382;
                                return (ushort)( SYS.DISPLAY.INUMOFDISPLAYS) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private CrestronString FGETDATAHEADER (  SplusExecutionContext __context__, ushort ITYPE ) 
            { 
            
            __context__.SourceCodeLine = 387;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 389;
                        return ( "MTRX_VSRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 390;
                        return ( "MTRX_VDST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 391;
                        return ( "MTRX_ASRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 392;
                        return ( "MTRX_ADST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 393;
                        return ( "MTRX_SRCF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 394;
                        return ( "MTRX_SRCG;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 395;
                        return ( "MTRX_DSTF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 396;
                        return ( "MTRX_DSTG;" ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            return ""; // default return value (none specified in module)
            }
            
        private CrestronString FGETUSBCMDINDEX (  SplusExecutionContext __context__, ushort IINC ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 412;
            if ( Functions.TestForTrue  ( ( IINC)  ) ) 
                {
                __context__.SourceCodeLine = 412;
                LIUSB_CMDINDEX = (uint) ( (LIUSB_CMDINDEX + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 414;
            MakeString ( STEMP , "{0}{1}{2}{3}", Functions.Chr (  (int) ( Functions.High( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) ) ; 
            __context__.SourceCodeLine = 419;
            return ( STEMP ) ; 
            
            }
            
        private void FUSBSENDROUTEKILL (  SplusExecutionContext __context__, ushort IDST ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 426;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 431;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 432;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u000a{1}{2}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTETAKE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 443;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 445;
            FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
            __context__.SourceCodeLine = 447;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 448;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
            __context__.SourceCodeLine = 454;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 455;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 467;
            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IISUSB)  ) ) 
                { 
                __context__.SourceCodeLine = 469;
                if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 471;
                    if ( Functions.TestForTrue  ( ( LIST[ 1 ].ITEM[ ISRC ].IISUSB)  ) ) 
                        { 
                        __context__.SourceCodeLine = 473;
                        FUSBSENDROUTETAKE (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 477;
                        FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 482;
                    FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
                    } 
                
                } 
            
            
            }
            
        private void FMTRXSENDROUTE (  SplusExecutionContext __context__, ushort ILIST , ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 490;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 494;
                        LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 495;
                        MTRX_V_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 499;
                        LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 500;
                        MTRX_A_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 504;
                        Trace( "Global - in fMTRXSendRoute - didnt catch iList case - iList={0:d}", (ushort)ILIST) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private short FMTRXSENDROUTEVIRTUAL (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort IDSTROOM = 0;
            ushort ISRCROOM = 0;
            ushort ILOCALID = 0;
            
            CrestronString STEMPNAME;
            STEMPNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 524;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 526;
                IDSTROOM = (ushort) ( LIST[ 2 ].ITEM[ IDST ].IRMASS ) ; 
                __context__.SourceCodeLine = 527;
                ISRCROOM = (ushort) ( LIST[ 1 ].ITEM[ ISRC ].IRMASS ) ; 
                __context__.SourceCodeLine = 529;
                ILOCALID = (ushort) ( LIST[ 2 ].ITEM[ IDST ].ILOCALID ) ; 
                __context__.SourceCodeLine = 531;
                LIST [ 2] . ITEM [ IDST] . IVLINK = (ushort) ( ISRC ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 535;
                Trace( "GlobalMST - in fMTRXSendRouteVirtual - attempting function with iDst value 0") ; 
                __context__.SourceCodeLine = 536;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 540;
            STEMPNAME  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
            __context__.SourceCodeLine = 542;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                {
                __context__.SourceCodeLine = 542;
                STEMPNAME  .UpdateValue ( LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME  ) ; 
                }
            
            __context__.SourceCodeLine = 544;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ IDSTROOM] , "{{V_LINK_VSRC; LocalID={0:d}: GUID={1:d},{2}|;}}", (ushort)ILOCALID, (ushort)ISRC, STEMPNAME ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCAMGETFOLDEDCMD (  SplusExecutionContext __context__, CrestronString STEMPDATA ) 
            { 
            
            __context__.SourceCodeLine = 561;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "stop" , STEMPDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 561;
                return (ushort)( 0) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 562;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "up" , STEMPDATA ))  ) ) 
                    {
                    __context__.SourceCodeLine = 562;
                    return (ushort)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 563;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "down" , STEMPDATA ))  ) ) 
                        {
                        __context__.SourceCodeLine = 563;
                        return (ushort)( 2) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 564;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "left" , STEMPDATA ))  ) ) 
                            {
                            __context__.SourceCodeLine = 564;
                            return (ushort)( 3) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 565;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "right" , STEMPDATA ))  ) ) 
                                {
                                __context__.SourceCodeLine = 565;
                                return (ushort)( 4) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 566;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomin" , STEMPDATA ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 566;
                                    return (ushort)( 5) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 567;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomout" , STEMPDATA ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 567;
                                        return (ushort)( 6) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 568;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweron" , STEMPDATA ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 568;
                                            return (ushort)( 7) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 569;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweroff" , STEMPDATA ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 569;
                                                return (ushort)( 8) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 570;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetrec" , STEMPDATA ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 570;
                                                    return (ushort)( (Functions.Atoi( STEMPDATA ) + 100)) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 571;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetsav" , STEMPDATA ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 571;
                                                        return (ushort)( (Functions.Atoi( STEMPDATA ) + 200)) ; 
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
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FCAMPROCESSPRESET (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
            { 
            
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 589;
            LISTFB__DOLLAR__ [ ILIST]  .UpdateValue ( SDATA  ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 599;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 601;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 602;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 606;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 608;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 608;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 610;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 611;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 613;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 614;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 615;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 606;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 619;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 621;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 622;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 631;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 633;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 635;
                    STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                    __context__.SourceCodeLine = 636;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 640;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 642;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 642;
                            MakeString ( STEMP , "{{ListVisFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 644;
                        MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                        __context__.SourceCodeLine = 645;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 647;
                            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                            __context__.SourceCodeLine = 648;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 649;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 640;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 653;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 655;
                    MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                    __context__.SourceCodeLine = 656;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 666;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 668;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 670;
                MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                __context__.SourceCodeLine = 671;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 673;
                    MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                    __context__.SourceCodeLine = 671;
                    } 
                
                __context__.SourceCodeLine = 675;
                STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                __context__.SourceCodeLine = 676;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 680;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 682;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 684;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 684;
                            MakeString ( STEMP , "{{ListTextFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 686;
                        MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                        __context__.SourceCodeLine = 687;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 689;
                            MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                            __context__.SourceCodeLine = 687;
                            } 
                        
                        __context__.SourceCodeLine = 691;
                        MakeString ( STEMP , "{0}|", STEMP ) ; 
                        __context__.SourceCodeLine = 693;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 600 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 695;
                            MakeString ( STEMP , "{0};}}", STEMP ) ; 
                            __context__.SourceCodeLine = 696;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 697;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 680;
                    } 
                
                __context__.SourceCodeLine = 701;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 703;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 704;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTFBFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 716;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 718;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 719;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 723;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 725;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 725;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 727;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 728;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 730;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 731;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 732;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 723;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 736;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 738;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 739;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVISFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 747;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 749;
                MakeString ( STEMP , "{{ListVisFB:{0:d}={1:d},", (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 753;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 755;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 755;
                        MakeString ( STEMP , "{{ListVisFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 757;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    __context__.SourceCodeLine = 758;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 760;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 761;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 762;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 753;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 766;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 768;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 769;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXTFILTER (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 778;
            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
            __context__.SourceCodeLine = 780;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 782;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 782;
                    MakeString ( STEMP , "{{ListTextFB:") ; 
                    }
                
                __context__.SourceCodeLine = 784;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 786;
                    MakeString ( STEMP , "{0}{1:d}={2},|", STEMP , (ushort)FILTER[ ILIST ].ITEM[ I ].IGLOBALTOLIST, FILTER [ ILIST] . ITEM [ I] . STEXT [ 1 ] ) ; 
                    } 
                
                __context__.SourceCodeLine = 791;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 800 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 793;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 794;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 795;
                    STEMP  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 780;
                } 
            
            __context__.SourceCodeLine = 798;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 800;
                MakeString ( STEMP , "{0};}}", STEMP ) ; 
                __context__.SourceCodeLine = 801;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            
            }
            
        private void FCONFIGURELISTFBSETVISIBLEITEMS (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 822;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 824;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IVIS)  ) ) 
                    { 
                    __context__.SourceCodeLine = 826;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 827;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 822;
                } 
            
            
            }
            
        private void FCONFIGURELISTFBRESETALL (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 835;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 837;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 839;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 840;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 835;
                } 
            
            __context__.SourceCodeLine = 843;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            
            }
            
        private void FCONFIGURELISTFBTOGGLE (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 849;
            LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( LIST[ ILIST ].ITEM[ IINDEX ].IFB ) ) ; 
            __context__.SourceCodeLine = 850;
            FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private ushort FCONFIGURELISTFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort ISAME = 0;
            
            
            __context__.SourceCodeLine = 856;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 858;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ILIST ].IITEMSELECTEDLAST == IINDEX))  ) ) 
                    { 
                    __context__.SourceCodeLine = 860;
                    LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 861;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 862;
                    ISAME = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 864;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                        { 
                        __context__.SourceCodeLine = 866;
                        LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 867;
                        FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                        __context__.SourceCodeLine = 868;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 869;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 873;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 874;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 876;
                FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                __context__.SourceCodeLine = 877;
                if ( Functions.TestForTrue  ( ( ISAME)  ) ) 
                    {
                    __context__.SourceCodeLine = 877;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 878;
                return (ushort)( IINDEX) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 882;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 884;
                    LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 885;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                    __context__.SourceCodeLine = 886;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                __context__.SourceCodeLine = 892;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCONFIGUREFILTERFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 900;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINDEX != FILTER[ ILIST ].IITEMSELECTEDLAST))  ) ) 
                { 
                __context__.SourceCodeLine = 902;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 904;
                    FILTER [ ILIST] . ITEM [ FILTER[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 905;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( FILTER[ ILIST ].IITEMSELECTEDLAST )) ; 
                    } 
                
                __context__.SourceCodeLine = 907;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 909;
                    FILTER [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 910;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    } 
                
                __context__.SourceCodeLine = 912;
                FILTER [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 913;
                return (ushort)( 1) ; 
                } 
            
            __context__.SourceCodeLine = 915;
            return (ushort)( 0) ; 
            
            }
            
        private void FCONFIGUREFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            ushort ITEMPLIST1 = 0;
            ushort ITEMPLIST2 = 0;
            
            
            __context__.SourceCodeLine = 923;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
            __context__.SourceCodeLine = 924;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX )) ; 
            __context__.SourceCodeLine = 926;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 928;
                FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
                __context__.SourceCodeLine = 929;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 931;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 933;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 934;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 929;
                    } 
                
                __context__.SourceCodeLine = 937;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 939;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 941;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 942;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 937;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 948;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 950;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 952;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 953;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 948;
                    } 
                
                __context__.SourceCodeLine = 956;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                    { 
                    __context__.SourceCodeLine = 958;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 960;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 961;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 956;
                    } 
                
                } 
            
            
            }
            
        private void FCONFIGUREGROUP (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 971;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 973;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 975;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 977;
                        FILTER [ (ILIST - 1)] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 978;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 973;
                    } 
                
                __context__.SourceCodeLine = 982;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ) && Functions.TestForTrue ( Functions.Not( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 985;
                    FCONFIGUREFILTERFBMUTEX (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 986;
                    FCONFIGUREFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 991;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 993;
                    if ( Functions.TestForTrue  ( ( Functions.Not( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 995;
                        FILTER [ FILTER[ ILIST ].IMEMBERLISTFINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 996;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 991;
                    } 
                
                } 
            
            
            }
            
        private CrestronString FGETROUTEDSOURCENAME (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1008;
            try 
                { 
                __context__.SourceCodeLine = 1010;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1012;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1014;
                        return ( LIST [ (ILIST - 1)] . ITEM [ LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC] . SGLOBALNAME ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1016;
                        return ( SYS . SBLANKSRCTEXT ) ; 
                        }
                    
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1021;
                Trace( "GlobalMST fGetRoutedSourceName - error - iList={0:d}, iIndex={1:d}, List[{2:d}].Item[{3:d}].iRoutedSrc={4:d}", (ushort)ILIST, (ushort)IINDEX, (ushort)ILIST, (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC) ; 
                
                }
                
                
                return ""; // default return value (none specified in module)
                }
                
            private ushort FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX , ushort ITEXTCOLUMN ) 
                { 
                
                __context__.SourceCodeLine = 1028;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1030;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)ITEXTCOLUMN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1032;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1033;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( FGETROUTEDSOURCENAME (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX ))  ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 1036;
                    return (ushort)( 0) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1038;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1040;
                        FILTER [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( FILTER [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                        } 
                    
                    }
                
                
                return 0; // default return value (none specified in module)
                }
                
            private void FCONFIGURELISTALL (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
                { 
                
                
                }
                
            private void FPROCESSROOMDATA (  SplusExecutionContext __context__, ushort IROOM , CrestronString STEMP ) 
                { 
                ushort I = 0;
                ushort J = 0;
                ushort IRELAYTYPE = 0;
                ushort IDISPLAYVGUID = 0;
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
                
                
                __context__.SourceCodeLine = 1068;
                STEMPDATA  .UpdateValue ( STEMP  ) ; 
                __context__.SourceCodeLine = 1069;
                STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
                __context__.SourceCodeLine = 1071;
                while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1073;
                    STEMP2  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 1074;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_V_RTE" , STEMPHEADER ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1076;
                        STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                        __context__.SourceCodeLine = 1077;
                        IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                        __context__.SourceCodeLine = 1078;
                        IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                        __context__.SourceCodeLine = 1079;
                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1081;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_rte" , STEMPHEADER ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1083;
                            Trace( "in GlobalMST usb_rte") ; 
                            __context__.SourceCodeLine = 1084;
                            STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                            __context__.SourceCodeLine = 1085;
                            IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                            __context__.SourceCodeLine = 1086;
                            IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                            __context__.SourceCodeLine = 1087;
                            Trace( "iGUIDdst = {0:d}, iGUIDsrc = {1:d}", (ushort)IGUIDDST, (ushort)IGUIDSRC) ; 
                            __context__.SourceCodeLine = 1089;
                            FUSBSENDROUTE (  __context__ , (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1091;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_ctrl" , STEMPHEADER ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1093;
                                STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                __context__.SourceCodeLine = 1094;
                                I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                __context__.SourceCodeLine = 1095;
                                if ( Functions.TestForTrue  ( ( I)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1097;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1098;
                                    CAM_FOLDEDCMD [ I]  .Value = (ushort) ( FCAMGETFOLDEDCMD( __context__ , STEMP2 ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1102;
                                    Trace( "Global fProcessRoomData, found cam_ctrl - iCamGUID resolved to zero(0)") ; 
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1105;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "dply_cmd" , STEMPHEADER ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1107;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1108;
                                    I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                    __context__.SourceCodeLine = 1109;
                                    if ( Functions.TestForTrue  ( ( I)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1111;
                                        STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                        __context__.SourceCodeLine = 1113;
                                        DISPLAY_FOLDEDCMD [ I]  .Value = (ushort) ( (Functions.Atoi( STEMP2 ) + 10) ) ; 
                                        __context__.SourceCodeLine = 1117;
                                        IDISPLAYVGUID = (ushort) ( SYS.DISPLAY.IGUID[ I ] ) ; 
                                        __context__.SourceCodeLine = 1118;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 1))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1120;
                                            IRELAYTYPE = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1122;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 6))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1124;
                                                IRELAYTYPE = (ushort) ( 2 ) ; 
                                                } 
                                            
                                            }
                                        
                                        __context__.SourceCodeLine = 1127;
                                        if ( Functions.TestForTrue  ( ( IRELAYTYPE)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1129;
                                            
                                                {
                                                int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.Atoi( STEMP2 ));
                                                
                                                    { 
                                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1133;
                                                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__1 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYOFFNUMOF; 
                                                        int __FN_FORSTEP_VAL__1 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                                                            { 
                                                            __context__.SourceCodeLine = 1135;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1136;
                                                            Functions.Delay (  (int) ( 30 ) ) ; 
                                                            __context__.SourceCodeLine = 1137;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1133;
                                                            } 
                                                        
                                                        } 
                                                    
                                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1142;
                                                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__2 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYONNUMOF; 
                                                        int __FN_FORSTEP_VAL__2 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
                                                            { 
                                                            __context__.SourceCodeLine = 1144;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1145;
                                                            Functions.Delay (  (int) ( 30 ) ) ; 
                                                            __context__.SourceCodeLine = 1146;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1142;
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
                    
                    __context__.SourceCodeLine = 1071;
                    } 
                
                
                }
                
            object FROM_ROOM_RX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    ushort I = 0;
                    ushort IROOM = 0;
                    
                    CrestronString STEMPDATA;
                    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
                    
                    
                    __context__.SourceCodeLine = 1161;
                    IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1163;
                    STEMPDATA  .UpdateValue ( Functions.Gather ( Functions.Length( FROM_ROOM_RX__DOLLAR__[ IROOM ] ), FROM_ROOM_RX__DOLLAR__ [ IROOM ] )  ) ; 
                    __context__.SourceCodeLine = 1164;
                    FPROCESSROOMDATA (  __context__ , (ushort)( IROOM ), STEMPDATA) ; 
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        object MTRX_V_IN_OnChange_1 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IDST = 0;
                ushort ISRC = 0;
                
                
                __context__.SourceCodeLine = 1173;
                if ( Functions.TestForTrue  ( ( LIST[ 2 ].IINITIALIZED)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1175;
                    IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1177;
                    ISRC = (ushort) ( MTRX_V_IN[ IDST ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 1179;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 1000 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1181;
                        Trace( "GlobalMST - Change MTRX_V_In, dstGUID={0:d}, srcValue(not a GUID)={1:d}", (ushort)IDST, (ushort)ISRC) ; 
                        __context__.SourceCodeLine = 1182;
                        ISRC = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1183;
                        LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 1184;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                        __context__.SourceCodeLine = 1185;
                        FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1187;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISRC ) && Functions.TestForTrue ( Functions.BoolToInt (ISRC != LIST[ 2 ].ITEM[ IDST ].IROUTEDSRC) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1189;
                            LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 1190;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                            __context__.SourceCodeLine = 1191;
                            FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                            __context__.SourceCodeLine = 1193;
                            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IRMASS)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1195;
                                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 2 ].ITEM[ IDST ].IRMASS] , "{{MTRX_V_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 2 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1202;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ISRC ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1204;
                                Trace( "GlobalMST - Change MTRX_V_In, iSrc == 0") ; 
                                __context__.SourceCodeLine = 1205;
                                LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 1206;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                                __context__.SourceCodeLine = 1207;
                                FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1211;
                                Trace( "GlobalMST MTRX_V_In - else trap") ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1214;
                    Trace( "Global received analog FB from the video MTRX system, but Global has not completed data initialization. Skipping FB process.") ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MTRX_A_IN_OnChange_2 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort IDST = 0;
            ushort ISRC = 0;
            
            
            __context__.SourceCodeLine = 1222;
            if ( Functions.TestForTrue  ( ( LIST[ 4 ].IINITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 1224;
                IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 1226;
                ISRC = (ushort) ( MTRX_A_IN[ IDST ] .UshortValue ) ; 
                __context__.SourceCodeLine = 1227;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISRC != LIST[ 4 ].ITEM[ IDST ].IROUTEDSRC))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1229;
                    LIST [ 4] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                    __context__.SourceCodeLine = 1230;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                    __context__.SourceCodeLine = 1231;
                    FUPDATELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST )) ; 
                    __context__.SourceCodeLine = 1233;
                    if ( Functions.TestForTrue  ( ( LIST[ 4 ].ITEM[ IDST ].IRMASS)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1235;
                        MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 4 ].ITEM[ IDST ].IRMASS] , "{{MTRX_A_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 4 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 3] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1243;
                Trace( "Global received analog FB from the audio MTRX system, but Global has not completed data initialization. Skipping FB process.") ; 
                }
            
            
            
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
    CrestronString STEMPCOMPORT;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    STEMPCOMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 1261;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1264;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)23; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1266;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ I] , "{0}COMPLETE|}}", FGETDATAHEADER (  __context__ , (ushort)( ILIST )) ) ; 
            __context__.SourceCodeLine = 1267;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 1264;
            } 
        
        __context__.SourceCodeLine = 1270;
        LIST [ ILIST] . IINITIALIZED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1272;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 1274;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1275;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1277;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1277;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 2 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1272;
            } 
        
        __context__.SourceCodeLine = 1280;
        FUPDATELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1281;
        FUPDATELISTVIS (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1283;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1285;
            LIST_NUMOFITEMS [ ILIST]  .Value = (ushort) ( FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1286;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 1288;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
                __context__.SourceCodeLine = 1286;
                } 
            
            __context__.SourceCodeLine = 1290;
            FUPDATELISTTEXTFILTER (  __context__ , (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1291;
            FUPDATELISTVISFILTER (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
            } 
        
        }
    
    __context__.SourceCodeLine = 1294;
    Functions.Delay (  (int) ( 100 ) ) ; 
    
    return 0; // default return value (none specified in module)
    }
    
private void FPROCESSLINE (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort I = 0;
    ushort J = 0;
    ushort ICAMGUID = 0;
    ushort IDISPLAYGUID = 0;
    ushort IERR = 0;
    
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    CrestronString STEMPPAIR;
    CrestronString STEMPLINE;
    CrestronString STEMPHEADER;
    CrestronString STEMP;
    CrestronString STEMP2;
    CrestronString STEMPCOMPORT;
    CrestronString STEMPUSB;
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    STEMPCOMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPUSB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    
    __context__.SourceCodeLine = 1314;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1316;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1318;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1319;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1320;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1322;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1324;
            LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            __context__.SourceCodeLine = 1325;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), (ushort)( 1 )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1327;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1329;
                LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1331;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1331;
                    LIST [ ITYPE] . ITEM [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1332;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_id" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1332;
                        LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1334;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_src_id" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1334;
                            LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1335;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1335;
                                LIST [ ITYPE] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1336;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "filter" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1336;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . IFILTERID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1338;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ip_address" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1338;
                                        LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1339;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "com_port" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1339;
                                            LIST [ ITYPE] . ITEM [ IINDEX] . ICOMPORT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1340;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "processor_index" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1340;
                                                LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1342;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1342;
                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1343;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1343;
                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1344;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "relay_proc" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1344;
                                                            LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYPROCESSOR = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1345;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_on" , STEMPKEY ))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 1347;
                                                                I = (ushort) ( 1 ) ; 
                                                                __context__.SourceCodeLine = 1348;
                                                                while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1350;
                                                                    STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                                                                    __context__.SourceCodeLine = 1351;
                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                                                    __context__.SourceCodeLine = 1352;
                                                                    if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 1354;
                                                                        STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                                                        __context__.SourceCodeLine = 1355;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                                                        __context__.SourceCodeLine = 1356;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                                                        } 
                                                                    
                                                                    __context__.SourceCodeLine = 1358;
                                                                    I = (ushort) ( (I + 1) ) ; 
                                                                    __context__.SourceCodeLine = 1348;
                                                                    } 
                                                                
                                                                __context__.SourceCodeLine = 1360;
                                                                LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYONNUMOF = (ushort) ( I ) ; 
                                                                __context__.SourceCodeLine = 1361;
                                                                I = (ushort) ( 0 ) ; 
                                                                } 
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1363;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_off" , STEMPKEY ))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1365;
                                                                    I = (ushort) ( 1 ) ; 
                                                                    __context__.SourceCodeLine = 1366;
                                                                    while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 1368;
                                                                        STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                                                                        __context__.SourceCodeLine = 1369;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                                                        __context__.SourceCodeLine = 1370;
                                                                        if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1372;
                                                                            STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                                                            __context__.SourceCodeLine = 1373;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                                                            __context__.SourceCodeLine = 1374;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                                                            } 
                                                                        
                                                                        __context__.SourceCodeLine = 1376;
                                                                        I = (ushort) ( (I + 1) ) ; 
                                                                        __context__.SourceCodeLine = 1366;
                                                                        } 
                                                                    
                                                                    __context__.SourceCodeLine = 1378;
                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYOFFNUMOF = (ushort) ( I ) ; 
                                                                    __context__.SourceCodeLine = 1379;
                                                                    I = (ushort) ( 0 ) ; 
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 1381;
                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "device_type" , STEMPKEY ))  ) ) 
                                                                        {
                                                                        __context__.SourceCodeLine = 1381;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                        }
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 1383;
                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1385;
                                                                            STEMPVALUE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                            __context__.SourceCodeLine = 1387;
                                                                            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR , "{0}{1}{2}", Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 1 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 3 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 5 ) , (int)( 2 ) ) ) ) ) ) ; 
                                                                            __context__.SourceCodeLine = 1393;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                                                                            } 
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 1395;
                                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_vtc" , STEMPKEY ))  ) ) 
                                                                                {
                                                                                __context__.SourceCodeLine = 1395;
                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . IISVTC = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                }
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 1396;
                                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vtc_io" , STEMPKEY ))  ) ) 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 1396;
                                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IVTCIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                    }
                                                                                
                                                                                else 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 1398;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 1398;
                                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                        }
                                                                                    
                                                                                    else 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 1399;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cmd" , STEMPKEY ))  ) ) 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 1401;
                                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . SCMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                                            __context__.SourceCodeLine = 1402;
                                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . ICMDDATA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                            } 
                                                                                        
                                                                                        else 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 1406;
                                                                                            IERR = (ushort) ( 1 ) ; 
                                                                                            __context__.SourceCodeLine = 1407;
                                                                                            Trace( "error - MTRX Init Data - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
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
                
                }
            
            }
        
        __context__.SourceCodeLine = 1316;
        } 
    
    __context__.SourceCodeLine = 1411;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1413;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1416;
            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , "{0:d3} {1}", (ushort)ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].IROOMNUM, LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME ) ; 
            } 
        
        __context__.SourceCodeLine = 1422;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
            { 
            __context__.SourceCodeLine = 1424;
            SYS . CAM . INUMOFCAMS = (ushort) ( (SYS.CAM.INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1425;
            SYS . CAM . IGUID [ SYS.CAM.INUMOFCAMS] = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1426;
            ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFCAMS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1427;
            LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1428;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1429;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1430;
            ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1432;
            MakeString ( CAM_DATAINIT__DOLLAR__ [ 1] , "{{ListTextFB:{0:d}= global_name={1}~ip={2},|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS ) ; 
            __context__.SourceCodeLine = 1437;
            MakeString ( LISTFB__DOLLAR__ [ 12] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)ICAMGUID) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1443;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                { 
                __context__.SourceCodeLine = 1445;
                SYS . DISPLAY . INUMOFDISPLAYS = (ushort) ( (SYS.DISPLAY.INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1446;
                SYS . DISPLAY . IGUID [ SYS.DISPLAY.INUMOFDISPLAYS] = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 1447;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFDISPLAYS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1448;
                LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1449;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1450;
                IDISPLAYGUID = (ushort) ( SYS.DISPLAY.INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1451;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1454;
                LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( 5 ) ; 
                __context__.SourceCodeLine = 1456;
                STEMPCOMPORT  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 1457;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT)  ) ) 
                    {
                    __context__.SourceCodeLine = 1457;
                    MakeString ( STEMPCOMPORT , "~com_port={0:d},", (ushort)LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT) ; 
                    }
                
                __context__.SourceCodeLine = 1459;
                MakeString ( DISPLAY_DATAINIT__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IPROCESSORINDEX] , "{{ListTextFB:{0:d}= global_name={1}~ip={2}~device_type={3}{4},|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS , LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE , STEMPCOMPORT ) ; 
                __context__.SourceCodeLine = 1466;
                MakeString ( LISTFB__DOLLAR__ [ 13] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)IDISPLAYGUID) ; 
                __context__.SourceCodeLine = 1473;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYPROCESSOR == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1475;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYONNUMOF; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1477;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IISINITINDEX )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1479;
                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1475;
                        } 
                    
                    __context__.SourceCodeLine = 1485;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYOFFNUMOF; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 1487;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IISINITINDEX )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1489;
                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1485;
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1497;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1499;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_5__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1502;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVOUTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1504;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVINGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            }
        
        __context__.SourceCodeLine = 1508;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISUSB)  ) ) 
            {
            __context__.SourceCodeLine = 1508;
            MakeString ( STEMPUSB , " usb_mac={0},", LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR ) ; 
            }
        
        __context__.SourceCodeLine = 1510;
        LIST [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1511;
        LIST [ ITYPE] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1512;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1513;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1516;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
                {
                __context__.SourceCodeLine = 1516;
                MakeString ( STEMP , "is_camera=1, cam_localID={0:d}, cam_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMGUID) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1520;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                    {
                    __context__.SourceCodeLine = 1520;
                    MakeString ( STEMP , "is_display=1, display_localID={0:d}, display_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYGUID) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1525;
            STEMPHEADER  .UpdateValue ( FGETDATAHEADER (  __context__ , (ushort)( ITYPE ))  ) ; 
            __context__.SourceCodeLine = 1526;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITYPE >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITYPE <= 2 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1526;
                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] , "{{{0} LOCALID={1:d}: GUID={2:d}, global_name={3}, local_name={4}, {5}is_virtual={6:d}, {7}|}}", STEMPHEADER , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID, (ushort)IINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME , STEMP , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL, STEMPUSB ) ; 
                }
            
            __context__.SourceCodeLine = 1538;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                {
                __context__.SourceCodeLine = 1538;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . IVIRTUALVDSTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID] = (ushort) ( IINDEX ) ; 
                }
            
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1541;
        Trace( "GlobalMST - in fProcessLine - iErr <> 0  -  iIndex = {0:d}", (ushort)IINDEX) ; 
        }
    
    
    }
    
private void FPROCESSROOMS (  SplusExecutionContext __context__, ushort ITYPE , CrestronString STEMPLINE ) 
    { 
    ushort I = 0;
    ushort IROOMNUM = 0;
    ushort IINDEX = 0;
    
    CrestronString STEMPNAME;
    CrestronString STEMPKEY;
    CrestronString STEMPKV;
    CrestronString STEMPNAMESHORT;
    CrestronString SDATA;
    STEMPNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPKV  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPNAMESHORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 1549;
    if ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1551;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1552;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1554;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1555;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 1556;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_guid" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1556;
                IINDEX = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1557;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1557;
                    ROOM [ IINDEX] . SROOMNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) ))  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1558;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bldg_rm_num" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1558;
                        ROOM [ IINDEX] . IROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1559;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1559;
                            ROOM [ IINDEX] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1560;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1560;
                                ROOM [ IINDEX] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1552;
            } 
        
        __context__.SourceCodeLine = 1563;
        MakeString ( TO_ROOM_TX__DOLLAR__ [ IINDEX] , "{{ROOMS; RoomID={0:d}:{1},{2:d},discrete_macro_mode={3:d},macro_take_mode={4:d}|}}", (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME , (ushort)ROOM[ IINDEX ].IROOMNUM, (ushort)ROOM[ IINDEX ].IDISCRETEMACROMODE, (ushort)ROOM[ IINDEX ].IMACROTAKEMODE) ; 
        __context__.SourceCodeLine = 1570;
        MakeString ( LISTFB__DOLLAR__ [ 11] , "{{ListVisFB:{0:d}=1,; ListTextFB:{1:d}={2},|;}}", (ushort)IINDEX, (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME ) ; 
        } 
    
    
    }
    
private void FPROCESSFILTER (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINE ) 
    { 
    ushort I = 0;
    ushort ITYPELIST = 0;
    ushort IERR = 0;
    
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    CrestronString SDATA;
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 1579;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1580;
    while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1582;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
        __context__.SourceCodeLine = 1583;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1585;
            STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1586;
            FILTER [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPVALUE , (int)( (Functions.Length( STEMPVALUE ) - 1) ) ))  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1588;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list_index" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1590;
                STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                __context__.SourceCodeLine = 1591;
                FILTER [ ITYPE] . ITEM [ IINDEX] . IGLOBALTOLIST = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                __context__.SourceCodeLine = 1592;
                FILTER [ ITYPE] . ITEM [ Functions.Atoi( STEMPVALUE )] . ILISTTOGLOBAL = (ushort) ( IINDEX ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1594;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "v_guid" , STEMPKEY ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1596;
                    STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                    __context__.SourceCodeLine = 1597;
                    while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1599;
                        I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        __context__.SourceCodeLine = 1600;
                        FILTER [ ITYPE] . IMEMBERLISTV [ IINDEX , I] = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1601;
                        STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                        __context__.SourceCodeLine = 1602;
                        FILTER [ ITYPE] . INUMOFMEMBERSV [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSV[ IINDEX ] + 1) ) ; 
                        __context__.SourceCodeLine = 1597;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1605;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "a_guid" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1607;
                        STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 1608;
                        while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1610;
                            I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1611;
                            FILTER [ ITYPE] . IMEMBERLISTA [ IINDEX , I] = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1612;
                            STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                            __context__.SourceCodeLine = 1613;
                            FILTER [ ITYPE] . INUMOFMEMBERSA [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSA[ IINDEX ] + 1) ) ; 
                            __context__.SourceCodeLine = 1608;
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1616;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "f_guid" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1618;
                            STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                            __context__.SourceCodeLine = 1619;
                            while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1621;
                                I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                __context__.SourceCodeLine = 1622;
                                FILTER [ ITYPE] . IMEMBERLISTF [ IINDEX , I] = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1623;
                                STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                                __context__.SourceCodeLine = 1624;
                                FILTER [ ITYPE] . INUMOFMEMBERSF [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSF[ IINDEX ] + 1) ) ; 
                                __context__.SourceCodeLine = 1619;
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1629;
                            Trace( "Global - in fProcessFilter - didn't catch key. GUID={0:d} key:\u0022{1}\u0022", (ushort)IINDEX, STEMPKEY ) ; 
                            __context__.SourceCodeLine = 1630;
                            IERR = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1580;
        } 
    
    __context__.SourceCodeLine = 1634;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1636;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1637;
        FILTER [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1638;
        FILTER [ ITYPE] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
        } 
    
    
    }
    
private void FPROCESSINIT (  SplusExecutionContext __context__, CrestronString STEMPINITDATA ) 
    { 
    ushort I = 0;
    ushort J = 0;
    ushort IINDEX = 0;
    ushort ITYPE = 0;
    
    CrestronString STEMPDATA;
    CrestronString STEMPDATA2;
    CrestronString STEMPHEADER;
    CrestronString STEMPGUID;
    CrestronString STEMPLINE;
    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    STEMPDATA2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPGUID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    
    
    __context__.SourceCodeLine = 1655;
    STEMPDATA2  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1656;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1657;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1659;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VSRC" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1659;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1660;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VDST" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1660;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1661;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ASRC" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1661;
                ITYPE = (ushort) ( 3 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1662;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ADST" , STEMPHEADER ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1662;
                    ITYPE = (ushort) ( 4 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1663;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCF" , STEMPHEADER ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1663;
                        ITYPE = (ushort) ( 5 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1664;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCG" , STEMPHEADER ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1664;
                            ITYPE = (ushort) ( 6 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1665;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTF" , STEMPHEADER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1665;
                                ITYPE = (ushort) ( 7 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1666;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTG" , STEMPHEADER ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1666;
                                    ITYPE = (ushort) ( 8 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1667;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1667;
                                        ITYPE = (ushort) ( 13 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1668;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MACRO" , STEMPHEADER ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1668;
                                            ITYPE = (ushort) ( 14 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1669;
                                            Trace( "Global - in fProcessInit - didn't catch header type - {0}", STEMPHEADER ) ; 
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
    
    __context__.SourceCodeLine = 1672;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
        { 
        __context__.SourceCodeLine = 1674;
        if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPDATA2 ))  ) ) 
            {
            __context__.SourceCodeLine = 1674;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ Functions.Atoi( STEMPDATA2 )] , "{0}", STEMPDATA2 ) ; 
            }
        
        } 
    
    __context__.SourceCodeLine = 1676;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1678;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1679;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1681;
            FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1683;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                { 
                __context__.SourceCodeLine = 1685;
                FPROCESSROOMS (  __context__ , (ushort)( ITYPE ), STEMPLINE) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1689;
                STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
                __context__.SourceCodeLine = 1690;
                IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                __context__.SourceCodeLine = 1691;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1693;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_6__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1695;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1696;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1697;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1698;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1699;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1700;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1701;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1702;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1705;
                    Trace( "error - MTRX fProcessInit, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1676;
        } 
    
    
    }
    
private void FUPDATEVTC (  SplusExecutionContext __context__, ushort IVTCSEL ) 
    { 
    ushort I = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1721;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1722;
    VTC_CTRL_SEL_UNITNAME__DOLLAR__  .UpdateValue ( SYS . VTC [ SYS.IVTCSEL] . SUNITNAME  ) ; 
    __context__.SourceCodeLine = 1723;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].IROOMRES)  ) ) 
        {
        __context__.SourceCodeLine = 1723;
        STEMP  .UpdateValue ( ROOM [ SYS.VTC[ IVTCSEL ].IROOMRES] . SROOMNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1724;
    VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1725;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1726;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICAMSELECT)  ) ) 
        {
        __context__.SourceCodeLine = 1726;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICAMSELECT] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1727;
    VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1728;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1729;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICONTENTSRC)  ) ) 
        {
        __context__.SourceCodeLine = 1729;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICONTENTSRC] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1730;
    VTC_CONTENTSHARE_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    
    }
    
object VTC_CTRL_SEL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1743;
        SYS . IVTCSEL = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1745;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)3; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 1745;
            VTC_CTRL_SEL_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1745;
            }
        
        __context__.SourceCodeLine = 1746;
        VTC_CTRL_SEL_FB [ SYS.IVTCSEL]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1748;
        FUPDATEVTC (  __context__ , (ushort)( SYS.IVTCSEL )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_SENDTOVTC_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IVTC = 0;
        ushort ISRCGUID = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        
        __context__.SourceCodeLine = 1758;
        IVTC = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1761;
        ISRCGUID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1762;
        STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
        __context__.SourceCodeLine = 1765;
        if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 1767;
            ISRCGUID = (ushort) ( SYS.CAM.IGUID[ SYS.ICAMSEL ] ) ; 
            __context__.SourceCodeLine = 1768;
            STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ SYS.ICAMSEL ]] . SGLOBALNAME  ) ; 
            } 
        
        __context__.SourceCodeLine = 1771;
        SYS . VTC [ IVTC] . ICAMSELECT = (ushort) ( ISRCGUID ) ; 
        __context__.SourceCodeLine = 1773;
        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ IVTC ].IVINGUID[ 1 ] ), (ushort)( SYS.VTC[ IVTC ].ICAMSELECT )) ; 
        __context__.SourceCodeLine = 1774;
        VTC_CAMSELECT_NAME__DOLLAR__ [ IVTC]  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1775;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVTC == SYS.IVTCSEL))  ) ) 
            {
            __context__.SourceCodeLine = 1775;
            VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_FOLDEDCTRL_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1782;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYS.UI.ISUB == 2))  ) ) 
            { 
            __context__.SourceCodeLine = 1784;
            if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
                { 
                __context__.SourceCodeLine = 1786;
                CAM_FOLDEDCMD [ SYS.ICAMSEL]  .Value = (ushort) ( CAM_FOLDEDCTRL  .UshortValue ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FMTRXTAKE (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1802;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1804;
        if ( Functions.TestForTrue  ( ( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST)  ) ) 
            { 
            __context__.SourceCodeLine = 1806;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1808;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1810;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1810;
                        FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1811;
                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1806;
                } 
            
            } 
        
        } 
    
    
    }
    
private void FMTRXCLEARROUTES (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1822;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1824;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1826;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                { 
                __context__.SourceCodeLine = 1828;
                if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1828;
                    FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1829;
                    FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1824;
            } 
        
        } 
    
    
    }
    
object MTRX_TAKE_ALL_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1845;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1846;
        FMTRXTAKE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_TAKE_VIDEO_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1851;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_TAKE_AUDIO_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1856;
        FMTRXTAKE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_ALL_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1861;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1862;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1863;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1864;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_VIDEO_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1868;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1869;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_AUDIO_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1873;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1874;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1878;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1879;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_VIDEO_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1883;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_AUDIO_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1887;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_CLEAR_ROUTE_ALL_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1891;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1892;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LIST_ITEMCLICKED_OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort ILIST = 0;
        ushort IINDEX = 0;
        ushort IPREVIOUSROOM = 0;
        
        ushort IERR = 0;
        
        
        __context__.SourceCodeLine = 1905;
        IERR = (ushort) ( 10000 ) ; 
        __context__.SourceCodeLine = 1906;
        ILIST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1907;
        IINDEX = (ushort) ( LIST_ITEMCLICKED[ ILIST ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1909;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ) ) && Functions.TestForTrue ( IINDEX )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1909;
            IINDEX = (ushort) ( FILTER[ ILIST ].ITEM[ IINDEX ].ILISTTOGLOBAL ) ; 
            }
        
        __context__.SourceCodeLine = 1911;
        
            {
            int __SPLS_TMPVAR__SWTCH_7__ = ((int)ILIST);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1913;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1914;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1915;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1916;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 5) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1917;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 6) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1918;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 7) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1919;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 8) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1920;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1923;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_8__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1928;
                                IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                                __context__.SourceCodeLine = 1930;
                                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1932;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                    __context__.SourceCodeLine = 1933;
                                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__1 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__1 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                        { 
                                        __context__.SourceCodeLine = 1936;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 1 ].ITEM[ SYS.CAM.IGUID[ I ] ].IRMASS == IINDEX))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1936;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1937;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 1933;
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1942;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 1943;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        {
                                        __context__.SourceCodeLine = 1943;
                                        LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                        __context__.SourceCodeLine = 1943;
                                        }
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 1945;
                                FUPDATELISTVIS (  __context__ , (ushort)( 12 ), (ushort)( 0 )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1949;
                                FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                                __context__.SourceCodeLine = 1951;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1953;
                                    IPREVIOUSROOM = (ushort) ( SYS.VTC[ SYS.IVTCSEL ].IROOMRES ) ; 
                                    __context__.SourceCodeLine = 1954;
                                    SYS . VTC [ SYS.IVTCSEL] . IROOMRES = (ushort) ( IINDEX ) ; 
                                    __context__.SourceCodeLine = 1955;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1955;
                                        ROOM [ IINDEX] . IVTCASSIGNMENT = (ushort) ( SYS.IVTCSEL ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 1956;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1956;
                                        ROOM [ IPREVIOUSROOM] . IVTCASSIGNMENT = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 1959;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IPREVIOUSROOM ) ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        { 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1964;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPREVIOUSROOM == IINDEX))  ) ) 
                                            { 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1969;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.BoolToInt (IPREVIOUSROOM != IINDEX) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1972;
                                                Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                                __context__.SourceCodeLine = 1974;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1975;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1977;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1978;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 2 ] ), (ushort)( 0 )) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 1982;
                                    if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1985;
                                        Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                        __context__.SourceCodeLine = 1987;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 1988;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 1993;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 1994;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 1996;
                                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 1 ] )) ; 
                                        __context__.SourceCodeLine = 1997;
                                        if ( Functions.TestForTrue  ( ( SYS.VTC[ SYS.IVTCSEL ].IDUALDISPLAY)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1999;
                                            FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 2 ] )) ; 
                                            } 
                                        
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 2009;
                    IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    __context__.SourceCodeLine = 2010;
                    SYS . ICAMSEL = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 2012;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_9__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2017;
                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.IVDSTPANELGUID ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2021;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2023;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 2025;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( SYS.CAM.IGUID[ IINDEX ] ) ; 
                                        __context__.SourceCodeLine = 2026;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                        __context__.SourceCodeLine = 2027;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        __context__.SourceCodeLine = 2028;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 2032;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 2033;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                        __context__.SourceCodeLine = 2034;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        __context__.SourceCodeLine = 2035;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2042;
        if ( Functions.TestForTrue  ( ( IERR)  ) ) 
            { 
            __context__.SourceCodeLine = 2044;
            
                {
                int __SPLS_TMPVAR__SWTCH_10__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2046;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2047;
                        FCONFIGUREGROUP (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2048;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2049;
                        FCONFIGUREGROUP (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    } 
                    
                }
                
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DATAINIT_RX__DOLLAR___OnChange_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20000, this );
        
        
        __context__.SourceCodeLine = 2059;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 2061;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 2062;
            FPROCESSINIT (  __context__ , STEMP) ; 
            __context__.SourceCodeLine = 2059;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UI_PAGE_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2072;
        SYS . UI . IPAGE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UI_SUB_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2077;
        SYS . UI . ISUB = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        
        
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
        
        __context__.SourceCodeLine = 2096;
        SYS . SBLANKSRCTEXT  .UpdateValue ( "---"  ) ; 
        __context__.SourceCodeLine = 2098;
        SYS . VTC [ 1] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit01"  ) ; 
        __context__.SourceCodeLine = 2099;
        SYS . VTC [ 2] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit02"  ) ; 
        __context__.SourceCodeLine = 2100;
        SYS . VTC [ 3] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit03"  ) ; 
        __context__.SourceCodeLine = 2102;
        LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2103;
        LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2104;
        LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2105;
        LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2107;
        LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2108;
        LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2109;
        LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2110;
        LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2111;
        LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2112;
        LIST [ 7] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2113;
        LIST [ 12] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2114;
        LIST [ 13] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2116;
        FILTER [ 6] . IMEMBERLISTFINDEX = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 2117;
        FILTER [ 8] . IMEMBERLISTFINDEX = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 2119;
        FILTER [ 5] . IMEMBERLISTVINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2120;
        FILTER [ 5] . IMEMBERLISTAINDEX = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 2122;
        FILTER [ 7] . IMEMBERLISTVINDEX = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2123;
        FILTER [ 7] . IMEMBERLISTAINDEX = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 2125;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2127;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2130;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 350 ) ; 
            __context__.SourceCodeLine = 2127;
            } 
        
        __context__.SourceCodeLine = 2132;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 3 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)4; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 2135;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 400 ) ; 
            __context__.SourceCodeLine = 2132;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    SYS  = new STSYSTEM( this, true );
    SYS .PopulateCustomAttributeList( false );
    LIST  = new STLIST[ 14 ];
    for( uint i = 0; i < 14; i++ )
    {
        LIST [i] = new STLIST( this, true );
        LIST [i].PopulateCustomAttributeList( false );
        
    }
    FILTER  = new STFILTER[ 9 ];
    for( uint i = 0; i < 9; i++ )
    {
        FILTER [i] = new STFILTER( this, true );
        FILTER [i].PopulateCustomAttributeList( false );
        
    }
    ROOM  = new STROOM[ 31 ];
    for( uint i = 0; i < 31; i++ )
    {
        ROOM [i] = new STROOM( this, true );
        ROOM [i].PopulateCustomAttributeList( false );
        
    }
    
    MTRX_TAKE_ALL = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_TAKE_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_TAKE_ALL__DigitalInput__, MTRX_TAKE_ALL );
    
    MTRX_TAKE_VIDEO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_TAKE_VIDEO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_TAKE_VIDEO__DigitalInput__, MTRX_TAKE_VIDEO );
    
    MTRX_TAKE_AUDIO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_TAKE_AUDIO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_TAKE_AUDIO__DigitalInput__, MTRX_TAKE_AUDIO );
    
    MTRX_DESELECT_ALL = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_DESELECT_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_DESELECT_ALL__DigitalInput__, MTRX_DESELECT_ALL );
    
    MTRX_DESELECT_VIDEO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_DESELECT_VIDEO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_DESELECT_VIDEO__DigitalInput__, MTRX_DESELECT_VIDEO );
    
    MTRX_DESELECT_AUDIO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_DESELECT_AUDIO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_DESELECT_AUDIO__DigitalInput__, MTRX_DESELECT_AUDIO );
    
    MTRX_SELECT_ALL = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_SELECT_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_SELECT_ALL__DigitalInput__, MTRX_SELECT_ALL );
    
    MTRX_SELECT_ALL_VIDEO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_SELECT_ALL_VIDEO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_SELECT_ALL_VIDEO__DigitalInput__, MTRX_SELECT_ALL_VIDEO );
    
    MTRX_SELECT_ALL_AUDIO = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_SELECT_ALL_AUDIO__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_SELECT_ALL_AUDIO__DigitalInput__, MTRX_SELECT_ALL_AUDIO );
    
    MTRX_CLEAR_ROUTE_ALL = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_CLEAR_ROUTE_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( MTRX_CLEAR_ROUTE_ALL__DigitalInput__, MTRX_CLEAR_ROUTE_ALL );
    
    UI_PAGE = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        UI_PAGE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( UI_PAGE__DigitalInput__ + i, UI_PAGE__DigitalInput__, this );
        m_DigitalInputList.Add( UI_PAGE__DigitalInput__ + i, UI_PAGE[i+1] );
    }
    
    UI_SUB = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        UI_SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( UI_SUB__DigitalInput__ + i, UI_SUB__DigitalInput__, this );
        m_DigitalInputList.Add( UI_SUB__DigitalInput__ + i, UI_SUB[i+1] );
    }
    
    CAM_SENDTOVTC = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        CAM_SENDTOVTC[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_SENDTOVTC__DigitalInput__ + i, CAM_SENDTOVTC__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_SENDTOVTC__DigitalInput__ + i, CAM_SENDTOVTC[i+1] );
    }
    
    CAM_SAVE = new InOutArray<DigitalInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        CAM_SAVE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_SAVE__DigitalInput__ + i, CAM_SAVE__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_SAVE__DigitalInput__ + i, CAM_SAVE[i+1] );
    }
    
    VTC_CTRL_SEL = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_CTRL_SEL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VTC_CTRL_SEL__DigitalInput__ + i, VTC_CTRL_SEL__DigitalInput__, this );
        m_DigitalInputList.Add( VTC_CTRL_SEL__DigitalInput__ + i, VTC_CTRL_SEL[i+1] );
    }
    
    VTC_DISPLAYSINGLE = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_DISPLAYSINGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VTC_DISPLAYSINGLE__DigitalInput__ + i, VTC_DISPLAYSINGLE__DigitalInput__, this );
        m_DigitalInputList.Add( VTC_DISPLAYSINGLE__DigitalInput__ + i, VTC_DISPLAYSINGLE[i+1] );
    }
    
    VTC_DISPLAYDUAL = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_DISPLAYDUAL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VTC_DISPLAYDUAL__DigitalInput__ + i, VTC_DISPLAYDUAL__DigitalInput__, this );
        m_DigitalInputList.Add( VTC_DISPLAYDUAL__DigitalInput__ + i, VTC_DISPLAYDUAL[i+1] );
    }
    
    CAM_POWERON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( CAM_POWERON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( CAM_POWERON_FB__DigitalOutput__, CAM_POWERON_FB );
    
    CAM_POWEROFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( CAM_POWEROFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( CAM_POWEROFF_FB__DigitalOutput__, CAM_POWEROFF_FB );
    
    CAM_SAVE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( CAM_SAVE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( CAM_SAVE_FB__DigitalOutput__, CAM_SAVE_FB );
    
    VTC_ROOMRES_POPRESET = new Crestron.Logos.SplusObjects.DigitalOutput( VTC_ROOMRES_POPRESET__DigitalOutput__, this );
    m_DigitalOutputList.Add( VTC_ROOMRES_POPRESET__DigitalOutput__, VTC_ROOMRES_POPRESET );
    
    VTC_CAMSEL_POPRESET = new Crestron.Logos.SplusObjects.DigitalOutput( VTC_CAMSEL_POPRESET__DigitalOutput__, this );
    m_DigitalOutputList.Add( VTC_CAMSEL_POPRESET__DigitalOutput__, VTC_CAMSEL_POPRESET );
    
    VTC_CONTENT_POPRESET = new Crestron.Logos.SplusObjects.DigitalOutput( VTC_CONTENT_POPRESET__DigitalOutput__, this );
    m_DigitalOutputList.Add( VTC_CONTENT_POPRESET__DigitalOutput__, VTC_CONTENT_POPRESET );
    
    VTC_CTRL_SEL_FB = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_CTRL_SEL_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VTC_CTRL_SEL_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( VTC_CTRL_SEL_FB__DigitalOutput__ + i, VTC_CTRL_SEL_FB[i+1] );
    }
    
    VTC_ENDALLCALLS = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_ENDALLCALLS[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VTC_ENDALLCALLS__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( VTC_ENDALLCALLS__DigitalOutput__ + i, VTC_ENDALLCALLS[i+1] );
    }
    
    CAM_FOLDEDCTRL = new Crestron.Logos.SplusObjects.AnalogInput( CAM_FOLDEDCTRL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CAM_FOLDEDCTRL__AnalogSerialInput__, CAM_FOLDEDCTRL );
    
    LIST_ITEMCLICKED = new InOutArray<AnalogInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        LIST_ITEMCLICKED[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LIST_ITEMCLICKED__AnalogSerialInput__ + i, LIST_ITEMCLICKED__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LIST_ITEMCLICKED__AnalogSerialInput__ + i, LIST_ITEMCLICKED[i+1] );
    }
    
    MTRX_V_IN = new InOutArray<AnalogInput>( 350, this );
    for( uint i = 0; i < 350; i++ )
    {
        MTRX_V_IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_V_IN__AnalogSerialInput__ + i, MTRX_V_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_V_IN__AnalogSerialInput__ + i, MTRX_V_IN[i+1] );
    }
    
    MTRX_A_IN = new InOutArray<AnalogInput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        MTRX_A_IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_A_IN__AnalogSerialInput__ + i, MTRX_A_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_A_IN__AnalogSerialInput__ + i, MTRX_A_IN[i+1] );
    }
    
    LIST_NUMOFITEMS = new InOutArray<AnalogOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        LIST_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, LIST_NUMOFITEMS[i+1] );
    }
    
    MTRX_V_OUT = new InOutArray<AnalogOutput>( 350, this );
    for( uint i = 0; i < 350; i++ )
    {
        MTRX_V_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_V_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_V_OUT__AnalogSerialOutput__ + i, MTRX_V_OUT[i+1] );
    }
    
    MTRX_A_OUT = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        MTRX_A_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_A_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_A_OUT__AnalogSerialOutput__ + i, MTRX_A_OUT[i+1] );
    }
    
    CAM_FOLDEDCMD = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        CAM_FOLDEDCMD[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CAM_FOLDEDCMD__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CAM_FOLDEDCMD__AnalogSerialOutput__ + i, CAM_FOLDEDCMD[i+1] );
    }
    
    DISPLAY_FOLDEDCMD = new InOutArray<AnalogOutput>( 200, this );
    for( uint i = 0; i < 200; i++ )
    {
        DISPLAY_FOLDEDCMD[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DISPLAY_FOLDEDCMD__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DISPLAY_FOLDEDCMD__AnalogSerialOutput__ + i, DISPLAY_FOLDEDCMD[i+1] );
    }
    
    CAM_PRESETTEXT__DOLLAR___IN = new Crestron.Logos.SplusObjects.StringInput( CAM_PRESETTEXT__DOLLAR___IN__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( CAM_PRESETTEXT__DOLLAR___IN__AnalogSerialInput__, CAM_PRESETTEXT__DOLLAR___IN );
    
    FROM_ROOM_RX__DOLLAR__ = new InOutArray<StringInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        FROM_ROOM_RX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ + i, FROM_ROOM_RX__DOLLAR____AnalogSerialInput__, 1000, this );
        m_StringInputList.Add( FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ + i, FROM_ROOM_RX__DOLLAR__[i+1] );
    }
    
    VTC_CTRL_SEL_UNITNAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( VTC_CTRL_SEL_UNITNAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( VTC_CTRL_SEL_UNITNAME__DOLLAR____AnalogSerialOutput__, VTC_CTRL_SEL_UNITNAME__DOLLAR__ );
    
    USB_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( USB_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( USB_TX__DOLLAR____AnalogSerialOutput__, USB_TX__DOLLAR__ );
    
    CAM_PRESETTEXT__DOLLAR___OUT = new Crestron.Logos.SplusObjects.StringOutput( CAM_PRESETTEXT__DOLLAR___OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CAM_PRESETTEXT__DOLLAR___OUT__AnalogSerialOutput__, CAM_PRESETTEXT__DOLLAR___OUT );
    
    CAM_LIST_SELECTEDCAM__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CAM_LIST_SELECTEDCAM__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( CAM_LIST_SELECTEDCAM__DOLLAR____AnalogSerialOutput__, CAM_LIST_SELECTEDCAM__DOLLAR__ );
    
    ROOMS_LIST_SELECTEDROOM__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ROOMS_LIST_SELECTEDROOM__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROOMS_LIST_SELECTEDROOM__DOLLAR____AnalogSerialOutput__, ROOMS_LIST_SELECTEDROOM__DOLLAR__ );
    
    VTC_ROOMRES_NAME__DOLLAR___SEL = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        VTC_ROOMRES_NAME__DOLLAR___SEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_ROOMRES_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_ROOMRES_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, VTC_ROOMRES_NAME__DOLLAR___SEL[i+1] );
    }
    
    VTC_ROOMRES_NAME__DOLLAR__ = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_ROOMRES_NAME__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_ROOMRES_NAME__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_ROOMRES_NAME__DOLLAR____AnalogSerialOutput__ + i, VTC_ROOMRES_NAME__DOLLAR__[i+1] );
    }
    
    VTC_CAMSELECT_NAME__DOLLAR___SEL = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        VTC_CAMSELECT_NAME__DOLLAR___SEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_CAMSELECT_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_CAMSELECT_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, VTC_CAMSELECT_NAME__DOLLAR___SEL[i+1] );
    }
    
    VTC_CAMSELECT_NAME__DOLLAR__ = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_CAMSELECT_NAME__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_CAMSELECT_NAME__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_CAMSELECT_NAME__DOLLAR____AnalogSerialOutput__ + i, VTC_CAMSELECT_NAME__DOLLAR__[i+1] );
    }
    
    VTC_CONTENTSHARE_NAME__DOLLAR___SEL = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        VTC_CONTENTSHARE_NAME__DOLLAR___SEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_CONTENTSHARE_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_CONTENTSHARE_NAME__DOLLAR___SEL__AnalogSerialOutput__ + i, VTC_CONTENTSHARE_NAME__DOLLAR___SEL[i+1] );
    }
    
    VTC_CONTENTSHARE_NAME__DOLLAR__ = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        VTC_CONTENTSHARE_NAME__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VTC_CONTENTSHARE_NAME__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( VTC_CONTENTSHARE_NAME__DOLLAR____AnalogSerialOutput__ + i, VTC_CONTENTSHARE_NAME__DOLLAR__[i+1] );
    }
    
    LISTFB__DOLLAR__ = new InOutArray<StringOutput>( 13, this );
    for( uint i = 0; i < 13; i++ )
    {
        LISTFB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LISTFB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LISTFB__DOLLAR____AnalogSerialOutput__ + i, LISTFB__DOLLAR__[i+1] );
    }
    
    CAM_DATAINIT__DOLLAR__ = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        CAM_DATAINIT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CAM_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CAM_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, CAM_DATAINIT__DOLLAR__[i+1] );
    }
    
    DISPLAY_DATAINIT__DOLLAR__ = new InOutArray<StringOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        DISPLAY_DATAINIT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DISPLAY_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DISPLAY_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, DISPLAY_DATAINIT__DOLLAR__[i+1] );
    }
    
    RELAY_DATAINIT__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RELAY_DATAINIT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( RELAY_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( RELAY_DATAINIT__DOLLAR____AnalogSerialOutput__ + i, RELAY_DATAINIT__DOLLAR__[i+1] );
    }
    
    TO_ROOM_TX__DOLLAR__ = new InOutArray<StringOutput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        TO_ROOM_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, TO_ROOM_TX__DOLLAR__[i+1] );
    }
    
    DATAINIT_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( DATAINIT_RX__DOLLAR____AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( DATAINIT_RX__DOLLAR____AnalogSerialInput__, DATAINIT_RX__DOLLAR__ );
    
    
    for( uint i = 0; i < 30; i++ )
        FROM_ROOM_RX__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_ROOM_RX__DOLLAR___OnChange_0, false ) );
        
    for( uint i = 0; i < 350; i++ )
        MTRX_V_IN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_V_IN_OnChange_1, false ) );
        
    for( uint i = 0; i < 500; i++ )
        MTRX_A_IN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_A_IN_OnChange_2, false ) );
        
    for( uint i = 0; i < 3; i++ )
        VTC_CTRL_SEL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VTC_CTRL_SEL_OnPush_3, false ) );
        
    for( uint i = 0; i < 3; i++ )
        CAM_SENDTOVTC[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_SENDTOVTC_OnPush_4, false ) );
        
    CAM_FOLDEDCTRL.OnAnalogChange.Add( new InputChangeHandlerWrapper( CAM_FOLDEDCTRL_OnChange_5, false ) );
    MTRX_TAKE_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_ALL_OnPush_6, false ) );
    MTRX_TAKE_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_VIDEO_OnPush_7, false ) );
    MTRX_TAKE_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_AUDIO_OnPush_8, false ) );
    MTRX_DESELECT_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_ALL_OnPush_9, false ) );
    MTRX_DESELECT_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_VIDEO_OnPush_10, false ) );
    MTRX_DESELECT_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_AUDIO_OnPush_11, false ) );
    MTRX_SELECT_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_OnPush_12, false ) );
    MTRX_SELECT_ALL_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_VIDEO_OnPush_13, false ) );
    MTRX_SELECT_ALL_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_AUDIO_OnPush_14, false ) );
    MTRX_CLEAR_ROUTE_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_CLEAR_ROUTE_ALL_OnPush_15, false ) );
    for( uint i = 0; i < 12; i++ )
        LIST_ITEMCLICKED[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( LIST_ITEMCLICKED_OnChange_16, false ) );
        
    DATAINIT_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR___OnChange_17, true ) );
    for( uint i = 0; i < 5; i++ )
        UI_PAGE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( UI_PAGE_OnPush_18, false ) );
        
    for( uint i = 0; i < 5; i++ )
        UI_SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( UI_SUB_OnPush_19, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_62 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint MTRX_TAKE_ALL__DigitalInput__ = 0;
const uint MTRX_TAKE_VIDEO__DigitalInput__ = 1;
const uint MTRX_TAKE_AUDIO__DigitalInput__ = 2;
const uint MTRX_DESELECT_ALL__DigitalInput__ = 3;
const uint MTRX_DESELECT_VIDEO__DigitalInput__ = 4;
const uint MTRX_DESELECT_AUDIO__DigitalInput__ = 5;
const uint MTRX_SELECT_ALL__DigitalInput__ = 6;
const uint MTRX_SELECT_ALL_VIDEO__DigitalInput__ = 7;
const uint MTRX_SELECT_ALL_AUDIO__DigitalInput__ = 8;
const uint MTRX_CLEAR_ROUTE_ALL__DigitalInput__ = 9;
const uint UI_PAGE__DigitalInput__ = 10;
const uint UI_SUB__DigitalInput__ = 15;
const uint CAM_SENDTOVTC__DigitalInput__ = 20;
const uint CAM_SAVE__DigitalInput__ = 23;
const uint VTC_CTRL_SEL__DigitalInput__ = 24;
const uint VTC_DISPLAYSINGLE__DigitalInput__ = 27;
const uint VTC_DISPLAYDUAL__DigitalInput__ = 30;
const uint CAM_FOLDEDCTRL__AnalogSerialInput__ = 0;
const uint CAM_PRESETTEXT__DOLLAR___IN__AnalogSerialInput__ = 1;
const uint DATAINIT_RX__DOLLAR____AnalogSerialInput__ = 2;
const uint FROM_ROOM_RX__DOLLAR____AnalogSerialInput__ = 3;
const uint LIST_ITEMCLICKED__AnalogSerialInput__ = 33;
const uint MTRX_V_IN__AnalogSerialInput__ = 45;
const uint MTRX_A_IN__AnalogSerialInput__ = 395;
const uint CAM_POWERON_FB__DigitalOutput__ = 0;
const uint CAM_POWEROFF_FB__DigitalOutput__ = 1;
const uint CAM_SAVE_FB__DigitalOutput__ = 2;
const uint VTC_ROOMRES_POPRESET__DigitalOutput__ = 3;
const uint VTC_CAMSEL_POPRESET__DigitalOutput__ = 4;
const uint VTC_CONTENT_POPRESET__DigitalOutput__ = 5;
const uint VTC_CTRL_SEL_FB__DigitalOutput__ = 6;
const uint VTC_ENDALLCALLS__DigitalOutput__ = 9;
const uint VTC_CTRL_SEL_UNITNAME__DOLLAR____AnalogSerialOutput__ = 0;
const uint USB_TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint CAM_PRESETTEXT__DOLLAR___OUT__AnalogSerialOutput__ = 2;
const uint CAM_LIST_SELECTEDCAM__DOLLAR____AnalogSerialOutput__ = 3;
const uint ROOMS_LIST_SELECTEDROOM__DOLLAR____AnalogSerialOutput__ = 4;
const uint VTC_ROOMRES_NAME__DOLLAR___SEL__AnalogSerialOutput__ = 5;
const uint VTC_ROOMRES_NAME__DOLLAR____AnalogSerialOutput__ = 6;
const uint VTC_CAMSELECT_NAME__DOLLAR___SEL__AnalogSerialOutput__ = 9;
const uint VTC_CAMSELECT_NAME__DOLLAR____AnalogSerialOutput__ = 10;
const uint VTC_CONTENTSHARE_NAME__DOLLAR___SEL__AnalogSerialOutput__ = 13;
const uint VTC_CONTENTSHARE_NAME__DOLLAR____AnalogSerialOutput__ = 14;
const uint LISTFB__DOLLAR____AnalogSerialOutput__ = 17;
const uint CAM_DATAINIT__DOLLAR____AnalogSerialOutput__ = 30;
const uint DISPLAY_DATAINIT__DOLLAR____AnalogSerialOutput__ = 31;
const uint RELAY_DATAINIT__DOLLAR____AnalogSerialOutput__ = 37;
const uint TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ = 39;
const uint LIST_NUMOFITEMS__AnalogSerialOutput__ = 69;
const uint MTRX_V_OUT__AnalogSerialOutput__ = 81;
const uint MTRX_A_OUT__AnalogSerialOutput__ = 431;
const uint CAM_FOLDEDCMD__AnalogSerialOutput__ = 931;
const uint DISPLAY_FOLDEDCMD__AnalogSerialOutput__ = 981;

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
public class STRELAY : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IRELAYINDEX = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IISINITINDEX = 0;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SIPADDRESS;
    
    
    public STRELAY( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SIPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STLISTITEM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IITEMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IFB = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  IVIS = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IICON = 0;
    
    [SplusStructAttribute(4, false, false)]
    public CrestronString  [] STEXT;
    
    [SplusStructAttribute(5, false, false)]
    public CrestronString  SGLOBALNAME;
    
    [SplusStructAttribute(6, false, false)]
    public CrestronString  SLOCALNAME;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IGLOBALTOLIST = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  ILISTTOGLOBAL = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IRMASS = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  ILOCALID = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  IFUNCTIONID = 0;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  IFILTERID = 0;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IGROUPID = 0;
    
    [SplusStructAttribute(14, false, false)]
    public CrestronString  SIPADDRESS;
    
    [SplusStructAttribute(15, false, false)]
    public ushort  ICOMPORT = 0;
    
    [SplusStructAttribute(16, false, false)]
    public ushort  IPROCESSORINDEX = 0;
    
    [SplusStructAttribute(17, false, false)]
    public ushort  IISCAMERA = 0;
    
    [SplusStructAttribute(18, false, false)]
    public ushort  ICAMLOCALID = 0;
    
    [SplusStructAttribute(19, false, false)]
    public ushort  ICAMGUID = 0;
    
    [SplusStructAttribute(20, false, false)]
    public ushort  IISDISPLAY = 0;
    
    [SplusStructAttribute(21, false, false)]
    public ushort  IDISPLAYLOCALID = 0;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  IDISPLAYGUID = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IRELAYPROCESSOR = 0;
    
    public STRELAY [] RELAYON;
    
    public STRELAY [] RELAYOFF;
    
    [SplusStructAttribute(24, false, false)]
    public ushort  IRELAYONNUMOF = 0;
    
    [SplusStructAttribute(25, false, false)]
    public ushort  IRELAYOFFNUMOF = 0;
    
    [SplusStructAttribute(26, false, false)]
    public ushort  IISVTC = 0;
    
    [SplusStructAttribute(27, false, false)]
    public ushort  IVTCIO = 0;
    
    [SplusStructAttribute(28, false, false)]
    public CrestronString  SDEVICETYPE;
    
    [SplusStructAttribute(29, false, false)]
    public CrestronString  SUSBADDR;
    
    [SplusStructAttribute(30, false, false)]
    public ushort  IISUSB = 0;
    
    [SplusStructAttribute(31, false, false)]
    public ushort  IISVIRTUAL = 0;
    
    [SplusStructAttribute(32, false, false)]
    public ushort  IVLINK = 0;
    
    [SplusStructAttribute(33, false, false)]
    public CrestronString  SCMDDATA;
    
    [SplusStructAttribute(34, false, false)]
    public ushort  ICMDDATA = 0;
    
    [SplusStructAttribute(35, false, false)]
    public ushort  IROUTEDSRC = 0;
    
    [SplusStructAttribute(36, false, false)]
    public ushort  ILASTROUTEREQ = 0;
    
    
    public STLISTITEM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SIPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SDEVICETYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SUSBADDR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, Owner );
        SCMDDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        STEXT  = new CrestronString[ 5 ];
        for( uint i = 0; i < 5; i++ )
            STEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        RELAYON  = new STRELAY[ 11 ];
        for( uint i = 0; i < 11; i++ )
        {
            RELAYON [i] = new STRELAY( Owner, true );
            
        }
        RELAYOFF  = new STRELAY[ 11 ];
        for( uint i = 0; i < 11; i++ )
        {
            RELAYOFF [i] = new STRELAY( Owner, true );
            
        }
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STFILTER : SplusStructureBase
{

    public STLISTITEM [] ITEM;
    
    [SplusStructAttribute(0, false, false)]
    public ushort  IITEMSELECTEDLAST = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IHIGHESTLISTINDEX = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] INUMOFMEMBERSV;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  [] INUMOFMEMBERSA;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  [] INUMOFMEMBERSF;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  [,] IMEMBERLISTV;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  [,] IMEMBERLISTA;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  [,] IMEMBERLISTF;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IMEMBERLISTVINDEX = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IMEMBERLISTAINDEX = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IMEMBERLISTFINDEX = 0;
    
    
    public STFILTER( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        INUMOFMEMBERSV  = new ushort[ 101 ];
        INUMOFMEMBERSA  = new ushort[ 101 ];
        INUMOFMEMBERSF  = new ushort[ 101 ];
        IMEMBERLISTV  = new ushort[ 101,401 ];
        IMEMBERLISTA  = new ushort[ 101,401 ];
        IMEMBERLISTF  = new ushort[ 31,101 ];
        ITEM  = new STLISTITEM[ 101 ];
        for( uint i = 0; i < 101; i++ )
        {
            ITEM [i] = new STLISTITEM( Owner, true );
            
        }
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STLIST : SplusStructureBase
{

    public STLISTITEM [] ITEM;
    
    [SplusStructAttribute(0, false, false)]
    public ushort  IHIGHESTLISTINDEX = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  INUMOFTEXTCOLUMNS = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  ILISTUSESFB = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  ILISTUSESVIS = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  ILISTUSESICON = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  ILISTUSESTEXT = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  [] IGLOBALTOLOCAL;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IINITIALIZED = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IITEMSELECTEDLAST = 0;
    
    
    public STLIST( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IGLOBALTOLOCAL  = new ushort[ 401 ];
        ITEM  = new STLISTITEM[ 401 ];
        for( uint i = 0; i < 401; i++ )
        {
            ITEM [i] = new STLISTITEM( Owner, true );
            
        }
        
        
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
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IDISCRETEMACROMODE = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IMACROTAKEMODE = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  [] IVIRTUALVDSTGUID;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IVTCASSIGNMENT = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  INUMOFCAMS = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  INUMOFDISPLAYS = 0;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IVIRTUALVDSTGUID  = new ushort[ 11 ];
        SROOMNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SROOMNAMESHORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STCAM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  INUMOFCAMS = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  [] IGUID;
    
    
    public STCAM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IGUID  = new ushort[ 51 ];
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STDISPLAY : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  INUMOFDISPLAYS = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  [] IGUID;
    
    
    public STDISPLAY( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IGUID  = new ushort[ 201 ];
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STUI : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IPAGE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ISUB = 0;
    
    
    public STUI( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STVTC : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IDUALDISPLAY = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  [] IVOUTGUID;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] IVINGUID;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IROOMRES = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  ICAMSELECT = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  ICONTENTSRC = 0;
    
    [SplusStructAttribute(6, false, false)]
    public CrestronString  SUNITNAME;
    
    
    public STVTC( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IVOUTGUID  = new ushort[ 3 ];
        IVINGUID  = new ushort[ 4 ];
        SUNITNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STSYSTEM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  SBLANKSRCTEXT;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ICAMSEL = 0;
    
    public STCAM CAM;
    
    public STDISPLAY DISPLAY;
    
    public STUI UI;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  IROOMSEL = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  INUMOFROOMS = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IVTCSEL = 0;
    
    public STVTC [] VTC;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IVDSTPANELGUID = 0;
    
    
    public STSYSTEM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SBLANKSRCTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, Owner );
        CAM  = new STCAM( __caller__, true );
        DISPLAY  = new STDISPLAY( __caller__, true );
        UI  = new STUI( __caller__, true );
        VTC  = new STVTC[ 4 ];
        for( uint i = 0; i < 4; i++ )
        {
            VTC [i] = new STVTC( Owner, true );
            
        }
        
        
    }
    
}

}
