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
   public class prc_getpageidbyname : GXProcedure
   {
      public prc_getpageidbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getpageidbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Trn_PageName ,
                           out Guid aP1_Trn_PageId )
      {
         this.AV8Trn_PageName = aP0_Trn_PageName;
         this.AV9Trn_PageId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP1_Trn_PageId=this.AV9Trn_PageId;
      }

      public Guid executeUdp( string aP0_Trn_PageName )
      {
         execute(aP0_Trn_PageName, out aP1_Trn_PageId);
         return AV9Trn_PageId ;
      }

      public void executeSubmit( string aP0_Trn_PageName ,
                                 out Guid aP1_Trn_PageId )
      {
         this.AV8Trn_PageName = aP0_Trn_PageName;
         this.AV9Trn_PageId = Guid.Empty ;
         SubmitImpl();
         aP1_Trn_PageId=this.AV9Trn_PageId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P007V2 */
         pr_default.execute(0, new Object[] {AV8Trn_PageName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A318Trn_PageName = P007V2_A318Trn_PageName[0];
            A310Trn_PageId = P007V2_A310Trn_PageId[0];
            AV9Trn_PageId = A310Trn_PageId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9Trn_PageId = Guid.Empty;
         P007V2_A318Trn_PageName = new string[] {""} ;
         P007V2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getpageidbyname__default(),
            new Object[][] {
                new Object[] {
               P007V2_A318Trn_PageName, P007V2_A310Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8Trn_PageName ;
      private string A318Trn_PageName ;
      private Guid AV9Trn_PageId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007V2_A318Trn_PageName ;
      private Guid[] P007V2_A310Trn_PageId ;
      private Guid aP1_Trn_PageId ;
   }

   public class prc_getpageidbyname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007V2;
          prmP007V2 = new Object[] {
          new ParDef("AV8Trn_PageName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007V2", "SELECT Trn_PageName, Trn_PageId FROM Trn_Page WHERE Trn_PageName = ( :AV8Trn_PageName) ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007V2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
