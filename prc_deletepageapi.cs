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
   public class prc_deletepageapi : GXProcedure
   {
      public prc_deletepageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletepageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_Trn_PageId )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV18UserName, ref  AV17LocationId, ref  AV19OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV18UserName))) )
         {
            cleanup();
            if (true) return;
         }
         /* Optimized DELETE. */
         /* Using cursor P009Z2 */
         pr_default.execute(0, new Object[] {AV13Trn_PageId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
         /* End optimized DELETE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletepageapi",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV18UserName = "";
         AV17LocationId = Guid.Empty;
         AV19OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletepageapi__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18UserName ;
      private Guid AV13Trn_PageId ;
      private Guid AV17LocationId ;
      private Guid AV19OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class prc_deletepageapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Z2;
          prmP009Z2 = new Object[] {
          new ParDef("AV13Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Z2", "DELETE FROM Trn_Page  WHERE Trn_PageId = :AV13Trn_PageId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009Z2)
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
