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
   public class prc_generaldynamicform : GXProcedure
   {
      public prc_generaldynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_generaldynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_GeneralDynamicFormIds )
      {
         this.AV10GeneralDynamicFormIds = new GxSimpleCollection<short>() ;
         initialize();
         ExecuteImpl();
         aP0_GeneralDynamicFormIds=this.AV10GeneralDynamicFormIds;
      }

      public GxSimpleCollection<short> executeUdp( )
      {
         execute(out aP0_GeneralDynamicFormIds);
         return AV10GeneralDynamicFormIds ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_GeneralDynamicFormIds )
      {
         this.AV10GeneralDynamicFormIds = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP0_GeneralDynamicFormIds=this.AV10GeneralDynamicFormIds;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8LocationDynamicFormIds = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV10GeneralDynamicFormIds = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P00812 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = P00812_A206WWPFormId[0];
            A395LocationDynamicFormId = P00812_A395LocationDynamicFormId[0];
            A11OrganisationId = P00812_A11OrganisationId[0];
            A29LocationId = P00812_A29LocationId[0];
            AV8LocationDynamicFormIds.Add(A206WWPFormId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A206WWPFormId ,
                                              AV8LocationDynamicFormIds } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00813 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A206WWPFormId = P00813_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00813_A207WWPFormVersionNumber[0];
            AV10GeneralDynamicFormIds.Add(A206WWPFormId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV10GeneralDynamicFormIds = new GxSimpleCollection<short>();
         AV8LocationDynamicFormIds = new GxSimpleCollection<short>();
         P00812_A206WWPFormId = new short[1] ;
         P00812_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00812_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00812_A29LocationId = new Guid[] {Guid.Empty} ;
         A395LocationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00813_A206WWPFormId = new short[1] ;
         P00813_A207WWPFormVersionNumber = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_generaldynamicform__default(),
            new Object[][] {
                new Object[] {
               P00812_A206WWPFormId, P00812_A395LocationDynamicFormId, P00812_A11OrganisationId, P00812_A29LocationId
               }
               , new Object[] {
               P00813_A206WWPFormId, P00813_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private Guid A395LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV10GeneralDynamicFormIds ;
      private GxSimpleCollection<short> AV8LocationDynamicFormIds ;
      private IDataStoreProvider pr_default ;
      private short[] P00812_A206WWPFormId ;
      private Guid[] P00812_A395LocationDynamicFormId ;
      private Guid[] P00812_A11OrganisationId ;
      private Guid[] P00812_A29LocationId ;
      private short[] P00813_A206WWPFormId ;
      private short[] P00813_A207WWPFormVersionNumber ;
      private GxSimpleCollection<short> aP0_GeneralDynamicFormIds ;
   }

   public class prc_generaldynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00813( IGxContext context ,
                                             short A206WWPFormId ,
                                             GxSimpleCollection<short> AV8LocationDynamicFormIds )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8LocationDynamicFormIds, "WWPFormId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormId, WWPFormVersionNumber";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00813(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00812;
          prmP00812 = new Object[] {
          };
          Object[] prmP00813;
          prmP00813 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00812", "SELECT WWPFormId, LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm ORDER BY LocationDynamicFormId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00812,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00813", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00813,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
