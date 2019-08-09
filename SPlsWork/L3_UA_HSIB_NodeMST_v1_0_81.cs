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
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MTRX_MACRO_DST_FB;
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
            
            __context__.SourceCodeLine = 369;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMACRO >= 01 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IMACRO <= 25 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 369;
                return (ushort)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 370;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 26))  ) ) 
                    {
                    __context__.SourceCodeLine = 370;
                    return (ushort)( 2) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 371;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 27))  ) ) 
                        {
                        __context__.SourceCodeLine = 371;
                        return (ushort)( 3) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 372;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 30 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 372;
                            return (ushort)( 4) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 373;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 40 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 373;
                                return (ushort)( 5) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 374;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 56 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 374;
                                    return (ushort)( 6) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 375;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 57))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 375;
                                        return (ushort)( 7) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 376;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 58))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 376;
                                            return (ushort)( 8) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 377;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 59))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 377;
                                                return (ushort)( 9) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 378;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 60))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 378;
                                                    return (ushort)( 10) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 379;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 70 ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 379;
                                                        return (ushort)( 11) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 380;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 80 ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 380;
                                                            return (ushort)( 12) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 381;
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
                    
                    }
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FGETNUMITEMSSELECTED (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort I = 0;
            ushort ICOUNT = 0;
            
            
            __context__.SourceCodeLine = 388;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 390;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 390;
                    ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 388;
                } 
            
            __context__.SourceCodeLine = 393;
            return (ushort)( ICOUNT) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 398;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private ushort FOTHERROOMSRCNUM (  SplusExecutionContext __context__, ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 403;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 10 ))  ) ) 
                { 
                __context__.SourceCodeLine = 405;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)ISRC);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 407;
                            return (ushort)( 7) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 408;
                            return (ushort)( 8) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                            {
                            __context__.SourceCodeLine = 409;
                            return (ushort)( 9) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                            {
                            __context__.SourceCodeLine = 410;
                            return (ushort)( 1) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                            {
                            __context__.SourceCodeLine = 411;
                            return (ushort)( 2) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                            {
                            __context__.SourceCodeLine = 412;
                            return (ushort)( 3) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 415;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 20 ))  ) ) 
                    { 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 419;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 30 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 421;
                        
                            {
                            int __SPLS_TMPVAR__SWTCH_2__ = ((int)ISRC);
                            
                                { 
                                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 21) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 423;
                                    return (ushort)( 24) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 22) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 424;
                                    return (ushort)( 25) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 23) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 425;
                                    return (ushort)( 26) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 24) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 426;
                                    return (ushort)( 21) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 25) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 427;
                                    return (ushort)( 22) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 26) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 428;
                                    return (ushort)( 23) ; 
                                    }
                                
                                } 
                                
                            }
                            
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 431;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 40 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 432;
                            return (ushort)( (ISRC + 10)) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 433;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 50 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 434;
                                return (ushort)( (ISRC - 10)) ; 
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FCOPYIO (  SplusExecutionContext __context__, ushort IFROMROOM , ushort IFROMINDEX , ushort ITOROOM , ushort ITOINDEX , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 440;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IITEMACTIVE = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IITEMACTIVE ) ; 
            __context__.SourceCodeLine = 441;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SGLOBALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 442;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SLOCALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 443;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IRMASS = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IRMASS ) ; 
            __context__.SourceCodeLine = 444;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IGUID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 445;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFUNCTIONID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFUNCTIONID ) ; 
            __context__.SourceCodeLine = 446;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFILTERID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFILTERID ) ; 
            __context__.SourceCodeLine = 447;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IISVIRTUAL = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IISVIRTUAL ) ; 
            __context__.SourceCodeLine = 448;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IVLINK = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IVLINK ) ; 
            __context__.SourceCodeLine = 450;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 454;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IROUTEDSRC = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IROUTEDSRC ) ; 
                        __context__.SourceCodeLine = 455;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SROUTEDSRC  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SROUTEDSRC  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 467;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 469;
                        MTRX_ADMINVSRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 470;
                        MTRX_ADMINVDST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 471;
                        DSP_MICS_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 472;
                        DSP_LINE_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 473;
                        MTRX_MACRO_SRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 474;
                        MTRX_MACRO_DST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTNUMOFITEMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 480;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 482;
                        MTRX_ADMINVSRC_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 483;
                        MTRX_ADMINVDST_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 484;
                        DSP_MICS_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 485;
                        DSP_LINE_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FDISPLAYCMD (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort IFOLDEDCMD ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 501;
            if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                { 
                __context__.SourceCodeLine = 504;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(40 / 2); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 506;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 508;
                        ROOM [ IROOM] . DISPLAY [ I] . IDISPLAYPOWERSTATE = (ushort) ( IFOLDEDCMD ) ; 
                        __context__.SourceCodeLine = 509;
                        MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},cmd={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYGUID, (ushort)IFOLDEDCMD) ; 
                        __context__.SourceCodeLine = 510;
                        Functions.Delay (  (int) ( 5 ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 504;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 516;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 518;
                    ROOM [ IROOM] . DISPLAY [ IINDEX] . IDISPLAYPOWERSTATE = (ushort) ( IFOLDEDCMD ) ; 
                    __context__.SourceCodeLine = 519;
                    MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},cmd={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYGUID, (ushort)IFOLDEDCMD) ; 
                    } 
                
                } 
            
            
            }
            
        private void FCAMCMDSEND (  SplusExecutionContext __context__, ushort IROOM , ushort IGUID , CrestronString SCMD ) 
            { 
            
            __context__.SourceCodeLine = 529;
            if ( Functions.TestForTrue  ( ( Functions.Not( IGUID ))  ) ) 
                {
                __context__.SourceCodeLine = 529;
                IGUID = (ushort) ( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].ICAMGUID ) ; 
                }
            
            __context__.SourceCodeLine = 530;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{CAM_CTRL; guid={0:d}: cmd={1},|;}}", (ushort)IGUID, SCMD ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 546;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESFB)  ) ) 
                { 
                __context__.SourceCodeLine = 548;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 549;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 551;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 555;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 556;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 557;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                            }
                        
                        __context__.SourceCodeLine = 555;
                        }
                    
                    __context__.SourceCodeLine = 558;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 560;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 569;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 571;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 572;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 573;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 576;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 577;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 578;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                            }
                        
                        __context__.SourceCodeLine = 576;
                        }
                    
                    __context__.SourceCodeLine = 579;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 581;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                __context__.SourceCodeLine = 582;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 582;
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
            
            
            __context__.SourceCodeLine = 591;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESICON)  ) ) 
                { 
                __context__.SourceCodeLine = 593;
                STEMP  .UpdateValue ( "{ListIconFB:"  ) ; 
                __context__.SourceCodeLine = 594;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 596;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 600;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 601;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 602;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                            }
                        
                        __context__.SourceCodeLine = 600;
                        }
                    
                    __context__.SourceCodeLine = 604;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 606;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 615;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESTEXT)  ) ) 
                { 
                __context__.SourceCodeLine = 617;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 618;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 620;
                    STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                    __context__.SourceCodeLine = 621;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 622;
                        MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                        __context__.SourceCodeLine = 621;
                        }
                    
                    __context__.SourceCodeLine = 623;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 627;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 629;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 631;
                            STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                            __context__.SourceCodeLine = 632;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                                {
                                __context__.SourceCodeLine = 633;
                                MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                                __context__.SourceCodeLine = 632;
                                }
                            
                            __context__.SourceCodeLine = 634;
                            STEMP  .UpdateValue ( STEMP + "|"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 636;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 850 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 638;
                            STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                            __context__.SourceCodeLine = 639;
                            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 640;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                                {
                                __context__.SourceCodeLine = 640;
                                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                                }
                            
                            __context__.SourceCodeLine = 641;
                            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 627;
                        } 
                    
                    __context__.SourceCodeLine = 644;
                    STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 646;
                if ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 648;
                    FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 649;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 649;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                        }
                    
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 657;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 658;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 659;
            FUPDATELISTICON (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 660;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FCONFIGURELISTVISPROCESS (  SplusExecutionContext __context__, ushort IROOM , ushort IFROMLIST , ushort ITOLIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 672;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                {
                __context__.SourceCodeLine = 672;
                ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 674;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                    {
                    __context__.SourceCodeLine = 674;
                    ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IVLINK ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 676;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        {
                        __context__.SourceCodeLine = 676;
                        ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 677;
                        ; 
                        }
                    
                    }
                
                }
            
            
            }
            
        private void FCONFIGURELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 683;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                {
                __context__.SourceCodeLine = 683;
                FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 684;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    {
                    __context__.SourceCodeLine = 684;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    __context__.SourceCodeLine = 684;
                    }
                
                }
            
            __context__.SourceCodeLine = 687;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 689;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    {
                    __context__.SourceCodeLine = 689;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 690;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        {
                        __context__.SourceCodeLine = 690;
                        FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                        __context__.SourceCodeLine = 690;
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 697;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                {
                __context__.SourceCodeLine = 697;
                MakeString ( STEMP , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                }
            
            __context__.SourceCodeLine = 698;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 700;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_6__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 704;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 706;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 711;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 712;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ] , "{0}", ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SROUTEDSRC ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 716;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS ))  ) ) 
                                {
                                __context__.SourceCodeLine = 717;
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
            
            
            __context__.SourceCodeLine = 727;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 729;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I != ISKIPINDEX))  ) ) 
                    {
                    __context__.SourceCodeLine = 729;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( IVAL ) ; 
                    }
                
                __context__.SourceCodeLine = 727;
                } 
            
            
            }
            
        private void FSETLISTMACROFB (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 738;
            
                {
                int __SPLS_TMPVAR__SWTCH_7__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 742;
                        MTRX_MACRO1_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 743;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 745;
                            MTRX_MACRO1_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 746;
                            MTRX_MACRO1_SRC_FB [ 2]  .Value = (ushort) ( ISRC ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 751;
                        MTRX_MACRO2_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                        __context__.SourceCodeLine = 752;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 754;
                            MTRX_MACRO2_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 755;
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
            
            
            __context__.SourceCodeLine = 766;
            STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
            __context__.SourceCodeLine = 767;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 769;
                IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 770;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].ICAMSEL == I))  ) ) 
                    {
                    __context__.SourceCodeLine = 770;
                    IFB = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 772;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)IFB) ; 
                __context__.SourceCodeLine = 767;
                } 
            
            __context__.SourceCodeLine = 775;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 777;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUPDATECAMVIS (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 785;
            STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 786;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 788;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)ROOM[ IROOM ].CAM[ I ].IVIS) ; 
                __context__.SourceCodeLine = 786;
                } 
            
            __context__.SourceCodeLine = 791;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 792;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUSBTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 804;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{USB_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FMTRXTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 811;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{MTRX_V_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FUPDATECONFMONITORRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 831;
            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 49 ].IGUID ), (ushort)( ISRCGUID )) ; 
            
            }
            
        private void FRUNMACROUSB (  SplusExecutionContext __context__, ushort IROOM , ushort IVSRCLOCALID , ushort IVDSTLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 836;
            FUSBTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID )) ; 
            
            }
            
        private void FRUNMACROPGMAUDIO (  SplusExecutionContext __context__, ushort IROOM , ushort IVSRCLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 856;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVSRCLOCALID <= 3 ))  ) ) 
                {
                __context__.SourceCodeLine = 857;
                DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IPGMAUDIO ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 859;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IVSRCLOCALID >= 6 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IVSRCLOCALID <= 9 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 860;
                    DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( 4 ) ; 
                    }
                
                }
            
            
            }
            
        private void FRUNMACROMTRX (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
            { 
            ushort IDST = 0;
            ushort IVDSTLOCALID = 0;
            ushort ISRCGUID = 0;
            
            
            __context__.SourceCodeLine = 869;
            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
            __context__.SourceCodeLine = 870;
            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
            __context__.SourceCodeLine = 873;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IVSRCLOCALID ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IITEMACTIVE )) ))  ) ) 
                {
                __context__.SourceCodeLine = 874;
                ISRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID ) ; 
                }
            
            __context__.SourceCodeLine = 878;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IPGMAUDIO)  ) ) 
                {
                __context__.SourceCodeLine = 879;
                FRUNMACROPGMAUDIO (  __context__ , (ushort)( IROOM ), (ushort)( IVSRCLOCALID )) ; 
                }
            
            __context__.SourceCodeLine = 882;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 884;
                IVDSTLOCALID = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IDST ] ) ; 
                __context__.SourceCodeLine = 886;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ISRCGUID )) ; 
                __context__.SourceCodeLine = 891;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IUSB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 894;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IISRCITEM ) ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IISUSB )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 895;
                        FRUNMACROUSB (  __context__ , (ushort)( IROOM ), (ushort)( IVSRCLOCALID ), (ushort)( IVDSTLOCALID )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 882;
                } 
            
            
            }
            
        private void FRUNMACRODISPLAYCTRL (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
            { 
            ushort IINDEX = 0;
            ushort IFOLDEDCMD = 0;
            
            
            __context__.SourceCodeLine = 905;
            if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                {
                __context__.SourceCodeLine = 905;
                IFOLDEDCMD = (ushort) ( 11 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 906;
                IFOLDEDCMD = (ushort) ( 10 ) ; 
                }
            
            __context__.SourceCodeLine = 908;
            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IFOLDEDCMD ) ; 
            __context__.SourceCodeLine = 909;
            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IFOLDEDCMD )) ; 
            __context__.SourceCodeLine = 911;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 913;
                FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IINDEX ] ), (ushort)( IFOLDEDCMD )) ; 
                __context__.SourceCodeLine = 914;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 911;
                } 
            
            
            }
            
        private ushort FRUNMACROSPECIALFUNCTION (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 927;
            
                {
                int __SPLS_TMPVAR__SWTCH_8__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].ISPECIALFUNCTION);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 933;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)10; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            {
                            __context__.SourceCodeLine = 934;
                            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ (I + 30) ].IGUID )) ; 
                            __context__.SourceCodeLine = 933;
                            }
                        
                        __context__.SourceCodeLine = 937;
                        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                            {
                            __context__.SourceCodeLine = 938;
                            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__2 = (ushort)10; 
                            int __FN_FORSTEP_VAL__2 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                {
                                __context__.SourceCodeLine = 939;
                                FMTRXTAKE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 1 ].ITEM[ (I + 30) ].IGUID )) ; 
                                __context__.SourceCodeLine = 938;
                                }
                            
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 947;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 10 )) ; 
                        __context__.SourceCodeLine = 951;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 2 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)4; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                            {
                            __context__.SourceCodeLine = 952;
                            FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 11 )) ; 
                            __context__.SourceCodeLine = 951;
                            }
                        
                        __context__.SourceCodeLine = 954;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_33__" , 500 , __SPLS_TMPVAR__WAITLABEL_33___Callback ) ;
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 966;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 11 )) ; 
                        __context__.SourceCodeLine = 968;
                        ushort __FN_FORSTART_VAL__6 = (ushort) ( 2 ) ;
                        ushort __FN_FOREND_VAL__6 = (ushort)4; 
                        int __FN_FORSTEP_VAL__6 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                            {
                            __context__.SourceCodeLine = 969;
                            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__7 = (ushort)4; 
                            int __FN_FORSTEP_VAL__7 = (int)1; 
                            for ( J  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (J  >= __FN_FORSTART_VAL__7) && (J  <= __FN_FOREND_VAL__7) ) : ( (J  <= __FN_FORSTART_VAL__7) && (J  >= __FN_FOREND_VAL__7) ) ; J  += (ushort)__FN_FORSTEP_VAL__7) 
                                {
                                __context__.SourceCodeLine = 970;
                                FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( ((60 + J) + ((I - 2) * 4)) )) ; 
                                __context__.SourceCodeLine = 969;
                                }
                            
                            __context__.SourceCodeLine = 968;
                            }
                        
                        __context__.SourceCodeLine = 972;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_34__" , 500 , __SPLS_TMPVAR__WAITLABEL_34___Callback ) ;
                        } 
                    
                    } 
                    
                }
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_33___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            ushort I = 0;
            ushort J = 0;
            
            __context__.SourceCodeLine = 957;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 2 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)4; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                {
                __context__.SourceCodeLine = 958;
                ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__5 = (ushort)4; 
                int __FN_FORSTEP_VAL__5 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                    {
                    __context__.SourceCodeLine = 959;
                    FDISPLAYCMD (  __context__ , (ushort)( 1 ), (ushort)( I ), (ushort)( ((80 + J) + ((I - 2) * 4)) )) ; 
                    __context__.SourceCodeLine = 958;
                    }
                
                __context__.SourceCodeLine = 957;
                }
            
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_34___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 974;
            FDISPLAYCMD (  __context__ , (ushort)( 1 ), (ushort)( 2 ), (ushort)( 81 )) ; 
            __context__.SourceCodeLine = 975;
            FDISPLAYCMD (  __context__ , (ushort)( 1 ), (ushort)( 4 ), (ushort)( 90 )) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FUPDATEMACROSRC (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
    { 
    
    __context__.SourceCodeLine = 984;
    ROOM [ IROOM] . ILASTSRCSEL [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID ) ; 
    __context__.SourceCodeLine = 987;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IDISCRETEMACROMODE)  ) ) 
        {
        __context__.SourceCodeLine = 988;
        FRUNMACROMTRX (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
        }
    
    else 
        { 
        __context__.SourceCodeLine = 992;
        ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
        __context__.SourceCodeLine = 993;
        FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
        } 
    
    
    }
    
private void FUPDATECAMRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ICAM ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1004;
    ROOM [ IROOM] . ILASTSRCSEL [ 3 , 2] = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
    __context__.SourceCodeLine = 1006;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ 5 ].INUMOFOBJECTS; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1008;
        FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ 5 ].ILIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID )) ; 
        __context__.SourceCodeLine = 1006;
        } 
    
    
    }
    
private void FCONFIGURELISTTEXTRMNUMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort ISTATE ) 
    { 
    ushort IINDEX = 0;
    
    CrestronString STHISROOM;
    CrestronString SOTHERROOM;
    STHISROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SOTHERROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    
    __context__.SourceCodeLine = 1025;
    if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
        { 
        __context__.SourceCodeLine = 1027;
        MakeString ( STHISROOM , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
        __context__.SourceCodeLine = 1028;
        MakeString ( SOTHERROOM , "{0} ", ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . SROOMNAMESHORT ) ; 
        } 
    
    __context__.SourceCodeLine = 1031;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)50; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1033;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
            { 
            __context__.SourceCodeLine = 1035;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                {
                __context__.SourceCodeLine = 1036;
                MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", SOTHERROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1038;
                MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STHISROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1031;
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
    
    
    __context__.SourceCodeLine = 1047;
    
        {
        int __SPLS_TMPVAR__SWTCH_9__ = ((int)ITYPE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                { 
                __context__.SourceCodeLine = 1052;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)2; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1054;
                    V [ IROOM] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 5 ].IVLINK ) ; 
                    __context__.SourceCodeLine = 1052;
                    } 
                
                __context__.SourceCodeLine = 1057;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ 2 ].IVTCALLOCATION ) && Functions.TestForTrue ( Functions.Not( ROOM[ 1 ].IVTCALLOCATION ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1059;
                    FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1060;
                    FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 6 ), (ushort)( 1 ), (ushort)( 6 ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1062;
                    ROOM [ 1] . IVTCALLOCATION = (ushort) ( ROOM[ 2 ].IVTCALLOCATION ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1066;
                    FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 5 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1067;
                    FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 6 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1069;
                    ROOM [ 2] . IVTCALLOCATION = (ushort) ( ROOM[ 1 ].IVTCALLOCATION ) ; 
                    } 
                
                __context__.SourceCodeLine = 1073;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)2; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 1075;
                    FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                    __context__.SourceCodeLine = 1076;
                    ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                    ushort __FN_FOREND_VAL__3 = (ushort)6; 
                    int __FN_FORSTEP_VAL__3 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                        { 
                        __context__.SourceCodeLine = 1078;
                        ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( ROOM[ IROOM ].CAM[ I ].ICAMACTIVE ) ; 
                        __context__.SourceCodeLine = 1076;
                        } 
                    
                    __context__.SourceCodeLine = 1080;
                    FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                    __context__.SourceCodeLine = 1073;
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 0) ) ) ) 
                { 
                __context__.SourceCodeLine = 1092;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)2; 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( IROOM  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__4) && (IROOM  <= __FN_FOREND_VAL__4) ) : ( (IROOM  <= __FN_FORSTART_VAL__4) && (IROOM  >= __FN_FOREND_VAL__4) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__4) 
                    {
                    __context__.SourceCodeLine = 1093;
                    ushort __FN_FORSTART_VAL__5 = (ushort) ( 4 ) ;
                    ushort __FN_FOREND_VAL__5 = (ushort)6; 
                    int __FN_FORSTEP_VAL__5 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                        {
                        __context__.SourceCodeLine = 1093;
                        ROOM [ IROOM] . LIST [ 1] . ITEM [ I] . IVLINK = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1093;
                        }
                    
                    __context__.SourceCodeLine = 1092;
                    }
                
                __context__.SourceCodeLine = 1096;
                ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__6 = (ushort)2; 
                int __FN_FORSTEP_VAL__6 = (int)1; 
                for ( IROOM  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__6) && (IROOM  <= __FN_FOREND_VAL__6) ) : ( (IROOM  <= __FN_FORSTART_VAL__6) && (IROOM  >= __FN_FOREND_VAL__6) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__6) 
                    { 
                    __context__.SourceCodeLine = 1098;
                    ROOM [ IROOM] . ICAMSEL = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1099;
                    FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                    __context__.SourceCodeLine = 1100;
                    ushort __FN_FORSTART_VAL__7 = (ushort) ( 4 ) ;
                    ushort __FN_FOREND_VAL__7 = (ushort)6; 
                    int __FN_FORSTEP_VAL__7 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                        {
                        __context__.SourceCodeLine = 1100;
                        ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1100;
                        }
                    
                    __context__.SourceCodeLine = 1101;
                    FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                    __context__.SourceCodeLine = 1096;
                    } 
                
                } 
            
            } 
            
        }
        
    
    __context__.SourceCodeLine = 1106;
    ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__8 = (ushort)2; 
    int __FN_FORSTEP_VAL__8 = (int)1; 
    for ( IROOM  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__8) && (IROOM  <= __FN_FOREND_VAL__8) ) : ( (IROOM  <= __FN_FORSTART_VAL__8) && (IROOM  >= __FN_FOREND_VAL__8) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__8) 
        { 
        __context__.SourceCodeLine = 1108;
        ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__9 = (ushort)2; 
        int __FN_FORSTEP_VAL__9 = (int)1; 
        for ( ILIST  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__9) && (ILIST  <= __FN_FOREND_VAL__9) ) : ( (ILIST  <= __FN_FORSTART_VAL__9) && (ILIST  >= __FN_FOREND_VAL__9) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__9) 
            { 
            __context__.SourceCodeLine = 1110;
            ushort __FN_FORSTART_VAL__10 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__10 = (ushort)50; 
            int __FN_FORSTEP_VAL__10 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__10; (__FN_FORSTEP_VAL__10 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__10) && (IINDEX  <= __FN_FOREND_VAL__10) ) : ( (IINDEX  <= __FN_FORSTART_VAL__10) && (IINDEX  >= __FN_FOREND_VAL__10) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__10) 
                { 
                __context__.SourceCodeLine = 1112;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM ) || Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1114;
                    FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    __context__.SourceCodeLine = 1115;
                    FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    } 
                
                __context__.SourceCodeLine = 1110;
                } 
            
            __context__.SourceCodeLine = 1119;
            FCONFIGURELISTTEXTRMNUMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1120;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1108;
            } 
        
        __context__.SourceCodeLine = 1106;
        } 
    
    
    }
    
private void FUPDATERC_STATE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1135;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1137;
        if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1139;
            RC_OFF_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1140;
            RC_ON_FB [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1145;
            RC_ON_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1146;
            RC_OFF_FB [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        __context__.SourceCodeLine = 1135;
        } 
    
    
    }
    
private void FUPDATERC_ENABLE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 1155;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1157;
        if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1159;
            PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1160;
            PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1164;
            PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1165;
            PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        __context__.SourceCodeLine = 1155;
        } 
    
    
    }
    
private void FPROCESSFINALIZE (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
    { 
    ushort IOTHERROOM = 0;
    ushort I = 0;
    ushort J = 0;
    
    
    __context__.SourceCodeLine = 1181;
    FUPDATELISTNUMOFITEMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST )) ; 
    __context__.SourceCodeLine = 1183;
    
        {
        int __SPLS_TMPVAR__SWTCH_10__ = ((int)ILIST);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 1) ) ) ) 
                { 
                __context__.SourceCodeLine = 1198;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)3; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1200;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1201;
                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                    __context__.SourceCodeLine = 1204;
                    if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1206;
                        ROOM [ IROOM] . LIST [ 1] . ITEM [ (I + 6)] . IISRCITEM = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1207;
                        FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 6) ), (ushort)( ILIST )) ; 
                        __context__.SourceCodeLine = 1208;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 6) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1198;
                    } 
                
                __context__.SourceCodeLine = 1213;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)3; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    {
                    __context__.SourceCodeLine = 1214;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 3)] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 3) ].IVLINK ) ; 
                    __context__.SourceCodeLine = 1213;
                    }
                
                __context__.SourceCodeLine = 1217;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 10 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)20; 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 1219;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1221;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1222;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1217;
                    } 
                
                __context__.SourceCodeLine = 1227;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)3; 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                    { 
                    __context__.SourceCodeLine = 1229;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 20) ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1231;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1232;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                        __context__.SourceCodeLine = 1235;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1237;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1238;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 20) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 23) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1239;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 23) )) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 1227;
                    } 
                
                __context__.SourceCodeLine = 1245;
                ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__5 = (ushort)10; 
                int __FN_FORSTEP_VAL__5 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                    { 
                    __context__.SourceCodeLine = 1247;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 30) ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1249;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 30)] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1250;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 30) )) ; 
                        __context__.SourceCodeLine = 1253;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1255;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1256;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 30) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 40) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1257;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 40) )) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 1245;
                    } 
                
                __context__.SourceCodeLine = 1263;
                ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__6 = (ushort)50; 
                int __FN_FORSTEP_VAL__6 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                    { 
                    __context__.SourceCodeLine = 1265;
                    if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1266;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 1263;
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 2) ) ) ) 
                { 
                __context__.SourceCodeLine = 1272;
                if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1287;
                    ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__7 = (ushort)20; 
                    int __FN_FORSTEP_VAL__7 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                        { 
                        __context__.SourceCodeLine = 1289;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1291;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1292;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                            __context__.SourceCodeLine = 1295;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 20) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1296;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1299;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IISRCITEM = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1287;
                        } 
                    
                    __context__.SourceCodeLine = 1303;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 41 ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1305;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 41] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1306;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 41 )) ; 
                        __context__.SourceCodeLine = 1309;
                        FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 41 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 42 ), (ushort)( ILIST )) ; 
                        __context__.SourceCodeLine = 1310;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 42 )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1312;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 42] . IISRCITEM = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1316;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 49 ].IITEMACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1318;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 49] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1319;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 49 )) ; 
                        __context__.SourceCodeLine = 1322;
                        FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 49 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 50 ), (ushort)( ILIST )) ; 
                        __context__.SourceCodeLine = 1323;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 50 )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1325;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 50] . IISRCITEM = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1331;
                    ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__8 = (ushort)50; 
                    int __FN_FORSTEP_VAL__8 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                        { 
                        __context__.SourceCodeLine = 1334;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1336;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1337;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1340;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 1331;
                        } 
                    
                    } 
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 14) ) ) ) 
                { 
                __context__.SourceCodeLine = 1348;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 2))  ) ) 
                    {
                    __context__.SourceCodeLine = 1348;
                    CreateWait ( "__SPLS_TMPVAR__WAITLABEL_35__" , 1000 , __SPLS_TMPVAR__WAITLABEL_35___Callback ) ;
                    }
                
                } 
            
            } 
            
        }
        
    
    __context__.SourceCodeLine = 1369;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ILIST <= 5 ))  ) ) 
        { 
        __context__.SourceCodeLine = 1371;
        FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1372;
        FUPDATELISTALL (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1374;
        FCONFIGURELISTVIS (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1375;
        FUPDATELISTALL (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        } 
    
    
    }
    
public void __SPLS_TMPVAR__WAITLABEL_35___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            ushort I = 0;
            
            __context__.SourceCodeLine = 1351;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1353;
                SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1354;
                SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
                __context__.SourceCodeLine = 1355;
                ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__9 = (ushort)2; 
                int __FN_FORSTEP_VAL__9 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (I  >= __FN_FORSTART_VAL__9) && (I  <= __FN_FOREND_VAL__9) ) : ( (I  <= __FN_FORSTART_VAL__9) && (I  >= __FN_FOREND_VAL__9) ) ; I  += (ushort)__FN_FORSTEP_VAL__9) 
                    { 
                    __context__.SourceCodeLine = 1357;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1358;
                    RC_OFF_FB [ I]  .Value = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
                    __context__.SourceCodeLine = 1359;
                    RC_ON_FB [ I]  .Value = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
                    __context__.SourceCodeLine = 1355;
                    } 
                
                __context__.SourceCodeLine = 1361;
                FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                } 
            
            __context__.SourceCodeLine = 1363;
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
    
    
    __context__.SourceCodeLine = 1388;
    STEMPDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1389;
    STEMPGUID  .UpdateValue ( Functions.Remove ( "," , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1390;
    STEMPSRC  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (Functions.Find( "," , STEMPDATA ) - 1) ) )  ) ; 
    __context__.SourceCodeLine = 1391;
    STRASH  .UpdateValue ( Functions.Remove ( "src_name=" , STEMPSRC )  ) ; 
    __context__.SourceCodeLine = 1394;
    ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
    __context__.SourceCodeLine = 1395;
    ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
    __context__.SourceCodeLine = 1396;
    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1397;
    FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1400;
    if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
        { 
        __context__.SourceCodeLine = 1402;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX <= 20 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1404;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1405;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
            __context__.SourceCodeLine = 1406;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1407;
            FUPDATELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            } 
        
        } 
    
    
    }
    
private ushort FPROCESSMACROOBJECT (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , CrestronString SDATA ) 
    { 
    
    __context__.SourceCodeLine = 1416;
    if ( Functions.TestForTrue  ( ( Functions.Find( "*" , SDATA ))  ) ) 
        {
        __context__.SourceCodeLine = 1416;
        ROOM [ IROOM] . MACRO [ IMACRO] . IPRIMARYOBJECT = (ushort) ( Functions.Atoi( SDATA ) ) ; 
        }
    
    __context__.SourceCodeLine = 1417;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Atoi( SDATA ) ) || Functions.TestForTrue ( Functions.Find( "0" , SDATA ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1419;
        ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( (ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS + 1) ) ; 
        __context__.SourceCodeLine = 1420;
        ROOM [ IROOM] . MACRO [ IMACRO] . ILIST [ ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS] = (ushort) ( Functions.Atoi( SDATA ) ) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1422;
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
    
    
    __context__.SourceCodeLine = 1432;
    SDATA  .UpdateValue ( SLINE  ) ; 
    __context__.SourceCodeLine = 1434;
    ROOM [ IROOM] . MACRO [ IMACRO] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1435;
    ROOM [ IROOM] . MACRO [ IMACRO] . IMACROTYPE = (ushort) ( FGETMACROTYPE( __context__ , (ushort)( IMACRO ) ) ) ; 
    __context__.SourceCodeLine = 1436;
    ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1437;
    while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1439;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
        __context__.SourceCodeLine = 1441;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1443;
            ROOM [ IROOM] . MACRO [ IMACRO] . SNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "," , SDATA ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 1444;
            STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1446;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1446;
                ROOM [ IROOM] . MACRO [ IMACRO] . IUSB = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1447;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1447;
                    ROOM [ IROOM] . MACRO [ IMACRO] . IPGMAUDIO = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1448;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1450;
                        STEMP  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 1451;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMP ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1452;
                            FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), Functions.Remove( "," , STEMP )) ; 
                            __context__.SourceCodeLine = 1451;
                            }
                        
                        __context__.SourceCodeLine = 1453;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 1 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1454;
                            FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), STEMP) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1456;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "special_func" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1456;
                            ROOM [ IROOM] . MACRO [ IMACRO] . ISPECIALFUNCTION = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                            }
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1459;
                            Trace( "NodeMST - fProcessMacro - error parsing macro, {0}", SLINE ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1437;
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
    
    
    __context__.SourceCodeLine = 1476;
    STEMPLINE  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1479;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1480;
    ROOM [ IROOM] . LIST [ ILIST] . IMAXNUMITEMS = (ushort) ( Functions.Max( IINDEX , ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ) ; 
    __context__.SourceCodeLine = 1483;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1485;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1486;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1487;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1489;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1489;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1490;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1490;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1491;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1491;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1492;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1492;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1493;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1493;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1494;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1494;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1495;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_localid" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1495;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1496;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_global" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1496;
                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1498;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1498;
                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1499;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_localid" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1499;
                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1500;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_global" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1500;
                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1501;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "virtual" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1501;
                                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1502;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_usb" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1502;
                                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISUSB = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1503;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1503;
                                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IPGMAUDIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                { 
                                                                __context__.SourceCodeLine = 1507;
                                                                Trace( "NodeMST - fProcessLine - didn't catch key:   GUID={0:d}, {1}{2}", (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                                                __context__.SourceCodeLine = 1508;
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
        
        __context__.SourceCodeLine = 1483;
        } 
    
    __context__.SourceCodeLine = 1512;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID)  ) ) 
        {
        __context__.SourceCodeLine = 1512;
        ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID] = (ushort) ( IINDEX ) ; 
        }
    
    __context__.SourceCodeLine = 1514;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
        { 
        __context__.SourceCodeLine = 1517;
        ICAM = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMLOCALID ) ; 
        __context__.SourceCodeLine = 1519;
        ROOM [ IROOM] . CAM [ ICAM] . ICAMGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMGUID ) ; 
        __context__.SourceCodeLine = 1520;
        ROOM [ IROOM] . CAM [ ICAM] . ICAMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1521;
        ROOM [ IROOM] . CAM [ ICAM] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1522;
        ROOM [ IROOM] . CAM [ ICAM] . IVSRCLOCALID = (ushort) ( IINDEX ) ; 
        __context__.SourceCodeLine = 1523;
        ROOM [ IROOM] . CAM [ ICAM] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
        __context__.SourceCodeLine = 1524;
        ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
        __context__.SourceCodeLine = 1525;
        ROOM [ IROOM] . CAM [ ICAM] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
        __context__.SourceCodeLine = 1527;
        ROOM [ IROOM] . CAM [ ICAM] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
        __context__.SourceCodeLine = 1529;
        MakeString ( CAM_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)ICAM, (ushort)ICAM, ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
        __context__.SourceCodeLine = 1531;
        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
            { 
            __context__.SourceCodeLine = 1533;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1534;
            MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(ICAM + 3), ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
            __context__.SourceCodeLine = 1536;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 1538;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVIS = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1539;
                MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(ICAM + 3)) ; 
                } 
            
            __context__.SourceCodeLine = 1541;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].ICAMGUID ) ; 
            __context__.SourceCodeLine = 1542;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1545;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
            { 
            __context__.SourceCodeLine = 1548;
            IDISPLAY = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYLOCALID ) ; 
            __context__.SourceCodeLine = 1549;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYGUID ) ; 
            __context__.SourceCodeLine = 1550;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1551;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1552;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTLOCALID = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1553;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 1554;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 1555;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 1557;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
            __context__.SourceCodeLine = 1559;
            MakeString ( DISPLAY_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)IDISPLAY, (ushort)IDISPLAY, ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
            __context__.SourceCodeLine = 1562;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1564;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1566;
                MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(IDISPLAY + (40 / 2)), ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                __context__.SourceCodeLine = 1568;
                if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1570;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVIS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1571;
                    MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(IDISPLAY + (40 / 2))) ; 
                    } 
                
                __context__.SourceCodeLine = 1573;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1574;
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
    
    
    __context__.SourceCodeLine = 1583;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1585;
    if ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1587;
        ROOM [ IROOM] . IROOMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1588;
        ROOM [ IROOM] . IROOMGUID = (ushort) ( IGLOBALROOMNUM ) ; 
        } 
    
    __context__.SourceCodeLine = 1590;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IROOM == 2) ) && Functions.TestForTrue ( ROOM[ IROOM ].IROOMGUID )) ))  ) ) 
        {
        __context__.SourceCodeLine = 1590;
        SYS . IISRCPAIR = (ushort) ( 1 ) ; 
        }
    
    __context__.SourceCodeLine = 1592;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1594;
        STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
        __context__.SourceCodeLine = 1595;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
        __context__.SourceCodeLine = 1596;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1596;
            ROOM [ IROOM] . SROOMNAME  .UpdateValue ( ST . StringTrim (  Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) )  .ToSimplSharpString() )  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1597;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_num" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1597;
                ROOM [ IROOM] . IBLDGROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1598;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1598;
                    ROOM [ IROOM] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1599;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1599;
                        ROOM [ IROOM] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1592;
        } 
    
    __context__.SourceCodeLine = 1602;
    ROOMNAME__DOLLAR___OUT [ IROOM]  .UpdateValue ( ROOM [ IROOM] . SROOMNAME  ) ; 
    __context__.SourceCodeLine = 1603;
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
    
    
    __context__.SourceCodeLine = 1613;
    Trace( "in fProcessVLink - iRoom = {0:d}, iLocalIndex = {1:d}, sData = {2}", (ushort)IROOM, (ushort)ILOCALINDEX, STEMPLINE ) ; 
    __context__.SourceCodeLine = 1614;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1615;
    IVLINK = (ushort) ( Functions.Atoi( SDATA ) ) ; 
    __context__.SourceCodeLine = 1616;
    STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
    __context__.SourceCodeLine = 1618;
    
        {
        int __SPLS_TMPVAR__SWTCH_11__ = ((int)ITYPE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 15) ) ) ) 
                {
                __context__.SourceCodeLine = 1620;
                ILIST = (ushort) ( 1 ) ; 
                }
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 16) ) ) ) 
                {
                __context__.SourceCodeLine = 1621;
                ILIST = (ushort) ( 2 ) ; 
                }
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 17) ) ) ) 
                {
                __context__.SourceCodeLine = 1622;
                ILIST = (ushort) ( 3 ) ; 
                }
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 18) ) ) ) 
                {
                __context__.SourceCodeLine = 1623;
                ILIST = (ushort) ( 4 ) ; 
                }
            
            } 
            
        }
        
    
    __context__.SourceCodeLine = 1626;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IISVIRTUAL)  ) ) 
        { 
        __context__.SourceCodeLine = 1628;
        IOLDGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IVLINK ) ; 
        __context__.SourceCodeLine = 1631;
        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVLINK = (ushort) ( IVLINK ) ; 
        __context__.SourceCodeLine = 1632;
        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IGUID = (ushort) ( IVLINK ) ; 
        __context__.SourceCodeLine = 1633;
        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SGLOBALNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "|" , SDATA ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1634;
        ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ IVLINK] = (ushort) ( ILOCALINDEX ) ; 
        __context__.SourceCodeLine = 1637;
        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1638;
        FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1640;
        FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1641;
        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1644;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IOLDGUID ) && Functions.TestForTrue ( Functions.BoolToInt (IOLDGUID != IVLINK) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1646;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1648;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IROUTEDSRC == IOLDGUID))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1650;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( IVLINK )) ; 
                    } 
                
                __context__.SourceCodeLine = 1646;
                } 
            
            } 
        
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 1657;
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
    
    
    __context__.SourceCodeLine = 1673;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1675;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1677;
    ITYPE = (ushort) ( Functions.Atoi( STEMPHEADER ) ) ; 
    __context__.SourceCodeLine = 1679;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1681;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1682;
        if ( Functions.TestForTrue  ( ( Functions.Find( "COMPLETE" , STEMPLINE ))  ) ) 
            {
            __context__.SourceCodeLine = 1682;
            FPROCESSFINALIZE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 1686;
            if ( Functions.TestForTrue  ( ( Functions.Find( ";" , STEMPLINE ))  ) ) 
                {
                __context__.SourceCodeLine = 1686;
                STRASH  .UpdateValue ( Functions.Remove ( ";" , STEMPLINE )  ) ; 
                }
            
            __context__.SourceCodeLine = 1687;
            ILOCALINDEX = (ushort) ( Functions.Atoi( Functions.Remove( ":" , STEMPLINE ) ) ) ; 
            __context__.SourceCodeLine = 1689;
            if ( Functions.TestForTrue  ( ( ILOCALINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1691;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITYPE <= 4 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1691;
                    FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1692;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 10))  ) ) 
                        {
                        __context__.SourceCodeLine = 1692;
                        FPROCESSVROUTE (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1693;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
                            {
                            __context__.SourceCodeLine = 1693;
                            FPROCESSMACRO (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1694;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 1694;
                                FPROCESSROOMS (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1695;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 15))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1695;
                                    FPROCESSVLINK (  __context__ , (ushort)( ITYPE ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1696;
                                    Trace( "NodeMST - fProcessData - didn't catch iLocalIndex") ; 
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1698;
                Trace( "NodeMST - fProcessData - iLocalIndex=0.    {0} iLocalID={1:d};{2}", STEMPHEADER , (ushort)ILOCALINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1679;
        } 
    
    
    }
    
private void FMACROTYPESELECTOR (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
    { 
    
    __context__.SourceCodeLine = 1721;
    Trace( "fMacroBase, iRoom={0:d}, iMacro={1:d}, iState={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE) ; 
    __context__.SourceCodeLine = 1723;
    MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
    __context__.SourceCodeLine = 1724;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].ISPECIALFUNCTION)  ) ) 
        {
        __context__.SourceCodeLine = 1725;
        FRUNMACROSPECIALFUNCTION (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
        }
    
    else 
        { 
        __context__.SourceCodeLine = 1728;
        
            {
            int __SPLS_TMPVAR__SWTCH_12__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 01) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1730;
                    FRUNMACROMTRX (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 02) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 03) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 04) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 05) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1734;
                    FRUNMACRODISPLAYCTRL (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 06) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 11) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 12) ) ) ) 
                    { 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1738;
                    Trace( "NodeMST - fMacroTypeSelector - didn't catch iMacroType index. iRoom={0:d}, iMacro={1:d}, iMacroType={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE) ; 
                    }
                
                } 
                
            }
            
        
        } 
    
    
    }
    
private ushort FMACROSYSTEM (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
    { 
    ushort IINDEX = 0;
    ushort ISUBMACRO = 0;
    
    
    __context__.SourceCodeLine = 1752;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1754;
        ISUBMACRO = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IINDEX ] ) ; 
        __context__.SourceCodeLine = 1755;
        FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( ISUBMACRO ), (ushort)( ISTATE )) ; 
        __context__.SourceCodeLine = 1752;
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
        
        
        __context__.SourceCodeLine = 1771;
        SYS . IRCSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1772;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1773;
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
        
        
        __context__.SourceCodeLine = 1780;
        SYS . IRCSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1781;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1782;
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
        
        
        __context__.SourceCodeLine = 1789;
        SYS . IRCSTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 1790;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 1791;
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
        
        
        __context__.SourceCodeLine = 1799;
        if ( Functions.TestForTrue  ( ( SYS.IPARTITIONENABLED)  ) ) 
            { 
            __context__.SourceCodeLine = 1801;
            SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
            __context__.SourceCodeLine = 1803;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1804;
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
        
        
        __context__.SourceCodeLine = 1812;
        SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1814;
        FUPDATERC_ENABLE_FB (  __context__ , (ushort)( SYS.IPARTITIONENABLED )) ; 
        __context__.SourceCodeLine = 1816;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) != SYS.IRCSTATE))  ) ) 
            { 
            __context__.SourceCodeLine = 1818;
            SYS . IRCSTATE = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
            __context__.SourceCodeLine = 1819;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 1820;
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
        
        
        __context__.SourceCodeLine = 1827;
        SYS . IPARTITIONENABLED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1829;
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
        
        
        __context__.SourceCodeLine = 1835;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1837;
        Functions.Pulse ( 10, SYS_POWERON_GO [ IROOM] ) ; 
        __context__.SourceCodeLine = 1838;
        ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1840;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
        __context__.SourceCodeLine = 1843;
        if ( Functions.TestForTrue  ( ( Functions.Not( SYS.IRCSTATE ))  ) ) 
            {
            __context__.SourceCodeLine = 1844;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 57 ), (ushort)( 2 )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 1848;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 59 ), (ushort)( 2 )) ; 
            __context__.SourceCodeLine = 1850;
            Functions.Pulse ( 10, SYS_POWERON_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 1851;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1853;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1854;
            FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 59 ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) )) ; 
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
        
        
        __context__.SourceCodeLine = 1861;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1863;
        Functions.Pulse ( 10, SYS_POWEROFF_GO [ IROOM] ) ; 
        __context__.SourceCodeLine = 1864;
        ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1866;
        ROOM [ IROOM] . ILASTSRCSEL [ 3 , 1] = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1869;
        if ( Functions.TestForTrue  ( ( Functions.Not( SYS.IRCSTATE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1871;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 58 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1872;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1876;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ILASTSRCSEL [ 3 , 1] = (ushort) ( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) ) ; 
            __context__.SourceCodeLine = 1879;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 60 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1881;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 1882;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1883;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) , (ushort)( 60 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1886;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 1887;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
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
        
        
        __context__.SourceCodeLine = 1903;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1904;
        ISYSPRESET = (ushort) ( SYS_PRESET[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1906;
        if ( Functions.TestForTrue  ( ( ISYSPRESET)  ) ) 
            { 
            __context__.SourceCodeLine = 1908;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1910;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1912;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == ISYSPRESET) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == 9) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1914;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 1 )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1918;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1908;
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
        
        
        __context__.SourceCodeLine = 1932;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1934;
        ISRC = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED ) ; 
        __context__.SourceCodeLine = 1935;
        if ( Functions.TestForTrue  ( ( FGETNUMITEMSSELECTED( __context__ , (ushort)( IROOM ) , (ushort)( 2 ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1937;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ 2 ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1939;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1941;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
                    } 
                
                __context__.SourceCodeLine = 1937;
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
        
        
        __context__.SourceCodeLine = 1952;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1954;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1955;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1957;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1958;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1960;
        ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1961;
        ROOM [ IROOM] . LIST [ 2] . INUMOFITEMSSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1963;
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
        
        
        __context__.SourceCodeLine = 1970;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1972;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 1973;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1975;
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
        
        
        __context__.SourceCodeLine = 1981;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1982;
        IINDEX = (ushort) ( MTRX_ADMINVSRC_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 1984;
        if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1986;
            
                {
                int __SPLS_TMPVAR__SWTCH_13__ = ((int)ROOM[ IROOM ].IUI_PAGE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1991;
                        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
                        __context__.SourceCodeLine = 1992;
                        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1997;
                        ROOM [ IROOM] . ILASTSRCSEL [ 4 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID ) ; 
                        __context__.SourceCodeLine = 1998;
                        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
                        __context__.SourceCodeLine = 2001;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED)  ) ) 
                            { 
                            __context__.SourceCodeLine = 2003;
                            ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED] . IFB = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 2004;
                            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 2006;
                        ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( IINDEX ) ; 
                        __context__.SourceCodeLine = 2007;
                        ROOM [ IROOM] . LIST [ 1] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 2008;
                        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
                        } 
                    
                    } 
                    
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
        
        
        __context__.SourceCodeLine = 2017;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2018;
        IINDEX = (ushort) ( MTRX_ADMINVDST_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2021;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IINDEX ].IFB ) ) ; 
        __context__.SourceCodeLine = 2022;
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
        
        
        __context__.SourceCodeLine = 2029;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2030;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2031;
        ISRC = (ushort) ( MTRX_MACRO1_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2033;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2034;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2036;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2038;
            ISRC = (ushort) ( FOTHERROOMSRCNUM( __context__ , (ushort)( ISRC ) ) ) ; 
            __context__.SourceCodeLine = 2039;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2040;
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
        
        
        __context__.SourceCodeLine = 2047;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2048;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2049;
        ISRC = (ushort) ( MTRX_MACRO2_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2051;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2052;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2054;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2056;
            ISRC = (ushort) ( FOTHERROOMSRCNUM( __context__ , (ushort)( ISRC ) ) ) ; 
            __context__.SourceCodeLine = 2057;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2058;
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
        ushort IMACRO = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 2066;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2067;
        IMACRO = (ushort) ( MTRX_MACRO1_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2069;
        MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
        __context__.SourceCodeLine = 2070;
        
            {
            int __SPLS_TMPVAR__SWTCH_14__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 07) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 08) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 09) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 10) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 11) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2077;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 2 )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 12) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2078;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2079;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE )) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2082;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2084;
            MTRX_MACRO_DST_FB [ FOTHERROOM( __context__ , (ushort)( IROOM ) )]  .Value = (ushort) ( IMACRO ) ; 
            __context__.SourceCodeLine = 2086;
            
                {
                int __SPLS_TMPVAR__SWTCH_15__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 07) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 08) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 09) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 10) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 11) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2093;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2094;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 2095;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE ) ) )) ; 
                        }
                    
                    } 
                    
                }
                
            
            } 
        
        
        
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
        ushort IMACRO = 0;
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 2102;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2103;
        IMACRO = (ushort) ( MTRX_MACRO2_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2105;
        MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
        __context__.SourceCodeLine = 2107;
        
            {
            int __SPLS_TMPVAR__SWTCH_16__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 07) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 08) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 09) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 10) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 11) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2114;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 2 )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 12) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2115;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2116;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE )) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2120;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2122;
            MTRX_MACRO_DST_FB [ FOTHERROOM( __context__ , (ushort)( IROOM ) )]  .Value = (ushort) ( IMACRO ) ; 
            __context__.SourceCodeLine = 2124;
            
                {
                int __SPLS_TMPVAR__SWTCH_17__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 07) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 08) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 09) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 10) ) ) ) 
                        { 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 11) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2131;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_17__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2132;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 2133;
                        FMACROTYPESELECTOR (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE ) ) )) ; 
                        }
                    
                    } 
                    
                }
                
            
            } 
        
        
        
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
        
        __context__.SourceCodeLine = 2147;
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
        
        __context__.SourceCodeLine = 2151;
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
        
        __context__.SourceCodeLine = 2155;
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
        
        __context__.SourceCodeLine = 2159;
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
        
        __context__.SourceCodeLine = 2163;
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
        
        __context__.SourceCodeLine = 2167;
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
        
        __context__.SourceCodeLine = 2171;
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
        
        __context__.SourceCodeLine = 2175;
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
        
        __context__.SourceCodeLine = 2180;
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
        
        __context__.SourceCodeLine = 2185;
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
        
        
        __context__.SourceCodeLine = 2193;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2194;
        ROOM [ IROOM] . ICAMSEL = (ushort) ( CAM_SELECT[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2196;
        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
        __context__.SourceCodeLine = 2198;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 2200;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].IVSRCGUID )) ; 
            __context__.SourceCodeLine = 2201;
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
    
    
    __context__.SourceCodeLine = 2215;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPAGE ) && Functions.TestForTrue ( ISUB )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2217;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ILASTSRCSEL[ IPAGE , ISUB ])  ) ) 
            { 
            __context__.SourceCodeLine = 2219;
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
        
        
        __context__.SourceCodeLine = 2227;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2229;
        ROOM [ IROOM] . IUI_PAGE = (ushort) ( UI_PAGE[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2231;
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
        
        
        __context__.SourceCodeLine = 2237;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2239;
        ROOM [ IROOM] . IUI_SUB = (ushort) ( UI_SUB[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2241;
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
        
        
        __context__.SourceCodeLine = 2255;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2257;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2258;
            FPROCESSDATA (  __context__ , (ushort)( 1 ), STEMP) ; 
            __context__.SourceCodeLine = 2255;
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
        
        
        __context__.SourceCodeLine = 2266;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2268;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2269;
            FPROCESSDATA (  __context__ , (ushort)( 2 ), STEMP) ; 
            __context__.SourceCodeLine = 2266;
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
        
        __context__.SourceCodeLine = 2280;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2282;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2284;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)2; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( L  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (L  >= __FN_FORSTART_VAL__2) && (L  <= __FN_FOREND_VAL__2) ) : ( (L  <= __FN_FORSTART_VAL__2) && (L  >= __FN_FOREND_VAL__2) ) ; L  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 2286;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)6; 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 2288;
                    ROOM [ I] . LIST [ L] . ITEM [ J] . IISVIRTUAL = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 2286;
                    } 
                
                __context__.SourceCodeLine = 2284;
                } 
            
            __context__.SourceCodeLine = 2282;
            } 
        
        __context__.SourceCodeLine = 2293;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)2; 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 2295;
            ROOM [ I] . LIST [ 1] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2296;
            ROOM [ I] . LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2297;
            ROOM [ I] . LIST [ 1] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2298;
            ROOM [ I] . LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2299;
            ROOM [ I] . LIST [ 1] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2300;
            ROOM [ I] . LIST [ 1] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2302;
            ROOM [ I] . LIST [ 2] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2303;
            ROOM [ I] . LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 2304;
            ROOM [ I] . LIST [ 2] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2305;
            ROOM [ I] . LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2306;
            ROOM [ I] . LIST [ 2] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2307;
            ROOM [ I] . LIST [ 2] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2309;
            ROOM [ I] . LIST [ 3] . IMAXNUMITEMS = (ushort) ( 24 ) ; 
            __context__.SourceCodeLine = 2310;
            ROOM [ I] . LIST [ 3] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2311;
            ROOM [ I] . LIST [ 3] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2312;
            ROOM [ I] . LIST [ 3] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2313;
            ROOM [ I] . LIST [ 3] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2314;
            ROOM [ I] . LIST [ 3] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2316;
            ROOM [ I] . LIST [ 4] . IMAXNUMITEMS = (ushort) ( 15 ) ; 
            __context__.SourceCodeLine = 2317;
            ROOM [ I] . LIST [ 4] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2318;
            ROOM [ I] . LIST [ 4] . ILISTUSESFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2319;
            ROOM [ I] . LIST [ 4] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2320;
            ROOM [ I] . LIST [ 4] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2321;
            ROOM [ I] . LIST [ 4] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2323;
            ROOM [ I] . LIST [ 5] . IMAXNUMITEMS = (ushort) ( 9 ) ; 
            __context__.SourceCodeLine = 2324;
            ROOM [ I] . LIST [ 5] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2325;
            ROOM [ I] . LIST [ 5] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2326;
            ROOM [ I] . LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2327;
            ROOM [ I] . LIST [ 5] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2328;
            ROOM [ I] . LIST [ 5] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2330;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)9; 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                { 
                __context__.SourceCodeLine = 2332;
                ROOM [ I] . LIST [ 5] . ITEM [ J] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2333;
                ROOM [ I] . LIST [ 5] . ITEM [ (J + 20)] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2330;
                } 
            
            __context__.SourceCodeLine = 2293;
            } 
        
        __context__.SourceCodeLine = 2338;
        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__6 = (ushort)2; 
        int __FN_FORSTEP_VAL__6 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
            { 
            __context__.SourceCodeLine = 2342;
            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__7 = (ushort)10; 
            int __FN_FORSTEP_VAL__7 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (J  >= __FN_FORSTART_VAL__7) && (J  <= __FN_FOREND_VAL__7) ) : ( (J  <= __FN_FORSTART_VAL__7) && (J  >= __FN_FOREND_VAL__7) ) ; J  += (ushort)__FN_FORSTEP_VAL__7) 
                {
                __context__.SourceCodeLine = 2343;
                ROOM [ I] . CAM [ J] . IVSRCLOCALID = (ushort) ( (J + 20) ) ; 
                __context__.SourceCodeLine = 2342;
                }
            
            __context__.SourceCodeLine = 2344;
            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__8 = (ushort)40; 
            int __FN_FORSTEP_VAL__8 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (J  >= __FN_FORSTART_VAL__8) && (J  <= __FN_FOREND_VAL__8) ) : ( (J  <= __FN_FORSTART_VAL__8) && (J  >= __FN_FOREND_VAL__8) ) ; J  += (ushort)__FN_FORSTEP_VAL__8) 
                {
                __context__.SourceCodeLine = 2345;
                ROOM [ I] . DISPLAY [ J] . IVDSTLOCALID = (ushort) ( J ) ; 
                __context__.SourceCodeLine = 2344;
                }
            
            __context__.SourceCodeLine = 2338;
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
    
    MTRX_MACRO_DST_FB = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MTRX_MACRO_DST_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MTRX_MACRO_DST_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MTRX_MACRO_DST_FB__AnalogSerialOutput__ + i, MTRX_MACRO_DST_FB[i+1] );
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
    
    __SPLS_TMPVAR__WAITLABEL_33___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_33___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_34___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_34___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_35___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_35___CallbackFn );
    
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


private WaitFunction __SPLS_TMPVAR__WAITLABEL_33___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_34___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_35___Callback;


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
const uint MTRX_MACRO_DST_FB__AnalogSerialOutput__ = 2;
const uint MTRX_MACRO1_SRC_FB__AnalogSerialOutput__ = 4;
const uint MTRX_MACRO2_SRC_FB__AnalogSerialOutput__ = 9;
const uint MTRX_ADMINVSRC_NUMOFITEMS__AnalogSerialOutput__ = 14;
const uint MTRX_ADMINVDST_NUMOFITEMS__AnalogSerialOutput__ = 16;
const uint DSP_MICS_NUMOFITEMS__AnalogSerialOutput__ = 18;
const uint DSP_LINE_NUMOFITEMS__AnalogSerialOutput__ = 20;
const uint TO_MST_TX__DOLLAR____AnalogSerialOutput__ = 22;
const uint TO_DSP_TX__DOLLAR____AnalogSerialOutput__ = 24;
const uint MTRX_ADMINVSRC_FB__DOLLAR____AnalogSerialOutput__ = 26;
const uint MTRX_ADMINVDST_FB__DOLLAR____AnalogSerialOutput__ = 28;
const uint DSP_MICS_FB__DOLLAR____AnalogSerialOutput__ = 30;
const uint DSP_LINE_FB__DOLLAR____AnalogSerialOutput__ = 32;
const uint CAM_FB__DOLLAR____AnalogSerialOutput__ = 34;
const uint CAM_PRESETS_FB__DOLLAR____AnalogSerialOutput__ = 36;
const uint DISPLAY_FB__DOLLAR____AnalogSerialOutput__ = 38;
const uint MTRX_MACRO_SRC_FB__DOLLAR____AnalogSerialOutput__ = 40;
const uint MTRX_MACRO_DST_FB__DOLLAR____AnalogSerialOutput__ = 42;
const uint ROOMNAME__DOLLAR___OUT__AnalogSerialOutput__ = 44;

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
    
    [SplusStructAttribute(11, false, false)]
    public ushort  ISPECIALFUNCTION = 0;
    
    
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
        MACRO  = new STMACRO[ 81 ];
        for( uint i = 0; i < 81; i++ )
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
