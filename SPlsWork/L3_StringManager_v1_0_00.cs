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

namespace UserModule_L3_STRINGMANAGER_V1_0_00
{
    public class UserModuleClass_L3_STRINGMANAGER_V1_0_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.DigitalInput BACKSPACE;
        Crestron.Logos.SplusObjects.DigitalInput USE_FILTER;
        Crestron.Logos.SplusObjects.StringInput IN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OUT__DOLLAR__;
        StringParameter FILTER_CHARS;
        CrestronString SDATA;
        CrestronString SFILTERCHARS;
        private CrestronString FFILTER (  SplusExecutionContext __context__, CrestronString SSRCIN ) 
            { 
            ushort I = 0;
            
            CrestronString SSRC;
            CrestronString STEMP;
            CrestronString STEMPCHR;
            SSRC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPCHR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 36;
            SSRC  .UpdateValue ( SSRCIN  ) ; 
            __context__.SourceCodeLine = 38;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SSRC ) ))  ) ) 
                {
                __context__.SourceCodeLine = 38;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 40;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( SFILTERCHARS ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 42;
                STEMPCHR  .UpdateValue ( Functions.Chr (  (int) ( Byte( SFILTERCHARS , (int)( I ) ) ) )  ) ; 
                __context__.SourceCodeLine = 44;
                while ( Functions.TestForTrue  ( ( Functions.Find( STEMPCHR , SSRC ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 46;
                    STEMP  .UpdateValue ( Functions.Remove ( STEMPCHR , SSRC )  ) ; 
                    __context__.SourceCodeLine = 47;
                    STEMP  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 48;
                    SSRC  .UpdateValue ( STEMP + SSRC  ) ; 
                    __context__.SourceCodeLine = 44;
                    } 
                
                __context__.SourceCodeLine = 40;
                } 
            
            __context__.SourceCodeLine = 51;
            return ( SSRC ) ; 
            
            }
            
        object IN__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 56;
                SDATA  .UpdateValue ( IN__DOLLAR__  ) ; 
                __context__.SourceCodeLine = 58;
                if ( Functions.TestForTrue  ( ( USE_FILTER  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 59;
                    SDATA  .UpdateValue ( FFILTER (  __context__ , SDATA)  ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object USE_FILTER_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 64;
            SDATA  .UpdateValue ( FFILTER (  __context__ , SDATA)  ) ; 
            __context__.SourceCodeLine = 65;
            OUT__DOLLAR__  .UpdateValue ( SDATA  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CLEAR_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 70;
        SDATA  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 71;
        OUT__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKSPACE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 76;
        SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 77;
        OUT__DOLLAR__  .UpdateValue ( SDATA  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 85;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 86;
        SFILTERCHARS  .UpdateValue ( FILTER_CHARS  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    SFILTERCHARS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    BACKSPACE = new Crestron.Logos.SplusObjects.DigitalInput( BACKSPACE__DigitalInput__, this );
    m_DigitalInputList.Add( BACKSPACE__DigitalInput__, BACKSPACE );
    
    USE_FILTER = new Crestron.Logos.SplusObjects.DigitalInput( USE_FILTER__DigitalInput__, this );
    m_DigitalInputList.Add( USE_FILTER__DigitalInput__, USE_FILTER );
    
    IN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( IN__DOLLAR____AnalogSerialInput__, 1000, this );
    m_StringInputList.Add( IN__DOLLAR____AnalogSerialInput__, IN__DOLLAR__ );
    
    OUT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( OUT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( OUT__DOLLAR____AnalogSerialOutput__, OUT__DOLLAR__ );
    
    FILTER_CHARS = new StringParameter( FILTER_CHARS__Parameter__, this );
    m_ParameterList.Add( FILTER_CHARS__Parameter__, FILTER_CHARS );
    
    
    IN__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( IN__DOLLAR___OnChange_0, false ) );
    USE_FILTER.OnDigitalPush.Add( new InputChangeHandlerWrapper( USE_FILTER_OnPush_1, false ) );
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_2, false ) );
    BACKSPACE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACKSPACE_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_STRINGMANAGER_V1_0_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CLEAR__DigitalInput__ = 0;
const uint BACKSPACE__DigitalInput__ = 1;
const uint USE_FILTER__DigitalInput__ = 2;
const uint IN__DOLLAR____AnalogSerialInput__ = 0;
const uint OUT__DOLLAR____AnalogSerialOutput__ = 0;
const uint FILTER_CHARS__Parameter__ = 10;

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
