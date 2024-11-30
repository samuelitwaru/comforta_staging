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
   public class trn_productserviceconversion : GXProcedure
   {
      public trn_productserviceconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_productserviceconversion( IGxContext context )
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
         /* Using cursor TRN_PRODUC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49SupplierAgbId = TRN_PRODUC2_A49SupplierAgbId[0];
            n49SupplierAgbId = TRN_PRODUC2_n49SupplierAgbId[0];
            A42SupplierGenId = TRN_PRODUC2_A42SupplierGenId[0];
            n42SupplierGenId = TRN_PRODUC2_n42SupplierGenId[0];
            A60ProductServiceDescription = TRN_PRODUC2_A60ProductServiceDescription[0];
            A301ProductServiceTileName = TRN_PRODUC2_A301ProductServiceTileName[0];
            A59ProductServiceName = TRN_PRODUC2_A59ProductServiceName[0];
            A11OrganisationId = TRN_PRODUC2_A11OrganisationId[0];
            A29LocationId = TRN_PRODUC2_A29LocationId[0];
            A58ProductServiceId = TRN_PRODUC2_A58ProductServiceId[0];
            A40001ProductServiceImage_GXI = TRN_PRODUC2_A40001ProductServiceImage_GXI[0];
            A61ProductServiceImage = TRN_PRODUC2_A61ProductServiceImage[0];
            /*
               INSERT RECORD ON TABLE GXA0075

            */
            AV2ProductServiceId = A58ProductServiceId;
            AV3LocationId = A29LocationId;
            AV4OrganisationId = A11OrganisationId;
            AV5ProductServiceName = A59ProductServiceName;
            AV6ProductServiceTileName = A301ProductServiceTileName;
            AV7ProductServiceDescription = A60ProductServiceDescription;
            AV8ProductServiceImage = A61ProductServiceImage;
            AV9ProductServiceImage_GXI = A40001ProductServiceImage_GXI;
            AV9ProductServiceImage_GXI = A40001ProductServiceImage_GXI;
            AV10ProductServiceGroup = " ";
            if ( TRN_PRODUC2_n42SupplierGenId[0] )
            {
               AV11SupplierGenId = Guid.Empty;
               nV11SupplierGenId = false;
               nV11SupplierGenId = true;
            }
            else
            {
               AV11SupplierGenId = A42SupplierGenId;
               nV11SupplierGenId = false;
            }
            if ( TRN_PRODUC2_n49SupplierAgbId[0] )
            {
               AV12SupplierAgbId = Guid.Empty;
               nV12SupplierAgbId = false;
               nV12SupplierAgbId = true;
            }
            else
            {
               AV12SupplierAgbId = A49SupplierAgbId;
               nV12SupplierAgbId = false;
            }
            /* Using cursor TRN_PRODUC3 */
            pr_default.execute(1, new Object[] {AV2ProductServiceId, AV3LocationId, AV4OrganisationId, AV5ProductServiceName, AV6ProductServiceTileName, AV7ProductServiceDescription, AV8ProductServiceImage, AV9ProductServiceImage_GXI, AV10ProductServiceGroup, nV11SupplierGenId, AV11SupplierGenId, nV12SupplierAgbId, AV12SupplierAgbId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0075");
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
         TRN_PRODUC2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_n49SupplierAgbId = new bool[] {false} ;
         TRN_PRODUC2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_n42SupplierGenId = new bool[] {false} ;
         TRN_PRODUC2_A60ProductServiceDescription = new string[] {""} ;
         TRN_PRODUC2_A301ProductServiceTileName = new string[] {""} ;
         TRN_PRODUC2_A59ProductServiceName = new string[] {""} ;
         TRN_PRODUC2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_A40001ProductServiceImage_GXI = new string[] {""} ;
         TRN_PRODUC2_A61ProductServiceImage = new string[] {""} ;
         A49SupplierAgbId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A60ProductServiceDescription = "";
         A301ProductServiceTileName = "";
         A59ProductServiceName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A40001ProductServiceImage_GXI = "";
         A61ProductServiceImage = "";
         AV2ProductServiceId = Guid.Empty;
         AV3LocationId = Guid.Empty;
         AV4OrganisationId = Guid.Empty;
         AV5ProductServiceName = "";
         AV6ProductServiceTileName = "";
         AV7ProductServiceDescription = "";
         AV8ProductServiceImage = "";
         AV9ProductServiceImage_GXI = "";
         AV10ProductServiceGroup = "";
         AV11SupplierGenId = Guid.Empty;
         AV12SupplierAgbId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_PRODUC2_A49SupplierAgbId, TRN_PRODUC2_n49SupplierAgbId, TRN_PRODUC2_A42SupplierGenId, TRN_PRODUC2_n42SupplierGenId, TRN_PRODUC2_A60ProductServiceDescription, TRN_PRODUC2_A301ProductServiceTileName, TRN_PRODUC2_A59ProductServiceName, TRN_PRODUC2_A11OrganisationId, TRN_PRODUC2_A29LocationId, TRN_PRODUC2_A58ProductServiceId,
               TRN_PRODUC2_A40001ProductServiceImage_GXI, TRN_PRODUC2_A61ProductServiceImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0075 ;
      private string A301ProductServiceTileName ;
      private string AV6ProductServiceTileName ;
      private string Gx_emsg ;
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private bool nV11SupplierGenId ;
      private bool nV12SupplierAgbId ;
      private string A60ProductServiceDescription ;
      private string AV7ProductServiceDescription ;
      private string A59ProductServiceName ;
      private string A40001ProductServiceImage_GXI ;
      private string AV5ProductServiceName ;
      private string AV9ProductServiceImage_GXI ;
      private string AV10ProductServiceGroup ;
      private string A61ProductServiceImage ;
      private string AV8ProductServiceImage ;
      private Guid A49SupplierAgbId ;
      private Guid A42SupplierGenId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid AV2ProductServiceId ;
      private Guid AV3LocationId ;
      private Guid AV4OrganisationId ;
      private Guid AV11SupplierGenId ;
      private Guid AV12SupplierAgbId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_PRODUC2_A49SupplierAgbId ;
      private bool[] TRN_PRODUC2_n49SupplierAgbId ;
      private Guid[] TRN_PRODUC2_A42SupplierGenId ;
      private bool[] TRN_PRODUC2_n42SupplierGenId ;
      private string[] TRN_PRODUC2_A60ProductServiceDescription ;
      private string[] TRN_PRODUC2_A301ProductServiceTileName ;
      private string[] TRN_PRODUC2_A59ProductServiceName ;
      private Guid[] TRN_PRODUC2_A11OrganisationId ;
      private Guid[] TRN_PRODUC2_A29LocationId ;
      private Guid[] TRN_PRODUC2_A58ProductServiceId ;
      private string[] TRN_PRODUC2_A40001ProductServiceImage_GXI ;
      private string[] TRN_PRODUC2_A61ProductServiceImage ;
   }

   public class trn_productserviceconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_PRODUC2;
          prmTRN_PRODUC2 = new Object[] {
          };
          Object[] prmTRN_PRODUC3;
          prmTRN_PRODUC3 = new Object[] {
          new ParDef("AV2ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV5ProductServiceName",GXType.VarChar,100,0) ,
          new ParDef("AV6ProductServiceTileName",GXType.Char,20,0) ,
          new ParDef("AV7ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV8ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
          new ParDef("AV9ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=6, Tbl="GXA0075", Fld="ProductServiceImage"} ,
          new ParDef("AV10ProductServiceGroup",GXType.VarChar,40,0) ,
          new ParDef("AV11SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV12SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_PRODUC2", "SELECT SupplierAgbId, SupplierGenId, ProductServiceDescription, ProductServiceTileName, ProductServiceName, OrganisationId, LocationId, ProductServiceId, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PRODUC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PRODUC3", "INSERT INTO GXA0075(ProductServiceId, LocationId, OrganisationId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceImage, ProductServiceImage_GXI, ProductServiceGroup, SupplierGenId, SupplierAgbId) VALUES(:AV2ProductServiceId, :AV3LocationId, :AV4OrganisationId, :AV5ProductServiceName, :AV6ProductServiceTileName, :AV7ProductServiceDescription, :AV8ProductServiceImage, :AV9ProductServiceImage_GXI, :AV10ProductServiceGroup, :AV11SupplierGenId, :AV12SupplierAgbId)", GxErrorMask.GX_NOMASK,prmTRN_PRODUC3)
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[7])[0] = rslt.getGuid(6);
                ((Guid[]) buf[8])[0] = rslt.getGuid(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(9));
                return;
       }
    }

 }

}
