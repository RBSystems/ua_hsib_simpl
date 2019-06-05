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

namespace UserModule_L3_DATA_TIMEDSTEPPER_250X75_V1_0_03_HSIB
{
    public class UserModuleClass_L3_DATA_TIMEDSTEPPER_250X75_V1_0_03_HSIB : SplusObject
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
        ushort IINITIALIZED = 0;
        ushort INUMOFKEYS = 0;
        CrestronString STRASH;
        CrestronString [] SKEYS;
        L3_Tools.StringTools ST;
        private void FSEND (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 76;
            OUT__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.SDATA [ I ]  ) ; 
            
            }
            
        private void FRUNLOOPWORK (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 84;
            Trace( "TimedStepper - fRunLoopWork") ; 
            __context__.SourceCodeLine = 85;
            ILOOPRUNNING = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 86;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)HIGHEST_INDEX  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 88;
                if ( Functions.TestForTrue  ( ( Functions.Not( ITCPCONNECTED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 90;
                    Trace( "TimedStepper - exited fRunLoopWork via  !TCP_is_Connected  condition") ; 
                    __context__.SourceCodeLine = 91;
                    ILOOPRUNNING = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 92;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 95;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( _SplusNVRAM.ICHANGED[ I ] ) && Functions.TestForTrue ( Functions.Length( _SplusNVRAM.SDATA[ I ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 97;
                    FSEND (  __context__ , (ushort)( I )) ; 
                    __context__.SourceCodeLine = 98;
                    Functions.Delay (  (int) ( STEP_TIME  .Value ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 86;
                } 
            
            __context__.SourceCodeLine = 101;
            Trace( "TimedStepper - exited naturally") ; 
            __context__.SourceCodeLine = 103;
            ILOOPRUNNING = (ushort) ( 0 ) ; 
            
            }
            
        private void FRUNLOOP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 108;
            Trace( "TimedStepper - fRunLoop;  TCP_is_Connected={0:d}, iLoopRunning={1:d}", (ushort)ITCPCONNECTED, (short)ILOOPRUNNING) ; 
            __context__.SourceCodeLine = 110;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( ITCPCONNECTED ) && Functions.TestForTrue ( Functions.Not( ILOOPRUNNING ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 112;
                FRUNLOOPWORK (  __context__  ) ; 
                __context__.SourceCodeLine = 114;
                while ( Functions.TestForTrue  ( ( INEWCHANGEDURINGLOOP)  ) ) 
                    { 
                    __context__.SourceCodeLine = 116;
                    INEWCHANGEDURINGLOOP = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 117;
                    if ( Functions.TestForTrue  ( ( ITCPCONNECTED)  ) ) 
                        {
                        __context__.SourceCodeLine = 117;
                        FRUNLOOPWORK (  __context__  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 114;
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
            CrestronString SDIVCHAR;
            STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            STEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            STEMPOUTPUT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            SDIVCHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 127;
            STEMPDATA  .UpdateValue ( SDATA  ) ; 
            __context__.SourceCodeLine = 128;
            SDIVCHAR  .UpdateValue ( ","  ) ; 
            __context__.SourceCodeLine = 129;
            if ( Functions.TestForTrue  ( ( Functions.Find( "~" , STEMPDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 129;
                SDIVCHAR  .UpdateValue ( "~"  ) ; 
                }
            
            __context__.SourceCodeLine = 131;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)INUMOFKEYS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 133;
                IMARKER = (ushort) ( Functions.Find( SKEYS[ I ] , STEMPDATA ) ) ; 
                __context__.SourceCodeLine = 134;
                if ( Functions.TestForTrue  ( ( IMARKER)  ) ) 
                    { 
                    __context__.SourceCodeLine = 136;
                    MakeString ( STEMPOUTPUT , "{0}{1},", STEMPOUTPUT , Functions.Mid ( STEMPDATA ,  (int) ( IMARKER ) ,  (int) ( (Functions.Find( SDIVCHAR , STEMPDATA , IMARKER ) - IMARKER) ) ) ) ; 
                    __context__.SourceCodeLine = 137;
                    STEMP1  .UpdateValue ( Functions.Left ( STEMPDATA ,  (int) ( (IMARKER - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 138;
                    STRASH  .UpdateValue ( Functions.Remove ( Functions.Find( SDIVCHAR , STEMPDATA , IMARKER ), STEMPDATA )  ) ; 
                    __context__.SourceCodeLine = 139;
                    STEMPDATA  .UpdateValue ( STEMP1 + STEMPDATA  ) ; 
                    } 
                
                __context__.SourceCodeLine = 131;
                } 
            
            __context__.SourceCodeLine = 143;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEMPOUTPUT ))  ) ) 
                {
                __context__.SourceCodeLine = 143;
                STEMPOUTPUT  .UpdateValue ( Functions.Left ( STEMPOUTPUT ,  (int) ( (Functions.Length( STEMPOUTPUT ) - 1) ) )  ) ; 
                }
            
            __context__.SourceCodeLine = 145;
            return ( STEMPOUTPUT ) ; 
            
            }
            
        object INITIALIZED_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 152;
                IINITIALIZED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 153;
                INITIALIZED_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 155;
                FRUNLOOP (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    private void FCLEARDATA (  SplusExecutionContext __context__ ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 163;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)250; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 165;
            _SplusNVRAM.ICHANGED [ I] = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 166;
            _SplusNVRAM.SDATA [ I ]  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 163;
            } 
        
        
        }
        
    object INITIALIZED_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 172;
            IINITIALIZED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 173;
            INITIALIZED_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 175;
            FCLEARDATA (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TCP_IS_CONNECTED_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 181;
        Trace( "TimedStepper - TCP_is_Connected push") ; 
        __context__.SourceCodeLine = 182;
        ITCPCONNECTED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 183;
        if ( Functions.TestForTrue  ( ( IINITIALIZED)  ) ) 
            {
            __context__.SourceCodeLine = 183;
            FRUNLOOP (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TCP_IS_CONNECTED_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 189;
        Trace( "TimedStepper - TCP_is_Connected release") ; 
        __context__.SourceCodeLine = 191;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)HIGHEST_INDEX  .Value; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 193;
            _SplusNVRAM.ICHANGED [ I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 191;
            } 
        
        __context__.SourceCodeLine = 195;
        ITCPCONNECTED = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MANUAL_UPDATE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 200;
        FRUNLOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IN__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 207;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 209;
        _SplusNVRAM.ICHANGED [ I] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 210;
        _SplusNVRAM.SDATA [ I ]  .UpdateValue ( FFILTERKEYDATA (  __context__ , IN__DOLLAR__[ I ])  ) ; 
        __context__.SourceCodeLine = 212;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ILOOPRUNNING ) ) && Functions.TestForTrue ( IINITIALIZED )) ))  ) ) 
            {
            __context__.SourceCodeLine = 212;
            FSEND (  __context__ , (ushort)( I )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 213;
            if ( Functions.TestForTrue  ( ( IINITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 215;
                INEWCHANGEDURINGLOOP = (ushort) ( 1 ) ; 
                } 
            
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
        
        __context__.SourceCodeLine = 224;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 227;
        I = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 228;
        STEMPKEYS  .UpdateValue ( KEYS_TO_STORE  ) ; 
        __context__.SourceCodeLine = 229;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "," , STEMPKEYS ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I <= 30 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 231;
            I = (ushort) ( (I + 1) ) ; 
            __context__.SourceCodeLine = 232;
            STEMP  .UpdateValue ( Functions.Remove ( "," , STEMPKEYS )  ) ; 
            __context__.SourceCodeLine = 233;
            SKEYS [ I ]  .UpdateValue ( ST . StringTrim (  Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) )  .ToSimplSharpString() )  ) ; 
            __context__.SourceCodeLine = 229;
            } 
        
        __context__.SourceCodeLine = 236;
        STEMPKEYS  .UpdateValue ( ST . StringTrim (  STEMPKEYS  .ToSimplSharpString() )  ) ; 
        __context__.SourceCodeLine = 237;
        INUMOFKEYS = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 239;
        ITCPCONNECTED = (ushort) ( TCP_IS_CONNECTED  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.ICHANGED  = new ushort[ 251 ];
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
    INITIALIZED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( INITIALIZED_OnRelease_1, false ) );
    TCP_IS_CONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( TCP_IS_CONNECTED_OnPush_2, false ) );
    TCP_IS_CONNECTED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TCP_IS_CONNECTED_OnRelease_3, false ) );
    MANUAL_UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MANUAL_UPDATE_OnPush_4, false ) );
    for( uint i = 0; i < 250; i++ )
        IN__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( IN__DOLLAR___OnChange_5, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ST  = new L3_Tools.StringTools();
    
    
}

public UserModuleClass_L3_DATA_TIMEDSTEPPER_250X75_V1_0_03_HSIB ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
            public ushort [] ICHANGED;
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
