using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_createpage : GXProcedure
   {
      public prc_createpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PageName ,
                           ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
      }

      public string executeUdp( string aP0_PageName )
      {
         execute(aP0_PageName, ref aP1_Response);
         return AV17Response ;
      }

      public void executeSubmit( string aP0_PageName ,
                                 ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         SubmitImpl();
         aP1_Response=this.AV17Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV19UserName, ref  AV20LocationId, ref  AV21OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV19UserName))) )
         {
            cleanup();
            if (true) return;
         }
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV8BC_Trn_Page.gxTpr_Trn_pagename = AV16PageName;
         AV8BC_Trn_Page.gxTpr_Pageispublished = false;
         AV8BC_Trn_Page.gxTpr_Locationid = AV20LocationId;
         AV8BC_Trn_Page.gxTpr_Organisationid = AV21OrganisationId;
         AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
         AV8BC_Trn_Page.gxTpr_Pagegjsjson = context.GetMessage( "{\"assets\":[],\"styles\":[],\"pages\":[{\"frames\":[{\"component\":{\"type\":\"wrapper\",\"droppable\":false,\"stylable\":[\"background\",\"background-color\",\"background-image\",\"background-repeat\",\"background-attachment\",\"background-position\",\"background-size\"],\"resizable\":{\"handles\":\"e\"},\"selectable\":false,\"attributes\":{\"theme\":\"Modern\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"frame-container\"],\"attributes\":{\"id\":\"frame-container\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"container-column\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"selectable\":false,\"classes\":[\"container-row\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"droppable\":false,\"selectable\":false,\"classes\":[\"template-wrapper\",\"default-template\"],\"attributes\":{\"tile-text\":\"Tile\",\"tile-text-color\":\"#000000\",\"tile-text-align\":\"left\",\"tile-icon\":\"icon-name\",\"tile-icon-color\":\"#000000\",\"tile-icon-align\":\"left\",\"tile-bg-color\":\"#ffffff\",\"tile-bg-image\":\"\",\"tile-bg-image-opacity\":\"100\",\"tile-action-object\":\"Page\",\"tile-action-object-id\":\"\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"hoverable\":false,\"classes\":[\"template-block\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-icon-section\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-close-icon\",\"top-right\",\"selected-tile-icon\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"×\",\"_undoexc\":[\"status\",\"open\"]}]},{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-icon\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"\\n                \",\"_undoexc\":[\"status\",\"open\"]}]}]},{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-title-section\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-close-icon\",\"top-right\",\"selected-tile-title\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"×\",\"_undoexc\":[\"status\",\"open\"]}]},{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-title\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"Title\",\"_undoexc\":[\"status\",\"open\"]}]}]}]},{\"tagName\":\"button\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":true,\"hoverable\":false,\"classes\":[\"action-button\",\"add-button-bottom\"],\"attributes\":{\"title\":\"Add template below\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"svg\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"selectable\":false,\"hoverable\":false,\"attributes\":{\"xmlns\":\"http://www.w3.org/2000/svg\",\"width\":\"16\",\"height\":\"16\",\"viewBox\":\"0 0 24 24\",\"fill\":\"none\",\"stroke\":\"currentColor\",\"stroke-width\":\"2\",\"stroke-linecap\":\"round\",\"stroke-linejoin\":\"round\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"12\",\"y1\":\"5\",\"x2\":\"12\",\"y2\":\"19\"},\"_undoexc\":[\"status\",\"open\"]},{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"5\",\"y1\":\"12\",\"x2\":\"19\",\"y2\":\"12\"},\"_undoexc\":[\"status\",\"open\"]}]}]},{\"tagName\":\"button\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":true,\"hoverable\":false,\"classes\":[\"action-button\",\"add-button-right\"],\"attributes\":{\"title\":\"Add template right\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"svg\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"selectable\":false,\"hoverable\":false,\"attributes\":{\"xmlns\":\"http://www.w3.org/2000/svg\",\"width\":\"16\",\"height\":\"16\",\"viewBox\":\"0 0 24 24\",\"fill\":\"none\",\"stroke\":\"currentColor\",\"stroke-width\":\"2\",\"stroke-linecap\":\"round\",\"stroke-linejoin\":\"round\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"12\",\"y1\":\"5\",\"x2\":\"12\",\"y2\":\"19\"},\"_undoexc\":[\"status\",\"open\"]},{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"5\",\"y1\":\"12\",\"x2\":\"19\",\"y2\":\"12\"},\"_undoexc\":[\"status\",\"open\"]}]}]},{\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"resize-handle\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"\\n          \",\"_undoexc\":[\"status\",\"open\"]}]}]}]}]}]}]}}],\"type\":\"main\",\"id\":\"M1I3WJbl1jsJyHc2\"}]}", "");
         AV8BC_Trn_Page.gxTpr_Pageiscontentpage = false;
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Pagechildren_SetNull();
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Productserviceid_SetNull();
         AV8BC_Trn_Page.Save();
         if ( AV8BC_Trn_Page.Success() )
         {
            context.CommitDataStores("prc_createpage",pr_default);
         }
         else
         {
            AV23GXV2 = 1;
            AV22GXV1 = AV8BC_Trn_Page.GetMessages();
            while ( AV23GXV2 <= AV22GXV1.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV22GXV1.Item(AV23GXV2));
               new prc_logtofile(context ).execute(  AV9Message.gxTpr_Description) ;
               AV23GXV2 = (int)(AV23GXV2+1);
            }
         }
         AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
         new prc_logtofile(context ).execute(  AV17Response) ;
         cleanup();
         if (true) return;
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV19UserName = "";
         AV20LocationId = Guid.Empty;
         AV21OrganisationId = Guid.Empty;
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV22GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV2 ;
      private string AV17Response ;
      private string AV16PageName ;
      private string AV19UserName ;
      private Guid AV20LocationId ;
      private Guid AV21OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP1_Response ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_createpage__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_createpage__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
