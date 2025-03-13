/*
				   File: type_SdtSDT_PageV2
			Description: SDT_PageV2
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
	[XmlRoot(ElementName="SDT_PageV2")]
	[XmlType(TypeName="SDT_PageV2" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_PageV2 : GxUserType
	{
		public SdtSDT_PageV2( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageV2_Pagename = "";

			gxTv_SdtSDT_PageV2_Pagetype = "";

			gxTv_SdtSDT_PageV2_Pagestructure = "";

		}

		public SdtSDT_PageV2(IGxContext context)
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
			AddObjectProperty("PageId", gxTpr_Pageid, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);


			AddObjectProperty("PageType", gxTpr_Pagetype, false);


			AddObjectProperty("PageStructure", gxTpr_Pagestructure, false);

			if (gxTv_SdtSDT_PageV2_Pagecontentstructure != null)
			{
				AddObjectProperty("PageContentStructure", gxTv_SdtSDT_PageV2_Pagecontentstructure, false);
			}
			if (gxTv_SdtSDT_PageV2_Pagemenustructure != null)
			{
				AddObjectProperty("PageMenuStructure", gxTv_SdtSDT_PageV2_Pagemenustructure, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_PageV2_Pageid; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_PageV2_Pagename; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="PageType")]
		[XmlElement(ElementName="PageType")]
		public string gxTpr_Pagetype
		{
			get {
				return gxTv_SdtSDT_PageV2_Pagetype; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pagetype = value;
				SetDirty("Pagetype");
			}
		}




		[SoapElement(ElementName="PageStructure")]
		[XmlElement(ElementName="PageStructure")]
		public string gxTpr_Pagestructure
		{
			get {
				return gxTv_SdtSDT_PageV2_Pagestructure; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pagestructure = value;
				SetDirty("Pagestructure");
			}
		}



		[SoapElement(ElementName="PageContentStructure")]
		[XmlElement(ElementName="PageContentStructure")]
		public GeneXus.Programs.SdtSDT_ContentPage gxTpr_Pagecontentstructure
		{
			get {
				if ( gxTv_SdtSDT_PageV2_Pagecontentstructure == null )
				{
					gxTv_SdtSDT_PageV2_Pagecontentstructure = new GeneXus.Programs.SdtSDT_ContentPage(context);
				}
				return gxTv_SdtSDT_PageV2_Pagecontentstructure; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pagecontentstructure = value;
				SetDirty("Pagecontentstructure");
			}
		}
		public void gxTv_SdtSDT_PageV2_Pagecontentstructure_SetNull()
		{
			gxTv_SdtSDT_PageV2_Pagecontentstructure_N = true;
			gxTv_SdtSDT_PageV2_Pagecontentstructure = null;
		}

		public bool gxTv_SdtSDT_PageV2_Pagecontentstructure_IsNull()
		{
			return gxTv_SdtSDT_PageV2_Pagecontentstructure == null;
		}
		public bool ShouldSerializegxTpr_Pagecontentstructure_Json()
		{
			return gxTv_SdtSDT_PageV2_Pagecontentstructure != null;

		}

		[SoapElement(ElementName="PageMenuStructure")]
		[XmlElement(ElementName="PageMenuStructure")]
		public GeneXus.Programs.SdtSDT_MenuPage gxTpr_Pagemenustructure
		{
			get {
				if ( gxTv_SdtSDT_PageV2_Pagemenustructure == null )
				{
					gxTv_SdtSDT_PageV2_Pagemenustructure = new GeneXus.Programs.SdtSDT_MenuPage(context);
				}
				return gxTv_SdtSDT_PageV2_Pagemenustructure; 
			}
			set {
				gxTv_SdtSDT_PageV2_Pagemenustructure = value;
				SetDirty("Pagemenustructure");
			}
		}
		public void gxTv_SdtSDT_PageV2_Pagemenustructure_SetNull()
		{
			gxTv_SdtSDT_PageV2_Pagemenustructure_N = true;
			gxTv_SdtSDT_PageV2_Pagemenustructure = null;
		}

		public bool gxTv_SdtSDT_PageV2_Pagemenustructure_IsNull()
		{
			return gxTv_SdtSDT_PageV2_Pagemenustructure == null;
		}
		public bool ShouldSerializegxTpr_Pagemenustructure_Json()
		{
			return gxTv_SdtSDT_PageV2_Pagemenustructure != null;

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
			gxTv_SdtSDT_PageV2_Pagename = "";
			gxTv_SdtSDT_PageV2_Pagetype = "";
			gxTv_SdtSDT_PageV2_Pagestructure = "";

			gxTv_SdtSDT_PageV2_Pagecontentstructure_N = true;


			gxTv_SdtSDT_PageV2_Pagemenustructure_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_PageV2_Pageid;
		 

		protected string gxTv_SdtSDT_PageV2_Pagename;
		 

		protected string gxTv_SdtSDT_PageV2_Pagetype;
		 

		protected string gxTv_SdtSDT_PageV2_Pagestructure;
		 

		protected GeneXus.Programs.SdtSDT_ContentPage gxTv_SdtSDT_PageV2_Pagecontentstructure = null;
		protected bool gxTv_SdtSDT_PageV2_Pagecontentstructure_N;
		 

		protected GeneXus.Programs.SdtSDT_MenuPage gxTv_SdtSDT_PageV2_Pagemenustructure = null;
		protected bool gxTv_SdtSDT_PageV2_Pagemenustructure_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PageV2", Namespace="Comforta_version2")]
	public class SdtSDT_PageV2_RESTInterface : GxGenericCollectionItem<SdtSDT_PageV2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageV2_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageV2_RESTInterface( SdtSDT_PageV2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageId", Order=0)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="PageName", Order=1)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="PageType", Order=2)]
		public  string gxTpr_Pagetype
		{
			get { 
				return sdt.gxTpr_Pagetype;

			}
			set { 
				 sdt.gxTpr_Pagetype = value;
			}
		}

		[DataMember(Name="PageStructure", Order=3)]
		public  string gxTpr_Pagestructure
		{
			get { 
				return sdt.gxTpr_Pagestructure;

			}
			set { 
				 sdt.gxTpr_Pagestructure = value;
			}
		}

		[DataMember(Name="PageContentStructure", Order=4, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_ContentPage_RESTInterface gxTpr_Pagecontentstructure
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Pagecontentstructure_Json())
					return new GeneXus.Programs.SdtSDT_ContentPage_RESTInterface(sdt.gxTpr_Pagecontentstructure);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Pagecontentstructure = value.sdt;
			}
		}

		[DataMember(Name="PageMenuStructure", Order=5, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_MenuPage_RESTInterface gxTpr_Pagemenustructure
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Pagemenustructure_Json())
					return new GeneXus.Programs.SdtSDT_MenuPage_RESTInterface(sdt.gxTpr_Pagemenustructure);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Pagemenustructure = value.sdt;
			}
		}


		#endregion

		public SdtSDT_PageV2 sdt
		{
			get { 
				return (SdtSDT_PageV2)Sdt;
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
				sdt = new SdtSDT_PageV2() ;
			}
		}
	}
	#endregion
}