/*
				   File: type_SdtWP_CreateOrganisationAndManagerData_Step3
			Description: Step3
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
	[XmlRoot(ElementName="WP_CreateOrganisationAndManagerData.Step3")]
	[XmlType(TypeName="WP_CreateOrganisationAndManagerData.Step3" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateOrganisationAndManagerData_Step3 : GxUserType
	{
		public SdtWP_CreateOrganisationAndManagerData_Step3( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationctatheme = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationbrandtheme = "";

		}

		public SdtWP_CreateOrganisationAndManagerData_Step3(IGxContext context)
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
			AddObjectProperty("OrganisationCtaTheme", gxTpr_Organisationctatheme, false);


			AddObjectProperty("OrganisationBrandTheme", gxTpr_Organisationbrandtheme, false);


			AddObjectProperty("OrganisationHasMyCare", gxTpr_Organisationhasmycare, false);


			AddObjectProperty("OrganisationHasMyLiving", gxTpr_Organisationhasmyliving, false);


			AddObjectProperty("OrganisationHasMyServices", gxTpr_Organisationhasmyservices, false);


			AddObjectProperty("OrganisationHasDynamicForms", gxTpr_Organisationhasdynamicforms, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationCtaTheme")]
		[XmlElement(ElementName="OrganisationCtaTheme")]
		public string gxTpr_Organisationctatheme
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationctatheme; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationctatheme = value;
				SetDirty("Organisationctatheme");
			}
		}




		[SoapElement(ElementName="OrganisationBrandTheme")]
		[XmlElement(ElementName="OrganisationBrandTheme")]
		public string gxTpr_Organisationbrandtheme
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationbrandtheme; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationbrandtheme = value;
				SetDirty("Organisationbrandtheme");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyCare")]
		[XmlElement(ElementName="OrganisationHasMyCare")]
		public bool gxTpr_Organisationhasmycare
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare = value;
				SetDirty("Organisationhasmycare");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyLiving")]
		[XmlElement(ElementName="OrganisationHasMyLiving")]
		public bool gxTpr_Organisationhasmyliving
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving = value;
				SetDirty("Organisationhasmyliving");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyServices")]
		[XmlElement(ElementName="OrganisationHasMyServices")]
		public bool gxTpr_Organisationhasmyservices
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices = value;
				SetDirty("Organisationhasmyservices");
			}
		}




		[SoapElement(ElementName="OrganisationHasDynamicForms")]
		[XmlElement(ElementName="OrganisationHasDynamicForms")]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms = value;
				SetDirty("Organisationhasdynamicforms");
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
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationctatheme = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationbrandtheme = "";




			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationctatheme;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationbrandtheme;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateOrganisationAndManagerData.Step3", Namespace="Comforta_version2")]
	public class SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface : GxGenericCollectionItem<SdtWP_CreateOrganisationAndManagerData_Step3>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface( SdtWP_CreateOrganisationAndManagerData_Step3 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationCtaTheme", Order=0)]
		public  string gxTpr_Organisationctatheme
		{
			get { 
				return sdt.gxTpr_Organisationctatheme;

			}
			set { 
				 sdt.gxTpr_Organisationctatheme = value;
			}
		}

		[DataMember(Name="OrganisationBrandTheme", Order=1)]
		public  string gxTpr_Organisationbrandtheme
		{
			get { 
				return sdt.gxTpr_Organisationbrandtheme;

			}
			set { 
				 sdt.gxTpr_Organisationbrandtheme = value;
			}
		}

		[DataMember(Name="OrganisationHasMyCare", Order=2)]
		public bool gxTpr_Organisationhasmycare
		{
			get { 
				return sdt.gxTpr_Organisationhasmycare;

			}
			set { 
				sdt.gxTpr_Organisationhasmycare = value;
			}
		}

		[DataMember(Name="OrganisationHasMyLiving", Order=3)]
		public bool gxTpr_Organisationhasmyliving
		{
			get { 
				return sdt.gxTpr_Organisationhasmyliving;

			}
			set { 
				sdt.gxTpr_Organisationhasmyliving = value;
			}
		}

		[DataMember(Name="OrganisationHasMyServices", Order=4)]
		public bool gxTpr_Organisationhasmyservices
		{
			get { 
				return sdt.gxTpr_Organisationhasmyservices;

			}
			set { 
				sdt.gxTpr_Organisationhasmyservices = value;
			}
		}

		[DataMember(Name="OrganisationHasDynamicForms", Order=5)]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get { 
				return sdt.gxTpr_Organisationhasdynamicforms;

			}
			set { 
				sdt.gxTpr_Organisationhasdynamicforms = value;
			}
		}


		#endregion

		public SdtWP_CreateOrganisationAndManagerData_Step3 sdt
		{
			get { 
				return (SdtWP_CreateOrganisationAndManagerData_Step3)Sdt;
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
				sdt = new SdtWP_CreateOrganisationAndManagerData_Step3() ;
			}
		}
	}
	#endregion
}