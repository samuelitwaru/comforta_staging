/*
				   File: type_SdtSDT_NetworkIndividual
			Description: SDT_NetworkIndividual
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
	[XmlRoot(ElementName="SDT_NetworkIndividual")]
	[XmlType(TypeName="SDT_NetworkIndividual" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_NetworkIndividual : GxUserType
	{
		public SdtSDT_NetworkIndividual( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NetworkIndividual_Networkindividualbsnnumber = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualgivenname = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividuallastname = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualemail = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualphone = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephone = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualphonecode = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonecode = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualphonenumber = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonenumber = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualgender = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualcountry = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualcity = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualzipcode = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline1 = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline2 = "";

			gxTv_SdtSDT_NetworkIndividual_Networkindividualfulladdress = "";

		}

		public SdtSDT_NetworkIndividual(IGxContext context)
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
			AddObjectProperty("NetworkIndividualId", gxTpr_Networkindividualid, false);


			AddObjectProperty("NetworkIndividualBsnNumber", gxTpr_Networkindividualbsnnumber, false);


			AddObjectProperty("NetworkIndividualGivenName", gxTpr_Networkindividualgivenname, false);


			AddObjectProperty("NetworkIndividualLastName", gxTpr_Networkindividuallastname, false);


			AddObjectProperty("NetworkIndividualEmail", gxTpr_Networkindividualemail, false);


			AddObjectProperty("NetworkIndividualPhone", gxTpr_Networkindividualphone, false);


			AddObjectProperty("NetworkIndividualHomePhone", gxTpr_Networkindividualhomephone, false);


			AddObjectProperty("NetworkIndividualPhoneCode", gxTpr_Networkindividualphonecode, false);


			AddObjectProperty("NetworkIndividualHomePhoneCode", gxTpr_Networkindividualhomephonecode, false);


			AddObjectProperty("NetworkIndividualPhoneNumber", gxTpr_Networkindividualphonenumber, false);


			AddObjectProperty("NetworkIndividualHomePhoneNumber", gxTpr_Networkindividualhomephonenumber, false);


			AddObjectProperty("NetworkIndividualGender", gxTpr_Networkindividualgender, false);


			AddObjectProperty("NetworkIndividualCountry", gxTpr_Networkindividualcountry, false);


			AddObjectProperty("NetworkIndividualCity", gxTpr_Networkindividualcity, false);


			AddObjectProperty("NetworkIndividualZipCode", gxTpr_Networkindividualzipcode, false);


			AddObjectProperty("NetworkIndividualAddressLine1", gxTpr_Networkindividualaddressline1, false);


			AddObjectProperty("NetworkIndividualAddressLine2", gxTpr_Networkindividualaddressline2, false);


			AddObjectProperty("NetworkIndividualFullAddress", gxTpr_Networkindividualfulladdress, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NetworkIndividualId")]
		[XmlElement(ElementName="NetworkIndividualId")]
		public Guid gxTpr_Networkindividualid
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualid; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualid = value;
				SetDirty("Networkindividualid");
			}
		}




		[SoapElement(ElementName="NetworkIndividualBsnNumber")]
		[XmlElement(ElementName="NetworkIndividualBsnNumber")]
		public string gxTpr_Networkindividualbsnnumber
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualbsnnumber; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualbsnnumber = value;
				SetDirty("Networkindividualbsnnumber");
			}
		}




		[SoapElement(ElementName="NetworkIndividualGivenName")]
		[XmlElement(ElementName="NetworkIndividualGivenName")]
		public string gxTpr_Networkindividualgivenname
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualgivenname; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualgivenname = value;
				SetDirty("Networkindividualgivenname");
			}
		}




		[SoapElement(ElementName="NetworkIndividualLastName")]
		[XmlElement(ElementName="NetworkIndividualLastName")]
		public string gxTpr_Networkindividuallastname
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividuallastname; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividuallastname = value;
				SetDirty("Networkindividuallastname");
			}
		}




		[SoapElement(ElementName="NetworkIndividualEmail")]
		[XmlElement(ElementName="NetworkIndividualEmail")]
		public string gxTpr_Networkindividualemail
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualemail; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualemail = value;
				SetDirty("Networkindividualemail");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhone")]
		[XmlElement(ElementName="NetworkIndividualPhone")]
		public string gxTpr_Networkindividualphone
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualphone; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualphone = value;
				SetDirty("Networkindividualphone");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhone")]
		[XmlElement(ElementName="NetworkIndividualHomePhone")]
		public string gxTpr_Networkindividualhomephone
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephone; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephone = value;
				SetDirty("Networkindividualhomephone");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhoneCode")]
		[XmlElement(ElementName="NetworkIndividualPhoneCode")]
		public string gxTpr_Networkindividualphonecode
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualphonecode; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualphonecode = value;
				SetDirty("Networkindividualphonecode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhoneCode")]
		[XmlElement(ElementName="NetworkIndividualHomePhoneCode")]
		public string gxTpr_Networkindividualhomephonecode
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonecode; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonecode = value;
				SetDirty("Networkindividualhomephonecode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualPhoneNumber")]
		[XmlElement(ElementName="NetworkIndividualPhoneNumber")]
		public string gxTpr_Networkindividualphonenumber
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualphonenumber; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualphonenumber = value;
				SetDirty("Networkindividualphonenumber");
			}
		}




		[SoapElement(ElementName="NetworkIndividualHomePhoneNumber")]
		[XmlElement(ElementName="NetworkIndividualHomePhoneNumber")]
		public string gxTpr_Networkindividualhomephonenumber
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonenumber; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonenumber = value;
				SetDirty("Networkindividualhomephonenumber");
			}
		}




		[SoapElement(ElementName="NetworkIndividualGender")]
		[XmlElement(ElementName="NetworkIndividualGender")]
		public string gxTpr_Networkindividualgender
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualgender; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualgender = value;
				SetDirty("Networkindividualgender");
			}
		}




		[SoapElement(ElementName="NetworkIndividualCountry")]
		[XmlElement(ElementName="NetworkIndividualCountry")]
		public string gxTpr_Networkindividualcountry
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualcountry; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualcountry = value;
				SetDirty("Networkindividualcountry");
			}
		}




		[SoapElement(ElementName="NetworkIndividualCity")]
		[XmlElement(ElementName="NetworkIndividualCity")]
		public string gxTpr_Networkindividualcity
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualcity; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualcity = value;
				SetDirty("Networkindividualcity");
			}
		}




		[SoapElement(ElementName="NetworkIndividualZipCode")]
		[XmlElement(ElementName="NetworkIndividualZipCode")]
		public string gxTpr_Networkindividualzipcode
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualzipcode; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualzipcode = value;
				SetDirty("Networkindividualzipcode");
			}
		}




		[SoapElement(ElementName="NetworkIndividualAddressLine1")]
		[XmlElement(ElementName="NetworkIndividualAddressLine1")]
		public string gxTpr_Networkindividualaddressline1
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline1; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline1 = value;
				SetDirty("Networkindividualaddressline1");
			}
		}




		[SoapElement(ElementName="NetworkIndividualAddressLine2")]
		[XmlElement(ElementName="NetworkIndividualAddressLine2")]
		public string gxTpr_Networkindividualaddressline2
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline2; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline2 = value;
				SetDirty("Networkindividualaddressline2");
			}
		}




		[SoapElement(ElementName="NetworkIndividualFullAddress")]
		[XmlElement(ElementName="NetworkIndividualFullAddress")]
		public string gxTpr_Networkindividualfulladdress
		{
			get {
				return gxTv_SdtSDT_NetworkIndividual_Networkindividualfulladdress; 
			}
			set {
				gxTv_SdtSDT_NetworkIndividual_Networkindividualfulladdress = value;
				SetDirty("Networkindividualfulladdress");
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
			gxTv_SdtSDT_NetworkIndividual_Networkindividualbsnnumber = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualgivenname = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividuallastname = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualemail = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualphone = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephone = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualphonecode = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonecode = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualphonenumber = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonenumber = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualgender = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualcountry = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualcity = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualzipcode = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline1 = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline2 = "";
			gxTv_SdtSDT_NetworkIndividual_Networkindividualfulladdress = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_NetworkIndividual_Networkindividualid;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualbsnnumber;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualgivenname;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividuallastname;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualemail;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualphone;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephone;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualphonecode;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonecode;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualphonenumber;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualhomephonenumber;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualgender;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualcountry;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualcity;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualzipcode;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline1;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualaddressline2;
		 

		protected string gxTv_SdtSDT_NetworkIndividual_Networkindividualfulladdress;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NetworkIndividual", Namespace="Comforta_version2")]
	public class SdtSDT_NetworkIndividual_RESTInterface : GxGenericCollectionItem<SdtSDT_NetworkIndividual>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NetworkIndividual_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NetworkIndividual_RESTInterface( SdtSDT_NetworkIndividual psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NetworkIndividualId", Order=0)]
		public Guid gxTpr_Networkindividualid
		{
			get { 
				return sdt.gxTpr_Networkindividualid;

			}
			set { 
				sdt.gxTpr_Networkindividualid = value;
			}
		}

		[DataMember(Name="NetworkIndividualBsnNumber", Order=1)]
		public  string gxTpr_Networkindividualbsnnumber
		{
			get { 
				return sdt.gxTpr_Networkindividualbsnnumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualbsnnumber = value;
			}
		}

		[DataMember(Name="NetworkIndividualGivenName", Order=2)]
		public  string gxTpr_Networkindividualgivenname
		{
			get { 
				return sdt.gxTpr_Networkindividualgivenname;

			}
			set { 
				 sdt.gxTpr_Networkindividualgivenname = value;
			}
		}

		[DataMember(Name="NetworkIndividualLastName", Order=3)]
		public  string gxTpr_Networkindividuallastname
		{
			get { 
				return sdt.gxTpr_Networkindividuallastname;

			}
			set { 
				 sdt.gxTpr_Networkindividuallastname = value;
			}
		}

		[DataMember(Name="NetworkIndividualEmail", Order=4)]
		public  string gxTpr_Networkindividualemail
		{
			get { 
				return sdt.gxTpr_Networkindividualemail;

			}
			set { 
				 sdt.gxTpr_Networkindividualemail = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhone", Order=5)]
		public  string gxTpr_Networkindividualphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkindividualphone);

			}
			set { 
				 sdt.gxTpr_Networkindividualphone = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhone", Order=6)]
		public  string gxTpr_Networkindividualhomephone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkindividualhomephone);

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephone = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhoneCode", Order=7)]
		public  string gxTpr_Networkindividualphonecode
		{
			get { 
				return sdt.gxTpr_Networkindividualphonecode;

			}
			set { 
				 sdt.gxTpr_Networkindividualphonecode = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhoneCode", Order=8)]
		public  string gxTpr_Networkindividualhomephonecode
		{
			get { 
				return sdt.gxTpr_Networkindividualhomephonecode;

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephonecode = value;
			}
		}

		[DataMember(Name="NetworkIndividualPhoneNumber", Order=9)]
		public  string gxTpr_Networkindividualphonenumber
		{
			get { 
				return sdt.gxTpr_Networkindividualphonenumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualphonenumber = value;
			}
		}

		[DataMember(Name="NetworkIndividualHomePhoneNumber", Order=10)]
		public  string gxTpr_Networkindividualhomephonenumber
		{
			get { 
				return sdt.gxTpr_Networkindividualhomephonenumber;

			}
			set { 
				 sdt.gxTpr_Networkindividualhomephonenumber = value;
			}
		}

		[DataMember(Name="NetworkIndividualGender", Order=11)]
		public  string gxTpr_Networkindividualgender
		{
			get { 
				return sdt.gxTpr_Networkindividualgender;

			}
			set { 
				 sdt.gxTpr_Networkindividualgender = value;
			}
		}

		[DataMember(Name="NetworkIndividualCountry", Order=12)]
		public  string gxTpr_Networkindividualcountry
		{
			get { 
				return sdt.gxTpr_Networkindividualcountry;

			}
			set { 
				 sdt.gxTpr_Networkindividualcountry = value;
			}
		}

		[DataMember(Name="NetworkIndividualCity", Order=13)]
		public  string gxTpr_Networkindividualcity
		{
			get { 
				return sdt.gxTpr_Networkindividualcity;

			}
			set { 
				 sdt.gxTpr_Networkindividualcity = value;
			}
		}

		[DataMember(Name="NetworkIndividualZipCode", Order=14)]
		public  string gxTpr_Networkindividualzipcode
		{
			get { 
				return sdt.gxTpr_Networkindividualzipcode;

			}
			set { 
				 sdt.gxTpr_Networkindividualzipcode = value;
			}
		}

		[DataMember(Name="NetworkIndividualAddressLine1", Order=15)]
		public  string gxTpr_Networkindividualaddressline1
		{
			get { 
				return sdt.gxTpr_Networkindividualaddressline1;

			}
			set { 
				 sdt.gxTpr_Networkindividualaddressline1 = value;
			}
		}

		[DataMember(Name="NetworkIndividualAddressLine2", Order=16)]
		public  string gxTpr_Networkindividualaddressline2
		{
			get { 
				return sdt.gxTpr_Networkindividualaddressline2;

			}
			set { 
				 sdt.gxTpr_Networkindividualaddressline2 = value;
			}
		}

		[DataMember(Name="NetworkIndividualFullAddress", Order=17)]
		public  string gxTpr_Networkindividualfulladdress
		{
			get { 
				return sdt.gxTpr_Networkindividualfulladdress;

			}
			set { 
				 sdt.gxTpr_Networkindividualfulladdress = value;
			}
		}


		#endregion

		public SdtSDT_NetworkIndividual sdt
		{
			get { 
				return (SdtSDT_NetworkIndividual)Sdt;
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
				sdt = new SdtSDT_NetworkIndividual() ;
			}
		}
	}
	#endregion
}