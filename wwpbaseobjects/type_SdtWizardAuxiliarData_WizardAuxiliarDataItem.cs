/*
				   File: type_SdtWizardAuxiliarData_WizardAuxiliarDataItem
			Description: WizardAuxiliarData
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
	[XmlRoot(ElementName="WizardAuxiliarDataItem")]
	[XmlType(TypeName="WizardAuxiliarDataItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWizardAuxiliarData_WizardAuxiliarDataItem : GxUserType
	{
		public SdtWizardAuxiliarData_WizardAuxiliarDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Key = "";

			gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Value = "";

		}

		public SdtWizardAuxiliarData_WizardAuxiliarDataItem(IGxContext context)
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
			AddObjectProperty("Key", gxTpr_Key, false);


			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Key")]
		[XmlElement(ElementName="Key")]
		public string gxTpr_Key
		{
			get {
				return gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Key; 
			}
			set {
				gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Key = value;
				SetDirty("Key");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Value; 
			}
			set {
				gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Value = value;
				SetDirty("Value");
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
			gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Key = "";
			gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Key;
		 

		protected string gxTv_SdtWizardAuxiliarData_WizardAuxiliarDataItem_Value;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WizardAuxiliarDataItem", Namespace="Comforta_version2")]
	public class SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface : GxGenericCollectionItem<SdtWizardAuxiliarData_WizardAuxiliarDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface( SdtWizardAuxiliarData_WizardAuxiliarDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Key", Order=0)]
		public  string gxTpr_Key
		{
			get { 
				return sdt.gxTpr_Key;

			}
			set { 
				 sdt.gxTpr_Key = value;
			}
		}

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}


		#endregion

		public SdtWizardAuxiliarData_WizardAuxiliarDataItem sdt
		{
			get { 
				return (SdtWizardAuxiliarData_WizardAuxiliarDataItem)Sdt;
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
				sdt = new SdtWizardAuxiliarData_WizardAuxiliarDataItem() ;
			}
		}
	}
	#endregion
}