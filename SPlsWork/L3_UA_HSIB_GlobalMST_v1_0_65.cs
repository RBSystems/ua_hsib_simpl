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

namespace UserModule_L3_UA_HSIB_GLOBALMST_V1_0_65
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_65 : SplusObject
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
            
            __context__.SourceCodeLine = 365;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 365;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 366;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 375;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 375;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 377;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 378;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 379;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 381;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 381;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 382;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 379;
                } 
            
            __context__.SourceCodeLine = 384;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 385;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 385;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 387;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 388;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 389;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 391;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 391;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 392;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 393;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 394;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 389;
                } 
            
            __context__.SourceCodeLine = 397;
            return ( SDATA ) ; 
            
            }
            
        private ushort FHIGHESTLISTINDEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 403;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 405;
                LIST [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( LIST[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                __context__.SourceCodeLine = 406;
                return (ushort)( LIST[ ILIST ].IHIGHESTLISTINDEX) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 408;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 410;
                    FILTER [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( FILTER[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                    __context__.SourceCodeLine = 411;
                    return (ushort)( FILTER[ ILIST ].IHIGHESTLISTINDEX) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 413;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 11))  ) ) 
                        {
                        __context__.SourceCodeLine = 413;
                        return (ushort)( SYS.INUMOFROOMS) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 414;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 12))  ) ) 
                            {
                            __context__.SourceCodeLine = 414;
                            return (ushort)( SYS.CAM.INUMOFCAMS) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 415;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 415;
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
            
            __context__.SourceCodeLine = 420;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 422;
                        return ( "MTRX_VSRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 423;
                        return ( "MTRX_VDST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 424;
                        return ( "MTRX_ASRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 425;
                        return ( "MTRX_ADST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 426;
                        return ( "MTRX_SRCF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 427;
                        return ( "MTRX_SRCG;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 428;
                        return ( "MTRX_DSTF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 429;
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
            
            
            __context__.SourceCodeLine = 445;
            if ( Functions.TestForTrue  ( ( IINC)  ) ) 
                {
                __context__.SourceCodeLine = 445;
                LIUSB_CMDINDEX = (uint) ( (LIUSB_CMDINDEX + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 447;
            MakeString ( STEMP , "{0}{1}{2}{3}", Functions.Chr (  (int) ( Functions.High( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) Functions.HighWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) Functions.LowWord( (uint)( LIUSB_CMDINDEX ) ) ) ) ) ) ; 
            __context__.SourceCodeLine = 452;
            return ( STEMP ) ; 
            
            }
            
        private void FUSBSENDROUTEKILL (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 459;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 464;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 466;
                SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
                __context__.SourceCodeLine = 467;
                MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u000a{1}{2}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
                } 
            
            __context__.SourceCodeLine = 472;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                { 
                __context__.SourceCodeLine = 474;
                SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
                __context__.SourceCodeLine = 475;
                MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u000a{1}{2}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
                } 
            
            
            }
            
        private void FUSBSENDROUTETAKE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            CrestronString SHANDLE;
            SHANDLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 487;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 489;
            FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
            __context__.SourceCodeLine = 491;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 492;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
            __context__.SourceCodeLine = 499;
            SHANDLE  .UpdateValue ( FGETUSBCMDINDEX (  __context__ , (ushort)( 1 ))  ) ; 
            __context__.SourceCodeLine = 500;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4{0}\u0004{1}{2}{3}{4}", SHANDLE , "\u0000\u001b\u0013" , LIST [ 1] . ITEM [ ISRC] . SUSBADDR , "\u0000\u001b\u0013" , LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 512;
            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IISUSB)  ) ) 
                { 
                __context__.SourceCodeLine = 514;
                if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 516;
                    if ( Functions.TestForTrue  ( ( LIST[ 1 ].ITEM[ ISRC ].IISUSB)  ) ) 
                        { 
                        __context__.SourceCodeLine = 518;
                        FUSBSENDROUTETAKE (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 522;
                        FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 527;
                    FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST ), (ushort)( 0 )) ; 
                    } 
                
                } 
            
            
            }
            
        private void FMTRXSENDROUTE (  SplusExecutionContext __context__, ushort ILIST , ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 535;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 537;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 541;
                            LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 542;
                            MTRX_V_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 546;
                            LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 547;
                            MTRX_A_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 551;
                            Trace( "GlobalMST - in fMTRXSendRoute - didnt catch iList case - iList={0:d}", (ushort)ILIST) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 555;
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
            
            
            __context__.SourceCodeLine = 573;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 575;
                IDSTROOM = (ushort) ( LIST[ 2 ].ITEM[ IDST ].IRMASS ) ; 
                __context__.SourceCodeLine = 576;
                ISRCROOM = (ushort) ( LIST[ 1 ].ITEM[ ISRC ].IRMASS ) ; 
                __context__.SourceCodeLine = 578;
                ILOCALID = (ushort) ( LIST[ 2 ].ITEM[ IDST ].ILOCALID ) ; 
                __context__.SourceCodeLine = 580;
                LIST [ 2] . ITEM [ IDST] . IVLINK = (ushort) ( ISRC ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 584;
                Trace( "GlobalMST - in fMTRXSendRouteVirtual - attempting function with iDst value 0") ; 
                __context__.SourceCodeLine = 585;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 589;
            STEMPNAME  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
            __context__.SourceCodeLine = 591;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                {
                __context__.SourceCodeLine = 591;
                STEMPNAME  .UpdateValue ( LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME  ) ; 
                }
            
            __context__.SourceCodeLine = 593;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ IDSTROOM] , "{{V_LINK_VSRC; LocalID={0:d}: GUID={1:d},{2}|;}}", (ushort)ILOCALID, (ushort)ISRC, STEMPNAME ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCAMGETFOLDEDCMD (  SplusExecutionContext __context__, CrestronString STEMPDATA ) 
            { 
            
            __context__.SourceCodeLine = 610;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "stop" , STEMPDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 610;
                return (ushort)( 0) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 611;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "up" , STEMPDATA ))  ) ) 
                    {
                    __context__.SourceCodeLine = 611;
                    return (ushort)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 612;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "down" , STEMPDATA ))  ) ) 
                        {
                        __context__.SourceCodeLine = 612;
                        return (ushort)( 2) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 613;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "left" , STEMPDATA ))  ) ) 
                            {
                            __context__.SourceCodeLine = 613;
                            return (ushort)( 3) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 614;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "right" , STEMPDATA ))  ) ) 
                                {
                                __context__.SourceCodeLine = 614;
                                return (ushort)( 4) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 615;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomin" , STEMPDATA ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 615;
                                    return (ushort)( 5) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 616;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomout" , STEMPDATA ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 616;
                                        return (ushort)( 6) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 617;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweron" , STEMPDATA ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 617;
                                            return (ushort)( 7) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 618;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweroff" , STEMPDATA ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 618;
                                                return (ushort)( 8) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 619;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetrec" , STEMPDATA ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 619;
                                                    return (ushort)( (Functions.Atoi( STEMPDATA ) + 100)) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 620;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetsav" , STEMPDATA ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 620;
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
            
            __context__.SourceCodeLine = 638;
            LISTFB__DOLLAR__ [ ILIST]  .UpdateValue ( SDATA  ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 648;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 650;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 651;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 655;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 657;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 657;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 659;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 660;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 662;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 663;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 664;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 655;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 668;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 670;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 671;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 680;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 682;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 684;
                    STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                    __context__.SourceCodeLine = 685;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 689;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 691;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 691;
                            MakeString ( STEMP , "{{ListVisFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 693;
                        MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                        __context__.SourceCodeLine = 694;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 696;
                            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                            __context__.SourceCodeLine = 697;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 698;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 689;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 702;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 704;
                    MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                    __context__.SourceCodeLine = 705;
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
            
            
            __context__.SourceCodeLine = 715;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 717;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 719;
                MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                __context__.SourceCodeLine = 720;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 722;
                    MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                    __context__.SourceCodeLine = 720;
                    } 
                
                __context__.SourceCodeLine = 724;
                STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                __context__.SourceCodeLine = 725;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 729;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 731;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 733;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 733;
                            MakeString ( STEMP , "{{ListTextFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 735;
                        MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                        __context__.SourceCodeLine = 736;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 738;
                            MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                            __context__.SourceCodeLine = 736;
                            } 
                        
                        __context__.SourceCodeLine = 740;
                        MakeString ( STEMP , "{0}|", STEMP ) ; 
                        __context__.SourceCodeLine = 742;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 600 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 744;
                            MakeString ( STEMP , "{0};}}", STEMP ) ; 
                            __context__.SourceCodeLine = 745;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 746;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 729;
                    } 
                
                __context__.SourceCodeLine = 750;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 752;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 753;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTFBFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 765;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 767;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 768;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 772;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 774;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 774;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 776;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 777;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 779;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 780;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 781;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 772;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 785;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 787;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 788;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVISFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 796;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 798;
                MakeString ( STEMP , "{{ListVisFB:{0:d}={1:d},", (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 802;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 804;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 804;
                        MakeString ( STEMP , "{{ListVisFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 806;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    __context__.SourceCodeLine = 807;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 809;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 810;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 811;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 802;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 815;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 817;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 818;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXTFILTER (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 827;
            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
            __context__.SourceCodeLine = 829;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 831;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 831;
                    MakeString ( STEMP , "{{ListTextFB:") ; 
                    }
                
                __context__.SourceCodeLine = 833;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 835;
                    MakeString ( STEMP , "{0}{1:d}={2},|", STEMP , (ushort)FILTER[ ILIST ].ITEM[ I ].IGLOBALTOLIST, FILTER [ ILIST] . ITEM [ I] . STEXT [ 1 ] ) ; 
                    } 
                
                __context__.SourceCodeLine = 840;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 800 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 842;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 843;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 844;
                    STEMP  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 829;
                } 
            
            __context__.SourceCodeLine = 847;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 849;
                MakeString ( STEMP , "{0};}}", STEMP ) ; 
                __context__.SourceCodeLine = 850;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            
            }
            
        private void FCONFIGURELISTFBSETVISIBLEITEMS (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 871;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 873;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IVIS)  ) ) 
                    { 
                    __context__.SourceCodeLine = 875;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 876;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 871;
                } 
            
            
            }
            
        private void FCONFIGURELISTFBRESETALL (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 884;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 886;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 888;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 889;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 884;
                } 
            
            __context__.SourceCodeLine = 892;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            
            }
            
        private CrestronString FGETROUTEDSOURCENAME (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1013;
            try 
                { 
                __context__.SourceCodeLine = 1015;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1017;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1019;
                        return ( LIST [ (ILIST - 1)] . ITEM [ LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC] . SGLOBALNAME ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1021;
                        return ( SYS . SBLANKSRCTEXT ) ; 
                        }
                    
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1026;
                Trace( "GlobalMST fGetRoutedSourceName - error - iList={0:d}, iIndex={1:d}, List[{2:d}].Item[{3:d}].iRoutedSrc={4:d}", (ushort)ILIST, (ushort)IINDEX, (ushort)ILIST, (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC) ; 
                
                }
                
                
                return ""; // default return value (none specified in module)
                }
                
            private ushort FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX , ushort ITEXTCOLUMN ) 
                { 
                
                __context__.SourceCodeLine = 1033;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1035;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)ITEXTCOLUMN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1037;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1038;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( FGETROUTEDSOURCENAME (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX ))  ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 1041;
                    return (ushort)( 0) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1043;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1045;
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
                
                
                __context__.SourceCodeLine = 1073;
                STEMPDATA  .UpdateValue ( STEMP  ) ; 
                __context__.SourceCodeLine = 1074;
                STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
                __context__.SourceCodeLine = 1076;
                while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1078;
                    STEMP2  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 1079;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_V_RTE" , STEMPHEADER ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1081;
                        STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                        __context__.SourceCodeLine = 1082;
                        IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                        __context__.SourceCodeLine = 1083;
                        IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                        __context__.SourceCodeLine = 1084;
                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1086;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_rte" , STEMPHEADER ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1088;
                            Trace( "in GlobalMST usb_rte") ; 
                            __context__.SourceCodeLine = 1089;
                            STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                            __context__.SourceCodeLine = 1090;
                            IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                            __context__.SourceCodeLine = 1091;
                            IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                            __context__.SourceCodeLine = 1092;
                            Trace( "iGUIDdst = {0:d}, iGUIDsrc = {1:d}", (ushort)IGUIDDST, (ushort)IGUIDSRC) ; 
                            __context__.SourceCodeLine = 1094;
                            FUSBSENDROUTE (  __context__ , (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1096;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_ctrl" , STEMPHEADER ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1098;
                                STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                __context__.SourceCodeLine = 1099;
                                I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                __context__.SourceCodeLine = 1100;
                                if ( Functions.TestForTrue  ( ( I)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1102;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1103;
                                    CAM_FOLDEDCMD [ I]  .Value = (ushort) ( FCAMGETFOLDEDCMD( __context__ , STEMP2 ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1107;
                                    Trace( "Global fProcessRoomData, found cam_ctrl - iCamGUID resolved to zero(0)") ; 
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1110;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "dply_cmd" , STEMPHEADER ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1112;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1113;
                                    I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                    __context__.SourceCodeLine = 1114;
                                    if ( Functions.TestForTrue  ( ( I)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1116;
                                        STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                        __context__.SourceCodeLine = 1118;
                                        DISPLAY_FOLDEDCMD [ I]  .Value = (ushort) ( (Functions.Atoi( STEMP2 ) + 10) ) ; 
                                        __context__.SourceCodeLine = 1122;
                                        IDISPLAYVGUID = (ushort) ( SYS.DISPLAY.IGUID[ I ] ) ; 
                                        __context__.SourceCodeLine = 1123;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 1))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1125;
                                            IRELAYTYPE = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1127;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYPROCESSOR == 6))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1129;
                                                IRELAYTYPE = (ushort) ( 2 ) ; 
                                                } 
                                            
                                            }
                                        
                                        __context__.SourceCodeLine = 1132;
                                        if ( Functions.TestForTrue  ( ( IRELAYTYPE)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1134;
                                            
                                                {
                                                int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.Atoi( STEMP2 ));
                                                
                                                    { 
                                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1138;
                                                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__1 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYOFFNUMOF; 
                                                        int __FN_FORSTEP_VAL__1 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                                                            { 
                                                            __context__.SourceCodeLine = 1140;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1141;
                                                            Functions.Delay (  (int) ( 50 ) ) ; 
                                                            __context__.SourceCodeLine = 1142;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYOFF[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1138;
                                                            } 
                                                        
                                                        } 
                                                    
                                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1147;
                                                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__2 = (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].IRELAYONNUMOF; 
                                                        int __FN_FORSTEP_VAL__2 = (int)1; 
                                                        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
                                                            { 
                                                            __context__.SourceCodeLine = 1149;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=1,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1150;
                                                            Functions.Delay (  (int) ( 50 ) ) ; 
                                                            __context__.SourceCodeLine = 1151;
                                                            MakeString ( RELAY_DATAINIT__DOLLAR__ [ IRELAYTYPE] , "{{ListButtonFB:{0:d}=0,|;}}", (ushort)LIST[ 2 ].ITEM[ IDISPLAYVGUID ].RELAYON[ J ].IRELAYINDEX) ; 
                                                            __context__.SourceCodeLine = 1147;
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
                    
                    __context__.SourceCodeLine = 1076;
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
                    
                    
                    __context__.SourceCodeLine = 1166;
                    IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1168;
                    STEMPDATA  .UpdateValue ( Functions.Gather ( Functions.Length( FROM_ROOM_RX__DOLLAR__[ IROOM ] ), FROM_ROOM_RX__DOLLAR__ [ IROOM ] )  ) ; 
                    __context__.SourceCodeLine = 1169;
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
                
                
                __context__.SourceCodeLine = 1178;
                if ( Functions.TestForTrue  ( ( LIST[ 2 ].IINITIALIZED)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1180;
                    IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1182;
                    ISRC = (ushort) ( MTRX_V_IN[ IDST ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 1184;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 1000 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1186;
                        Trace( "GlobalMST - Change MTRX_V_In, dstGUID={0:d}, srcValue(not a GUID)={1:d}", (ushort)IDST, (ushort)ISRC) ; 
                        __context__.SourceCodeLine = 1187;
                        ISRC = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1188;
                        LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 1189;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                        __context__.SourceCodeLine = 1190;
                        FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1192;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISRC ) && Functions.TestForTrue ( Functions.BoolToInt (ISRC != LIST[ 2 ].ITEM[ IDST ].IROUTEDSRC) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1194;
                            LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 1195;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                            __context__.SourceCodeLine = 1196;
                            FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                            __context__.SourceCodeLine = 1198;
                            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IRMASS)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1200;
                                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 2 ].ITEM[ IDST ].IRMASS] , "{{MTRX_V_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 2 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1207;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ISRC ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1209;
                                Trace( "GlobalMST - Change MTRX_V_In, iSrc == 0") ; 
                                __context__.SourceCodeLine = 1210;
                                LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 1211;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                                __context__.SourceCodeLine = 1212;
                                FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1216;
                                Trace( "GlobalMST MTRX_V_In - else trap") ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1219;
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
            
            
            __context__.SourceCodeLine = 1227;
            if ( Functions.TestForTrue  ( ( LIST[ 4 ].IINITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 1229;
                IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 1231;
                ISRC = (ushort) ( MTRX_A_IN[ IDST ] .UshortValue ) ; 
                __context__.SourceCodeLine = 1232;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISRC != LIST[ 4 ].ITEM[ IDST ].IROUTEDSRC))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1234;
                    LIST [ 4] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                    __context__.SourceCodeLine = 1235;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                    __context__.SourceCodeLine = 1236;
                    FUPDATELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST )) ; 
                    __context__.SourceCodeLine = 1238;
                    if ( Functions.TestForTrue  ( ( LIST[ 4 ].ITEM[ IDST ].IRMASS)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1240;
                        MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 4 ].ITEM[ IDST ].IRMASS] , "{{MTRX_A_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 4 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 3] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1248;
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
    
    
    __context__.SourceCodeLine = 1266;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1268;
        LIST [ ILIST] . IINITIALIZED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1270;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1272;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1273;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1275;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1275;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 2 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1270;
            } 
        
        __context__.SourceCodeLine = 1278;
        FUPDATELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1279;
        FUPDATELISTVIS (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1281;
        Functions.Delay (  (int) ( 100 ) ) ; 
        __context__.SourceCodeLine = 1283;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)23; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 1285;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ I] , "{0}COMPLETE|}}", FGETDATAHEADER (  __context__ , (ushort)( ILIST )) ) ; 
            __context__.SourceCodeLine = 1286;
            Functions.Delay (  (int) ( 200 ) ) ; 
            __context__.SourceCodeLine = 1283;
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1290;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1292;
            LIST_NUMOFITEMS [ ILIST]  .Value = (ushort) ( FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1293;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 1295;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
                __context__.SourceCodeLine = 1293;
                } 
            
            __context__.SourceCodeLine = 1297;
            FUPDATELISTTEXTFILTER (  __context__ , (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1298;
            FUPDATELISTVISFILTER (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
            } 
        
        }
    
    __context__.SourceCodeLine = 1301;
    Functions.Delay (  (int) ( 100 ) ) ; 
    __context__.SourceCodeLine = 1303;
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
    
    
    __context__.SourceCodeLine = 1317;
    STEMPHEADER  .UpdateValue ( FGETDATAHEADER (  __context__ , (ushort)( ITYPE ))  ) ; 
    __context__.SourceCodeLine = 1319;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1321;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1323;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISUSB)  ) ) 
                {
                __context__.SourceCodeLine = 1323;
                MakeString ( STEMPUSB , " usb_mac={0},", LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR ) ; 
                }
            
            __context__.SourceCodeLine = 1325;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
                {
                __context__.SourceCodeLine = 1325;
                MakeString ( STEMP , "is_camera=1, cam_localID={0:d}, cam_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMGUID) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1329;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                    {
                    __context__.SourceCodeLine = 1329;
                    MakeString ( STEMP , "is_display=1, display_localID={0:d}, display_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYGUID) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1334;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].ISYSPRESET)  ) ) 
                {
                __context__.SourceCodeLine = 1334;
                MakeString ( STEMPSYSPRESET , "sys_preset={0:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ISYSPRESET) ; 
                }
            
            __context__.SourceCodeLine = 1337;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] , "{{{0} LOCALID={1:d}: GUID={2:d}, global_name={3}, local_name={4}, {5}{6}is_virtual={7:d}, {8}|}}", STEMPHEADER , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID, (ushort)IINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME , STEMPSYSPRESET , STEMP , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL, STEMPUSB ) ; 
            __context__.SourceCodeLine = 1350;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                {
                __context__.SourceCodeLine = 1350;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . IVIRTUALVDSTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID] = (ushort) ( IINDEX ) ; 
                }
            
            __context__.SourceCodeLine = 1351;
            Functions.Delay (  (int) ( 5 ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1319;
        } 
    
    __context__.SourceCodeLine = 1355;
    Functions.Delay (  (int) ( 300 ) ) ; 
    __context__.SourceCodeLine = 1356;
    FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
    
    }
    
private short FPROCESSLINESYS (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    CrestronString STEMPLINE;
    CrestronString STEMPPAIR;
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 1371;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1372;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1374;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1375;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1376;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1378;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1378;
            LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1380;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_ass" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1380;
                LIST [ ITYPE] . ITEM [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1381;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_id" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1381;
                    LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1383;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function_id" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1383;
                        LIST [ ITYPE] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1384;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "filter" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1384;
                            LIST [ ITYPE] . ITEM [ IINDEX] . IFILTERID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1386;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1386;
                                LIST [ ITYPE] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1387;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_src_id" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1387;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1389;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1389;
                                        LIST [ ITYPE] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 1393;
                                        Trace( "error - MTRX Init Data - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                        __context__.SourceCodeLine = 1394;
                                        return (short)( 1) ; 
                                        } 
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1372;
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
private short FPROCESSLINEDEVICE (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    CrestronString STEMPLINE;
    CrestronString STEMPPAIR;
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 1406;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1407;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1409;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1410;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1411;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1414;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "device_type" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1414;
            LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1415;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ip_address" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1415;
                LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1417;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1417;
                    LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1418;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1418;
                        LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1420;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_vtc" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1420;
                            LIST [ ITYPE] . ITEM [ IINDEX] . IISVTC = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1422;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "com_port" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1422;
                                LIST [ ITYPE] . ITEM [ IINDEX] . ICOMPORT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1423;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "processor_index" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1423;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1427;
                                    Trace( "error - MTRX Init Data - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                    __context__.SourceCodeLine = 1428;
                                    return (short)( 1) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1407;
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
private short FPROCESSLINEIO (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort I = 0;
    
    CrestronString STEMPLINE;
    CrestronString STEMPPAIR;
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    CrestronString STEMP;
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    
    __context__.SourceCodeLine = 1442;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1443;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1445;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1446;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1447;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1450;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cmd_io" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1452;
            LIST [ ITYPE] . ITEM [ IINDEX] . SCMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
            __context__.SourceCodeLine = 1453;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICMDDATA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1455;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1457;
                STEMPVALUE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                __context__.SourceCodeLine = 1458;
                MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR , "{0}{1}{2}", Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 1 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 3 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 5 ) , (int)( 2 ) ) ) ) ) ) ; 
                __context__.SourceCodeLine = 1463;
                LIST [ ITYPE] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1465;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "relay_proc" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1465;
                    LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYPROCESSOR = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1466;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_on" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1468;
                        I = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1469;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1471;
                            STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                            __context__.SourceCodeLine = 1472;
                            LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                            __context__.SourceCodeLine = 1473;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1475;
                                STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                __context__.SourceCodeLine = 1476;
                                LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1477;
                                LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1479;
                            I = (ushort) ( (I + 1) ) ; 
                            __context__.SourceCodeLine = 1469;
                            } 
                        
                        __context__.SourceCodeLine = 1481;
                        LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYONNUMOF = (ushort) ( I ) ; 
                        __context__.SourceCodeLine = 1482;
                        I = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1484;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "rly_off" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1486;
                            I = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1487;
                            while ( Functions.TestForTrue  ( ( Functions.Find( "+" , STEMPVALUE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1489;
                                STEMP  .UpdateValue ( Functions.Remove ( "+" , STEMPVALUE )  ) ; 
                                __context__.SourceCodeLine = 1490;
                                LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IRELAYINDEX = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                __context__.SourceCodeLine = 1491;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "^" , STEMP ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1493;
                                    STRASH  .UpdateValue ( Functions.Remove ( "^" , STEMP )  ) ; 
                                    __context__.SourceCodeLine = 1494;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . IISINITINDEX = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1495;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "+" , STEMP ) - 1) ) )  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 1497;
                                I = (ushort) ( (I + 1) ) ; 
                                __context__.SourceCodeLine = 1487;
                                } 
                            
                            __context__.SourceCodeLine = 1499;
                            LIST [ ITYPE] . ITEM [ IINDEX] . IRELAYOFFNUMOF = (ushort) ( I ) ; 
                            __context__.SourceCodeLine = 1500;
                            I = (ushort) ( 0 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1502;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vtc_io" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1502;
                                LIST [ ITYPE] . ITEM [ IINDEX] . IVTCIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1506;
                                Trace( "error - MTRX Init Data - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                __context__.SourceCodeLine = 1507;
                                return (short)( 1) ; 
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1443;
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
private void FPROCESSLINEISCAM (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX ) 
    { 
    ushort I = 0;
    ushort ICAMGUID = 0;
    
    
    __context__.SourceCodeLine = 1516;
    SYS . CAM . INUMOFCAMS = (ushort) ( (SYS.CAM.INUMOFCAMS + 1) ) ; 
    __context__.SourceCodeLine = 1517;
    SYS . CAM . IGUID [ SYS.CAM.INUMOFCAMS] = (ushort) ( IINDEX ) ; 
    __context__.SourceCodeLine = 1518;
    ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFCAMS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS + 1) ) ; 
    __context__.SourceCodeLine = 1519;
    LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1520;
    LIST [ ITYPE] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS ) ; 
    __context__.SourceCodeLine = 1521;
    LIST [ ITYPE] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
    __context__.SourceCodeLine = 1522;
    ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
    __context__.SourceCodeLine = 1524;
    MakeString ( CAM_DATAINIT__DOLLAR__ [ 1] , "{{ListTextFB:{0:d}= global_name={1}~ip={2},|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS ) ; 
    __context__.SourceCodeLine = 1529;
    MakeString ( LISTFB__DOLLAR__ [ 12] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)ICAMGUID) ; 
    
    }
    
private void FPROCESSLINEISDISPLAY (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX ) 
    { 
    ushort I = 0;
    ushort IDISPLAYGUID = 0;
    
    CrestronString STEMPCOMPORT;
    STEMPCOMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 1541;
    SYS . DISPLAY . INUMOFDISPLAYS = (ushort) ( (SYS.DISPLAY.INUMOFDISPLAYS + 1) ) ; 
    __context__.SourceCodeLine = 1542;
    SYS . DISPLAY . IGUID [ SYS.DISPLAY.INUMOFDISPLAYS] = (ushort) ( IINDEX ) ; 
    __context__.SourceCodeLine = 1543;
    ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFDISPLAYS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS + 1) ) ; 
    __context__.SourceCodeLine = 1544;
    LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1545;
    LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS ) ; 
    __context__.SourceCodeLine = 1546;
    IDISPLAYGUID = (ushort) ( SYS.DISPLAY.INUMOFDISPLAYS ) ; 
    __context__.SourceCodeLine = 1547;
    LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( IDISPLAYGUID ) ; 
    __context__.SourceCodeLine = 1549;
    LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( 5 ) ; 
    __context__.SourceCodeLine = 1551;
    STEMPCOMPORT  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 1553;
    if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT)  ) ) 
        {
        __context__.SourceCodeLine = 1553;
        MakeString ( STEMPCOMPORT , "~com_port={0:d},", (ushort)LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT) ; 
        }
    
    __context__.SourceCodeLine = 1555;
    MakeString ( DISPLAY_DATAINIT__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IPROCESSORINDEX] , "{{ListTextFB:{0:d}= global_name={1}~ip={2}~device_type={3}{4},|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS , LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE , STEMPCOMPORT ) ; 
    __context__.SourceCodeLine = 1562;
    MakeString ( LISTFB__DOLLAR__ [ 13] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)IDISPLAYGUID) ; 
    __context__.SourceCodeLine = 1569;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYPROCESSOR == 6))  ) ) 
        { 
        __context__.SourceCodeLine = 1571;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYONNUMOF; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 1572;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IISINITINDEX )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1574;
                MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYON[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYON [ I] . SIPADDRESS ) ; 
                } 
            
            __context__.SourceCodeLine = 1571;
            }
        
        __context__.SourceCodeLine = 1579;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IRELAYOFFNUMOF; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            {
            __context__.SourceCodeLine = 1580;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX ) && Functions.TestForTrue ( LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IISINITINDEX )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1582;
                MakeString ( RELAY_DATAINIT__DOLLAR__ [ 2] , "{{ListTextFB:{0:d}= ip={1},|;}}", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].RELAYOFF[ I ].IRELAYINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . RELAYOFF [ I] . SIPADDRESS ) ; 
                } 
            
            __context__.SourceCodeLine = 1579;
            }
        
        } 
    
    
    }
    
private void FPROCESSLINEISVTCIO (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX ) 
    { 
    
    __context__.SourceCodeLine = 1592;
    
        {
        int __SPLS_TMPVAR__SWTCH_5__ = ((int)ITYPE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                {
                __context__.SourceCodeLine = 1595;
                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVOUTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                }
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                {
                __context__.SourceCodeLine = 1597;
                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVINGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                }
            
            } 
            
        }
        
    
    
    }
    
private void FPROCESSLINE (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort IERR = 0;
    
    CrestronString STEMPLINE;
    CrestronString STEMP;
    CrestronString STEMP2;
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1610;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1613;
    while ( Functions.TestForTrue  ( ( Functions.Find( "]" , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1615;
        STEMP  .UpdateValue ( Functions.Remove ( "[" , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1616;
        STEMP2  .UpdateValue ( Functions.Remove ( "]" , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1618;
        if ( Functions.TestForTrue  ( ( Functions.Find( "sys_data" , STEMP ))  ) ) 
            {
            __context__.SourceCodeLine = 1618;
            IERR = (ushort) ( FPROCESSLINESYS( __context__ , (ushort)( ITYPE ) , (ushort)( IINDEX ) , STEMP2 ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1619;
            if ( Functions.TestForTrue  ( ( Functions.Find( "device_data" , STEMP ))  ) ) 
                {
                __context__.SourceCodeLine = 1619;
                IERR = (ushort) ( FPROCESSLINEDEVICE( __context__ , (ushort)( ITYPE ) , (ushort)( IINDEX ) , STEMP2 ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1620;
                if ( Functions.TestForTrue  ( ( Functions.Find( "io_data" , STEMP ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1620;
                    IERR = (ushort) ( FPROCESSLINEIO( __context__ , (ushort)( ITYPE ) , (ushort)( IINDEX ) , STEMP2 ) ) ; 
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1613;
        } 
    
    __context__.SourceCodeLine = 1623;
    if ( Functions.TestForTrue  ( ( IERR)  ) ) 
        {
        __context__.SourceCodeLine = 1623;
        Trace( "GlobalMST - in fProcessLine - iErr<>0, iType={0:d}, iIndex={1:d}", (ushort)ITYPE, (ushort)IINDEX) ; 
        }
    
    else 
        { 
        __context__.SourceCodeLine = 1626;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1628;
            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , "{0:d3} {1}", (ushort)ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].IROOMNUM, LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME ) ; 
            } 
        
        __context__.SourceCodeLine = 1634;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
            {
            __context__.SourceCodeLine = 1634;
            FPROCESSLINEISCAM (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1635;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                {
                __context__.SourceCodeLine = 1635;
                FPROCESSLINEISDISPLAY (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1636;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC)  ) ) 
                    {
                    __context__.SourceCodeLine = 1636;
                    FPROCESSLINEISVTCIO (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1638;
        LIST [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1639;
        LIST [ ITYPE] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1640;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
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
    
    
    __context__.SourceCodeLine = 1652;
    if ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1654;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1655;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1657;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1658;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 1659;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_guid" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1659;
                IINDEX = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1660;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1660;
                    ROOM [ IINDEX] . SROOMNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) ))  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1661;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bldg_rm_num" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1661;
                        ROOM [ IINDEX] . IROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1662;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1662;
                            ROOM [ IINDEX] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1663;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1663;
                                ROOM [ IINDEX] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1655;
            } 
        
        __context__.SourceCodeLine = 1666;
        MakeString ( TO_ROOM_TX__DOLLAR__ [ IINDEX] , "{{ROOMS; RoomID={0:d}:{1},{2:d},discrete_macro_mode={3:d},macro_take_mode={4:d}|}}", (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME , (ushort)ROOM[ IINDEX ].IROOMNUM, (ushort)ROOM[ IINDEX ].IDISCRETEMACROMODE, (ushort)ROOM[ IINDEX ].IMACROTAKEMODE) ; 
        __context__.SourceCodeLine = 1673;
        MakeString ( LISTFB__DOLLAR__ [ 11] , "{{ListVisFB:{0:d}=1,; ListTextFB:{1:d}={2},|;}}", (ushort)IINDEX, (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME ) ; 
        } 
    
    
    }
    
private ushort FGETSOURCEDESTENUM (  SplusExecutionContext __context__, CrestronString STEMP ) 
    { 
    
    __context__.SourceCodeLine = 1680;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "source" , STEMP ))  ) ) 
        {
        __context__.SourceCodeLine = 1680;
        return (ushort)( 5) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1681;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "dest" , STEMP ))  ) ) 
            {
            __context__.SourceCodeLine = 1681;
            return (ushort)( 7) ; 
            }
        
        }
    
    __context__.SourceCodeLine = 1683;
    return (ushort)( 0) ; 
    
    }
    
private void FPROCESSFILTER (  SplusExecutionContext __context__, ushort ITYPE , ushort IINDEX , CrestronString STEMPLINE ) 
    { 
    ushort I = 0;
    ushort IFILTERTYPE = 0;
    ushort IFILTERINDEX = 0;
    ushort IGROUPINDEX = 0;
    ushort IERR = 0;
    
    CrestronString SFILTERNAME;
    CrestronString SGROUPNAME;
    CrestronString STEMPKEY;
    CrestronString STEMPVALUE;
    CrestronString SDATA;
    SFILTERNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    SGROUPNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 1700;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1704;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1706;
        STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
        __context__.SourceCodeLine = 1707;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPVALUE )  ) ; 
        __context__.SourceCodeLine = 1709;
        if ( Functions.TestForTrue  ( ( Functions.Find( "filter_type" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1709;
            IFILTERTYPE = (ushort) ( FGETSOURCEDESTENUM( __context__ , STEMPVALUE ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1710;
            if ( Functions.TestForTrue  ( ( Functions.Find( "filter_id" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1710;
                IFILTERINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1711;
                if ( Functions.TestForTrue  ( ( Functions.Find( "group_id" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1711;
                    IGROUPINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1712;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "filter_name" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1712;
                        SFILTERNAME  .UpdateValue ( Functions.Left ( STEMPVALUE ,  (int) ( (Functions.Find( "," , STEMPVALUE ) - 1) ) )  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1713;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "group_name" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1713;
                            SGROUPNAME  .UpdateValue ( Functions.Left ( STEMPVALUE ,  (int) ( (Functions.Find( "," , STEMPVALUE ) - 1) ) )  ) ; 
                            }
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1714;
                            IERR = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1714;
                            break ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1704;
        } 
    
    __context__.SourceCodeLine = 1717;
    if ( Functions.TestForTrue  ( ( IERR)  ) ) 
        {
        __context__.SourceCodeLine = 1717;
        Trace( "Global - in fProcessFilter - caught iErr.   iIndex={0:d}, {1}{2}", (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
        }
    
    else 
        { 
        } 
    
    __context__.SourceCodeLine = 1799;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1801;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1802;
        FILTER [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1803;
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
    
    
    __context__.SourceCodeLine = 1825;
    STEMPDATA2  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1826;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1827;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1829;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VSRC" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1829;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1830;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VDST" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1830;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1831;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ASRC" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1831;
                ITYPE = (ushort) ( 3 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1832;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ADST" , STEMPHEADER ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1832;
                    ITYPE = (ushort) ( 4 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1833;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCF" , STEMPHEADER ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1833;
                        ITYPE = (ushort) ( 5 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1834;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCG" , STEMPHEADER ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1834;
                            ITYPE = (ushort) ( 6 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1835;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTF" , STEMPHEADER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1835;
                                ITYPE = (ushort) ( 7 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1836;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTG" , STEMPHEADER ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1836;
                                    ITYPE = (ushort) ( 8 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1837;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1837;
                                        ITYPE = (ushort) ( 13 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1838;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MACRO" , STEMPHEADER ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1838;
                                            ITYPE = (ushort) ( 14 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1839;
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
    
    __context__.SourceCodeLine = 1841;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
        {
        __context__.SourceCodeLine = 1841;
        if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPDATA2 ))  ) ) 
            {
            __context__.SourceCodeLine = 1841;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ Functions.Atoi( STEMPDATA2 )] , "{0}", STEMPDATA2 ) ; 
            }
        
        }
    
    __context__.SourceCodeLine = 1843;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1845;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1846;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1848;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITYPE >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITYPE <= 4 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1848;
                FPROCESSLINESTOROOM (  __context__ , (ushort)( ITYPE )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1849;
                FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1851;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                {
                __context__.SourceCodeLine = 1851;
                FPROCESSROOMS (  __context__ , (ushort)( ITYPE ), STEMPLINE) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1854;
                STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
                __context__.SourceCodeLine = 1855;
                IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                __context__.SourceCodeLine = 1856;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1858;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_6__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1860;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1861;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1862;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1863;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1864;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1865;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1866;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1867;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1870;
                    Trace( "error - MTRX fProcessInit, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1843;
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
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20000, this );
        
        
        __context__.SourceCodeLine = 1883;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 1885;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 1886;
            FPROCESSINIT (  __context__ , STEMP) ; 
            __context__.SourceCodeLine = 1883;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FUPDATEVTC (  SplusExecutionContext __context__, ushort IVTCSEL ) 
    { 
    ushort I = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1903;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1904;
    VTC_CTRL_SEL_UNITNAME__DOLLAR__  .UpdateValue ( SYS . VTC [ SYS.IVTCSEL] . SUNITNAME  ) ; 
    __context__.SourceCodeLine = 1905;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].IROOMRES)  ) ) 
        {
        __context__.SourceCodeLine = 1905;
        STEMP  .UpdateValue ( ROOM [ SYS.VTC[ IVTCSEL ].IROOMRES] . SROOMNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1906;
    VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1907;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1908;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICAMSELECT)  ) ) 
        {
        __context__.SourceCodeLine = 1908;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICAMSELECT] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1909;
    VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1910;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1911;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICONTENTSRC)  ) ) 
        {
        __context__.SourceCodeLine = 1911;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICONTENTSRC] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1912;
    VTC_CONTENTSHARE_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    
    }
    
object VTC_CTRL_SEL_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1923;
        SYS . IVTCSEL = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1925;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)3; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 1925;
            VTC_CTRL_SEL_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1925;
            }
        
        __context__.SourceCodeLine = 1926;
        VTC_CTRL_SEL_FB [ SYS.IVTCSEL]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1928;
        FUPDATEVTC (  __context__ , (ushort)( SYS.IVTCSEL )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_SENDTOVTC_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IVTC = 0;
        ushort ISRCGUID = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        
        __context__.SourceCodeLine = 1938;
        IVTC = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1941;
        ISRCGUID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1942;
        STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
        __context__.SourceCodeLine = 1945;
        if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 1947;
            ISRCGUID = (ushort) ( SYS.CAM.IGUID[ SYS.ICAMSEL ] ) ; 
            __context__.SourceCodeLine = 1948;
            STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ SYS.ICAMSEL ]] . SGLOBALNAME  ) ; 
            } 
        
        __context__.SourceCodeLine = 1951;
        SYS . VTC [ IVTC] . ICAMSELECT = (ushort) ( ISRCGUID ) ; 
        __context__.SourceCodeLine = 1953;
        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ IVTC ].IVINGUID[ 1 ] ), (ushort)( SYS.VTC[ IVTC ].ICAMSELECT )) ; 
        __context__.SourceCodeLine = 1954;
        VTC_CAMSELECT_NAME__DOLLAR__ [ IVTC]  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1955;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVTC == SYS.IVTCSEL))  ) ) 
            {
            __context__.SourceCodeLine = 1955;
            VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_FOLDEDCTRL_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1961;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYS.UI.ISUB == 2))  ) ) 
            { 
            __context__.SourceCodeLine = 1963;
            if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
                { 
                __context__.SourceCodeLine = 1965;
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
    
    
    __context__.SourceCodeLine = 1981;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1983;
        if ( Functions.TestForTrue  ( ( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST)  ) ) 
            { 
            __context__.SourceCodeLine = 1985;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1987;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1989;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1989;
                        FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1990;
                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1985;
                } 
            
            } 
        
        } 
    
    
    }
    
private void FMTRXCLEARROUTES (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 2001;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2003;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2005;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                { 
                __context__.SourceCodeLine = 2007;
                if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2007;
                    FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2008;
                    FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 2003;
            } 
        
        } 
    
    
    }
    
object MTRX_TAKE_ALL_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2021;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 2022;
        FMTRXTAKE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_TAKE_VIDEO_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2027;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_TAKE_AUDIO_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2032;
        FMTRXTAKE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_ALL_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2037;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 2038;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 2039;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 2040;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_VIDEO_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2044;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 2045;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_DESELECT_AUDIO_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2049;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 2050;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2054;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 2055;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_VIDEO_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2059;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELECT_ALL_AUDIO_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2063;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_CLEAR_ROUTE_ALL_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2067;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 2068;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FCONFIGURELISTFBTOGGLE (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
    { 
    
    __context__.SourceCodeLine = 2079;
    LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( LIST[ ILIST ].ITEM[ IINDEX ].IFB ) ) ; 
    __context__.SourceCodeLine = 2080;
    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
    
    }
    
private ushort FCONFIGURELISTFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
    { 
    ushort ISAME = 0;
    
    
    __context__.SourceCodeLine = 2086;
    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
        { 
        __context__.SourceCodeLine = 2088;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ILIST ].IITEMSELECTEDLAST == IINDEX))  ) ) 
            { 
            __context__.SourceCodeLine = 2090;
            LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2091;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2092;
            ISAME = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 2094;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                { 
                __context__.SourceCodeLine = 2096;
                LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 2097;
                FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                __context__.SourceCodeLine = 2098;
                LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 2099;
                LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 2103;
                LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 2104;
                LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 2106;
        FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 2107;
        if ( Functions.TestForTrue  ( ( ISAME)  ) ) 
            {
            __context__.SourceCodeLine = 2107;
            return (ushort)( 0) ; 
            }
        
        __context__.SourceCodeLine = 2108;
        return (ushort)( IINDEX) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 2112;
        if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
            { 
            __context__.SourceCodeLine = 2114;
            LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2115;
            FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
            __context__.SourceCodeLine = 2116;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            } 
        
        __context__.SourceCodeLine = 2122;
        return (ushort)( 0) ; 
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
object LIST_ITEMCLICKED_OnChange_17 ( Object __EventInfo__ )

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
        
        
        __context__.SourceCodeLine = 2136;
        IERR = (ushort) ( 10000 ) ; 
        __context__.SourceCodeLine = 2137;
        ILIST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2138;
        IINDEX = (ushort) ( LIST_ITEMCLICKED[ ILIST ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2140;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ) ) && Functions.TestForTrue ( IINDEX )) ))  ) ) 
            {
            __context__.SourceCodeLine = 2140;
            IINDEX = (ushort) ( FILTER[ ILIST ].ITEM[ IINDEX ].ILISTTOGLOBAL ) ; 
            }
        
        __context__.SourceCodeLine = 2142;
        
            {
            int __SPLS_TMPVAR__SWTCH_7__ = ((int)ILIST);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2144;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2145;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2146;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2147;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 5) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2148;
                    ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 6) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2149;
                    ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 7) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2150;
                    ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 8) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2151;
                    ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 2154;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_8__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2159;
                                IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                                __context__.SourceCodeLine = 2161;
                                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2163;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                    __context__.SourceCodeLine = 2164;
                                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__1 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__1 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                        { 
                                        __context__.SourceCodeLine = 2167;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 1 ].ITEM[ SYS.CAM.IGUID[ I ] ].IRMASS == IINDEX))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 2167;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 2168;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 2164;
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 2173;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 2174;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        {
                                        __context__.SourceCodeLine = 2174;
                                        LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                        __context__.SourceCodeLine = 2174;
                                        }
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 2176;
                                FUPDATELISTVIS (  __context__ , (ushort)( 12 ), (ushort)( 0 )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2180;
                                FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                                __context__.SourceCodeLine = 2182;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2184;
                                    IPREVIOUSROOM = (ushort) ( SYS.VTC[ SYS.IVTCSEL ].IROOMRES ) ; 
                                    __context__.SourceCodeLine = 2185;
                                    SYS . VTC [ SYS.IVTCSEL] . IROOMRES = (ushort) ( IINDEX ) ; 
                                    __context__.SourceCodeLine = 2186;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 2186;
                                        ROOM [ IINDEX] . IVTCASSIGNMENT = (ushort) ( SYS.IVTCSEL ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 2187;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 2187;
                                        ROOM [ IPREVIOUSROOM] . IVTCASSIGNMENT = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 2190;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IPREVIOUSROOM ) ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        { 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 2195;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPREVIOUSROOM == IINDEX))  ) ) 
                                            { 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 2200;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.BoolToInt (IPREVIOUSROOM != IINDEX) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 2203;
                                                Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                                __context__.SourceCodeLine = 2205;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2206;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2208;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 2209;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 2 ] ), (ushort)( 0 )) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 2213;
                                    if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 2216;
                                        Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                        __context__.SourceCodeLine = 2218;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 2219;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 2224;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 2225;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 2227;
                                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 1 ] )) ; 
                                        __context__.SourceCodeLine = 2228;
                                        if ( Functions.TestForTrue  ( ( SYS.VTC[ SYS.IVTCSEL ].IDUALDISPLAY)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 2230;
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
                    __context__.SourceCodeLine = 2240;
                    IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    __context__.SourceCodeLine = 2241;
                    SYS . ICAMSEL = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 2243;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_9__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2248;
                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.IVDSTPANELGUID ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 2252;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2254;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 2256;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( SYS.CAM.IGUID[ IINDEX ] ) ; 
                                        __context__.SourceCodeLine = 2257;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                        __context__.SourceCodeLine = 2258;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        __context__.SourceCodeLine = 2259;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 2263;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 2264;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                        __context__.SourceCodeLine = 2265;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        __context__.SourceCodeLine = 2266;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2273;
        if ( Functions.TestForTrue  ( ( IERR)  ) ) 
            { 
            __context__.SourceCodeLine = 2275;
            
                {
                int __SPLS_TMPVAR__SWTCH_10__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2277;
                        ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2278;
                        ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2279;
                        ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2280;
                        ; 
                        }
                    
                    } 
                    
                }
                
            
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
        
        __context__.SourceCodeLine = 2293;
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
        
        __context__.SourceCodeLine = 2298;
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
        
        __context__.SourceCodeLine = 2320;
        SYS . SBLANKSRCTEXT  .UpdateValue ( "---"  ) ; 
        __context__.SourceCodeLine = 2322;
        SYS . VTC [ 1] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit01"  ) ; 
        __context__.SourceCodeLine = 2323;
        SYS . VTC [ 2] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit02"  ) ; 
        __context__.SourceCodeLine = 2324;
        SYS . VTC [ 3] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit03"  ) ; 
        __context__.SourceCodeLine = 2326;
        LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2327;
        LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2328;
        LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2329;
        LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2331;
        LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2332;
        LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2333;
        LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2334;
        LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2335;
        LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2336;
        LIST [ 7] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2337;
        LIST [ 12] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2338;
        LIST [ 13] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2340;
        FILTER [ 6] . IMEMBERLISTFINDEX = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 2341;
        FILTER [ 8] . IMEMBERLISTFINDEX = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 2343;
        FILTER [ 5] . IMEMBERLISTVINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2344;
        FILTER [ 5] . IMEMBERLISTAINDEX = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 2346;
        FILTER [ 7] . IMEMBERLISTVINDEX = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2347;
        FILTER [ 7] . IMEMBERLISTAINDEX = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 2349;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2351;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2354;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 350 ) ; 
            __context__.SourceCodeLine = 2351;
            } 
        
        __context__.SourceCodeLine = 2356;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 3 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)4; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 2359;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 400 ) ; 
            __context__.SourceCodeLine = 2356;
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
        
    DATAINIT_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR___OnChange_3, true ) );
    for( uint i = 0; i < 3; i++ )
        VTC_CTRL_SEL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VTC_CTRL_SEL_OnPush_4, false ) );
        
    for( uint i = 0; i < 3; i++ )
        CAM_SENDTOVTC[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_SENDTOVTC_OnPush_5, false ) );
        
    CAM_FOLDEDCTRL.OnAnalogChange.Add( new InputChangeHandlerWrapper( CAM_FOLDEDCTRL_OnChange_6, false ) );
    MTRX_TAKE_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_ALL_OnPush_7, false ) );
    MTRX_TAKE_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_VIDEO_OnPush_8, false ) );
    MTRX_TAKE_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_AUDIO_OnPush_9, false ) );
    MTRX_DESELECT_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_ALL_OnPush_10, false ) );
    MTRX_DESELECT_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_VIDEO_OnPush_11, false ) );
    MTRX_DESELECT_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_DESELECT_AUDIO_OnPush_12, false ) );
    MTRX_SELECT_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_OnPush_13, false ) );
    MTRX_SELECT_ALL_VIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_VIDEO_OnPush_14, false ) );
    MTRX_SELECT_ALL_AUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELECT_ALL_AUDIO_OnPush_15, false ) );
    MTRX_CLEAR_ROUTE_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_CLEAR_ROUTE_ALL_OnPush_16, false ) );
    for( uint i = 0; i < 12; i++ )
        LIST_ITEMCLICKED[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( LIST_ITEMCLICKED_OnChange_17, false ) );
        
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

public UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_65 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
public class STFILTERITEM : SplusStructureBase
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
    public ushort  INUMOFMEMBERSV = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  INUMOFMEMBERSA = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  INUMOFMEMBERSF = 0;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  [] IMEMBERLISTV;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  [] IMEMBERLISTA;
    
    [SplusStructAttribute(14, false, false)]
    public ushort  [] IMEMBERLISTF;
    
    
    public STFILTERITEM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IMEMBERLISTV  = new ushort[ 401 ];
        IMEMBERLISTA  = new ushort[ 401 ];
        IMEMBERLISTF  = new ushort[ 101 ];
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        STEXT  = new CrestronString[ 5 ];
        for( uint i = 0; i < 5; i++ )
            STEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STFILTER : SplusStructureBase
{

    public STFILTERITEM [] ITEM;
    
    [SplusStructAttribute(0, false, false)]
    public ushort  IITEMSELECTEDLAST = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IHIGHESTLISTINDEX = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  IMEMBERLISTVINDEX = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IMEMBERLISTAINDEX = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IMEMBERLISTFINDEX = 0;
    
    
    public STFILTER( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ITEM  = new STFILTERITEM[ 101 ];
        for( uint i = 0; i < 101; i++ )
        {
            ITEM [i] = new STFILTERITEM( Owner, true );
            
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
