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

namespace UserModule_L3_UA_HSIB_GLOBALDPLY_V1_0_00
{
    public class UserModuleClass_L3_UA_HSIB_GLOBALDPLY_V1_0_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PRESS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DATAIN__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AOUT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DATAOUT__DOLLAR__;
        CrestronString STRASH;
        private void FSET (  SplusExecutionContext __context__, ushort IINDEX , ushort IVAL ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 25;
            J = (ushort) ( ((IINDEX - 1) * 3) ) ; 
            __context__.SourceCodeLine = 26;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)3; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 28;
                FB [ (J + I)]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 26;
                } 
            
            __context__.SourceCodeLine = 30;
            FB [ (J + IVAL)]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        object PRESS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                ushort IDPLYINDEX = 0;
                
                
                __context__.SourceCodeLine = 40;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 42;
                IDPLYINDEX = (ushort) ( ((I + 2) / 3) ) ; 
                __context__.SourceCodeLine = 43;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)Mod( (I + 3) , 3 ));
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 47;
                            FSET (  __context__ , (ushort)( IDPLYINDEX ), (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 48;
                            AOUT [ IDPLYINDEX]  .Value = (ushort) ( 11 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 52;
                            FSET (  __context__ , (ushort)( IDPLYINDEX ), (ushort)( 2 )) ; 
                            __context__.SourceCodeLine = 53;
                            AOUT [ IDPLYINDEX]  .Value = (ushort) ( 10 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 58;
                            AOUT [ IDPLYINDEX]  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DATAIN__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 69;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 70;
            J = (ushort) ( ((I * 3) - 3) ) ; 
            __context__.SourceCodeLine = 71;
            MakeString ( STEMP , "{0:d3}.", (ushort)I) ; 
            __context__.SourceCodeLine = 72;
            DATAOUT__DOLLAR__ [ (J + 1)]  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 73;
            DATAOUT__DOLLAR__ [ (J + 3)]  .UpdateValue ( DATAIN__DOLLAR__ [ I ]  ) ; 
            __context__.SourceCodeLine = 75;
            STEMP  .UpdateValue ( DATAIN__DOLLAR__ [ I ]  ) ; 
            __context__.SourceCodeLine = 76;
            STRASH  .UpdateValue ( Functions.Remove ( "name=" , STEMP )  ) ; 
            __context__.SourceCodeLine = 77;
            DATAOUT__DOLLAR__ [ (J + 2)]  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "~" , STEMP ) - 1) ) )  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    
    PRESS = new InOutArray<DigitalInput>( 600, this );
    for( uint i = 0; i < 600; i++ )
    {
        PRESS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PRESS__DigitalInput__ + i, PRESS__DigitalInput__, this );
        m_DigitalInputList.Add( PRESS__DigitalInput__ + i, PRESS[i+1] );
    }
    
    FB = new InOutArray<DigitalOutput>( 600, this );
    for( uint i = 0; i < 600; i++ )
    {
        FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FB__DigitalOutput__ + i, FB[i+1] );
    }
    
    AOUT = new InOutArray<AnalogOutput>( 200, this );
    for( uint i = 0; i < 200; i++ )
    {
        AOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AOUT__AnalogSerialOutput__ + i, AOUT[i+1] );
    }
    
    DATAIN__DOLLAR__ = new InOutArray<StringInput>( 200, this );
    for( uint i = 0; i < 200; i++ )
    {
        DATAIN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( DATAIN__DOLLAR____AnalogSerialInput__ + i, DATAIN__DOLLAR____AnalogSerialInput__, 200, this );
        m_StringInputList.Add( DATAIN__DOLLAR____AnalogSerialInput__ + i, DATAIN__DOLLAR__[i+1] );
    }
    
    DATAOUT__DOLLAR__ = new InOutArray<StringOutput>( 600, this );
    for( uint i = 0; i < 600; i++ )
    {
        DATAOUT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DATAOUT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DATAOUT__DOLLAR____AnalogSerialOutput__ + i, DATAOUT__DOLLAR__[i+1] );
    }
    
    
    for( uint i = 0; i < 600; i++ )
        PRESS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESS_OnPush_0, false ) );
        
    for( uint i = 0; i < 200; i++ )
        DATAIN__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAIN__DOLLAR___OnChange_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_UA_HSIB_GLOBALDPLY_V1_0_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PRESS__DigitalInput__ = 0;
const uint DATAIN__DOLLAR____AnalogSerialInput__ = 0;
const uint FB__DigitalOutput__ = 0;
const uint AOUT__AnalogSerialOutput__ = 0;
const uint DATAOUT__DOLLAR____AnalogSerialOutput__ = 200;

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
