/*
				   File: type_SdtWWPDateRangePickerOptions_TimePicker
			Description: TimePicker
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.TimePicker")]
	[XmlType(TypeName="WWPDateRangePickerOptions.TimePicker" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_TimePicker : GxUserType
	{
		public SdtWWPDateRangePickerOptions_TimePicker( )
		{
			/* Constructor for serialization */
		}

		public SdtWWPDateRangePickerOptions_TimePicker(IGxContext context)
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
			AddObjectProperty("Show", gxTpr_Show, false);


			if (ShouldSerializegxTpr_Increment_Json())
			{	
				AddObjectProperty("Increment", gxTpr_Increment, false);
			}


			AddObjectProperty("Hour24", gxTpr_Hour24, false);


			AddObjectProperty("ShowSeconds", gxTpr_Showseconds, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Show")]
		[XmlElement(ElementName="Show")]
		public bool gxTpr_Show
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_TimePicker_Show; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_TimePicker_Show = value;
				SetDirty("Show");
			}
		}




		[SoapElement(ElementName="Increment")]
		[XmlElement(ElementName="Increment")]
		public int gxTpr_Increment
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment_N = false;
				gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment = value;
				SetDirty("Increment");
			}
		}

		public bool ShouldSerializegxTpr_Increment_Json()
		{
			return !gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment_N;

		}



		[SoapElement(ElementName="Hour24")]
		[XmlElement(ElementName="Hour24")]
		public bool gxTpr_Hour24
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_TimePicker_Hour24; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_TimePicker_Hour24 = value;
				SetDirty("Hour24");
			}
		}




		[SoapElement(ElementName="ShowSeconds")]
		[XmlElement(ElementName="ShowSeconds")]
		public bool gxTpr_Showseconds
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_TimePicker_Showseconds; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_TimePicker_Showseconds = value;
				SetDirty("Showseconds");
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
			gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment = 10;
			gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment_N = true;

			gxTv_SdtWWPDateRangePickerOptions_TimePicker_Hour24 = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWWPDateRangePickerOptions_TimePicker_Show;
		 

		protected int gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment;
		protected bool gxTv_SdtWWPDateRangePickerOptions_TimePicker_Increment_N;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_TimePicker_Hour24;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_TimePicker_Showseconds;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPDateRangePickerOptions.TimePicker", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_TimePicker_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_TimePicker>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_TimePicker_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_TimePicker_RESTInterface( SdtWWPDateRangePickerOptions_TimePicker psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Show", Order=0)]
		public bool gxTpr_Show
		{
			get { 
				return sdt.gxTpr_Show;

			}
			set { 
				sdt.gxTpr_Show = value;
			}
		}

		[DataMember(Name="Increment", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Increment
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Increment_Json())
					return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Increment, 8, 0));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Increment = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Hour24", Order=2)]
		public bool gxTpr_Hour24
		{
			get { 
				return sdt.gxTpr_Hour24;

			}
			set { 
				sdt.gxTpr_Hour24 = value;
			}
		}

		[DataMember(Name="ShowSeconds", Order=3)]
		public bool gxTpr_Showseconds
		{
			get { 
				return sdt.gxTpr_Showseconds;

			}
			set { 
				sdt.gxTpr_Showseconds = value;
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_TimePicker sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_TimePicker)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_TimePicker() ;
			}
		}
	}
	#endregion
}