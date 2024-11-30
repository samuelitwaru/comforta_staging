/*
				   File: type_SdtAuditingObject
			Description: AuditingObject
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
	[XmlRoot(ElementName="AuditingObject")]
	[XmlType(TypeName="AuditingObject" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtAuditingObject : GxUserType
	{
		public SdtAuditingObject( )
		{
			/* Constructor for serialization */
			gxTv_SdtAuditingObject_Mode = "";

		}

		public SdtAuditingObject(IGxContext context)
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
			AddObjectProperty("Mode", gxTpr_Mode, false);

			if (gxTv_SdtAuditingObject_Record != null)
			{
				AddObjectProperty("Record", gxTv_SdtAuditingObject_Record, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Mode")]
		[XmlElement(ElementName="Mode")]
		public string gxTpr_Mode
		{
			get {
				return gxTv_SdtAuditingObject_Mode; 
			}
			set {
				gxTv_SdtAuditingObject_Mode = value;
				SetDirty("Mode");
			}
		}




		[SoapElement(ElementName="Record" )]
		[XmlArray(ElementName="Record"  )]
		[XmlArrayItemAttribute(ElementName="RecordItem" , IsNullable=false )]
		public GXBaseCollection<SdtAuditingObject_RecordItem> gxTpr_Record
		{
			get {
				if ( gxTv_SdtAuditingObject_Record == null )
				{
					gxTv_SdtAuditingObject_Record = new GXBaseCollection<SdtAuditingObject_RecordItem>( context, "AuditingObject.RecordItem", "");
				}
				return gxTv_SdtAuditingObject_Record;
			}
			set {
				gxTv_SdtAuditingObject_Record_N = false;
				gxTv_SdtAuditingObject_Record = value;
				SetDirty("Record");
			}
		}

		public void gxTv_SdtAuditingObject_Record_SetNull()
		{
			gxTv_SdtAuditingObject_Record_N = true;
			gxTv_SdtAuditingObject_Record = null;
		}

		public bool gxTv_SdtAuditingObject_Record_IsNull()
		{
			return gxTv_SdtAuditingObject_Record == null;
		}
		public bool ShouldSerializegxTpr_Record_GxSimpleCollection_Json()
		{
			return gxTv_SdtAuditingObject_Record != null && gxTv_SdtAuditingObject_Record.Count > 0;

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
			gxTv_SdtAuditingObject_Mode = "";

			gxTv_SdtAuditingObject_Record_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtAuditingObject_Mode;
		 
		protected bool gxTv_SdtAuditingObject_Record_N;
		protected GXBaseCollection<SdtAuditingObject_RecordItem> gxTv_SdtAuditingObject_Record = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"AuditingObject", Namespace="Comforta_version2")]
	public class SdtAuditingObject_RESTInterface : GxGenericCollectionItem<SdtAuditingObject>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAuditingObject_RESTInterface( ) : base()
		{	
		}

		public SdtAuditingObject_RESTInterface( SdtAuditingObject psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Mode", Order=0)]
		public  string gxTpr_Mode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mode);

			}
			set { 
				 sdt.gxTpr_Mode = value;
			}
		}

		[DataMember(Name="Record", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtAuditingObject_RecordItem_RESTInterface> gxTpr_Record
		{
			get {
				if (sdt.ShouldSerializegxTpr_Record_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtAuditingObject_RecordItem_RESTInterface>(sdt.gxTpr_Record);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Record);
			}
		}


		#endregion

		public SdtAuditingObject sdt
		{
			get { 
				return (SdtAuditingObject)Sdt;
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
				sdt = new SdtAuditingObject() ;
			}
		}
	}
	#endregion
}