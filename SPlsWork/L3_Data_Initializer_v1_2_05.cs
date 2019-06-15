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
using L3_Tools;

namespace UserModule_L3_DATA_INITIALIZER_V1_2_05
{
    public class UserModuleClass_L3_DATA_INITIALIZER_V1_2_05 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput INIT_TRIG;
        Crestron.Logos.SplusObjects.DigitalInput USE_FILE_CHK;
        Crestron.Logos.SplusObjects.DigitalInput OVERRIDE_FILE_CHK;
        Crestron.Logos.SplusObjects.DigitalInput OUTPUT_FILE_PER_LINE;
        Crestron.Logos.SplusObjects.DigitalInput USE_INDEX_PREFIXING;
        Crestron.Logos.SplusObjects.DigitalInput SEND_FINALIZE_START;
        Crestron.Logos.SplusObjects.DigitalInput SEND_FINALIZE_END;
        Crestron.Logos.SplusObjects.AnalogInput LINE_DELAY;
        Crestron.Logos.SplusObjects.StringInput FILENAMEINSERT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DATAINSERT__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_PULSE;
        Crestron.Logos.SplusObjects.DigitalOutput FAILED_FILE_READ;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_READ_COMPLETE;
        Crestron.Logos.SplusObjects.StringOutput STATUS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DATASEND__DOLLAR__;
        StringParameter FILEFOLDER__DOLLAR__;
        StringParameter FILENAME__DOLLAR__;
        StringParameter FILELINEDELIMITER__DOLLAR__;
        StringParameter FILECUSTOMDELIMITER__DOLLAR__;
        StringParameter OPENCHAR__DOLLAR__;
        StringParameter LINEHEADER__DOLLAR__;
        StringParameter LINEHEADERDELIMITER__DOLLAR__;
        StringParameter INDEXINGPREFIX__DOLLAR__;
        StringParameter INDEXINGPREFIXDELIMITER__DOLLAR__;
        StringParameter LINEDELIMITER__DOLLAR__;
        StringParameter CLOSECHAR__DOLLAR__;
        StringParameter FINALIZESTARTDATA__DOLLAR__;
        StringParameter FINALIZEENDDATA__DOLLAR__;
        StringParameter FINALIZEDELIMITER__DOLLAR__;
        UShortParameter LINE_DELAY_IN_TICKS;
        UShortParameter END_DELAY;
        L3_Tools.StringTools ST;
        ushort ILINEDELAY = 0;
        ushort IINDEXINGLENGTH = 0;
        ushort IDATAINITCOMPLETE = 0;
        ushort IINITTRIGBUFFERED = 0;
        CrestronString SDATATOSEND;
        CrestronString SFILELINEDELIMITER;
        CrestronString SFILELOCATION;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 285;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 285;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 286;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 295;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 295;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 297;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 298;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 299;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 301;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 301;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 302;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 299;
                } 
            
            __context__.SourceCodeLine = 304;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 305;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 305;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 307;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 308;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 309;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 311;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 311;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 312;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 313;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 314;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 309;
                } 
            
            __context__.SourceCodeLine = 317;
            return ( SDATA ) ; 
            
            }
            
        private void FUPDATESTATUS (  SplusExecutionContext __context__ ) 
            { 
            CrestronString STEMP1;
            CrestronString STEMP2;
            CrestronString STEMP3;
            STEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMP3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 325;
            STEMP1  .UpdateValue ( "module is not enabled"  ) ; 
            __context__.SourceCodeLine = 326;
            STEMP2  .UpdateValue ( "data init has not started"  ) ; 
            __context__.SourceCodeLine = 327;
            STEMP3  .UpdateValue ( "init trigger is armed"  ) ; 
            __context__.SourceCodeLine = 329;
            if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 329;
                STEMP1  .UpdateValue ( "module is enabled"  ) ; 
                }
            
            __context__.SourceCodeLine = 330;
            if ( Functions.TestForTrue  ( ( IDATAINITCOMPLETE)  ) ) 
                {
                __context__.SourceCodeLine = 330;
                STEMP2  .UpdateValue ( "data init has completed"  ) ; 
                }
            
            __context__.SourceCodeLine = 331;
            if ( Functions.TestForTrue  ( ( IINITTRIGBUFFERED)  ) ) 
                {
                __context__.SourceCodeLine = 331;
                STEMP3  .UpdateValue ( "init trigger is armed, awaiting enable"  ) ; 
                }
            
            __context__.SourceCodeLine = 333;
            MakeString ( STATUS__DOLLAR__ , "{0} - {1}: {2}: {3}", LINEHEADER__DOLLAR__ , STEMP1 , STEMP2 , STEMP3 ) ; 
            
            }
            
        private CrestronString FGETLINEDATA (  SplusExecutionContext __context__, ushort IGUID , CrestronString SFILELINE ) 
            { 
            CrestronString SLOCALLINE;
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 341;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 343;
                MakeString ( SLOCALLINE , "{0}={1:d3}{2} {3}{4}", INDEXINGPREFIX__DOLLAR__ , (ushort)IGUID, INDEXINGPREFIXDELIMITER__DOLLAR__ , SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 348;
                MakeString ( SLOCALLINE , "{0}{1}", SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 352;
            return ( SLOCALLINE ) ; 
            
            }
            
        private void FSENDFINALIZESTARTDATA (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 358;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZESTARTDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            
            }
            
        private void FSENDFINALIZEENDDATA (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 362;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEENDDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            
            }
            
        private short FPROCESSFILEDATA (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort I = 0;
            
            CrestronString SFILEDATA;
            CrestronString SLOCALDATATOSEND;
            CrestronString SLOCALHEADER;
            CrestronString SLOCALLINE;
            CrestronString SFILELINE;
            CrestronString SCLOSECHAR;
            SFILEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 45000, this );
            SLOCALDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5000, this );
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 600, this );
            SFILELINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 600, this );
            SCLOSECHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 371;
            SFILEDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 373;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SFILEDATA ) ))  ) ) 
                {
                __context__.SourceCodeLine = 373;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                }
            
            __context__.SourceCodeLine = 375;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 377;
            MakeString ( SLOCALHEADER , "{0}{1}{2}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 378;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 378;
                MakeString ( SLOCALHEADER , "{0}{1}", SLOCALHEADER , INDEXINGPREFIX__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 380;
            SCLOSECHAR  .UpdateValue ( LINEDELIMITER__DOLLAR__ + CLOSECHAR__DOLLAR__  ) ; 
            __context__.SourceCodeLine = 382;
            if ( Functions.TestForTrue  ( ( SEND_FINALIZE_START  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 384;
                FSENDFINALIZESTARTDATA (  __context__  ) ; 
                __context__.SourceCodeLine = 385;
                Functions.Delay (  (int) ( END_DELAY  .Value ) ) ; 
                } 
            
            __context__.SourceCodeLine = 388;
            while ( Functions.TestForTrue  ( ( Functions.Find( SFILELINEDELIMITER , SFILEDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 390;
                SFILELINE  .UpdateValue ( Functions.Remove ( SFILELINEDELIMITER , SFILEDATA )  ) ; 
                __context__.SourceCodeLine = 391;
                SFILELINE  .UpdateValue ( Functions.Left ( SFILELINE ,  (int) ( (Functions.Length( SFILELINE ) - Functions.Length( SFILELINEDELIMITER )) ) )  ) ; 
                __context__.SourceCodeLine = 392;
                if ( Functions.TestForTrue  ( ( Functions.Find( "//" , SFILELINE ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 394;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "//" , SFILELINE ) == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 394;
                        continue ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 395;
                        SFILELINE  .UpdateValue ( ST . StringTrim (  Functions.Left( SFILELINE , (int)( (Functions.Find( "//" , SFILELINE ) - 1) ) )  .ToSimplSharpString() )  ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 397;
                    SFILELINE  .UpdateValue ( ST . StringTrim (  SFILELINE  .ToSimplSharpString() )  ) ; 
                    }
                
                __context__.SourceCodeLine = 398;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SFILELINE ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 398;
                    continue ; 
                    }
                
                __context__.SourceCodeLine = 400;
                if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 400;
                    MakeString ( SDATATOSEND , "{0}={1:d3}{2} {3}{4}", SLOCALHEADER , (ushort)I, INDEXINGPREFIXDELIMITER__DOLLAR__ , SFILELINE , SCLOSECHAR ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 401;
                    MakeString ( SDATATOSEND , "{0}{1}{2}", SLOCALHEADER , SFILELINE , SCLOSECHAR ) ; 
                    }
                
                __context__.SourceCodeLine = 403;
                if ( Functions.TestForTrue  ( ( OUTPUT_FILE_PER_LINE  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 403;
                    DATASEND__DOLLAR__ [ I]  .UpdateValue ( SDATATOSEND  ) ; 
                    }
                
                __context__.SourceCodeLine = 404;
                TX__DOLLAR__  .UpdateValue ( SDATATOSEND  ) ; 
                __context__.SourceCodeLine = 405;
                Functions.Delay (  (int) ( ILINEDELAY ) ) ; 
                __context__.SourceCodeLine = 407;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 388;
                } 
            
            __context__.SourceCodeLine = 410;
            if ( Functions.TestForTrue  ( ( SEND_FINALIZE_END  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 410;
                FSENDFINALIZEENDDATA (  __context__  ) ; 
                }
            
            __context__.SourceCodeLine = 411;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_31__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_31___Callback ) ;
            
            return 0; // default return value (none specified in module)
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_31___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 413;
            _SplusNVRAM.NVIDONEFB = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 414;
            DONE_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 415;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            __context__.SourceCodeLine = 416;
            IDATAINITCOMPLETE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 417;
            FILE_READ_COMPLETE  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 418;
            FUPDATESTATUS (  __context__  ) ; 
            __context__.SourceCodeLine = 419;
            Trace( "{0}.{1:d3}  ______Data Init List: {2}_____:Complete_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds(), LINEHEADER__DOLLAR__ ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private CrestronString FGETFILEDATA (  SplusExecutionContext __context__ ) 
        { 
        ushort I = 0;
        ushort IFILEEND = 0;
        ushort INOMOREDELIMITERS = 0;
        ushort IOPSCLOSED = 0;
        ushort IFILECLOSED = 0;
        
        int SIFILEPOINTER = 0;
        
        short SIERRFILEHANDLE = 0;
        short SIERRFOUND = 0;
        short SIERRFILESEEK = 0;
        
        int SIERRFILEREAD = 0;
        int SIERRFILEOPEN = 0;
        int SIERRFILECLOSE = 0;
        int SIERRENDFILEOPS = 0;
        
        CrestronString SFILEDATA;
        CrestronString SFILEPATH;
        CrestronString SFILEPATHTEMP;
        SFILEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 60000, this );
        SFILEPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        SFILEPATHTEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        
        FILE_INFO FILEINFO;
        FILEINFO  = new FILE_INFO();
        FILEINFO .PopulateDefaults();
        
        
        __context__.SourceCodeLine = 433;
        Trace( "{0}.{1:d3}  ______Data Init List: {2}_____:Start_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds(), LINEHEADER__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 435;
        I = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 438;
        SFILEPATH  .UpdateValue ( SFILELOCATION  ) ; 
        __context__.SourceCodeLine = 440;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 441;
        SIERRFOUND = (short) ( FindFirstShared( SFILEPATH , ref FILEINFO ) ) ; 
        __context__.SourceCodeLine = 443;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 445;
            Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
            __context__.SourceCodeLine = 446;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 447;
            return ( "" ) ; 
            } 
        
        __context__.SourceCodeLine = 451;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 453;
            SFILEPATHTEMP  .UpdateValue ( "/ROMDISK/USER/" + FILENAME__DOLLAR__  ) ; 
            __context__.SourceCodeLine = 454;
            SIERRFOUND = (short) ( FindFirstShared( SFILEPATHTEMP , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 456;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 458;
                Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
                __context__.SourceCodeLine = 459;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 460;
                return ( "" ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 464;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 466;
            Trace( "DataInitializer - {0}, file not found: {1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
            __context__.SourceCodeLine = 467;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 468;
            return ( "fileNotFound" ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 475;
            SIERRFILEOPEN = (int) ( FileOpenShared( SFILEPATH ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 476;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEOPEN < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 479;
                Trace( "DataInitializer - {0}, fileopenshared failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILEHANDLE, SFILEPATH ) ; 
                __context__.SourceCodeLine = 480;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 481;
                return ( "" ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 487;
                SIERRFILESEEK = (short) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) ) ; 
                __context__.SourceCodeLine = 488;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILESEEK < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 491;
                    Trace( "DataInitializer - {0}, fileseek failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILESEEK, SFILEPATH ) ; 
                    __context__.SourceCodeLine = 492;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 492;
                        Trace( "DataInitializer - {0}, fileseek failed, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 493;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 493;
                        Trace( "DataInitializer - {0}, fileseek failed, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 494;
                    return ( "" ) ; 
                    } 
                
                __context__.SourceCodeLine = 497;
                SIERRFILEREAD = (int) ( FileRead( (short)( SIERRFILEHANDLE ) , SFILEDATA , (ushort)( 60000 ) ) ) ; 
                __context__.SourceCodeLine = 499;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 499;
                    Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 500;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 500;
                    Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 502;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 504;
                    Trace( "DataInitializer - siErrFileRead={0:d}", (int)SIERRFILEREAD) ; 
                    __context__.SourceCodeLine = 505;
                    return ( "" ) ; 
                    } 
                
                __context__.SourceCodeLine = 508;
                return ( SFILEDATA ) ; 
                } 
            
            } 
        
        
        return ""; // default return value (none specified in module)
        }
        
    private short FRUN (  SplusExecutionContext __context__ ) 
        { 
        short SIERR = 0;
        
        CrestronString STEMP;
        CrestronString SCHK;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 60000, this );
        SCHK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
        
        
        __context__.SourceCodeLine = 518;
        STEMP  .UpdateValue ( FGETFILEDATA (  __context__  )  ) ; 
        __context__.SourceCodeLine = 525;
        if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
            { 
            __context__.SourceCodeLine = 528;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStringsNoCase( STEMP , "fileNotFound" ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 531;
                DONE_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 532;
                _SplusNVRAM.NVIDONEFB = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 533;
                STATUS__DOLLAR__  .UpdateValue ( "file not found"  ) ; 
                __context__.SourceCodeLine = 534;
                Trace( "{0}.{1:d3}  ______Data Init List: {2}_____:File not found_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds(), LINEHEADER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 536;
                Functions.Pulse ( 10, DONE_PULSE ) ; 
                __context__.SourceCodeLine = 538;
                FSENDFINALIZEENDDATA (  __context__  ) ; 
                __context__.SourceCodeLine = 539;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 541;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( USE_FILE_CHK  .Value ) && Functions.TestForTrue ( Functions.Not( OVERRIDE_FILE_CHK  .Value ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 543;
                    SCHK  .UpdateValue ( ST . StringXOrChk (  STEMP  .ToSimplSharpString() )  ) ; 
                    __context__.SourceCodeLine = 544;
                    if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStrings( SCHK , _SplusNVRAM.NVSCHK ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 546;
                        Trace( "{0}.{1:d3}  ______Data Init List: {2}_____:Chk match, skipping_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds(), LINEHEADER__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 547;
                        STATUS__DOLLAR__  .UpdateValue ( "skipped file. checksum match"  ) ; 
                        __context__.SourceCodeLine = 548;
                        Functions.Pulse ( 10, DONE_PULSE ) ; 
                        __context__.SourceCodeLine = 550;
                        DONE_FB  .Value = (ushort) ( _SplusNVRAM.NVIDONEFB ) ; 
                        __context__.SourceCodeLine = 552;
                        FSENDFINALIZEENDDATA (  __context__  ) ; 
                        __context__.SourceCodeLine = 553;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    } 
                
                }
            
            __context__.SourceCodeLine = 557;
            _SplusNVRAM.NVSCHK  .UpdateValue ( ST . StringXOrChk (  STEMP  .ToSimplSharpString() )  ) ; 
            __context__.SourceCodeLine = 558;
            SIERR = (short) ( FPROCESSFILEDATA( __context__ , STEMP ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 562;
            SIERR = (short) ( 1 ) ; 
            __context__.SourceCodeLine = 563;
            STATUS__DOLLAR__  .UpdateValue ( "failed file-read"  ) ; 
            __context__.SourceCodeLine = 564;
            Trace( "{0}.{1:d3}  ______Data Init List: {2}_____:Failed file read_//\u000d\u000a", Functions.Time ( ) , (ushort)Functions.GetHSeconds(), LINEHEADER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 566;
            _SplusNVRAM.NVIDONEFB = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 567;
            DONE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 568;
            Functions.Pulse ( 10, FAILED_FILE_READ ) ; 
            } 
        
        
        return 0; // default return value (none specified in module)
        }
        
    object LINE_DELAY_OnChange_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 574;
            ILINEDELAY = (ushort) ( LINE_DELAY  .UshortValue ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DATAINSERT__DOLLAR___OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        
        CrestronString SDATATOSEND;
        SDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
        
        
        __context__.SourceCodeLine = 582;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 585;
        MakeString ( SDATATOSEND , "{0}{1}{2} ", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 591;
        if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 593;
            MakeString ( SDATATOSEND , "{0}{1}={2:d3}{3} ", SDATATOSEND , INDEXINGPREFIX__DOLLAR__ , (ushort)I, INDEXINGPREFIXDELIMITER__DOLLAR__ ) ; 
            } 
        
        __context__.SourceCodeLine = 601;
        MakeString ( SDATATOSEND , "{0}{1}{2}{3}", SDATATOSEND , DATAINSERT__DOLLAR__ [ I ] , LINEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 608;
        MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
        __context__.SourceCodeLine = 610;
        MakeString ( DATASEND__DOLLAR__ [ I] , "{0}", SDATATOSEND ) ; 
        __context__.SourceCodeLine = 612;
        if ( Functions.TestForTrue  ( ( SEND_FINALIZE_END  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 612;
            FSENDFINALIZEENDDATA (  __context__  ) ; 
            }
        
        __context__.SourceCodeLine = 614;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_32__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_32___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_32___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 616;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object INIT_TRIG_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 622;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 622;
            FRUN (  __context__  ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 625;
            IINITTRIGBUFFERED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 626;
            FUPDATESTATUS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 632;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINITTRIGBUFFERED ) && Functions.TestForTrue ( ENABLE  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 634;
            IINITTRIGBUFFERED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 635;
            FRUN (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 637;
            FUPDATESTATUS (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FILENAMEINSERT__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 642;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( FILENAMEINSERT__DOLLAR__ ) ))  ) ) 
            {
            __context__.SourceCodeLine = 642;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 643;
            SFILELOCATION  .UpdateValue ( FILENAMEINSERT__DOLLAR__  ) ; 
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
        
        __context__.SourceCodeLine = 656;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 658;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStrings( FILELINEDELIMITER__DOLLAR__  , "Custom" ) ))  ) ) 
            {
            __context__.SourceCodeLine = 658;
            SFILELINEDELIMITER  .UpdateValue ( FILECUSTOMDELIMITER__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 659;
            SFILELINEDELIMITER  .UpdateValue ( FILELINEDELIMITER__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 661;
        if ( Functions.TestForTrue  ( ( Functions.Length( FILENAMEINSERT__DOLLAR__ ))  ) ) 
            {
            __context__.SourceCodeLine = 661;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAMEINSERT__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 662;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 664;
        ILINEDELAY = (ushort) ( LINE_DELAY_IN_TICKS  .Value ) ; 
        __context__.SourceCodeLine = 667;
        FUPDATESTATUS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
    SFILELINEDELIMITER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SFILELOCATION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
    _SplusNVRAM.NVSCHK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    INIT_TRIG = new Crestron.Logos.SplusObjects.DigitalInput( INIT_TRIG__DigitalInput__, this );
    m_DigitalInputList.Add( INIT_TRIG__DigitalInput__, INIT_TRIG );
    
    USE_FILE_CHK = new Crestron.Logos.SplusObjects.DigitalInput( USE_FILE_CHK__DigitalInput__, this );
    m_DigitalInputList.Add( USE_FILE_CHK__DigitalInput__, USE_FILE_CHK );
    
    OVERRIDE_FILE_CHK = new Crestron.Logos.SplusObjects.DigitalInput( OVERRIDE_FILE_CHK__DigitalInput__, this );
    m_DigitalInputList.Add( OVERRIDE_FILE_CHK__DigitalInput__, OVERRIDE_FILE_CHK );
    
    OUTPUT_FILE_PER_LINE = new Crestron.Logos.SplusObjects.DigitalInput( OUTPUT_FILE_PER_LINE__DigitalInput__, this );
    m_DigitalInputList.Add( OUTPUT_FILE_PER_LINE__DigitalInput__, OUTPUT_FILE_PER_LINE );
    
    USE_INDEX_PREFIXING = new Crestron.Logos.SplusObjects.DigitalInput( USE_INDEX_PREFIXING__DigitalInput__, this );
    m_DigitalInputList.Add( USE_INDEX_PREFIXING__DigitalInput__, USE_INDEX_PREFIXING );
    
    SEND_FINALIZE_START = new Crestron.Logos.SplusObjects.DigitalInput( SEND_FINALIZE_START__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_FINALIZE_START__DigitalInput__, SEND_FINALIZE_START );
    
    SEND_FINALIZE_END = new Crestron.Logos.SplusObjects.DigitalInput( SEND_FINALIZE_END__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_FINALIZE_END__DigitalInput__, SEND_FINALIZE_END );
    
    DONE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_FB__DigitalOutput__, DONE_FB );
    
    DONE_PULSE = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_PULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_PULSE__DigitalOutput__, DONE_PULSE );
    
    FAILED_FILE_READ = new Crestron.Logos.SplusObjects.DigitalOutput( FAILED_FILE_READ__DigitalOutput__, this );
    m_DigitalOutputList.Add( FAILED_FILE_READ__DigitalOutput__, FAILED_FILE_READ );
    
    FILE_READ_COMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_READ_COMPLETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_READ_COMPLETE__DigitalOutput__, FILE_READ_COMPLETE );
    
    LINE_DELAY = new Crestron.Logos.SplusObjects.AnalogInput( LINE_DELAY__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LINE_DELAY__AnalogSerialInput__, LINE_DELAY );
    
    FILENAMEINSERT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FILENAMEINSERT__DOLLAR____AnalogSerialInput__, 200, this );
    m_StringInputList.Add( FILENAMEINSERT__DOLLAR____AnalogSerialInput__, FILENAMEINSERT__DOLLAR__ );
    
    DATAINSERT__DOLLAR__ = new InOutArray<StringInput>( 1000, this );
    for( uint i = 0; i < 1000; i++ )
    {
        DATAINSERT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( DATAINSERT__DOLLAR____AnalogSerialInput__ + i, DATAINSERT__DOLLAR____AnalogSerialInput__, 1000, this );
        m_StringInputList.Add( DATAINSERT__DOLLAR____AnalogSerialInput__ + i, DATAINSERT__DOLLAR__[i+1] );
    }
    
    STATUS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( STATUS__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( STATUS__DOLLAR____AnalogSerialOutput__, STATUS__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    DATASEND__DOLLAR__ = new InOutArray<StringOutput>( 1000, this );
    for( uint i = 0; i < 1000; i++ )
    {
        DATASEND__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DATASEND__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DATASEND__DOLLAR____AnalogSerialOutput__ + i, DATASEND__DOLLAR__[i+1] );
    }
    
    LINE_DELAY_IN_TICKS = new UShortParameter( LINE_DELAY_IN_TICKS__Parameter__, this );
    m_ParameterList.Add( LINE_DELAY_IN_TICKS__Parameter__, LINE_DELAY_IN_TICKS );
    
    END_DELAY = new UShortParameter( END_DELAY__Parameter__, this );
    m_ParameterList.Add( END_DELAY__Parameter__, END_DELAY );
    
    FILEFOLDER__DOLLAR__ = new StringParameter( FILEFOLDER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEFOLDER__DOLLAR____Parameter__, FILEFOLDER__DOLLAR__ );
    
    FILENAME__DOLLAR__ = new StringParameter( FILENAME__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILENAME__DOLLAR____Parameter__, FILENAME__DOLLAR__ );
    
    FILELINEDELIMITER__DOLLAR__ = new StringParameter( FILELINEDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILELINEDELIMITER__DOLLAR____Parameter__, FILELINEDELIMITER__DOLLAR__ );
    
    FILECUSTOMDELIMITER__DOLLAR__ = new StringParameter( FILECUSTOMDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILECUSTOMDELIMITER__DOLLAR____Parameter__, FILECUSTOMDELIMITER__DOLLAR__ );
    
    OPENCHAR__DOLLAR__ = new StringParameter( OPENCHAR__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OPENCHAR__DOLLAR____Parameter__, OPENCHAR__DOLLAR__ );
    
    LINEHEADER__DOLLAR__ = new StringParameter( LINEHEADER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( LINEHEADER__DOLLAR____Parameter__, LINEHEADER__DOLLAR__ );
    
    LINEHEADERDELIMITER__DOLLAR__ = new StringParameter( LINEHEADERDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( LINEHEADERDELIMITER__DOLLAR____Parameter__, LINEHEADERDELIMITER__DOLLAR__ );
    
    INDEXINGPREFIX__DOLLAR__ = new StringParameter( INDEXINGPREFIX__DOLLAR____Parameter__, this );
    m_ParameterList.Add( INDEXINGPREFIX__DOLLAR____Parameter__, INDEXINGPREFIX__DOLLAR__ );
    
    INDEXINGPREFIXDELIMITER__DOLLAR__ = new StringParameter( INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__, INDEXINGPREFIXDELIMITER__DOLLAR__ );
    
    LINEDELIMITER__DOLLAR__ = new StringParameter( LINEDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( LINEDELIMITER__DOLLAR____Parameter__, LINEDELIMITER__DOLLAR__ );
    
    CLOSECHAR__DOLLAR__ = new StringParameter( CLOSECHAR__DOLLAR____Parameter__, this );
    m_ParameterList.Add( CLOSECHAR__DOLLAR____Parameter__, CLOSECHAR__DOLLAR__ );
    
    FINALIZESTARTDATA__DOLLAR__ = new StringParameter( FINALIZESTARTDATA__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FINALIZESTARTDATA__DOLLAR____Parameter__, FINALIZESTARTDATA__DOLLAR__ );
    
    FINALIZEENDDATA__DOLLAR__ = new StringParameter( FINALIZEENDDATA__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FINALIZEENDDATA__DOLLAR____Parameter__, FINALIZEENDDATA__DOLLAR__ );
    
    FINALIZEDELIMITER__DOLLAR__ = new StringParameter( FINALIZEDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FINALIZEDELIMITER__DOLLAR____Parameter__, FINALIZEDELIMITER__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_31___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_31___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_32___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_32___CallbackFn );
    
    LINE_DELAY.OnAnalogChange.Add( new InputChangeHandlerWrapper( LINE_DELAY_OnChange_0, false ) );
    for( uint i = 0; i < 1000; i++ )
        DATAINSERT__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINSERT__DOLLAR___OnChange_1, false ) );
        
    INIT_TRIG.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_TRIG_OnPush_2, false ) );
    ENABLE.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_3, false ) );
    FILENAMEINSERT__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FILENAMEINSERT__DOLLAR___OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ST  = new L3_Tools.StringTools();
    
    
}

public UserModuleClass_L3_DATA_INITIALIZER_V1_2_05 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_31___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_32___Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint INIT_TRIG__DigitalInput__ = 1;
const uint USE_FILE_CHK__DigitalInput__ = 2;
const uint OVERRIDE_FILE_CHK__DigitalInput__ = 3;
const uint OUTPUT_FILE_PER_LINE__DigitalInput__ = 4;
const uint USE_INDEX_PREFIXING__DigitalInput__ = 5;
const uint SEND_FINALIZE_START__DigitalInput__ = 6;
const uint SEND_FINALIZE_END__DigitalInput__ = 7;
const uint LINE_DELAY__AnalogSerialInput__ = 0;
const uint FILENAMEINSERT__DOLLAR____AnalogSerialInput__ = 1;
const uint DATAINSERT__DOLLAR____AnalogSerialInput__ = 2;
const uint DONE_FB__DigitalOutput__ = 0;
const uint DONE_PULSE__DigitalOutput__ = 1;
const uint FAILED_FILE_READ__DigitalOutput__ = 2;
const uint FILE_READ_COMPLETE__DigitalOutput__ = 3;
const uint STATUS__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint DATASEND__DOLLAR____AnalogSerialOutput__ = 2;
const uint FILEFOLDER__DOLLAR____Parameter__ = 10;
const uint FILENAME__DOLLAR____Parameter__ = 11;
const uint FILELINEDELIMITER__DOLLAR____Parameter__ = 12;
const uint FILECUSTOMDELIMITER__DOLLAR____Parameter__ = 13;
const uint OPENCHAR__DOLLAR____Parameter__ = 14;
const uint LINEHEADER__DOLLAR____Parameter__ = 15;
const uint LINEHEADERDELIMITER__DOLLAR____Parameter__ = 16;
const uint INDEXINGPREFIX__DOLLAR____Parameter__ = 17;
const uint INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__ = 18;
const uint LINEDELIMITER__DOLLAR____Parameter__ = 19;
const uint CLOSECHAR__DOLLAR____Parameter__ = 20;
const uint FINALIZESTARTDATA__DOLLAR____Parameter__ = 21;
const uint FINALIZEENDDATA__DOLLAR____Parameter__ = 22;
const uint FINALIZEDELIMITER__DOLLAR____Parameter__ = 23;
const uint LINE_DELAY_IN_TICKS__Parameter__ = 24;
const uint END_DELAY__Parameter__ = 25;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort NVIDONEFB = 0;
            [SplusStructAttribute(1, false, true)]
            public CrestronString NVSCHK;
            
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
