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
   [XmlRoot(ElementName = "Trn_Tile" )]
   [XmlType(TypeName =  "Trn_Tile" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Tile : GxSilentTrnSdt
   {
      public SdtTrn_Tile( )
      {
      }

      public SdtTrn_Tile( IGxContext context )
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

      public void Load( Guid AV407TileId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV407TileId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TileId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Tile");
         metadata.Set("BT", "Trn_Tile");
         metadata.Set("PK", "[ \"TileId\" ]");
         metadata.Set("PKAssigned", "[ \"TileId\" ]");
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
         state.Add("gxTpr_Tileid_Z");
         state.Add("gxTpr_Tilename_Z");
         state.Add("gxTpr_Tilebgcolor_Z");
         state.Add("gxTpr_Tilebgimageurl_Z");
         state.Add("gxTpr_Tiletextcolor_Z");
         state.Add("gxTpr_Tiletextalignment_Z");
         state.Add("gxTpr_Tileicon_Z");
         state.Add("gxTpr_Tileiconalignment_Z");
         state.Add("gxTpr_Tileiconcolor_Z");
         state.Add("gxTpr_Tilebgcolor_N");
         state.Add("gxTpr_Tilebgimageurl_N");
         state.Add("gxTpr_Tileicon_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Tile sdt;
         sdt = (SdtTrn_Tile)(source);
         gxTv_SdtTrn_Tile_Tileid = sdt.gxTv_SdtTrn_Tile_Tileid ;
         gxTv_SdtTrn_Tile_Tilename = sdt.gxTv_SdtTrn_Tile_Tilename ;
         gxTv_SdtTrn_Tile_Tilebgcolor = sdt.gxTv_SdtTrn_Tile_Tilebgcolor ;
         gxTv_SdtTrn_Tile_Tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl ;
         gxTv_SdtTrn_Tile_Tiletextcolor = sdt.gxTv_SdtTrn_Tile_Tiletextcolor ;
         gxTv_SdtTrn_Tile_Tiletextalignment = sdt.gxTv_SdtTrn_Tile_Tiletextalignment ;
         gxTv_SdtTrn_Tile_Tileicon = sdt.gxTv_SdtTrn_Tile_Tileicon ;
         gxTv_SdtTrn_Tile_Tileiconalignment = sdt.gxTv_SdtTrn_Tile_Tileiconalignment ;
         gxTv_SdtTrn_Tile_Tileiconcolor = sdt.gxTv_SdtTrn_Tile_Tileiconcolor ;
         gxTv_SdtTrn_Tile_Tileaction = sdt.gxTv_SdtTrn_Tile_Tileaction ;
         gxTv_SdtTrn_Tile_Mode = sdt.gxTv_SdtTrn_Tile_Mode ;
         gxTv_SdtTrn_Tile_Initialized = sdt.gxTv_SdtTrn_Tile_Initialized ;
         gxTv_SdtTrn_Tile_Tileid_Z = sdt.gxTv_SdtTrn_Tile_Tileid_Z ;
         gxTv_SdtTrn_Tile_Tilename_Z = sdt.gxTv_SdtTrn_Tile_Tilename_Z ;
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = sdt.gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = sdt.gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = sdt.gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
         gxTv_SdtTrn_Tile_Tileicon_Z = sdt.gxTv_SdtTrn_Tile_Tileicon_Z ;
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = sdt.gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = sdt.gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
         gxTv_SdtTrn_Tile_Tilebgcolor_N = sdt.gxTv_SdtTrn_Tile_Tilebgcolor_N ;
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
         gxTv_SdtTrn_Tile_Tileicon_N = sdt.gxTv_SdtTrn_Tile_Tileicon_N ;
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
         AddObjectProperty("TileId", gxTv_SdtTrn_Tile_Tileid, false, includeNonInitialized);
         AddObjectProperty("TileName", gxTv_SdtTrn_Tile_Tilename, false, includeNonInitialized);
         AddObjectProperty("TileBGColor", gxTv_SdtTrn_Tile_Tilebgcolor, false, includeNonInitialized);
         AddObjectProperty("TileBGColor_N", gxTv_SdtTrn_Tile_Tilebgcolor_N, false, includeNonInitialized);
         AddObjectProperty("TileBGImageUrl", gxTv_SdtTrn_Tile_Tilebgimageurl, false, includeNonInitialized);
         AddObjectProperty("TileBGImageUrl_N", gxTv_SdtTrn_Tile_Tilebgimageurl_N, false, includeNonInitialized);
         AddObjectProperty("TileTextColor", gxTv_SdtTrn_Tile_Tiletextcolor, false, includeNonInitialized);
         AddObjectProperty("TileTextAlignment", gxTv_SdtTrn_Tile_Tiletextalignment, false, includeNonInitialized);
         AddObjectProperty("TileIcon", gxTv_SdtTrn_Tile_Tileicon, false, includeNonInitialized);
         AddObjectProperty("TileIcon_N", gxTv_SdtTrn_Tile_Tileicon_N, false, includeNonInitialized);
         AddObjectProperty("TileIconAlignment", gxTv_SdtTrn_Tile_Tileiconalignment, false, includeNonInitialized);
         AddObjectProperty("TileIconColor", gxTv_SdtTrn_Tile_Tileiconcolor, false, includeNonInitialized);
         AddObjectProperty("TileAction", gxTv_SdtTrn_Tile_Tileaction, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Tile_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Tile_Initialized, false, includeNonInitialized);
            AddObjectProperty("TileId_Z", gxTv_SdtTrn_Tile_Tileid_Z, false, includeNonInitialized);
            AddObjectProperty("TileName_Z", gxTv_SdtTrn_Tile_Tilename_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGColor_Z", gxTv_SdtTrn_Tile_Tilebgcolor_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGImageUrl_Z", gxTv_SdtTrn_Tile_Tilebgimageurl_Z, false, includeNonInitialized);
            AddObjectProperty("TileTextColor_Z", gxTv_SdtTrn_Tile_Tiletextcolor_Z, false, includeNonInitialized);
            AddObjectProperty("TileTextAlignment_Z", gxTv_SdtTrn_Tile_Tiletextalignment_Z, false, includeNonInitialized);
            AddObjectProperty("TileIcon_Z", gxTv_SdtTrn_Tile_Tileicon_Z, false, includeNonInitialized);
            AddObjectProperty("TileIconAlignment_Z", gxTv_SdtTrn_Tile_Tileiconalignment_Z, false, includeNonInitialized);
            AddObjectProperty("TileIconColor_Z", gxTv_SdtTrn_Tile_Tileiconcolor_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGColor_N", gxTv_SdtTrn_Tile_Tilebgcolor_N, false, includeNonInitialized);
            AddObjectProperty("TileBGImageUrl_N", gxTv_SdtTrn_Tile_Tilebgimageurl_N, false, includeNonInitialized);
            AddObjectProperty("TileIcon_N", gxTv_SdtTrn_Tile_Tileicon_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Tile sdt )
      {
         if ( sdt.IsDirty("TileId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileid = sdt.gxTv_SdtTrn_Tile_Tileid ;
         }
         if ( sdt.IsDirty("TileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename = sdt.gxTv_SdtTrn_Tile_Tilename ;
         }
         if ( sdt.IsDirty("TileBGColor") )
         {
            gxTv_SdtTrn_Tile_Tilebgcolor_N = (short)(sdt.gxTv_SdtTrn_Tile_Tilebgcolor_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor = sdt.gxTv_SdtTrn_Tile_Tilebgcolor ;
         }
         if ( sdt.IsDirty("TileBGImageUrl") )
         {
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = (short)(sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl ;
         }
         if ( sdt.IsDirty("TileTextColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor = sdt.gxTv_SdtTrn_Tile_Tiletextcolor ;
         }
         if ( sdt.IsDirty("TileTextAlignment") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment = sdt.gxTv_SdtTrn_Tile_Tiletextalignment ;
         }
         if ( sdt.IsDirty("TileIcon") )
         {
            gxTv_SdtTrn_Tile_Tileicon_N = (short)(sdt.gxTv_SdtTrn_Tile_Tileicon_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon = sdt.gxTv_SdtTrn_Tile_Tileicon ;
         }
         if ( sdt.IsDirty("TileIconAlignment") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment = sdt.gxTv_SdtTrn_Tile_Tileiconalignment ;
         }
         if ( sdt.IsDirty("TileIconColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor = sdt.gxTv_SdtTrn_Tile_Tileiconcolor ;
         }
         if ( sdt.IsDirty("TileAction") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileaction = sdt.gxTv_SdtTrn_Tile_Tileaction ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TileId" )]
      [  XmlElement( ElementName = "TileId"   )]
      public Guid gxTpr_Tileid
      {
         get {
            return gxTv_SdtTrn_Tile_Tileid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Tile_Tileid != value )
            {
               gxTv_SdtTrn_Tile_Mode = "INS";
               this.gxTv_SdtTrn_Tile_Tileid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilebgcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilebgimageurl_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tiletextcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tiletextalignment_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileicon_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileiconalignment_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileiconcolor_Z_SetNull( );
            }
            gxTv_SdtTrn_Tile_Tileid = value;
            SetDirty("Tileid");
         }

      }

      [  SoapElement( ElementName = "TileName" )]
      [  XmlElement( ElementName = "TileName"   )]
      public string gxTpr_Tilename
      {
         get {
            return gxTv_SdtTrn_Tile_Tilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename = value;
            SetDirty("Tilename");
         }

      }

      [  SoapElement( ElementName = "TileBGColor" )]
      [  XmlElement( ElementName = "TileBGColor"   )]
      public string gxTpr_Tilebgcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor ;
         }

         set {
            gxTv_SdtTrn_Tile_Tilebgcolor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor = value;
            SetDirty("Tilebgcolor");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_N = 1;
         gxTv_SdtTrn_Tile_Tilebgcolor = "";
         SetDirty("Tilebgcolor");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tilebgcolor_N==1) ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl" )]
      [  XmlElement( ElementName = "TileBGImageUrl"   )]
      public string gxTpr_Tilebgimageurl
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl ;
         }

         set {
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl = value;
            SetDirty("Tilebgimageurl");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = 1;
         gxTv_SdtTrn_Tile_Tilebgimageurl = "";
         SetDirty("Tilebgimageurl");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tilebgimageurl_N==1) ;
      }

      [  SoapElement( ElementName = "TileTextColor" )]
      [  XmlElement( ElementName = "TileTextColor"   )]
      public string gxTpr_Tiletextcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor = value;
            SetDirty("Tiletextcolor");
         }

      }

      [  SoapElement( ElementName = "TileTextAlignment" )]
      [  XmlElement( ElementName = "TileTextAlignment"   )]
      public string gxTpr_Tiletextalignment
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextalignment ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment = value;
            SetDirty("Tiletextalignment");
         }

      }

      [  SoapElement( ElementName = "TileIcon" )]
      [  XmlElement( ElementName = "TileIcon"   )]
      public string gxTpr_Tileicon
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon ;
         }

         set {
            gxTv_SdtTrn_Tile_Tileicon_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon = value;
            SetDirty("Tileicon");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_N = 1;
         gxTv_SdtTrn_Tile_Tileicon = "";
         SetDirty("Tileicon");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tileicon_N==1) ;
      }

      [  SoapElement( ElementName = "TileIconAlignment" )]
      [  XmlElement( ElementName = "TileIconAlignment"   )]
      public string gxTpr_Tileiconalignment
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconalignment ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment = value;
            SetDirty("Tileiconalignment");
         }

      }

      [  SoapElement( ElementName = "TileIconColor" )]
      [  XmlElement( ElementName = "TileIconColor"   )]
      public string gxTpr_Tileiconcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor = value;
            SetDirty("Tileiconcolor");
         }

      }

      [  SoapElement( ElementName = "TileAction" )]
      [  XmlElement( ElementName = "TileAction"   )]
      public string gxTpr_Tileaction
      {
         get {
            return gxTv_SdtTrn_Tile_Tileaction ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileaction = value;
            SetDirty("Tileaction");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Tile_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Tile_Mode_SetNull( )
      {
         gxTv_SdtTrn_Tile_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Tile_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Tile_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Tile_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileId_Z" )]
      [  XmlElement( ElementName = "TileId_Z"   )]
      public Guid gxTpr_Tileid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileid_Z = value;
            SetDirty("Tileid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileid_Z = Guid.Empty;
         SetDirty("Tileid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileName_Z" )]
      [  XmlElement( ElementName = "TileName_Z"   )]
      public string gxTpr_Tilename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename_Z = value;
            SetDirty("Tilename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilename_Z = "";
         SetDirty("Tilename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGColor_Z" )]
      [  XmlElement( ElementName = "TileBGColor_Z"   )]
      public string gxTpr_Tilebgcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor_Z = value;
            SetDirty("Tilebgcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = "";
         SetDirty("Tilebgcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl_Z" )]
      [  XmlElement( ElementName = "TileBGImageUrl_Z"   )]
      public string gxTpr_Tilebgimageurl_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl_Z = value;
            SetDirty("Tilebgimageurl_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = "";
         SetDirty("Tilebgimageurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileTextColor_Z" )]
      [  XmlElement( ElementName = "TileTextColor_Z"   )]
      public string gxTpr_Tiletextcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor_Z = value;
            SetDirty("Tiletextcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tiletextcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = "";
         SetDirty("Tiletextcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tiletextcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileTextAlignment_Z" )]
      [  XmlElement( ElementName = "TileTextAlignment_Z"   )]
      public string gxTpr_Tiletextalignment_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment_Z = value;
            SetDirty("Tiletextalignment_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tiletextalignment_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = "";
         SetDirty("Tiletextalignment_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tiletextalignment_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIcon_Z" )]
      [  XmlElement( ElementName = "TileIcon_Z"   )]
      public string gxTpr_Tileicon_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon_Z = value;
            SetDirty("Tileicon_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_Z = "";
         SetDirty("Tileicon_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIconAlignment_Z" )]
      [  XmlElement( ElementName = "TileIconAlignment_Z"   )]
      public string gxTpr_Tileiconalignment_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment_Z = value;
            SetDirty("Tileiconalignment_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileiconalignment_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = "";
         SetDirty("Tileiconalignment_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileiconalignment_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIconColor_Z" )]
      [  XmlElement( ElementName = "TileIconColor_Z"   )]
      public string gxTpr_Tileiconcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor_Z = value;
            SetDirty("Tileiconcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileiconcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = "";
         SetDirty("Tileiconcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileiconcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGColor_N" )]
      [  XmlElement( ElementName = "TileBGColor_N"   )]
      public short gxTpr_Tilebgcolor_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor_N = value;
            SetDirty("Tilebgcolor_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_N = 0;
         SetDirty("Tilebgcolor_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl_N" )]
      [  XmlElement( ElementName = "TileBGImageUrl_N"   )]
      public short gxTpr_Tilebgimageurl_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = value;
            SetDirty("Tilebgimageurl_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = 0;
         SetDirty("Tilebgimageurl_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIcon_N" )]
      [  XmlElement( ElementName = "TileIcon_N"   )]
      public short gxTpr_Tileicon_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon_N = value;
            SetDirty("Tileicon_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_N = 0;
         SetDirty("Tileicon_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_N_IsNull( )
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
         gxTv_SdtTrn_Tile_Tileid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Tile_Tilename = "";
         gxTv_SdtTrn_Tile_Tilebgcolor = "";
         gxTv_SdtTrn_Tile_Tilebgimageurl = "";
         gxTv_SdtTrn_Tile_Tiletextcolor = "";
         gxTv_SdtTrn_Tile_Tiletextalignment = "";
         gxTv_SdtTrn_Tile_Tileicon = "";
         gxTv_SdtTrn_Tile_Tileiconalignment = "";
         gxTv_SdtTrn_Tile_Tileiconcolor = "";
         gxTv_SdtTrn_Tile_Tileaction = "";
         gxTv_SdtTrn_Tile_Mode = "";
         gxTv_SdtTrn_Tile_Tileid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Tilename_Z = "";
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = "";
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = "";
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = "";
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = "";
         gxTv_SdtTrn_Tile_Tileicon_Z = "";
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = "";
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_tile", "GeneXus.Programs.trn_tile_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Tile_Initialized ;
      private short gxTv_SdtTrn_Tile_Tilebgcolor_N ;
      private short gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
      private short gxTv_SdtTrn_Tile_Tileicon_N ;
      private string gxTv_SdtTrn_Tile_Tilebgcolor ;
      private string gxTv_SdtTrn_Tile_Tiletextcolor ;
      private string gxTv_SdtTrn_Tile_Tiletextalignment ;
      private string gxTv_SdtTrn_Tile_Tileicon ;
      private string gxTv_SdtTrn_Tile_Tileiconalignment ;
      private string gxTv_SdtTrn_Tile_Tileiconcolor ;
      private string gxTv_SdtTrn_Tile_Mode ;
      private string gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
      private string gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
      private string gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
      private string gxTv_SdtTrn_Tile_Tileicon_Z ;
      private string gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
      private string gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
      private string gxTv_SdtTrn_Tile_Tileaction ;
      private string gxTv_SdtTrn_Tile_Tilename ;
      private string gxTv_SdtTrn_Tile_Tilebgimageurl ;
      private string gxTv_SdtTrn_Tile_Tilename_Z ;
      private string gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
      private Guid gxTv_SdtTrn_Tile_Tileid ;
      private Guid gxTv_SdtTrn_Tile_Tileid_Z ;
   }

   [DataContract(Name = @"Trn_Tile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_RESTInterface : GxGenericCollectionItem<SdtTrn_Tile>
   {
      public SdtTrn_Tile_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Tile_RESTInterface( SdtTrn_Tile psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TileId" , Order = 0 )]
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

      [DataMember( Name = "TileName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tilename
      {
         get {
            return sdt.gxTpr_Tilename ;
         }

         set {
            sdt.gxTpr_Tilename = value;
         }

      }

      [DataMember( Name = "TileBGColor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tilebgcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tilebgcolor) ;
         }

         set {
            sdt.gxTpr_Tilebgcolor = value;
         }

      }

      [DataMember( Name = "TileBGImageUrl" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Tilebgimageurl
      {
         get {
            return sdt.gxTpr_Tilebgimageurl ;
         }

         set {
            sdt.gxTpr_Tilebgimageurl = value;
         }

      }

      [DataMember( Name = "TileTextColor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Tiletextcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tiletextcolor) ;
         }

         set {
            sdt.gxTpr_Tiletextcolor = value;
         }

      }

      [DataMember( Name = "TileTextAlignment" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tiletextalignment
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tiletextalignment) ;
         }

         set {
            sdt.gxTpr_Tiletextalignment = value;
         }

      }

      [DataMember( Name = "TileIcon" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Tileicon
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileicon) ;
         }

         set {
            sdt.gxTpr_Tileicon = value;
         }

      }

      [DataMember( Name = "TileIconAlignment" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tileiconalignment
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileiconalignment) ;
         }

         set {
            sdt.gxTpr_Tileiconalignment = value;
         }

      }

      [DataMember( Name = "TileIconColor" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tileiconcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileiconcolor) ;
         }

         set {
            sdt.gxTpr_Tileiconcolor = value;
         }

      }

      [DataMember( Name = "TileAction" , Order = 9 )]
      public string gxTpr_Tileaction
      {
         get {
            return sdt.gxTpr_Tileaction ;
         }

         set {
            sdt.gxTpr_Tileaction = value;
         }

      }

      public SdtTrn_Tile sdt
      {
         get {
            return (SdtTrn_Tile)Sdt ;
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
            sdt = new SdtTrn_Tile() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"Trn_Tile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_RESTLInterface : GxGenericCollectionItem<SdtTrn_Tile>
   {
      public SdtTrn_Tile_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Tile_RESTLInterface( SdtTrn_Tile psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TileName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tilename
      {
         get {
            return sdt.gxTpr_Tilename ;
         }

         set {
            sdt.gxTpr_Tilename = value;
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

      public SdtTrn_Tile sdt
      {
         get {
            return (SdtTrn_Tile)Sdt ;
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
            sdt = new SdtTrn_Tile() ;
         }
      }

   }

}
