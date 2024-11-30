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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_agendacalendar_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_agendacalendar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendacalendar_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1358( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1358( ) ;
         standaloneModal( ) ;
         AddRow1358( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z303AgendaCalendarId = A303AgendaCalendarId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_130( )
      {
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1358( ) ;
            }
            else
            {
               CheckExtendedTable1358( ) ;
               if ( AnyError == 0 )
               {
                  ZM1358( 9) ;
               }
               CloseExtendedTableCursors1358( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1358( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z304AgendaCalendarTitle = A304AgendaCalendarTitle;
            Z305AgendaCalendarStartDate = A305AgendaCalendarStartDate;
            Z306AgendaCalendarEndDate = A306AgendaCalendarEndDate;
            Z454AgendaCalendarType = A454AgendaCalendarType;
            Z307AgendaCalendarAllDay = A307AgendaCalendarAllDay;
            Z450AgendaCalendarRecurring = A450AgendaCalendarRecurring;
            Z451AgendaCalendarRecurringType = A451AgendaCalendarRecurringType;
            Z452AgendaCalendarAddRSVP = A452AgendaCalendarAddRSVP;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z304AgendaCalendarTitle = A304AgendaCalendarTitle;
            Z305AgendaCalendarStartDate = A305AgendaCalendarStartDate;
            Z306AgendaCalendarEndDate = A306AgendaCalendarEndDate;
            Z454AgendaCalendarType = A454AgendaCalendarType;
            Z307AgendaCalendarAllDay = A307AgendaCalendarAllDay;
            Z450AgendaCalendarRecurring = A450AgendaCalendarRecurring;
            Z451AgendaCalendarRecurringType = A451AgendaCalendarRecurringType;
            Z452AgendaCalendarAddRSVP = A452AgendaCalendarAddRSVP;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A303AgendaCalendarId) )
         {
            A303AgendaCalendarId = Guid.NewGuid( );
         }
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1358( )
      {
         /* Using cursor BC00135 */
         pr_default.execute(3, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A304AgendaCalendarTitle = BC00135_A304AgendaCalendarTitle[0];
            A305AgendaCalendarStartDate = BC00135_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = BC00135_A306AgendaCalendarEndDate[0];
            A454AgendaCalendarType = BC00135_A454AgendaCalendarType[0];
            A307AgendaCalendarAllDay = BC00135_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = BC00135_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = BC00135_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = BC00135_A452AgendaCalendarAddRSVP[0];
            A29LocationId = BC00135_A29LocationId[0];
            A11OrganisationId = BC00135_A11OrganisationId[0];
            ZM1358( -8) ;
         }
         pr_default.close(3);
         OnLoadActions1358( ) ;
      }

      protected void OnLoadActions1358( )
      {
      }

      protected void CheckExtendedTable1358( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00134 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A454AgendaCalendarType, "Event") == 0 ) || ( StringUtil.StrCmp(A454AgendaCalendarType, "Activity") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Agenda Calendar Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1358( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1358( )
      {
         /* Using cursor BC00136 */
         pr_default.execute(4, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00133 */
         pr_default.execute(1, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1358( 8) ;
            RcdFound58 = 1;
            A303AgendaCalendarId = BC00133_A303AgendaCalendarId[0];
            A304AgendaCalendarTitle = BC00133_A304AgendaCalendarTitle[0];
            A305AgendaCalendarStartDate = BC00133_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = BC00133_A306AgendaCalendarEndDate[0];
            A454AgendaCalendarType = BC00133_A454AgendaCalendarType[0];
            A307AgendaCalendarAllDay = BC00133_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = BC00133_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = BC00133_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = BC00133_A452AgendaCalendarAddRSVP[0];
            A29LocationId = BC00133_A29LocationId[0];
            A11OrganisationId = BC00133_A11OrganisationId[0];
            Z303AgendaCalendarId = A303AgendaCalendarId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1358( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1358( ) ;
            }
            Gx_mode = sMode58;
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1358( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode58;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1358( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_130( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1358( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00132 */
            pr_default.execute(0, new Object[] {A303AgendaCalendarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z304AgendaCalendarTitle, BC00132_A304AgendaCalendarTitle[0]) != 0 ) || ( Z305AgendaCalendarStartDate != BC00132_A305AgendaCalendarStartDate[0] ) || ( Z306AgendaCalendarEndDate != BC00132_A306AgendaCalendarEndDate[0] ) || ( StringUtil.StrCmp(Z454AgendaCalendarType, BC00132_A454AgendaCalendarType[0]) != 0 ) || ( Z307AgendaCalendarAllDay != BC00132_A307AgendaCalendarAllDay[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z450AgendaCalendarRecurring != BC00132_A450AgendaCalendarRecurring[0] ) || ( StringUtil.StrCmp(Z451AgendaCalendarRecurringType, BC00132_A451AgendaCalendarRecurringType[0]) != 0 ) || ( Z452AgendaCalendarAddRSVP != BC00132_A452AgendaCalendarAddRSVP[0] ) || ( Z29LocationId != BC00132_A29LocationId[0] ) || ( Z11OrganisationId != BC00132_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaCalendar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1358( )
      {
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1358( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1358( 0) ;
            CheckOptimisticConcurrency1358( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1358( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1358( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00137 */
                     pr_default.execute(5, new Object[] {A303AgendaCalendarId, A304AgendaCalendarTitle, A305AgendaCalendarStartDate, A306AgendaCalendarEndDate, A454AgendaCalendarType, A307AgendaCalendarAllDay, A450AgendaCalendarRecurring, A451AgendaCalendarRecurringType, A452AgendaCalendarAddRSVP, A29LocationId, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1358( ) ;
            }
            EndLevel1358( ) ;
         }
         CloseExtendedTableCursors1358( ) ;
      }

      protected void Update1358( )
      {
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1358( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1358( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1358( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1358( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00138 */
                     pr_default.execute(6, new Object[] {A304AgendaCalendarTitle, A305AgendaCalendarStartDate, A306AgendaCalendarEndDate, A454AgendaCalendarType, A307AgendaCalendarAllDay, A450AgendaCalendarRecurring, A451AgendaCalendarRecurringType, A452AgendaCalendarAddRSVP, A29LocationId, A11OrganisationId, A303AgendaCalendarId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1358( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1358( ) ;
         }
         CloseExtendedTableCursors1358( ) ;
      }

      protected void DeferredUpdate1358( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1358( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1358( ) ;
            AfterConfirm1358( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1358( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00139 */
                  pr_default.execute(7, new Object[] {A303AgendaCalendarId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1358( ) ;
         Gx_mode = sMode58;
      }

      protected void OnDeleteControls1358( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001310 */
            pr_default.execute(8, new Object[] {A303AgendaCalendarId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_AgendaEventGroup", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1358( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1358( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1358( )
      {
         /* Using cursor BC001311 */
         pr_default.execute(9, new Object[] {A303AgendaCalendarId});
         RcdFound58 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A303AgendaCalendarId = BC001311_A303AgendaCalendarId[0];
            A304AgendaCalendarTitle = BC001311_A304AgendaCalendarTitle[0];
            A305AgendaCalendarStartDate = BC001311_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = BC001311_A306AgendaCalendarEndDate[0];
            A454AgendaCalendarType = BC001311_A454AgendaCalendarType[0];
            A307AgendaCalendarAllDay = BC001311_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = BC001311_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = BC001311_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = BC001311_A452AgendaCalendarAddRSVP[0];
            A29LocationId = BC001311_A29LocationId[0];
            A11OrganisationId = BC001311_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1358( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound58 = 0;
         ScanKeyLoad1358( ) ;
      }

      protected void ScanKeyLoad1358( )
      {
         sMode58 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A303AgendaCalendarId = BC001311_A303AgendaCalendarId[0];
            A304AgendaCalendarTitle = BC001311_A304AgendaCalendarTitle[0];
            A305AgendaCalendarStartDate = BC001311_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = BC001311_A306AgendaCalendarEndDate[0];
            A454AgendaCalendarType = BC001311_A454AgendaCalendarType[0];
            A307AgendaCalendarAllDay = BC001311_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = BC001311_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = BC001311_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = BC001311_A452AgendaCalendarAddRSVP[0];
            A29LocationId = BC001311_A29LocationId[0];
            A11OrganisationId = BC001311_A11OrganisationId[0];
         }
         Gx_mode = sMode58;
      }

      protected void ScanKeyEnd1358( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1358( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1358( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1358( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1358( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1358( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1358( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1358( )
      {
      }

      protected void send_integrity_lvl_hashes1358( )
      {
      }

      protected void AddRow1358( )
      {
         VarsToRow58( bcTrn_AgendaCalendar) ;
      }

      protected void ReadRow1358( )
      {
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
      }

      protected void InitializeNonKey1358( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A454AgendaCalendarType = "";
         A307AgendaCalendarAllDay = false;
         A450AgendaCalendarRecurring = false;
         A451AgendaCalendarRecurringType = "";
         A452AgendaCalendarAddRSVP = false;
         Z304AgendaCalendarTitle = "";
         Z305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z454AgendaCalendarType = "";
         Z307AgendaCalendarAllDay = false;
         Z450AgendaCalendarRecurring = false;
         Z451AgendaCalendarRecurringType = "";
         Z452AgendaCalendarAddRSVP = false;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1358( )
      {
         A303AgendaCalendarId = Guid.NewGuid( );
         InitializeNonKey1358( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         A11OrganisationId = i11OrganisationId;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow58( SdtTrn_AgendaCalendar obj58 )
      {
         obj58.gxTpr_Mode = Gx_mode;
         obj58.gxTpr_Locationid = A29LocationId;
         obj58.gxTpr_Organisationid = A11OrganisationId;
         obj58.gxTpr_Agendacalendartitle = A304AgendaCalendarTitle;
         obj58.gxTpr_Agendacalendarstartdate = A305AgendaCalendarStartDate;
         obj58.gxTpr_Agendacalendarenddate = A306AgendaCalendarEndDate;
         obj58.gxTpr_Agendacalendartype = A454AgendaCalendarType;
         obj58.gxTpr_Agendacalendarallday = A307AgendaCalendarAllDay;
         obj58.gxTpr_Agendacalendarrecurring = A450AgendaCalendarRecurring;
         obj58.gxTpr_Agendacalendarrecurringtype = A451AgendaCalendarRecurringType;
         obj58.gxTpr_Agendacalendaraddrsvp = A452AgendaCalendarAddRSVP;
         obj58.gxTpr_Agendacalendarid = A303AgendaCalendarId;
         obj58.gxTpr_Agendacalendarid_Z = Z303AgendaCalendarId;
         obj58.gxTpr_Locationid_Z = Z29LocationId;
         obj58.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj58.gxTpr_Agendacalendartitle_Z = Z304AgendaCalendarTitle;
         obj58.gxTpr_Agendacalendarstartdate_Z = Z305AgendaCalendarStartDate;
         obj58.gxTpr_Agendacalendarenddate_Z = Z306AgendaCalendarEndDate;
         obj58.gxTpr_Agendacalendartype_Z = Z454AgendaCalendarType;
         obj58.gxTpr_Agendacalendarallday_Z = Z307AgendaCalendarAllDay;
         obj58.gxTpr_Agendacalendarrecurring_Z = Z450AgendaCalendarRecurring;
         obj58.gxTpr_Agendacalendarrecurringtype_Z = Z451AgendaCalendarRecurringType;
         obj58.gxTpr_Agendacalendaraddrsvp_Z = Z452AgendaCalendarAddRSVP;
         obj58.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow58( SdtTrn_AgendaCalendar obj58 )
      {
         obj58.gxTpr_Agendacalendarid = A303AgendaCalendarId;
         return  ;
      }

      public void RowToVars58( SdtTrn_AgendaCalendar obj58 ,
                               int forceLoad )
      {
         Gx_mode = obj58.gxTpr_Mode;
         A29LocationId = obj58.gxTpr_Locationid;
         A11OrganisationId = obj58.gxTpr_Organisationid;
         A304AgendaCalendarTitle = obj58.gxTpr_Agendacalendartitle;
         A305AgendaCalendarStartDate = obj58.gxTpr_Agendacalendarstartdate;
         A306AgendaCalendarEndDate = obj58.gxTpr_Agendacalendarenddate;
         A454AgendaCalendarType = obj58.gxTpr_Agendacalendartype;
         A307AgendaCalendarAllDay = obj58.gxTpr_Agendacalendarallday;
         A450AgendaCalendarRecurring = obj58.gxTpr_Agendacalendarrecurring;
         A451AgendaCalendarRecurringType = obj58.gxTpr_Agendacalendarrecurringtype;
         A452AgendaCalendarAddRSVP = obj58.gxTpr_Agendacalendaraddrsvp;
         A303AgendaCalendarId = obj58.gxTpr_Agendacalendarid;
         Z303AgendaCalendarId = obj58.gxTpr_Agendacalendarid_Z;
         Z29LocationId = obj58.gxTpr_Locationid_Z;
         Z11OrganisationId = obj58.gxTpr_Organisationid_Z;
         Z304AgendaCalendarTitle = obj58.gxTpr_Agendacalendartitle_Z;
         Z305AgendaCalendarStartDate = obj58.gxTpr_Agendacalendarstartdate_Z;
         Z306AgendaCalendarEndDate = obj58.gxTpr_Agendacalendarenddate_Z;
         Z454AgendaCalendarType = obj58.gxTpr_Agendacalendartype_Z;
         Z307AgendaCalendarAllDay = obj58.gxTpr_Agendacalendarallday_Z;
         Z450AgendaCalendarRecurring = obj58.gxTpr_Agendacalendarrecurring_Z;
         Z451AgendaCalendarRecurringType = obj58.gxTpr_Agendacalendarrecurringtype_Z;
         Z452AgendaCalendarAddRSVP = obj58.gxTpr_Agendacalendaraddrsvp_Z;
         Gx_mode = obj58.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A303AgendaCalendarId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1358( ) ;
         ScanKeyStart1358( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z303AgendaCalendarId = A303AgendaCalendarId;
         }
         ZM1358( -8) ;
         OnLoadActions1358( ) ;
         AddRow1358( ) ;
         ScanKeyEnd1358( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars58( bcTrn_AgendaCalendar, 0) ;
         ScanKeyStart1358( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z303AgendaCalendarId = A303AgendaCalendarId;
         }
         ZM1358( -8) ;
         OnLoadActions1358( ) ;
         AddRow1358( ) ;
         ScanKeyEnd1358( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1358( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1358( ) ;
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A303AgendaCalendarId != Z303AgendaCalendarId )
               {
                  A303AgendaCalendarId = Z303AgendaCalendarId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1358( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A303AgendaCalendarId != Z303AgendaCalendarId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1358( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1358( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
         SaveImpl( ) ;
         VarsToRow58( bcTrn_AgendaCalendar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1358( ) ;
         AfterTrn( ) ;
         VarsToRow58( bcTrn_AgendaCalendar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow58( bcTrn_AgendaCalendar) ;
         }
         else
         {
            SdtTrn_AgendaCalendar auxBC = new SdtTrn_AgendaCalendar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A303AgendaCalendarId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AgendaCalendar);
               auxBC.Save();
               bcTrn_AgendaCalendar.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1358( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow58( bcTrn_AgendaCalendar) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow58( bcTrn_AgendaCalendar) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_AgendaCalendar, 0) ;
         GetKey1358( ) ;
         if ( RcdFound58 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A303AgendaCalendarId != Z303AgendaCalendarId )
            {
               A303AgendaCalendarId = Z303AgendaCalendarId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A303AgendaCalendarId != Z303AgendaCalendarId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_agendacalendar_bc",pr_default);
         VarsToRow58( bcTrn_AgendaCalendar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_AgendaCalendar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AgendaCalendar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AgendaCalendar )
         {
            bcTrn_AgendaCalendar = (SdtTrn_AgendaCalendar)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AgendaCalendar.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaCalendar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow58( bcTrn_AgendaCalendar) ;
            }
            else
            {
               RowToVars58( bcTrn_AgendaCalendar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AgendaCalendar.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaCalendar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars58( bcTrn_AgendaCalendar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AgendaCalendar Trn_AgendaCalendar_BC
      {
         get {
            return bcTrn_AgendaCalendar ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_agendacalendar_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z303AgendaCalendarId = Guid.Empty;
         A303AgendaCalendarId = Guid.Empty;
         Z304AgendaCalendarTitle = "";
         A304AgendaCalendarTitle = "";
         Z305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z454AgendaCalendarType = "";
         A454AgendaCalendarType = "";
         Z451AgendaCalendarRecurringType = "";
         A451AgendaCalendarRecurringType = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC00135_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC00135_A304AgendaCalendarTitle = new string[] {""} ;
         BC00135_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC00135_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC00135_A454AgendaCalendarType = new string[] {""} ;
         BC00135_A307AgendaCalendarAllDay = new bool[] {false} ;
         BC00135_A450AgendaCalendarRecurring = new bool[] {false} ;
         BC00135_A451AgendaCalendarRecurringType = new string[] {""} ;
         BC00135_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         BC00135_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00135_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00134_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00136_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC00133_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC00133_A304AgendaCalendarTitle = new string[] {""} ;
         BC00133_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC00133_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC00133_A454AgendaCalendarType = new string[] {""} ;
         BC00133_A307AgendaCalendarAllDay = new bool[] {false} ;
         BC00133_A450AgendaCalendarRecurring = new bool[] {false} ;
         BC00133_A451AgendaCalendarRecurringType = new string[] {""} ;
         BC00133_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         BC00133_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00133_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode58 = "";
         BC00132_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC00132_A304AgendaCalendarTitle = new string[] {""} ;
         BC00132_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC00132_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC00132_A454AgendaCalendarType = new string[] {""} ;
         BC00132_A307AgendaCalendarAllDay = new bool[] {false} ;
         BC00132_A450AgendaCalendarRecurring = new bool[] {false} ;
         BC00132_A451AgendaCalendarRecurringType = new string[] {""} ;
         BC00132_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         BC00132_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00132_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001310_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001310_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001311_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001311_A304AgendaCalendarTitle = new string[] {""} ;
         BC001311_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC001311_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC001311_A454AgendaCalendarType = new string[] {""} ;
         BC001311_A307AgendaCalendarAllDay = new bool[] {false} ;
         BC001311_A450AgendaCalendarRecurring = new bool[] {false} ;
         BC001311_A451AgendaCalendarRecurringType = new string[] {""} ;
         BC001311_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         BC001311_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001311_A11OrganisationId = new Guid[] {Guid.Empty} ;
         i29LocationId = Guid.Empty;
         i11OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__default(),
            new Object[][] {
                new Object[] {
               BC00132_A303AgendaCalendarId, BC00132_A304AgendaCalendarTitle, BC00132_A305AgendaCalendarStartDate, BC00132_A306AgendaCalendarEndDate, BC00132_A454AgendaCalendarType, BC00132_A307AgendaCalendarAllDay, BC00132_A450AgendaCalendarRecurring, BC00132_A451AgendaCalendarRecurringType, BC00132_A452AgendaCalendarAddRSVP, BC00132_A29LocationId,
               BC00132_A11OrganisationId
               }
               , new Object[] {
               BC00133_A303AgendaCalendarId, BC00133_A304AgendaCalendarTitle, BC00133_A305AgendaCalendarStartDate, BC00133_A306AgendaCalendarEndDate, BC00133_A454AgendaCalendarType, BC00133_A307AgendaCalendarAllDay, BC00133_A450AgendaCalendarRecurring, BC00133_A451AgendaCalendarRecurringType, BC00133_A452AgendaCalendarAddRSVP, BC00133_A29LocationId,
               BC00133_A11OrganisationId
               }
               , new Object[] {
               BC00134_A29LocationId
               }
               , new Object[] {
               BC00135_A303AgendaCalendarId, BC00135_A304AgendaCalendarTitle, BC00135_A305AgendaCalendarStartDate, BC00135_A306AgendaCalendarEndDate, BC00135_A454AgendaCalendarType, BC00135_A307AgendaCalendarAllDay, BC00135_A450AgendaCalendarRecurring, BC00135_A451AgendaCalendarRecurringType, BC00135_A452AgendaCalendarAddRSVP, BC00135_A29LocationId,
               BC00135_A11OrganisationId
               }
               , new Object[] {
               BC00136_A303AgendaCalendarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001310_A303AgendaCalendarId, BC001310_A62ResidentId
               }
               , new Object[] {
               BC001311_A303AgendaCalendarId, BC001311_A304AgendaCalendarTitle, BC001311_A305AgendaCalendarStartDate, BC001311_A306AgendaCalendarEndDate, BC001311_A454AgendaCalendarType, BC001311_A307AgendaCalendarAllDay, BC001311_A450AgendaCalendarRecurring, BC001311_A451AgendaCalendarRecurringType, BC001311_A452AgendaCalendarAddRSVP, BC001311_A29LocationId,
               BC001311_A11OrganisationId
               }
            }
         );
         Z303AgendaCalendarId = Guid.NewGuid( );
         A303AgendaCalendarId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound58 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode58 ;
      private DateTime Z305AgendaCalendarStartDate ;
      private DateTime A305AgendaCalendarStartDate ;
      private DateTime Z306AgendaCalendarEndDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private bool Z307AgendaCalendarAllDay ;
      private bool A307AgendaCalendarAllDay ;
      private bool Z450AgendaCalendarRecurring ;
      private bool A450AgendaCalendarRecurring ;
      private bool Z452AgendaCalendarAddRSVP ;
      private bool A452AgendaCalendarAddRSVP ;
      private bool Gx_longc ;
      private string Z304AgendaCalendarTitle ;
      private string A304AgendaCalendarTitle ;
      private string Z454AgendaCalendarType ;
      private string A454AgendaCalendarType ;
      private string Z451AgendaCalendarRecurringType ;
      private string A451AgendaCalendarRecurringType ;
      private Guid Z303AgendaCalendarId ;
      private Guid A303AgendaCalendarId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i29LocationId ;
      private Guid i11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00135_A303AgendaCalendarId ;
      private string[] BC00135_A304AgendaCalendarTitle ;
      private DateTime[] BC00135_A305AgendaCalendarStartDate ;
      private DateTime[] BC00135_A306AgendaCalendarEndDate ;
      private string[] BC00135_A454AgendaCalendarType ;
      private bool[] BC00135_A307AgendaCalendarAllDay ;
      private bool[] BC00135_A450AgendaCalendarRecurring ;
      private string[] BC00135_A451AgendaCalendarRecurringType ;
      private bool[] BC00135_A452AgendaCalendarAddRSVP ;
      private Guid[] BC00135_A29LocationId ;
      private Guid[] BC00135_A11OrganisationId ;
      private Guid[] BC00134_A29LocationId ;
      private Guid[] BC00136_A303AgendaCalendarId ;
      private Guid[] BC00133_A303AgendaCalendarId ;
      private string[] BC00133_A304AgendaCalendarTitle ;
      private DateTime[] BC00133_A305AgendaCalendarStartDate ;
      private DateTime[] BC00133_A306AgendaCalendarEndDate ;
      private string[] BC00133_A454AgendaCalendarType ;
      private bool[] BC00133_A307AgendaCalendarAllDay ;
      private bool[] BC00133_A450AgendaCalendarRecurring ;
      private string[] BC00133_A451AgendaCalendarRecurringType ;
      private bool[] BC00133_A452AgendaCalendarAddRSVP ;
      private Guid[] BC00133_A29LocationId ;
      private Guid[] BC00133_A11OrganisationId ;
      private Guid[] BC00132_A303AgendaCalendarId ;
      private string[] BC00132_A304AgendaCalendarTitle ;
      private DateTime[] BC00132_A305AgendaCalendarStartDate ;
      private DateTime[] BC00132_A306AgendaCalendarEndDate ;
      private string[] BC00132_A454AgendaCalendarType ;
      private bool[] BC00132_A307AgendaCalendarAllDay ;
      private bool[] BC00132_A450AgendaCalendarRecurring ;
      private string[] BC00132_A451AgendaCalendarRecurringType ;
      private bool[] BC00132_A452AgendaCalendarAddRSVP ;
      private Guid[] BC00132_A29LocationId ;
      private Guid[] BC00132_A11OrganisationId ;
      private Guid[] BC001310_A303AgendaCalendarId ;
      private Guid[] BC001310_A62ResidentId ;
      private Guid[] BC001311_A303AgendaCalendarId ;
      private string[] BC001311_A304AgendaCalendarTitle ;
      private DateTime[] BC001311_A305AgendaCalendarStartDate ;
      private DateTime[] BC001311_A306AgendaCalendarEndDate ;
      private string[] BC001311_A454AgendaCalendarType ;
      private bool[] BC001311_A307AgendaCalendarAllDay ;
      private bool[] BC001311_A450AgendaCalendarRecurring ;
      private string[] BC001311_A451AgendaCalendarRecurringType ;
      private bool[] BC001311_A452AgendaCalendarAddRSVP ;
      private Guid[] BC001311_A29LocationId ;
      private Guid[] BC001311_A11OrganisationId ;
      private SdtTrn_AgendaCalendar bcTrn_AgendaCalendar ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendacalendar_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_agendacalendar_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_agendacalendar_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00132;
       prmBC00132 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00133;
       prmBC00133 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00134;
       prmBC00134 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00135;
       prmBC00135 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00136;
       prmBC00136 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00137;
       prmBC00137 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00138;
       prmBC00138 = new Object[] {
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00139;
       prmBC00139 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001310;
       prmBC001310 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001311;
       prmBC001311 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00132", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId  FOR UPDATE OF Trn_AgendaCalendar",true, GxErrorMask.GX_NOMASK, false, this,prmBC00132,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00133", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00133,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00134", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00134,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00135", "SELECT TM1.AgendaCalendarId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarType, TM1.AgendaCalendarAllDay, TM1.AgendaCalendarRecurring, TM1.AgendaCalendarRecurringType, TM1.AgendaCalendarAddRSVP, TM1.LocationId, TM1.OrganisationId FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00135,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00136", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00136,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00137", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaCalendar(AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId) VALUES(:AgendaCalendarId, :AgendaCalendarTitle, :AgendaCalendarStartDate, :AgendaCalendarEndDate, :AgendaCalendarType, :AgendaCalendarAllDay, :AgendaCalendarRecurring, :AgendaCalendarRecurringType, :AgendaCalendarAddRSVP, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00137)
          ,new CursorDef("BC00138", "SAVEPOINT gxupdate;UPDATE Trn_AgendaCalendar SET AgendaCalendarTitle=:AgendaCalendarTitle, AgendaCalendarStartDate=:AgendaCalendarStartDate, AgendaCalendarEndDate=:AgendaCalendarEndDate, AgendaCalendarType=:AgendaCalendarType, AgendaCalendarAllDay=:AgendaCalendarAllDay, AgendaCalendarRecurring=:AgendaCalendarRecurring, AgendaCalendarRecurringType=:AgendaCalendarRecurringType, AgendaCalendarAddRSVP=:AgendaCalendarAddRSVP, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00138)
          ,new CursorDef("BC00139", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00139)
          ,new CursorDef("BC001310", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001310,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001311", "SELECT TM1.AgendaCalendarId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarType, TM1.AgendaCalendarAllDay, TM1.AgendaCalendarRecurring, TM1.AgendaCalendarRecurringType, TM1.AgendaCalendarAddRSVP, TM1.LocationId, TM1.OrganisationId FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001311,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
    }
 }

}

}
