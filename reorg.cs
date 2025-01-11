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
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
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

      protected override void ExecutePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeTrn_SupplierGen( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierGen */
         cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD SupplierGenEmail VARCHAR(100) NOT NULL DEFAULT '' "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_SupplierGen ALTER COLUMN SupplierGenEmail DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERGEN ON Trn_SupplierGen (SupplierGenCompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_SUPPLIERGEN "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERGEN ON Trn_SupplierGen (SupplierGenCompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_CallToAction( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_CallToAction */
         cmdBuffer=" UPDATE Trn_CallToAction SET CallToActionPhoneNumber = SUBSTR(CallToActionPhoneNumber, 1, 9) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_CallToAction ALTER COLUMN CallToActionPhoneNumber TYPE VARCHAR(9)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_ProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ProductService */
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_PRODUCTSERVICE ON Trn_ProductService (ProductServiceName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_PRODUCTSERVICE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_PRODUCTSERVICE ON Trn_ProductService (ProductServiceName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_Receptionist( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Receptionist */
         try
         {
            cmdBuffer=" CREATE INDEX ORGANISATIONINDEX ON Trn_Receptionist (OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ORGANISATIONINDEX "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ORGANISATIONINDEX ON Trn_Receptionist (OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_Resident( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Resident */
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_RESIDENT ON Trn_Resident (OrganisationId ,LocationId ,ResidentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_RESIDENT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_RESIDENT ON Trn_Resident (OrganisationId ,LocationId ,ResidentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_SupplierAGB( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierAGB */
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERAGB ON Trn_SupplierAGB (SupplierAgbName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_SUPPLIERAGB "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERAGB ON Trn_SupplierAGB (SupplierAgbName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_Location( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Location */
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_LOCATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_Organisation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Organisation */
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_ORGANISATION ON Trn_Organisation (OrganisationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_ORGANISATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_ORGANISATION ON Trn_Organisation (OrganisationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            Trn_SupplierGenCount = P00012_ATrn_SupplierGenCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Trn_SupplierGen" ,  Trn_SupplierGenCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            Trn_CallToActionCount = P00023_ATrn_CallToActionCount[0];
            pr_default.close(1);
            PrintRecordCount ( "Trn_CallToAction" ,  Trn_CallToActionCount );
            /* Using cursor P00034 */
            pr_default.execute(2);
            Trn_ProductServiceCount = P00034_ATrn_ProductServiceCount[0];
            pr_default.close(2);
            PrintRecordCount ( "Trn_ProductService" ,  Trn_ProductServiceCount );
            /* Using cursor P00045 */
            pr_default.execute(3);
            Trn_ReceptionistCount = P00045_ATrn_ReceptionistCount[0];
            pr_default.close(3);
            PrintRecordCount ( "Trn_Receptionist" ,  Trn_ReceptionistCount );
            /* Using cursor P00056 */
            pr_default.execute(4);
            Trn_ResidentCount = P00056_ATrn_ResidentCount[0];
            pr_default.close(4);
            PrintRecordCount ( "Trn_Resident" ,  Trn_ResidentCount );
            /* Using cursor P00067 */
            pr_default.execute(5);
            Trn_SupplierAGBCount = P00067_ATrn_SupplierAGBCount[0];
            pr_default.close(5);
            PrintRecordCount ( "Trn_SupplierAGB" ,  Trn_SupplierAGBCount );
            /* Using cursor P00078 */
            pr_default.execute(6);
            Trn_LocationCount = P00078_ATrn_LocationCount[0];
            pr_default.close(6);
            PrintRecordCount ( "Trn_Location" ,  Trn_LocationCount );
            /* Using cursor P00089 */
            pr_default.execute(7);
            Trn_OrganisationCount = P00089_ATrn_OrganisationCount[0];
            pr_default.close(7);
            PrintRecordCount ( "Trn_Organisation" ,  Trn_OrganisationCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( ColumnExist("Trn_SupplierGen",sSchemaVar,"SupplierGenEmail") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"SupplierGenEmail", "Trn_SupplierGen"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P000910 */
         pr_default.execute(8, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(8) != 101) )
         {
            tablename = P000910_Atablename[0];
            ntablename = P000910_ntablename[0];
            schemaname = P000910_Aschemaname[0];
            nschemaname = P000910_nschemaname[0];
            columnname = P000910_Acolumnname[0];
            ncolumnname = P000910_ncolumnname[0];
            attrelid = P000910_Aattrelid[0];
            nattrelid = P000910_nattrelid[0];
            oid = P000910_Aoid[0];
            noid = P000910_noid[0];
            relname = P000910_Arelname[0];
            nrelname = P000910_nrelname[0];
            result = true;
            pr_default.readNext(8);
         }
         pr_default.close(8);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeTrn_CallToAction" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "ReorganizeTrn_ProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "ReorganizeTrn_Receptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "ReorganizeTrn_Resident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "ReorganizeTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "ReorganizeTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "ReorganizeTrn_Organisation" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_SupplierGen", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_CallToAction", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_ProductService", ""}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Receptionist", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Resident", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_SupplierAGB", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Location", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Organisation", ""}) );
      }

      private void SetPrecedenceris( )
      {
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         P00012_ATrn_SupplierGenCount = new int[1] ;
         P00023_ATrn_CallToActionCount = new int[1] ;
         P00034_ATrn_ProductServiceCount = new int[1] ;
         P00045_ATrn_ReceptionistCount = new int[1] ;
         P00056_ATrn_ResidentCount = new int[1] ;
         P00067_ATrn_SupplierAGBCount = new int[1] ;
         P00078_ATrn_LocationCount = new int[1] ;
         P00089_ATrn_OrganisationCount = new int[1] ;
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         sMyColumnName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         columnname = "";
         ncolumnname = false;
         attrelid = "";
         nattrelid = false;
         oid = "";
         noid = false;
         relname = "";
         nrelname = false;
         P000910_Atablename = new string[] {""} ;
         P000910_ntablename = new bool[] {false} ;
         P000910_Aschemaname = new string[] {""} ;
         P000910_nschemaname = new bool[] {false} ;
         P000910_Acolumnname = new string[] {""} ;
         P000910_ncolumnname = new bool[] {false} ;
         P000910_Aattrelid = new string[] {""} ;
         P000910_nattrelid = new bool[] {false} ;
         P000910_Aoid = new string[] {""} ;
         P000910_noid = new bool[] {false} ;
         P000910_Arelname = new string[] {""} ;
         P000910_nrelname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_SupplierGenCount
               }
               , new Object[] {
               P00023_ATrn_CallToActionCount
               }
               , new Object[] {
               P00034_ATrn_ProductServiceCount
               }
               , new Object[] {
               P00045_ATrn_ReceptionistCount
               }
               , new Object[] {
               P00056_ATrn_ResidentCount
               }
               , new Object[] {
               P00067_ATrn_SupplierAGBCount
               }
               , new Object[] {
               P00078_ATrn_LocationCount
               }
               , new Object[] {
               P00089_ATrn_OrganisationCount
               }
               , new Object[] {
               P000910_Atablename, P000910_Aschemaname, P000910_Acolumnname, P000910_Aattrelid, P000910_Aoid, P000910_Arelname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_SupplierGenCount ;
      protected int Trn_CallToActionCount ;
      protected int Trn_ProductServiceCount ;
      protected int Trn_ReceptionistCount ;
      protected int Trn_ResidentCount ;
      protected int Trn_SupplierAGBCount ;
      protected int Trn_LocationCount ;
      protected int Trn_OrganisationCount ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected string sMyColumnName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected bool nattrelid ;
      protected bool noid ;
      protected bool nrelname ;
      protected string tablename ;
      protected string schemaname ;
      protected string columnname ;
      protected string attrelid ;
      protected string oid ;
      protected string relname ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATrn_SupplierGenCount ;
      protected int[] P00023_ATrn_CallToActionCount ;
      protected int[] P00034_ATrn_ProductServiceCount ;
      protected int[] P00045_ATrn_ReceptionistCount ;
      protected int[] P00056_ATrn_ResidentCount ;
      protected int[] P00067_ATrn_SupplierAGBCount ;
      protected int[] P00078_ATrn_LocationCount ;
      protected int[] P00089_ATrn_OrganisationCount ;
      protected string[] P000910_Atablename ;
      protected bool[] P000910_ntablename ;
      protected string[] P000910_Aschemaname ;
      protected bool[] P000910_nschemaname ;
      protected string[] P000910_Acolumnname ;
      protected bool[] P000910_ncolumnname ;
      protected string[] P000910_Aattrelid ;
      protected bool[] P000910_nattrelid ;
      protected string[] P000910_Aoid ;
      protected bool[] P000910_noid ;
      protected string[] P000910_Arelname ;
      protected bool[] P000910_nrelname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          };
          Object[] prmP00067;
          prmP00067 = new Object[] {
          };
          Object[] prmP00078;
          prmP00078 = new Object[] {
          };
          Object[] prmP00089;
          prmP00089 = new Object[] {
          };
          Object[] prmP000910;
          prmP000910 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0) ,
          new ParDef("sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_SupplierGen ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM Trn_CallToAction ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT COUNT(*) FROM Trn_ProductService ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT COUNT(*) FROM Trn_Receptionist ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT COUNT(*) FROM Trn_Resident ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00067", "SELECT COUNT(*) FROM Trn_SupplierAGB ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00067,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00078", "SELECT COUNT(*) FROM Trn_Location ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00078,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00089", "SELECT COUNT(*) FROM Trn_Organisation ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00089,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000910", "SELECT T.TABLENAME, T.TABLEOWNER, T1.ATTNAME, T1.ATTRELID, T2.OID, T2.RELNAME FROM PG_TABLES T, PG_ATTRIBUTE T1, PG_CLASS T2 WHERE (UPPER(T.TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(T.TABLEOWNER) = ( UPPER(:sMySchemaName))) AND (UPPER(T1.ATTNAME) = ( UPPER(:sMyColumnName))) AND (T2.OID = ( T1.ATTRELID)) AND (T2.RELNAME = ( T.TABLENAME)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000910,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
