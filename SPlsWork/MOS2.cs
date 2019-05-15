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

namespace UserModule_MOS2
{
    public class UserModuleClass_MOS2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TRIG;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OUT;
        InOutArray<UShortParameter> PULSELEN;
        object TRIG_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 18;
                Functions.Pulse ( PULSELEN[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .Value, OUT [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )] ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        TRIG = new InOutArray<DigitalInput>( 45, this );
        for( uint i = 0; i < 45; i++ )
        {
            TRIG[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TRIG__DigitalInput__ + i, TRIG__DigitalInput__, this );
            m_DigitalInputList.Add( TRIG__DigitalInput__ + i, TRIG[i+1] );
        }
        
        OUT = new InOutArray<DigitalOutput>( 45, this );
        for( uint i = 0; i < 45; i++ )
        {
            OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OUT__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( OUT__DigitalOutput__ + i, OUT[i+1] );
        }
        
        PULSELEN = new InOutArray<UShortParameter>( 45, this );
        for( uint i = 0; i < 45; i++ )
        {
            PULSELEN[i+1] = new UShortParameter( PULSELEN__Parameter__ + i, PULSELEN__Parameter__, this );
            m_ParameterList.Add( PULSELEN__Parameter__ + i, PULSELEN[i+1] );
        }
        
        
        for( uint i = 0; i < 45; i++ )
            TRIG[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TRIG_OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_MOS2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TRIG__DigitalInput__ = 0;
    const uint OUT__DigitalOutput__ = 0;
    const uint PULSELEN__Parameter__ = 10;
    
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
