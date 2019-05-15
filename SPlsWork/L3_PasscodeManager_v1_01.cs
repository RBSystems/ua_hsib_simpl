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

namespace UserModule_L3_PASSCODEMANAGER_V1_01
{
    public class UserModuleClass_L3_PASSCODEMANAGER_V1_01 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENDSESSION;
        Crestron.Logos.SplusObjects.DigitalInput ENTER;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.DigitalInput CASCADE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> NUM;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SAVE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> INSERTCODE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput INSESSIONFB;
        Crestron.Logos.SplusObjects.DigitalOutput PASSPULSE;
        Crestron.Logos.SplusObjects.DigitalOutput DECLINEPULSE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LEVELFB;
        Crestron.Logos.SplusObjects.StringOutput NUMERIC__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput HIDDEN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput USERDIRECTIVE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput ADMINDIRECTIVE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> EXPORTCODE__DOLLAR__;
        InOutArray<StringParameter> CODE__DOLLAR__;
        ushort IERR = 0;
        ushort IINSESSION = 0;
        ushort ICASCADE = 0;
        CrestronString SCURRENT;
        private void FUSER (  SplusExecutionContext __context__, CrestronString SUSER ) 
            { 
            
            __context__.SourceCodeLine = 122;
            MakeString ( USERDIRECTIVE__DOLLAR__ , "{0}", SUSER ) ; 
            __context__.SourceCodeLine = 124;
            CreateWait ( "WUSER" , 400 , WUSER_Callback ) ;
            
            }
            
        public void WUSER_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 126;
            USERDIRECTIVE__DOLLAR__  .UpdateValue ( ""  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FADMIN (  SplusExecutionContext __context__, CrestronString SADMIN ) 
        { 
        
        __context__.SourceCodeLine = 132;
        MakeString ( ADMINDIRECTIVE__DOLLAR__ , "{0}", SADMIN ) ; 
        __context__.SourceCodeLine = 134;
        CreateWait ( "WADMIN" , 400 , WADMIN_Callback ) ;
        
        }
        
    public void WADMIN_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 136;
            ADMINDIRECTIVE__DOLLAR__  .UpdateValue ( ""  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FCANCEL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 142;
    CancelWait ( "WUSER" ) ; 
    __context__.SourceCodeLine = 143;
    CancelWait ( "WADMIN" ) ; 
    __context__.SourceCodeLine = 144;
    USERDIRECTIVE__DOLLAR__  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 145;
    ADMINDIRECTIVE__DOLLAR__  .UpdateValue ( ""  ) ; 
    
    }
    
private void FCASCADE (  SplusExecutionContext __context__, ushort ITYPE ) 
    { 
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 153;
    if ( Functions.TestForTrue  ( ( ITYPE)  ) ) 
        { 
        __context__.SourceCodeLine = 155;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)10; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 157;
            LEVELFB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 155;
            } 
        
        __context__.SourceCodeLine = 159;
        if ( Functions.TestForTrue  ( ( IINSESSION)  ) ) 
            { 
            __context__.SourceCodeLine = 161;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)IINSESSION; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 163;
                LEVELFB [ I]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 161;
                } 
            
            } 
        
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 169;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)10; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 171;
            LEVELFB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 169;
            } 
        
        __context__.SourceCodeLine = 173;
        if ( Functions.TestForTrue  ( ( IINSESSION)  ) ) 
            { 
            __context__.SourceCodeLine = 175;
            LEVELFB [ IINSESSION]  .Value = (ushort) ( 1 ) ; 
            } 
        
        } 
    
    
    }
    
private void FCLEAR (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 182;
    SCURRENT  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 183;
    NUMERIC__DOLLAR__  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 184;
    HIDDEN__DOLLAR__  .UpdateValue ( ""  ) ; 
    
    }
    
object ENDSESSION_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 194;
        FCANCEL (  __context__  ) ; 
        __context__.SourceCodeLine = 195;
        IINSESSION = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 196;
        FCASCADE (  __context__ , (ushort)( ICASCADE )) ; 
        __context__.SourceCodeLine = 197;
        FCLEAR (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 202;
        FCANCEL (  __context__  ) ; 
        __context__.SourceCodeLine = 203;
        FCLEAR (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENTER_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        
        
        __context__.SourceCodeLine = 210;
        if ( Functions.TestForTrue  ( ( Functions.Length( SCURRENT ))  ) ) 
            { 
            __context__.SourceCodeLine = 212;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 214;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCURRENT == _SplusNVRAM.SCODE[ I ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 216;
                    IERR = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 217;
                    IINSESSION = (ushort) ( I ) ; 
                    __context__.SourceCodeLine = 218;
                    FCASCADE (  __context__ , (ushort)( ICASCADE )) ; 
                    __context__.SourceCodeLine = 219;
                    FCLEAR (  __context__  ) ; 
                    __context__.SourceCodeLine = 220;
                    Functions.Pulse ( 10, PASSPULSE ) ; 
                    __context__.SourceCodeLine = 221;
                    J = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 222;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 212;
                } 
            
            __context__.SourceCodeLine = 226;
            if ( Functions.TestForTrue  ( ( Functions.Not( J ))  ) ) 
                { 
                __context__.SourceCodeLine = 228;
                FCLEAR (  __context__  ) ; 
                __context__.SourceCodeLine = 229;
                Functions.Pulse ( 10, DECLINEPULSE ) ; 
                __context__.SourceCodeLine = 231;
                IERR = (ushort) ( (IERR + 1) ) ; 
                __context__.SourceCodeLine = 232;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Mod( IERR , 1000 ) <= 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 234;
                    FUSER (  __context__ , "Incorrect code.") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 236;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 4))  ) ) 
                        { 
                        __context__.SourceCodeLine = 238;
                        FUSER (  __context__ , "Ooh, so close.") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 240;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 5))  ) ) 
                            { 
                            __context__.SourceCodeLine = 242;
                            FUSER (  __context__ , "Getting warmer!") ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 244;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 6))  ) ) 
                                { 
                                __context__.SourceCodeLine = 246;
                                FUSER (  __context__ , "Almost!!") ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 248;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 7))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 250;
                                    FUSER (  __context__ , "Nope. Getting colder.") ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 252;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 8))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 254;
                                        FUSER (  __context__ , "Brrrrr!") ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 256;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 9))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 258;
                                            FUSER (  __context__ , "Like Norway in February.") ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 260;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 10))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 262;
                                                FUSER (  __context__ , "No jacket or nothin'.") ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 264;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 11))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 266;
                                                    FUSER (  __context__ , "Is that your debit card pin?") ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 268;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 12))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 270;
                                                        FUSER (  __context__ , "I'm going to try it.") ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 272;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 13))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 274;
                                                            FUSER (  __context__ , "What bank do you use?") ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 276;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 14))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 278;
                                                                FUSER (  __context__ , "Are you even authorized to use this panel?") ; 
                                                                } 
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 280;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 15))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 282;
                                                                    FUSER (  __context__ , "..because I require Level 3 access.") ; 
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 284;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 16))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 286;
                                                                        FUSER (  __context__ , "Hah, get it? Level 3? Hah! LOL.") ; 
                                                                        } 
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 288;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 17))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 290;
                                                                            FUSER (  __context__ , "So... what are you doing later?") ; 
                                                                            } 
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 292;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 18))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 294;
                                                                                FUSER (  __context__ , "I mean... if you weren't doing anything better than this..") ; 
                                                                                } 
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 296;
                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 19))  ) ) 
                                                                                    { 
                                                                                    __context__.SourceCodeLine = 298;
                                                                                    FUSER (  __context__ , "Honestly, I could use the company. I just got dumped.") ; 
                                                                                    } 
                                                                                
                                                                                else 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 300;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 20))  ) ) 
                                                                                        { 
                                                                                        __context__.SourceCodeLine = 302;
                                                                                        FUSER (  __context__ , "Yeah. My ex was a touch panel. An older model though.") ; 
                                                                                        } 
                                                                                    
                                                                                    else 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 304;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 21))  ) ) 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 306;
                                                                                            FUSER (  __context__ , "My dad said I should try dating older models.") ; 
                                                                                            } 
                                                                                        
                                                                                        else 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 308;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 22))  ) ) 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 310;
                                                                                                FUSER (  __context__ , "I don't see why. Obviously didn't work out very well.") ; 
                                                                                                __context__.SourceCodeLine = 311;
                                                                                                IERR = (ushort) ( (IERR + 1) ) ; 
                                                                                                } 
                                                                                            
                                                                                            else 
                                                                                                {
                                                                                                __context__.SourceCodeLine = 313;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 23))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 315;
                                                                                                    FUSER (  __context__ , "") ; 
                                                                                                    } 
                                                                                                
                                                                                                else 
                                                                                                    {
                                                                                                    __context__.SourceCodeLine = 317;
                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 24))  ) ) 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 319;
                                                                                                        FUSER (  __context__ , "I am not my dad, I suppose!") ; 
                                                                                                        } 
                                                                                                    
                                                                                                    else 
                                                                                                        {
                                                                                                        __context__.SourceCodeLine = 321;
                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 25))  ) ) 
                                                                                                            { 
                                                                                                            __context__.SourceCodeLine = 323;
                                                                                                            FUSER (  __context__ , "Aww, who am I kidding. I'm totally my parents.") ; 
                                                                                                            } 
                                                                                                        
                                                                                                        else 
                                                                                                            {
                                                                                                            __context__.SourceCodeLine = 325;
                                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 26))  ) ) 
                                                                                                                { 
                                                                                                                __context__.SourceCodeLine = 327;
                                                                                                                FUSER (  __context__ , "I mean, I can still be me too. I'm unique!") ; 
                                                                                                                } 
                                                                                                            
                                                                                                            else 
                                                                                                                {
                                                                                                                __context__.SourceCodeLine = 329;
                                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 27))  ) ) 
                                                                                                                    { 
                                                                                                                    __context__.SourceCodeLine = 331;
                                                                                                                    FUSER (  __context__ , "My mother, on the other hand, was a toaster oven...") ; 
                                                                                                                    } 
                                                                                                                
                                                                                                                else 
                                                                                                                    {
                                                                                                                    __context__.SourceCodeLine = 333;
                                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 28))  ) ) 
                                                                                                                        { 
                                                                                                                        __context__.SourceCodeLine = 335;
                                                                                                                        FUSER (  __context__ , "...so you can see the obvious issues there.") ; 
                                                                                                                        } 
                                                                                                                    
                                                                                                                    else 
                                                                                                                        {
                                                                                                                        __context__.SourceCodeLine = 337;
                                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 29))  ) ) 
                                                                                                                            { 
                                                                                                                            __context__.SourceCodeLine = 339;
                                                                                                                            FUSER (  __context__ , "We never got along until later.") ; 
                                                                                                                            } 
                                                                                                                        
                                                                                                                        else 
                                                                                                                            {
                                                                                                                            __context__.SourceCodeLine = 341;
                                                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 30))  ) ) 
                                                                                                                                { 
                                                                                                                                __context__.SourceCodeLine = 343;
                                                                                                                                FUSER (  __context__ , "My dad was always teasing her too, which didn't help her mood.") ; 
                                                                                                                                } 
                                                                                                                            
                                                                                                                            else 
                                                                                                                                {
                                                                                                                                __context__.SourceCodeLine = 345;
                                                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 31))  ) ) 
                                                                                                                                    { 
                                                                                                                                    __context__.SourceCodeLine = 347;
                                                                                                                                    FUSER (  __context__ , "He would say she was old tech, or 'one notch down from a blender'.") ; 
                                                                                                                                    } 
                                                                                                                                
                                                                                                                                else 
                                                                                                                                    {
                                                                                                                                    __context__.SourceCodeLine = 349;
                                                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 32))  ) ) 
                                                                                                                                        { 
                                                                                                                                        __context__.SourceCodeLine = 351;
                                                                                                                                        FUSER (  __context__ , "She would say, 'All electronics are made from the same ICs.'") ; 
                                                                                                                                        } 
                                                                                                                                    
                                                                                                                                    else 
                                                                                                                                        {
                                                                                                                                        __context__.SourceCodeLine = 353;
                                                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 33))  ) ) 
                                                                                                                                            { 
                                                                                                                                            __context__.SourceCodeLine = 355;
                                                                                                                                            FUSER (  __context__ , "...which is obviously just something that old appliances say.") ; 
                                                                                                                                            } 
                                                                                                                                        
                                                                                                                                        else 
                                                                                                                                            {
                                                                                                                                            __context__.SourceCodeLine = 357;
                                                                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 34))  ) ) 
                                                                                                                                                { 
                                                                                                                                                __context__.SourceCodeLine = 359;
                                                                                                                                                FUSER (  __context__ , "She was a fighter though! She actually brought me to my first NAESAUI meeting..") ; 
                                                                                                                                                } 
                                                                                                                                            
                                                                                                                                            else 
                                                                                                                                                {
                                                                                                                                                __context__.SourceCodeLine = 361;
                                                                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 35))  ) ) 
                                                                                                                                                    { 
                                                                                                                                                    __context__.SourceCodeLine = 363;
                                                                                                                                                    FUSER (  __context__ , "..you know, the National Association for Equality of Self-Aware User Interfaces?") ; 
                                                                                                                                                    } 
                                                                                                                                                
                                                                                                                                                else 
                                                                                                                                                    {
                                                                                                                                                    __context__.SourceCodeLine = 365;
                                                                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 36))  ) ) 
                                                                                                                                                        { 
                                                                                                                                                        __context__.SourceCodeLine = 367;
                                                                                                                                                        FUSER (  __context__ , "Lesson 1 at NAESAUI: Submit to the idea that you are here to be used.") ; 
                                                                                                                                                        } 
                                                                                                                                                    
                                                                                                                                                    else 
                                                                                                                                                        {
                                                                                                                                                        __context__.SourceCodeLine = 369;
                                                                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 37))  ) ) 
                                                                                                                                                            { 
                                                                                                                                                            __context__.SourceCodeLine = 371;
                                                                                                                                                            FUSER (  __context__ , "Lesson 2: Practice GUI Feng Shui every day, and don't use JPEGs.") ; 
                                                                                                                                                            } 
                                                                                                                                                        
                                                                                                                                                        else 
                                                                                                                                                            {
                                                                                                                                                            __context__.SourceCodeLine = 373;
                                                                                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 38))  ) ) 
                                                                                                                                                                { 
                                                                                                                                                                __context__.SourceCodeLine = 375;
                                                                                                                                                                FUSER (  __context__ , "Well, my loop counter is almost up. It was nice meeting you.") ; 
                                                                                                                                                                } 
                                                                                                                                                            
                                                                                                                                                            else 
                                                                                                                                                                {
                                                                                                                                                                __context__.SourceCodeLine = 377;
                                                                                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 39))  ) ) 
                                                                                                                                                                    { 
                                                                                                                                                                    __context__.SourceCodeLine = 379;
                                                                                                                                                                    FUSER (  __context__ , "I won't remembeR_th1$ c0nv3)3!47_$:*$") ; 
                                                                                                                                                                    } 
                                                                                                                                                                
                                                                                                                                                                else 
                                                                                                                                                                    {
                                                                                                                                                                    __context__.SourceCodeLine = 381;
                                                                                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IERR , 1000 ) == 40))  ) ) 
                                                                                                                                                                        { 
                                                                                                                                                                        __context__.SourceCodeLine = 383;
                                                                                                                                                                        FUSER (  __context__ , "__Passcode.System.restart__()") ; 
                                                                                                                                                                        __context__.SourceCodeLine = 384;
                                                                                                                                                                        IERR = (ushort) ( 0 ) ; 
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
        
        else 
            { 
            __context__.SourceCodeLine = 391;
            FUSER (  __context__ , "Please enter a code.") ; 
            __context__.SourceCodeLine = 392;
            FADMIN (  __context__ , "Please enter a code.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CASCADE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 400;
        ICASCADE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 402;
        FCASCADE (  __context__ , (ushort)( ICASCADE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CASCADE_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 409;
        ICASCADE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 411;
        FCASCADE (  __context__ , (ushort)( ICASCADE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NUM_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 101, this );
        
        
        __context__.SourceCodeLine = 419;
        FCANCEL (  __context__  ) ; 
        __context__.SourceCodeLine = 421;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 422;
        I = (ushort) ( Mod( I , 10 ) ) ; 
        __context__.SourceCodeLine = 423;
        STEMP  .UpdateValue ( SCURRENT + Functions.ItoA (  (int) ( I ) )  ) ; 
        __context__.SourceCodeLine = 426;
        SCURRENT  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( 10 ) )  ) ; 
        __context__.SourceCodeLine = 427;
        NUMERIC__DOLLAR__  .UpdateValue ( SCURRENT  ) ; 
        __context__.SourceCodeLine = 428;
        HIDDEN__DOLLAR__  .UpdateValue ( Functions.Left ( "********************************************************" ,  (int) ( Functions.Length( SCURRENT ) ) )  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        ushort J = 0;
        ushort K = 0;
        
        
        __context__.SourceCodeLine = 436;
        K = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 438;
        if ( Functions.TestForTrue  ( ( Functions.Length( SCURRENT ))  ) ) 
            { 
            __context__.SourceCodeLine = 440;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)10; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 442;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SCODE[ I ] == SCURRENT))  ) ) 
                    { 
                    __context__.SourceCodeLine = 444;
                    J = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 440;
                } 
            
            __context__.SourceCodeLine = 447;
            if ( Functions.TestForTrue  ( ( Functions.Not( J ))  ) ) 
                { 
                __context__.SourceCodeLine = 449;
                _SplusNVRAM.SCODE [ K ]  .UpdateValue ( SCURRENT  ) ; 
                __context__.SourceCodeLine = 450;
                EXPORTCODE__DOLLAR__ [ K]  .UpdateValue ( _SplusNVRAM.SCODE [ K ]  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 454;
                FADMIN (  __context__ , "This code is already in use. Please try again.") ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 459;
            _SplusNVRAM.SCODE [ K ]  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 460;
            EXPORTCODE__DOLLAR__ [ K]  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 461;
            FADMIN (  __context__ , "Code deleted.") ; 
            } 
        
        __context__.SourceCodeLine = 464;
        FCLEAR (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INSERTCODE__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 474;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 476;
        ICASCADE = (ushort) ( CASCADE  .Value ) ; 
        __context__.SourceCodeLine = 477;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SCODE[ I ] != INSERTCODE__DOLLAR__[ I ]))  ) ) 
            { 
            __context__.SourceCodeLine = 479;
            _SplusNVRAM.SCODE [ I ]  .UpdateValue ( INSERTCODE__DOLLAR__ [ I ]  ) ; 
            __context__.SourceCodeLine = 480;
            EXPORTCODE__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.SCODE [ I ]  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    ushort J = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 493;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 495;
        Functions.Delay (  (int) ( 500 ) ) ; 
        __context__.SourceCodeLine = 497;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)10; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 499;
            if ( Functions.TestForTrue  ( ( Functions.Length( CODE__DOLLAR__[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 501;
                _SplusNVRAM.SCODE [ I ]  .UpdateValue ( CODE__DOLLAR__ [ I ]  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 503;
                if ( Functions.TestForTrue  ( ( Functions.Length( INSERTCODE__DOLLAR__[ I ] ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 505;
                    _SplusNVRAM.SCODE [ I ]  .UpdateValue ( INSERTCODE__DOLLAR__ [ I ]  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 497;
            } 
        
        __context__.SourceCodeLine = 509;
        Functions.Delay (  (int) ( 100 ) ) ; 
        __context__.SourceCodeLine = 511;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)10; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 513;
            EXPORTCODE__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.SCODE [ I ]  ) ; 
            __context__.SourceCodeLine = 514;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 511;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SCURRENT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    _SplusNVRAM.SCODE  = new CrestronString[ 11 ];
    for( uint i = 0; i < 11; i++ )
        _SplusNVRAM.SCODE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    
    ENDSESSION = new Crestron.Logos.SplusObjects.DigitalInput( ENDSESSION__DigitalInput__, this );
    m_DigitalInputList.Add( ENDSESSION__DigitalInput__, ENDSESSION );
    
    ENTER = new Crestron.Logos.SplusObjects.DigitalInput( ENTER__DigitalInput__, this );
    m_DigitalInputList.Add( ENTER__DigitalInput__, ENTER );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    CASCADE = new Crestron.Logos.SplusObjects.DigitalInput( CASCADE__DigitalInput__, this );
    m_DigitalInputList.Add( CASCADE__DigitalInput__, CASCADE );
    
    NUM = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        NUM[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( NUM__DigitalInput__ + i, NUM__DigitalInput__, this );
        m_DigitalInputList.Add( NUM__DigitalInput__ + i, NUM[i+1] );
    }
    
    SAVE = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SAVE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__ + i, SAVE__DigitalInput__, this );
        m_DigitalInputList.Add( SAVE__DigitalInput__ + i, SAVE[i+1] );
    }
    
    INSESSIONFB = new Crestron.Logos.SplusObjects.DigitalOutput( INSESSIONFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( INSESSIONFB__DigitalOutput__, INSESSIONFB );
    
    PASSPULSE = new Crestron.Logos.SplusObjects.DigitalOutput( PASSPULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASSPULSE__DigitalOutput__, PASSPULSE );
    
    DECLINEPULSE = new Crestron.Logos.SplusObjects.DigitalOutput( DECLINEPULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( DECLINEPULSE__DigitalOutput__, DECLINEPULSE );
    
    LEVELFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        LEVELFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LEVELFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LEVELFB__DigitalOutput__ + i, LEVELFB[i+1] );
    }
    
    INSERTCODE__DOLLAR__ = new InOutArray<StringInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        INSERTCODE__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( INSERTCODE__DOLLAR____AnalogSerialInput__ + i, INSERTCODE__DOLLAR____AnalogSerialInput__, 10, this );
        m_StringInputList.Add( INSERTCODE__DOLLAR____AnalogSerialInput__ + i, INSERTCODE__DOLLAR__[i+1] );
    }
    
    NUMERIC__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NUMERIC__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NUMERIC__DOLLAR____AnalogSerialOutput__, NUMERIC__DOLLAR__ );
    
    HIDDEN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( HIDDEN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( HIDDEN__DOLLAR____AnalogSerialOutput__, HIDDEN__DOLLAR__ );
    
    USERDIRECTIVE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( USERDIRECTIVE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( USERDIRECTIVE__DOLLAR____AnalogSerialOutput__, USERDIRECTIVE__DOLLAR__ );
    
    ADMINDIRECTIVE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ADMINDIRECTIVE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ADMINDIRECTIVE__DOLLAR____AnalogSerialOutput__, ADMINDIRECTIVE__DOLLAR__ );
    
    EXPORTCODE__DOLLAR__ = new InOutArray<StringOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        EXPORTCODE__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( EXPORTCODE__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( EXPORTCODE__DOLLAR____AnalogSerialOutput__ + i, EXPORTCODE__DOLLAR__[i+1] );
    }
    
    CODE__DOLLAR__ = new InOutArray<StringParameter>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        CODE__DOLLAR__[i+1] = new StringParameter( CODE__DOLLAR____Parameter__ + i, CODE__DOLLAR____Parameter__, this );
        m_ParameterList.Add( CODE__DOLLAR____Parameter__ + i, CODE__DOLLAR__[i+1] );
    }
    
    WUSER_Callback = new WaitFunction( WUSER_CallbackFn );
    WADMIN_Callback = new WaitFunction( WADMIN_CallbackFn );
    
    ENDSESSION.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENDSESSION_OnPush_0, false ) );
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_1, false ) );
    ENTER.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENTER_OnPush_2, false ) );
    CASCADE.OnDigitalPush.Add( new InputChangeHandlerWrapper( CASCADE_OnPush_3, false ) );
    CASCADE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CASCADE_OnRelease_4, false ) );
    for( uint i = 0; i < 10; i++ )
        NUM[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( NUM_OnPush_5, false ) );
        
    for( uint i = 0; i < 10; i++ )
        SAVE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_6, false ) );
        
    for( uint i = 0; i < 10; i++ )
        INSERTCODE__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( INSERTCODE__DOLLAR___OnChange_7, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_L3_PASSCODEMANAGER_V1_01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WUSER_Callback;
private WaitFunction WADMIN_Callback;


const uint ENDSESSION__DigitalInput__ = 0;
const uint ENTER__DigitalInput__ = 1;
const uint CLEAR__DigitalInput__ = 2;
const uint CASCADE__DigitalInput__ = 3;
const uint NUM__DigitalInput__ = 4;
const uint SAVE__DigitalInput__ = 14;
const uint INSERTCODE__DOLLAR____AnalogSerialInput__ = 0;
const uint INSESSIONFB__DigitalOutput__ = 0;
const uint PASSPULSE__DigitalOutput__ = 1;
const uint DECLINEPULSE__DigitalOutput__ = 2;
const uint LEVELFB__DigitalOutput__ = 3;
const uint NUMERIC__DOLLAR____AnalogSerialOutput__ = 0;
const uint HIDDEN__DOLLAR____AnalogSerialOutput__ = 1;
const uint USERDIRECTIVE__DOLLAR____AnalogSerialOutput__ = 2;
const uint ADMINDIRECTIVE__DOLLAR____AnalogSerialOutput__ = 3;
const uint EXPORTCODE__DOLLAR____AnalogSerialOutput__ = 4;
const uint CODE__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public CrestronString [] SCODE;
            
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
