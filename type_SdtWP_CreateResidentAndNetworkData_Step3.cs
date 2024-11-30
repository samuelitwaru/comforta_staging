/*
				   File: type_SdtWP_CreateResidentAndNetworkData_Step3
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
	[XmlRoot(ElementName="WP_CreateResidentAndNetworkData.Step3")]
	[XmlType(TypeName="WP_CreateResidentAndNetworkData.Step3" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateResidentAndNetworkData_Step3 : GxUserType
	{
		public SdtWP_CreateResidentAndNetworkData_Step3( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline1 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline2 = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyzipcode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycity = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyname = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanykvknumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyemail = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonecode = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonenumber = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphone = "";

		}

		public SdtWP_CreateResidentAndNetworkData_Step3(IGxContext context)
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
			AddObjectProperty("NetworkCompanyAddressLine1", gxTpr_Networkcompanyaddressline1, false);


			AddObjectProperty("NetworkCompanyAddressLine2", gxTpr_Networkcompanyaddressline2, false);


			AddObjectProperty("NetworkCompanyZipCode", gxTpr_Networkcompanyzipcode, false);


			AddObjectProperty("NetworkCompanyCity", gxTpr_Networkcompanycity, false);


			AddObjectProperty("NetworkCompanyCountry", gxTpr_Networkcompanycountry, false);


			AddObjectProperty("NetworkCompanyId", gxTpr_Networkcompanyid, false);


			AddObjectProperty("NetworkCompanyName", gxTpr_Networkcompanyname, false);


			AddObjectProperty("NetworkCompanyKvkNumber", gxTpr_Networkcompanykvknumber, false);


			AddObjectProperty("NetworkCompanyEmail", gxTpr_Networkcompanyemail, false);


			AddObjectProperty("NetworkCompanyPhoneCode", gxTpr_Networkcompanyphonecode, false);


			AddObjectProperty("NetworkCompanyPhoneNumber", gxTpr_Networkcompanyphonenumber, false);


			AddObjectProperty("NetworkCompanyPhone", gxTpr_Networkcompanyphone, false);

			if (gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys != null)
			{
				AddObjectProperty("SDT_NetworkCompanys", gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NetworkCompanyAddressLine1")]
		[XmlElement(ElementName="NetworkCompanyAddressLine1")]
		public string gxTpr_Networkcompanyaddressline1
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline1 = value;
				SetDirty("Networkcompanyaddressline1");
			}
		}




		[SoapElement(ElementName="NetworkCompanyAddressLine2")]
		[XmlElement(ElementName="NetworkCompanyAddressLine2")]
		public string gxTpr_Networkcompanyaddressline2
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline2 = value;
				SetDirty("Networkcompanyaddressline2");
			}
		}




		[SoapElement(ElementName="NetworkCompanyZipCode")]
		[XmlElement(ElementName="NetworkCompanyZipCode")]
		public string gxTpr_Networkcompanyzipcode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyzipcode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyzipcode = value;
				SetDirty("Networkcompanyzipcode");
			}
		}




		[SoapElement(ElementName="NetworkCompanyCity")]
		[XmlElement(ElementName="NetworkCompanyCity")]
		public string gxTpr_Networkcompanycity
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycity; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycity = value;
				SetDirty("Networkcompanycity");
			}
		}




		[SoapElement(ElementName="NetworkCompanyCountry")]
		[XmlElement(ElementName="NetworkCompanyCountry")]
		public string gxTpr_Networkcompanycountry
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycountry; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycountry = value;
				SetDirty("Networkcompanycountry");
			}
		}




		[SoapElement(ElementName="NetworkCompanyId")]
		[XmlElement(ElementName="NetworkCompanyId")]
		public Guid gxTpr_Networkcompanyid
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyid; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyid = value;
				SetDirty("Networkcompanyid");
			}
		}




		[SoapElement(ElementName="NetworkCompanyName")]
		[XmlElement(ElementName="NetworkCompanyName")]
		public string gxTpr_Networkcompanyname
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyname; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyname = value;
				SetDirty("Networkcompanyname");
			}
		}




		[SoapElement(ElementName="NetworkCompanyKvkNumber")]
		[XmlElement(ElementName="NetworkCompanyKvkNumber")]
		public string gxTpr_Networkcompanykvknumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanykvknumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanykvknumber = value;
				SetDirty("Networkcompanykvknumber");
			}
		}




		[SoapElement(ElementName="NetworkCompanyEmail")]
		[XmlElement(ElementName="NetworkCompanyEmail")]
		public string gxTpr_Networkcompanyemail
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyemail; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyemail = value;
				SetDirty("Networkcompanyemail");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhoneCode")]
		[XmlElement(ElementName="NetworkCompanyPhoneCode")]
		public string gxTpr_Networkcompanyphonecode
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonecode; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonecode = value;
				SetDirty("Networkcompanyphonecode");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhoneNumber")]
		[XmlElement(ElementName="NetworkCompanyPhoneNumber")]
		public string gxTpr_Networkcompanyphonenumber
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonenumber = value;
				SetDirty("Networkcompanyphonenumber");
			}
		}




		[SoapElement(ElementName="NetworkCompanyPhone")]
		[XmlElement(ElementName="NetworkCompanyPhone")]
		public string gxTpr_Networkcompanyphone
		{
			get {
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphone; 
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphone = value;
				SetDirty("Networkcompanyphone");
			}
		}




		[SoapElement(ElementName="SDT_NetworkCompanys" )]
		[XmlArray(ElementName="SDT_NetworkCompanys"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkCompany> gxTpr_Sdt_networkcompanys_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys == null )
				{
					gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = new GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkCompany>( context, "SDT_NetworkCompany", "");
				}
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys;
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N = false;
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkCompany> gxTpr_Sdt_networkcompanys
		{
			get {
				if ( gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys == null )
				{
					gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = new GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkCompany>( context, "SDT_NetworkCompany", "");
				}
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N = false;
				return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys ;
			}
			set {
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N = false;
				gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = value;
				SetDirty("Sdt_networkcompanys");
			}
		}

		public void gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_SetNull()
		{
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N = true;
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = null;
		}

		public bool gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_IsNull()
		{
			return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys == null;
		}
		public bool ShouldSerializegxTpr_Sdt_networkcompanys_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys != null && gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys.Count > 0;

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
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline1 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline2 = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyzipcode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycity = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycountry = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyname = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanykvknumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyemail = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonecode = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonenumber = "";
			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphone = "";

			gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline1;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyaddressline2;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyzipcode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycity;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanycountry;
		 

		protected Guid gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyid;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyname;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanykvknumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyemail;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonecode;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphonenumber;
		 

		protected string gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Networkcompanyphone;
		 
		protected bool gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_NetworkCompany> gxTv_SdtWP_CreateResidentAndNetworkData_Step3_Sdt_networkcompanys = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateResidentAndNetworkData.Step3", Namespace="Comforta_version2")]
	public class SdtWP_CreateResidentAndNetworkData_Step3_RESTInterface : GxGenericCollectionItem<SdtWP_CreateResidentAndNetworkData_Step3>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateResidentAndNetworkData_Step3_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateResidentAndNetworkData_Step3_RESTInterface( SdtWP_CreateResidentAndNetworkData_Step3 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NetworkCompanyAddressLine1", Order=0)]
		public  string gxTpr_Networkcompanyaddressline1
		{
			get { 
				return sdt.gxTpr_Networkcompanyaddressline1;

			}
			set { 
				 sdt.gxTpr_Networkcompanyaddressline1 = value;
			}
		}

		[DataMember(Name="NetworkCompanyAddressLine2", Order=1)]
		public  string gxTpr_Networkcompanyaddressline2
		{
			get { 
				return sdt.gxTpr_Networkcompanyaddressline2;

			}
			set { 
				 sdt.gxTpr_Networkcompanyaddressline2 = value;
			}
		}

		[DataMember(Name="NetworkCompanyZipCode", Order=2)]
		public  string gxTpr_Networkcompanyzipcode
		{
			get { 
				return sdt.gxTpr_Networkcompanyzipcode;

			}
			set { 
				 sdt.gxTpr_Networkcompanyzipcode = value;
			}
		}

		[DataMember(Name="NetworkCompanyCity", Order=3)]
		public  string gxTpr_Networkcompanycity
		{
			get { 
				return sdt.gxTpr_Networkcompanycity;

			}
			set { 
				 sdt.gxTpr_Networkcompanycity = value;
			}
		}

		[DataMember(Name="NetworkCompanyCountry", Order=4)]
		public  string gxTpr_Networkcompanycountry
		{
			get { 
				return sdt.gxTpr_Networkcompanycountry;

			}
			set { 
				 sdt.gxTpr_Networkcompanycountry = value;
			}
		}

		[DataMember(Name="NetworkCompanyId", Order=5)]
		public Guid gxTpr_Networkcompanyid
		{
			get { 
				return sdt.gxTpr_Networkcompanyid;

			}
			set { 
				sdt.gxTpr_Networkcompanyid = value;
			}
		}

		[DataMember(Name="NetworkCompanyName", Order=6)]
		public  string gxTpr_Networkcompanyname
		{
			get { 
				return sdt.gxTpr_Networkcompanyname;

			}
			set { 
				 sdt.gxTpr_Networkcompanyname = value;
			}
		}

		[DataMember(Name="NetworkCompanyKvkNumber", Order=7)]
		public  string gxTpr_Networkcompanykvknumber
		{
			get { 
				return sdt.gxTpr_Networkcompanykvknumber;

			}
			set { 
				 sdt.gxTpr_Networkcompanykvknumber = value;
			}
		}

		[DataMember(Name="NetworkCompanyEmail", Order=8)]
		public  string gxTpr_Networkcompanyemail
		{
			get { 
				return sdt.gxTpr_Networkcompanyemail;

			}
			set { 
				 sdt.gxTpr_Networkcompanyemail = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhoneCode", Order=9)]
		public  string gxTpr_Networkcompanyphonecode
		{
			get { 
				return sdt.gxTpr_Networkcompanyphonecode;

			}
			set { 
				 sdt.gxTpr_Networkcompanyphonecode = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhoneNumber", Order=10)]
		public  string gxTpr_Networkcompanyphonenumber
		{
			get { 
				return sdt.gxTpr_Networkcompanyphonenumber;

			}
			set { 
				 sdt.gxTpr_Networkcompanyphonenumber = value;
			}
		}

		[DataMember(Name="NetworkCompanyPhone", Order=11)]
		public  string gxTpr_Networkcompanyphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networkcompanyphone);

			}
			set { 
				 sdt.gxTpr_Networkcompanyphone = value;
			}
		}

		[DataMember(Name="SDT_NetworkCompanys", Order=12, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_NetworkCompany_RESTInterface> gxTpr_Sdt_networkcompanys
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_networkcompanys_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_NetworkCompany_RESTInterface>(sdt.gxTpr_Sdt_networkcompanys);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_networkcompanys);
			}
		}


		#endregion

		public SdtWP_CreateResidentAndNetworkData_Step3 sdt
		{
			get { 
				return (SdtWP_CreateResidentAndNetworkData_Step3)Sdt;
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
				sdt = new SdtWP_CreateResidentAndNetworkData_Step3() ;
			}
		}
	}
	#endregion
}