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
                Trace( "{0}.{1:d3}  ______DataInit: Start_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds()) ; 
                __context__.SourceCodeLine = 67;
                ISTOPSEM = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 68;
                ISTARTSEM = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 69;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 70;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINDEX == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 70;
                    IINDEX = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 71;
                Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 73;
                if ( Functions.TestForTrue  ( ( Functions.Not( IINITIALIZED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 76;
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
                
                __context__.SourceCodeLine = 83;
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
            
            __context__.SourceCodeLine = 88;
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
        
        __context__.SourceCodeLine = 94;
        if ( Functions.TestForTrue  ( ( Functions.Not( DISABLE  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 96;
            DONE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 97;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 99;
            IINDEX = (ushort) ( (Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) + 1) ) ; 
            __context__.SourceCodeLine = 102;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= HIGHEST_INDEX_USED  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 104;
                if ( Functions.TestForTrue  ( ( Functions.Not( ISTOPSEM ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 106;
                    Functions.Delay (  (int) ( DELAY_TIME  .Value ) ) ; 
                    __context__.SourceCodeLine = 107;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 108;
                    Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 112;
                    Trace( "{0}.{1:d3}  ______DataInit: Stopped_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds()) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 118;
                Trace( "{0}.{1:d3}  ______DataInit: Complete_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds()) ; 
                __context__.SourceCodeLine = 119;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 120;
                DONE_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 121;
                ISTOPSEM = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 122;
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
        
        __context__.SourceCodeLine = 131;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 133;
        IINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 135;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_100__" , DELAY_TIME  .Value , __SPLS_TMPVAR__WAITLABEL_100___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_100___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 137;
            IINITIALIZED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 138;
            if ( Functions.TestForTrue  ( ( ISTARTSEM)  ) ) 
                { 
                __context__.SourceCodeLine = 140;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 141;
                Functions.Pulse ( 10, TRIG [ IINDEX] ) ; 
                __context__.SourceCodeLine = 142;
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
    
    DONE = new InOutArray<DigitalInput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        DONE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DONE__DigitalInput__ + i, DONE__DigitalInput__, this );
        m_DigitalInputList.Add( DONE__DigitalInput__ + i, DONE[i+1] );
    }
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DONE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_FB__DigitalOutput__, DONE_FB );
    
    TRIG = new InOutArray<DigitalOutput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        TRIG[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( TRIG__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( TRIG__DigitalOutput__ + i, TRIG[i+1] );
    }
    
    HIGHEST_INDEX_USED = new UShortParameter( HIGHEST_INDEX_USED__Parameter__, this );
    m_ParameterList.Add( HIGHEST_INDEX_USED__Parameter__, HIGHEST_INDEX_USED );
    
    DELAY_TIME = new UShortParameter( DELAY_TIME__Parameter__, this );
    m_ParameterList.Add( DELAY_TIME__Parameter__, DELAY_TIME );
    
    __SPLS_TMPVAR__WAITLABEL_100___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_100___CallbackFn );
    
    START.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_OnPush_0, false ) );
    STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_OnPush_1, false ) );
    for( uint i = 0; i < 20; i++ )
        DONE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DONE_OnPush_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_DATA_INIT_DRIVER_V1_0_01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_100___Callback;


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
