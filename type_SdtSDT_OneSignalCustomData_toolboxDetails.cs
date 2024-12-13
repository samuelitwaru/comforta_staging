/*
				   File: type_SdtSDT_OneSignalCustomData_toolboxDetails
			Description: toolboxDetails
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData.toolboxDetails")]
	[XmlType(TypeName="SDT_OneSignalCustomData.toolboxDetails" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData_toolboxDetails : GxUserType
	{
		public SdtSDT_OneSignalCustomData_toolboxDetails( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pagename = "";

		}

		public SdtSDT_OneSignalCustomData_toolboxDetails(IGxContext context)
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
			AddObjectProperty("pageName", gxTpr_Pagename, false);


			AddObjectProperty("pageId", gxTpr_Pageid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="pageName")]
		[XmlElement(ElementName="pageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pagename; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="pageId")]
		[XmlElement(ElementName="pageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pageid; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pageid = value;
				SetDirty("Pageid");
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
			gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pagename = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pagename;
		 

		protected Guid gxTv_SdtSDT_OneSignalCustomData_toolboxDetails_Pageid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData.toolboxDetails", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomData_toolboxDetails_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData_toolboxDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_toolboxDetails_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_toolboxDetails_RESTInterface( SdtSDT_OneSignalCustomData_toolboxDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="pageName", Order=0)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="pageId", Order=1)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomData_toolboxDetails sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData_toolboxDetails)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData_toolboxDetails() ;
			}
		}
	}
	#endregion
}