/*
				   File: type_SdtSDT_OneSignalCustomBody_data
			Description: data
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
	[XmlRoot(ElementName="SDT_OneSignalCustomBody.data")]
	[XmlType(TypeName="SDT_OneSignalCustomBody.data" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomBody_data : GxUserType
	{
		public SdtSDT_OneSignalCustomBody_data( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_OneSignalCustomBody_data(IGxContext context)
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
			if (gxTv_SdtSDT_OneSignalCustomBody_data_Items != null)
			{
				AddObjectProperty("items", gxTv_SdtSDT_OneSignalCustomBody_data_Items, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="items" )]
		[XmlArray(ElementName="items"  )]
		[XmlArrayItemAttribute(ElementName="SDT_OneSignalCustomDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem> gxTpr_Items_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_data_Items == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_data_Items = new GXBaseCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem>( context, "SDT_OneSignalCustomData", "");
				}
				return gxTv_SdtSDT_OneSignalCustomBody_data_Items;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_data_Items_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_data_Items = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem> gxTpr_Items
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_data_Items == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_data_Items = new GXBaseCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem>( context, "SDT_OneSignalCustomData", "");
				}
				gxTv_SdtSDT_OneSignalCustomBody_data_Items_N = false;
				return gxTv_SdtSDT_OneSignalCustomBody_data_Items ;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_data_Items_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_data_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtSDT_OneSignalCustomBody_data_Items_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomBody_data_Items_N = true;
			gxTv_SdtSDT_OneSignalCustomBody_data_Items = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomBody_data_Items_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_data_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_data_Items != null && gxTv_SdtSDT_OneSignalCustomBody_data_Items.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Items_GXBaseCollection_Json()||  
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
			gxTv_SdtSDT_OneSignalCustomBody_data_Items_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_OneSignalCustomBody_data_Items_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem> gxTv_SdtSDT_OneSignalCustomBody_data_Items = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomBody.data", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomBody_data_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomBody_data>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomBody_data_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomBody_data_RESTInterface( SdtSDT_OneSignalCustomBody_data psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="items", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_RESTInterface> gxTpr_Items
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Items_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomBody_data sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomBody_data)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomBody_data() ;
			}
		}
	}
	#endregion
}