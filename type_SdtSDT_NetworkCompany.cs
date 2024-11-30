/*
				   File: type_SdtSDT_NetworkCompany
			Description: SDT_NetworkCompany
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
	[XmlRoot(ElementName="SDT_NetworkCompany")]
	[XmlType(TypeName="SDT_NetworkCompany" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_NetworkCompany : GxUserType
	{
		public SdtSDT_NetworkCompany( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NetworkCompany_Networkcompanykvknumber = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyname = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyemail = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyphonecode = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyphonenumber = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyphone = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanycountry = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanycity = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyzipcode = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline1 = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline2 = "";

			gxTv_SdtSDT_NetworkCompany_Networkcompanyfulladdress = "";

		}

		public SdtSDT_NetworkCompany(IGxContext context)
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
			AddObjectProperty("NetworkCompanyId", gxTpr_Networkcompanyid, false);


			AddObjectProperty("NetworkCompanyKvkNumber", gxTpr_Networkcompanykvknumber, false);


			AddObjectProperty("NetworkCompanyName", gxTpr_Networkcompanyname, false);


			AddObjectProperty("NetworkCompanyEmail", gxTpr_Networkcompanyemail, false);


			AddObjectProperty("NetworkCompanyPhoneCode", gxTpr_Networkcompanyphonecode, false);


			AddObjectProperty("NetworkCompanyPhoneNumber", gxTpr_Networkcompanyphonenumber, false);


			AddObjectProperty("NetworkCompanyPhone", gxTpr_Networkcompanyphone, false);


			AddObjectProperty("NetworkCompanyCountry", gxTpr_Networkcompanycountry, false);


			AddObjectProperty("NetworkCompanyCity", gxTpr_Networkcompanycity, false);


			AddObjectProperty("NetworkCompanyZipCode", gxTpr_Networkcompanyzipcode, false);


			AddObjectProperty("NetworkCompanyAddressLine1", gxTpr_Networkcompanyaddressline1, false);


			AddObjectProperty("NetworkCompanyAddressLine2", gxTpr_Networkcompanyaddressline2, false);


			AddObjectProperty("NetworkCompanyFullAddress", gxTpr_Networkcompanyfulladdress, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NetworkCompanyId")]
		[XmlElement(ElementName="NetworkCompanyId")]
		public Guid gxTpr_Networkcompanyid
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyid; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyid = value;
				SetDirty("Networkcompanyid");
			}
		}




		[SoapElement(ElementName="NetworkCompanyKvkNumber")]
		[XmlElement(ElementName="NetworkCompanyKvkNumber")]
		public string gxTpr_Networkcompanykvknumber
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanykvknumber; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanykvknumber = value;
				SetDirty("Networkcompanykvknumber");
			}
		}




		[SoapElement(ElementName="NetworkCompanyName")]
		[XmlElement(ElementName="NetworkCompanyName")]
		public string gxTpr_Networkcompanyname
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyname; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyname = value;
				SetDirty("Networkcompanyname");
			}
		}




		[SoapElement(ElementName="NetworkCompanyEmail")]
		[XmlElement(ElementName="NetworkCompanyEmail")]
		public string gxTpr_Networkcompanyemail
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyemail; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyemail = value;
				SetDirty("Networkcompanyemail");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhoneCode")]
		[XmlElement(ElementName="NetworkCompanyPhoneCode")]
		public string gxTpr_Networkcompanyphonecode
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyphonecode; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyphonecode = value;
				SetDirty("Networkcompanyphonecode");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhoneNumber")]
		[XmlElement(ElementName="NetworkCompanyPhoneNumber")]
		public string gxTpr_Networkcompanyphonenumber
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyphonenumber; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyphonenumber = value;
				SetDirty("Networkcompanyphonenumber");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhone")]
		[XmlElement(ElementName="NetworkCompanyPhone")]
		public string gxTpr_Networkcompanyphone
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyphone; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyphone = value;
				SetDirty("Networkcompanyphone");
			}
		}




		[SoapElement(ElementName="NetworkCompanyCountry")]
		[XmlElement(ElementName="NetworkCompanyCountry")]
		public string gxTpr_Networkcompanycountry
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanycountry; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanycountry = value;
				SetDirty("Networkcompanycountry");
			}
		}




		[SoapElement(ElementName="NetworkCompanyCity")]
		[XmlElement(ElementName="NetworkCompanyCity")]
		public string gxTpr_Networkcompanycity
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanycity; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanycity = value;
				SetDirty("Networkcompanycity");
			}
		}




		[SoapElement(ElementName="NetworkCompanyZipCode")]
		[XmlElement(ElementName="NetworkCompanyZipCode")]
		public string gxTpr_Networkcompanyzipcode
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyzipcode; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyzipcode = value;
				SetDirty("Networkcompanyzipcode");
			}
		}




		[SoapElement(ElementName="NetworkCompanyAddressLine1")]
		[XmlElement(ElementName="NetworkCompanyAddressLine1")]
		public string gxTpr_Networkcompanyaddressline1
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline1; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline1 = value;
				SetDirty("Networkcompanyaddressline1");
			}
		}




		[SoapElement(ElementName="NetworkCompanyAddressLine2")]
		[XmlElement(ElementName="NetworkCompanyAddressLine2")]
		public string gxTpr_Networkcompanyaddressline2
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline2; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline2 = value;
				SetDirty("Networkcompanyaddressline2");
			}
		}




		[SoapElement(ElementName="NetworkCompanyFullAddress")]
		[XmlElement(ElementName="NetworkCompanyFullAddress")]
		public string gxTpr_Networkcompanyfulladdress
		{
			get {
				return gxTv_SdtSDT_NetworkCompany_Networkcompanyfulladdress; 
			}
			set {
				gxTv_SdtSDT_NetworkCompany_Networkcompanyfulladdress = value;
				SetDirty("Networkcompanyfulladdress");
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
			gxTv_SdtSDT_NetworkCompany_Networkcompanykvknumber = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyname = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyemail = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyphonecode = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyphonenumber = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyphone = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanycountry = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanycity = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyzipcode = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline1 = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline2 = "";
			gxTv_SdtSDT_NetworkCompany_Networkcompanyfulladdress = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_NetworkCompany_Networkcompanyid;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanykvknumber;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyname;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyemail;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyphonecode;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyphonenumber;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyphone;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanycountry;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanycity;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyzipcode;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline1;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyaddressline2;
		 

		protected string gxTv_SdtSDT_NetworkCompany_Networkcompanyfulladdress;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NetworkCompany", Namespace="Comforta_version2")]
	public class SdtSDT_NetworkCompany_RESTInterface : GxGenericCollectionItem<SdtSDT_NetworkCompany>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NetworkCompany_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NetworkCompany_RESTInterface( SdtSDT_NetworkCompany psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NetworkCompanyId", Order=0)]
		public Guid gxTpr_Networkcompanyid
		{
			get { 
				return sdt.gxTpr_Networkcompanyid;

			}
			set { 
				sdt.gxTpr_Networkcompanyid = value;
			}
		}

		[DataMember(Name="NetworkCompanyKvkNumber", Order=1)]
		public  string gxTpr_Networkcompanykvknumber
		{
			get { 
				return sdt.gxTpr_Networkcompanykvknumber;

			}
			set { 
				 sdt.gxTpr_Networkcompanykvknumber = value;
			}
		}

		[DataMember(Name="NetworkCompanyName", Order=2)]
		public  string gxTpr_Networkcompanyname
		{
			get { 
				return sdt.gxTpr_Networkcompanyname;

			}
			set { 
				 sdt.gxTpr_Networkcompanyname = value;
			}
		}

		[DataMember(Name="NetworkCompanyEmail", Order=3)]
		public  string gxTpr_Networkcompanyemail
		{
			get { 
				return sdt.gxTpr_Networkcompanyemail;

			}
			set { 
				 sdt.gxTpr_Networkcompanyemail = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhoneCode", Order=4)]
		public  string gxTpr_Networkcompanyphonecode
		{
			get { 
				return sdt.gxTpr_Networkcompanyphonecode;

			}
			set { 
				 sdt.gxTpr_Networkcompanyphonecode = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhoneNumber", Order=5)]
		public  string gxTpr_Networkcompanyphonenumber
		{
			get { 
				return sdt.gxTpr_Networkcompanyphonenumber;

			}
			set { 
				 sdt.gxTpr_Networkcompanyphonenumber = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhone", Order=6)]
		public  string gxTpr_Networkcompanyphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkcompanyphone);

			}
			set { 
				 sdt.gxTpr_Networkcompanyphone = value;
			}
		}

		[DataMember(Name="NetworkCompanyCountry", Order=7)]
		public  string gxTpr_Networkcompanycountry
		{
			get { 
				return sdt.gxTpr_Networkcompanycountry;

			}
			set { 
				 sdt.gxTpr_Networkcompanycountry = value;
			}
		}

		[DataMember(Name="NetworkCompanyCity", Order=8)]
		public  string gxTpr_Networkcompanycity
		{
			get { 
				return sdt.gxTpr_Networkcompanycity;

			}
			set { 
				 sdt.gxTpr_Networkcompanycity = value;
			}
		}

		[DataMember(Name="NetworkCompanyZipCode", Order=9)]
		public  string gxTpr_Networkcompanyzipcode
		{
			get { 
				return sdt.gxTpr_Networkcompanyzipcode;

			}
			set { 
				 sdt.gxTpr_Networkcompanyzipcode = value;
			}
		}

		[DataMember(Name="NetworkCompanyAddressLine1", Order=10)]
		public  string gxTpr_Networkcompanyaddressline1
		{
			get { 
				return sdt.gxTpr_Networkcompanyaddressline1;

			}
			set { 
				 sdt.gxTpr_Networkcompanyaddressline1 = value;
			}
		}

		[DataMember(Name="NetworkCompanyAddressLine2", Order=11)]
		public  string gxTpr_Networkcompanyaddressline2
		{
			get { 
				return sdt.gxTpr_Networkcompanyaddressline2;

			}
			set { 
				 sdt.gxTpr_Networkcompanyaddressline2 = value;
			}
		}

		[DataMember(Name="NetworkCompanyFullAddress", Order=12)]
		public  string gxTpr_Networkcompanyfulladdress
		{
			get { 
				return sdt.gxTpr_Networkcompanyfulladdress;

			}
			set { 
				 sdt.gxTpr_Networkcompanyfulladdress = value;
			}
		}


		#endregion

		public SdtSDT_NetworkCompany sdt
		{
			get { 
				return (SdtSDT_NetworkCompany)Sdt;
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
				sdt = new SdtSDT_NetworkCompany() ;
			}
		}
	}
	#endregion
}