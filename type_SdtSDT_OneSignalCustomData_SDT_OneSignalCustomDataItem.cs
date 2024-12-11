/*
				   File: type_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem
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
	[XmlRoot(ElementName="SDT_OneSignalCustomDataItem")]
	[XmlType(TypeName="SDT_OneSignalCustomDataItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem : GxUserType
	{
		public SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Key = "";

			gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Value = "";

		}

		public SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(IGxContext context)
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
				return gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Key; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Key = value;
				SetDirty("Key");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Value; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Value = value;
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
			gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Key = "";
			gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Key;
		 

		protected string gxTv_SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_Value;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_OneSignalCustomDataItem", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_RESTInterface( SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem psdt ) : base(psdt)
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

		public SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem() ;
			}
		}
	}
	#endregion
}