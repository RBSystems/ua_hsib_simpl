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

namespace UserModule_L3_UA_HSIB_NODEMST_V1_0_81
{
    public class UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_81 : SplusObject
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
        private ushort FGETMACROTYPE (  SplusExecutionContext __context__, ushort IMACRO ) 
            { 
            
            __context__.SourceCodeLine = 370;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMACRO >= 01 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IMACRO <= 25 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 370;
                return (ushort)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 371;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 26))  ) ) 
                    {
                    __context__.SourceCodeLine = 371;
                    return (ushort)( 2) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 372;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 27))  ) ) 
                        {
                        __context__.SourceCodeLine = 372;
                        return (ushort)( 3) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 373;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMACRO >= 28 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IMACRO <= 30 ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 373;
                            return (ushort)( 4) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 374;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMACRO >= 31 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IMACRO <= 40 ) )) ))  ) ) 
                                {
                                __context__.SourceCodeLine = 374;
                                return (ushort)( 5) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 375;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMACRO >= 41 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IMACRO <= 56 ) )) ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 375;
                                    return (ushort)( 6) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 376;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 57))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 376;
                                        return (ushort)( 7) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 377;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 58))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 377;
                                            return (ushort)( 8) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 378;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 59))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 378;
                                                return (ushort)( 9) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 379;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 60))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 379;
                                                    return (ushort)( 10) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 380;
                                                    Trace( "NodeMST - fGetMacroType - didn't catch iMacro index. iMacro={0:d}", (ushort)IMACRO) ; 
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
            
        private ushort FGETNUMITEMSSELECTED (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort I = 0;
            ushort ICOUNT = 0;
            
            
            __context__.SourceCodeLine = 387;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 389;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 389;
                    ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 387;
                } 
            
            __context__.SourceCodeLine = 392;
            return (ushort)( ICOUNT) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 397;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private void FCOPYIO (  SplusExecutionContext __context__, ushort IFROMROOM , ushort IFROMINDEX , ushort ITOROOM , ushort ITOINDEX , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 403;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IITEMACTIVE = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IITEMACTIVE ) ; 
            __context__.SourceCodeLine = 404;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SGLOBALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 405;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SLOCALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 406;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IRMASS = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IRMASS ) ; 
            __context__.SourceCodeLine = 407;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IGUID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 408;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFUNCTIONID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFUNCTIONID ) ; 
            __context__.SourceCodeLine = 409;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFILTERID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFILTERID ) ; 
            __context__.SourceCodeLine = 410;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IISVIRTUAL = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IISVIRTUAL ) ; 
            __context__.SourceCodeLine = 411;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IVLINK = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IVLINK ) ; 
            __context__.SourceCodeLine = 413;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 417;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IROUTEDSRC = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IROUTEDSRC ) ; 
                        __context__.SourceCodeLine = 418;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SROUTEDSRC  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SROUTEDSRC  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 430;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 432;
                        MTRX_ADMINVSRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 433;
                        MTRX_ADMINVDST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 434;
                        DSP_MICS_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 435;
                        DSP_LINE_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 436;
                        MTRX_MACRO_SRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 437;
                        MTRX_MACRO_DST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTNUMOFITEMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 443;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 445;
                        MTRX_ADMINVSRC_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 446;
                        MTRX_ADMINVDST_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 447;
                        DSP_MICS_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 448;
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
            
            
            __context__.SourceCodeLine = 461;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESFB)  ) ) 
                { 
                __context__.SourceCodeLine = 463;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 464;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 466;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 470;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 472;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 472;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                            }
                        
                        __context__.SourceCodeLine = 470;
                        } 
                    
                    __context__.SourceCodeLine = 474;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 476;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 485;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 487;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 488;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 488;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 491;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 493;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 493;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                            }
                        
                        __context__.SourceCodeLine = 491;
                        } 
                    
                    __context__.SourceCodeLine = 495;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 497;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                __context__.SourceCodeLine = 498;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 498;
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
            
            
            __context__.SourceCodeLine = 508;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESICON)  ) ) 
                { 
                __context__.SourceCodeLine = 510;
                STEMP  .UpdateValue ( "{ListIconFB:"  ) ; 
                __context__.SourceCodeLine = 511;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 513;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 517;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 519;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 519;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                            }
                        
                        __context__.SourceCodeLine = 517;
                        } 
                    
                    __context__.SourceCodeLine = 521;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 523;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 532;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESTEXT)  ) ) 
                { 
                __context__.SourceCodeLine = 534;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 535;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 537;
                    STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                    __context__.SourceCodeLine = 538;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 540;
                        MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                        __context__.SourceCodeLine = 538;
                        } 
                    
                    __context__.SourceCodeLine = 542;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 546;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 548;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 550;
                            STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                            __context__.SourceCodeLine = 551;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                                { 
                                __context__.SourceCodeLine = 553;
                                MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                                __context__.SourceCodeLine = 551;
                                } 
                            
                            __context__.SourceCodeLine = 555;
                            STEMP  .UpdateValue ( STEMP + "|"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 557;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 850 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 559;
                            STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                            __context__.SourceCodeLine = 560;
                            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 561;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                                {
                                __context__.SourceCodeLine = 561;
                                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                                }
                            
                            __context__.SourceCodeLine = 562;
                            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 546;
                        } 
                    
                    __context__.SourceCodeLine = 565;
                    STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 567;
                if ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 569;
                    FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 570;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 570;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                        }
                    
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 578;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 579;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 580;
            FUPDATELISTICON (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 581;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FCONFIGURELISTVISPROCESS (  SplusExecutionContext __context__, ushort IROOM , ushort IFROMLIST , ushort ITOLIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 593;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                {
                __context__.SourceCodeLine = 593;
                ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 595;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                    {
                    __context__.SourceCodeLine = 595;
                    ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IVLINK ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 597;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        {
                        __context__.SourceCodeLine = 597;
                        ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 598;
                        ; 
                        }
                    
                    }
                
                }
            
            
            }
            
        private void FCONFIGURELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 604;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                {
                __context__.SourceCodeLine = 604;
                FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 605;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    {
                    __context__.SourceCodeLine = 605;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    __context__.SourceCodeLine = 605;
                    }
                
                }
            
            __context__.SourceCodeLine = 608;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 610;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    {
                    __context__.SourceCodeLine = 610;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 611;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        {
                        __context__.SourceCodeLine = 611;
                        FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                        __context__.SourceCodeLine = 611;
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 618;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                {
                __context__.SourceCodeLine = 618;
                MakeString ( STEMP , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                }
            
            __context__.SourceCodeLine = 619;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 621;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_4__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 625;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 627;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 632;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 633;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ] , "{0}", ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SROUTEDSRC ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 637;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS ))  ) ) 
                                {
                                __context__.SourceCodeLine = 638;
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
            
            
            __context__.SourceCodeLine = 648;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 650;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I != ISKIPINDEX))  ) ) 
                    {
                    __context__.SourceCodeLine = 650;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( IVAL ) ; 
                    }
                
                __context__.SourceCodeLine = 648;
                } 
            
            
            }
            
        private void FSETLISTMACROFB (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 659;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 663;
                        MTRX_MACRO1_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 664;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 666;
                            MTRX_MACRO1_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 667;
                            MTRX_MACRO1_SRC_FB [ 2]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 672;
                        MTRX_MACRO2_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 673;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 675;
                            MTRX_MACRO2_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 676;
                            MTRX_MACRO2_SRC_FB [ 2]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
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
            
            
            __context__.SourceCodeLine = 687;
            STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
            __context__.SourceCodeLine = 688;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 690;
                IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 691;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].ICAMSEL == I))  ) ) 
                    {
                    __context__.SourceCodeLine = 691;
                    IFB = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 693;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)IFB) ; 
                __context__.SourceCodeLine = 688;
                } 
            
            __context__.SourceCodeLine = 696;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 698;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUPDATECAMVIS (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 706;
            STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 707;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 709;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)ROOM[ IROOM ].CAM[ I ].IVIS) ; 
                __context__.SourceCodeLine = 707;
                } 
            
            __context__.SourceCodeLine = 712;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 713;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUSBTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 726;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{USB_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FMTRXTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 733;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{MTRX_V_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FUPDATECONFMONITORRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 744;
            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 49 ].IGUID ), (ushort)( ISRCGUID )) ; 
            
            }
            
        private short FMTRX_VRTE_CLEAR (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 759;
            if ( Functions.TestForTrue  ( ( IDSTINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 761;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDSTINDEX ].IGUID ), (ushort)( 0 )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 765;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 767;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IISRCITEM ) ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 769;
                        FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( 0 )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 765;
                    } 
                
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FUPDATEMACROSRCNONDISCRETE (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
            { 
            ushort IDST = 0;
            ushort ISRCISUSB = 0;
            ushort IVDSTLOCALID = 0;
            
            
            __context__.SourceCodeLine = 779;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 781;
                ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
                __context__.SourceCodeLine = 782;
                FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
                __context__.SourceCodeLine = 783;
                FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 787;
                Trace( "NodeMST - attempting to use a Macro Src set other than [1] while discrete_macro_mode is disabled") ; 
                } 
            
            
            }
            
        private void FUPDATEMACROSRCDISCRETE (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
            { 
            ushort IDST = 0;
            ushort ISRCISUSB = 0;
            ushort IVDSTLOCALID = 0;
            
            
            __context__.SourceCodeLine = 795;
            ROOM [ IROOM] . ILASTSRCSEL [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID ) ; 
            __context__.SourceCodeLine = 797;
            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
            __context__.SourceCodeLine = 798;
            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
            __context__.SourceCodeLine = 801;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IPGMAUDIO)  ) ) 
                { 
                __context__.SourceCodeLine = 803;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVSRCLOCALID < 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 805;
                    DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IPGMAUDIO ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 808;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVSRCLOCALID <= 9 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 810;
                        DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( 4 ) ; 
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 815;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 817;
                IVDSTLOCALID = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IDST ] ) ; 
                __context__.SourceCodeLine = 819;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID )) ; 
                __context__.SourceCodeLine = 824;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IUSB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 827;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IISRCITEM ) ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IISUSB )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 829;
                        FUSBTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID )) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 815;
                } 
            
            
            }
            
        private void FUPDATEMACRODST (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRODST ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 842;
            
                {
                int __SPLS_TMPVAR__SWTCH_6__ = ((int)ROOM[ IROOM ].IMACROTAKEMODE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 846;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ 1 ].ISTATE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 848;
                            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRODST ].INUMOFOBJECTS; 
                            int __FN_FORSTEP_VAL__1 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                { 
                                __context__.SourceCodeLine = 850;
                                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ IMACRODST ].ILIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ROOM[ IROOM ].MACRO[ 1 ].ISTATE ].IGUID )) ; 
                                __context__.SourceCodeLine = 848;
                                } 
                            
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 858;
                        ROOM [ IROOM] . MACRO [ IMACRODST] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].MACRO[ IMACRODST ].IFB ) ) ; 
                        __context__.SourceCodeLine = 859;
                        MakeString ( STEMP , "{{ListButtonFB;{0:d}={1:d},|", (ushort)IMACRODST, (ushort)ROOM[ IROOM ].MACRO[ IMACRODST ].IFB) ; 
                        __context__.SourceCodeLine = 860;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), STEMP) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATECAMRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ICAM ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 869;
            ROOM [ IROOM] . ILASTSRCSEL [ 3 , 2] = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
            __context__.SourceCodeLine = 871;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ 5 ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 873;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ 5 ].ILIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID )) ; 
                __context__.SourceCodeLine = 871;
                } 
            
            
            }
            
        private void FCONFIGURELISTTEXTRMNUMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort ISTATE ) 
            { 
            ushort IINDEX = 0;
            
            CrestronString STHISROOM;
            CrestronString SOTHERROOM;
            STHISROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            SOTHERROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 890;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 892;
                MakeString ( STHISROOM , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                __context__.SourceCodeLine = 893;
                MakeString ( SOTHERROOM , "{0} ", ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . SROOMNAMESHORT ) ; 
                } 
            
            __context__.SourceCodeLine = 896;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 898;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 900;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                        {
                        __context__.SourceCodeLine = 901;
                        MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", SOTHERROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 903;
                        MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STHISROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 896;
                } 
            
            
            }
            
        private void FUPDATERC (  SplusExecutionContext __context__, ushort ITYPE ) 
            { 
            ushort I = 0;
            ushort IROOM = 0;
            ushort ILIST = 0;
            ushort IINDEX = 0;
            ushort [] V;
            V  = new ushort[ 3 ];
            
            
            __context__.SourceCodeLine = 912;
            
                {
                int __SPLS_TMPVAR__SWTCH_7__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 917;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)2; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 919;
                            V [ IROOM] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 5 ].IVLINK ) ; 
                            __context__.SourceCodeLine = 917;
                            } 
                        
                        __context__.SourceCodeLine = 922;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ 2 ].IVTCALLOCATION ) && Functions.TestForTrue ( Functions.Not( ROOM[ 1 ].IVTCALLOCATION ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 924;
                            FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 925;
                            FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 6 ), (ushort)( 1 ), (ushort)( 6 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 927;
                            ROOM [ 1] . IVTCALLOCATION = (ushort) ( ROOM[ 2 ].IVTCALLOCATION ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 931;
                            FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 5 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 932;
                            FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 6 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 934;
                            ROOM [ 2] . IVTCALLOCATION = (ushort) ( ROOM[ 1 ].IVTCALLOCATION ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 938;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)2; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 940;
                            FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 941;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)6; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                                { 
                                __context__.SourceCodeLine = 943;
                                ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( ROOM[ IROOM ].CAM[ I ].ICAMACTIVE ) ; 
                                __context__.SourceCodeLine = 941;
                                } 
                            
                            __context__.SourceCodeLine = 945;
                            FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 938;
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 950;
                        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__4 = (ushort)2; 
                        int __FN_FORSTEP_VAL__4 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__4) && (IROOM  <= __FN_FOREND_VAL__4) ) : ( (IROOM  <= __FN_FORSTART_VAL__4) && (IROOM  >= __FN_FOREND_VAL__4) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__4) 
                            {
                            __context__.SourceCodeLine = 951;
                            ushort __FN_FORSTART_VAL__5 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__5 = (ushort)6; 
                            int __FN_FORSTEP_VAL__5 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                                {
                                __context__.SourceCodeLine = 951;
                                ROOM [ IROOM] . LIST [ 1] . ITEM [ I] . IVLINK = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 951;
                                }
                            
                            __context__.SourceCodeLine = 950;
                            }
                        
                        __context__.SourceCodeLine = 954;
                        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__6 = (ushort)2; 
                        int __FN_FORSTEP_VAL__6 = (int)1; 
                        for ( IROOM  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__6) && (IROOM  <= __FN_FOREND_VAL__6) ) : ( (IROOM  <= __FN_FORSTART_VAL__6) && (IROOM  >= __FN_FOREND_VAL__6) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__6) 
                            { 
                            __context__.SourceCodeLine = 956;
                            ROOM [ IROOM] . ICAMSEL = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 957;
                            FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 958;
                            ushort __FN_FORSTART_VAL__7 = (ushort) ( 4 ) ;
                            ushort __FN_FOREND_VAL__7 = (ushort)6; 
                            int __FN_FORSTEP_VAL__7 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                                {
                                __context__.SourceCodeLine = 958;
                                ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 958;
                                }
                            
                            __context__.SourceCodeLine = 959;
                            FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                            __context__.SourceCodeLine = 954;
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 964;
            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__8 = (ushort)2; 
            int __FN_FORSTEP_VAL__8 = (int)1; 
            for ( IROOM  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__8) && (IROOM  <= __FN_FOREND_VAL__8) ) : ( (IROOM  <= __FN_FORSTART_VAL__8) && (IROOM  >= __FN_FOREND_VAL__8) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__8) 
                { 
                __context__.SourceCodeLine = 966;
                ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__9 = (ushort)2; 
                int __FN_FORSTEP_VAL__9 = (int)1; 
                for ( ILIST  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__9) && (ILIST  <= __FN_FOREND_VAL__9) ) : ( (ILIST  <= __FN_FORSTART_VAL__9) && (ILIST  >= __FN_FOREND_VAL__9) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__9) 
                    { 
                    __context__.SourceCodeLine = 968;
                    ushort __FN_FORSTART_VAL__10 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__10 = (ushort)50; 
                    int __FN_FORSTEP_VAL__10 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__10; (__FN_FORSTEP_VAL__10 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__10) && (IINDEX  <= __FN_FOREND_VAL__10) ) : ( (IINDEX  <= __FN_FORSTART_VAL__10) && (IINDEX  >= __FN_FOREND_VAL__10) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__10) 
                        { 
                        __context__.SourceCodeLine = 970;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM ) || Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 972;
                            FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                            __context__.SourceCodeLine = 973;
                            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 968;
                        } 
                    
                    __context__.SourceCodeLine = 977;
                    FCONFIGURELISTTEXTRMNUMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( SYS.IRCSTATE )) ; 
                    __context__.SourceCodeLine = 978;
                    FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 966;
                    } 
                
                __context__.SourceCodeLine = 964;
                } 
            
            
            }
            
        private void FUPDATERC_STATE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 993;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 995;
                if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 997;
                    RC_OFF_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 998;
                    RC_ON_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1002;
                    RC_ON_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1003;
                    RC_OFF_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 993;
                } 
            
            
            }
            
        private void FUPDATERC_ENABLE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1012;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1014;
                if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1016;
                    PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1017;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1021;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1022;
                    PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1012;
                } 
            
            
            }
            
        private void FPROCESSFINALIZE (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort IOTHERROOM = 0;
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 1038;
            FUPDATELISTNUMOFITEMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST )) ; 
            __context__.SourceCodeLine = 1040;
            
                {
                int __SPLS_TMPVAR__SWTCH_8__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1055;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)3; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 1057;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1058;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                            __context__.SourceCodeLine = 1061;
                            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1063;
                                ROOM [ IROOM] . LIST [ 1] . ITEM [ (I + 6)] . IISRCITEM = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1064;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 6) ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1065;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 6) )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1055;
                            } 
                        
                        __context__.SourceCodeLine = 1070;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)3; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                            {
                            __context__.SourceCodeLine = 1071;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 3)] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 3) ].IVLINK ) ; 
                            __context__.SourceCodeLine = 1070;
                            }
                        
                        __context__.SourceCodeLine = 1074;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 10 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)20; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 1076;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1078;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1079;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1074;
                            } 
                        
                        __context__.SourceCodeLine = 1084;
                        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__4 = (ushort)3; 
                        int __FN_FORSTEP_VAL__4 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                            { 
                            __context__.SourceCodeLine = 1086;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 20) ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1088;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1089;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                                __context__.SourceCodeLine = 1092;
                                if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1094;
                                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1095;
                                    FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 20) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 23) ), (ushort)( ILIST )) ; 
                                    __context__.SourceCodeLine = 1096;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 23) )) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 1084;
                            } 
                        
                        __context__.SourceCodeLine = 1102;
                        ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__5 = (ushort)10; 
                        int __FN_FORSTEP_VAL__5 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                            { 
                            __context__.SourceCodeLine = 1104;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 30) ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1106;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 30)] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1107;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 30) )) ; 
                                __context__.SourceCodeLine = 1110;
                                if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1112;
                                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1113;
                                    FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 30) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 40) ), (ushort)( ILIST )) ; 
                                    __context__.SourceCodeLine = 1114;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 40) )) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 1102;
                            } 
                        
                        __context__.SourceCodeLine = 1120;
                        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__6 = (ushort)50; 
                        int __FN_FORSTEP_VAL__6 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                            { 
                            __context__.SourceCodeLine = 1122;
                            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1123;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 1120;
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1129;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1144;
                            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__7 = (ushort)20; 
                            int __FN_FORSTEP_VAL__7 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                                { 
                                __context__.SourceCodeLine = 1146;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1148;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1149;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                    __context__.SourceCodeLine = 1152;
                                    FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 20) ), (ushort)( ILIST )) ; 
                                    __context__.SourceCodeLine = 1153;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 1156;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IISRCITEM = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1144;
                                } 
                            
                            __context__.SourceCodeLine = 1160;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 41 ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1162;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 41] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1163;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 41 )) ; 
                                __context__.SourceCodeLine = 1166;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 41 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 42 ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1167;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 42 )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1169;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 42] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1173;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 49 ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1175;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 49] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1176;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 49 )) ; 
                                __context__.SourceCodeLine = 1179;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 49 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 50 ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1180;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 50 )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1182;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 50] . IISRCITEM = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1188;
                            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__8 = (ushort)50; 
                            int __FN_FORSTEP_VAL__8 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                                { 
                                __context__.SourceCodeLine = 1191;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1193;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1194;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1197;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 1188;
                                } 
                            
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 14) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1205;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 2))  ) ) 
                            {
                            __context__.SourceCodeLine = 1205;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_112__" , 1000 , __SPLS_TMPVAR__WAITLABEL_112___Callback ) ;
                            }
                        
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1226;
            FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1227;
            FUPDATELISTALL (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1229;
            FCONFIGURELISTVIS (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1230;
            FUPDATELISTALL (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_112___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            ushort I = 0;
            
            __context__.SourceCodeLine = 1208;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1211;
                SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1212;
                SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
                __context__.SourceCodeLine = 1213;
                ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__9 = (ushort)2; 
                int __FN_FORSTEP_VAL__9 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (I  >= __FN_FORSTART_VAL__9) && (I  <= __FN_FOREND_VAL__9) ) : ( (I  <= __FN_FORSTART_VAL__9) && (I  >= __FN_FOREND_VAL__9) ) ; I  += (ushort)__FN_FORSTEP_VAL__9) 
                    { 
                    __context__.SourceCodeLine = 1215;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1216;
                    RC_OFF_FB [ I]  .Value = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
                    __context__.SourceCodeLine = 1217;
                    RC_ON_FB [ I]  .Value = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
                    __context__.SourceCodeLine = 1213;
                    } 
                
                __context__.SourceCodeLine = 1219;
                FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                } 
            
            __context__.SourceCodeLine = 1221;
            FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FPROCESSVROUTE (  SplusExecutionContext __context__, ushort IROOM , ushort ILOCALINDEX , CrestronString STEMPLINE ) 
        { 
        CrestronString STEMPDATA;
        CrestronString STEMPGUID;
        CrestronString STEMPSRC;
        STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
        STEMPGUID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
        STEMPSRC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        
        __context__.SourceCodeLine = 1242;
        STEMPDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1243;
        STEMPGUID  .UpdateValue ( Functions.Remove ( "," , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1244;
        STEMPSRC  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (Functions.Find( "," , STEMPDATA ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1245;
        STRASH  .UpdateValue ( Functions.Remove ( "src_name=" , STEMPSRC )  ) ; 
        __context__.SourceCodeLine = 1248;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
        __context__.SourceCodeLine = 1249;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
        __context__.SourceCodeLine = 1250;
        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1251;
        FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1254;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1256;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX <= 20 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1258;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
                __context__.SourceCodeLine = 1259;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
                __context__.SourceCodeLine = 1260;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
                __context__.SourceCodeLine = 1261;
                FUPDATELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
                } 
            
            } 
        
        
        }
        
    private ushort FPROCESSMACROOBJECT (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , CrestronString SDATA ) 
        { 
        
        __context__.SourceCodeLine = 1274;
        if ( Functions.TestForTrue  ( ( Functions.Find( "*" , SDATA ))  ) ) 
            {
            __context__.SourceCodeLine = 1274;
            ROOM [ IROOM] . MACRO [ IMACRO] . IPRIMARYOBJECT = (ushort) ( Functions.Atoi( SDATA ) ) ; 
            }
        
        __context__.SourceCodeLine = 1275;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Atoi( SDATA ) ) || Functions.TestForTrue ( Functions.Find( "0" , SDATA ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1277;
            ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( (ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS + 1) ) ; 
            __context__.SourceCodeLine = 1278;
            ROOM [ IROOM] . MACRO [ IMACRO] . ILIST [ ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS] = (ushort) ( Functions.Atoi( SDATA ) ) ; 
            __context__.SourceCodeLine = 1279;
            Trace( "fProcessMacroObject, Room[{0:d}].Macro[{1:d}].iList[{2:d}] = {3:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS, (ushort)Functions.Atoi( SDATA )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1281;
            return (ushort)( 0) ; 
            }
        
        
        return 0; // default return value (none specified in module)
        }
        
    private ushort FPROCESSMACRO (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , CrestronString SLINE ) 
        { 
        ushort I = 0;
        
        CrestronString STEMP;
        CrestronString SDATA;
        CrestronString STEMPKV;
        CrestronString STEMPKEY;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
        STEMPKV  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
        STEMPKEY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        
        __context__.SourceCodeLine = 1291;
        SDATA  .UpdateValue ( SLINE  ) ; 
        __context__.SourceCodeLine = 1293;
        ROOM [ IROOM] . MACRO [ IMACRO] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1294;
        ROOM [ IROOM] . MACRO [ IMACRO] . IMACROTYPE = (ushort) ( FGETMACROTYPE( __context__ , (ushort)( IMACRO ) ) ) ; 
        __context__.SourceCodeLine = 1295;
        ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1296;
        while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1298;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
            __context__.SourceCodeLine = 1300;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "name" , STEMPKEY ))  ) ) 
                { 
                __context__.SourceCodeLine = 1302;
                ROOM [ IROOM] . MACRO [ IMACRO] . SNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "," , SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 1303;
                STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1305;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1305;
                    ROOM [ IROOM] . MACRO [ IMACRO] . IUSB = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1306;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1306;
                        ROOM [ IROOM] . MACRO [ IMACRO] . IPGMAUDIO = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1307;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1309;
                            STEMP  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                            __context__.SourceCodeLine = 1310;
                            while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMP ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1311;
                                FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), Functions.Remove( "," , STEMP )) ; 
                                __context__.SourceCodeLine = 1310;
                                }
                            
                            __context__.SourceCodeLine = 1312;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 1 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1313;
                                FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), STEMP) ; 
                                }
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1317;
                            Trace( "NodeMST - fProcessMacro - error parsing macro, {0}", SLINE ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1296;
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
        
        
        __context__.SourceCodeLine = 1334;
        STEMPLINE  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1337;
        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1338;
        ROOM [ IROOM] . LIST [ ILIST] . IMAXNUMITEMS = (ushort) ( Functions.Max( IINDEX , ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ) ; 
        __context__.SourceCodeLine = 1341;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1343;
            STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
            __context__.SourceCodeLine = 1344;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
            __context__.SourceCodeLine = 1345;
            STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 1347;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1347;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1348;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1348;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1349;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1349;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1350;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1350;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1351;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1351;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1352;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1352;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1353;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_localid" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1353;
                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1354;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_global" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1354;
                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1356;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1356;
                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1357;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_localid" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1357;
                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1358;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_global" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1358;
                                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1359;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "virtual" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1359;
                                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1360;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb_mac" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1360;
                                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISUSB = (ushort) ( 1 ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1361;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 1361;
                                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IPGMAUDIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1365;
                                                                    Trace( "NodeMST - fProcessLine - didn't catch key:   GUID={0:d}, {1}{2}", (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                                                    __context__.SourceCodeLine = 1366;
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
            
            __context__.SourceCodeLine = 1341;
            } 
        
        __context__.SourceCodeLine = 1370;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID)  ) ) 
            {
            __context__.SourceCodeLine = 1370;
            ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID] = (ushort) ( IINDEX ) ; 
            }
        
        __context__.SourceCodeLine = 1372;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
            { 
            __context__.SourceCodeLine = 1375;
            ICAM = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMLOCALID ) ; 
            __context__.SourceCodeLine = 1377;
            ROOM [ IROOM] . CAM [ ICAM] . ICAMGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMGUID ) ; 
            __context__.SourceCodeLine = 1378;
            ROOM [ IROOM] . CAM [ ICAM] . ICAMACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1379;
            ROOM [ IROOM] . CAM [ ICAM] . IVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1380;
            ROOM [ IROOM] . CAM [ ICAM] . IVSRCLOCALID = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1381;
            ROOM [ IROOM] . CAM [ ICAM] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 1382;
            ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 1383;
            ROOM [ IROOM] . CAM [ ICAM] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 1385;
            ROOM [ IROOM] . CAM [ ICAM] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
            __context__.SourceCodeLine = 1387;
            MakeString ( CAM_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)ICAM, (ushort)ICAM, ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
            __context__.SourceCodeLine = 1389;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1391;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1392;
                MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(ICAM + 3), ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
                __context__.SourceCodeLine = 1394;
                if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1396;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVIS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1397;
                    MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(ICAM + 3)) ; 
                    } 
                
                __context__.SourceCodeLine = 1399;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].ICAMGUID ) ; 
                __context__.SourceCodeLine = 1400;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1403;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
                { 
                __context__.SourceCodeLine = 1406;
                IDISPLAY = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYLOCALID ) ; 
                __context__.SourceCodeLine = 1407;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1408;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1409;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVIS = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1410;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTLOCALID = (ushort) ( IINDEX ) ; 
                __context__.SourceCodeLine = 1411;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
                __context__.SourceCodeLine = 1412;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
                __context__.SourceCodeLine = 1413;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                __context__.SourceCodeLine = 1415;
                ROOM [ IROOM] . DISPLAY [ IDISPLAY] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
                __context__.SourceCodeLine = 1417;
                MakeString ( DISPLAY_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)IDISPLAY, (ushort)IDISPLAY, ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                __context__.SourceCodeLine = 1420;
                if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1422;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1424;
                    MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(IDISPLAY + (40 / 2)), ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                    __context__.SourceCodeLine = 1426;
                    if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1428;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1429;
                        MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(IDISPLAY + (40 / 2))) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1431;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IDISPLAYGUID ) ; 
                    __context__.SourceCodeLine = 1432;
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
        
        
        __context__.SourceCodeLine = 1441;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1443;
        if ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1445;
            ROOM [ IROOM] . IROOMACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1446;
            ROOM [ IROOM] . IROOMGUID = (ushort) ( IGLOBALROOMNUM ) ; 
            } 
        
        __context__.SourceCodeLine = 1448;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IROOM == 2) ) && Functions.TestForTrue ( ROOM[ IROOM ].IROOMGUID )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1448;
            SYS . IISRCPAIR = (ushort) ( 1 ) ; 
            }
        
        __context__.SourceCodeLine = 1450;
        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1452;
            STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1453;
            STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
            __context__.SourceCodeLine = 1454;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1454;
                ROOM [ IROOM] . SROOMNAME  .UpdateValue ( ST . StringTrim (  Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) )  .ToSimplSharpString() )  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1455;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_num" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1455;
                    ROOM [ IROOM] . IBLDGROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1456;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1456;
                        ROOM [ IROOM] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1457;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1457;
                            ROOM [ IROOM] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1458;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "use_src_list_mode" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1458;
                                ROOM [ IROOM] . IUSESRCLISTMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1450;
            } 
        
        __context__.SourceCodeLine = 1460;
        ROOMNAME__DOLLAR___OUT [ IROOM]  .UpdateValue ( ROOM [ IROOM] . SROOMNAME  ) ; 
        __context__.SourceCodeLine = 1461;
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
        
        
        __context__.SourceCodeLine = 1471;
        Trace( "in fProcessVLink - iRoom = {0:d}, iLocalIndex = {1:d}, sData = {2}", (ushort)IROOM, (ushort)ILOCALINDEX, STEMPLINE ) ; 
        __context__.SourceCodeLine = 1472;
        SDATA  .UpdateValue ( STEMPLINE  ) ; 
        __context__.SourceCodeLine = 1473;
        IVLINK = (ushort) ( Functions.Atoi( SDATA ) ) ; 
        __context__.SourceCodeLine = 1474;
        STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
        __context__.SourceCodeLine = 1476;
        
            {
            int __SPLS_TMPVAR__SWTCH_9__ = ((int)ITYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 15) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1478;
                    ILIST = (ushort) ( 1 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 16) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1479;
                    ILIST = (ushort) ( 2 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 17) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1480;
                    ILIST = (ushort) ( 3 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 18) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1481;
                    ILIST = (ushort) ( 4 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1484;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IISVIRTUAL)  ) ) 
            { 
            __context__.SourceCodeLine = 1486;
            IOLDGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IVLINK ) ; 
            __context__.SourceCodeLine = 1489;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVLINK = (ushort) ( IVLINK ) ; 
            __context__.SourceCodeLine = 1490;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IGUID = (ushort) ( IVLINK ) ; 
            __context__.SourceCodeLine = 1491;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SGLOBALNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "|" , SDATA ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 1492;
            ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ IVLINK] = (ushort) ( ILOCALINDEX ) ; 
            __context__.SourceCodeLine = 1495;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1496;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1498;
            FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1499;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1502;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IOLDGUID ) && Functions.TestForTrue ( Functions.BoolToInt (IOLDGUID != IVLINK) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1504;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1506;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IROUTEDSRC == IOLDGUID))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1508;
                        FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( IVLINK )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1504;
                    } 
                
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1515;
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
        
        
        __context__.SourceCodeLine = 1531;
        STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
        __context__.SourceCodeLine = 1533;
        STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1535;
        ITYPE = (ushort) ( Functions.Atoi( STEMPHEADER ) ) ; 
        __context__.SourceCodeLine = 1537;
        while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
            { 
            __context__.SourceCodeLine = 1539;
            STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
            __context__.SourceCodeLine = 1540;
            if ( Functions.TestForTrue  ( ( Functions.Find( "COMPLETE" , STEMPLINE ))  ) ) 
                {
                __context__.SourceCodeLine = 1540;
                FPROCESSFINALIZE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE )) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1544;
                if ( Functions.TestForTrue  ( ( Functions.Find( ";" , STEMPLINE ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1544;
                    STRASH  .UpdateValue ( Functions.Remove ( ";" , STEMPLINE )  ) ; 
                    }
                
                __context__.SourceCodeLine = 1545;
                ILOCALINDEX = (ushort) ( Functions.Atoi( Functions.Remove( ":" , STEMPLINE ) ) ) ; 
                __context__.SourceCodeLine = 1547;
                if ( Functions.TestForTrue  ( ( ILOCALINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1549;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITYPE <= 4 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1549;
                        FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1550;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 10))  ) ) 
                            {
                            __context__.SourceCodeLine = 1550;
                            FPROCESSVROUTE (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1551;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
                                {
                                __context__.SourceCodeLine = 1551;
                                FPROCESSMACRO (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1552;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1552;
                                    FPROCESSROOMS (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1553;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 15))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1553;
                                        FPROCESSVLINK (  __context__ , (ushort)( ITYPE ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1554;
                                        Trace( "NodeMST - fProcessData - didn't catch iLocalIndex") ; 
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1556;
                    Trace( "NodeMST - fProcessData - iLocalIndex=0.    {0} iLocalID={1:d};{2}", STEMPHEADER , (ushort)ILOCALINDEX, STEMPLINE ) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1537;
            } 
        
        
        }
        
    private void FDISPLAYPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort ISTATE ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1572;
        if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
            { 
            __context__.SourceCodeLine = 1574;
            Trace( "fDisplayPower, in !iIndex") ; 
            __context__.SourceCodeLine = 1575;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(40 / 2); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1577;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1579;
                    ROOM [ IROOM] . DISPLAY [ I] . IDISPLAYPOWERSTATE = (ushort) ( ISTATE ) ; 
                    __context__.SourceCodeLine = 1580;
                    MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},power={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYGUID, (ushort)ISTATE) ; 
                    __context__.SourceCodeLine = 1581;
                    Functions.Delay (  (int) ( 5 ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 1575;
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1587;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1589;
                ROOM [ IROOM] . DISPLAY [ IINDEX] . IDISPLAYPOWERSTATE = (ushort) ( ISTATE ) ; 
                __context__.SourceCodeLine = 1590;
                MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},power={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYGUID, (ushort)ISTATE) ; 
                __context__.SourceCodeLine = 1591;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1592;
                MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},power={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYGUID, (ushort)ISTATE) ; 
                } 
            
            } 
        
        
        }
        
    private void FCAMCMDSEND (  SplusExecutionContext __context__, ushort IROOM , ushort IGUID , CrestronString SCMD ) 
        { 
        
        __context__.SourceCodeLine = 1600;
        if ( Functions.TestForTrue  ( ( Functions.Not( IGUID ))  ) ) 
            {
            __context__.SourceCodeLine = 1600;
            IGUID = (ushort) ( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].ICAMGUID ) ; 
            }
        
        __context__.SourceCodeLine = 1601;
        MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{CAM_CTRL; guid={0:d}: cmd={1},|;}}", (ushort)IGUID, SCMD ) ; 
        
        }
        
    private void FCAMPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort ISTATE ) 
        { 
        
        __context__.SourceCodeLine = 1609;
        if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1611;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].CAM[ IINDEX ].ICAMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1613;
                ROOM [ IROOM] . CAM [ IINDEX] . ICAMPOWERSTATE = (ushort) ( ISTATE ) ; 
                __context__.SourceCodeLine = 1614;
                if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                    {
                    __context__.SourceCodeLine = 1614;
                    FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_on") ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1615;
                    FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_off") ; 
                    }
                
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1620;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)3; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1622;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].CAM[ IINDEX ].ICAMACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1624;
                    ROOM [ IROOM] . CAM [ IINDEX] . ICAMPOWERSTATE = (ushort) ( ISTATE ) ; 
                    __context__.SourceCodeLine = 1625;
                    if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                        {
                        __context__.SourceCodeLine = 1625;
                        FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_on") ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1626;
                        FCAMCMDSEND (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ IINDEX ].ICAMGUID ), "power_off") ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1620;
                } 
            
            } 
        
        
        }
        
    private void FSYSTEMPOWER (  SplusExecutionContext __context__, ushort IROOM , ushort ISTATE ) 
        { 
        short SIERR = 0;
        
        
        __context__.SourceCodeLine = 1637;
        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( 0 ), (ushort)( ISTATE )) ; 
        __context__.SourceCodeLine = 1640;
        if ( Functions.TestForTrue  ( ( Functions.Not( ISTATE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1642;
            SIERR = (short) ( FMTRX_VRTE_CLEAR( __context__ , (ushort)( IROOM ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1643;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            } 
        
        
        }
        
    private void FMACROBASE (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
        { 
        ushort IOBJECT = 0;
        
        
        __context__.SourceCodeLine = 1665;
        Trace( "fMacroBase, iRoom={0:d}, iMacro={1:d}, iState={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE) ; 
        __context__.SourceCodeLine = 1666;
        
            {
            int __SPLS_TMPVAR__SWTCH_10__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 01) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1670;
                    Trace( "Case(1): vDST, Room[{0:d}].Macro[{1:d}].iNumOfObjects={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
                    __context__.SourceCodeLine = 1672;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IDISCRETEMACROMODE)  ) ) 
                        {
                        __context__.SourceCodeLine = 1673;
                        FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1675;
                        FUPDATEMACROSRCNONDISCRETE (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
                        }
                    
                    __context__.SourceCodeLine = 1676;
                    Functions.Delay (  (int) ( 1 ) ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == (  (int) ( 02 ) ) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == (  (int) ( 03 ) ) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == (  (int) ( 04 ) ) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == (  (int) ( 05 ) ) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1686;
                    Trace( "Case(5): DisplayPower, Room[{0:d}].Macro[{1:d}].iNumOfObjects={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
                    __context__.SourceCodeLine = 1687;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IOBJECT  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IOBJECT  >= __FN_FORSTART_VAL__1) && (IOBJECT  <= __FN_FOREND_VAL__1) ) : ( (IOBJECT  <= __FN_FORSTART_VAL__1) && (IOBJECT  >= __FN_FOREND_VAL__1) ) ; IOBJECT  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1689;
                        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IOBJECT ] ), (ushort)( ISTATE )) ; 
                        __context__.SourceCodeLine = 1690;
                        Functions.Delay (  (int) ( 1 ) ) ; 
                        __context__.SourceCodeLine = 1687;
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == (  (int) ( 06 ) ) ) ) ) 
                    { 
                    } 
                
                } 
                
            }
            
        
        
        }
        
    private ushort FMACROSYSTEM (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE , ushort IISRCCALL ) 
        { 
        ushort I = 0;
        ushort J = 0;
        ushort ILISTINDEX = 0;
        ushort IOBJECT = 0;
        ushort ITYPE = 0;
        
        
        __context__.SourceCodeLine = 1706;
        Trace( "fMacroSystem, iRoom={0:d}, iMacro={1:d}, iState={2:d}, iIsRCCall={3:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE, (ushort)IISRCCALL) ; 
        __context__.SourceCodeLine = 1709;
        Trace( "fMacroSystem, Room[{0:d}].Macro[{1:d}].iNumOfObjects={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
        __context__.SourceCodeLine = 1710;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( ILISTINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILISTINDEX  >= __FN_FORSTART_VAL__1) && (ILISTINDEX  <= __FN_FOREND_VAL__1) ) : ( (ILISTINDEX  <= __FN_FORSTART_VAL__1) && (ILISTINDEX  >= __FN_FOREND_VAL__1) ) ; ILISTINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1712;
            IOBJECT = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ ILISTINDEX ] ) ; 
            __context__.SourceCodeLine = 1713;
            ITYPE = (ushort) ( ROOM[ IROOM ].MACRO[ IOBJECT ].IMACROTYPE ) ; 
            __context__.SourceCodeLine = 1715;
            
                {
                int __SPLS_TMPVAR__SWTCH_11__ = ((int)ITYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1719;
                        Trace( "fMacroSystem, Room[{0:d}].Macro[{1:d}].iNumOfObjects={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
                        __context__.SourceCodeLine = 1721;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISTATE ) && Functions.TestForTrue ( Functions.Not( IISRCCALL ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1722;
                            ROOM [ IROOM] . MACRO [ IOBJECT] . ISTATE = (ushort) ( 2 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1723;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ISTATE ) && Functions.TestForTrue ( IISRCCALL )) ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1724;
                                ROOM [ IROOM] . MACRO [ IOBJECT] . ISTATE = (ushort) ( (2 + 6) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1726;
                                ROOM [ IROOM] . MACRO [ IOBJECT] . ISTATE = (ushort) ( ISTATE ) ; 
                                }
                            
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1731;
                        ROOM [ IROOM] . MACRO [ IOBJECT] . ISTATE = (ushort) ( ISTATE ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1734;
            Trace( "fMacroSystem, Room[{0:d}].Macro[{1:d}].iState={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IOBJECT ].ISTATE) ; 
            __context__.SourceCodeLine = 1736;
            FMACROBASE (  __context__ , (ushort)( IROOM ), (ushort)( IOBJECT ), (ushort)( ROOM[ IROOM ].MACRO[ IOBJECT ].ISTATE )) ; 
            __context__.SourceCodeLine = 1710;
            } 
        
        
        return 0; // default return value (none specified in module)
        }
        
    object RC_ON_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 1752;
            SYS . IRCSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1753;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1754;
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
        
        
        __context__.SourceCodeLine = 1761;
        SYS . IRCSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1762;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1763;
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
        
        
        __context__.SourceCodeLine = 1770;
        SYS . IRCSTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 1771;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1772;
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
        
        
        __context__.SourceCodeLine = 1779;
        if ( Functions.TestForTrue  ( ( SYS.IPARTITIONENABLED)  ) ) 
            { 
            __context__.SourceCodeLine = 1781;
            SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
            __context__.SourceCodeLine = 1783;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1784;
            FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
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
        
        
        __context__.SourceCodeLine = 1791;
        SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1793;
        FUPDATERC_ENABLE_FB (  __context__ , (ushort)( SYS.IPARTITIONENABLED )) ; 
        __context__.SourceCodeLine = 1795;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) != SYS.IRCSTATE))  ) ) 
            { 
            __context__.SourceCodeLine = 1797;
            SYS . IRCSTATE = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
            __context__.SourceCodeLine = 1798;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1799;
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
        
        
        __context__.SourceCodeLine = 1806;
        SYS . IPARTITIONENABLED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1808;
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
        ushort IROOM = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1815;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1817;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1819;
            Trace( "Sys_PowerOn, iRCState = 1") ; 
            __context__.SourceCodeLine = 1820;
            Functions.Pulse ( 10, SYS_POWERON_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 1821;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1823;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1824;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 59 ), (ushort)( 1 ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1826;
            Functions.Pulse ( 10, SYS_POWERON_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 1827;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1829;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1830;
            FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 59 ), (ushort)( 1 ), (ushort)( 1 )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1834;
            Trace( "Sys_PowerOn, iRCState = 0") ; 
            __context__.SourceCodeLine = 1835;
            Functions.Pulse ( 10, SYS_POWERON_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 1836;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1838;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1839;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 57 ), (ushort)( 1 ), (ushort)( 0 )) ; 
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
        ushort IROOM = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1846;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1848;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1850;
            Trace( "Sys_PowerOff, iRCState = 1") ; 
            __context__.SourceCodeLine = 1853;
            DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1854;
            DSP_PGM_RTE [ FOTHERROOM( __context__ , (ushort)( IROOM ) )]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1857;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 1858;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1859;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 60 ) , (ushort)( 0 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1861;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 1862;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1863;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) , (ushort)( 60 ) , (ushort)( 0 ) , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 1866;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1867;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1871;
            Trace( "Sys_PowerOff, iRCState = 0") ; 
            __context__.SourceCodeLine = 1873;
            DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1875;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 1876;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1877;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 58 ) , (ushort)( 0 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1879;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
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
        
        
        __context__.SourceCodeLine = 1895;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1896;
        ISYSPRESET = (ushort) ( SYS_PRESET[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1898;
        if ( Functions.TestForTrue  ( ( ISYSPRESET)  ) ) 
            { 
            __context__.SourceCodeLine = 1900;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1902;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1904;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == ISYSPRESET) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == 9) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1906;
                        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 1 )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1910;
                        FDISPLAYPOWER (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1900;
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
        
        
        __context__.SourceCodeLine = 1924;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1926;
        ISRC = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED ) ; 
        __context__.SourceCodeLine = 1927;
        if ( Functions.TestForTrue  ( ( FGETNUMITEMSSELECTED( __context__ , (ushort)( IROOM ) , (ushort)( 2 ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1929;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ 2 ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1931;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1933;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                    } 
                
                __context__.SourceCodeLine = 1929;
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
        
        
        __context__.SourceCodeLine = 1944;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1946;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1947;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1949;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1950;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1952;
        ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1953;
        ROOM [ IROOM] . LIST [ 2] . INUMOFITEMSSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1955;
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
        
        
        __context__.SourceCodeLine = 1962;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1964;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1965;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1967;
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
        
        
        __context__.SourceCodeLine = 1973;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1974;
        IINDEX = (ushort) ( MTRX_ADMINVSRC_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1976;
        if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1979;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED)  ) ) 
                { 
                __context__.SourceCodeLine = 1981;
                ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED] . IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1982;
                FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED )) ; 
                } 
            
            __context__.SourceCodeLine = 1984;
            ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1985;
            ROOM [ IROOM] . LIST [ 1] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1986;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 1988;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
            __context__.SourceCodeLine = 1990;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IUSESRCLISTMODE)  ) ) 
                {
                __context__.SourceCodeLine = 1990;
                FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
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
        
        
        __context__.SourceCodeLine = 1997;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1998;
        IINDEX = (ushort) ( MTRX_ADMINVDST_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2001;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IINDEX ].IFB ) ) ; 
        __context__.SourceCodeLine = 2002;
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
        
        
        __context__.SourceCodeLine = 2009;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2010;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2011;
        ISRC = (ushort) ( MTRX_MACRO1_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2013;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2014;
        FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2016;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2021;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC < 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 2021;
                ISRC = (ushort) ( (ISRC + 6) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 2022;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2022;
                    ISRC = (ushort) ( (ISRC - 6) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 2024;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2025;
            FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
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
        
        
        __context__.SourceCodeLine = 2032;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2033;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2034;
        ISRC = (ushort) ( MTRX_MACRO2_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2036;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2037;
        FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2039;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2044;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC < 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 2044;
                ISRC = (ushort) ( (ISRC + 6) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 2045;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC > 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2045;
                    ISRC = (ushort) ( (ISRC - 6) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 2046;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2047;
            FUPDATEMACROSRCDISCRETE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
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
        
        
        __context__.SourceCodeLine = 2054;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2055;
        IDST = (ushort) ( MTRX_MACRO1_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2057;
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
        
        
        __context__.SourceCodeLine = 2062;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2063;
        IDST = (ushort) ( MTRX_MACRO2_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2065;
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
        
        __context__.SourceCodeLine = 2077;
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
        
        __context__.SourceCodeLine = 2081;
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
        
        __context__.SourceCodeLine = 2085;
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
        
        __context__.SourceCodeLine = 2089;
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
        
        __context__.SourceCodeLine = 2093;
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
        
        __context__.SourceCodeLine = 2097;
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
        
        __context__.SourceCodeLine = 2101;
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
        
        __context__.SourceCodeLine = 2105;
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
        
        __context__.SourceCodeLine = 2110;
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
        
        __context__.SourceCodeLine = 2115;
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
        
        
        __context__.SourceCodeLine = 2123;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2124;
        ROOM [ IROOM] . ICAMSEL = (ushort) ( CAM_SELECT[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2126;
        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
        __context__.SourceCodeLine = 2128;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 2130;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].IVSRCGUID )) ; 
            __context__.SourceCodeLine = 2131;
            FUPDATECAMRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].ICAMSEL )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FUPDATEGUI (  SplusExecutionContext __context__, ushort IROOM , ushort IPAGE , ushort ISUB ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 2145;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPAGE ) && Functions.TestForTrue ( ISUB )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2147;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ILASTSRCSEL[ IPAGE , ISUB ])  ) ) 
            { 
            __context__.SourceCodeLine = 2149;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].ILASTSRCSEL[ IPAGE , ISUB ] )) ; 
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
        
        
        __context__.SourceCodeLine = 2157;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2159;
        ROOM [ IROOM] . IUI_PAGE = (ushort) ( UI_PAGE[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2161;
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
        
        
        __context__.SourceCodeLine = 2167;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2169;
        ROOM [ IROOM] . IUI_SUB = (ushort) ( UI_SUB[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2171;
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
        
        
        __context__.SourceCodeLine = 2185;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2187;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2188;
            FPROCESSDATA (  __context__ , (ushort)( 1 ), STEMP) ; 
            __context__.SourceCodeLine = 2185;
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
        
        
        __context__.SourceCodeLine = 2196;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2198;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2199;
            FPROCESSDATA (  __context__ , (ushort)( 2 ), STEMP) ; 
            __context__.SourceCodeLine = 2196;
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
        
        __context__.SourceCodeLine = 2210;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2212;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2214;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)2; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( L  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (L  >= __FN_FORSTART_VAL__2) && (L  <= __FN_FOREND_VAL__2) ) : ( (L  <= __FN_FORSTART_VAL__2) && (L  >= __FN_FOREND_VAL__2) ) ; L  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 2216;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)6; 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 2218;
                    ROOM [ I] . LIST [ L] . ITEM [ J] . IISVIRTUAL = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 2216;
                    } 
                
                __context__.SourceCodeLine = 2214;
                } 
            
            __context__.SourceCodeLine = 2212;
            } 
        
        __context__.SourceCodeLine = 2223;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)2; 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 2225;
            ROOM [ I] . LIST [ 1] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2226;
            ROOM [ I] . LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2227;
            ROOM [ I] . LIST [ 1] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2228;
            ROOM [ I] . LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2229;
            ROOM [ I] . LIST [ 1] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2230;
            ROOM [ I] . LIST [ 1] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2232;
            ROOM [ I] . LIST [ 2] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2233;
            ROOM [ I] . LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 2234;
            ROOM [ I] . LIST [ 2] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2235;
            ROOM [ I] . LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2236;
            ROOM [ I] . LIST [ 2] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2237;
            ROOM [ I] . LIST [ 2] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2239;
            ROOM [ I] . LIST [ 3] . IMAXNUMITEMS = (ushort) ( 24 ) ; 
            __context__.SourceCodeLine = 2240;
            ROOM [ I] . LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2241;
            ROOM [ I] . LIST [ 3] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2242;
            ROOM [ I] . LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2243;
            ROOM [ I] . LIST [ 3] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2244;
            ROOM [ I] . LIST [ 3] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2246;
            ROOM [ I] . LIST [ 4] . IMAXNUMITEMS = (ushort) ( 15 ) ; 
            __context__.SourceCodeLine = 2247;
            ROOM [ I] . LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2248;
            ROOM [ I] . LIST [ 4] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2249;
            ROOM [ I] . LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2250;
            ROOM [ I] . LIST [ 4] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2251;
            ROOM [ I] . LIST [ 4] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2253;
            ROOM [ I] . LIST [ 5] . IMAXNUMITEMS = (ushort) ( 9 ) ; 
            __context__.SourceCodeLine = 2254;
            ROOM [ I] . LIST [ 5] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2255;
            ROOM [ I] . LIST [ 5] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2256;
            ROOM [ I] . LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2257;
            ROOM [ I] . LIST [ 5] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2258;
            ROOM [ I] . LIST [ 5] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2260;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)9; 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                { 
                __context__.SourceCodeLine = 2262;
                ROOM [ I] . LIST [ 5] . ITEM [ J] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2263;
                ROOM [ I] . LIST [ 5] . ITEM [ (J + 20)] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2260;
                } 
            
            __context__.SourceCodeLine = 2223;
            } 
        
        __context__.SourceCodeLine = 2268;
        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__6 = (ushort)2; 
        int __FN_FORSTEP_VAL__6 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
            { 
            __context__.SourceCodeLine = 2272;
            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__7 = (ushort)10; 
            int __FN_FORSTEP_VAL__7 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (J  >= __FN_FORSTART_VAL__7) && (J  <= __FN_FOREND_VAL__7) ) : ( (J  <= __FN_FORSTART_VAL__7) && (J  >= __FN_FOREND_VAL__7) ) ; J  += (ushort)__FN_FORSTEP_VAL__7) 
                {
                __context__.SourceCodeLine = 2273;
                ROOM [ I] . CAM [ J] . IVSRCLOCALID = (ushort) ( (J + 20) ) ; 
                __context__.SourceCodeLine = 2272;
                }
            
            __context__.SourceCodeLine = 2274;
            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__8 = (ushort)40; 
            int __FN_FORSTEP_VAL__8 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (J  >= __FN_FORSTART_VAL__8) && (J  <= __FN_FOREND_VAL__8) ) : ( (J  <= __FN_FORSTART_VAL__8) && (J  >= __FN_FOREND_VAL__8) ) ; J  += (ushort)__FN_FORSTEP_VAL__8) 
                {
                __context__.SourceCodeLine = 2275;
                ROOM [ I] . DISPLAY [ J] . IVDSTLOCALID = (ushort) ( J ) ; 
                __context__.SourceCodeLine = 2274;
                }
            
            __context__.SourceCodeLine = 2268;
            } 
        
        
        
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
    
    __SPLS_TMPVAR__WAITLABEL_112___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_112___CallbackFn );
    
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

public UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_81 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_112___Callback;


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
    public ushort  IITEMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SNAME;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  INUMOFOBJECTS = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  [] ILIST;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IPRIMARYOBJECT = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  ISTATE = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  IMACROTYPE = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IVIS = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IFB = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  IUSB = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IPGMAUDIO = 0;
    
    
    public STMACRO( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ILIST  = new ushort[ 31 ];
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
    
    public STLIST [] LIST;
    
    public STMACRO [] MACRO;
    
    [SplusStructAttribute(12, false, false)]
    public ushort  [,] ILASTSRCSEL;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IUI_PAGE = 0;
    
    [SplusStructAttribute(14, false, false)]
    public ushort  IUI_SUB = 0;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ILASTSRCSEL  = new ushort[ 21,21 ];
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
        MACRO  = new STMACRO[ 61 ];
        for( uint i = 0; i < 61; i++ )
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
