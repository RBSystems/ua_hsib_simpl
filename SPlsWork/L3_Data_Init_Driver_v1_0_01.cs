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

namespace UserModule_L3_DATA_INIT_DRIVER_V1_0_01
{
    public class UserModuleClass_L3_DATA_INIT_DRIVER_V1_0_01 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DISABLE;
        Crestron.Logos.SplusObjects.DigitalInput START;
        Crestron.Logos.SplusObjects.DigitalInput STOP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DONE;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> TRIG;
        UShortParameter HIGHEST_INDEX_USED;
        UShortParameter DELAY_TIME;
        ushort IINDEX = 0;
        ushort ISTOPSEM = 0;
        ushort ISTARTSEM = 0;
        ushort IINITIALIZED = 0;
        private void FSTART (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 63;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINITIALIZED ) && Functions.TestForTrue ( Functions.Not( DISABLE  .Value ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 65;
                ISTOPSEM = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 66;
                ISTARTSEM = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 67;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINDEX == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 68;
                    IINDEX = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 69;
                Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 71;
                if ( Functions.TestForTrue  ( ( Functions.Not( IINITIALIZED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 73;
                    ISTARTSEM = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            
            }
            
        object START_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 80;
                FSTART (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object STOP_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 85;
            ISTOPSEM = (ushort) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DONE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 91;
        if ( Functions.TestForTrue  ( ( Functions.Not( DISABLE  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 93;
            DONE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 94;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 96;
            IINDEX = (ushort) ( (Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) + 1) ) ; 
            __context__.SourceCodeLine = 99;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= HIGHEST_INDEX_USED  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 101;
                if ( Functions.TestForTrue  ( ( Functions.Not( ISTOPSEM ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 103;
                    Functions.Delay (  (int) ( DELAY_TIME  .Value ) ) ; 
                    __context__.SourceCodeLine = 104;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 105;
                    Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 114;
                Trace( "\\\\______Data Inititialization Complete______//") ; 
                __context__.SourceCodeLine = 115;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 116;
                DONE_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 117;
                ISTOPSEM = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 118;
                IINDEX = (ushort) ( 1 ) ; 
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
        
        __context__.SourceCodeLine = 127;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 129;
        IINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 131;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_0__" , DELAY_TIME  .Value , __SPLS_TMPVAR__WAITLABEL_0___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_0___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 133;
            IINITIALIZED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 134;
            if ( Functions.TestForTrue  ( ( ISTARTSEM)  ) ) 
                { 
                __context__.SourceCodeLine = 136;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 137;
                Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                __context__.SourceCodeLine = 138;
                ISTARTSEM = (ushort) ( 0 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DISABLE = new Crestron.Logos.SplusObjects.DigitalInput( DISABLE__DigitalInput__, this );
    m_DigitalInputList.Add( DISABLE__DigitalInput__, DISABLE );
    
    START = new Crestron.Logos.SplusObjects.DigitalInput( START__DigitalInput__, this );
    m_DigitalInputList.Add( START__DigitalInput__, START );
    
    STOP = new Crestron.Logos.SplusObjects.DigitalInput( STOP__DigitalInput__, this );
    m_DigitalInputList.Add( STOP__DigitalInput__, STOP );
    
    DONE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        DONE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DONE__DigitalInput__ + i, DONE__DigitalInput__, this );
        m_DigitalInputList.Add( DONE__DigitalInput__ + i, DONE[i+1] );
    }
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DONE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_FB__DigitalOutput__, DONE_FB );
    
    TRIG = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TRIG[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( TRIG__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( TRIG__DigitalOutput__ + i, TRIG[i+1] );
    }
    
    HIGHEST_INDEX_USED = new UShortParameter( HIGHEST_INDEX_USED__Parameter__, this );
    m_ParameterList.Add( HIGHEST_INDEX_USED__Parameter__, HIGHEST_INDEX_USED );
    
    DELAY_TIME = new UShortParameter( DELAY_TIME__Parameter__, this );
    m_ParameterList.Add( DELAY_TIME__Parameter__, DELAY_TIME );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    START.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_OnPush_0, false ) );
    STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_OnPush_1, false ) );
    for( uint i = 0; i < 100; i++ )
        DONE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DONE_OnPush_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_DATA_INIT_DRIVER_V1_0_01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint DISABLE__DigitalInput__ = 0;
const uint START__DigitalInput__ = 1;
const uint STOP__DigitalInput__ = 2;
const uint DONE__DigitalInput__ = 3;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DONE_FB__DigitalOutput__ = 1;
const uint TRIG__DigitalOutput__ = 2;
const uint HIGHEST_INDEX_USED__Parameter__ = 10;
const uint DELAY_TIME__Parameter__ = 11;

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
