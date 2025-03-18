/*
				   File: type_SdtSDT_DebugResults_Summary
			Description: Summary
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
	[XmlRoot(ElementName="SDT_DebugResults.Summary")]
	[XmlType(TypeName="SDT_DebugResults.Summary" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_DebugResults_Summary : GxUserType
	{
		public SdtSDT_DebugResults_Summary( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_DebugResults_Summary(IGxContext context)
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
			AddObjectProperty("TotalUrls", gxTpr_Totalurls, false);


			AddObjectProperty("SuccessCount", gxTpr_Successcount, false);


			AddObjectProperty("FailureCount", gxTpr_Failurecount, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TotalUrls")]
		[XmlElement(ElementName="TotalUrls")]
		public short gxTpr_Totalurls
		{
			get {
				return gxTv_SdtSDT_DebugResults_Summary_Totalurls; 
			}
			set {
				gxTv_SdtSDT_DebugResults_Summary_Totalurls = value;
				SetDirty("Totalurls");
			}
		}




		[SoapElement(ElementName="SuccessCount")]
		[XmlElement(ElementName="SuccessCount")]
		public short gxTpr_Successcount
		{
			get {
				return gxTv_SdtSDT_DebugResults_Summary_Successcount; 
			}
			set {
				gxTv_SdtSDT_DebugResults_Summary_Successcount = value;
				SetDirty("Successcount");
			}
		}




		[SoapElement(ElementName="FailureCount")]
		[XmlElement(ElementName="FailureCount")]
		public short gxTpr_Failurecount
		{
			get {
				return gxTv_SdtSDT_DebugResults_Summary_Failurecount; 
			}
			set {
				gxTv_SdtSDT_DebugResults_Summary_Failurecount = value;
				SetDirty("Failurecount");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDT_DebugResults_Summary_Totalurls;
		 

		protected short gxTv_SdtSDT_DebugResults_Summary_Successcount;
		 

		protected short gxTv_SdtSDT_DebugResults_Summary_Failurecount;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DebugResults.Summary", Namespace="Comforta_version2")]
	public class SdtSDT_DebugResults_Summary_RESTInterface : GxGenericCollectionItem<SdtSDT_DebugResults_Summary>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DebugResults_Summary_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DebugResults_Summary_RESTInterface( SdtSDT_DebugResults_Summary psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TotalUrls", Order=0)]
		public short gxTpr_Totalurls
		{
			get { 
				return sdt.gxTpr_Totalurls;

			}
			set { 
				sdt.gxTpr_Totalurls = value;
			}
		}

		[DataMember(Name="SuccessCount", Order=1)]
		public short gxTpr_Successcount
		{
			get { 
				return sdt.gxTpr_Successcount;

			}
			set { 
				sdt.gxTpr_Successcount = value;
			}
		}

		[DataMember(Name="FailureCount", Order=2)]
		public short gxTpr_Failurecount
		{
			get { 
				return sdt.gxTpr_Failurecount;

			}
			set { 
				sdt.gxTpr_Failurecount = value;
			}
		}


		#endregion

		public SdtSDT_DebugResults_Summary sdt
		{
			get { 
				return (SdtSDT_DebugResults_Summary)Sdt;
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
				sdt = new SdtSDT_DebugResults_Summary() ;
			}
		}
	}
	#endregion
}