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
   public class prc_savepagev2 : GXProcedure
   {
      public prc_savepagev2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_savepagev2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           string aP3_PageType ,
                           string aP4_PageStructure ,
                           out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageId = aP1_PageId;
         this.AV10PageName = aP2_PageName;
         this.AV11PageType = aP3_PageType;
         this.AV12PageStructure = aP4_PageStructure;
         this.AV23SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP5_SDT_Error=this.AV23SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_PageId ,
                                      string aP2_PageName ,
                                      string aP3_PageType ,
                                      string aP4_PageStructure )
      {
         execute(aP0_AppVersionId, aP1_PageId, aP2_PageName, aP3_PageType, aP4_PageStructure, out aP5_SDT_Error);
         return AV23SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 string aP3_PageType ,
                                 string aP4_PageStructure ,
                                 out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageId = aP1_PageId;
         this.AV10PageName = aP2_PageName;
         this.AV11PageType = aP3_PageType;
         this.AV12PageStructure = aP4_PageStructure;
         this.AV23SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP5_SDT_Error=this.AV23SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV23SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV23SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00BQ2 */
         pr_default.execute(0, new Object[] {AV8AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A543AppVersionId = P00BQ2_A543AppVersionId[0];
            /* Using cursor P00BQ3 */
            pr_default.execute(1, new Object[] {A543AppVersionId, AV9PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               GXTBQ3 = 0;
               A521PageId = P00BQ3_A521PageId[0];
               A522PageName = P00BQ3_A522PageName[0];
               A545PageType = P00BQ3_A545PageType[0];
               A523PageStructure = P00BQ3_A523PageStructure[0];
               A522PageName = AV10PageName;
               if ( StringUtil.StrCmp(A545PageType, "Menu") == 0 )
               {
                  AV17SDT_MenuPage.FromJSonString(AV12PageStructure, null);
                  AV21CleanedPageStructure = AV17SDT_MenuPage.ToJSonString(false, true);
               }
               else
               {
                  AV19SDT_ContentPage.FromJSonString(AV12PageStructure, null);
                  AV21CleanedPageStructure = AV19SDT_ContentPage.ToJSonString(false, true);
               }
               A523PageStructure = AV21CleanedPageStructure;
               GXTBQ3 = 1;
               /* Using cursor P00BQ4 */
               pr_default.execute(2, new Object[] {A522PageName, A523PageStructure, A543AppVersionId, A521PageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               if ( GXTBQ3 == 1 )
               {
                  context.CommitDataStores("prc_savepagev2",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepagev2",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV23SDT_Error = new SdtSDT_Error(context);
         P00BQ2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A543AppVersionId = Guid.Empty;
         P00BQ3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BQ3_A521PageId = new Guid[] {Guid.Empty} ;
         P00BQ3_A522PageName = new string[] {""} ;
         P00BQ3_A545PageType = new string[] {""} ;
         P00BQ3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         AV17SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV21CleanedPageStructure = "";
         AV19SDT_ContentPage = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__default(),
            new Object[][] {
                new Object[] {
               P00BQ2_A543AppVersionId
               }
               , new Object[] {
               P00BQ3_A543AppVersionId, P00BQ3_A521PageId, P00BQ3_A522PageName, P00BQ3_A545PageType, P00BQ3_A523PageStructure
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBQ3 ;
      private string AV12PageStructure ;
      private string A523PageStructure ;
      private string AV21CleanedPageStructure ;
      private string AV10PageName ;
      private string AV11PageType ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid AV8AppVersionId ;
      private Guid AV9PageId ;
      private Guid A543AppVersionId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV23SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BQ2_A543AppVersionId ;
      private Guid[] P00BQ3_A543AppVersionId ;
      private Guid[] P00BQ3_A521PageId ;
      private string[] P00BQ3_A522PageName ;
      private string[] P00BQ3_A545PageType ;
      private string[] P00BQ3_A523PageStructure ;
      private SdtSDT_MenuPage AV17SDT_MenuPage ;
      private SdtSDT_ContentPage AV19SDT_ContentPage ;
      private SdtSDT_Error aP5_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_savepagev2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_savepagev2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_savepagev2__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BQ2;
       prmP00BQ2 = new Object[] {
       new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BQ3;
       prmP00BQ3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV9PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BQ4;
       prmP00BQ4 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BQ2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV8AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BQ3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV9PageId ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BQ4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName, PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BQ4)
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
