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
using L3_Tools;

namespace UserModule_L3_UA_HSIB_NODEMST_V1_0_80
{
    public class UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_80 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RC_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RC_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RC_TOG;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PARTSENSESIGNAL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PARTSENSE_ENABLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PARTSENSE_DISABLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SYS_POWERON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SYS_POWEROFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MTRX_TAKE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MTRX_CLEAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MTRX_SELALL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_TILT_UP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_TILT_DN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_PAN_LEFT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_PAN_RIGHT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_ZOOM_TIGHT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_ZOOM_WIDE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_FOCUS_NEAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_FOCUS_FAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_POWER_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_POWER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CAM_POWER_TOG;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> SYS_PRESET;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> UI_PAGE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> UI_SUB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CAM_SELECT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CAM_PRESET_RECALL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_MACRO1_SRC;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_MACRO2_SRC;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_MACRO1_DST;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_MACRO2_DST;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_ADMINVSRC_CLICKED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MTRX_ADMINVDST_CLICKED;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> FROM_GLOBAL_RX__DOLLAR___1;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> FROM_GLOBAL_RX__DOLLAR___2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> RC_ON_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> RC_OFF_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PARTSENSE_ENABLE_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PARTSENSE_DISABLE_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SYS_POWERON_GO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SYS_POWEROFF_GO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> CAM_POWER_ON_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> CAM_POWER_OFF_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSP_PGM_RTE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_MACRO1_SRC_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_MACRO2_SRC_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_ADMINVSRC_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_ADMINVDST_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSP_MICS_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSP_LINE_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_MST_TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_DSP_TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_ADMINVSRC_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_ADMINVDST_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSP_MICS_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSP_LINE_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CAM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CAM_PRESETS_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DISPLAY_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_MACRO_SRC_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_MACRO_DST_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ROOMNAME__DOLLAR___OUT;
        STROOM [] ROOM;
        STSYS SYS;
        L3_Tools.StringTools ST;
        CrestronString STRASH;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 348;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 348;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 349;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 358;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 358;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 360;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 361;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 362;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 364;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 364;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 365;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 362;
                } 
            
            __context__.SourceCodeLine = 367;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 368;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 368;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 370;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 371;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 372;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 374;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 374;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 375;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 376;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 377;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 372;
                } 
            
            __context__.SourceCodeLine = 380;
            return ( SDATA ) ; 
            
            }
            
        private ushort FGETNUMITEMSSELECTED (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort I = 0;
            ushort ICOUNT = 0;
            
            
            __context__.SourceCodeLine = 386;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 388;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 388;
                    ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 386;
                } 
            
            __context__.SourceCodeLine = 391;
            return (ushort)( ICOUNT) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 396;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private void FCOPYIO (  SplusExecutionContext __context__, ushort IFROMROOM , ushort IFROMINDEX , ushort ITOROOM , ushort ITOINDEX , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 401;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IITEMACTIVE = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IITEMACTIVE ) ; 
            __context__.SourceCodeLine = 402;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SGLOBALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 403;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SLOCALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 404;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IRMASS = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IRMASS ) ; 
            __context__.SourceCodeLine = 405;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IGUID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 406;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFUNCTIONID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFUNCTIONID ) ; 
            __context__.SourceCodeLine = 407;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFILTERID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFILTERID ) ; 
            __context__.SourceCodeLine = 408;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IISVIRTUAL = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IISVIRTUAL ) ; 
            __context__.SourceCodeLine = 409;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IVLINK = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IVLINK ) ; 
            __context__.SourceCodeLine = 411;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 415;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IROUTEDSRC = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IROUTEDSRC ) ; 
                        __context__.SourceCodeLine = 416;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SROUTEDSRC  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SROUTEDSRC  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 428;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 430;
                        MTRX_ADMINVSRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 431;
                        MTRX_ADMINVDST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 432;
                        DSP_MICS_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 433;
                        DSP_LINE_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 434;
                        MTRX_MACRO_SRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 435;
                        MTRX_MACRO_DST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTNUMOFITEMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 441;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 443;
                        MTRX_ADMINVSRC_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 444;
                        MTRX_ADMINVDST_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 445;
                        DSP_MICS_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 446;
                        DSP_LINE_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 459;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESFB)  ) ) 
                { 
                __context__.SourceCodeLine = 461;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 462;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 464;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 468;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 470;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 470;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                            }
                        
                        __context__.SourceCodeLine = 468;
                        } 
                    
                    __context__.SourceCodeLine = 472;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 474;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 483;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 485;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 486;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 486;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 489;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 491;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 491;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                            }
                        
                        __context__.SourceCodeLine = 489;
                        } 
                    
                    __context__.SourceCodeLine = 493;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 495;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                __context__.SourceCodeLine = 496;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 496;
                    FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                    }
                
                } 
            
            
            }
            
        private void FUPDATELISTICON (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 506;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESICON)  ) ) 
                { 
                __context__.SourceCodeLine = 508;
                STEMP  .UpdateValue ( "{ListIconFB:"  ) ; 
                __context__.SourceCodeLine = 509;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 511;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 515;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 517;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 517;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                            }
                        
                        __context__.SourceCodeLine = 515;
                        } 
                    
                    __context__.SourceCodeLine = 519;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 521;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 530;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESTEXT)  ) ) 
                { 
                __context__.SourceCodeLine = 532;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 533;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 535;
                    STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                    __context__.SourceCodeLine = 536;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 538;
                        MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                        __context__.SourceCodeLine = 536;
                        } 
                    
                    __context__.SourceCodeLine = 540;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 544;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 546;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 548;
                            STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                            __context__.SourceCodeLine = 549;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                                { 
                                __context__.SourceCodeLine = 551;
                                MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                                __context__.SourceCodeLine = 549;
                                } 
                            
                            __context__.SourceCodeLine = 553;
                            STEMP  .UpdateValue ( STEMP + "|"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 555;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 850 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 557;
                            STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                            __context__.SourceCodeLine = 558;
                            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 559;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                                {
                                __context__.SourceCodeLine = 559;
                                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                                }
                            
                            __context__.SourceCodeLine = 560;
                            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 544;
                        } 
                    
                    __context__.SourceCodeLine = 563;
                    STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 565;
                if ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 567;
                    FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 568;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 568;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                        }
                    
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 576;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 577;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 578;
            FUPDATELISTICON (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 579;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FCONFIGURELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 590;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 592;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                    {
                    __context__.SourceCodeLine = 592;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 593;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                        {
                        __context__.SourceCodeLine = 593;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVLINK ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 594;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 594;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 595;
                            ; 
                            }
                        
                        }
                    
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 599;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 601;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                        {
                        __context__.SourceCodeLine = 601;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 602;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                            {
                            __context__.SourceCodeLine = 602;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVLINK ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 603;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                                {
                                __context__.SourceCodeLine = 603;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 604;
                                ; 
                                }
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 599;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 608;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 610;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 612;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                        {
                        __context__.SourceCodeLine = 612;
                        ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 613;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                            {
                            __context__.SourceCodeLine = 613;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVLINK ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 614;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                                {
                                __context__.SourceCodeLine = 614;
                                ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 615;
                                ; 
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 619;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 621;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                            {
                            __context__.SourceCodeLine = 621;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 622;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                                {
                                __context__.SourceCodeLine = 622;
                                ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVLINK ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 623;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 623;
                                    ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 624;
                                    ; 
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 619;
                        } 
                    
                    } 
                
                } 
            
            
            }
            
        private void FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 633;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                {
                __context__.SourceCodeLine = 633;
                MakeString ( STEMP , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                }
            
            __context__.SourceCodeLine = 634;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 636;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_4__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 640;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 641;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 645;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 646;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SROUTEDSRC  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                            { 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                            { 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 658;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 660;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                                } 
                            
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            
            }
            
        private void FSETLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort ISKIPINDEX , ushort IVAL ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 671;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 673;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I != ISKIPINDEX))  ) ) 
                    {
                    __context__.SourceCodeLine = 673;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( IVAL ) ; 
                    }
                
                __context__.SourceCodeLine = 671;
                } 
            
            
            }
            
        private void FSETLISTMACROFB (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 682;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 686;
                        MTRX_MACRO1_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 690;
                        MTRX_MACRO2_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATECAMFB (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            ushort I = 0;
            ushort IFB = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 700;
            STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
            __context__.SourceCodeLine = 701;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 703;
                IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 704;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].ICAMSEL == I))  ) ) 
                    {
                    __context__.SourceCodeLine = 704;
                    IFB = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 706;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)IFB) ; 
                __context__.SourceCodeLine = 701;
                } 
            
            __context__.SourceCodeLine = 709;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 711;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUPDATECAMVIS (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 719;
            STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 720;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 722;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)ROOM[ IROOM ].CAM[ I ].IVIS) ; 
                __context__.SourceCodeLine = 720;
                } 
            
            __context__.SourceCodeLine = 725;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 726;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUSBTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 739;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{USB_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FMTRXTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 747;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{MTRX_V_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FUPDATECONFMONITORRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 770;
            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 49 ].IGUID ), (ushort)( ISRCGUID )) ; 
            
            }
            
        private void FMTRX_VRTE_CLEAR (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 785;
            if ( Functions.TestForTrue  ( ( IDSTINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 787;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDSTINDEX ].IGUID ), (ushort)( 0 )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 791;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 793;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IISRCITEM ) ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 795;
                        FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( 0 )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 791;
                    } 
                
                } 
            
            
            }
            
        private void FUPDATEMACROSRC (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 806;
            Trace( "NodeMST - in fUpdateMacroSrc: iRoom={0:d}, iMacro={1:d}, iSrc={2:d}, iDiscreteMacroMode={3:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISRC, (ushort)ROOM[ IROOM ].IDISCRETEMACROMODE) ; 
            __context__.SourceCodeLine = 809;
            
                {
                int __SPLS_TMPVAR__SWTCH_6__ = ((int)ROOM[ IROOM ].IDISCRETEMACROMODE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 814;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 816;
                            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 817;
                            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
                            __context__.SourceCodeLine = 818;
                            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 822;
                            Trace( "NodeMST - attempting to use a Macro Src set other than [1] while discrete_macro_mode is disabled") ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 827;
                        ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 828;
                        FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
                        __context__.SourceCodeLine = 829;
                        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                        __context__.SourceCodeLine = 832;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IPGMAUDIO)  ) ) 
                            {
                            __context__.SourceCodeLine = 833;
                            DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IPGMAUDIO ) ; 
                            }
                        
                        __context__.SourceCodeLine = 835;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFDST; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 837;
                            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ IMACRO ].IDSTLIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                            __context__.SourceCodeLine = 840;
                            FUSBTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ IMACRO ].IDSTLIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                            __context__.SourceCodeLine = 835;
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATEMACRODST (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRODST ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 855;
            
                {
                int __SPLS_TMPVAR__SWTCH_7__ = ((int)ROOM[ IROOM ].IMACROTAKEMODE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 859;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ 1 ].ISTATE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 861;
                            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRODST ].INUMOFDST; 
                            int __FN_FORSTEP_VAL__1 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                { 
                                __context__.SourceCodeLine = 863;
                                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ IMACRODST ].IDSTLIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ROOM[ IROOM ].MACRO[ 1 ].ISTATE ].IGUID )) ; 
                                __context__.SourceCodeLine = 861;
                                } 
                            
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 871;
                        ROOM [ IROOM] . MACRO [ IMACRODST] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].MACRO[ IMACRODST ].IFB ) ) ; 
                        __context__.SourceCodeLine = 872;
                        MakeString ( STEMP , "{{ListButtonFB;{0:d}={1:d},|", (ushort)IMACRODST, (ushort)ROOM[ IROOM ].MACRO[ IMACRODST ].IFB) ; 
                        __context__.SourceCodeLine = 873;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), STEMP) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FCONFIGURELISTTEXTRMNUMS (  SplusExecutionContext __context__, ushort IROOM , ushort ISTATE ) 
            { 
            ushort IINDEX = 0;
            ushort ILIST = 0;
            
            CrestronString STHISROOM;
            CrestronString SOTHERROOM;
            STHISROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            SOTHERROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 884;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 886;
                MakeString ( STHISROOM , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                __context__.SourceCodeLine = 887;
                MakeString ( SOTHERROOM , "{0} ", ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . SROOMNAMESHORT ) ; 
                } 
            
            __context__.SourceCodeLine = 890;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 892;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)2; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( ILIST  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__2) && (ILIST  <= __FN_FOREND_VAL__2) ) : ( (ILIST  <= __FN_FORSTART_VAL__2) && (ILIST  >= __FN_FOREND_VAL__2) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 894;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 896;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                            {
                            __context__.SourceCodeLine = 897;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", SOTHERROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 899;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STHISROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 892;
                    } 
                
                __context__.SourceCodeLine = 890;
                } 
            
            
            }
            
        private void FUPDATERC (  SplusExecutionContext __context__, ushort ITYPE ) 
            { 
            ushort I = 0;
            ushort IROOM = 0;
            ushort [] V;
            V  = new ushort[ 3 ];
            
            
            __context__.SourceCodeLine = 909;
            
                {
                int __SPLS_TMPVAR__SWTCH_8__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 914;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)2; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
                            {
                            __context__.SourceCodeLine = 915;
                            V [ IROOM] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 4 ].IVLINK ) ; 
                            __context__.SourceCodeLine = 914;
                            }
                        
                        __context__.SourceCodeLine = 918;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( V[ 2 ] ) && Functions.TestForTrue ( Functions.Not( V[ 1 ] ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 920;
                            FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 4 ), (ushort)( 1 ), (ushort)( 4 ), (ushort)( 1 )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 924;
                            FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 4 ), (ushort)( 2 ), (ushort)( 4 ), (ushort)( 1 )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 928;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)2; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 930;
                            V [ IROOM] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 5 ].IVLINK ) ; 
                            __context__.SourceCodeLine = 928;
                            } 
                        
                        __context__.SourceCodeLine = 933;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ 2 ].IVTCALLOCATION ) && Functions.TestForTrue ( Functions.Not( ROOM[ 1 ].IVTCALLOCATION ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 935;
                            FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 936;
                            FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 6 ), (ushort)( 1 ), (ushort)( 6 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 938;
                            ROOM [ 1] . IVTCALLOCATION = (ushort) ( ROOM[ 2 ].IVTCALLOCATION ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 942;
                            FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 5 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 943;
                            FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 6 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 945;
                            ROOM [ 2] . IVTCALLOCATION = (ushort) ( ROOM[ 1 ].IVTCALLOCATION ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 949;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)2; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__3) && (IROOM  <= __FN_FOREND_VAL__3) ) : ( (IROOM  <= __FN_FORSTART_VAL__3) && (IROOM  >= __FN_FOREND_VAL__3) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 951;
                            FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 952;
                            ushort __FN_FORSTART_VAL__4 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__4 = (ushort)6; 
                            int __FN_FORSTEP_VAL__4 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                                { 
                                __context__.SourceCodeLine = 954;
                                ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( ROOM[ IROOM ].CAM[ I ].ICAMACTIVE ) ; 
                                __context__.SourceCodeLine = 952;
                                } 
                            
                            __context__.SourceCodeLine = 956;
                            FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 949;
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 961;
                        ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__5 = (ushort)2; 
                        int __FN_FORSTEP_VAL__5 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__5) && (IROOM  <= __FN_FOREND_VAL__5) ) : ( (IROOM  <= __FN_FORSTART_VAL__5) && (IROOM  >= __FN_FOREND_VAL__5) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__5) 
                            { 
                            __context__.SourceCodeLine = 963;
                            ushort __FN_FORSTART_VAL__6 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__6 = (ushort)6; 
                            int __FN_FORSTEP_VAL__6 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                                { 
                                __context__.SourceCodeLine = 965;
                                ROOM [ IROOM] . LIST [ 1] . ITEM [ I] . IVLINK = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 963;
                                } 
                            
                            __context__.SourceCodeLine = 961;
                            } 
                        
                        __context__.SourceCodeLine = 970;
                        ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__7 = (ushort)2; 
                        int __FN_FORSTEP_VAL__7 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__7) && (IROOM  <= __FN_FOREND_VAL__7) ) : ( (IROOM  <= __FN_FORSTART_VAL__7) && (IROOM  >= __FN_FOREND_VAL__7) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__7) 
                            { 
                            __context__.SourceCodeLine = 972;
                            ROOM [ IROOM] . ICAMSEL = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 973;
                            FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 974;
                            ushort __FN_FORSTART_VAL__8 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__8 = (ushort)6; 
                            int __FN_FORSTEP_VAL__8 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                                { 
                                __context__.SourceCodeLine = 976;
                                ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 974;
                                } 
                            
                            __context__.SourceCodeLine = 978;
                            FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 970;
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 983;
            ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__9 = (ushort)2; 
            int __FN_FORSTEP_VAL__9 = (int)1; 
            for ( IROOM  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__9) && (IROOM  <= __FN_FOREND_VAL__9) ) : ( (IROOM  <= __FN_FORSTART_VAL__9) && (IROOM  >= __FN_FOREND_VAL__9) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__9) 
                { 
                __context__.SourceCodeLine = 985;
                FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 986;
                FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 988;
                FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 989;
                FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 992;
                FCONFIGURELISTTEXTRMNUMS (  __context__ , (ushort)( IROOM ), (ushort)( SYS.IRCSTATE )) ; 
                __context__.SourceCodeLine = 993;
                FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 994;
                FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 983;
                } 
            
            
            }
            
        private void FPROCESSFINALIZE (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort IOTHERROOM = 0;
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 1008;
            IOTHERROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            __context__.SourceCodeLine = 1010;
            FUPDATELISTNUMOFITEMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1012;
            
                {
                int __SPLS_TMPVAR__SWTCH_9__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1021;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)3; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 1025;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1026;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                            __context__.SourceCodeLine = 1028;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( IOTHERROOM ), (ushort)( (I + 6) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1029;
                            ROOM [ IOTHERROOM] . LIST [ ILIST] . ITEM [ (I + 6)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1030;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( (I + 6) )) ; 
                            __context__.SourceCodeLine = 1034;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 3)] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 3) ].IVLINK ) ; 
                            __context__.SourceCodeLine = 1021;
                            } 
                        
                        __context__.SourceCodeLine = 1036;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)3; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 1039;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 20) ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1042;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1043;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                                __context__.SourceCodeLine = 1045;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 20) ), (ushort)( IOTHERROOM ), (ushort)( ((I + 20) + (10 / 2)) ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1046;
                                ROOM [ IOTHERROOM] . LIST [ ILIST] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1047;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( (I + 23) )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1036;
                            } 
                        
                        __context__.SourceCodeLine = 1050;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 10 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)20; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 1052;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1054;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1055;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1050;
                            } 
                        
                        __context__.SourceCodeLine = 1058;
                        ushort __FN_FORSTART_VAL__4 = (ushort) ( 31 ) ;
                        ushort __FN_FOREND_VAL__4 = (ushort)50; 
                        int __FN_FORSTEP_VAL__4 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                            { 
                            __context__.SourceCodeLine = 1060;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1062;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1063;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1058;
                            } 
                        
                        __context__.SourceCodeLine = 1066;
                        ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__5 = (ushort)50; 
                        int __FN_FORSTEP_VAL__5 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                            { 
                            __context__.SourceCodeLine = 1068;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1070;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1066;
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1076;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1087;
                            ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__6 = (ushort)(40 / 2); 
                            int __FN_FORSTEP_VAL__6 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                                { 
                                __context__.SourceCodeLine = 1089;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1092;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1093;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                    __context__.SourceCodeLine = 1095;
                                    FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( IOTHERROOM ), (ushort)( (I + (40 / 2)) ), (ushort)( ILIST )) ; 
                                    __context__.SourceCodeLine = 1096;
                                    ROOM [ IOTHERROOM] . LIST [ ILIST] . ITEM [ (I + (40 / 2))] . IISRCITEM = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1097;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( (I + (40 / 2)) )) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 1087;
                                } 
                            
                            __context__.SourceCodeLine = 1100;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 41 ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1102;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 41] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1103;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 41 )) ; 
                                __context__.SourceCodeLine = 1105;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 41 ), (ushort)( IOTHERROOM ), (ushort)( 42 ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1106;
                                ROOM [ IOTHERROOM] . LIST [ ILIST] . ITEM [ 42] . IISRCITEM = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1107;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( 42 )) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1109;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 49 ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1111;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 49] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1112;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 49 )) ; 
                                    __context__.SourceCodeLine = 1114;
                                    FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 41 ), (ushort)( IOTHERROOM ), (ushort)( 50 ), (ushort)( ILIST )) ; 
                                    __context__.SourceCodeLine = 1115;
                                    ROOM [ IOTHERROOM] . LIST [ ILIST] . ITEM [ 50] . IISRCITEM = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1116;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( 50 )) ; 
                                    } 
                                
                                }
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1121;
                            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__7 = (ushort)50; 
                            int __FN_FORSTEP_VAL__7 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                                { 
                                __context__.SourceCodeLine = 1123;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1125;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1126;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1130;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 1121;
                                } 
                            
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 13) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1137;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . IOTHERROOMACTIVE = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1138;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . IOTHERROOMGUID = (ushort) ( ROOM[ IROOM ].IROOMGUID ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1142;
            FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1143;
            FUPDATELISTALL (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1145;
            FCONFIGURELISTVIS (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1146;
            FUPDATELISTALL (  __context__ , (ushort)( IOTHERROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            
            }
            
        private void FPROCESSVROUTE (  SplusExecutionContext __context__, ushort IROOM , ushort ILOCALINDEX , CrestronString STEMPLINE ) 
            { 
            CrestronString STEMPDATA;
            CrestronString STEMPGUID;
            CrestronString STEMPSRC;
            STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            STEMPGUID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
            STEMPSRC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1158;
            STEMPDATA  .UpdateValue ( STEMPLINE  ) ; 
            __context__.SourceCodeLine = 1159;
            STEMPGUID  .UpdateValue ( Functions.Remove ( "," , STEMPDATA )  ) ; 
            __context__.SourceCodeLine = 1160;
            STEMPSRC  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (Functions.Find( "," , STEMPDATA ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 1161;
            STRASH  .UpdateValue ( Functions.Remove ( "src_name=" , STEMPSRC )  ) ; 
            __context__.SourceCodeLine = 1164;
            ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1165;
            ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
            __context__.SourceCodeLine = 1166;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1167;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1170;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 1172;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX <= 20 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1174;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                    __context__.SourceCodeLine = 1175;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
                    __context__.SourceCodeLine = 1176;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
                    __context__.SourceCodeLine = 1177;
                    FUPDATELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
                    } 
                
                } 
            
            
            }
            
        private ushort FPROCESSMACRO (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , CrestronString SLINE ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            CrestronString SDATA;
            CrestronString STEMPKV;
            CrestronString STEMPKEY;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            STEMPKV  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
            STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1188;
            SDATA  .UpdateValue ( SLINE  ) ; 
            __context__.SourceCodeLine = 1190;
            while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 1192;
                STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
                __context__.SourceCodeLine = 1194;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "name" , STEMPKEY ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1196;
                    ROOM [ IROOM] . MACRO [ IMACRO] . SNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "," , SDATA ) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 1197;
                    STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1199;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "primary" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1199;
                        ROOM [ IROOM] . MACRO [ IMACRO] . IPRIMARYDST = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1200;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1200;
                            ROOM [ IROOM] . MACRO [ IMACRO] . IUSB = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1201;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_dst" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1201;
                                ROOM [ IROOM] . MACRO [ IMACRO] . ICAMDST = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1202;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1202;
                                    ROOM [ IROOM] . MACRO [ IMACRO] . IPGMAUDIO = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1203;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list" , STEMPKEY ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1205;
                                        I = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 1206;
                                        STEMP  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                                        __context__.SourceCodeLine = 1207;
                                        while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMP ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1209;
                                            I = (ushort) ( (I + 1) ) ; 
                                            __context__.SourceCodeLine = 1210;
                                            ROOM [ IROOM] . MACRO [ IMACRO] . IDSTLIST [ I] = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                            __context__.SourceCodeLine = 1211;
                                            STRASH  .UpdateValue ( Functions.Remove ( "," , STEMP )  ) ; 
                                            __context__.SourceCodeLine = 1207;
                                            } 
                                        
                                        __context__.SourceCodeLine = 1213;
                                        if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMP ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1215;
                                            I = (ushort) ( (I + 1) ) ; 
                                            __context__.SourceCodeLine = 1216;
                                            ROOM [ IROOM] . MACRO [ IMACRO] . IDSTLIST [ I] = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                            } 
                                        
                                        __context__.SourceCodeLine = 1218;
                                        ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFDST = (ushort) ( I ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 1222;
                                        Trace( "NodeMST - fProcessMacro - error parsing macro, {0}", SLINE ) ; 
                                        } 
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 1190;
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FPROCESSLINE (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX , CrestronString STEMP ) 
            { 
            ushort I = 0;
            ushort IERR = 0;
            ushort ICAM = 0;
            ushort IDISPLAY = 0;
            
            CrestronString STEMPKEY;
            CrestronString STEMPVALUE;
            CrestronString STEMPPAIR;
            CrestronString STEMPLINE;
            STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            STEMPVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMPPAIR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 151, this );
            STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 1239;
            STEMPLINE  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 1242;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1243;
            ROOM [ IROOM] . LIST [ ILIST] . IMAXNUMITEMS = (ushort) ( Functions.Max( IINDEX , ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ) ; 
            __context__.SourceCodeLine = 1246;
            while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
                { 
                __context__.SourceCodeLine = 1248;
                STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
                __context__.SourceCodeLine = 1249;
                STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
                __context__.SourceCodeLine = 1250;
                STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 1252;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1252;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1253;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1253;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1254;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1254;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1255;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1255;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1256;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1256;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1257;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1257;
                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1258;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_localid" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1258;
                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1259;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_global" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1259;
                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1261;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1261;
                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1262;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_localid" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1262;
                                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1263;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_global" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1263;
                                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1264;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "virtual" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1264;
                                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1265;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 1265;
                                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 1266;
                                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                                                                        {
                                                                        __context__.SourceCodeLine = 1266;
                                                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IPGMAUDIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                        }
                                                                    
                                                                    else 
                                                                        { 
                                                                        __context__.SourceCodeLine = 1270;
                                                                        Trace( "NodeMST - fProcessLine - didn't catch key:   GUID={0:d}, {1}{2}", (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                                                        __context__.SourceCodeLine = 1271;
                                                                        IERR = (ushort) ( 1 ) ; 
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
                
                __context__.SourceCodeLine = 1246;
                } 
            
            __context__.SourceCodeLine = 1275;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID)  ) ) 
                {
                __context__.SourceCodeLine = 1275;
                ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID] = (ushort) ( IINDEX ) ; 
                }
            
            __context__.SourceCodeLine = 1277;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
                { 
                __context__.SourceCodeLine = 1281;
                ICAM = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMLOCALID ) ; 
                __context__.SourceCodeLine = 1282;
                ROOM [ IROOM] . CAM [ ICAM] . ICAMGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMGUID ) ; 
                __context__.SourceCodeLine = 1283;
                ROOM [ IROOM] . CAM [ ICAM] . ICAMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1284;
                ROOM [ IROOM] . CAM [ ICAM] . IVIS = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1285;
                ROOM [ IROOM] . CAM [ ICAM] . IVSRCLOCALID = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 1286;
                ROOM [ IROOM] . CAM [ ICAM] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
                __context__.SourceCodeLine = 1288;
                ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                __context__.SourceCodeLine = 1289;
                ROOM [ IROOM] . CAM [ ICAM] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                __context__.SourceCodeLine = 1291;
                ROOM [ IROOM] . CAM [ ICAM] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
                __context__.SourceCodeLine = 1294;
                MakeString ( CAM_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)ICAM, (ushort)ICAM, ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
                __context__.SourceCodeLine = 1296;
                if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1298;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMACTIVE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1299;
                    MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(ICAM + 3), ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
                    __context__.SourceCodeLine = 1301;
                    if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1303;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1304;
                        MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(ICAM + 3)) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1306;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].ICAMGUID ) ; 
                    __context__.SourceCodeLine = 1307;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVSRCLOCALID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCLOCALID ) ; 
                    __context__.SourceCodeLine = 1308;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1311;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1314;
                    IDISPLAY = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYLOCALID ) ; 
                    __context__.SourceCodeLine = 1315;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYGUID ) ; 
                    __context__.SourceCodeLine = 1316;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1317;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVIS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1318;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTLOCALID = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 1319;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
                    __context__.SourceCodeLine = 1321;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1322;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                    __context__.SourceCodeLine = 1324;
                    ROOM [ IROOM] . DISPLAY [ IDISPLAY] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
                    __context__.SourceCodeLine = 1326;
                    MakeString ( DISPLAY_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)IDISPLAY, (ushort)IDISPLAY, ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                    __context__.SourceCodeLine = 1329;
                    if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1331;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1333;
                        MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(IDISPLAY + (40 / 2)), ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                        __context__.SourceCodeLine = 1335;
                        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1337;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1338;
                            MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(IDISPLAY + (40 / 2))) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1340;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IDISPLAYGUID ) ; 
                        __context__.SourceCodeLine = 1341;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVDSTLOCALID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IVDSTLOCALID ) ; 
                        __context__.SourceCodeLine = 1342;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVDSTGUID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IVDSTGUID ) ; 
                        } 
                    
                    } 
                
                }
            
            
            }
            
        private void FPROCESSROOMS (  SplusExecutionContext __context__, ushort IROOM , ushort IGLOBALROOMNUM , CrestronString STEMPLINE ) 
            { 
            CrestronString SDATA;
            CrestronString STEMPKV;
            CrestronString STEMPKEY;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPKV  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1351;
            SDATA  .UpdateValue ( STEMPLINE  ) ; 
            __context__.SourceCodeLine = 1353;
            if ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 1355;
                ROOM [ IROOM] . IROOMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1356;
                ROOM [ IROOM] . IROOMGUID = (ushort) ( IGLOBALROOMNUM ) ; 
                } 
            
            __context__.SourceCodeLine = 1358;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IROOM == 2) ) && Functions.TestForTrue ( ROOM[ IROOM ].IROOMGUID )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1358;
                SYS . IISRCPAIR = (ushort) ( 1 ) ; 
                }
            
            __context__.SourceCodeLine = 1360;
            while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 1362;
                STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                __context__.SourceCodeLine = 1363;
                STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
                __context__.SourceCodeLine = 1364;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1364;
                    ROOM [ IROOM] . SROOMNAME  .UpdateValue ( ST . StringTrim (  STEMPKV  .ToSimplSharpString() )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1365;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_num" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1365;
                        ROOM [ IROOM] . IBLDGROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1366;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1366;
                            ROOM [ IROOM] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1367;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1367;
                                ROOM [ IROOM] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1368;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "use_src_list_mode" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1368;
                                    ROOM [ IROOM] . IUSESRCLISTMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 1360;
                } 
            
            __context__.SourceCodeLine = 1370;
            ROOMNAME__DOLLAR___OUT [ IROOM]  .UpdateValue ( ROOM [ IROOM] . SROOMNAME  ) ; 
            __context__.SourceCodeLine = 1371;
            MakeString ( ROOM [ IROOM] . SROOMNAMESHORT , "{0:d}", (ushort)ROOM[ IROOM ].IBLDGROOMNUM) ; 
            
            }
            
        private void FPROCESSVLINK (  SplusExecutionContext __context__, ushort ITYPE , ushort IROOM , ushort ILOCALINDEX , CrestronString STEMPLINE ) 
            { 
            ushort I = 0;
            ushort ILIST = 0;
            ushort IVLINK = 0;
            ushort ILOCALID = 0;
            ushort IOLDGUID = 0;
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 1381;
            Trace( "in fProcessVLink - iRoom = {0:d}, iLocalIndex = {1:d}, sData = {2}", (ushort)IROOM, (ushort)ILOCALINDEX, STEMPLINE ) ; 
            __context__.SourceCodeLine = 1382;
            SDATA  .UpdateValue ( STEMPLINE  ) ; 
            __context__.SourceCodeLine = 1383;
            IVLINK = (ushort) ( Functions.Atoi( SDATA ) ) ; 
            __context__.SourceCodeLine = 1384;
            STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1386;
            
                {
                int __SPLS_TMPVAR__SWTCH_10__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 15) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1388;
                        ILIST = (ushort) ( 1 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 16) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1389;
                        ILIST = (ushort) ( 2 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 17) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1390;
                        ILIST = (ushort) ( 3 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 18) ) ) ) 
                        {
                        __context__.SourceCodeLine = 1391;
                        ILIST = (ushort) ( 4 ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1394;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IISVIRTUAL)  ) ) 
                { 
                __context__.SourceCodeLine = 1396;
                IOLDGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IVLINK ) ; 
                __context__.SourceCodeLine = 1399;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVLINK = (ushort) ( IVLINK ) ; 
                __context__.SourceCodeLine = 1400;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IGUID = (ushort) ( IVLINK ) ; 
                __context__.SourceCodeLine = 1401;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SGLOBALNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "|" , SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 1402;
                ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ IVLINK] = (ushort) ( ILOCALINDEX ) ; 
                __context__.SourceCodeLine = 1405;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
                __context__.SourceCodeLine = 1406;
                FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
                __context__.SourceCodeLine = 1408;
                FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
                __context__.SourceCodeLine = 1409;
                FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
                __context__.SourceCodeLine = 1412;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IOLDGUID ) && Functions.TestForTrue ( Functions.BoolToInt (IOLDGUID != IVLINK) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1414;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)50; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1416;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IROUTEDSRC == IOLDGUID))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1418;
                            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( IVLINK )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1414;
                        } 
                    
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1425;
                Trace( "NodeMST - in fProcessVLink - attempting to change the GUID of a list item that is not virtual, room={0:d}, list={1:d}, item={2:d}", (ushort)IROOM, (ushort)ILIST, (ushort)ILOCALINDEX) ; 
                } 
            
            
            }
            
        private void FPROCESSDATA (  SplusExecutionContext __context__, ushort IROOM , CrestronString STEMPINITDATA ) 
            { 
            ushort I = 0;
            ushort J = 0;
            ushort ITYPE = 0;
            ushort ILOCALINDEX = 0;
            
            CrestronString STEMPDATA;
            CrestronString STEMPHEADER;
            CrestronString STEMPLOCALID;
            CrestronString STEMPLINE;
            STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMPLOCALID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            STEMPLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
            
            
            __context__.SourceCodeLine = 1441;
            STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
            __context__.SourceCodeLine = 1443;
            STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
            __context__.SourceCodeLine = 1445;
            ITYPE = (ushort) ( Functions.Atoi( STEMPHEADER ) ) ; 
            __context__.SourceCodeLine = 1447;
            while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 1449;
                STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
                __context__.SourceCodeLine = 1450;
                if ( Functions.TestForTrue  ( ( Functions.Find( "COMPLETE" , STEMPLINE ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1450;
                    FPROCESSFINALIZE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE )) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 1453;
                    if ( Functions.TestForTrue  ( ( Functions.Find( ";" , STEMPLINE ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1453;
                        STRASH  .UpdateValue ( Functions.Remove ( ";" , STEMPLINE )  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 1454;
                    ILOCALINDEX = (ushort) ( Functions.Atoi( Functions.Remove( ":" , STEMPLINE ) ) ) ; 
                    __context__.SourceCodeLine = 1456;
                    if ( Functions.TestForTrue  ( ( ILOCALINDEX)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1458;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITYPE <= 4 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1458;
                            FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1459;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 10))  ) ) 
                                {
                                __context__.SourceCodeLine = 1459;
                                FPROCESSVROUTE (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1460;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1460;
                                    FPROCESSMACRO (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1461;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1461;
                                        FPROCESSROOMS (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1462;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 15))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1462;
                                            FPROCESSVLINK (  __context__ , (ushort)( ITYPE ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1463;
                                            Trace( "NodeMST - fProcessData - didn't catch iLocalIndex") ; 
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1465;
                        Trace( "NodeMST - fProcessData - iLocalIndex=0.    {0} iLocalID={1:d};{2}", STEMPHEADER , (ushort)ILOCALINDEX, STEMPLINE ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1447;
                } 
            
            
            }
            
        private void FDISPLAYPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort ISTATE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1481;
            if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                { 
                __context__.SourceCodeLine = 1483;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(40 / 2); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1485;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1487;
                        ROOM [ IROOM] . DISPLAY [ I] . IDISPLAYPOWERSTATE = (ushort) ( ISTATE ) ; 
                        __context__.SourceCodeLine = 1488;
                        MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},power={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYGUID, (ushort)ISTATE) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1483;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1494;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1496;
                    ROOM [ IROOM] . DISPLAY [ IINDEX] . IDISPLAYPOWERSTATE = (ushort) ( ISTATE ) ; 
                    __context__.SourceCodeLine = 1497;
                    MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},power={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYGUID, (ushort)ISTATE) ; 
                    } 
                
                } 
            
            
            }
            
        private void FCAMCMDSEND (  SplusExecutionContext __context__, ushort IROOM , ushort IGUID , CrestronString SCMD ) 
            { 
            
            __context__.SourceCodeLine = 1504;
            if ( Functions.TestForTrue  ( ( Functions.Not( IGUID ))  ) ) 
                {
                __context__.SourceCodeLine = 1504;
                IGUID = (ushort) ( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].ICAMGUID ) ; 
                }
            
            __context__.SourceCodeLine = 1505;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{CAM_CTRL; guid={0:d}: cmd={1},|;}}", (ushort)IGUID, SCMD ) ; 
            
            }
            
        private void FCAMPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort ISTATE ) 
            { 
            
            __context__.SourceCodeLine = 1513;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1515;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].CAM[ IINDEX ].ICAMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1517;
                    ROOM [ IROOM] . CAM [ IINDEX] . ICAMPOWERSTATE = (ushort) ( ISTATE ) ; 
                    __context__.SourceCodeLine = 1518;
                    if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                        {
                        __context__.SourceCodeLine = 1518;
                        FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_on") ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1519;
                        FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_off") ; 
                        }
                    
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1525;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)3; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1527;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].CAM[ IINDEX ].ICAMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1529;
                        ROOM [ IROOM] . CAM [ IINDEX] . ICAMPOWERSTATE = (ushort) ( ISTATE ) ; 
                        __context__.SourceCodeLine = 1530;
                        if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                            {
                            __context__.SourceCodeLine = 1530;
                            FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_on") ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1531;
                            FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_off") ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 1525;
                    } 
                
                } 
            
            
            }
            
        private void FSYSTEMPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort ISTATE ) 
            { 
            
            __context__.SourceCodeLine = 1540;
            FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( 0 ), (ushort)( ISTATE )) ; 
            __context__.SourceCodeLine = 1542;
            FMTRX_VRTE_CLEAR (  __context__ , (ushort)( IROOM ), (ushort)( 0 )) ; 
            
            }
            
        private void FUPDATERC_STATE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1555;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1557;
                if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1559;
                    RC_OFF_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1560;
                    RC_ON_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1564;
                    RC_ON_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1565;
                    RC_OFF_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1555;
                } 
            
            
            }
            
        private void FUPDATERC_ENABLE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1574;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1576;
                if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1578;
                    PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1579;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1583;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1584;
                    PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1574;
                } 
            
            
            }
            
        object RC_ON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                ushort J = 0;
                
                
                __context__.SourceCodeLine = 1598;
                SYS . IRCSTATE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1599;
                FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                __context__.SourceCodeLine = 1600;
                FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RC_OFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 1607;
            SYS . IRCSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1608;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1609;
            FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RC_TOG_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        
        
        __context__.SourceCodeLine = 1616;
        SYS . IRCSTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 1617;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1618;
        FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PARTSENSESIGNAL_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1625;
        if ( Functions.TestForTrue  ( ( SYS.IPARTITIONENABLED)  ) ) 
            { 
            __context__.SourceCodeLine = 1627;
            SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PARTSENSE_ENABLE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1634;
        SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1636;
        FUPDATERC_ENABLE_FB (  __context__ , (ushort)( SYS.IPARTITIONENABLED )) ; 
        __context__.SourceCodeLine = 1638;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) != SYS.IRCSTATE))  ) ) 
            { 
            __context__.SourceCodeLine = 1640;
            SYS . IRCSTATE = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
            __context__.SourceCodeLine = 1641;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1642;
            FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PARTSENSE_DISABLE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1649;
        SYS . IPARTITIONENABLED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1651;
        FUPDATERC_ENABLE_FB (  __context__ , (ushort)( SYS.IPARTITIONENABLED )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SYS_POWERON_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1658;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1660;
        Functions.Pulse ( 10, SYS_POWERON_GO [ I] ) ; 
        __context__.SourceCodeLine = 1661;
        ROOM [ I] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1662;
        FSYSTEMPOWER (  __context__ , (ushort)( I ), (ushort)( ROOM[ I ].ISYSPOWERSTATE )) ; 
        __context__.SourceCodeLine = 1664;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1666;
            Functions.Pulse ( 10, SYS_POWERON_GO [ FOTHERROOM( __context__ , (ushort)( I ) )] ) ; 
            __context__.SourceCodeLine = 1667;
            ROOM [ FOTHERROOM( __context__ , (ushort)( I ) )] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1668;
            FSYSTEMPOWER (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( I ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( I ) ) ].ISYSPOWERSTATE )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SYS_POWEROFF_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1675;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1677;
        Functions.Pulse ( 10, SYS_POWEROFF_GO [ I] ) ; 
        __context__.SourceCodeLine = 1678;
        ROOM [ I] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1679;
        FSYSTEMPOWER (  __context__ , (ushort)( I ), (ushort)( ROOM[ I ].ISYSPOWERSTATE )) ; 
        __context__.SourceCodeLine = 1681;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1683;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ FOTHERROOM( __context__ , (ushort)( I ) )] ) ; 
            __context__.SourceCodeLine = 1684;
            ROOM [ FOTHERROOM( __context__ , (ushort)( I ) )] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1685;
            FSYSTEMPOWER (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( I ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( I ) ) ].ISYSPOWERSTATE )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SYS_PRESET_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort ISYSPRESET = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1701;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1702;
        ISYSPRESET = (ushort) ( SYS_PRESET[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1704;
        if ( Functions.TestForTrue  ( ( ISYSPRESET)  ) ) 
            { 
            __context__.SourceCodeLine = 1706;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1708;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1710;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == ISYSPRESET) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == 9) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1712;
                        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 1 )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1716;
                        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1706;
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_TAKE_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IDST = 0;
        ushort IROOM = 0;
        ushort ISRC = 0;
        
        
        __context__.SourceCodeLine = 1730;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1732;
        ISRC = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED ) ; 
        __context__.SourceCodeLine = 1733;
        if ( Functions.TestForTrue  ( ( FGETNUMITEMSSELECTED( __context__ , (ushort)( IROOM ) , (ushort)( 2 ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1735;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ 2 ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1737;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1739;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                    } 
                
                __context__.SourceCodeLine = 1735;
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_CLEAR_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1748;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1750;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1751;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1753;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1754;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1756;
        ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1757;
        ROOM [ IROOM] . LIST [ 2] . INUMOFITEMSSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1759;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_SELALL_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1766;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1768;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1769;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1771;
        ROOM [ IROOM] . LIST [ 2] . INUMOFITEMSSELECTED = (ushort) ( FGETNUMITEMSSELECTED( __context__ , (ushort)( IROOM ) , (ushort)( 2 ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_ADMINVSRC_CLICKED_OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort IINDEX = 0;
        
        
        __context__.SourceCodeLine = 1777;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1778;
        IINDEX = (ushort) ( MTRX_ADMINVSRC_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1780;
        if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1783;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED)  ) ) 
                { 
                __context__.SourceCodeLine = 1785;
                ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED] . IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1786;
                FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED )) ; 
                } 
            
            __context__.SourceCodeLine = 1788;
            ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1789;
            ROOM [ IROOM] . LIST [ 1] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1790;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 1792;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
            __context__.SourceCodeLine = 1796;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IUSESRCLISTMODE)  ) ) 
                {
                __context__.SourceCodeLine = 1796;
                FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_ADMINVDST_CLICKED_OnChange_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort IINDEX = 0;
        
        
        __context__.SourceCodeLine = 1804;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1805;
        IINDEX = (ushort) ( MTRX_ADMINVDST_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1808;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IINDEX ].IFB ) ) ; 
        __context__.SourceCodeLine = 1809;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( IINDEX )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_MACRO1_SRC_OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort ISRC = 0;
        ushort IMACRO = 0;
        ushort I = 0;
        
        short SISRC = 0;
        
        
        __context__.SourceCodeLine = 1816;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1817;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1818;
        ISRC = (ushort) ( MTRX_MACRO1_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1820;
        ROOM [ IROOM] . ILASTMACROSEL = (ushort) ( ISRC ) ; 
        __context__.SourceCodeLine = 1822;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 1824;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1829;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC < 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 1829;
                ISRC = (ushort) ( (ISRC + 6) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1830;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1830;
                    ISRC = (ushort) ( (ISRC - 6) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1831;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ILASTMACROSEL = (ushort) ( ISRC ) ; 
            __context__.SourceCodeLine = 1832;
            FUPDATEMACROSRC (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_MACRO2_SRC_OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort ISRC = 0;
        ushort IMACRO = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1838;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1839;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1840;
        ISRC = (ushort) ( MTRX_MACRO2_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1842;
        ROOM [ IROOM] . ILASTMACROSEL = (ushort) ( ISRC ) ; 
        __context__.SourceCodeLine = 1844;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 1846;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1851;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC < 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 1851;
                ISRC = (ushort) ( (ISRC + 6) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1852;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1852;
                    ISRC = (ushort) ( (ISRC - 6) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1853;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ILASTMACROSEL = (ushort) ( ISRC ) ; 
            __context__.SourceCodeLine = 1854;
            FUPDATEMACROSRC (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_MACRO1_DST_OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort IDST = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1862;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1863;
        IDST = (ushort) ( MTRX_MACRO1_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1865;
        FUPDATEMACRODST (  __context__ , (ushort)( IROOM ), (ushort)( IDST )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MTRX_MACRO2_DST_OnChange_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        ushort IDST = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1870;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1871;
        IDST = (ushort) ( MTRX_MACRO2_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1873;
        FUPDATEMACRODST (  __context__ , (ushort)( IROOM ), (ushort)( IDST )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_TILT_UP_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1885;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "pantilt_up") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_TILT_DN_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1889;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "pantilt_down") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_PAN_LEFT_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1893;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "pantilt_left") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_PAN_RIGHT_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1897;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "pantilt_right") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_ZOOM_TIGHT_OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1901;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "zoom_in") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_ZOOM_WIDE_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1905;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "zoom_out") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_POWER_ON_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1909;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "power_on") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_POWER_OFF_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1913;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "power_off") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_TILT_UP_OnRelease_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1918;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "pantilt_stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_ZOOM_TIGHT_OnRelease_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1923;
        FCAMCMDSEND (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 ), "zoom_stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CAM_SELECT_OnChange_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IFB = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        
        __context__.SourceCodeLine = 1931;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1932;
        ROOM [ IROOM] . ICAMSEL = (ushort) ( CAM_SELECT[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1934;
        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
        __context__.SourceCodeLine = 1936;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].IVSRCGUID )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FUPDATEGUI (  SplusExecutionContext __context__, ushort IROOM , ushort IPAGE , ushort ISUB ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1950;
    
        {
        int __SPLS_TMPVAR__SWTCH_11__ = ((int)IPAGE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 1) ) ) ) 
                { 
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 2) ) ) ) 
                { 
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 3) ) ) ) 
                { 
                __context__.SourceCodeLine = 1956;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_12__ = ((int)ISUB);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 1960;
                            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ROOM[ IROOM ].ILASTMACROSEL ].IGUID )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 1964;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ICAMSEL)  ) ) 
                                {
                                __context__.SourceCodeLine = 1965;
                                FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].IVSRCGUID )) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 3) ) ) ) 
                            { 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 4) ) ) ) 
                { 
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 5) ) ) ) 
                { 
                } 
            
            } 
            
        }
        
    
    
    }
    
object UI_PAGE_OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1982;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1984;
        ROOM [ IROOM] . IUI_PAGE = (ushort) ( UI_PAGE[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1986;
        FUPDATEGUI (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IUI_PAGE ), (ushort)( ROOM[ IROOM ].IUI_SUB )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UI_SUB_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1992;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1994;
        ROOM [ IROOM] . IUI_SUB = (ushort) ( UI_SUB[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1996;
        FUPDATEGUI (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IUI_PAGE ), (ushort)( ROOM[ IROOM ].IUI_SUB )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_GLOBAL_RX__DOLLAR___1_OnChange_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        
        __context__.SourceCodeLine = 2010;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2012;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2013;
            FPROCESSDATA (  __context__ , (ushort)( 1 ), STEMP) ; 
            __context__.SourceCodeLine = 2010;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_GLOBAL_RX__DOLLAR___2_OnChange_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        
        __context__.SourceCodeLine = 2021;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2023;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2024;
            FPROCESSDATA (  __context__ , (ushort)( 2 ), STEMP) ; 
            __context__.SourceCodeLine = 2021;
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
    ushort L = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 2035;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2037;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2039;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)2; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( L  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (L  >= __FN_FORSTART_VAL__2) && (L  <= __FN_FOREND_VAL__2) ) : ( (L  <= __FN_FORSTART_VAL__2) && (L  >= __FN_FOREND_VAL__2) ) ; L  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 2041;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)6; 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 2043;
                    ROOM [ I] . LIST [ L] . ITEM [ J] . IISVIRTUAL = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 2041;
                    } 
                
                __context__.SourceCodeLine = 2039;
                } 
            
            __context__.SourceCodeLine = 2037;
            } 
        
        __context__.SourceCodeLine = 2048;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)2; 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 2050;
            ROOM [ I] . LIST [ 1] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2051;
            ROOM [ I] . LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2052;
            ROOM [ I] . LIST [ 1] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2053;
            ROOM [ I] . LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2054;
            ROOM [ I] . LIST [ 1] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2055;
            ROOM [ I] . LIST [ 1] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2057;
            ROOM [ I] . LIST [ 2] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2058;
            ROOM [ I] . LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 2059;
            ROOM [ I] . LIST [ 2] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2060;
            ROOM [ I] . LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2061;
            ROOM [ I] . LIST [ 2] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2062;
            ROOM [ I] . LIST [ 2] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2064;
            ROOM [ I] . LIST [ 3] . IMAXNUMITEMS = (ushort) ( 24 ) ; 
            __context__.SourceCodeLine = 2065;
            ROOM [ I] . LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2066;
            ROOM [ I] . LIST [ 3] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2067;
            ROOM [ I] . LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2068;
            ROOM [ I] . LIST [ 3] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2069;
            ROOM [ I] . LIST [ 3] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2071;
            ROOM [ I] . LIST [ 4] . IMAXNUMITEMS = (ushort) ( 15 ) ; 
            __context__.SourceCodeLine = 2072;
            ROOM [ I] . LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2073;
            ROOM [ I] . LIST [ 4] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2074;
            ROOM [ I] . LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2075;
            ROOM [ I] . LIST [ 4] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2076;
            ROOM [ I] . LIST [ 4] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2078;
            ROOM [ I] . LIST [ 5] . IMAXNUMITEMS = (ushort) ( 9 ) ; 
            __context__.SourceCodeLine = 2079;
            ROOM [ I] . LIST [ 5] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2080;
            ROOM [ I] . LIST [ 5] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2081;
            ROOM [ I] . LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2082;
            ROOM [ I] . LIST [ 5] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2083;
            ROOM [ I] . LIST [ 5] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2085;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)9; 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                { 
                __context__.SourceCodeLine = 2087;
                ROOM [ I] . LIST [ 5] . ITEM [ J] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2088;
                ROOM [ I] . LIST [ 5] . ITEM [ (J + 20)] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2085;
                } 
            
            __context__.SourceCodeLine = 2048;
            } 
        
        __context__.SourceCodeLine = 2092;
        SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2093;
        SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
        __context__.SourceCodeLine = 2094;
        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__6 = (ushort)2; 
        int __FN_FORSTEP_VAL__6 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
            { 
            __context__.SourceCodeLine = 2096;
            PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2097;
            RC_OFF_FB [ I]  .Value = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
            __context__.SourceCodeLine = 2098;
            RC_ON_FB [ I]  .Value = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
            __context__.SourceCodeLine = 2094;
            } 
        
        __context__.SourceCodeLine = 2100;
        FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    SYS  = new STSYS( this, true );
    SYS .PopulateCustomAttributeList( false );
    ROOM  = new STROOM[ 3 ];
    for( uint i = 0; i < 3; i++ )
    {
        ROOM [i] = new STROOM( this, true );
        ROOM [i].PopulateCustomAttributeList( false );
        
    }
    
    RC_ON = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RC_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RC_ON__DigitalInput__ + i, RC_ON__DigitalInput__, this );
        m_DigitalInputList.Add( RC_ON__DigitalInput__ + i, RC_ON[i+1] );
    }
    
    RC_OFF = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RC_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RC_OFF__DigitalInput__ + i, RC_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( RC_OFF__DigitalInput__ + i, RC_OFF[i+1] );
    }
    
    RC_TOG = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RC_TOG[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RC_TOG__DigitalInput__ + i, RC_TOG__DigitalInput__, this );
        m_DigitalInputList.Add( RC_TOG__DigitalInput__ + i, RC_TOG[i+1] );
    }
    
    PARTSENSESIGNAL = new InOutArray<DigitalInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        PARTSENSESIGNAL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PARTSENSESIGNAL__DigitalInput__ + i, PARTSENSESIGNAL__DigitalInput__, this );
        m_DigitalInputList.Add( PARTSENSESIGNAL__DigitalInput__ + i, PARTSENSESIGNAL[i+1] );
    }
    
    PARTSENSE_ENABLE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PARTSENSE_ENABLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PARTSENSE_ENABLE__DigitalInput__ + i, PARTSENSE_ENABLE__DigitalInput__, this );
        m_DigitalInputList.Add( PARTSENSE_ENABLE__DigitalInput__ + i, PARTSENSE_ENABLE[i+1] );
    }
    
    PARTSENSE_DISABLE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PARTSENSE_DISABLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PARTSENSE_DISABLE__DigitalInput__ + i, PARTSENSE_DISABLE__DigitalInput__, this );
        m_DigitalInputList.Add( PARTSENSE_DISABLE__DigitalInput__ + i, PARTSENSE_DISABLE[i+1] );
    }
    
    SYS_POWERON = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SYS_POWERON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SYS_POWERON__DigitalInput__ + i, SYS_POWERON__DigitalInput__, this );
        m_DigitalInputList.Add( SYS_POWERON__DigitalInput__ + i, SYS_POWERON[i+1] );
    }
    
    SYS_POWEROFF = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SYS_POWEROFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SYS_POWEROFF__DigitalInput__ + i, SYS_POWEROFF__DigitalInput__, this );
        m_DigitalInputList.Add( SYS_POWEROFF__DigitalInput__ + i, SYS_POWEROFF[i+1] );
    }
    
    MTRX_TAKE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_TAKE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_TAKE__DigitalInput__ + i, MTRX_TAKE__DigitalInput__, this );
        m_DigitalInputList.Add( MTRX_TAKE__DigitalInput__ + i, MTRX_TAKE[i+1] );
    }
    
    MTRX_CLEAR = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_CLEAR[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_CLEAR__DigitalInput__ + i, MTRX_CLEAR__DigitalInput__, this );
        m_DigitalInputList.Add( MTRX_CLEAR__DigitalInput__ + i, MTRX_CLEAR[i+1] );
    }
    
    MTRX_SELALL = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_SELALL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MTRX_SELALL__DigitalInput__ + i, MTRX_SELALL__DigitalInput__, this );
        m_DigitalInputList.Add( MTRX_SELALL__DigitalInput__ + i, MTRX_SELALL[i+1] );
    }
    
    CAM_TILT_UP = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_TILT_UP[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_TILT_UP__DigitalInput__ + i, CAM_TILT_UP__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_TILT_UP__DigitalInput__ + i, CAM_TILT_UP[i+1] );
    }
    
    CAM_TILT_DN = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_TILT_DN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_TILT_DN__DigitalInput__ + i, CAM_TILT_DN__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_TILT_DN__DigitalInput__ + i, CAM_TILT_DN[i+1] );
    }
    
    CAM_PAN_LEFT = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_PAN_LEFT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_PAN_LEFT__DigitalInput__ + i, CAM_PAN_LEFT__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_PAN_LEFT__DigitalInput__ + i, CAM_PAN_LEFT[i+1] );
    }
    
    CAM_PAN_RIGHT = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_PAN_RIGHT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_PAN_RIGHT__DigitalInput__ + i, CAM_PAN_RIGHT__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_PAN_RIGHT__DigitalInput__ + i, CAM_PAN_RIGHT[i+1] );
    }
    
    CAM_ZOOM_TIGHT = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_ZOOM_TIGHT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_ZOOM_TIGHT__DigitalInput__ + i, CAM_ZOOM_TIGHT__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_ZOOM_TIGHT__DigitalInput__ + i, CAM_ZOOM_TIGHT[i+1] );
    }
    
    CAM_ZOOM_WIDE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_ZOOM_WIDE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_ZOOM_WIDE__DigitalInput__ + i, CAM_ZOOM_WIDE__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_ZOOM_WIDE__DigitalInput__ + i, CAM_ZOOM_WIDE[i+1] );
    }
    
    CAM_FOCUS_NEAR = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_FOCUS_NEAR[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_FOCUS_NEAR__DigitalInput__ + i, CAM_FOCUS_NEAR__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_FOCUS_NEAR__DigitalInput__ + i, CAM_FOCUS_NEAR[i+1] );
    }
    
    CAM_FOCUS_FAR = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_FOCUS_FAR[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_FOCUS_FAR__DigitalInput__ + i, CAM_FOCUS_FAR__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_FOCUS_FAR__DigitalInput__ + i, CAM_FOCUS_FAR[i+1] );
    }
    
    CAM_POWER_ON = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_POWER_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_POWER_ON__DigitalInput__ + i, CAM_POWER_ON__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_POWER_ON__DigitalInput__ + i, CAM_POWER_ON[i+1] );
    }
    
    CAM_POWER_OFF = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_POWER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_POWER_OFF__DigitalInput__ + i, CAM_POWER_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_POWER_OFF__DigitalInput__ + i, CAM_POWER_OFF[i+1] );
    }
    
    CAM_POWER_TOG = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_POWER_TOG[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CAM_POWER_TOG__DigitalInput__ + i, CAM_POWER_TOG__DigitalInput__, this );
        m_DigitalInputList.Add( CAM_POWER_TOG__DigitalInput__ + i, CAM_POWER_TOG[i+1] );
    }
    
    RC_ON_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RC_ON_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( RC_ON_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( RC_ON_FB__DigitalOutput__ + i, RC_ON_FB[i+1] );
    }
    
    RC_OFF_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        RC_OFF_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( RC_OFF_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( RC_OFF_FB__DigitalOutput__ + i, RC_OFF_FB[i+1] );
    }
    
    PARTSENSE_ENABLE_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PARTSENSE_ENABLE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PARTSENSE_ENABLE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PARTSENSE_ENABLE_FB__DigitalOutput__ + i, PARTSENSE_ENABLE_FB[i+1] );
    }
    
    PARTSENSE_DISABLE_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PARTSENSE_DISABLE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PARTSENSE_DISABLE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PARTSENSE_DISABLE_FB__DigitalOutput__ + i, PARTSENSE_DISABLE_FB[i+1] );
    }
    
    SYS_POWERON_GO = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SYS_POWERON_GO[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SYS_POWERON_GO__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SYS_POWERON_GO__DigitalOutput__ + i, SYS_POWERON_GO[i+1] );
    }
    
    SYS_POWEROFF_GO = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SYS_POWEROFF_GO[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SYS_POWEROFF_GO__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SYS_POWEROFF_GO__DigitalOutput__ + i, SYS_POWEROFF_GO[i+1] );
    }
    
    CAM_POWER_ON_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_POWER_ON_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( CAM_POWER_ON_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( CAM_POWER_ON_FB__DigitalOutput__ + i, CAM_POWER_ON_FB[i+1] );
    }
    
    CAM_POWER_OFF_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_POWER_OFF_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( CAM_POWER_OFF_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( CAM_POWER_OFF_FB__DigitalOutput__ + i, CAM_POWER_OFF_FB[i+1] );
    }
    
    SYS_PRESET = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SYS_PRESET[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( SYS_PRESET__AnalogSerialInput__ + i, SYS_PRESET__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SYS_PRESET__AnalogSerialInput__ + i, SYS_PRESET[i+1] );
    }
    
    UI_PAGE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        UI_PAGE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( UI_PAGE__AnalogSerialInput__ + i, UI_PAGE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( UI_PAGE__AnalogSerialInput__ + i, UI_PAGE[i+1] );
    }
    
    UI_SUB = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        UI_SUB[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( UI_SUB__AnalogSerialInput__ + i, UI_SUB__AnalogSerialInput__, this );
        m_AnalogInputList.Add( UI_SUB__AnalogSerialInput__ + i, UI_SUB[i+1] );
    }
    
    CAM_SELECT = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_SELECT[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CAM_SELECT__AnalogSerialInput__ + i, CAM_SELECT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CAM_SELECT__AnalogSerialInput__ + i, CAM_SELECT[i+1] );
    }
    
    CAM_PRESET_RECALL = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_PRESET_RECALL[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CAM_PRESET_RECALL__AnalogSerialInput__ + i, CAM_PRESET_RECALL__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CAM_PRESET_RECALL__AnalogSerialInput__ + i, CAM_PRESET_RECALL[i+1] );
    }
    
    MTRX_MACRO1_SRC = new InOutArray<AnalogInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        MTRX_MACRO1_SRC[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_MACRO1_SRC__AnalogSerialInput__ + i, MTRX_MACRO1_SRC__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_MACRO1_SRC__AnalogSerialInput__ + i, MTRX_MACRO1_SRC[i+1] );
    }
    
    MTRX_MACRO2_SRC = new InOutArray<AnalogInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        MTRX_MACRO2_SRC[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_MACRO2_SRC__AnalogSerialInput__ + i, MTRX_MACRO2_SRC__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_MACRO2_SRC__AnalogSerialInput__ + i, MTRX_MACRO2_SRC[i+1] );
    }
    
    MTRX_MACRO1_DST = new InOutArray<AnalogInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        MTRX_MACRO1_DST[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_MACRO1_DST__AnalogSerialInput__ + i, MTRX_MACRO1_DST__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_MACRO1_DST__AnalogSerialInput__ + i, MTRX_MACRO1_DST[i+1] );
    }
    
    MTRX_MACRO2_DST = new InOutArray<AnalogInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        MTRX_MACRO2_DST[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_MACRO2_DST__AnalogSerialInput__ + i, MTRX_MACRO2_DST__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_MACRO2_DST__AnalogSerialInput__ + i, MTRX_MACRO2_DST[i+1] );
    }
    
    MTRX_ADMINVSRC_CLICKED = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVSRC_CLICKED[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_ADMINVSRC_CLICKED__AnalogSerialInput__ + i, MTRX_ADMINVSRC_CLICKED__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_ADMINVSRC_CLICKED__AnalogSerialInput__ + i, MTRX_ADMINVSRC_CLICKED[i+1] );
    }
    
    MTRX_ADMINVDST_CLICKED = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVDST_CLICKED[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MTRX_ADMINVDST_CLICKED__AnalogSerialInput__ + i, MTRX_ADMINVDST_CLICKED__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MTRX_ADMINVDST_CLICKED__AnalogSerialInput__ + i, MTRX_ADMINVDST_CLICKED[i+1] );
    }
    
    DSP_PGM_RTE = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DSP_PGM_RTE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSP_PGM_RTE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSP_PGM_RTE__AnalogSerialOutput__ + i, DSP_PGM_RTE[i+1] );
    }
    
    MTRX_MACRO1_SRC_FB = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        MTRX_MACRO1_SRC_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_MACRO1_SRC_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_MACRO1_SRC_FB__AnalogSerialOutput__ + i, MTRX_MACRO1_SRC_FB[i+1] );
    }
    
    MTRX_MACRO2_SRC_FB = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        MTRX_MACRO2_SRC_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_MACRO2_SRC_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_MACRO2_SRC_FB__AnalogSerialOutput__ + i, MTRX_MACRO2_SRC_FB[i+1] );
    }
    
    MTRX_ADMINVSRC_NUMOFITEMS = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVSRC_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_ADMINVSRC_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_ADMINVSRC_NUMOFITEMS__AnalogSerialOutput__ + i, MTRX_ADMINVSRC_NUMOFITEMS[i+1] );
    }
    
    MTRX_ADMINVDST_NUMOFITEMS = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVDST_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_ADMINVDST_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_ADMINVDST_NUMOFITEMS__AnalogSerialOutput__ + i, MTRX_ADMINVDST_NUMOFITEMS[i+1] );
    }
    
    DSP_MICS_NUMOFITEMS = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DSP_MICS_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSP_MICS_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSP_MICS_NUMOFITEMS__AnalogSerialOutput__ + i, DSP_MICS_NUMOFITEMS[i+1] );
    }
    
    DSP_LINE_NUMOFITEMS = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DSP_LINE_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSP_LINE_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSP_LINE_NUMOFITEMS__AnalogSerialOutput__ + i, DSP_LINE_NUMOFITEMS[i+1] );
    }
    
    TO_MST_TX__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        TO_MST_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_MST_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_MST_TX__DOLLAR____AnalogSerialOutput__ + i, TO_MST_TX__DOLLAR__[i+1] );
    }
    
    TO_DSP_TX__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        TO_DSP_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_DSP_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_DSP_TX__DOLLAR____AnalogSerialOutput__ + i, TO_DSP_TX__DOLLAR__[i+1] );
    }
    
    MTRX_ADMINVSRC_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVSRC_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MTRX_ADMINVSRC_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MTRX_ADMINVSRC_FB__DOLLAR____AnalogSerialOutput__ + i, MTRX_ADMINVSRC_FB__DOLLAR__[i+1] );
    }
    
    MTRX_ADMINVDST_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_ADMINVDST_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MTRX_ADMINVDST_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MTRX_ADMINVDST_FB__DOLLAR____AnalogSerialOutput__ + i, MTRX_ADMINVDST_FB__DOLLAR__[i+1] );
    }
    
    DSP_MICS_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DSP_MICS_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSP_MICS_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSP_MICS_FB__DOLLAR____AnalogSerialOutput__ + i, DSP_MICS_FB__DOLLAR__[i+1] );
    }
    
    DSP_LINE_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DSP_LINE_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSP_LINE_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSP_LINE_FB__DOLLAR____AnalogSerialOutput__ + i, DSP_LINE_FB__DOLLAR__[i+1] );
    }
    
    CAM_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CAM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CAM_FB__DOLLAR____AnalogSerialOutput__ + i, CAM_FB__DOLLAR__[i+1] );
    }
    
    CAM_PRESETS_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CAM_PRESETS_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CAM_PRESETS_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CAM_PRESETS_FB__DOLLAR____AnalogSerialOutput__ + i, CAM_PRESETS_FB__DOLLAR__[i+1] );
    }
    
    DISPLAY_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DISPLAY_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DISPLAY_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DISPLAY_FB__DOLLAR____AnalogSerialOutput__ + i, DISPLAY_FB__DOLLAR__[i+1] );
    }
    
    MTRX_MACRO_SRC_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_MACRO_SRC_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MTRX_MACRO_SRC_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MTRX_MACRO_SRC_FB__DOLLAR____AnalogSerialOutput__ + i, MTRX_MACRO_SRC_FB__DOLLAR__[i+1] );
    }
    
    MTRX_MACRO_DST_FB__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_MACRO_DST_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MTRX_MACRO_DST_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MTRX_MACRO_DST_FB__DOLLAR____AnalogSerialOutput__ + i, MTRX_MACRO_DST_FB__DOLLAR__[i+1] );
    }
    
    ROOMNAME__DOLLAR___OUT = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        ROOMNAME__DOLLAR___OUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ROOMNAME__DOLLAR___OUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( ROOMNAME__DOLLAR___OUT__AnalogSerialOutput__ + i, ROOMNAME__DOLLAR___OUT[i+1] );
    }
    
    FROM_GLOBAL_RX__DOLLAR___1 = new InOutArray<BufferInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        FROM_GLOBAL_RX__DOLLAR___1[i+1] = new Crestron.Logos.SplusObjects.BufferInput( FROM_GLOBAL_RX__DOLLAR___1__AnalogSerialInput__ + i, FROM_GLOBAL_RX__DOLLAR___1__AnalogSerialInput__, 5000, this );
        m_StringInputList.Add( FROM_GLOBAL_RX__DOLLAR___1__AnalogSerialInput__ + i, FROM_GLOBAL_RX__DOLLAR___1[i+1] );
    }
    
    FROM_GLOBAL_RX__DOLLAR___2 = new InOutArray<BufferInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        FROM_GLOBAL_RX__DOLLAR___2[i+1] = new Crestron.Logos.SplusObjects.BufferInput( FROM_GLOBAL_RX__DOLLAR___2__AnalogSerialInput__ + i, FROM_GLOBAL_RX__DOLLAR___2__AnalogSerialInput__, 5000, this );
        m_StringInputList.Add( FROM_GLOBAL_RX__DOLLAR___2__AnalogSerialInput__ + i, FROM_GLOBAL_RX__DOLLAR___2[i+1] );
    }
    
    
    for( uint i = 0; i < 2; i++ )
        RC_ON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RC_ON_OnPush_0, false ) );
        
    for( uint i = 0; i < 2; i++ )
        RC_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RC_OFF_OnPush_1, false ) );
        
    for( uint i = 0; i < 2; i++ )
        RC_TOG[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RC_TOG_OnPush_2, false ) );
        
    for( uint i = 0; i < 1; i++ )
        PARTSENSESIGNAL[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( PARTSENSESIGNAL_OnChange_3, false ) );
        
    for( uint i = 0; i < 2; i++ )
        PARTSENSE_ENABLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PARTSENSE_ENABLE_OnPush_4, false ) );
        
    for( uint i = 0; i < 2; i++ )
        PARTSENSE_DISABLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PARTSENSE_DISABLE_OnPush_5, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SYS_POWERON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SYS_POWERON_OnPush_6, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SYS_POWEROFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SYS_POWEROFF_OnPush_7, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SYS_PRESET[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( SYS_PRESET_OnChange_8, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MTRX_TAKE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_TAKE_OnPush_9, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MTRX_CLEAR[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_CLEAR_OnPush_10, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MTRX_SELALL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MTRX_SELALL_OnPush_11, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MTRX_ADMINVSRC_CLICKED[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_ADMINVSRC_CLICKED_OnChange_12, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MTRX_ADMINVDST_CLICKED[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_ADMINVDST_CLICKED_OnChange_13, false ) );
        
    for( uint i = 0; i < 5; i++ )
        MTRX_MACRO1_SRC[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_MACRO1_SRC_OnChange_14, false ) );
        
    for( uint i = 0; i < 5; i++ )
        MTRX_MACRO2_SRC[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_MACRO2_SRC_OnChange_15, false ) );
        
    for( uint i = 0; i < 1; i++ )
        MTRX_MACRO1_DST[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_MACRO1_DST_OnChange_16, false ) );
        
    for( uint i = 0; i < 1; i++ )
        MTRX_MACRO2_DST[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MTRX_MACRO2_DST_OnChange_17, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_TILT_UP[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnPush_18, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_TILT_DN[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_TILT_DN_OnPush_19, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_PAN_LEFT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_PAN_LEFT_OnPush_20, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_PAN_RIGHT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_PAN_RIGHT_OnPush_21, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_ZOOM_TIGHT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_ZOOM_TIGHT_OnPush_22, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_ZOOM_WIDE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_ZOOM_WIDE_OnPush_23, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_POWER_ON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_POWER_ON_OnPush_24, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_POWER_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CAM_POWER_OFF_OnPush_25, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_TILT_UP[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_TILT_DN[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_PAN_LEFT[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_PAN_RIGHT[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_FOCUS_NEAR[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_FOCUS_FAR[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_TILT_UP_OnRelease_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_ZOOM_TIGHT[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_ZOOM_TIGHT_OnRelease_27, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_ZOOM_WIDE[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( CAM_ZOOM_TIGHT_OnRelease_27, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CAM_SELECT[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( CAM_SELECT_OnChange_28, false ) );
        
    for( uint i = 0; i < 2; i++ )
        UI_PAGE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( UI_PAGE_OnChange_29, false ) );
        
    for( uint i = 0; i < 2; i++ )
        UI_SUB[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( UI_SUB_OnChange_30, false ) );
        
    for( uint i = 0; i < 1; i++ )
        FROM_GLOBAL_RX__DOLLAR___1[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_GLOBAL_RX__DOLLAR___1_OnChange_31, true ) );
        
    for( uint i = 0; i < 1; i++ )
        FROM_GLOBAL_RX__DOLLAR___2[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_GLOBAL_RX__DOLLAR___2_OnChange_32, true ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ST  = new L3_Tools.StringTools();
    
    
}

public UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_80 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RC_ON__DigitalInput__ = 0;
const uint RC_OFF__DigitalInput__ = 2;
const uint RC_TOG__DigitalInput__ = 4;
const uint PARTSENSESIGNAL__DigitalInput__ = 6;
const uint PARTSENSE_ENABLE__DigitalInput__ = 7;
const uint PARTSENSE_DISABLE__DigitalInput__ = 9;
const uint SYS_POWERON__DigitalInput__ = 11;
const uint SYS_POWEROFF__DigitalInput__ = 13;
const uint MTRX_TAKE__DigitalInput__ = 15;
const uint MTRX_CLEAR__DigitalInput__ = 17;
const uint MTRX_SELALL__DigitalInput__ = 19;
const uint CAM_TILT_UP__DigitalInput__ = 21;
const uint CAM_TILT_DN__DigitalInput__ = 23;
const uint CAM_PAN_LEFT__DigitalInput__ = 25;
const uint CAM_PAN_RIGHT__DigitalInput__ = 27;
const uint CAM_ZOOM_TIGHT__DigitalInput__ = 29;
const uint CAM_ZOOM_WIDE__DigitalInput__ = 31;
const uint CAM_FOCUS_NEAR__DigitalInput__ = 33;
const uint CAM_FOCUS_FAR__DigitalInput__ = 35;
const uint CAM_POWER_ON__DigitalInput__ = 37;
const uint CAM_POWER_OFF__DigitalInput__ = 39;
const uint CAM_POWER_TOG__DigitalInput__ = 41;
const uint SYS_PRESET__AnalogSerialInput__ = 0;
const uint UI_PAGE__AnalogSerialInput__ = 2;
const uint UI_SUB__AnalogSerialInput__ = 4;
const uint CAM_SELECT__AnalogSerialInput__ = 6;
const uint CAM_PRESET_RECALL__AnalogSerialInput__ = 8;
const uint MTRX_MACRO1_SRC__AnalogSerialInput__ = 10;
const uint MTRX_MACRO2_SRC__AnalogSerialInput__ = 15;
const uint MTRX_MACRO1_DST__AnalogSerialInput__ = 20;
const uint MTRX_MACRO2_DST__AnalogSerialInput__ = 21;
const uint MTRX_ADMINVSRC_CLICKED__AnalogSerialInput__ = 22;
const uint MTRX_ADMINVDST_CLICKED__AnalogSerialInput__ = 24;
const uint FROM_GLOBAL_RX__DOLLAR___1__AnalogSerialInput__ = 26;
const uint FROM_GLOBAL_RX__DOLLAR___2__AnalogSerialInput__ = 27;
const uint RC_ON_FB__DigitalOutput__ = 0;
const uint RC_OFF_FB__DigitalOutput__ = 2;
const uint PARTSENSE_ENABLE_FB__DigitalOutput__ = 4;
const uint PARTSENSE_DISABLE_FB__DigitalOutput__ = 6;
const uint SYS_POWERON_GO__DigitalOutput__ = 8;
const uint SYS_POWEROFF_GO__DigitalOutput__ = 10;
const uint CAM_POWER_ON_FB__DigitalOutput__ = 12;
const uint CAM_POWER_OFF_FB__DigitalOutput__ = 14;
const uint DSP_PGM_RTE__AnalogSerialOutput__ = 0;
const uint MTRX_MACRO1_SRC_FB__AnalogSerialOutput__ = 2;
const uint MTRX_MACRO2_SRC_FB__AnalogSerialOutput__ = 7;
const uint MTRX_ADMINVSRC_NUMOFITEMS__AnalogSerialOutput__ = 12;
const uint MTRX_ADMINVDST_NUMOFITEMS__AnalogSerialOutput__ = 14;
const uint DSP_MICS_NUMOFITEMS__AnalogSerialOutput__ = 16;
const uint DSP_LINE_NUMOFITEMS__AnalogSerialOutput__ = 18;
const uint TO_MST_TX__DOLLAR____AnalogSerialOutput__ = 20;
const uint TO_DSP_TX__DOLLAR____AnalogSerialOutput__ = 22;
const uint MTRX_ADMINVSRC_FB__DOLLAR____AnalogSerialOutput__ = 24;
const uint MTRX_ADMINVDST_FB__DOLLAR____AnalogSerialOutput__ = 26;
const uint DSP_MICS_FB__DOLLAR____AnalogSerialOutput__ = 28;
const uint DSP_LINE_FB__DOLLAR____AnalogSerialOutput__ = 30;
const uint CAM_FB__DOLLAR____AnalogSerialOutput__ = 32;
const uint CAM_PRESETS_FB__DOLLAR____AnalogSerialOutput__ = 34;
const uint DISPLAY_FB__DOLLAR____AnalogSerialOutput__ = 36;
const uint MTRX_MACRO_SRC_FB__DOLLAR____AnalogSerialOutput__ = 38;
const uint MTRX_MACRO_DST_FB__DOLLAR____AnalogSerialOutput__ = 40;
const uint ROOMNAME__DOLLAR___OUT__AnalogSerialOutput__ = 42;

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
    public ushort  IRMASS = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IGUID = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IFUNCTIONID = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IFILTERID = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  IISVIRTUAL = 0;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  IVLINK = 0;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IISRCITEM = 0;
    
    [SplusStructAttribute(14, false, false)]
    public ushort  IROUTEDSRC = 0;
    
    [SplusStructAttribute(15, false, false)]
    public CrestronString  SROUTEDSRC;
    
    [SplusStructAttribute(16, false, false)]
    public ushort  ILASTROUTEREQ = 0;
    
    [SplusStructAttribute(17, false, false)]
    public ushort  IMUTESTATE = 0;
    
    [SplusStructAttribute(18, false, false)]
    public ushort  IVOLSTATE = 0;
    
    [SplusStructAttribute(19, false, false)]
    public ushort  IISCAMERA = 0;
    
    [SplusStructAttribute(20, false, false)]
    public ushort  IISDISPLAY = 0;
    
    [SplusStructAttribute(21, false, false)]
    public ushort  ICAMLOCALID = 0;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  ICAMGUID = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IDISPLAYLOCALID = 0;
    
    [SplusStructAttribute(24, false, false)]
    public ushort  IDISPLAYGUID = 0;
    
    [SplusStructAttribute(25, false, false)]
    public ushort  ISYSPRESET = 0;
    
    [SplusStructAttribute(26, false, false)]
    public ushort  IISUSB = 0;
    
    [SplusStructAttribute(27, false, false)]
    public ushort  IISAUDIODST = 0;
    
    [SplusStructAttribute(28, false, false)]
    public ushort  IPGMAUDIO = 0;
    
    
    public STLISTITEM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SROUTEDSRC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        STEXT  = new CrestronString[ 5 ];
        for( uint i = 0; i < 5; i++ )
            STEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STLIST : SplusStructureBase
{

    public STLISTITEM [] ITEM;
    
    [SplusStructAttribute(0, false, false)]
    public ushort  IMAXNUMITEMS = 0;
    
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
    public ushort  IITEMSELECTED = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  INUMOFITEMSSELECTED = 0;
    
    
    public STLIST( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IGLOBALTOLOCAL  = new ushort[ 401 ];
        ITEM  = new STLISTITEM[ 51 ];
        for( uint i = 0; i < 51; i++ )
        {
            ITEM [i] = new STLISTITEM( Owner, true );
            
        }
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STMACRO : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  SNAME;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ISTATE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  INUMOFDST = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  [] IDSTLIST;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IPRIMARYDST = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IVIS = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  IFB = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IUSB = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  ICAMDST = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IPGMAUDIO = 0;
    
    
    public STMACRO( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IDSTLIST  = new ushort[ 21 ];
        SNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STPRESET : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IPRESETACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SPRESETNAME;
    
    
    public STPRESET( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SPRESETNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STCAM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  ICAMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SGLOBALNAME;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SLOCALNAME;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  ISYSPRESET = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IFB = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IVIS = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  ICAMGUID = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IVSRCLOCALID = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IVSRCGUID = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  ICAMPOWERSTATE = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  ICAMPRESETSTATE = 0;
    
    public STPRESET [] PRESET;
    
    
    public STCAM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        PRESET  = new STPRESET[ 17 ];
        for( uint i = 0; i < 17; i++ )
        {
            PRESET [i] = new STPRESET( Owner, true );
            
        }
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STDISPLAY : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IDISPLAYACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SGLOBALNAME;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SLOCALNAME;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  ISYSPRESET = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IFB = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IVIS = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  IDISPLAYGUID = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IVDSTLOCALID = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IVDSTGUID = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IDISPLAYPOWERSTATE = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IDISPLAYINPUTSTATE = 0;
    
    
    public STDISPLAY( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STROOM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IROOMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IROOMGUID = 0;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SROOMNAME;
    
    [SplusStructAttribute(3, false, false)]
    public CrestronString  SROOMNAMESHORT;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IBLDGROOMNUM = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IDISCRETEMACROMODE = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  IMACROTAKEMODE = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IUSESRCLISTMODE = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  ICAMSEL = 0;
    
    public STCAM [] CAM;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IDISPLAYSEL = 0;
    
    public STDISPLAY [] DISPLAY;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  ISYSPOWERSTATE = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  IVTCALLOCATION = 0;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  IOTHERROOMACTIVE = 0;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IOTHERROOMGUID = 0;
    
    public STLIST [] LIST;
    
    public STMACRO [] MACRO;
    
    [SplusStructAttribute(14, false, false)]
    public ushort  ILASTMACROSEL = 0;
    
    [SplusStructAttribute(15, false, false)]
    public ushort  IUI_PAGE = 0;
    
    [SplusStructAttribute(16, false, false)]
    public ushort  IUI_SUB = 0;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SROOMNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        SROOMNAMESHORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        CAM  = new STCAM[ 11 ];
        for( uint i = 0; i < 11; i++ )
        {
            CAM [i] = new STCAM( Owner, true );
            
        }
        DISPLAY  = new STDISPLAY[ 41 ];
        for( uint i = 0; i < 41; i++ )
        {
            DISPLAY [i] = new STDISPLAY( Owner, true );
            
        }
        LIST  = new STLIST[ 6 ];
        for( uint i = 0; i < 6; i++ )
        {
            LIST [i] = new STLIST( Owner, true );
            
        }
        MACRO  = new STMACRO[ 21 ];
        for( uint i = 0; i < 21; i++ )
        {
            MACRO [i] = new STMACRO( Owner, true );
            
        }
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STSYS : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IRCSTATE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IPARTITIONSTATE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  IPARTITIONENABLED = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IISRCPAIR = 0;
    
    
    public STSYS( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
