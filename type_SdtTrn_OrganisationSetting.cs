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
   [XmlRoot(ElementName = "Trn_OrganisationSetting" )]
   [XmlType(TypeName =  "Trn_OrganisationSetting" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_OrganisationSetting : GxSilentTrnSdt
   {
      public SdtTrn_OrganisationSetting( )
      {
      }

      public SdtTrn_OrganisationSetting( IGxContext context )
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

      public void Load( Guid AV100OrganisationSettingid )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV100OrganisationSettingid});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OrganisationSettingid", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_OrganisationSetting");
         metadata.Set("BT", "Trn_OrganisationSetting");
         metadata.Set("PK", "[ \"OrganisationSettingid\" ]");
         metadata.Set("PKAssigned", "[ \"OrganisationSettingid\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Organisationsettinglogo_gxi");
         state.Add("gxTpr_Organisationsettingfavicon_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Organisationsettingid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Organisationsettingbasecolor_Z");
         state.Add("gxTpr_Organisationsettingfontsize_Z");
         state.Add("gxTpr_Organisationsettinglogo_gxi_Z");
         state.Add("gxTpr_Organisationsettingfavicon_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_OrganisationSetting sdt;
         sdt = (SdtTrn_OrganisationSetting)(source);
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         gxTv_SdtTrn_OrganisationSetting_Organisationid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         gxTv_SdtTrn_OrganisationSetting_Mode = sdt.gxTv_SdtTrn_OrganisationSetting_Mode ;
         gxTv_SdtTrn_OrganisationSetting_Initialized = sdt.gxTv_SdtTrn_OrganisationSetting_Initialized ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
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
         AddObjectProperty("OrganisationSettingid", gxTv_SdtTrn_OrganisationSetting_Organisationsettingid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_OrganisationSetting_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingLogo", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingFavicon", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingBaseColor", gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingFontSize", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingLanguage", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("OrganisationSettingLogo_GXI", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFavicon_GXI", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_OrganisationSetting_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_OrganisationSetting_Initialized, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingid_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_OrganisationSetting_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingBaseColor_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFontSize_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingLogo_GXI_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFavicon_GXI_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_OrganisationSetting sdt )
      {
         if ( sdt.IsDirty("OrganisationSettingid") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         }
         if ( sdt.IsDirty("OrganisationSettingLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         }
         if ( sdt.IsDirty("OrganisationSettingLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         }
         if ( sdt.IsDirty("OrganisationSettingFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         }
         if ( sdt.IsDirty("OrganisationSettingFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         }
         if ( sdt.IsDirty("OrganisationSettingBaseColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         }
         if ( sdt.IsDirty("OrganisationSettingFontSize") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         }
         if ( sdt.IsDirty("OrganisationSettingLanguage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OrganisationSettingid" )]
      [  XmlElement( ElementName = "OrganisationSettingid"   )]
      public Guid gxTpr_Organisationsettingid
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_OrganisationSetting_Organisationsettingid != value )
            {
               gxTv_SdtTrn_OrganisationSetting_Mode = "INS";
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = value;
            SetDirty("Organisationsettingid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLogo" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo"   )]
      [GxUpload()]
      public string gxTpr_Organisationsettinglogo
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = value;
            SetDirty("Organisationsettinglogo");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLogo_GXI" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo_GXI"   )]
      public string gxTpr_Organisationsettinglogo_gxi
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = value;
            SetDirty("Organisationsettinglogo_gxi");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon"   )]
      [GxUpload()]
      public string gxTpr_Organisationsettingfavicon
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = value;
            SetDirty("Organisationsettingfavicon");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon_GXI" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon_GXI"   )]
      public string gxTpr_Organisationsettingfavicon_gxi
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = value;
            SetDirty("Organisationsettingfavicon_gxi");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingBaseColor" )]
      [  XmlElement( ElementName = "OrganisationSettingBaseColor"   )]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = value;
            SetDirty("Organisationsettingbasecolor");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFontSize" )]
      [  XmlElement( ElementName = "OrganisationSettingFontSize"   )]
      public string gxTpr_Organisationsettingfontsize
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = value;
            SetDirty("Organisationsettingfontsize");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLanguage" )]
      [  XmlElement( ElementName = "OrganisationSettingLanguage"   )]
      public string gxTpr_Organisationsettinglanguage
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = value;
            SetDirty("Organisationsettinglanguage");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Mode_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Initialized_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingid_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingid_Z"   )]
      public Guid gxTpr_Organisationsettingid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = value;
            SetDirty("Organisationsettingid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = Guid.Empty;
         SetDirty("Organisationsettingid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingBaseColor_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingBaseColor_Z"   )]
      public string gxTpr_Organisationsettingbasecolor_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = value;
            SetDirty("Organisationsettingbasecolor_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = "";
         SetDirty("Organisationsettingbasecolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingFontSize_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingFontSize_Z"   )]
      public string gxTpr_Organisationsettingfontsize_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = value;
            SetDirty("Organisationsettingfontsize_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = "";
         SetDirty("Organisationsettingfontsize_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingLogo_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo_GXI_Z"   )]
      public string gxTpr_Organisationsettinglogo_gxi_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = value;
            SetDirty("Organisationsettinglogo_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = "";
         SetDirty("Organisationsettinglogo_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon_GXI_Z"   )]
      public string gxTpr_Organisationsettingfavicon_gxi_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = value;
            SetDirty("Organisationsettingfavicon_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = "";
         SetDirty("Organisationsettingfavicon_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_IsNull( )
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
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_OrganisationSetting_Organisationid = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = "";
         gxTv_SdtTrn_OrganisationSetting_Mode = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_organisationsetting", "GeneXus.Programs.trn_organisationsetting_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_OrganisationSetting_Initialized ;
      private string gxTv_SdtTrn_OrganisationSetting_Mode ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationid ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
   }

   [DataContract(Name = @"Trn_OrganisationSetting", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationSetting_RESTInterface : GxGenericCollectionItem<SdtTrn_OrganisationSetting>
   {
      public SdtTrn_OrganisationSetting_RESTInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationSetting_RESTInterface( SdtTrn_OrganisationSetting psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationSettingid" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationsettingid
      {
         get {
            return sdt.gxTpr_Organisationsettingid ;
         }

         set {
            sdt.gxTpr_Organisationsettingid = value;
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

      [DataMember( Name = "OrganisationSettingLogo" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Organisationsettinglogo
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationsettinglogo) : StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationsettinglogo = value;
         }

      }

      [DataMember( Name = "OrganisationSettingFavicon" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Organisationsettingfavicon
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationsettingfavicon) : StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationsettingfavicon = value;
         }

      }

      [DataMember( Name = "OrganisationSettingBaseColor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return sdt.gxTpr_Organisationsettingbasecolor ;
         }

         set {
            sdt.gxTpr_Organisationsettingbasecolor = value;
         }

      }

      [DataMember( Name = "OrganisationSettingFontSize" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingfontsize
      {
         get {
            return sdt.gxTpr_Organisationsettingfontsize ;
         }

         set {
            sdt.gxTpr_Organisationsettingfontsize = value;
         }

      }

      [DataMember( Name = "OrganisationSettingLanguage" , Order = 6 )]
      public string gxTpr_Organisationsettinglanguage
      {
         get {
            return sdt.gxTpr_Organisationsettinglanguage ;
         }

         set {
            sdt.gxTpr_Organisationsettinglanguage = value;
         }

      }

      public SdtTrn_OrganisationSetting sdt
      {
         get {
            return (SdtTrn_OrganisationSetting)Sdt ;
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
            sdt = new SdtTrn_OrganisationSetting() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"Trn_OrganisationSetting", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationSetting_RESTLInterface : GxGenericCollectionItem<SdtTrn_OrganisationSetting>
   {
      public SdtTrn_OrganisationSetting_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationSetting_RESTLInterface( SdtTrn_OrganisationSetting psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationSettingBaseColor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return sdt.gxTpr_Organisationsettingbasecolor ;
         }

         set {
            sdt.gxTpr_Organisationsettingbasecolor = value;
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

      public SdtTrn_OrganisationSetting sdt
      {
         get {
            return (SdtTrn_OrganisationSetting)Sdt ;
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
            sdt = new SdtTrn_OrganisationSetting() ;
         }
      }

   }

}
