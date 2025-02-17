/*
				   File: type_SdtSDT_DynamicForms
			Description: SDT_DynamicForms
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
	[XmlRoot(ElementName="SDT_DynamicForms")]
	[XmlType(TypeName="SDT_DynamicForms" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_DynamicForms : GxUserType
	{
		public SdtSDT_DynamicForms( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DynamicForms_Referencename = "";

			gxTv_SdtSDT_DynamicForms_Formurl = "";

		}

		public SdtSDT_DynamicForms(IGxContext context)
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
			AddObjectProperty("FormId", gxTpr_Formid, false);


			AddObjectProperty("ReferenceName", gxTpr_Referencename, false);


			AddObjectProperty("FormUrl", gxTpr_Formurl, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FormId")]
		[XmlElement(ElementName="FormId")]
		public Guid gxTpr_Formid
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Formid; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Formid = value;
				SetDirty("Formid");
			}
		}




		[SoapElement(ElementName="ReferenceName")]
		[XmlElement(ElementName="ReferenceName")]
		public string gxTpr_Referencename
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Referencename; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Referencename = value;
				SetDirty("Referencename");
			}
		}




		[SoapElement(ElementName="FormUrl")]
		[XmlElement(ElementName="FormUrl")]
		public string gxTpr_Formurl
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Formurl; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Formurl = value;
				SetDirty("Formurl");
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
			gxTv_SdtSDT_DynamicForms_Referencename = "";
			gxTv_SdtSDT_DynamicForms_Formurl = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_DynamicForms_Formid;
		 

		protected string gxTv_SdtSDT_DynamicForms_Referencename;
		 

		protected string gxTv_SdtSDT_DynamicForms_Formurl;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DynamicForms", Namespace="Comforta_version2")]
	public class SdtSDT_DynamicForms_RESTInterface : GxGenericCollectionItem<SdtSDT_DynamicForms>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DynamicForms_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DynamicForms_RESTInterface( SdtSDT_DynamicForms psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FormId", Order=0)]
		public Guid gxTpr_Formid
		{
			get { 
				return sdt.gxTpr_Formid;

			}
			set { 
				sdt.gxTpr_Formid = value;
			}
		}

		[DataMember(Name="ReferenceName", Order=1)]
		public  string gxTpr_Referencename
		{
			get { 
				return sdt.gxTpr_Referencename;

			}
			set { 
				 sdt.gxTpr_Referencename = value;
			}
		}

		[DataMember(Name="FormUrl", Order=2)]
		public  string gxTpr_Formurl
		{
			get { 
				return sdt.gxTpr_Formurl;

			}
			set { 
				 sdt.gxTpr_Formurl = value;
			}
		}


		#endregion

		public SdtSDT_DynamicForms sdt
		{
			get { 
				return (SdtSDT_DynamicForms)Sdt;
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
				sdt = new SdtSDT_DynamicForms() ;
			}
		}
	}
	#endregion
}