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
   public class prc_deletecascadeorganisationdynamicform : GXProcedure
   {
      public prc_deletecascadeorganisationdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeorganisationdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationDynamicFormId ,
                           short aP1_WWPFormId ,
                           Guid aP2_OrganisationId )
      {
         this.AV8OrganisationDynamicFormId = aP0_OrganisationDynamicFormId;
         this.AV10WWPFormId = aP1_WWPFormId;
         this.AV9OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_OrganisationDynamicFormId ,
                                 short aP1_WWPFormId ,
                                 Guid aP2_OrganisationId )
      {
         this.AV8OrganisationDynamicFormId = aP0_OrganisationDynamicFormId;
         this.AV10WWPFormId = aP1_WWPFormId;
         this.AV9OrganisationId = aP2_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9OrganisationId ,
                                              AV8OrganisationDynamicFormId ,
                                              AV10WWPFormId ,
                                              A11OrganisationId ,
                                              A542OrganisationDynamicFormId ,
                                              A206WWPFormId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00C12 */
         pr_default.execute(0, new Object[] {AV9OrganisationId, AV8OrganisationDynamicFormId, AV10WWPFormId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = P00C12_A206WWPFormId[0];
            A542OrganisationDynamicFormId = P00C12_A542OrganisationDynamicFormId[0];
            A11OrganisationId = P00C12_A11OrganisationId[0];
            A207WWPFormVersionNumber = P00C12_A207WWPFormVersionNumber[0];
            new prc_deleteorganisationform(context ).execute(  A206WWPFormId,  A207WWPFormVersionNumber,  A542OrganisationDynamicFormId,  A11OrganisationId, out  AV11Messages) ;
            if ( AV11Messages.Count == 0 )
            {
               /* Using cursor P00C13 */
               pr_default.execute(1, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeorganisationdynamicform",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A11OrganisationId = Guid.Empty;
         A542OrganisationDynamicFormId = Guid.Empty;
         P00C12_A206WWPFormId = new short[1] ;
         P00C12_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00C12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C12_A207WWPFormVersionNumber = new short[1] ;
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeorganisationdynamicform__default(),
            new Object[][] {
                new Object[] {
               P00C12_A206WWPFormId, P00C12_A542OrganisationDynamicFormId, P00C12_A11OrganisationId, P00C12_A207WWPFormVersionNumber
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPFormId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private Guid AV8OrganisationDynamicFormId ;
      private Guid AV9OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A542OrganisationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00C12_A206WWPFormId ;
      private Guid[] P00C12_A542OrganisationDynamicFormId ;
      private Guid[] P00C12_A11OrganisationId ;
      private short[] P00C12_A207WWPFormVersionNumber ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
   }

   public class prc_deletecascadeorganisationdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C12( IGxContext context ,
                                             Guid AV9OrganisationId ,
                                             Guid AV8OrganisationDynamicFormId ,
                                             short AV10WWPFormId ,
                                             Guid A11OrganisationId ,
                                             Guid A542OrganisationDynamicFormId ,
                                             short A206WWPFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormId, OrganisationDynamicFormId, OrganisationId, WWPFormVersionNumber FROM Trn_OrganisationDynamicForm";
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV9OrganisationId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV8OrganisationDynamicFormId) )
         {
            AddWhere(sWhereString, "(OrganisationDynamicFormId = :AV8OrganisationDynamicFormId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV10WWPFormId) )
         {
            AddWhere(sWhereString, "(WWPFormId = :AV10WWPFormId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationDynamicFormId, OrganisationId";
         scmdbuf += " FOR UPDATE OF Trn_OrganisationDynamicForm";
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
                     return conditional_P00C12(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (short)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (short)dynConstraints[5] );
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
          Object[] prmP00C13;
          prmP00C13 = new Object[] {
          new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00C12;
          prmP00C12 = new Object[] {
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C12", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C13", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationDynamicForm  WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C13)
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
