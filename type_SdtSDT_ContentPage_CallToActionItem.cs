/*
				   File: type_SdtSDT_ContentPage_CallToActionItem
			Description: CallToAction
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
	[XmlRoot(ElementName="SDT_ContentPage.CallToActionItem")]
	[XmlType(TypeName="SDT_ContentPage.CallToActionItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage_CallToActionItem : GxUserType
	{
		public SdtSDT_ContentPage_CallToActionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionname = "";

			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionphone = "";

			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionurl = "";

			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionemail = "";

		}

		public SdtSDT_ContentPage_CallToActionItem(IGxContext context)
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
			AddObjectProperty("CallToActionId", gxTpr_Calltoactionid, false);


			AddObjectProperty("CallToActionName", gxTpr_Calltoactionname, false);


			AddObjectProperty("CallToActionPhone", gxTpr_Calltoactionphone, false);


			AddObjectProperty("CallToActionUrl", gxTpr_Calltoactionurl, false);


			AddObjectProperty("CallToActionEmail", gxTpr_Calltoactionemail, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CallToActionId")]
		[XmlElement(ElementName="CallToActionId")]
		public Guid gxTpr_Calltoactionid
		{
			get {
				return gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionid; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionid = value;
				SetDirty("Calltoactionid");
			}
		}




		[SoapElement(ElementName="CallToActionName")]
		[XmlElement(ElementName="CallToActionName")]
		public string gxTpr_Calltoactionname
		{
			get {
				return gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionname; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionname = value;
				SetDirty("Calltoactionname");
			}
		}




		[SoapElement(ElementName="CallToActionPhone")]
		[XmlElement(ElementName="CallToActionPhone")]
		public string gxTpr_Calltoactionphone
		{
			get {
				return gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionphone; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionphone = value;
				SetDirty("Calltoactionphone");
			}
		}




		[SoapElement(ElementName="CallToActionUrl")]
		[XmlElement(ElementName="CallToActionUrl")]
		public string gxTpr_Calltoactionurl
		{
			get {
				return gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionurl; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionurl = value;
				SetDirty("Calltoactionurl");
			}
		}




		[SoapElement(ElementName="CallToActionEmail")]
		[XmlElement(ElementName="CallToActionEmail")]
		public string gxTpr_Calltoactionemail
		{
			get {
				return gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionemail; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionemail = value;
				SetDirty("Calltoactionemail");
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
			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionname = "";
			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionphone = "";
			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionurl = "";
			gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionemail = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionid;
		 

		protected string gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionname;
		 

		protected string gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionphone;
		 

		protected string gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionurl;
		 

		protected string gxTv_SdtSDT_ContentPage_CallToActionItem_Calltoactionemail;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ContentPage.CallToActionItem", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage_CallToActionItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage_CallToActionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage_CallToActionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage_CallToActionItem_RESTInterface( SdtSDT_ContentPage_CallToActionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CallToActionId", Order=0)]
		public Guid gxTpr_Calltoactionid
		{
			get { 
				return sdt.gxTpr_Calltoactionid;

			}
			set { 
				sdt.gxTpr_Calltoactionid = value;
			}
		}

		[DataMember(Name="CallToActionName", Order=1)]
		public  string gxTpr_Calltoactionname
		{
			get { 
				return sdt.gxTpr_Calltoactionname;

			}
			set { 
				 sdt.gxTpr_Calltoactionname = value;
			}
		}

		[DataMember(Name="CallToActionPhone", Order=2)]
		public  string gxTpr_Calltoactionphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calltoactionphone);

			}
			set { 
				 sdt.gxTpr_Calltoactionphone = value;
			}
		}

		[DataMember(Name="CallToActionUrl", Order=3)]
		public  string gxTpr_Calltoactionurl
		{
			get { 
				return sdt.gxTpr_Calltoactionurl;

			}
			set { 
				 sdt.gxTpr_Calltoactionurl = value;
			}
		}

		[DataMember(Name="CallToActionEmail", Order=4)]
		public  string gxTpr_Calltoactionemail
		{
			get { 
				return sdt.gxTpr_Calltoactionemail;

			}
			set { 
				 sdt.gxTpr_Calltoactionemail = value;
			}
		}


		#endregion

		public SdtSDT_ContentPage_CallToActionItem sdt
		{
			get { 
				return (SdtSDT_ContentPage_CallToActionItem)Sdt;
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
				sdt = new SdtSDT_ContentPage_CallToActionItem() ;
			}
		}
	}
	#endregion
}