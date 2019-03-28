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

namespace CrestronModule_USB_EXT_DM_FUNCTIONS_V1_0
{
    public class CrestronModuleClass_USB_EXT_DM_FUNCTIONS_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DIENABLEUDP;
        Crestron.Logos.SplusObjects.DigitalInput DIGETDEVICES;
        Crestron.Logos.SplusObjects.DigitalInput DIPAIRDEVICES;
        Crestron.Logos.SplusObjects.DigitalInput DIREMOVEPAIRING;
        Crestron.Logos.SplusObjects.DigitalInput DIREMOVEALLPAIRINGS;
        Crestron.Logos.SplusObjects.DigitalInput DIPING;
        Crestron.Logos.SplusObjects.AnalogInput AODEVICENUMBER;
        Crestron.Logos.SplusObjects.StringInput SILOCALDEVICE;
        Crestron.Logos.SplusObjects.StringInput SIREMOTEDEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput DOMODULEREADY;
        Crestron.Logos.SplusObjects.AnalogOutput AOERROR;
        Crestron.Logos.SplusObjects.StringOutput SOUDP_RX;
        Crestron.Logos.SplusObjects.StringOutput SOLOCALDEVICE;
        Crestron.Logos.SplusObjects.StringOutput SOREMOTEDEVICE;
        CrestronString DEBUGSTRING;
        short STATUS = 0;
        uint TRANSACTION = 0;
        ushort ERROR = 0;
        ushort RETRYCOUNT = 0;
        SplusUdpSocket DMUSBUDP;
        private void DEBUGPRINT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 56;
            Print( "\r\nDebug: {0}", DEBUGSTRING ) ; 
            
            }
            
        private void DEBUGPRINTHEX (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 62;
            Print( "len: {0:d} val: ", (short)Functions.Length( MSG )) ; 
            __context__.SourceCodeLine = 63;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( MSG ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 65;
                Print( "{0:x2} ", Byte( MSG , (int)( I ) )) ; 
                __context__.SourceCodeLine = 63;
                } 
            
            
            }
            
        private void SENDCOMMAND (  SplusExecutionContext __context__, CrestronString COMMAND ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            ushort TRANSACTIONHIGH = 0;
            
            ushort TRANSACTIONLOW = 0;
            
            
            __context__.SourceCodeLine = 74;
            TRANSACTION = (uint) ( (TRANSACTION + 1) ) ; 
            __context__.SourceCodeLine = 75;
            TRANSACTIONHIGH = (ushort) ( Functions.HighWord( (uint)( TRANSACTION ) ) ) ; 
            __context__.SourceCodeLine = 76;
            TRANSACTIONLOW = (ushort) ( Functions.LowWord( (uint)( TRANSACTION ) ) ) ; 
            __context__.SourceCodeLine = 78;
            MSG  .UpdateValue ( "\u00A9\u00C4\u00D8\u00F4" + Functions.Chr (  (int) ( Functions.High( (ushort) TRANSACTIONHIGH ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) TRANSACTIONHIGH ) ) ) + Functions.Chr (  (int) ( Functions.High( (ushort) TRANSACTIONLOW ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) TRANSACTIONLOW ) ) ) + COMMAND  ) ; 
            __context__.SourceCodeLine = 83;
            STATUS = (short) ( Functions.SocketSend( DMUSBUDP , MSG ) ) ; 
            __context__.SourceCodeLine = 84;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 85;
                Print( "Error Sending to DmUsbUdp: {0:d}\r\n", (short)STATUS) ; 
                }
            
            __context__.SourceCodeLine = 87;
            
            
            }
            
        private CrestronString PARSEADDRESS (  SplusExecutionContext __context__, CrestronString STRADDRESS ) 
            { 
            CrestronString PARSEDADDRESS;
            PARSEDADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            CrestronString CHARACTER;
            CHARACTER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            ushort VALUE = 0;
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 105;
            
            __context__.SourceCodeLine = 109;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( STRADDRESS ) != 6))  ) ) 
                { 
                __context__.SourceCodeLine = 111;
                ERROR = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 112;
                return ( "FAILED" ) ; 
                } 
            
            __context__.SourceCodeLine = 114;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 116;
                CHARACTER  .UpdateValue ( Functions.Mid ( STRADDRESS ,  (int) ( ((I * 2) + 1) ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 117;
                VALUE = (ushort) ( Functions.HextoI( CHARACTER ) ) ; 
                __context__.SourceCodeLine = 118;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( VALUE > 255 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 120;
                    ERROR = (ushort) ( 2 ) ; 
                    __context__.SourceCodeLine = 121;
                    return ( "FAILED" ) ; 
                    } 
                
                __context__.SourceCodeLine = 123;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 125;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "00" , CHARACTER ) == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 127;
                        ERROR = (ushort) ( 2 ) ; 
                        __context__.SourceCodeLine = 128;
                        return ( "FAILED" ) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 131;
                PARSEDADDRESS  .UpdateValue ( PARSEDADDRESS + Functions.Chr (  (int) ( VALUE ) )  ) ; 
                __context__.SourceCodeLine = 133;
                
                __context__.SourceCodeLine = 114;
                } 
            
            __context__.SourceCodeLine = 140;
            return ( PARSEDADDRESS ) ; 
            
            }
            
        private void PARSECOMMAND (  SplusExecutionContext __context__, ushort COMMAND , CrestronString DEVICE0ADDRESS , CrestronString DEVICE1ADDRESS ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            CrestronString DEVICE;
            DEVICE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
            
            
            __context__.SourceCodeLine = 147;
            
            __context__.SourceCodeLine = 153;
            switch ((int)COMMAND)
            
                { 
                case 0 : 
                case 2 : 
                case 3 : 
                case 6 : 
                case 10 : 
                
                    { 
                    __context__.SourceCodeLine = 161;
                    MSG  .UpdateValue ( Functions.Chr (  (int) ( COMMAND ) ) + "\u0000\u001B\u0013" + DEVICE0ADDRESS  ) ; 
                    __context__.SourceCodeLine = 162;
                    SENDCOMMAND (  __context__ , MSG) ; 
                    __context__.SourceCodeLine = 163;
                    break ; 
                    } 
                
                goto case 4 ;
                case 4 : 
                goto case 5 ;
                case 5 : 
                
                    { 
                    __context__.SourceCodeLine = 169;
                    MSG  .UpdateValue ( Functions.Chr (  (int) ( COMMAND ) ) + "\u0000\u001B\u0013" + DEVICE1ADDRESS + "\u0000\u001B\u0013" + DEVICE0ADDRESS  ) ; 
                    __context__.SourceCodeLine = 170;
                    SENDCOMMAND (  __context__ , MSG) ; 
                    __context__.SourceCodeLine = 171;
                    MSG  .UpdateValue ( Functions.Chr (  (int) ( COMMAND ) ) + "\u0000\u001B\u0013" + DEVICE0ADDRESS + "\u0000\u001B\u0013" + DEVICE1ADDRESS  ) ; 
                    __context__.SourceCodeLine = 172;
                    SENDCOMMAND (  __context__ , MSG) ; 
                    __context__.SourceCodeLine = 173;
                    break ; 
                    } 
                
                goto case 1 ;
                case 1 : 
                goto case 7 ;
                case 7 : 
                goto case 8 ;
                case 8 : 
                goto case 9 ;
                case 9 : 
                
                    { 
                    __context__.SourceCodeLine = 180;
                    break ; 
                    } 
                
                goto default;
                default : 
                
                    { 
                    __context__.SourceCodeLine = 184;
                    Print( "Unknown command") ; 
                    __context__.SourceCodeLine = 185;
                    break ; 
                    } 
                break;
                
                } 
                
            
            
            }
            
        object DIPAIRDEVICES_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 193;
                
                __context__.SourceCodeLine = 197;
                PARSECOMMAND (  __context__ , (ushort)( 10 ), PARSEADDRESS( __context__ , SILOCALDEVICE ), "") ; 
                __context__.SourceCodeLine = 198;
                
                __context__.SourceCodeLine = 202;
                PARSECOMMAND (  __context__ , (ushort)( 10 ), PARSEADDRESS( __context__ , SIREMOTEDEVICE ), "") ; 
                __context__.SourceCodeLine = 203;
                
                __context__.SourceCodeLine = 207;
                PARSECOMMAND (  __context__ , (ushort)( 4 ), PARSEADDRESS( __context__ , SILOCALDEVICE ), PARSEADDRESS( __context__ , SIREMOTEDEVICE )) ; 
                __context__.SourceCodeLine = 208;
                AOERROR  .Value = (ushort) ( ERROR ) ; 
                __context__.SourceCodeLine = 209;
                ERROR = (ushort) ( 0 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIREMOVEALLPAIRINGS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 214;
            PARSECOMMAND (  __context__ , (ushort)( 10 ), PARSEADDRESS( __context__ , SILOCALDEVICE ), "") ; 
            __context__.SourceCodeLine = 215;
            AOERROR  .Value = (ushort) ( ERROR ) ; 
            __context__.SourceCodeLine = 216;
            ERROR = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DIPING_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 221;
        PARSECOMMAND (  __context__ , (ushort)( 2 ), PARSEADDRESS( __context__ , SILOCALDEVICE ), "") ; 
        __context__.SourceCodeLine = 222;
        AOERROR  .Value = (ushort) ( ERROR ) ; 
        __context__.SourceCodeLine = 223;
        ERROR = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIREMOVEPAIRING_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 228;
        PARSECOMMAND (  __context__ , (ushort)( 5 ), PARSEADDRESS( __context__ , SILOCALDEVICE ), PARSEADDRESS( __context__ , SIREMOTEDEVICE )) ; 
        __context__.SourceCodeLine = 229;
        AOERROR  .Value = (ushort) ( ERROR ) ; 
        __context__.SourceCodeLine = 230;
        ERROR = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGETDEVICES_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString MSG;
        MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 237;
        MSG  .UpdateValue ( "\u0000" + "\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF"  ) ; 
        __context__.SourceCodeLine = 238;
        SENDCOMMAND (  __context__ , MSG) ; 
        __context__.SourceCodeLine = 239;
        
        __context__.SourceCodeLine = 245;
        AOERROR  .Value = (ushort) ( ERROR ) ; 
        __context__.SourceCodeLine = 246;
        ERROR = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIENABLEUDP_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMP;
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 253;
        RETRYCOUNT = (ushort) ( (RETRYCOUNT + 1) ) ; 
        __context__.SourceCodeLine = 254;
        STATUS = (short) ( Functions.SocketUDP_Enable( DMUSBUDP , "255.255.255.255" , (ushort)( 6137 ) ) ) ; 
        __context__.SourceCodeLine = 255;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 257;
            
            __context__.SourceCodeLine = 261;
            AOERROR  .Value = (ushort) ( 3 ) ; 
            __context__.SourceCodeLine = 262;
            DOMODULEREADY  .Value = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 266;
            DOMODULEREADY  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 267;
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DMUSBUDP_OnSocketReceive_6 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    DEBUGSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    DMUSBUDP  = new SplusUdpSocket ( 1024, this );
    
    DIENABLEUDP = new Crestron.Logos.SplusObjects.DigitalInput( DIENABLEUDP__DigitalInput__, this );
    m_DigitalInputList.Add( DIENABLEUDP__DigitalInput__, DIENABLEUDP );
    
    DIGETDEVICES = new Crestron.Logos.SplusObjects.DigitalInput( DIGETDEVICES__DigitalInput__, this );
    m_DigitalInputList.Add( DIGETDEVICES__DigitalInput__, DIGETDEVICES );
    
    DIPAIRDEVICES = new Crestron.Logos.SplusObjects.DigitalInput( DIPAIRDEVICES__DigitalInput__, this );
    m_DigitalInputList.Add( DIPAIRDEVICES__DigitalInput__, DIPAIRDEVICES );
    
    DIREMOVEPAIRING = new Crestron.Logos.SplusObjects.DigitalInput( DIREMOVEPAIRING__DigitalInput__, this );
    m_DigitalInputList.Add( DIREMOVEPAIRING__DigitalInput__, DIREMOVEPAIRING );
    
    DIREMOVEALLPAIRINGS = new Crestron.Logos.SplusObjects.DigitalInput( DIREMOVEALLPAIRINGS__DigitalInput__, this );
    m_DigitalInputList.Add( DIREMOVEALLPAIRINGS__DigitalInput__, DIREMOVEALLPAIRINGS );
    
    DIPING = new Crestron.Logos.SplusObjects.DigitalInput( DIPING__DigitalInput__, this );
    m_DigitalInputList.Add( DIPING__DigitalInput__, DIPING );
    
    DOMODULEREADY = new Crestron.Logos.SplusObjects.DigitalOutput( DOMODULEREADY__DigitalOutput__, this );
    m_DigitalOutputList.Add( DOMODULEREADY__DigitalOutput__, DOMODULEREADY );
    
    AODEVICENUMBER = new Crestron.Logos.SplusObjects.AnalogInput( AODEVICENUMBER__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AODEVICENUMBER__AnalogSerialInput__, AODEVICENUMBER );
    
    AOERROR = new Crestron.Logos.SplusObjects.AnalogOutput( AOERROR__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AOERROR__AnalogSerialOutput__, AOERROR );
    
    SILOCALDEVICE = new Crestron.Logos.SplusObjects.StringInput( SILOCALDEVICE__AnalogSerialInput__, 20, this );
    m_StringInputList.Add( SILOCALDEVICE__AnalogSerialInput__, SILOCALDEVICE );
    
    SIREMOTEDEVICE = new Crestron.Logos.SplusObjects.StringInput( SIREMOTEDEVICE__AnalogSerialInput__, 20, this );
    m_StringInputList.Add( SIREMOTEDEVICE__AnalogSerialInput__, SIREMOTEDEVICE );
    
    SOUDP_RX = new Crestron.Logos.SplusObjects.StringOutput( SOUDP_RX__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SOUDP_RX__AnalogSerialOutput__, SOUDP_RX );
    
    SOLOCALDEVICE = new Crestron.Logos.SplusObjects.StringOutput( SOLOCALDEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SOLOCALDEVICE__AnalogSerialOutput__, SOLOCALDEVICE );
    
    SOREMOTEDEVICE = new Crestron.Logos.SplusObjects.StringOutput( SOREMOTEDEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SOREMOTEDEVICE__AnalogSerialOutput__, SOREMOTEDEVICE );
    
    
    DIPAIRDEVICES.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIPAIRDEVICES_OnPush_0, false ) );
    DIREMOVEALLPAIRINGS.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIREMOVEALLPAIRINGS_OnPush_1, false ) );
    DIPING.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIPING_OnPush_2, false ) );
    DIREMOVEPAIRING.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIREMOVEPAIRING_OnPush_3, false ) );
    DIGETDEVICES.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGETDEVICES_OnPush_4, false ) );
    DIENABLEUDP.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIENABLEUDP_OnPush_5, false ) );
    DMUSBUDP.OnSocketReceive.Add( new SocketHandlerWrapper( DMUSBUDP_OnSocketReceive_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_USB_EXT_DM_FUNCTIONS_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DIENABLEUDP__DigitalInput__ = 0;
const uint DIGETDEVICES__DigitalInput__ = 1;
const uint DIPAIRDEVICES__DigitalInput__ = 2;
const uint DIREMOVEPAIRING__DigitalInput__ = 3;
const uint DIREMOVEALLPAIRINGS__DigitalInput__ = 4;
const uint DIPING__DigitalInput__ = 5;
const uint AODEVICENUMBER__AnalogSerialInput__ = 0;
const uint SILOCALDEVICE__AnalogSerialInput__ = 1;
const uint SIREMOTEDEVICE__AnalogSerialInput__ = 2;
const uint DOMODULEREADY__DigitalOutput__ = 0;
const uint AOERROR__AnalogSerialOutput__ = 0;
const uint SOUDP_RX__AnalogSerialOutput__ = 1;
const uint SOLOCALDEVICE__AnalogSerialOutput__ = 2;
const uint SOREMOTEDEVICE__AnalogSerialOutput__ = 3;

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
