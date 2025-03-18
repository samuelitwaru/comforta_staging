/*
				   File: type_SdtSDT_DebugResults_UrlListItem
			Description: UrlList
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
	[XmlRoot(ElementName="SDT_DebugResults.UrlListItem")]
	[XmlType(TypeName="SDT_DebugResults.UrlListItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_DebugResults_UrlListItem : GxUserType
	{
		public SdtSDT_DebugResults_UrlListItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DebugResults_UrlListItem_Url = "";

			gxTv_SdtSDT_DebugResults_UrlListItem_Statuscode = "";

			gxTv_SdtSDT_DebugResults_UrlListItem_Statusmessage = "";

		}

		public SdtSDT_DebugResults_UrlListItem(IGxContext context)
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
			AddObjectProperty("Url", gxTpr_Url, false);


			AddObjectProperty("StatusCode", gxTpr_Statuscode, false);


			AddObjectProperty("StatusMessage", gxTpr_Statusmessage, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Url")]
		[XmlElement(ElementName="Url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtSDT_DebugResults_UrlListItem_Url; 
			}
			set {
				gxTv_SdtSDT_DebugResults_UrlListItem_Url = value;
				SetDirty("Url");
			}
		}




		[SoapElement(ElementName="StatusCode")]
		[XmlElement(ElementName="StatusCode")]
		public string gxTpr_Statuscode
		{
			get {
				return gxTv_SdtSDT_DebugResults_UrlListItem_Statuscode; 
			}
			set {
				gxTv_SdtSDT_DebugResults_UrlListItem_Statuscode = value;
				SetDirty("Statuscode");
			}
		}




		[SoapElement(ElementName="StatusMessage")]
		[XmlElement(ElementName="StatusMessage")]
		public string gxTpr_Statusmessage
		{
			get {
				return gxTv_SdtSDT_DebugResults_UrlListItem_Statusmessage; 
			}
			set {
				gxTv_SdtSDT_DebugResults_UrlListItem_Statusmessage = value;
				SetDirty("Statusmessage");
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
			gxTv_SdtSDT_DebugResults_UrlListItem_Url = "";
			gxTv_SdtSDT_DebugResults_UrlListItem_Statuscode = "";
			gxTv_SdtSDT_DebugResults_UrlListItem_Statusmessage = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_DebugResults_UrlListItem_Url;
		 

		protected string gxTv_SdtSDT_DebugResults_UrlListItem_Statuscode;
		 

		protected string gxTv_SdtSDT_DebugResults_UrlListItem_Statusmessage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_DebugResults.UrlListItem", Namespace="Comforta_version2")]
	public class SdtSDT_DebugResults_UrlListItem_RESTInterface : GxGenericCollectionItem<SdtSDT_DebugResults_UrlListItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DebugResults_UrlListItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DebugResults_UrlListItem_RESTInterface( SdtSDT_DebugResults_UrlListItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Url", Order=0)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}

		[DataMember(Name="StatusCode", Order=1)]
		public  string gxTpr_Statuscode
		{
			get { 
				return sdt.gxTpr_Statuscode;

			}
			set { 
				 sdt.gxTpr_Statuscode = value;
			}
		}

		[DataMember(Name="StatusMessage", Order=2)]
		public  string gxTpr_Statusmessage
		{
			get { 
				return sdt.gxTpr_Statusmessage;

			}
			set { 
				 sdt.gxTpr_Statusmessage = value;
			}
		}


		#endregion

		public SdtSDT_DebugResults_UrlListItem sdt
		{
			get { 
				return (SdtSDT_DebugResults_UrlListItem)Sdt;
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
				sdt = new SdtSDT_DebugResults_UrlListItem() ;
			}
		}
	}
	#endregion
}