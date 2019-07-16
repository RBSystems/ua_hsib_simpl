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

namespace UserModule_L3_UA_HSIB_NODEDSP_V1_0_77
{
    public class UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_77 : SplusObject
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
            
            
            __context__.SourceCodeLine = 262;
            STEMP  .UpdateValue ( SSRC  ) ; 
            __context__.SourceCodeLine = 263;
            while ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 265;
                I = (ushort) ( Functions.GetC( STEMP ) ) ; 
                __context__.SourceCodeLine = 266;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( I >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I <= 126 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 266;
                    STEMP2  .UpdateValue ( STEMP2 + Functions.Chr (  (int) ( I ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 263;
                } 
            
            __context__.SourceCodeLine = 268;
            return ( STEMP2 ) ; 
            
            }
            
        private CrestronString FTRUEFALSE (  SplusExecutionContext __context__, ushort I , ushort IINVERTED ) 
            { 
            
            __context__.SourceCodeLine = 273;
            if ( Functions.TestForTrue  ( ( IINVERTED)  ) ) 
                {
                __context__.SourceCodeLine = 273;
                I = (ushort) ( Functions.Not( I ) ) ; 
                }
            
            __context__.SourceCodeLine = 275;
            if ( Functions.TestForTrue  ( ( I)  ) ) 
                {
                __context__.SourceCodeLine = 275;
                return ( "true" ) ; 
                }
            
            __context__.SourceCodeLine = 276;
            return ( "false" ) ; 
            
            }
            
        private ushort FOTHERROOM (  SplusExecutionContext __context__, ushort IROOM ) 
            { 
            
            __context__.SourceCodeLine = 281;
            return (ushort)( (3 - IROOM)) ; 
            
            }
            
        private ushort FOTHERLIST (  SplusExecutionContext __context__, ushort ILIST ) 
            { 
            
            __context__.SourceCodeLine = 285;
            return (ushort)( (3 - ILIST)) ; 
            
            }
            
        private void FSENDLISTFB (  SplusExecutionContext __context__, ushort IROOM , ushort ILIST , CrestronString SDATA ) 
            { 
            
            __context__.SourceCodeLine = 300;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 302;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)IROOM);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 304;
                            LIST_FB__DOLLAR__1 [ ILIST]  .UpdateValue ( SDATA  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 305;
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
            
            
            __context__.SourceCodeLine = 316;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILIST == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ILIST == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 318;
                STEMP  .UpdateValue ( "{ListVisFB:"  ) ; 
                __context__.SourceCodeLine = 319;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    {
                    __context__.SourceCodeLine = 319;
                    MakeString ( STEMP , "{0}{1:d}={2:d},;}}", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 322;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)50; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IINDEX  >= __FN_FORSTART_VAL__1) && (IINDEX  <= __FN_FOREND_VAL__1) ) : ( (IINDEX  <= __FN_FORSTART_VAL__1) && (IINDEX  >= __FN_FOREND_VAL__1) ) ; IINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 324;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == ILIST))  ) ) 
                            { 
                            __context__.SourceCodeLine = 326;
                            MakeString ( STEMP , "{0}{1:d}={2:d},", STEMP , (ushort)IINDEX, (ushort)ROOM[ IROOM ].POINT[ IINDEX ].ILISTITEMVIS) ; 
                            } 
                        
                        __context__.SourceCodeLine = 322;
                        } 
                    
                    __context__.SourceCodeLine = 329;
                    MakeString ( STEMP , "{0};|}}", STEMP ) ; 
                    } 
                
                __context__.SourceCodeLine = 331;
                FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), STEMP) ; 
                } 
            
            
            }
            
        private ushort FSETVOLFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            ushort IVOLFB = 0;
            
            CrestronString SVOLFB;
            SVOLFB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 346;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE)  ) ) 
                {
                __context__.SourceCodeLine = 346;
                IVOLFB = (ushort) ( (((ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) * IVOLFBRANGE[ IROOM ]) / ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 350;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 351;
            MakeString ( SVOLFB , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 352;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 356;
                        DSPVOLGAUGEFB1 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 357;
                        DSPVOLDBFB__DOLLAR__1 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 358;
                        DSPVOLDB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 360;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 362;
                            FIXEDVOLGAUGEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 366;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 368;
                            DSPVOLGAUGEFB2 [ (IINDEX + 25)]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 375;
                        DSPVOLGAUGEFB2 [ IINDEX]  .Value = (ushort) ( IVOLFB ) ; 
                        __context__.SourceCodeLine = 376;
                        DSPVOLDBFB__DOLLAR__2 [ IINDEX]  .UpdateValue ( SVOLFB  ) ; 
                        __context__.SourceCodeLine = 377;
                        DSPVOLDB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ; 
                        __context__.SourceCodeLine = 379;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 381;
                            FIXEDVOLGAUGEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 385;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 387;
                            DSPVOLGAUGEFB1 [ (IINDEX + 25)]  .Value = (ushort) ( IVOLFB ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void FSETMUTEFB (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 397;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)IROOM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 401;
                        DSPMUTEFB1 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 402;
                        DSPMUTENOTFB1 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 404;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 406;
                            FIXEDMUTEFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 407;
                            FIXEDMUTENOTFB1 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 411;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 413;
                            DSPMUTEFB2 [ (IINDEX + 25)]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 419;
                        DSPMUTEFB2 [ IINDEX]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                        __context__.SourceCodeLine = 420;
                        DSPMUTENOTFB2 [ IINDEX]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                        __context__.SourceCodeLine = 422;
                        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID)  ) ) 
                            { 
                            __context__.SourceCodeLine = 424;
                            FIXEDMUTEFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            __context__.SourceCodeLine = 425;
                            FIXEDMUTENOTFB2 [ ROOM[ IROOM ].POINT[ IINDEX ].IFIXEDID]  .Value = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 429;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 2) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 431;
                            DSPMUTEFB1 [ (IINDEX + 25)]  .Value = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private short FCHECKBOUNDS (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , short SIVAL ) 
            { 
            
            __context__.SourceCodeLine = 440;
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
            
            
            __context__.SourceCodeLine = 449;
            MakeString ( SVOLCMDVALUE , "{0:d}.0dB", (short)ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE) ; 
            __context__.SourceCodeLine = 451;
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
            
            
            __context__.SourceCodeLine = 460;
            FSETMUTEFB (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
            
            }
            
        private void FGROUPMANAGER (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX , CrestronString STYPE ) 
            { 
            ushort IMEMBERINDEX = 0;
            ushort IGROUP = 0;
            ushort L = 0;
            ushort IROOMTEMP = 0;
            ushort IMEMBERINDEXTEMP = 0;
            
            
            __context__.SourceCodeLine = 468;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) && Functions.TestForTrue ( SYS.IRCSTATE )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 471;
                IGROUP = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) ; 
                __context__.SourceCodeLine = 472;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( L  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (L  >= __FN_FORSTART_VAL__1) && (L  <= __FN_FOREND_VAL__1) ) : ( (L  <= __FN_FORSTART_VAL__1) && (L  >= __FN_FOREND_VAL__1) ) ; L  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 474;
                    IMEMBERINDEX = (ushort) ( ROOM[ IROOM ].GROUP[ IGROUP ].IGROUPMEMBERS[ L ] ) ; 
                    __context__.SourceCodeLine = 478;
                    IMEMBERINDEXTEMP = (ushort) ( (Mod( (IMEMBERINDEX - 1) , 50 ) + 1) ) ; 
                    __context__.SourceCodeLine = 479;
                    IROOMTEMP = (ushort) ( (((IMEMBERINDEX - 1) / 50) + 1) ) ; 
                    __context__.SourceCodeLine = 481;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 483;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOMTEMP ].POINT[ IMEMBERINDEXTEMP ].BVOLISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLISDISABLED ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 485;
                            ROOM [ IROOMTEMP] . POINT [ IMEMBERINDEXTEMP] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( IINDEX ) , (short)( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLSTATE ) ) ) ; 
                            __context__.SourceCodeLine = 486;
                            FSENDVOL (  __context__ , (ushort)( IROOMTEMP ), (ushort)( IMEMBERINDEXTEMP )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 490;
                            Trace( "Node_DSP: Point[{0:d}] Volume control is disabled. Group Vol command blocked at this control Point.", (ushort)IMEMBERINDEXTEMP) ; 
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 494;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 496;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOMTEMP ].POINT[ IMEMBERINDEXTEMP ].BMUTEISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEISDISABLED ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 498;
                                ROOM [ IROOMTEMP] . POINT [ IMEMBERINDEXTEMP] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTESTATE ) ; 
                                __context__.SourceCodeLine = 499;
                                FSENDMUTE (  __context__ , (ushort)( IROOMTEMP ), (ushort)( IMEMBERINDEXTEMP )) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 503;
                                Trace( "Node_DSP: Point[{0:d}] Mute control is disabled. Group Mute command blocked at this control Point.", (ushort)IMEMBERINDEXTEMP) ; 
                                } 
                            
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 472;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 511;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol" , STYPE ))  ) ) 
                    {
                    __context__.SourceCodeLine = 511;
                    FSENDVOL (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 512;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute" , STYPE ))  ) ) 
                        {
                        __context__.SourceCodeLine = 512;
                        FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX )) ; 
                        }
                    
                    }
                
                } 
            
            
            }
            
        private void FDEFAULTPOINT (  SplusExecutionContext __context__, ushort IROOM , ushort IINDEX ) 
            { 
            
            __context__.SourceCodeLine = 518;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BVOLISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 520;
                ROOM [ IROOM] . POINT [ IINDEX] . SIVOLSTATE = (short) ( ROOM[ IROOM ].POINT[ IINDEX ].SIVOLDEFAULT ) ; 
                __context__.SourceCodeLine = 521;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 523;
                Trace( "NodeDSP - fDefaultPoint - Room[iRoom].Point {0:d}, {1}: attempted to default a disabled volume field", (ushort)IINDEX, ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME ) ; 
                }
            
            __context__.SourceCodeLine = 524;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEDEFAULTISDISABLED ) ) && Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ IINDEX ].BMUTEISDISABLED ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 526;
                ROOM [ IROOM] . POINT [ IINDEX] . IMUTESTATE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IMUTEDEFAULT ) ; 
                __context__.SourceCodeLine = 527;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( IINDEX ), "mute") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 529;
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
                
                
                __context__.SourceCodeLine = 541;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 542;
                IROOM = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 544;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 546;
                    J = (ushort) ( ((INSERT2BYTE1[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                    __context__.SourceCodeLine = 547;
                    ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                    __context__.SourceCodeLine = 548;
                    FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 550;
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
            
            
            __context__.SourceCodeLine = 556;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 557;
            IROOM = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 559;
            if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
                { 
                __context__.SourceCodeLine = 561;
                J = (ushort) ( ((INSERT2BYTE2[ I ] .UshortValue * ROOM[ IROOM ].POINT[ I ].IVOLRANGE) / IVOLFBRANGE[ IROOM ]) ) ; 
                __context__.SourceCodeLine = 562;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( (J + ROOM[ IROOM ].POINT[ I ].SIVOLMIN) ) ; 
                __context__.SourceCodeLine = 563;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 565;
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
        
        
        __context__.SourceCodeLine = 573;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 574;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 576;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 578;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB1[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 579;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 581;
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
        
        
        __context__.SourceCodeLine = 588;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 589;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 591;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 593;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( FCHECKBOUNDS( __context__ , (ushort)( IROOM ) , (ushort)( I ) , (short)( INSERTDB2[ I ] .ShortValue ) ) ) ; 
            __context__.SourceCodeLine = 594;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 596;
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
        
        
        __context__.SourceCodeLine = 603;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 604;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 606;
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
        
        
        __context__.SourceCodeLine = 612;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 613;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 615;
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
        
        
        __context__.SourceCodeLine = 625;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 627;
        I = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 628;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 630;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ I ].IITEMACTIVE)  ) ) 
                { 
                __context__.SourceCodeLine = 632;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 634;
                    FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 638;
                    J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                    __context__.SourceCodeLine = 639;
                    MakeString ( STEMP , ":{0:d};", (short)J) ; 
                    __context__.SourceCodeLine = 640;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 642;
                        STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                        __context__.SourceCodeLine = 643;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 645;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( J )) ; 
                            __context__.SourceCodeLine = 646;
                            Trace( "Node_DSP: DefaultPointAll just propagated Point[{0:d}], which passed the gauntlet.", (short)J) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 650;
                            FDEFAULTPOINT (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
                            } 
                        
                        __context__.SourceCodeLine = 652;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BVOLDEFAULTISDISABLED ) || Functions.TestForTrue ( ROOM[ IROOM ].POINT[ I ].BMUTEDEFAULTISDISABLED )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 654;
                            Trace( "Node_DSP: DefaultPointAll just propagated Point[{0:d}] to group number {1:d}d. This Point has a disabled VolDefault or MuteDefault. Just an FYI.", (short)I, (short)ROOM[ IROOM ].POINT[ I ].IGROUP) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 628;
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
    
    
    __context__.SourceCodeLine = 672;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 674;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)2; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
            {
            __context__.SourceCodeLine = 674;
            STEMPVIS [ J ]  .UpdateValue ( "{ListVisFB:"  ) ; 
            __context__.SourceCodeLine = 674;
            }
        
        __context__.SourceCodeLine = 676;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 26 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)50; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 678;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 680;
                ROOM [ IROOM] . POINT [ I] . ILISTITEMVIS = (ushort) ( SYS.IRCSTATE ) ; 
                __context__.SourceCodeLine = 681;
                MakeString ( STEMPVIS [ ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ] , "{0}{1:d}={2:d},", STEMPVIS [ ROOM[ IROOM ].POINT[ I ].IPOINTTYPE ] , (ushort)I, (ushort)SYS.IRCSTATE) ; 
                } 
            
            __context__.SourceCodeLine = 676;
            } 
        
        __context__.SourceCodeLine = 685;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)2; 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (J  >= __FN_FORSTART_VAL__4) && (J  <= __FN_FOREND_VAL__4) ) : ( (J  <= __FN_FORSTART_VAL__4) && (J  >= __FN_FOREND_VAL__4) ) ; J  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 687;
            MakeString ( STEMPVIS [ J ] , "{0};|}}", STEMPVIS [ J ] ) ; 
            __context__.SourceCodeLine = 688;
            FSENDLISTFB (  __context__ , (ushort)( IROOM ), (ushort)( J ), STEMPVIS[ J ]) ; 
            __context__.SourceCodeLine = 685;
            } 
        
        __context__.SourceCodeLine = 672;
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
        
        
        __context__.SourceCodeLine = 702;
        SYS . IRCSTATE = (ushort) ( Functions.Not( RC_STATE  .Value ) ) ; 
        __context__.SourceCodeLine = 703;
        if ( Functions.TestForTrue  ( ( Functions.Not( IGROUPSEM ))  ) ) 
            { 
            __context__.SourceCodeLine = 706;
            IGROUPSEM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 707;
            Functions.Delay (  (int) ( 100 ) ) ; 
            __context__.SourceCodeLine = 709;
            IROOM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 711;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(50 / 2); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 713;
                if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IGROUP ))  ) ) 
                    { 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 717;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ I ].IPOINTTYPE != 3))  ) ) 
                        { 
                        __context__.SourceCodeLine = 719;
                        J = (ushort) ( ROOM[ IROOM ].POINT[ I ].IGROUP ) ; 
                        __context__.SourceCodeLine = 720;
                        MakeString ( STEMP , ":{0:d};", (short)J) ; 
                        __context__.SourceCodeLine = 722;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( STEMP , STEMP2 ) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 724;
                            STEMP2  .UpdateValue ( STEMP2 + STEMP  ) ; 
                            __context__.SourceCodeLine = 725;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J <= 50 ) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ J ].IGROUP == J) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BVOLISDISABLED ) ) || Functions.TestForTrue ( Functions.Not( ROOM[ IROOM ].POINT[ J ].BMUTEISDISABLED ) )) ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 727;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "vol") ; 
                                __context__.SourceCodeLine = 728;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( J ), "mute") ; 
                                __context__.SourceCodeLine = 729;
                                Trace( "Node_DSP: Group update just propagated Point[{0:d}] with group number {1:d}. Passed the gauntlet.", (short)J, (ushort)ROOM[ IROOM ].POINT[ J ].IGROUP) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 734;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                                __context__.SourceCodeLine = 735;
                                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
                                __context__.SourceCodeLine = 736;
                                Trace( "Node_DSP: Group update just propagated Point[{0:d}] with group number {1:d} based on the Point being the lowest index in the group.", (short)I, (ushort)ROOM[ IROOM ].POINT[ I ].IGROUP) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            } 
                        
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 711;
                } 
            
            __context__.SourceCodeLine = 747;
            FUPDATERCLISTITEMS (  __context__  ) ; 
            } 
        
        __context__.SourceCodeLine = 749;
        IGROUPSEM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 751;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)2; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( IROOM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__2) && (IROOM  <= __FN_FOREND_VAL__2) ) : ( (IROOM  <= __FN_FORSTART_VAL__2) && (IROOM  >= __FN_FOREND_VAL__2) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 753;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
                { 
                __context__.SourceCodeLine = 755;
                ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 756;
                FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IRCMUTE )) ; 
                } 
            
            __context__.SourceCodeLine = 751;
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
        
        
        __context__.SourceCodeLine = 766;
        SYS . IRCSTATE = (ushort) ( Functions.Not( RC_STATE  .Value ) ) ; 
        __context__.SourceCodeLine = 768;
        FUPDATERCLISTITEMS (  __context__  ) ; 
        __context__.SourceCodeLine = 770;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( IROOM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IROOM  >= __FN_FORSTART_VAL__1) && (IROOM  <= __FN_FOREND_VAL__1) ) : ( (IROOM  <= __FN_FORSTART_VAL__1) && (IROOM  >= __FN_FOREND_VAL__1) ) ; IROOM  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 772;
            if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
                { 
                __context__.SourceCodeLine = 774;
                ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 775;
                FSENDMUTE (  __context__ , (ushort)( IROOM ), (ushort)( ROOM[ IROOM ].IRCMUTE )) ; 
                } 
            
            __context__.SourceCodeLine = 770;
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
        
        
        __context__.SourceCodeLine = 783;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 784;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 786;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 787;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 789;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 790;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 793;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 795;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 796;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 797;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 798;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP1[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 800;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 801;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 798;
                } 
            
            __context__.SourceCodeLine = 803;
            while ( Functions.TestForTrue  ( ( DSPVOLUP1[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 805;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 806;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 807;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 803;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 810;
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
        
        
        __context__.SourceCodeLine = 816;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 817;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 819;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 820;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 822;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 823;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 827;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 829;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 830;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 831;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 832;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLUP2[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 834;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 835;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 832;
                } 
            
            __context__.SourceCodeLine = 837;
            while ( Functions.TestForTrue  ( ( DSPVOLUP2[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 839;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 840;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 841;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 837;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 844;
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
        
        
        __context__.SourceCodeLine = 851;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 852;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 854;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 855;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 857;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 858;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 862;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 864;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 865;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 866;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 867;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN1[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 869;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 870;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 867;
                } 
            
            __context__.SourceCodeLine = 872;
            while ( Functions.TestForTrue  ( ( DSPVOLDN1[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 874;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 875;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 876;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 872;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 879;
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
        
        
        __context__.SourceCodeLine = 886;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 887;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 889;
        IEXTARRYINDEX = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 890;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 892;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 893;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 896;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 898;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 899;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 900;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 901;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( DSPVOLDN2[ IEXTARRYINDEX ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 903;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 904;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 901;
                } 
            
            __context__.SourceCodeLine = 906;
            while ( Functions.TestForTrue  ( ( DSPVOLDN2[ IEXTARRYINDEX ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 908;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 909;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 910;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 906;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 913;
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
        
        
        __context__.SourceCodeLine = 921;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 922;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 924;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 926;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 927;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 931;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 933;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 934;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 936;
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
        
        
        __context__.SourceCodeLine = 944;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 945;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 947;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 949;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 950;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 953;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 955;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 956;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 958;
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
        
        
        __context__.SourceCodeLine = 966;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 967;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 969;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 971;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 972;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 976;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 978;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 979;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 981;
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
        
        
        __context__.SourceCodeLine = 988;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 989;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 991;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 993;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 994;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 996;
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
        
        
        __context__.SourceCodeLine = 1003;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1004;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1006;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1008;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 1009;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1013;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1015;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1016;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1018;
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
        
        
        __context__.SourceCodeLine = 1024;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1025;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1027;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 25 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1029;
            I = (ushort) ( (Mod( (I - 1) , 25 ) + 1) ) ; 
            __context__.SourceCodeLine = 1030;
            IROOM = (ushort) ( FOTHERROOM( __context__ , (ushort)( IROOM ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1034;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1036;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1037;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1039;
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
        
        
        __context__.SourceCodeLine = 1053;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1055;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].PGMRTEINDEX)  ) ) 
            { 
            __context__.SourceCodeLine = 1057;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 1))  ) ) 
                {
                __context__.SourceCodeLine = 1057;
                DSPVOLDB1 [ ROOM[ IROOM ].PGMRTEINDEX]  .Value = (ushort) ( PGM_RTE[ IROOM ] .UshortValue ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1058;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IROOM == 2))  ) ) 
                    {
                    __context__.SourceCodeLine = 1058;
                    DSPVOLDB2 [ ROOM[ IROOM ].PGMRTEINDEX]  .Value = (ushort) ( PGM_RTE[ IROOM ] .UshortValue ) ; 
                    }
                
                }
            
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
        
        
        __context__.SourceCodeLine = 1067;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1068;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1069;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1071;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1073;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 1074;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1075;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1076;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1078;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1079;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1076;
                } 
            
            __context__.SourceCodeLine = 1081;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1083;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 1084;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1085;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1081;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1088;
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
        
        
        __context__.SourceCodeLine = 1094;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1095;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1096;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1098;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1100;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
            __context__.SourceCodeLine = 1101;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1102;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1103;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLUP2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1105;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1106;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1103;
                } 
            
            __context__.SourceCodeLine = 1108;
            while ( Functions.TestForTrue  ( ( FIXEDVOLUP2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1110;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMin( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE + 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMAX ) ) ; 
                __context__.SourceCodeLine = 1111;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1112;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1108;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1115;
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
        
        
        __context__.SourceCodeLine = 1122;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1123;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1124;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1126;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1128;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 1129;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1130;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1131;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN1[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1133;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1134;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1131;
                } 
            
            __context__.SourceCodeLine = 1136;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN1[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1138;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 1139;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1140;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1136;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1143;
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
        
        
        __context__.SourceCodeLine = 1150;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1151;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1152;
        IFIXED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1154;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BVOLISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1156;
            ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
            __context__.SourceCodeLine = 1157;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
            __context__.SourceCodeLine = 1158;
            J = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1159;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( J < 25 ) ) && Functions.TestForTrue ( FIXEDVOLDN2[ IFIXED ] .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1161;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 1162;
                Functions.Delay (  (int) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1159;
                } 
            
            __context__.SourceCodeLine = 1164;
            while ( Functions.TestForTrue  ( ( FIXEDVOLDN2[ IFIXED ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 1166;
                ROOM [ IROOM] . POINT [ I] . SIVOLSTATE = (short) ( Functions.SMax( (ROOM[ IROOM ].POINT[ I ].SIVOLSTATE - 1) , ROOM[ IROOM ].POINT[ I ].SIVOLMIN ) ) ; 
                __context__.SourceCodeLine = 1167;
                FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "vol") ; 
                __context__.SourceCodeLine = 1168;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 1164;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1171;
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
        
        
        __context__.SourceCodeLine = 1178;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1179;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1181;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1183;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 1184;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1186;
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
        
        
        __context__.SourceCodeLine = 1193;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1194;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1196;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1198;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( Functions.Not( ROOM[ IROOM ].POINT[ I ].IMUTESTATE ) ) ; 
            __context__.SourceCodeLine = 1199;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1201;
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
        
        
        __context__.SourceCodeLine = 1208;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1209;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1211;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1213;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1214;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1216;
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
        
        
        __context__.SourceCodeLine = 1222;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1223;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1225;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1227;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1228;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1230;
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
        
        
        __context__.SourceCodeLine = 1236;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1237;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1239;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1241;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1242;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1244;
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
        
        
        __context__.SourceCodeLine = 1249;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1250;
        I = (ushort) ( ROOM[ IROOM ].FIXEDTOLOCALID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] ) ; 
        __context__.SourceCodeLine = 1252;
        if ( Functions.TestForTrue  ( ( Functions.Not( ROOM[ IROOM ].POINT[ I ].BMUTEISDISABLED ))  ) ) 
            { 
            __context__.SourceCodeLine = 1254;
            ROOM [ IROOM] . POINT [ I] . IMUTESTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1255;
            FGROUPMANAGER (  __context__ , (ushort)( IROOM ), (ushort)( I ), "mute") ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1257;
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
        
        
        __context__.SourceCodeLine = 1273;
        IROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1275;
        if ( Functions.TestForTrue  ( ( VOLFBRANGE[ IROOM ] .UshortValue)  ) ) 
            {
            __context__.SourceCodeLine = 1275;
            IVOLFBRANGE [ IROOM] = (ushort) ( VOLFBRANGE[ IROOM ] .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1276;
            IVOLFBRANGE [ IROOM] = (ushort) ( 936 ) ; 
            }
        
        __context__.SourceCodeLine = 1278;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1280;
            FSETVOLFB (  __context__ , (ushort)( IROOM ), (ushort)( I )) ; 
            __context__.SourceCodeLine = 1278;
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
    
    
    __context__.SourceCodeLine = 1300;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)2; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( ILIST  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILIST  >= __FN_FORSTART_VAL__1) && (ILIST  <= __FN_FOREND_VAL__1) ) : ( (ILIST  <= __FN_FORSTART_VAL__1) && (ILIST  >= __FN_FOREND_VAL__1) ) ; ILIST  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 1302;
        FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( ILIST ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 1303;
        Functions.Delay (  (int) ( 10 ) ) ; 
        __context__.SourceCodeLine = 1300;
        } 
    
    __context__.SourceCodeLine = 1307;
    if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].IRCMUTE)  ) ) 
        { 
        __context__.SourceCodeLine = 1309;
        ROOM [ IROOM] . POINT [ ROOM[ IROOM ].IRCMUTE] . IMUTESTATE = (ushort) ( Functions.Not( SYS.IRCSTATE ) ) ; 
        __context__.SourceCodeLine = 1310;
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
    
    
    __context__.SourceCodeLine = 1326;
    STEMPLINE  .UpdateValue ( STEMPLINEARG  ) ; 
    __context__.SourceCodeLine = 1328;
    while ( Functions.TestForTrue  ( ( Functions.Find( "," , STEMPLINE ))  ) ) 
        { 
        __context__.SourceCodeLine = 1330;
        STEMPPAIR  .UpdateValue ( Functions.Remove ( "," , STEMPLINE )  ) ; 
        __context__.SourceCodeLine = 1331;
        STEMPKEY  .UpdateValue ( Functions.Remove ( "=" , STEMPPAIR )  ) ; 
        __context__.SourceCodeLine = 1332;
        STEMPVALUE  .UpdateValue ( Functions.Left ( STEMPPAIR ,  (int) ( (Functions.Length( STEMPPAIR ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 1334;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "global_name" , STEMPKEY ))  ) ) 
            {
            __context__.SourceCodeLine = 1334;
            ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  .UpdateValue ( STEMPVALUE  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1335;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "local_name" , STEMPKEY ))  ) ) 
                {
                __context__.SourceCodeLine = 1335;
                ROOM [ IROOM] . POINT [ IINDEX] . SLOCALNAME  .UpdateValue ( STEMPVALUE  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1336;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "room" , STEMPKEY ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1336;
                    ROOM [ IROOM] . POINT [ IINDEX] . IRMASS = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1337;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "guid" , STEMPKEY ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1337;
                        ROOM [ IROOM] . POINT [ IINDEX] . IGUID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1338;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "fixed_id" , STEMPKEY ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1340;
                            ROOM [ IROOM] . POINT [ IINDEX] . IFIXEDID = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                            __context__.SourceCodeLine = 1341;
                            ROOM [ IROOM] . FIXEDTOLOCALID [ Functions.Atoi( STEMPVALUE )] = (ushort) ( IINDEX ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1343;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "group" , STEMPKEY ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1343;
                                ROOM [ IROOM] . POINT [ IINDEX] . IGROUP = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1344;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "is_virtual" , STEMPKEY ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1344;
                                    ROOM [ IROOM] . POINT [ IINDEX] . IISVIRTUAL = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1345;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_max" , STEMPKEY ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 1345;
                                        ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1346;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "range_min" , STEMPKEY ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 1346;
                                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1347;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_vol" , STEMPKEY ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 1347;
                                                ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( Functions.Atosi( STEMPVALUE ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1348;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "default_mute" , STEMPKEY ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 1348;
                                                    ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1349;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "vol_disabled" , STEMPKEY ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 1349;
                                                        ROOM [ IROOM] . POINT [ IINDEX] . BVOLISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1350;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "mute_disabled" , STEMPKEY ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 1350;
                                                            ROOM [ IROOM] . POINT [ IINDEX] . BMUTEISDISABLED = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1351;
                                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "point_type" , STEMPKEY ))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1351;
                                                                ROOM [ IROOM] . POINT [ IINDEX] . IPOINTTYPE = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                }
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 1352;
                                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "function" , STEMPKEY ))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 1352;
                                                                    ROOM [ IROOM] . POINT [ IINDEX] . IFUNCTION = (ushort) ( Functions.Atoi( STEMPVALUE ) ) ; 
                                                                    }
                                                                
                                                                else 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1355;
                                                                    IERR = (ushort) ( 1 ) ; 
                                                                    __context__.SourceCodeLine = 1356;
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
        
        __context__.SourceCodeLine = 1328;
        } 
    
    __context__.SourceCodeLine = 1360;
    if ( Functions.TestForTrue  ( ( Functions.Not( IERR ))  ) ) 
        { 
        __context__.SourceCodeLine = 1363;
        
            {
            int __SPLS_TMPVAR__SWTCH_4__ = ((int)ROOM[ IROOM ].POINT[ IINDEX ].IFUNCTION);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                    { 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 1366;
                    ROOM [ IROOM] . IRCMUTE = (ushort) ( IINDEX ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1370;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE == 3))  ) ) 
            {
            __context__.SourceCodeLine = 1371;
            ROOM [ IROOM] . PGMRTEINDEX = (ushort) ( IINDEX ) ; 
            }
        
        __context__.SourceCodeLine = 1373;
        IPOINTTYPE = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IPOINTTYPE ) ; 
        __context__.SourceCodeLine = 1375;
        ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1376;
        ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( (ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMAX - ROOM[ IROOM ].POINT[ IINDEX ].SIVOLMIN) ) ; 
        __context__.SourceCodeLine = 1377;
        ROOM [ IROOM] . IINDEXPRIMARY [ IINDEX] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1379;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . IINDEXRC [ (IINDEX + 25)] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1380;
        ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . POINT [ (IINDEX + 25)] . IPOINTTYPE = (ushort) ( IPOINTTYPE ) ; 
        __context__.SourceCodeLine = 1382;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE == 0) ) || Functions.TestForTrue ( Functions.BoolToInt ( ROOM[ IROOM ].POINT[ IINDEX ].IVOLRANGE > 50000 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1384;
            ROOM [ IROOM] . POINT [ IINDEX] . IITEMACTIVE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1386;
            Trace( "NodeDSP - error parsing iRoom={0:d}, iIndex={1:d} - iVolRange calculated to be zero", (ushort)IROOM, (ushort)IINDEX) ; 
            } 
        
        __context__.SourceCodeLine = 1389;
        if ( Functions.TestForTrue  ( ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP)  ) ) 
            { 
            __context__.SourceCodeLine = 1391;
            IGROUP = (ushort) ( ROOM[ IROOM ].POINT[ IINDEX ].IGROUP ) ; 
            __context__.SourceCodeLine = 1393;
            ROOM [ IROOM] . GROUP [ IGROUP] . INUMOFMEMBERS = (ushort) ( (ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS + 1) ) ; 
            __context__.SourceCodeLine = 1394;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . GROUP [ IGROUP] . INUMOFMEMBERS = (ushort) ( (ROOM[ FOTHERROOM( __context__ , (ushort)( IROOM ) ) ].GROUP[ IGROUP ].INUMOFMEMBERS + 1) ) ; 
            __context__.SourceCodeLine = 1396;
            ROOM [ IROOM] . GROUP [ IGROUP] . IGROUPMEMBERS [ ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS] = (ushort) ( (IINDEX + ((IROOM - 1) * 50)) ) ; 
            __context__.SourceCodeLine = 1397;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . GROUP [ IGROUP] . IGROUPMEMBERS [ ROOM[ IROOM ].GROUP[ IGROUP ].INUMOFMEMBERS] = (ushort) ( (IINDEX + ((IROOM - 1) * 50)) ) ; 
            } 
        
        __context__.SourceCodeLine = 1406;
        
            {
            int __SPLS_TMPVAR__SWTCH_5__ = ((int)IROOM);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1410;
                    DSPPOINTNAME__DOLLAR__1 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1412;
                    DSPPOINTNAME__DOLLAR__2 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1416;
                    DSPPOINTNAME__DOLLAR__2 [ IINDEX]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    __context__.SourceCodeLine = 1417;
                    DSPPOINTNAME__DOLLAR__1 [ (IINDEX + 25)]  .UpdateValue ( ROOM [ IROOM] . POINT [ IINDEX] . SGLOBALNAME  ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 1421;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IPOINTTYPE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (IPOINTTYPE == 2) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1423;
            ROOM [ IROOM] . POINT [ IINDEX] . ILISTITEMVIS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1424;
            FUPDATELISTVIS (  __context__ , (ushort)( IROOM ), (ushort)( IPOINTTYPE ), (ushort)( IINDEX )) ; 
            __context__.SourceCodeLine = 1426;
            ROOM [ FOTHERROOM( __context__ , (ushort)( IROOM ) )] . POINT [ (IINDEX + 25)] . ILISTITEMVIS = (ushort) ( SYS.IRCSTATE ) ; 
            __context__.SourceCodeLine = 1427;
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
    
    
    __context__.SourceCodeLine = 1442;
    STEMPDATA  .UpdateValue ( STEMPINITDATA  ) ; 
    __context__.SourceCodeLine = 1443;
    STEMPHEADER  .UpdateValue ( Functions.Remove ( ";" , STEMPDATA )  ) ; 
    __context__.SourceCodeLine = 1445;
    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_POINTS" , STEMPHEADER ))  ) ) 
        {
        __context__.SourceCodeLine = 1445;
        ITYPE = (ushort) ( 1 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 1446;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "DSP_PRESETS" , STEMPHEADER ))  ) ) 
            {
            __context__.SourceCodeLine = 1446;
            ITYPE = (ushort) ( 2 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1447;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ROOMS" , STEMPHEADER ))  ) ) 
                {
                __context__.SourceCodeLine = 1447;
                ITYPE = (ushort) ( 13 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1448;
                Trace( "NodeDSP - in fProcessInit - didn't catch header type - {0}", STEMPHEADER ) ; 
                }
            
            }
        
        }
    
    __context__.SourceCodeLine = 1450;
    while ( Functions.TestForTrue  ( ( Functions.Find( "|" , STEMPDATA ))  ) ) 
        { 
        __context__.SourceCodeLine = 1452;
        STEMPLINE  .UpdateValue ( Functions.Remove ( "|" , STEMPDATA )  ) ; 
        __context__.SourceCodeLine = 1453;
        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "complete" , STEMPLINE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1455;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 1456;
            FPROCESSLIST (  __context__ , (ushort)( IROOM )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1460;
            STEMPGUID  .UpdateValue ( Functions.Remove ( ":" , STEMPLINE )  ) ; 
            __context__.SourceCodeLine = 1461;
            IINDEX = (ushort) ( Functions.Atoi( STEMPGUID ) ) ; 
            __context__.SourceCodeLine = 1463;
            if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                { 
                __context__.SourceCodeLine = 1465;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_6__ = ((int)ITYPE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 1469;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMAX = (short) ( 6 ) ; 
                            __context__.SourceCodeLine = 1470;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLMIN = (short) ( Functions.ToInteger( -( 20 ) ) ) ; 
                            __context__.SourceCodeLine = 1471;
                            ROOM [ IROOM] . POINT [ IINDEX] . IVOLRANGE = (ushort) ( 26 ) ; 
                            __context__.SourceCodeLine = 1472;
                            ROOM [ IROOM] . POINT [ IINDEX] . IMUTEDEFAULT = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1473;
                            ROOM [ IROOM] . POINT [ IINDEX] . SIVOLDEFAULT = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 1475;
                            FPROCESSLINE (  __context__ , (ushort)( IROOM ), (ushort)( ITYPE ), (ushort)( IINDEX ), STEMPLINE) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1481;
                Trace( "NodeDSP - fProcessInit error, iIndex did not resolve -    {0} {1:d} {2}", STEMPHEADER , (ushort)IINDEX, STEMPLINE ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1450;
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
        
        
        __context__.SourceCodeLine = 1498;
        IROOM = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1499;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__1[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1501;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__1 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1502;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1499;
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
        
        
        __context__.SourceCodeLine = 1510;
        IROOM = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1511;
        while ( Functions.TestForTrue  ( ( Functions.Find( "}" , DATAINIT_RX__DOLLAR__2[ 1 ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 1513;
            STEMP  .UpdateValue ( Functions.Gather ( "}" , DATAINIT_RX__DOLLAR__2 [ 1 ] )  ) ; 
            __context__.SourceCodeLine = 1514;
            FPROCESSINIT (  __context__ , (ushort)( IROOM ), STEMP) ; 
            __context__.SourceCodeLine = 1511;
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
        
        __context__.SourceCodeLine = 1531;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1533;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)2; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1535;
            if ( Functions.TestForTrue  ( ( VOLFBRANGE[ I ] .UshortValue)  ) ) 
                {
                __context__.SourceCodeLine = 1535;
                IVOLFBRANGE [ I] = (ushort) ( VOLFBRANGE[ I ] .UshortValue ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1536;
                IVOLFBRANGE [ I] = (ushort) ( 936 ) ; 
                }
            
            __context__.SourceCodeLine = 1533;
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

public UserModuleClass_L3_UA_HSIB_NODEDSP_V1_0_77 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
