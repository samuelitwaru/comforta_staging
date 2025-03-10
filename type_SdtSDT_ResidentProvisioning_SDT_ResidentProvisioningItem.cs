/*
				   File: type_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem
			Description: SDT_ResidentProvisioning
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
	[XmlRoot(ElementName="SDT_ResidentProvisioningItem")]
	[XmlType(TypeName="SDT_ResidentProvisioningItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem : GxUserType
	{
		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisiondescription = "";

			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisionvalue = "";

		}

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(IGxContext context)
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
			AddObjectProperty("OrganisationProvisionDescription", gxTpr_Organisationprovisiondescription, false);


			AddObjectProperty("OrganisationprovisionValue", gxTpr_Organisationprovisionvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationProvisionDescription")]
		[XmlElement(ElementName="OrganisationProvisionDescription")]
		public string gxTpr_Organisationprovisiondescription
		{
			get {
				return gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisiondescription; 
			}
			set {
				gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisiondescription = value;
				SetDirty("Organisationprovisiondescription");
			}
		}




		[SoapElement(ElementName="OrganisationprovisionValue")]
		[XmlElement(ElementName="OrganisationprovisionValue")]
		public string gxTpr_Organisationprovisionvalue
		{
			get {
				return gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisionvalue; 
			}
			set {
				gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisionvalue = value;
				SetDirty("Organisationprovisionvalue");
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
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisiondescription = "";
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisionvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisiondescription;
		 

		protected string gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Organisationprovisionvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ResidentProvisioningItem", Namespace="Comforta_version2")]
	public class SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface( SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationProvisionDescription", Order=0)]
		public  string gxTpr_Organisationprovisiondescription
		{
			get { 
				return sdt.gxTpr_Organisationprovisiondescription;

			}
			set { 
				 sdt.gxTpr_Organisationprovisiondescription = value;
			}
		}

		[DataMember(Name="OrganisationprovisionValue", Order=1)]
		public  string gxTpr_Organisationprovisionvalue
		{
			get { 
				return sdt.gxTpr_Organisationprovisionvalue;

			}
			set { 
				 sdt.gxTpr_Organisationprovisionvalue = value;
			}
		}


		#endregion

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem sdt
		{
			get { 
				return (SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem)Sdt;
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
				sdt = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem() ;
			}
		}
	}
	#endregion
}