/*
				   File: type_SdtWWPDateRangePickerOptions_FormattedDaysItem
			Description: FormattedDays
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
	[XmlRoot(ElementName="WWPDateRangePickerOptions.FormattedDaysItem")]
	[XmlType(TypeName="WWPDateRangePickerOptions.FormattedDaysItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPDateRangePickerOptions_FormattedDaysItem : GxUserType
	{
		public SdtWWPDateRangePickerOptions_FormattedDaysItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Class = "";

			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Tooltip = "";

		}

		public SdtWWPDateRangePickerOptions_FormattedDaysItem(IGxContext context)
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
			datetime_STZ = gxTpr_Date;
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
			AddObjectProperty("Date", sDateCnv, false);



			AddObjectProperty("Disabled", gxTpr_Disabled, false);


			AddObjectProperty("Class", gxTpr_Class, false);


			AddObjectProperty("Tooltip", gxTpr_Tooltip, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Date")]
		[XmlElement(ElementName="Date" , IsNullable=true)]
		public string gxTpr_Date_Nullable
		{
			get {
				if ( gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date).value ;
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Date
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date = value;
				SetDirty("Date");
			}
		}



		[SoapElement(ElementName="Disabled")]
		[XmlElement(ElementName="Disabled")]
		public bool gxTpr_Disabled
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Disabled; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Disabled = value;
				SetDirty("Disabled");
			}
		}




		[SoapElement(ElementName="Class")]
		[XmlElement(ElementName="Class")]
		public string gxTpr_Class
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Class; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Class = value;
				SetDirty("Class");
			}
		}




		[SoapElement(ElementName="Tooltip")]
		[XmlElement(ElementName="Tooltip")]
		public string gxTpr_Tooltip
		{
			get {
				return gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Tooltip; 
			}
			set {
				gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Tooltip = value;
				SetDirty("Tooltip");
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
			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Class = "";
			gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Tooltip = "";
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

		protected DateTime gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Date;
		 

		protected bool gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Disabled;
		 

		protected string gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Class;
		 

		protected string gxTv_SdtWWPDateRangePickerOptions_FormattedDaysItem_Tooltip;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWPDateRangePickerOptions.FormattedDaysItem", Namespace="Comforta_version2")]
	public class SdtWWPDateRangePickerOptions_FormattedDaysItem_RESTInterface : GxGenericCollectionItem<SdtWWPDateRangePickerOptions_FormattedDaysItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPDateRangePickerOptions_FormattedDaysItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWPDateRangePickerOptions_FormattedDaysItem_RESTInterface( SdtWWPDateRangePickerOptions_FormattedDaysItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Date", Order=0)]
		public  string gxTpr_Date
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Date,context);

			}
			set { 
				sdt.gxTpr_Date = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="Disabled", Order=1)]
		public bool gxTpr_Disabled
		{
			get { 
				return sdt.gxTpr_Disabled;

			}
			set { 
				sdt.gxTpr_Disabled = value;
			}
		}

		[DataMember(Name="Class", Order=2)]
		public  string gxTpr_Class
		{
			get { 
				return sdt.gxTpr_Class;

			}
			set { 
				 sdt.gxTpr_Class = value;
			}
		}

		[DataMember(Name="Tooltip", Order=3)]
		public  string gxTpr_Tooltip
		{
			get { 
				return sdt.gxTpr_Tooltip;

			}
			set { 
				 sdt.gxTpr_Tooltip = value;
			}
		}


		#endregion

		public SdtWWPDateRangePickerOptions_FormattedDaysItem sdt
		{
			get { 
				return (SdtWWPDateRangePickerOptions_FormattedDaysItem)Sdt;
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
				sdt = new SdtWWPDateRangePickerOptions_FormattedDaysItem() ;
			}
		}
	}
	#endregion
}