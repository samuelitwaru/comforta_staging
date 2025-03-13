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
   [XmlRoot(ElementName = "Trn_AppVersion" )]
   [XmlType(TypeName =  "Trn_AppVersion" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_AppVersion : GxSilentTrnSdt
   {
      public SdtTrn_AppVersion( )
      {
      }

      public SdtTrn_AppVersion( IGxContext context )
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

      public void Load( Guid AV543AppVersionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV543AppVersionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AppVersionId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_AppVersion");
         metadata.Set("BT", "Trn_AppVersion");
         metadata.Set("PK", "[ \"AppVersionId\" ]");
         metadata.Set("PKAssigned", "[ \"AppVersionId\" ]");
         metadata.Set("Levels", "[ \"Page\" ]");
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
         state.Add("gxTpr_Appversionid_Z");
         state.Add("gxTpr_Appversionname_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Isactive_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_AppVersion sdt;
         sdt = (SdtTrn_AppVersion)(source);
         gxTv_SdtTrn_AppVersion_Appversionid = sdt.gxTv_SdtTrn_AppVersion_Appversionid ;
         gxTv_SdtTrn_AppVersion_Appversionname = sdt.gxTv_SdtTrn_AppVersion_Appversionname ;
         gxTv_SdtTrn_AppVersion_Locationid = sdt.gxTv_SdtTrn_AppVersion_Locationid ;
         gxTv_SdtTrn_AppVersion_Isactive = sdt.gxTv_SdtTrn_AppVersion_Isactive ;
         gxTv_SdtTrn_AppVersion_Page = sdt.gxTv_SdtTrn_AppVersion_Page ;
         gxTv_SdtTrn_AppVersion_Mode = sdt.gxTv_SdtTrn_AppVersion_Mode ;
         gxTv_SdtTrn_AppVersion_Initialized = sdt.gxTv_SdtTrn_AppVersion_Initialized ;
         gxTv_SdtTrn_AppVersion_Appversionid_Z = sdt.gxTv_SdtTrn_AppVersion_Appversionid_Z ;
         gxTv_SdtTrn_AppVersion_Appversionname_Z = sdt.gxTv_SdtTrn_AppVersion_Appversionname_Z ;
         gxTv_SdtTrn_AppVersion_Locationid_Z = sdt.gxTv_SdtTrn_AppVersion_Locationid_Z ;
         gxTv_SdtTrn_AppVersion_Isactive_Z = sdt.gxTv_SdtTrn_AppVersion_Isactive_Z ;
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
         AddObjectProperty("AppVersionId", gxTv_SdtTrn_AppVersion_Appversionid, false, includeNonInitialized);
         AddObjectProperty("AppVersionName", gxTv_SdtTrn_AppVersion_Appversionname, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_AppVersion_Locationid, false, includeNonInitialized);
         AddObjectProperty("IsActive", gxTv_SdtTrn_AppVersion_Isactive, false, includeNonInitialized);
         if ( gxTv_SdtTrn_AppVersion_Page != null )
         {
            AddObjectProperty("Page", gxTv_SdtTrn_AppVersion_Page, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_AppVersion_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_AppVersion_Initialized, false, includeNonInitialized);
            AddObjectProperty("AppVersionId_Z", gxTv_SdtTrn_AppVersion_Appversionid_Z, false, includeNonInitialized);
            AddObjectProperty("AppVersionName_Z", gxTv_SdtTrn_AppVersion_Appversionname_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_AppVersion_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("IsActive_Z", gxTv_SdtTrn_AppVersion_Isactive_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_AppVersion sdt )
      {
         if ( sdt.IsDirty("AppVersionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Appversionid = sdt.gxTv_SdtTrn_AppVersion_Appversionid ;
         }
         if ( sdt.IsDirty("AppVersionName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Appversionname = sdt.gxTv_SdtTrn_AppVersion_Appversionname ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Locationid = sdt.gxTv_SdtTrn_AppVersion_Locationid ;
         }
         if ( sdt.IsDirty("IsActive") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Isactive = sdt.gxTv_SdtTrn_AppVersion_Isactive ;
         }
         if ( gxTv_SdtTrn_AppVersion_Page != null )
         {
            GXBCLevelCollection<SdtTrn_AppVersion_Page> newCollectionPage = sdt.gxTpr_Page;
            SdtTrn_AppVersion_Page currItemPage;
            SdtTrn_AppVersion_Page newItemPage;
            short idx = 1;
            while ( idx <= newCollectionPage.Count )
            {
               newItemPage = ((SdtTrn_AppVersion_Page)newCollectionPage.Item(idx));
               currItemPage = gxTv_SdtTrn_AppVersion_Page.GetByKey(newItemPage.gxTpr_Pageid);
               if ( StringUtil.StrCmp(currItemPage.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemPage.UpdateDirties(newItemPage);
                  if ( StringUtil.StrCmp(newItemPage.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemPage.gxTpr_Mode = "DLT";
                  }
                  currItemPage.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTrn_AppVersion_Page.Add(newItemPage, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "AppVersionId" )]
      [  XmlElement( ElementName = "AppVersionId"   )]
      public Guid gxTpr_Appversionid
      {
         get {
            return gxTv_SdtTrn_AppVersion_Appversionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_AppVersion_Appversionid != value )
            {
               gxTv_SdtTrn_AppVersion_Mode = "INS";
               this.gxTv_SdtTrn_AppVersion_Appversionid_Z_SetNull( );
               this.gxTv_SdtTrn_AppVersion_Appversionname_Z_SetNull( );
               this.gxTv_SdtTrn_AppVersion_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_AppVersion_Isactive_Z_SetNull( );
               if ( gxTv_SdtTrn_AppVersion_Page != null )
               {
                  GXBCLevelCollection<SdtTrn_AppVersion_Page> collectionPage = gxTv_SdtTrn_AppVersion_Page;
                  SdtTrn_AppVersion_Page currItemPage;
                  short idx = 1;
                  while ( idx <= collectionPage.Count )
                  {
                     currItemPage = ((SdtTrn_AppVersion_Page)collectionPage.Item(idx));
                     currItemPage.gxTpr_Mode = "INS";
                     currItemPage.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtTrn_AppVersion_Appversionid = value;
            SetDirty("Appversionid");
         }

      }

      [  SoapElement( ElementName = "AppVersionName" )]
      [  XmlElement( ElementName = "AppVersionName"   )]
      public string gxTpr_Appversionname
      {
         get {
            return gxTv_SdtTrn_AppVersion_Appversionname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Appversionname = value;
            SetDirty("Appversionname");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_AppVersion_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "IsActive" )]
      [  XmlElement( ElementName = "IsActive"   )]
      public bool gxTpr_Isactive
      {
         get {
            return gxTv_SdtTrn_AppVersion_Isactive ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Isactive = value;
            SetDirty("Isactive");
         }

      }

      [  SoapElement( ElementName = "Page" )]
      [  XmlArray( ElementName = "Page"  )]
      [  XmlArrayItemAttribute( ElementName= "Trn_AppVersion.Page"  , IsNullable=false)]
      public GXBCLevelCollection<SdtTrn_AppVersion_Page> gxTpr_Page_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTrn_AppVersion_Page == null )
            {
               gxTv_SdtTrn_AppVersion_Page = new GXBCLevelCollection<SdtTrn_AppVersion_Page>( context, "Trn_AppVersion.Page", "Comforta_version2");
            }
            return gxTv_SdtTrn_AppVersion_Page ;
         }

         set {
            if ( gxTv_SdtTrn_AppVersion_Page == null )
            {
               gxTv_SdtTrn_AppVersion_Page = new GXBCLevelCollection<SdtTrn_AppVersion_Page>( context, "Trn_AppVersion.Page", "Comforta_version2");
            }
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtTrn_AppVersion_Page> gxTpr_Page
      {
         get {
            if ( gxTv_SdtTrn_AppVersion_Page == null )
            {
               gxTv_SdtTrn_AppVersion_Page = new GXBCLevelCollection<SdtTrn_AppVersion_Page>( context, "Trn_AppVersion.Page", "Comforta_version2");
            }
            sdtIsNull = 0;
            return gxTv_SdtTrn_AppVersion_Page ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Page = value;
            SetDirty("Page");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Page_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Page = null;
         SetDirty("Page");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Page_IsNull( )
      {
         if ( gxTv_SdtTrn_AppVersion_Page == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_AppVersion_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Mode_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_AppVersion_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Initialized_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AppVersionId_Z" )]
      [  XmlElement( ElementName = "AppVersionId_Z"   )]
      public Guid gxTpr_Appversionid_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Appversionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Appversionid_Z = value;
            SetDirty("Appversionid_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Appversionid_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Appversionid_Z = Guid.Empty;
         SetDirty("Appversionid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Appversionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AppVersionName_Z" )]
      [  XmlElement( ElementName = "AppVersionName_Z"   )]
      public string gxTpr_Appversionname_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Appversionname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Appversionname_Z = value;
            SetDirty("Appversionname_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Appversionname_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Appversionname_Z = "";
         SetDirty("Appversionname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Appversionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IsActive_Z" )]
      [  XmlElement( ElementName = "IsActive_Z"   )]
      public bool gxTpr_Isactive_Z
      {
         get {
            return gxTv_SdtTrn_AppVersion_Isactive_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AppVersion_Isactive_Z = value;
            SetDirty("Isactive_Z");
         }

      }

      public void gxTv_SdtTrn_AppVersion_Isactive_Z_SetNull( )
      {
         gxTv_SdtTrn_AppVersion_Isactive_Z = false;
         SetDirty("Isactive_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AppVersion_Isactive_Z_IsNull( )
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
         gxTv_SdtTrn_AppVersion_Appversionid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_AppVersion_Appversionname = "";
         gxTv_SdtTrn_AppVersion_Locationid = Guid.Empty;
         gxTv_SdtTrn_AppVersion_Mode = "";
         gxTv_SdtTrn_AppVersion_Appversionid_Z = Guid.Empty;
         gxTv_SdtTrn_AppVersion_Appversionname_Z = "";
         gxTv_SdtTrn_AppVersion_Locationid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_appversion", "GeneXus.Programs.trn_appversion_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_AppVersion_Initialized ;
      private string gxTv_SdtTrn_AppVersion_Mode ;
      private bool gxTv_SdtTrn_AppVersion_Isactive ;
      private bool gxTv_SdtTrn_AppVersion_Isactive_Z ;
      private string gxTv_SdtTrn_AppVersion_Appversionname ;
      private string gxTv_SdtTrn_AppVersion_Appversionname_Z ;
      private Guid gxTv_SdtTrn_AppVersion_Appversionid ;
      private Guid gxTv_SdtTrn_AppVersion_Locationid ;
      private Guid gxTv_SdtTrn_AppVersion_Appversionid_Z ;
      private Guid gxTv_SdtTrn_AppVersion_Locationid_Z ;
      private GXBCLevelCollection<SdtTrn_AppVersion_Page> gxTv_SdtTrn_AppVersion_Page=null ;
   }

   [DataContract(Name = @"Trn_AppVersion", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AppVersion_RESTInterface : GxGenericCollectionItem<SdtTrn_AppVersion>
   {
      public SdtTrn_AppVersion_RESTInterface( ) : base()
      {
      }

      public SdtTrn_AppVersion_RESTInterface( SdtTrn_AppVersion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AppVersionId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Appversionid
      {
         get {
            return sdt.gxTpr_Appversionid ;
         }

         set {
            sdt.gxTpr_Appversionid = value;
         }

      }

      [DataMember( Name = "AppVersionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Appversionname
      {
         get {
            return sdt.gxTpr_Appversionname ;
         }

         set {
            sdt.gxTpr_Appversionname = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 2 )]
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

      [DataMember( Name = "IsActive" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Isactive
      {
         get {
            return sdt.gxTpr_Isactive ;
         }

         set {
            sdt.gxTpr_Isactive = value;
         }

      }

      [DataMember( Name = "Page" , Order = 4 )]
      public GxGenericCollection<SdtTrn_AppVersion_Page_RESTInterface> gxTpr_Page
      {
         get {
            return new GxGenericCollection<SdtTrn_AppVersion_Page_RESTInterface>(sdt.gxTpr_Page) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Page);
         }

      }

      public SdtTrn_AppVersion sdt
      {
         get {
            return (SdtTrn_AppVersion)Sdt ;
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
            sdt = new SdtTrn_AppVersion() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Trn_AppVersion", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AppVersion_RESTLInterface : GxGenericCollectionItem<SdtTrn_AppVersion>
   {
      public SdtTrn_AppVersion_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_AppVersion_RESTLInterface( SdtTrn_AppVersion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AppVersionName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Appversionname
      {
         get {
            return sdt.gxTpr_Appversionname ;
         }

         set {
            sdt.gxTpr_Appversionname = value;
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

      public SdtTrn_AppVersion sdt
      {
         get {
            return (SdtTrn_AppVersion)Sdt ;
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
            sdt = new SdtTrn_AppVersion() ;
         }
      }

   }

}
