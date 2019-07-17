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

namespace UserModule_TCP_NOKEEPALIVE_V1_0
{
    public class UserModuleClass_TCP_NOKEEPALIVE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECTFB;
        Crestron.Logos.SplusObjects.DigitalInput REMOVEDEL;
        Crestron.Logos.SplusObjects.DigitalOutput CONNECT;
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        UShortParameter CMDDELAY;
        StringParameter DELIMITER;
        CrestronString SDATA;
        ushort ISEM = 0;
        ushort ICOUNT = 0;
        private void FSEND (  SplusExecutionContext __context__ ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 27;
            ISEM = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 29;
            if ( Functions.TestForTrue  ( ( Functions.Not( CONNECTFB  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 31;
                CONNECT  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 34;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( CONNECTFB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( I < 50 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 36;
                Functions.Delay (  (int) ( 5 ) ) ; 
                __context__.SourceCodeLine = 37;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 34;
                } 
            
            __context__.SourceCodeLine = 40;
            if ( Functions.TestForTrue  ( ( CONNECTFB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 42;
                STEMP  .UpdateValue ( Functions.Remove ( DELIMITER , SDATA )  ) ; 
                __context__.SourceCodeLine = 43;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 45;
                    TX__DOLLAR__  .UpdateValue ( STEMP  ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 49;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 50))  ) ) 
                    { 
                    __context__.SourceCodeLine = 51;
                    Trace( "deleted buffer from FUNCTION, {0}", SDATA ) ; 
                    __context__.SourceCodeLine = 53;
                    SDATA  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 54;
                    RX__DOLLAR__  .UpdateValue ( ""  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 57;
            ISEM = (ushort) ( 0 ) ; 
            
            }
            
        object RX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort K = 0;
                
                
                __context__.SourceCodeLine = 64;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISEM == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 66;
                    ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOUNT == 5))  ) ) 
                    { 
                    __context__.SourceCodeLine = 70;
                    ISEM = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 71;
                    ICOUNT = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 73;
                    Trace( "deleted buffer from CHANGE statement, {0}", SDATA ) ; 
                    __context__.SourceCodeLine = 74;
                    SDATA  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 76;
                SDATA  .UpdateValue ( SDATA + Functions.Gather ( DELIMITER , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 78;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( SDATA ) ) && Functions.TestForTrue ( Functions.BoolToInt ( K < 5 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 81;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISEM == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 83;
                        FSEND (  __context__  ) ; 
                        __context__.SourceCodeLine = 84;
                        K = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 87;
                    Functions.Delay (  (int) ( CMDDELAY  .Value ) ) ; 
                    __context__.SourceCodeLine = 89;
                    K = (ushort) ( (K + 1) ) ; 
                    __context__.SourceCodeLine = 91;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (K == 5))  ) ) 
                        { 
                        __context__.SourceCodeLine = 93;
                        Trace( "deleted buffer from CHANGE, while statement, {0}", SDATA ) ; 
                        __context__.SourceCodeLine = 95;
                        SDATA  .UpdateValue ( ""  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 78;
                    } 
                
                __context__.SourceCodeLine = 99;
                Functions.Delay (  (int) ( 20 ) ) ; 
                __context__.SourceCodeLine = 100;
                CONNECT  .Value = (ushort) ( 0 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10000, this );
        
        CONNECTFB = new Crestron.Logos.SplusObjects.DigitalInput( CONNECTFB__DigitalInput__, this );
        m_DigitalInputList.Add( CONNECTFB__DigitalInput__, CONNECTFB );
        
        REMOVEDEL = new Crestron.Logos.SplusObjects.DigitalInput( REMOVEDEL__DigitalInput__, this );
        m_DigitalInputList.Add( REMOVEDEL__DigitalInput__, REMOVEDEL );
        
        CONNECT = new Crestron.Logos.SplusObjects.DigitalOutput( CONNECT__DigitalOutput__, this );
        m_DigitalOutputList.Add( CONNECT__DigitalOutput__, CONNECT );
        
        RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 1000, this );
        m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
        
        TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
        
        CMDDELAY = new UShortParameter( CMDDELAY__Parameter__, this );
        m_ParameterList.Add( CMDDELAY__Parameter__, CMDDELAY );
        
        DELIMITER = new StringParameter( DELIMITER__Parameter__, this );
        m_ParameterList.Add( DELIMITER__Parameter__, DELIMITER );
        
        
        RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TCP_NOKEEPALIVE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CONNECTFB__DigitalInput__ = 0;
    const uint REMOVEDEL__DigitalInput__ = 1;
    const uint CONNECT__DigitalOutput__ = 0;
    const uint RX__DOLLAR____AnalogSerialInput__ = 0;
    const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
    const uint CMDDELAY__Parameter__ = 10;
    const uint DELIMITER__Parameter__ = 11;
    
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
