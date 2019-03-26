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

namespace UserModule_L3_UA_HSIB_NODEDSP_V1_0_60
{
    public class UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_60 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RC_STATE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDVOLUP1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDVOLUP2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDVOLDN1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDVOLDN2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTEON1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTEON2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTEOFF1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTEOFF2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTETOG1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDMUTETOG2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDDEFAULTPOINT1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FIXEDDEFAULTPOINT2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPVOLUP1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPVOLUP2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPVOLDN1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPVOLDN2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTEON1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTEON2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTEOFF1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTEOFF2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTETOG1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DSPMUTETOG2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DEFAULTPOINTALL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DEFAULTPOINT1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DEFAULTPOINT2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VOLFBRANGE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERT2BYTE1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERT2BYTE2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERTDB1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERTDB2;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> DATAINIT_RX__DOLLAR__1;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> DATAINIT_RX__DOLLAR__2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FIXEDMUTEFB1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FIXEDMUTEFB2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FIXEDMUTENOTFB1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FIXEDMUTENOTFB2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DSPMUTEFB1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DSPMUTEFB2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DSPMUTENOTFB1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DSPMUTENOTFB2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FIXEDVOLGAUGEFB1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FIXEDVOLGAUGEFB2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSPVOLGAUGEFB1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSPVOLGAUGEFB2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIST_NUMOFITEMS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSPVOLDBFB__DOLLAR__1;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSPVOLDBFB__DOLLAR__2;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LIST_FB__DOLLAR__1;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LIST_FB__DOLLAR__2;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSPPOINTNAME__DOLLAR__1;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSPPOINTNAME__DOLLAR__2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSPVOLDB1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DSPVOLDB2;
        STROOM [] ROOM;
        ushort IGROUPSEM = 0;
        ushort [] IVOLFBRANGE;
        CrestronString STRASH;
        private CrestronString FREMWHITESPACE (  SplusExecutionContext __context__, CrestronString SSRC ) 
            { 
            ushort I = 0;
            
            CrestronString STEMP;
            CrestronString STEMP2;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 252;
            STEMP  .UpdateValue ( SSRC  ) ; 
            __context__.SourceCodeLine = 253;
            while ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 255;
                I = (ushort) ( Functions.GetC( STEMP ) ) ; 
                __context__.SourceCodeLine = 256;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( I >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I <= 126 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 256;
                    STEMP2  .UpdateValue ( STEMP2 + Functions.Chr (  (int) ( I ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 253;
                } 
            
            __context__.SourceCodeLine = 258;
            return ( STEMP2 ) ; 
            
            }
            
        private CrestronString FTRUEFALSE (  SplusExecutionContext __context__, ushort I , ushort IINVERTED ) 
            { 
            
            __context__.SourceCodeLine = 263;
            if ( Functions.TestForTrue  ( ( IINVERTED)  ) ) 
                {
                __context__.SourceCodeLine = 263;
                I = (ushort) ( Functions.Not( I ) ) ; 
                }
            
            __context__.SourceCodeLine = 265;
            if ( Functions.TestForTrue  ( ( I)  ) ) 
                {
                __context__.SourceCodeLine = 265;
                return ( "true" ) ; 
                }
            
            __context__.SourceCodeLine = 266;
            return ( "false" ) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 271;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private ushort FOTHERLIST (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 275;
            return (ushort)( (3 - ILIST)) ; 
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 288;
            Trace( "in NodeDSP fSendListFB - iRoom = {0:d}, iList = {1:d}, sData = {2}", (ushort)IROOM, (ushort)ILIST, SDATA ) ; 
            __context__.SourceCodeLine = 290;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 292;
                        LIST_FB__DOLLAR__1 [ ILIST]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 293;
                        LIST_FB__DOLLAR__2 [ ILIST]  .UpdateValue ( SDATA  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void FUPDATELISTVIS (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 302;
            STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 303;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                {
                __context__.SourceCodeLine = 303;
                MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS[ ILIST ]) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 306;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 308;
                    MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS[ ILIST ]) ; 
                    __context__.SourceCodeLine = 306;
                    } 
                
                __context__.SourceCodeLine = 310;
                MakeString ( STEMP , "{0};|}}", STEMP ) ; 
                } 
            
            __context__.SourceCodeLine = 312;
            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
            
            }
            
        private ushort FSETVOLFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            ushort IVOLFB = 0;
            
            CrestronString SVOLFB;
            SVOLFB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 326;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE)  ) ) 
                {
                __context__.SourceCodeLine = 326;
                IVOLFB = (ushort) ( (((ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) * IVOLFBRANGE[ IROOM ]) / ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 330;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 331;
            MakeString ( SVOLFB , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 332;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 336;
                        DSPVOLGAUGEFB1 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 337;
                        DSPVOLDBFB__DOLLAR__1 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 338;
                        DSPVOLDB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 340;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 342;
                            FIXEDVOLGAUGEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 347;
                        DSPVOLGAUGEFB2 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 348;
                        DSPVOLDBFB__DOLLAR__2 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 349;
                        DSPVOLDB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 351;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 353;
                            FIXEDVOLGAUGEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FSETMUTEFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 361;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 365;
                        DSPMUTEFB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 366;
                        DSPMUTENOTFB1 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 368;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 370;
                            FIXEDMUTEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 371;
                            FIXEDMUTENOTFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 376;
                        DSPMUTEFB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 377;
                        DSPMUTENOTFB2 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 379;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 381;
                            FIXEDMUTEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 382;
                            FIXEDMUTENOTFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private short FCHECKBOUNDS (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , short SIVAL ) 
            { 
            
            __context__.SourceCodeLine = 390;
            return (short)( Functions.SMin( Functions.SMax( SIVAL , ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN ) , ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMAX )) ; 
            
            }
            
        private void FSENDVOL (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort K = 0;
            ushort L = 0;
            
            CrestronString SVOLCMDVALUE;
            SVOLCMDVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 399;
            MakeString ( SVOLCMDVALUE , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 401;
            FSETVOLFB (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FSENDMUTE (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            ushort I = 0;
            ushort J = 0;
            ushort K = 0;
            ushort L = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 410;
            FSETMUTEFB (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FGROUPMANAGER (  SplusExecutionContext __context__, ushort IROOM , ushort I , CrestronString STYPE ) 
            { 
            ushort J = 0;
            ushort K = 0;
            ushort L = 0;
            
            
            __context__.SourceCodeLine = 417;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].IGROUP ) && Functions.TestForTrue ( RC_STATE  .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 419;
                K = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                __context__.SourceCodeLine = 420;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].GROUP[ K ].INUMOFMEMBERS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( L  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (L  >= __FN_FORSTART_VAL__1) && (L  <= __FN_FOREND_VAL__1) ) : ( (L  <= __FN_FORSTART_VAL__1) && (L  >= __FN_FOREND_VAL__1) ) ; L  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 422;
                    J = (ushort) ( ROOM[ IROOM ].GROUP[ K ].IGROUPMEMBERS[ L ] ) ; 
                    __context__.SourceCodeLine = 423;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 425;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 427;
                            ROOM [ IROOM] . POINT [ J] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( J ) , (short)( ROOM[ IROOM ].POINT[ I ].SIVOLSTATE ) ) ) ; 
                            __context__.SourceCodeLine = 428;
                            FSENDVOL (  __context__ , (ushort)( IROOM ), (ushort)( J )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 432;
                            Trace( "Node_DSP: Point[{0:d}] Volume control is disabled. Group Vol command blocked at this control Point.", (ushort)J) ; 
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 436;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 438;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 440;
                                ROOM [ IROOM] . POINT [ J] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ; 
                                __context__.SourceCodeLine = 441;
                                FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( J )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 445;
                                Trace( "Node_DSP: Point[{0:d}] Mute control is disabled. Group Mute command blocked at this control Point.", (ushort)J) ; 
                                } 
                            
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 420;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 453;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                    {
                    __context__.SourceCodeLine = 453;
                    FSENDVOL (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 454;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                        {
                        __context__.SourceCodeLine = 454;
                        FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FDEFAULTPOINT (  SplusExecutionContext __context__, ushort IROOM , ushort I ) 
            { 
            
            __context__.SourceCodeLine = 460;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 462;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( ROOM[ IROOM ].POINT[ I ].SIVOLDEFAULT ) ; 
                __context__.SourceCodeLine = 463;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 465;
                Trace( "NodeDSP - fDefaultPoint - Room[iRoom].Point {0:d}, {1}: attempted to default a disabled volume field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
                }
            
            __context__.SourceCodeLine = 466;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 468;
                ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ I ].IMUTEDEFAULT ) ; 
                __context__.SourceCodeLine = 469;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 471;
                Trace( "NodeDSP - fDefaultPoint - Point {0:d}, {1}: attempted to default a disabled mute field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
                }
            
            
            }
            
        object INSERT2BYTE1_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                ushort J = 0;
                ushort IROOM = 0;
                
                
                __context__.SourceCodeLine = 483;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 484;
                IROOM = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 486;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 488;
                    J = (ushort) ( ((INSERT2BYTE1[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                    __context__.SourceCodeLine = 489;
                    ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                    __context__.SourceCodeLine = 490;
                    FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 492;
                    Trace( "NodeDSP - Insert2Byte - Point {0:d}, {1}: attempted to change a disabled vol field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INSERT2BYTE2_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort J = 0;
            ushort IROOM = 0;
            
            
            __context__.SourceCodeLine = 498;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 499;
            IROOM = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 501;
            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                { 
                __context__.SourceCodeLine = 503;
                J = (ushort) ( ((INSERT2BYTE2[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                __context__.SourceCodeLine = 504;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                __context__.SourceCodeLine = 505;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 507;
                Trace( "NodeDSP - Insert2Byte - Point {0:d}, {1}: attempted to change a disabled vol field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object INSERTDB1_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        short SIINSERTDB = 0;
        
        
        __context__.SourceCodeLine = 515;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 516;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 518;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 520;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB1[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 521;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 523;
            Trace( "NodeDSP - InsertDB - Point {0:d}, {1}: attempted to change a disabled vol field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INSERTDB2_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        short SIINSERTDB = 0;
        
        
        __context__.SourceCodeLine = 530;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 531;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 533;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 535;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB2[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 536;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 538;
            Trace( "NodeDSP - InsertDB - Point {0:d}, {1}: attempted to change a disabled vol field", (ushort)I, ROOM [ IROOM] . POINT [ I] . SGLOBALNAME ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEFAULTPOINT1_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 545;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 546;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 548;
        FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEFAULTPOINT2_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 554;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 555;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 557;
        FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEFAULTPOINTALL_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort K = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        CrestronString STEMP2;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        
        __context__.SourceCodeLine = 567;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 569;
        I = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 570;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 572;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 574;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 576;
                    FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 580;
                    J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                    __context__.SourceCodeLine = 581;
                    MakeString ( STEMP , ":{0:d};", (short)J) ; 
                    __context__.SourceCodeLine = 582;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 584;
                        STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                        __context__.SourceCodeLine = 585;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 587;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( J )) ; 
                            __context__.SourceCodeLine = 588;
                            Trace( "Node_DSP: DefaultPointAll just propagated Point[{0:d}], which passed the gauntlet.", (short)J) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 592;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 594;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BVOLDEFAULTISDISABLED ) || Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BMUTEDEFAULTISDISABLED )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 596;
                            Trace( "Node_DSP: DefaultPointAll just propagated Point[{0:d}] to group number {1:d}d. This Point has a disabled VolDefault or MuteDefault. Just an FYI.", (short)I, (short)ROOM[ IROOM ].POINT[ I ].IGROUP) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 570;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RC_STATE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort K = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        CrestronString STEMP2;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        
        __context__.SourceCodeLine = 615;
        if ( Functions.TestForTrue  ( ( Functions.Not( IGROUPSEM ))  ) ) 
            { 
            __context__.SourceCodeLine = 617;
            IGROUPSEM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 618;
            Functions.Delay (  (int) ( 100 ) ) ; 
            __context__.SourceCodeLine = 620;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 622;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 628;
                    J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                    __context__.SourceCodeLine = 629;
                    MakeString ( STEMP , ":{0:d};", (short)J) ; 
                    __context__.SourceCodeLine = 631;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 633;
                        STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                        __context__.SourceCodeLine = 634;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 636;
                            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "vol") ; 
                            __context__.SourceCodeLine = 637;
                            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "mute") ; 
                            __context__.SourceCodeLine = 638;
                            Trace( "Node_DSP: Group update just propagated Point[{0:d}] with group number {1:d}. Passed the gauntlet.", (short)J, (ushort)ROOM[ IROOM ].POINT[ J ].IGROUP) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 643;
                            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                            __context__.SourceCodeLine = 644;
                            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
                            __context__.SourceCodeLine = 645;
                            Trace( "Node_DSP: Group update just propagated Point[{0:d}] with group number {1:d} based on the Point being the lowest index in the group.", (short)I, (ushort)ROOM[ IROOM ].POINT[ I ].IGROUP) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 620;
                } 
            
            __context__.SourceCodeLine = 655;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 26 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)50; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 657;
                FUPDATELISTVIS (  __context__ , (ushort)( 1 ), (ushort)( ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ), (ushort)( I )) ; 
                __context__.SourceCodeLine = 658;
                FUPDATELISTVIS (  __context__ , (ushort)( 1 ), (ushort)( FOTHERLIST( __context__ , (ushort)( ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ) ) ), (ushort)( I )) ; 
                __context__.SourceCodeLine = 659;
                FUPDATELISTVIS (  __context__ , (ushort)( 1 ), (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].POINT[ I ].IPOINTTYPE ), (ushort)( I )) ; 
                __context__.SourceCodeLine = 660;
                FUPDATELISTVIS (  __context__ , (ushort)( 1 ), (ushort)( FOTHERLIST( __context__ , (ushort)( ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].POINT[ I ].IPOINTTYPE ) ) ), (ushort)( I )) ; 
                __context__.SourceCodeLine = 655;
                } 
            
            __context__.SourceCodeLine = 663;
            IGROUPSEM = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLUP1_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 670;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 671;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 673;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 675;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 676;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 677;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 678;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP1[ I ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 680;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 681;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 678;
                } 
            
            __context__.SourceCodeLine = 683;
            while ( Functions.TestForTrue  ( ( DSPVOLUP1[ I ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 685;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 686;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 687;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 683;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 690;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLUP2_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 696;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 697;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 699;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 701;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 702;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 703;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 704;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP2[ I ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 706;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 707;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 704;
                } 
            
            __context__.SourceCodeLine = 709;
            while ( Functions.TestForTrue  ( ( DSPVOLUP2[ I ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 711;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 712;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 713;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 709;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 716;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLDN1_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 723;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 724;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 726;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 728;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 729;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 730;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 731;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN1[ I ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 733;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 734;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 731;
                } 
            
            __context__.SourceCodeLine = 736;
            while ( Functions.TestForTrue  ( ( DSPVOLDN1[ I ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 738;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 739;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 740;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 736;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 743;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLDN2_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 750;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 751;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 753;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 755;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 756;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 757;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 758;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN2[ I ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 760;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 761;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 758;
                } 
            
            __context__.SourceCodeLine = 763;
            while ( Functions.TestForTrue  ( ( DSPVOLDN2[ I ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 765;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 766;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 767;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 763;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 770;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTETOG1_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 778;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 779;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 781;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 783;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 784;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 786;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTETOG2_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 794;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 795;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 797;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 799;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 800;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 802;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEON1_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 810;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 811;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 813;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 815;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 816;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 818;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEON2_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 825;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 826;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 828;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 830;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 831;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 833;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEOFF1_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 840;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 841;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 843;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 845;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 846;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 848;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEOFF2_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 854;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 855;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 857;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 859;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 860;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 862;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLUP1_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 875;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 876;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 877;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 879;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 881;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 882;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 883;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 884;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 886;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 887;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 884;
                } 
            
            __context__.SourceCodeLine = 889;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 891;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 892;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 893;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 889;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 896;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLUP2_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 902;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 903;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 904;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 906;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 908;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 909;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 910;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 911;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 913;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 914;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 911;
                } 
            
            __context__.SourceCodeLine = 916;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 918;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 919;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 920;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 916;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 923;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLDN1_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 930;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 931;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 932;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 934;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 936;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 937;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 938;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 939;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 941;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 942;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 939;
                } 
            
            __context__.SourceCodeLine = 944;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 946;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 947;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 948;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 944;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 951;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLDN2_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 958;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 959;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 960;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 962;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 964;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 965;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 966;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 967;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 969;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 970;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 967;
                } 
            
            __context__.SourceCodeLine = 972;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 974;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 975;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 976;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 972;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 979;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTETOG1_OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 986;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 987;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 989;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 991;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 992;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 994;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTETOG2_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1001;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1002;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1004;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1006;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 1007;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1009;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEON1_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1016;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1017;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1019;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1021;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1022;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1024;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEON2_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1030;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1031;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1033;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1035;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1036;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1038;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEOFF1_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1044;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1045;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1047;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1049;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1050;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1052;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEOFF2_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1057;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1058;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1060;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1062;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1063;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1065;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLFBRANGE_OnChange_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1081;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1083;
        if ( Functions.TestForTrue  ( ( VOLFBRANGE[ IROOM ] .UshortValue)  ) ) 
            {
            __context__.SourceCodeLine = 1083;
            IVOLFBRANGE [ IROOM] = (ushort) ( VOLFBRANGE[ IROOM ] .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1084;
            IVOLFBRANGE [ IROOM] = (ushort) ( 936 ) ; 
            }
        
        __context__.SourceCodeLine = 1086;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1088;
            FSETVOLFB (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
            __context__.SourceCodeLine = 1086;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FPROCESSLIST (  SplusExecutionContext __context__, ushort IROOM ) 
    { 
    ushort IINDEX = 0;
    ushort ILIST = 0;
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    
    __context__.SourceCodeLine = 1108;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( ILIST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__1) && (ILIST  <= __FN_FOREND_VAL__1) ) : ( (ILIST  <= __FN_FORSTART_VAL__1) && (ILIST  >= __FN_FOREND_VAL__1) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1110;
        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1111;
        Functions.Delay (  (int) ( 10 ) ) ; 
        __context__.SourceCodeLine = 1108;
        } 
    
    
    }
    
private void FPROCESSLINE (  SplusExecutionContext __context__, ushort IROOM , ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort I = 0;
    ushort IERR = 0;
    ushort IGROUP = 0;
    
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
    
    
    __context__.SourceCodeLine = 1126;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1128;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1130;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1131;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1132;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1134;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1134;
            ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1135;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1135;
                ROOM [ IROOM] . POINT [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1136;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1136;
                    ROOM [ IROOM] . POINT [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1137;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1137;
                        ROOM [ IROOM] . POINT [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1138;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "fixed_id" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1140;
                            ROOM [ IROOM] . POINT [ IINDEX] . IFIXEDID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1141;
                            ROOM [ IROOM] . FIXEDTOLOCALID [ Functions.Atoi( STEMPVALUE )] = (ushort) ( IINDEX ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1143;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "group" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1143;
                                ROOM [ IROOM] . POINT [ IINDEX] . IGROUP = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1144;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1144;
                                    ROOM [ IROOM] . POINT [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1145;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_max" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1145;
                                        ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1146;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_min" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1146;
                                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1147;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_vol" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1147;
                                                ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1148;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_mute" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1148;
                                                    ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1149;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol_disabled" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1149;
                                                        ROOM [ IROOM] . POINT [ IINDEX] . BVOLISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1150;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute_disabled" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1150;
                                                            ROOM [ IROOM] . POINT [ IINDEX] . BMUTEISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1151;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "point_type" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1151;
                                                                ROOM [ IROOM] . POINT [ IINDEX] . IPOINTTYPE = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                { 
                                                                __context__.SourceCodeLine = 1154;
                                                                IERR = (ushort) ( 1 ) ; 
                                                                __context__.SourceCodeLine = 1155;
                                                                Trace( "NodeDSP - fProcessLine error - didn't catch key - type={0:d}, GUID={1:d}, key={2}, value={3}", (ushort)ITYPE, (ushort)IINDEX, STEMPKEY , STEMPVALUE ) ; 
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
        
        __context__.SourceCodeLine = 1128;
        } 
    
    __context__.SourceCodeLine = 1159;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1162;
        ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1164;
        ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( (ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMAX - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) ) ; 
        __context__.SourceCodeLine = 1166;
        ROOM [ IROOM] . IINDEXPRIMARY [ IINDEX] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1168;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . IINDEXRC [ (IINDEX + 25)] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1171;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE == 0) ) || Functions.TestForTrue ( Functions.BoolToInt ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE > 50000 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1173;
            ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1175;
            Trace( "NodeDSP - error parsing iRoom={0:d}, iIndex={1:d} - iVolRange calculated to be zero", (ushort)IROOM, (ushort)IINDEX) ; 
            } 
        
        __context__.SourceCodeLine = 1178;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP)  ) ) 
            { 
            __context__.SourceCodeLine = 1180;
            IGROUP = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) ; 
            __context__.SourceCodeLine = 1182;
            ROOM [ IROOM] . GROUP [ IGROUP] . INUMOFMEMBERS = (ushort) ( (ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS + 1) ) ; 
            __context__.SourceCodeLine = 1184;
            ROOM [ IROOM] . GROUP [ IGROUP] . IGROUPMEMBERS [ ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS] = (ushort) ( IINDEX ) ; 
            } 
        
        __context__.SourceCodeLine = 1187;
        
            {
            int __SPLS_TMPVAR__SWTCH_4__ = ((int)IROOM);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1191;
                    DSPPOINTNAME__DOLLAR__1 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1193;
                    DSPPOINTNAME__DOLLAR__2 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1197;
                    DSPPOINTNAME__DOLLAR__2 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1198;
                    DSPPOINTNAME__DOLLAR__1 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1202;
        ROOM [ IROOM] . POINT [ IINDEX] . ILISTITEMVIS [ ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1203;
        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE ), (ushort)( IINDEX )) ; 
        __context__.SourceCodeLine = 1204;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . POINT [ (IINDEX + (50 / 2))] . ILISTITEMVIS [ ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1205;
        FUPDATELISTVIS (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE ), (ushort)( IINDEX )) ; 
        } 
    
    
    }
    
private void FPROCESSINIT (  SplusExecutionContext __context__, ushort IROOM , CrestronString STEMPINITDATA ) 
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
    
    
    __context__.SourceCodeLine = 1220;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1221;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1223;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_POINTS" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1223;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1224;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_PRESETS" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1224;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1225;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1225;
                ITYPE = (ushort) ( 13 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1226;
                Trace( "NodeDSP - in fProcessInit - didn't catch header type - {0}", STEMPHEADER ) ; 
                }
            
            }
        
        }
    
    __context__.SourceCodeLine = 1228;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1230;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1231;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1233;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 1234;
            FPROCESSLIST (  __context__ , (ushort)( IROOM )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1238;
            STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
            __context__.SourceCodeLine = 1239;
            IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1241;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1243;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_5__ = ((int)ITYPE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 1247;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( 6 ) ; 
                            __context__.SourceCodeLine = 1248;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.ToInteger( -( 20 ) ) ) ; 
                            __context__.SourceCodeLine = 1249;
                            ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( 26 ) ; 
                            __context__.SourceCodeLine = 1250;
                            ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1251;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 1253;
                            FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1259;
                Trace( "NodeDSP - fProcessInit error, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1228;
        } 
    
    
    }
    
object DATAINIT_RX__DOLLAR__1_OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
        
        
        __context__.SourceCodeLine = 1276;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1277;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1279;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1280;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1277;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DATAINIT_RX__DOLLAR__2_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
        
        
        __context__.SourceCodeLine = 1288;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1289;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1291;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1292;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1289;
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
    CrestronString STEMP2;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1309;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1311;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1313;
            if ( Functions.TestForTrue  ( ( VOLFBRANGE[ I ] .UshortValue)  ) ) 
                {
                __context__.SourceCodeLine = 1313;
                IVOLFBRANGE [ I] = (ushort) ( VOLFBRANGE[ I ] .UshortValue ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1314;
                IVOLFBRANGE [ I] = (ushort) ( 936 ) ; 
                }
            
            __context__.SourceCodeLine = 1311;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    IVOLFBRANGE  = new ushort[ 3 ];
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    ROOM  = new STROOM[ 3 ];
    for( uint i = 0; i < 3; i++ )
    {
        ROOM [i] = new STROOM( this, true );
        ROOM [i].PopulateCustomAttributeList( false );
        
    }
    
    RC_STATE = new Crestron.Logos.SplusObjects.DigitalInput( RC_STATE__DigitalInput__, this );
    m_DigitalInputList.Add( RC_STATE__DigitalInput__, RC_STATE );
    
    FIXEDVOLUP1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLUP1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDVOLUP1__DigitalInput__ + i, FIXEDVOLUP1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDVOLUP1__DigitalInput__ + i, FIXEDVOLUP1[i+1] );
    }
    
    FIXEDVOLUP2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLUP2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDVOLUP2__DigitalInput__ + i, FIXEDVOLUP2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDVOLUP2__DigitalInput__ + i, FIXEDVOLUP2[i+1] );
    }
    
    FIXEDVOLDN1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLDN1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDVOLDN1__DigitalInput__ + i, FIXEDVOLDN1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDVOLDN1__DigitalInput__ + i, FIXEDVOLDN1[i+1] );
    }
    
    FIXEDVOLDN2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLDN2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDVOLDN2__DigitalInput__ + i, FIXEDVOLDN2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDVOLDN2__DigitalInput__ + i, FIXEDVOLDN2[i+1] );
    }
    
    FIXEDMUTEON1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEON1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTEON1__DigitalInput__ + i, FIXEDMUTEON1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTEON1__DigitalInput__ + i, FIXEDMUTEON1[i+1] );
    }
    
    FIXEDMUTEON2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEON2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTEON2__DigitalInput__ + i, FIXEDMUTEON2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTEON2__DigitalInput__ + i, FIXEDMUTEON2[i+1] );
    }
    
    FIXEDMUTEOFF1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEOFF1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTEOFF1__DigitalInput__ + i, FIXEDMUTEOFF1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTEOFF1__DigitalInput__ + i, FIXEDMUTEOFF1[i+1] );
    }
    
    FIXEDMUTEOFF2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEOFF2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTEOFF2__DigitalInput__ + i, FIXEDMUTEOFF2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTEOFF2__DigitalInput__ + i, FIXEDMUTEOFF2[i+1] );
    }
    
    FIXEDMUTETOG1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTETOG1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTETOG1__DigitalInput__ + i, FIXEDMUTETOG1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTETOG1__DigitalInput__ + i, FIXEDMUTETOG1[i+1] );
    }
    
    FIXEDMUTETOG2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTETOG2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDMUTETOG2__DigitalInput__ + i, FIXEDMUTETOG2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDMUTETOG2__DigitalInput__ + i, FIXEDMUTETOG2[i+1] );
    }
    
    FIXEDDEFAULTPOINT1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDDEFAULTPOINT1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDDEFAULTPOINT1__DigitalInput__ + i, FIXEDDEFAULTPOINT1__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDDEFAULTPOINT1__DigitalInput__ + i, FIXEDDEFAULTPOINT1[i+1] );
    }
    
    FIXEDDEFAULTPOINT2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDDEFAULTPOINT2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FIXEDDEFAULTPOINT2__DigitalInput__ + i, FIXEDDEFAULTPOINT2__DigitalInput__, this );
        m_DigitalInputList.Add( FIXEDDEFAULTPOINT2__DigitalInput__ + i, FIXEDDEFAULTPOINT2[i+1] );
    }
    
    DSPVOLUP1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLUP1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPVOLUP1__DigitalInput__ + i, DSPVOLUP1__DigitalInput__, this );
        m_DigitalInputList.Add( DSPVOLUP1__DigitalInput__ + i, DSPVOLUP1[i+1] );
    }
    
    DSPVOLUP2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLUP2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPVOLUP2__DigitalInput__ + i, DSPVOLUP2__DigitalInput__, this );
        m_DigitalInputList.Add( DSPVOLUP2__DigitalInput__ + i, DSPVOLUP2[i+1] );
    }
    
    DSPVOLDN1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDN1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPVOLDN1__DigitalInput__ + i, DSPVOLDN1__DigitalInput__, this );
        m_DigitalInputList.Add( DSPVOLDN1__DigitalInput__ + i, DSPVOLDN1[i+1] );
    }
    
    DSPVOLDN2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDN2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPVOLDN2__DigitalInput__ + i, DSPVOLDN2__DigitalInput__, this );
        m_DigitalInputList.Add( DSPVOLDN2__DigitalInput__ + i, DSPVOLDN2[i+1] );
    }
    
    DSPMUTEON1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEON1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTEON1__DigitalInput__ + i, DSPMUTEON1__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTEON1__DigitalInput__ + i, DSPMUTEON1[i+1] );
    }
    
    DSPMUTEON2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEON2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTEON2__DigitalInput__ + i, DSPMUTEON2__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTEON2__DigitalInput__ + i, DSPMUTEON2[i+1] );
    }
    
    DSPMUTEOFF1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEOFF1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTEOFF1__DigitalInput__ + i, DSPMUTEOFF1__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTEOFF1__DigitalInput__ + i, DSPMUTEOFF1[i+1] );
    }
    
    DSPMUTEOFF2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEOFF2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTEOFF2__DigitalInput__ + i, DSPMUTEOFF2__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTEOFF2__DigitalInput__ + i, DSPMUTEOFF2[i+1] );
    }
    
    DSPMUTETOG1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTETOG1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTETOG1__DigitalInput__ + i, DSPMUTETOG1__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTETOG1__DigitalInput__ + i, DSPMUTETOG1[i+1] );
    }
    
    DSPMUTETOG2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTETOG2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DSPMUTETOG2__DigitalInput__ + i, DSPMUTETOG2__DigitalInput__, this );
        m_DigitalInputList.Add( DSPMUTETOG2__DigitalInput__ + i, DSPMUTETOG2[i+1] );
    }
    
    DEFAULTPOINTALL = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        DEFAULTPOINTALL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DEFAULTPOINTALL__DigitalInput__ + i, DEFAULTPOINTALL__DigitalInput__, this );
        m_DigitalInputList.Add( DEFAULTPOINTALL__DigitalInput__ + i, DEFAULTPOINTALL[i+1] );
    }
    
    DEFAULTPOINT1 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DEFAULTPOINT1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DEFAULTPOINT1__DigitalInput__ + i, DEFAULTPOINT1__DigitalInput__, this );
        m_DigitalInputList.Add( DEFAULTPOINT1__DigitalInput__ + i, DEFAULTPOINT1[i+1] );
    }
    
    DEFAULTPOINT2 = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DEFAULTPOINT2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DEFAULTPOINT2__DigitalInput__ + i, DEFAULTPOINT2__DigitalInput__, this );
        m_DigitalInputList.Add( DEFAULTPOINT2__DigitalInput__ + i, DEFAULTPOINT2[i+1] );
    }
    
    FIXEDMUTEFB1 = new InOutArray<DigitalOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEFB1[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FIXEDMUTEFB1__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FIXEDMUTEFB1__DigitalOutput__ + i, FIXEDMUTEFB1[i+1] );
    }
    
    FIXEDMUTEFB2 = new InOutArray<DigitalOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTEFB2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FIXEDMUTEFB2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FIXEDMUTEFB2__DigitalOutput__ + i, FIXEDMUTEFB2[i+1] );
    }
    
    FIXEDMUTENOTFB1 = new InOutArray<DigitalOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTENOTFB1[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FIXEDMUTENOTFB1__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FIXEDMUTENOTFB1__DigitalOutput__ + i, FIXEDMUTENOTFB1[i+1] );
    }
    
    FIXEDMUTENOTFB2 = new InOutArray<DigitalOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDMUTENOTFB2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FIXEDMUTENOTFB2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FIXEDMUTENOTFB2__DigitalOutput__ + i, FIXEDMUTENOTFB2[i+1] );
    }
    
    DSPMUTEFB1 = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEFB1[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DSPMUTEFB1__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DSPMUTEFB1__DigitalOutput__ + i, DSPMUTEFB1[i+1] );
    }
    
    DSPMUTEFB2 = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTEFB2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DSPMUTEFB2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DSPMUTEFB2__DigitalOutput__ + i, DSPMUTEFB2[i+1] );
    }
    
    DSPMUTENOTFB1 = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTENOTFB1[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DSPMUTENOTFB1__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DSPMUTENOTFB1__DigitalOutput__ + i, DSPMUTENOTFB1[i+1] );
    }
    
    DSPMUTENOTFB2 = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPMUTENOTFB2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DSPMUTENOTFB2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DSPMUTENOTFB2__DigitalOutput__ + i, DSPMUTENOTFB2[i+1] );
    }
    
    VOLFBRANGE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        VOLFBRANGE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VOLFBRANGE__AnalogSerialInput__ + i, VOLFBRANGE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( VOLFBRANGE__AnalogSerialInput__ + i, VOLFBRANGE[i+1] );
    }
    
    INSERT2BYTE1 = new InOutArray<AnalogInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        INSERT2BYTE1[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INSERT2BYTE1__AnalogSerialInput__ + i, INSERT2BYTE1__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INSERT2BYTE1__AnalogSerialInput__ + i, INSERT2BYTE1[i+1] );
    }
    
    INSERT2BYTE2 = new InOutArray<AnalogInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        INSERT2BYTE2[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INSERT2BYTE2__AnalogSerialInput__ + i, INSERT2BYTE2__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INSERT2BYTE2__AnalogSerialInput__ + i, INSERT2BYTE2[i+1] );
    }
    
    INSERTDB1 = new InOutArray<AnalogInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        INSERTDB1[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INSERTDB1__AnalogSerialInput__ + i, INSERTDB1__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INSERTDB1__AnalogSerialInput__ + i, INSERTDB1[i+1] );
    }
    
    INSERTDB2 = new InOutArray<AnalogInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        INSERTDB2[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INSERTDB2__AnalogSerialInput__ + i, INSERTDB2__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INSERTDB2__AnalogSerialInput__ + i, INSERTDB2[i+1] );
    }
    
    FIXEDVOLGAUGEFB1 = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLGAUGEFB1[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FIXEDVOLGAUGEFB1__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( FIXEDVOLGAUGEFB1__AnalogSerialOutput__ + i, FIXEDVOLGAUGEFB1[i+1] );
    }
    
    FIXEDVOLGAUGEFB2 = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        FIXEDVOLGAUGEFB2[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FIXEDVOLGAUGEFB2__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( FIXEDVOLGAUGEFB2__AnalogSerialOutput__ + i, FIXEDVOLGAUGEFB2[i+1] );
    }
    
    DSPVOLGAUGEFB1 = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLGAUGEFB1[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSPVOLGAUGEFB1__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSPVOLGAUGEFB1__AnalogSerialOutput__ + i, DSPVOLGAUGEFB1[i+1] );
    }
    
    DSPVOLGAUGEFB2 = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLGAUGEFB2[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSPVOLGAUGEFB2__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSPVOLGAUGEFB2__AnalogSerialOutput__ + i, DSPVOLGAUGEFB2[i+1] );
    }
    
    LIST_NUMOFITEMS = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        LIST_NUMOFITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIST_NUMOFITEMS__AnalogSerialOutput__ + i, LIST_NUMOFITEMS[i+1] );
    }
    
    DSPVOLDB1 = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDB1[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSPVOLDB1__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSPVOLDB1__AnalogSerialOutput__ + i, DSPVOLDB1[i+1] );
    }
    
    DSPVOLDB2 = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDB2[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DSPVOLDB2__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DSPVOLDB2__AnalogSerialOutput__ + i, DSPVOLDB2[i+1] );
    }
    
    DSPVOLDBFB__DOLLAR__1 = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDBFB__DOLLAR__1[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSPVOLDBFB__DOLLAR__1__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSPVOLDBFB__DOLLAR__1__AnalogSerialOutput__ + i, DSPVOLDBFB__DOLLAR__1[i+1] );
    }
    
    DSPVOLDBFB__DOLLAR__2 = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPVOLDBFB__DOLLAR__2[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSPVOLDBFB__DOLLAR__2__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSPVOLDBFB__DOLLAR__2__AnalogSerialOutput__ + i, DSPVOLDBFB__DOLLAR__2[i+1] );
    }
    
    LIST_FB__DOLLAR__1 = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        LIST_FB__DOLLAR__1[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LIST_FB__DOLLAR__1__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LIST_FB__DOLLAR__1__AnalogSerialOutput__ + i, LIST_FB__DOLLAR__1[i+1] );
    }
    
    LIST_FB__DOLLAR__2 = new InOutArray<StringOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        LIST_FB__DOLLAR__2[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LIST_FB__DOLLAR__2__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LIST_FB__DOLLAR__2__AnalogSerialOutput__ + i, LIST_FB__DOLLAR__2[i+1] );
    }
    
    DSPPOINTNAME__DOLLAR__1 = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPPOINTNAME__DOLLAR__1[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSPPOINTNAME__DOLLAR__1__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSPPOINTNAME__DOLLAR__1__AnalogSerialOutput__ + i, DSPPOINTNAME__DOLLAR__1[i+1] );
    }
    
    DSPPOINTNAME__DOLLAR__2 = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSPPOINTNAME__DOLLAR__2[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSPPOINTNAME__DOLLAR__2__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSPPOINTNAME__DOLLAR__2__AnalogSerialOutput__ + i, DSPPOINTNAME__DOLLAR__2[i+1] );
    }
    
    DATAINIT_RX__DOLLAR__1 = new InOutArray<BufferInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        DATAINIT_RX__DOLLAR__1[i+1] = new Crestron.Logos.SplusObjects.BufferInput( DATAINIT_RX__DOLLAR__1__AnalogSerialInput__ + i, DATAINIT_RX__DOLLAR__1__AnalogSerialInput__, 5000, this );
        m_StringInputList.Add( DATAINIT_RX__DOLLAR__1__AnalogSerialInput__ + i, DATAINIT_RX__DOLLAR__1[i+1] );
    }
    
    DATAINIT_RX__DOLLAR__2 = new InOutArray<BufferInput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        DATAINIT_RX__DOLLAR__2[i+1] = new Crestron.Logos.SplusObjects.BufferInput( DATAINIT_RX__DOLLAR__2__AnalogSerialInput__ + i, DATAINIT_RX__DOLLAR__2__AnalogSerialInput__, 5000, this );
        m_StringInputList.Add( DATAINIT_RX__DOLLAR__2__AnalogSerialInput__ + i, DATAINIT_RX__DOLLAR__2[i+1] );
    }
    
    
    for( uint i = 0; i < 50; i++ )
        INSERT2BYTE1[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( INSERT2BYTE1_OnChange_0, false ) );
        
    for( uint i = 0; i < 50; i++ )
        INSERT2BYTE2[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( INSERT2BYTE2_OnChange_1, false ) );
        
    for( uint i = 0; i < 50; i++ )
        INSERTDB1[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( INSERTDB1_OnChange_2, false ) );
        
    for( uint i = 0; i < 50; i++ )
        INSERTDB2[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( INSERTDB2_OnChange_3, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DEFAULTPOINT1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DEFAULTPOINT1_OnPush_4, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DEFAULTPOINT2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DEFAULTPOINT2_OnPush_5, false ) );
        
    for( uint i = 0; i < 2; i++ )
        DEFAULTPOINTALL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DEFAULTPOINTALL_OnPush_6, false ) );
        
    RC_STATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( RC_STATE_OnPush_7, false ) );
    for( uint i = 0; i < 50; i++ )
        DSPVOLUP1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLUP1_OnPush_8, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLUP2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLUP2_OnPush_9, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLDN1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLDN1_OnPush_10, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLDN2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLDN2_OnPush_11, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTETOG1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTETOG1_OnPush_12, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTETOG2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTETOG2_OnPush_13, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEON1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEON1_OnPush_14, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEON2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEON2_OnPush_15, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEOFF1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEOFF1_OnPush_16, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEOFF2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEOFF2_OnPush_17, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLUP1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLUP1_OnPush_18, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLUP2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLUP2_OnPush_19, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLDN1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLDN1_OnPush_20, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLDN2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLDN2_OnPush_21, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTETOG1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTETOG1_OnPush_22, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTETOG2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTETOG2_OnPush_23, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEON1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEON1_OnPush_24, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEON2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEON2_OnPush_25, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEOFF1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEOFF1_OnPush_26, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEOFF2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEOFF2_OnPush_27, false ) );
        
    for( uint i = 0; i < 2; i++ )
        VOLFBRANGE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLFBRANGE_OnChange_28, false ) );
        
    for( uint i = 0; i < 1; i++ )
        DATAINIT_RX__DOLLAR__1[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR__1_OnChange_29, true ) );
        
    for( uint i = 0; i < 1; i++ )
        DATAINIT_RX__DOLLAR__2[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR__2_OnChange_30, true ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_60 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RC_STATE__DigitalInput__ = 0;
const uint FIXEDVOLUP1__DigitalInput__ = 1;
const uint FIXEDVOLUP2__DigitalInput__ = 6;
const uint FIXEDVOLDN1__DigitalInput__ = 11;
const uint FIXEDVOLDN2__DigitalInput__ = 16;
const uint FIXEDMUTEON1__DigitalInput__ = 21;
const uint FIXEDMUTEON2__DigitalInput__ = 26;
const uint FIXEDMUTEOFF1__DigitalInput__ = 31;
const uint FIXEDMUTEOFF2__DigitalInput__ = 36;
const uint FIXEDMUTETOG1__DigitalInput__ = 41;
const uint FIXEDMUTETOG2__DigitalInput__ = 46;
const uint FIXEDDEFAULTPOINT1__DigitalInput__ = 51;
const uint FIXEDDEFAULTPOINT2__DigitalInput__ = 56;
const uint DSPVOLUP1__DigitalInput__ = 61;
const uint DSPVOLUP2__DigitalInput__ = 111;
const uint DSPVOLDN1__DigitalInput__ = 161;
const uint DSPVOLDN2__DigitalInput__ = 211;
const uint DSPMUTEON1__DigitalInput__ = 261;
const uint DSPMUTEON2__DigitalInput__ = 311;
const uint DSPMUTEOFF1__DigitalInput__ = 361;
const uint DSPMUTEOFF2__DigitalInput__ = 411;
const uint DSPMUTETOG1__DigitalInput__ = 461;
const uint DSPMUTETOG2__DigitalInput__ = 511;
const uint DEFAULTPOINTALL__DigitalInput__ = 561;
const uint DEFAULTPOINT1__DigitalInput__ = 563;
const uint DEFAULTPOINT2__DigitalInput__ = 613;
const uint VOLFBRANGE__AnalogSerialInput__ = 0;
const uint INSERT2BYTE1__AnalogSerialInput__ = 2;
const uint INSERT2BYTE2__AnalogSerialInput__ = 52;
const uint INSERTDB1__AnalogSerialInput__ = 102;
const uint INSERTDB2__AnalogSerialInput__ = 152;
const uint DATAINIT_RX__DOLLAR__1__AnalogSerialInput__ = 202;
const uint DATAINIT_RX__DOLLAR__2__AnalogSerialInput__ = 203;
const uint FIXEDMUTEFB1__DigitalOutput__ = 0;
const uint FIXEDMUTEFB2__DigitalOutput__ = 5;
const uint FIXEDMUTENOTFB1__DigitalOutput__ = 10;
const uint FIXEDMUTENOTFB2__DigitalOutput__ = 15;
const uint DSPMUTEFB1__DigitalOutput__ = 20;
const uint DSPMUTEFB2__DigitalOutput__ = 70;
const uint DSPMUTENOTFB1__DigitalOutput__ = 120;
const uint DSPMUTENOTFB2__DigitalOutput__ = 170;
const uint FIXEDVOLGAUGEFB1__AnalogSerialOutput__ = 0;
const uint FIXEDVOLGAUGEFB2__AnalogSerialOutput__ = 5;
const uint DSPVOLGAUGEFB1__AnalogSerialOutput__ = 10;
const uint DSPVOLGAUGEFB2__AnalogSerialOutput__ = 60;
const uint LIST_NUMOFITEMS__AnalogSerialOutput__ = 110;
const uint DSPVOLDBFB__DOLLAR__1__AnalogSerialOutput__ = 112;
const uint DSPVOLDBFB__DOLLAR__2__AnalogSerialOutput__ = 162;
const uint LIST_FB__DOLLAR__1__AnalogSerialOutput__ = 212;
const uint LIST_FB__DOLLAR__2__AnalogSerialOutput__ = 214;
const uint DSPPOINTNAME__DOLLAR__1__AnalogSerialOutput__ = 216;
const uint DSPPOINTNAME__DOLLAR__2__AnalogSerialOutput__ = 266;
const uint DSPVOLDB1__AnalogSerialOutput__ = 316;
const uint DSPVOLDB2__AnalogSerialOutput__ = 366;

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
public class STPOINT : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IITEMACTIVE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SGLOBALNAME;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  SLOCALNAME;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  IRMASS = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IGUID = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  IGROUP = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  IFUNCTIONID = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  IISVIRTUAL = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  IVLINK = 0;
    
    [SplusStructAttribute(9, false, false)]
    public short  SIVOLSTATE = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  IMUTESTATE = 0;
    
    [SplusStructAttribute(11, false, false)]
    public short  SIVOLMAX = 0;
    
    [SplusStructAttribute(12, false, false)]
    public short  SIVOLMIN = 0;
    
    [SplusStructAttribute(13, false, false)]
    public ushort  IVOLRANGE = 0;
    
    [SplusStructAttribute(14, false, false)]
    public short  SIVOLDEFAULT = 0;
    
    [SplusStructAttribute(15, false, false)]
    public ushort  IMUTEDEFAULT = 0;
    
    [SplusStructAttribute(16, false, false)]
    public ushort  IMUTEINVERTED = 0;
    
    [SplusStructAttribute(17, false, false)]
    public ushort  BVOLISDISABLED = 0;
    
    [SplusStructAttribute(18, false, false)]
    public ushort  BMUTEISDISABLED = 0;
    
    [SplusStructAttribute(19, false, false)]
    public ushort  BVOLDEFAULTISDISABLED = 0;
    
    [SplusStructAttribute(20, false, false)]
    public ushort  BMUTEDEFAULTISDISABLED = 0;
    
    [SplusStructAttribute(21, false, false)]
    public ushort  [] ILISTITEMVIS;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  IPOINTTYPE = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IFIXEDID = 0;
    
    
    public STPOINT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ILISTITEMVIS  = new ushort[ 3 ];
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STGROUP : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IFUNCTION = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  INUMOFMEMBERS = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] IGROUPMEMBERS;
    
    
    public STGROUP( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IGROUPMEMBERS  = new ushort[ 51 ];
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STROOM : SplusStructureBase
{

    public STGROUP [] GROUP;
    
    [SplusStructAttribute(0, false, false)]
    public ushort  [] IINDEXPRIMARY;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  [] IINDEXRC;
    
    public STPOINT [] POINT;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] FIXEDTOLOCALID;
    
    
    public STROOM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        IINDEXPRIMARY  = new ushort[ 51 ];
        IINDEXRC  = new ushort[ 51 ];
        FIXEDTOLOCALID  = new ushort[ 6 ];
        GROUP  = new STGROUP[ 51 ];
        for( uint i = 0; i < 51; i++ )
        {
            GROUP [i] = new STGROUP( Owner, true );
            
        }
        POINT  = new STPOINT[ 51 ];
        for( uint i = 0; i < 51; i++ )
        {
            POINT [i] = new STPOINT( Owner, true );
            
        }
        
        
    }
    
}

}
