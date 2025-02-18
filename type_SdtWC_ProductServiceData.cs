/*
				   File: type_SdtWC_ProductServiceData
			Description: WC_ProductServiceData
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
	[XmlRoot(ElementName="WC_ProductServiceData")]
	[XmlType(TypeName="WC_ProductServiceData" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWC_ProductServiceData : GxUserType
	{
		public SdtWC_ProductServiceData( )
		{
			/* Constructor for serialization */
		}

		public SdtWC_ProductServiceData(IGxContext context)
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
			if (gxTv_SdtWC_ProductServiceData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWC_ProductServiceData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWC_ProductServiceData_Auxiliardata == null )
				{
					gxTv_SdtWC_ProductServiceData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWC_ProductServiceData_Auxiliardata;
			}
			set {
				gxTv_SdtWC_ProductServiceData_Auxiliardata_N = false;
				gxTv_SdtWC_ProductServiceData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWC_ProductServiceData_Auxiliardata == null )
				{
					gxTv_SdtWC_ProductServiceData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWC_ProductServiceData_Auxiliardata_N = false;
				return gxTv_SdtWC_ProductServiceData_Auxiliardata ;
			}
			set {
				gxTv_SdtWC_ProductServiceData_Auxiliardata_N = false;
				gxTv_SdtWC_ProductServiceData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWC_ProductServiceData_Auxiliardata_SetNull()
		{
			gxTv_SdtWC_ProductServiceData_Auxiliardata_N = true;
			gxTv_SdtWC_ProductServiceData_Auxiliardata = null;
		}

		public bool gxTv_SdtWC_ProductServiceData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWC_ProductServiceData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWC_ProductServiceData_Auxiliardata != null && gxTv_SdtWC_ProductServiceData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
				false);
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
			gxTv_SdtWC_ProductServiceData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWC_ProductServiceData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWC_ProductServiceData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WC_ProductServiceData", Namespace="Comforta_version2")]
	public class SdtWC_ProductServiceData_RESTInterface : GxGenericCollectionItem<SdtWC_ProductServiceData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWC_ProductServiceData_RESTInterface( ) : base()
		{	
		}

		public SdtWC_ProductServiceData_RESTInterface( SdtWC_ProductServiceData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AuxiliarData", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion

		public SdtWC_ProductServiceData sdt
		{
			get { 
				return (SdtWC_ProductServiceData)Sdt;
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
				sdt = new SdtWC_ProductServiceData() ;
			}
		}
	}
	#endregion
}