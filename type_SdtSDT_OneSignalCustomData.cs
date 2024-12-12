/*
				   File: type_SdtSDT_OneSignalCustomData
			Description: SDT_OneSignalCustomData
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData")]
	[XmlType(TypeName="SDT_OneSignalCustomData" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData : GxUserType
	{
		public SdtSDT_OneSignalCustomData( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_OneSignalCustomData(IGxContext context)
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
			AddObjectProperty("isDiscussion", gxTpr_Isdiscussion, false);


			AddObjectProperty("isDynamicForm", gxTpr_Isdynamicform, false);


			AddObjectProperty("isAgendaEvent", gxTpr_Isagendaevent, false);


			AddObjectProperty("isGeneralCommunication", gxTpr_Isgeneralcommunication, false);

			if (gxTv_SdtSDT_OneSignalCustomData_Formdetails != null)
			{
				AddObjectProperty("formDetails", gxTv_SdtSDT_OneSignalCustomData_Formdetails, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomData_Discussiondetails != null)
			{
				AddObjectProperty("discussionDetails", gxTv_SdtSDT_OneSignalCustomData_Discussiondetails, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomData_Agendadetails != null)
			{
				AddObjectProperty("agendaDetails", gxTv_SdtSDT_OneSignalCustomData_Agendadetails, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="isDiscussion")]
		[XmlElement(ElementName="isDiscussion")]
		public bool gxTpr_Isdiscussion
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_Isdiscussion; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Isdiscussion = value;
				SetDirty("Isdiscussion");
			}
		}




		[SoapElement(ElementName="isDynamicForm")]
		[XmlElement(ElementName="isDynamicForm")]
		public bool gxTpr_Isdynamicform
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_Isdynamicform; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Isdynamicform = value;
				SetDirty("Isdynamicform");
			}
		}




		[SoapElement(ElementName="isAgendaEvent")]
		[XmlElement(ElementName="isAgendaEvent")]
		public bool gxTpr_Isagendaevent
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_Isagendaevent; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Isagendaevent = value;
				SetDirty("Isagendaevent");
			}
		}




		[SoapElement(ElementName="isGeneralCommunication")]
		[XmlElement(ElementName="isGeneralCommunication")]
		public bool gxTpr_Isgeneralcommunication
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_Isgeneralcommunication; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Isgeneralcommunication = value;
				SetDirty("Isgeneralcommunication");
			}
		}



		[SoapElement(ElementName="formDetails" )]
		[XmlElement(ElementName="formDetails" )]
		public SdtSDT_OneSignalCustomData_formDetails gxTpr_Formdetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Formdetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Formdetails = new SdtSDT_OneSignalCustomData_formDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Formdetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Formdetails = value;
				SetDirty("Formdetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Formdetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Formdetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Formdetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Formdetails == null;
		}
		public bool ShouldSerializegxTpr_Formdetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Formdetails != null && gxTv_SdtSDT_OneSignalCustomData_Formdetails.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="discussionDetails" )]
		[XmlElement(ElementName="discussionDetails" )]
		public SdtSDT_OneSignalCustomData_discussionDetails gxTpr_Discussiondetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Discussiondetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = new SdtSDT_OneSignalCustomData_discussionDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Discussiondetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = value;
				SetDirty("Discussiondetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Discussiondetails == null;
		}
		public bool ShouldSerializegxTpr_Discussiondetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Discussiondetails != null && gxTv_SdtSDT_OneSignalCustomData_Discussiondetails.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="agendaDetails" )]
		[XmlElement(ElementName="agendaDetails" )]
		public SdtSDT_OneSignalCustomData_agendaDetails gxTpr_Agendadetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Agendadetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Agendadetails = new SdtSDT_OneSignalCustomData_agendaDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Agendadetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails = value;
				SetDirty("Agendadetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Agendadetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Agendadetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Agendadetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Agendadetails == null;
		}
		public bool ShouldSerializegxTpr_Agendadetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Agendadetails != null && gxTv_SdtSDT_OneSignalCustomData_Agendadetails.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = true;


			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = true;


			gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_OneSignalCustomData_Isdiscussion;
		 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Isdynamicform;
		 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Isagendaevent;
		 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Isgeneralcommunication;
		 
		protected bool gxTv_SdtSDT_OneSignalCustomData_Formdetails_N;
		protected SdtSDT_OneSignalCustomData_formDetails gxTv_SdtSDT_OneSignalCustomData_Formdetails = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N;
		protected SdtSDT_OneSignalCustomData_discussionDetails gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N;
		protected SdtSDT_OneSignalCustomData_agendaDetails gxTv_SdtSDT_OneSignalCustomData_Agendadetails = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomData_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_RESTInterface( SdtSDT_OneSignalCustomData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="isDiscussion", Order=0)]
		public bool gxTpr_Isdiscussion
		{
			get { 
				return sdt.gxTpr_Isdiscussion;

			}
			set { 
				sdt.gxTpr_Isdiscussion = value;
			}
		}

		[DataMember(Name="isDynamicForm", Order=1)]
		public bool gxTpr_Isdynamicform
		{
			get { 
				return sdt.gxTpr_Isdynamicform;

			}
			set { 
				sdt.gxTpr_Isdynamicform = value;
			}
		}

		[DataMember(Name="isAgendaEvent", Order=2)]
		public bool gxTpr_Isagendaevent
		{
			get { 
				return sdt.gxTpr_Isagendaevent;

			}
			set { 
				sdt.gxTpr_Isagendaevent = value;
			}
		}

		[DataMember(Name="isGeneralCommunication", Order=3)]
		public bool gxTpr_Isgeneralcommunication
		{
			get { 
				return sdt.gxTpr_Isgeneralcommunication;

			}
			set { 
				sdt.gxTpr_Isgeneralcommunication = value;
			}
		}

		[DataMember(Name="formDetails", Order=4, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_formDetails_RESTInterface gxTpr_Formdetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Formdetails_Json())
					return new SdtSDT_OneSignalCustomData_formDetails_RESTInterface(sdt.gxTpr_Formdetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Formdetails = value.sdt;
			}

		}

		[DataMember(Name="discussionDetails", Order=5, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface gxTpr_Discussiondetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Discussiondetails_Json())
					return new SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface(sdt.gxTpr_Discussiondetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Discussiondetails = value.sdt;
			}

		}

		[DataMember(Name="agendaDetails", Order=6, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface gxTpr_Agendadetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Agendadetails_Json())
					return new SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface(sdt.gxTpr_Agendadetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Agendadetails = value.sdt;
			}

		}


		#endregion

		public SdtSDT_OneSignalCustomData sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData() ;
			}
		}
	}
	#endregion
}