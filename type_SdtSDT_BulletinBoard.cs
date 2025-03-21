/*
				   File: type_SdtSDT_BulletinBoard
			Description: SDT_BulletinBoard
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
	[XmlRoot(ElementName="SDT_BulletinBoard")]
	[XmlType(TypeName="SDT_BulletinBoard" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_BulletinBoard : GxUserType
	{
		public SdtSDT_BulletinBoard( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_BulletinBoard_Bulletinboardbgcolorcode = "";

			gxTv_SdtSDT_BulletinBoard_Bulletinboardform = "";

		}

		public SdtSDT_BulletinBoard(IGxContext context)
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
			AddObjectProperty("BulletinBoardId", gxTpr_Bulletinboardid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("BulletinBoardBgColorCode", gxTpr_Bulletinboardbgcolorcode, false);


			AddObjectProperty("BulletinBoardForm", gxTpr_Bulletinboardform, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="BulletinBoardId")]
		[XmlElement(ElementName="BulletinBoardId")]
		public Guid gxTpr_Bulletinboardid
		{
			get {
				return gxTv_SdtSDT_BulletinBoard_Bulletinboardid; 
			}
			set {
				gxTv_SdtSDT_BulletinBoard_Bulletinboardid = value;
				SetDirty("Bulletinboardid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_BulletinBoard_Organisationid; 
			}
			set {
				gxTv_SdtSDT_BulletinBoard_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_BulletinBoard_Locationid; 
			}
			set {
				gxTv_SdtSDT_BulletinBoard_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="BulletinBoardBgColorCode")]
		[XmlElement(ElementName="BulletinBoardBgColorCode")]
		public string gxTpr_Bulletinboardbgcolorcode
		{
			get {
				return gxTv_SdtSDT_BulletinBoard_Bulletinboardbgcolorcode; 
			}
			set {
				gxTv_SdtSDT_BulletinBoard_Bulletinboardbgcolorcode = value;
				SetDirty("Bulletinboardbgcolorcode");
			}
		}




		[SoapElement(ElementName="BulletinBoardForm")]
		[XmlElement(ElementName="BulletinBoardForm")]
		public string gxTpr_Bulletinboardform
		{
			get {
				return gxTv_SdtSDT_BulletinBoard_Bulletinboardform; 
			}
			set {
				gxTv_SdtSDT_BulletinBoard_Bulletinboardform = value;
				SetDirty("Bulletinboardform");
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
			gxTv_SdtSDT_BulletinBoard_Bulletinboardbgcolorcode = "";
			gxTv_SdtSDT_BulletinBoard_Bulletinboardform = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_BulletinBoard_Bulletinboardid;
		 

		protected Guid gxTv_SdtSDT_BulletinBoard_Organisationid;
		 

		protected Guid gxTv_SdtSDT_BulletinBoard_Locationid;
		 

		protected string gxTv_SdtSDT_BulletinBoard_Bulletinboardbgcolorcode;
		 

		protected string gxTv_SdtSDT_BulletinBoard_Bulletinboardform;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_BulletinBoard", Namespace="Comforta_version2")]
	public class SdtSDT_BulletinBoard_RESTInterface : GxGenericCollectionItem<SdtSDT_BulletinBoard>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_BulletinBoard_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_BulletinBoard_RESTInterface( SdtSDT_BulletinBoard psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="BulletinBoardId", Order=0)]
		public Guid gxTpr_Bulletinboardid
		{
			get { 
				return sdt.gxTpr_Bulletinboardid;

			}
			set { 
				sdt.gxTpr_Bulletinboardid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=1)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="LocationId", Order=2)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="BulletinBoardBgColorCode", Order=3)]
		public  string gxTpr_Bulletinboardbgcolorcode
		{
			get { 
				return sdt.gxTpr_Bulletinboardbgcolorcode;

			}
			set { 
				 sdt.gxTpr_Bulletinboardbgcolorcode = value;
			}
		}

		[DataMember(Name="BulletinBoardForm", Order=4)]
		public  string gxTpr_Bulletinboardform
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Bulletinboardform);

			}
			set { 
				 sdt.gxTpr_Bulletinboardform = value;
			}
		}


		#endregion

		public SdtSDT_BulletinBoard sdt
		{
			get { 
				return (SdtSDT_BulletinBoard)Sdt;
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
				sdt = new SdtSDT_BulletinBoard() ;
			}
		}
	}
	#endregion
}