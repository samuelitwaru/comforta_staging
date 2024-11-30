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
   [XmlRoot(ElementName = "Trn_Col" )]
   [XmlType(TypeName =  "Trn_Col" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Col : GxSilentTrnSdt
   {
      public SdtTrn_Col( )
      {
      }

      public SdtTrn_Col( IGxContext context )
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

      public void Load( Guid AV328Trn_ColId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV328Trn_ColId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_ColId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Col");
         metadata.Set("BT", "Trn_Col");
         metadata.Set("PK", "[ \"Trn_ColId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_ColId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TileId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Trn_RowId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Trn_colid_Z");
         state.Add("gxTpr_Trn_rowid_Z");
         state.Add("gxTpr_Trn_colname_Z");
         state.Add("gxTpr_Tileid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Col sdt;
         sdt = (SdtTrn_Col)(source);
         gxTv_SdtTrn_Col_Trn_colid = sdt.gxTv_SdtTrn_Col_Trn_colid ;
         gxTv_SdtTrn_Col_Trn_rowid = sdt.gxTv_SdtTrn_Col_Trn_rowid ;
         gxTv_SdtTrn_Col_Trn_colname = sdt.gxTv_SdtTrn_Col_Trn_colname ;
         gxTv_SdtTrn_Col_Tileid = sdt.gxTv_SdtTrn_Col_Tileid ;
         gxTv_SdtTrn_Col_Mode = sdt.gxTv_SdtTrn_Col_Mode ;
         gxTv_SdtTrn_Col_Initialized = sdt.gxTv_SdtTrn_Col_Initialized ;
         gxTv_SdtTrn_Col_Trn_colid_Z = sdt.gxTv_SdtTrn_Col_Trn_colid_Z ;
         gxTv_SdtTrn_Col_Trn_rowid_Z = sdt.gxTv_SdtTrn_Col_Trn_rowid_Z ;
         gxTv_SdtTrn_Col_Trn_colname_Z = sdt.gxTv_SdtTrn_Col_Trn_colname_Z ;
         gxTv_SdtTrn_Col_Tileid_Z = sdt.gxTv_SdtTrn_Col_Tileid_Z ;
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
         AddObjectProperty("Trn_ColId", gxTv_SdtTrn_Col_Trn_colid, false, includeNonInitialized);
         AddObjectProperty("Trn_RowId", gxTv_SdtTrn_Col_Trn_rowid, false, includeNonInitialized);
         AddObjectProperty("Trn_ColName", gxTv_SdtTrn_Col_Trn_colname, false, includeNonInitialized);
         AddObjectProperty("TileId", gxTv_SdtTrn_Col_Tileid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Col_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Col_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_ColId_Z", gxTv_SdtTrn_Col_Trn_colid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_RowId_Z", gxTv_SdtTrn_Col_Trn_rowid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ColName_Z", gxTv_SdtTrn_Col_Trn_colname_Z, false, includeNonInitialized);
            AddObjectProperty("TileId_Z", gxTv_SdtTrn_Col_Tileid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Col sdt )
      {
         if ( sdt.IsDirty("Trn_ColId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_colid = sdt.gxTv_SdtTrn_Col_Trn_colid ;
         }
         if ( sdt.IsDirty("Trn_RowId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_rowid = sdt.gxTv_SdtTrn_Col_Trn_rowid ;
         }
         if ( sdt.IsDirty("Trn_ColName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_colname = sdt.gxTv_SdtTrn_Col_Trn_colname ;
         }
         if ( sdt.IsDirty("TileId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Tileid = sdt.gxTv_SdtTrn_Col_Tileid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_ColId" )]
      [  XmlElement( ElementName = "Trn_ColId"   )]
      public Guid gxTpr_Trn_colid
      {
         get {
            return gxTv_SdtTrn_Col_Trn_colid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Col_Trn_colid != value )
            {
               gxTv_SdtTrn_Col_Mode = "INS";
               this.gxTv_SdtTrn_Col_Trn_colid_Z_SetNull( );
               this.gxTv_SdtTrn_Col_Trn_rowid_Z_SetNull( );
               this.gxTv_SdtTrn_Col_Trn_colname_Z_SetNull( );
               this.gxTv_SdtTrn_Col_Tileid_Z_SetNull( );
            }
            gxTv_SdtTrn_Col_Trn_colid = value;
            SetDirty("Trn_colid");
         }

      }

      [  SoapElement( ElementName = "Trn_RowId" )]
      [  XmlElement( ElementName = "Trn_RowId"   )]
      public Guid gxTpr_Trn_rowid
      {
         get {
            return gxTv_SdtTrn_Col_Trn_rowid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_rowid = value;
            SetDirty("Trn_rowid");
         }

      }

      [  SoapElement( ElementName = "Trn_ColName" )]
      [  XmlElement( ElementName = "Trn_ColName"   )]
      public string gxTpr_Trn_colname
      {
         get {
            return gxTv_SdtTrn_Col_Trn_colname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_colname = value;
            SetDirty("Trn_colname");
         }

      }

      [  SoapElement( ElementName = "TileId" )]
      [  XmlElement( ElementName = "TileId"   )]
      public Guid gxTpr_Tileid
      {
         get {
            return gxTv_SdtTrn_Col_Tileid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Tileid = value;
            SetDirty("Tileid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Col_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Col_Mode_SetNull( )
      {
         gxTv_SdtTrn_Col_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Col_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Col_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Col_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ColId_Z" )]
      [  XmlElement( ElementName = "Trn_ColId_Z"   )]
      public Guid gxTpr_Trn_colid_Z
      {
         get {
            return gxTv_SdtTrn_Col_Trn_colid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_colid_Z = value;
            SetDirty("Trn_colid_Z");
         }

      }

      public void gxTv_SdtTrn_Col_Trn_colid_Z_SetNull( )
      {
         gxTv_SdtTrn_Col_Trn_colid_Z = Guid.Empty;
         SetDirty("Trn_colid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Trn_colid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_RowId_Z" )]
      [  XmlElement( ElementName = "Trn_RowId_Z"   )]
      public Guid gxTpr_Trn_rowid_Z
      {
         get {
            return gxTv_SdtTrn_Col_Trn_rowid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_rowid_Z = value;
            SetDirty("Trn_rowid_Z");
         }

      }

      public void gxTv_SdtTrn_Col_Trn_rowid_Z_SetNull( )
      {
         gxTv_SdtTrn_Col_Trn_rowid_Z = Guid.Empty;
         SetDirty("Trn_rowid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Trn_rowid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ColName_Z" )]
      [  XmlElement( ElementName = "Trn_ColName_Z"   )]
      public string gxTpr_Trn_colname_Z
      {
         get {
            return gxTv_SdtTrn_Col_Trn_colname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Trn_colname_Z = value;
            SetDirty("Trn_colname_Z");
         }

      }

      public void gxTv_SdtTrn_Col_Trn_colname_Z_SetNull( )
      {
         gxTv_SdtTrn_Col_Trn_colname_Z = "";
         SetDirty("Trn_colname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Trn_colname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileId_Z" )]
      [  XmlElement( ElementName = "TileId_Z"   )]
      public Guid gxTpr_Tileid_Z
      {
         get {
            return gxTv_SdtTrn_Col_Tileid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Col_Tileid_Z = value;
            SetDirty("Tileid_Z");
         }

      }

      public void gxTv_SdtTrn_Col_Tileid_Z_SetNull( )
      {
         gxTv_SdtTrn_Col_Tileid_Z = Guid.Empty;
         SetDirty("Tileid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Col_Tileid_Z_IsNull( )
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
         gxTv_SdtTrn_Col_Trn_colid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Col_Trn_rowid = Guid.Empty;
         gxTv_SdtTrn_Col_Trn_colname = "";
         gxTv_SdtTrn_Col_Tileid = Guid.Empty;
         gxTv_SdtTrn_Col_Mode = "";
         gxTv_SdtTrn_Col_Trn_colid_Z = Guid.Empty;
         gxTv_SdtTrn_Col_Trn_rowid_Z = Guid.Empty;
         gxTv_SdtTrn_Col_Trn_colname_Z = "";
         gxTv_SdtTrn_Col_Tileid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_col", "GeneXus.Programs.trn_col_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Col_Initialized ;
      private string gxTv_SdtTrn_Col_Mode ;
      private string gxTv_SdtTrn_Col_Trn_colname ;
      private string gxTv_SdtTrn_Col_Trn_colname_Z ;
      private Guid gxTv_SdtTrn_Col_Trn_colid ;
      private Guid gxTv_SdtTrn_Col_Trn_rowid ;
      private Guid gxTv_SdtTrn_Col_Tileid ;
      private Guid gxTv_SdtTrn_Col_Trn_colid_Z ;
      private Guid gxTv_SdtTrn_Col_Trn_rowid_Z ;
      private Guid gxTv_SdtTrn_Col_Tileid_Z ;
   }

   [DataContract(Name = @"Trn_Col", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Col_RESTInterface : GxGenericCollectionItem<SdtTrn_Col>
   {
      public SdtTrn_Col_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Col_RESTInterface( SdtTrn_Col psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_ColId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_colid
      {
         get {
            return sdt.gxTpr_Trn_colid ;
         }

         set {
            sdt.gxTpr_Trn_colid = value;
         }

      }

      [DataMember( Name = "Trn_RowId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_rowid
      {
         get {
            return sdt.gxTpr_Trn_rowid ;
         }

         set {
            sdt.gxTpr_Trn_rowid = value;
         }

      }

      [DataMember( Name = "Trn_ColName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Trn_colname
      {
         get {
            return sdt.gxTpr_Trn_colname ;
         }

         set {
            sdt.gxTpr_Trn_colname = value;
         }

      }

      [DataMember( Name = "TileId" , Order = 3 )]
      [GxSeudo()]
      public Guid gxTpr_Tileid
      {
         get {
            return sdt.gxTpr_Tileid ;
         }

         set {
            sdt.gxTpr_Tileid = value;
         }

      }

      public SdtTrn_Col sdt
      {
         get {
            return (SdtTrn_Col)Sdt ;
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
            sdt = new SdtTrn_Col() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Trn_Col", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Col_RESTLInterface : GxGenericCollectionItem<SdtTrn_Col>
   {
      public SdtTrn_Col_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Col_RESTLInterface( SdtTrn_Col psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_ColName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_colname
      {
         get {
            return sdt.gxTpr_Trn_colname ;
         }

         set {
            sdt.gxTpr_Trn_colname = value;
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

      public SdtTrn_Col sdt
      {
         get {
            return (SdtTrn_Col)Sdt ;
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
            sdt = new SdtTrn_Col() ;
         }
      }

   }

}
