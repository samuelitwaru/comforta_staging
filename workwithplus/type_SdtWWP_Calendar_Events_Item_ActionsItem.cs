/*
				   File: type_SdtWWP_Calendar_Events_Item_ActionsItem
			Description: Actions
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
	[XmlRoot(ElementName="WWP_Calendar_Events.Item.ActionsItem")]
	[XmlType(TypeName="WWP_Calendar_Events.Item.ActionsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWP_Calendar_Events_Item_ActionsItem : GxUserType
	{
		public SdtWWP_Calendar_Events_Item_ActionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Key = "";

			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Url = "";

			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Caption = "";

			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Icon = "";

		}

		public SdtWWP_Calendar_Events_Item_ActionsItem(IGxContext context)
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


			AddObjectProperty("Url", gxTpr_Url, false);


			AddObjectProperty("Caption", gxTpr_Caption, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Key")]
		[XmlElement(ElementName="Key")]
		public string gxTpr_Key
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Key; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Key = value;
				SetDirty("Key");
			}
		}




		[SoapElement(ElementName="Url")]
		[XmlElement(ElementName="Url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Url; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Url = value;
				SetDirty("Url");
			}
		}




		[SoapElement(ElementName="Caption")]
		[XmlElement(ElementName="Caption")]
		public string gxTpr_Caption
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Caption; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Icon; 
			}
			set {
				gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Icon = value;
				SetDirty("Icon");
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
			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Key = "";
			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Url = "";
			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Caption = "";
			gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Icon = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Key;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Url;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Caption;
		 

		protected string gxTv_SdtWWP_Calendar_Events_Item_ActionsItem_Icon;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_Calendar_Events.Item.ActionsItem", Namespace="Comforta_version2")]
	public class SdtWWP_Calendar_Events_Item_ActionsItem_RESTInterface : GxGenericCollectionItem<SdtWWP_Calendar_Events_Item_ActionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_Calendar_Events_Item_ActionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_Calendar_Events_Item_ActionsItem_RESTInterface( SdtWWP_Calendar_Events_Item_ActionsItem psdt ) : base(psdt)
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

		[DataMember(Name="Url", Order=1)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}

		[DataMember(Name="Caption", Order=2)]
		public  string gxTpr_Caption
		{
			get { 
				return sdt.gxTpr_Caption;

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="Icon", Order=3)]
		public  string gxTpr_Icon
		{
			get { 
				return sdt.gxTpr_Icon;

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}


		#endregion

		public SdtWWP_Calendar_Events_Item_ActionsItem sdt
		{
			get { 
				return (SdtWWP_Calendar_Events_Item_ActionsItem)Sdt;
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
				sdt = new SdtWWP_Calendar_Events_Item_ActionsItem() ;
			}
		}
	}
	#endregion
}