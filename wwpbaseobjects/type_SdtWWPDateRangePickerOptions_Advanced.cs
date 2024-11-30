/*
				   File: type_SdtWWPDateRangePickerOptions_Advanced
			Description: Advanced
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.Advanced")]
	[XmlType(TypeName="WWPDateRangePickerOptions.Advanced" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_Advanced : GxUserType
	{
		public SdtWWPDateRangePickerOptions_Advanced( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation = "";

		}

		public SdtWWPDateRangePickerOptions_Advanced(IGxContext context)
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
			if (ShouldSerializegxTpr_Openlocation_Json())
			{	
				AddObjectProperty("OpenLocation", gxTpr_Openlocation, false);
			}


			AddObjectProperty("AutoApply", gxTpr_Autoapply, false);


			AddObjectProperty("AutoUpdateInput", gxTpr_Autoupdateinput, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OpenLocation")]
		[XmlElement(ElementName="OpenLocation")]
		public string gxTpr_Openlocation
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation = value;
				SetDirty("Openlocation");
			}
		}

		public bool ShouldSerializegxTpr_Openlocation_Json()
		{
			return !gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation_N && !String.IsNullOrEmpty(gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation);
				

		}



		[SoapElement(ElementName="AutoApply")]
		[XmlElement(ElementName="AutoApply")]
		public bool gxTpr_Autoapply
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoapply; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoapply = value;
				SetDirty("Autoapply");
			}
		}




		[SoapElement(ElementName="AutoUpdateInput")]
		[XmlElement(ElementName="AutoUpdateInput")]
		public bool gxTpr_Autoupdateinput
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoupdateinput; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoupdateinput = value;
				SetDirty("Autoupdateinput");
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
			gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation = "";
			gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation_N = true;

			gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoapply = true;
			gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoupdateinput = true;
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation;
		protected bool gxTv_SdtWWPDateRangePickerOptions_Advanced_Openlocation_N;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoapply;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Advanced_Autoupdateinput;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPDateRangePickerOptions.Advanced", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_Advanced_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_Advanced>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_Advanced_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_Advanced_RESTInterface( SdtWWPDateRangePickerOptions_Advanced psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OpenLocation", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Openlocation
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Openlocation_Json())
					return StringUtil.RTrim( sdt.gxTpr_Openlocation);
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Openlocation = value;
			}
		}

		[DataMember(Name="AutoApply", Order=1)]
		public bool gxTpr_Autoapply
		{
			get { 
				return sdt.gxTpr_Autoapply;

			}
			set { 
				sdt.gxTpr_Autoapply = value;
			}
		}

		[DataMember(Name="AutoUpdateInput", Order=2)]
		public bool gxTpr_Autoupdateinput
		{
			get { 
				return sdt.gxTpr_Autoupdateinput;

			}
			set { 
				sdt.gxTpr_Autoupdateinput = value;
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_Advanced sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_Advanced)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_Advanced() ;
			}
		}
	}
	#endregion
}