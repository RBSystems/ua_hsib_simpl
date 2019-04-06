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

namespace UserModule_L3_UA_HSIB_GLOBALMST_V1_0_63
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_63 : SplusObject
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
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DATAINIT_DONE;
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
            
            __context__.SourceCodeLine = 347;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 347;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 348;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 357;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 357;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 359;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 360;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 361;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 363;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 363;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 364;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 361;
                } 
            
            __context__.SourceCodeLine = 366;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 367;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 367;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 369;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 370;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 371;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 373;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 373;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 374;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 375;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 376;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 371;
                } 
            
            __context__.SourceCodeLine = 379;
            return ( SDATA ) ; 
            
            }
            
        private ushort FHIGHESTLISTINDEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 385;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 387;
                LIST [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( LIST[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                __context__.SourceCodeLine = 388;
                return (ushort)( LIST[ ILIST ].IHIGHESTLISTINDEX) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 390;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 392;
                    FILTER [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( FILTER[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                    __context__.SourceCodeLine = 393;
                    return (ushort)( FILTER[ ILIST ].IHIGHESTLISTINDEX) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 395;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 11))  ) ) 
                        {
                        __context__.SourceCodeLine = 395;
                        return (ushort)( SYS.INUMOFROOMS) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 396;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 12))  ) ) 
                            {
                            __context__.SourceCodeLine = 396;
                            return (ushort)( SYS.CAM.INUMOFCAMS) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 397;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 397;
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
            
            __context__.SourceCodeLine = 402;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 404;
                        return ( "MTRX_VSRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 405;
                        return ( "MTRX_VDST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 406;
                        return ( "MTRX_ASRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 407;
                        return ( "MTRX_ADST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 408;
                        return ( "MTRX_SRCF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 409;
                        return ( "MTRX_SRCG;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 410;
                        return ( "MTRX_DSTF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 411;
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
            
            
            __context__.SourceCodeLine = 427;
            if ( Functions.TestForTrue  ( ( IINC)  ) ) 
                {
                __context__.SourceCodeLine = 427;
                LIUSB_CMDINDEX = (uint) ( (LIUSB_CMDINDEX + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 429;
            MakeString ( STEMP , "{0}{1}{2}{3}", Functions.Chr (  (int) ( Functions.High( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) ) ; 
            __context__.SourceCodeLine = 434;
            return ( STEMP ) ; 
            
            }
            
        private void FUSBSENDROUTEKILL (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 441;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 446;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 448;
                SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
                __context__.SourceCodeLine = 449;
                MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u000a{1}{2}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
                } 
            
            __context__.SourceCodeLine = 454;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                { 
                __context__.SourceCodeLine = 456;
                SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
                __context__.SourceCodeLine = 457;
                MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u000a{1}{2}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
                } 
            
            
            }
            
        private void FUSBSENDROUTETAKE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 469;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 471;
            FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
            __context__.SourceCodeLine = 473;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 474;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
            __context__.SourceCodeLine = 481;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 482;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 494;
            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IISUSB)  ) ) 
                { 
                __context__.SourceCodeLine = 496;
                if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 498;
                    if ( Functions.TestForTrue  ( ( LIST[ 1 ].ITEM[ ISRC ].IISUSB)  ) ) 
                        { 
                        __context__.SourceCodeLine = 500;
                        FUSBSENDROUTETAKE (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 504;
                        FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 509;
                    FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( 0 )) ; 
                    } 
                
                } 
            
            
            }
            
        private void FMTRXSENDROUTE (  SplusExecutionContext __context__, ushort ILIST , ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 517;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 519;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 523;
                            LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 524;
                            MTRX_V_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 528;
                            LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 529;
                            MTRX_A_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 533;
                            Trace( "GlobalMST - in fMTRXSendRoute - didnt catch iList case - iList={0:d}", (ushort)ILIST) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 537;
                Trace( "GlobalMST - in fMTRXSendRoute - attempting to send to VDST Guid (0).  iList={0:d}, iDst={1:d}, iSrc={2:d}", (short)ILIST, (short)IDST, (short)ISRC) ; 
                }
            
            
            }
            
        private short FMTRXSENDROUTEVIRTUAL (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort IDSTROOM = 0;
            ushort ISRCROOM = 0;
            ushort ILOCALID = 0;
            
            CrestronString STEMPNAME;
            STEMPNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 555;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 557;
                IDSTROOM = (ushort) ( LIST[ 2 ].ITEM[ IDST ].IRMASS ) ; 
                __context__.SourceCodeLine = 558;
                ISRCROOM = (ushort) ( LIST[ 1 ].ITEM[ ISRC ].IRMASS ) ; 
                __context__.SourceCodeLine = 560;
                ILOCALID = (ushort) ( LIST[ 2 ].ITEM[ IDST ].ILOCALID ) ; 
                __context__.SourceCodeLine = 562;
                LIST [ 2] . ITEM [ IDST] . IVLINK = (ushort) ( ISRC ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 566;
                Trace( "GlobalMST - in fMTRXSendRouteVirtual - attempting function with iDst value 0") ; 
                __context__.SourceCodeLine = 567;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 571;
            STEMPNAME  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
            __context__.SourceCodeLine = 573;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                {
                __context__.SourceCodeLine = 573;
                STEMPNAME  .UpdateValue ( LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME  ) ; 
                }
            
            __context__.SourceCodeLine = 575;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ IDSTROOM] , "{{V_LINK_VSRC; LocalID={0:d}: GUID={1:d},{2}|;}}", (ushort)ILOCALID, (ushort)ISRC, STEMPNAME ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCAMGETFOLDEDCMD (  SplusExecutionContext __context__, CrestronString STEMPDATA ) 
            { 
            
            __context__.SourceCodeLine = 592;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "stop" , STEMPDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 592;
                return (ushort)( 0) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 593;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "up" , STEMPDATA ))  ) ) 
                    {
                    __context__.SourceCodeLine = 593;
                    return (ushort)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 594;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "down" , STEMPDATA ))  ) ) 
                        {
                        __context__.SourceCodeLine = 594;
                        return (ushort)( 2) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 595;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "left" , STEMPDATA ))  ) ) 
                            {
                            __context__.SourceCodeLine = 595;
                            return (ushort)( 3) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 596;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "right" , STEMPDATA ))  ) ) 
                                {
                                __context__.SourceCodeLine = 596;
                                return (ushort)( 4) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 597;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomin" , STEMPDATA ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 597;
                                    return (ushort)( 5) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 598;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomout" , STEMPDATA ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 598;
                                        return (ushort)( 6) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 599;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweron" , STEMPDATA ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 599;
                                            return (ushort)( 7) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 600;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweroff" , STEMPDATA ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 600;
                                                return (ushort)( 8) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 601;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetrec" , STEMPDATA ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 601;
                                                    return (ushort)( (Functions.Atoi( STEMPDATA ) + 100)) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 602;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetsav" , STEMPDATA ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 602;
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
            
            __context__.SourceCodeLine = 620;
            LISTFB__DOLLAR__ [ ILIST]  .UpdateValue ( SDATA  ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 630;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 632;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 633;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 637;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 639;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 639;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 641;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 642;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 644;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 645;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 646;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 637;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 650;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 652;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 653;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 662;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 664;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 666;
                    STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                    __context__.SourceCodeLine = 667;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 671;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 673;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 673;
                            MakeString ( STEMP , "{{ListVisFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 675;
                        MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                        __context__.SourceCodeLine = 676;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 678;
                            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                            __context__.SourceCodeLine = 679;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 680;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 671;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 684;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 686;
                    MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                    __context__.SourceCodeLine = 687;
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
            
            
            __context__.SourceCodeLine = 697;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 699;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 701;
                MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                __context__.SourceCodeLine = 702;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 704;
                    MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                    __context__.SourceCodeLine = 702;
                    } 
                
                __context__.SourceCodeLine = 706;
                STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                __context__.SourceCodeLine = 707;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 711;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 713;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 715;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 715;
                            MakeString ( STEMP , "{{ListTextFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 717;
                        MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                        __context__.SourceCodeLine = 718;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 720;
                            MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                            __context__.SourceCodeLine = 718;
                            } 
                        
                        __context__.SourceCodeLine = 722;
                        MakeString ( STEMP , "{0}|", STEMP ) ; 
                        __context__.SourceCodeLine = 724;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 600 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 726;
                            MakeString ( STEMP , "{0};}}", STEMP ) ; 
                            __context__.SourceCodeLine = 727;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 728;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 711;
                    } 
                
                __context__.SourceCodeLine = 732;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 734;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 735;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTFBFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 747;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 749;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 750;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 754;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 756;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 756;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 758;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 759;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 761;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 762;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 763;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 754;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 767;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 769;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 770;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVISFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 778;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 780;
                MakeString ( STEMP , "{{ListVisFB:{0:d}={1:d},", (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 784;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 786;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 786;
                        MakeString ( STEMP , "{{ListVisFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 788;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    __context__.SourceCodeLine = 789;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 791;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 792;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 793;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 784;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 797;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 799;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 800;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXTFILTER (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 809;
            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
            __context__.SourceCodeLine = 811;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 813;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 813;
                    MakeString ( STEMP , "{{ListTextFB:") ; 
                    }
                
                __context__.SourceCodeLine = 815;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 817;
                    MakeString ( STEMP , "{0}{1:d}={2},|", STEMP , (ushort)FILTER[ ILIST ].ITEM[ I ].IGLOBALTOLIST, FILTER [ ILIST] . ITEM [ I] . STEXT [ 1 ] ) ; 
                    } 
                
                __context__.SourceCodeLine = 822;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 800 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 824;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 825;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 826;
                    STEMP  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 811;
                } 
            
            __context__.SourceCodeLine = 829;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 831;
                MakeString ( STEMP , "{0};}}", STEMP ) ; 
                __context__.SourceCodeLine = 832;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            
            }
            
        private void FCONFIGURELISTFBSETVISIBLEITEMS (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 853;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 855;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IVIS)  ) ) 
                    { 
                    __context__.SourceCodeLine = 857;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 858;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 853;
                } 
            
            
            }
            
        private void FCONFIGURELISTFBRESETALL (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 866;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 868;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 870;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 871;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 866;
                } 
            
            __context__.SourceCodeLine = 874;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            
            }
            
        private void FCONFIGURELISTFBTOGGLE (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 880;
            LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( LIST[ ILIST ].ITEM[ IINDEX ].IFB ) ) ; 
            __context__.SourceCodeLine = 881;
            FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private ushort FCONFIGURELISTFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort ISAME = 0;
            
            
            __context__.SourceCodeLine = 887;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 889;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ILIST ].IITEMSELECTEDLAST == IINDEX))  ) ) 
                    { 
                    __context__.SourceCodeLine = 891;
                    LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 892;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 893;
                    ISAME = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 895;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                        { 
                        __context__.SourceCodeLine = 897;
                        LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 898;
                        FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                        __context__.SourceCodeLine = 899;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 900;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 904;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 905;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 907;
                FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                __context__.SourceCodeLine = 908;
                if ( Functions.TestForTrue  ( ( ISAME)  ) ) 
                    {
                    __context__.SourceCodeLine = 908;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 909;
                return (ushort)( IINDEX) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 913;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 915;
                    LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 916;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                    __context__.SourceCodeLine = 917;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                __context__.SourceCodeLine = 923;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCONFIGUREFILTERFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 931;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINDEX != FILTER[ ILIST ].IITEMSELECTEDLAST))  ) ) 
                { 
                __context__.SourceCodeLine = 933;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 935;
                    FILTER [ ILIST] . ITEM [ FILTER[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 936;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( FILTER[ ILIST ].IITEMSELECTEDLAST )) ; 
                    } 
                
                __context__.SourceCodeLine = 938;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 940;
                    FILTER [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 941;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    } 
                
                __context__.SourceCodeLine = 943;
                FILTER [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 944;
                return (ushort)( 1) ; 
                } 
            
            __context__.SourceCodeLine = 946;
            return (ushort)( 0) ; 
            
            }
            
        private void FCONFIGUREFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            ushort ITEMPLIST1 = 0;
            ushort ITEMPLIST2 = 0;
            
            
            __context__.SourceCodeLine = 954;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
            __context__.SourceCodeLine = 955;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX )) ; 
            __context__.SourceCodeLine = 957;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 959;
                FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
                __context__.SourceCodeLine = 960;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 962;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 964;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 965;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 960;
                    } 
                
                __context__.SourceCodeLine = 968;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 970;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 972;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 973;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 968;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 979;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 981;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 983;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 984;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 979;
                    } 
                
                __context__.SourceCodeLine = 987;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                    { 
                    __context__.SourceCodeLine = 989;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 991;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 992;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 987;
                    } 
                
                } 
            
            
            }
            
        private void FCONFIGUREGROUP (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 1002;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1004;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1006;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1008;
                        FILTER [ (ILIST - 1)] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 1009;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1004;
                    } 
                
                __context__.SourceCodeLine = 1013;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ) && Functions.TestForTrue ( Functions.Not( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1016;
                    FCONFIGUREFILTERFBMUTEX (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 1017;
                    FCONFIGUREFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1022;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 1024;
                    if ( Functions.TestForTrue  ( ( Functions.Not( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1026;
                        FILTER [ FILTER[ ILIST ].IMEMBERLISTFINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1027;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1022;
                    } 
                
                } 
            
            
            }
            
        private CrestronString FGETROUTEDSOURCENAME (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1039;
            try 
                { 
                __context__.SourceCodeLine = 1041;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1043;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1045;
                        return ( LIST [ (ILIST - 1)] . ITEM [ LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC] . SGLOBALNAME ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1047;
                        return ( SYS . SBLANKSRCTEXT ) ; 
                        }
                    
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1052;
                Trace( "GlobalMST fGetRoutedSourceName - error - iList={0:d}, iIndex={1:d}, List[{2:d}].Item[{3:d}].iRoutedSrc={4:d}", (ushort)ILIST, (ushort)IINDEX, (ushort)ILIST, (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC) ; 
                
                }
                
                
                return ""; // default return value (none specified in module)
                }
                
            private ushort FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX , ushort ITEXTCOLUMN ) 
                { 
                
                __context__.SourceCodeLine = 1059;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1061;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)ITEXTCOLUMN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1063;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1064;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( FGETROUTEDSOURCENAME (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX ))  ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 1067;
                    return (ushort)( 0) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1069;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1071;
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
                
                
                __context__.SourceCodeLine = 1099;
                STEMPDATA  .UpdateValue ( STEMP  ) ; 
                __context__.SourceCodeLine = 1100;
                STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
                __context__.SourceCodeLine = 1102;
                while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1104;
                    STEMP2  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 1105;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_V_RTE" , STEMPHEADER ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1107;
                        STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                        __context__.SourceCodeLine = 1108;
                        IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                        __context__.SourceCodeLine = 1109;
                        IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                        __context__.SourceCodeLine = 1110;
                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1112;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_rte" , STEMPHEADER ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1114;
                            Trace( "in GlobalMST usb_rte") ; 
                            __context__.SourceCodeLine = 1115;
                            STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                            __context__.SourceCodeLine = 1116;
                            IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                            __context__.SourceCodeLine = 1117;
                            IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                            __context__.SourceCodeLine = 1118;
                            Trace( "iGUIDdst = {0:d}, iGUIDsrc = {1:d}", (ushort)IGUIDDST, (ushort)IGUIDSRC) ; 
                            __context__.SourceCodeLine = 1120;
                            FUSBSENDROUTE (  __context__ , (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1122;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_ctrl" , STEMPHEADER ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1124;
                                STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                __context__.SourceCodeLine = 1125;
                                I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                __context__.SourceCodeLine = 1126;
                                if ( Functions.TestForTrue  ( ( I)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1128;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1129;
                                    CAM_FOLDEDCMD [ I]  .Value = (ushort) ( FCAMGETFOLDEDCMD( __context__ , STEMP2 ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1133;
                                    Trace( "Global fProcessRoomData, found cam_ctrl - iCamGUID resolved to zero(0)") ; 
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1136;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "dply_cmd" , STEMPHEADER ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1138;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1139;
                                    I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                    __context__.SourceCodeLine = 1140;
                                    if ( Functions.TestForTrue  ( ( I)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1142;
                                        STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                        __context__.SourceCodeLine = 1144;
                                        DISPLAY_FOLDEDCMD [ I]  .Value = (ushort) ( (Functions.Atoi( STEMP2 ) + 10) ) ; 
                                        __context__.SourceCodeLine = 1148;
                                        IDISPLAYVGUID = (ushort) ( SYS.DISPLAY.IGUID[ I ] ) ; 
                                        __context__.SourceCodeLine = 1149;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 1))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1151;
                                            IRELAYTYPE = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1153;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 6))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1155;
                                                IRELAYTYPE = (ushort) ( 2 ) ; 
                                                } 
                                            
                                            }
                                        
                                        __context__.SourceCodeLine = 1158;
                                        if ( Functions.TestForTrue  ( ( IRELAYTYPE)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1160;
                                            
                                                {
                                                int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.Atoi( STEMP2 ));
                                                
                                                    { 
                                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1164;
                                                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__1 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYOFFNUMOF; 
                                                        int __FN_FORSTEP_VAL__1 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                                                            { 
                                                            __context__.SourceCodeLine = 1166;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1167;
                                                            Functions.Delay (  (int) ( 50 ) ) ; 
                                                            __context__.SourceCodeLine = 1168;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1164;
                                                            } 
                                                        
                                                        } 
                                                    
                                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1173;
                                                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__2 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYONNUMOF; 
                                                        int __FN_FORSTEP_VAL__2 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
                                                            { 
                                                            __context__.SourceCodeLine = 1175;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1176;
                                                            Functions.Delay (  (int) ( 50 ) ) ; 
                                                            __context__.SourceCodeLine = 1177;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1173;
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
                    
                    __context__.SourceCodeLine = 1102;
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
                    
                    
                    __context__.SourceCodeLine = 1192;
                    IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1194;
                    STEMPDATA  .UpdateValue ( Functions.Gather ( Functions.Length( FROM_ROOM_RX__DOLLAR__[ IROOM ] ), FROM_ROOM_RX__DOLLAR__ [ IROOM ] )  ) ; 
                    __context__.SourceCodeLine = 1195;
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
                
                
                __context__.SourceCodeLine = 1204;
                if ( Functions.TestForTrue  ( ( LIST[ 2 ].IINITIALIZED)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1206;
                    IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1208;
                    ISRC = (ushort) ( MTRX_V_IN[ IDST ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 1210;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 1000 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1212;
                        Trace( "GlobalMST - Change MTRX_V_In, dstGUID={0:d}, srcValue(not a GUID)={1:d}", (ushort)IDST, (ushort)ISRC) ; 
                        __context__.SourceCodeLine = 1213;
                        ISRC = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1214;
                        LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 1215;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                        __context__.SourceCodeLine = 1216;
                        FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1218;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISRC ) && Functions.TestForTrue ( Functions.BoolToInt (ISRC != LIST[ 2 ].ITEM[ IDST ].IROUTEDSRC) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1220;
                            LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 1221;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                            __context__.SourceCodeLine = 1222;
                            FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                            __context__.SourceCodeLine = 1224;
                            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IRMASS)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1226;
                                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 2 ].ITEM[ IDST ].IRMASS] , "{{MTRX_V_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 2 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1233;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ISRC ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1235;
                                Trace( "GlobalMST - Change MTRX_V_In, iSrc == 0") ; 
                                __context__.SourceCodeLine = 1236;
                                LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 1237;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                                __context__.SourceCodeLine = 1238;
                                FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1242;
                                Trace( "GlobalMST MTRX_V_In - else trap") ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1245;
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
            
            
            __context__.SourceCodeLine = 1253;
            if ( Functions.TestForTrue  ( ( LIST[ 4 ].IINITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 1255;
                IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 1257;
                ISRC = (ushort) ( MTRX_A_IN[ IDST ] .UshortValue ) ; 
                __context__.SourceCodeLine = 1258;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISRC != LIST[ 4 ].ITEM[ IDST ].IROUTEDSRC))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1260;
                    LIST [ 4] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                    __context__.SourceCodeLine = 1261;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                    __context__.SourceCodeLine = 1262;
                    FUPDATELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST )) ; 
                    __context__.SourceCodeLine = 1264;
                    if ( Functions.TestForTrue  ( ( LIST[ 4 ].ITEM[ IDST ].IRMASS)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1266;
                        MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 4 ].ITEM[ IDST ].IRMASS] , "{{MTRX_A_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 4 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 3] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1274;
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
    
    
    __context__.SourceCodeLine = 1292;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1294;
        LIST [ ILIST] . IINITIALIZED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1296;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1298;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1299;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1301;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1301;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 2 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1296;
            } 
        
        __context__.SourceCodeLine = 1304;
        FUPDATELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1305;
        FUPDATELISTVIS (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1307;
        Functions.Delay (  (int) ( 100 ) ) ; 
        __context__.SourceCodeLine = 1309;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)23; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 1311;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ I] , "{0}COMPLETE|}}", FGETDATAHEADER (  __context__ , (ushort)( ILIST )) ) ; 
            __context__.SourceCodeLine = 1312;
            Functions.Delay (  (int) ( 200 ) ) ; 
            __context__.SourceCodeLine = 1309;
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1316;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1318;
            LIST_NUMOFITEMS [ ILIST]  .Value = (ushort) ( FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1319;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 1321;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
                __context__.SourceCodeLine = 1319;
                } 
            
            __context__.SourceCodeLine = 1323;
            FUPDATELISTTEXTFILTER (  __context__ , (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1324;
            FUPDATELISTVISFILTER (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
            } 
        
        }
    
    __context__.SourceCodeLine = 1327;
    Functions.Delay (  (int) ( 100 ) ) ; 
    __context__.SourceCodeLine = 1329;
    Functions.Pulse ( 20, DATAINIT_DONE [ ILIST] ) ; 
    
    return 0; // default return value (none specified in module)
    }
    
private void FPROCESSLINESTOROOM (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    ushort J = 0;
    ushort IINDEX = 0;
    
    CrestronString STEMP;
    CrestronString STEMPHEADER;
    CrestronString STEMPUSB;
    CrestronString STEMPSYSPRESET;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 60, this );
    STEMPUSB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    STEMPSYSPRESET  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    
    __context__.SourceCodeLine = 1343;
    STEMPHEADER  .UpdateValue ( FGETDATAHEADER (  __context__ , (ushort)( ITYPE ))  ) ; 
    __context__.SourceCodeLine = 1345;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1347;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1349;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISUSB)  ) ) 
                {
                __context__.SourceCodeLine = 1349;
                MakeString ( STEMPUSB , " usb_mac={0},", LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR ) ; 
                }
            
            __context__.SourceCodeLine = 1351;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
                {
                __context__.SourceCodeLine = 1351;
                MakeString ( STEMP , "is_camera=1, cam_localID={0:d}, cam_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMGUID) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1355;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                    {
                    __context__.SourceCodeLine = 1355;
                    MakeString ( STEMP , "is_display=1, display_localID={0:d}, display_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYGUID) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1360;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].ISYSPRESET)  ) ) 
                {
                __context__.SourceCodeLine = 1360;
                MakeString ( STEMPSYSPRESET , "sys_preset={0:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ISYSPRESET) ; 
                }
            
            __context__.SourceCodeLine = 1363;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] , "{{{0} LOCALID={1:d}: GUID={2:d}, global_name={3}, local_name={4}, {5}{6}is_virtual={7:d}, {8}|}}", STEMPHEADER , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID, (ushort)IINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME , STEMPSYSPRESET , STEMP , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL, STEMPUSB ) ; 
            __context__.SourceCodeLine = 1376;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                {
                __context__.SourceCodeLine = 1376;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . IVIRTUALVDSTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID] = (ushort) ( IINDEX ) ; 
                }
            
            __context__.SourceCodeLine = 1377;
            Functions.Delay (  (int) ( 5 ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1345;
        } 
    
    __context__.SourceCodeLine = 1381;
    Functions.Delay (  (int) ( 300 ) ) ; 
    __context__.SourceCodeLine = 1382;
    FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
    
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
    CrestronString STEMP;
    CrestronString STEMP2;
    CrestronString STEMPCOMPORT;
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    STEMPCOMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 1404;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1406;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1408;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1409;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1410;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1412;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1414;
            LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            __context__.SourceCodeLine = 1415;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), (ushort)( 1 )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1417;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1419;
                LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1421;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1421;
                    LIST [ ITYPE] . ITEM [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1422;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_id" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1422;
                        LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1424;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_src_id" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1424;
                            LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1425;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1425;
                                LIST [ ITYPE] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1426;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "filter" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1426;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . IFILTERID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1428;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ip_address" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1428;
                                        LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1429;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "com_port" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1429;
                                            LIST [ ITYPE] . ITEM [ IINDEX] . ICOMPORT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1430;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "processor_index" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1430;
                                                LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1432;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1432;
                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1433;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1433;
                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1434;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1434;
                                                            LIST [ ITYPE] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1435;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "relay_proc" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1435;
                                                                LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYPROCESSOR = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1436;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_on" , STEMPKEY ))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1438;
                                                                    I = (ushort) ( 1 ) ; 
                                                                    __context__.SourceCodeLine = 1439;
                                                                    while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 1441;
                                                                        STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                                                                        __context__.SourceCodeLine = 1442;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                                                        __context__.SourceCodeLine = 1443;
                                                                        if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1445;
                                                                            STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                                                            __context__.SourceCodeLine = 1446;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                                                            __context__.SourceCodeLine = 1447;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                                                            } 
                                                                        
                                                                        __context__.SourceCodeLine = 1449;
                                                                        I = (ushort) ( (I + 1) ) ; 
                                                                        __context__.SourceCodeLine = 1439;
                                                                        } 
                                                                    
                                                                    __context__.SourceCodeLine = 1451;
                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYONNUMOF = (ushort) ( I ) ; 
                                                                    __context__.SourceCodeLine = 1452;
                                                                    I = (ushort) ( 0 ) ; 
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 1454;
                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_off" , STEMPKEY ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 1456;
                                                                        I = (ushort) ( 1 ) ; 
                                                                        __context__.SourceCodeLine = 1457;
                                                                        while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1459;
                                                                            STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                                                                            __context__.SourceCodeLine = 1460;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                                                            __context__.SourceCodeLine = 1461;
                                                                            if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 1463;
                                                                                STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                                                                __context__.SourceCodeLine = 1464;
                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                                                                __context__.SourceCodeLine = 1465;
                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                                                                } 
                                                                            
                                                                            __context__.SourceCodeLine = 1467;
                                                                            I = (ushort) ( (I + 1) ) ; 
                                                                            __context__.SourceCodeLine = 1457;
                                                                            } 
                                                                        
                                                                        __context__.SourceCodeLine = 1469;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYOFFNUMOF = (ushort) ( I ) ; 
                                                                        __context__.SourceCodeLine = 1470;
                                                                        I = (ushort) ( 0 ) ; 
                                                                        } 
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 1472;
                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "device_type" , STEMPKEY ))  ) ) 
                                                                            {
                                                                            __context__.SourceCodeLine = 1472;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                            }
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 1474;
                                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 1476;
                                                                                STEMPVALUE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                                __context__.SourceCodeLine = 1478;
                                                                                MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR , "{0}{1}{2}", Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 1 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 3 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 5 ) , (int)( 2 ) ) ) ) ) ) ; 
                                                                                __context__.SourceCodeLine = 1484;
                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                                                                                } 
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 1486;
                                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_vtc" , STEMPKEY ))  ) ) 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 1486;
                                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IISVTC = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                    }
                                                                                
                                                                                else 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 1487;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vtc_io" , STEMPKEY ))  ) ) 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 1487;
                                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IVTCIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                        }
                                                                                    
                                                                                    else 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 1489;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 1489;
                                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                            }
                                                                                        
                                                                                        else 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 1490;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cmd" , STEMPKEY ))  ) ) 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 1492;
                                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . SCMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                                                __context__.SourceCodeLine = 1493;
                                                                                                LIST [ ITYPE] . ITEM [ IINDEX] . ICMDDATA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                                                } 
                                                                                            
                                                                                            else 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 1497;
                                                                                                IERR = (ushort) ( 1 ) ; 
                                                                                                __context__.SourceCodeLine = 1498;
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
            
            }
        
        __context__.SourceCodeLine = 1406;
        } 
    
    __context__.SourceCodeLine = 1502;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1504;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1507;
            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , "{0:d3} {1}", (ushort)ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].IROOMNUM, LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME ) ; 
            } 
        
        __context__.SourceCodeLine = 1513;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
            { 
            __context__.SourceCodeLine = 1515;
            SYS . CAM . INUMOFCAMS = (ushort) ( (SYS.CAM.INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1516;
            SYS . CAM . IGUID [ SYS.CAM.INUMOFCAMS] = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1517;
            ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFCAMS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1518;
            LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1519;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1520;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1521;
            ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1523;
            MakeString ( CAM_DATAINIT__DOLLAR__ [ 1] , "{{ListTextFB:{0:d}= global_name={1}~ip={2},|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS ) ; 
            __context__.SourceCodeLine = 1528;
            MakeString ( LISTFB__DOLLAR__ [ 12] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)ICAMGUID) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1534;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                { 
                __context__.SourceCodeLine = 1536;
                SYS . DISPLAY . INUMOFDISPLAYS = (ushort) ( (SYS.DISPLAY.INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1537;
                SYS . DISPLAY . IGUID [ SYS.DISPLAY.INUMOFDISPLAYS] = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 1538;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFDISPLAYS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1539;
                LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1540;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1541;
                IDISPLAYGUID = (ushort) ( SYS.DISPLAY.INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1542;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1545;
                LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( 5 ) ; 
                __context__.SourceCodeLine = 1547;
                STEMPCOMPORT  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 1548;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT)  ) ) 
                    {
                    __context__.SourceCodeLine = 1548;
                    MakeString ( STEMPCOMPORT , "~com_port={0:d},", (ushort)LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT) ; 
                    }
                
                __context__.SourceCodeLine = 1550;
                MakeString ( DISPLAY_DATAINIT__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IPROCESSORINDEX] , "{{ListTextFB:{0:d}= global_name={1}~ip={2}~device_type={3}{4},|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS , LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE , STEMPCOMPORT ) ; 
                __context__.SourceCodeLine = 1557;
                MakeString ( LISTFB__DOLLAR__ [ 13] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)IDISPLAYGUID) ; 
                __context__.SourceCodeLine = 1564;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYPROCESSOR == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1566;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYONNUMOF; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1568;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IISINITINDEX )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1570;
                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1566;
                        } 
                    
                    __context__.SourceCodeLine = 1576;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYOFFNUMOF; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 1578;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IISINITINDEX )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1580;
                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1576;
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1588;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1590;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_5__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1593;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVOUTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1595;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVINGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            }
        
        __context__.SourceCodeLine = 1599;
        LIST [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1600;
        LIST [ ITYPE] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1601;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1604;
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
    
    
    __context__.SourceCodeLine = 1612;
    if ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1614;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1615;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1617;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1618;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 1619;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_guid" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1619;
                IINDEX = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1620;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1620;
                    ROOM [ IINDEX] . SROOMNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) ))  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1621;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bldg_rm_num" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1621;
                        ROOM [ IINDEX] . IROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1622;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1622;
                            ROOM [ IINDEX] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1623;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1623;
                                ROOM [ IINDEX] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1615;
            } 
        
        __context__.SourceCodeLine = 1626;
        MakeString ( TO_ROOM_TX__DOLLAR__ [ IINDEX] , "{{ROOMS; RoomID={0:d}:{1},{2:d},discrete_macro_mode={3:d},macro_take_mode={4:d}|}}", (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME , (ushort)ROOM[ IINDEX ].IROOMNUM, (ushort)ROOM[ IINDEX ].IDISCRETEMACROMODE, (ushort)ROOM[ IINDEX ].IMACROTAKEMODE) ; 
        __context__.SourceCodeLine = 1633;
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
    
    
    __context__.SourceCodeLine = 1642;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1643;
    while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1645;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
        __context__.SourceCodeLine = 1646;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1648;
            STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1649;
            FILTER [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPVALUE , (int)( (Functions.Length( STEMPVALUE ) - 1) ) ))  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1651;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list_index" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1653;
                STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                __context__.SourceCodeLine = 1654;
                FILTER [ ITYPE] . ITEM [ IINDEX] . IGLOBALTOLIST = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                __context__.SourceCodeLine = 1655;
                FILTER [ ITYPE] . ITEM [ Functions.Atoi( STEMPVALUE )] . ILISTTOGLOBAL = (ushort) ( IINDEX ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1657;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "v_guid" , STEMPKEY ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1659;
                    STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                    __context__.SourceCodeLine = 1660;
                    while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1662;
                        I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        __context__.SourceCodeLine = 1663;
                        FILTER [ ITYPE] . IMEMBERLISTV [ IINDEX , I] = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1664;
                        STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                        __context__.SourceCodeLine = 1665;
                        FILTER [ ITYPE] . INUMOFMEMBERSV [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSV[ IINDEX ] + 1) ) ; 
                        __context__.SourceCodeLine = 1660;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1668;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "a_guid" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1670;
                        STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 1671;
                        while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1673;
                            I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1674;
                            FILTER [ ITYPE] . IMEMBERLISTA [ IINDEX , I] = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1675;
                            STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                            __context__.SourceCodeLine = 1676;
                            FILTER [ ITYPE] . INUMOFMEMBERSA [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSA[ IINDEX ] + 1) ) ; 
                            __context__.SourceCodeLine = 1671;
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1679;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "f_guid" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1681;
                            STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                            __context__.SourceCodeLine = 1682;
                            while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1684;
                                I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                __context__.SourceCodeLine = 1685;
                                FILTER [ ITYPE] . IMEMBERLISTF [ IINDEX , I] = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1686;
                                STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                                __context__.SourceCodeLine = 1687;
                                FILTER [ ITYPE] . INUMOFMEMBERSF [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSF[ IINDEX ] + 1) ) ; 
                                __context__.SourceCodeLine = 1682;
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1692;
                            Trace( "Global - in fProcessFilter - didn't catch key. GUID={0:d} key:\u0022{1}\u0022", (ushort)IINDEX, STEMPKEY ) ; 
                            __context__.SourceCodeLine = 1693;
                            IERR = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1643;
        } 
    
    __context__.SourceCodeLine = 1697;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1699;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1700;
        FILTER [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1701;
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
    
    
    __context__.SourceCodeLine = 1718;
    STEMPDATA2  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1719;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1720;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1722;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VSRC" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1722;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1723;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VDST" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1723;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1724;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ASRC" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1724;
                ITYPE = (ushort) ( 3 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1725;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ADST" , STEMPHEADER ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1725;
                    ITYPE = (ushort) ( 4 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1726;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCF" , STEMPHEADER ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1726;
                        ITYPE = (ushort) ( 5 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1727;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCG" , STEMPHEADER ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1727;
                            ITYPE = (ushort) ( 6 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1728;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTF" , STEMPHEADER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1728;
                                ITYPE = (ushort) ( 7 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1729;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTG" , STEMPHEADER ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1729;
                                    ITYPE = (ushort) ( 8 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1730;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1730;
                                        ITYPE = (ushort) ( 13 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1731;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MACRO" , STEMPHEADER ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1731;
                                            ITYPE = (ushort) ( 14 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1732;
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
    
    __context__.SourceCodeLine = 1735;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
        { 
        __context__.SourceCodeLine = 1737;
        if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPDATA2 ))  ) ) 
            {
            __context__.SourceCodeLine = 1737;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ Functions.Atoi( STEMPDATA2 )] , "{0}", STEMPDATA2 ) ; 
            }
        
        } 
    
    __context__.SourceCodeLine = 1739;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1741;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1742;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1744;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITYPE >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITYPE <= 4 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1744;
                FPROCESSLINESTOROOM (  __context__ , (ushort)( ITYPE )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1745;
                FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1747;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                { 
                __context__.SourceCodeLine = 1749;
                FPROCESSROOMS (  __context__ , (ushort)( ITYPE ), STEMPLINE) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1753;
                STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
                __context__.SourceCodeLine = 1754;
                IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                __context__.SourceCodeLine = 1755;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1757;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_6__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1759;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1760;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1761;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1762;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1763;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1764;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1765;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1766;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1769;
                    Trace( "error - MTRX fProcessInit, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1739;
        } 
    
    
    }
    
private void FUPDATEVTC (  SplusExecutionContext __context__, ushort IVTCSEL ) 
    { 
    ushort I = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1785;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1786;
    VTC_CTRL_SEL_UNITNAME__DOLLAR__  .UpdateValue ( SYS . VTC [ SYS.IVTCSEL] . SUNITNAME  ) ; 
    __context__.SourceCodeLine = 1787;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].IROOMRES)  ) ) 
        {
        __context__.SourceCodeLine = 1787;
        STEMP  .UpdateValue ( ROOM [ SYS.VTC[ IVTCSEL ].IROOMRES] . SROOMNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1788;
    VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1789;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1790;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICAMSELECT)  ) ) 
        {
        __context__.SourceCodeLine = 1790;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICAMSELECT] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1791;
    VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1792;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1793;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICONTENTSRC)  ) ) 
        {
        __context__.SourceCodeLine = 1793;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICONTENTSRC] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1794;
    VTC_CONTENTSHARE_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    
    }
    
object VTC_CTRL_SEL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1807;
        SYS . IVTCSEL = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1809;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)3; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 1809;
            VTC_CTRL_SEL_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1809;
            }
        
        __context__.SourceCodeLine = 1810;
        VTC_CTRL_SEL_FB [ SYS.IVTCSEL]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1812;
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
        
        
        __context__.SourceCodeLine = 1822;
        IVTC = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1825;
        ISRCGUID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1826;
        STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
        __context__.SourceCodeLine = 1829;
        if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 1831;
            ISRCGUID = (ushort) ( SYS.CAM.IGUID[ SYS.ICAMSEL ] ) ; 
            __context__.SourceCodeLine = 1832;
            STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ SYS.ICAMSEL ]] . SGLOBALNAME  ) ; 
            } 
        
        __context__.SourceCodeLine = 1835;
        SYS . VTC [ IVTC] . ICAMSELECT = (ushort) ( ISRCGUID ) ; 
        __context__.SourceCodeLine = 1837;
        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ IVTC ].IVINGUID[ 1 ] ), (ushort)( SYS.VTC[ IVTC ].ICAMSELECT )) ; 
        __context__.SourceCodeLine = 1838;
        VTC_CAMSELECT_NAME__DOLLAR__ [ IVTC]  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1839;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVTC == SYS.IVTCSEL))  ) ) 
            {
            __context__.SourceCodeLine = 1839;
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
        
        __context__.SourceCodeLine = 1846;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYS.UI.ISUB == 2))  ) ) 
            { 
            __context__.SourceCodeLine = 1848;
            if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
                { 
                __context__.SourceCodeLine = 1850;
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
    
    
    __context__.SourceCodeLine = 1866;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1868;
        if ( Functions.TestForTrue  ( ( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST)  ) ) 
            { 
            __context__.SourceCodeLine = 1870;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1872;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1874;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1874;
                        FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1875;
                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1870;
                } 
            
            } 
        
        } 
    
    
    }
    
private void FMTRXCLEARROUTES (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1886;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1888;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1890;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                { 
                __context__.SourceCodeLine = 1892;
                if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1892;
                    FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1893;
                    FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1888;
            } 
        
        } 
    
    
    }
    
object MTRX_TAKE_ALL_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1909;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1910;
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
        
        __context__.SourceCodeLine = 1915;
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
        
        __context__.SourceCodeLine = 1920;
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
        
        __context__.SourceCodeLine = 1925;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1926;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1927;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1928;
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
        
        __context__.SourceCodeLine = 1932;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1933;
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
        
        __context__.SourceCodeLine = 1937;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1938;
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
        
        __context__.SourceCodeLine = 1942;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1943;
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
        
        __context__.SourceCodeLine = 1947;
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
        
        __context__.SourceCodeLine = 1951;
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
        
        __context__.SourceCodeLine = 1955;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1956;
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
        
        
        __context__.SourceCodeLine = 1969;
        IERR = (ushort) ( 10000 ) ; 
        __context__.SourceCodeLine = 1970;
        ILIST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1971;
        IINDEX = (ushort) ( LIST_ITEMCLICKED[ ILIST ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1973;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ) ) && Functions.TestForTrue ( IINDEX )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1973;
            IINDEX = (ushort) ( FILTER[ ILIST ].ITEM[ IINDEX ].ILISTTOGLOBAL ) ; 
            }
        
        __context__.SourceCodeLine = 1975;
        
            {
            int __SPLS_TMPVAR__SWTCH_7__ = ((int)ILIST);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1977;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1978;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1979;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1980;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 5) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1981;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 6) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1982;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 7) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1983;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 8) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1984;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1987;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_8__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1992;
                                IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                                __context__.SourceCodeLine = 1994;
                                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1996;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                    __context__.SourceCodeLine = 1997;
                                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__1 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__1 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                        { 
                                        __context__.SourceCodeLine = 2000;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 1 ].ITEM[ SYS.CAM.IGUID[ I ] ].IRMASS == IINDEX))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 2000;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 2001;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 1997;
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 2006;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 2007;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        {
                                        __context__.SourceCodeLine = 2007;
                                        LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                        __context__.SourceCodeLine = 2007;
                                        }
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 2009;
                                FUPDATELISTVIS (  __context__ , (ushort)( 12 ), (ushort)( 0 )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2013;
                                FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                                __context__.SourceCodeLine = 2015;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2017;
                                    IPREVIOUSROOM = (ushort) ( SYS.VTC[ SYS.IVTCSEL ].IROOMRES ) ; 
                                    __context__.SourceCodeLine = 2018;
                                    SYS . VTC [ SYS.IVTCSEL] . IROOMRES = (ushort) ( IINDEX ) ; 
                                    __context__.SourceCodeLine = 2019;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 2019;
                                        ROOM [ IINDEX] . IVTCASSIGNMENT = (ushort) ( SYS.IVTCSEL ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 2020;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 2020;
                                        ROOM [ IPREVIOUSROOM] . IVTCASSIGNMENT = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 2023;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IPREVIOUSROOM ) ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        { 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 2028;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPREVIOUSROOM == IINDEX))  ) ) 
                                            { 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 2033;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.BoolToInt (IPREVIOUSROOM != IINDEX) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 2036;
                                                Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                                __context__.SourceCodeLine = 2038;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2039;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2041;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2042;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 2 ] ), (ushort)( 0 )) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 2046;
                                    if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 2049;
                                        Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                        __context__.SourceCodeLine = 2051;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 2052;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 2057;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 2058;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 2060;
                                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 1 ] )) ; 
                                        __context__.SourceCodeLine = 2061;
                                        if ( Functions.TestForTrue  ( ( SYS.VTC[ SYS.IVTCSEL ].IDUALDISPLAY)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 2063;
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
                    __context__.SourceCodeLine = 2073;
                    IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    __context__.SourceCodeLine = 2074;
                    SYS . ICAMSEL = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 2076;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_9__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2081;
                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.IVDSTPANELGUID ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2085;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2087;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 2089;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( SYS.CAM.IGUID[ IINDEX ] ) ; 
                                        __context__.SourceCodeLine = 2090;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                        __context__.SourceCodeLine = 2091;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        __context__.SourceCodeLine = 2092;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 2096;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 2097;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                        __context__.SourceCodeLine = 2098;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        __context__.SourceCodeLine = 2099;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2106;
        if ( Functions.TestForTrue  ( ( IERR)  ) ) 
            { 
            __context__.SourceCodeLine = 2108;
            
                {
                int __SPLS_TMPVAR__SWTCH_10__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2110;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2111;
                        FCONFIGUREGROUP (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2112;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2113;
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
        
        
        __context__.SourceCodeLine = 2123;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 2125;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 2126;
            FPROCESSINIT (  __context__ , STEMP) ; 
            __context__.SourceCodeLine = 2123;
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
        
        __context__.SourceCodeLine = 2136;
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
        
        __context__.SourceCodeLine = 2141;
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
        
        __context__.SourceCodeLine = 2160;
        SYS . SBLANKSRCTEXT  .UpdateValue ( "---"  ) ; 
        __context__.SourceCodeLine = 2162;
        SYS . VTC [ 1] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit01"  ) ; 
        __context__.SourceCodeLine = 2163;
        SYS . VTC [ 2] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit02"  ) ; 
        __context__.SourceCodeLine = 2164;
        SYS . VTC [ 3] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit03"  ) ; 
        __context__.SourceCodeLine = 2166;
        LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2167;
        LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2168;
        LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2169;
        LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2171;
        LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2172;
        LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2173;
        LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2174;
        LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2175;
        LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2176;
        LIST [ 7] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2177;
        LIST [ 12] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2178;
        LIST [ 13] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2180;
        FILTER [ 6] . IMEMBERLISTFINDEX = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 2181;
        FILTER [ 8] . IMEMBERLISTFINDEX = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 2183;
        FILTER [ 5] . IMEMBERLISTVINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2184;
        FILTER [ 5] . IMEMBERLISTAINDEX = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 2186;
        FILTER [ 7] . IMEMBERLISTVINDEX = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2187;
        FILTER [ 7] . IMEMBERLISTAINDEX = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 2189;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2191;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2194;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 350 ) ; 
            __context__.SourceCodeLine = 2191;
            } 
        
        __context__.SourceCodeLine = 2196;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 3 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)4; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 2199;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 400 ) ; 
            __context__.SourceCodeLine = 2196;
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
    
    DATAINIT_DONE = new InOutArray<DigitalOutput>( 13, this );
    for( uint i = 0; i < 13; i++ )
    {
        DATAINIT_DONE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DATAINIT_DONE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DATAINIT_DONE__DigitalOutput__ + i, DATAINIT_DONE[i+1] );
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

public UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_63 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
const uint DATAINIT_DONE__DigitalOutput__ = 12;
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
    
    [SplusStructAttribute(37, false, false)]
    public ushort  ISYSPRESET = 0;
    
    
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
