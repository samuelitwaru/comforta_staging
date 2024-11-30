/*
				   File: type_SdtWP_CreateResidentAndNetworkData_Step1
			Description: Step1
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
	[XmlRoot(ElementName="WP_CreateResidentAndNetworkData.Step1")]
	[XmlType(TypeName="WP_CreateResidentAndNetworkData.Step1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateResidentAndNetworkData_Step1 : GxUserType
	{
		public SdtWP_CreateResidentAndNetworkData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline1 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline2 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentzipcode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcity = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentsalutation = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgivenname = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentlastname = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgender = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentemail = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonecode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonenumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphone = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonecode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonenumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephone = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbsnnumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypename = "";

		}

		public SdtWP_CreateResidentAndNetworkData_Step1(IGxContext context)
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
			AddObjectProperty("ResidentAddressLine1", gxTpr_Residentaddressline1, false);


			AddObjectProperty("ResidentAddressLine2", gxTpr_Residentaddressline2, false);


			AddObjectProperty("ResidentZipCode", gxTpr_Residentzipcode, false);


			AddObjectProperty("ResidentCity", gxTpr_Residentcity, false);


			AddObjectProperty("ResidentCountry", gxTpr_Residentcountry, false);


			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("ResidentSalutation", gxTpr_Residentsalutation, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentGender", gxTpr_Residentgender, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ResidentBirthDate", sDateCnv, false);



			AddObjectProperty("ResidentEmail", gxTpr_Residentemail, false);


			AddObjectProperty("ResidentPhoneCode", gxTpr_Residentphonecode, false);


			AddObjectProperty("ResidentPhoneNumber", gxTpr_Residentphonenumber, false);


			AddObjectProperty("ResidentPhone", gxTpr_Residentphone, false);


			AddObjectProperty("ResidentHomePhoneCode", gxTpr_Residenthomephonecode, false);


			AddObjectProperty("ResidentHomePhoneNumber", gxTpr_Residenthomephonenumber, false);


			AddObjectProperty("ResidentHomePhone", gxTpr_Residenthomephone, false);


			AddObjectProperty("ResidentBsnNumber", gxTpr_Residentbsnnumber, false);


			AddObjectProperty("ResidentTypeId", gxTpr_Residenttypeid, false);


			AddObjectProperty("MedicalIndicationId", gxTpr_Medicalindicationid, false);


			AddObjectProperty("ResidentTypeName", gxTpr_Residenttypename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentAddressLine1")]
		[XmlElement(ElementName="ResidentAddressLine1")]
		public string gxTpr_Residentaddressline1
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline1 = value;
				SetDirty("Residentaddressline1");
			}
		}




		[SoapElement(ElementName="ResidentAddressLine2")]
		[XmlElement(ElementName="ResidentAddressLine2")]
		public string gxTpr_Residentaddressline2
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline2 = value;
				SetDirty("Residentaddressline2");
			}
		}




		[SoapElement(ElementName="ResidentZipCode")]
		[XmlElement(ElementName="ResidentZipCode")]
		public string gxTpr_Residentzipcode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentzipcode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentzipcode = value;
				SetDirty("Residentzipcode");
			}
		}




		[SoapElement(ElementName="ResidentCity")]
		[XmlElement(ElementName="ResidentCity")]
		public string gxTpr_Residentcity
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcity; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcity = value;
				SetDirty("Residentcity");
			}
		}




		[SoapElement(ElementName="ResidentCountry")]
		[XmlElement(ElementName="ResidentCountry")]
		public string gxTpr_Residentcountry
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcountry; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcountry = value;
				SetDirty("Residentcountry");
			}
		}




		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentid; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="ResidentSalutation")]
		[XmlElement(ElementName="ResidentSalutation")]
		public string gxTpr_Residentsalutation
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentsalutation; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentsalutation = value;
				SetDirty("Residentsalutation");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgivenname; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentlastname; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentGender")]
		[XmlElement(ElementName="ResidentGender")]
		public string gxTpr_Residentgender
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgender; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgender = value;
				SetDirty("Residentgender");
			}
		}



		[SoapElement(ElementName="ResidentBirthDate")]
		[XmlElement(ElementName="ResidentBirthDate" , IsNullable=true)]
		public string gxTpr_Residentbirthdate_Nullable
		{
			get {
				if ( gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate).value ;
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Residentbirthdate
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate = value;
				SetDirty("Residentbirthdate");
			}
		}



		[SoapElement(ElementName="ResidentEmail")]
		[XmlElement(ElementName="ResidentEmail")]
		public string gxTpr_Residentemail
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentemail; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentemail = value;
				SetDirty("Residentemail");
			}
		}




		[SoapElement(ElementName="ResidentPhoneCode")]
		[XmlElement(ElementName="ResidentPhoneCode")]
		public string gxTpr_Residentphonecode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonecode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonecode = value;
				SetDirty("Residentphonecode");
			}
		}




		[SoapElement(ElementName="ResidentPhoneNumber")]
		[XmlElement(ElementName="ResidentPhoneNumber")]
		public string gxTpr_Residentphonenumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonenumber = value;
				SetDirty("Residentphonenumber");
			}
		}




		[SoapElement(ElementName="ResidentPhone")]
		[XmlElement(ElementName="ResidentPhone")]
		public string gxTpr_Residentphone
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphone; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphone = value;
				SetDirty("Residentphone");
			}
		}




		[SoapElement(ElementName="ResidentHomePhoneCode")]
		[XmlElement(ElementName="ResidentHomePhoneCode")]
		public string gxTpr_Residenthomephonecode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonecode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonecode = value;
				SetDirty("Residenthomephonecode");
			}
		}




		[SoapElement(ElementName="ResidentHomePhoneNumber")]
		[XmlElement(ElementName="ResidentHomePhoneNumber")]
		public string gxTpr_Residenthomephonenumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonenumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonenumber = value;
				SetDirty("Residenthomephonenumber");
			}
		}




		[SoapElement(ElementName="ResidentHomePhone")]
		[XmlElement(ElementName="ResidentHomePhone")]
		public string gxTpr_Residenthomephone
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephone; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephone = value;
				SetDirty("Residenthomephone");
			}
		}




		[SoapElement(ElementName="ResidentBsnNumber")]
		[XmlElement(ElementName="ResidentBsnNumber")]
		public string gxTpr_Residentbsnnumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbsnnumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbsnnumber = value;
				SetDirty("Residentbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentTypeId")]
		[XmlElement(ElementName="ResidentTypeId")]
		public Guid gxTpr_Residenttypeid
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypeid; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypeid = value;
				SetDirty("Residenttypeid");
			}
		}




		[SoapElement(ElementName="MedicalIndicationId")]
		[XmlElement(ElementName="MedicalIndicationId")]
		public Guid gxTpr_Medicalindicationid
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Medicalindicationid; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Medicalindicationid = value;
				SetDirty("Medicalindicationid");
			}
		}




		[SoapElement(ElementName="ResidentTypeName")]
		[XmlElement(ElementName="ResidentTypeName")]
		public string gxTpr_Residenttypename
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypename; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypename = value;
				SetDirty("Residenttypename");
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
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline1 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline2 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentzipcode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcity = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentsalutation = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgivenname = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentlastname = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgender = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentemail = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonecode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonenumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphone = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonecode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonenumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephone = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbsnnumber = "";


			gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypename = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline1;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentaddressline2;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentzipcode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcity;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentcountry;
		 

		protected Guid gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentid;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentsalutation;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgivenname;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentlastname;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentgender;
		 

		protected DateTime gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbirthdate;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentemail;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonecode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphonenumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentphone;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonecode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephonenumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenthomephone;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residentbsnnumber;
		 

		protected Guid gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypeid;
		 

		protected Guid gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Medicalindicationid;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step1_Residenttypename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateResidentAndNetworkData.Step1", Namespace="Comforta_version2")]
	public class SdtWP_CreateResidentAndNetworkData_Step1_RESTInterface : GxGenericCollectionItem<SdtWP_CreateResidentAndNetworkData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateResidentAndNetworkData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateResidentAndNetworkData_Step1_RESTInterface( SdtWP_CreateResidentAndNetworkData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentAddressLine1", Order=0)]
		public  string gxTpr_Residentaddressline1
		{
			get { 
				return sdt.gxTpr_Residentaddressline1;

			}
			set { 
				 sdt.gxTpr_Residentaddressline1 = value;
			}
		}

		[DataMember(Name="ResidentAddressLine2", Order=1)]
		public  string gxTpr_Residentaddressline2
		{
			get { 
				return sdt.gxTpr_Residentaddressline2;

			}
			set { 
				 sdt.gxTpr_Residentaddressline2 = value;
			}
		}

		[DataMember(Name="ResidentZipCode", Order=2)]
		public  string gxTpr_Residentzipcode
		{
			get { 
				return sdt.gxTpr_Residentzipcode;

			}
			set { 
				 sdt.gxTpr_Residentzipcode = value;
			}
		}

		[DataMember(Name="ResidentCity", Order=3)]
		public  string gxTpr_Residentcity
		{
			get { 
				return sdt.gxTpr_Residentcity;

			}
			set { 
				 sdt.gxTpr_Residentcity = value;
			}
		}

		[DataMember(Name="ResidentCountry", Order=4)]
		public  string gxTpr_Residentcountry
		{
			get { 
				return sdt.gxTpr_Residentcountry;

			}
			set { 
				 sdt.gxTpr_Residentcountry = value;
			}
		}

		[DataMember(Name="ResidentId", Order=5)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="ResidentSalutation", Order=6)]
		public  string gxTpr_Residentsalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentsalutation);

			}
			set { 
				 sdt.gxTpr_Residentsalutation = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=7)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=8)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentGender", Order=9)]
		public  string gxTpr_Residentgender
		{
			get { 
				return sdt.gxTpr_Residentgender;

			}
			set { 
				 sdt.gxTpr_Residentgender = value;
			}
		}

		[DataMember(Name="ResidentBirthDate", Order=10)]
		public  string gxTpr_Residentbirthdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Residentbirthdate);

			}
			set { 
				sdt.gxTpr_Residentbirthdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ResidentEmail", Order=11)]
		public  string gxTpr_Residentemail
		{
			get { 
				return sdt.gxTpr_Residentemail;

			}
			set { 
				 sdt.gxTpr_Residentemail = value;
			}
		}

		[DataMember(Name="ResidentPhoneCode", Order=12)]
		public  string gxTpr_Residentphonecode
		{
			get { 
				return sdt.gxTpr_Residentphonecode;

			}
			set { 
				 sdt.gxTpr_Residentphonecode = value;
			}
		}

		[DataMember(Name="ResidentPhoneNumber", Order=13)]
		public  string gxTpr_Residentphonenumber
		{
			get { 
				return sdt.gxTpr_Residentphonenumber;

			}
			set { 
				 sdt.gxTpr_Residentphonenumber = value;
			}
		}

		[DataMember(Name="ResidentPhone", Order=14)]
		public  string gxTpr_Residentphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentphone);

			}
			set { 
				 sdt.gxTpr_Residentphone = value;
			}
		}

		[DataMember(Name="ResidentHomePhoneCode", Order=15)]
		public  string gxTpr_Residenthomephonecode
		{
			get { 
				return sdt.gxTpr_Residenthomephonecode;

			}
			set { 
				 sdt.gxTpr_Residenthomephonecode = value;
			}
		}

		[DataMember(Name="ResidentHomePhoneNumber", Order=16)]
		public  string gxTpr_Residenthomephonenumber
		{
			get { 
				return sdt.gxTpr_Residenthomephonenumber;

			}
			set { 
				 sdt.gxTpr_Residenthomephonenumber = value;
			}
		}

		[DataMember(Name="ResidentHomePhone", Order=17)]
		public  string gxTpr_Residenthomephone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residenthomephone);

			}
			set { 
				 sdt.gxTpr_Residenthomephone = value;
			}
		}

		[DataMember(Name="ResidentBsnNumber", Order=18)]
		public  string gxTpr_Residentbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentTypeId", Order=19)]
		public Guid gxTpr_Residenttypeid
		{
			get { 
				return sdt.gxTpr_Residenttypeid;

			}
			set { 
				sdt.gxTpr_Residenttypeid = value;
			}
		}

		[DataMember(Name="MedicalIndicationId", Order=20)]
		public Guid gxTpr_Medicalindicationid
		{
			get { 
				return sdt.gxTpr_Medicalindicationid;

			}
			set { 
				sdt.gxTpr_Medicalindicationid = value;
			}
		}

		[DataMember(Name="ResidentTypeName", Order=21)]
		public  string gxTpr_Residenttypename
		{
			get { 
				return sdt.gxTpr_Residenttypename;

			}
			set { 
				 sdt.gxTpr_Residenttypename = value;
			}
		}


		#endregion

		public SdtWP_CreateResidentAndNetworkData_Step1 sdt
		{
			get { 
				return (SdtWP_CreateResidentAndNetworkData_Step1)Sdt;
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
				sdt = new SdtWP_CreateResidentAndNetworkData_Step1() ;
			}
		}
	}
	#endregion
}