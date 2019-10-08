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

namespace UserModule_L3_UA_HSIB_NODEMST_V1_0_83
{
    public class UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_83 : SplusObject
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
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_MST_TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_ADMINVSRC_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MTRX_ADMINVDST_FB__DOLLAR__;
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
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 30 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 373;
                            return (ushort)( 4) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 374;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 40 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 374;
                                return (ushort)( 5) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 375;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 56 ))  ) ) 
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
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 70 ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 380;
                                                        return (ushort)( 11) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 381;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 80 ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 381;
                                                            return (ushort)( 12) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 382;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 100 ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 382;
                                                                return (ushort)( 1) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 383;
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
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FGETNUMITEMSSELECTED (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            ushort I = 0;
            ushort ICOUNT = 0;
            
            
            __context__.SourceCodeLine = 390;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 392;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 392;
                    ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 390;
                } 
            
            __context__.SourceCodeLine = 395;
            return (ushort)( ICOUNT) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 400;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private ushort FOTHERROOMSRCNUM (  SplusExecutionContext __context__, ushort ISRC ) 
            { 
            
            __context__.SourceCodeLine = 405;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 10 ))  ) ) 
                { 
                __context__.SourceCodeLine = 407;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)ISRC);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 409;
                            return (ushort)( 7) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 410;
                            return (ushort)( 8) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                            {
                            __context__.SourceCodeLine = 411;
                            return (ushort)( 9) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                            {
                            __context__.SourceCodeLine = 412;
                            return (ushort)( 4) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                            {
                            __context__.SourceCodeLine = 413;
                            return (ushort)( 5) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                            {
                            __context__.SourceCodeLine = 414;
                            return (ushort)( 6) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                            {
                            __context__.SourceCodeLine = 415;
                            return (ushort)( 1) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                            {
                            __context__.SourceCodeLine = 416;
                            return (ushort)( 2) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                            {
                            __context__.SourceCodeLine = 417;
                            return (ushort)( 3) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 420;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 20 ))  ) ) 
                    { 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 424;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 30 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 426;
                        
                            {
                            int __SPLS_TMPVAR__SWTCH_2__ = ((int)ISRC);
                            
                                { 
                                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 21) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 428;
                                    return (ushort)( 24) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 22) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 429;
                                    return (ushort)( 25) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 23) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 430;
                                    return (ushort)( 26) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 24) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 431;
                                    return (ushort)( 21) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 25) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 432;
                                    return (ushort)( 22) ; 
                                    }
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 26) ) ) ) 
                                    {
                                    __context__.SourceCodeLine = 433;
                                    return (ushort)( 23) ; 
                                    }
                                
                                } 
                                
                            }
                            
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 436;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 40 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 437;
                            return (ushort)( (ISRC + 10)) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 438;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISRC <= 50 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 439;
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
            
            __context__.SourceCodeLine = 445;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IITEMACTIVE = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IITEMACTIVE ) ; 
            __context__.SourceCodeLine = 446;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SGLOBALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 447;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SLOCALNAME  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 448;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IRMASS = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IRMASS ) ; 
            __context__.SourceCodeLine = 449;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IGUID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 450;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFUNCTIONID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFUNCTIONID ) ; 
            __context__.SourceCodeLine = 451;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IFILTERID = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IFILTERID ) ; 
            __context__.SourceCodeLine = 452;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IISVIRTUAL = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IISVIRTUAL ) ; 
            __context__.SourceCodeLine = 453;
            ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IVLINK = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IVLINK ) ; 
            __context__.SourceCodeLine = 455;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 459;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . IROUTEDSRC = (ushort) ( ROOM[ IFROMROOM ].LIST[ ILIST ].ITEM[ IFROMINDEX ].IROUTEDSRC ) ; 
                        __context__.SourceCodeLine = 460;
                        ROOM [ ITOROOM] . LIST [ ILIST] . ITEM [ ITOINDEX] . SROUTEDSRC  .UpdateValue ( ROOM [ IFROMROOM] . LIST [ ILIST] . ITEM [ IFROMINDEX] . SROUTEDSRC  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 472;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 474;
                        MTRX_ADMINVSRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 475;
                        MTRX_ADMINVDST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 476;
                        MTRX_MACRO_SRC_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 477;
                        MTRX_MACRO_DST_FB__DOLLAR__ [ IROOM]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTNUMOFITEMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 483;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)ILIST);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 485;
                        MTRX_ADMINVSRC_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 486;
                        MTRX_ADMINVDST_NUMOFITEMS [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FDISPLAYCMD (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , ushort IFOLDEDCMD ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 503;
            Trace( "") ; 
            __context__.SourceCodeLine = 505;
            if ( Functions.TestForTrue  ( ( Functions.Not( IINDEX ))  ) ) 
                { 
                __context__.SourceCodeLine = 508;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(40 / 2); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 510;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 512;
                        ROOM [ IROOM] . DISPLAY [ I] . IDISPLAYPOWERSTATE = (ushort) ( IFOLDEDCMD ) ; 
                        __context__.SourceCodeLine = 513;
                        MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},cmd={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYGUID, (ushort)IFOLDEDCMD) ; 
                        __context__.SourceCodeLine = 514;
                        Functions.Delay (  (int) ( 5 ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 508;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 520;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 522;
                    ROOM [ IROOM] . DISPLAY [ IINDEX] . IDISPLAYPOWERSTATE = (ushort) ( IFOLDEDCMD ) ; 
                    __context__.SourceCodeLine = 523;
                    MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{DPLY_CMD;guid={0:d},cmd={1:d},|;}}", (ushort)ROOM[ IROOM ].DISPLAY[ IINDEX ].IDISPLAYGUID, (ushort)IFOLDEDCMD) ; 
                    } 
                
                } 
            
            
            }
            
        private void FCAMCMDSEND (  SplusExecutionContext __context__, ushort IROOM , ushort IGUID , CrestronString SCMD ) 
            { 
            
            __context__.SourceCodeLine = 533;
            if ( Functions.TestForTrue  ( ( Functions.Not( IGUID ))  ) ) 
                {
                __context__.SourceCodeLine = 533;
                IGUID = (ushort) ( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].ICAMGUID ) ; 
                }
            
            __context__.SourceCodeLine = 534;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{CAM_CTRL; guid={0:d}: cmd={1},|;}}", (ushort)IGUID, SCMD ) ; 
            
            }
            
        private void FUPDATELISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 550;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESFB)  ) ) 
                { 
                __context__.SourceCodeLine = 552;
                STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
                __context__.SourceCodeLine = 553;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 555;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 559;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 560;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 561;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IFB) ; 
                            }
                        
                        __context__.SourceCodeLine = 559;
                        }
                    
                    __context__.SourceCodeLine = 562;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 564;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 573;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESVIS)  ) ) 
                { 
                __context__.SourceCodeLine = 575;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 576;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 577;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 580;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 581;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 582;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IVIS) ; 
                            }
                        
                        __context__.SourceCodeLine = 580;
                        }
                    
                    __context__.SourceCodeLine = 583;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 585;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                __context__.SourceCodeLine = 586;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 586;
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
            
            
            __context__.SourceCodeLine = 595;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESICON)  ) ) 
                { 
                __context__.SourceCodeLine = 597;
                STEMP  .UpdateValue ( "{ListIconFB:"  ) ; 
                __context__.SourceCodeLine = 598;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 600;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 604;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 605;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            {
                            __context__.SourceCodeLine = 606;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IICON) ; 
                            }
                        
                        __context__.SourceCodeLine = 604;
                        }
                    
                    __context__.SourceCodeLine = 608;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 610;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private void FUPDATELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 619;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ILISTUSESTEXT)  ) ) 
                { 
                __context__.SourceCodeLine = 621;
                STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                __context__.SourceCodeLine = 622;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINDEX ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 624;
                    STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                    __context__.SourceCodeLine = 625;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 626;
                        MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                        __context__.SourceCodeLine = 625;
                        }
                    
                    __context__.SourceCodeLine = 627;
                    STEMP  .UpdateValue ( STEMP + "|;}"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 631;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 633;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 635;
                            STEMP  .UpdateValue ( STEMP + Functions.ItoA (  (int) ( IINDEX ) ) + "="  ) ; 
                            __context__.SourceCodeLine = 636;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].INUMOFTEXTCOLUMNS; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( J  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (J  >= __FN_FORSTART_VAL__3) && (J  <= __FN_FOREND_VAL__3) ) : ( (J  <= __FN_FORSTART_VAL__3) && (J  >= __FN_FOREND_VAL__3) ) ; J  += (ushort)__FN_FORSTEP_VAL__3) 
                                {
                                __context__.SourceCodeLine = 637;
                                MakeString ( STEMP , "{0}{1},", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ J ] ) ; 
                                __context__.SourceCodeLine = 636;
                                }
                            
                            __context__.SourceCodeLine = 638;
                            STEMP  .UpdateValue ( STEMP + "|"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 640;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 850 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 642;
                            STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                            __context__.SourceCodeLine = 643;
                            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                            __context__.SourceCodeLine = 644;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                                {
                                __context__.SourceCodeLine = 644;
                                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                                }
                            
                            __context__.SourceCodeLine = 645;
                            STEMP  .UpdateValue ( "{ListTextFB:"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 631;
                        } 
                    
                    __context__.SourceCodeLine = 648;
                    STEMP  .UpdateValue ( STEMP + ";}"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 650;
                if ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 652;
                    FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                    __context__.SourceCodeLine = 653;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 653;
                        FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 5 ), STEMP) ; 
                        }
                    
                    } 
                
                } 
            
            
            }
            
        private void FUPDATELISTALL (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 661;
            FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 662;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 663;
            FUPDATELISTICON (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 664;
            FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FCONFIGURELISTVISPROCESS (  SplusExecutionContext __context__, ushort IROOM , ushort IFROMLIST , ushort ITOLIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 676;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                {
                __context__.SourceCodeLine = 676;
                ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( SYS.IRCSTATE ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 678;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IISVIRTUAL)  ) ) 
                    {
                    __context__.SourceCodeLine = 678;
                    ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IVLINK ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 680;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ IFROMLIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                        {
                        __context__.SourceCodeLine = 680;
                        ROOM [ IROOM] . LIST [ ITOLIST] . ITEM [ IINDEX] . IVIS = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 681;
                        ; 
                        }
                    
                    }
                
                }
            
            
            }
            
        private void FCONFIGURELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 687;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                {
                __context__.SourceCodeLine = 687;
                FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 688;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    {
                    __context__.SourceCodeLine = 688;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                    __context__.SourceCodeLine = 688;
                    }
                
                }
            
            __context__.SourceCodeLine = 691;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 693;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    {
                    __context__.SourceCodeLine = 693;
                    FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 694;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)ROOM[ IROOM ].LIST[ 5 ].IMAXNUMITEMS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__2) && (IINDEX  <= __FN_FOREND_VAL__2) ) : ( (IINDEX  <= __FN_FORSTART_VAL__2) && (IINDEX  >= __FN_FOREND_VAL__2) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        {
                        __context__.SourceCodeLine = 694;
                        FCONFIGURELISTVISPROCESS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 5 ), (ushort)( IINDEX )) ; 
                        __context__.SourceCodeLine = 694;
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FCONFIGURELISTTEXT (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 701;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                {
                __context__.SourceCodeLine = 701;
                MakeString ( STEMP , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
                }
            
            __context__.SourceCodeLine = 702;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 704;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_6__ = ((int)ILIST);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 708;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 710;
                            ROOM [ IROOM] . LIST [ 5] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 715;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STEMP , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                            __context__.SourceCodeLine = 716;
                            MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ] , "{0}", ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SROUTEDSRC ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 720;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ))  ) ) 
                                {
                                __context__.SourceCodeLine = 721;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 725;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 727;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ]  .UpdateValue ( ROOM [ IROOM] . MACRO [ IINDEX] . SNAME  ) ; 
                                __context__.SourceCodeLine = 728;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IINDEX ].ISTATE)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 729;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ]  .UpdateValue ( STEMP + ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].MACRO[ IINDEX ].ISTATE] . SLOCALNAME  ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 731;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 2 ]  .UpdateValue ( "---"  ) ; 
                                    }
                                
                                } 
                            
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            
            }
            
        private void FSETLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort ISKIPINDEX , ushort IVAL ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 742;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 744;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I != ISKIPINDEX))  ) ) 
                    {
                    __context__.SourceCodeLine = 744;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IFB = (ushort) ( IVAL ) ; 
                    }
                
                __context__.SourceCodeLine = 742;
                } 
            
            
            }
            
        private void FSETLISTMACROFB (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISRC ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 756;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMACRO <= 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 758;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_7__ = ((int)IROOM);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 762;
                            MTRX_MACRO1_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 763;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                                { 
                                __context__.SourceCodeLine = 765;
                                MTRX_MACRO1_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 766;
                                MTRX_MACRO1_SRC_FB [ 2]  .Value = (ushort) ( ISRC ) ; 
                                } 
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 771;
                            MTRX_MACRO2_SRC_FB [ IMACRO]  .Value = (ushort) ( ISRC ) ; 
                            __context__.SourceCodeLine = 772;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IMACRO == 3))  ) ) 
                                { 
                                __context__.SourceCodeLine = 774;
                                MTRX_MACRO2_SRC_FB [ 1]  .Value = (ushort) ( ISRC ) ; 
                                __context__.SourceCodeLine = 775;
                                MTRX_MACRO2_SRC_FB [ 2]  .Value = (ushort) ( ISRC ) ; 
                                } 
                            
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
            
            
            __context__.SourceCodeLine = 787;
            STEMP  .UpdateValue ( "{ListButtonFB:"  ) ; 
            __context__.SourceCodeLine = 788;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 790;
                IFB = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 791;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].ICAMSEL == I))  ) ) 
                    {
                    __context__.SourceCodeLine = 791;
                    IFB = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 793;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)IFB) ; 
                __context__.SourceCodeLine = 788;
                } 
            
            __context__.SourceCodeLine = 796;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 798;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUPDATECAMVIS (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 806;
            STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 807;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 809;
                MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)I, (ushort)ROOM[ IROOM ].CAM[ I ].IVIS) ; 
                __context__.SourceCodeLine = 807;
                } 
            
            __context__.SourceCodeLine = 812;
            MakeString ( STEMP , "{0}|;}}", STEMP ) ; 
            __context__.SourceCodeLine = 813;
            CAM_FB__DOLLAR__ [ IROOM]  .UpdateValue ( STEMP  ) ; 
            
            }
            
        private void FUSBTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 825;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{USB_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            
            }
            
        private void FMTRXTAKE (  SplusExecutionContext __context__, ushort IROOM , ushort IDSTGUID , ushort ISRCGUID , ushort IDSTLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 832;
            MakeString ( TO_MST_TX__DOLLAR__ [ IROOM] , "{{MTRX_V_RTE; iGUIDdst={0:d}: iGUIDsrc={1:d}|}}", (ushort)IDSTGUID, (ushort)ISRCGUID) ; 
            __context__.SourceCodeLine = 836;
            if ( Functions.TestForTrue  ( ( IDSTLOCALID)  ) ) 
                {
                __context__.SourceCodeLine = 837;
                ROOM [ IROOM] . LIST [ 2] . ITEM [ IDSTLOCALID] . IROUTEDSRC = (ushort) ( ISRCGUID ) ; 
                }
            
            
            }
            
        private void FUPDATECONFMONITORRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ISRCGUID ) 
            { 
            
            __context__.SourceCodeLine = 856;
            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 49 ].IGUID ), (ushort)( ISRCGUID ), (ushort)( 49 )) ; 
            
            }
            
        private void FRUNMACROUSB (  SplusExecutionContext __context__, ushort IROOM , ushort IVSRCLOCALID , ushort IVDSTLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 861;
            FUSBTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID )) ; 
            
            }
            
        private void FRUNMACROPGMAUDIO (  SplusExecutionContext __context__, ushort IROOM , ushort IVSRCLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 881;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVSRCLOCALID <= 3 ))  ) ) 
                {
                __context__.SourceCodeLine = 882;
                DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IPGMAUDIO ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 884;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IVSRCLOCALID >= 7 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IVSRCLOCALID <= 9 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 885;
                    DSP_PGM_RTE [ IROOM]  .Value = (ushort) ( 4 ) ; 
                    }
                
                }
            
            
            }
            
        private void FRUNMACROMTRX (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
            { 
            ushort IDST = 0;
            ushort IVDSTLOCALID = 0;
            ushort ISRCGUID = 0;
            
            
            __context__.SourceCodeLine = 897;
            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
            __context__.SourceCodeLine = 898;
            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
            __context__.SourceCodeLine = 901;
            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].IDISCRETEMACROMODE ))  ) ) 
                { 
                __context__.SourceCodeLine = 903;
                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), (ushort)( IMACRO )) ; 
                __context__.SourceCodeLine = 904;
                FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), (ushort)( IMACRO )) ; 
                } 
            
            __context__.SourceCodeLine = 908;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IVSRCLOCALID ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IITEMACTIVE )) ))  ) ) 
                {
                __context__.SourceCodeLine = 909;
                ISRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID ) ; 
                }
            
            __context__.SourceCodeLine = 911;
            Trace( "NodeMST - fRunMacroMTRX: iVSrcLocalID={0:d}, iSrcGUID={1:d}, iMacro={2:d}, iRoom={3:d}", (ushort)IVSRCLOCALID, (ushort)ISRCGUID, (ushort)IMACRO, (ushort)IROOM) ; 
            __context__.SourceCodeLine = 914;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IPGMAUDIO)  ) ) 
                {
                __context__.SourceCodeLine = 915;
                FRUNMACROPGMAUDIO (  __context__ , (ushort)( IROOM ), (ushort)( IVSRCLOCALID )) ; 
                }
            
            __context__.SourceCodeLine = 918;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 920;
                IVDSTLOCALID = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IDST ] ) ; 
                __context__.SourceCodeLine = 922;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IGUID ), (ushort)( ISRCGUID ), (ushort)( IVDSTLOCALID )) ; 
                __context__.SourceCodeLine = 928;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].IUSB)  ) ) 
                    { 
                    __context__.SourceCodeLine = 931;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IISRCITEM ) ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IVDSTLOCALID ].IISUSB )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 932;
                        FRUNMACROUSB (  __context__ , (ushort)( IROOM ), (ushort)( IVSRCLOCALID ), (ushort)( IVDSTLOCALID )) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 918;
                } 
            
            __context__.SourceCodeLine = 937;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].MACRO[ IMACRO ].IUSB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 44 ].IGUID )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 939;
                FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ 44 ].IGUID ), (ushort)( ISRCGUID ), (ushort)( IVDSTLOCALID )) ; 
                } 
            
            
            }
            
        private void FRUNMACRODISPLAYCTRL (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
            { 
            ushort IINDEX = 0;
            ushort IFOLDEDCMD = 0;
            
            
            __context__.SourceCodeLine = 951;
            if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                {
                __context__.SourceCodeLine = 951;
                IFOLDEDCMD = (ushort) ( 11 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 952;
                IFOLDEDCMD = (ushort) ( 10 ) ; 
                }
            
            __context__.SourceCodeLine = 954;
            ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IFOLDEDCMD ) ; 
            __context__.SourceCodeLine = 955;
            FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IFOLDEDCMD )) ; 
            __context__.SourceCodeLine = 957;
            Trace( "NodeMST - fRunMacroDisplayCtrl: iRoom={0:d}, iMacro={1:d}, iState={2:d}, iNumOfObjects={3:d}, ", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
            __context__.SourceCodeLine = 959;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 961;
                FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IINDEX ] ].IDISPLAYLOCALID ), (ushort)( IFOLDEDCMD )) ; 
                __context__.SourceCodeLine = 962;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 959;
                } 
            
            
            }
            
        private void FUPDATEMACROSRC (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort IVSRCLOCALID ) 
            { 
            
            __context__.SourceCodeLine = 976;
            ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IVSRCLOCALID ].IGUID ) ; 
            __context__.SourceCodeLine = 979;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IDISCRETEMACROMODE)  ) ) 
                {
                __context__.SourceCodeLine = 980;
                FRUNMACROMTRX (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 984;
                ROOM [ IROOM] . MACRO [ IMACRO] . ISTATE = (ushort) ( IVSRCLOCALID ) ; 
                __context__.SourceCodeLine = 985;
                FSETLISTMACROFB (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( IVSRCLOCALID )) ; 
                } 
            
            
            }
            
        private ushort FRUNMACROSPECIALFUNCTION (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
            { 
            ushort I = 0;
            ushort J = 0;
            ushort N = 0;
            
            
            __context__.SourceCodeLine = 994;
            
                {
                int __SPLS_TMPVAR__SWTCH_8__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].ISPECIALFUNCTION);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1000;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)10; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            {
                            __context__.SourceCodeLine = 1001;
                            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ (I + 30) ].IGUID ), (ushort)( I )) ; 
                            __context__.SourceCodeLine = 1000;
                            }
                        
                        __context__.SourceCodeLine = 1005;
                        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                            {
                            __context__.SourceCodeLine = 1006;
                            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__2 = (ushort)10; 
                            int __FN_FORSTEP_VAL__2 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                {
                                __context__.SourceCodeLine = 1007;
                                FMTRXTAKE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 1 ].ITEM[ (I + 30) ].IGUID ), (ushort)( I )) ; 
                                __context__.SourceCodeLine = 1006;
                                }
                            
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1016;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 10 )) ; 
                        __context__.SourceCodeLine = 1020;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 2 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)4; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 1022;
                            Functions.Delay (  (int) ( 15 ) ) ; 
                            __context__.SourceCodeLine = 1023;
                            FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 11 )) ; 
                            __context__.SourceCodeLine = 1020;
                            } 
                        
                        __context__.SourceCodeLine = 1026;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_18__" , 1400 , __SPLS_TMPVAR__WAITLABEL_18___Callback ) ;
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == (  (int) ( 3 ) ) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1041;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 11 )) ; 
                        __context__.SourceCodeLine = 1044;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1046;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 101 )) ; 
                        __context__.SourceCodeLine = 1047;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1048;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 62 )) ; 
                        __context__.SourceCodeLine = 1049;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1050;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 63 )) ; 
                        __context__.SourceCodeLine = 1051;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1052;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 64 )) ; 
                        __context__.SourceCodeLine = 1053;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1054;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 3 ), (ushort)( 65 )) ; 
                        __context__.SourceCodeLine = 1055;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1056;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 3 ), (ushort)( 66 )) ; 
                        __context__.SourceCodeLine = 1057;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1058;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 3 ), (ushort)( 67 )) ; 
                        __context__.SourceCodeLine = 1059;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1060;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 3 ), (ushort)( 68 )) ; 
                        __context__.SourceCodeLine = 1061;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1062;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 4 ), (ushort)( 69 )) ; 
                        __context__.SourceCodeLine = 1063;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1064;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 4 ), (ushort)( 110 )) ; 
                        __context__.SourceCodeLine = 1065;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1066;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 4 ), (ushort)( 71 )) ; 
                        __context__.SourceCodeLine = 1067;
                        Functions.Delay (  (int) ( 20 ) ) ; 
                        __context__.SourceCodeLine = 1068;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 4 ), (ushort)( 72 )) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1074;
                        if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1076;
                            J = (ushort) ( 0 ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1082;
                            J = (ushort) ( 20 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1087;
                        ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__6 = (ushort)4; 
                        int __FN_FORSTEP_VAL__6 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                            { 
                            __context__.SourceCodeLine = 1089;
                            FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ((80 + (Mod( (ROOM[ IROOM ].MACRO[ ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ I ] ].ILIST[ 1 ] - 1) , 20 ) + 1)) + J) )) ; 
                            __context__.SourceCodeLine = 1090;
                            Functions.Delay (  (int) ( 15 ) ) ; 
                            __context__.SourceCodeLine = 1087;
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == (  (int) ( 6 ) ) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1095;
                        ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__7 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
                        int __FN_FORSTEP_VAL__7 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                            { 
                            __context__.SourceCodeLine = 1097;
                            FRUNMACROMTRX (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ I ] ), (ushort)( ISTATE )) ; 
                            __context__.SourceCodeLine = 1098;
                            Functions.Delay (  (int) ( 50 ) ) ; 
                            __context__.SourceCodeLine = 1095;
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_18___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            ushort I = 0;
            ushort J = 0;
            
            __context__.SourceCodeLine = 1029;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 2 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)4; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                {
                __context__.SourceCodeLine = 1030;
                ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__5 = (ushort)4; 
                int __FN_FORSTEP_VAL__5 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                    { 
                    __context__.SourceCodeLine = 1032;
                    FDISPLAYCMD (  __context__ , (ushort)( 1 ), (ushort)( I ), (ushort)( ((80 + J) + ((I - 2) * 4)) )) ; 
                    __context__.SourceCodeLine = 1033;
                    Functions.Delay (  (int) ( 20 ) ) ; 
                    __context__.SourceCodeLine = 1030;
                    } 
                
                __context__.SourceCodeLine = 1029;
                }
            
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FUPDATECAMRTE (  SplusExecutionContext __context__, ushort IROOM , ushort ICAM ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1111;
        ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 2] = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
        __context__.SourceCodeLine = 1113;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ 5 ].INUMOFOBJECTS; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1115;
            FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ ROOM[ IROOM ].MACRO[ 5 ].ILIST[ I ] ].IGUID ), (ushort)( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ), (ushort)( ROOM[ IROOM ].MACRO[ 5 ].ILIST[ I ] )) ; 
            __context__.SourceCodeLine = 1113;
            } 
        
        
        }
        
    private void FCONFIGURELISTTEXTRMNUMS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort ISTATE ) 
        { 
        ushort IINDEX = 0;
        
        CrestronString STHISROOM;
        CrestronString SOTHERROOM;
        STHISROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
        SOTHERROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
        
        
        __context__.SourceCodeLine = 1133;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 1135;
            MakeString ( STHISROOM , "{0} ", ROOM [ IROOM] . SROOMNAMESHORT ) ; 
            __context__.SourceCodeLine = 1136;
            MakeString ( SOTHERROOM , "{0} ", ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . SROOMNAMESHORT ) ; 
            } 
        
        __context__.SourceCodeLine = 1139;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1141;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 1143;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM)  ) ) 
                    {
                    __context__.SourceCodeLine = 1144;
                    MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", SOTHERROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1146;
                    MakeString ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . STEXT [ 1 ] , "{0}{1}", STHISROOM , ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME ) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1139;
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
        
        
        __context__.SourceCodeLine = 1155;
        
            {
            int __SPLS_TMPVAR__SWTCH_9__ = ((int)ITYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1160;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)2; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1162;
                        V [ IROOM] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 5 ].IVLINK ) ; 
                        __context__.SourceCodeLine = 1160;
                        } 
                    
                    __context__.SourceCodeLine = 1165;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ 2 ].IVTCALLOCATION ) && Functions.TestForTrue ( Functions.Not( ROOM[ 1 ].IVTCALLOCATION ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1167;
                        FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                        __context__.SourceCodeLine = 1168;
                        FCOPYIO (  __context__ , (ushort)( 2 ), (ushort)( 6 ), (ushort)( 1 ), (ushort)( 6 ), (ushort)( 1 )) ; 
                        __context__.SourceCodeLine = 1170;
                        ROOM [ 1] . IVTCALLOCATION = (ushort) ( ROOM[ 2 ].IVTCALLOCATION ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1174;
                        FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 5 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                        __context__.SourceCodeLine = 1175;
                        FCOPYIO (  __context__ , (ushort)( 1 ), (ushort)( 6 ), (ushort)( 2 ), (ushort)( 5 ), (ushort)( 1 )) ; 
                        __context__.SourceCodeLine = 1177;
                        ROOM [ 2] . IVTCALLOCATION = (ushort) ( ROOM[ 1 ].IVTCALLOCATION ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1181;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)2; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 1183;
                        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                        __context__.SourceCodeLine = 1184;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 4 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)6; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 1186;
                            ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( ROOM[ IROOM ].CAM[ I ].ICAMACTIVE ) ; 
                            __context__.SourceCodeLine = 1184;
                            } 
                        
                        __context__.SourceCodeLine = 1188;
                        FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                        __context__.SourceCodeLine = 1181;
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1202;
                    ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__4 = (ushort)2; 
                    int __FN_FORSTEP_VAL__4 = (int)1; 
                    for ( IROOM  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__4) && (IROOM  <= __FN_FOREND_VAL__4) ) : ( (IROOM  <= __FN_FORSTART_VAL__4) && (IROOM  >= __FN_FOREND_VAL__4) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__4) 
                        {
                        __context__.SourceCodeLine = 1203;
                        ushort __FN_FORSTART_VAL__5 = (ushort) ( 4 ) ;
                        ushort __FN_FOREND_VAL__5 = (ushort)6; 
                        int __FN_FORSTEP_VAL__5 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                            {
                            __context__.SourceCodeLine = 1203;
                            ROOM [ IROOM] . LIST [ 1] . ITEM [ I] . IVLINK = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1203;
                            }
                        
                        __context__.SourceCodeLine = 1202;
                        }
                    
                    __context__.SourceCodeLine = 1206;
                    ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__6 = (ushort)2; 
                    int __FN_FORSTEP_VAL__6 = (int)1; 
                    for ( IROOM  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__6) && (IROOM  <= __FN_FOREND_VAL__6) ) : ( (IROOM  <= __FN_FORSTART_VAL__6) && (IROOM  >= __FN_FOREND_VAL__6) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__6) 
                        { 
                        __context__.SourceCodeLine = 1208;
                        ROOM [ IROOM] . ICAMSEL = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1209;
                        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
                        __context__.SourceCodeLine = 1210;
                        ushort __FN_FORSTART_VAL__7 = (ushort) ( 4 ) ;
                        ushort __FN_FOREND_VAL__7 = (ushort)6; 
                        int __FN_FORSTEP_VAL__7 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                            {
                            __context__.SourceCodeLine = 1210;
                            ROOM [ IROOM] . CAM [ I] . IVIS = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1210;
                            }
                        
                        __context__.SourceCodeLine = 1211;
                        FUPDATECAMVIS (  __context__ , (ushort)( IROOM )) ; 
                        __context__.SourceCodeLine = 1206;
                        } 
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1216;
        ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__8 = (ushort)2; 
        int __FN_FORSTEP_VAL__8 = (int)1; 
        for ( IROOM  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__8) && (IROOM  <= __FN_FOREND_VAL__8) ) : ( (IROOM  <= __FN_FORSTART_VAL__8) && (IROOM  >= __FN_FOREND_VAL__8) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__8) 
            { 
            __context__.SourceCodeLine = 1218;
            ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__9 = (ushort)2; 
            int __FN_FORSTEP_VAL__9 = (int)1; 
            for ( ILIST  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__9) && (ILIST  <= __FN_FOREND_VAL__9) ) : ( (ILIST  <= __FN_FORSTART_VAL__9) && (ILIST  >= __FN_FOREND_VAL__9) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__9) 
                { 
                __context__.SourceCodeLine = 1220;
                ushort __FN_FORSTART_VAL__10 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__10 = (ushort)50; 
                int __FN_FORSTEP_VAL__10 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__10; (__FN_FORSTEP_VAL__10 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__10) && (IINDEX  <= __FN_FOREND_VAL__10) ) : ( (IINDEX  <= __FN_FORSTART_VAL__10) && (IINDEX  >= __FN_FOREND_VAL__10) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__10) 
                    { 
                    __context__.SourceCodeLine = 1222;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISRCITEM ) || Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISVIRTUAL )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1224;
                        FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        __context__.SourceCodeLine = 1225;
                        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( IINDEX )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1220;
                    } 
                
                __context__.SourceCodeLine = 1229;
                FCONFIGURELISTTEXTRMNUMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( SYS.IRCSTATE )) ; 
                __context__.SourceCodeLine = 1230;
                FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
                __context__.SourceCodeLine = 1218;
                } 
            
            __context__.SourceCodeLine = 1216;
            } 
        
        
        }
        
    private void FUPDATERC_STATE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1245;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1247;
            if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 1249;
                RC_OFF_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1250;
                RC_ON_FB [ I]  .Value = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1255;
                RC_ON_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1256;
                RC_OFF_FB [ I]  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 1245;
            } 
        
        
        }
        
    private void FUPDATERC_ENABLE_FB (  SplusExecutionContext __context__, ushort ISTATE ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1265;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1267;
            if ( Functions.TestForTrue  ( ( ISTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 1269;
                PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1270;
                PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1274;
                PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1275;
                PARTSENSE_DISABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 1265;
            } 
        
        
        }
        
    private void FPROCESSFINALIZE (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST ) 
        { 
        ushort IOTHERROOM = 0;
        ushort I = 0;
        ushort J = 0;
        
        
        __context__.SourceCodeLine = 1291;
        Trace( "NodeMST - in fProcessFinalize, iRoom={0:d}, iList={1:d}", (ushort)IROOM, (ushort)ILIST) ; 
        __context__.SourceCodeLine = 1293;
        FUPDATELISTNUMOFITEMS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST )) ; 
        __context__.SourceCodeLine = 1295;
        
            {
            int __SPLS_TMPVAR__SWTCH_10__ = ((int)ILIST);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1310;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)3; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1312;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1313;
                        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                        __context__.SourceCodeLine = 1310;
                        } 
                    
                    __context__.SourceCodeLine = 1318;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)3; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 1320;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Not( ROOM[ IROOM ].IROOMGUID ) == 17))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1322;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 3)] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 3) ].IVLINK ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1326;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 3)] . IVIS = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 3) ].IITEMACTIVE ) ; 
                            __context__.SourceCodeLine = 1327;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 3) )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1318;
                        } 
                    
                    __context__.SourceCodeLine = 1333;
                    ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__3 = (ushort)3; 
                    int __FN_FORSTEP_VAL__3 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                        { 
                        __context__.SourceCodeLine = 1335;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1337;
                            ROOM [ IROOM] . LIST [ 1] . ITEM [ (I + 6)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1338;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 6) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1339;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 6) )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1343;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 6) ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1345;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 6)] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1346;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 6) )) ; 
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 1333;
                        } 
                    
                    __context__.SourceCodeLine = 1353;
                    ushort __FN_FORSTART_VAL__4 = (ushort) ( 10 ) ;
                    ushort __FN_FOREND_VAL__4 = (ushort)20; 
                    int __FN_FORSTEP_VAL__4 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                        { 
                        __context__.SourceCodeLine = 1355;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1357;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1358;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1353;
                        } 
                    
                    __context__.SourceCodeLine = 1363;
                    ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__5 = (ushort)3; 
                    int __FN_FORSTEP_VAL__5 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                        { 
                        __context__.SourceCodeLine = 1365;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 20) ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1367;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1368;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1363;
                        } 
                    
                    __context__.SourceCodeLine = 1373;
                    ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__6 = (ushort)3; 
                    int __FN_FORSTEP_VAL__6 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                        { 
                        __context__.SourceCodeLine = 1375;
                        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1377;
                            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 23)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1378;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 20) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 23) ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1379;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 23) )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1383;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 23) ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1385;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 23)] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1386;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 23) )) ; 
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 1373;
                        } 
                    
                    __context__.SourceCodeLine = 1392;
                    ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__7 = (ushort)10; 
                    int __FN_FORSTEP_VAL__7 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                        { 
                        __context__.SourceCodeLine = 1394;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 30) ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1396;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 30)] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1397;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 30) )) ; 
                            __context__.SourceCodeLine = 1400;
                            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1402;
                                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 1] . ITEM [ (I + 40)] . IISRCITEM = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1403;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( (I + 30) ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 40) ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1404;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 40) )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1408;
                                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ (I + 40) ].IITEMACTIVE)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1410;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 40)] . IVIS = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1411;
                                    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( (I + 40) )) ; 
                                    } 
                                
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 1392;
                        } 
                    
                    __context__.SourceCodeLine = 1418;
                    ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__8 = (ushort)50; 
                    int __FN_FORSTEP_VAL__8 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                        { 
                        __context__.SourceCodeLine = 1420;
                        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1421;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 1418;
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1427;
                    if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1442;
                        ushort __FN_FORSTART_VAL__9 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__9 = (ushort)20; 
                        int __FN_FORSTEP_VAL__9 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__9; (__FN_FORSTEP_VAL__9 > 0)  ? ( (I  >= __FN_FORSTART_VAL__9) && (I  <= __FN_FOREND_VAL__9) ) : ( (I  <= __FN_FORSTART_VAL__9) && (I  >= __FN_FOREND_VAL__9) ) ; I  += (ushort)__FN_FORSTEP_VAL__9) 
                            { 
                            __context__.SourceCodeLine = 1444;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1446;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1447;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                __context__.SourceCodeLine = 1450;
                                FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( (I + 20) ), (ushort)( ILIST )) ; 
                                __context__.SourceCodeLine = 1451;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( (I + 20) )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 1454;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ (I + 20)] . IISRCITEM = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1442;
                            } 
                        
                        __context__.SourceCodeLine = 1458;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 41 ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1460;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 41] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1461;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 41 )) ; 
                            __context__.SourceCodeLine = 1464;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 41 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 42 ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1465;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 42 )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1467;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 42] . IISRCITEM = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1471;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ 49 ].IITEMACTIVE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 1473;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ 49] . IVIS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1474;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 49 )) ; 
                            __context__.SourceCodeLine = 1477;
                            FCOPYIO (  __context__ , (ushort)( IROOM ), (ushort)( 49 ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 50 ), (ushort)( ILIST )) ; 
                            __context__.SourceCodeLine = 1478;
                            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 50 )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1480;
                        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ ILIST] . ITEM [ 50] . IISRCITEM = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1486;
                        ushort __FN_FORSTART_VAL__10 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__10 = (ushort)50; 
                        int __FN_FORSTEP_VAL__10 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__10; (__FN_FORSTEP_VAL__10 > 0)  ? ( (I  >= __FN_FORSTART_VAL__10) && (I  <= __FN_FOREND_VAL__10) ) : ( (I  <= __FN_FORSTART_VAL__10) && (I  >= __FN_FOREND_VAL__10) ) ; I  += (ushort)__FN_FORSTEP_VAL__10) 
                            { 
                            __context__.SourceCodeLine = 1489;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ I ].IITEMACTIVE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 1491;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 1492;
                                FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( I )) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1495;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ I] . IVIS = (ushort) ( 0 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 1486;
                            } 
                        
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_10__ == ( 14) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1503;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 2))  ) ) 
                        {
                        __context__.SourceCodeLine = 1503;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_19__" , 1000 , __SPLS_TMPVAR__WAITLABEL_19___Callback ) ;
                        }
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1521;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILIST <= 2 ) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 5) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1523;
            FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1524;
            FUPDATELISTALL (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1526;
            FCONFIGURELISTVIS (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 1527;
            FUPDATELISTALL (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILIST ), (ushort)( 0 )) ; 
            } 
        
        
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_19___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            ushort I = 0;
            
            __context__.SourceCodeLine = 1506;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1508;
                SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1509;
                SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
                __context__.SourceCodeLine = 1510;
                ushort __FN_FORSTART_VAL__11 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__11 = (ushort)2; 
                int __FN_FORSTEP_VAL__11 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__11; (__FN_FORSTEP_VAL__11 > 0)  ? ( (I  >= __FN_FORSTART_VAL__11) && (I  <= __FN_FOREND_VAL__11) ) : ( (I  <= __FN_FORSTART_VAL__11) && (I  >= __FN_FOREND_VAL__11) ) ; I  += (ushort)__FN_FORSTEP_VAL__11) 
                    {
                    __context__.SourceCodeLine = 1511;
                    PARTSENSE_ENABLE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1510;
                    }
                
                __context__.SourceCodeLine = 1512;
                FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                __context__.SourceCodeLine = 1514;
                FUPDATERC (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
                } 
            
            
        
        
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
    
    
    __context__.SourceCodeLine = 1540;
    STEMPDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1541;
    STEMPGUID  .UpdateValue ( Functions.Remove ( "," , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1542;
    STEMPSRC  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (Functions.Find( "," , STEMPDATA ) - 1) ) )  ) ; 
    __context__.SourceCodeLine = 1543;
    STRASH  .UpdateValue ( Functions.Remove ( "src_name=" , STEMPSRC )  ) ; 
    __context__.SourceCodeLine = 1546;
    ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
    __context__.SourceCodeLine = 1547;
    ROOM [ IROOM] . LIST [ 2] . ITEM [ ILOCALINDEX] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
    __context__.SourceCodeLine = 1548;
    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1549;
    FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1552;
    if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
        { 
        __context__.SourceCodeLine = 1554;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOCALINDEX <= 20 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1556;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . IROUTEDSRC = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1557;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . LIST [ 2] . ITEM [ (ILOCALINDEX + 20)] . SROUTEDSRC  .UpdateValue ( STEMPSRC  ) ; 
            __context__.SourceCodeLine = 1558;
            FCONFIGURELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            __context__.SourceCodeLine = 1559;
            FUPDATELISTTEXT (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( 2 ), (ushort)( ILOCALINDEX )) ; 
            } 
        
        } 
    
    
    }
    
private ushort FPROCESSMACROOBJECT (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , CrestronString SDATA ) 
    { 
    
    __context__.SourceCodeLine = 1568;
    if ( Functions.TestForTrue  ( ( Functions.Find( "*" , SDATA ))  ) ) 
        {
        __context__.SourceCodeLine = 1568;
        ROOM [ IROOM] . MACRO [ IMACRO] . IPRIMARYOBJECT = (ushort) ( Functions.Atoi( SDATA ) ) ; 
        }
    
    __context__.SourceCodeLine = 1569;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Atoi( SDATA ) ) || Functions.TestForTrue ( Functions.Find( "0" , SDATA ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1571;
        ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( (ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS + 1) ) ; 
        __context__.SourceCodeLine = 1572;
        ROOM [ IROOM] . MACRO [ IMACRO] . ILIST [ ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS] = (ushort) ( Functions.Atoi( SDATA ) ) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1574;
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
    
    
    __context__.SourceCodeLine = 1584;
    SDATA  .UpdateValue ( SLINE  ) ; 
    __context__.SourceCodeLine = 1587;
    ROOM [ IROOM] . MACRO [ IMACRO] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1588;
    ROOM [ IROOM] . MACRO [ IMACRO] . IMACROTYPE = (ushort) ( FGETMACROTYPE( __context__ , (ushort)( IMACRO ) ) ) ; 
    __context__.SourceCodeLine = 1589;
    ROOM [ IROOM] . MACRO [ IMACRO] . INUMOFOBJECTS = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1592;
    ROOM [ IROOM] . LIST [ 6] . ITEM [ IMACRO] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1595;
    ROOM [ IROOM] . MACRO [ IMACRO] . ISPECIALFUNCTION = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1597;
    while ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1599;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
        __context__.SourceCodeLine = 1601;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "name" , STEMPKEY ))  ) ) 
            { 
            __context__.SourceCodeLine = 1603;
            ROOM [ IROOM] . MACRO [ IMACRO] . SNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "," , SDATA ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 1604;
            STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
            __context__.SourceCodeLine = 1605;
            ROOM [ IROOM] . LIST [ 6] . ITEM [ IMACRO] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . MACRO [ IMACRO] . SNAME  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1607;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "usb" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1607;
                ROOM [ IROOM] . MACRO [ IMACRO] . IUSB = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1608;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1608;
                    ROOM [ IROOM] . MACRO [ IMACRO] . IPGMAUDIO = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1609;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "list" , STEMPKEY ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1611;
                        STEMP  .UpdateValue ( Functions.Remove ( ")" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 1612;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMP ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1613;
                            FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), Functions.Remove( "," , STEMP )) ; 
                            __context__.SourceCodeLine = 1612;
                            }
                        
                        __context__.SourceCodeLine = 1614;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 1 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1615;
                            FPROCESSMACROOBJECT (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), STEMP) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1617;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "special_func" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1617;
                            ROOM [ IROOM] . MACRO [ IMACRO] . ISPECIALFUNCTION = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                            }
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1620;
                            Trace( "NodeMST - fProcessMacro - error parsing macro, {0}", SLINE ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1597;
        } 
    
    __context__.SourceCodeLine = 1625;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE == 1) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].IDISCRETEMACROMODE ) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1627;
        FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), (ushort)( IMACRO )) ; 
        __context__.SourceCodeLine = 1628;
        FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( 6 ), (ushort)( IMACRO )) ; 
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
    
    
    __context__.SourceCodeLine = 1644;
    STEMPLINE  .UpdateValue ( STEMP  ) ; 
    __context__.SourceCodeLine = 1647;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1648;
    ROOM [ IROOM] . LIST [ ILIST] . IMAXNUMITEMS = (ushort) ( Functions.Max( IINDEX , ROOM[ IROOM ].LIST[ ILIST ].IMAXNUMITEMS ) ) ; 
    __context__.SourceCodeLine = 1651;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1653;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1654;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1655;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1657;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1657;
            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1658;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1658;
                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1659;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1659;
                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1660;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1660;
                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IFUNCTIONID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1661;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "sys_preset" , STEMPKEY ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1661;
                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ISYSPRESET = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1662;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_camera" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1662;
                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISCAMERA = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1663;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_localid" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1663;
                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1664;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "cam_global" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1664;
                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . ICAMGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1666;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_display" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1666;
                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISDISPLAY = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1667;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_localid" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1667;
                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYLOCALID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1668;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "display_global" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1668;
                                                    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IDISPLAYGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1669;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "virtual" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1669;
                                                        ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1670;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_usb" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1670;
                                                            ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IISUSB = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1671;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "pgm_audio" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1671;
                                                                ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . IPGMAUDIO = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                { 
                                                                __context__.SourceCodeLine = 1675;
                                                                Trace( "NodeMST - fProcessLine - didn't catch key:   GUID={0:d}, {1}{2}", (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
                                                                __context__.SourceCodeLine = 1676;
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
        
        __context__.SourceCodeLine = 1651;
        } 
    
    __context__.SourceCodeLine = 1680;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID)  ) ) 
        {
        __context__.SourceCodeLine = 1680;
        ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID] = (ushort) ( IINDEX ) ; 
        }
    
    __context__.SourceCodeLine = 1682;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISCAMERA)  ) ) 
        { 
        __context__.SourceCodeLine = 1685;
        ICAM = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMLOCALID ) ; 
        __context__.SourceCodeLine = 1687;
        ROOM [ IROOM] . CAM [ ICAM] . ICAMGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ICAMGUID ) ; 
        __context__.SourceCodeLine = 1688;
        ROOM [ IROOM] . CAM [ ICAM] . ICAMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1689;
        ROOM [ IROOM] . CAM [ ICAM] . IVIS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1690;
        ROOM [ IROOM] . CAM [ ICAM] . IVSRCLOCALID = (ushort) ( IINDEX ) ; 
        __context__.SourceCodeLine = 1691;
        ROOM [ IROOM] . CAM [ ICAM] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
        __context__.SourceCodeLine = 1692;
        ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
        __context__.SourceCodeLine = 1693;
        ROOM [ IROOM] . CAM [ ICAM] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
        __context__.SourceCodeLine = 1695;
        ROOM [ IROOM] . CAM [ ICAM] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
        __context__.SourceCodeLine = 1697;
        MakeString ( CAM_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)ICAM, (ushort)ICAM, ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
        __context__.SourceCodeLine = 1699;
        if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
            { 
            __context__.SourceCodeLine = 1701;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1702;
            MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(ICAM + 3), ROOM [ IROOM] . CAM [ ICAM] . SGLOBALNAME ) ; 
            __context__.SourceCodeLine = 1704;
            if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                { 
                __context__.SourceCodeLine = 1706;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVIS = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1707;
                MakeString ( CAM_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(ICAM + 3)) ; 
                } 
            
            __context__.SourceCodeLine = 1709;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . ICAMGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].ICAMGUID ) ; 
            __context__.SourceCodeLine = 1710;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . CAM [ (ICAM + 3)] . IVSRCGUID = (ushort) ( ROOM[ IROOM ].CAM[ ICAM ].IVSRCGUID ) ; 
            } 
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 1713;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IISDISPLAY)  ) ) 
            { 
            __context__.SourceCodeLine = 1716;
            IDISPLAY = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYLOCALID ) ; 
            __context__.SourceCodeLine = 1717;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IDISPLAYGUID ) ; 
            __context__.SourceCodeLine = 1718;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1719;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1720;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTLOCALID = (ushort) ( IINDEX ) ; 
            __context__.SourceCodeLine = 1721;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . IVDSTGUID = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].IGUID ) ; 
            __context__.SourceCodeLine = 1722;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SGLOBALNAME  ) ; 
            __context__.SourceCodeLine = 1723;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SLOCALNAME  .UpdateValue ( ROOM [ IROOM] . LIST [ ILIST] . ITEM [ IINDEX] . SLOCALNAME  ) ; 
            __context__.SourceCodeLine = 1725;
            ROOM [ IROOM] . DISPLAY [ IDISPLAY] . ISYSPRESET = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ IINDEX ].ISYSPRESET ) ; 
            __context__.SourceCodeLine = 1727;
            MakeString ( DISPLAY_FB__DOLLAR__ [ IROOM] , "{{ListVisFB:{0:d}=1,|; ListTextFB:{1:d}={2},|;}}", (ushort)IDISPLAY, (ushort)IDISPLAY, ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
            __context__.SourceCodeLine = 1730;
            if ( Functions.TestForTrue  ( ( SYS.IISRCPAIR)  ) ) 
                { 
                __context__.SourceCodeLine = 1732;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1734;
                MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListTextFB:{0:d}={1},|;}}", (ushort)(IDISPLAY + (40 / 2)), ROOM [ IROOM] . DISPLAY [ IDISPLAY] . SGLOBALNAME ) ; 
                __context__.SourceCodeLine = 1736;
                if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1738;
                    ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IVIS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1739;
                    MakeString ( DISPLAY_FB__DOLLAR__ [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] , "{{ListVisFB:{0:d}=1,|;}}", (ushort)(IDISPLAY + (40 / 2))) ; 
                    } 
                
                __context__.SourceCodeLine = 1741;
                ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . DISPLAY [ (IDISPLAY + (40 / 2))] . IDISPLAYGUID = (ushort) ( ROOM[ IROOM ].DISPLAY[ IDISPLAY ].IDISPLAYGUID ) ; 
                __context__.SourceCodeLine = 1742;
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
    
    
    __context__.SourceCodeLine = 1751;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1753;
    if ( Functions.TestForTrue  ( ( Functions.Find( "=" , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1755;
        ROOM [ IROOM] . IROOMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1756;
        ROOM [ IROOM] . IROOMGUID = (ushort) ( IGLOBALROOMNUM ) ; 
        } 
    
    __context__.SourceCodeLine = 1758;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IROOM == 2) ) && Functions.TestForTrue ( ROOM[ IROOM ].IROOMGUID )) ))  ) ) 
        {
        __context__.SourceCodeLine = 1758;
        SYS . IISRCPAIR = (ushort) ( 1 ) ; 
        }
    
    __context__.SourceCodeLine = 1760;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1762;
        STEMPKV  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
        __context__.SourceCodeLine = 1763;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPKV )  ) ; 
        __context__.SourceCodeLine = 1764;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1764;
            ROOM [ IROOM] . SROOMNAME  .UpdateValue ( ST . StringTrim (  Functions.Left( STEMPKV , (int)( (Functions.Length( STEMPKV ) - 1) ) )  .ToSimplSharpString() )  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1765;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room_num" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1765;
                ROOM [ IROOM] . IBLDGROOMNUM = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1766;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "discrete_macro_mode" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1766;
                    ROOM [ IROOM] . IDISCRETEMACROMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1767;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "macro_take_mode" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1767;
                        ROOM [ IROOM] . IMACROTAKEMODE = (ushort) ( Functions.Atoi( STEMPKV ) ) ; 
                        }
                    
                    }
                
                }
            
            }
        
        __context__.SourceCodeLine = 1760;
        } 
    
    __context__.SourceCodeLine = 1770;
    ROOMNAME__DOLLAR___OUT [ IROOM]  .UpdateValue ( ROOM [ IROOM] . SROOMNAME  ) ; 
    __context__.SourceCodeLine = 1771;
    MakeString ( ROOM [ IROOM] . SROOMNAMESHORT , "{0:d}", (ushort)ROOM[ IROOM ].IBLDGROOMNUM) ; 
    
    }
    
private ushort FADDVLINK (  SplusExecutionContext __context__, ushort ILIST , ushort IROOM , ushort ILOCALINDEX , CrestronString STEMPLINE , ushort IVLINK ) 
    { 
    ushort I = 0;
    
    CrestronString SDATA;
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1780;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1782;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 1784;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVLINK = (ushort) ( IVLINK ) ; 
    __context__.SourceCodeLine = 1785;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IGUID = (ushort) ( IVLINK ) ; 
    __context__.SourceCodeLine = 1786;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SLOCALNAME  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Find( "|" , SDATA ) - 1) ) )  ) ; 
    __context__.SourceCodeLine = 1787;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SGLOBALNAME  .UpdateValue ( "Rm" + Functions.ItoA (  (int) ( ROOM[ IROOM ].IROOMGUID ) ) + " " + Functions.Left ( SDATA ,  (int) ( (Functions.Find( "|" , SDATA ) - 1) ) )  ) ; 
    __context__.SourceCodeLine = 1788;
    ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ IVLINK] = (ushort) ( ILOCALINDEX ) ; 
    __context__.SourceCodeLine = 1790;
    Trace( "NodeMST - fAddVLink:  iLocalIndex={0:d}, iVLink={1:d}, iList={2:d}", (ushort)ILOCALINDEX, (ushort)IVLINK, (ushort)ILIST) ; 
    __context__.SourceCodeLine = 1793;
    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1794;
    FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1796;
    FCONFIGURELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1797;
    FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    
    return 0; // default return value (none specified in module)
    }
    
private ushort FREMOVEVLINK (  SplusExecutionContext __context__, ushort ILIST , ushort IROOM , ushort ILOCALINDEX ) 
    { 
    ushort I = 0;
    ushort IVLINK = 0;
    
    
    __context__.SourceCodeLine = 1804;
    Trace( "in fRemoveVLink - iList={0:d}, iRoom={1:d}, iLocalIndex={2:d}", (ushort)ILIST, (ushort)IROOM, (ushort)ILOCALINDEX) ; 
    __context__.SourceCodeLine = 1806;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IITEMACTIVE ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IVLINK )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 1808;
        IVLINK = (ushort) ( ROOM[ IROOM ].LIST[ ILIST ].ITEM[ ILOCALINDEX ].IVLINK ) ; 
        __context__.SourceCodeLine = 1809;
        ROOM [ IROOM] . LIST [ ILIST] . IGLOBALTOLOCAL [ IVLINK] = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1811;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILIST == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 1813;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 1814;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IROUTEDSRC == IVLINK))  ) ) 
                    {
                    __context__.SourceCodeLine = 1815;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ I ].IGUID ), (ushort)( 0 ), (ushort)( I )) ; 
                    }
                
                __context__.SourceCodeLine = 1813;
                }
            
            } 
        
        } 
    
    __context__.SourceCodeLine = 1819;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SLOCALNAME  .UpdateValue ( "---"  ) ; 
    __context__.SourceCodeLine = 1820;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . SGLOBALNAME  .UpdateValue ( "---"  ) ; 
    __context__.SourceCodeLine = 1823;
    FCONFIGURELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1824;
    FUPDATELISTTEXT (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1828;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVIS = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1829;
    FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( ILOCALINDEX )) ; 
    __context__.SourceCodeLine = 1831;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IITEMACTIVE = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1833;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IVLINK = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1834;
    ROOM [ IROOM] . LIST [ ILIST] . ITEM [ ILOCALINDEX] . IGUID = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1837;
    return (ushort)( 1) ; 
    
    }
    
private void FPROCESSVLINK (  SplusExecutionContext __context__, ushort ITYPE , ushort IROOM , ushort ILOCALINDEX , CrestronString STEMPLINE ) 
    { 
    ushort I = 0;
    ushort ILIST = 0;
    ushort IVLINK = 0;
    ushort ILOCALID = 0;
    
    CrestronString SDATA;
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    
    __context__.SourceCodeLine = 1845;
    SDATA  .UpdateValue ( STEMPLINE  ) ; 
    __context__.SourceCodeLine = 1846;
    IVLINK = (ushort) ( Functions.Atoi( SDATA ) ) ; 
    __context__.SourceCodeLine = 1847;
    STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
    __context__.SourceCodeLine = 1848;
    STRASH  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
    __context__.SourceCodeLine = 1850;
    
        {
        int __SPLS_TMPVAR__SWTCH_11__ = ((int)ITYPE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 15) ) ) ) 
                {
                __context__.SourceCodeLine = 1852;
                ILIST = (ushort) ( 1 ) ; 
                }
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_11__ == ( 16) ) ) ) 
                {
                __context__.SourceCodeLine = 1853;
                ILIST = (ushort) ( 2 ) ; 
                }
            
            } 
            
        }
        
    
    __context__.SourceCodeLine = 1856;
    if ( Functions.TestForTrue  ( ( IVLINK)  ) ) 
        { 
        __context__.SourceCodeLine = 1858;
        FADDVLINK (  __context__ , (ushort)( ILIST ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), SDATA, (ushort)( IVLINK )) ; 
        __context__.SourceCodeLine = 1859;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( SYS.IISRCPAIR ) && Functions.TestForTrue ( SYS.IRCSTATE )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1860;
            FADDVLINK (  __context__ , (ushort)( ILIST ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILOCALINDEX ), SDATA, (ushort)( IVLINK )) ; 
            }
        
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 1864;
        FREMOVEVLINK (  __context__ , (ushort)( ILIST ), (ushort)( IROOM ), (ushort)( ILOCALINDEX )) ; 
        __context__.SourceCodeLine = 1865;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( SYS.IISRCPAIR ) && Functions.TestForTrue ( SYS.IRCSTATE )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1866;
            FREMOVEVLINK (  __context__ , (ushort)( ILIST ), (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ILOCALINDEX )) ; 
            }
        
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
    
    
    __context__.SourceCodeLine = 1911;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1913;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1915;
    ITYPE = (ushort) ( Functions.Atoi( STEMPHEADER ) ) ; 
    __context__.SourceCodeLine = 1917;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1919;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1920;
        if ( Functions.TestForTrue  ( ( Functions.Find( "COMPLETE" , STEMPLINE ))  ) ) 
            {
            __context__.SourceCodeLine = 1920;
            FPROCESSFINALIZE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 1924;
            if ( Functions.TestForTrue  ( ( Functions.Find( ";" , STEMPLINE ))  ) ) 
                {
                __context__.SourceCodeLine = 1924;
                STRASH  .UpdateValue ( Functions.Remove ( ";" , STEMPLINE )  ) ; 
                }
            
            __context__.SourceCodeLine = 1925;
            ILOCALINDEX = (ushort) ( Functions.Atoi( Functions.Remove( ":" , STEMPLINE ) ) ) ; 
            __context__.SourceCodeLine = 1927;
            if ( Functions.TestForTrue  ( ( ILOCALINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1929;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITYPE <= 4 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1929;
                    FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1930;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 10))  ) ) 
                        {
                        __context__.SourceCodeLine = 1930;
                        FPROCESSVROUTE (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1931;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 14))  ) ) 
                            {
                            __context__.SourceCodeLine = 1931;
                            FPROCESSMACRO (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1932;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 13))  ) ) 
                                {
                                __context__.SourceCodeLine = 1932;
                                FPROCESSROOMS (  __context__ , (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1933;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 15))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1933;
                                    FPROCESSVLINK (  __context__ , (ushort)( ITYPE ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1934;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 16))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1934;
                                        FPROCESSVLINK (  __context__ , (ushort)( ITYPE ), (ushort)( IROOM ), (ushort)( ILOCALINDEX ), STEMPLINE) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1935;
                                        Trace( "NodeMST - fProcessData - didn't catch iLocalIndex") ; 
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1937;
                Trace( "NodeMST - fProcessData - iLocalIndex=0.    {0} iLocalID={1:d};{2}", STEMPHEADER , (ushort)ILOCALINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1917;
        } 
    
    
    }
    
private void FMACROTYPESELECTOR (  SplusExecutionContext __context__, ushort IROOM , ushort IMACRO , ushort ISTATE ) 
    { 
    
    __context__.SourceCodeLine = 1960;
    Trace( "NodeMST - fMacroTypeSelector: iRoom={0:d}, iMacro={1:d}, iState={2:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE) ; 
    __context__.SourceCodeLine = 1962;
    MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
    __context__.SourceCodeLine = 1963;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].MACRO[ IMACRO ].ISPECIALFUNCTION)  ) ) 
        {
        __context__.SourceCodeLine = 1964;
        FRUNMACROSPECIALFUNCTION (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISTATE )) ; 
        }
    
    else 
        { 
        __context__.SourceCodeLine = 1967;
        
            {
            int __SPLS_TMPVAR__SWTCH_12__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_12__ == ( 01) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1969;
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
                    __context__.SourceCodeLine = 1973;
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
                    __context__.SourceCodeLine = 1977;
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
    
    
    __context__.SourceCodeLine = 1992;
    Trace( "NodeMST - fMacroSystem: iRoom={0:d}, iMacro={1:d}, iState={2:d}, iNumOfObjects={3:d}", (ushort)IROOM, (ushort)IMACRO, (ushort)ISTATE, (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS) ; 
    __context__.SourceCodeLine = 1994;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].MACRO[ IMACRO ].INUMOFOBJECTS; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1996;
        ISUBMACRO = (ushort) ( ROOM[ IROOM ].MACRO[ IMACRO ].ILIST[ IINDEX ] ) ; 
        __context__.SourceCodeLine = 1997;
        FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( ISUBMACRO ), (ushort)( ISTATE )) ; 
        __context__.SourceCodeLine = 1994;
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
        
        
        __context__.SourceCodeLine = 2013;
        SYS . IRCSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2014;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 2015;
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
        
        
        __context__.SourceCodeLine = 2022;
        SYS . IRCSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2023;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 2024;
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
        
        
        __context__.SourceCodeLine = 2031;
        SYS . IRCSTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 2032;
        FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
        __context__.SourceCodeLine = 2033;
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
        
        
        __context__.SourceCodeLine = 2041;
        if ( Functions.TestForTrue  ( ( SYS.IPARTITIONENABLED)  ) ) 
            { 
            __context__.SourceCodeLine = 2043;
            SYS . IRCSTATE = (ushort) ( Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) ) ; 
            __context__.SourceCodeLine = 2045;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 2046;
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
        
        
        __context__.SourceCodeLine = 2054;
        SYS . IPARTITIONENABLED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2056;
        FUPDATERC_ENABLE_FB (  __context__ , (ushort)( SYS.IPARTITIONENABLED )) ; 
        __context__.SourceCodeLine = 2058;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Not( PARTSENSESIGNAL[ 1 ] .Value ) != SYS.IRCSTATE))  ) ) 
            { 
            __context__.SourceCodeLine = 2060;
            SYS . IRCSTATE = (ushort) ( PARTSENSESIGNAL[ 1 ] .Value ) ; 
            __context__.SourceCodeLine = 2061;
            FUPDATERC_STATE_FB (  __context__ , (ushort)( SYS.IRCSTATE )) ; 
            __context__.SourceCodeLine = 2062;
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
        
        
        __context__.SourceCodeLine = 2069;
        SYS . IPARTITIONENABLED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2071;
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
        
        
        __context__.SourceCodeLine = 2077;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2080;
        ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID ) ; 
        __context__.SourceCodeLine = 2081;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
        __context__.SourceCodeLine = 2083;
        Functions.Pulse ( 10, SYS_POWERON_GO [ IROOM] ) ; 
        __context__.SourceCodeLine = 2084;
        ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2087;
        if ( Functions.TestForTrue  ( ( Functions.Not( SYS.IRCSTATE ))  ) ) 
            {
            __context__.SourceCodeLine = 2088;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 57 ), (ushort)( 2 )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 2093;
            FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( 59 ), (ushort)( 2 )) ; 
            __context__.SourceCodeLine = 2096;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID ) ; 
            __context__.SourceCodeLine = 2097;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 2099;
            Functions.Pulse ( 10, SYS_POWERON_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 2100;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2102;
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
        
        
        __context__.SourceCodeLine = 2109;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2114;
        if ( Functions.TestForTrue  ( ( Functions.Not( SYS.IRCSTATE ))  ) ) 
            { 
            __context__.SourceCodeLine = 2116;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 2117;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2118;
            ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID ) ; 
            __context__.SourceCodeLine = 2119;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 58 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 2120;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 2125;
            ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID ) ; 
            __context__.SourceCodeLine = 2126;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].LIST[ 1 ].ITEM[ 2 ].IGUID ) ; 
            __context__.SourceCodeLine = 2129;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ IROOM] ) ; 
            __context__.SourceCodeLine = 2130;
            ROOM [ IROOM] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2131;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( IROOM ) , (ushort)( 60 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 2133;
            Functions.Pulse ( 10, SYS_POWEROFF_GO [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] ) ; 
            __context__.SourceCodeLine = 2134;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . ISYSPOWERSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2135;
            I = (ushort) ( FMACROSYSTEM( __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) , (ushort)( 60 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 2138;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ 2 ].IGUID )) ; 
            __context__.SourceCodeLine = 2139;
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
        
        
        __context__.SourceCodeLine = 2155;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2156;
        ISYSPRESET = (ushort) ( SYS_PRESET[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2158;
        if ( Functions.TestForTrue  ( ( ISYSPRESET)  ) ) 
            { 
            __context__.SourceCodeLine = 2160;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 2162;
                if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].DISPLAY[ I ].IDISPLAYACTIVE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 2164;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == ISYSPRESET) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].DISPLAY[ I ].ISYSPRESET == 9) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2166;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 1 )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 2170;
                        FDISPLAYCMD (  __context__ , (ushort)( IROOM ), (ushort)( I ), (ushort)( 0 )) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 2160;
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
        
        
        __context__.SourceCodeLine = 2184;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2186;
        ISRC = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED ) ; 
        __context__.SourceCodeLine = 2187;
        if ( Functions.TestForTrue  ( ( FGETNUMITEMSSELECTED( __context__ , (ushort)( IROOM ) , (ushort)( 2 ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2189;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].LIST[ 2 ].IMAXNUMITEMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IDST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDST  >= __FN_FORSTART_VAL__1) && (IDST  <= __FN_FOREND_VAL__1) ) : ( (IDST  <= __FN_FORSTART_VAL__1) && (IDST  >= __FN_FOREND_VAL__1) ) ; IDST  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 2191;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IFB ) && Functions.TestForTrue ( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IITEMACTIVE )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2193;
                    FMTRXTAKE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IDST ].IGUID ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID ), (ushort)( IDST )) ; 
                    } 
                
                __context__.SourceCodeLine = 2189;
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
        
        
        __context__.SourceCodeLine = 2205;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2207;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 2208;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 2210;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 2211;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 2213;
        ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2214;
        ROOM [ IROOM] . LIST [ 2] . INUMOFITEMSSELECTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2216;
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
        
        
        __context__.SourceCodeLine = 2223;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2225;
        FSETLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 ), (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 2226;
        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 2 ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 2228;
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
        
        
        __context__.SourceCodeLine = 2234;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2235;
        IINDEX = (ushort) ( MTRX_ADMINVSRC_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2237;
        if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 2240;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].IUI_PAGE == 3))  ) ) 
                { 
                __context__.SourceCodeLine = 2242;
                ROOM [ IROOM] . ILASTSRCSELVGUID [ 3 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID ) ; 
                __context__.SourceCodeLine = 2244;
                FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
                __context__.SourceCodeLine = 2245;
                FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
                __context__.SourceCodeLine = 2247;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].IROOMGUID == 17))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2250;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED)  ) ) 
                        { 
                        __context__.SourceCodeLine = 2252;
                        ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED] . IFB = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 2253;
                        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 2255;
                    ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 2256;
                    ROOM [ IROOM] . LIST [ 1] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 2257;
                    FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 2261;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].IUI_PAGE == 4) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].IROOMGUID == 23) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2263;
                    ROOM [ IROOM] . ILASTSRCSELVGUID [ 4 , 1] = (ushort) ( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID ) ; 
                    __context__.SourceCodeLine = 2264;
                    FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ IINDEX ].IGUID )) ; 
                    __context__.SourceCodeLine = 2267;
                    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED)  ) ) 
                        { 
                        __context__.SourceCodeLine = 2269;
                        ROOM [ IROOM] . LIST [ 1] . ITEM [ ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED] . IFB = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 2270;
                        FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].IITEMSELECTED )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 2272;
                    ROOM [ IROOM] . LIST [ 1] . IITEMSELECTED = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 2273;
                    ROOM [ IROOM] . LIST [ 1] . ITEM [ IINDEX] . IFB = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 2274;
                    FUPDATELISTFB (  __context__ , (ushort)( IROOM ), (ushort)( 1 ), (ushort)( IINDEX )) ; 
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
        
        
        __context__.SourceCodeLine = 2284;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2285;
        IINDEX = (ushort) ( MTRX_ADMINVDST_CLICKED[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2288;
        ROOM [ IROOM] . LIST [ 2] . ITEM [ IINDEX] . IFB = (ushort) ( Functions.Not( ROOM[ IROOM ].LIST[ 2 ].ITEM[ IINDEX ].IFB ) ) ; 
        __context__.SourceCodeLine = 2289;
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
        
        
        __context__.SourceCodeLine = 2296;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2297;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2298;
        ISRC = (ushort) ( MTRX_MACRO1_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2300;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2301;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2303;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2305;
            ISRC = (ushort) ( FOTHERROOMSRCNUM( __context__ , (ushort)( ISRC ) ) ) ; 
            __context__.SourceCodeLine = 2306;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2307;
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
        
        
        __context__.SourceCodeLine = 2314;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2315;
        IMACRO = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2316;
        ISRC = (ushort) ( MTRX_MACRO2_SRC[ IMACRO ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2318;
        FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
        __context__.SourceCodeLine = 2319;
        FUPDATEMACROSRC (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ISRC )) ; 
        __context__.SourceCodeLine = 2321;
        if ( Functions.TestForTrue  ( ( SYS.IRCSTATE)  ) ) 
            { 
            __context__.SourceCodeLine = 2323;
            ISRC = (ushort) ( FOTHERROOMSRCNUM( __context__ , (ushort)( ISRC ) ) ) ; 
            __context__.SourceCodeLine = 2324;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].LIST[ 1 ].ITEM[ ISRC ].IGUID )) ; 
            __context__.SourceCodeLine = 2325;
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
        
        
        __context__.SourceCodeLine = 2333;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2334;
        IMACRO = (ushort) ( MTRX_MACRO1_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2336;
        MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
        __context__.SourceCodeLine = 2338;
        Trace( "NodeMST - CHANGE MTRX_Macro1_Dst:  iMacro={0:d}", (ushort)IMACRO) ; 
        __context__.SourceCodeLine = 2339;
        
            {
            int __SPLS_TMPVAR__SWTCH_13__ = ((int)ROOM[ IROOM ].MACRO[ IMACRO ].IMACROTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 07) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 08) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 09) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 10) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 11) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2346;
                    FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 2 )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_13__ == ( 12) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2347;
                    FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2348;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE )) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2351;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( SYS.IRCSTATE ) && Functions.TestForTrue ( SYS.IISRCPAIR )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2353;
            MTRX_MACRO_DST_FB [ FOTHERROOM( __context__ , (ushort)( IROOM ) )]  .Value = (ushort) ( IMACRO ) ; 
            __context__.SourceCodeLine = 2355;
            
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
                        __context__.SourceCodeLine = 2362;
                        FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_14__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2363;
                        FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 2364;
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
        
        
        __context__.SourceCodeLine = 2371;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 2372;
        IMACRO = (ushort) ( MTRX_MACRO2_DST[ 1 ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2374;
        MTRX_MACRO_DST_FB [ IROOM]  .Value = (ushort) ( IMACRO ) ; 
        __context__.SourceCodeLine = 2376;
        Trace( "NodeMST - CHANGE MTRX_Macro2_Dst:  iMacro={0:d}", (ushort)IMACRO) ; 
        __context__.SourceCodeLine = 2378;
        
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
                    __context__.SourceCodeLine = 2385;
                    FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 2 )) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_15__ == ( 12) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2386;
                    FMACROSYSTEM (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2387;
                    FMACROTYPESELECTOR (  __context__ , (ushort)( IROOM ), (ushort)( IMACRO ), (ushort)( ROOM[ IROOM ].MACRO[ 1 ].ISTATE )) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2391;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( SYS.IRCSTATE ) && Functions.TestForTrue ( SYS.IISRCPAIR )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2393;
            MTRX_MACRO_DST_FB [ FOTHERROOM( __context__ , (ushort)( IROOM ) )]  .Value = (ushort) ( IMACRO ) ; 
            __context__.SourceCodeLine = 2395;
            
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
                        __context__.SourceCodeLine = 2402;
                        FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( FOTHERROOMSRCNUM( __context__ , (ushort)( 2 ) ) )) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_16__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 2403;
                        FMACROSYSTEM (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IMACRO ), (ushort)( 0 )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 2404;
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
        
        __context__.SourceCodeLine = 2418;
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
        
        __context__.SourceCodeLine = 2422;
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
        
        __context__.SourceCodeLine = 2426;
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
        
        __context__.SourceCodeLine = 2430;
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
        
        __context__.SourceCodeLine = 2434;
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
        
        __context__.SourceCodeLine = 2438;
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
        
        __context__.SourceCodeLine = 2442;
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
        
        __context__.SourceCodeLine = 2446;
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
        
        __context__.SourceCodeLine = 2451;
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
        
        __context__.SourceCodeLine = 2456;
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
        
        
        __context__.SourceCodeLine = 2464;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2465;
        ROOM [ IROOM] . ICAMSEL = (ushort) ( CAM_SELECT[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2467;
        FUPDATECAMFB (  __context__ , (ushort)( IROOM )) ; 
        __context__.SourceCodeLine = 2469;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ICAMSEL)  ) ) 
            { 
            __context__.SourceCodeLine = 2471;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].CAM[ ROOM[ IROOM ].ICAMSEL ].IVSRCGUID )) ; 
            __context__.SourceCodeLine = 2472;
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
    
    
    __context__.SourceCodeLine = 2486;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IPAGE ) && Functions.TestForTrue ( ISUB )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2488;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].ILASTSRCSELVGUID[ IPAGE , ISUB ])  ) ) 
            { 
            __context__.SourceCodeLine = 2490;
            FUPDATECONFMONITORRTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].ILASTSRCSELVGUID[ IPAGE , ISUB ] )) ; 
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
        
        
        __context__.SourceCodeLine = 2498;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2500;
        ROOM [ IROOM] . IUI_PAGE = (ushort) ( UI_PAGE[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2502;
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
        
        
        __context__.SourceCodeLine = 2508;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 2510;
        ROOM [ IROOM] . IUI_SUB = (ushort) ( UI_SUB[ IROOM ] .UshortValue ) ; 
        __context__.SourceCodeLine = 2512;
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
        
        
        __context__.SourceCodeLine = 2526;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2528;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2529;
            FPROCESSDATA (  __context__ , (ushort)( 1 ), STEMP) ; 
            __context__.SourceCodeLine = 2526;
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
        
        
        __context__.SourceCodeLine = 2537;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , FROM_GLOBAL_RX__DOLLAR___2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 2539;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , FROM_GLOBAL_RX__DOLLAR___2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 2540;
            FPROCESSDATA (  __context__ , (ushort)( 2 ), STEMP) ; 
            __context__.SourceCodeLine = 2537;
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
        
        __context__.SourceCodeLine = 2551;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2566;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2568;
            ROOM [ I] . LIST [ 1] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2569;
            ROOM [ I] . LIST [ 1] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2570;
            ROOM [ I] . LIST [ 1] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2571;
            ROOM [ I] . LIST [ 1] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2572;
            ROOM [ I] . LIST [ 1] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2573;
            ROOM [ I] . LIST [ 1] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2575;
            ROOM [ I] . LIST [ 2] . IMAXNUMITEMS = (ushort) ( 30 ) ; 
            __context__.SourceCodeLine = 2576;
            ROOM [ I] . LIST [ 2] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 2577;
            ROOM [ I] . LIST [ 2] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2578;
            ROOM [ I] . LIST [ 2] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2579;
            ROOM [ I] . LIST [ 2] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2580;
            ROOM [ I] . LIST [ 2] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2583;
            ROOM [ I] . LIST [ 5] . IMAXNUMITEMS = (ushort) ( 9 ) ; 
            __context__.SourceCodeLine = 2584;
            ROOM [ I] . LIST [ 5] . INUMOFTEXTCOLUMNS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2585;
            ROOM [ I] . LIST [ 5] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2586;
            ROOM [ I] . LIST [ 5] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2587;
            ROOM [ I] . LIST [ 5] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2588;
            ROOM [ I] . LIST [ 5] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2590;
            ROOM [ I] . LIST [ 6] . IMAXNUMITEMS = (ushort) ( 100 ) ; 
            __context__.SourceCodeLine = 2591;
            ROOM [ I] . LIST [ 6] . INUMOFTEXTCOLUMNS = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 2592;
            ROOM [ I] . LIST [ 6] . ILISTUSESFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2593;
            ROOM [ I] . LIST [ 6] . ILISTUSESVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2594;
            ROOM [ I] . LIST [ 6] . ILISTUSESICON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2595;
            ROOM [ I] . LIST [ 6] . ILISTUSESTEXT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2597;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)9; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 2599;
                ROOM [ I] . LIST [ 5] . ITEM [ J] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2600;
                ROOM [ I] . LIST [ 5] . ITEM [ (J + 20)] . IITEMACTIVE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2597;
                } 
            
            __context__.SourceCodeLine = 2566;
            } 
        
        __context__.SourceCodeLine = 2604;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)2; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 2606;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)10; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (J  >= __FN_FORSTART_VAL__4) && (J  <= __FN_FOREND_VAL__4) ) : ( (J  <= __FN_FORSTART_VAL__4) && (J  >= __FN_FOREND_VAL__4) ) ; J  += (ushort)__FN_FORSTEP_VAL__4) 
                {
                __context__.SourceCodeLine = 2607;
                ROOM [ I] . CAM [ J] . IVSRCLOCALID = (ushort) ( (J + 20) ) ; 
                __context__.SourceCodeLine = 2606;
                }
            
            __context__.SourceCodeLine = 2608;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)40; 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (J  >= __FN_FORSTART_VAL__5) && (J  <= __FN_FOREND_VAL__5) ) : ( (J  <= __FN_FORSTART_VAL__5) && (J  >= __FN_FOREND_VAL__5) ) ; J  += (ushort)__FN_FORSTEP_VAL__5) 
                {
                __context__.SourceCodeLine = 2609;
                ROOM [ I] . DISPLAY [ J] . IVDSTLOCALID = (ushort) ( J ) ; 
                __context__.SourceCodeLine = 2608;
                }
            
            __context__.SourceCodeLine = 2604;
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
    
    TO_MST_TX__DOLLAR__ = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        TO_MST_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_MST_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_MST_TX__DOLLAR____AnalogSerialOutput__ + i, TO_MST_TX__DOLLAR__[i+1] );
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
    
    __SPLS_TMPVAR__WAITLABEL_18___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_18___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_19___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_19___CallbackFn );
    
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

public UserModuleClass_L3_UA_HSIB_NODEMST_V1_0_83 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_18___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_19___Callback;


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
const uint TO_MST_TX__DOLLAR____AnalogSerialOutput__ = 18;
const uint MTRX_ADMINVSRC_FB__DOLLAR____AnalogSerialOutput__ = 20;
const uint MTRX_ADMINVDST_FB__DOLLAR____AnalogSerialOutput__ = 22;
const uint CAM_FB__DOLLAR____AnalogSerialOutput__ = 24;
const uint CAM_PRESETS_FB__DOLLAR____AnalogSerialOutput__ = 26;
const uint DISPLAY_FB__DOLLAR____AnalogSerialOutput__ = 28;
const uint MTRX_MACRO_SRC_FB__DOLLAR____AnalogSerialOutput__ = 30;
const uint MTRX_MACRO_DST_FB__DOLLAR____AnalogSerialOutput__ = 32;
const uint ROOMNAME__DOLLAR___OUT__AnalogSerialOutput__ = 34;

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
    public ushort  IISCAMERA = 0;
    
    [SplusStructAttribute(17, false, false)]
    public ushort  IISDISPLAY = 0;
    
    [SplusStructAttribute(18, false, false)]
    public ushort  ICAMLOCALID = 0;
    
    [SplusStructAttribute(19, false, false)]
    public ushort  ICAMGUID = 0;
    
    [SplusStructAttribute(20, false, false)]
    public ushort  IDISPLAYLOCALID = 0;
    
    [SplusStructAttribute(21, false, false)]
    public ushort  IDISPLAYGUID = 0;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  ISYSPRESET = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IISUSB = 0;
    
    [SplusStructAttribute(24, false, false)]
    public ushort  IISAUDIODST = 0;
    
    [SplusStructAttribute(25, false, false)]
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
        ITEM  = new STLISTITEM[ 101 ];
        for( uint i = 0; i < 101; i++ )
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
    public ushort  [,] ILASTSRCSELVGUID;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IUI_PAGE = 0;
    
    [SplusStructAttribute(14, false, false)]
    public ushort  IUI_SUB = 0;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ILASTSRCSELVGUID  = new ushort[ 21,21 ];
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
        LIST  = new STLIST[ 7 ];
        for( uint i = 0; i < 7; i++ )
        {
            LIST [i] = new STLIST( Owner, true );
            
        }
        MACRO  = new STMACRO[ 101 ];
        for( uint i = 0; i < 101; i++ )
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
