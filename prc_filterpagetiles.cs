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
   public class prc_filterpagetiles : GXProcedure
   {
      public prc_filterpagetiles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_filterpagetiles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                           string aP1_UserId ,
                           out SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage )
      {
         this.AV10SDT_MobilePage = aP0_SDT_MobilePage;
         this.AV9UserId = aP1_UserId;
         this.AV12Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP2_Filtered_SDT_MobilePage=this.AV12Filtered_SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                                           string aP1_UserId )
      {
         execute(aP0_SDT_MobilePage, aP1_UserId, out aP2_Filtered_SDT_MobilePage);
         return AV12Filtered_SDT_MobilePage ;
      }

      public void executeSubmit( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                                 string aP1_UserId ,
                                 out SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage )
      {
         this.AV10SDT_MobilePage = aP0_SDT_MobilePage;
         this.AV9UserId = aP1_UserId;
         this.AV12Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP2_Filtered_SDT_MobilePage=this.AV12Filtered_SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Filtered_SDT_MobilePage.FromJSonString(AV10SDT_MobilePage.ToJSonString(false, true), null);
         AV11ModuleCollection.FromJSonString(context.GetMessage( "[\"my care\",\"my living\",\"my services\"]", ""), null);
         /* Using cursor P00CH2 */
         pr_default.execute(0, new Object[] {AV9UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A554ResidentPackageId = P00CH2_A554ResidentPackageId[0];
            n554ResidentPackageId = P00CH2_n554ResidentPackageId[0];
            A558ResidentPackageModules = P00CH2_A558ResidentPackageModules[0];
            A62ResidentId = P00CH2_A62ResidentId[0];
            A29LocationId = P00CH2_A29LocationId[0];
            A11OrganisationId = P00CH2_A11OrganisationId[0];
            A558ResidentPackageModules = P00CH2_A558ResidentPackageModules[0];
            /* Using cursor P00CH3 */
            pr_default.execute(1, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               AV16UserModuleCollection.FromJSonString(StringUtil.Lower( A558ResidentPackageModules), null);
               new prc_logtoserver(context ).execute(  AV16UserModuleCollection.ToJSonString(false)) ;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12Filtered_SDT_MobilePage.gxTpr_Row.Clear();
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV10SDT_MobilePage.gxTpr_Row.Count )
         {
            AV13RowItem = ((SdtSDT_Row)AV10SDT_MobilePage.gxTpr_Row.Item(AV22GXV1));
            AV18Index = 1;
            AV19FilteredRow = new SdtSDT_Row(context);
            if ( AV13RowItem.gxTpr_Col.Count > 0 )
            {
               new prc_logtoserver(context ).execute(  context.GetMessage( "Row: ", "")+StringUtil.Str( (decimal)(AV18Index), 4, 0)) ;
               AV23GXV2 = 1;
               while ( AV23GXV2 <= AV13RowItem.gxTpr_Col.Count )
               {
                  AV14ColItem = ((SdtSDT_Col)AV13RowItem.gxTpr_Col.Item(AV23GXV2));
                  AV17TileName = StringUtil.Lower( AV14ColItem.gxTpr_Tile.gxTpr_Tilename);
                  new prc_logtoserver(context ).execute(  "    "+AV17TileName) ;
                  if ( (AV11ModuleCollection.IndexOf(StringUtil.RTrim( AV17TileName))>0) )
                  {
                     if ( (AV16UserModuleCollection.IndexOf(StringUtil.RTrim( AV17TileName))>0) )
                     {
                        AV19FilteredRow.gxTpr_Col.Add(AV14ColItem, 0);
                     }
                  }
                  else
                  {
                     AV19FilteredRow.gxTpr_Col.Add(AV14ColItem, 0);
                  }
                  AV18Index = (short)(AV18Index+1);
                  AV23GXV2 = (int)(AV23GXV2+1);
               }
            }
            AV12Filtered_SDT_MobilePage.gxTpr_Row.Add(AV19FilteredRow, 0);
            new prc_logtoserver(context ).execute(  AV12Filtered_SDT_MobilePage.gxTpr_Row.ToJSonString(false)) ;
            new prc_logtoserver(context ).execute(  "-------------------------------------------------------------------------") ;
            AV22GXV1 = (int)(AV22GXV1+1);
         }
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
         AV12Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV11ModuleCollection = new GxSimpleCollection<string>();
         P00CH2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00CH2_n554ResidentPackageId = new bool[] {false} ;
         P00CH2_A558ResidentPackageModules = new string[] {""} ;
         P00CH2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00CH2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CH2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A554ResidentPackageId = Guid.Empty;
         A558ResidentPackageModules = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00CH3_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00CH3_n554ResidentPackageId = new bool[] {false} ;
         AV16UserModuleCollection = new GxSimpleCollection<string>();
         AV13RowItem = new SdtSDT_Row(context);
         AV19FilteredRow = new SdtSDT_Row(context);
         AV14ColItem = new SdtSDT_Col(context);
         AV17TileName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_filterpagetiles__default(),
            new Object[][] {
                new Object[] {
               P00CH2_A554ResidentPackageId, P00CH2_n554ResidentPackageId, P00CH2_A558ResidentPackageModules, P00CH2_A62ResidentId, P00CH2_A29LocationId, P00CH2_A11OrganisationId
               }
               , new Object[] {
               P00CH3_A554ResidentPackageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18Index ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private bool n554ResidentPackageId ;
      private string A558ResidentPackageModules ;
      private string AV9UserId ;
      private string AV17TileName ;
      private Guid A554ResidentPackageId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV10SDT_MobilePage ;
      private SdtSDT_MobilePage AV12Filtered_SDT_MobilePage ;
      private GxSimpleCollection<string> AV11ModuleCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CH2_A554ResidentPackageId ;
      private bool[] P00CH2_n554ResidentPackageId ;
      private string[] P00CH2_A558ResidentPackageModules ;
      private Guid[] P00CH2_A62ResidentId ;
      private Guid[] P00CH2_A29LocationId ;
      private Guid[] P00CH2_A11OrganisationId ;
      private Guid[] P00CH3_A554ResidentPackageId ;
      private bool[] P00CH3_n554ResidentPackageId ;
      private GxSimpleCollection<string> AV16UserModuleCollection ;
      private SdtSDT_Row AV13RowItem ;
      private SdtSDT_Row AV19FilteredRow ;
      private SdtSDT_Col AV14ColItem ;
      private SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage ;
   }

   public class prc_filterpagetiles__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CH2;
          prmP00CH2 = new Object[] {
          new ParDef("AV9UserId",GXType.VarChar,40,0)
          };
          Object[] prmP00CH3;
          prmP00CH3 = new Object[] {
          new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00CH2", "SELECT T1.ResidentPackageId, T2.ResidentPackageModules, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentPackage T2 ON T2.ResidentPackageId = T1.ResidentPackageId) WHERE T1.ResidentId = CASE WHEN (:AV9UserId ~ ('[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}')) THEN RTRIM(:AV9UserId) ELSE '00000000-0000-0000-0000-000000000000' END ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CH3", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH3,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
