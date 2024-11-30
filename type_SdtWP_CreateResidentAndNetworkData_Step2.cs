/*
				   File: type_SdtWP_CreateResidentAndNetworkData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="WP_CreateResidentAndNetworkData.Step2")]
	[XmlType(TypeName="WP_CreateResidentAndNetworkData.Step2" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateResidentAndNetworkData_Step2 : GxUserType
	{
		public SdtWP_CreateResidentAndNetworkData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline1 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline2 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualzipcode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcity = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgivenname = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividuallastname = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgender = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualemail = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonecode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonenumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphone = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonecode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonenumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephone = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualbsnnumber = "";

		}

		public SdtWP_CreateResidentAndNetworkData_Step2(IGxContext context)
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
			AddObjectProperty("NetworkIndividualAddressLine1", gxTpr_Networkindividualaddressline1, false);


			AddObjectProperty("NetworkIndividualAddressLine2", gxTpr_Networkindividualaddressline2, false);


			AddObjectProperty("NetworkIndividualZipCode", gxTpr_Networkindividualzipcode, false);


			AddObjectProperty("NetworkIndividualCity", gxTpr_Networkindividualcity, false);


			AddObjectProperty("NetworkIndividualCountry", gxTpr_Networkindividualcountry, false);


			AddObjectProperty("NetworkIndividualId", gxTpr_Networkindividualid, false);


			AddObjectProperty("NetworkIndividualGivenName", gxTpr_Networkindividualgivenname, false);


			AddObjectProperty("NetworkIndividualLastName", gxTpr_Networkindividuallastname, false);


			AddObjectProperty("NetworkIndividualGender", gxTpr_Networkindividualgender, false);


			AddObjectProperty("NetworkIndividualEmail", gxTpr_Networkindividualemail, false);


			AddObjectProperty("NetworkIndividualPhoneCode", gxTpr_Networkindividualphonecode, false);


			AddObjectProperty("NetworkIndividualPhoneNumber", gxTpr_Networkindividualphonenumber, false);


			AddObjectProperty("NetworkIndividualPhone", gxTpr_Networkindividualphone, false);


			AddObjectProperty("NetworkIndividualHomePhoneCode", gxTpr_Networkindividualhomephonecode, false);


			AddObjectProperty("NetworkIndividualHomePhoneNumber", gxTpr_Networkindividualhomephonenumber, false);


			AddObjectProperty("NetworkIndividualHomePhone", gxTpr_Networkindividualhomephone, false);


			AddObjectProperty("NetworkIndividualBsnNumber", gxTpr_Networkindividualbsnnumber, false);

			if (gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals != null)
			{
				AddObjectProperty("SDT_NetworkIndividuals", gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NetworkIndividualAddressLine1")]
		[XmlElement(ElementName="NetworkIndividualAddressLine1")]
		public string gxTpr_Networkindividualaddressline1
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline1 = value;
				SetDirty("Networkindividualaddressline1");
			}
		}




		[SoapElement(ElementName="NetworkIndividualAddressLine2")]
		[XmlElement(ElementName="NetworkIndividualAddressLine2")]
		public string gxTpr_Networkindividualaddressline2
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline2 = value;
				SetDirty("Networkindividualaddressline2");
			}
		}




		[SoapElement(ElementName="NetworkIndividualZipCode")]
		[XmlElement(ElementName="NetworkIndividualZipCode")]
		public string gxTpr_Networkindividualzipcode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualzipcode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualzipcode = value;
				SetDirty("Networkindividualzipcode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualCity")]
		[XmlElement(ElementName="NetworkIndividualCity")]
		public string gxTpr_Networkindividualcity
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcity; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcity = value;
				SetDirty("Networkindividualcity");
			}
		}




		[SoapElement(ElementName="NetworkIndividualCountry")]
		[XmlElement(ElementName="NetworkIndividualCountry")]
		public string gxTpr_Networkindividualcountry
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcountry; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcountry = value;
				SetDirty("Networkindividualcountry");
			}
		}




		[SoapElement(ElementName="NetworkIndividualId")]
		[XmlElement(ElementName="NetworkIndividualId")]
		public Guid gxTpr_Networkindividualid
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualid; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualid = value;
				SetDirty("Networkindividualid");
			}
		}




		[SoapElement(ElementName="NetworkIndividualGivenName")]
		[XmlElement(ElementName="NetworkIndividualGivenName")]
		public string gxTpr_Networkindividualgivenname
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgivenname; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgivenname = value;
				SetDirty("Networkindividualgivenname");
			}
		}




		[SoapElement(ElementName="NetworkIndividualLastName")]
		[XmlElement(ElementName="NetworkIndividualLastName")]
		public string gxTpr_Networkindividuallastname
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividuallastname; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividuallastname = value;
				SetDirty("Networkindividuallastname");
			}
		}




		[SoapElement(ElementName="NetworkIndividualGender")]
		[XmlElement(ElementName="NetworkIndividualGender")]
		public string gxTpr_Networkindividualgender
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgender; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgender = value;
				SetDirty("Networkindividualgender");
			}
		}




		[SoapElement(ElementName="NetworkIndividualEmail")]
		[XmlElement(ElementName="NetworkIndividualEmail")]
		public string gxTpr_Networkindividualemail
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualemail; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualemail = value;
				SetDirty("Networkindividualemail");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhoneCode")]
		[XmlElement(ElementName="NetworkIndividualPhoneCode")]
		public string gxTpr_Networkindividualphonecode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonecode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonecode = value;
				SetDirty("Networkindividualphonecode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhoneNumber")]
		[XmlElement(ElementName="NetworkIndividualPhoneNumber")]
		public string gxTpr_Networkindividualphonenumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonenumber = value;
				SetDirty("Networkindividualphonenumber");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhone")]
		[XmlElement(ElementName="NetworkIndividualPhone")]
		public string gxTpr_Networkindividualphone
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphone; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphone = value;
				SetDirty("Networkindividualphone");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhoneCode")]
		[XmlElement(ElementName="NetworkIndividualHomePhoneCode")]
		public string gxTpr_Networkindividualhomephonecode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonecode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonecode = value;
				SetDirty("Networkindividualhomephonecode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhoneNumber")]
		[XmlElement(ElementName="NetworkIndividualHomePhoneNumber")]
		public string gxTpr_Networkindividualhomephonenumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonenumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonenumber = value;
				SetDirty("Networkindividualhomephonenumber");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhone")]
		[XmlElement(ElementName="NetworkIndividualHomePhone")]
		public string gxTpr_Networkindividualhomephone
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephone; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephone = value;
				SetDirty("Networkindividualhomephone");
			}
		}




		[SoapElement(ElementName="NetworkIndividualBsnNumber")]
		[XmlElement(ElementName="NetworkIndividualBsnNumber")]
		public string gxTpr_Networkindividualbsnnumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualbsnnumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualbsnnumber = value;
				SetDirty("Networkindividualbsnnumber");
			}
		}




		[SoapElement(ElementName="SDT_NetworkIndividuals" )]
		[XmlArray(ElementName="SDT_NetworkIndividuals"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkIndividual> gxTpr_Sdt_networkindividuals_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals == null )
				{
					gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = new GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkIndividual>( context, "SDT_NetworkIndividual", "");
				}
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals;
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N = false;
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkIndividual> gxTpr_Sdt_networkindividuals
		{
			get {
				if ( gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals == null )
				{
					gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = new GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkIndividual>( context, "SDT_NetworkIndividual", "");
				}
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N = false;
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals ;
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N = false;
				gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = value;
				SetDirty("Sdt_networkindividuals");
			}
		}

		public void gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_SetNull()
		{
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N = true;
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = null;
		}

		public bool gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_IsNull()
		{
			return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals == null;
		}
		public bool ShouldSerializegxTpr_Sdt_networkindividuals_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals != null && gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals.Count > 0;

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
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline1 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline2 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualzipcode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcity = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgivenname = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividuallastname = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgender = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualemail = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonecode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonenumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphone = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonecode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonenumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephone = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualbsnnumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline1;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualaddressline2;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualzipcode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcity;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualcountry;
		 

		protected Guid gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualid;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgivenname;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividuallastname;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualgender;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualemail;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonecode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphonenumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualphone;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonecode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephonenumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualhomephone;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Networkindividualbsnnumber;
		 
		protected bool gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkIndividual> gxTv_SdtWP_CreateResidentAndNetworkData_Step2_Sdt_networkindividuals = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateResidentAndNetworkData.Step2", Namespace="Comforta_version2")]
	public class SdtWP_CreateResidentAndNetworkData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_CreateResidentAndNetworkData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateResidentAndNetworkData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateResidentAndNetworkData_Step2_RESTInterface( SdtWP_CreateResidentAndNetworkData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NetworkIndividualAddressLine1", Order=0)]
		public  string gxTpr_Networkindividualaddressline1
		{
			get { 
				return sdt.gxTpr_Networkindividualaddressline1;

			}
			set { 
				 sdt.gxTpr_Networkindividualaddressline1 = value;
			}
		}

		[DataMember(Name="NetworkIndividualAddressLine2", Order=1)]
		public  string gxTpr_Networkindividualaddressline2
		{
			get { 
				return sdt.gxTpr_Networkindividualaddressline2;

			}
			set { 
				 sdt.gxTpr_Networkindividualaddressline2 = value;
			}
		}

		[DataMember(Name="NetworkIndividualZipCode", Order=2)]
		public  string gxTpr_Networkindividualzipcode
		{
			get { 
				return sdt.gxTpr_Networkindividualzipcode;

			}
			set { 
				 sdt.gxTpr_Networkindividualzipcode = value;
			}
		}

		[DataMember(Name="NetworkIndividualCity", Order=3)]
		public  string gxTpr_Networkindividualcity
		{
			get { 
				return sdt.gxTpr_Networkindividualcity;

			}
			set { 
				 sdt.gxTpr_Networkindividualcity = value;
			}
		}

		[DataMember(Name="NetworkIndividualCountry", Order=4)]
		public  string gxTpr_Networkindividualcountry
		{
			get { 
				return sdt.gxTpr_Networkindividualcountry;

			}
			set { 
				 sdt.gxTpr_Networkindividualcountry = value;
			}
		}

		[DataMember(Name="NetworkIndividualId", Order=5)]
		public Guid gxTpr_Networkindividualid
		{
			get { 
				return sdt.gxTpr_Networkindividualid;

			}
			set { 
				sdt.gxTpr_Networkindividualid = value;
			}
		}

		[DataMember(Name="NetworkIndividualGivenName", Order=6)]
		public  string gxTpr_Networkindividualgivenname
		{
			get { 
				return sdt.gxTpr_Networkindividualgivenname;

			}
			set { 
				 sdt.gxTpr_Networkindividualgivenname = value;
			}
		}

		[DataMember(Name="NetworkIndividualLastName", Order=7)]
		public  string gxTpr_Networkindividuallastname
		{
			get { 
				return sdt.gxTpr_Networkindividuallastname;

			}
			set { 
				 sdt.gxTpr_Networkindividuallastname = value;
			}
		}

		[DataMember(Name="NetworkIndividualGender", Order=8)]
		public  string gxTpr_Networkindividualgender
		{
			get { 
				return sdt.gxTpr_Networkindividualgender;

			}
			set { 
				 sdt.gxTpr_Networkindividualgender = value;
			}
		}

		[DataMember(Name="NetworkIndividualEmail", Order=9)]
		public  string gxTpr_Networkindividualemail
		{
			get { 
				return sdt.gxTpr_Networkindividualemail;

			}
			set { 
				 sdt.gxTpr_Networkindividualemail = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhoneCode", Order=10)]
		public  string gxTpr_Networkindividualphonecode
		{
			get { 
				return sdt.gxTpr_Networkindividualphonecode;

			}
			set { 
				 sdt.gxTpr_Networkindividualphonecode = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhoneNumber", Order=11)]
		public  string gxTpr_Networkindividualphonenumber
		{
			get { 
				return sdt.gxTpr_Networkindividualphonenumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualphonenumber = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhone", Order=12)]
		public  string gxTpr_Networkindividualphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkindividualphone);

			}
			set { 
				 sdt.gxTpr_Networkindividualphone = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhoneCode", Order=13)]
		public  string gxTpr_Networkindividualhomephonecode
		{
			get { 
				return sdt.gxTpr_Networkindividualhomephonecode;

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephonecode = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhoneNumber", Order=14)]
		public  string gxTpr_Networkindividualhomephonenumber
		{
			get { 
				return sdt.gxTpr_Networkindividualhomephonenumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephonenumber = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhone", Order=15)]
		public  string gxTpr_Networkindividualhomephone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkindividualhomephone);

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephone = value;
			}
		}

		[DataMember(Name="NetworkIndividualBsnNumber", Order=16)]
		public  string gxTpr_Networkindividualbsnnumber
		{
			get { 
				return sdt.gxTpr_Networkindividualbsnnumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualbsnnumber = value;
			}
		}

		[DataMember(Name="SDT_NetworkIndividuals", Order=17, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_NetworkIndividual_RESTInterface> gxTpr_Sdt_networkindividuals
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_networkindividuals_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_NetworkIndividual_RESTInterface>(sdt.gxTpr_Sdt_networkindividuals);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_networkindividuals);
			}
		}


		#endregion

		public SdtWP_CreateResidentAndNetworkData_Step2 sdt
		{
			get { 
				return (SdtWP_CreateResidentAndNetworkData_Step2)Sdt;
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
				sdt = new SdtWP_CreateResidentAndNetworkData_Step2() ;
			}
		}
	}
	#endregion
}