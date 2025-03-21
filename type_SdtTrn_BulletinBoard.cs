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
   [XmlRoot(ElementName = "Trn_BulletinBoard" )]
   [XmlType(TypeName =  "Trn_BulletinBoard" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_BulletinBoard : GxSilentTrnSdt
   {
      public SdtTrn_BulletinBoard( )
      {
      }

      public SdtTrn_BulletinBoard( IGxContext context )
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

      public void Load( Guid AV574BulletinBoardId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV574BulletinBoardId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"BulletinBoardId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_BulletinBoard");
         metadata.Set("BT", "Trn_BulletinBoard");
         metadata.Set("PK", "[ \"BulletinBoardId\" ]");
         metadata.Set("PKAssigned", "[ \"BulletinBoardId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Bulletinboardid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Organisationname_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Locationname_Z");
         state.Add("gxTpr_Bulletinboardname_Z");
         state.Add("gxTpr_Bulletinboardbgcolorcode_Z");
         state.Add("gxTpr_Bulletinboardform_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_BulletinBoard sdt;
         sdt = (SdtTrn_BulletinBoard)(source);
         gxTv_SdtTrn_BulletinBoard_Bulletinboardid = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardid ;
         gxTv_SdtTrn_BulletinBoard_Organisationid = sdt.gxTv_SdtTrn_BulletinBoard_Organisationid ;
         gxTv_SdtTrn_BulletinBoard_Organisationname = sdt.gxTv_SdtTrn_BulletinBoard_Organisationname ;
         gxTv_SdtTrn_BulletinBoard_Locationid = sdt.gxTv_SdtTrn_BulletinBoard_Locationid ;
         gxTv_SdtTrn_BulletinBoard_Locationname = sdt.gxTv_SdtTrn_BulletinBoard_Locationname ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardname ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardform = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardform ;
         gxTv_SdtTrn_BulletinBoard_Mode = sdt.gxTv_SdtTrn_BulletinBoard_Mode ;
         gxTv_SdtTrn_BulletinBoard_Initialized = sdt.gxTv_SdtTrn_BulletinBoard_Initialized ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z ;
         gxTv_SdtTrn_BulletinBoard_Organisationid_Z = sdt.gxTv_SdtTrn_BulletinBoard_Organisationid_Z ;
         gxTv_SdtTrn_BulletinBoard_Organisationname_Z = sdt.gxTv_SdtTrn_BulletinBoard_Organisationname_Z ;
         gxTv_SdtTrn_BulletinBoard_Locationid_Z = sdt.gxTv_SdtTrn_BulletinBoard_Locationid_Z ;
         gxTv_SdtTrn_BulletinBoard_Locationname_Z = sdt.gxTv_SdtTrn_BulletinBoard_Locationname_Z ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z ;
         gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z ;
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
         AddObjectProperty("BulletinBoardId", gxTv_SdtTrn_BulletinBoard_Bulletinboardid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_BulletinBoard_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationName", gxTv_SdtTrn_BulletinBoard_Organisationname, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_BulletinBoard_Locationid, false, includeNonInitialized);
         AddObjectProperty("LocationName", gxTv_SdtTrn_BulletinBoard_Locationname, false, includeNonInitialized);
         AddObjectProperty("BulletinBoardName", gxTv_SdtTrn_BulletinBoard_Bulletinboardname, false, includeNonInitialized);
         AddObjectProperty("BulletinBoardBgColorCode", gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode, false, includeNonInitialized);
         AddObjectProperty("BulletinBoardForm", gxTv_SdtTrn_BulletinBoard_Bulletinboardform, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_BulletinBoard_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_BulletinBoard_Initialized, false, includeNonInitialized);
            AddObjectProperty("BulletinBoardId_Z", gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_BulletinBoard_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationName_Z", gxTv_SdtTrn_BulletinBoard_Organisationname_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_BulletinBoard_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationName_Z", gxTv_SdtTrn_BulletinBoard_Locationname_Z, false, includeNonInitialized);
            AddObjectProperty("BulletinBoardName_Z", gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z, false, includeNonInitialized);
            AddObjectProperty("BulletinBoardBgColorCode_Z", gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z, false, includeNonInitialized);
            AddObjectProperty("BulletinBoardForm_Z", gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_BulletinBoard sdt )
      {
         if ( sdt.IsDirty("BulletinBoardId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardid = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationid = sdt.gxTv_SdtTrn_BulletinBoard_Organisationid ;
         }
         if ( sdt.IsDirty("OrganisationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationname = sdt.gxTv_SdtTrn_BulletinBoard_Organisationname ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationid = sdt.gxTv_SdtTrn_BulletinBoard_Locationid ;
         }
         if ( sdt.IsDirty("LocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationname = sdt.gxTv_SdtTrn_BulletinBoard_Locationname ;
         }
         if ( sdt.IsDirty("BulletinBoardName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardname = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardname ;
         }
         if ( sdt.IsDirty("BulletinBoardBgColorCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode ;
         }
         if ( sdt.IsDirty("BulletinBoardForm") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardform = sdt.gxTv_SdtTrn_BulletinBoard_Bulletinboardform ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "BulletinBoardId" )]
      [  XmlElement( ElementName = "BulletinBoardId"   )]
      public Guid gxTpr_Bulletinboardid
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_BulletinBoard_Bulletinboardid != value )
            {
               gxTv_SdtTrn_BulletinBoard_Mode = "INS";
               this.gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Organisationname_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Locationname_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z_SetNull( );
               this.gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z_SetNull( );
            }
            gxTv_SdtTrn_BulletinBoard_Bulletinboardid = value;
            SetDirty("Bulletinboardid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationName" )]
      [  XmlElement( ElementName = "OrganisationName"   )]
      public string gxTpr_Organisationname
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Organisationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationname = value;
            SetDirty("Organisationname");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "LocationName" )]
      [  XmlElement( ElementName = "LocationName"   )]
      public string gxTpr_Locationname
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Locationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationname = value;
            SetDirty("Locationname");
         }

      }

      [  SoapElement( ElementName = "BulletinBoardName" )]
      [  XmlElement( ElementName = "BulletinBoardName"   )]
      public string gxTpr_Bulletinboardname
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardname = value;
            SetDirty("Bulletinboardname");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Bulletinboardname_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname = "";
         SetDirty("Bulletinboardname");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Bulletinboardname_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BulletinBoardBgColorCode" )]
      [  XmlElement( ElementName = "BulletinBoardBgColorCode"   )]
      public string gxTpr_Bulletinboardbgcolorcode
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode = value;
            SetDirty("Bulletinboardbgcolorcode");
         }

      }

      [  SoapElement( ElementName = "BulletinBoardForm" )]
      [  XmlElement( ElementName = "BulletinBoardForm"   )]
      public string gxTpr_Bulletinboardform
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardform ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardform = value;
            SetDirty("Bulletinboardform");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Mode_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Initialized_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BulletinBoardId_Z" )]
      [  XmlElement( ElementName = "BulletinBoardId_Z"   )]
      public Guid gxTpr_Bulletinboardid_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z = value;
            SetDirty("Bulletinboardid_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z = Guid.Empty;
         SetDirty("Bulletinboardid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationName_Z" )]
      [  XmlElement( ElementName = "OrganisationName_Z"   )]
      public string gxTpr_Organisationname_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Organisationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Organisationname_Z = value;
            SetDirty("Organisationname_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Organisationname_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Organisationname_Z = "";
         SetDirty("Organisationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Organisationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationName_Z" )]
      [  XmlElement( ElementName = "LocationName_Z"   )]
      public string gxTpr_Locationname_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Locationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Locationname_Z = value;
            SetDirty("Locationname_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Locationname_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Locationname_Z = "";
         SetDirty("Locationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Locationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BulletinBoardName_Z" )]
      [  XmlElement( ElementName = "BulletinBoardName_Z"   )]
      public string gxTpr_Bulletinboardname_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z = value;
            SetDirty("Bulletinboardname_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z = "";
         SetDirty("Bulletinboardname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BulletinBoardBgColorCode_Z" )]
      [  XmlElement( ElementName = "BulletinBoardBgColorCode_Z"   )]
      public string gxTpr_Bulletinboardbgcolorcode_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z = value;
            SetDirty("Bulletinboardbgcolorcode_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z = "";
         SetDirty("Bulletinboardbgcolorcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BulletinBoardForm_Z" )]
      [  XmlElement( ElementName = "BulletinBoardForm_Z"   )]
      public string gxTpr_Bulletinboardform_Z
      {
         get {
            return gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z = value;
            SetDirty("Bulletinboardform_Z");
         }

      }

      public void gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z_SetNull( )
      {
         gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z = "";
         SetDirty("Bulletinboardform_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z_IsNull( )
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
         gxTv_SdtTrn_BulletinBoard_Bulletinboardid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_BulletinBoard_Organisationid = Guid.Empty;
         gxTv_SdtTrn_BulletinBoard_Organisationname = "";
         gxTv_SdtTrn_BulletinBoard_Locationid = Guid.Empty;
         gxTv_SdtTrn_BulletinBoard_Locationname = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardform = "";
         gxTv_SdtTrn_BulletinBoard_Mode = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z = Guid.Empty;
         gxTv_SdtTrn_BulletinBoard_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_BulletinBoard_Organisationname_Z = "";
         gxTv_SdtTrn_BulletinBoard_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_BulletinBoard_Locationname_Z = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z = "";
         gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_bulletinboard", "GeneXus.Programs.trn_bulletinboard_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_BulletinBoard_Initialized ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardform ;
      private string gxTv_SdtTrn_BulletinBoard_Mode ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardform_Z ;
      private string gxTv_SdtTrn_BulletinBoard_Organisationname ;
      private string gxTv_SdtTrn_BulletinBoard_Locationname ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardname ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode ;
      private string gxTv_SdtTrn_BulletinBoard_Organisationname_Z ;
      private string gxTv_SdtTrn_BulletinBoard_Locationname_Z ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardname_Z ;
      private string gxTv_SdtTrn_BulletinBoard_Bulletinboardbgcolorcode_Z ;
      private Guid gxTv_SdtTrn_BulletinBoard_Bulletinboardid ;
      private Guid gxTv_SdtTrn_BulletinBoard_Organisationid ;
      private Guid gxTv_SdtTrn_BulletinBoard_Locationid ;
      private Guid gxTv_SdtTrn_BulletinBoard_Bulletinboardid_Z ;
      private Guid gxTv_SdtTrn_BulletinBoard_Organisationid_Z ;
      private Guid gxTv_SdtTrn_BulletinBoard_Locationid_Z ;
   }

   [DataContract(Name = @"Trn_BulletinBoard", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_BulletinBoard_RESTInterface : GxGenericCollectionItem<SdtTrn_BulletinBoard>
   {
      public SdtTrn_BulletinBoard_RESTInterface( ) : base()
      {
      }

      public SdtTrn_BulletinBoard_RESTInterface( SdtTrn_BulletinBoard psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BulletinBoardId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Bulletinboardid
      {
         get {
            return sdt.gxTpr_Bulletinboardid ;
         }

         set {
            sdt.gxTpr_Bulletinboardid = value;
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

      [DataMember( Name = "OrganisationName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Organisationname
      {
         get {
            return sdt.gxTpr_Organisationname ;
         }

         set {
            sdt.gxTpr_Organisationname = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 3 )]
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

      [DataMember( Name = "LocationName" , Order = 4 )]
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

      [DataMember( Name = "BulletinBoardName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Bulletinboardname
      {
         get {
            return sdt.gxTpr_Bulletinboardname ;
         }

         set {
            sdt.gxTpr_Bulletinboardname = value;
         }

      }

      [DataMember( Name = "BulletinBoardBgColorCode" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Bulletinboardbgcolorcode
      {
         get {
            return sdt.gxTpr_Bulletinboardbgcolorcode ;
         }

         set {
            sdt.gxTpr_Bulletinboardbgcolorcode = value;
         }

      }

      [DataMember( Name = "BulletinBoardForm" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Bulletinboardform
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Bulletinboardform) ;
         }

         set {
            sdt.gxTpr_Bulletinboardform = value;
         }

      }

      public SdtTrn_BulletinBoard sdt
      {
         get {
            return (SdtTrn_BulletinBoard)Sdt ;
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
            sdt = new SdtTrn_BulletinBoard() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"Trn_BulletinBoard", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_BulletinBoard_RESTLInterface : GxGenericCollectionItem<SdtTrn_BulletinBoard>
   {
      public SdtTrn_BulletinBoard_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_BulletinBoard_RESTLInterface( SdtTrn_BulletinBoard psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BulletinBoardName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Bulletinboardname
      {
         get {
            return sdt.gxTpr_Bulletinboardname ;
         }

         set {
            sdt.gxTpr_Bulletinboardname = value;
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

      public SdtTrn_BulletinBoard sdt
      {
         get {
            return (SdtTrn_BulletinBoard)Sdt ;
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
            sdt = new SdtTrn_BulletinBoard() ;
         }
      }

   }

}
