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

namespace UserModule_TOGGLE2_
{
    public class UserModuleClass_TOGGLE2_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CLOCK;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RESET;
        Crestron.Logos.SplusObjects.DigitalOutput OUT;
        Crestron.Logos.SplusObjects.DigitalOutput __DOLLAR__OUT;
        Crestron.Logos.SplusObjects.DigitalOutput OUT_PULSE;
        Crestron.Logos.SplusObjects.DigitalOutput __DOLLAR__OUT_PULSE;
        UShortParameter TIME_IN_TICKS;
        ushort S = 0;
        ushort T = 0;
        object SET_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 36;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (S == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 38;
                    OUT_PULSE  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 39;
                    __DOLLAR__OUT_PULSE  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 41;
                    __DOLLAR__OUT  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 42;
                    OUT  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 43;
                    Functions.Pulse ( T, OUT_PULSE ) ; 
                    __context__.SourceCodeLine = 45;
                    S = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RESET_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 51;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (S == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 53;
                OUT_PULSE  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 54;
                __DOLLAR__OUT_PULSE  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 56;
                OUT  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 57;
                __DOLLAR__OUT  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 58;
                Functions.Pulse ( T, __DOLLAR__OUT_PULSE ) ; 
                __context__.SourceCodeLine = 60;
                S = (ushort) ( 0 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CLOCK_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 66;
        OUT_PULSE  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 67;
        __DOLLAR__OUT_PULSE  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 69;
        if ( Functions.TestForTrue  ( ( S)  ) ) 
            { 
            __context__.SourceCodeLine = 71;
            OUT  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 72;
            __DOLLAR__OUT  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 73;
            Functions.Pulse ( T, __DOLLAR__OUT_PULSE ) ; 
            __context__.SourceCodeLine = 74;
            S = (ushort) ( 0 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 76;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (S == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 78;
                __DOLLAR__OUT  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 79;
                OUT  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 80;
                Functions.Pulse ( T, OUT_PULSE ) ; 
                __context__.SourceCodeLine = 81;
                S = (ushort) ( 1 ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 87;
        T = (ushort) ( TIME_IN_TICKS  .Value ) ; 
        __context__.SourceCodeLine = 88;
        __DOLLAR__OUT  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 89;
        S = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    CLOCK = new Crestron.Logos.SplusObjects.DigitalInput( CLOCK__DigitalInput__, this );
    m_DigitalInputList.Add( CLOCK__DigitalInput__, CLOCK );
    
    SET = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SET[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET__DigitalInput__ + i, SET__DigitalInput__, this );
        m_DigitalInputList.Add( SET__DigitalInput__ + i, SET[i+1] );
    }
    
    RESET = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        RESET[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RESET__DigitalInput__ + i, RESET__DigitalInput__, this );
        m_DigitalInputList.Add( RESET__DigitalInput__ + i, RESET[i+1] );
    }
    
    OUT = new Crestron.Logos.SplusObjects.DigitalOutput( OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT__DigitalOutput__, OUT );
    
    __DOLLAR__OUT = new Crestron.Logos.SplusObjects.DigitalOutput( __DOLLAR__OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( __DOLLAR__OUT__DigitalOutput__, __DOLLAR__OUT );
    
    OUT_PULSE = new Crestron.Logos.SplusObjects.DigitalOutput( OUT_PULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT_PULSE__DigitalOutput__, OUT_PULSE );
    
    __DOLLAR__OUT_PULSE = new Crestron.Logos.SplusObjects.DigitalOutput( __DOLLAR__OUT_PULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( __DOLLAR__OUT_PULSE__DigitalOutput__, __DOLLAR__OUT_PULSE );
    
    TIME_IN_TICKS = new UShortParameter( TIME_IN_TICKS__Parameter__, this );
    m_ParameterList.Add( TIME_IN_TICKS__Parameter__, TIME_IN_TICKS );
    
    
    for( uint i = 0; i < 3; i++ )
        SET[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_OnPush_0, false ) );
        
    for( uint i = 0; i < 3; i++ )
        RESET[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RESET_OnPush_1, false ) );
        
    CLOCK.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLOCK_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TOGGLE2_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CLOCK__DigitalInput__ = 0;
const uint SET__DigitalInput__ = 1;
const uint RESET__DigitalInput__ = 4;
const uint OUT__DigitalOutput__ = 0;
const uint __DOLLAR__OUT__DigitalOutput__ = 1;
const uint OUT_PULSE__DigitalOutput__ = 2;
const uint __DOLLAR__OUT_PULSE__DigitalOutput__ = 3;
const uint TIME_IN_TICKS__Parameter__ = 10;

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
