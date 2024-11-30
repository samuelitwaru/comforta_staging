/*
				   File: type_SdtWWPSuggestDataItem
			Description: WWPSuggestDataItem
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
	[XmlRoot(ElementName="WWPSuggestDataItem")]
	[XmlType(TypeName="WWPSuggestDataItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPSuggestDataItem : GxUserType
	{
		public SdtWWPSuggestDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPSuggestDataItem_Id = "";

			gxTv_SdtWWPSuggestDataItem_Displayname = "";

		}

		public SdtWWPSuggestDataItem(IGxContext context)
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
				mapper["dn"] = "Displayname";
				mapper["t"] = "Text";

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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("dn", gxTpr_Displayname, false);

			if (gxTv_SdtWWPSuggestDataItem_Text != null)
			{
				AddObjectProperty("t", gxTv_SdtWWPSuggestDataItem_Text, false);
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
				return gxTv_SdtWWPSuggestDataItem_Id; 
			}
			set {
				gxTv_SdtWWPSuggestDataItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="DisplayName")]
		[XmlElement(ElementName="DisplayName")]
		public string gxTpr_Displayname
		{
			get {
				return gxTv_SdtWWPSuggestDataItem_Displayname; 
			}
			set {
				gxTv_SdtWWPSuggestDataItem_Displayname = value;
				SetDirty("Displayname");
			}
		}




		[SoapElement(ElementName="Text" )]
		[XmlArray(ElementName="Text"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Text_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtWWPSuggestDataItem_Text == null )
				{
					gxTv_SdtWWPSuggestDataItem_Text = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtWWPSuggestDataItem_Text;
			}
			set {
				gxTv_SdtWWPSuggestDataItem_Text_N = false;
				gxTv_SdtWWPSuggestDataItem_Text = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Text
		{
			get {
				if ( gxTv_SdtWWPSuggestDataItem_Text == null )
				{
					gxTv_SdtWWPSuggestDataItem_Text = new GxSimpleCollection<string>();
				}
				gxTv_SdtWWPSuggestDataItem_Text_N = false;
				return gxTv_SdtWWPSuggestDataItem_Text ;
			}
			set {
				gxTv_SdtWWPSuggestDataItem_Text_N = false;
				gxTv_SdtWWPSuggestDataItem_Text = value;
				SetDirty("Text");
			}
		}

		public void gxTv_SdtWWPSuggestDataItem_Text_SetNull()
		{
			gxTv_SdtWWPSuggestDataItem_Text_N = true;
			gxTv_SdtWWPSuggestDataItem_Text = null;
		}

		public bool gxTv_SdtWWPSuggestDataItem_Text_IsNull()
		{
			return gxTv_SdtWWPSuggestDataItem_Text == null;
		}
		public bool ShouldSerializegxTpr_Text_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWPSuggestDataItem_Text != null && gxTv_SdtWWPSuggestDataItem_Text.Count > 0;

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
			gxTv_SdtWWPSuggestDataItem_Id = "";
			gxTv_SdtWWPSuggestDataItem_Displayname = "";

			gxTv_SdtWWPSuggestDataItem_Text_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPSuggestDataItem_Id;
		 

		protected string gxTv_SdtWWPSuggestDataItem_Displayname;
		 
		protected bool gxTv_SdtWWPSuggestDataItem_Text_N;
		protected GxSimpleCollection<string> gxTv_SdtWWPSuggestDataItem_Text = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPSuggestDataItem", Namespace="Comforta_version2")]
	public class SdtWWPSuggestDataItem_RESTInterface : GxGenericCollectionItem<SdtWWPSuggestDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPSuggestDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWPSuggestDataItem_RESTInterface( SdtWWPSuggestDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="dn", Order=1)]
		public  string gxTpr_Displayname
		{
			get { 
				return sdt.gxTpr_Displayname;

			}
			set { 
				 sdt.gxTpr_Displayname = value;
			}
		}

		[DataMember(Name="t", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Text
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Text_GxSimpleCollection_Json())
					return sdt.gxTpr_Text;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Text = value ;
			}
		}


		#endregion

		public SdtWWPSuggestDataItem sdt
		{
			get { 
				return (SdtWWPSuggestDataItem)Sdt;
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
				sdt = new SdtWWPSuggestDataItem() ;
			}
		}
	}
	#endregion
}