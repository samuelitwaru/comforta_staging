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
   [XmlRoot(ElementName = "Trn_ResidentNotification" )]
   [XmlType(TypeName =  "Trn_ResidentNotification" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_ResidentNotification : GxSilentTrnSdt
   {
      public SdtTrn_ResidentNotification( )
      {
      }

      public SdtTrn_ResidentNotification( IGxContext context )
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

      public void Load( Guid AV497ResidentNotificationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV497ResidentNotificationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ResidentNotificationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_ResidentNotification");
         metadata.Set("BT", "Trn_ResidentNotification");
         metadata.Set("PK", "[ \"ResidentNotificationId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentNotificationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AppNotificationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Residentnotificationid_Z");
         state.Add("gxTpr_Appnotificationid_Z");
         state.Add("gxTpr_Residentid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_ResidentNotification sdt;
         sdt = (SdtTrn_ResidentNotification)(source);
         gxTv_SdtTrn_ResidentNotification_Residentnotificationid = sdt.gxTv_SdtTrn_ResidentNotification_Residentnotificationid ;
         gxTv_SdtTrn_ResidentNotification_Appnotificationid = sdt.gxTv_SdtTrn_ResidentNotification_Appnotificationid ;
         gxTv_SdtTrn_ResidentNotification_Residentid = sdt.gxTv_SdtTrn_ResidentNotification_Residentid ;
         gxTv_SdtTrn_ResidentNotification_Mode = sdt.gxTv_SdtTrn_ResidentNotification_Mode ;
         gxTv_SdtTrn_ResidentNotification_Initialized = sdt.gxTv_SdtTrn_ResidentNotification_Initialized ;
         gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z = sdt.gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z ;
         gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z = sdt.gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z ;
         gxTv_SdtTrn_ResidentNotification_Residentid_Z = sdt.gxTv_SdtTrn_ResidentNotification_Residentid_Z ;
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
         AddObjectProperty("ResidentNotificationId", gxTv_SdtTrn_ResidentNotification_Residentnotificationid, false, includeNonInitialized);
         AddObjectProperty("AppNotificationId", gxTv_SdtTrn_ResidentNotification_Appnotificationid, false, includeNonInitialized);
         AddObjectProperty("ResidentId", gxTv_SdtTrn_ResidentNotification_Residentid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_ResidentNotification_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_ResidentNotification_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentNotificationId_Z", gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z, false, includeNonInitialized);
            AddObjectProperty("AppNotificationId_Z", gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentId_Z", gxTv_SdtTrn_ResidentNotification_Residentid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_ResidentNotification sdt )
      {
         if ( sdt.IsDirty("ResidentNotificationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Residentnotificationid = sdt.gxTv_SdtTrn_ResidentNotification_Residentnotificationid ;
         }
         if ( sdt.IsDirty("AppNotificationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Appnotificationid = sdt.gxTv_SdtTrn_ResidentNotification_Appnotificationid ;
         }
         if ( sdt.IsDirty("ResidentId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Residentid = sdt.gxTv_SdtTrn_ResidentNotification_Residentid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentNotificationId" )]
      [  XmlElement( ElementName = "ResidentNotificationId"   )]
      public Guid gxTpr_Residentnotificationid
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Residentnotificationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ResidentNotification_Residentnotificationid != value )
            {
               gxTv_SdtTrn_ResidentNotification_Mode = "INS";
               this.gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentNotification_Residentid_Z_SetNull( );
            }
            gxTv_SdtTrn_ResidentNotification_Residentnotificationid = value;
            SetDirty("Residentnotificationid");
         }

      }

      [  SoapElement( ElementName = "AppNotificationId" )]
      [  XmlElement( ElementName = "AppNotificationId"   )]
      public Guid gxTpr_Appnotificationid
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Appnotificationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Appnotificationid = value;
            SetDirty("Appnotificationid");
         }

      }

      [  SoapElement( ElementName = "ResidentId" )]
      [  XmlElement( ElementName = "ResidentId"   )]
      public Guid gxTpr_Residentid
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Residentid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Residentid = value;
            SetDirty("Residentid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_ResidentNotification_Mode_SetNull( )
      {
         gxTv_SdtTrn_ResidentNotification_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentNotification_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_ResidentNotification_Initialized_SetNull( )
      {
         gxTv_SdtTrn_ResidentNotification_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentNotification_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentNotificationId_Z" )]
      [  XmlElement( ElementName = "ResidentNotificationId_Z"   )]
      public Guid gxTpr_Residentnotificationid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z = value;
            SetDirty("Residentnotificationid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z = Guid.Empty;
         SetDirty("Residentnotificationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AppNotificationId_Z" )]
      [  XmlElement( ElementName = "AppNotificationId_Z"   )]
      public Guid gxTpr_Appnotificationid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z = value;
            SetDirty("Appnotificationid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z = Guid.Empty;
         SetDirty("Appnotificationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentId_Z" )]
      [  XmlElement( ElementName = "ResidentId_Z"   )]
      public Guid gxTpr_Residentid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentNotification_Residentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentNotification_Residentid_Z = value;
            SetDirty("Residentid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentNotification_Residentid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentNotification_Residentid_Z = Guid.Empty;
         SetDirty("Residentid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentNotification_Residentid_Z_IsNull( )
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
         gxTv_SdtTrn_ResidentNotification_Residentnotificationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_ResidentNotification_Appnotificationid = Guid.Empty;
         gxTv_SdtTrn_ResidentNotification_Residentid = Guid.Empty;
         gxTv_SdtTrn_ResidentNotification_Mode = "";
         gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentNotification_Residentid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_residentnotification", "GeneXus.Programs.trn_residentnotification_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_ResidentNotification_Initialized ;
      private string gxTv_SdtTrn_ResidentNotification_Mode ;
      private Guid gxTv_SdtTrn_ResidentNotification_Residentnotificationid ;
      private Guid gxTv_SdtTrn_ResidentNotification_Appnotificationid ;
      private Guid gxTv_SdtTrn_ResidentNotification_Residentid ;
      private Guid gxTv_SdtTrn_ResidentNotification_Residentnotificationid_Z ;
      private Guid gxTv_SdtTrn_ResidentNotification_Appnotificationid_Z ;
      private Guid gxTv_SdtTrn_ResidentNotification_Residentid_Z ;
   }

   [DataContract(Name = @"Trn_ResidentNotification", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentNotification_RESTInterface : GxGenericCollectionItem<SdtTrn_ResidentNotification>
   {
      public SdtTrn_ResidentNotification_RESTInterface( ) : base()
      {
      }

      public SdtTrn_ResidentNotification_RESTInterface( SdtTrn_ResidentNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentNotificationId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Residentnotificationid
      {
         get {
            return sdt.gxTpr_Residentnotificationid ;
         }

         set {
            sdt.gxTpr_Residentnotificationid = value;
         }

      }

      [DataMember( Name = "AppNotificationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Appnotificationid
      {
         get {
            return sdt.gxTpr_Appnotificationid ;
         }

         set {
            sdt.gxTpr_Appnotificationid = value;
         }

      }

      [DataMember( Name = "ResidentId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Residentid
      {
         get {
            return sdt.gxTpr_Residentid ;
         }

         set {
            sdt.gxTpr_Residentid = value;
         }

      }

      public SdtTrn_ResidentNotification sdt
      {
         get {
            return (SdtTrn_ResidentNotification)Sdt ;
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
            sdt = new SdtTrn_ResidentNotification() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Trn_ResidentNotification", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentNotification_RESTLInterface : GxGenericCollectionItem<SdtTrn_ResidentNotification>
   {
      public SdtTrn_ResidentNotification_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_ResidentNotification_RESTLInterface( SdtTrn_ResidentNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_ResidentNotification sdt
      {
         get {
            return (SdtTrn_ResidentNotification)Sdt ;
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
            sdt = new SdtTrn_ResidentNotification() ;
         }
      }

   }

}
