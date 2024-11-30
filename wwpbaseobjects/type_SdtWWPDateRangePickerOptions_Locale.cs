/*
				   File: type_SdtWWPDateRangePickerOptions_Locale
			Description: Locale
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.Locale")]
	[XmlType(TypeName="WWPDateRangePickerOptions.Locale" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_Locale : GxUserType
	{
		public SdtWWPDateRangePickerOptions_Locale( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPDateRangePickerOptions_Locale_Id = "";

			gxTv_SdtWWPDateRangePickerOptions_Locale_Format = "";

		}

		public SdtWWPDateRangePickerOptions_Locale(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Format", gxTpr_Format, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Locale_Id; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Locale_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Format")]
		[XmlElement(ElementName="Format")]
		public string gxTpr_Format
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Locale_Format; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Locale_Format = value;
				SetDirty("Format");
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
			gxTv_SdtWWPDateRangePickerOptions_Locale_Id = "";
			gxTv_SdtWWPDateRangePickerOptions_Locale_Format = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPDateRangePickerOptions_Locale_Id;
		 

		protected string gxTv_SdtWWPDateRangePickerOptions_Locale_Format;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPDateRangePickerOptions.Locale", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_Locale_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_Locale>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_Locale_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_Locale_RESTInterface( SdtWWPDateRangePickerOptions_Locale psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Format", Order=1)]
		public  string gxTpr_Format
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Format);

			}
			set { 
				 sdt.gxTpr_Format = value;
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_Locale sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_Locale)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_Locale() ;
			}
		}
	}
	#endregion
}