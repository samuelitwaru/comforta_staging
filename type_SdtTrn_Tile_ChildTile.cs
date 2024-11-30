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
   [XmlRoot(ElementName = "Trn_Tile.ChildTile" )]
   [XmlType(TypeName =  "Trn_Tile.ChildTile" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Tile_ChildTile : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_Tile_ChildTile( )
      {
      }

      public SdtTrn_Tile_ChildTile( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"SG_TileId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ChildTile");
         metadata.Set("BT", "Trn_TileChildTile");
         metadata.Set("PK", "[ \"SG_TileId\" ]");
         metadata.Set("PKAssigned", "[ \"SG_TileId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"Trn_TileId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Trn_TileId\" ],\"FKMap\":[ \"SG_TileId-Trn_TileId\" ] } ]");
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
         state.Add("gxTpr_Sg_tileid_Z");
         state.Add("gxTpr_Sg_tilename_Z");
         state.Add("gxTpr_Sg_tilewidth_Z");
         state.Add("gxTpr_Sg_tilecolor_Z");
         state.Add("gxTpr_Sg_tilebgimageurl_Z");
         state.Add("gxTpr_Childtileorder_Z");
         state.Add("gxTpr_Sg_tilewidth_N");
         state.Add("gxTpr_Sg_tilecolor_N");
         state.Add("gxTpr_Sg_tilebgimageurl_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Tile_ChildTile sdt;
         sdt = (SdtTrn_Tile_ChildTile)(source);
         gxTv_SdtTrn_Tile_ChildTile_Sg_tileid = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tileid ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilename = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilename ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl ;
         gxTv_SdtTrn_Tile_ChildTile_Childtileorder = sdt.gxTv_SdtTrn_Tile_ChildTile_Childtileorder ;
         gxTv_SdtTrn_Tile_ChildTile_Mode = sdt.gxTv_SdtTrn_Tile_ChildTile_Mode ;
         gxTv_SdtTrn_Tile_ChildTile_Modified = sdt.gxTv_SdtTrn_Tile_ChildTile_Modified ;
         gxTv_SdtTrn_Tile_ChildTile_Initialized = sdt.gxTv_SdtTrn_Tile_ChildTile_Initialized ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z = sdt.gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N ;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N ;
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
         AddObjectProperty("SG_TileId", gxTv_SdtTrn_Tile_ChildTile_Sg_tileid, false, includeNonInitialized);
         AddObjectProperty("SG_TileName", gxTv_SdtTrn_Tile_ChildTile_Sg_tilename, false, includeNonInitialized);
         AddObjectProperty("SG_TileWidth", gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth, false, includeNonInitialized);
         AddObjectProperty("SG_TileWidth_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N, false, includeNonInitialized);
         AddObjectProperty("SG_TileColor", gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor, false, includeNonInitialized);
         AddObjectProperty("SG_TileColor_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N, false, includeNonInitialized);
         AddObjectProperty("SG_TileBGImageUrl", gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl, false, includeNonInitialized);
         AddObjectProperty("SG_TileBGImageUrl_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N, false, includeNonInitialized);
         AddObjectProperty("ChildTileOrder", gxTv_SdtTrn_Tile_ChildTile_Childtileorder, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Tile_ChildTile_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_Tile_ChildTile_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Tile_ChildTile_Initialized, false, includeNonInitialized);
            AddObjectProperty("SG_TileId_Z", gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_TileName_Z", gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z, false, includeNonInitialized);
            AddObjectProperty("SG_TileWidth_Z", gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z, false, includeNonInitialized);
            AddObjectProperty("SG_TileColor_Z", gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z, false, includeNonInitialized);
            AddObjectProperty("SG_TileBGImageUrl_Z", gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z, false, includeNonInitialized);
            AddObjectProperty("ChildTileOrder_Z", gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z, false, includeNonInitialized);
            AddObjectProperty("SG_TileWidth_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N, false, includeNonInitialized);
            AddObjectProperty("SG_TileColor_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N, false, includeNonInitialized);
            AddObjectProperty("SG_TileBGImageUrl_N", gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Tile_ChildTile sdt )
      {
         if ( sdt.IsDirty("SG_TileId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tileid = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tileid ;
         }
         if ( sdt.IsDirty("SG_TileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilename = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilename ;
         }
         if ( sdt.IsDirty("SG_TileWidth") )
         {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = (short)(sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth ;
         }
         if ( sdt.IsDirty("SG_TileColor") )
         {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = (short)(sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor ;
         }
         if ( sdt.IsDirty("SG_TileBGImageUrl") )
         {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = (short)(sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl = sdt.gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl ;
         }
         if ( sdt.IsDirty("ChildTileOrder") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Childtileorder = sdt.gxTv_SdtTrn_Tile_ChildTile_Childtileorder ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SG_TileId" )]
      [  XmlElement( ElementName = "SG_TileId"   )]
      public Guid gxTpr_Sg_tileid
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tileid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tileid = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tileid");
         }

      }

      [  SoapElement( ElementName = "SG_TileName" )]
      [  XmlElement( ElementName = "SG_TileName"   )]
      public string gxTpr_Sg_tilename
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilename = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilename");
         }

      }

      [  SoapElement( ElementName = "SG_TileWidth" )]
      [  XmlElement( ElementName = "SG_TileWidth"   )]
      public short gxTpr_Sg_tilewidth
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth ;
         }

         set {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilewidth");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = 1;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth = 0;
         SetDirty("Sg_tilewidth");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N==1) ;
      }

      [  SoapElement( ElementName = "SG_TileColor" )]
      [  XmlElement( ElementName = "SG_TileColor"   )]
      public string gxTpr_Sg_tilecolor
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor ;
         }

         set {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilecolor");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = 1;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor = "";
         SetDirty("Sg_tilecolor");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N==1) ;
      }

      [  SoapElement( ElementName = "SG_TileBGImageUrl" )]
      [  XmlElement( ElementName = "SG_TileBGImageUrl"   )]
      public string gxTpr_Sg_tilebgimageurl
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl ;
         }

         set {
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilebgimageurl");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = 1;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl = "";
         SetDirty("Sg_tilebgimageurl");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N==1) ;
      }

      [  SoapElement( ElementName = "ChildTileOrder" )]
      [  XmlElement( ElementName = "ChildTileOrder"   )]
      public short gxTpr_Childtileorder
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Childtileorder ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Childtileorder = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Childtileorder");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Mode_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Modified_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Initialized = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileId_Z" )]
      [  XmlElement( ElementName = "SG_TileId_Z"   )]
      public Guid gxTpr_Sg_tileid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tileid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z = Guid.Empty;
         SetDirty("Sg_tileid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileName_Z" )]
      [  XmlElement( ElementName = "SG_TileName_Z"   )]
      public string gxTpr_Sg_tilename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z = "";
         SetDirty("Sg_tilename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileWidth_Z" )]
      [  XmlElement( ElementName = "SG_TileWidth_Z"   )]
      public short gxTpr_Sg_tilewidth_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilewidth_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z = 0;
         SetDirty("Sg_tilewidth_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileColor_Z" )]
      [  XmlElement( ElementName = "SG_TileColor_Z"   )]
      public string gxTpr_Sg_tilecolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilecolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z = "";
         SetDirty("Sg_tilecolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileBGImageUrl_Z" )]
      [  XmlElement( ElementName = "SG_TileBGImageUrl_Z"   )]
      public string gxTpr_Sg_tilebgimageurl_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilebgimageurl_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z = "";
         SetDirty("Sg_tilebgimageurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChildTileOrder_Z" )]
      [  XmlElement( ElementName = "ChildTileOrder_Z"   )]
      public short gxTpr_Childtileorder_Z
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Childtileorder_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z = 0;
         SetDirty("Childtileorder_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileWidth_N" )]
      [  XmlElement( ElementName = "SG_TileWidth_N"   )]
      public short gxTpr_Sg_tilewidth_N
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilewidth_N");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N = 0;
         SetDirty("Sg_tilewidth_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileColor_N" )]
      [  XmlElement( ElementName = "SG_TileColor_N"   )]
      public short gxTpr_Sg_tilecolor_N
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilecolor_N");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N = 0;
         SetDirty("Sg_tilecolor_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_TileBGImageUrl_N" )]
      [  XmlElement( ElementName = "SG_TileBGImageUrl_N"   )]
      public short gxTpr_Sg_tilebgimageurl_N
      {
         get {
            return gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = value;
            gxTv_SdtTrn_Tile_ChildTile_Modified = 1;
            SetDirty("Sg_tilebgimageurl_N");
         }

      }

      public void gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N = 0;
         SetDirty("Sg_tilebgimageurl_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N_IsNull( )
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
         gxTv_SdtTrn_Tile_ChildTile_Sg_tileid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilename = "";
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor = "";
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl = "";
         gxTv_SdtTrn_Tile_ChildTile_Mode = "";
         gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z = "";
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z = "";
         gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth ;
      private short gxTv_SdtTrn_Tile_ChildTile_Childtileorder ;
      private short gxTv_SdtTrn_Tile_ChildTile_Modified ;
      private short gxTv_SdtTrn_Tile_ChildTile_Initialized ;
      private short gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_Z ;
      private short gxTv_SdtTrn_Tile_ChildTile_Childtileorder_Z ;
      private short gxTv_SdtTrn_Tile_ChildTile_Sg_tilewidth_N ;
      private short gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_N ;
      private short gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_N ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor ;
      private string gxTv_SdtTrn_Tile_ChildTile_Mode ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilecolor_Z ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilename ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilename_Z ;
      private string gxTv_SdtTrn_Tile_ChildTile_Sg_tilebgimageurl_Z ;
      private Guid gxTv_SdtTrn_Tile_ChildTile_Sg_tileid ;
      private Guid gxTv_SdtTrn_Tile_ChildTile_Sg_tileid_Z ;
   }

   [DataContract(Name = @"Trn_Tile.ChildTile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_ChildTile_RESTInterface : GxGenericCollectionItem<SdtTrn_Tile_ChildTile>
   {
      public SdtTrn_Tile_ChildTile_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Tile_ChildTile_RESTInterface( SdtTrn_Tile_ChildTile psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SG_TileId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_tileid
      {
         get {
            return sdt.gxTpr_Sg_tileid ;
         }

         set {
            sdt.gxTpr_Sg_tileid = value;
         }

      }

      [DataMember( Name = "SG_TileName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Sg_tilename
      {
         get {
            return sdt.gxTpr_Sg_tilename ;
         }

         set {
            sdt.gxTpr_Sg_tilename = value;
         }

      }

      [DataMember( Name = "SG_TileWidth" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sg_tilewidth
      {
         get {
            return sdt.gxTpr_Sg_tilewidth ;
         }

         set {
            sdt.gxTpr_Sg_tilewidth = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SG_TileColor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Sg_tilecolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sg_tilecolor) ;
         }

         set {
            sdt.gxTpr_Sg_tilecolor = value;
         }

      }

      [DataMember( Name = "SG_TileBGImageUrl" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Sg_tilebgimageurl
      {
         get {
            return sdt.gxTpr_Sg_tilebgimageurl ;
         }

         set {
            sdt.gxTpr_Sg_tilebgimageurl = value;
         }

      }

      [DataMember( Name = "ChildTileOrder" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Childtileorder
      {
         get {
            return sdt.gxTpr_Childtileorder ;
         }

         set {
            sdt.gxTpr_Childtileorder = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtTrn_Tile_ChildTile sdt
      {
         get {
            return (SdtTrn_Tile_ChildTile)Sdt ;
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
            sdt = new SdtTrn_Tile_ChildTile() ;
         }
      }

   }

   [DataContract(Name = @"Trn_Tile.ChildTile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_ChildTile_RESTLInterface : GxGenericCollectionItem<SdtTrn_Tile_ChildTile>
   {
      public SdtTrn_Tile_ChildTile_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Tile_ChildTile_RESTLInterface( SdtTrn_Tile_ChildTile psdt ) : base(psdt)
      {
      }

      public SdtTrn_Tile_ChildTile sdt
      {
         get {
            return (SdtTrn_Tile_ChildTile)Sdt ;
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
            sdt = new SdtTrn_Tile_ChildTile() ;
         }
      }

   }

}
