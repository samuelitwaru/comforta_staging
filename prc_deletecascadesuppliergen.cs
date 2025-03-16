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
   public class prc_deletecascadesuppliergen : GXProcedure
   {
      public prc_deletecascadesuppliergen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadesuppliergen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierGenId ,
                           Guid aP1_OrganisationId )
      {
         this.AV9SupplierGenId = aP0_SupplierGenId;
         this.AV8OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_SupplierGenId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV9SupplierGenId = aP0_SupplierGenId;
         this.AV8OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9SupplierGenId ,
                                              AV8OrganisationId ,
                                              A42SupplierGenId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00C52 */
         pr_default.execute(0, new Object[] {AV9SupplierGenId, AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00C52_A11OrganisationId[0];
            n11OrganisationId = P00C52_n11OrganisationId[0];
            A42SupplierGenId = P00C52_A42SupplierGenId[0];
            new prc_deletecascadeproductservice(context ).execute(  Guid.Empty,  A42SupplierGenId,  Guid.Empty,  A11OrganisationId) ;
            /* Using cursor P00C53 */
            pr_default.execute(1, new Object[] {A42SupplierGenId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadesuppliergen",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A42SupplierGenId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00C52_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C52_n11OrganisationId = new bool[] {false} ;
         P00C52_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadesuppliergen__default(),
            new Object[][] {
                new Object[] {
               P00C52_A11OrganisationId, P00C52_n11OrganisationId, P00C52_A42SupplierGenId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n11OrganisationId ;
      private Guid AV9SupplierGenId ;
      private Guid AV8OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C52_A11OrganisationId ;
      private bool[] P00C52_n11OrganisationId ;
      private Guid[] P00C52_A42SupplierGenId ;
   }

   public class prc_deletecascadesuppliergen__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C52( IGxContext context ,
                                             Guid AV9SupplierGenId ,
                                             Guid AV8OrganisationId ,
                                             Guid A42SupplierGenId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, SupplierGenId FROM Trn_SupplierGen";
         if ( ! (Guid.Empty==AV9SupplierGenId) )
         {
            AddWhere(sWhereString, "(SupplierGenId = :AV9SupplierGenId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV8OrganisationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenId";
         scmdbuf += " FOR UPDATE OF Trn_SupplierGen";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00C52(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C53;
          prmP00C53 = new Object[] {
          new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00C52;
          prmP00C52 = new Object[] {
          new ParDef("AV9SupplierGenId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C52", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C52,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C53", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C53)
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
