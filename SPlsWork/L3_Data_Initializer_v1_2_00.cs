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

namespace UserModule_L3_DATA_INITIALIZER_V1_2_00
{
    public class UserModuleClass_L3_DATA_INITIALIZER_V1_2_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput INIT_TRIG;
        Crestron.Logos.SplusObjects.DigitalInput USE_FILE_READ;
        Crestron.Logos.SplusObjects.DigitalInput OUTPUT_FILE_PER_LINE;
        Crestron.Logos.SplusObjects.DigitalInput USE_INDEX_PREFIXING;
        Crestron.Logos.SplusObjects.DigitalInput SEND_FINALIZE_DATA;
        Crestron.Logos.SplusObjects.StringInput FILENAMEINSERT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DATAINSERT__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_PULSE;
        Crestron.Logos.SplusObjects.StringOutput STATUS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DATASEND__DOLLAR__;
        UShortParameter HIGHEST_INDEX_USED;
        UShortParameter MAX_LINES_PER_SEND;
        UShortParameter MAX_BYTES_PER_SEND;
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
        InOutArray<StringParameter> DATA__DOLLAR__;
        ushort IINDEXINGLENGTH = 0;
        ushort IDATAINITCOMPLETE = 0;
        ushort IINITTRIGBUFFERED = 0;
        CrestronString SDATATOSEND;
        CrestronString SFILELINEDELIMITER;
        CrestronString SFILELOCATION;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 213;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 213;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 214;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 223;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 223;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 225;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 226;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 227;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 229;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 229;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 230;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 227;
                } 
            
            __context__.SourceCodeLine = 232;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 233;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 233;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 235;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 236;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 237;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 239;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 239;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 240;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 241;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 242;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 237;
                } 
            
            __context__.SourceCodeLine = 245;
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
            
            
            __context__.SourceCodeLine = 253;
            STEMP1  .UpdateValue ( "module is not enabled"  ) ; 
            __context__.SourceCodeLine = 254;
            STEMP2  .UpdateValue ( "data init has not started"  ) ; 
            __context__.SourceCodeLine = 255;
            STEMP3  .UpdateValue ( "init trigger has not been propagated"  ) ; 
            __context__.SourceCodeLine = 257;
            if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 257;
                STEMP1  .UpdateValue ( "module is enabled"  ) ; 
                }
            
            __context__.SourceCodeLine = 258;
            if ( Functions.TestForTrue  ( ( IDATAINITCOMPLETE)  ) ) 
                {
                __context__.SourceCodeLine = 258;
                STEMP2  .UpdateValue ( "data init has completed"  ) ; 
                }
            
            __context__.SourceCodeLine = 259;
            if ( Functions.TestForTrue  ( ( IINITTRIGBUFFERED)  ) ) 
                {
                __context__.SourceCodeLine = 259;
                STEMP3  .UpdateValue ( "init trigger is armed, awaiting enable"  ) ; 
                }
            
            __context__.SourceCodeLine = 261;
            MakeString ( STATUS__DOLLAR__ , "{0} - {1}: {2}: {3}", LINEHEADER__DOLLAR__ , STEMP1 , STEMP2 , STEMP3 ) ; 
            
            }
            
        private CrestronString FGETLINEDATA (  SplusExecutionContext __context__, ushort IGUID , CrestronString SFILELINE ) 
            { 
            CrestronString SLOCALLINE;
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 269;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 271;
                MakeString ( SLOCALLINE , "{0}={1:d3}{2} {3}{4}", INDEXINGPREFIX__DOLLAR__ , (ushort)IGUID, INDEXINGPREFIXDELIMITER__DOLLAR__ , SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 272;
                IINDEXINGLENGTH = (ushort) ( ((Functions.Length( INDEXINGPREFIX__DOLLAR__  ) + Functions.Length( INDEXINGPREFIXDELIMITER__DOLLAR__  )) + 4) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 276;
                MakeString ( SLOCALLINE , "{0}{1}", SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 277;
                IINDEXINGLENGTH = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 280;
            return ( SLOCALLINE ) ; 
            
            }
            
        private void FPROCESSLOCALDATA (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            CrestronString SLOCALDATATOSEND;
            CrestronString SLOCALHEADER;
            CrestronString SLOCALLINE;
            SLOCALDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            
            __context__.SourceCodeLine = 288;
            Trace( "\\\\______Starting Data Init List: {0} (local data)______//", LINEHEADER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 289;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 291;
            Functions.Delay (  (int) ( END_DELAY  .Value ) ) ; 
            __context__.SourceCodeLine = 293;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 294;
            J = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 297;
            MakeString ( SLOCALHEADER , "{0}{1}{2}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 298;
            SDATATOSEND  .UpdateValue ( SLOCALHEADER  ) ; 
            __context__.SourceCodeLine = 301;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I <= HIGHEST_INDEX_USED  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 303;
                SLOCALLINE  .UpdateValue ( FGETLINEDATA (  __context__ , (ushort)( I ), DATA__DOLLAR__[ I ])  ) ; 
                __context__.SourceCodeLine = 306;
                MakeString ( SDATATOSEND , "{0} {1}", SDATATOSEND , SLOCALLINE ) ; 
                __context__.SourceCodeLine = 308;
                if ( Functions.TestForTrue  ( ( OUTPUT_FILE_PER_LINE  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 308;
                    MakeString ( DATASEND__DOLLAR__ [ I] , "{0} {1}{2}", SLOCALHEADER , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 313;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (((Functions.Length( SDATATOSEND ) + Functions.Length( DATA__DOLLAR__[ Functions.Min( (I + 1) , 1000 ) ] )) + Functions.Length( CLOSECHAR__DOLLAR__  )) + IINDEXINGLENGTH) >= MAX_BYTES_PER_SEND  .Value ) ) || Functions.TestForTrue ( Functions.BoolToInt (I == HIGHEST_INDEX_USED  .Value) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (J == MAX_LINES_PER_SEND  .Value) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 319;
                    MakeString ( SDATATOSEND , "{0}{1}", SDATATOSEND , CLOSECHAR__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 320;
                    MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                    __context__.SourceCodeLine = 323;
                    J = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 325;
                    SDATATOSEND  .UpdateValue ( SLOCALHEADER  ) ; 
                    __context__.SourceCodeLine = 326;
                    Functions.Delay (  (int) ( 2 ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 329;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 330;
                J = (ushort) ( (J + 1) ) ; 
                __context__.SourceCodeLine = 301;
                } 
            
            __context__.SourceCodeLine = 333;
            if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 335;
                MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 338;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_36__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_36___Callback ) ;
            
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_36___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 340;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 341;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            __context__.SourceCodeLine = 342;
            IDATAINITCOMPLETE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 343;
            FUPDATESTATUS (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private short FPROCESSFILEDATA (  SplusExecutionContext __context__ ) 
        { 
        ushort I = 0;
        ushort J = 0;
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
        CrestronString SFILEDATAREMAINDER;
        CrestronString SFILEPATH;
        CrestronString SLOCALDATATOSEND;
        CrestronString SLOCALHEADER;
        CrestronString SLOCALLINE;
        CrestronString SFILELINE;
        SFILEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 58000, this );
        SFILEDATAREMAINDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
        SFILEPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
        SLOCALDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        SLOCALHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        SFILELINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        FILE_INFO FILEINFO;
        FILEINFO  = new FILE_INFO();
        FILEINFO .PopulateDefaults();
        
        
        __context__.SourceCodeLine = 357;
        Trace( "\\\\______Starting Data Init List: {0} ______(file data)//", LINEHEADER__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 358;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 360;
        I = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 361;
        J = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 363;
        MakeString ( SLOCALHEADER , "{0}{1}{2}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 364;
        SDATATOSEND  .UpdateValue ( SLOCALHEADER  ) ; 
        __context__.SourceCodeLine = 367;
        SFILEPATH  .UpdateValue ( SFILELOCATION  ) ; 
        __context__.SourceCodeLine = 368;
        Trace( "DataInitializer - {0}, sFilePath={1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
        __context__.SourceCodeLine = 369;
        Functions.Delay (  (int) ( END_DELAY  .Value ) ) ; 
        __context__.SourceCodeLine = 372;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 374;
        SIERRFOUND = (short) ( FindFirstShared( SFILEPATH , ref FILEINFO ) ) ; 
        __context__.SourceCodeLine = 376;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 378;
            Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
            __context__.SourceCodeLine = 379;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 380;
            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
            } 
        
        __context__.SourceCodeLine = 383;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 385;
            Trace( "DataInitializer - {0}, file not found: {1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
            __context__.SourceCodeLine = 386;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 387;
            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 392;
            Trace( "DataInitializer - {0}, file found: {1} ", LINEHEADER__DOLLAR__ , FILEINFO .  Name ) ; 
            __context__.SourceCodeLine = 394;
            SIERRFILEOPEN = (int) ( FileOpenShared( SFILEPATH ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 395;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEOPEN < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 398;
                Trace( "DataInitializer - {0}, fileopenshared failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILEHANDLE, SFILEPATH ) ; 
                __context__.SourceCodeLine = 399;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 400;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 406;
                SIERRFILESEEK = (short) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) ) ; 
                __context__.SourceCodeLine = 407;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILESEEK < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 410;
                    Trace( "DataInitializer - {0}, fileseek failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILESEEK, SFILEPATH ) ; 
                    __context__.SourceCodeLine = 411;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 411;
                        Trace( "DataInitializer - {0}, fileseek failed, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 412;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 412;
                        Trace( "DataInitializer - {0}, fileseek failed, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 413;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 415;
                SIERRFILEREAD = (int) ( 0 ) ; 
                __context__.SourceCodeLine = 417;
                while ( Functions.TestForTrue  ( ( Functions.Not( IFILEEND ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 419;
                    SIERRFILEREAD = (int) ( FileRead( (short)( SIERRFILEHANDLE ) , SFILEDATA , (ushort)( 58000 ) ) ) ; 
                    __context__.SourceCodeLine = 420;
                    SIFILEPOINTER = (int) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 1 ) ) ) ; 
                    __context__.SourceCodeLine = 421;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIFILEPOINTER >= FILEINFO.lSize ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 423;
                        IFILEEND = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 424;
                        Trace( "DataInitializer - found end of file, closing file") ; 
                        __context__.SourceCodeLine = 425;
                        SIERRFILECLOSE = (int) ( FileClose( (short)( SIERRFILEHANDLE ) ) ) ; 
                        __context__.SourceCodeLine = 426;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFILECLOSE != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 428;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            __context__.SourceCodeLine = 429;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 431;
                            IFILECLOSED = (ushort) ( 1 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 433;
                        SIERRENDFILEOPS = (int) ( EndFileOperations() ) ; 
                        __context__.SourceCodeLine = 435;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRENDFILEOPS != 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 437;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            __context__.SourceCodeLine = 438;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 440;
                            IOPSCLOSED = (ushort) ( 1 ) ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 442;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 444;
                        Trace( "DataInitializer - siErrFileRead={0:d}", (int)SIERRFILEREAD) ; 
                        __context__.SourceCodeLine = 445;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 445;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 446;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 446;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 447;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 450;
                    SFILEDATA  .UpdateValue ( SFILEDATAREMAINDER + SFILEDATA  ) ; 
                    __context__.SourceCodeLine = 451;
                    SFILEDATAREMAINDER  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 453;
                    while ( Functions.TestForTrue  ( ( Functions.Length( SFILEDATA ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 455;
                        if ( Functions.TestForTrue  ( ( Functions.Find( SFILELINEDELIMITER , SFILEDATA ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 458;
                            SFILELINE  .UpdateValue ( Functions.Remove ( SFILELINEDELIMITER , SFILEDATA )  ) ; 
                            __context__.SourceCodeLine = 459;
                            SFILELINE  .UpdateValue ( Functions.Left ( SFILELINE ,  (int) ( (Functions.Length( SFILELINE ) - Functions.Length( SFILELINEDELIMITER )) ) )  ) ; 
                            __context__.SourceCodeLine = 460;
                            SFILELINE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , SFILELINE)  ) ; 
                            __context__.SourceCodeLine = 461;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "//" , SFILELINE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 463;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "//" , SFILELINE ) == 1))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 463;
                                    continue ; 
                                    }
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 466;
                                    SFILELINE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( SFILELINE , (int)( (Functions.Find( "//" , SFILELINE ) - 1) ) ))  ) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 469;
                            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SFILELINE ) ))  ) ) 
                                {
                                __context__.SourceCodeLine = 469;
                                continue ; 
                                }
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 472;
                            if ( Functions.TestForTrue  ( ( IFILEEND)  ) ) 
                                { 
                                __context__.SourceCodeLine = 474;
                                INOMOREDELIMITERS = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 475;
                                SFILELINE  .UpdateValue ( Functions.Remove ( Functions.Length( SFILEDATA ), SFILEDATA )  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 479;
                                SFILEDATAREMAINDER  .UpdateValue ( SFILEDATA  ) ; 
                                __context__.SourceCodeLine = 480;
                                SFILEDATA  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 481;
                                continue ; 
                                } 
                            
                            }
                        
                        __context__.SourceCodeLine = 484;
                        if ( Functions.TestForTrue  ( ( Functions.Length( SFILELINE ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 486;
                            SLOCALLINE  .UpdateValue ( FGETLINEDATA (  __context__ , (ushort)( I ), SFILELINE)  ) ; 
                            __context__.SourceCodeLine = 488;
                            if ( Functions.TestForTrue  ( ( OUTPUT_FILE_PER_LINE  .Value)  ) ) 
                                {
                                __context__.SourceCodeLine = 488;
                                MakeString ( DATASEND__DOLLAR__ [ I] , "{0} {1}{2}", SLOCALHEADER , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                                }
                            
                            __context__.SourceCodeLine = 492;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (((Functions.Length( SDATATOSEND ) + Functions.Length( SLOCALLINE )) + Functions.Length( CLOSECHAR__DOLLAR__  )) + IINDEXINGLENGTH) >= MAX_BYTES_PER_SEND  .Value ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 494;
                                MakeString ( SDATATOSEND , "{0}{1}", SDATATOSEND , CLOSECHAR__DOLLAR__ ) ; 
                                __context__.SourceCodeLine = 495;
                                MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                __context__.SourceCodeLine = 496;
                                MakeString ( SDATATOSEND , "{0} {1}", SLOCALHEADER , SLOCALLINE ) ; 
                                __context__.SourceCodeLine = 497;
                                J = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 498;
                                Functions.Delay (  (int) ( 5 ) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 501;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (J == MAX_LINES_PER_SEND  .Value))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 503;
                                    MakeString ( SDATATOSEND , "{0} {1}{2}", SDATATOSEND , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                                    __context__.SourceCodeLine = 504;
                                    MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                    __context__.SourceCodeLine = 505;
                                    MakeString ( SDATATOSEND , "{0}", SLOCALHEADER ) ; 
                                    __context__.SourceCodeLine = 506;
                                    J = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 507;
                                    Functions.Delay (  (int) ( 5 ) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 510;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IFILEEND ) && Functions.TestForTrue ( INOMOREDELIMITERS )) ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 512;
                                        MakeString ( SDATATOSEND , "{0} {1}{2}", SDATATOSEND , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                                        __context__.SourceCodeLine = 513;
                                        MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                        __context__.SourceCodeLine = 514;
                                        J = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 515;
                                        Functions.Delay (  (int) ( 5 ) ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 519;
                                        MakeString ( SDATATOSEND , "{0} {1}", SDATATOSEND , SLOCALLINE ) ; 
                                        } 
                                    
                                    }
                                
                                }
                            
                            __context__.SourceCodeLine = 522;
                            I = (ushort) ( (I + 1) ) ; 
                            __context__.SourceCodeLine = 523;
                            J = (ushort) ( (J + 1) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 453;
                        } 
                    
                    __context__.SourceCodeLine = 417;
                    } 
                
                __context__.SourceCodeLine = 528;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 532;
                    if ( Functions.TestForTrue  ( ( Functions.Not( IFILECLOSED ))  ) ) 
                        {
                        __context__.SourceCodeLine = 532;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 532;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 533;
                    if ( Functions.TestForTrue  ( ( Functions.Not( IOPSCLOSED ))  ) ) 
                        {
                        __context__.SourceCodeLine = 533;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 533;
                            Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 534;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 536;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IFILECLOSED ) ) && Functions.TestForTrue ( Functions.Not( IOPSCLOSED ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 536;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 538;
                        Trace( "DataInitializer - {0}, ending fileseek failed", LINEHEADER__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 539;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 541;
                if ( Functions.TestForTrue  ( ( Functions.Not( IFILECLOSED ))  ) ) 
                    {
                    __context__.SourceCodeLine = 541;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 543;
                        Trace( "DataInitializer - {0}, ending fileclose, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 544;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 546;
                if ( Functions.TestForTrue  ( ( Functions.Not( IOPSCLOSED ))  ) ) 
                    {
                    __context__.SourceCodeLine = 546;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 548;
                        Trace( "DataInitializer - {0}, ending endfileoperations, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 549;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    }
                
                } 
            
            } 
        
        __context__.SourceCodeLine = 554;
        if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 556;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            } 
        
        __context__.SourceCodeLine = 559;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_37__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_37___Callback ) ;
        
        return 0; // default return value (none specified in module)
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_37___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 561;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 562;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            __context__.SourceCodeLine = 563;
            IDATAINITCOMPLETE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 564;
            FUPDATESTATUS (  __context__  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FRUN (  SplusExecutionContext __context__ ) 
    { 
    short SIERR = 0;
    
    
    __context__.SourceCodeLine = 572;
    if ( Functions.TestForTrue  ( ( Functions.Not( USE_FILE_READ  .Value ))  ) ) 
        {
        __context__.SourceCodeLine = 572;
        FPROCESSLOCALDATA (  __context__  ) ; 
        }
    
    else 
        { 
        __context__.SourceCodeLine = 575;
        SIERR = (short) ( FPROCESSFILEDATA( __context__ ) ) ; 
        __context__.SourceCodeLine = 576;
        if ( Functions.TestForTrue  ( ( SIERR)  ) ) 
            { 
            __context__.SourceCodeLine = 578;
            STATUS__DOLLAR__  .UpdateValue ( "failed file-read"  ) ; 
            __context__.SourceCodeLine = 579;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 580;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            } 
        
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
        
        
        __context__.SourceCodeLine = 592;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 593;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 596;
        MakeString ( SDATATOSEND , "{0}{1}{2} ", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 602;
        if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 604;
            MakeString ( SDATATOSEND , "{0}{1}={2:d3}{3} ", SDATATOSEND , INDEXINGPREFIX__DOLLAR__ , (ushort)I, INDEXINGPREFIXDELIMITER__DOLLAR__ ) ; 
            } 
        
        __context__.SourceCodeLine = 612;
        MakeString ( SDATATOSEND , "{0}{1}{2}{3}", SDATATOSEND , DATAINSERT__DOLLAR__ [ I ] , LINEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 619;
        MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
        __context__.SourceCodeLine = 621;
        MakeString ( DATASEND__DOLLAR__ [ I] , "{0}", SDATATOSEND ) ; 
        __context__.SourceCodeLine = 623;
        if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 625;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_38__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_38___Callback ) ;
            } 
        
        __context__.SourceCodeLine = 631;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_39__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_39___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_38___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 627;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_39___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 633;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 634;
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
        
        __context__.SourceCodeLine = 640;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 640;
            FRUN (  __context__  ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 643;
            IINITTRIGBUFFERED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 644;
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
        
        __context__.SourceCodeLine = 650;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINITTRIGBUFFERED ) && Functions.TestForTrue ( ENABLE  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 652;
            IINITTRIGBUFFERED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 653;
            FRUN (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 655;
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
        
        __context__.SourceCodeLine = 660;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( FILENAMEINSERT__DOLLAR__ ) ))  ) ) 
            {
            __context__.SourceCodeLine = 660;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 661;
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
        
        __context__.SourceCodeLine = 674;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 676;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStrings( FILELINEDELIMITER__DOLLAR__  , "!!!!~~~~" ) ))  ) ) 
            {
            __context__.SourceCodeLine = 676;
            SFILELINEDELIMITER  .UpdateValue ( FILECUSTOMDELIMITER__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 677;
            SFILELINEDELIMITER  .UpdateValue ( FILELINEDELIMITER__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 679;
        if ( Functions.TestForTrue  ( ( Functions.Length( FILENAMEINSERT__DOLLAR__ ))  ) ) 
            {
            __context__.SourceCodeLine = 679;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAMEINSERT__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 680;
            SFILELOCATION  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 682;
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
    
    USE_FILE_READ = new Crestron.Logos.SplusObjects.DigitalInput( USE_FILE_READ__DigitalInput__, this );
    m_DigitalInputList.Add( USE_FILE_READ__DigitalInput__, USE_FILE_READ );
    
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
    
    MAX_LINES_PER_SEND = new UShortParameter( MAX_LINES_PER_SEND__Parameter__, this );
    m_ParameterList.Add( MAX_LINES_PER_SEND__Parameter__, MAX_LINES_PER_SEND );
    
    MAX_BYTES_PER_SEND = new UShortParameter( MAX_BYTES_PER_SEND__Parameter__, this );
    m_ParameterList.Add( MAX_BYTES_PER_SEND__Parameter__, MAX_BYTES_PER_SEND );
    
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
    
    DATA__DOLLAR__ = new InOutArray<StringParameter>( 1000, this );
    for( uint i = 0; i < 1000; i++ )
    {
        DATA__DOLLAR__[i+1] = new StringParameter( DATA__DOLLAR____Parameter__ + i, DATA__DOLLAR____Parameter__, this );
        m_ParameterList.Add( DATA__DOLLAR____Parameter__ + i, DATA__DOLLAR__[i+1] );
    }
    
    __SPLS_TMPVAR__WAITLABEL_36___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_36___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_37___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_37___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_38___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_38___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_39___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_39___CallbackFn );
    
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
    
    
}

public UserModuleClass_L3_DATA_INITIALIZER_V1_2_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_36___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_37___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_38___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_39___Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint INIT_TRIG__DigitalInput__ = 1;
const uint USE_FILE_READ__DigitalInput__ = 2;
const uint OUTPUT_FILE_PER_LINE__DigitalInput__ = 3;
const uint USE_INDEX_PREFIXING__DigitalInput__ = 4;
const uint SEND_FINALIZE_DATA__DigitalInput__ = 5;
const uint FILENAMEINSERT__DOLLAR____AnalogSerialInput__ = 0;
const uint DATAINSERT__DOLLAR____AnalogSerialInput__ = 1;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DONE_PULSE__DigitalOutput__ = 1;
const uint STATUS__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint DATASEND__DOLLAR____AnalogSerialOutput__ = 2;
const uint HIGHEST_INDEX_USED__Parameter__ = 10;
const uint MAX_LINES_PER_SEND__Parameter__ = 11;
const uint MAX_BYTES_PER_SEND__Parameter__ = 12;
const uint END_DELAY__Parameter__ = 13;
const uint FILEFOLDER__DOLLAR____Parameter__ = 14;
const uint FILENAME__DOLLAR____Parameter__ = 15;
const uint FILELINEDELIMITER__DOLLAR____Parameter__ = 16;
const uint FILECUSTOMDELIMITER__DOLLAR____Parameter__ = 17;
const uint OPENCHAR__DOLLAR____Parameter__ = 18;
const uint LINEHEADER__DOLLAR____Parameter__ = 19;
const uint LINEHEADERDELIMITER__DOLLAR____Parameter__ = 20;
const uint INDEXINGPREFIX__DOLLAR____Parameter__ = 21;
const uint INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__ = 22;
const uint LINEDELIMITER__DOLLAR____Parameter__ = 23;
const uint CLOSECHAR__DOLLAR____Parameter__ = 24;
const uint FINALIZEDATA__DOLLAR____Parameter__ = 25;
const uint FINALIZEDELIMITER__DOLLAR____Parameter__ = 26;
const uint DATA__DOLLAR____Parameter__ = 27;

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
