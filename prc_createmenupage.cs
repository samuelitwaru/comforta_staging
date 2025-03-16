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
   public class prc_createmenupage : GXProcedure
   {
      public prc_createmenupage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createmenupage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV12PageName = aP1_PageName;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_PageName, out aP2_PageItem, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV12PageName = aP1_PageName;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV18BC_Trn_AppVersion.Load(AV11AppVersionId);
         AV10BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV10BC_Page.gxTpr_Pagename = AV12PageName;
         AV10BC_Page.gxTpr_Pagetype = "Menu";
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         /* Execute user subroutine: 'DEFAULTMENUPAGETILE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10BC_Page.gxTpr_Pagestructure = AV13SDT_MenuPage.ToJSonString(false, true);
         AV18BC_Trn_AppVersion.gxTpr_Page.Add(AV10BC_Page, 0);
         AV18BC_Trn_AppVersion.Save();
         if ( AV18BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createmenupage",pr_default);
            AV20PageItem.FromJSonString(AV10BC_Page.ToJSonString(true, true), null);
            AV20PageItem.gxTpr_Pagemenustructure = AV13SDT_MenuPage;
         }
         else
         {
            AV22GXV2 = 1;
            AV21GXV1 = AV18BC_Trn_AppVersion.GetMessages();
            while ( AV22GXV2 <= AV21GXV1.Count )
            {
               AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV21GXV1.Item(AV22GXV2));
               AV8SDT_Error.gxTpr_Message = AV19Message.gxTpr_Description;
               AV22GXV2 = (int)(AV22GXV2+1);
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'DEFAULTMENUPAGETILE' Routine */
         returnInSub = false;
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV16TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Reception", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV16TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV17RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV17RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV17RowsItem.gxTpr_Tiles.Add(AV16TilesItem, 0);
         AV13SDT_MenuPage.gxTpr_Rows.Add(AV17RowsItem, 0);
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
         AV20PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV18BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV10BC_Page = new SdtTrn_AppVersion_Page(context);
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV21GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV16TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createmenupage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createmenupage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createmenupage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV2 ;
      private bool returnInSub ;
      private string AV12PageName ;
      private Guid AV11AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV20PageItem ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_AppVersion AV18BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV10BC_Page ;
      private SdtSDT_MenuPage AV13SDT_MenuPage ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV16TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 ;
      private SdtSDT_MenuPage_RowsItem AV17RowsItem ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createmenupage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createmenupage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createmenupage__default : DataStoreHelperBase, IDataStoreHelper
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
