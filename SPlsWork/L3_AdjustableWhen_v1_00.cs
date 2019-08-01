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

namespace UserModule_L3_ADJUSTABLEWHEN_V1_00
{
    public class UserModuleClass_L3_ADJUSTABLEWHEN_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LATER60;
        Crestron.Logos.SplusObjects.DigitalInput LATER15;
        Crestron.Logos.SplusObjects.DigitalInput EARLIER15;
        Crestron.Logos.SplusObjects.DigitalInput EARLIER60;
        Crestron.Logos.SplusObjects.DigitalInput CANCEL;
        Crestron.Logos.SplusObjects.AnalogInput INHOUR;
        Crestron.Logos.SplusObjects.AnalogInput INMIN;
        Crestron.Logos.SplusObjects.AnalogInput INWARNSECS;
        Crestron.Logos.SplusObjects.StringInput TOD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput WARNING;
        Crestron.Logos.SplusObjects.DigitalOutput TRIGGER;
        Crestron.Logos.SplusObjects.StringOutput TRIGTIME;
        Crestron.Logos.SplusObjects.StringOutput WARNTIME;
        UShortParameter WARNINGTIME;
        short ICANCEL = 0;
        ushort IWARNSECS = 0;
        CrestronString STIME;
        CrestronString SWARN;
        uint LITIMEEPOC = 0;
        uint LIWARNEPOC = 0;
        private void FTIME (  SplusExecutionContext __context__ ) 
            { 
            uint HT = 0;
            uint MT = 0;
            uint ST = 0;
            uint HT12 = 0;
            uint HW = 0;
            uint MW = 0;
            uint SW = 0;
            uint HW12 = 0;
            
            CrestronString AMPMT;
            CrestronString AMPMW;
            AMPMT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            AMPMW  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 66;
            HT = (uint) ( (LITIMEEPOC / 3600) ) ; 
            __context__.SourceCodeLine = 67;
            MT = (uint) ( (Mod( LITIMEEPOC , 3600 ) / 60) ) ; 
            __context__.SourceCodeLine = 68;
            ST = (uint) ( Mod( LITIMEEPOC , 60 ) ) ; 
            __context__.SourceCodeLine = 70;
            MakeString ( STIME , "{0:d2}{1:d2}{2:d2}", (uint)HT, (uint)MT, (uint)ST) ; 
            __context__.SourceCodeLine = 72;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( HT >= 12 ))  ) ) 
                {
                __context__.SourceCodeLine = 72;
                AMPMT  .UpdateValue ( "PM"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 73;
                AMPMT  .UpdateValue ( "AM"  ) ; 
                }
            
            __context__.SourceCodeLine = 75;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (HT == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (HT == 12) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 75;
                HT12 = (uint) ( 12 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 76;
                HT12 = (uint) ( Mod( HT , 12 ) ) ; 
                }
            
            __context__.SourceCodeLine = 77;
            MakeString ( TRIGTIME , "{0:d2}:{1:d2} {2}", (uint)HT12, (uint)MT, AMPMT ) ; 
            __context__.SourceCodeLine = 80;
            HW = (uint) ( (LIWARNEPOC / 3600) ) ; 
            __context__.SourceCodeLine = 81;
            MW = (uint) ( (Mod( LIWARNEPOC , 3600 ) / 60) ) ; 
            __context__.SourceCodeLine = 82;
            SW = (uint) ( Mod( LIWARNEPOC , 60 ) ) ; 
            __context__.SourceCodeLine = 84;
            MakeString ( SWARN , "{0:d2}{1:d2}{2:d2}", (uint)HW, (uint)MW, (uint)SW) ; 
            __context__.SourceCodeLine = 86;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( HW >= 12 ))  ) ) 
                {
                __context__.SourceCodeLine = 86;
                AMPMW  .UpdateValue ( "PM"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 87;
                AMPMW  .UpdateValue ( "AM"  ) ; 
                }
            
            __context__.SourceCodeLine = 89;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (HW == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (HW == 12) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 89;
                HW12 = (uint) ( 12 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 90;
                HW12 = (uint) ( Mod( HW , 12 ) ) ; 
                }
            
            __context__.SourceCodeLine = 91;
            MakeString ( WARNTIME , "{0:d2}:{1:d2} {2}", (uint)HW12, (uint)MW, AMPMW ) ; 
            
            }
            
        object TOD__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                ushort J = 0;
                
                
                __context__.SourceCodeLine = 101;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( SWARN , Functions.Mid( TOD__DOLLAR__ , (int)( 9 ) , (int)( 6 ) ) ) ) && Functions.TestForTrue ( Functions.BoolToInt (ICANCEL == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 103;
                    Functions.Pulse ( 10, WARNING ) ; 
                    } 
                
                __context__.SourceCodeLine = 106;
                if ( Functions.TestForTrue  ( ( Functions.Find( STIME , Functions.Mid( TOD__DOLLAR__ , (int)( 9 ) , (int)( 6 ) ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 108;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICANCEL == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 108;
                        Functions.Pulse ( 10, TRIGGER ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 109;
                        ICANCEL = (short) ( 0 ) ; 
                        }
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CANCEL_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 115;
            ICANCEL = (short) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object LATER60_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 120;
        LITIMEEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) + 3600) , 86400 ) ) ; 
        __context__.SourceCodeLine = 121;
        LIWARNEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - IWARNSECS) , 86400 ) ) ; 
        __context__.SourceCodeLine = 122;
        FTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LATER15_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 127;
        LITIMEEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) + 900) , 86400 ) ) ; 
        __context__.SourceCodeLine = 128;
        LIWARNEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - IWARNSECS) , 86400 ) ) ; 
        __context__.SourceCodeLine = 129;
        FTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EARLIER15_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 135;
        LITIMEEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - 900) , 86400 ) ) ; 
        __context__.SourceCodeLine = 136;
        LIWARNEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - IWARNSECS) , 86400 ) ) ; 
        __context__.SourceCodeLine = 137;
        FTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EARLIER60_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 143;
        LITIMEEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - 3600) , 86400 ) ) ; 
        __context__.SourceCodeLine = 144;
        LIWARNEPOC = (uint) ( Mod( ((LITIMEEPOC + 86400) - IWARNSECS) , 86400 ) ) ; 
        __context__.SourceCodeLine = 145;
        FTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INHOUR_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 150;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INHOUR  .UshortValue >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 152;
            LITIMEEPOC = (uint) ( ((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) ) ; 
            __context__.SourceCodeLine = 153;
            LIWARNEPOC = (uint) ( Mod( ((((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) + 86400) - IWARNSECS) , 86400 ) ) ; 
            __context__.SourceCodeLine = 154;
            FTIME (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INMIN_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 160;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INMIN  .UshortValue >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 162;
            LITIMEEPOC = (uint) ( ((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) ) ; 
            __context__.SourceCodeLine = 163;
            LIWARNEPOC = (uint) ( Mod( ((((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) + 86400) - IWARNSECS) , 86400 ) ) ; 
            __context__.SourceCodeLine = 164;
            FTIME (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INWARNSECS_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 170;
        IWARNSECS = (ushort) ( INWARNSECS  .UshortValue ) ; 
        __context__.SourceCodeLine = 171;
        LIWARNEPOC = (uint) ( Mod( ((((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) + 86400) - IWARNSECS) , 86400 ) ) ; 
        __context__.SourceCodeLine = 172;
        FTIME (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 178;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 180;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INWARNSECS  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 180;
            IWARNSECS = (ushort) ( INWARNSECS  .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 181;
            IWARNSECS = (ushort) ( WARNINGTIME  .Value ) ; 
            }
        
        __context__.SourceCodeLine = 183;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INHOUR  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INMIN  .UshortValue >= 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 185;
            LITIMEEPOC = (uint) ( ((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) ) ; 
            __context__.SourceCodeLine = 186;
            LIWARNEPOC = (uint) ( Mod( ((((Mod( INHOUR  .UintValue , 24 ) * 3600) + (Mod( INMIN  .UintValue , 60 ) * 60)) + 86400) - IWARNSECS) , 86400 ) ) ; 
            __context__.SourceCodeLine = 187;
            FTIME (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SWARN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    LATER60 = new Crestron.Logos.SplusObjects.DigitalInput( LATER60__DigitalInput__, this );
    m_DigitalInputList.Add( LATER60__DigitalInput__, LATER60 );
    
    LATER15 = new Crestron.Logos.SplusObjects.DigitalInput( LATER15__DigitalInput__, this );
    m_DigitalInputList.Add( LATER15__DigitalInput__, LATER15 );
    
    EARLIER15 = new Crestron.Logos.SplusObjects.DigitalInput( EARLIER15__DigitalInput__, this );
    m_DigitalInputList.Add( EARLIER15__DigitalInput__, EARLIER15 );
    
    EARLIER60 = new Crestron.Logos.SplusObjects.DigitalInput( EARLIER60__DigitalInput__, this );
    m_DigitalInputList.Add( EARLIER60__DigitalInput__, EARLIER60 );
    
    CANCEL = new Crestron.Logos.SplusObjects.DigitalInput( CANCEL__DigitalInput__, this );
    m_DigitalInputList.Add( CANCEL__DigitalInput__, CANCEL );
    
    WARNING = new Crestron.Logos.SplusObjects.DigitalOutput( WARNING__DigitalOutput__, this );
    m_DigitalOutputList.Add( WARNING__DigitalOutput__, WARNING );
    
    TRIGGER = new Crestron.Logos.SplusObjects.DigitalOutput( TRIGGER__DigitalOutput__, this );
    m_DigitalOutputList.Add( TRIGGER__DigitalOutput__, TRIGGER );
    
    INHOUR = new Crestron.Logos.SplusObjects.AnalogInput( INHOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( INHOUR__AnalogSerialInput__, INHOUR );
    
    INMIN = new Crestron.Logos.SplusObjects.AnalogInput( INMIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( INMIN__AnalogSerialInput__, INMIN );
    
    INWARNSECS = new Crestron.Logos.SplusObjects.AnalogInput( INWARNSECS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( INWARNSECS__AnalogSerialInput__, INWARNSECS );
    
    TOD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TOD__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TOD__DOLLAR____AnalogSerialInput__, TOD__DOLLAR__ );
    
    TRIGTIME = new Crestron.Logos.SplusObjects.StringOutput( TRIGTIME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TRIGTIME__AnalogSerialOutput__, TRIGTIME );
    
    WARNTIME = new Crestron.Logos.SplusObjects.StringOutput( WARNTIME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( WARNTIME__AnalogSerialOutput__, WARNTIME );
    
    WARNINGTIME = new UShortParameter( WARNINGTIME__Parameter__, this );
    m_ParameterList.Add( WARNINGTIME__Parameter__, WARNINGTIME );
    
    
    TOD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TOD__DOLLAR___OnChange_0, false ) );
    CANCEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( CANCEL_OnPush_1, false ) );
    LATER60.OnDigitalPush.Add( new InputChangeHandlerWrapper( LATER60_OnPush_2, false ) );
    LATER15.OnDigitalPush.Add( new InputChangeHandlerWrapper( LATER15_OnPush_3, false ) );
    EARLIER15.OnDigitalPush.Add( new InputChangeHandlerWrapper( EARLIER15_OnPush_4, false ) );
    EARLIER60.OnDigitalPush.Add( new InputChangeHandlerWrapper( EARLIER60_OnPush_5, false ) );
    INHOUR.OnAnalogChange.Add( new InputChangeHandlerWrapper( INHOUR_OnChange_6, false ) );
    INMIN.OnAnalogChange.Add( new InputChangeHandlerWrapper( INMIN_OnChange_7, false ) );
    INWARNSECS.OnAnalogChange.Add( new InputChangeHandlerWrapper( INWARNSECS_OnChange_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_ADJUSTABLEWHEN_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LATER60__DigitalInput__ = 0;
const uint LATER15__DigitalInput__ = 1;
const uint EARLIER15__DigitalInput__ = 2;
const uint EARLIER60__DigitalInput__ = 3;
const uint CANCEL__DigitalInput__ = 4;
const uint INHOUR__AnalogSerialInput__ = 0;
const uint INMIN__AnalogSerialInput__ = 1;
const uint INWARNSECS__AnalogSerialInput__ = 2;
const uint TOD__DOLLAR____AnalogSerialInput__ = 3;
const uint WARNING__DigitalOutput__ = 0;
const uint TRIGGER__DigitalOutput__ = 1;
const uint TRIGTIME__AnalogSerialOutput__ = 0;
const uint WARNTIME__AnalogSerialOutput__ = 1;
const uint WARNINGTIME__Parameter__ = 10;

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
