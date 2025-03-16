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
   public class prc_getappversions : GXProcedure
   {
      public prc_getappversions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getappversions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ,
                           ref SdtSDT_Error aP1_SDT_Error )
      {
         this.AV8SDT_AppVersionCollection = aP0_SDT_AppVersionCollection;
         this.AV11SDT_Error = aP1_SDT_Error;
         initialize();
         ExecuteImpl();
         aP0_SDT_AppVersionCollection=this.AV8SDT_AppVersionCollection;
         aP1_SDT_Error=this.AV11SDT_Error;
      }

      public SdtSDT_Error executeUdp( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection )
      {
         execute(ref aP0_SDT_AppVersionCollection, ref aP1_SDT_Error);
         return AV11SDT_Error ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ,
                                 ref SdtSDT_Error aP1_SDT_Error )
      {
         this.AV8SDT_AppVersionCollection = aP0_SDT_AppVersionCollection;
         this.AV11SDT_Error = aP1_SDT_Error;
         SubmitImpl();
         aP0_SDT_AppVersionCollection=this.AV8SDT_AppVersionCollection;
         aP1_SDT_Error=this.AV11SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV11SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV11SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV21Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            /* Using cursor P00BL2 */
            pr_default.execute(0, new Object[] {AV21Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A543AppVersionId = P00BL2_A543AppVersionId[0];
               A29LocationId = P00BL2_A29LocationId[0];
               A544AppVersionName = P00BL2_A544AppVersionName[0];
               AV10BC_Trn_AppVersion.Load(A543AppVersionId);
               AV9SDT_AppVersion.FromJSonString(AV10BC_Trn_AppVersion.ToJSonString(true, true), null);
               AV9SDT_AppVersion.gxTpr_Pages.Clear();
               /* Using cursor P00BL3 */
               pr_default.execute(1, new Object[] {A543AppVersionId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTBL3 = 0;
                  A521PageId = P00BL3_A521PageId[0];
                  A522PageName = P00BL3_A522PageName[0];
                  A545PageType = P00BL3_A545PageType[0];
                  A523PageStructure = P00BL3_A523PageStructure[0];
                  AV12PageItem = new SdtSDT_AppVersion_PagesItem(context);
                  AV12PageItem.gxTpr_Pageid = A521PageId;
                  AV12PageItem.gxTpr_Pagename = A522PageName;
                  AV12PageItem.gxTpr_Pagetype = A545PageType;
                  AV19PageStructure = "";
                  AV17SDT_ContentPage = new SdtSDT_ContentPage(context);
                  AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
                  if ( StringUtil.StrCmp(AV12PageItem.gxTpr_Pagetype, "Menu") == 0 )
                  {
                     AV13SDT_MenuPage.FromJSonString(A523PageStructure, null);
                     AV12PageItem.gxTpr_Pagemenustructure = AV13SDT_MenuPage;
                     AV19PageStructure = AV13SDT_MenuPage.ToJSonString(false, true);
                  }
                  else
                  {
                     AV17SDT_ContentPage.FromJSonString(A523PageStructure, null);
                     GXt_SdtSDT_ContentPage1 = AV18UpdatedSDT_ContentPage;
                     new prc_updateproductservicestructuredata(context ).execute(  A521PageId,  AV17SDT_ContentPage, out  GXt_SdtSDT_ContentPage1) ;
                     AV18UpdatedSDT_ContentPage = GXt_SdtSDT_ContentPage1;
                     AV12PageItem.gxTpr_Pagecontentstructure = AV18UpdatedSDT_ContentPage;
                     AV19PageStructure = AV18UpdatedSDT_ContentPage.ToJSonString(false, true);
                     A523PageStructure = AV19PageStructure;
                     GXTBL3 = 1;
                  }
                  AV12PageItem.gxTpr_Pagestructure = AV19PageStructure;
                  AV9SDT_AppVersion.gxTpr_Pages.Add(AV12PageItem, 0);
                  /* Using cursor P00BL4 */
                  pr_default.execute(2, new Object[] {A523PageStructure, A543AppVersionId, A521PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( GXTBL3 == 1 )
                  {
                     context.CommitDataStores("prc_getappversions",pr_default);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV8SDT_AppVersionCollection.Add(AV9SDT_AppVersion, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         new prc_logtoserver(context ).execute(  AV8SDT_AppVersionCollection.ToJSonString(false)) ;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_getappversions",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV21Udparg1 = Guid.Empty;
         P00BL2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BL2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BL2_A544AppVersionName = new string[] {""} ;
         A543AppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A544AppVersionName = "";
         AV10BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         P00BL3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BL3_A521PageId = new Guid[] {Guid.Empty} ;
         P00BL3_A522PageName = new string[] {""} ;
         P00BL3_A545PageType = new string[] {""} ;
         P00BL3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A522PageName = "";
         A545PageType = "";
         A523PageStructure = "";
         AV12PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV19PageStructure = "";
         AV17SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV18UpdatedSDT_ContentPage = new SdtSDT_ContentPage(context);
         GXt_SdtSDT_ContentPage1 = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_getappversions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_getappversions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getappversions__default(),
            new Object[][] {
                new Object[] {
               P00BL2_A543AppVersionId, P00BL2_A29LocationId, P00BL2_A544AppVersionName
               }
               , new Object[] {
               P00BL3_A543AppVersionId, P00BL3_A521PageId, P00BL3_A522PageName, P00BL3_A545PageType, P00BL3_A523PageStructure
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBL3 ;
      private string A523PageStructure ;
      private string AV19PageStructure ;
      private string A544AppVersionName ;
      private string A522PageName ;
      private string A545PageType ;
      private Guid AV21Udparg1 ;
      private Guid A543AppVersionId ;
      private Guid A29LocationId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AppVersion> AV8SDT_AppVersionCollection ;
      private GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ;
      private SdtSDT_Error AV11SDT_Error ;
      private SdtSDT_Error aP1_SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BL2_A543AppVersionId ;
      private Guid[] P00BL2_A29LocationId ;
      private string[] P00BL2_A544AppVersionName ;
      private SdtTrn_AppVersion AV10BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
      private Guid[] P00BL3_A543AppVersionId ;
      private Guid[] P00BL3_A521PageId ;
      private string[] P00BL3_A522PageName ;
      private string[] P00BL3_A545PageType ;
      private string[] P00BL3_A523PageStructure ;
      private SdtSDT_AppVersion_PagesItem AV12PageItem ;
      private SdtSDT_ContentPage AV17SDT_ContentPage ;
      private SdtSDT_MenuPage AV13SDT_MenuPage ;
      private SdtSDT_ContentPage AV18UpdatedSDT_ContentPage ;
      private SdtSDT_ContentPage GXt_SdtSDT_ContentPage1 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_getappversions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_getappversions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_getappversions__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00BL2;
       prmP00BL2 = new Object[] {
       new ParDef("AV21Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BL3;
       prmP00BL3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BL4;
       prmP00BL4 = new Object[] {
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BL2", "SELECT AppVersionId, LocationId, AppVersionName FROM Trn_AppVersion WHERE LocationId = :AV21Udparg1 ORDER BY AppVersionName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BL3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BL4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BL4)
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
