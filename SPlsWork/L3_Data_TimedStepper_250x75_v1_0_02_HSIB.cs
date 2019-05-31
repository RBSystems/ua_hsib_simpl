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

namespace UserModule_L3_DATA_TIMEDSTEPPER_250X75_V1_0_02_HSIB
{
    public class UserModuleClass_L3_DATA_TIMEDSTEPPER_250X75_V1_0_02_HSIB : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalInput TCP_IS_CONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput MANUAL_UPDATE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> IN__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZED_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> OUT__DOLLAR__;
        UShortParameter STEP_TIME;
        UShortParameter HIGHEST_INDEX;
        StringParameter KEYS_TO_STORE;
        ushort ITCPCONNECTED = 0;
        ushort INEWCHANGEDURINGLOOP = 0;
        ushort ILOOPRUNNING = 0;
        ushort [] ICHANGED;
        ushort INUMOFKEYS = 0;
        CrestronString STRASH;
        CrestronString [] SKEYS;
        L3_Tools.StringTools ST;
        private void FSEND (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 72;
            OUT__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.SDATA [ I ]  ) ; 
            __context__.SourceCodeLine = 73;
            ICHANGED [ I] = (ushort) ( 0 ) ; 
            
            }
            
        private void FRUNLOOPWORK (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 80;
            Trace( "TimedStepper - fRunLoopWork") ; 
            __context__.SourceCodeLine = 81;
            ILOOPRUNNING = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 82;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)HIGHEST_INDEX  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 84;
                if ( Functions.TestForTrue  ( ( Functions.Not( ITCPCONNECTED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 86;
                    Trace( "TimedStepper - exited fRunLoopWork via  !TCP_is_Connected  condition") ; 
                    __context__.SourceCodeLine = 87;
                    ILOOPRUNNING = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 88;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 91;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ICHANGED[ I ] ) && Functions.TestForTrue ( Functions.Length( _SplusNVRAM.SDATA[ I ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 93;
                    FSEND (  __context__ , (ushort)( I )) ; 
                    __context__.SourceCodeLine = 94;
                    Functions.Delay (  (int) ( STEP_TIME  .Value ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 82;
                } 
            
            __context__.SourceCodeLine = 97;
            Trace( "TimedStepper - exited naturally") ; 
            __context__.SourceCodeLine = 99;
            ILOOPRUNNING = (ushort) ( 0 ) ; 
            
            }
            
        private void FRUNLOOP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 104;
            Trace( "TimedStepper - fRunLoop;  TCP_is_Connected={0:d}, iLoopRunning={1:d}", (ushort)ITCPCONNECTED, (short)ILOOPRUNNING) ; 
            __context__.SourceCodeLine = 106;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ITCPCONNECTED ) && Functions.TestForTrue ( Functions.Not( ILOOPRUNNING ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 108;
                FRUNLOOPWORK (  __context__  ) ; 
                __context__.SourceCodeLine = 110;
                while ( Functions.TestForTrue  ( ( INEWCHANGEDURINGLOOP)  ) ) 
                    { 
                    __context__.SourceCodeLine = 112;
                    INEWCHANGEDURINGLOOP = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 113;
                    if ( Functions.TestForTrue  ( ( ITCPCONNECTED)  ) ) 
                        {
                        __context__.SourceCodeLine = 113;
                        FRUNLOOPWORK (  __context__  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 110;
                    } 
                
                } 
            
            
            }
            
        private CrestronString FFILTERKEYDATA (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            ushort I = 0;
            ushort IMARKER = 0;
            
            CrestronString STEMPDATA;
            CrestronString STEMP1;
            CrestronString STEMPOUTPUT;
            STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            STEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            STEMPOUTPUT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            
            
            __context__.SourceCodeLine = 123;
            STEMPDATA  .UpdateValue ( SDATA  ) ; 
            __context__.SourceCodeLine = 125;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)INUMOFKEYS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 127;
                IMARKER = (ushort) ( Functions.Find( SKEYS[ I ] , STEMPDATA ) ) ; 
                __context__.SourceCodeLine = 128;
                if ( Functions.TestForTrue  ( ( IMARKER)  ) ) 
                    { 
                    __context__.SourceCodeLine = 130;
                    MakeString ( STEMPOUTPUT , "{0}{1},", STEMPOUTPUT , Functions.Mid ( STEMPDATA ,  (int) ( IMARKER ) ,  (int) ( Functions.Find( "," , STEMPDATA , IMARKER ) ) ) ) ; 
                    __context__.SourceCodeLine = 131;
                    STEMP1  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (IMARKER - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 132;
                    STRASH  .UpdateValue ( Functions.Remove ( Functions.Find( "," , STEMPDATA , IMARKER ), STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 133;
                    STEMPDATA  .UpdateValue ( STEMP1 + STEMPDATA  ) ; 
                    } 
                
                __context__.SourceCodeLine = 125;
                } 
            
            __context__.SourceCodeLine = 137;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMPOUTPUT ))  ) ) 
                {
                __context__.SourceCodeLine = 137;
                STEMPOUTPUT  .UpdateValue ( Functions.Left ( STEMPOUTPUT ,  (int) ( (Functions.Length( STEMPOUTPUT ) - 1) ) )  ) ; 
                }
            
            __context__.SourceCodeLine = 139;
            return ( STEMPOUTPUT ) ; 
            
            }
            
        object INITIALIZED_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 146;
                _SplusNVRAM.IINITIALIZED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 147;
                INITIALIZED_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 149;
                Trace( "TimedStepper - Initialized") ; 
                __context__.SourceCodeLine = 151;
                FRUNLOOP (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object TCP_IS_CONNECTED_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 158;
            Trace( "TimedStepper - TCP_is_Connected push") ; 
            __context__.SourceCodeLine = 159;
            ITCPCONNECTED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 160;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.IINITIALIZED)  ) ) 
                {
                __context__.SourceCodeLine = 160;
                FRUNLOOP (  __context__  ) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TCP_IS_CONNECTED_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 166;
        Trace( "TimedStepper - TCP_is_Connected release") ; 
        __context__.SourceCodeLine = 168;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)HIGHEST_INDEX  .Value; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 170;
            ICHANGED [ I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 168;
            } 
        
        __context__.SourceCodeLine = 172;
        ITCPCONNECTED = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MANUAL_UPDATE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 177;
        FRUNLOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IN__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 184;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 186;
        ICHANGED [ I] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 187;
        _SplusNVRAM.SDATA [ I ]  .UpdateValue ( FFILTERKEYDATA (  __context__ , IN__DOLLAR__[ I ])  ) ; 
        __context__.SourceCodeLine = 189;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ILOOPRUNNING ) ) && Functions.TestForTrue ( _SplusNVRAM.IINITIALIZED )) ))  ) ) 
            {
            __context__.SourceCodeLine = 189;
            FSEND (  __context__ , (ushort)( I )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 192;
            INEWCHANGEDURINGLOOP = (ushort) ( 1 ) ; 
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
    CrestronString STEMPKEYS;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    STEMPKEYS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 201;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 203;
        I = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 204;
        STEMPKEYS  .UpdateValue ( KEYS_TO_STORE  ) ; 
        __context__.SourceCodeLine = 205;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "," , STEMPKEYS ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I <= 30 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 207;
            I = (ushort) ( (I + 1) ) ; 
            __context__.SourceCodeLine = 208;
            STEMP  .UpdateValue ( Functions.Remove ( "," , STEMPKEYS )  ) ; 
            __context__.SourceCodeLine = 209;
            SKEYS [ I ]  .UpdateValue ( ST . StringTrim (  Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) )  .ToSimplSharpString() )  ) ; 
            __context__.SourceCodeLine = 205;
            } 
        
        __context__.SourceCodeLine = 212;
        STEMPKEYS  .UpdateValue ( ST . StringTrim (  STEMPKEYS  .ToSimplSharpString() )  ) ; 
        __context__.SourceCodeLine = 213;
        if ( Functions.TestForTrue  ( ( Functions.Length( STEMPKEYS ))  ) ) 
            { 
            __context__.SourceCodeLine = 215;
            I = (ushort) ( (I + 1) ) ; 
            __context__.SourceCodeLine = 216;
            SKEYS [ I ]  .UpdateValue ( ST . StringTrim (  STEMPKEYS  .ToSimplSharpString() )  ) ; 
            } 
        
        __context__.SourceCodeLine = 219;
        INUMOFKEYS = (ushort) ( I ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    ICHANGED  = new ushort[ 751 ];
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    _SplusNVRAM.SDATA  = new CrestronString[ 251 ];
    for( uint i = 0; i < 251; i++ )
        _SplusNVRAM.SDATA [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 75, this );
    SKEYS  = new CrestronString[ 31 ];
    for( uint i = 0; i < 31; i++ )
        SKEYS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    INITIALIZED = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZED__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZED__DigitalInput__, INITIALIZED );
    
    TCP_IS_CONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( TCP_IS_CONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( TCP_IS_CONNECTED__DigitalInput__, TCP_IS_CONNECTED );
    
    MANUAL_UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( MANUAL_UPDATE__DigitalInput__, this );
    m_DigitalInputList.Add( MANUAL_UPDATE__DigitalInput__, MANUAL_UPDATE );
    
    INITIALIZED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZED_FB__DigitalOutput__, INITIALIZED_FB );
    
    IN__DOLLAR__ = new InOutArray<StringInput>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        IN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR____AnalogSerialInput__, 500, this );
        m_StringInputList.Add( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR__[i+1] );
    }
    
    OUT__DOLLAR__ = new InOutArray<StringOutput>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        OUT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( OUT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( OUT__DOLLAR____AnalogSerialOutput__ + i, OUT__DOLLAR__[i+1] );
    }
    
    STEP_TIME = new UShortParameter( STEP_TIME__Parameter__, this );
    m_ParameterList.Add( STEP_TIME__Parameter__, STEP_TIME );
    
    HIGHEST_INDEX = new UShortParameter( HIGHEST_INDEX__Parameter__, this );
    m_ParameterList.Add( HIGHEST_INDEX__Parameter__, HIGHEST_INDEX );
    
    KEYS_TO_STORE = new StringParameter( KEYS_TO_STORE__Parameter__, this );
    m_ParameterList.Add( KEYS_TO_STORE__Parameter__, KEYS_TO_STORE );
    
    
    INITIALIZED.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZED_OnPush_0, false ) );
    TCP_IS_CONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( TCP_IS_CONNECTED_OnPush_1, false ) );
    TCP_IS_CONNECTED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TCP_IS_CONNECTED_OnRelease_2, false ) );
    MANUAL_UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MANUAL_UPDATE_OnPush_3, false ) );
    for( uint i = 0; i < 250; i++ )
        IN__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( IN__DOLLAR___OnChange_4, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ST  = new L3_Tools.StringTools();
    
    
}

public UserModuleClass_L3_DATA_TIMEDSTEPPER_250X75_V1_0_02_HSIB ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZED__DigitalInput__ = 0;
const uint TCP_IS_CONNECTED__DigitalInput__ = 1;
const uint MANUAL_UPDATE__DigitalInput__ = 2;
const uint IN__DOLLAR____AnalogSerialInput__ = 0;
const uint INITIALIZED_FB__DigitalOutput__ = 0;
const uint OUT__DOLLAR____AnalogSerialOutput__ = 0;
const uint STEP_TIME__Parameter__ = 10;
const uint HIGHEST_INDEX__Parameter__ = 11;
const uint KEYS_TO_STORE__Parameter__ = 12;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort IINITIALIZED = 0;
            [SplusStructAttribute(1, false, true)]
            public CrestronString [] SDATA;
            
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


}
