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

      public void ReorganizeTrn_Location( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Location */
         cmdBuffer=" ALTER TABLE Trn_Location ADD LocationBrandTheme TEXT , ADD LocationCtaTheme TEXT , ADD LocationHasMyCare BOOLEAN NOT NULL DEFAULT FALSE, ADD LocationHasMyServices BOOLEAN NOT NULL DEFAULT FALSE, ADD LocationHasMyLiving BOOLEAN NOT NULL DEFAULT FALSE, ADD LocationHasOwnBrand BOOLEAN NOT NULL DEFAULT FALSE, ADD ReceptionImage BYTEA , ADD ReceptionImage_GXI VARCHAR(2048) , ADD ReceptionDescription VARCHAR(200)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Location ALTER COLUMN LocationHasMyCare DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Location ALTER COLUMN LocationHasMyServices DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Location ALTER COLUMN LocationHasMyLiving DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Location ALTER COLUMN LocationHasOwnBrand DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_Memo( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Memo */
         cmdBuffer=" ALTER TABLE Trn_Memo ADD MemoBgColorCode VARCHAR(100) NOT NULL DEFAULT '', ADD MemoForm CHAR(20) NOT NULL DEFAULT '', ADD SG_OrganisationId CHAR(36) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000', ADD SG_LocationId CHAR(36) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000' "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo ALTER COLUMN MemoBgColorCode DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo ALTER COLUMN MemoForm DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" UPDATE Trn_Memo SET SG_OrganisationId=T.SG_OrganisationId, SG_LocationId=T.SG_LocationId FROM (SELECT T1.MemoId, T2.SG_OrganisationId, T2.SG_LocationId FROM (((Trn_Memo T1 INNER JOIN Trn_BulletinBoard T4 ON T4.BulletinBoardId = T1.BulletinBoardId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = T1.ResidentId AND T3.LocationId = T4.LocationId AND T3.OrganisationId = T4.OrganisationId) LEFT JOIN Trn_ResidentPackage T2 ON T2.ResidentPackageId = T3.ResidentPackageId)) T WHERE Trn_Memo.MemoId= T.MemoId "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo ALTER COLUMN SG_OrganisationId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo ALTER COLUMN SG_LocationId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo ALTER COLUMN ResidentId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" DROP INDEX ITRN_MEMO2 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_MEMO2 ON Trn_Memo (ResidentId ,SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_MEMO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_MEMO2 ON Trn_Memo (ResidentId ,SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         cmdBuffer=" ALTER TABLE Trn_Memo DROP CONSTRAINT ITRN_MEMO2 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Memo DROP BulletinBoardId "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void DeleteTrn_BulletinBoard( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" DROP TABLE Trn_BulletinBoard CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP VIEW Trn_BulletinBoard CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP FUNCTION Trn_BulletinBoard CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
               }
            }
         }
      }

      public void RITrn_MemoTrn_Resident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Memo DROP CONSTRAINT ITRN_MEMO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
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
            Trn_LocationCount = P00012_ATrn_LocationCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Trn_Location" ,  Trn_LocationCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            Trn_MemoCount = P00023_ATrn_MemoCount[0];
            pr_default.close(1);
            PrintRecordCount ( "Trn_Memo" ,  Trn_MemoCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationBrandTheme") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationBrandTheme", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationCtaTheme") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationCtaTheme", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationHasMyCare") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationHasMyCare", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationHasMyServices") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationHasMyServices", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationHasMyLiving") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationHasMyLiving", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"LocationHasOwnBrand") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"LocationHasOwnBrand", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"ReceptionImage") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ReceptionImage", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"ReceptionImage_GXI") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ReceptionImage_GXI", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Location",sSchemaVar,"ReceptionDescription") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ReceptionDescription", "Trn_Location"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Memo",sSchemaVar,"MemoBgColorCode") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"MemoBgColorCode", "Trn_Memo"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Memo",sSchemaVar,"MemoForm") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"MemoForm", "Trn_Memo"}) ) ;
            return false ;
         }
         if ( ! ColumnExist("Trn_Memo",sSchemaVar,"BulletinBoardId") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_not_exist", new   object[]  {"BulletinBoardId", "Trn_Memo"}) ) ;
            return false ;
         }
         if ( ! tableexist("Trn_BulletinBoard",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_not_exist", new   object[]  {"Trn_BulletinBoard"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            tablename = P00045_Atablename[0];
            ntablename = P00045_ntablename[0];
            schemaname = P00045_Aschemaname[0];
            nschemaname = P00045_nschemaname[0];
            result = true;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         return result ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P00056 */
         pr_default.execute(4, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(4) != 101) )
         {
            tablename = P00056_Atablename[0];
            ntablename = P00056_ntablename[0];
            schemaname = P00056_Aschemaname[0];
            nschemaname = P00056_nschemaname[0];
            columnname = P00056_Acolumnname[0];
            ncolumnname = P00056_ncolumnname[0];
            attrelid = P00056_Aattrelid[0];
            nattrelid = P00056_nattrelid[0];
            oid = P00056_Aoid[0];
            noid = P00056_noid[0];
            relname = P00056_Arelname[0];
            nrelname = P00056_nrelname[0];
            result = true;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeTrn_Memo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "DeleteTrn_BulletinBoard" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "RITrn_MemoTrn_Resident" , new Object[]{ });
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
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Location", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Memo", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileremove", new   object[]  {"Trn_BulletinBoard", ""}) );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "DeleteTrn_BulletinBoard" ,  "ReorganizeTrn_Memo" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_MEMO2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_MemoTrn_Resident" ,  "ReorganizeTrn_Memo" );
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
         P00012_ATrn_LocationCount = new int[1] ;
         P00023_ATrn_MemoCount = new int[1] ;
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         P00045_Atablename = new string[] {""} ;
         P00045_ntablename = new bool[] {false} ;
         P00045_Aschemaname = new string[] {""} ;
         P00045_nschemaname = new bool[] {false} ;
         sMyColumnName = "";
         columnname = "";
         ncolumnname = false;
         attrelid = "";
         nattrelid = false;
         oid = "";
         noid = false;
         relname = "";
         nrelname = false;
         P00056_Atablename = new string[] {""} ;
         P00056_ntablename = new bool[] {false} ;
         P00056_Aschemaname = new string[] {""} ;
         P00056_nschemaname = new bool[] {false} ;
         P00056_Acolumnname = new string[] {""} ;
         P00056_ncolumnname = new bool[] {false} ;
         P00056_Aattrelid = new string[] {""} ;
         P00056_nattrelid = new bool[] {false} ;
         P00056_Aoid = new string[] {""} ;
         P00056_noid = new bool[] {false} ;
         P00056_Arelname = new string[] {""} ;
         P00056_nrelname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_LocationCount
               }
               , new Object[] {
               P00023_ATrn_MemoCount
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Atablename, P00045_Aschemaname
               }
               , new Object[] {
               P00056_Atablename, P00056_Aschemaname, P00056_Acolumnname, P00056_Aattrelid, P00056_Aoid, P00056_Arelname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_LocationCount ;
      protected int Trn_MemoCount ;
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
      protected int[] P00012_ATrn_LocationCount ;
      protected int[] P00023_ATrn_MemoCount ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Atablename ;
      protected bool[] P00045_ntablename ;
      protected string[] P00045_Aschemaname ;
      protected bool[] P00045_nschemaname ;
      protected string[] P00056_Atablename ;
      protected bool[] P00056_ntablename ;
      protected string[] P00056_Aschemaname ;
      protected bool[] P00056_nschemaname ;
      protected string[] P00056_Acolumnname ;
      protected bool[] P00056_ncolumnname ;
      protected string[] P00056_Aattrelid ;
      protected bool[] P00056_nattrelid ;
      protected string[] P00056_Aoid ;
      protected bool[] P00056_noid ;
      protected string[] P00056_Arelname ;
      protected bool[] P00056_nrelname ;
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
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0) ,
          new ParDef("sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_Location ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM Trn_Memo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT TABLENAME, TABLEOWNER FROM PG_TABLES WHERE (UPPER(TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(TABLEOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT VIEWNAME, VIEWOWNER FROM PG_VIEWS WHERE (UPPER(VIEWNAME) = ( UPPER(:sTableName))) AND (UPPER(VIEWOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT T.TABLENAME, T.TABLEOWNER, T1.ATTNAME, T1.ATTRELID, T2.OID, T2.RELNAME FROM PG_TABLES T, PG_ATTRIBUTE T1, PG_CLASS T2 WHERE (UPPER(T.TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(T.TABLEOWNER) = ( UPPER(:sMySchemaName))) AND (UPPER(T1.ATTNAME) = ( UPPER(:sMyColumnName))) AND (T2.OID = ( T1.ATTRELID)) AND (T2.RELNAME = ( T.TABLENAME)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
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
