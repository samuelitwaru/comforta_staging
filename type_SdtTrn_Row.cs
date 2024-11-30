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
   [XmlRoot(ElementName = "Trn_Row" )]
   [XmlType(TypeName =  "Trn_Row" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Row : GxSilentTrnSdt
   {
      public SdtTrn_Row( )
      {
      }

      public SdtTrn_Row( IGxContext context )
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

      public void Load( Guid AV319Trn_RowId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV319Trn_RowId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_RowId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Row");
         metadata.Set("BT", "Trn_Row");
         metadata.Set("PK", "[ \"Trn_RowId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_RowId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"Trn_PageId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Trn_rowid_Z");
         state.Add("gxTpr_Trn_rowname_Z");
         state.Add("gxTpr_Trn_pageid_Z");
         state.Add("gxTpr_Trn_pagename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Row sdt;
         sdt = (SdtTrn_Row)(source);
         gxTv_SdtTrn_Row_Trn_rowid = sdt.gxTv_SdtTrn_Row_Trn_rowid ;
         gxTv_SdtTrn_Row_Trn_rowname = sdt.gxTv_SdtTrn_Row_Trn_rowname ;
         gxTv_SdtTrn_Row_Trn_pageid = sdt.gxTv_SdtTrn_Row_Trn_pageid ;
         gxTv_SdtTrn_Row_Trn_pagename = sdt.gxTv_SdtTrn_Row_Trn_pagename ;
         gxTv_SdtTrn_Row_Mode = sdt.gxTv_SdtTrn_Row_Mode ;
         gxTv_SdtTrn_Row_Initialized = sdt.gxTv_SdtTrn_Row_Initialized ;
         gxTv_SdtTrn_Row_Trn_rowid_Z = sdt.gxTv_SdtTrn_Row_Trn_rowid_Z ;
         gxTv_SdtTrn_Row_Trn_rowname_Z = sdt.gxTv_SdtTrn_Row_Trn_rowname_Z ;
         gxTv_SdtTrn_Row_Trn_pageid_Z = sdt.gxTv_SdtTrn_Row_Trn_pageid_Z ;
         gxTv_SdtTrn_Row_Trn_pagename_Z = sdt.gxTv_SdtTrn_Row_Trn_pagename_Z ;
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
         AddObjectProperty("Trn_RowId", gxTv_SdtTrn_Row_Trn_rowid, false, includeNonInitialized);
         AddObjectProperty("Trn_RowName", gxTv_SdtTrn_Row_Trn_rowname, false, includeNonInitialized);
         AddObjectProperty("Trn_PageId", gxTv_SdtTrn_Row_Trn_pageid, false, includeNonInitialized);
         AddObjectProperty("Trn_PageName", gxTv_SdtTrn_Row_Trn_pagename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Row_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Row_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_RowId_Z", gxTv_SdtTrn_Row_Trn_rowid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_RowName_Z", gxTv_SdtTrn_Row_Trn_rowname_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_PageId_Z", gxTv_SdtTrn_Row_Trn_pageid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_PageName_Z", gxTv_SdtTrn_Row_Trn_pagename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Row sdt )
      {
         if ( sdt.IsDirty("Trn_RowId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_rowid = sdt.gxTv_SdtTrn_Row_Trn_rowid ;
         }
         if ( sdt.IsDirty("Trn_RowName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_rowname = sdt.gxTv_SdtTrn_Row_Trn_rowname ;
         }
         if ( sdt.IsDirty("Trn_PageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pageid = sdt.gxTv_SdtTrn_Row_Trn_pageid ;
         }
         if ( sdt.IsDirty("Trn_PageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pagename = sdt.gxTv_SdtTrn_Row_Trn_pagename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_RowId" )]
      [  XmlElement( ElementName = "Trn_RowId"   )]
      public Guid gxTpr_Trn_rowid
      {
         get {
            return gxTv_SdtTrn_Row_Trn_rowid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Row_Trn_rowid != value )
            {
               gxTv_SdtTrn_Row_Mode = "INS";
               this.gxTv_SdtTrn_Row_Trn_rowid_Z_SetNull( );
               this.gxTv_SdtTrn_Row_Trn_rowname_Z_SetNull( );
               this.gxTv_SdtTrn_Row_Trn_pageid_Z_SetNull( );
               this.gxTv_SdtTrn_Row_Trn_pagename_Z_SetNull( );
            }
            gxTv_SdtTrn_Row_Trn_rowid = value;
            SetDirty("Trn_rowid");
         }

      }

      [  SoapElement( ElementName = "Trn_RowName" )]
      [  XmlElement( ElementName = "Trn_RowName"   )]
      public string gxTpr_Trn_rowname
      {
         get {
            return gxTv_SdtTrn_Row_Trn_rowname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_rowname = value;
            SetDirty("Trn_rowname");
         }

      }

      [  SoapElement( ElementName = "Trn_PageId" )]
      [  XmlElement( ElementName = "Trn_PageId"   )]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return gxTv_SdtTrn_Row_Trn_pageid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pageid = value;
            SetDirty("Trn_pageid");
         }

      }

      [  SoapElement( ElementName = "Trn_PageName" )]
      [  XmlElement( ElementName = "Trn_PageName"   )]
      public string gxTpr_Trn_pagename
      {
         get {
            return gxTv_SdtTrn_Row_Trn_pagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pagename = value;
            SetDirty("Trn_pagename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Row_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Row_Mode_SetNull( )
      {
         gxTv_SdtTrn_Row_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Row_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Row_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Row_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_RowId_Z" )]
      [  XmlElement( ElementName = "Trn_RowId_Z"   )]
      public Guid gxTpr_Trn_rowid_Z
      {
         get {
            return gxTv_SdtTrn_Row_Trn_rowid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_rowid_Z = value;
            SetDirty("Trn_rowid_Z");
         }

      }

      public void gxTv_SdtTrn_Row_Trn_rowid_Z_SetNull( )
      {
         gxTv_SdtTrn_Row_Trn_rowid_Z = Guid.Empty;
         SetDirty("Trn_rowid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Trn_rowid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_RowName_Z" )]
      [  XmlElement( ElementName = "Trn_RowName_Z"   )]
      public string gxTpr_Trn_rowname_Z
      {
         get {
            return gxTv_SdtTrn_Row_Trn_rowname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_rowname_Z = value;
            SetDirty("Trn_rowname_Z");
         }

      }

      public void gxTv_SdtTrn_Row_Trn_rowname_Z_SetNull( )
      {
         gxTv_SdtTrn_Row_Trn_rowname_Z = "";
         SetDirty("Trn_rowname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Trn_rowname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageId_Z" )]
      [  XmlElement( ElementName = "Trn_PageId_Z"   )]
      public Guid gxTpr_Trn_pageid_Z
      {
         get {
            return gxTv_SdtTrn_Row_Trn_pageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pageid_Z = value;
            SetDirty("Trn_pageid_Z");
         }

      }

      public void gxTv_SdtTrn_Row_Trn_pageid_Z_SetNull( )
      {
         gxTv_SdtTrn_Row_Trn_pageid_Z = Guid.Empty;
         SetDirty("Trn_pageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Trn_pageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageName_Z" )]
      [  XmlElement( ElementName = "Trn_PageName_Z"   )]
      public string gxTpr_Trn_pagename_Z
      {
         get {
            return gxTv_SdtTrn_Row_Trn_pagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Row_Trn_pagename_Z = value;
            SetDirty("Trn_pagename_Z");
         }

      }

      public void gxTv_SdtTrn_Row_Trn_pagename_Z_SetNull( )
      {
         gxTv_SdtTrn_Row_Trn_pagename_Z = "";
         SetDirty("Trn_pagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Row_Trn_pagename_Z_IsNull( )
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
         gxTv_SdtTrn_Row_Trn_rowid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Row_Trn_rowname = "";
         gxTv_SdtTrn_Row_Trn_pageid = Guid.Empty;
         gxTv_SdtTrn_Row_Trn_pagename = "";
         gxTv_SdtTrn_Row_Mode = "";
         gxTv_SdtTrn_Row_Trn_rowid_Z = Guid.Empty;
         gxTv_SdtTrn_Row_Trn_rowname_Z = "";
         gxTv_SdtTrn_Row_Trn_pageid_Z = Guid.Empty;
         gxTv_SdtTrn_Row_Trn_pagename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_row", "GeneXus.Programs.trn_row_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Row_Initialized ;
      private string gxTv_SdtTrn_Row_Mode ;
      private string gxTv_SdtTrn_Row_Trn_rowname ;
      private string gxTv_SdtTrn_Row_Trn_pagename ;
      private string gxTv_SdtTrn_Row_Trn_rowname_Z ;
      private string gxTv_SdtTrn_Row_Trn_pagename_Z ;
      private Guid gxTv_SdtTrn_Row_Trn_rowid ;
      private Guid gxTv_SdtTrn_Row_Trn_pageid ;
      private Guid gxTv_SdtTrn_Row_Trn_rowid_Z ;
      private Guid gxTv_SdtTrn_Row_Trn_pageid_Z ;
   }

   [DataContract(Name = @"Trn_Row", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Row_RESTInterface : GxGenericCollectionItem<SdtTrn_Row>
   {
      public SdtTrn_Row_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Row_RESTInterface( SdtTrn_Row psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_RowId" , Order = 0 )]
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

      [DataMember( Name = "Trn_RowName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_rowname
      {
         get {
            return sdt.gxTpr_Trn_rowname ;
         }

         set {
            sdt.gxTpr_Trn_rowname = value;
         }

      }

      [DataMember( Name = "Trn_PageId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return sdt.gxTpr_Trn_pageid ;
         }

         set {
            sdt.gxTpr_Trn_pageid = value;
         }

      }

      [DataMember( Name = "Trn_PageName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Trn_pagename
      {
         get {
            return sdt.gxTpr_Trn_pagename ;
         }

         set {
            sdt.gxTpr_Trn_pagename = value;
         }

      }

      public SdtTrn_Row sdt
      {
         get {
            return (SdtTrn_Row)Sdt ;
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
            sdt = new SdtTrn_Row() ;
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

   [DataContract(Name = @"Trn_Row", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Row_RESTLInterface : GxGenericCollectionItem<SdtTrn_Row>
   {
      public SdtTrn_Row_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Row_RESTLInterface( SdtTrn_Row psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_RowName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_rowname
      {
         get {
            return sdt.gxTpr_Trn_rowname ;
         }

         set {
            sdt.gxTpr_Trn_rowname = value;
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

      public SdtTrn_Row sdt
      {
         get {
            return (SdtTrn_Row)Sdt ;
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
            sdt = new SdtTrn_Row() ;
         }
      }

   }

}
