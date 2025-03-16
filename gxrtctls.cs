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
         Console.WriteLine( context.GetMessage( "Searching Trn_ThemeCtaColor for duplicate values on new unique index on Trn_ThemeId, CtaColorName", "") );
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKR012 = false;
            A564CtaColorName = LTCTLS2_A564CtaColorName[0];
            A247Trn_ThemeId = LTCTLS2_A247Trn_ThemeId[0];
            A563CtaColorId = LTCTLS2_A563CtaColorId[0];
            AV3Count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( LTCTLS2_A247Trn_ThemeId[0] == A247Trn_ThemeId ) && ( StringUtil.StrCmp(LTCTLS2_A564CtaColorName[0], A564CtaColorName) == 0 ) )
            {
               BRKR012 = false;
               A563CtaColorId = LTCTLS2_A563CtaColorId[0];
               if ( AV3Count != 0 )
               {
                  AV2Status = 1;
                  Console.WriteLine( context.GetMessage( "Fail: Duplicates found. The first non unique value found follows.", "") );
                  Console.WriteLine( context.GetMessage( "Trn_ThemeId: ", "")+A247Trn_ThemeId );
                  Console.WriteLine( context.GetMessage( "CtaColorName: ", "")+StringUtil.RTrim( A564CtaColorName) );
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
            Console.WriteLine( context.GetMessage( "Success: No duplicates found for Trn_ThemeId, CtaColorName", "") );
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
         LTCTLS2_A564CtaColorName = new string[] {""} ;
         LTCTLS2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         LTCTLS2_A563CtaColorId = new Guid[] {Guid.Empty} ;
         A564CtaColorName = "";
         A247Trn_ThemeId = Guid.Empty;
         A563CtaColorId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A564CtaColorName, LTCTLS2_A247Trn_ThemeId, LTCTLS2_A563CtaColorId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private int AV3Count ;
      private bool BRKR012 ;
      private string A564CtaColorName ;
      private Guid A247Trn_ThemeId ;
      private Guid A563CtaColorId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] LTCTLS2_A564CtaColorName ;
      private Guid[] LTCTLS2_A247Trn_ThemeId ;
      private Guid[] LTCTLS2_A563CtaColorId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT CtaColorName, Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor ORDER BY Trn_ThemeId, CtaColorName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
