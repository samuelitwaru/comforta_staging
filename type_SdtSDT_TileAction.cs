/*
				   File: type_SdtSDT_TileAction
			Description: SDT_TileAction
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
	[XmlRoot(ElementName="SDT_TileAction")]
	[XmlType(TypeName="SDT_TileAction" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_TileAction : GxUserType
	{
		public SdtSDT_TileAction( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TileAction_Objecttype = "";

		}

		public SdtSDT_TileAction(IGxContext context)
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
			AddObjectProperty("ObjectType", gxTpr_Objecttype, false);


			AddObjectProperty("ObjectId", gxTpr_Objectid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ObjectType")]
		[XmlElement(ElementName="ObjectType")]
		public string gxTpr_Objecttype
		{
			get {
				return gxTv_SdtSDT_TileAction_Objecttype; 
			}
			set {
				gxTv_SdtSDT_TileAction_Objecttype = value;
				SetDirty("Objecttype");
			}
		}




		[SoapElement(ElementName="ObjectId")]
		[XmlElement(ElementName="ObjectId")]
		public Guid gxTpr_Objectid
		{
			get {
				return gxTv_SdtSDT_TileAction_Objectid; 
			}
			set {
				gxTv_SdtSDT_TileAction_Objectid = value;
				SetDirty("Objectid");
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
			gxTv_SdtSDT_TileAction_Objecttype = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_TileAction_Objecttype;
		 

		protected Guid gxTv_SdtSDT_TileAction_Objectid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_TileAction", Namespace="Comforta_version2")]
	public class SdtSDT_TileAction_RESTInterface : GxGenericCollectionItem<SdtSDT_TileAction>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TileAction_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TileAction_RESTInterface( SdtSDT_TileAction psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ObjectType", Order=0)]
		public  string gxTpr_Objecttype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Objecttype);

			}
			set { 
				 sdt.gxTpr_Objecttype = value;
			}
		}

		[DataMember(Name="ObjectId", Order=1)]
		public Guid gxTpr_Objectid
		{
			get { 
				return sdt.gxTpr_Objectid;

			}
			set { 
				sdt.gxTpr_Objectid = value;
			}
		}


		#endregion

		public SdtSDT_TileAction sdt
		{
			get { 
				return (SdtSDT_TileAction)Sdt;
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
				sdt = new SdtSDT_TileAction() ;
			}
		}
	}
	#endregion
}