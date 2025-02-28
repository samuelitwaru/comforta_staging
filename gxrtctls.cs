using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         ExecuteImpl();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         SubmitImpl();
         aP0_Status=this.AV2Status;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV2Status = 0;
         Console.WriteLine( context.GetMessage( "=== Starting run time controls", "") );
         Console.WriteLine( context.GetMessage( "Searching Trn_ThemeIcon for duplicate values on new unique index on Trn_ThemeId, IconName, IconCategory", "") );
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKR012 = false;
            A443IconCategory = LTCTLS2_A443IconCategory[0];
            A262IconName = LTCTLS2_A262IconName[0];
            A247Trn_ThemeId = LTCTLS2_A247Trn_ThemeId[0];
            A261IconId = LTCTLS2_A261IconId[0];
            AV3Count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( LTCTLS2_A247Trn_ThemeId[0] == A247Trn_ThemeId ) && ( StringUtil.StrCmp(LTCTLS2_A262IconName[0], A262IconName) == 0 ) && ( StringUtil.StrCmp(LTCTLS2_A443IconCategory[0], A443IconCategory) == 0 ) )
            {
               BRKR012 = false;
               A261IconId = LTCTLS2_A261IconId[0];
               if ( AV3Count != 0 )
               {
                  AV2Status = 1;
                  Console.WriteLine( context.GetMessage( "Fail: Duplicates found. The first non unique value found follows.", "") );
                  Console.WriteLine( context.GetMessage( "Trn_ThemeId: ", "")+A247Trn_ThemeId );
                  Console.WriteLine( context.GetMessage( "IconName: ", "")+StringUtil.RTrim( A262IconName) );
                  Console.WriteLine( context.GetMessage( "IconCategory: ", "")+StringUtil.RTrim( A443IconCategory) );
                  Console.WriteLine( context.GetMessage( "Recovery: See recovery information for reorganization message rgz0020.", "") );
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV3Count = (int)(AV3Count+1);
               BRKR012 = true;
               pr_default.readNext(0);
            }
            if ( AV2Status != 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKR012 )
            {
               BRKR012 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         if ( AV2Status == 0 )
         {
            Console.WriteLine( context.GetMessage( "Success: No duplicates found for Trn_ThemeId, IconName, IconCategory", "") );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( context.GetMessage( "Searching Trn_ThemeColor for duplicate values on new unique index on Trn_ThemeId, ColorName, ColorCode", "") );
         /* Using cursor LTCTLS3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKR014 = false;
            A251ColorCode = LTCTLS3_A251ColorCode[0];
            A250ColorName = LTCTLS3_A250ColorName[0];
            A247Trn_ThemeId = LTCTLS3_A247Trn_ThemeId[0];
            A249ColorId = LTCTLS3_A249ColorId[0];
            AV3Count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( LTCTLS3_A247Trn_ThemeId[0] == A247Trn_ThemeId ) && ( StringUtil.StrCmp(LTCTLS3_A250ColorName[0], A250ColorName) == 0 ) && ( StringUtil.StrCmp(LTCTLS3_A251ColorCode[0], A251ColorCode) == 0 ) )
            {
               BRKR014 = false;
               A249ColorId = LTCTLS3_A249ColorId[0];
               if ( AV3Count != 0 )
               {
                  AV2Status = 1;
                  Console.WriteLine( context.GetMessage( "Fail: Duplicates found. The first non unique value found follows.", "") );
                  Console.WriteLine( context.GetMessage( "Trn_ThemeId: ", "")+A247Trn_ThemeId );
                  Console.WriteLine( context.GetMessage( "ColorName: ", "")+StringUtil.RTrim( A250ColorName) );
                  Console.WriteLine( context.GetMessage( "ColorCode: ", "")+StringUtil.RTrim( A251ColorCode) );
                  Console.WriteLine( context.GetMessage( "Recovery: See recovery information for reorganization message rgz0020.", "") );
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV3Count = (int)(AV3Count+1);
               BRKR014 = true;
               pr_default.readNext(1);
            }
            if ( AV2Status != 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKR014 )
            {
               BRKR014 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         if ( AV2Status == 0 )
         {
            Console.WriteLine( context.GetMessage( "Success: No duplicates found for Trn_ThemeId, ColorName, ColorCode", "") );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( context.GetMessage( "=== End of run time controls", "") );
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
         LTCTLS2_A443IconCategory = new string[] {""} ;
         LTCTLS2_A262IconName = new string[] {""} ;
         LTCTLS2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         LTCTLS2_A261IconId = new Guid[] {Guid.Empty} ;
         A443IconCategory = "";
         A262IconName = "";
         A247Trn_ThemeId = Guid.Empty;
         A261IconId = Guid.Empty;
         LTCTLS3_A251ColorCode = new string[] {""} ;
         LTCTLS3_A250ColorName = new string[] {""} ;
         LTCTLS3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         LTCTLS3_A249ColorId = new Guid[] {Guid.Empty} ;
         A251ColorCode = "";
         A250ColorName = "";
         A249ColorId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A443IconCategory, LTCTLS2_A262IconName, LTCTLS2_A247Trn_ThemeId, LTCTLS2_A261IconId
               }
               , new Object[] {
               LTCTLS3_A251ColorCode, LTCTLS3_A250ColorName, LTCTLS3_A247Trn_ThemeId, LTCTLS3_A249ColorId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private int AV3Count ;
      private bool BRKR012 ;
      private bool BRKR014 ;
      private string A443IconCategory ;
      private string A262IconName ;
      private string A251ColorCode ;
      private string A250ColorName ;
      private Guid A247Trn_ThemeId ;
      private Guid A261IconId ;
      private Guid A249ColorId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] LTCTLS2_A443IconCategory ;
      private string[] LTCTLS2_A262IconName ;
      private Guid[] LTCTLS2_A247Trn_ThemeId ;
      private Guid[] LTCTLS2_A261IconId ;
      private string[] LTCTLS3_A251ColorCode ;
      private string[] LTCTLS3_A250ColorName ;
      private Guid[] LTCTLS3_A247Trn_ThemeId ;
      private Guid[] LTCTLS3_A249ColorId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          Object[] prmLTCTLS3;
          prmLTCTLS3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT IconCategory, IconName, Trn_ThemeId, IconId FROM Trn_ThemeIcon ORDER BY Trn_ThemeId, IconName, IconCategory ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT ColorCode, ColorName, Trn_ThemeId, ColorId FROM Trn_ThemeColor ORDER BY Trn_ThemeId, ColorName, ColorCode ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
