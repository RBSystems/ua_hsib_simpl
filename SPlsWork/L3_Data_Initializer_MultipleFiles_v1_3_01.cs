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

namespace UserModule_L3_DATA_INITIALIZER_MULTIPLEFILES_V1_3_01
{
    public class UserModuleClass_L3_DATA_INITIALIZER_MULTIPLEFILES_V1_3_01 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput INIT_TRIG;
        Crestron.Logos.SplusObjects.DigitalInput USE_INDEX_PREFIXING;
        Crestron.Logos.SplusObjects.DigitalInput SEND_FINALIZE_DATA;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DONE_PULSE;
        Crestron.Logos.SplusObjects.StringOutput STATUS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        UShortParameter MAX_LINES_PER_SEND;
        UShortParameter MAX_BYTES_PER_SEND;
        UShortParameter END_DELAY;
        StringParameter FILEFOLDER__DOLLAR__;
        StringParameter FILELINEDELIMITER__DOLLAR__;
        StringParameter FILECUSTOMDELIMITER__DOLLAR__;
        StringParameter OPENCHAR__DOLLAR__;
        StringParameter LINEHEADER__DOLLAR__;
        StringParameter LINEHEADERDELIMITER__DOLLAR__;
        StringParameter FILEPREFIX__DOLLAR__;
        StringParameter FILEPREFIXDELIMITER__DOLLAR__;
        StringParameter INDEXINGPREFIX__DOLLAR__;
        StringParameter INDEXINGPREFIXDELIMITER__DOLLAR__;
        StringParameter LINEDELIMITER__DOLLAR__;
        StringParameter CLOSECHAR__DOLLAR__;
        StringParameter FINALIZEDATA__DOLLAR__;
        StringParameter FINALIZEDELIMITER__DOLLAR__;
        InOutArray<StringParameter> FILENAME__DOLLAR__;
        ushort IINDEXINGLENGTH = 0;
        ushort IDATAINITCOMPLETE = 0;
        ushort IINITTRIGBUFFERED = 0;
        CrestronString SDATATOSEND;
        CrestronString SFILELINEDELIMITER;
        CrestronString SFILELOCATION;
        private ushort FISCHARPRINTABLE (  SplusExecutionContext __context__, ushort ITEMP ) 
            { 
            
            __context__.SourceCodeLine = 217;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITEMP >= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITEMP <= 126 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 217;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 218;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString FTRIMWHITESPACE (  SplusExecutionContext __context__, CrestronString STEMP ) 
            { 
            ushort ITEMPC = 0;
            
            CrestronString SDATA;
            CrestronString STEMPC;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            STEMPC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 227;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( STEMP ) ))  ) ) 
                {
                __context__.SourceCodeLine = 227;
                return ( "" ) ; 
                }
            
            __context__.SourceCodeLine = 229;
            SDATA  .UpdateValue ( STEMP  ) ; 
            __context__.SourceCodeLine = 230;
            ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
            __context__.SourceCodeLine = 231;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 233;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 233;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 234;
                ITEMPC = (ushort) ( Functions.GetC( SDATA ) ) ; 
                __context__.SourceCodeLine = 231;
                } 
            
            __context__.SourceCodeLine = 236;
            SDATA  .UpdateValue ( Functions.Chr (  (int) ( ITEMPC ) ) + SDATA  ) ; 
            __context__.SourceCodeLine = 237;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SDATA ) <= 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 237;
                return ( SDATA ) ; 
                }
            
            __context__.SourceCodeLine = 239;
            STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 240;
            ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
            __context__.SourceCodeLine = 241;
            while ( Functions.TestForTrue  ( ( Functions.Not( FISCHARPRINTABLE( __context__ , (ushort)( ITEMPC ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 243;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SDATA ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 243;
                    return ( "" ) ; 
                    }
                
                __context__.SourceCodeLine = 244;
                SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 245;
                STEMPC  .UpdateValue ( Functions.Right ( SDATA ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 246;
                ITEMPC = (ushort) ( Functions.GetC( STEMPC ) ) ; 
                __context__.SourceCodeLine = 241;
                } 
            
            __context__.SourceCodeLine = 249;
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
            
            
            __context__.SourceCodeLine = 258;
            STEMP1  .UpdateValue ( "module is not enabled"  ) ; 
            __context__.SourceCodeLine = 259;
            STEMP2  .UpdateValue ( "data init has not started"  ) ; 
            __context__.SourceCodeLine = 260;
            STEMP3  .UpdateValue ( "init trigger has not been propagated"  ) ; 
            __context__.SourceCodeLine = 262;
            if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 262;
                STEMP1  .UpdateValue ( "module is enabled"  ) ; 
                }
            
            __context__.SourceCodeLine = 263;
            if ( Functions.TestForTrue  ( ( IDATAINITCOMPLETE)  ) ) 
                {
                __context__.SourceCodeLine = 263;
                STEMP2  .UpdateValue ( "data init has completed"  ) ; 
                }
            
            __context__.SourceCodeLine = 264;
            if ( Functions.TestForTrue  ( ( IINITTRIGBUFFERED)  ) ) 
                {
                __context__.SourceCodeLine = 264;
                STEMP3  .UpdateValue ( "init trigger is armed, awaiting enable"  ) ; 
                }
            
            __context__.SourceCodeLine = 266;
            MakeString ( STATUS__DOLLAR__ , "{0} - {1}: {2}: {3}", LINEHEADER__DOLLAR__ , STEMP1 , STEMP2 , STEMP3 ) ; 
            
            }
            
        private CrestronString FGETLINEDATA (  SplusExecutionContext __context__, ushort IGUID , CrestronString SFILELINE ) 
            { 
            CrestronString SLOCALLINE;
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            
            
            __context__.SourceCodeLine = 274;
            if ( Functions.TestForTrue  ( ( USE_INDEX_PREFIXING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 276;
                MakeString ( SLOCALLINE , "{0}{1:d3}{2} {3}{4}", INDEXINGPREFIX__DOLLAR__ , (ushort)IGUID, INDEXINGPREFIXDELIMITER__DOLLAR__ , SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 277;
                IINDEXINGLENGTH = (ushort) ( ((Functions.Length( INDEXINGPREFIX__DOLLAR__  ) + Functions.Length( INDEXINGPREFIXDELIMITER__DOLLAR__  )) + 4) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 281;
                MakeString ( SLOCALLINE , "{0}{1}", SFILELINE , LINEDELIMITER__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 282;
                IINDEXINGLENGTH = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 285;
            return ( SLOCALLINE ) ; 
            
            }
            
        private short FPROCESSFILEDATA (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort J = 0;
            ushort IFILEEND = 0;
            ushort INOMOREDELIMITERS = 0;
            ushort IFILEINDEX = 0;
            
            int SIFILEPOINTER = 0;
            
            short SIERRFILEHANDLE = 0;
            short SIERRFOUND = 0;
            short SIERRFILESEEK = 0;
            
            short SIERRFILEREAD = 0;
            short SIERRFILEOPEN = 0;
            
            CrestronString SFILEDATA;
            CrestronString SFILEDATAREMAINDER;
            CrestronString SFILEPATH;
            CrestronString SLOCALDATATOSEND;
            CrestronString SLOCALHEADER;
            CrestronString SLOCALLINE;
            CrestronString SFILELINE;
            CrestronString SFILEPATHTEMP;
            SFILEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50000, this );
            SFILEDATAREMAINDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
            SFILEPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            SLOCALDATATOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLOCALLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SFILELINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SFILEPATHTEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 298;
            Trace( "\\\\______Starting Data Init List: {0} ______(file data)//", LINEHEADER__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 299;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 302;
            Trace( "DataInitializer - {0}, sFilePath={1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
            __context__.SourceCodeLine = 303;
            Functions.Delay (  (int) ( END_DELAY  .Value ) ) ; 
            __context__.SourceCodeLine = 305;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IFILEINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IFILEINDEX  >= __FN_FORSTART_VAL__1) && (IFILEINDEX  <= __FN_FOREND_VAL__1) ) : ( (IFILEINDEX  <= __FN_FORSTART_VAL__1) && (IFILEINDEX  >= __FN_FOREND_VAL__1) ) ; IFILEINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 307;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( FILENAME__DOLLAR__[ IFILEINDEX ] ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.CompareStrings( FILENAME__DOLLAR__[ IFILEINDEX ] , "0d" ) != 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 309;
                    I = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 310;
                    J = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 313;
                    IFILEEND = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 314;
                    SIERRFOUND = (short) ( 0 ) ; 
                    __context__.SourceCodeLine = 315;
                    SIERRFILEOPEN = (short) ( 0 ) ; 
                    __context__.SourceCodeLine = 316;
                    INOMOREDELIMITERS = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 317;
                    SFILEDATA  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 318;
                    SFILELINE  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 321;
                    MakeString ( SLOCALHEADER , "{0}{1}{2}{3}{4:d2}{5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FILEPREFIX__DOLLAR__ , (ushort)IFILEINDEX, FILEPREFIXDELIMITER__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 322;
                    SDATATOSEND  .UpdateValue ( SLOCALHEADER  ) ; 
                    __context__.SourceCodeLine = 325;
                    StartFileOperations ( ) ; 
                    __context__.SourceCodeLine = 327;
                    SFILEPATH  .UpdateValue ( FILEFOLDER__DOLLAR__ + FILENAME__DOLLAR__ [ IFILEINDEX ]  ) ; 
                    __context__.SourceCodeLine = 329;
                    SIERRFOUND = (short) ( FindFirstShared( SFILEPATH , ref FILEINFO ) ) ; 
                    __context__.SourceCodeLine = 332;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 334;
                        Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
                        __context__.SourceCodeLine = 335;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 336;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 340;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 342;
                        SFILEPATHTEMP  .UpdateValue ( "/ROMDISK/USER/MACROS/" + FILENAME__DOLLAR__ [ IFILEINDEX ]  ) ; 
                        __context__.SourceCodeLine = 343;
                        SIERRFOUND = (short) ( FindFirstShared( SFILEPATHTEMP , ref FILEINFO ) ) ; 
                        __context__.SourceCodeLine = 346;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FindClose() < 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 348;
                            Trace( "DataInitializer - {0}, findclose failed, siErrFound={1:d}", LINEHEADER__DOLLAR__ , (short)SIERRFOUND) ; 
                            __context__.SourceCodeLine = 349;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 350;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 355;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIERRFOUND != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 357;
                        Trace( "DataInitializer - {0}, file not found: {1}", LINEHEADER__DOLLAR__ , SFILEPATH ) ; 
                        __context__.SourceCodeLine = 358;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 359;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 364;
                        Trace( "DataInitializer - {0}, file found: {1} ", LINEHEADER__DOLLAR__ , FILEINFO .  Name ) ; 
                        __context__.SourceCodeLine = 366;
                        SIERRFILEOPEN = (short) ( FileOpenShared( SFILEPATH ,(ushort) (0 | 16384) ) ) ; 
                        __context__.SourceCodeLine = 367;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEOPEN < 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 370;
                            Trace( "DataInitializer - {0}, fileopenshared failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILEHANDLE, SFILEPATH ) ; 
                            __context__.SourceCodeLine = 371;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 372;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 378;
                            SIERRFILESEEK = (short) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) ) ; 
                            __context__.SourceCodeLine = 379;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILESEEK < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 382;
                                Trace( "DataInitializer - {0}, fileseek failed: err code={1:d}, {2}", LINEHEADER__DOLLAR__ , (short)SIERRFILESEEK, SFILEPATH ) ; 
                                __context__.SourceCodeLine = 383;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 383;
                                    Trace( "DataInitializer - {0}, fileseek failed, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 384;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 384;
                                    Trace( "DataInitializer - {0}, fileseek failed, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 385;
                                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                } 
                            
                            __context__.SourceCodeLine = 387;
                            SIERRFILEREAD = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 389;
                            while ( Functions.TestForTrue  ( ( Functions.Not( IFILEEND ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 391;
                                SIERRFILEREAD = (short) ( FileRead( (short)( SIERRFILEHANDLE ) , SFILEDATA , (ushort)( 8096 ) ) ) ; 
                                __context__.SourceCodeLine = 393;
                                SIFILEPOINTER = (int) ( FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 1 ) ) ) ; 
                                __context__.SourceCodeLine = 394;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIFILEPOINTER >= FILEINFO.lSize ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 394;
                                    IFILEEND = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 396;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 398;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 398;
                                        Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 399;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 399;
                                        Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 400;
                                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 403;
                                SFILEDATA  .UpdateValue ( SFILEDATAREMAINDER + SFILEDATA  ) ; 
                                __context__.SourceCodeLine = 404;
                                SFILEDATAREMAINDER  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 406;
                                while ( Functions.TestForTrue  ( ( Functions.Length( SFILEDATA ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 408;
                                    if ( Functions.TestForTrue  ( ( Functions.Find( SFILELINEDELIMITER , SFILEDATA ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 411;
                                        SFILELINE  .UpdateValue ( Functions.Remove ( SFILELINEDELIMITER , SFILEDATA )  ) ; 
                                        __context__.SourceCodeLine = 412;
                                        SFILELINE  .UpdateValue ( Functions.Left ( SFILELINE ,  (int) ( (Functions.Length( SFILELINE ) - Functions.Length( SFILELINEDELIMITER )) ) )  ) ; 
                                        __context__.SourceCodeLine = 413;
                                        SFILELINE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , SFILELINE)  ) ; 
                                        __context__.SourceCodeLine = 414;
                                        if ( Functions.TestForTrue  ( ( Functions.Find( "//" , SFILELINE ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 416;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "//" , SFILELINE ) == 1))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 416;
                                                continue ; 
                                                }
                                            
                                            else 
                                                { 
                                                __context__.SourceCodeLine = 419;
                                                SFILELINE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , Functions.Left( SFILELINE , (int)( (Functions.Find( "//" , SFILELINE ) - 1) ) ))  ) ; 
                                                } 
                                            
                                            } 
                                        
                                        __context__.SourceCodeLine = 422;
                                        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Length( SFILELINE ) ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 422;
                                            continue ; 
                                            }
                                        
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 425;
                                        if ( Functions.TestForTrue  ( ( IFILEEND)  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 429;
                                            INOMOREDELIMITERS = (ushort) ( 1 ) ; 
                                            __context__.SourceCodeLine = 430;
                                            SFILELINE  .UpdateValue ( FTRIMWHITESPACE (  __context__ , SFILEDATA)  ) ; 
                                            __context__.SourceCodeLine = 431;
                                            SFILEDATA  .UpdateValue ( ""  ) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 436;
                                            SFILEDATAREMAINDER  .UpdateValue ( SFILEDATA  ) ; 
                                            __context__.SourceCodeLine = 437;
                                            SFILEDATA  .UpdateValue ( ""  ) ; 
                                            __context__.SourceCodeLine = 438;
                                            continue ; 
                                            } 
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 441;
                                    if ( Functions.TestForTrue  ( ( Functions.Length( SFILELINE ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 445;
                                        SLOCALLINE  .UpdateValue ( FGETLINEDATA (  __context__ , (ushort)( I ), SFILELINE)  ) ; 
                                        __context__.SourceCodeLine = 448;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (((Functions.Length( SDATATOSEND ) + Functions.Length( SLOCALLINE )) + Functions.Length( CLOSECHAR__DOLLAR__  )) + IINDEXINGLENGTH) >= MAX_BYTES_PER_SEND  .Value ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 450;
                                            MakeString ( SDATATOSEND , "{0}{1}", SDATATOSEND , CLOSECHAR__DOLLAR__ ) ; 
                                            __context__.SourceCodeLine = 451;
                                            MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                            __context__.SourceCodeLine = 452;
                                            MakeString ( SDATATOSEND , "{0} {1}", SLOCALHEADER , SLOCALLINE ) ; 
                                            __context__.SourceCodeLine = 453;
                                            if ( Functions.TestForTrue  ( ( IFILEEND)  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 455;
                                                MakeString ( TX__DOLLAR__ , "{0}{1}", SDATATOSEND , CLOSECHAR__DOLLAR__ ) ; 
                                                __context__.SourceCodeLine = 456;
                                                break ; 
                                                } 
                                            
                                            __context__.SourceCodeLine = 458;
                                            J = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 461;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (J == MAX_LINES_PER_SEND  .Value))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 463;
                                                MakeString ( SDATATOSEND , "{0} {1}{2}", SDATATOSEND , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                                                __context__.SourceCodeLine = 464;
                                                MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                                __context__.SourceCodeLine = 465;
                                                MakeString ( SDATATOSEND , "{0}", SLOCALHEADER ) ; 
                                                __context__.SourceCodeLine = 466;
                                                J = (ushort) ( 0 ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 469;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IFILEEND ) && Functions.TestForTrue ( INOMOREDELIMITERS )) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 471;
                                                    MakeString ( SDATATOSEND , "{0} {1}{2}", SDATATOSEND , SLOCALLINE , CLOSECHAR__DOLLAR__ ) ; 
                                                    __context__.SourceCodeLine = 472;
                                                    MakeString ( TX__DOLLAR__ , "{0}", SDATATOSEND ) ; 
                                                    __context__.SourceCodeLine = 473;
                                                    J = (ushort) ( 0 ) ; 
                                                    } 
                                                
                                                else 
                                                    { 
                                                    __context__.SourceCodeLine = 477;
                                                    MakeString ( SDATATOSEND , "{0} {1}", SDATATOSEND , SLOCALLINE ) ; 
                                                    } 
                                                
                                                }
                                            
                                            }
                                        
                                        __context__.SourceCodeLine = 481;
                                        I = (ushort) ( (I + 1) ) ; 
                                        __context__.SourceCodeLine = 482;
                                        J = (ushort) ( (J + 1) ) ; 
                                        } 
                                    
                                    __context__.SourceCodeLine = 406;
                                    } 
                                
                                __context__.SourceCodeLine = 389;
                                } 
                            
                            __context__.SourceCodeLine = 487;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIERRFILEREAD < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 491;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 491;
                                    Trace( "DataInitializer - {0}, siErrFileRead < 0, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 492;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 492;
                                    Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 493;
                                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 495;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileSeek( (short)( SIERRFILEHANDLE ) , (uint)( 0 ) , (ushort)( 0 ) ) != 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 497;
                                    Trace( "DataInitializer - {0}, ending fileseek failed", LINEHEADER__DOLLAR__ ) ; 
                                    __context__.SourceCodeLine = 498;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 498;
                                        Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 500;
                                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 502;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( SIERRFILEHANDLE ) ) != 0))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 504;
                                        Trace( "DataInitializer - {0}, ending fileclose, fileclose() failed", LINEHEADER__DOLLAR__ ) ; 
                                        __context__.SourceCodeLine = 505;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 505;
                                            Trace( "DataInitializer - {0}, siErrFileRead < 0, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 507;
                                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 509;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EndFileOperations() != 0))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 511;
                                            Trace( "DataInitializer - {0}, ending endfileoperations, endfileoperations() failed", LINEHEADER__DOLLAR__ ) ; 
                                            __context__.SourceCodeLine = 512;
                                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                                            } 
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            } 
                        
                        __context__.SourceCodeLine = 515;
                        Functions.Delay (  (int) ( 5 ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 518;
                    if ( Functions.TestForTrue  ( ( SEND_FINALIZE_DATA  .Value)  ) ) 
                        { 
                        __context__.SourceCodeLine = 520;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_33__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_33___Callback ) ;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 528;
                    Trace( "data_initializer_multipleFiles  {0}  - skipping index {1:d}", LINEHEADER__DOLLAR__ , (ushort)IFILEINDEX) ; 
                    } 
                
                __context__.SourceCodeLine = 305;
                } 
            
            __context__.SourceCodeLine = 532;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_34__" , END_DELAY  .Value , __SPLS_TMPVAR__WAITLABEL_34___Callback ) ;
            
            return 0; // default return value (none specified in module)
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_33___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 522;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2} {3}{4} {5}", OPENCHAR__DOLLAR__ , LINEHEADER__DOLLAR__ , LINEHEADERDELIMITER__DOLLAR__ , FINALIZEDATA__DOLLAR__ , FINALIZEDELIMITER__DOLLAR__ , CLOSECHAR__DOLLAR__ ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_34___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 534;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 535;
            Functions.Pulse ( 10, DONE_PULSE ) ; 
            __context__.SourceCodeLine = 536;
            IDATAINITCOMPLETE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 537;
            FUPDATESTATUS (  __context__  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FRUN (  SplusExecutionContext __context__ ) 
    { 
    short SIERR = 0;
    
    
    __context__.SourceCodeLine = 545;
    SIERR = (short) ( FPROCESSFILEDATA( __context__ ) ) ; 
    __context__.SourceCodeLine = 546;
    if ( Functions.TestForTrue  ( ( SIERR)  ) ) 
        { 
        __context__.SourceCodeLine = 548;
        STATUS__DOLLAR__  .UpdateValue ( "failed file-read"  ) ; 
        __context__.SourceCodeLine = 549;
        BUSY_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 550;
        Functions.Pulse ( 10, DONE_PULSE ) ; 
        } 
    
    
    }
    
object INIT_TRIG_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 556;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 556;
            FRUN (  __context__  ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 559;
            IINITTRIGBUFFERED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 560;
            FUPDATESTATUS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 566;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IINITTRIGBUFFERED ) && Functions.TestForTrue ( ENABLE  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 568;
            IINITTRIGBUFFERED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 569;
            FRUN (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 571;
            FUPDATESTATUS (  __context__  ) ; 
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
        
        __context__.SourceCodeLine = 585;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 587;
        if ( Functions.TestForTrue  ( ( Functions.Not( Functions.CompareStrings( FILELINEDELIMITER__DOLLAR__  , "!!!!~~~~" ) ))  ) ) 
            {
            __context__.SourceCodeLine = 587;
            SFILELINEDELIMITER  .UpdateValue ( FILECUSTOMDELIMITER__DOLLAR__  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 588;
            SFILELINEDELIMITER  .UpdateValue ( FILELINEDELIMITER__DOLLAR__  ) ; 
            }
        
        __context__.SourceCodeLine = 591;
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
    
    USE_INDEX_PREFIXING = new Crestron.Logos.SplusObjects.DigitalInput( USE_INDEX_PREFIXING__DigitalInput__, this );
    m_DigitalInputList.Add( USE_INDEX_PREFIXING__DigitalInput__, USE_INDEX_PREFIXING );
    
    SEND_FINALIZE_DATA = new Crestron.Logos.SplusObjects.DigitalInput( SEND_FINALIZE_DATA__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_FINALIZE_DATA__DigitalInput__, SEND_FINALIZE_DATA );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DONE_PULSE = new Crestron.Logos.SplusObjects.DigitalOutput( DONE_PULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( DONE_PULSE__DigitalOutput__, DONE_PULSE );
    
    STATUS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( STATUS__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( STATUS__DOLLAR____AnalogSerialOutput__, STATUS__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    MAX_LINES_PER_SEND = new UShortParameter( MAX_LINES_PER_SEND__Parameter__, this );
    m_ParameterList.Add( MAX_LINES_PER_SEND__Parameter__, MAX_LINES_PER_SEND );
    
    MAX_BYTES_PER_SEND = new UShortParameter( MAX_BYTES_PER_SEND__Parameter__, this );
    m_ParameterList.Add( MAX_BYTES_PER_SEND__Parameter__, MAX_BYTES_PER_SEND );
    
    END_DELAY = new UShortParameter( END_DELAY__Parameter__, this );
    m_ParameterList.Add( END_DELAY__Parameter__, END_DELAY );
    
    FILEFOLDER__DOLLAR__ = new StringParameter( FILEFOLDER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEFOLDER__DOLLAR____Parameter__, FILEFOLDER__DOLLAR__ );
    
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
    
    FILEPREFIX__DOLLAR__ = new StringParameter( FILEPREFIX__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEPREFIX__DOLLAR____Parameter__, FILEPREFIX__DOLLAR__ );
    
    FILEPREFIXDELIMITER__DOLLAR__ = new StringParameter( FILEPREFIXDELIMITER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEPREFIXDELIMITER__DOLLAR____Parameter__, FILEPREFIXDELIMITER__DOLLAR__ );
    
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
    
    FILENAME__DOLLAR__ = new InOutArray<StringParameter>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        FILENAME__DOLLAR__[i+1] = new StringParameter( FILENAME__DOLLAR____Parameter__ + i, FILENAME__DOLLAR____Parameter__, this );
        m_ParameterList.Add( FILENAME__DOLLAR____Parameter__ + i, FILENAME__DOLLAR__[i+1] );
    }
    
    __SPLS_TMPVAR__WAITLABEL_33___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_33___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_34___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_34___CallbackFn );
    
    INIT_TRIG.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_TRIG_OnPush_0, false ) );
    ENABLE.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_DATA_INITIALIZER_MULTIPLEFILES_V1_3_01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_33___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_34___Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint INIT_TRIG__DigitalInput__ = 1;
const uint USE_INDEX_PREFIXING__DigitalInput__ = 2;
const uint SEND_FINALIZE_DATA__DigitalInput__ = 3;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DONE_PULSE__DigitalOutput__ = 1;
const uint STATUS__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint MAX_LINES_PER_SEND__Parameter__ = 10;
const uint MAX_BYTES_PER_SEND__Parameter__ = 11;
const uint END_DELAY__Parameter__ = 12;
const uint FILEFOLDER__DOLLAR____Parameter__ = 13;
const uint FILELINEDELIMITER__DOLLAR____Parameter__ = 14;
const uint FILECUSTOMDELIMITER__DOLLAR____Parameter__ = 15;
const uint OPENCHAR__DOLLAR____Parameter__ = 16;
const uint LINEHEADER__DOLLAR____Parameter__ = 17;
const uint LINEHEADERDELIMITER__DOLLAR____Parameter__ = 18;
const uint FILEPREFIX__DOLLAR____Parameter__ = 19;
const uint FILEPREFIXDELIMITER__DOLLAR____Parameter__ = 20;
const uint INDEXINGPREFIX__DOLLAR____Parameter__ = 21;
const uint INDEXINGPREFIXDELIMITER__DOLLAR____Parameter__ = 22;
const uint LINEDELIMITER__DOLLAR____Parameter__ = 23;
const uint CLOSECHAR__DOLLAR____Parameter__ = 24;
const uint FINALIZEDATA__DOLLAR____Parameter__ = 25;
const uint FINALIZEDELIMITER__DOLLAR____Parameter__ = 26;
const uint FILENAME__DOLLAR____Parameter__ = 27;

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
