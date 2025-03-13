/*
				   File: type_SdtSDT_MenuPage_Content
			Description: Content
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
	[XmlRoot(ElementName="SDT_MenuPage.Content")]
	[XmlType(TypeName="SDT_MenuPage.Content" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_MenuPage_Content : GxUserType
	{
		public SdtSDT_MenuPage_Content( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_MenuPage_Content(IGxContext context)
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
			if (gxTv_SdtSDT_MenuPage_Content_Rows != null)
			{
				AddObjectProperty("Rows", gxTv_SdtSDT_MenuPage_Content_Rows, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Rows" )]
		[XmlArray(ElementName="Rows"  )]
		[XmlArrayItemAttribute(ElementName="RowsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_MenuPage_Content_RowsItem> gxTpr_Rows
		{
			get {
				if ( gxTv_SdtSDT_MenuPage_Content_Rows == null )
				{
					gxTv_SdtSDT_MenuPage_Content_Rows = new GXBaseCollection<SdtSDT_MenuPage_Content_RowsItem>( context, "SDT_MenuPage.Content.RowsItem", "");
				}
				return gxTv_SdtSDT_MenuPage_Content_Rows;
			}
			set {
				gxTv_SdtSDT_MenuPage_Content_Rows_N = false;
				gxTv_SdtSDT_MenuPage_Content_Rows = value;
				SetDirty("Rows");
			}
		}

		public void gxTv_SdtSDT_MenuPage_Content_Rows_SetNull()
		{
			gxTv_SdtSDT_MenuPage_Content_Rows_N = true;
			gxTv_SdtSDT_MenuPage_Content_Rows = null;
		}

		public bool gxTv_SdtSDT_MenuPage_Content_Rows_IsNull()
		{
			return gxTv_SdtSDT_MenuPage_Content_Rows == null;
		}
		public bool ShouldSerializegxTpr_Rows_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_MenuPage_Content_Rows != null && gxTv_SdtSDT_MenuPage_Content_Rows.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Rows_GxSimpleCollection_Json() || 
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
			gxTv_SdtSDT_MenuPage_Content_Rows_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_MenuPage_Content_Rows_N;
		protected GXBaseCollection<SdtSDT_MenuPage_Content_RowsItem> gxTv_SdtSDT_MenuPage_Content_Rows = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_MenuPage.Content", Namespace="Comforta_version2")]
	public class SdtSDT_MenuPage_Content_RESTInterface : GxGenericCollectionItem<SdtSDT_MenuPage_Content>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MenuPage_Content_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MenuPage_Content_RESTInterface( SdtSDT_MenuPage_Content psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Rows", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_MenuPage_Content_RowsItem_RESTInterface> gxTpr_Rows
		{
			get {
				if (sdt.ShouldSerializegxTpr_Rows_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_MenuPage_Content_RowsItem_RESTInterface>(sdt.gxTpr_Rows);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Rows);
			}
		}


		#endregion

		public SdtSDT_MenuPage_Content sdt
		{
			get { 
				return (SdtSDT_MenuPage_Content)Sdt;
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
				sdt = new SdtSDT_MenuPage_Content() ;
			}
		}
	}
	#endregion
}