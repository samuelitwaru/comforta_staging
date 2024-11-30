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
         GXt_char1 = AV19UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV19UserName = GXt_char1;
         /* Using cursor P008V2 */
         pr_default.execute(0, new Object[] {AV19UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P008V2_A93ReceptionistEmail[0];
            A29LocationId = P008V2_A29LocationId[0];
            A11OrganisationId = P008V2_A11OrganisationId[0];
            A89ReceptionistId = P008V2_A89ReceptionistId[0];
            AV20LocationId = A29LocationId;
            AV21OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV8BC_Trn_Page.gxTpr_Trn_pagename = AV16PageName;
         AV8BC_Trn_Page.gxTpr_Pageispublished = false;
         AV8BC_Trn_Page.gxTpr_Locationid = AV20LocationId;
         AV8BC_Trn_Page.gxTpr_Organisationid = AV21OrganisationId;
         AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
         AV8BC_Trn_Page.gxTpr_Pagegjsjson = context.GetMessage( "{\"assets\":[],\"styles\":[],\"pages\":[{\"frames\":[{\"component\":{\"type\":\"wrapper\",\"droppable\":false,\"stylable\":[\"background\",\"background-color\",\"background-image\",\"background-repeat\",\"background-attachment\",\"background-position\",\"background-size\"],\"resizable\":{\"handles\":\"e\"},\"selectable\":false,\"attributes\":{\"theme\":\"Modern\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"frame-container\"],\"attributes\":{\"id\":\"frame-container\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"container-column\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"draggable\":false,\"selectable\":false,\"classes\":[\"container-row\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"template-wrapper\",\"droppable\":false,\"selectable\":false,\"classes\":[\"template-wrapper\",\"default-template\"],\"attributes\":{\"tile-text\":\"Tile\",\"tile-text-color\":\"#000000\",\"tile-text-align\":\"left\",\"tile-icon\":\"icon-name\",\"tile-icon-color\":\"#000000\",\"tile-icon-align\":\"left\",\"tile-bg-color\":\"#ffffff\",\"tile-bg-image\":\"\",\"tile-bg-image-opacity\":\"100\",\"tile-action-object\":\"Page\",\"tile-action-object-id\":\"\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"hoverable\":false,\"classes\":[\"template-block\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-icon-section\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-close-icon\",\"top-right\",\"selected-tile-icon\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"×\",\"_undoexc\":[\"status\",\"open\"]}]},{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-icon\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"\\n                \",\"_undoexc\":[\"status\",\"open\"]}]}]},{\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-title-section\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-close-icon\",\"top-right\",\"selected-tile-title\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"×\",\"_undoexc\":[\"status\",\"open\"]}]},{\"tagName\":\"span\",\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"tile-title\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"Title\",\"_undoexc\":[\"status\",\"open\"]}]}]}]},{\"tagName\":\"button\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"action-button\",\"add-button-bottom\"],\"attributes\":{\"title\":\"Add template below\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"svg\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"selectable\":false,\"hoverable\":false,\"attributes\":{\"xmlns\":\"http://www.w3.org/2000/svg\",\"width\":\"16\",\"height\":\"16\",\"viewBox\":\"0 0 24 24\",\"fill\":\"none\",\"stroke\":\"currentColor\",\"stroke-width\":\"2\",\"stroke-linecap\":\"round\",\"stroke-linejoin\":\"round\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"12\",\"y1\":\"5\",\"x2\":\"12\",\"y2\":\"19\"},\"_undoexc\":[\"status\",\"open\"]},{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"5\",\"y1\":\"12\",\"x2\":\"19\",\"y2\":\"12\"},\"_undoexc\":[\"status\",\"open\"]}]}]},{\"tagName\":\"button\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"action-button\",\"add-button-right\"],\"attributes\":{\"title\":\"Add template right\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"svg\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"selectable\":false,\"hoverable\":false,\"attributes\":{\"xmlns\":\"http://www.w3.org/2000/svg\",\"width\":\"16\",\"height\":\"16\",\"viewBox\":\"0 0 24 24\",\"fill\":\"none\",\"stroke\":\"currentColor\",\"stroke-width\":\"2\",\"stroke-linecap\":\"round\",\"stroke-linejoin\":\"round\"},\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"12\",\"y1\":\"5\",\"x2\":\"12\",\"y2\":\"19\"},\"_undoexc\":[\"status\",\"open\"]},{\"tagName\":\"line\",\"type\":\"svg-in\",\"draggable\":false,\"droppable\":false,\"highlightable\":false,\"resizable\":{\"ratioDefault\":1},\"attributes\":{\"x1\":\"5\",\"y1\":\"12\",\"x2\":\"19\",\"y2\":\"12\"},\"_undoexc\":[\"status\",\"open\"]}]}]},{\"type\":\"text\",\"draggable\":false,\"highlightable\":false,\"editable\":false,\"selectable\":false,\"hoverable\":false,\"classes\":[\"resize-handle\"],\"_undoexc\":[\"status\",\"open\"],\"components\":[{\"type\":\"textnode\",\"content\":\"\\n          \",\"_undoexc\":[\"status\",\"open\"]}]}]}]}]}]}]}}],\"type\":\"main\",\"id\":\"M1I3WJbl1jsJyHc2\"}]}", "");
         AV8BC_Trn_Page.gxTpr_Pageiscontentpage = false;
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Pagechildren_SetNull();
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Productserviceid_SetNull();
         AV8BC_Trn_Page.Save();
         new prc_logtofile(context ).execute(  context.GetMessage( "Something", "")) ;
         if ( AV8BC_Trn_Page.Success() )
         {
            context.CommitDataStores("prc_createpage",pr_default);
         }
         else
         {
            AV24GXV2 = 1;
            AV23GXV1 = AV8BC_Trn_Page.GetMessages();
            while ( AV24GXV2 <= AV23GXV1.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV23GXV1.Item(AV24GXV2));
               new prc_logtofile(context ).execute(  AV9Message.gxTpr_Description) ;
               AV24GXV2 = (int)(AV24GXV2+1);
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
         GXt_char1 = "";
         P008V2_A93ReceptionistEmail = new string[] {""} ;
         P008V2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008V2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008V2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV20LocationId = Guid.Empty;
         AV21OrganisationId = Guid.Empty;
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV23GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
                new Object[] {
               P008V2_A93ReceptionistEmail, P008V2_A29LocationId, P008V2_A11OrganisationId, P008V2_A89ReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV2 ;
      private string GXt_char1 ;
      private string AV17Response ;
      private string AV16PageName ;
      private string AV19UserName ;
      private string A93ReceptionistEmail ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private Guid AV20LocationId ;
      private Guid AV21OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP1_Response ;
      private IDataStoreProvider pr_default ;
      private string[] P008V2_A93ReceptionistEmail ;
      private Guid[] P008V2_A29LocationId ;
      private Guid[] P008V2_A11OrganisationId ;
      private Guid[] P008V2_A89ReceptionistId ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23GXV1 ;
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
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP008V2;
       prmP008V2 = new Object[] {
       new ParDef("AV19UserName",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008V2", "SELECT ReceptionistEmail, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV19UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V2,100, GxCacheFrequency.OFF ,false,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
    }
 }

}

}
