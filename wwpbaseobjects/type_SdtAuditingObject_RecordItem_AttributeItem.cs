/*
				   File: type_SdtAuditingObject_RecordItem_AttributeItem
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="AuditingObject.RecordItem.AttributeItem")]
	[XmlType(TypeName="AuditingObject.RecordItem.AttributeItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtAuditingObject_RecordItem_AttributeItem : GxUserType
	{
		public SdtAuditingObject_RecordItem_AttributeItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Name = "";

			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Oldvalue = "";

			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Newvalue = "";

			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Description = "";

		}

		public SdtAuditingObject_RecordItem_AttributeItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("IsPartOfKey", gxTpr_Ispartofkey, false);


			AddObjectProperty("IsDescriptionAttribute", gxTpr_Isdescriptionattribute, false);


			AddObjectProperty("OldValue", gxTpr_Oldvalue, false);


			AddObjectProperty("NewValue", gxTpr_Newvalue, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Name; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="IsPartOfKey")]
		[XmlElement(ElementName="IsPartOfKey")]
		public bool gxTpr_Ispartofkey
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Ispartofkey; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Ispartofkey = value;
				SetDirty("Ispartofkey");
			}
		}




		[SoapElement(ElementName="IsDescriptionAttribute")]
		[XmlElement(ElementName="IsDescriptionAttribute")]
		public bool gxTpr_Isdescriptionattribute
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Isdescriptionattribute; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Isdescriptionattribute = value;
				SetDirty("Isdescriptionattribute");
			}
		}




		[SoapElement(ElementName="OldValue")]
		[XmlElement(ElementName="OldValue")]
		public string gxTpr_Oldvalue
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Oldvalue; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Oldvalue = value;
				SetDirty("Oldvalue");
			}
		}




		[SoapElement(ElementName="NewValue")]
		[XmlElement(ElementName="NewValue")]
		public string gxTpr_Newvalue
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Newvalue; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Newvalue = value;
				SetDirty("Newvalue");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtAuditingObject_RecordItem_AttributeItem_Description; 
			}
			set {
				gxTv_SdtAuditingObject_RecordItem_AttributeItem_Description = value;
				SetDirty("Description");
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
			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Name = "";


			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Oldvalue = "";
			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Newvalue = "";
			gxTv_SdtAuditingObject_RecordItem_AttributeItem_Description = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtAuditingObject_RecordItem_AttributeItem_Name;
		 

		protected bool gxTv_SdtAuditingObject_RecordItem_AttributeItem_Ispartofkey;
		 

		protected bool gxTv_SdtAuditingObject_RecordItem_AttributeItem_Isdescriptionattribute;
		 

		protected string gxTv_SdtAuditingObject_RecordItem_AttributeItem_Oldvalue;
		 

		protected string gxTv_SdtAuditingObject_RecordItem_AttributeItem_Newvalue;
		 

		protected string gxTv_SdtAuditingObject_RecordItem_AttributeItem_Description;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"AuditingObject.RecordItem.AttributeItem", Namespace="Comforta_version2")]
	public class SdtAuditingObject_RecordItem_AttributeItem_RESTInterface : GxGenericCollectionItem<SdtAuditingObject_RecordItem_AttributeItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAuditingObject_RecordItem_AttributeItem_RESTInterface( ) : base()
		{	
		}

		public SdtAuditingObject_RecordItem_AttributeItem_RESTInterface( SdtAuditingObject_RecordItem_AttributeItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="IsPartOfKey", Order=1)]
		public bool gxTpr_Ispartofkey
		{
			get { 
				return sdt.gxTpr_Ispartofkey;

			}
			set { 
				sdt.gxTpr_Ispartofkey = value;
			}
		}

		[DataMember(Name="IsDescriptionAttribute", Order=2)]
		public bool gxTpr_Isdescriptionattribute
		{
			get { 
				return sdt.gxTpr_Isdescriptionattribute;

			}
			set { 
				sdt.gxTpr_Isdescriptionattribute = value;
			}
		}

		[DataMember(Name="OldValue", Order=3)]
		public  string gxTpr_Oldvalue
		{
			get { 
				return sdt.gxTpr_Oldvalue;

			}
			set { 
				 sdt.gxTpr_Oldvalue = value;
			}
		}

		[DataMember(Name="NewValue", Order=4)]
		public  string gxTpr_Newvalue
		{
			get { 
				return sdt.gxTpr_Newvalue;

			}
			set { 
				 sdt.gxTpr_Newvalue = value;
			}
		}

		[DataMember(Name="Description", Order=5)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtAuditingObject_RecordItem_AttributeItem sdt
		{
			get { 
				return (SdtAuditingObject_RecordItem_AttributeItem)Sdt;
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
				sdt = new SdtAuditingObject_RecordItem_AttributeItem() ;
			}
		}
	}
	#endregion
}