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
   public class prc_activateappversion : GXProcedure
   {
      public prc_activateappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_activateappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, out aP1_SDT_AppVersion, out aP2_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         /* Using cursor P00CL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTCL2 = 0;
            A543AppVersionId = P00CL2_A543AppVersionId[0];
            A561IsActive = P00CL2_A561IsActive[0];
            A29LocationId = P00CL2_A29LocationId[0];
            A561IsActive = false;
            if ( ( ( A543AppVersionId == AV10AppVersionId ) ) && ( ( A29LocationId == AV12LocationId ) ) )
            {
               A561IsActive = true;
               AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
               AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
               AV13BC_Trn_AppVersion.Load(A543AppVersionId);
               AV8SDT_AppVersion.FromJSonString(AV13BC_Trn_AppVersion.ToJSonString(true, true), null);
               AV8SDT_AppVersion.gxTpr_Pages.Clear();
               /* Using cursor P00CL3 */
               pr_default.execute(1, new Object[] {A543AppVersionId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTCL3 = 0;
                  A521PageId = P00CL3_A521PageId[0];
                  A522PageName = P00CL3_A522PageName[0];
                  A545PageType = P00CL3_A545PageType[0];
                  A523PageStructure = P00CL3_A523PageStructure[0];
                  AV18PageItem = new SdtSDT_AppVersion_PagesItem(context);
                  AV18PageItem.gxTpr_Pageid = A521PageId;
                  AV18PageItem.gxTpr_Pagename = A522PageName;
                  AV18PageItem.gxTpr_Pagetype = A545PageType;
                  AV14PageStructure = "";
                  AV15SDT_ContentPage = new SdtSDT_ContentPage(context);
                  AV16SDT_MenuPage = new SdtSDT_MenuPage(context);
                  if ( StringUtil.StrCmp(AV18PageItem.gxTpr_Pagetype, "Menu") == 0 )
                  {
                     AV16SDT_MenuPage.FromJSonString(A523PageStructure, null);
                     AV18PageItem.gxTpr_Pagemenustructure = AV16SDT_MenuPage;
                     AV14PageStructure = AV16SDT_MenuPage.ToJSonString(false, true);
                  }
                  else
                  {
                     AV15SDT_ContentPage.FromJSonString(A523PageStructure, null);
                     GXt_SdtSDT_ContentPage2 = AV17UpdatedSDT_ContentPage;
                     new prc_updateproductservicestructuredata(context ).execute(  A521PageId,  AV15SDT_ContentPage, out  GXt_SdtSDT_ContentPage2) ;
                     AV17UpdatedSDT_ContentPage = GXt_SdtSDT_ContentPage2;
                     AV18PageItem.gxTpr_Pagecontentstructure = AV17UpdatedSDT_ContentPage;
                     AV14PageStructure = AV17UpdatedSDT_ContentPage.ToJSonString(false, true);
                     A523PageStructure = AV14PageStructure;
                     GXTCL3 = 1;
                  }
                  AV18PageItem.gxTpr_Pagestructure = AV14PageStructure;
                  AV8SDT_AppVersion.gxTpr_Pages.Add(AV18PageItem, 0);
                  /* Using cursor P00CL4 */
                  pr_default.execute(2, new Object[] {A523PageStructure, A543AppVersionId, A521PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( GXTCL3 == 1 )
                  {
                     context.CommitDataStores("prc_activateappversion",pr_default);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            GXTCL2 = 1;
            /* Using cursor P00CL5 */
            pr_default.execute(3, new Object[] {A561IsActive, A543AppVersionId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTCL2 == 1 )
            {
               context.CommitDataStores("prc_activateappversion",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_activateappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00CL2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00CL2_A561IsActive = new bool[] {false} ;
         P00CL2_A29LocationId = new Guid[] {Guid.Empty} ;
         A543AppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00CL3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00CL3_A521PageId = new Guid[] {Guid.Empty} ;
         P00CL3_A522PageName = new string[] {""} ;
         P00CL3_A545PageType = new string[] {""} ;
         P00CL3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         AV18PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV14PageStructure = "";
         AV15SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV16SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV17UpdatedSDT_ContentPage = new SdtSDT_ContentPage(context);
         GXt_SdtSDT_ContentPage2 = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__default(),
            new Object[][] {
                new Object[] {
               P00CL2_A543AppVersionId, P00CL2_A561IsActive, P00CL2_A29LocationId
               }
               , new Object[] {
               P00CL3_A543AppVersionId, P00CL3_A521PageId, P00CL3_A522PageName, P00CL3_A545PageType, P00CL3_A523PageStructure
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTCL2 ;
      private short GXTCL3 ;
      private bool A561IsActive ;
      private string A523PageStructure ;
      private string AV14PageStructure ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid AV10AppVersionId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A543AppVersionId ;
      private Guid A29LocationId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CL2_A543AppVersionId ;
      private bool[] P00CL2_A561IsActive ;
      private Guid[] P00CL2_A29LocationId ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private Guid[] P00CL3_A543AppVersionId ;
      private Guid[] P00CL3_A521PageId ;
      private string[] P00CL3_A522PageName ;
      private string[] P00CL3_A545PageType ;
      private string[] P00CL3_A523PageStructure ;
      private SdtSDT_AppVersion_PagesItem AV18PageItem ;
      private SdtSDT_ContentPage AV15SDT_ContentPage ;
      private SdtSDT_MenuPage AV16SDT_MenuPage ;
      private SdtSDT_ContentPage AV17UpdatedSDT_ContentPage ;
      private SdtSDT_ContentPage GXt_SdtSDT_ContentPage2 ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_activateappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_activateappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_activateappversion__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00CL2;
       prmP00CL2 = new Object[] {
       };
       Object[] prmP00CL3;
       prmP00CL3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CL4;
       prmP00CL4 = new Object[] {
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CL5;
       prmP00CL5 = new Object[] {
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CL2", "SELECT AppVersionId, IsActive, LocationId FROM Trn_AppVersion ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CL3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CL4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CL4)
          ,new CursorDef("P00CL5", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET IsActive=:IsActive  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CL5)
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
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
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
