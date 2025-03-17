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
         Console.WriteLine( context.GetMessage( "Checking that table Trn_Media does NOT contain records.", "") );
         AV3NotFound = 0;
         AV4GXLvl5 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = LTCTLS2_A29LocationId[0];
            A409MediaId = LTCTLS2_A409MediaId[0];
            AV4GXLvl5 = 1;
            AV5GXLvl8 = 0;
            /* Using cursor LTCTLS3 */
            pr_default.execute(1, new Object[] {A29LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = LTCTLS3_A11OrganisationId[0];
               if ( A11OrganisationId == Guid.Empty )
               {
                  AV5GXLvl8 = 1;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV5GXLvl8 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( context.GetMessage( "Fail: Table Trn_Media has records but referenced key value in table Trn_Location does _not_ exist.", "") );
               Console.WriteLine( context.GetMessage( "Recovery: See recovery information for reorganization message rgz0029.", "") );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV4GXLvl5 == 0 )
         {
            Console.WriteLine( context.GetMessage( "Success: Table Trn_Media does NOT have records.", "") );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( context.GetMessage( "Success: Table Trn_Mediahas records but all referenced key values in table Trn_Location exist.", "") );
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
         LTCTLS2_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS2_A409MediaId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A409MediaId = Guid.Empty;
         LTCTLS3_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A29LocationId, LTCTLS2_A409MediaId
               }
               , new Object[] {
               LTCTLS3_A29LocationId, LTCTLS3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private short AV3NotFound ;
      private short AV4GXLvl5 ;
      private short AV5GXLvl8 ;
      private Guid A29LocationId ;
      private Guid A409MediaId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] LTCTLS2_A29LocationId ;
      private Guid[] LTCTLS2_A409MediaId ;
      private Guid[] LTCTLS3_A29LocationId ;
      private Guid[] LTCTLS3_A11OrganisationId ;
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
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT DISTINCT LocationId, MediaId FROM Trn_Media ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
