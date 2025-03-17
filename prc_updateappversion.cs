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
   public class prc_updateappversion : GXProcedure
   {
      public prc_updateappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_AppVersionName ,
                           out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV10AppVersionName = aP1_AppVersionName;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_AppVersion=this.AV9SDT_AppVersion;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_AppVersionName ,
                                      out SdtSDT_AppVersion aP2_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, aP1_AppVersionName, out aP2_SDT_AppVersion, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_AppVersionName ,
                                 out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV10AppVersionName = aP1_AppVersionName;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_AppVersion=this.AV9SDT_AppVersion;
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
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         /* Using cursor P00CK2 */
         pr_default.execute(0, new Object[] {AV11AppVersionId, AV12LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTCK2 = 0;
            A543AppVersionId = P00CK2_A543AppVersionId[0];
            A29LocationId = P00CK2_A29LocationId[0];
            A544AppVersionName = P00CK2_A544AppVersionName[0];
            A544AppVersionName = AV10AppVersionName;
            GXTCK2 = 1;
            AV13BC_Trn_AppVersion.Load(A543AppVersionId);
            AV9SDT_AppVersion.FromJSonString(AV13BC_Trn_AppVersion.ToJSonString(true, true), null);
            AV9SDT_AppVersion.gxTpr_Pages.Clear();
            /* Using cursor P00CK3 */
            pr_default.execute(1, new Object[] {A543AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               GXTCK3 = 0;
               A521PageId = P00CK3_A521PageId[0];
               A522PageName = P00CK3_A522PageName[0];
               A545PageType = P00CK3_A545PageType[0];
               A523PageStructure = P00CK3_A523PageStructure[0];
               AV14PageItem = new SdtSDT_AppVersion_PagesItem(context);
               AV14PageItem.gxTpr_Pageid = A521PageId;
               AV14PageItem.gxTpr_Pagename = A522PageName;
               AV14PageItem.gxTpr_Pagetype = A545PageType;
               AV17PageStructure = "";
               AV16SDT_ContentPage = new SdtSDT_ContentPage(context);
               AV15SDT_MenuPage = new SdtSDT_MenuPage(context);
               if ( StringUtil.StrCmp(AV14PageItem.gxTpr_Pagetype, "Menu") == 0 )
               {
                  AV15SDT_MenuPage.FromJSonString(A523PageStructure, null);
                  AV14PageItem.gxTpr_Pagemenustructure = AV15SDT_MenuPage;
                  AV17PageStructure = AV15SDT_MenuPage.ToJSonString(false, true);
               }
               else
               {
                  AV16SDT_ContentPage.FromJSonString(A523PageStructure, null);
                  GXt_SdtSDT_ContentPage2 = AV18UpdatedSDT_ContentPage;
                  new prc_updateproductservicestructuredata(context ).execute(  A521PageId,  AV16SDT_ContentPage, out  GXt_SdtSDT_ContentPage2) ;
                  AV18UpdatedSDT_ContentPage = GXt_SdtSDT_ContentPage2;
                  AV14PageItem.gxTpr_Pagecontentstructure = AV18UpdatedSDT_ContentPage;
                  AV17PageStructure = AV18UpdatedSDT_ContentPage.ToJSonString(false, true);
                  A523PageStructure = AV17PageStructure;
                  GXTCK3 = 1;
               }
               AV14PageItem.gxTpr_Pagestructure = AV17PageStructure;
               AV9SDT_AppVersion.gxTpr_Pages.Add(AV14PageItem, 0);
               /* Using cursor P00CK4 */
               pr_default.execute(2, new Object[] {A523PageStructure, A543AppVersionId, A521PageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               if ( GXTCK3 == 1 )
               {
                  context.CommitDataStores("prc_updateappversion",pr_default);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P00CK5 */
            pr_default.execute(3, new Object[] {A544AppVersionName, A543AppVersionId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTCK2 == 1 )
            {
               context.CommitDataStores("prc_updateappversion",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateappversion",pr_default);
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
         AV8SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00CK2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00CK2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CK2_A544AppVersionName = new string[] {""} ;
         A543AppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A544AppVersionName = "";
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00CK3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00CK3_A521PageId = new Guid[] {Guid.Empty} ;
         P00CK3_A522PageName = new string[] {""} ;
         P00CK3_A545PageType = new string[] {""} ;
         P00CK3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         AV14PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV17PageStructure = "";
         AV16SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV15SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV18UpdatedSDT_ContentPage = new SdtSDT_ContentPage(context);
         GXt_SdtSDT_ContentPage2 = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__default(),
            new Object[][] {
                new Object[] {
               P00CK2_A543AppVersionId, P00CK2_A29LocationId, P00CK2_A544AppVersionName
               }
               , new Object[] {
               P00CK3_A543AppVersionId, P00CK3_A521PageId, P00CK3_A522PageName, P00CK3_A545PageType, P00CK3_A523PageStructure
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTCK2 ;
      private short GXTCK3 ;
      private string A523PageStructure ;
      private string AV17PageStructure ;
      private string AV10AppVersionName ;
      private string A544AppVersionName ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid AV11AppVersionId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A543AppVersionId ;
      private Guid A29LocationId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CK2_A543AppVersionId ;
      private Guid[] P00CK2_A29LocationId ;
      private string[] P00CK2_A544AppVersionName ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private Guid[] P00CK3_A543AppVersionId ;
      private Guid[] P00CK3_A521PageId ;
      private string[] P00CK3_A522PageName ;
      private string[] P00CK3_A545PageType ;
      private string[] P00CK3_A523PageStructure ;
      private SdtSDT_AppVersion_PagesItem AV14PageItem ;
      private SdtSDT_ContentPage AV16SDT_ContentPage ;
      private SdtSDT_MenuPage AV15SDT_MenuPage ;
      private SdtSDT_ContentPage AV18UpdatedSDT_ContentPage ;
      private SdtSDT_ContentPage GXt_SdtSDT_ContentPage2 ;
      private SdtSDT_AppVersion aP2_SDT_AppVersion ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new UpdateCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00CK2;
       prmP00CK2 = new Object[] {
       new ParDef("AV11AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CK3;
       prmP00CK3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CK4;
       prmP00CK4 = new Object[] {
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CK5;
       prmP00CK5 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CK2", "SELECT AppVersionId, LocationId, AppVersionName FROM Trn_AppVersion WHERE (AppVersionId = :AV11AppVersionId) AND (LocationId = :AV12LocationId) ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00CK3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CK4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CK4)
          ,new CursorDef("P00CK5", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CK5)
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
    }
 }

}

}
