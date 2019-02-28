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

namespace UserModule_L3_UA_HSIB_GLOBALMST_V1_0_55
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_55 : SplusObject
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
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 315;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 315;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 316;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 325;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 325;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 327;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 328;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 329;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 331;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 331;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 332;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 329;
                } 
            
            __context__.SourceCodeLine = 334;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 335;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 335;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 337;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 338;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 339;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 341;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 341;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 342;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 343;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 344;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 339;
                } 
            
            __context__.SourceCodeLine = 347;
            return ( SDATA ) ; 
            
            }
            
        private ushort FHIGHESTLISTINDEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 353;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 355;
                LIST [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( LIST[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                __context__.SourceCodeLine = 356;
                return (ushort)( LIST[ ILIST ].IHIGHESTLISTINDEX) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 358;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 360;
                    FILTER [ ILIST] . IHIGHESTLISTINDEX = (ushort) ( Functions.Max( FILTER[ ILIST ].IHIGHESTLISTINDEX , IINDEX ) ) ; 
                    __context__.SourceCodeLine = 361;
                    return (ushort)( FILTER[ ILIST ].IHIGHESTLISTINDEX) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 363;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 11))  ) ) 
                        {
                        __context__.SourceCodeLine = 363;
                        return (ushort)( SYS.INUMOFROOMS) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 364;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 12))  ) ) 
                            {
                            __context__.SourceCodeLine = 364;
                            return (ushort)( SYS.CAM.INUMOFCAMS) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 365;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 365;
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
            
            __context__.SourceCodeLine = 370;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 372;
                        return ( "MTRX_VSRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 373;
                        return ( "MTRX_VDST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 374;
                        return ( "MTRX_ASRC;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 375;
                        return ( "MTRX_ADST;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 376;
                        return ( "MTRX_SRCF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 377;
                        return ( "MTRX_SRCG;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 378;
                        return ( "MTRX_DSTF;" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 379;
                        return ( "MTRX_DSTG;" ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            return ""; // default return value (none specified in module)
            }
            
        private void FUSBSENDROUTEKILL (  SplusExecutionContext __context__, ushort IDST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 394;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 398;
            Trace( "fUSBSendRouteKill, iDst = {0:d}, List[2].Item[iDst] = {1}", (ushort)IDST, LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            __context__.SourceCodeLine = 399;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4\u0000\u0000\u0000\u0001\u000a{0}", LIST [ 2] . ITEM [ IDST] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTETAKE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 406;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 408;
            FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
            __context__.SourceCodeLine = 410;
            MakeString ( USB_TX__DOLLAR__ , "\u00a9\u00c4\u00d8\u00f4\u0000\u0000\u0000\u0001\u0004{0}{1}", LIST [ 2] . ITEM [ IDST] . SUSBADDR , LIST [ 1] . ITEM [ ISRC] . SUSBADDR ) ; 
            
            }
            
        private void FUSBSENDROUTE (  SplusExecutionContext __context__, ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 418;
            Trace( "in GlobalMST - fUSBSendRoute, iSrc={0:d}, iDst={1:d}", (ushort)ISRC, (ushort)IDST) ; 
            __context__.SourceCodeLine = 419;
            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IISUSB)  ) ) 
                { 
                __context__.SourceCodeLine = 421;
                if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 423;
                    if ( Functions.TestForTrue  ( ( LIST[ 1 ].ITEM[ ISRC ].IISUSB)  ) ) 
                        { 
                        __context__.SourceCodeLine = 425;
                        Trace( "in GlobalMST - fUSBSendRoute - condition1") ; 
                        __context__.SourceCodeLine = 426;
                        FUSBSENDROUTETAKE (  __context__ , (ushort)( IDST ), (ushort)( ISRC )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 430;
                        Trace( "in GlobalMST - fUSBSendRoute - condition2") ; 
                        __context__.SourceCodeLine = 431;
                        FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 436;
                    Trace( "in GlobalMST - fUSBSendRoute - condition3") ; 
                    __context__.SourceCodeLine = 437;
                    FUSBSENDROUTEKILL (  __context__ , (ushort)( IDST )) ; 
                    } 
                
                } 
            
            
            }
            
        private void FMTRXSENDROUTE (  SplusExecutionContext __context__, ushort ILIST , ushort IDST , ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 445;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 449;
                        LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 450;
                        MTRX_V_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 454;
                        LIST [ ILIST] . ITEM [ IDST] . ILASTROUTEREQ = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 455;
                        MTRX_A_OUT [ IDST]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 459;
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
            
            
            __context__.SourceCodeLine = 479;
            if ( Functions.TestForTrue  ( ( IDST)  ) ) 
                { 
                __context__.SourceCodeLine = 481;
                IDSTROOM = (ushort) ( LIST[ 2 ].ITEM[ IDST ].IRMASS ) ; 
                __context__.SourceCodeLine = 482;
                ISRCROOM = (ushort) ( LIST[ 1 ].ITEM[ ISRC ].IRMASS ) ; 
                __context__.SourceCodeLine = 484;
                ILOCALID = (ushort) ( LIST[ 2 ].ITEM[ IDST ].ILOCALID ) ; 
                __context__.SourceCodeLine = 486;
                LIST [ 2] . ITEM [ IDST] . IVLINK = (ushort) ( ISRC ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 490;
                Trace( "GlobalMST - in fMTRXSendRouteVirtual - attempting function with iDst value 0") ; 
                __context__.SourceCodeLine = 491;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 495;
            STEMPNAME  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
            __context__.SourceCodeLine = 497;
            if ( Functions.TestForTrue  ( ( ISRC)  ) ) 
                {
                __context__.SourceCodeLine = 497;
                STEMPNAME  .UpdateValue ( LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME  ) ; 
                }
            
            __context__.SourceCodeLine = 499;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ IDSTROOM] , "{{V_LINK_VSRC; LocalID={0:d}: GUID={1:d},{2}|;}}", (ushort)ILOCALID, (ushort)ISRC, STEMPNAME ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCAMGETFOLDEDCMD (  SplusExecutionContext __context__, CrestronString STEMPDATA ) 
            { 
            
            __context__.SourceCodeLine = 517;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "stop" , STEMPDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 517;
                return (ushort)( 0) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 518;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "up" , STEMPDATA ))  ) ) 
                    {
                    __context__.SourceCodeLine = 518;
                    return (ushort)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 519;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "down" , STEMPDATA ))  ) ) 
                        {
                        __context__.SourceCodeLine = 519;
                        return (ushort)( 2) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 520;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "left" , STEMPDATA ))  ) ) 
                            {
                            __context__.SourceCodeLine = 520;
                            return (ushort)( 3) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 521;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "right" , STEMPDATA ))  ) ) 
                                {
                                __context__.SourceCodeLine = 521;
                                return (ushort)( 4) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 522;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomin" , STEMPDATA ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 522;
                                    return (ushort)( 5) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 523;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "zoomout" , STEMPDATA ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 523;
                                        return (ushort)( 6) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 524;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweron" , STEMPDATA ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 524;
                                            return (ushort)( 7) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 525;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "poweroff" , STEMPDATA ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 525;
                                                return (ushort)( 8) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 526;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetrec" , STEMPDATA ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 526;
                                                    return (ushort)( (Functions.Atoi( STEMPDATA ) + 100)) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 527;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "presetsav" , STEMPDATA ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 527;
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
            
            __context__.SourceCodeLine = 545;
            LISTFB__DOLLAR__ [ ILIST]  .UpdateValue ( SDATA  ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 555;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 557;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 558;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 562;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 564;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 564;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 566;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 567;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 569;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 570;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 571;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 562;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 575;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 577;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 578;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 587;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 589;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 591;
                    STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                    __context__.SourceCodeLine = 592;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 596;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 598;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 598;
                            MakeString ( STEMP , "{{ListVisFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 600;
                        MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                        __context__.SourceCodeLine = 601;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 603;
                            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                            __context__.SourceCodeLine = 604;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 605;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 596;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 609;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 611;
                    MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                    __context__.SourceCodeLine = 612;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 622;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 624;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 626;
                MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                __context__.SourceCodeLine = 627;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 629;
                    MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                    __context__.SourceCodeLine = 627;
                    } 
                
                __context__.SourceCodeLine = 631;
                STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                __context__.SourceCodeLine = 632;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 636;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 638;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 640;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 640;
                            MakeString ( STEMP , "{{ListTextFB:") ; 
                            }
                        
                        __context__.SourceCodeLine = 642;
                        MakeString ( STEMP , "{0}{1:d}=", STEMP , (ushort)IINDEX) ; 
                        __context__.SourceCodeLine = 643;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 645;
                            MakeString ( STEMP , "{0}{1},", STEMP , LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                            __context__.SourceCodeLine = 643;
                            } 
                        
                        __context__.SourceCodeLine = 647;
                        MakeString ( STEMP , "{0}|", STEMP ) ; 
                        __context__.SourceCodeLine = 649;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 600 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 651;
                            MakeString ( STEMP , "{0};}}", STEMP ) ; 
                            __context__.SourceCodeLine = 652;
                            FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 653;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 636;
                    } 
                
                __context__.SourceCodeLine = 657;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 659;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 660;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTFBFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 672;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 674;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 675;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 679;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 681;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 681;
                        MakeString ( STEMP , "{{ListButtonFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 683;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    __context__.SourceCodeLine = 684;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 686;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 687;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 688;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 679;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 692;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 694;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 695;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVISFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 703;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 705;
                MakeString ( STEMP , "{{ListVisFB:{0:d}={1:d},", (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 709;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 711;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 711;
                        MakeString ( STEMP , "{{ListVisFB:") ; 
                        }
                    
                    __context__.SourceCodeLine = 713;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IGLOBALTOLIST, (ushort)FILTER[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    __context__.SourceCodeLine = 714;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 900 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 716;
                        MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                        __context__.SourceCodeLine = 717;
                        FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                        __context__.SourceCodeLine = 718;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 709;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 722;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 724;
                MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
                __context__.SourceCodeLine = 725;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXTFILTER (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 734;
            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
            __context__.SourceCodeLine = 736;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 738;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 738;
                    MakeString ( STEMP , "{{ListTextFB:") ; 
                    }
                
                __context__.SourceCodeLine = 740;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 742;
                    MakeString ( STEMP , "{0}{1:d}={2},|", STEMP , (ushort)FILTER[ ILIST ].ITEM[ I ].IGLOBALTOLIST, FILTER [ ILIST] . ITEM [ I] . STEXT [ 1 ] ) ; 
                    } 
                
                __context__.SourceCodeLine = 747;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 800 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 749;
                    MakeString ( STEMP , "{0};}}", STEMP ) ; 
                    __context__.SourceCodeLine = 750;
                    FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 751;
                    STEMP  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 736;
                } 
            
            __context__.SourceCodeLine = 754;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 756;
                MakeString ( STEMP , "{0};}}", STEMP ) ; 
                __context__.SourceCodeLine = 757;
                FSENDLISTFB (  __context__ , (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            
            }
            
        private void FCONFIGURELISTFBSETVISIBLEITEMS (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 778;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 780;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IVIS)  ) ) 
                    { 
                    __context__.SourceCodeLine = 782;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 783;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 778;
                } 
            
            
            }
            
        private void FCONFIGURELISTFBRESETALL (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 791;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 793;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 795;
                    LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 796;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 791;
                } 
            
            __context__.SourceCodeLine = 799;
            LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
            
            }
            
        private void FCONFIGURELISTFBTOGGLE (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 805;
            LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( LIST[ ILIST ].ITEM[ IINDEX ].IFB ) ) ; 
            __context__.SourceCodeLine = 806;
            FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private ushort FCONFIGURELISTFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort ISAME = 0;
            
            
            __context__.SourceCodeLine = 812;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 814;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ ILIST ].IITEMSELECTEDLAST == IINDEX))  ) ) 
                    { 
                    __context__.SourceCodeLine = 816;
                    LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 817;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 818;
                    ISAME = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 820;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                        { 
                        __context__.SourceCodeLine = 822;
                        LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 823;
                        FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                        __context__.SourceCodeLine = 824;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 825;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 829;
                        LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 830;
                        LIST [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 832;
                FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                __context__.SourceCodeLine = 833;
                if ( Functions.TestForTrue  ( ( ISAME)  ) ) 
                    {
                    __context__.SourceCodeLine = 833;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 834;
                return (ushort)( IINDEX) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 838;
                if ( Functions.TestForTrue  ( ( LIST[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 840;
                    LIST [ ILIST] . ITEM [ LIST[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 841;
                    FUPDATELISTFB (  __context__ , (ushort)( ILIST ), (ushort)( LIST[ ILIST ].IITEMSELECTEDLAST )) ; 
                    __context__.SourceCodeLine = 842;
                    LIST [ ILIST] . IITEMSELECTEDLAST = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                __context__.SourceCodeLine = 848;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FCONFIGUREFILTERFBMUTEX (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 856;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINDEX != FILTER[ ILIST ].IITEMSELECTEDLAST))  ) ) 
                { 
                __context__.SourceCodeLine = 858;
                if ( Functions.TestForTrue  ( ( FILTER[ ILIST ].IITEMSELECTEDLAST)  ) ) 
                    { 
                    __context__.SourceCodeLine = 860;
                    FILTER [ ILIST] . ITEM [ FILTER[ ILIST ].IITEMSELECTEDLAST] . IFB = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 861;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( FILTER[ ILIST ].IITEMSELECTEDLAST )) ; 
                    } 
                
                __context__.SourceCodeLine = 863;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 865;
                    FILTER [ ILIST] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 866;
                    FUPDATELISTFBFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    } 
                
                __context__.SourceCodeLine = 868;
                FILTER [ ILIST] . IITEMSELECTEDLAST = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 869;
                return (ushort)( 1) ; 
                } 
            
            __context__.SourceCodeLine = 871;
            return (ushort)( 0) ; 
            
            }
            
        private void FCONFIGUREFILTER (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            ushort ITEMPLIST1 = 0;
            ushort ITEMPLIST2 = 0;
            
            
            __context__.SourceCodeLine = 879;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
            __context__.SourceCodeLine = 880;
            FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX )) ; 
            __context__.SourceCodeLine = 882;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 884;
                FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX )) ; 
                __context__.SourceCodeLine = 885;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 887;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 889;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTV[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 890;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 885;
                    } 
                
                __context__.SourceCodeLine = 893;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 895;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 897;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTA[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 898;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 893;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 904;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 906;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTVINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 908;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTVINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 909;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTVINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 904;
                    } 
                
                __context__.SourceCodeLine = 912;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                    { 
                    __context__.SourceCodeLine = 914;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ FILTER[ ILIST ].IMEMBERLISTAINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 916;
                        LIST [ FILTER[ ILIST ].IMEMBERLISTAINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 917;
                        FUPDATELISTVIS (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTAINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 912;
                    } 
                
                } 
            
            
            }
            
        private void FCONFIGUREGROUP (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 927;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 929;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 931;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS != FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 933;
                        FILTER [ (ILIST - 1)] . ITEM [ I] . IVIS = (ushort) ( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , I ] ) ; 
                        __context__.SourceCodeLine = 934;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 929;
                    } 
                
                __context__.SourceCodeLine = 938;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ) && Functions.TestForTrue ( Functions.Not( FILTER[ ILIST ].IMEMBERLISTF[ IINDEX , FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].IITEMSELECTEDLAST ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 941;
                    FCONFIGUREFILTERFBMUTEX (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 942;
                    FCONFIGUREFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( 0 )) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 947;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ) , (ushort)( 0 ) ); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 949;
                    if ( Functions.TestForTrue  ( ( Functions.Not( FILTER[ FILTER[ ILIST ].IMEMBERLISTFINDEX ].ITEM[ I ].IVIS ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 951;
                        FILTER [ FILTER[ ILIST ].IMEMBERLISTFINDEX] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 952;
                        FUPDATELISTVISFILTER (  __context__ , (ushort)( FILTER[ ILIST ].IMEMBERLISTFINDEX ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 947;
                    } 
                
                } 
            
            
            }
            
        private CrestronString FGETROUTEDSOURCENAME (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 964;
            try 
                { 
                __context__.SourceCodeLine = 966;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 968;
                    if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC)  ) ) 
                        { 
                        __context__.SourceCodeLine = 970;
                        return ( LIST [ (ILIST - 1)] . ITEM [ LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC] . SGLOBALNAME ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 972;
                        return ( SYS . SBLANKSRCTEXT ) ; 
                        }
                    
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 977;
                Trace( "GlobalMST fGetRoutedSourceName - error - iList={0:d}, iIndex={1:d}, List[{2:d}].Item[{3:d}].iRoutedSrc={4:d}", (ushort)ILIST, (ushort)IINDEX, (ushort)ILIST, (ushort)IINDEX, (ushort)LIST[ ILIST ].ITEM[ IINDEX ].IROUTEDSRC) ; 
                
                }
                
                
                return ""; // default return value (none specified in module)
                }
                
            private ushort FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort ILIST , ushort IINDEX , ushort ITEXTCOLUMN ) 
                { 
                
                __context__.SourceCodeLine = 984;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 986;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)ITEXTCOLUMN);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 988;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 989;
                                LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ ITEXTCOLUMN ]  .UpdateValue ( FGETROUTEDSOURCENAME (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX ))  ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 992;
                    return (ushort)( 0) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 994;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 996;
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
                
                
                __context__.SourceCodeLine = 1024;
                STEMPDATA  .UpdateValue ( STEMP  ) ; 
                __context__.SourceCodeLine = 1025;
                STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
                __context__.SourceCodeLine = 1027;
                while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1029;
                    STEMP2  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 1030;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_V_RTE" , STEMPHEADER ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1032;
                        STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                        __context__.SourceCodeLine = 1033;
                        IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                        __context__.SourceCodeLine = 1034;
                        IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                        __context__.SourceCodeLine = 1035;
                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1037;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_rte" , STEMPHEADER ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1039;
                            Trace( "in GlobalMST usb_rte") ; 
                            __context__.SourceCodeLine = 1040;
                            STEMP1  .UpdateValue ( Functions.Remove ( ":" , STEMP2 )  ) ; 
                            __context__.SourceCodeLine = 1041;
                            IGUIDDST = (ushort) ( Functions.Atoi( STEMP1 ) ) ; 
                            __context__.SourceCodeLine = 1042;
                            IGUIDSRC = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                            __context__.SourceCodeLine = 1043;
                            Trace( "iGUIDdst = {0:d}, iGUIDsrc = {1:d}", (ushort)IGUIDDST, (ushort)IGUIDSRC) ; 
                            __context__.SourceCodeLine = 1045;
                            FUSBSENDROUTE (  __context__ , (ushort)( IGUIDDST ), (ushort)( IGUIDSRC )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1047;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_ctrl" , STEMPHEADER ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1049;
                                STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                __context__.SourceCodeLine = 1050;
                                I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                __context__.SourceCodeLine = 1051;
                                if ( Functions.TestForTrue  ( ( I)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1053;
                                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP2 )  ) ; 
                                    __context__.SourceCodeLine = 1054;
                                    CAM_FOLDEDCMD [ I]  .Value = (ushort) ( FCAMGETFOLDEDCMD( __context__ , STEMP2 ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1058;
                                    Trace( "Global fProcessRoomData, found cam_ctrl - iCamGUID resolved to zero(0)") ; 
                                    } 
                                
                                } 
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 1027;
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
                    
                    
                    __context__.SourceCodeLine = 1069;
                    IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1071;
                    STEMPDATA  .UpdateValue ( Functions.Gather ( Functions.Length( FROM_ROOM_RX__DOLLAR__[ IROOM ] ), FROM_ROOM_RX__DOLLAR__ [ IROOM ] )  ) ; 
                    __context__.SourceCodeLine = 1072;
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
                
                
                __context__.SourceCodeLine = 1081;
                if ( Functions.TestForTrue  ( ( LIST[ 2 ].IINITIALIZED)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1083;
                    IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 1085;
                    ISRC = (ushort) ( MTRX_V_IN[ IDST ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 1087;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 1000 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1089;
                        Trace( "GlobalMST - Change MTRX_V_In, dstGUID={0:d}, srcValue(not a GUID)={1:d}", (ushort)IDST, (ushort)ISRC) ; 
                        __context__.SourceCodeLine = 1090;
                        ISRC = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1091;
                        LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 1092;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                        __context__.SourceCodeLine = 1093;
                        FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1095;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISRC ) && Functions.TestForTrue ( Functions.BoolToInt (ISRC != LIST[ 2 ].ITEM[ IDST ].IROUTEDSRC) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1097;
                            LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 1098;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                            __context__.SourceCodeLine = 1099;
                            FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                            __context__.SourceCodeLine = 1101;
                            if ( Functions.TestForTrue  ( ( LIST[ 2 ].ITEM[ IDST ].IRMASS)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1103;
                                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 2 ].ITEM[ IDST ].IRMASS] , "{{MTRX_V_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 2 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 1] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1110;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ISRC ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1112;
                                Trace( "GlobalMST - Change MTRX_V_In, iSrc == 0") ; 
                                __context__.SourceCodeLine = 1113;
                                LIST [ 2] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 1114;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                                __context__.SourceCodeLine = 1115;
                                FUPDATELISTTEXT (  __context__ , (ushort)( 2 ), (ushort)( IDST )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1119;
                                Trace( "GlobalMST MTRX_V_In - else trap") ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1122;
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
            
            
            __context__.SourceCodeLine = 1130;
            if ( Functions.TestForTrue  ( ( LIST[ 4 ].IINITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 1132;
                IDST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 1134;
                ISRC = (ushort) ( MTRX_A_IN[ IDST ] .UshortValue ) ; 
                __context__.SourceCodeLine = 1135;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISRC != LIST[ 4 ].ITEM[ IDST ].IROUTEDSRC))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1137;
                    LIST [ 4] . ITEM [ IDST] . IROUTEDSRC = (ushort) ( ISRC ) ; 
                    __context__.SourceCodeLine = 1138;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST ), (ushort)( 2 )) ; 
                    __context__.SourceCodeLine = 1139;
                    FUPDATELISTTEXT (  __context__ , (ushort)( 4 ), (ushort)( IDST )) ; 
                    __context__.SourceCodeLine = 1141;
                    if ( Functions.TestForTrue  ( ( LIST[ 4 ].ITEM[ IDST ].IRMASS)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1143;
                        MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ 4 ].ITEM[ IDST ].IRMASS] , "{{MTRX_A_RTE; LocalID={0:d}:src_guid={1:d},src_name={2},|}}", (ushort)LIST[ 4 ].ITEM[ IDST ].ILOCALID, (ushort)ISRC, LIST [ 3] . ITEM [ ISRC] . SGLOBALNAME ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1151;
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
    
    
    __context__.SourceCodeLine = 1169;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 4 ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1171;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)30; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1173;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ I] , "{0}COMPLETE|}}", FGETDATAHEADER (  __context__ , (ushort)( ILIST )) ) ; 
            __context__.SourceCodeLine = 1174;
            Functions.Delay (  (int) ( 5 ) ) ; 
            __context__.SourceCodeLine = 1171;
            } 
        
        __context__.SourceCodeLine = 1177;
        LIST [ ILIST] . IINITIALIZED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1179;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 1181;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1182;
            if ( Functions.TestForTrue  ( ( LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1184;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 4) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1184;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 2 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1179;
            } 
        
        __context__.SourceCodeLine = 1187;
        FUPDATELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1188;
        FUPDATELISTVIS (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1190;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1192;
            LIST_NUMOFITEMS [ ILIST]  .Value = (ushort) ( FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1193;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ILIST ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 1195;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( ILIST ), (ushort)( I ), (ushort)( 1 )) ; 
                __context__.SourceCodeLine = 1193;
                } 
            
            __context__.SourceCodeLine = 1197;
            FUPDATELISTTEXTFILTER (  __context__ , (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1198;
            FUPDATELISTVISFILTER (  __context__ , (ushort)( ILIST ), (ushort)( 0 )) ; 
            } 
        
        }
    
    __context__.SourceCodeLine = 1201;
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
    STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 151, this );
    STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    STEMPCOMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMPUSB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    
    __context__.SourceCodeLine = 1221;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1223;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1225;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1226;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1227;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1229;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1231;
            LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            __context__.SourceCodeLine = 1232;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), (ushort)( 1 )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1234;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1236;
                LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1238;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1238;
                    LIST [ ITYPE] . ITEM [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1239;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1239;
                        LIST [ ITYPE] . ITEM [ IINDEX] . ILOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1240;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1240;
                            LIST [ ITYPE] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1241;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "filter" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1241;
                                LIST [ ITYPE] . ITEM [ IINDEX] . IFILTERID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1243;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ip_address" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1243;
                                    LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1244;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "com_port" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1244;
                                        LIST [ ITYPE] . ITEM [ IINDEX] . ICOMPORT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1245;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "processor_index" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1245;
                                            LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1247;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1247;
                                                LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1248;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1248;
                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1249;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "device_type" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1249;
                                                        LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1251;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 1253;
                                                            STEMPVALUE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                            __context__.SourceCodeLine = 1254;
                                                            Trace( "usbAddr = {0}", STEMPVALUE ) ; 
                                                            __context__.SourceCodeLine = 1255;
                                                            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR , "{0}{1}{2}", Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 1 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 3 ) , (int)( 2 ) ) ) ) ) , Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( STEMPVALUE , (int)( 5 ) , (int)( 2 ) ) ) ) ) ) ; 
                                                            __context__.SourceCodeLine = 1260;
                                                            Trace( "List[{0:d}].Item[{1:d}].sUSBAddr={2}", (ushort)ITYPE, (ushort)IINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR ) ; 
                                                            __context__.SourceCodeLine = 1261;
                                                            LIST [ ITYPE] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1263;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_vtc" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1263;
                                                                LIST [ ITYPE] . ITEM [ IINDEX] . IISVTC = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1264;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vtc_io" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 1264;
                                                                    LIST [ ITYPE] . ITEM [ IINDEX] . IVTCIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 1266;
                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                                                        {
                                                                        __context__.SourceCodeLine = 1266;
                                                                        LIST [ ITYPE] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                        }
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 1267;
                                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cmd" , STEMPKEY ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1269;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . SCMDDATA  .UpdateValue ( FTRIMWHITESPACE (  __context__ , STEMPVALUE)  ) ; 
                                                                            __context__.SourceCodeLine = 1270;
                                                                            LIST [ ITYPE] . ITEM [ IINDEX] . ICMDDATA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                            } 
                                                                        
                                                                        else 
                                                                            { 
                                                                            __context__.SourceCodeLine = 1274;
                                                                            IERR = (ushort) ( 1 ) ; 
                                                                            __context__.SourceCodeLine = 1275;
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
        
        __context__.SourceCodeLine = 1223;
        } 
    
    __context__.SourceCodeLine = 1279;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1281;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1284;
            MakeString ( LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , "{0:d3} {1}", (ushort)ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].IROOMNUM, LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME ) ; 
            } 
        
        __context__.SourceCodeLine = 1290;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
            { 
            __context__.SourceCodeLine = 1292;
            SYS . CAM . INUMOFCAMS = (ushort) ( (SYS.CAM.INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1293;
            SYS . CAM . IGUID [ SYS.CAM.INUMOFCAMS] = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1294;
            ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFCAMS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS + 1) ) ; 
            __context__.SourceCodeLine = 1295;
            LIST [ ITYPE] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1296;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1297;
            LIST [ ITYPE] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1298;
            ICAMGUID = (ushort) ( SYS.CAM.INUMOFCAMS ) ; 
            __context__.SourceCodeLine = 1300;
            MakeString ( CAM_DATAINIT__DOLLAR__ [ 1] , "{{ListTextFB:{0:d}= global_name={1}~ip={2},|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS ) ; 
            __context__.SourceCodeLine = 1305;
            MakeString ( LISTFB__DOLLAR__ [ 12] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)ICAMGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)ICAMGUID) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1311;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                { 
                __context__.SourceCodeLine = 1313;
                SYS . DISPLAY . INUMOFDISPLAYS = (ushort) ( (SYS.DISPLAY.INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1314;
                SYS . DISPLAY . IGUID [ SYS.DISPLAY.INUMOFDISPLAYS] = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 1315;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . INUMOFDISPLAYS = (ushort) ( (ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS + 1) ) ; 
                __context__.SourceCodeLine = 1316;
                LIST [ ITYPE] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1317;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( ROOM[ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS ].INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1318;
                IDISPLAYGUID = (ushort) ( SYS.DISPLAY.INUMOFDISPLAYS ) ; 
                __context__.SourceCodeLine = 1319;
                LIST [ ITYPE] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1322;
                LIST [ ITYPE] . ITEM [ IINDEX] . IPROCESSORINDEX = (ushort) ( 5 ) ; 
                __context__.SourceCodeLine = 1324;
                STEMPCOMPORT  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 1325;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT)  ) ) 
                    {
                    __context__.SourceCodeLine = 1325;
                    MakeString ( STEMPCOMPORT , "~com_port={0:d},", (ushort)LIST[ ITYPE ].ITEM[ SYS.DISPLAY.IGUID[ I ] ].ICOMPORT) ; 
                    }
                
                __context__.SourceCodeLine = 1327;
                MakeString ( DISPLAY_DATAINIT__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IPROCESSORINDEX] , "{{ListTextFB:{0:d}= global_name={1}~ip={2}~device_type={3}{4},|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SIPADDRESS , LIST [ ITYPE] . ITEM [ IINDEX] . SDEVICETYPE , STEMPCOMPORT ) ; 
                __context__.SourceCodeLine = 1334;
                MakeString ( LISTFB__DOLLAR__ [ 13] , "{{ListTextFB:{0:d}={1},|; ListVisFB:{2:d}=1,|;}}", (ushort)IDISPLAYGUID, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , (ushort)IDISPLAYGUID) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1341;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1343;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_4__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1346;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVOUTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1348;
                                SYS . VTC [ LIST[ ITYPE ].ITEM[ IINDEX ].IISVTC] . IVINGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].IVTCIO] = (ushort) ( IINDEX ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            }
        
        __context__.SourceCodeLine = 1352;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISUSB)  ) ) 
            {
            __context__.SourceCodeLine = 1352;
            MakeString ( STEMPUSB , " usb_mac={0},", LIST [ ITYPE] . ITEM [ IINDEX] . SUSBADDR ) ; 
            }
        
        __context__.SourceCodeLine = 1354;
        LIST [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1355;
        LIST [ ITYPE] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1356;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1357;
        if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS)  ) ) 
            { 
            __context__.SourceCodeLine = 1360;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
                {
                __context__.SourceCodeLine = 1360;
                MakeString ( STEMP , "is_camera=1, cam_localID={0:d}, cam_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ICAMGUID) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1364;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                    {
                    __context__.SourceCodeLine = 1364;
                    MakeString ( STEMP , "is_display=1, display_localID={0:d}, display_global={1:d}, ", (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYLOCALID, (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IDISPLAYGUID) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1369;
            STEMPHEADER  .UpdateValue ( FGETDATAHEADER (  __context__ , (ushort)( ITYPE ))  ) ; 
            __context__.SourceCodeLine = 1370;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITYPE >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITYPE <= 2 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1370;
                MakeString ( TO_ROOM_TX__DOLLAR__ [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] , "{{{0} LOCALID={1:d}: GUID={2:d}, global_name={3}, local_name={4}, {5}is_virtual={6:d}, {7}|}}", STEMPHEADER , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID, (ushort)IINDEX, LIST [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME , LIST [ ITYPE] . ITEM [ IINDEX] . SLOCALNAME , STEMP , (ushort)LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL, STEMPUSB ) ; 
                }
            
            __context__.SourceCodeLine = 1382;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                {
                __context__.SourceCodeLine = 1382;
                ROOM [ LIST[ ITYPE ].ITEM[ IINDEX ].IRMASS] . IVIRTUALVDSTGUID [ LIST[ ITYPE ].ITEM[ IINDEX ].ILOCALID] = (ushort) ( IINDEX ) ; 
                }
            
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1385;
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
    
    
    __context__.SourceCodeLine = 1393;
    if ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1395;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1396;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1398;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1399;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 1400;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_guid" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1400;
                IINDEX = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1401;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1401;
                    ROOM [ IINDEX] . SROOMNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) ))  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1402;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bldg_rm_num" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1402;
                        ROOM [ IINDEX] . IROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1403;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1403;
                            ROOM [ IINDEX] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1404;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1404;
                                ROOM [ IINDEX] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1396;
            } 
        
        __context__.SourceCodeLine = 1407;
        MakeString ( TO_ROOM_TX__DOLLAR__ [ IINDEX] , "{{ROOMS; RoomID={0:d}:{1},{2:d},discrete_macro_mode={3:d},macro_take_mode={4:d}|}}", (ushort)IINDEX, ROOM [ IINDEX] . SROOMNAME , (ushort)ROOM[ IINDEX ].IROOMNUM, (ushort)ROOM[ IINDEX ].IDISCRETEMACROMODE, (ushort)ROOM[ IINDEX ].IMACROTAKEMODE) ; 
        __context__.SourceCodeLine = 1414;
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
    
    
    __context__.SourceCodeLine = 1423;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1424;
    while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1426;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
        __context__.SourceCodeLine = 1427;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1429;
            STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1430;
            FILTER [ ITYPE] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( STEMPVALUE , (int)( (Functions.Length( STEMPVALUE ) - 1) ) ))  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1432;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list_index" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1434;
                STEMPVALUE  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                __context__.SourceCodeLine = 1435;
                FILTER [ ITYPE] . ITEM [ IINDEX] . IGLOBALTOLIST = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                __context__.SourceCodeLine = 1436;
                FILTER [ ITYPE] . ITEM [ Functions.Atoi( STEMPVALUE )] . ILISTTOGLOBAL = (ushort) ( IINDEX ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1438;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "v_guid" , STEMPKEY ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1440;
                    STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                    __context__.SourceCodeLine = 1441;
                    while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1443;
                        I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        __context__.SourceCodeLine = 1444;
                        FILTER [ ITYPE] . IMEMBERLISTV [ IINDEX , I] = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1445;
                        STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                        __context__.SourceCodeLine = 1446;
                        FILTER [ ITYPE] . INUMOFMEMBERSV [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSV[ IINDEX ] + 1) ) ; 
                        __context__.SourceCodeLine = 1441;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1449;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "a_guid" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1451;
                        STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 1452;
                        while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1454;
                            I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1455;
                            FILTER [ ITYPE] . IMEMBERLISTA [ IINDEX , I] = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1456;
                            STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                            __context__.SourceCodeLine = 1457;
                            FILTER [ ITYPE] . INUMOFMEMBERSA [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSA[ IINDEX ] + 1) ) ; 
                            __context__.SourceCodeLine = 1452;
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1460;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "f_guid" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1462;
                            STEMPVALUE  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                            __context__.SourceCodeLine = 1463;
                            while ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPVALUE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1465;
                                I = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                __context__.SourceCodeLine = 1466;
                                FILTER [ ITYPE] . IMEMBERLISTF [ IINDEX , I] = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1467;
                                STRASH  .UpdateValue ( Functions.Remove ( Functions.ItoA (  (int) ( I ) ) , STEMPVALUE )  ) ; 
                                __context__.SourceCodeLine = 1468;
                                FILTER [ ITYPE] . INUMOFMEMBERSF [ IINDEX] = (ushort) ( (FILTER[ ITYPE ].INUMOFMEMBERSF[ IINDEX ] + 1) ) ; 
                                __context__.SourceCodeLine = 1463;
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1473;
                            Trace( "Global - in fProcessFilter - didn't catch key. GUID={0:d} key:\u0022{1}\u0022", (ushort)IINDEX, STEMPKEY ) ; 
                            __context__.SourceCodeLine = 1474;
                            IERR = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1424;
        } 
    
    __context__.SourceCodeLine = 1478;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1480;
        FHIGHESTLISTINDEX (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1481;
        FILTER [ ITYPE] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1482;
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
    
    
    __context__.SourceCodeLine = 1499;
    STEMPDATA2  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1500;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1501;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1503;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VSRC" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1503;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1504;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_VDST" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1504;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1505;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ASRC" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1505;
                ITYPE = (ushort) ( 3 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1506;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_ADST" , STEMPHEADER ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1506;
                    ITYPE = (ushort) ( 4 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1507;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCF" , STEMPHEADER ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1507;
                        ITYPE = (ushort) ( 5 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1508;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_SRCG" , STEMPHEADER ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1508;
                            ITYPE = (ushort) ( 6 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1509;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTF" , STEMPHEADER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1509;
                                ITYPE = (ushort) ( 7 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1510;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MTRX_DSTG" , STEMPHEADER ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1510;
                                    ITYPE = (ushort) ( 8 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1511;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1511;
                                        ITYPE = (ushort) ( 13 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1512;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "MACRO" , STEMPHEADER ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1512;
                                            ITYPE = (ushort) ( 14 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1513;
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
    
    __context__.SourceCodeLine = 1516;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
        { 
        __context__.SourceCodeLine = 1518;
        if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMPDATA2 ))  ) ) 
            {
            __context__.SourceCodeLine = 1518;
            MakeString ( TO_ROOM_TX__DOLLAR__ [ Functions.Atoi( STEMPDATA2 )] , "{0}", STEMPDATA2 ) ; 
            }
        
        } 
    
    __context__.SourceCodeLine = 1520;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1522;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1523;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1525;
            FPROCESSLIST (  __context__ , (ushort)( ITYPE )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1527;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                { 
                __context__.SourceCodeLine = 1529;
                FPROCESSROOMS (  __context__ , (ushort)( ITYPE ), STEMPLINE) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1533;
                STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
                __context__.SourceCodeLine = 1534;
                IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                __context__.SourceCodeLine = 1535;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1537;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_5__ = ((int)ITYPE);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1539;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1540;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1541;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 4) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1542;
                                FPROCESSLINE (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 5) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1543;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 6) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1544;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 7) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1545;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 8) ) ) ) 
                                {
                                __context__.SourceCodeLine = 1546;
                                FPROCESSFILTER (  __context__ , (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1549;
                    Trace( "error - MTRX fProcessInit, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1520;
        } 
    
    
    }
    
private void FUPDATEVTC (  SplusExecutionContext __context__, ushort IVTCSEL ) 
    { 
    ushort I = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1565;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1566;
    VTC_CTRL_SEL_UNITNAME__DOLLAR__  .UpdateValue ( SYS . VTC [ SYS.IVTCSEL] . SUNITNAME  ) ; 
    __context__.SourceCodeLine = 1567;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].IROOMRES)  ) ) 
        {
        __context__.SourceCodeLine = 1567;
        STEMP  .UpdateValue ( ROOM [ SYS.VTC[ IVTCSEL ].IROOMRES] . SROOMNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1568;
    VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1569;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1570;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICAMSELECT)  ) ) 
        {
        __context__.SourceCodeLine = 1570;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICAMSELECT] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1571;
    VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1572;
    STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
    __context__.SourceCodeLine = 1573;
    if ( Functions.TestForTrue  ( ( SYS.VTC[ IVTCSEL ].ICONTENTSRC)  ) ) 
        {
        __context__.SourceCodeLine = 1573;
        STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.VTC[ IVTCSEL ].ICONTENTSRC] . SGLOBALNAME  ) ; 
        }
    
    __context__.SourceCodeLine = 1574;
    VTC_CONTENTSHARE_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( STEMP  ) ; 
    
    }
    
object VTC_CTRL_SEL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1587;
        SYS . IVTCSEL = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1589;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)3; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 1589;
            VTC_CTRL_SEL_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1589;
            }
        
        __context__.SourceCodeLine = 1590;
        VTC_CTRL_SEL_FB [ SYS.IVTCSEL]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1592;
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
        
        
        __context__.SourceCodeLine = 1602;
        IVTC = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1605;
        ISRCGUID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1606;
        STEMP  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
        __context__.SourceCodeLine = 1609;
        if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 1611;
            ISRCGUID = (ushort) ( SYS.CAM.IGUID[ SYS.ICAMSEL ] ) ; 
            __context__.SourceCodeLine = 1612;
            STEMP  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ SYS.ICAMSEL ]] . SGLOBALNAME  ) ; 
            } 
        
        __context__.SourceCodeLine = 1615;
        SYS . VTC [ IVTC] . ICAMSELECT = (ushort) ( ISRCGUID ) ; 
        __context__.SourceCodeLine = 1617;
        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ IVTC ].IVINGUID[ 1 ] ), (ushort)( SYS.VTC[ IVTC ].ICAMSELECT )) ; 
        __context__.SourceCodeLine = 1618;
        VTC_CAMSELECT_NAME__DOLLAR__ [ IVTC]  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1619;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVTC == SYS.IVTCSEL))  ) ) 
            {
            __context__.SourceCodeLine = 1619;
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
        
        __context__.SourceCodeLine = 1626;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYS.UI.ISUB == 2))  ) ) 
            { 
            __context__.SourceCodeLine = 1628;
            if ( Functions.TestForTrue  ( ( SYS.ICAMSEL)  ) ) 
                { 
                __context__.SourceCodeLine = 1630;
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
    
    
    __context__.SourceCodeLine = 1646;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1648;
        if ( Functions.TestForTrue  ( ( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST)  ) ) 
            { 
            __context__.SourceCodeLine = 1650;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1652;
                if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1654;
                    if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1654;
                        FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1655;
                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( LIST[ (ITYPE - 1) ].IITEMSELECTEDLAST )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1650;
                } 
            
            } 
        
        } 
    
    
    }
    
private void FMTRXCLEARROUTES (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1666;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ITYPE == 4) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1668;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)FHIGHESTLISTINDEX( __context__ , (ushort)( ITYPE ) , (ushort)( 0 ) ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1670;
            if ( Functions.TestForTrue  ( ( LIST[ ITYPE ].ITEM[ I ].IFB)  ) ) 
                { 
                __context__.SourceCodeLine = 1672;
                if ( Functions.TestForTrue  ( ( Functions.Not( LIST[ ITYPE ].ITEM[ I ].IISVIRTUAL ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1672;
                    FMTRXSENDROUTE (  __context__ , (ushort)( ITYPE ), (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1673;
                    FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( I ), (ushort)( 0 )) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1668;
            } 
        
        } 
    
    
    }
    
object MTRX_TAKE_ALL_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1689;
        FMTRXTAKE (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1690;
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
        
        __context__.SourceCodeLine = 1695;
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
        
        __context__.SourceCodeLine = 1700;
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
        
        __context__.SourceCodeLine = 1705;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1706;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1707;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1708;
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
        
        __context__.SourceCodeLine = 1712;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1713;
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
        
        __context__.SourceCodeLine = 1717;
        FCONFIGURELISTFBRESETALL (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 1718;
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
        
        __context__.SourceCodeLine = 1722;
        FCONFIGURELISTFBSETVISIBLEITEMS (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1723;
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
        
        __context__.SourceCodeLine = 1727;
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
        
        __context__.SourceCodeLine = 1731;
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
        
        __context__.SourceCodeLine = 1735;
        FMTRXCLEARROUTES (  __context__ , (ushort)( 2 )) ; 
        __context__.SourceCodeLine = 1736;
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
        
        
        __context__.SourceCodeLine = 1749;
        IERR = (ushort) ( 10000 ) ; 
        __context__.SourceCodeLine = 1750;
        ILIST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1751;
        IINDEX = (ushort) ( LIST_ITEMCLICKED[ ILIST ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1753;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST >= 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 8 ) )) ) ) && Functions.TestForTrue ( IINDEX )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1753;
            IINDEX = (ushort) ( FILTER[ ILIST ].ITEM[ IINDEX ].ILISTTOGLOBAL ) ; 
            }
        
        __context__.SourceCodeLine = 1755;
        
            {
            int __SPLS_TMPVAR__SWTCH_6__ = ((int)ILIST);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1757;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1758;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1759;
                    FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1760;
                    FCONFIGURELISTFBTOGGLE (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1761;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1762;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 7) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1763;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 8) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1764;
                    IERR = (ushort) ( FCONFIGUREFILTERFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1767;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_7__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1772;
                                IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                                __context__.SourceCodeLine = 1774;
                                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1776;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                    __context__.SourceCodeLine = 1777;
                                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__1 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__1 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                        { 
                                        __context__.SourceCodeLine = 1780;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST[ 1 ].ITEM[ SYS.CAM.IGUID[ I ] ].IRMASS == IINDEX))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1780;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1781;
                                            LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 1777;
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1786;
                                    ROOMS_LIST_SELECTEDROOM__DOLLAR__  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 1787;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)SYS.CAM.INUMOFCAMS; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        {
                                        __context__.SourceCodeLine = 1787;
                                        LIST [ 12] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                        __context__.SourceCodeLine = 1787;
                                        }
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 1789;
                                FUPDATELISTVIS (  __context__ , (ushort)( 12 ), (ushort)( 0 )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1793;
                                FCONFIGURELISTFBMUTEX (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                                __context__.SourceCodeLine = 1795;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1797;
                                    IPREVIOUSROOM = (ushort) ( SYS.VTC[ SYS.IVTCSEL ].IROOMRES ) ; 
                                    __context__.SourceCodeLine = 1798;
                                    SYS . VTC [ SYS.IVTCSEL] . IROOMRES = (ushort) ( IINDEX ) ; 
                                    __context__.SourceCodeLine = 1799;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1799;
                                        ROOM [ IINDEX] . IVTCASSIGNMENT = (ushort) ( SYS.IVTCSEL ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 1800;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1800;
                                        ROOM [ IPREVIOUSROOM] . IVTCASSIGNMENT = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 1803;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IPREVIOUSROOM ) ) && Functions.TestForTrue ( Functions.Not( IINDEX ) )) ))  ) ) 
                                        { 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1808;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPREVIOUSROOM == IINDEX))  ) ) 
                                            { 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1813;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPREVIOUSROOM ) && Functions.TestForTrue ( Functions.BoolToInt (IPREVIOUSROOM != IINDEX) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1816;
                                                Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                                __context__.SourceCodeLine = 1818;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1819;
                                                FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IPREVIOUSROOM ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1821;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                                __context__.SourceCodeLine = 1822;
                                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 2 ] ), (ushort)( 0 )) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 1826;
                                    if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1829;
                                        Functions.Pulse ( 10, VTC_ENDALLCALLS [ SYS.IVTCSEL] ) ; 
                                        __context__.SourceCodeLine = 1831;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 1832;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 1837;
                                        VTC_ROOMRES_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 1838;
                                        VTC_ROOMRES_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( ROOM [ IINDEX] . SROOMNAME  ) ; 
                                        __context__.SourceCodeLine = 1840;
                                        FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 5 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 1 ] )) ; 
                                        __context__.SourceCodeLine = 1841;
                                        if ( Functions.TestForTrue  ( ( SYS.VTC[ SYS.IVTCSEL ].IDUALDISPLAY)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1843;
                                            FMTRXSENDROUTEVIRTUAL (  __context__ , (ushort)( ROOM[ IINDEX ].IVIRTUALVDSTGUID[ 6 ] ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVOUTGUID[ 2 ] )) ; 
                                            } 
                                        
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1853;
                    IINDEX = (ushort) ( FCONFIGURELISTFBMUTEX( __context__ , (ushort)( ILIST ) , (ushort)( IINDEX ) ) ) ; 
                    __context__.SourceCodeLine = 1854;
                    SYS . ICAMSEL = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 1856;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_8__ = ((int)SYS.UI.ISUB);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                                { 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1861;
                                FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.IVDSTPANELGUID ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 1865;
                                if ( Functions.TestForTrue  ( ( SYS.IVTCSEL)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1867;
                                    if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1869;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( SYS.CAM.IGUID[ IINDEX ] ) ; 
                                        __context__.SourceCodeLine = 1870;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( SYS.CAM.IGUID[ IINDEX ] )) ; 
                                        __context__.SourceCodeLine = 1871;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        __context__.SourceCodeLine = 1872;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( LIST [ 1] . ITEM [ SYS.CAM.IGUID[ IINDEX ]] . SGLOBALNAME  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 1876;
                                        SYS . VTC [ SYS.IVTCSEL] . ICAMSELECT = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 1877;
                                        FMTRXSENDROUTE (  __context__ , (ushort)( 2 ), (ushort)( SYS.VTC[ SYS.IVTCSEL ].IVINGUID[ 1 ] ), (ushort)( 0 )) ; 
                                        __context__.SourceCodeLine = 1878;
                                        VTC_CAMSELECT_NAME__DOLLAR__ [ SYS.IVTCSEL]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        __context__.SourceCodeLine = 1879;
                                        VTC_CAMSELECT_NAME__DOLLAR___SEL [ 1]  .UpdateValue ( SYS . SBLANKSRCTEXT  ) ; 
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1886;
        if ( Functions.TestForTrue  ( ( IERR)  ) ) 
            { 
            __context__.SourceCodeLine = 1888;
            
                {
                int __SPLS_TMPVAR__SWTCH_9__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1890;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1891;
                        FCONFIGUREGROUP (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1892;
                        FCONFIGUREFILTER (  __context__ , (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1893;
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
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10000, this );
        
        
        __context__.SourceCodeLine = 1903;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 1905;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 1906;
            FPROCESSINIT (  __context__ , STEMP) ; 
            __context__.SourceCodeLine = 1903;
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
        
        __context__.SourceCodeLine = 1916;
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
        
        __context__.SourceCodeLine = 1921;
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
        
        __context__.SourceCodeLine = 1940;
        SYS . SBLANKSRCTEXT  .UpdateValue ( "---"  ) ; 
        __context__.SourceCodeLine = 1942;
        SYS . VTC [ 1] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit01"  ) ; 
        __context__.SourceCodeLine = 1943;
        SYS . VTC [ 2] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit02"  ) ; 
        __context__.SourceCodeLine = 1944;
        SYS . VTC [ 3] . SUNITNAME  .UpdateValue ( "Cisco SX80 Unit03"  ) ; 
        __context__.SourceCodeLine = 1946;
        LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1947;
        LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1948;
        LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1949;
        LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1951;
        LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1952;
        LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1953;
        LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1954;
        LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1955;
        LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1956;
        LIST [ 7] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1957;
        LIST [ 12] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1958;
        LIST [ 13] . ILISTUSESVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1960;
        FILTER [ 6] . IMEMBERLISTFINDEX = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 1961;
        FILTER [ 8] . IMEMBERLISTFINDEX = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 1963;
        FILTER [ 5] . IMEMBERLISTVINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1964;
        FILTER [ 5] . IMEMBERLISTAINDEX = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 1966;
        FILTER [ 7] . IMEMBERLISTVINDEX = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1967;
        FILTER [ 7] . IMEMBERLISTAINDEX = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 1969;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1971;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1974;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 350 ) ; 
            __context__.SourceCodeLine = 1971;
            } 
        
        __context__.SourceCodeLine = 1976;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 3 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)4; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 1979;
            LIST_NUMOFITEMS [ I]  .Value = (ushort) ( 400 ) ; 
            __context__.SourceCodeLine = 1976;
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
    
    TO_ROOM_TX__DOLLAR__ = new InOutArray<StringOutput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        TO_ROOM_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ + i, TO_ROOM_TX__DOLLAR__[i+1] );
    }
    
    DATAINIT_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( DATAINIT_RX__DOLLAR____AnalogSerialInput__, 5000, this );
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

public UserModuleClass_L3_UA_HSIB_GLOBALMST_V1_0_55 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
const uint TO_ROOM_TX__DOLLAR____AnalogSerialOutput__ = 37;
const uint LIST_NUMOFITEMS__AnalogSerialOutput__ = 67;
const uint MTRX_V_OUT__AnalogSerialOutput__ = 79;
const uint MTRX_A_OUT__AnalogSerialOutput__ = 429;
const uint CAM_FOLDEDCMD__AnalogSerialOutput__ = 929;
const uint DISPLAY_FOLDEDCMD__AnalogSerialOutput__ = 979;

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
    public ushort  IISVTC = 0;
    
    [SplusStructAttribute(24, false, false)]
    public ushort  IVTCIO = 0;
    
    [SplusStructAttribute(25, false, false)]
    public CrestronString  SDEVICETYPE;
    
    [SplusStructAttribute(26, false, false)]
    public CrestronString  SUSBADDR;
    
    [SplusStructAttribute(27, false, false)]
    public ushort  IISUSB = 0;
    
    [SplusStructAttribute(28, false, false)]
    public ushort  IISVIRTUAL = 0;
    
    [SplusStructAttribute(29, false, false)]
    public ushort  IVLINK = 0;
    
    [SplusStructAttribute(30, false, false)]
    public CrestronString  SCMDDATA;
    
    [SplusStructAttribute(31, false, false)]
    public ushort  ICMDDATA = 0;
    
    [SplusStructAttribute(32, false, false)]
    public ushort  IROUTEDSRC = 0;
    
    [SplusStructAttribute(33, false, false)]
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
