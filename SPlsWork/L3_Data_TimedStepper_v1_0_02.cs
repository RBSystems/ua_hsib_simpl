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

namespace UserModule_L3_DATA_TIMEDSTEPPER_V1_0_02
{
    public class UserModuleClass_L3_DATA_TIMEDSTEPPER_V1_0_02 : SplusObject
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
        ushort INEWCHANGEDURINGLOOP = 0;
        ushort IINITIALIZED = 0;
        ushort ILOOPRUNNING = 0;
        ushort [] ICHANGED;
        CrestronString [] SDATA;
        private void FSEND (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 49;
            OUT__DOLLAR__ [ I]  .UpdateValue ( SDATA [ I ]  ) ; 
            __context__.SourceCodeLine = 50;
            ICHANGED [ I] = (ushort) ( 0 ) ; 
            
            }
            
        private void FRUNLOOPWORK (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 57;
            ILOOPRUNNING = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 58;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)HIGHEST_INDEX  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 60;
                if ( Functions.TestForTrue  ( ( Functions.Not( TCP_IS_CONNECTED  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 62;
                    ILOOPRUNNING = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 63;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 65;
                if ( Functions.TestForTrue  ( ( ICHANGED[ I ])  ) ) 
                    { 
                    __context__.SourceCodeLine = 67;
                    FSEND (  __context__ , (ushort)( I )) ; 
                    __context__.SourceCodeLine = 68;
                    Functions.Delay (  (int) ( STEP_TIME  .Value ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 58;
                } 
            
            __context__.SourceCodeLine = 71;
            ILOOPRUNNING = (ushort) ( 0 ) ; 
            
            }
            
        private void FRUNLOOP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 76;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( TCP_IS_CONNECTED  .Value ) && Functions.TestForTrue ( Functions.Not( ILOOPRUNNING ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 78;
                FRUNLOOPWORK (  __context__  ) ; 
                __context__.SourceCodeLine = 80;
                while ( Functions.TestForTrue  ( ( INEWCHANGEDURINGLOOP)  ) ) 
                    { 
                    __context__.SourceCodeLine = 82;
                    INEWCHANGEDURINGLOOP = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 83;
                    if ( Functions.TestForTrue  ( ( TCP_IS_CONNECTED  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 83;
                        FRUNLOOPWORK (  __context__  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 80;
                    } 
                
                } 
            
            
            }
            
        object INITIALIZED_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 90;
                IINITIALIZED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 91;
                INITIALIZED_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 92;
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
            
            __context__.SourceCodeLine = 97;
            if ( Functions.TestForTrue  ( ( IINITIALIZED)  ) ) 
                {
                __context__.SourceCodeLine = 97;
                FRUNLOOP (  __context__  ) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object MANUAL_UPDATE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 102;
        FRUNLOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IN__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 109;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 111;
        ICHANGED [ I] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 112;
        SDATA [ I ]  .UpdateValue ( IN__DOLLAR__ [ I ]  ) ; 
        __context__.SourceCodeLine = 114;
        if ( Functions.TestForTrue  ( ( Functions.Not( ILOOPRUNNING ))  ) ) 
            {
            __context__.SourceCodeLine = 114;
            FSEND (  __context__ , (ushort)( I )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 117;
            INEWCHANGEDURINGLOOP = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    ICHANGED  = new ushort[ 711 ];
    SDATA  = new CrestronString[ 711 ];
    for( uint i = 0; i < 711; i++ )
        SDATA [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    
    INITIALIZED = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZED__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZED__DigitalInput__, INITIALIZED );
    
    TCP_IS_CONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( TCP_IS_CONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( TCP_IS_CONNECTED__DigitalInput__, TCP_IS_CONNECTED );
    
    MANUAL_UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( MANUAL_UPDATE__DigitalInput__, this );
    m_DigitalInputList.Add( MANUAL_UPDATE__DigitalInput__, MANUAL_UPDATE );
    
    INITIALIZED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZED_FB__DigitalOutput__, INITIALIZED_FB );
    
    IN__DOLLAR__ = new InOutArray<StringInput>( 710, this );
    for( uint i = 0; i < 710; i++ )
    {
        IN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR____AnalogSerialInput__, 300, this );
        m_StringInputList.Add( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR__[i+1] );
    }
    
    OUT__DOLLAR__ = new InOutArray<StringOutput>( 710, this );
    for( uint i = 0; i < 710; i++ )
    {
        OUT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( OUT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( OUT__DOLLAR____AnalogSerialOutput__ + i, OUT__DOLLAR__[i+1] );
    }
    
    STEP_TIME = new UShortParameter( STEP_TIME__Parameter__, this );
    m_ParameterList.Add( STEP_TIME__Parameter__, STEP_TIME );
    
    HIGHEST_INDEX = new UShortParameter( HIGHEST_INDEX__Parameter__, this );
    m_ParameterList.Add( HIGHEST_INDEX__Parameter__, HIGHEST_INDEX );
    
    
    INITIALIZED.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZED_OnPush_0, false ) );
    TCP_IS_CONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( TCP_IS_CONNECTED_OnPush_1, false ) );
    MANUAL_UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MANUAL_UPDATE_OnPush_2, false ) );
    for( uint i = 0; i < 710; i++ )
        IN__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( IN__DOLLAR___OnChange_3, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_DATA_TIMEDSTEPPER_V1_0_02 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZED__DigitalInput__ = 0;
const uint TCP_IS_CONNECTED__DigitalInput__ = 1;
const uint MANUAL_UPDATE__DigitalInput__ = 2;
const uint IN__DOLLAR____AnalogSerialInput__ = 0;
const uint INITIALIZED_FB__DigitalOutput__ = 0;
const uint OUT__DOLLAR____AnalogSerialOutput__ = 0;
const uint STEP_TIME__Parameter__ = 10;
const uint HIGHEST_INDEX__Parameter__ = 11;

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


}
