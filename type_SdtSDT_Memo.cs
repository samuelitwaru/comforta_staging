/*
				   File: type_SdtSDT_Memo
			Description: SDT_Memo
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
	[XmlRoot(ElementName="SDT_Memo")]
	[XmlType(TypeName="SDT_Memo" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Memo : GxUserType
	{
		public SdtSDT_Memo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Memo_Memocategoryname = "";

			gxTv_SdtSDT_Memo_Memotitle = "";

			gxTv_SdtSDT_Memo_Memodescription = "";

			gxTv_SdtSDT_Memo_Memoimage = "";

			gxTv_SdtSDT_Memo_Memodocument = "";

			gxTv_SdtSDT_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_Memo_Residentsalutation = "";

			gxTv_SdtSDT_Memo_Residentgivenname = "";

			gxTv_SdtSDT_Memo_Residentlastname = "";

			gxTv_SdtSDT_Memo_Residentguid = "";

			gxTv_SdtSDT_Memo_Memobgcolorcode = "";

			gxTv_SdtSDT_Memo_Memoform = "";

		}

		public SdtSDT_Memo(IGxContext context)
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
			AddObjectProperty("MemoId", gxTpr_Memoid, false);


			AddObjectProperty("BulletinBoardId", gxTpr_Bulletinboardid, false);


			AddObjectProperty("MemoCategoryId", gxTpr_Memocategoryid, false);


			AddObjectProperty("MemoCategoryName", gxTpr_Memocategoryname, false);


			AddObjectProperty("MemoTitle", gxTpr_Memotitle, false);


			AddObjectProperty("MemoDescription", gxTpr_Memodescription, false);


			AddObjectProperty("MemoImage", gxTpr_Memoimage, false);


			AddObjectProperty("MemoDocument", gxTpr_Memodocument, false);


			datetime_STZ = gxTpr_Memostartdatetime;
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
			AddObjectProperty("MemoStartDateTime", sDateCnv, false);



			datetime_STZ = gxTpr_Memoenddatetime;
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
			AddObjectProperty("MemoEndDateTime", sDateCnv, false);



			AddObjectProperty("MemoDuration", gxTpr_Memoduration, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MemoRemoveDate", sDateCnv, false);



			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("ResidentSalutation", gxTpr_Residentsalutation, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentGUID", gxTpr_Residentguid, false);


			AddObjectProperty("MemoBgColorCode", gxTpr_Memobgcolorcode, false);


			AddObjectProperty("MemoForm", gxTpr_Memoform, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MemoId")]
		[XmlElement(ElementName="MemoId")]
		public Guid gxTpr_Memoid
		{
			get {
				return gxTv_SdtSDT_Memo_Memoid; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoid = value;
				SetDirty("Memoid");
			}
		}




		[SoapElement(ElementName="BulletinBoardId")]
		[XmlElement(ElementName="BulletinBoardId")]
		public Guid gxTpr_Bulletinboardid
		{
			get {
				return gxTv_SdtSDT_Memo_Bulletinboardid; 
			}
			set {
				gxTv_SdtSDT_Memo_Bulletinboardid = value;
				SetDirty("Bulletinboardid");
			}
		}




		[SoapElement(ElementName="MemoCategoryId")]
		[XmlElement(ElementName="MemoCategoryId")]
		public Guid gxTpr_Memocategoryid
		{
			get {
				return gxTv_SdtSDT_Memo_Memocategoryid; 
			}
			set {
				gxTv_SdtSDT_Memo_Memocategoryid = value;
				SetDirty("Memocategoryid");
			}
		}




		[SoapElement(ElementName="MemoCategoryName")]
		[XmlElement(ElementName="MemoCategoryName")]
		public string gxTpr_Memocategoryname
		{
			get {
				return gxTv_SdtSDT_Memo_Memocategoryname; 
			}
			set {
				gxTv_SdtSDT_Memo_Memocategoryname = value;
				SetDirty("Memocategoryname");
			}
		}




		[SoapElement(ElementName="MemoTitle")]
		[XmlElement(ElementName="MemoTitle")]
		public string gxTpr_Memotitle
		{
			get {
				return gxTv_SdtSDT_Memo_Memotitle; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotitle = value;
				SetDirty("Memotitle");
			}
		}




		[SoapElement(ElementName="MemoDescription")]
		[XmlElement(ElementName="MemoDescription")]
		public string gxTpr_Memodescription
		{
			get {
				return gxTv_SdtSDT_Memo_Memodescription; 
			}
			set {
				gxTv_SdtSDT_Memo_Memodescription = value;
				SetDirty("Memodescription");
			}
		}




		[SoapElement(ElementName="MemoImage")]
		[XmlElement(ElementName="MemoImage")]
		public string gxTpr_Memoimage
		{
			get {
				return gxTv_SdtSDT_Memo_Memoimage; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoimage = value;
				SetDirty("Memoimage");
			}
		}




		[SoapElement(ElementName="MemoDocument")]
		[XmlElement(ElementName="MemoDocument")]
		public string gxTpr_Memodocument
		{
			get {
				return gxTv_SdtSDT_Memo_Memodocument; 
			}
			set {
				gxTv_SdtSDT_Memo_Memodocument = value;
				SetDirty("Memodocument");
			}
		}



		[SoapElement(ElementName="MemoStartDateTime")]
		[XmlElement(ElementName="MemoStartDateTime" , IsNullable=true)]
		public string gxTpr_Memostartdatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memostartdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_Memo_Memostartdatetime).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memostartdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memostartdatetime
		{
			get {
				return gxTv_SdtSDT_Memo_Memostartdatetime; 
			}
			set {
				gxTv_SdtSDT_Memo_Memostartdatetime = value;
				SetDirty("Memostartdatetime");
			}
		}


		[SoapElement(ElementName="MemoEndDateTime")]
		[XmlElement(ElementName="MemoEndDateTime" , IsNullable=true)]
		public string gxTpr_Memoenddatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memoenddatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_Memo_Memoenddatetime).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memoenddatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memoenddatetime
		{
			get {
				return gxTv_SdtSDT_Memo_Memoenddatetime; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoenddatetime = value;
				SetDirty("Memoenddatetime");
			}
		}



		[SoapElement(ElementName="MemoDuration")]
		[XmlElement(ElementName="MemoDuration")]
		public short gxTpr_Memoduration
		{
			get {
				return gxTv_SdtSDT_Memo_Memoduration; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoduration = value;
				SetDirty("Memoduration");
			}
		}



		[SoapElement(ElementName="MemoRemoveDate")]
		[XmlElement(ElementName="MemoRemoveDate" , IsNullable=true)]
		public string gxTpr_Memoremovedate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memoremovedate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_Memo_Memoremovedate).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memoremovedate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memoremovedate
		{
			get {
				return gxTv_SdtSDT_Memo_Memoremovedate; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoremovedate = value;
				SetDirty("Memoremovedate");
			}
		}



		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtSDT_Memo_Residentid; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="ResidentSalutation")]
		[XmlElement(ElementName="ResidentSalutation")]
		public string gxTpr_Residentsalutation
		{
			get {
				return gxTv_SdtSDT_Memo_Residentsalutation; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentsalutation = value;
				SetDirty("Residentsalutation");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtSDT_Memo_Residentgivenname; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtSDT_Memo_Residentlastname; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentGUID")]
		[XmlElement(ElementName="ResidentGUID")]
		public string gxTpr_Residentguid
		{
			get {
				return gxTv_SdtSDT_Memo_Residentguid; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentguid = value;
				SetDirty("Residentguid");
			}
		}




		[SoapElement(ElementName="MemoBgColorCode")]
		[XmlElement(ElementName="MemoBgColorCode")]
		public string gxTpr_Memobgcolorcode
		{
			get {
				return gxTv_SdtSDT_Memo_Memobgcolorcode; 
			}
			set {
				gxTv_SdtSDT_Memo_Memobgcolorcode = value;
				SetDirty("Memobgcolorcode");
			}
		}




		[SoapElement(ElementName="MemoForm")]
		[XmlElement(ElementName="MemoForm")]
		public string gxTpr_Memoform
		{
			get {
				return gxTv_SdtSDT_Memo_Memoform; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoform = value;
				SetDirty("Memoform");
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
			gxTv_SdtSDT_Memo_Memocategoryname = "";
			gxTv_SdtSDT_Memo_Memotitle = "";
			gxTv_SdtSDT_Memo_Memodescription = "";
			gxTv_SdtSDT_Memo_Memoimage = "";
			gxTv_SdtSDT_Memo_Memodocument = "";
			gxTv_SdtSDT_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);



			gxTv_SdtSDT_Memo_Residentsalutation = "";
			gxTv_SdtSDT_Memo_Residentgivenname = "";
			gxTv_SdtSDT_Memo_Residentlastname = "";
			gxTv_SdtSDT_Memo_Residentguid = "";
			gxTv_SdtSDT_Memo_Memobgcolorcode = "";
			gxTv_SdtSDT_Memo_Memoform = "";
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

		protected Guid gxTv_SdtSDT_Memo_Memoid;
		 

		protected Guid gxTv_SdtSDT_Memo_Bulletinboardid;
		 

		protected Guid gxTv_SdtSDT_Memo_Memocategoryid;
		 

		protected string gxTv_SdtSDT_Memo_Memocategoryname;
		 

		protected string gxTv_SdtSDT_Memo_Memotitle;
		 

		protected string gxTv_SdtSDT_Memo_Memodescription;
		 

		protected string gxTv_SdtSDT_Memo_Memoimage;
		 

		protected string gxTv_SdtSDT_Memo_Memodocument;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memostartdatetime;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memoenddatetime;
		 

		protected short gxTv_SdtSDT_Memo_Memoduration;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memoremovedate;
		 

		protected Guid gxTv_SdtSDT_Memo_Residentid;
		 

		protected string gxTv_SdtSDT_Memo_Residentsalutation;
		 

		protected string gxTv_SdtSDT_Memo_Residentgivenname;
		 

		protected string gxTv_SdtSDT_Memo_Residentlastname;
		 

		protected string gxTv_SdtSDT_Memo_Residentguid;
		 

		protected string gxTv_SdtSDT_Memo_Memobgcolorcode;
		 

		protected string gxTv_SdtSDT_Memo_Memoform;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Memo", Namespace="Comforta_version2")]
	public class SdtSDT_Memo_RESTInterface : GxGenericCollectionItem<SdtSDT_Memo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Memo_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Memo_RESTInterface( SdtSDT_Memo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MemoId", Order=0)]
		public Guid gxTpr_Memoid
		{
			get { 
				return sdt.gxTpr_Memoid;

			}
			set { 
				sdt.gxTpr_Memoid = value;
			}
		}

		[DataMember(Name="BulletinBoardId", Order=1)]
		public Guid gxTpr_Bulletinboardid
		{
			get { 
				return sdt.gxTpr_Bulletinboardid;

			}
			set { 
				sdt.gxTpr_Bulletinboardid = value;
			}
		}

		[DataMember(Name="MemoCategoryId", Order=2)]
		public Guid gxTpr_Memocategoryid
		{
			get { 
				return sdt.gxTpr_Memocategoryid;

			}
			set { 
				sdt.gxTpr_Memocategoryid = value;
			}
		}

		[DataMember(Name="MemoCategoryName", Order=3)]
		public  string gxTpr_Memocategoryname
		{
			get { 
				return sdt.gxTpr_Memocategoryname;

			}
			set { 
				 sdt.gxTpr_Memocategoryname = value;
			}
		}

		[DataMember(Name="MemoTitle", Order=4)]
		public  string gxTpr_Memotitle
		{
			get { 
				return sdt.gxTpr_Memotitle;

			}
			set { 
				 sdt.gxTpr_Memotitle = value;
			}
		}

		[DataMember(Name="MemoDescription", Order=5)]
		public  string gxTpr_Memodescription
		{
			get { 
				return sdt.gxTpr_Memodescription;

			}
			set { 
				 sdt.gxTpr_Memodescription = value;
			}
		}

		[DataMember(Name="MemoImage", Order=6)]
		public  string gxTpr_Memoimage
		{
			get { 
				return sdt.gxTpr_Memoimage;

			}
			set { 
				 sdt.gxTpr_Memoimage = value;
			}
		}

		[DataMember(Name="MemoDocument", Order=7)]
		public  string gxTpr_Memodocument
		{
			get { 
				return sdt.gxTpr_Memodocument;

			}
			set { 
				 sdt.gxTpr_Memodocument = value;
			}
		}

		[DataMember(Name="MemoStartDateTime", Order=8)]
		public  string gxTpr_Memostartdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Memostartdatetime,context);

			}
			set { 
				sdt.gxTpr_Memostartdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="MemoEndDateTime", Order=9)]
		public  string gxTpr_Memoenddatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Memoenddatetime,context);

			}
			set { 
				sdt.gxTpr_Memoenddatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="MemoDuration", Order=10)]
		public short gxTpr_Memoduration
		{
			get { 
				return sdt.gxTpr_Memoduration;

			}
			set { 
				sdt.gxTpr_Memoduration = value;
			}
		}

		[DataMember(Name="MemoRemoveDate", Order=11)]
		public  string gxTpr_Memoremovedate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Memoremovedate);

			}
			set { 
				sdt.gxTpr_Memoremovedate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ResidentId", Order=12)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="ResidentSalutation", Order=13)]
		public  string gxTpr_Residentsalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentsalutation);

			}
			set { 
				 sdt.gxTpr_Residentsalutation = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=14)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=15)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentGUID", Order=16)]
		public  string gxTpr_Residentguid
		{
			get { 
				return sdt.gxTpr_Residentguid;

			}
			set { 
				 sdt.gxTpr_Residentguid = value;
			}
		}

		[DataMember(Name="MemoBgColorCode", Order=17)]
		public  string gxTpr_Memobgcolorcode
		{
			get { 
				return sdt.gxTpr_Memobgcolorcode;

			}
			set { 
				 sdt.gxTpr_Memobgcolorcode = value;
			}
		}

		[DataMember(Name="MemoForm", Order=18)]
		public  string gxTpr_Memoform
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Memoform);

			}
			set { 
				 sdt.gxTpr_Memoform = value;
			}
		}


		#endregion

		public SdtSDT_Memo sdt
		{
			get { 
				return (SdtSDT_Memo)Sdt;
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
				sdt = new SdtSDT_Memo() ;
			}
		}
	}
	#endregion
}