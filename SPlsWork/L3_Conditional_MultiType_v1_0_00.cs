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

namespace UserModule_L3_CONDITIONAL_MULTITYPE_V1_0_00
{
    public class UserModuleClass_L3_CONDITIONAL_MULTITYPE_V1_0_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput PULSE_DIGITAL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CONDITION;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DIGITAL_IN;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> ANALOG_IN;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> STRING_IN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITAL_OUT_TRUE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITAL_OUT_FALSE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> ANALOG_OUT_TRUE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> ANALOG_OUT_FALSE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> STRING_OUT_TRUE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> STRING_OUT_FALSE;
        UShortParameter PULSE_WIDTH;
        object DIGITAL_IN_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 50;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 51;
                if ( Functions.TestForTrue  ( ( CONDITION[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 53;
                    if ( Functions.TestForTrue  ( ( PULSE_DIGITAL  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 53;
                        Functions.Pulse ( PULSE_WIDTH  .Value, DIGITAL_OUT_TRUE [ I] ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 54;
                        DIGITAL_OUT_TRUE [ I]  .Value = (ushort) ( 1 ) ; 
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 58;
                    if ( Functions.TestForTrue  ( ( PULSE_DIGITAL  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 58;
                        Functions.Pulse ( PULSE_WIDTH  .Value, DIGITAL_OUT_FALSE [ I] ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 59;
                        DIGITAL_OUT_FALSE [ I]  .Value = (ushort) ( 1 ) ; 
                        }
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIGITAL_IN_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 66;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 68;
            if ( Functions.TestForTrue  ( ( Functions.Not( PULSE_DIGITAL  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 70;
                if ( Functions.TestForTrue  ( ( CONDITION[ I ] .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 71;
                    DIGITAL_OUT_TRUE [ I]  .Value = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 73;
                    DIGITAL_OUT_FALSE [ I]  .Value = (ushort) ( 0 ) ; 
                    }
                
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ANALOG_IN_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 81;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 82;
        if ( Functions.TestForTrue  ( ( CONDITION[ I ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 83;
            ANALOG_OUT_TRUE [ I]  .Value = (ushort) ( ANALOG_IN[ I ] .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 85;
            ANALOG_OUT_FALSE [ I]  .Value = (ushort) ( ANALOG_IN[ I ] .UshortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STRING_IN_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 91;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 92;
        if ( Functions.TestForTrue  ( ( CONDITION[ I ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 93;
            STRING_OUT_TRUE [ I]  .UpdateValue ( STRING_IN [ I ]  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 95;
            STRING_OUT_FALSE [ I]  .UpdateValue ( STRING_IN [ I ]  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    PULSE_DIGITAL = new Crestron.Logos.SplusObjects.DigitalInput( PULSE_DIGITAL__DigitalInput__, this );
    m_DigitalInputList.Add( PULSE_DIGITAL__DigitalInput__, PULSE_DIGITAL );
    
    CONDITION = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        CONDITION[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CONDITION__DigitalInput__ + i, CONDITION__DigitalInput__, this );
        m_DigitalInputList.Add( CONDITION__DigitalInput__ + i, CONDITION[i+1] );
    }
    
    DIGITAL_IN = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        DIGITAL_IN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DIGITAL_IN__DigitalInput__ + i, DIGITAL_IN__DigitalInput__, this );
        m_DigitalInputList.Add( DIGITAL_IN__DigitalInput__ + i, DIGITAL_IN[i+1] );
    }
    
    DIGITAL_OUT_TRUE = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        DIGITAL_OUT_TRUE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITAL_OUT_TRUE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITAL_OUT_TRUE__DigitalOutput__ + i, DIGITAL_OUT_TRUE[i+1] );
    }
    
    DIGITAL_OUT_FALSE = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        DIGITAL_OUT_FALSE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITAL_OUT_FALSE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITAL_OUT_FALSE__DigitalOutput__ + i, DIGITAL_OUT_FALSE[i+1] );
    }
    
    ANALOG_IN = new InOutArray<AnalogInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        ANALOG_IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( ANALOG_IN__AnalogSerialInput__ + i, ANALOG_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( ANALOG_IN__AnalogSerialInput__ + i, ANALOG_IN[i+1] );
    }
    
    ANALOG_OUT_TRUE = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        ANALOG_OUT_TRUE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( ANALOG_OUT_TRUE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( ANALOG_OUT_TRUE__AnalogSerialOutput__ + i, ANALOG_OUT_TRUE[i+1] );
    }
    
    ANALOG_OUT_FALSE = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        ANALOG_OUT_FALSE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( ANALOG_OUT_FALSE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( ANALOG_OUT_FALSE__AnalogSerialOutput__ + i, ANALOG_OUT_FALSE[i+1] );
    }
    
    STRING_IN = new InOutArray<StringInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        STRING_IN[i+1] = new Crestron.Logos.SplusObjects.StringInput( STRING_IN__AnalogSerialInput__ + i, STRING_IN__AnalogSerialInput__, 1000, this );
        m_StringInputList.Add( STRING_IN__AnalogSerialInput__ + i, STRING_IN[i+1] );
    }
    
    STRING_OUT_TRUE = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        STRING_OUT_TRUE[i+1] = new Crestron.Logos.SplusObjects.StringOutput( STRING_OUT_TRUE__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( STRING_OUT_TRUE__AnalogSerialOutput__ + i, STRING_OUT_TRUE[i+1] );
    }
    
    STRING_OUT_FALSE = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        STRING_OUT_FALSE[i+1] = new Crestron.Logos.SplusObjects.StringOutput( STRING_OUT_FALSE__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( STRING_OUT_FALSE__AnalogSerialOutput__ + i, STRING_OUT_FALSE[i+1] );
    }
    
    PULSE_WIDTH = new UShortParameter( PULSE_WIDTH__Parameter__, this );
    m_ParameterList.Add( PULSE_WIDTH__Parameter__, PULSE_WIDTH );
    
    
    for( uint i = 0; i < 3; i++ )
        DIGITAL_IN[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGITAL_IN_OnPush_0, false ) );
        
    for( uint i = 0; i < 3; i++ )
        DIGITAL_IN[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( DIGITAL_IN_OnRelease_1, false ) );
        
    for( uint i = 0; i < 3; i++ )
        ANALOG_IN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( ANALOG_IN_OnChange_2, false ) );
        
    for( uint i = 0; i < 3; i++ )
        STRING_IN[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( STRING_IN_OnChange_3, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_CONDITIONAL_MULTITYPE_V1_0_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PULSE_DIGITAL__DigitalInput__ = 0;
const uint CONDITION__DigitalInput__ = 1;
const uint DIGITAL_IN__DigitalInput__ = 4;
const uint ANALOG_IN__AnalogSerialInput__ = 0;
const uint STRING_IN__AnalogSerialInput__ = 3;
const uint DIGITAL_OUT_TRUE__DigitalOutput__ = 0;
const uint DIGITAL_OUT_FALSE__DigitalOutput__ = 3;
const uint ANALOG_OUT_TRUE__AnalogSerialOutput__ = 0;
const uint ANALOG_OUT_FALSE__AnalogSerialOutput__ = 3;
const uint STRING_OUT_TRUE__AnalogSerialOutput__ = 6;
const uint STRING_OUT_FALSE__AnalogSerialOutput__ = 9;
const uint PULSE_WIDTH__Parameter__ = 10;

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
