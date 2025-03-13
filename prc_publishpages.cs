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
   public class prc_publishpages : GXProcedure
   {
      public prc_publishpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_publishpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           ref GXBaseCollection<SdtSDT_PageV2> aP1_SDT_PageV2Collection ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV19AppVersionId = aP0_AppVersionId;
         this.AV10SDT_PageV2Collection = aP1_SDT_PageV2Collection;
         this.AV22SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_PageV2Collection=this.AV10SDT_PageV2Collection;
         aP2_SDT_Error=this.AV22SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      ref GXBaseCollection<SdtSDT_PageV2> aP1_SDT_PageV2Collection )
      {
         execute(aP0_AppVersionId, ref aP1_SDT_PageV2Collection, out aP2_SDT_Error);
         return AV22SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 ref GXBaseCollection<SdtSDT_PageV2> aP1_SDT_PageV2Collection ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV19AppVersionId = aP0_AppVersionId;
         this.AV10SDT_PageV2Collection = aP1_SDT_PageV2Collection;
         this.AV22SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_PageV2Collection=this.AV10SDT_PageV2Collection;
         aP2_SDT_Error=this.AV22SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV22SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV22SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV10SDT_PageV2Collection.Count )
         {
            AV8SDT_PageV2 = ((SdtSDT_PageV2)AV10SDT_PageV2Collection.Item(AV23GXV1));
            /* Using cursor P00BW2 */
            pr_default.execute(0, new Object[] {AV19AppVersionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A543AppVersionId = P00BW2_A543AppVersionId[0];
               /* Using cursor P00BW3 */
               pr_default.execute(1, new Object[] {A543AppVersionId, AV8SDT_PageV2.gxTpr_Pageid});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTBW3 = 0;
                  A521PageId = P00BW3_A521PageId[0];
                  A522PageName = P00BW3_A522PageName[0];
                  A545PageType = P00BW3_A545PageType[0];
                  A523PageStructure = P00BW3_A523PageStructure[0];
                  A562PagePublishedStructure = P00BW3_A562PagePublishedStructure[0];
                  A522PageName = AV8SDT_PageV2.gxTpr_Pagename;
                  if ( StringUtil.StrCmp(A545PageType, "Menu") == 0 )
                  {
                     AV16SDT_MenuPage.FromJSonString(AV8SDT_PageV2.gxTpr_Pagestructure, null);
                     AV12CleanedPageStructure = AV16SDT_MenuPage.ToJSonString(false, true);
                  }
                  else
                  {
                     AV17SDT_ContentPage.FromJSonString(AV8SDT_PageV2.gxTpr_Pagestructure, null);
                     AV12CleanedPageStructure = AV17SDT_ContentPage.ToJSonString(false, true);
                  }
                  A523PageStructure = AV12CleanedPageStructure;
                  A562PagePublishedStructure = AV12CleanedPageStructure;
                  GXTBW3 = 1;
                  /* Using cursor P00BW4 */
                  pr_default.execute(2, new Object[] {A522PageName, A523PageStructure, A562PagePublishedStructure, A543AppVersionId, A521PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( GXTBW3 == 1 )
                  {
                     context.CommitDataStores("prc_publishpages",pr_default);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_publishpages",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV22SDT_Error = new SdtSDT_Error(context);
         AV8SDT_PageV2 = new SdtSDT_PageV2(context);
         P00BW2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A543AppVersionId = Guid.Empty;
         P00BW3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BW3_A521PageId = new Guid[] {Guid.Empty} ;
         P00BW3_A522PageName = new string[] {""} ;
         P00BW3_A545PageType = new string[] {""} ;
         P00BW3_A523PageStructure = new string[] {""} ;
         P00BW3_A562PagePublishedStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         A562PagePublishedStructure = "";
         AV16SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV12CleanedPageStructure = "";
         AV17SDT_ContentPage = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_publishpages__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_publishpages__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_publishpages__default(),
            new Object[][] {
                new Object[] {
               P00BW2_A543AppVersionId
               }
               , new Object[] {
               P00BW3_A543AppVersionId, P00BW3_A521PageId, P00BW3_A522PageName, P00BW3_A545PageType, P00BW3_A523PageStructure, P00BW3_A562PagePublishedStructure
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBW3 ;
      private int AV23GXV1 ;
      private string A523PageStructure ;
      private string A562PagePublishedStructure ;
      private string AV12CleanedPageStructure ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid AV19AppVersionId ;
      private Guid A543AppVersionId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageV2> AV10SDT_PageV2Collection ;
      private GXBaseCollection<SdtSDT_PageV2> aP1_SDT_PageV2Collection ;
      private SdtSDT_Error AV22SDT_Error ;
      private SdtSDT_PageV2 AV8SDT_PageV2 ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BW2_A543AppVersionId ;
      private Guid[] P00BW3_A543AppVersionId ;
      private Guid[] P00BW3_A521PageId ;
      private string[] P00BW3_A522PageName ;
      private string[] P00BW3_A545PageType ;
      private string[] P00BW3_A523PageStructure ;
      private string[] P00BW3_A562PagePublishedStructure ;
      private SdtSDT_MenuPage AV16SDT_MenuPage ;
      private SdtSDT_ContentPage AV17SDT_ContentPage ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_publishpages__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_publishpages__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_publishpages__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00BW2;
       prmP00BW2 = new Object[] {
       new ParDef("AV19AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BW3;
       prmP00BW3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV8SDT_PageV2__Pageid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BW4;
       prmP00BW4 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BW2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV19AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BW2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BW3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure, PagePublishedStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV8SDT_PageV2__Pageid ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BW3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BW4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName, PageStructure=:PageStructure, PagePublishedStructure=:PagePublishedStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BW4)
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
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
    }
 }

}

}
