/*
				   File: type_SdtWWP_Calendar_Events_Item
			Description: WWP_Calendar_Events
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
namespace GeneXus.Programs.workwithplus
{
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWP_Calendar_Events_Item : GxUserType
	{
		public SdtWWP_Calendar_Events_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_Calendar_Events_Item_Id = "";

			gxTv_SdtWWP_Calendar_Events_Item_Start = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_Calendar_Events_Item_End = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_Calendar_Events_Item_Title = "";

			gxTv_SdtWWP_Calendar_Events_Item_Type = "";

			gxTv_SdtWWP_Calendar_Events_Item_Recurringtype = "";

			gxTv_SdtWWP_Calendar_Events_Item_Classname = "";

			gxTv_SdtWWP_Calendar_Events_Item_Backgroundcolor = "";

			gxTv_SdtWWP_Calendar_Events_Item_Bordercolor = "";

			gxTv_SdtWWP_Calendar_Events_Item_Textcolor = "";

			gxTv_SdtWWP_Calendar_Events_Item_Display = "";

			gxTv_SdtWWP_Calendar_Events_Item_Url = "";

		}

		public SdtWWP_Calendar_Events_Item(IGxContext context)
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
				mapper["id"] = "Id";
				mapper["allDay"] = "Allday";
				mapper["start"] = "Start";
				mapper["end"] = "End";
				mapper["title"] = "Title";
				mapper["editable"] = "Editable";
				mapper["overlap"] = "Overlap";
				mapper["className"] = "Classname";
				mapper["backgroundColor"] = "Backgroundcolor";
				mapper["borderColor"] = "Bordercolor";
				mapper["textColor"] = "Textcolor";
				mapper["display"] = "Display";
				mapper["url"] = "Url";

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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("allDay", gxTpr_Allday, false);


			datetime_STZ = gxTpr_Start;
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
			AddObjectProperty("start", sDateCnv, false);



			datetime_STZ = gxTpr_End;
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
			AddObjectProperty("end", sDateCnv, false);



			AddObjectProperty("title", gxTpr_Title, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Recurring", gxTpr_Recurring, false);


			AddObjectProperty("RecurringType", gxTpr_Recurringtype, false);


			AddObjectProperty("AddRSVP", gxTpr_Addrsvp, false);


			AddObjectProperty("editable", gxTpr_Editable, false);


			AddObjectProperty("overlap", gxTpr_Overlap, false);


			AddObjectProperty("className", gxTpr_Classname, false);


			AddObjectProperty("backgroundColor", gxTpr_Backgroundcolor, false);


			AddObjectProperty("borderColor", gxTpr_Bordercolor, false);


			AddObjectProperty("textColor", gxTpr_Textcolor, false);


			AddObjectProperty("display", gxTpr_Display, false);


			AddObjectProperty("url", gxTpr_Url, false);

			if (gxTv_SdtWWP_Calendar_Events_Item_Actions != null)
			{
				AddObjectProperty("Actions", gxTv_SdtWWP_Calendar_Events_Item_Actions, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Id; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="AllDay")]
		[XmlElement(ElementName="AllDay")]
		public bool gxTpr_Allday
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Allday; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Allday = value;
				SetDirty("Allday");
			}
		}



		[SoapElement(ElementName="Start")]
		[XmlElement(ElementName="Start" , IsNullable=true)]
		public string gxTpr_Start_Nullable
		{
			get {
				if ( gxTv_SdtWWP_Calendar_Events_Item_Start == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_Calendar_Events_Item_Start).value ;
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Start = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Start
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Start; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Start = value;
				SetDirty("Start");
			}
		}


		[SoapElement(ElementName="End")]
		[XmlElement(ElementName="End" , IsNullable=true)]
		public string gxTpr_End_Nullable
		{
			get {
				if ( gxTv_SdtWWP_Calendar_Events_Item_End == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_Calendar_Events_Item_End).value ;
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_End = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_End
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_End; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_End = value;
				SetDirty("End");
			}
		}



		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Title; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Type; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Recurring")]
		[XmlElement(ElementName="Recurring")]
		public bool gxTpr_Recurring
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Recurring; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Recurring = value;
				SetDirty("Recurring");
			}
		}




		[SoapElement(ElementName="RecurringType")]
		[XmlElement(ElementName="RecurringType")]
		public string gxTpr_Recurringtype
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Recurringtype; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Recurringtype = value;
				SetDirty("Recurringtype");
			}
		}




		[SoapElement(ElementName="AddRSVP")]
		[XmlElement(ElementName="AddRSVP")]
		public bool gxTpr_Addrsvp
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Addrsvp; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Addrsvp = value;
				SetDirty("Addrsvp");
			}
		}




		[SoapElement(ElementName="Editable")]
		[XmlElement(ElementName="Editable")]
		public bool gxTpr_Editable
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Editable; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Editable = value;
				SetDirty("Editable");
			}
		}




		[SoapElement(ElementName="Overlap")]
		[XmlElement(ElementName="Overlap")]
		public bool gxTpr_Overlap
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Overlap; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Overlap = value;
				SetDirty("Overlap");
			}
		}




		[SoapElement(ElementName="ClassName")]
		[XmlElement(ElementName="ClassName")]
		public string gxTpr_Classname
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Classname; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Classname = value;
				SetDirty("Classname");
			}
		}




		[SoapElement(ElementName="BackgroundColor")]
		[XmlElement(ElementName="BackgroundColor")]
		public string gxTpr_Backgroundcolor
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Backgroundcolor; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Backgroundcolor = value;
				SetDirty("Backgroundcolor");
			}
		}




		[SoapElement(ElementName="BorderColor")]
		[XmlElement(ElementName="BorderColor")]
		public string gxTpr_Bordercolor
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Bordercolor; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Bordercolor = value;
				SetDirty("Bordercolor");
			}
		}




		[SoapElement(ElementName="TextColor")]
		[XmlElement(ElementName="TextColor")]
		public string gxTpr_Textcolor
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Textcolor; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Textcolor = value;
				SetDirty("Textcolor");
			}
		}




		[SoapElement(ElementName="Display")]
		[XmlElement(ElementName="Display")]
		public string gxTpr_Display
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Display; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Display = value;
				SetDirty("Display");
			}
		}




		[SoapElement(ElementName="Url")]
		[XmlElement(ElementName="Url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_Url; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Url = value;
				SetDirty("Url");
			}
		}




		[SoapElement(ElementName="Actions" )]
		[XmlArray(ElementName="Actions"  )]
		[XmlArrayItemAttribute(ElementName="ActionsItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_Calendar_Events_Item_ActionsItem> gxTpr_Actions
		{
			get {
				if ( gxTv_SdtWWP_Calendar_Events_Item_Actions == null )
				{
					gxTv_SdtWWP_Calendar_Events_Item_Actions = new GXBaseCollection<SdtWWP_Calendar_Events_Item_ActionsItem>( context, "WWP_Calendar_Events.Item.ActionsItem", "");
				}
				return gxTv_SdtWWP_Calendar_Events_Item_Actions;
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_Actions_N = false;
				gxTv_SdtWWP_Calendar_Events_Item_Actions = value;
				SetDirty("Actions");
			}
		}

		public void gxTv_SdtWWP_Calendar_Events_Item_Actions_SetNull()
		{
			gxTv_SdtWWP_Calendar_Events_Item_Actions_N = true;
			gxTv_SdtWWP_Calendar_Events_Item_Actions = null;
		}

		public bool gxTv_SdtWWP_Calendar_Events_Item_Actions_IsNull()
		{
			return gxTv_SdtWWP_Calendar_Events_Item_Actions == null;
		}
		public bool ShouldSerializegxTpr_Actions_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_Calendar_Events_Item_Actions != null && gxTv_SdtWWP_Calendar_Events_Item_Actions.Count > 0;

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
			gxTv_SdtWWP_Calendar_Events_Item_Id = "";

			gxTv_SdtWWP_Calendar_Events_Item_Start = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWP_Calendar_Events_Item_End = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWP_Calendar_Events_Item_Title = "";
			gxTv_SdtWWP_Calendar_Events_Item_Type = "";

			gxTv_SdtWWP_Calendar_Events_Item_Recurringtype = "";

			gxTv_SdtWWP_Calendar_Events_Item_Editable = true;
			gxTv_SdtWWP_Calendar_Events_Item_Overlap = true;
			gxTv_SdtWWP_Calendar_Events_Item_Classname = "";
			gxTv_SdtWWP_Calendar_Events_Item_Backgroundcolor = "";
			gxTv_SdtWWP_Calendar_Events_Item_Bordercolor = "";
			gxTv_SdtWWP_Calendar_Events_Item_Textcolor = "";
			gxTv_SdtWWP_Calendar_Events_Item_Display = "";
			gxTv_SdtWWP_Calendar_Events_Item_Url = "";

			gxTv_SdtWWP_Calendar_Events_Item_Actions_N = true;

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

		protected string gxTv_SdtWWP_Calendar_Events_Item_Id;
		 

		protected bool gxTv_SdtWWP_Calendar_Events_Item_Allday;
		 

		protected DateTime gxTv_SdtWWP_Calendar_Events_Item_Start;
		 

		protected DateTime gxTv_SdtWWP_Calendar_Events_Item_End;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Title;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Type;
		 

		protected bool gxTv_SdtWWP_Calendar_Events_Item_Recurring;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Recurringtype;
		 

		protected bool gxTv_SdtWWP_Calendar_Events_Item_Addrsvp;
		 

		protected bool gxTv_SdtWWP_Calendar_Events_Item_Editable;
		 

		protected bool gxTv_SdtWWP_Calendar_Events_Item_Overlap;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Classname;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Backgroundcolor;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Bordercolor;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Textcolor;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Display;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_Url;
		 
		protected bool gxTv_SdtWWP_Calendar_Events_Item_Actions_N;
		protected GXBaseCollection<SdtWWP_Calendar_Events_Item_ActionsItem> gxTv_SdtWWP_Calendar_Events_Item_Actions = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="Comforta_version2")]
	public class SdtWWP_Calendar_Events_Item_RESTInterface : GxGenericCollectionItem<SdtWWP_Calendar_Events_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_Calendar_Events_Item_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_Calendar_Events_Item_RESTInterface( SdtWWP_Calendar_Events_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="allDay", Order=1)]
		public bool gxTpr_Allday
		{
			get { 
				return sdt.gxTpr_Allday;

			}
			set { 
				sdt.gxTpr_Allday = value;
			}
		}

		[DataMember(Name="start", Order=2)]
		public  string gxTpr_Start
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Start,context);

			}
			set { 
				sdt.gxTpr_Start = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="end", Order=3)]
		public  string gxTpr_End
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_End,context);

			}
			set { 
				sdt.gxTpr_End = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="title", Order=4)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Type", Order=5)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Recurring", Order=6)]
		public bool gxTpr_Recurring
		{
			get { 
				return sdt.gxTpr_Recurring;

			}
			set { 
				sdt.gxTpr_Recurring = value;
			}
		}

		[DataMember(Name="RecurringType", Order=7)]
		public  string gxTpr_Recurringtype
		{
			get { 
				return sdt.gxTpr_Recurringtype;

			}
			set { 
				 sdt.gxTpr_Recurringtype = value;
			}
		}

		[DataMember(Name="AddRSVP", Order=8)]
		public bool gxTpr_Addrsvp
		{
			get { 
				return sdt.gxTpr_Addrsvp;

			}
			set { 
				sdt.gxTpr_Addrsvp = value;
			}
		}

		[DataMember(Name="editable", Order=9)]
		public bool gxTpr_Editable
		{
			get { 
				return sdt.gxTpr_Editable;

			}
			set { 
				sdt.gxTpr_Editable = value;
			}
		}

		[DataMember(Name="overlap", Order=10)]
		public bool gxTpr_Overlap
		{
			get { 
				return sdt.gxTpr_Overlap;

			}
			set { 
				sdt.gxTpr_Overlap = value;
			}
		}

		[DataMember(Name="className", Order=11)]
		public  string gxTpr_Classname
		{
			get { 
				return sdt.gxTpr_Classname;

			}
			set { 
				 sdt.gxTpr_Classname = value;
			}
		}

		[DataMember(Name="backgroundColor", Order=12)]
		public  string gxTpr_Backgroundcolor
		{
			get { 
				return sdt.gxTpr_Backgroundcolor;

			}
			set { 
				 sdt.gxTpr_Backgroundcolor = value;
			}
		}

		[DataMember(Name="borderColor", Order=13)]
		public  string gxTpr_Bordercolor
		{
			get { 
				return sdt.gxTpr_Bordercolor;

			}
			set { 
				 sdt.gxTpr_Bordercolor = value;
			}
		}

		[DataMember(Name="textColor", Order=14)]
		public  string gxTpr_Textcolor
		{
			get { 
				return sdt.gxTpr_Textcolor;

			}
			set { 
				 sdt.gxTpr_Textcolor = value;
			}
		}

		[DataMember(Name="display", Order=15)]
		public  string gxTpr_Display
		{
			get { 
				return sdt.gxTpr_Display;

			}
			set { 
				 sdt.gxTpr_Display = value;
			}
		}

		[DataMember(Name="url", Order=16)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}

		[DataMember(Name="Actions", Order=17, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_Calendar_Events_Item_ActionsItem_RESTInterface> gxTpr_Actions
		{
			get {
				if (sdt.ShouldSerializegxTpr_Actions_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_Calendar_Events_Item_ActionsItem_RESTInterface>(sdt.gxTpr_Actions);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Actions);
			}
		}


		#endregion

		public SdtWWP_Calendar_Events_Item sdt
		{
			get { 
				return (SdtWWP_Calendar_Events_Item)Sdt;
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
				sdt = new SdtWWP_Calendar_Events_Item() ;
			}
		}
	}
	#endregion
}