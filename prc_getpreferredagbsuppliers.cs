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
   public class prc_getpreferredagbsuppliers : GXProcedure
   {
      public prc_getpreferredagbsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getpreferredagbsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GxSimpleCollection<Guid> aP0_PreferredSuppliers )
      {
         this.AV9PreferredSuppliers = aP0_PreferredSuppliers;
         initialize();
         ExecuteImpl();
         aP0_PreferredSuppliers=this.AV9PreferredSuppliers;
      }

      public GxSimpleCollection<Guid> executeUdp( )
      {
         execute(ref aP0_PreferredSuppliers);
         return AV9PreferredSuppliers ;
      }

      public void executeSubmit( ref GxSimpleCollection<Guid> aP0_PreferredSuppliers )
      {
         this.AV9PreferredSuppliers = aP0_PreferredSuppliers;
         SubmitImpl();
         aP0_PreferredSuppliers=this.AV9PreferredSuppliers;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P008K2 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A430PreferredAgbOrganisationId = P008K2_A430PreferredAgbOrganisationId[0];
            A425PreferredSupplierAgbId = P008K2_A425PreferredSupplierAgbId[0];
            A428PreferredAgbSupplierId = P008K2_A428PreferredAgbSupplierId[0];
            AV9PreferredSuppliers.Add(A425PreferredSupplierAgbId, 0);
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
         AV11Udparg1 = Guid.Empty;
         P008K2_A430PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         P008K2_A425PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         P008K2_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         A430PreferredAgbOrganisationId = Guid.Empty;
         A425PreferredSupplierAgbId = Guid.Empty;
         A428PreferredAgbSupplierId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getpreferredagbsuppliers__default(),
            new Object[][] {
                new Object[] {
               P008K2_A430PreferredAgbOrganisationId, P008K2_A425PreferredSupplierAgbId, P008K2_A428PreferredAgbSupplierId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV11Udparg1 ;
      private Guid A430PreferredAgbOrganisationId ;
      private Guid A425PreferredSupplierAgbId ;
      private Guid A428PreferredAgbSupplierId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV9PreferredSuppliers ;
      private GxSimpleCollection<Guid> aP0_PreferredSuppliers ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008K2_A430PreferredAgbOrganisationId ;
      private Guid[] P008K2_A425PreferredSupplierAgbId ;
      private Guid[] P008K2_A428PreferredAgbSupplierId ;
   }

   public class prc_getpreferredagbsuppliers__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008K2;
          prmP008K2 = new Object[] {
          new ParDef("AV11Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008K2", "SELECT PreferredAgbOrganisationId, PreferredSupplierAgbId, PreferredAgbSupplierId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbOrganisationId = :AV11Udparg1 ORDER BY PreferredAgbSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
