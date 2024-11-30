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
   public class trn_organisationconversion : GXProcedure
   {
      public trn_organisationconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_organisationconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized copy (Insert w/Subselect). */
         /* Using cursor TRN_ORGANI2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
         /* Using cursor TRN_ORGANI3 */
         pr_default.execute(1, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End optimized group. */
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         A11OrganisationId = Guid.Empty;
         TRN_ORGANI3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationconversion__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               TRN_ORGANI3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string Gx_emsg ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_ORGANI3_A11OrganisationId ;
   }

   public class trn_organisationconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_ORGANI2;
          prmTRN_ORGANI2 = new Object[] {
          };
          Object[] prmTRN_ORGANI3;
          prmTRN_ORGANI3 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_ORGANI2", "INSERT INTO GXA0003(OrganisationId, OrganisationKvkNumber, OrganisationName, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationTypeId, OrganisationAddressZipCode, OrganisationAddressCity, OrganisationAddressCountry, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationPhoneCode, OrganisationPhoneNumber) SELECT OrganisationId, OrganisationKvkNumber, OrganisationName, OrganisationEmail, OrganisationPhone, SUBSTR(TO_CHAR(CAST(OrganisationVATNumber AS bigint),'99999999999999'), 2) AS GXC1, OrganisationTypeId, OrganisationAddressZipCode, OrganisationAddressCity, OrganisationAddressCountry, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationPhoneCode, OrganisationPhoneNumber  FROM Trn_Organisation", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTRN_ORGANI2)
             ,new CursorDef("TRN_ORGANI3", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_ORGANI3,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
