/*
				   File: type_SdtSDT_Tile_AttributeItem
			Description: Attribute
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
	[XmlRoot(ElementName="SDT_Tile.AttributeItem")]
	[XmlType(TypeName="SDT_Tile.AttributeItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Tile_AttributeItem : GxUserType
	{
		public SdtSDT_Tile_AttributeItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Tile_AttributeItem_Attributename = "";

			gxTv_SdtSDT_Tile_AttributeItem_Attrbutevalue = "";

		}

		public SdtSDT_Tile_AttributeItem(IGxContext context)
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
			AddObjectProperty("AttributeId", gxTpr_Attributeid, false);


			AddObjectProperty("AttributeName", gxTpr_Attributename, false);


			AddObjectProperty("AttrbuteValue", gxTpr_Attrbutevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeId")]
		[XmlElement(ElementName="AttributeId")]
		public Guid gxTpr_Attributeid
		{
			get {
				return gxTv_SdtSDT_Tile_AttributeItem_Attributeid; 
			}
			set {
				gxTv_SdtSDT_Tile_AttributeItem_Attributeid = value;
				SetDirty("Attributeid");
			}
		}




		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtSDT_Tile_AttributeItem_Attributename; 
			}
			set {
				gxTv_SdtSDT_Tile_AttributeItem_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="AttrbuteValue")]
		[XmlElement(ElementName="AttrbuteValue")]
		public string gxTpr_Attrbutevalue
		{
			get {
				return gxTv_SdtSDT_Tile_AttributeItem_Attrbutevalue; 
			}
			set {
				gxTv_SdtSDT_Tile_AttributeItem_Attrbutevalue = value;
				SetDirty("Attrbutevalue");
			}
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
			gxTv_SdtSDT_Tile_AttributeItem_Attributename = "";
			gxTv_SdtSDT_Tile_AttributeItem_Attrbutevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Tile_AttributeItem_Attributeid;
		 

		protected string gxTv_SdtSDT_Tile_AttributeItem_Attributename;
		 

		protected string gxTv_SdtSDT_Tile_AttributeItem_Attrbutevalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_Tile.AttributeItem", Namespace="Comforta_version2")]
	public class SdtSDT_Tile_AttributeItem_RESTInterface : GxGenericCollectionItem<SdtSDT_Tile_AttributeItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Tile_AttributeItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Tile_AttributeItem_RESTInterface( SdtSDT_Tile_AttributeItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AttributeId", Order=0)]
		public Guid gxTpr_Attributeid
		{
			get { 
				return sdt.gxTpr_Attributeid;

			}
			set { 
				sdt.gxTpr_Attributeid = value;
			}
		}

		[DataMember(Name="AttributeName", Order=1)]
		public  string gxTpr_Attributename
		{
			get { 
				return sdt.gxTpr_Attributename;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="AttrbuteValue", Order=2)]
		public  string gxTpr_Attrbutevalue
		{
			get { 
				return sdt.gxTpr_Attrbutevalue;

			}
			set { 
				 sdt.gxTpr_Attrbutevalue = value;
			}
		}


		#endregion

		public SdtSDT_Tile_AttributeItem sdt
		{
			get { 
				return (SdtSDT_Tile_AttributeItem)Sdt;
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
				sdt = new SdtSDT_Tile_AttributeItem() ;
			}
		}
	}
	#endregion
}