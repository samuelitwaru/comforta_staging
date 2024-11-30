/*
				   File: type_SdtWWPDateRangePickerOptions_RangesItem
			Description: Ranges
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.RangesItem")]
	[XmlType(TypeName="WWPDateRangePickerOptions.RangesItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_RangesItem : GxUserType
	{
		public SdtWWPDateRangePickerOptions_RangesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Displayname = "";

			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate = (DateTime)(DateTime.MinValue);

		}

		public SdtWWPDateRangePickerOptions_RangesItem(IGxContext context)
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
			AddObjectProperty("DisplayName", gxTpr_Displayname, false);


			datetime_STZ = gxTpr_Startdate;
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
			AddObjectProperty("StartDate", sDateCnv, false);



			datetime_STZ = gxTpr_Enddate;
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
			AddObjectProperty("EndDate", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DisplayName")]
		[XmlElement(ElementName="DisplayName")]
		public string gxTpr_Displayname
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_RangesItem_Displayname; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_RangesItem_Displayname = value;
				SetDirty("Displayname");
			}
		}



		[SoapElement(ElementName="StartDate")]
		[XmlElement(ElementName="StartDate" , IsNullable=true)]
		public string gxTpr_Startdate_Nullable
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate).value ;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Startdate
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate = value;
				SetDirty("Startdate");
			}
		}


		[SoapElement(ElementName="EndDate")]
		[XmlElement(ElementName="EndDate" , IsNullable=true)]
		public string gxTpr_Enddate_Nullable
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate).value ;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Enddate
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate = value;
				SetDirty("Enddate");
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
			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Displayname = "";
			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate = (DateTime)(DateTime.MinValue);
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

		protected string gxTv_SdtWWPDateRangePickerOptions_RangesItem_Displayname;
		 

		protected DateTime gxTv_SdtWWPDateRangePickerOptions_RangesItem_Startdate;
		 

		protected DateTime gxTv_SdtWWPDateRangePickerOptions_RangesItem_Enddate;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWPDateRangePickerOptions.RangesItem", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_RangesItem_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_RangesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_RangesItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_RangesItem_RESTInterface( SdtWWPDateRangePickerOptions_RangesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DisplayName", Order=0)]
		public  string gxTpr_Displayname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Displayname);

			}
			set { 
				 sdt.gxTpr_Displayname = value;
			}
		}

		[DataMember(Name="StartDate", Order=1)]
		public  string gxTpr_Startdate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Startdate,context);

			}
			set { 
				sdt.gxTpr_Startdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="EndDate", Order=2)]
		public  string gxTpr_Enddate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Enddate,context);

			}
			set { 
				sdt.gxTpr_Enddate = DateTimeUtil.CToT2(value,context);
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_RangesItem sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_RangesItem)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_RangesItem() ;
			}
		}
	}
	#endregion
}