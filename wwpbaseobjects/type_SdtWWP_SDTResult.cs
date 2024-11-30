/*
				   File: type_SdtWWP_SDTResult
			Description: WWP_SDTResult
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="WWP_SDTResult")]
	[XmlType(TypeName="WWP_SDTResult" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWP_SDTResult : GxUserType
	{
		public SdtWWP_SDTResult( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SDTResult_Result = "";

		}

		public SdtWWP_SDTResult(IGxContext context)
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
			AddObjectProperty("Result", gxTpr_Result, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Result")]
		[XmlElement(ElementName="Result")]
		public string gxTpr_Result
		{
			get {
				return gxTv_SdtWWP_SDTResult_Result; 
			}
			set {
				gxTv_SdtWWP_SDTResult_Result = value;
				SetDirty("Result");
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
			gxTv_SdtWWP_SDTResult_Result = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_SDTResult_Result;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_SDTResult", Namespace="Comforta_version2")]
	public class SdtWWP_SDTResult_RESTInterface : GxGenericCollectionItem<SdtWWP_SDTResult>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SDTResult_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_SDTResult_RESTInterface( SdtWWP_SDTResult psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Result", Order=0)]
		public  string gxTpr_Result
		{
			get { 
				return sdt.gxTpr_Result;

			}
			set { 
				 sdt.gxTpr_Result = value;
			}
		}


		#endregion

		public SdtWWP_SDTResult sdt
		{
			get { 
				return (SdtWWP_SDTResult)Sdt;
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
				sdt = new SdtWWP_SDTResult() ;
			}
		}
	}
	#endregion
}