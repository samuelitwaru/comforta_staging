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
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
         }
         cmdBuffer=" ALTER TABLE Trn_Location ALTER COLUMN Trn_ThemeId DROP NOT NULL "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void RITrn_AgendaCalendarTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_AgendaCalendar DROP CONSTRAINT ITRN_AGENDACALENDAR1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
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
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierGen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
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
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierAGB( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
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
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ReceptionistTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_Receptionist DROP CONSTRAINT ITRN_RECEPTIONIST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_ResidentType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
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
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_MedicalIndication( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
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
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
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
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
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
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
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
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_Location" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "RITrn_AgendaCalendarTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "RITrn_LocationDynamicFormTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "RITrn_LocationDynamicFormWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "RITrn_ProductServiceTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "RITrn_ProductServiceTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "RITrn_ProductServiceTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "RITrn_ReceptionistTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "RITrn_ResidentTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "RITrn_ResidentTrn_ResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "RITrn_ResidentTrn_MedicalIndication" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "RITrn_LocationTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "RITrn_LocationTrn_Theme" , new Object[]{ });
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
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_AGENDACALENDAR1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaCalendarTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM1"}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE2"}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE1"}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RECEPTIONIST1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ReceptionistTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT2"}) );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT1"}) );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Organisation" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Theme" ,  "ReorganizeTrn_Location" );
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
         sSchemaVar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_LocationCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_LocationCount ;
      protected string sSchemaVar ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATrn_LocationCount ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
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
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_Location ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
