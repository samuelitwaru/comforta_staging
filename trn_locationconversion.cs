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
   public class trn_locationconversion : GXProcedure
   {
      public trn_locationconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_locationconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
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
         /* Using cursor TRN_LOCATI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A247Trn_ThemeId = TRN_LOCATI2_A247Trn_ThemeId[0];
            n247Trn_ThemeId = TRN_LOCATI2_n247Trn_ThemeId[0];
            A384LocationPhoneNumber = TRN_LOCATI2_A384LocationPhoneNumber[0];
            A383LocationPhoneCode = TRN_LOCATI2_A383LocationPhoneCode[0];
            A359LocationCountry = TRN_LOCATI2_A359LocationCountry[0];
            A341LocationAddressLine2 = TRN_LOCATI2_A341LocationAddressLine2[0];
            A340LocationAddressLine1 = TRN_LOCATI2_A340LocationAddressLine1[0];
            A339LocationZipCode = TRN_LOCATI2_A339LocationZipCode[0];
            A338LocationCity = TRN_LOCATI2_A338LocationCity[0];
            A36LocationDescription = TRN_LOCATI2_A36LocationDescription[0];
            A35LocationPhone = TRN_LOCATI2_A35LocationPhone[0];
            A34LocationEmail = TRN_LOCATI2_A34LocationEmail[0];
            A31LocationName = TRN_LOCATI2_A31LocationName[0];
            A11OrganisationId = TRN_LOCATI2_A11OrganisationId[0];
            A29LocationId = TRN_LOCATI2_A29LocationId[0];
            A40000LocationImage_GXI = TRN_LOCATI2_A40000LocationImage_GXI[0];
            A506LocationImage = TRN_LOCATI2_A506LocationImage[0];
            /*
               INSERT RECORD ON TABLE GXA0006

            */
            AV2LocationId = A29LocationId;
            AV3OrganisationId = A11OrganisationId;
            AV4LocationName = A31LocationName;
            AV5LocationEmail = A34LocationEmail;
            AV6LocationPhone = A35LocationPhone;
            AV7LocationDescription = A36LocationDescription;
            AV8LocationCity = A338LocationCity;
            AV9LocationZipCode = A339LocationZipCode;
            AV10LocationAddressLine1 = A340LocationAddressLine1;
            AV11LocationAddressLine2 = A341LocationAddressLine2;
            AV12LocationCountry = A359LocationCountry;
            AV13LocationPhoneCode = A383LocationPhoneCode;
            AV14LocationPhoneNumber = A384LocationPhoneNumber;
            if ( TRN_LOCATI2_n247Trn_ThemeId[0] )
            {
               AV15Trn_ThemeId = Guid.Empty;
            }
            else
            {
               AV15Trn_ThemeId = A247Trn_ThemeId;
            }
            AV16LocationImage = A506LocationImage;
            AV17LocationImage_GXI = A40000LocationImage_GXI;
            AV17LocationImage_GXI = A40000LocationImage_GXI;
            /* Using cursor TRN_LOCATI3 */
            pr_default.execute(1, new Object[] {AV2LocationId, AV3OrganisationId, AV4LocationName, AV5LocationEmail, AV6LocationPhone, AV7LocationDescription, AV8LocationCity, AV9LocationZipCode, AV10LocationAddressLine1, AV11LocationAddressLine2, AV12LocationCountry, AV13LocationPhoneCode, AV14LocationPhoneNumber, AV15Trn_ThemeId, AV16LocationImage, AV17LocationImage_GXI});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0006");
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
         TRN_LOCATI2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n247Trn_ThemeId = new bool[] {false} ;
         TRN_LOCATI2_A384LocationPhoneNumber = new string[] {""} ;
         TRN_LOCATI2_A383LocationPhoneCode = new string[] {""} ;
         TRN_LOCATI2_A359LocationCountry = new string[] {""} ;
         TRN_LOCATI2_A341LocationAddressLine2 = new string[] {""} ;
         TRN_LOCATI2_A340LocationAddressLine1 = new string[] {""} ;
         TRN_LOCATI2_A339LocationZipCode = new string[] {""} ;
         TRN_LOCATI2_A338LocationCity = new string[] {""} ;
         TRN_LOCATI2_A36LocationDescription = new string[] {""} ;
         TRN_LOCATI2_A35LocationPhone = new string[] {""} ;
         TRN_LOCATI2_A34LocationEmail = new string[] {""} ;
         TRN_LOCATI2_A31LocationName = new string[] {""} ;
         TRN_LOCATI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A40000LocationImage_GXI = new string[] {""} ;
         TRN_LOCATI2_A506LocationImage = new string[] {""} ;
         A247Trn_ThemeId = Guid.Empty;
         A384LocationPhoneNumber = "";
         A383LocationPhoneCode = "";
         A359LocationCountry = "";
         A341LocationAddressLine2 = "";
         A340LocationAddressLine1 = "";
         A339LocationZipCode = "";
         A338LocationCity = "";
         A36LocationDescription = "";
         A35LocationPhone = "";
         A34LocationEmail = "";
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A40000LocationImage_GXI = "";
         A506LocationImage = "";
         AV2LocationId = Guid.Empty;
         AV3OrganisationId = Guid.Empty;
         AV4LocationName = "";
         AV5LocationEmail = "";
         AV6LocationPhone = "";
         AV7LocationDescription = "";
         AV8LocationCity = "";
         AV9LocationZipCode = "";
         AV10LocationAddressLine1 = "";
         AV11LocationAddressLine2 = "";
         AV12LocationCountry = "";
         AV13LocationPhoneCode = "";
         AV14LocationPhoneNumber = "";
         AV15Trn_ThemeId = Guid.Empty;
         AV16LocationImage = "";
         AV17LocationImage_GXI = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_LOCATI2_A247Trn_ThemeId, TRN_LOCATI2_n247Trn_ThemeId, TRN_LOCATI2_A384LocationPhoneNumber, TRN_LOCATI2_A383LocationPhoneCode, TRN_LOCATI2_A359LocationCountry, TRN_LOCATI2_A341LocationAddressLine2, TRN_LOCATI2_A340LocationAddressLine1, TRN_LOCATI2_A339LocationZipCode, TRN_LOCATI2_A338LocationCity, TRN_LOCATI2_A36LocationDescription,
               TRN_LOCATI2_A35LocationPhone, TRN_LOCATI2_A34LocationEmail, TRN_LOCATI2_A31LocationName, TRN_LOCATI2_A11OrganisationId, TRN_LOCATI2_A29LocationId, TRN_LOCATI2_A40000LocationImage_GXI, TRN_LOCATI2_A506LocationImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0006 ;
      private string A35LocationPhone ;
      private string AV6LocationPhone ;
      private string Gx_emsg ;
      private bool n247Trn_ThemeId ;
      private string A36LocationDescription ;
      private string AV7LocationDescription ;
      private string A384LocationPhoneNumber ;
      private string A383LocationPhoneCode ;
      private string A359LocationCountry ;
      private string A341LocationAddressLine2 ;
      private string A340LocationAddressLine1 ;
      private string A339LocationZipCode ;
      private string A338LocationCity ;
      private string A34LocationEmail ;
      private string A31LocationName ;
      private string A40000LocationImage_GXI ;
      private string AV4LocationName ;
      private string AV5LocationEmail ;
      private string AV8LocationCity ;
      private string AV9LocationZipCode ;
      private string AV10LocationAddressLine1 ;
      private string AV11LocationAddressLine2 ;
      private string AV12LocationCountry ;
      private string AV13LocationPhoneCode ;
      private string AV14LocationPhoneNumber ;
      private string AV17LocationImage_GXI ;
      private string A506LocationImage ;
      private string AV16LocationImage ;
      private Guid A247Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private Guid AV15Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_LOCATI2_A247Trn_ThemeId ;
      private bool[] TRN_LOCATI2_n247Trn_ThemeId ;
      private string[] TRN_LOCATI2_A384LocationPhoneNumber ;
      private string[] TRN_LOCATI2_A383LocationPhoneCode ;
      private string[] TRN_LOCATI2_A359LocationCountry ;
      private string[] TRN_LOCATI2_A341LocationAddressLine2 ;
      private string[] TRN_LOCATI2_A340LocationAddressLine1 ;
      private string[] TRN_LOCATI2_A339LocationZipCode ;
      private string[] TRN_LOCATI2_A338LocationCity ;
      private string[] TRN_LOCATI2_A36LocationDescription ;
      private string[] TRN_LOCATI2_A35LocationPhone ;
      private string[] TRN_LOCATI2_A34LocationEmail ;
      private string[] TRN_LOCATI2_A31LocationName ;
      private Guid[] TRN_LOCATI2_A11OrganisationId ;
      private Guid[] TRN_LOCATI2_A29LocationId ;
      private string[] TRN_LOCATI2_A40000LocationImage_GXI ;
      private string[] TRN_LOCATI2_A506LocationImage ;
   }

   public class trn_locationconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_LOCATI2;
          prmTRN_LOCATI2 = new Object[] {
          };
          Object[] prmTRN_LOCATI3;
          prmTRN_LOCATI3 = new Object[] {
          new ParDef("AV2LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4LocationName",GXType.VarChar,100,0) ,
          new ParDef("AV5LocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV6LocationPhone",GXType.Char,20,0) ,
          new ParDef("AV7LocationDescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV8LocationCity",GXType.VarChar,100,0) ,
          new ParDef("AV9LocationZipCode",GXType.VarChar,100,0) ,
          new ParDef("AV10LocationAddressLine1",GXType.VarChar,100,0) ,
          new ParDef("AV11LocationAddressLine2",GXType.VarChar,100,0) ,
          new ParDef("AV12LocationCountry",GXType.VarChar,100,0) ,
          new ParDef("AV13LocationPhoneCode",GXType.VarChar,40,0) ,
          new ParDef("AV14LocationPhoneNumber",GXType.VarChar,9,0) ,
          new ParDef("AV15Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16LocationImage",GXType.Byte,1024,0){InDB=false} ,
          new ParDef("AV17LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=14, Tbl="GXA0006", Fld="LocationImage"}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_LOCATI2", "SELECT Trn_ThemeId, LocationPhoneNumber, LocationPhoneCode, LocationCountry, LocationAddressLine2, LocationAddressLine1, LocationZipCode, LocationCity, LocationDescription, LocationPhone, LocationEmail, LocationName, OrganisationId, LocationId, LocationImage_GXI, LocationImage FROM Trn_Location ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_LOCATI2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_LOCATI3", "INSERT INTO GXA0006(LocationId, OrganisationId, LocationName, LocationEmail, LocationPhone, LocationDescription, LocationCity, LocationZipCode, LocationAddressLine1, LocationAddressLine2, LocationCountry, LocationPhoneCode, LocationPhoneNumber, Trn_ThemeId, LocationImage, LocationImage_GXI) VALUES(:AV2LocationId, :AV3OrganisationId, :AV4LocationName, :AV5LocationEmail, :AV6LocationPhone, :AV7LocationDescription, :AV8LocationCity, :AV9LocationZipCode, :AV10LocationAddressLine1, :AV11LocationAddressLine2, :AV12LocationCountry, :AV13LocationPhoneCode, :AV14LocationPhoneNumber, :AV15Trn_ThemeId, :AV16LocationImage, :AV17LocationImage_GXI)", GxErrorMask.GX_NOMASK,prmTRN_LOCATI3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[13])[0] = rslt.getGuid(13);
                ((Guid[]) buf[14])[0] = rslt.getGuid(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaUri(15);
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(15));
                return;
       }
    }

 }

}
