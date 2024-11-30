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
   public class trn_receptionistconversion : GXProcedure
   {
      public trn_receptionistconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_receptionistconversion( IGxContext context )
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
         /* Using cursor TRN_RECEPT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A95ReceptionistGAMGUID = TRN_RECEPT2_A95ReceptionistGAMGUID[0];
            A94ReceptionistPhone = TRN_RECEPT2_A94ReceptionistPhone[0];
            A93ReceptionistEmail = TRN_RECEPT2_A93ReceptionistEmail[0];
            A92ReceptionistInitials = TRN_RECEPT2_A92ReceptionistInitials[0];
            A91ReceptionistLastName = TRN_RECEPT2_A91ReceptionistLastName[0];
            A90ReceptionistGivenName = TRN_RECEPT2_A90ReceptionistGivenName[0];
            A29LocationId = TRN_RECEPT2_A29LocationId[0];
            A89ReceptionistId = TRN_RECEPT2_A89ReceptionistId[0];
            /*
               INSERT RECORD ON TABLE GXA0074

            */
            AV2ReceptionistId = A89ReceptionistId;
            AV3OrganisationId = Guid.Empty;
            AV4LocationId = A29LocationId;
            AV5ReceptionistGivenName = A90ReceptionistGivenName;
            AV6ReceptionistLastName = A91ReceptionistLastName;
            AV7ReceptionistInitials = A92ReceptionistInitials;
            AV8ReceptionistEmail = A93ReceptionistEmail;
            AV9ReceptionistPhone = A94ReceptionistPhone;
            AV10ReceptionistGAMGUID = A95ReceptionistGAMGUID;
            /* Using cursor TRN_RECEPT3 */
            pr_default.execute(1, new Object[] {AV2ReceptionistId, AV3OrganisationId, AV4LocationId, AV5ReceptionistGivenName, AV6ReceptionistLastName, AV7ReceptionistInitials, AV8ReceptionistEmail, AV9ReceptionistPhone, AV10ReceptionistGAMGUID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0074");
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
         TRN_RECEPT2_A95ReceptionistGAMGUID = new string[] {""} ;
         TRN_RECEPT2_A94ReceptionistPhone = new string[] {""} ;
         TRN_RECEPT2_A93ReceptionistEmail = new string[] {""} ;
         TRN_RECEPT2_A92ReceptionistInitials = new string[] {""} ;
         TRN_RECEPT2_A91ReceptionistLastName = new string[] {""} ;
         TRN_RECEPT2_A90ReceptionistGivenName = new string[] {""} ;
         TRN_RECEPT2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_RECEPT2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A95ReceptionistGAMGUID = "";
         A94ReceptionistPhone = "";
         A93ReceptionistEmail = "";
         A92ReceptionistInitials = "";
         A91ReceptionistLastName = "";
         A90ReceptionistGivenName = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV2ReceptionistId = Guid.Empty;
         AV3OrganisationId = Guid.Empty;
         AV4LocationId = Guid.Empty;
         AV5ReceptionistGivenName = "";
         AV6ReceptionistLastName = "";
         AV7ReceptionistInitials = "";
         AV8ReceptionistEmail = "";
         AV9ReceptionistPhone = "";
         AV10ReceptionistGAMGUID = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_RECEPT2_A95ReceptionistGAMGUID, TRN_RECEPT2_A94ReceptionistPhone, TRN_RECEPT2_A93ReceptionistEmail, TRN_RECEPT2_A92ReceptionistInitials, TRN_RECEPT2_A91ReceptionistLastName, TRN_RECEPT2_A90ReceptionistGivenName, TRN_RECEPT2_A29LocationId, TRN_RECEPT2_A89ReceptionistId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0074 ;
      private string A94ReceptionistPhone ;
      private string A92ReceptionistInitials ;
      private string AV7ReceptionistInitials ;
      private string AV9ReceptionistPhone ;
      private string Gx_emsg ;
      private string A95ReceptionistGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A91ReceptionistLastName ;
      private string A90ReceptionistGivenName ;
      private string AV5ReceptionistGivenName ;
      private string AV6ReceptionistLastName ;
      private string AV8ReceptionistEmail ;
      private string AV10ReceptionistGAMGUID ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid AV2ReceptionistId ;
      private Guid AV3OrganisationId ;
      private Guid AV4LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TRN_RECEPT2_A95ReceptionistGAMGUID ;
      private string[] TRN_RECEPT2_A94ReceptionistPhone ;
      private string[] TRN_RECEPT2_A93ReceptionistEmail ;
      private string[] TRN_RECEPT2_A92ReceptionistInitials ;
      private string[] TRN_RECEPT2_A91ReceptionistLastName ;
      private string[] TRN_RECEPT2_A90ReceptionistGivenName ;
      private Guid[] TRN_RECEPT2_A29LocationId ;
      private Guid[] TRN_RECEPT2_A89ReceptionistId ;
   }

   public class trn_receptionistconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_RECEPT2;
          prmTRN_RECEPT2 = new Object[] {
          };
          Object[] prmTRN_RECEPT3;
          prmTRN_RECEPT3 = new Object[] {
          new ParDef("AV2ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV5ReceptionistGivenName",GXType.VarChar,100,0) ,
          new ParDef("AV6ReceptionistLastName",GXType.VarChar,100,0) ,
          new ParDef("AV7ReceptionistInitials",GXType.Char,20,0) ,
          new ParDef("AV8ReceptionistEmail",GXType.VarChar,100,0) ,
          new ParDef("AV9ReceptionistPhone",GXType.Char,20,0) ,
          new ParDef("AV10ReceptionistGAMGUID",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_RECEPT2", "SELECT ReceptionistGAMGUID, ReceptionistPhone, ReceptionistEmail, ReceptionistInitials, ReceptionistLastName, ReceptionistGivenName, LocationId, ReceptionistId FROM Trn_Receptionist ORDER BY ReceptionistId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_RECEPT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_RECEPT3", "INSERT INTO GXA0074(ReceptionistId, OrganisationId, LocationId, ReceptionistGivenName, ReceptionistLastName, ReceptionistInitials, ReceptionistEmail, ReceptionistPhone, ReceptionistGAMGUID) VALUES(:AV2ReceptionistId, :AV3OrganisationId, :AV4LocationId, :AV5ReceptionistGivenName, :AV6ReceptionistLastName, :AV7ReceptionistInitials, :AV8ReceptionistEmail, :AV9ReceptionistPhone, :AV10ReceptionistGAMGUID)", GxErrorMask.GX_NOMASK,prmTRN_RECEPT3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
