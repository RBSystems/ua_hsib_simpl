namespace HSIB_Tools;
        // class declarations
         class TrimString;
         class C_HSIB_DataStore;
         class CDSGetStringArgs;
         class C_MyStringEventArgs;
     class TrimString 
    {
        // class delegates

        // class events

        // class functions
        SIMPLSHARPSTRING_FUNCTION TrimThis ( SIMPLSHARPSTRING sData );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class C_HSIB_DataStore 
    {
        // class delegates
        delegate FUNCTION CDSStringUpdateHandler ( SIMPLSHARPSTRING _tag , SIMPLSHARPSTRING _value );

        // class events

        // class functions
        FUNCTION OnStringUpdate ( STRING _tag , STRING _value );
        FUNCTION SetStringData ( STRING _tag , STRING _value );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty CDSStringUpdateHandler OnStringUpdateEvent;
    };

