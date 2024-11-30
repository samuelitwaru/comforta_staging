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
   public class trn_amenityconversion : GXProcedure
   {
      public trn_amenityconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_amenityconversion( IGxContext context )
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
         /* Using cursor TRN_AMENIT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41AmenityDescription = TRN_AMENIT2_A41AmenityDescription[0];
            A40AmenityName = TRN_AMENIT2_A40AmenityName[0];
            A29LocationId = TRN_AMENIT2_A29LocationId[0];
            A39AmenityId = TRN_AMENIT2_A39AmenityId[0];
            /*
               INSERT RECORD ON TABLE GXA0073

            */
            AV2AmenityId = A39AmenityId;
            AV3LocationId = A29LocationId;
            AV4OrganisationId = Guid.Empty;
            AV5AmenityName = A40AmenityName;
            AV6AmenityDescription = A41AmenityDescription;
            /* Using cursor TRN_AMENIT3 */
            pr_default.execute(1, new Object[] {AV2AmenityId, AV3LocationId, AV4OrganisationId, AV5AmenityName, AV6AmenityDescription});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0073");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TRN_AMENIT2_A41AmenityDescription = new string[] {""} ;
         TRN_AMENIT2_A40AmenityName = new string[] {""} ;
         TRN_AMENIT2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_AMENIT2_A39AmenityId = new Guid[] {Guid.Empty} ;
         A41AmenityDescription = "";
         A40AmenityName = "";
         A29LocationId = Guid.Empty;
         A39AmenityId = Guid.Empty;
         AV2AmenityId = Guid.Empty;
         AV3LocationId = Guid.Empty;
         AV4OrganisationId = Guid.Empty;
         AV5AmenityName = "";
         AV6AmenityDescription = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_amenityconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_AMENIT2_A41AmenityDescription, TRN_AMENIT2_A40AmenityName, TRN_AMENIT2_A29LocationId, TRN_AMENIT2_A39AmenityId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0073 ;
      private string Gx_emsg ;
      private string A41AmenityDescription ;
      private string AV6AmenityDescription ;
      private string A40AmenityName ;
      private string AV5AmenityName ;
      private Guid A29LocationId ;
      private Guid A39AmenityId ;
      private Guid AV2AmenityId ;
      private Guid AV3LocationId ;
      private Guid AV4OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TRN_AMENIT2_A41AmenityDescription ;
      private string[] TRN_AMENIT2_A40AmenityName ;
      private Guid[] TRN_AMENIT2_A29LocationId ;
      private Guid[] TRN_AMENIT2_A39AmenityId ;
   }

   public class trn_amenityconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmTRN_AMENIT2;
          prmTRN_AMENIT2 = new Object[] {
          };
          Object[] prmTRN_AMENIT3;
          prmTRN_AMENIT3 = new Object[] {
          new ParDef("AV2AmenityId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV5AmenityName",GXType.VarChar,100,0) ,
          new ParDef("AV6AmenityDescription",GXType.LongVarChar,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_AMENIT2", "SELECT AmenityDescription, AmenityName, LocationId, AmenityId FROM Trn_Amenity ORDER BY AmenityId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_AMENIT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_AMENIT3", "INSERT INTO GXA0073(AmenityId, LocationId, OrganisationId, AmenityName, AmenityDescription) VALUES(:AV2AmenityId, :AV3LocationId, :AV4OrganisationId, :AV5AmenityName, :AV6AmenityDescription)", GxErrorMask.GX_NOMASK,prmTRN_AMENIT3)
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
