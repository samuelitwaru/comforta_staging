/*
				   File: type_SdtSDT_Tile
			Description: SDT_Tile
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_Tile")]
	[XmlType(TypeName="SDT_Tile" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Tile : GxUserType
	{
		public SdtSDT_Tile( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Tile_Tilename = "";

			gxTv_SdtSDT_Tile_Tiletext = "";

			gxTv_SdtSDT_Tile_Tiletextcolor = "";

			gxTv_SdtSDT_Tile_Tiletextalignment = "";

			gxTv_SdtSDT_Tile_Tileicon = "";

			gxTv_SdtSDT_Tile_Tileiconcolor = "";

			gxTv_SdtSDT_Tile_Tileiconalignment = "";

			gxTv_SdtSDT_Tile_Tilebgcolor = "";

			gxTv_SdtSDT_Tile_Tilebgimageurl = "";

		}

		public SdtSDT_Tile(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("TileId", gxTpr_Tileid, false);


			AddObjectProperty("TileName", gxTpr_Tilename, false);


			AddObjectProperty("TileText", gxTpr_Tiletext, false);


			AddObjectProperty("TileTextColor", gxTpr_Tiletextcolor, false);


			AddObjectProperty("TileTextAlignment", gxTpr_Tiletextalignment, false);


			AddObjectProperty("TileIcon", gxTpr_Tileicon, false);


			AddObjectProperty("TileIconColor", gxTpr_Tileiconcolor, false);


			AddObjectProperty("TileIconAlignment", gxTpr_Tileiconalignment, false);


			AddObjectProperty("TileBGColor", gxTpr_Tilebgcolor, false);


			AddObjectProperty("TileBGImageUrl", gxTpr_Tilebgimageurl, false);


			AddObjectProperty("TileBGImageOpacity", gxTpr_Tilebgimageopacity, false);

			if (gxTv_SdtSDT_Tile_Tileaction != null)
			{
				AddObjectProperty("TileAction", gxTv_SdtSDT_Tile_Tileaction, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TileId")]
		[XmlElement(ElementName="TileId")]
		public Guid gxTpr_Tileid
		{
			get {
				return gxTv_SdtSDT_Tile_Tileid; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileid = value;
				SetDirty("Tileid");
			}
		}




		[SoapElement(ElementName="TileName")]
		[XmlElement(ElementName="TileName")]
		public string gxTpr_Tilename
		{
			get {
				return gxTv_SdtSDT_Tile_Tilename; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilename = value;
				SetDirty("Tilename");
			}
		}




		[SoapElement(ElementName="TileText")]
		[XmlElement(ElementName="TileText")]
		public string gxTpr_Tiletext
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletext; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletext = value;
				SetDirty("Tiletext");
			}
		}




		[SoapElement(ElementName="TileTextColor")]
		[XmlElement(ElementName="TileTextColor")]
		public string gxTpr_Tiletextcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletextcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletextcolor = value;
				SetDirty("Tiletextcolor");
			}
		}




		[SoapElement(ElementName="TileTextAlignment")]
		[XmlElement(ElementName="TileTextAlignment")]
		public string gxTpr_Tiletextalignment
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletextalignment; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletextalignment = value;
				SetDirty("Tiletextalignment");
			}
		}




		[SoapElement(ElementName="TileIcon")]
		[XmlElement(ElementName="TileIcon")]
		public string gxTpr_Tileicon
		{
			get {
				return gxTv_SdtSDT_Tile_Tileicon; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileicon = value;
				SetDirty("Tileicon");
			}
		}




		[SoapElement(ElementName="TileIconColor")]
		[XmlElement(ElementName="TileIconColor")]
		public string gxTpr_Tileiconcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tileiconcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileiconcolor = value;
				SetDirty("Tileiconcolor");
			}
		}




		[SoapElement(ElementName="TileIconAlignment")]
		[XmlElement(ElementName="TileIconAlignment")]
		public string gxTpr_Tileiconalignment
		{
			get {
				return gxTv_SdtSDT_Tile_Tileiconalignment; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileiconalignment = value;
				SetDirty("Tileiconalignment");
			}
		}




		[SoapElement(ElementName="TileBGColor")]
		[XmlElement(ElementName="TileBGColor")]
		public string gxTpr_Tilebgcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgcolor = value;
				SetDirty("Tilebgcolor");
			}
		}




		[SoapElement(ElementName="TileBGImageUrl")]
		[XmlElement(ElementName="TileBGImageUrl")]
		public string gxTpr_Tilebgimageurl
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgimageurl; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgimageurl = value;
				SetDirty("Tilebgimageurl");
			}
		}




		[SoapElement(ElementName="TileBGImageOpacity")]
		[XmlElement(ElementName="TileBGImageOpacity")]
		public short gxTpr_Tilebgimageopacity
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgimageopacity; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgimageopacity = value;
				SetDirty("Tilebgimageopacity");
			}
		}



		[SoapElement(ElementName="TileAction")]
		[XmlElement(ElementName="TileAction")]
		public GeneXus.Programs.SdtSDT_TileAction gxTpr_Tileaction
		{
			get {
				if ( gxTv_SdtSDT_Tile_Tileaction == null )
				{
					gxTv_SdtSDT_Tile_Tileaction = new GeneXus.Programs.SdtSDT_TileAction(context);
				}
				return gxTv_SdtSDT_Tile_Tileaction; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileaction = value;
				SetDirty("Tileaction");
			}
		}
		public void gxTv_SdtSDT_Tile_Tileaction_SetNull()
		{
			gxTv_SdtSDT_Tile_Tileaction_N = true;
			gxTv_SdtSDT_Tile_Tileaction = null;
		}

		public bool gxTv_SdtSDT_Tile_Tileaction_IsNull()
		{
			return gxTv_SdtSDT_Tile_Tileaction == null;
		}
		public bool ShouldSerializegxTpr_Tileaction_Json()
		{
			return gxTv_SdtSDT_Tile_Tileaction != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_Tile_Tilename = "";
			gxTv_SdtSDT_Tile_Tiletext = "";
			gxTv_SdtSDT_Tile_Tiletextcolor = "";
			gxTv_SdtSDT_Tile_Tiletextalignment = "";
			gxTv_SdtSDT_Tile_Tileicon = "";
			gxTv_SdtSDT_Tile_Tileiconcolor = "";
			gxTv_SdtSDT_Tile_Tileiconalignment = "";
			gxTv_SdtSDT_Tile_Tilebgcolor = "";
			gxTv_SdtSDT_Tile_Tilebgimageurl = "";


			gxTv_SdtSDT_Tile_Tileaction_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Tile_Tileid;
		 

		protected string gxTv_SdtSDT_Tile_Tilename;
		 

		protected string gxTv_SdtSDT_Tile_Tiletext;
		 

		protected string gxTv_SdtSDT_Tile_Tiletextcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tiletextalignment;
		 

		protected string gxTv_SdtSDT_Tile_Tileicon;
		 

		protected string gxTv_SdtSDT_Tile_Tileiconcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tileiconalignment;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgimageurl;
		 

		protected short gxTv_SdtSDT_Tile_Tilebgimageopacity;
		 

		protected GeneXus.Programs.SdtSDT_TileAction gxTv_SdtSDT_Tile_Tileaction = null;
		protected bool gxTv_SdtSDT_Tile_Tileaction_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Tile", Namespace="Comforta_version2")]
	public class SdtSDT_Tile_RESTInterface : GxGenericCollectionItem<SdtSDT_Tile>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Tile_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Tile_RESTInterface( SdtSDT_Tile psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TileId", Order=0)]
		public Guid gxTpr_Tileid
		{
			get { 
				return sdt.gxTpr_Tileid;

			}
			set { 
				sdt.gxTpr_Tileid = value;
			}
		}

		[DataMember(Name="TileName", Order=1)]
		public  string gxTpr_Tilename
		{
			get { 
				return sdt.gxTpr_Tilename;

			}
			set { 
				 sdt.gxTpr_Tilename = value;
			}
		}

		[DataMember(Name="TileText", Order=2)]
		public  string gxTpr_Tiletext
		{
			get { 
				return sdt.gxTpr_Tiletext;

			}
			set { 
				 sdt.gxTpr_Tiletext = value;
			}
		}

		[DataMember(Name="TileTextColor", Order=3)]
		public  string gxTpr_Tiletextcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tiletextcolor);

			}
			set { 
				 sdt.gxTpr_Tiletextcolor = value;
			}
		}

		[DataMember(Name="TileTextAlignment", Order=4)]
		public  string gxTpr_Tiletextalignment
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tiletextalignment);

			}
			set { 
				 sdt.gxTpr_Tiletextalignment = value;
			}
		}

		[DataMember(Name="TileIcon", Order=5)]
		public  string gxTpr_Tileicon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileicon);

			}
			set { 
				 sdt.gxTpr_Tileicon = value;
			}
		}

		[DataMember(Name="TileIconColor", Order=6)]
		public  string gxTpr_Tileiconcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileiconcolor);

			}
			set { 
				 sdt.gxTpr_Tileiconcolor = value;
			}
		}

		[DataMember(Name="TileIconAlignment", Order=7)]
		public  string gxTpr_Tileiconalignment
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileiconalignment);

			}
			set { 
				 sdt.gxTpr_Tileiconalignment = value;
			}
		}

		[DataMember(Name="TileBGColor", Order=8)]
		public  string gxTpr_Tilebgcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tilebgcolor);

			}
			set { 
				 sdt.gxTpr_Tilebgcolor = value;
			}
		}

		[DataMember(Name="TileBGImageUrl", Order=9)]
		public  string gxTpr_Tilebgimageurl
		{
			get { 
				return sdt.gxTpr_Tilebgimageurl;

			}
			set { 
				 sdt.gxTpr_Tilebgimageurl = value;
			}
		}

		[DataMember(Name="TileBGImageOpacity", Order=10)]
		public short gxTpr_Tilebgimageopacity
		{
			get { 
				return sdt.gxTpr_Tilebgimageopacity;

			}
			set { 
				sdt.gxTpr_Tilebgimageopacity = value;
			}
		}

		[DataMember(Name="TileAction", Order=11, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_TileAction_RESTInterface gxTpr_Tileaction
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tileaction_Json())
					return new GeneXus.Programs.SdtSDT_TileAction_RESTInterface(sdt.gxTpr_Tileaction);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Tileaction = value.sdt;
			}
		}


		#endregion

		public SdtSDT_Tile sdt
		{
			get { 
				return (SdtSDT_Tile)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_Tile() ;
			}
		}
	}
	#endregion
}