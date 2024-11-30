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
   [XmlRoot(ElementName = "Trn_Tile.Attribute" )]
   [XmlType(TypeName =  "Trn_Tile.Attribute" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Tile_Attribute : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_Tile_Attribute( )
      {
      }

      public SdtTrn_Tile_Attribute( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"AttributeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Attribute");
         metadata.Set("BT", "Trn_TileAttribute");
         metadata.Set("PK", "[ \"AttributeId\" ]");
         metadata.Set("PKAssigned", "[ \"AttributeId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TileId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Attributeid_Z");
         state.Add("gxTpr_Attributename_Z");
         state.Add("gxTpr_Attrbutevalue_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Tile_Attribute sdt;
         sdt = (SdtTrn_Tile_Attribute)(source);
         gxTv_SdtTrn_Tile_Attribute_Attributeid = sdt.gxTv_SdtTrn_Tile_Attribute_Attributeid ;
         gxTv_SdtTrn_Tile_Attribute_Attributename = sdt.gxTv_SdtTrn_Tile_Attribute_Attributename ;
         gxTv_SdtTrn_Tile_Attribute_Attrbutevalue = sdt.gxTv_SdtTrn_Tile_Attribute_Attrbutevalue ;
         gxTv_SdtTrn_Tile_Attribute_Mode = sdt.gxTv_SdtTrn_Tile_Attribute_Mode ;
         gxTv_SdtTrn_Tile_Attribute_Modified = sdt.gxTv_SdtTrn_Tile_Attribute_Modified ;
         gxTv_SdtTrn_Tile_Attribute_Initialized = sdt.gxTv_SdtTrn_Tile_Attribute_Initialized ;
         gxTv_SdtTrn_Tile_Attribute_Attributeid_Z = sdt.gxTv_SdtTrn_Tile_Attribute_Attributeid_Z ;
         gxTv_SdtTrn_Tile_Attribute_Attributename_Z = sdt.gxTv_SdtTrn_Tile_Attribute_Attributename_Z ;
         gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z = sdt.gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z ;
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
         AddObjectProperty("AttributeId", gxTv_SdtTrn_Tile_Attribute_Attributeid, false, includeNonInitialized);
         AddObjectProperty("AttributeName", gxTv_SdtTrn_Tile_Attribute_Attributename, false, includeNonInitialized);
         AddObjectProperty("AttrbuteValue", gxTv_SdtTrn_Tile_Attribute_Attrbutevalue, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Tile_Attribute_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_Tile_Attribute_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Tile_Attribute_Initialized, false, includeNonInitialized);
            AddObjectProperty("AttributeId_Z", gxTv_SdtTrn_Tile_Attribute_Attributeid_Z, false, includeNonInitialized);
            AddObjectProperty("AttributeName_Z", gxTv_SdtTrn_Tile_Attribute_Attributename_Z, false, includeNonInitialized);
            AddObjectProperty("AttrbuteValue_Z", gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Tile_Attribute sdt )
      {
         if ( sdt.IsDirty("AttributeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributeid = sdt.gxTv_SdtTrn_Tile_Attribute_Attributeid ;
         }
         if ( sdt.IsDirty("AttributeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributename = sdt.gxTv_SdtTrn_Tile_Attribute_Attributename ;
         }
         if ( sdt.IsDirty("AttrbuteValue") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attrbutevalue = sdt.gxTv_SdtTrn_Tile_Attribute_Attrbutevalue ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AttributeId" )]
      [  XmlElement( ElementName = "AttributeId"   )]
      public Guid gxTpr_Attributeid
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attributeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributeid = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attributeid");
         }

      }

      [  SoapElement( ElementName = "AttributeName" )]
      [  XmlElement( ElementName = "AttributeName"   )]
      public string gxTpr_Attributename
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attributename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributename = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attributename");
         }

      }

      [  SoapElement( ElementName = "AttrbuteValue" )]
      [  XmlElement( ElementName = "AttrbuteValue"   )]
      public string gxTpr_Attrbutevalue
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attrbutevalue ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attrbutevalue = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attrbutevalue");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Mode_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Modified_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Initialized = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttributeId_Z" )]
      [  XmlElement( ElementName = "AttributeId_Z"   )]
      public Guid gxTpr_Attributeid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attributeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributeid_Z = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attributeid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Attributeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Attributeid_Z = Guid.Empty;
         SetDirty("Attributeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Attributeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttributeName_Z" )]
      [  XmlElement( ElementName = "AttributeName_Z"   )]
      public string gxTpr_Attributename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attributename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attributename_Z = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attributename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Attributename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Attributename_Z = "";
         SetDirty("Attributename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Attributename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttrbuteValue_Z" )]
      [  XmlElement( ElementName = "AttrbuteValue_Z"   )]
      public string gxTpr_Attrbutevalue_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z = value;
            gxTv_SdtTrn_Tile_Attribute_Modified = 1;
            SetDirty("Attrbutevalue_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z = "";
         SetDirty("Attrbutevalue_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z_IsNull( )
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
         gxTv_SdtTrn_Tile_Attribute_Attributeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Tile_Attribute_Attributename = "";
         gxTv_SdtTrn_Tile_Attribute_Attrbutevalue = "";
         gxTv_SdtTrn_Tile_Attribute_Mode = "";
         gxTv_SdtTrn_Tile_Attribute_Attributeid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Attribute_Attributename_Z = "";
         gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Tile_Attribute_Modified ;
      private short gxTv_SdtTrn_Tile_Attribute_Initialized ;
      private string gxTv_SdtTrn_Tile_Attribute_Mode ;
      private string gxTv_SdtTrn_Tile_Attribute_Attributename ;
      private string gxTv_SdtTrn_Tile_Attribute_Attrbutevalue ;
      private string gxTv_SdtTrn_Tile_Attribute_Attributename_Z ;
      private string gxTv_SdtTrn_Tile_Attribute_Attrbutevalue_Z ;
      private Guid gxTv_SdtTrn_Tile_Attribute_Attributeid ;
      private Guid gxTv_SdtTrn_Tile_Attribute_Attributeid_Z ;
   }

   [DataContract(Name = @"Trn_Tile.Attribute", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_Attribute_RESTInterface : GxGenericCollectionItem<SdtTrn_Tile_Attribute>
   {
      public SdtTrn_Tile_Attribute_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Tile_Attribute_RESTInterface( SdtTrn_Tile_Attribute psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AttributeId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Attributeid
      {
         get {
            return sdt.gxTpr_Attributeid ;
         }

         set {
            sdt.gxTpr_Attributeid = value;
         }

      }

      [DataMember( Name = "AttributeName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Attributename
      {
         get {
            return sdt.gxTpr_Attributename ;
         }

         set {
            sdt.gxTpr_Attributename = value;
         }

      }

      [DataMember( Name = "AttrbuteValue" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Attrbutevalue
      {
         get {
            return sdt.gxTpr_Attrbutevalue ;
         }

         set {
            sdt.gxTpr_Attrbutevalue = value;
         }

      }

      public SdtTrn_Tile_Attribute sdt
      {
         get {
            return (SdtTrn_Tile_Attribute)Sdt ;
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
            sdt = new SdtTrn_Tile_Attribute() ;
         }
      }

   }

   [DataContract(Name = @"Trn_Tile.Attribute", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_Attribute_RESTLInterface : GxGenericCollectionItem<SdtTrn_Tile_Attribute>
   {
      public SdtTrn_Tile_Attribute_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Tile_Attribute_RESTLInterface( SdtTrn_Tile_Attribute psdt ) : base(psdt)
      {
      }

      public SdtTrn_Tile_Attribute sdt
      {
         get {
            return (SdtTrn_Tile_Attribute)Sdt ;
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
            sdt = new SdtTrn_Tile_Attribute() ;
         }
      }

   }

}
