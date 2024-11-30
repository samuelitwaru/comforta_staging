/*
				   File: type_SdtSDT_ContentPage_CtaItem
			Description: Cta
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
	[XmlRoot(ElementName="SDT_ContentPage.CtaItem")]
	[XmlType(TypeName="SDT_ContentPage.CtaItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage_CtaItem : GxUserType
	{
		public SdtSDT_ContentPage_CtaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = "";

		}

		public SdtSDT_ContentPage_CtaItem(IGxContext context)
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
			AddObjectProperty("CtaType", gxTpr_Ctatype, false);


			AddObjectProperty("CtaLabel", gxTpr_Ctalabel, false);


			AddObjectProperty("CtaAction", gxTpr_Ctaaction, false);


			AddObjectProperty("CtaBGColor", gxTpr_Ctabgcolor, false);


			AddObjectProperty("IsFullWidth", gxTpr_Isfullwidth, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CtaType")]
		[XmlElement(ElementName="CtaType")]
		public string gxTpr_Ctatype
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctatype; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = value;
				SetDirty("Ctatype");
			}
		}




		[SoapElement(ElementName="CtaLabel")]
		[XmlElement(ElementName="CtaLabel")]
		public string gxTpr_Ctalabel
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = value;
				SetDirty("Ctalabel");
			}
		}




		[SoapElement(ElementName="CtaAction")]
		[XmlElement(ElementName="CtaAction")]
		public string gxTpr_Ctaaction
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = value;
				SetDirty("Ctaaction");
			}
		}




		[SoapElement(ElementName="CtaBGColor")]
		[XmlElement(ElementName="CtaBGColor")]
		public string gxTpr_Ctabgcolor
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = value;
				SetDirty("Ctabgcolor");
			}
		}




		[SoapElement(ElementName="IsFullWidth")]
		[XmlElement(ElementName="IsFullWidth")]
		public bool gxTpr_Isfullwidth
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Isfullwidth; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Isfullwidth = value;
				SetDirty("Isfullwidth");
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
			gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctatype;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor;
		 

		protected bool gxTv_SdtSDT_ContentPage_CtaItem_Isfullwidth;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ContentPage.CtaItem", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage_CtaItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage_CtaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage_CtaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage_CtaItem_RESTInterface( SdtSDT_ContentPage_CtaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CtaType", Order=0)]
		public  string gxTpr_Ctatype
		{
			get { 
				return sdt.gxTpr_Ctatype;

			}
			set { 
				 sdt.gxTpr_Ctatype = value;
			}
		}

		[DataMember(Name="CtaLabel", Order=1)]
		public  string gxTpr_Ctalabel
		{
			get { 
				return sdt.gxTpr_Ctalabel;

			}
			set { 
				 sdt.gxTpr_Ctalabel = value;
			}
		}

		[DataMember(Name="CtaAction", Order=2)]
		public  string gxTpr_Ctaaction
		{
			get { 
				return sdt.gxTpr_Ctaaction;

			}
			set { 
				 sdt.gxTpr_Ctaaction = value;
			}
		}

		[DataMember(Name="CtaBGColor", Order=3)]
		public  string gxTpr_Ctabgcolor
		{
			get { 
				return sdt.gxTpr_Ctabgcolor;

			}
			set { 
				 sdt.gxTpr_Ctabgcolor = value;
			}
		}

		[DataMember(Name="IsFullWidth", Order=4)]
		public bool gxTpr_Isfullwidth
		{
			get { 
				return sdt.gxTpr_Isfullwidth;

			}
			set { 
				sdt.gxTpr_Isfullwidth = value;
			}
		}


		#endregion

		public SdtSDT_ContentPage_CtaItem sdt
		{
			get { 
				return (SdtSDT_ContentPage_CtaItem)Sdt;
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
				sdt = new SdtSDT_ContentPage_CtaItem() ;
			}
		}
	}
	#endregion
}