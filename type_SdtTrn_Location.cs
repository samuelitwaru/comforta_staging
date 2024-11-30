using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_Location" )]
   [XmlType(TypeName =  "Trn_Location" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Location : GxSilentTrnSdt
   {
      public SdtTrn_Location( )
      {
      }

      public SdtTrn_Location( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV29LocationId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV29LocationId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LocationId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Location");
         metadata.Set("BT", "Trn_Location");
         metadata.Set("PK", "[ \"LocationId\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"LocationId\",\"OrganisationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Trn_ThemeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationname_Z");
         state.Add("gxTpr_Locationcountry_Z");
         state.Add("gxTpr_Locationcity_Z");
         state.Add("gxTpr_Locationzipcode_Z");
         state.Add("gxTpr_Locationaddressline1_Z");
         state.Add("gxTpr_Locationaddressline2_Z");
         state.Add("gxTpr_Locationemail_Z");
         state.Add("gxTpr_Locationphonecode_Z");
         state.Add("gxTpr_Locationphonenumber_Z");
         state.Add("gxTpr_Locationphone_Z");
         state.Add("gxTpr_Trn_themeid_Z");
         state.Add("gxTpr_Trn_themeid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Location sdt;
         sdt = (SdtTrn_Location)(source);
         gxTv_SdtTrn_Location_Locationid = sdt.gxTv_SdtTrn_Location_Locationid ;
         gxTv_SdtTrn_Location_Organisationid = sdt.gxTv_SdtTrn_Location_Organisationid ;
         gxTv_SdtTrn_Location_Locationname = sdt.gxTv_SdtTrn_Location_Locationname ;
         gxTv_SdtTrn_Location_Locationcountry = sdt.gxTv_SdtTrn_Location_Locationcountry ;
         gxTv_SdtTrn_Location_Locationcity = sdt.gxTv_SdtTrn_Location_Locationcity ;
         gxTv_SdtTrn_Location_Locationzipcode = sdt.gxTv_SdtTrn_Location_Locationzipcode ;
         gxTv_SdtTrn_Location_Locationaddressline1 = sdt.gxTv_SdtTrn_Location_Locationaddressline1 ;
         gxTv_SdtTrn_Location_Locationaddressline2 = sdt.gxTv_SdtTrn_Location_Locationaddressline2 ;
         gxTv_SdtTrn_Location_Locationemail = sdt.gxTv_SdtTrn_Location_Locationemail ;
         gxTv_SdtTrn_Location_Locationphonecode = sdt.gxTv_SdtTrn_Location_Locationphonecode ;
         gxTv_SdtTrn_Location_Locationphonenumber = sdt.gxTv_SdtTrn_Location_Locationphonenumber ;
         gxTv_SdtTrn_Location_Locationphone = sdt.gxTv_SdtTrn_Location_Locationphone ;
         gxTv_SdtTrn_Location_Locationdescription = sdt.gxTv_SdtTrn_Location_Locationdescription ;
         gxTv_SdtTrn_Location_Trn_themeid = sdt.gxTv_SdtTrn_Location_Trn_themeid ;
         gxTv_SdtTrn_Location_Mode = sdt.gxTv_SdtTrn_Location_Mode ;
         gxTv_SdtTrn_Location_Initialized = sdt.gxTv_SdtTrn_Location_Initialized ;
         gxTv_SdtTrn_Location_Locationid_Z = sdt.gxTv_SdtTrn_Location_Locationid_Z ;
         gxTv_SdtTrn_Location_Organisationid_Z = sdt.gxTv_SdtTrn_Location_Organisationid_Z ;
         gxTv_SdtTrn_Location_Locationname_Z = sdt.gxTv_SdtTrn_Location_Locationname_Z ;
         gxTv_SdtTrn_Location_Locationcountry_Z = sdt.gxTv_SdtTrn_Location_Locationcountry_Z ;
         gxTv_SdtTrn_Location_Locationcity_Z = sdt.gxTv_SdtTrn_Location_Locationcity_Z ;
         gxTv_SdtTrn_Location_Locationzipcode_Z = sdt.gxTv_SdtTrn_Location_Locationzipcode_Z ;
         gxTv_SdtTrn_Location_Locationaddressline1_Z = sdt.gxTv_SdtTrn_Location_Locationaddressline1_Z ;
         gxTv_SdtTrn_Location_Locationaddressline2_Z = sdt.gxTv_SdtTrn_Location_Locationaddressline2_Z ;
         gxTv_SdtTrn_Location_Locationemail_Z = sdt.gxTv_SdtTrn_Location_Locationemail_Z ;
         gxTv_SdtTrn_Location_Locationphonecode_Z = sdt.gxTv_SdtTrn_Location_Locationphonecode_Z ;
         gxTv_SdtTrn_Location_Locationphonenumber_Z = sdt.gxTv_SdtTrn_Location_Locationphonenumber_Z ;
         gxTv_SdtTrn_Location_Locationphone_Z = sdt.gxTv_SdtTrn_Location_Locationphone_Z ;
         gxTv_SdtTrn_Location_Trn_themeid_Z = sdt.gxTv_SdtTrn_Location_Trn_themeid_Z ;
         gxTv_SdtTrn_Location_Trn_themeid_N = sdt.gxTv_SdtTrn_Location_Trn_themeid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("LocationId", gxTv_SdtTrn_Location_Locationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Location_Organisationid, false, includeNonInitialized);
         AddObjectProperty("LocationName", gxTv_SdtTrn_Location_Locationname, false, includeNonInitialized);
         AddObjectProperty("LocationCountry", gxTv_SdtTrn_Location_Locationcountry, false, includeNonInitialized);
         AddObjectProperty("LocationCity", gxTv_SdtTrn_Location_Locationcity, false, includeNonInitialized);
         AddObjectProperty("LocationZipCode", gxTv_SdtTrn_Location_Locationzipcode, false, includeNonInitialized);
         AddObjectProperty("LocationAddressLine1", gxTv_SdtTrn_Location_Locationaddressline1, false, includeNonInitialized);
         AddObjectProperty("LocationAddressLine2", gxTv_SdtTrn_Location_Locationaddressline2, false, includeNonInitialized);
         AddObjectProperty("LocationEmail", gxTv_SdtTrn_Location_Locationemail, false, includeNonInitialized);
         AddObjectProperty("LocationPhoneCode", gxTv_SdtTrn_Location_Locationphonecode, false, includeNonInitialized);
         AddObjectProperty("LocationPhoneNumber", gxTv_SdtTrn_Location_Locationphonenumber, false, includeNonInitialized);
         AddObjectProperty("LocationPhone", gxTv_SdtTrn_Location_Locationphone, false, includeNonInitialized);
         AddObjectProperty("LocationDescription", gxTv_SdtTrn_Location_Locationdescription, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeId", gxTv_SdtTrn_Location_Trn_themeid, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeId_N", gxTv_SdtTrn_Location_Trn_themeid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Location_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Location_Initialized, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Location_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Location_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationName_Z", gxTv_SdtTrn_Location_Locationname_Z, false, includeNonInitialized);
            AddObjectProperty("LocationCountry_Z", gxTv_SdtTrn_Location_Locationcountry_Z, false, includeNonInitialized);
            AddObjectProperty("LocationCity_Z", gxTv_SdtTrn_Location_Locationcity_Z, false, includeNonInitialized);
            AddObjectProperty("LocationZipCode_Z", gxTv_SdtTrn_Location_Locationzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("LocationAddressLine1_Z", gxTv_SdtTrn_Location_Locationaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("LocationAddressLine2_Z", gxTv_SdtTrn_Location_Locationaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEmail_Z", gxTv_SdtTrn_Location_Locationemail_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhoneCode_Z", gxTv_SdtTrn_Location_Locationphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhoneNumber_Z", gxTv_SdtTrn_Location_Locationphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhone_Z", gxTv_SdtTrn_Location_Locationphone_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_Z", gxTv_SdtTrn_Location_Trn_themeid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_N", gxTv_SdtTrn_Location_Trn_themeid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Location sdt )
      {
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationid = sdt.gxTv_SdtTrn_Location_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Organisationid = sdt.gxTv_SdtTrn_Location_Organisationid ;
         }
         if ( sdt.IsDirty("LocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname = sdt.gxTv_SdtTrn_Location_Locationname ;
         }
         if ( sdt.IsDirty("LocationCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry = sdt.gxTv_SdtTrn_Location_Locationcountry ;
         }
         if ( sdt.IsDirty("LocationCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity = sdt.gxTv_SdtTrn_Location_Locationcity ;
         }
         if ( sdt.IsDirty("LocationZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode = sdt.gxTv_SdtTrn_Location_Locationzipcode ;
         }
         if ( sdt.IsDirty("LocationAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1 = sdt.gxTv_SdtTrn_Location_Locationaddressline1 ;
         }
         if ( sdt.IsDirty("LocationAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2 = sdt.gxTv_SdtTrn_Location_Locationaddressline2 ;
         }
         if ( sdt.IsDirty("LocationEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail = sdt.gxTv_SdtTrn_Location_Locationemail ;
         }
         if ( sdt.IsDirty("LocationPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode = sdt.gxTv_SdtTrn_Location_Locationphonecode ;
         }
         if ( sdt.IsDirty("LocationPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber = sdt.gxTv_SdtTrn_Location_Locationphonenumber ;
         }
         if ( sdt.IsDirty("LocationPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone = sdt.gxTv_SdtTrn_Location_Locationphone ;
         }
         if ( sdt.IsDirty("LocationDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationdescription = sdt.gxTv_SdtTrn_Location_Locationdescription ;
         }
         if ( sdt.IsDirty("Trn_ThemeId") )
         {
            gxTv_SdtTrn_Location_Trn_themeid_N = (short)(sdt.gxTv_SdtTrn_Location_Trn_themeid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid = sdt.gxTv_SdtTrn_Location_Trn_themeid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Location_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Location_Locationid != value )
            {
               gxTv_SdtTrn_Location_Mode = "INS";
               this.gxTv_SdtTrn_Location_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationname_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcity_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationemail_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphone_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( );
            }
            gxTv_SdtTrn_Location_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Location_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Location_Organisationid != value )
            {
               gxTv_SdtTrn_Location_Mode = "INS";
               this.gxTv_SdtTrn_Location_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationname_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcity_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationemail_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphone_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( );
            }
            gxTv_SdtTrn_Location_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationName" )]
      [  XmlElement( ElementName = "LocationName"   )]
      public string gxTpr_Locationname
      {
         get {
            return gxTv_SdtTrn_Location_Locationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname = value;
            SetDirty("Locationname");
         }

      }

      [  SoapElement( ElementName = "LocationCountry" )]
      [  XmlElement( ElementName = "LocationCountry"   )]
      public string gxTpr_Locationcountry
      {
         get {
            return gxTv_SdtTrn_Location_Locationcountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry = value;
            SetDirty("Locationcountry");
         }

      }

      [  SoapElement( ElementName = "LocationCity" )]
      [  XmlElement( ElementName = "LocationCity"   )]
      public string gxTpr_Locationcity
      {
         get {
            return gxTv_SdtTrn_Location_Locationcity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity = value;
            SetDirty("Locationcity");
         }

      }

      [  SoapElement( ElementName = "LocationZipCode" )]
      [  XmlElement( ElementName = "LocationZipCode"   )]
      public string gxTpr_Locationzipcode
      {
         get {
            return gxTv_SdtTrn_Location_Locationzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode = value;
            SetDirty("Locationzipcode");
         }

      }

      [  SoapElement( ElementName = "LocationAddressLine1" )]
      [  XmlElement( ElementName = "LocationAddressLine1"   )]
      public string gxTpr_Locationaddressline1
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1 = value;
            SetDirty("Locationaddressline1");
         }

      }

      [  SoapElement( ElementName = "LocationAddressLine2" )]
      [  XmlElement( ElementName = "LocationAddressLine2"   )]
      public string gxTpr_Locationaddressline2
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2 = value;
            SetDirty("Locationaddressline2");
         }

      }

      [  SoapElement( ElementName = "LocationEmail" )]
      [  XmlElement( ElementName = "LocationEmail"   )]
      public string gxTpr_Locationemail
      {
         get {
            return gxTv_SdtTrn_Location_Locationemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail = value;
            SetDirty("Locationemail");
         }

      }

      [  SoapElement( ElementName = "LocationPhoneCode" )]
      [  XmlElement( ElementName = "LocationPhoneCode"   )]
      public string gxTpr_Locationphonecode
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode = value;
            SetDirty("Locationphonecode");
         }

      }

      [  SoapElement( ElementName = "LocationPhoneNumber" )]
      [  XmlElement( ElementName = "LocationPhoneNumber"   )]
      public string gxTpr_Locationphonenumber
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber = value;
            SetDirty("Locationphonenumber");
         }

      }

      [  SoapElement( ElementName = "LocationPhone" )]
      [  XmlElement( ElementName = "LocationPhone"   )]
      public string gxTpr_Locationphone
      {
         get {
            return gxTv_SdtTrn_Location_Locationphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone = value;
            SetDirty("Locationphone");
         }

      }

      [  SoapElement( ElementName = "LocationDescription" )]
      [  XmlElement( ElementName = "LocationDescription"   )]
      public string gxTpr_Locationdescription
      {
         get {
            return gxTv_SdtTrn_Location_Locationdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationdescription = value;
            SetDirty("Locationdescription");
         }

      }

      [  SoapElement( ElementName = "Trn_ThemeId" )]
      [  XmlElement( ElementName = "Trn_ThemeId"   )]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return gxTv_SdtTrn_Location_Trn_themeid ;
         }

         set {
            gxTv_SdtTrn_Location_Trn_themeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid = value;
            SetDirty("Trn_themeid");
         }

      }

      public void gxTv_SdtTrn_Location_Trn_themeid_SetNull( )
      {
         gxTv_SdtTrn_Location_Trn_themeid_N = 1;
         gxTv_SdtTrn_Location_Trn_themeid = Guid.Empty;
         SetDirty("Trn_themeid");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Trn_themeid_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Trn_themeid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Location_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Location_Mode_SetNull( )
      {
         gxTv_SdtTrn_Location_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Location_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Location_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Location_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationName_Z" )]
      [  XmlElement( ElementName = "LocationName_Z"   )]
      public string gxTpr_Locationname_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname_Z = value;
            SetDirty("Locationname_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationname_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationname_Z = "";
         SetDirty("Locationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationCountry_Z" )]
      [  XmlElement( ElementName = "LocationCountry_Z"   )]
      public string gxTpr_Locationcountry_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationcountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry_Z = value;
            SetDirty("Locationcountry_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationcountry_Z = "";
         SetDirty("Locationcountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationcountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationCity_Z" )]
      [  XmlElement( ElementName = "LocationCity_Z"   )]
      public string gxTpr_Locationcity_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationcity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity_Z = value;
            SetDirty("Locationcity_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationcity_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationcity_Z = "";
         SetDirty("Locationcity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationcity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationZipCode_Z" )]
      [  XmlElement( ElementName = "LocationZipCode_Z"   )]
      public string gxTpr_Locationzipcode_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode_Z = value;
            SetDirty("Locationzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationzipcode_Z = "";
         SetDirty("Locationzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationAddressLine1_Z" )]
      [  XmlElement( ElementName = "LocationAddressLine1_Z"   )]
      public string gxTpr_Locationaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1_Z = value;
            SetDirty("Locationaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationaddressline1_Z = "";
         SetDirty("Locationaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationAddressLine2_Z" )]
      [  XmlElement( ElementName = "LocationAddressLine2_Z"   )]
      public string gxTpr_Locationaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2_Z = value;
            SetDirty("Locationaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationaddressline2_Z = "";
         SetDirty("Locationaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEmail_Z" )]
      [  XmlElement( ElementName = "LocationEmail_Z"   )]
      public string gxTpr_Locationemail_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail_Z = value;
            SetDirty("Locationemail_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationemail_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationemail_Z = "";
         SetDirty("Locationemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhoneCode_Z" )]
      [  XmlElement( ElementName = "LocationPhoneCode_Z"   )]
      public string gxTpr_Locationphonecode_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode_Z = value;
            SetDirty("Locationphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphonecode_Z = "";
         SetDirty("Locationphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhoneNumber_Z" )]
      [  XmlElement( ElementName = "LocationPhoneNumber_Z"   )]
      public string gxTpr_Locationphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber_Z = value;
            SetDirty("Locationphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphonenumber_Z = "";
         SetDirty("Locationphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhone_Z" )]
      [  XmlElement( ElementName = "LocationPhone_Z"   )]
      public string gxTpr_Locationphone_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone_Z = value;
            SetDirty("Locationphone_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphone_Z = "";
         SetDirty("Locationphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeId_Z"   )]
      public Guid gxTpr_Trn_themeid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Trn_themeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid_Z = value;
            SetDirty("Trn_themeid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Trn_themeid_Z = Guid.Empty;
         SetDirty("Trn_themeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Trn_themeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_N" )]
      [  XmlElement( ElementName = "Trn_ThemeId_N"   )]
      public short gxTpr_Trn_themeid_N
      {
         get {
            return gxTv_SdtTrn_Location_Trn_themeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid_N = value;
            SetDirty("Trn_themeid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Trn_themeid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Trn_themeid_N = 0;
         SetDirty("Trn_themeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Trn_themeid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtTrn_Location_Locationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Location_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Location_Locationname = "";
         gxTv_SdtTrn_Location_Locationcountry = "";
         gxTv_SdtTrn_Location_Locationcity = "";
         gxTv_SdtTrn_Location_Locationzipcode = "";
         gxTv_SdtTrn_Location_Locationaddressline1 = "";
         gxTv_SdtTrn_Location_Locationaddressline2 = "";
         gxTv_SdtTrn_Location_Locationemail = "";
         gxTv_SdtTrn_Location_Locationphonecode = "";
         gxTv_SdtTrn_Location_Locationphonenumber = "";
         gxTv_SdtTrn_Location_Locationphone = "";
         gxTv_SdtTrn_Location_Locationdescription = "";
         gxTv_SdtTrn_Location_Trn_themeid = Guid.Empty;
         gxTv_SdtTrn_Location_Mode = "";
         gxTv_SdtTrn_Location_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Locationname_Z = "";
         gxTv_SdtTrn_Location_Locationcountry_Z = "";
         gxTv_SdtTrn_Location_Locationcity_Z = "";
         gxTv_SdtTrn_Location_Locationzipcode_Z = "";
         gxTv_SdtTrn_Location_Locationaddressline1_Z = "";
         gxTv_SdtTrn_Location_Locationaddressline2_Z = "";
         gxTv_SdtTrn_Location_Locationemail_Z = "";
         gxTv_SdtTrn_Location_Locationphonecode_Z = "";
         gxTv_SdtTrn_Location_Locationphonenumber_Z = "";
         gxTv_SdtTrn_Location_Locationphone_Z = "";
         gxTv_SdtTrn_Location_Trn_themeid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_location", "GeneXus.Programs.trn_location_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Location_Initialized ;
      private short gxTv_SdtTrn_Location_Trn_themeid_N ;
      private string gxTv_SdtTrn_Location_Locationphone ;
      private string gxTv_SdtTrn_Location_Mode ;
      private string gxTv_SdtTrn_Location_Locationphone_Z ;
      private string gxTv_SdtTrn_Location_Locationdescription ;
      private string gxTv_SdtTrn_Location_Locationname ;
      private string gxTv_SdtTrn_Location_Locationcountry ;
      private string gxTv_SdtTrn_Location_Locationcity ;
      private string gxTv_SdtTrn_Location_Locationzipcode ;
      private string gxTv_SdtTrn_Location_Locationaddressline1 ;
      private string gxTv_SdtTrn_Location_Locationaddressline2 ;
      private string gxTv_SdtTrn_Location_Locationemail ;
      private string gxTv_SdtTrn_Location_Locationphonecode ;
      private string gxTv_SdtTrn_Location_Locationphonenumber ;
      private string gxTv_SdtTrn_Location_Locationname_Z ;
      private string gxTv_SdtTrn_Location_Locationcountry_Z ;
      private string gxTv_SdtTrn_Location_Locationcity_Z ;
      private string gxTv_SdtTrn_Location_Locationzipcode_Z ;
      private string gxTv_SdtTrn_Location_Locationaddressline1_Z ;
      private string gxTv_SdtTrn_Location_Locationaddressline2_Z ;
      private string gxTv_SdtTrn_Location_Locationemail_Z ;
      private string gxTv_SdtTrn_Location_Locationphonecode_Z ;
      private string gxTv_SdtTrn_Location_Locationphonenumber_Z ;
      private Guid gxTv_SdtTrn_Location_Locationid ;
      private Guid gxTv_SdtTrn_Location_Organisationid ;
      private Guid gxTv_SdtTrn_Location_Trn_themeid ;
      private Guid gxTv_SdtTrn_Location_Locationid_Z ;
      private Guid gxTv_SdtTrn_Location_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Location_Trn_themeid_Z ;
   }

   [DataContract(Name = @"Trn_Location", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Location_RESTInterface : GxGenericCollectionItem<SdtTrn_Location>
   {
      public SdtTrn_Location_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Location_RESTInterface( SdtTrn_Location psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      [DataMember( Name = "LocationName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Locationname
      {
         get {
            return sdt.gxTpr_Locationname ;
         }

         set {
            sdt.gxTpr_Locationname = value;
         }

      }

      [DataMember( Name = "LocationCountry" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Locationcountry
      {
         get {
            return sdt.gxTpr_Locationcountry ;
         }

         set {
            sdt.gxTpr_Locationcountry = value;
         }

      }

      [DataMember( Name = "LocationCity" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Locationcity
      {
         get {
            return sdt.gxTpr_Locationcity ;
         }

         set {
            sdt.gxTpr_Locationcity = value;
         }

      }

      [DataMember( Name = "LocationZipCode" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Locationzipcode
      {
         get {
            return sdt.gxTpr_Locationzipcode ;
         }

         set {
            sdt.gxTpr_Locationzipcode = value;
         }

      }

      [DataMember( Name = "LocationAddressLine1" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Locationaddressline1
      {
         get {
            return sdt.gxTpr_Locationaddressline1 ;
         }

         set {
            sdt.gxTpr_Locationaddressline1 = value;
         }

      }

      [DataMember( Name = "LocationAddressLine2" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Locationaddressline2
      {
         get {
            return sdt.gxTpr_Locationaddressline2 ;
         }

         set {
            sdt.gxTpr_Locationaddressline2 = value;
         }

      }

      [DataMember( Name = "LocationEmail" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Locationemail
      {
         get {
            return sdt.gxTpr_Locationemail ;
         }

         set {
            sdt.gxTpr_Locationemail = value;
         }

      }

      [DataMember( Name = "LocationPhoneCode" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Locationphonecode
      {
         get {
            return sdt.gxTpr_Locationphonecode ;
         }

         set {
            sdt.gxTpr_Locationphonecode = value;
         }

      }

      [DataMember( Name = "LocationPhoneNumber" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Locationphonenumber
      {
         get {
            return sdt.gxTpr_Locationphonenumber ;
         }

         set {
            sdt.gxTpr_Locationphonenumber = value;
         }

      }

      [DataMember( Name = "LocationPhone" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Locationphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Locationphone) ;
         }

         set {
            sdt.gxTpr_Locationphone = value;
         }

      }

      [DataMember( Name = "LocationDescription" , Order = 12 )]
      public string gxTpr_Locationdescription
      {
         get {
            return sdt.gxTpr_Locationdescription ;
         }

         set {
            sdt.gxTpr_Locationdescription = value;
         }

      }

      [DataMember( Name = "Trn_ThemeId" , Order = 13 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return sdt.gxTpr_Trn_themeid ;
         }

         set {
            sdt.gxTpr_Trn_themeid = value;
         }

      }

      public SdtTrn_Location sdt
      {
         get {
            return (SdtTrn_Location)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Location() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Trn_Location", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Location_RESTLInterface : GxGenericCollectionItem<SdtTrn_Location>
   {
      public SdtTrn_Location_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Location_RESTLInterface( SdtTrn_Location psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Locationname
      {
         get {
            return sdt.gxTpr_Locationname ;
         }

         set {
            sdt.gxTpr_Locationname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_Location sdt
      {
         get {
            return (SdtTrn_Location)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Location() ;
         }
      }

   }

}
