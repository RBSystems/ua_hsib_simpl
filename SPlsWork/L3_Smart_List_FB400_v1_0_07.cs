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

namespace UserModule_L3_SMART_LIST_FB400_V1_0_07
{
    public class UserModuleClass_L3_SMART_LIST_FB400_V1_0_07 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VIS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TX__DOLLAR__1;
        UShortParameter HIGHINDEX;
        UShortParameter TEXTCOLUMNS;
        StringParameter HTMLDATA;
        STHTML [] HTML;
        ushort ICOLUMNS = 0;
        ushort [] IVIS;
        ushort [] IFB;
        CrestronString STRASH;
        private CrestronString FGETBOLDCLOSE (  SplusExecutionContext __context__, ushort IBOLD ) 
            { 
            
            __context__.SourceCodeLine = 62;
            if ( Functions.TestForTrue  ( ( IBOLD)  ) ) 
                {
                __context__.SourceCodeLine = 62;
                return ( "</b>" ) ; 
                }
            
            __context__.SourceCodeLine = 63;
            return ( "" ) ; 
            
            }
            
        private CrestronString FGETBOLD (  SplusExecutionContext __context__, ushort IBOLD ) 
            { 
            
            __context__.SourceCodeLine = 67;
            if ( Functions.TestForTrue  ( ( IBOLD)  ) ) 
                {
                __context__.SourceCodeLine = 67;
                return ( "<b>" ) ; 
                }
            
            __context__.SourceCodeLine = 68;
            return ( "" ) ; 
            
            }
            
        private CrestronString FHTML (  SplusExecutionContext __context__, CrestronString STEXT , ushort ICOLUMN ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 75;
            if ( Functions.TestForTrue  ( ( Functions.Length( STEXT ))  ) ) 
                { 
                __context__.SourceCodeLine = 77;
                MakeString ( STEMP , "{0}", FGETBOLD (  __context__ , (ushort)( HTML[ ICOLUMN ].IBOLD )) ) ; 
                __context__.SourceCodeLine = 78;
                MakeString ( STEMP , "{0}<font size=\u0022{1:d}\u0022", STEMP , (ushort)HTML[ ICOLUMN ].ISIZE) ; 
                __context__.SourceCodeLine = 79;
                MakeString ( STEMP , "{0} color=\u0022{1}\u0022>{2}", STEMP , HTML [ ICOLUMN] . SCOLOR , STEXT ) ; 
                __context__.SourceCodeLine = 80;
                MakeString ( STEMP , "{0}</font>{1}", STEMP , FGETBOLDCLOSE (  __context__ , (ushort)( HTML[ ICOLUMN ].IBOLD )) ) ; 
                } 
            
            __context__.SourceCodeLine = 82;
            return ( STEMP ) ; 
            
            }
            
        private void FPROCESSTEXT (  SplusExecutionContext __context__, ushort IINDEX , CrestronString STEMP1 , CrestronString STEMP2 ) 
            { 
            
            __context__.SourceCodeLine = 87;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ICOLUMNS);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 89;
                        TX__DOLLAR__1 [ IINDEX]  .UpdateValue ( FHTML (  __context__ , STEMP1, (ushort)( 1 ))  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 90;
                        TX__DOLLAR__1 [ IINDEX]  .UpdateValue ( FHTML (  __context__ , STEMP1, (ushort)( 1 )) + "\u000d" + FHTML (  __context__ , STEMP2, (ushort)( 2 ))  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private ushort FPROCESS (  SplusExecutionContext __context__, CrestronString SDATAPROCESS ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString STEMP;
            CrestronString STEMP2;
            CrestronString SDATA;
            CrestronString SDATAORIGINAL;
            CrestronString [] STEXT;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SDATAORIGINAL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            STEXT  = new CrestronString[ 3 ];
            for( uint i = 0; i < 3; i++ )
                STEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 99;
            SDATAORIGINAL  .UpdateValue ( SDATAPROCESS  ) ; 
            __context__.SourceCodeLine = 100;
            while ( Functions.TestForTrue  ( ( Functions.Find( ";" , SDATAORIGINAL ))  ) ) 
                { 
                __context__.SourceCodeLine = 102;
                SDATA  .UpdateValue ( Functions.Remove ( ";" , SDATAORIGINAL )  ) ; 
                __context__.SourceCodeLine = 103;
                STEMP  .UpdateValue ( Functions.Remove ( ":" , SDATA )  ) ; 
                __context__.SourceCodeLine = 105;
                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ListButtonFB" , STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 107;
                    while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 109;
                        STEMP  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
                        __context__.SourceCodeLine = 110;
                        I = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 111;
                        if ( Functions.TestForTrue  ( ( I)  ) ) 
                            { 
                            __context__.SourceCodeLine = 113;
                            IFB [ I] = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                            __context__.SourceCodeLine = 114;
                            FB [ I]  .Value = (ushort) ( IFB[ I ] ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 116;
                        STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                        __context__.SourceCodeLine = 107;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 119;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ListVisFB" , STEMP ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 121;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "," , SDATA ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 123;
                            STEMP  .UpdateValue ( Functions.Remove ( "=" , SDATA )  ) ; 
                            __context__.SourceCodeLine = 124;
                            I = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                            __context__.SourceCodeLine = 125;
                            if ( Functions.TestForTrue  ( ( I)  ) ) 
                                { 
                                __context__.SourceCodeLine = 127;
                                IVIS [ I] = (ushort) ( Functions.Atoi( SDATA ) ) ; 
                                __context__.SourceCodeLine = 128;
                                VIS [ I]  .Value = (ushort) ( IVIS[ I ] ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 130;
                            STRASH  .UpdateValue ( Functions.Remove ( "," , SDATA )  ) ; 
                            __context__.SourceCodeLine = 121;
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 133;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "ListTextFB" , STEMP ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 135;
                            while ( Functions.TestForTrue  ( ( Functions.Find( "|" , SDATA ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 137;
                                STEMP  .UpdateValue ( Functions.Remove ( "|" , SDATA )  ) ; 
                                __context__.SourceCodeLine = 138;
                                STEMP2  .UpdateValue ( Functions.Remove ( "=" , STEMP )  ) ; 
                                __context__.SourceCodeLine = 139;
                                I = (ushort) ( Functions.Atoi( STEMP2 ) ) ; 
                                __context__.SourceCodeLine = 141;
                                if ( Functions.TestForTrue  ( ( I)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 143;
                                    J = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 144;
                                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "," , STEMP ) ) && Functions.TestForTrue ( Functions.BoolToInt ( J <= TEXTCOLUMNS  .Value ) )) ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 146;
                                        STEXT [ J ]  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Find( "," , STEMP ) - 1) ) )  ) ; 
                                        __context__.SourceCodeLine = 147;
                                        STRASH  .UpdateValue ( Functions.Remove ( "," , STEMP )  ) ; 
                                        __context__.SourceCodeLine = 148;
                                        J = (ushort) ( (J + 1) ) ; 
                                        __context__.SourceCodeLine = 144;
                                        } 
                                    
                                    __context__.SourceCodeLine = 150;
                                    FPROCESSTEXT (  __context__ , (ushort)( I ), STEXT[ 1 ], STEXT[ 2 ]) ; 
                                    __context__.SourceCodeLine = 152;
                                    I = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 135;
                                } 
                            
                            } 
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 100;
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        object RX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 161;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 163;
                    FPROCESS (  __context__ , Functions.Gather( "}" , RX__DOLLAR__ )) ; 
                    __context__.SourceCodeLine = 161;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        ushort I = 0;
        
        CrestronString STEMP;
        CrestronString SHTML;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        SHTML  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 174;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 184;
            ICOLUMNS = (ushort) ( TEXTCOLUMNS  .Value ) ; 
            __context__.SourceCodeLine = 187;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 189;
                HTML [ I] . IBOLD = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 190;
                HTML [ I] . ISIZE = (ushort) ( 14 ) ; 
                __context__.SourceCodeLine = 191;
                HTML [ I] . SCOLOR  .UpdateValue ( "#ffffff"  ) ; 
                __context__.SourceCodeLine = 187;
                } 
            
            __context__.SourceCodeLine = 194;
            if ( Functions.TestForTrue  ( ( Functions.Length( HTMLDATA  ))  ) ) 
                { 
                __context__.SourceCodeLine = 196;
                SHTML  .UpdateValue ( HTMLDATA  ) ; 
                __context__.SourceCodeLine = 197;
                while ( Functions.TestForTrue  ( ( Functions.Find( ";" , SHTML ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 199;
                    STEMP  .UpdateValue ( Functions.Remove ( ";" , SHTML )  ) ; 
                    __context__.SourceCodeLine = 200;
                    I = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                    __context__.SourceCodeLine = 201;
                    STRASH  .UpdateValue ( Functions.Remove ( "=" , STEMP )  ) ; 
                    __context__.SourceCodeLine = 202;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bold" , STEMP ))  ) ) 
                        {
                        __context__.SourceCodeLine = 202;
                        HTML [ I] . IBOLD = (ushort) ( 1 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 203;
                    if ( Functions.TestForTrue  ( ( Functions.Atoi( STEMP ))  ) ) 
                        {
                        __context__.SourceCodeLine = 203;
                        HTML [ I] . ISIZE = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 204;
                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "white" , STEMP ))  ) ) 
                        {
                        __context__.SourceCodeLine = 204;
                        HTML [ I] . SCOLOR  .UpdateValue ( "#ffffff"  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 205;
                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "red" , STEMP ))  ) ) 
                            {
                            __context__.SourceCodeLine = 205;
                            HTML [ I] . SCOLOR  .UpdateValue ( "#ff0000"  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 206;
                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "green" , STEMP ))  ) ) 
                                {
                                __context__.SourceCodeLine = 206;
                                HTML [ I] . SCOLOR  .UpdateValue ( "#00ff00"  ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 207;
                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "blue" , STEMP ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 207;
                                    HTML [ I] . SCOLOR  .UpdateValue ( "#0000ff"  ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 208;
                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "orange" , STEMP ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 208;
                                        HTML [ I] . SCOLOR  .UpdateValue ( "#ffbb00"  ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 209;
                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "yellow" , STEMP ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 209;
                                            HTML [ I] . SCOLOR  .UpdateValue ( "#ffff00"  ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 210;
                                            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "black" , STEMP ))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 210;
                                                HTML [ I] . SCOLOR  .UpdateValue ( "#000000"  ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 211;
                                                if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "purple" , STEMP ))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 211;
                                                    HTML [ I] . SCOLOR  .UpdateValue ( "#ff00ff"  ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 212;
                                                    if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "bluegreen" , STEMP ))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 212;
                                                        HTML [ I] . SCOLOR  .UpdateValue ( "#00ffff"  ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 213;
                                                        if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "skyblue" , STEMP ))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 213;
                                                            HTML [ I] . SCOLOR  .UpdateValue ( "#8888ff"  ) ; 
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 197;
                    } 
                
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        IVIS  = new ushort[ 401 ];
        IFB  = new ushort[ 401 ];
        STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        HTML  = new STHTML[ 3 ];
        for( uint i = 0; i < 3; i++ )
        {
            HTML [i] = new STHTML( this, true );
            HTML [i].PopulateCustomAttributeList( false );
            
        }
        
        VIS = new InOutArray<DigitalOutput>( 400, this );
        for( uint i = 0; i < 400; i++ )
        {
            VIS[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VIS__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( VIS__DigitalOutput__ + i, VIS[i+1] );
        }
        
        FB = new InOutArray<DigitalOutput>( 400, this );
        for( uint i = 0; i < 400; i++ )
        {
            FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FB__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( FB__DigitalOutput__ + i, FB[i+1] );
        }
        
        TX__DOLLAR__1 = new InOutArray<StringOutput>( 400, this );
        for( uint i = 0; i < 400; i++ )
        {
            TX__DOLLAR__1[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR__1__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( TX__DOLLAR__1__AnalogSerialOutput__ + i, TX__DOLLAR__1[i+1] );
        }
        
        RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 10000, this );
        m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
        
        HIGHINDEX = new UShortParameter( HIGHINDEX__Parameter__, this );
        m_ParameterList.Add( HIGHINDEX__Parameter__, HIGHINDEX );
        
        TEXTCOLUMNS = new UShortParameter( TEXTCOLUMNS__Parameter__, this );
        m_ParameterList.Add( TEXTCOLUMNS__Parameter__, TEXTCOLUMNS );
        
        HTMLDATA = new StringParameter( HTMLDATA__Parameter__, this );
        m_ParameterList.Add( HTMLDATA__Parameter__, HTMLDATA );
        
        
        RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_0, true ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_L3_SMART_LIST_FB400_V1_0_07 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RX__DOLLAR____AnalogSerialInput__ = 0;
    const uint VIS__DigitalOutput__ = 0;
    const uint FB__DigitalOutput__ = 400;
    const uint TX__DOLLAR__1__AnalogSerialOutput__ = 0;
    const uint HIGHINDEX__Parameter__ = 10;
    const uint TEXTCOLUMNS__Parameter__ = 11;
    const uint HTMLDATA__Parameter__ = 12;
    
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

[SplusStructAttribute(-1, true, false)]
public class STHTML : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  IBOLD = 0;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  SCOLOR;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  ISIZE = 0;
    
    
    public STHTML( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SCOLOR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 7, Owner );
        
        
    }
    
}

}
