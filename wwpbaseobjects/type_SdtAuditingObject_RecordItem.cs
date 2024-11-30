/*
				   File: type_SdtAuditingObject_RecordItem
			Description: Record
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="AuditingObject.RecordItem")]
	[XmlType(TypeName="AuditingObject.RecordItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtAuditingObject_RecordItem : GxUserType
	{
		public SdtAuditingObject_RecordItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtAuditingObject_RecordItem_Tablename = "";

			gxTv_SdtAuditingObject_RecordItem_Mode = "";

		}

		public SdtAuditingObject_RecordItem(IGxContext context)
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
			AddObjectProperty("TableName", gxTpr_Tablename, false);


			AddObjectProperty("Mode", gxTpr_Mode, false);

			if (gxTv_SdtAuditingObject_RecordItem_Attribute != null)
			{
				AddObjectProperty("Attribute", gxTv_SdtAuditingObject_RecordItem_Attribute, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TableName")]
		[XmlElement(ElementName="TableName")]
		public string gxTpr_Tablename
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_Tablename; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_Tablename = value;
				SetDirty("Tablename");
			}
		}




		[SoapElement(ElementName="Mode")]
		[XmlElement(ElementName="Mode")]
		public string gxTpr_Mode
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_Mode; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_Mode = value;
				SetDirty("Mode");
			}
		}




		[SoapElement(ElementName="Attribute" )]
		[XmlArray(ElementName="Attribute"  )]
		[XmlArrayItemAttribute(ElementName="AttributeItem" , IsNullable=false )]
		public GXBaseCollection<SdtAuditingObject_RecordItem_AttributeItem> gxTpr_Attribute
		{
			get {
				if ( gxTv_SdtAuditingObject_RecordItem_Attribute == null )
				{
					gxTv_SdtAuditingObject_RecordItem_Attribute = new GXBaseCollection<SdtAuditingObject_RecordItem_AttributeItem>( context, "AuditingObject.RecordItem.AttributeItem", "");
				}
				return gxTv_SdtAuditingObject_RecordItem_Attribute;
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_Attribute_N = false;
				gxTv_SdtAuditingObject_RecordItem_Attribute = value;
				SetDirty("Attribute");
			}
		}

		public void gxTv_SdtAuditingObject_RecordItem_Attribute_SetNull()
		{
			gxTv_SdtAuditingObject_RecordItem_Attribute_N = true;
			gxTv_SdtAuditingObject_RecordItem_Attribute = null;
		}

		public bool gxTv_SdtAuditingObject_RecordItem_Attribute_IsNull()
		{
			return gxTv_SdtAuditingObject_RecordItem_Attribute == null;
		}
		public bool ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json()
		{
			return gxTv_SdtAuditingObject_RecordItem_Attribute != null && gxTv_SdtAuditingObject_RecordItem_Attribute.Count > 0;

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
			gxTv_SdtAuditingObject_RecordItem_Tablename = "";
			gxTv_SdtAuditingObject_RecordItem_Mode = "";

			gxTv_SdtAuditingObject_RecordItem_Attribute_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtAuditingObject_RecordItem_Tablename;
		 

		protected string gxTv_SdtAuditingObject_RecordItem_Mode;
		 
		protected bool gxTv_SdtAuditingObject_RecordItem_Attribute_N;
		protected GXBaseCollection<SdtAuditingObject_RecordItem_AttributeItem> gxTv_SdtAuditingObject_RecordItem_Attribute = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"AuditingObject.RecordItem", Namespace="Comforta_version2")]
	public class SdtAuditingObject_RecordItem_RESTInterface : GxGenericCollectionItem<SdtAuditingObject_RecordItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAuditingObject_RecordItem_RESTInterface( ) : base()
		{	
		}

		public SdtAuditingObject_RecordItem_RESTInterface( SdtAuditingObject_RecordItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TableName", Order=0)]
		public  string gxTpr_Tablename
		{
			get { 
				return sdt.gxTpr_Tablename;

			}
			set { 
				 sdt.gxTpr_Tablename = value;
			}
		}

		[DataMember(Name="Mode", Order=1)]
		public  string gxTpr_Mode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mode);

			}
			set { 
				 sdt.gxTpr_Mode = value;
			}
		}

		[DataMember(Name="Attribute", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtAuditingObject_RecordItem_AttributeItem_RESTInterface> gxTpr_Attribute
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtAuditingObject_RecordItem_AttributeItem_RESTInterface>(sdt.gxTpr_Attribute);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attribute);
			}
		}


		#endregion

		public SdtAuditingObject_RecordItem sdt
		{
			get { 
				return (SdtAuditingObject_RecordItem)Sdt;
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
				sdt = new SdtAuditingObject_RecordItem() ;
			}
		}
	}
	#endregion
}