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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_deleteform : GXProcedure
   {
      public wwp_df_deleteform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_deleteform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_WWPFormId )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P004L2 */
         pr_default.execute(0, new Object[] {A206WWPFormId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P004L3 */
         pr_default.execute(1, new Object[] {A206WWPFormId});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
         /* End optimized DELETE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("workwithplus.dynamicforms.wwp_df_deleteform",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class wwp_df_deleteform__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004L2;
          prmP004L2 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0)
          };
          Object[] prmP004L3;
          prmP004L3 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004L2", "DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004L2)
             ,new CursorDef("P004L3", "DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004L3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
