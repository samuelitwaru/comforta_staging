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
   public class prc_deletecascaderesident : GXProcedure
   {
      public prc_deletecascaderesident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascaderesident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.AV11ResidentId = aP0_ResidentId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ResidentId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId )
      {
         this.AV11ResidentId = aP0_ResidentId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9LocationId ,
                                              AV10OrganisationId ,
                                              AV11ResidentId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A62ResidentId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00CB2 */
         pr_default.execute(0, new Object[] {AV9LocationId, AV10OrganisationId, AV11ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A62ResidentId = P00CB2_A62ResidentId[0];
            A11OrganisationId = P00CB2_A11OrganisationId[0];
            A29LocationId = P00CB2_A29LocationId[0];
            A71ResidentGUID = P00CB2_A71ResidentGUID[0];
            new prc_deletegamuseraccount(context ).execute(  A71ResidentGUID, out  AV8GAMErrorResponse) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8GAMErrorResponse)) )
            {
               /* Using cursor P00CB3 */
               pr_default.execute(1, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascaderesident",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         P00CB2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00CB2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CB2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CB2_A71ResidentGUID = new string[] {""} ;
         A71ResidentGUID = "";
         AV8GAMErrorResponse = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascaderesident__default(),
            new Object[][] {
                new Object[] {
               P00CB2_A62ResidentId, P00CB2_A11OrganisationId, P00CB2_A29LocationId, P00CB2_A71ResidentGUID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8GAMErrorResponse ;
      private string A71ResidentGUID ;
      private Guid AV11ResidentId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CB2_A62ResidentId ;
      private Guid[] P00CB2_A11OrganisationId ;
      private Guid[] P00CB2_A29LocationId ;
      private string[] P00CB2_A71ResidentGUID ;
   }

   public class prc_deletecascaderesident__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CB2( IGxContext context ,
                                             Guid AV9LocationId ,
                                             Guid AV10OrganisationId ,
                                             Guid AV11ResidentId ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid A62ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ResidentId, OrganisationId, LocationId, ResidentGUID FROM Trn_Resident";
         if ( ! (Guid.Empty==AV9LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV9LocationId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV10OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV10OrganisationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Guid.Empty==AV11ResidentId) )
         {
            AddWhere(sWhereString, "(ResidentId = :AV11ResidentId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResidentId, LocationId, OrganisationId";
         scmdbuf += " FOR UPDATE OF Trn_Resident";
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
                     return conditional_P00CB2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
          Object[] prmP00CB3;
          prmP00CB3 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00CB2;
          prmP00CB2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11ResidentId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CB2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CB3", "SAVEPOINT gxupdate;DELETE FROM Trn_Resident  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB3)
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
