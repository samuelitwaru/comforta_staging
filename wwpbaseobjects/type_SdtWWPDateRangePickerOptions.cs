/*
				   File: type_SdtWWPDateRangePickerOptions
			Description: WWPDateRangePickerOptions
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions")]
	[XmlType(TypeName="WWPDateRangePickerOptions" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions : GxUserType
	{
		public SdtWWPDateRangePickerOptions( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPDateRangePickerOptions_Pickertype = "";

			gxTv_SdtWWPDateRangePickerOptions_Mindate = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWPDateRangePickerOptions_Maxdate = (DateTime)(DateTime.MinValue);

		}

		public SdtWWPDateRangePickerOptions(IGxContext context)
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
			AddObjectProperty("PickerType", gxTpr_Pickertype, false);


			if (ShouldSerializegxTpr_Mindate_Json())
			{	
				datetime_STZ = gxTpr_Mindate;
				sDateCnv = "";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "T";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				AddObjectProperty("MinDate", sDateCnv, false);

			}


			if (ShouldSerializegxTpr_Maxdate_Json())
			{	
				datetime_STZ = gxTpr_Maxdate;
				sDateCnv = "";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "T";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				AddObjectProperty("MaxDate", sDateCnv, false);

			}

			if (gxTv_SdtWWPDateRangePickerOptions_Locale != null)
			{
				AddObjectProperty("Locale", gxTv_SdtWWPDateRangePickerOptions_Locale, false);
			}
			if (gxTv_SdtWWPDateRangePickerOptions_Datepicker != null)
			{
				AddObjectProperty("DatePicker", gxTv_SdtWWPDateRangePickerOptions_Datepicker, false);
			}
			if (gxTv_SdtWWPDateRangePickerOptions_Timepicker != null)
			{
				AddObjectProperty("TimePicker", gxTv_SdtWWPDateRangePickerOptions_Timepicker, false);
			}
			if (gxTv_SdtWWPDateRangePickerOptions_Ranges != null)
			{
				AddObjectProperty("Ranges", gxTv_SdtWWPDateRangePickerOptions_Ranges, false);
			}

			AddObjectProperty("ShowCustomRangeLabel", gxTpr_Showcustomrangelabel, false);

			if (gxTv_SdtWWPDateRangePickerOptions_Advanced != null)
			{
				AddObjectProperty("Advanced", gxTv_SdtWWPDateRangePickerOptions_Advanced, false);
			}
			if (gxTv_SdtWWPDateRangePickerOptions_Formatteddays != null)
			{
				AddObjectProperty("FormattedDays", gxTv_SdtWWPDateRangePickerOptions_Formatteddays, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PickerType")]
		[XmlElement(ElementName="PickerType")]
		public string gxTpr_Pickertype
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Pickertype; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Pickertype = value;
				SetDirty("Pickertype");
			}
		}



		[SoapElement(ElementName="MinDate")]
		[XmlElement(ElementName="MinDate" , IsNullable=true)]
		public string gxTpr_Mindate_Nullable
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Mindate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPDateRangePickerOptions_Mindate).value ;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Mindate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Mindate
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Mindate; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Mindate_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Mindate = value;
				SetDirty("Mindate");
			}
		}

		public bool ShouldSerializegxTpr_Mindate_Json()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Mindate != DateTime.MinValue;

		}

		[SoapElement(ElementName="MaxDate")]
		[XmlElement(ElementName="MaxDate" , IsNullable=true)]
		public string gxTpr_Maxdate_Nullable
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Maxdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPDateRangePickerOptions_Maxdate).value ;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Maxdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Maxdate
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Maxdate; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Maxdate_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Maxdate = value;
				SetDirty("Maxdate");
			}
		}

		public bool ShouldSerializegxTpr_Maxdate_Json()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Maxdate != DateTime.MinValue;

		}

		[SoapElement(ElementName="Locale" )]
		[XmlElement(ElementName="Locale" )]
		public SdtWWPDateRangePickerOptions_Locale gxTpr_Locale
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Locale == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Locale = new SdtWWPDateRangePickerOptions_Locale(context);
				}
				gxTv_SdtWWPDateRangePickerOptions_Locale_N = false;
				return gxTv_SdtWWPDateRangePickerOptions_Locale;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Locale_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Locale = value;
				SetDirty("Locale");
			}

		}

		public void gxTv_SdtWWPDateRangePickerOptions_Locale_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Locale_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Locale = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Locale_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Locale == null;
		}
		public bool ShouldSerializegxTpr_Locale_Json()
		{
				return (gxTv_SdtWWPDateRangePickerOptions_Locale != null && gxTv_SdtWWPDateRangePickerOptions_Locale.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="DatePicker" )]
		[XmlElement(ElementName="DatePicker" )]
		public SdtWWPDateRangePickerOptions_DatePicker gxTpr_Datepicker
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Datepicker == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Datepicker = new SdtWWPDateRangePickerOptions_DatePicker(context);
				}
				gxTv_SdtWWPDateRangePickerOptions_Datepicker_N = false;
				return gxTv_SdtWWPDateRangePickerOptions_Datepicker;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Datepicker_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Datepicker = value;
				SetDirty("Datepicker");
			}

		}

		public void gxTv_SdtWWPDateRangePickerOptions_Datepicker_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Datepicker_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Datepicker = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Datepicker_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Datepicker == null;
		}
		public bool ShouldSerializegxTpr_Datepicker_Json()
		{
				return (gxTv_SdtWWPDateRangePickerOptions_Datepicker != null && gxTv_SdtWWPDateRangePickerOptions_Datepicker.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="TimePicker" )]
		[XmlElement(ElementName="TimePicker" )]
		public SdtWWPDateRangePickerOptions_TimePicker gxTpr_Timepicker
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Timepicker == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Timepicker = new SdtWWPDateRangePickerOptions_TimePicker(context);
				}
				gxTv_SdtWWPDateRangePickerOptions_Timepicker_N = false;
				return gxTv_SdtWWPDateRangePickerOptions_Timepicker;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Timepicker_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Timepicker = value;
				SetDirty("Timepicker");
			}

		}

		public void gxTv_SdtWWPDateRangePickerOptions_Timepicker_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Timepicker_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Timepicker = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Timepicker_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Timepicker == null;
		}
		public bool ShouldSerializegxTpr_Timepicker_Json()
		{
				return (gxTv_SdtWWPDateRangePickerOptions_Timepicker != null && gxTv_SdtWWPDateRangePickerOptions_Timepicker.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Ranges" )]
		[XmlArray(ElementName="Ranges"  )]
		[XmlArrayItemAttribute(ElementName="RangesItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWPDateRangePickerOptions_RangesItem> gxTpr_Ranges
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Ranges == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Ranges = new GXBaseCollection<SdtWWPDateRangePickerOptions_RangesItem>( context, "WWPDateRangePickerOptions.RangesItem", "");
				}
				return gxTv_SdtWWPDateRangePickerOptions_Ranges;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Ranges_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Ranges = value;
				SetDirty("Ranges");
			}
		}

		public void gxTv_SdtWWPDateRangePickerOptions_Ranges_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Ranges_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Ranges = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Ranges_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Ranges == null;
		}
		public bool ShouldSerializegxTpr_Ranges_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Ranges != null && gxTv_SdtWWPDateRangePickerOptions_Ranges.Count > 0;

		}



		[SoapElement(ElementName="ShowCustomRangeLabel")]
		[XmlElement(ElementName="ShowCustomRangeLabel")]
		public bool gxTpr_Showcustomrangelabel
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_Showcustomrangelabel; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Showcustomrangelabel = value;
				SetDirty("Showcustomrangelabel");
			}
		}



		[SoapElement(ElementName="Advanced" )]
		[XmlElement(ElementName="Advanced" )]
		public SdtWWPDateRangePickerOptions_Advanced gxTpr_Advanced
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Advanced == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Advanced = new SdtWWPDateRangePickerOptions_Advanced(context);
				}
				gxTv_SdtWWPDateRangePickerOptions_Advanced_N = false;
				return gxTv_SdtWWPDateRangePickerOptions_Advanced;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Advanced_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Advanced = value;
				SetDirty("Advanced");
			}

		}

		public void gxTv_SdtWWPDateRangePickerOptions_Advanced_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Advanced_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Advanced = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Advanced_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Advanced == null;
		}
		public bool ShouldSerializegxTpr_Advanced_Json()
		{
				return (gxTv_SdtWWPDateRangePickerOptions_Advanced != null && gxTv_SdtWWPDateRangePickerOptions_Advanced.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="FormattedDays" )]
		[XmlArray(ElementName="FormattedDays"  )]
		[XmlArrayItemAttribute(ElementName="FormattedDaysItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWPDateRangePickerOptions_FormattedDaysItem> gxTpr_Formatteddays
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_Formatteddays == null )
				{
					gxTv_SdtWWPDateRangePickerOptions_Formatteddays = new GXBaseCollection<SdtWWPDateRangePickerOptions_FormattedDaysItem>( context, "WWPDateRangePickerOptions.FormattedDaysItem", "");
				}
				return gxTv_SdtWWPDateRangePickerOptions_Formatteddays;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_Formatteddays_N = false;
				gxTv_SdtWWPDateRangePickerOptions_Formatteddays = value;
				SetDirty("Formatteddays");
			}
		}

		public void gxTv_SdtWWPDateRangePickerOptions_Formatteddays_SetNull()
		{
			gxTv_SdtWWPDateRangePickerOptions_Formatteddays_N = true;
			gxTv_SdtWWPDateRangePickerOptions_Formatteddays = null;
		}

		public bool gxTv_SdtWWPDateRangePickerOptions_Formatteddays_IsNull()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Formatteddays == null;
		}
		public bool ShouldSerializegxTpr_Formatteddays_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWPDateRangePickerOptions_Formatteddays != null && gxTv_SdtWWPDateRangePickerOptions_Formatteddays.Count > 0;

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
			gxTv_SdtWWPDateRangePickerOptions_Pickertype = "";
			gxTv_SdtWWPDateRangePickerOptions_Mindate = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWPDateRangePickerOptions_Mindate_N = true;

			gxTv_SdtWWPDateRangePickerOptions_Maxdate = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWPDateRangePickerOptions_Maxdate_N = true;


			gxTv_SdtWWPDateRangePickerOptions_Locale_N = true;


			gxTv_SdtWWPDateRangePickerOptions_Datepicker_N = true;


			gxTv_SdtWWPDateRangePickerOptions_Timepicker_N = true;


			gxTv_SdtWWPDateRangePickerOptions_Ranges_N = true;

			gxTv_SdtWWPDateRangePickerOptions_Showcustomrangelabel = true;

			gxTv_SdtWWPDateRangePickerOptions_Advanced_N = true;


			gxTv_SdtWWPDateRangePickerOptions_Formatteddays_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtWWPDateRangePickerOptions_Pickertype;
		 

		protected DateTime gxTv_SdtWWPDateRangePickerOptions_Mindate;
		protected bool gxTv_SdtWWPDateRangePickerOptions_Mindate_N;
		 

		protected DateTime gxTv_SdtWWPDateRangePickerOptions_Maxdate;
		protected bool gxTv_SdtWWPDateRangePickerOptions_Maxdate_N;
		 
		protected bool gxTv_SdtWWPDateRangePickerOptions_Locale_N;
		protected SdtWWPDateRangePickerOptions_Locale gxTv_SdtWWPDateRangePickerOptions_Locale = null; 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Datepicker_N;
		protected SdtWWPDateRangePickerOptions_DatePicker gxTv_SdtWWPDateRangePickerOptions_Datepicker = null; 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Timepicker_N;
		protected SdtWWPDateRangePickerOptions_TimePicker gxTv_SdtWWPDateRangePickerOptions_Timepicker = null; 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Ranges_N;
		protected GXBaseCollection<SdtWWPDateRangePickerOptions_RangesItem> gxTv_SdtWWPDateRangePickerOptions_Ranges = null; 


		protected bool gxTv_SdtWWPDateRangePickerOptions_Showcustomrangelabel;
		 
		protected bool gxTv_SdtWWPDateRangePickerOptions_Advanced_N;
		protected SdtWWPDateRangePickerOptions_Advanced gxTv_SdtWWPDateRangePickerOptions_Advanced = null; 

		protected bool gxTv_SdtWWPDateRangePickerOptions_Formatteddays_N;
		protected GXBaseCollection<SdtWWPDateRangePickerOptions_FormattedDaysItem> gxTv_SdtWWPDateRangePickerOptions_Formatteddays = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPDateRangePickerOptions", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_RESTInterface( SdtWWPDateRangePickerOptions psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PickerType", Order=0)]
		public  string gxTpr_Pickertype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pickertype);

			}
			set { 
				 sdt.gxTpr_Pickertype = value;
			}
		}

		[DataMember(Name="MinDate", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Mindate
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Mindate_Json())
					return DateTimeUtil.TToC2( sdt.gxTpr_Mindate,context);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Mindate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="MaxDate", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Maxdate
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Maxdate_Json())
					return DateTimeUtil.TToC2( sdt.gxTpr_Maxdate,context);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Maxdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="Locale", Order=3, EmitDefaultValue=false)]
		public SdtWWPDateRangePickerOptions_Locale_RESTInterface gxTpr_Locale
		{
			get {
				if (sdt.ShouldSerializegxTpr_Locale_Json())
					return new SdtWWPDateRangePickerOptions_Locale_RESTInterface(sdt.gxTpr_Locale);
				else
					return null;

			}

			set {
				sdt.gxTpr_Locale = value.sdt;
			}

		}

		[DataMember(Name="DatePicker", Order=4, EmitDefaultValue=false)]
		public SdtWWPDateRangePickerOptions_DatePicker_RESTInterface gxTpr_Datepicker
		{
			get {
				if (sdt.ShouldSerializegxTpr_Datepicker_Json())
					return new SdtWWPDateRangePickerOptions_DatePicker_RESTInterface(sdt.gxTpr_Datepicker);
				else
					return null;

			}

			set {
				sdt.gxTpr_Datepicker = value.sdt;
			}

		}

		[DataMember(Name="TimePicker", Order=5, EmitDefaultValue=false)]
		public SdtWWPDateRangePickerOptions_TimePicker_RESTInterface gxTpr_Timepicker
		{
			get {
				if (sdt.ShouldSerializegxTpr_Timepicker_Json())
					return new SdtWWPDateRangePickerOptions_TimePicker_RESTInterface(sdt.gxTpr_Timepicker);
				else
					return null;

			}

			set {
				sdt.gxTpr_Timepicker = value.sdt;
			}

		}

		[DataMember(Name="Ranges", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPDateRangePickerOptions_RangesItem_RESTInterface> gxTpr_Ranges
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ranges_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPDateRangePickerOptions_RangesItem_RESTInterface>(sdt.gxTpr_Ranges);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Ranges);
			}
		}

		[DataMember(Name="ShowCustomRangeLabel", Order=7)]
		public bool gxTpr_Showcustomrangelabel
		{
			get { 
				return sdt.gxTpr_Showcustomrangelabel;

			}
			set { 
				sdt.gxTpr_Showcustomrangelabel = value;
			}
		}

		[DataMember(Name="Advanced", Order=8, EmitDefaultValue=false)]
		public SdtWWPDateRangePickerOptions_Advanced_RESTInterface gxTpr_Advanced
		{
			get {
				if (sdt.ShouldSerializegxTpr_Advanced_Json())
					return new SdtWWPDateRangePickerOptions_Advanced_RESTInterface(sdt.gxTpr_Advanced);
				else
					return null;

			}

			set {
				sdt.gxTpr_Advanced = value.sdt;
			}

		}

		[DataMember(Name="FormattedDays", Order=9, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPDateRangePickerOptions_FormattedDaysItem_RESTInterface> gxTpr_Formatteddays
		{
			get {
				if (sdt.ShouldSerializegxTpr_Formatteddays_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPDateRangePickerOptions_FormattedDaysItem_RESTInterface>(sdt.gxTpr_Formatteddays);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Formatteddays);
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions() ;
			}
		}
	}
	#endregion
}