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
   public class prc_loadappversionsdt : GXProcedure
   {
      public prc_loadappversionsdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loadappversionsdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtTrn_AppVersion aP0_BC_Trn_AppVersion ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         this.AV8BC_Trn_AppVersion = aP0_BC_Trn_AppVersion;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV9SDT_AppVersion;
      }

      public SdtSDT_AppVersion executeUdp( SdtTrn_AppVersion aP0_BC_Trn_AppVersion )
      {
         execute(aP0_BC_Trn_AppVersion, out aP1_SDT_AppVersion);
         return AV9SDT_AppVersion ;
      }

      public void executeSubmit( SdtTrn_AppVersion aP0_BC_Trn_AppVersion ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         this.AV8BC_Trn_AppVersion = aP0_BC_Trn_AppVersion;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV9SDT_AppVersion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_AppVersion.FromJSonString(AV8BC_Trn_AppVersion.ToJSonString(true, true), null);
         AV9SDT_AppVersion.gxTpr_Pages.Clear();
         /* Using cursor P00CM2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTCM2 = 0;
            A521PageId = P00CM2_A521PageId[0];
            A522PageName = P00CM2_A522PageName[0];
            A545PageType = P00CM2_A545PageType[0];
            A523PageStructure = P00CM2_A523PageStructure[0];
            A543AppVersionId = P00CM2_A543AppVersionId[0];
            AV10PageItem = new SdtSDT_AppVersion_PagesItem(context);
            AV10PageItem.gxTpr_Pageid = A521PageId;
            AV10PageItem.gxTpr_Pagename = A522PageName;
            AV10PageItem.gxTpr_Pagetype = A545PageType;
            AV11PageStructure = "";
            AV13SDT_ContentPage = new SdtSDT_ContentPage(context);
            AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
            if ( StringUtil.StrCmp(AV10PageItem.gxTpr_Pagetype, "Menu") == 0 )
            {
               AV14SDT_MenuPage.FromJSonString(A523PageStructure, null);
               AV10PageItem.gxTpr_Pagemenustructure = AV14SDT_MenuPage;
               AV11PageStructure = AV14SDT_MenuPage.ToJSonString(false, true);
            }
            else
            {
               AV13SDT_ContentPage.FromJSonString(A523PageStructure, null);
               GXt_SdtSDT_ContentPage1 = AV12UpdatedSDT_ContentPage;
               new prc_updateproductservicestructuredata(context ).execute(  A521PageId,  AV13SDT_ContentPage, out  GXt_SdtSDT_ContentPage1) ;
               AV12UpdatedSDT_ContentPage = GXt_SdtSDT_ContentPage1;
               AV10PageItem.gxTpr_Pagecontentstructure = AV12UpdatedSDT_ContentPage;
               AV11PageStructure = AV12UpdatedSDT_ContentPage.ToJSonString(false, true);
               A523PageStructure = AV11PageStructure;
               GXTCM2 = 1;
            }
            AV10PageItem.gxTpr_Pagestructure = AV11PageStructure;
            AV9SDT_AppVersion.gxTpr_Pages.Add(AV10PageItem, 0);
            /* Using cursor P00CM3 */
            pr_default.execute(1, new Object[] {A523PageStructure, A543AppVersionId, A521PageId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
            if ( GXTCM2 == 1 )
            {
               context.CommitDataStores("prc_loadappversionsdt",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_loadappversionsdt",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         P00CM2_A521PageId = new Guid[] {Guid.Empty} ;
         P00CM2_A522PageName = new string[] {""} ;
         P00CM2_A545PageType = new string[] {""} ;
         P00CM2_A523PageStructure = new string[] {""} ;
         P00CM2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         A543AppVersionId = Guid.Empty;
         AV10PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV11PageStructure = "";
         AV13SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV12UpdatedSDT_ContentPage = new SdtSDT_ContentPage(context);
         GXt_SdtSDT_ContentPage1 = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_loadappversionsdt__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_loadappversionsdt__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_loadappversionsdt__default(),
            new Object[][] {
                new Object[] {
               P00CM2_A521PageId, P00CM2_A522PageName, P00CM2_A545PageType, P00CM2_A523PageStructure, P00CM2_A543AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTCM2 ;
      private string A523PageStructure ;
      private string AV11PageStructure ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid A521PageId ;
      private Guid A543AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion AV8BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CM2_A521PageId ;
      private string[] P00CM2_A522PageName ;
      private string[] P00CM2_A545PageType ;
      private string[] P00CM2_A523PageStructure ;
      private Guid[] P00CM2_A543AppVersionId ;
      private SdtSDT_AppVersion_PagesItem AV10PageItem ;
      private SdtSDT_ContentPage AV13SDT_ContentPage ;
      private SdtSDT_MenuPage AV14SDT_MenuPage ;
      private SdtSDT_ContentPage AV12UpdatedSDT_ContentPage ;
      private SdtSDT_ContentPage GXt_SdtSDT_ContentPage1 ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_loadappversionsdt__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_loadappversionsdt__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_loadappversionsdt__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00CM2;
       prmP00CM2 = new Object[] {
       };
       Object[] prmP00CM3;
       prmP00CM3 = new Object[] {
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CM2", "SELECT PageId, PageName, PageType, PageStructure, AppVersionId FROM Trn_AppVersionPage ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CM3", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CM3)
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
