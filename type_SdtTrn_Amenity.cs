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
   [XmlRoot(ElementName = "Trn_Amenity" )]
   [XmlType(TypeName =  "Trn_Amenity" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Amenity : GxSilentTrnSdt
   {
      public SdtTrn_Amenity( )
      {
      }

      public SdtTrn_Amenity( IGxContext context )
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

      public void Load( Guid AV39AmenityId ,
                        Guid AV29LocationId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV39AmenityId,(Guid)AV29LocationId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AmenityId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Amenity");
         metadata.Set("BT", "Trn_Amenity");
         metadata.Set("PK", "[ \"AmenityId\",\"LocationId\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"AmenityId\",\"LocationId\",\"OrganisationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Amenityid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Amenityname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Amenity sdt;
         sdt = (SdtTrn_Amenity)(source);
         gxTv_SdtTrn_Amenity_Amenityid = sdt.gxTv_SdtTrn_Amenity_Amenityid ;
         gxTv_SdtTrn_Amenity_Locationid = sdt.gxTv_SdtTrn_Amenity_Locationid ;
         gxTv_SdtTrn_Amenity_Organisationid = sdt.gxTv_SdtTrn_Amenity_Organisationid ;
         gxTv_SdtTrn_Amenity_Amenityname = sdt.gxTv_SdtTrn_Amenity_Amenityname ;
         gxTv_SdtTrn_Amenity_Amenitydescription = sdt.gxTv_SdtTrn_Amenity_Amenitydescription ;
         gxTv_SdtTrn_Amenity_Mode = sdt.gxTv_SdtTrn_Amenity_Mode ;
         gxTv_SdtTrn_Amenity_Initialized = sdt.gxTv_SdtTrn_Amenity_Initialized ;
         gxTv_SdtTrn_Amenity_Amenityid_Z = sdt.gxTv_SdtTrn_Amenity_Amenityid_Z ;
         gxTv_SdtTrn_Amenity_Locationid_Z = sdt.gxTv_SdtTrn_Amenity_Locationid_Z ;
         gxTv_SdtTrn_Amenity_Organisationid_Z = sdt.gxTv_SdtTrn_Amenity_Organisationid_Z ;
         gxTv_SdtTrn_Amenity_Amenityname_Z = sdt.gxTv_SdtTrn_Amenity_Amenityname_Z ;
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
         AddObjectProperty("AmenityId", gxTv_SdtTrn_Amenity_Amenityid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Amenity_Locationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Amenity_Organisationid, false, includeNonInitialized);
         AddObjectProperty("AmenityName", gxTv_SdtTrn_Amenity_Amenityname, false, includeNonInitialized);
         AddObjectProperty("AmenityDescription", gxTv_SdtTrn_Amenity_Amenitydescription, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Amenity_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Amenity_Initialized, false, includeNonInitialized);
            AddObjectProperty("AmenityId_Z", gxTv_SdtTrn_Amenity_Amenityid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Amenity_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Amenity_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("AmenityName_Z", gxTv_SdtTrn_Amenity_Amenityname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Amenity sdt )
      {
         if ( sdt.IsDirty("AmenityId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenityid = sdt.gxTv_SdtTrn_Amenity_Amenityid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Locationid = sdt.gxTv_SdtTrn_Amenity_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Organisationid = sdt.gxTv_SdtTrn_Amenity_Organisationid ;
         }
         if ( sdt.IsDirty("AmenityName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenityname = sdt.gxTv_SdtTrn_Amenity_Amenityname ;
         }
         if ( sdt.IsDirty("AmenityDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenitydescription = sdt.gxTv_SdtTrn_Amenity_Amenitydescription ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AmenityId" )]
      [  XmlElement( ElementName = "AmenityId"   )]
      public Guid gxTpr_Amenityid
      {
         get {
            return gxTv_SdtTrn_Amenity_Amenityid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Amenity_Amenityid != value )
            {
               gxTv_SdtTrn_Amenity_Mode = "INS";
               this.gxTv_SdtTrn_Amenity_Amenityid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Amenityname_Z_SetNull( );
            }
            gxTv_SdtTrn_Amenity_Amenityid = value;
            SetDirty("Amenityid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Amenity_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Amenity_Locationid != value )
            {
               gxTv_SdtTrn_Amenity_Mode = "INS";
               this.gxTv_SdtTrn_Amenity_Amenityid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Amenityname_Z_SetNull( );
            }
            gxTv_SdtTrn_Amenity_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Amenity_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Amenity_Organisationid != value )
            {
               gxTv_SdtTrn_Amenity_Mode = "INS";
               this.gxTv_SdtTrn_Amenity_Amenityid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Amenity_Amenityname_Z_SetNull( );
            }
            gxTv_SdtTrn_Amenity_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "AmenityName" )]
      [  XmlElement( ElementName = "AmenityName"   )]
      public string gxTpr_Amenityname
      {
         get {
            return gxTv_SdtTrn_Amenity_Amenityname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenityname = value;
            SetDirty("Amenityname");
         }

      }

      [  SoapElement( ElementName = "AmenityDescription" )]
      [  XmlElement( ElementName = "AmenityDescription"   )]
      public string gxTpr_Amenitydescription
      {
         get {
            return gxTv_SdtTrn_Amenity_Amenitydescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenitydescription = value;
            SetDirty("Amenitydescription");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Amenity_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Amenity_Mode_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Amenity_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Amenity_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenityId_Z" )]
      [  XmlElement( ElementName = "AmenityId_Z"   )]
      public Guid gxTpr_Amenityid_Z
      {
         get {
            return gxTv_SdtTrn_Amenity_Amenityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenityid_Z = value;
            SetDirty("Amenityid_Z");
         }

      }

      public void gxTv_SdtTrn_Amenity_Amenityid_Z_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Amenityid_Z = Guid.Empty;
         SetDirty("Amenityid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Amenityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Amenity_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Amenity_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Amenity_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Amenity_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenityName_Z" )]
      [  XmlElement( ElementName = "AmenityName_Z"   )]
      public string gxTpr_Amenityname_Z
      {
         get {
            return gxTv_SdtTrn_Amenity_Amenityname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Amenity_Amenityname_Z = value;
            SetDirty("Amenityname_Z");
         }

      }

      public void gxTv_SdtTrn_Amenity_Amenityname_Z_SetNull( )
      {
         gxTv_SdtTrn_Amenity_Amenityname_Z = "";
         SetDirty("Amenityname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Amenity_Amenityname_Z_IsNull( )
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
         gxTv_SdtTrn_Amenity_Amenityid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Amenity_Locationid = Guid.Empty;
         gxTv_SdtTrn_Amenity_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Amenity_Amenityname = "";
         gxTv_SdtTrn_Amenity_Amenitydescription = "";
         gxTv_SdtTrn_Amenity_Mode = "";
         gxTv_SdtTrn_Amenity_Amenityid_Z = Guid.Empty;
         gxTv_SdtTrn_Amenity_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Amenity_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Amenity_Amenityname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_amenity", "GeneXus.Programs.trn_amenity_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Amenity_Initialized ;
      private string gxTv_SdtTrn_Amenity_Mode ;
      private string gxTv_SdtTrn_Amenity_Amenitydescription ;
      private string gxTv_SdtTrn_Amenity_Amenityname ;
      private string gxTv_SdtTrn_Amenity_Amenityname_Z ;
      private Guid gxTv_SdtTrn_Amenity_Amenityid ;
      private Guid gxTv_SdtTrn_Amenity_Locationid ;
      private Guid gxTv_SdtTrn_Amenity_Organisationid ;
      private Guid gxTv_SdtTrn_Amenity_Amenityid_Z ;
      private Guid gxTv_SdtTrn_Amenity_Locationid_Z ;
      private Guid gxTv_SdtTrn_Amenity_Organisationid_Z ;
   }

   [DataContract(Name = @"Trn_Amenity", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Amenity_RESTInterface : GxGenericCollectionItem<SdtTrn_Amenity>
   {
      public SdtTrn_Amenity_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Amenity_RESTInterface( SdtTrn_Amenity psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AmenityId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Amenityid
      {
         get {
            return sdt.gxTpr_Amenityid ;
         }

         set {
            sdt.gxTpr_Amenityid = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 1 )]
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

      [DataMember( Name = "OrganisationId" , Order = 2 )]
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

      [DataMember( Name = "AmenityName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Amenityname
      {
         get {
            return sdt.gxTpr_Amenityname ;
         }

         set {
            sdt.gxTpr_Amenityname = value;
         }

      }

      [DataMember( Name = "AmenityDescription" , Order = 4 )]
      public string gxTpr_Amenitydescription
      {
         get {
            return sdt.gxTpr_Amenitydescription ;
         }

         set {
            sdt.gxTpr_Amenitydescription = value;
         }

      }

      public SdtTrn_Amenity sdt
      {
         get {
            return (SdtTrn_Amenity)Sdt ;
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
            sdt = new SdtTrn_Amenity() ;
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

   [DataContract(Name = @"Trn_Amenity", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Amenity_RESTLInterface : GxGenericCollectionItem<SdtTrn_Amenity>
   {
      public SdtTrn_Amenity_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Amenity_RESTLInterface( SdtTrn_Amenity psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AmenityName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Amenityname
      {
         get {
            return sdt.gxTpr_Amenityname ;
         }

         set {
            sdt.gxTpr_Amenityname = value;
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

      public SdtTrn_Amenity sdt
      {
         get {
            return (SdtTrn_Amenity)Sdt ;
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
            sdt = new SdtTrn_Amenity() ;
         }
      }

   }

}
