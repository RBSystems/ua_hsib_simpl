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

namespace UserModule_L3_UA_HSIB_NODEDSP_V1_0_82
{
    public class UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_82 : SplusObject
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
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> PGM_RTE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VOLFBRANGE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERT2BYTE1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERT2BYTE2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERTDB1;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INSERTDB2;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> DATAINIT_RX__DOLLAR__1;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> DATAINIT_RX__DOLLAR__2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PGM_RTE_FB;
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
        STSYS SYS;
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
            
            
            __context__.SourceCodeLine = 263;
            STEMP  .UpdateValue ( SSRC  ) ; 
            __context__.SourceCodeLine = 264;
            while ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 266;
                I = (ushort) ( Functions.GetC( STEMP ) ) ; 
                __context__.SourceCodeLine = 267;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( I >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I <= 126 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 267;
                    STEMP2  .UpdateValue ( STEMP2 + Functions.Chr (  (int) ( I ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 264;
                } 
            
            __context__.SourceCodeLine = 269;
            return ( STEMP2 ) ; 
            
            }
            
        private CrestronString FTRUEFALSE (  SplusExecutionContext __context__, ushort I , ushort IINVERTED ) 
            { 
            
            __context__.SourceCodeLine = 274;
            if ( Functions.TestForTrue  ( ( IINVERTED)  ) ) 
                {
                __context__.SourceCodeLine = 274;
                I = (ushort) ( Functions.Not( I ) ) ; 
                }
            
            __context__.SourceCodeLine = 276;
            if ( Functions.TestForTrue  ( ( I)  ) ) 
                {
                __context__.SourceCodeLine = 276;
                return ( "true" ) ; 
                }
            
            __context__.SourceCodeLine = 277;
            return ( "false" ) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 282;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private ushort FOTHERLIST (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 286;
            return (ushort)( (3 - ILIST)) ; 
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 301;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 303;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)IROOM);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 305;
                            LIST_FB__DOLLAR__1 [ ILIST]  .UpdateValue ( SDATA  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 306;
                            LIST_FB__DOLLAR__2 [ ILIST]  .UpdateValue ( SDATA  ) ; 
                            }
                        
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
            
            
            __context__.SourceCodeLine = 317;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 319;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 320;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    {
                    __context__.SourceCodeLine = 320;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 323;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)50; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 325;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == ILIST))  ) ) 
                            { 
                            __context__.SourceCodeLine = 327;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS) ; 
                            } 
                        
                        __context__.SourceCodeLine = 323;
                        } 
                    
                    __context__.SourceCodeLine = 330;
                    MakeString ( STEMP , "{0};|}}", STEMP ) ; 
                    } 
                
                __context__.SourceCodeLine = 332;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private ushort FSETVOLFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            ushort IVOLFB = 0;
            
            CrestronString SVOLFB;
            SVOLFB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 347;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE)  ) ) 
                {
                __context__.SourceCodeLine = 347;
                IVOLFB = (ushort) ( (((ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) * IVOLFBRANGE[ IROOM ]) / ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 351;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 352;
            MakeString ( SVOLFB , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 353;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 357;
                        DSPVOLGAUGEFB1 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 358;
                        DSPVOLDBFB__DOLLAR__1 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 359;
                        DSPVOLDB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 361;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 363;
                            FIXEDVOLGAUGEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 367;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 369;
                            DSPVOLGAUGEFB2 [ (IINDEX + 25)]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 376;
                        DSPVOLGAUGEFB2 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 377;
                        DSPVOLDBFB__DOLLAR__2 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 378;
                        DSPVOLDB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 380;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 382;
                            FIXEDVOLGAUGEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 386;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 388;
                            DSPVOLGAUGEFB1 [ (IINDEX + 25)]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FSETMUTEFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 398;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 402;
                        DSPMUTEFB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 403;
                        DSPMUTENOTFB1 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 405;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 407;
                            FIXEDMUTEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 408;
                            FIXEDMUTENOTFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 412;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 414;
                            DSPMUTEFB2 [ (IINDEX + 25)]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 420;
                        DSPMUTEFB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 421;
                        DSPMUTENOTFB2 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 423;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 425;
                            FIXEDMUTEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 426;
                            FIXEDMUTENOTFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 430;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 432;
                            DSPMUTEFB1 [ (IINDEX + 25)]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private short FCHECKBOUNDS (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , short SIVAL ) 
            { 
            
            __context__.SourceCodeLine = 441;
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
            
            
            __context__.SourceCodeLine = 450;
            MakeString ( SVOLCMDVALUE , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 452;
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
            
            
            __context__.SourceCodeLine = 461;
            FSETMUTEFB (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FGROUPMANAGER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , CrestronString STYPE ) 
            { 
            ushort IMEMBERINDEX = 0;
            ushort IGROUP = 0;
            ushort L = 0;
            ushort IROOMTEMP = 0;
            ushort IMEMBERINDEXTEMP = 0;
            
            
            __context__.SourceCodeLine = 469;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) && Functions.TestForTrue ( SYS.IRCSTATE )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 472;
                IGROUP = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) ; 
                __context__.SourceCodeLine = 473;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( L  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (L  >= __FN_FORSTART_VAL__1) && (L  <= __FN_FOREND_VAL__1) ) : ( (L  <= __FN_FORSTART_VAL__1) && (L  >= __FN_FOREND_VAL__1) ) ; L  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 475;
                    IMEMBERINDEX = (ushort) ( ROOM[ IROOM ].GROUP[ IGROUP ].IGROUPMEMBERS[ L ] ) ; 
                    __context__.SourceCodeLine = 479;
                    IMEMBERINDEXTEMP = (ushort) ( (Mod( (IMEMBERINDEX - 1) , 50 ) + 1) ) ; 
                    __context__.SourceCodeLine = 480;
                    IROOMTEMP = (ushort) ( (((IMEMBERINDEX - 1) / 50) + 1) ) ; 
                    __context__.SourceCodeLine = 482;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 484;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOMTEMP ].POINT[ IMEMBERINDEXTEMP ].BVOLISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLISDISABLED ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 486;
                            ROOM [ IROOMTEMP] . POINT [ IMEMBERINDEXTEMP] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( IINDEX ) , (short)( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ) ) ; 
                            __context__.SourceCodeLine = 487;
                            FSENDVOL (  __context__ , (ushort)( IROOMTEMP ), (ushort)( IMEMBERINDEXTEMP )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 491;
                            Trace( "Node_DSP: Point[{0:d}] Volume control is disabled. Group Vol command blocked at this control Point.", (ushort)IMEMBERINDEXTEMP) ; 
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 495;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 497;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOMTEMP ].POINT[ IMEMBERINDEXTEMP ].BMUTEISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEISDISABLED ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 499;
                                ROOM [ IROOMTEMP] . POINT [ IMEMBERINDEXTEMP] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                                __context__.SourceCodeLine = 500;
                                FSENDMUTE (  __context__ , (ushort)( IROOMTEMP ), (ushort)( IMEMBERINDEXTEMP )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 504;
                                Trace( "Node_DSP: Point[{0:d}] Mute control is disabled. Group Mute command blocked at this control Point.", (ushort)IMEMBERINDEXTEMP) ; 
                                } 
                            
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 473;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 512;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                    {
                    __context__.SourceCodeLine = 512;
                    FSENDVOL (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 513;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                        {
                        __context__.SourceCodeLine = 513;
                        FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FDEFAULTPOINT (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 519;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 521;
                ROOM [ IROOM] . POINT [ IINDEX] . SIVOLSTATE = (short) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLDEFAULT ) ; 
                __context__.SourceCodeLine = 522;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 524;
                Trace( "NodeDSP - fDefaultPoint - Room[iRoom].Point {0:d}, {1}: attempted to default a disabled volume field", (ushort)IINDEX, ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME ) ; 
                }
            
            __context__.SourceCodeLine = 525;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 527;
                ROOM [ IROOM] . POINT [ IINDEX] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTEDEFAULT ) ; 
                __context__.SourceCodeLine = 528;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX ), "mute") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 530;
                Trace( "NodeDSP - fDefaultPoint - Point {0:d}, {1}: attempted to default a disabled mute field", (ushort)IINDEX, ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME ) ; 
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
                
                
                __context__.SourceCodeLine = 542;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 543;
                IROOM = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 545;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 547;
                    J = (ushort) ( ((INSERT2BYTE1[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                    __context__.SourceCodeLine = 548;
                    ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                    __context__.SourceCodeLine = 549;
                    FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 551;
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
            
            
            __context__.SourceCodeLine = 557;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 558;
            IROOM = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 560;
            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                { 
                __context__.SourceCodeLine = 562;
                J = (ushort) ( ((INSERT2BYTE2[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                __context__.SourceCodeLine = 563;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                __context__.SourceCodeLine = 564;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 566;
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
        
        
        __context__.SourceCodeLine = 574;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 575;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 577;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 579;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB1[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 580;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 582;
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
        
        
        __context__.SourceCodeLine = 589;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 590;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 592;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 594;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB2[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 595;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 597;
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
        
        
        __context__.SourceCodeLine = 604;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 605;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 607;
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
        
        
        __context__.SourceCodeLine = 613;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 614;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 616;
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
        
        
        __context__.SourceCodeLine = 626;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 628;
        I = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 629;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 631;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 633;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 635;
                    FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 639;
                    J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                    __context__.SourceCodeLine = 640;
                    MakeString ( STEMP , ":{0:d};", (short)J) ; 
                    __context__.SourceCodeLine = 641;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 643;
                        STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                        __context__.SourceCodeLine = 644;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 646;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( J )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 651;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 653;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BVOLDEFAULTISDISABLED ) || Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BMUTEDEFAULTISDISABLED )) ))  ) ) 
                            { 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 629;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void FUPDATERCLISTITEMS (  SplusExecutionContext __context__ ) 
    { 
    ushort I = 0;
    ushort J = 0;
    ushort IROOM = 0;
    ushort ILIST = 0;
    
    CrestronString [] STEMPVIS;
    STEMPVIS  = new CrestronString[ 3 ];
    for( uint i = 0; i < 3; i++ )
        STEMPVIS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 800, this );
    
    
    __context__.SourceCodeLine = 673;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 675;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)2; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
            {
            __context__.SourceCodeLine = 675;
            STEMPVIS [ J ]  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 675;
            }
        
        __context__.SourceCodeLine = 677;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 26 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)50; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 679;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 681;
                ROOM [ IROOM] . POINT [ I] . ILISTITEMVIS = (ushort) ( SYS.IRCSTATE ) ; 
                __context__.SourceCodeLine = 682;
                MakeString ( STEMPVIS [ ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ] , "{0}{1:d}={2:d},", STEMPVIS [ ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ] , (ushort)I, (ushort)SYS.IRCSTATE) ; 
                } 
            
            __context__.SourceCodeLine = 677;
            } 
        
        __context__.SourceCodeLine = 686;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)2; 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (J  >= __FN_FORSTART_VAL__4) && (J  <= __FN_FOREND_VAL__4) ) : ( (J  <= __FN_FORSTART_VAL__4) && (J  >= __FN_FOREND_VAL__4) ) ; J  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 688;
            MakeString ( STEMPVIS [ J ] , "{0};|}}", STEMPVIS [ J ] ) ; 
            __context__.SourceCodeLine = 689;
            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( J ), STEMPVIS[ J ]) ; 
            __context__.SourceCodeLine = 686;
            } 
        
        __context__.SourceCodeLine = 673;
        } 
    
    
    }
    
object RC_STATE_OnRelease_7 ( Object __EventInfo__ )

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
        
        
        __context__.SourceCodeLine = 703;
        SYS . IRCSTATE = (ushort) ( Functions.Not( RC_STATE  .Value ) ) ; 
        __context__.SourceCodeLine = 704;
        if ( Functions.TestForTrue  ( ( Functions.Not( IGROUPSEM ))  ) ) 
            { 
            __context__.SourceCodeLine = 707;
            IGROUPSEM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 708;
            Functions.Delay (  (int) ( 100 ) ) ; 
            __context__.SourceCodeLine = 710;
            IROOM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 712;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(50 / 2); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 714;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 718;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE != 3))  ) ) 
                        { 
                        __context__.SourceCodeLine = 720;
                        J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                        __context__.SourceCodeLine = 721;
                        MakeString ( STEMP , ":{0:d};", (short)J) ; 
                        __context__.SourceCodeLine = 723;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 725;
                            STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                            __context__.SourceCodeLine = 726;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 728;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "vol") ; 
                                __context__.SourceCodeLine = 729;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "mute") ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 735;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                                __context__.SourceCodeLine = 736;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            } 
                        
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 712;
                } 
            
            __context__.SourceCodeLine = 748;
            FUPDATERCLISTITEMS (  __context__  ) ; 
            } 
        
        __context__.SourceCodeLine = 750;
        IGROUPSEM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 752;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)2; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 754;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
                { 
                __context__.SourceCodeLine = 756;
                ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 757;
                FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IRCMUTE )) ; 
                } 
            
            __context__.SourceCodeLine = 752;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RC_STATE_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 767;
        SYS . IRCSTATE = (ushort) ( Functions.Not( RC_STATE  .Value ) ) ; 
        __context__.SourceCodeLine = 769;
        FUPDATERCLISTITEMS (  __context__  ) ; 
        __context__.SourceCodeLine = 771;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 773;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
                { 
                __context__.SourceCodeLine = 775;
                ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 776;
                FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IRCMUTE )) ; 
                } 
            
            __context__.SourceCodeLine = 771;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLUP1_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IEXTARRYINDEX = 0;
        
        
        __context__.SourceCodeLine = 784;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 785;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 787;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 788;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 790;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 791;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 794;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 796;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 797;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 798;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 799;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP1[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 801;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 802;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 799;
                } 
            
            __context__.SourceCodeLine = 804;
            while ( Functions.TestForTrue  ( ( DSPVOLUP1[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 806;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 807;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 808;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 804;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 811;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLUP2_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IEXTARRYINDEX = 0;
        
        
        __context__.SourceCodeLine = 817;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 818;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 820;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 821;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 823;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 824;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 828;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 830;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 831;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 832;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 833;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP2[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 835;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 836;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 833;
                } 
            
            __context__.SourceCodeLine = 838;
            while ( Functions.TestForTrue  ( ( DSPVOLUP2[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 840;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 841;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 842;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 838;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 845;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLDN1_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IEXTARRYINDEX = 0;
        
        
        __context__.SourceCodeLine = 852;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 853;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 855;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 856;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 858;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 859;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 863;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 865;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 866;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 867;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 868;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN1[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 870;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 871;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 868;
                } 
            
            __context__.SourceCodeLine = 873;
            while ( Functions.TestForTrue  ( ( DSPVOLDN1[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 875;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 876;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 877;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 873;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 880;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPVOLDN2_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IEXTARRYINDEX = 0;
        
        
        __context__.SourceCodeLine = 887;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 888;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 890;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 891;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 893;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 894;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 897;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 899;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 900;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 901;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 902;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN2[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 904;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 905;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 902;
                } 
            
            __context__.SourceCodeLine = 907;
            while ( Functions.TestForTrue  ( ( DSPVOLDN2[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 909;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 910;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 911;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 907;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 914;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTETOG1_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 922;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 923;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 925;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 927;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 928;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 932;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 934;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 935;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 937;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTETOG2_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 945;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 946;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 948;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 950;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 951;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 954;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 956;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 957;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 959;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEON1_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 967;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 968;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 970;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 972;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 973;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 977;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 979;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 980;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 982;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEON2_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 989;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 990;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 992;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 994;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 995;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 997;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEOFF1_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1004;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1005;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1007;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1009;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 1010;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1014;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1016;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1017;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1019;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSPMUTEOFF2_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1025;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1026;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1028;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1030;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 1031;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1035;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1037;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1038;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1040;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PGM_RTE_OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1054;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1056;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].PGMRTEINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1058;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 1060;
                DSPVOLDB1 [ ROOM[ IROOM ].PGMRTEINDEX]  .Value = (ushort) ( PGM_RTE[ IROOM ] .UshortValue ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1062;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1064;
                    DSPVOLDB2 [ ROOM[ IROOM ].PGMRTEINDEX]  .Value = (ushort) ( PGM_RTE[ IROOM ] .UshortValue ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 1067;
            PGM_RTE_FB [ IROOM]  .Value = (ushort) ( PGM_RTE[ IROOM ] .UshortValue ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLUP1_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1074;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1075;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1076;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1078;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1080;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 1081;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1082;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1083;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1085;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1086;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1083;
                } 
            
            __context__.SourceCodeLine = 1088;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1090;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 1091;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1092;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1088;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1095;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLUP2_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1101;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1102;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1103;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1105;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1107;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 1108;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1109;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1110;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1112;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1113;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1110;
                } 
            
            __context__.SourceCodeLine = 1115;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1117;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 1118;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1119;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1115;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1122;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLDN1_OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1129;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1130;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1131;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1133;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1135;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 1136;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1137;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1138;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1140;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1141;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1138;
                } 
            
            __context__.SourceCodeLine = 1143;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1145;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 1146;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1147;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1143;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1150;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDVOLDN2_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1157;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1158;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1159;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1161;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1163;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 1164;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1165;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1166;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1168;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1169;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1166;
                } 
            
            __context__.SourceCodeLine = 1171;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1173;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 1174;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1175;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1171;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1178;
            Trace( "Node_DSP: User attempmting to ramp vol on Point[{0:d}] which has disabled Volume controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTETOG1_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1185;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1186;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1188;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1190;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 1191;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1193;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTETOG2_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1200;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1201;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1203;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1205;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 1206;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1208;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEON1_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1215;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1216;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1218;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1220;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1221;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1223;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEON2_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1229;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1230;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1232;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1234;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1235;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1237;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEOFF1_OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1243;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1244;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1246;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1248;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1249;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1251;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIXEDMUTEOFF2_OnPush_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        ushort IFIXED = 0;
        
        
        __context__.SourceCodeLine = 1256;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1257;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1259;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1261;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1262;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1264;
            Trace( "Node_DSP: User attempmting to affect mute on Point[{0:d}] which has disabled Mute controls.", (short)I) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLFBRANGE_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        
        __context__.SourceCodeLine = 1280;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1282;
        if ( Functions.TestForTrue  ( ( VOLFBRANGE[ IROOM ] .UshortValue)  ) ) 
            {
            __context__.SourceCodeLine = 1282;
            IVOLFBRANGE [ IROOM] = (ushort) ( VOLFBRANGE[ IROOM ] .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1283;
            IVOLFBRANGE [ IROOM] = (ushort) ( 936 ) ; 
            }
        
        __context__.SourceCodeLine = 1285;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1287;
            FSETVOLFB (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
            __context__.SourceCodeLine = 1285;
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
    
    
    __context__.SourceCodeLine = 1307;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( ILIST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__1) && (ILIST  <= __FN_FOREND_VAL__1) ) : ( (ILIST  <= __FN_FORSTART_VAL__1) && (ILIST  >= __FN_FOREND_VAL__1) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1309;
        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1310;
        Functions.Delay (  (int) ( 10 ) ) ; 
        __context__.SourceCodeLine = 1307;
        } 
    
    __context__.SourceCodeLine = 1314;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
        { 
        __context__.SourceCodeLine = 1316;
        ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 1317;
        FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IRCMUTE )) ; 
        } 
    
    
    }
    
private void FPROCESSLINE (  SplusExecutionContext __context__, ushort IROOM , ushort ITYPE , ushort IINDEX , CrestronString STEMPLINEARG ) 
    { 
    ushort I = 0;
    ushort IPOINTTYPE = 0;
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
    
    
    __context__.SourceCodeLine = 1333;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1335;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1337;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1338;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1339;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1341;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1341;
            ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1342;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1342;
                ROOM [ IROOM] . POINT [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1343;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1343;
                    ROOM [ IROOM] . POINT [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1344;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1344;
                        ROOM [ IROOM] . POINT [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1345;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "fixed_id" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1347;
                            ROOM [ IROOM] . POINT [ IINDEX] . IFIXEDID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1348;
                            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                                {
                                __context__.SourceCodeLine = 1349;
                                ROOM [ IROOM] . FIXEDTOLOCALID [ Functions.Atoi( STEMPVALUE )] = (ushort) ( IINDEX ) ; 
                                }
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1351;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "group" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1351;
                                ROOM [ IROOM] . POINT [ IINDEX] . IGROUP = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1352;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1352;
                                    ROOM [ IROOM] . POINT [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1353;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_max" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1353;
                                        ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1354;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_min" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1354;
                                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1355;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_vol" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1355;
                                                ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1356;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_mute" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1356;
                                                    ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1357;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol_disabled" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1357;
                                                        ROOM [ IROOM] . POINT [ IINDEX] . BVOLISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1358;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute_disabled" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1358;
                                                            ROOM [ IROOM] . POINT [ IINDEX] . BMUTEISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1359;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "point_type" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1359;
                                                                ROOM [ IROOM] . POINT [ IINDEX] . IPOINTTYPE = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1360;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 1360;
                                                                    ROOM [ IROOM] . POINT [ IINDEX] . IFUNCTION = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1363;
                                                                    IERR = (ushort) ( 1 ) ; 
                                                                    __context__.SourceCodeLine = 1364;
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
            
            }
        
        __context__.SourceCodeLine = 1335;
        } 
    
    __context__.SourceCodeLine = 1368;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1371;
        
            {
            int __SPLS_TMPVAR__SWTCH_4__ = ((int)ROOM[ IROOM ].POINT[ IINDEX ].IFUNCTION);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1376;
                    ROOM [ IROOM] . IRCMUTE = (ushort) ( IINDEX ) ; 
                    __context__.SourceCodeLine = 1377;
                    ROOM [ IROOM] . POINT [ IINDEX] . BMUTEDEFAULTISDISABLED = (ushort) ( 1 ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1382;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 3))  ) ) 
            {
            __context__.SourceCodeLine = 1383;
            ROOM [ IROOM] . PGMRTEINDEX = (ushort) ( IINDEX ) ; 
            }
        
        __context__.SourceCodeLine = 1385;
        IPOINTTYPE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE ) ; 
        __context__.SourceCodeLine = 1387;
        ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1388;
        ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( (ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMAX - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) ) ; 
        __context__.SourceCodeLine = 1389;
        ROOM [ IROOM] . IINDEXPRIMARY [ IINDEX] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1391;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . IINDEXRC [ (IINDEX + 25)] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1392;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . POINT [ (IINDEX + 25)] . IPOINTTYPE = (ushort) ( IPOINTTYPE ) ; 
        __context__.SourceCodeLine = 1394;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE == 0) ) || Functions.TestForTrue ( Functions.BoolToInt ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE > 50000 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1396;
            ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1398;
            Trace( "NodeDSP - error parsing iRoom={0:d}, iIndex={1:d} - iVolRange calculated to be zero", (ushort)IROOM, (ushort)IINDEX) ; 
            } 
        
        __context__.SourceCodeLine = 1401;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP)  ) ) 
            { 
            __context__.SourceCodeLine = 1403;
            IGROUP = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) ; 
            __context__.SourceCodeLine = 1405;
            ROOM [ IROOM] . GROUP [ IGROUP] . INUMOFMEMBERS = (ushort) ( (ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS + 1) ) ; 
            __context__.SourceCodeLine = 1406;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . GROUP [ IGROUP] . INUMOFMEMBERS = (ushort) ( (ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].GROUP[ IGROUP ].INUMOFMEMBERS + 1) ) ; 
            __context__.SourceCodeLine = 1408;
            ROOM [ IROOM] . GROUP [ IGROUP] . IGROUPMEMBERS [ ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS] = (ushort) ( (IINDEX + ((IROOM - 1) * 50)) ) ; 
            __context__.SourceCodeLine = 1409;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . GROUP [ IGROUP] . IGROUPMEMBERS [ ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS] = (ushort) ( (IINDEX + ((IROOM - 1) * 50)) ) ; 
            } 
        
        __context__.SourceCodeLine = 1418;
        
            {
            int __SPLS_TMPVAR__SWTCH_5__ = ((int)IROOM);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1422;
                    DSPPOINTNAME__DOLLAR__1 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1424;
                    DSPPOINTNAME__DOLLAR__2 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1428;
                    DSPPOINTNAME__DOLLAR__2 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1429;
                    DSPPOINTNAME__DOLLAR__1 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1433;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (IPOINTTYPE == 2) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1435;
            ROOM [ IROOM] . POINT [ IINDEX] . ILISTITEMVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1436;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( IPOINTTYPE ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 1438;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . POINT [ (IINDEX + 25)] . ILISTITEMVIS = (ushort) ( SYS.IRCSTATE ) ; 
            __context__.SourceCodeLine = 1439;
            FUPDATELISTVIS (  __context__ , (ushort)( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ), (ushort)( IPOINTTYPE ), (ushort)( (IINDEX + 25) )) ; 
            } 
        
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
    
    
    __context__.SourceCodeLine = 1454;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1455;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1457;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_POINTS" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1457;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1458;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_PRESETS" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1458;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1459;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1459;
                ITYPE = (ushort) ( 13 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1460;
                Trace( "NodeDSP - in fProcessInit - didn't catch header type - {0}", STEMPHEADER ) ; 
                }
            
            }
        
        }
    
    __context__.SourceCodeLine = 1462;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1464;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1465;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1467;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 1468;
            FPROCESSLIST (  __context__ , (ushort)( IROOM )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1472;
            STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
            __context__.SourceCodeLine = 1473;
            IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1475;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1477;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_6__ = ((int)ITYPE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 1481;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( 6 ) ; 
                            __context__.SourceCodeLine = 1482;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.ToInteger( -( 20 ) ) ) ; 
                            __context__.SourceCodeLine = 1483;
                            ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( 26 ) ; 
                            __context__.SourceCodeLine = 1484;
                            ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1485;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 1487;
                            FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1493;
                Trace( "NodeDSP - fProcessInit error, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1462;
        } 
    
    
    }
    
object DATAINIT_RX__DOLLAR__1_OnChange_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
        
        
        __context__.SourceCodeLine = 1510;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1511;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1513;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1514;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1511;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DATAINIT_RX__DOLLAR__2_OnChange_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort IROOM = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
        
        
        __context__.SourceCodeLine = 1522;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1523;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1525;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1526;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1523;
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
        
        __context__.SourceCodeLine = 1543;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1545;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1547;
            if ( Functions.TestForTrue  ( ( VOLFBRANGE[ I ] .UshortValue)  ) ) 
                {
                __context__.SourceCodeLine = 1547;
                IVOLFBRANGE [ I] = (ushort) ( VOLFBRANGE[ I ] .UshortValue ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1548;
                IVOLFBRANGE [ I] = (ushort) ( 936 ) ; 
                }
            
            __context__.SourceCodeLine = 1545;
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
    SYS  = new STSYS( this, true );
    SYS .PopulateCustomAttributeList( false );
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
    
    PGM_RTE_FB = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PGM_RTE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PGM_RTE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PGM_RTE_FB__DigitalOutput__ + i, PGM_RTE_FB[i+1] );
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
    
    PGM_RTE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        PGM_RTE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( PGM_RTE__AnalogSerialInput__ + i, PGM_RTE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( PGM_RTE__AnalogSerialInput__ + i, PGM_RTE[i+1] );
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
        
    RC_STATE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( RC_STATE_OnRelease_7, false ) );
    RC_STATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( RC_STATE_OnPush_8, false ) );
    for( uint i = 0; i < 50; i++ )
        DSPVOLUP1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLUP1_OnPush_9, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLUP2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLUP2_OnPush_10, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLDN1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLDN1_OnPush_11, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPVOLDN2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPVOLDN2_OnPush_12, true ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTETOG1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTETOG1_OnPush_13, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTETOG2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTETOG2_OnPush_14, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEON1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEON1_OnPush_15, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEON2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEON2_OnPush_16, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEOFF1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEOFF1_OnPush_17, false ) );
        
    for( uint i = 0; i < 50; i++ )
        DSPMUTEOFF2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DSPMUTEOFF2_OnPush_18, false ) );
        
    for( uint i = 0; i < 2; i++ )
        PGM_RTE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( PGM_RTE_OnChange_19, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLUP1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLUP1_OnPush_20, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLUP2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLUP2_OnPush_21, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLDN1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLDN1_OnPush_22, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDVOLDN2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDVOLDN2_OnPush_23, true ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTETOG1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTETOG1_OnPush_24, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTETOG2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTETOG2_OnPush_25, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEON1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEON1_OnPush_26, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEON2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEON2_OnPush_27, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEOFF1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEOFF1_OnPush_28, false ) );
        
    for( uint i = 0; i < 5; i++ )
        FIXEDMUTEOFF2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FIXEDMUTEOFF2_OnPush_29, false ) );
        
    for( uint i = 0; i < 2; i++ )
        VOLFBRANGE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLFBRANGE_OnChange_30, false ) );
        
    for( uint i = 0; i < 1; i++ )
        DATAINIT_RX__DOLLAR__1[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR__1_OnChange_31, true ) );
        
    for( uint i = 0; i < 1; i++ )
        DATAINIT_RX__DOLLAR__2[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINIT_RX__DOLLAR__2_OnChange_32, true ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_82 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
const uint PGM_RTE__AnalogSerialInput__ = 0;
const uint VOLFBRANGE__AnalogSerialInput__ = 2;
const uint INSERT2BYTE1__AnalogSerialInput__ = 4;
const uint INSERT2BYTE2__AnalogSerialInput__ = 54;
const uint INSERTDB1__AnalogSerialInput__ = 104;
const uint INSERTDB2__AnalogSerialInput__ = 154;
const uint DATAINIT_RX__DOLLAR__1__AnalogSerialInput__ = 204;
const uint DATAINIT_RX__DOLLAR__2__AnalogSerialInput__ = 205;
const uint PGM_RTE_FB__DigitalOutput__ = 0;
const uint FIXEDMUTEFB1__DigitalOutput__ = 2;
const uint FIXEDMUTEFB2__DigitalOutput__ = 7;
const uint FIXEDMUTENOTFB1__DigitalOutput__ = 12;
const uint FIXEDMUTENOTFB2__DigitalOutput__ = 17;
const uint DSPMUTEFB1__DigitalOutput__ = 22;
const uint DSPMUTEFB2__DigitalOutput__ = 72;
const uint DSPMUTENOTFB1__DigitalOutput__ = 122;
const uint DSPMUTENOTFB2__DigitalOutput__ = 172;
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
    public ushort  IFUNCTION = 0;
    
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
    public ushort  ILISTITEMVIS = 0;
    
    [SplusStructAttribute(22, false, false)]
    public ushort  IPOINTTYPE = 0;
    
    [SplusStructAttribute(23, false, false)]
    public ushort  IFIXEDID = 0;
    
    
    public STPOINT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SGLOBALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        SLOCALNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class STGROUP : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  INUMOFMEMBERS = 0;
    
    [SplusStructAttribute(1, false, false)]
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
    
    [SplusStructAttribute(3, false, false)]
    public ushort  PGMRTEINDEX = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  IRCMUTE = 0;
    
    
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
[SplusStructAttribute(-1, true, false)]
public class STSYS : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IRCSTATE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  IISRCSYSTEM = 0;
    
    
    public STSYS( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
