/*
				   File: type_SdtSDT_OneSignalCustomBody_headings
			Description: headings
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
	[XmlRoot(ElementName="SDT_OneSignalCustomBody.headings")]
	[XmlType(TypeName="SDT_OneSignalCustomBody.headings" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomBody_headings : GxUserType
	{
		public SdtSDT_OneSignalCustomBody_headings( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomBody_headings_En = "";

		}

		public SdtSDT_OneSignalCustomBody_headings(IGxContext context)
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
			AddObjectProperty("en", gxTpr_En, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="en")]
		[XmlElement(ElementName="en")]
		public string gxTpr_En
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomBody_headings_En; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_headings_En = value;
				SetDirty("En");
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
			gxTv_SdtSDT_OneSignalCustomBody_headings_En = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomBody_headings_En;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomBody.headings", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomBody_headings_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomBody_headings>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomBody_headings_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomBody_headings_RESTInterface( SdtSDT_OneSignalCustomBody_headings psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="en", Order=0)]
		public  string gxTpr_En
		{
			get { 
				return sdt.gxTpr_En;

			}
			set { 
				 sdt.gxTpr_En = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomBody_headings sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomBody_headings)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomBody_headings() ;
			}
		}
	}
	#endregion
}