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
using HSIB_Tools;

namespace UserModule_L3_DATA_INITIALIZER_V1_2_02
{
    public class UserModuleClass_L3_DATA_INITIALIZER_V1_2_02 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput INIT_TRIG;
        Crestron.Logos.SplusObjects.DigitalInput OUTPUT_FILE_PER_LINE;
        Crestron.Logos.SplusObjects.DigitalInput USE_INDEX_PREFIXING;
        Crestron.Logos.SplusObjects.DigitalInput SEND_FINALIZE_DATA;
        Crestron.Logos.SplusObjects.StringInput FILENAMEINSERT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DATAINSERT__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_PULSE;
        Crestron.Logos.SplusObjects.DigitalOutput FAILED_FILE_READ;
        Crestron.Logos.SplusObjects.StringOutput STATUS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DATASEND__DOLLAR__;
        UShortParameter HIGHEST_INDEX_USED;
        UShortParameter END_DELAY;
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
        StringParameter FINALIZEDATA__DOLLAR__;
        StringParameter FINALIZEDELIMITER__DOLLAR__;
        HSIB_Tools.TrimString TS;
        ushort IINDEXINGLENGTH = 0;
        ushort IDATAINITCOMPLETE = 0;
        ushort IINITTRIGBUFFERED = 0;
        CrestronString SDATATOSEND;
        CrestronString SFILELINEDELIMITER;
        CrestronString SFILELOCATION;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 219;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 219;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 220;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 229;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 229;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 231;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 232;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 233;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 235;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 235;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 236;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 233;
                } 
            
            __context__.SourceCodeLine = 238;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 239;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 239;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 241;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 242;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 243;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 245;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 245;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 246;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 247;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 248;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 243;
                } 
            
            __context__.SourceCodeLine = 251;
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
            
            
            __context__.SourceCodeLine = 259;
            STEMP1  .UpdateValue ( "module is not enabled"  ) ; 
            __context__.SourceCodeLine = 260;
            STEMP2  .UpdateValue ( "data init has not started"  ) ; 
            __context__.SourceCodeLine = 261;
            STEMP3  .UpdateValue ( "init trigger has not been propagated"  ) ; 
            __context__.SourceCodeLine = 263;
            if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 263;
                STEMP1  .UpdateValue ( "module is enabled"  ) ; 
                }
            
            __context__.SourceCodeLine = 264;
            if ( Functions.TestForTrue  ( ( IDATAINITCOMPLETE)  ) ) 
                {
                __context__.SourceCodeLine = 264;
                STEMP2  .UpdateValue ( "data init has completed"  ) ; 
                }
            
            __context__.SourceCodeLine = 265;
            if ( Functions.TestForTrue  ( ( IINITTRIGBUFFERED)  ) ) 
                {
                __context__.SourceCodeLine = 265;
                STEMP3  .UpdateValue ( "init trigger is armed, awaiting enable"  ) ; 
                }
            
            __context__.SourceCodeLine = 267;
            MakeString ( STATUS__DOLLAR__ , "{0} - {1}: {2}: {3}", LINEHEADER__DOLLAR__ , STEMP1 , STEMP2 , STEMP3 ) ; 
            
            }
            
        private CrestronString FGETLINEDATA (  SplusExecutionContext __context__, ushort IGUID , CrestronString SFILELINE ) 
            { 
            CrestronString SLOCALLINE;
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 275;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 277;
                MakeString ( SLOCALLINE , "{0}={1:d3}{2} {3}{4}", INDEXINGPREFIX__DOLLAR__ , (ushort)IGUID, INDEXINGPREFIXDELIMITER__DOLLAR__ , SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 278;
                IINDEXINGLENGTH = (ushort) ( ((Functions.Length( INDEXINGPREFIX__DOLLAR__  ) + Functions.Length( INDEXINGPREFIXDELIMITER__DOLLAR__  )) + 4) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 282;
                MakeString ( SLOCALLINE , "{0}{1}", SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 283;
                IINDEXINGLENGTH = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 286;
            return ( SLOCALLINE ) ; 
            
            }
            
        private short FPROCESSFILEDATA (  SplusExecutionContext __context__ ) 
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
            CrestronString SLOCALDATATOSEND;
            CrestronString SLOCALHEADER;
            CrestronString SLOCALLINE;
            CrestronString SFILELINE;
            SFILEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 45000, this );
            SFILEPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            SLOCALDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5000, this );
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 600, this );
            SFILELINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 600, this );
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 299;
            Trace( "\\\\______Starting Data Init List: {0} ______(file data)//", LINEHEADER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 300;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 302;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 304;
            MakeString ( SLOCALHEADER , "{0}{1}{2}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 305;
            SDATATOSEND  .UpdateValue ( SLOCALHEADER  ) ; 
            __context__.SourceCodeLine = 308;
            SFILEPATH  .UpdateValue ( SFILELOCATION  ) ; 
            __context__.SourceCodeLine = 309;
            Trace( "DataInitializer - {0}, sFilePath={1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
            __context__.SourceCodeLine = 312;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 314;
            SIERRFOUND = (short) ( FindFirstShared( SFILEPATH , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 316;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 318;
                Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
                __context__.SourceCodeLine = 319;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 320;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 323;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 325;
                Trace( "DataInitializer - {0}, file not found: {1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
                __context__.SourceCodeLine = 326;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 327;
                Functions.Pulse ( 10, FAILED_FILE_READ ) ; 
                __context__.SourceCodeLine = 328;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 333;
                Trace( "DataInitializer - {0}, file found: {1} ", LINEHEADER__DOLLAR__ , FILEINFO .  Name ) ; 
                __context__.SourceCodeLine = 335;
                SIERRFILEOPEN = (int) ( FileOpenShared( SFILEPATH ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 336;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEOPEN < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 339;
                    Trace( "DataInitializer - {0}, fileopenshared failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILEHANDLE, SFILEPATH ) ; 
                    __context__.SourceCodeLine = 340;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 341;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 347;
                    SIERRFILESEEK = (short) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) ) ; 
                    __context__.SourceCodeLine = 348;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILESEEK < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 351;
                        Trace( "DataInitializer - {0}, fileseek failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILESEEK, SFILEPATH ) ; 
                        __context__.SourceCodeLine = 352;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 352;
                            Trace( "DataInitializer - {0}, fileseek failed, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 353;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 353;
                            Trace( "DataInitializer - {0}, fileseek failed, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 354;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 357;
                    SIERRFILEREAD = (int) ( FileRead( (short)( SIERRFILEHANDLE ) , SFILEDATA , (ushort)( 45000 ) ) ) ; 
                    __context__.SourceCodeLine = 360;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 362;
                        Trace( "DataInitializer - siErrFileRead={0:d}", (int)SIERRFILEREAD) ; 
                        __context__.SourceCodeLine = 363;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 363;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 364;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 364;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 365;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 369;
                    while ( Functions.TestForTrue  ( ( Functions.Find( SFILELINEDELIMITER , SFILEDATA ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 371;
                        SFILELINE  .UpdateValue ( Functions.Remove ( SFILELINEDELIMITER , SFILEDATA )  ) ; 
                        __context__.SourceCodeLine = 372;
                        SFILELINE  .UpdateValue ( Functions.Left ( SFILELINE ,  (int) ( (Functions.Length( SFILELINE ) - Functions.Length( SFILELINEDELIMITER )) ) )  ) ; 
                        __context__.SourceCodeLine = 382;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "//" , SFILELINE ))  ) ) 
                            {
                            __context__.SourceCodeLine = 382;
                            continue ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 383;
                            SFILELINE  .UpdateValue ( TS . TrimThis (  SFILELINE  .ToSimplSharpString() )  ) ; 
                            }
                        
                        __context__.SourceCodeLine = 385;
                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SFILELINE ) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 385;
                            continue ; 
                            }
                        
                        __context__.SourceCodeLine = 388;
                        SLOCALLINE  .UpdateValue ( FGETLINEDATA (  __context__ , (ushort)( I ), SFILELINE)  ) ; 
                        __context__.SourceCodeLine = 390;
                        MakeString ( SDATATOSEND , "{0} {1}{2}", SLOCALHEADER , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 392;
                        if ( Functions.TestForTrue  ( ( OUTPUT_FILE_PER_LINE  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 392;
                            MakeString ( DATASEND__DOLLAR__ [ I] , "{0}", SDATATOSEND ) ; 
                            }
                        
                        __context__.SourceCodeLine = 393;
                        MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                        __context__.SourceCodeLine = 394;
                        Functions.Delay (  (int) ( 2 ) ) ; 
                        __context__.SourceCodeLine = 396;
                        I = (ushort) ( (I + 1) ) ; 
                        __context__.SourceCodeLine = 369;
                        } 
                    
                    __context__.SourceCodeLine = 399;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 403;
                        if ( Functions.TestForTrue  ( ( Functions.Not( IFILECLOSED ))  ) ) 
                            {
                            __context__.SourceCodeLine = 403;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                                {
                                __context__.SourceCodeLine = 403;
                                Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 404;
                        if ( Functions.TestForTrue  ( ( Functions.Not( IOPSCLOSED ))  ) ) 
                            {
                            __context__.SourceCodeLine = 404;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                {
                                __context__.SourceCodeLine = 404;
                                Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 405;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 407;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IFILECLOSED ) ) && Functions.TestForTrue ( Functions.Not( IOPSCLOSED ) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 407;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 409;
                            Trace( "DataInitializer - {0}, ending fileseek failed", LINEHEADER__DOLLAR__ ) ; 
                            __context__.SourceCodeLine = 410;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 412;
                    if ( Functions.TestForTrue  ( ( Functions.Not( IFILECLOSED ))  ) ) 
                        {
                        __context__.SourceCodeLine = 412;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 414;
                            Trace( "DataInitializer - {0}, ending fileclose, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            __context__.SourceCodeLine = 415;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 417;
                    if ( Functions.TestForTrue  ( ( Functions.Not( IOPSCLOSED ))  ) ) 
                        {
                        __context__.SourceCodeLine = 417;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 419;
                            Trace( "DataInitializer - {0}, ending endfileoperations, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            __context__.SourceCodeLine = 420;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        }
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 425;
            if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 427;
                MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 430;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_7__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_7___Callback ) ;
            
            return 0; // default return value (none specified in module)
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_7___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 432;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 433;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            __context__.SourceCodeLine = 434;
            IDATAINITCOMPLETE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 435;
            FUPDATESTATUS (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FRUN (  SplusExecutionContext __context__ ) 
        { 
        short SIERR = 0;
        
        
        __context__.SourceCodeLine = 443;
        SIERR = (short) ( FPROCESSFILEDATA( __context__ ) ) ; 
        __context__.SourceCodeLine = 444;
        if ( Functions.TestForTrue  ( ( SIERR)  ) ) 
            { 
            __context__.SourceCodeLine = 446;
            STATUS__DOLLAR__  .UpdateValue ( "failed file-read"  ) ; 
            __context__.SourceCodeLine = 447;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 448;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            } 
        
        
        }
        
    object DATAINSERT__DOLLAR___OnChange_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort J = 0;
            
            CrestronString SDATATOSEND;
            SDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1200, this );
            
            
            __context__.SourceCodeLine = 458;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 459;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 462;
            MakeString ( SDATATOSEND , "{0}{1}{2} ", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 468;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 470;
                MakeString ( SDATATOSEND , "{0}{1}={2:d3}{3} ", SDATATOSEND , INDEXINGPREFIX__DOLLAR__ , (ushort)I, INDEXINGPREFIXDELIMITER__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 478;
            MakeString ( SDATATOSEND , "{0}{1}{2}{3}", SDATATOSEND , DATAINSERT__DOLLAR__ [ I ] , LINEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 485;
            MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
            __context__.SourceCodeLine = 487;
            MakeString ( DATASEND__DOLLAR__ [ I] , "{0}", SDATATOSEND ) ; 
            __context__.SourceCodeLine = 489;
            if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 491;
                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_8__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_8___Callback ) ;
                } 
            
            __context__.SourceCodeLine = 497;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_9__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_9___Callback ) ;
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public void __SPLS_TMPVAR__WAITLABEL_8___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 493;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_9___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 499;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 500;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object INIT_TRIG_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 506;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 506;
            FRUN (  __context__  ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 509;
            IINITTRIGBUFFERED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 510;
            FUPDATESTATUS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 516;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINITTRIGBUFFERED ) && Functions.TestForTrue ( ENABLE  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 518;
            IINITTRIGBUFFERED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 519;
            FRUN (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 521;
            FUPDATESTATUS (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FILENAMEINSERT__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 526;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( FILENAMEINSERT__DOLLAR__ ) ))  ) ) 
            {
            __context__.SourceCodeLine = 526;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 527;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAMEINSERT__DOLLAR__  ) ; 
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
        
        __context__.SourceCodeLine = 540;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 542;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStrings( FILELINEDELIMITER__DOLLAR__  , "!!!!~~~~" ) ))  ) ) 
            {
            __context__.SourceCodeLine = 542;
            SFILELINEDELIMITER  .UpdateValue ( FILECUSTOMDELIMITER__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 543;
            SFILELINEDELIMITER  .UpdateValue ( FILELINEDELIMITER__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 545;
        if ( Functions.TestForTrue  ( ( Functions.Length( FILENAMEINSERT__DOLLAR__ ))  ) ) 
            {
            __context__.SourceCodeLine = 545;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAMEINSERT__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 546;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 548;
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
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    INIT_TRIG = new Crestron.Logos.SplusObjects.DigitalInput( INIT_TRIG__DigitalInput__, this );
    m_DigitalInputList.Add( INIT_TRIG__DigitalInput__, INIT_TRIG );
    
    OUTPUT_FILE_PER_LINE = new Crestron.Logos.SplusObjects.DigitalInput( OUTPUT_FILE_PER_LINE__DigitalInput__, this );
    m_DigitalInputList.Add( OUTPUT_FILE_PER_LINE__DigitalInput__, OUTPUT_FILE_PER_LINE );
    
    USE_INDEX_PREFIXING = new Crestron.Logos.SplusObjects.DigitalInput( USE_INDEX_PREFIXING__DigitalInput__, this );
    m_DigitalInputList.Add( USE_INDEX_PREFIXING__DigitalInput__, USE_INDEX_PREFIXING );
    
    SEND_FINALIZE_DATA = new Crestron.Logos.SplusObjects.DigitalInput( SEND_FINALIZE_DATA__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_FINALIZE_DATA__DigitalInput__, SEND_FINALIZE_DATA );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DONE_PULSE = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_PULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_PULSE__DigitalOutput__, DONE_PULSE );
    
    FAILED_FILE_READ = new Crestron.Logos.SplusObjects.DigitalOutput( FAILED_FILE_READ__DigitalOutput__, this );
    m_DigitalOutputList.Add( FAILED_FILE_READ__DigitalOutput__, FAILED_FILE_READ );
    
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
    
    HIGHEST_INDEX_USED = new UShortParameter( HIGHEST_INDEX_USED__Parameter__, this );
    m_ParameterList.Add( HIGHEST_INDEX_USED__Parameter__, HIGHEST_INDEX_USED );
    
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
    
    FINALIZEDATA__DOLLAR__ = new StringParameter( FINALIZEDATA__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FINALIZEDATA__DOLLAR____Parameter__, FINALIZEDATA__DOLLAR__ );
    
    FINALIZEDELIMITER__DOLLAR__ = new StringParameter( FINALIZEDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FINALIZEDELIMITER__DOLLAR____Parameter__, FINALIZEDELIMITER__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_7___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_7___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_8___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_8___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_9___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_9___CallbackFn );
    
    for( uint i = 0; i < 1000; i++ )
        DATAINSERT__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATAINSERT__DOLLAR___OnChange_0, false ) );
        
    INIT_TRIG.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_TRIG_OnPush_1, false ) );
    ENABLE.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_2, false ) );
    FILENAMEINSERT__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FILENAMEINSERT__DOLLAR___OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    TS  = new HSIB_Tools.TrimString();
    
    
}

public UserModuleClass_L3_DATA_INITIALIZER_V1_2_02 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_7___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_8___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_9___Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint INIT_TRIG__DigitalInput__ = 1;
const uint OUTPUT_FILE_PER_LINE__DigitalInput__ = 2;
const uint USE_INDEX_PREFIXING__DigitalInput__ = 3;
const uint SEND_FINALIZE_DATA__DigitalInput__ = 4;
const uint FILENAMEINSERT__DOLLAR____AnalogSerialInput__ = 0;
const uint DATAINSERT__DOLLAR____AnalogSerialInput__ = 1;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DONE_PULSE__DigitalOutput__ = 1;
const uint FAILED_FILE_READ__DigitalOutput__ = 2;
const uint STATUS__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint DATASEND__DOLLAR____AnalogSerialOutput__ = 2;
const uint HIGHEST_INDEX_USED__Parameter__ = 10;
const uint END_DELAY__Parameter__ = 11;
const uint FILEFOLDER__DOLLAR____Parameter__ = 12;
const uint FILENAME__DOLLAR____Parameter__ = 13;
const uint FILELINEDELIMITER__DOLLAR____Parameter__ = 14;
const uint FILECUSTOMDELIMITER__DOLLAR____Parameter__ = 15;
const uint OPENCHAR__DOLLAR____Parameter__ = 16;
const uint LINEHEADER__DOLLAR____Parameter__ = 17;
const uint LINEHEADERDELIMITER__DOLLAR____Parameter__ = 18;
const uint INDEXINGPREFIX__DOLLAR____Parameter__ = 19;
const uint INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__ = 20;
const uint LINEDELIMITER__DOLLAR____Parameter__ = 21;
const uint CLOSECHAR__DOLLAR____Parameter__ = 22;
const uint FINALIZEDATA__DOLLAR____Parameter__ = 23;
const uint FINALIZEDELIMITER__DOLLAR____Parameter__ = 24;

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
