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
   [XmlRoot(ElementName = "Trn_AppVersion.Page" )]
   [XmlType(TypeName =  "Trn_AppVersion.Page" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_AppVersion_Page : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_AppVersion_Page( )
      {
      }

      public SdtTrn_AppVersion_Page( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Page");
         metadata.Set("BT", "Trn_AppVersionPage");
         metadata.Set("PK", "[ \"PageId\" ]");
         metadata.Set("PKAssigned", "[ \"PageId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AppVersionId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Pageid_Z");
         state.Add("gxTpr_Pagename_Z");
         state.Add("gxTpr_Ispredefined_Z");
         state.Add("gxTpr_Pagetype_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_AppVersion_Page sdt;
         sdt = (SdtTrn_AppVersion_Page)(source);
         gxTv_SdtTrn_AppVersion_Page_Pageid = sdt.gxTv_SdtTrn_AppVersion_Page_Pageid ;
         gxTv_SdtTrn_AppVersion_Page_Pagename = sdt.gxTv_SdtTrn_AppVersion_Page_Pagename ;
         gxTv_SdtTrn_AppVersion_Page_Pagestructure = sdt.gxTv_SdtTrn_AppVersion_Page_Pagestructure ;
         gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure = sdt.gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure ;
         gxTv_SdtTrn_AppVersion_Page_Ispredefined = sdt.gxTv_SdtTrn_AppVersion_Page_Ispredefined ;
         gxTv_SdtTrn_AppVersion_Page_Pagetype = sdt.gxTv_SdtTrn_AppVersion_Page_Pagetype ;
         gxTv_SdtTrn_AppVersion_Page_Mode = sdt.gxTv_SdtTrn_AppVersion_Page_Mode ;
         gxTv_SdtTrn_AppVersion_Page_Modified = sdt.gxTv_SdtTrn_AppVersion_Page_Modified ;
         gxTv_SdtTrn_AppVersion_Page_Initialized = sdt.gxTv_SdtTrn_AppVersion_Page_Initialized ;
         gxTv_SdtTrn_AppVersion_Page_Pageid_Z = sdt.gxTv_SdtTrn_AppVersion_Page_Pageid_Z ;
         gxTv_SdtTrn_AppVersion_Page_Pagename_Z = sdt.gxTv_SdtTrn_AppVersion_Page_Pagename_Z ;
         gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z = sdt.gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z ;
         gxTv_SdtTrn_AppVersion_Page_Pagetype_Z = sdt.gxTv_SdtTrn_AppVersion_Page_Pagetype_Z ;
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
         AddObjectProperty("PageId", gxTv_SdtTrn_AppVersion_Page_Pageid, false, includeNonInitialized);
         AddObjectProperty("PageName", gxTv_SdtTrn_AppVersion_Page_Pagename, false, includeNonInitialized);
         AddObjectProperty("PageStructure", gxTv_SdtTrn_AppVersion_Page_Pagestructure, false, includeNonInitialized);
         AddObjectProperty("PagePublishedStructure", gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure, false, includeNonInitialized);
         AddObjectProperty("IsPredefined", gxTv_SdtTrn_AppVersion_Page_Ispredefined, false, includeNonInitialized);
         AddObjectProperty("PageType", gxTv_SdtTrn_AppVersion_Page_Pagetype, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_AppVersion_Page_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_AppVersion_Page_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_AppVersion_Page_Initialized, false, includeNonInitialized);
            AddObjectProperty("PageId_Z", gxTv_SdtTrn_AppVersion_Page_Pageid_Z, false, includeNonInitialized);
            AddObjectProperty("PageName_Z", gxTv_SdtTrn_AppVersion_Page_Pagename_Z, false, includeNonInitialized);
            AddObjectProperty("IsPredefined_Z", gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z, false, includeNonInitialized);
            AddObjectProperty("PageType_Z", gxTv_SdtTrn_AppVersion_Page_Pagetype_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_AppVersion_Page sdt )
      {
         if ( sdt.IsDirty("PageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pageid = sdt.gxTv_SdtTrn_AppVersion_Page_Pageid ;
         }
         if ( sdt.IsDirty("PageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagename = sdt.gxTv_SdtTrn_AppVersion_Page_Pagename ;
         }
         if ( sdt.IsDirty("PageStructure") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagestructure = sdt.gxTv_SdtTrn_AppVersion_Page_Pagestructure ;
         }
         if ( sdt.IsDirty("PagePublishedStructure") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure = sdt.gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure ;
         }
         if ( sdt.IsDirty("IsPredefined") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Ispredefined = sdt.gxTv_SdtTrn_AppVersion_Page_Ispredefined ;
         }
         if ( sdt.IsDirty("PageType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagetype = sdt.gxTv_SdtTrn_AppVersion_Page_Pagetype ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PageId" )]
      [  XmlElement( ElementName = "PageId"   )]
      public Guid gxTpr_Pageid
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pageid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pageid = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pageid");
         }

      }

      [  SoapElement( ElementName = "PageName" )]
      [  XmlElement( ElementName = "PageName"   )]
      public string gxTpr_Pagename
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagename = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagename");
         }

      }

      [  SoapElement( ElementName = "PageStructure" )]
      [  XmlElement( ElementName = "PageStructure"   )]
      public string gxTpr_Pagestructure
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagestructure ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagestructure = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagestructure");
         }

      }

      [  SoapElement( ElementName = "PagePublishedStructure" )]
      [  XmlElement( ElementName = "PagePublishedStructure"   )]
      public string gxTpr_Pagepublishedstructure
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagepublishedstructure");
         }

      }

      [  SoapElement( ElementName = "IsPredefined" )]
      [  XmlElement( ElementName = "IsPredefined"   )]
      public bool gxTpr_Ispredefined
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Ispredefined ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Ispredefined = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Ispredefined");
         }

      }

      [  SoapElement( ElementName = "PageType" )]
      [  XmlElement( ElementName = "PageType"   )]
      public string gxTpr_Pagetype
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagetype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagetype = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagetype");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Mode_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Modified_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Initialized = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Initialized_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageId_Z" )]
      [  XmlElement( ElementName = "PageId_Z"   )]
      public Guid gxTpr_Pageid_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pageid_Z = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pageid_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Pageid_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Pageid_Z = Guid.Empty;
         SetDirty("Pageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Pageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageName_Z" )]
      [  XmlElement( ElementName = "PageName_Z"   )]
      public string gxTpr_Pagename_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagename_Z = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagename_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Pagename_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Pagename_Z = "";
         SetDirty("Pagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Pagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IsPredefined_Z" )]
      [  XmlElement( ElementName = "IsPredefined_Z"   )]
      public bool gxTpr_Ispredefined_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Ispredefined_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z = false;
         SetDirty("Ispredefined_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageType_Z" )]
      [  XmlElement( ElementName = "PageType_Z"   )]
      public string gxTpr_Pagetype_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Page_Pagetype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page_Pagetype_Z = value;
            gxTv_SdtTrn_AppVersion_Page_Modified = 1;
            SetDirty("Pagetype_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_Pagetype_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page_Pagetype_Z = "";
         SetDirty("Pagetype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_Pagetype_Z_IsNull( )
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
         gxTv_SdtTrn_AppVersion_Page_Pageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_AppVersion_Page_Pagename = "";
         gxTv_SdtTrn_AppVersion_Page_Pagestructure = "";
         gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure = "";
         gxTv_SdtTrn_AppVersion_Page_Ispredefined = false;
         gxTv_SdtTrn_AppVersion_Page_Pagetype = "";
         gxTv_SdtTrn_AppVersion_Page_Mode = "";
         gxTv_SdtTrn_AppVersion_Page_Pageid_Z = Guid.Empty;
         gxTv_SdtTrn_AppVersion_Page_Pagename_Z = "";
         gxTv_SdtTrn_AppVersion_Page_Pagetype_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_AppVersion_Page_Modified ;
      private short gxTv_SdtTrn_AppVersion_Page_Initialized ;
      private string gxTv_SdtTrn_AppVersion_Page_Mode ;
      private bool gxTv_SdtTrn_AppVersion_Page_Ispredefined ;
      private bool gxTv_SdtTrn_AppVersion_Page_Ispredefined_Z ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagestructure ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagepublishedstructure ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagename ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagetype ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagename_Z ;
      private string gxTv_SdtTrn_AppVersion_Page_Pagetype_Z ;
      private Guid gxTv_SdtTrn_AppVersion_Page_Pageid ;
      private Guid gxTv_SdtTrn_AppVersion_Page_Pageid_Z ;
   }

   [DataContract(Name = @"Trn_AppVersion.Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AppVersion_Page_RESTInterface : GxGenericCollectionItem<SdtTrn_AppVersion_Page>
   {
      public SdtTrn_AppVersion_Page_RESTInterface( ) : base()
      {
      }

      public SdtTrn_AppVersion_Page_RESTInterface( SdtTrn_AppVersion_Page psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Pageid
      {
         get {
            return sdt.gxTpr_Pageid ;
         }

         set {
            sdt.gxTpr_Pageid = value;
         }

      }

      [DataMember( Name = "PageName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Pagename
      {
         get {
            return sdt.gxTpr_Pagename ;
         }

         set {
            sdt.gxTpr_Pagename = value;
         }

      }

      [DataMember( Name = "PageStructure" , Order = 2 )]
      public string gxTpr_Pagestructure
      {
         get {
            return sdt.gxTpr_Pagestructure ;
         }

         set {
            sdt.gxTpr_Pagestructure = value;
         }

      }

      [DataMember( Name = "PagePublishedStructure" , Order = 3 )]
      public string gxTpr_Pagepublishedstructure
      {
         get {
            return sdt.gxTpr_Pagepublishedstructure ;
         }

         set {
            sdt.gxTpr_Pagepublishedstructure = value;
         }

      }

      [DataMember( Name = "IsPredefined" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Ispredefined
      {
         get {
            return sdt.gxTpr_Ispredefined ;
         }

         set {
            sdt.gxTpr_Ispredefined = value;
         }

      }

      [DataMember( Name = "PageType" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Pagetype
      {
         get {
            return sdt.gxTpr_Pagetype ;
         }

         set {
            sdt.gxTpr_Pagetype = value;
         }

      }

      public SdtTrn_AppVersion_Page sdt
      {
         get {
            return (SdtTrn_AppVersion_Page)Sdt ;
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
            sdt = new SdtTrn_AppVersion_Page() ;
         }
      }

   }

   [DataContract(Name = @"Trn_AppVersion.Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AppVersion_Page_RESTLInterface : GxGenericCollectionItem<SdtTrn_AppVersion_Page>
   {
      public SdtTrn_AppVersion_Page_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_AppVersion_Page_RESTLInterface( SdtTrn_AppVersion_Page psdt ) : base(psdt)
      {
      }

      public SdtTrn_AppVersion_Page sdt
      {
         get {
            return (SdtTrn_AppVersion_Page)Sdt ;
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
            sdt = new SdtTrn_AppVersion_Page() ;
         }
      }

   }

}
