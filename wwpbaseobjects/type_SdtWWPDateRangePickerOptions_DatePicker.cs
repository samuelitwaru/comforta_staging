/*
				   File: type_SdtWWPDateRangePickerOptions_DatePicker
			Description: DatePicker
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.DatePicker")]
	[XmlType(TypeName="WWPDateRangePickerOptions.DatePicker" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_DatePicker : GxUserType
	{
		public SdtWWPDateRangePickerOptions_DatePicker( )
		{
			/* Constructor for serialization */
		}

		public SdtWWPDateRangePickerOptions_DatePicker(IGxContext context)
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


			AddObjectProperty("ShowDropdowns", gxTpr_Showdropdowns, false);


			if (ShouldSerializegxTpr_Minyear_Json())
			{	
				AddObjectProperty("MinYear", gxTpr_Minyear, false);
			}


			if (ShouldSerializegxTpr_Maxyear_Json())
			{	
				AddObjectProperty("MaxYear", gxTpr_Maxyear, false);
			}


			AddObjectProperty("ShowWeekNumbers", gxTpr_Showweeknumbers, false);


			if (ShouldSerializegxTpr_Linkedcalendars_Json())
			{	
				AddObjectProperty("LinkedCalendars", gxTpr_Linkedcalendars, false);
			}

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Show")]
		[XmlElement(ElementName="Show")]
		public bool gxTpr_Show
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Show; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Show = value;
				SetDirty("Show");
			}
		}




		[SoapElement(ElementName="ShowDropdowns")]
		[XmlElement(ElementName="ShowDropdowns")]
		public bool gxTpr_Showdropdowns
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showdropdowns; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showdropdowns = value;
				SetDirty("Showdropdowns");
			}
		}




		[SoapElement(ElementName="MinYear")]
		[XmlElement(ElementName="MinYear")]
		public int gxTpr_Minyear
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear_N = false;
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear = value;
				SetDirty("Minyear");
			}
		}

		public bool ShouldSerializegxTpr_Minyear_Json()
		{
			return !gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear_N;

		}



		[SoapElement(ElementName="MaxYear")]
		[XmlElement(ElementName="MaxYear")]
		public int gxTpr_Maxyear
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear_N = false;
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear = value;
				SetDirty("Maxyear");
			}
		}

		public bool ShouldSerializegxTpr_Maxyear_Json()
		{
			return !gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear_N;

		}



		[SoapElement(ElementName="ShowWeekNumbers")]
		[XmlElement(ElementName="ShowWeekNumbers")]
		public bool gxTpr_Showweeknumbers
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showweeknumbers; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showweeknumbers = value;
				SetDirty("Showweeknumbers");
			}
		}




		[SoapElement(ElementName="LinkedCalendars")]
		[XmlElement(ElementName="LinkedCalendars")]
		public bool gxTpr_Linkedcalendars
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars_N = false;
				gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars = value;
				SetDirty("Linkedcalendars");
			}
		}

		public bool ShouldSerializegxTpr_Linkedcalendars_Json()
		{
			return !gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars_N;

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
			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Show = true;
			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showdropdowns = true;

			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear_N = true;


			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear_N = true;


			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars = true;
			gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Show;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showdropdowns;
		 

		protected int gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear;
		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Minyear_N;
		 

		protected int gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear;
		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Maxyear_N;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Showweeknumbers;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars;
		protected bool gxTv_SdtWWPDateRangePickerOptions_DatePicker_Linkedcalendars_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPDateRangePickerOptions.DatePicker", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_DatePicker_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_DatePicker>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_DatePicker_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_DatePicker_RESTInterface( SdtWWPDateRangePickerOptions_DatePicker psdt ) : base(psdt)
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

		[DataMember(Name="ShowDropdowns", Order=1)]
		public bool gxTpr_Showdropdowns
		{
			get { 
				return sdt.gxTpr_Showdropdowns;

			}
			set { 
				sdt.gxTpr_Showdropdowns = value;
			}
		}

		[DataMember(Name="MinYear", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Minyear
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Minyear_Json())
					return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Minyear, 8, 0));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Minyear = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MaxYear", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Maxyear
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Maxyear_Json())
					return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Maxyear, 8, 0));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Maxyear = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ShowWeekNumbers", Order=4)]
		public bool gxTpr_Showweeknumbers
		{
			get { 
				return sdt.gxTpr_Showweeknumbers;

			}
			set { 
				sdt.gxTpr_Showweeknumbers = value;
			}
		}

		[DataMember(Name="LinkedCalendars", Order=5, EmitDefaultValue=false)]
		public  Nullable<bool> gxTpr_Linkedcalendars
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Linkedcalendars_Json())
					return sdt.gxTpr_Linkedcalendars;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Linkedcalendars = (bool) (value.HasValue ? value.Value : false);
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_DatePicker sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_DatePicker)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_DatePicker() ;
			}
		}
	}
	#endregion
}