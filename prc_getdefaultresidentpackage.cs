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
   public class prc_getdefaultresidentpackage : GXProcedure
   {
      public prc_getdefaultresidentpackage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdefaultresidentpackage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           out Guid aP1_ResidentPackageId ,
                           out string aP2_ResidentPackageName )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10ResidentPackageId = Guid.Empty ;
         this.AV11ResidentPackageName = "" ;
         initialize();
         ExecuteImpl();
         aP1_ResidentPackageId=this.AV10ResidentPackageId;
         aP2_ResidentPackageName=this.AV11ResidentPackageName;
      }

      public string executeUdp( Guid aP0_LocationId ,
                                out Guid aP1_ResidentPackageId )
      {
         execute(aP0_LocationId, out aP1_ResidentPackageId, out aP2_ResidentPackageName);
         return AV11ResidentPackageName ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out Guid aP1_ResidentPackageId ,
                                 out string aP2_ResidentPackageName )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10ResidentPackageId = Guid.Empty ;
         this.AV11ResidentPackageName = "" ;
         SubmitImpl();
         aP1_ResidentPackageId=this.AV10ResidentPackageId;
         aP2_ResidentPackageName=this.AV11ResidentPackageName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BM2 */
         pr_default.execute(0, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A559ResidentPackageDefault = P00BM2_A559ResidentPackageDefault[0];
            A555SG_LocationId = P00BM2_A555SG_LocationId[0];
            A554ResidentPackageId = P00BM2_A554ResidentPackageId[0];
            A557ResidentPackageName = P00BM2_A557ResidentPackageName[0];
            AV10ResidentPackageId = A554ResidentPackageId;
            AV11ResidentPackageName = A557ResidentPackageName;
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
         AV10ResidentPackageId = Guid.Empty;
         AV11ResidentPackageName = "";
         P00BM2_A559ResidentPackageDefault = new bool[] {false} ;
         P00BM2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00BM2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00BM2_A557ResidentPackageName = new string[] {""} ;
         A555SG_LocationId = Guid.Empty;
         A554ResidentPackageId = Guid.Empty;
         A557ResidentPackageName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdefaultresidentpackage__default(),
            new Object[][] {
                new Object[] {
               P00BM2_A559ResidentPackageDefault, P00BM2_A555SG_LocationId, P00BM2_A554ResidentPackageId, P00BM2_A557ResidentPackageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A559ResidentPackageDefault ;
      private string AV11ResidentPackageName ;
      private string A557ResidentPackageName ;
      private Guid AV9LocationId ;
      private Guid AV10ResidentPackageId ;
      private Guid A555SG_LocationId ;
      private Guid A554ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00BM2_A559ResidentPackageDefault ;
      private Guid[] P00BM2_A555SG_LocationId ;
      private Guid[] P00BM2_A554ResidentPackageId ;
      private string[] P00BM2_A557ResidentPackageName ;
      private Guid aP1_ResidentPackageId ;
      private string aP2_ResidentPackageName ;
   }

   public class prc_getdefaultresidentpackage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BM2;
          prmP00BM2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BM2", "SELECT ResidentPackageDefault, SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE (SG_LocationId = :AV9LocationId) AND (ResidentPackageDefault = TRUE) ORDER BY SG_LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
