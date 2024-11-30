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
   public class trn_appnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_appnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appnotification_bc( IGxContext context )
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
         ReadRow1I95( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1I95( ) ;
         standaloneModal( ) ;
         AddRow1I95( ) ;
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
               Z498AppNotificationId = A498AppNotificationId;
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

      protected void CONFIRM_1I0( )
      {
         BeforeValidate1I95( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1I95( ) ;
            }
            else
            {
               CheckExtendedTable1I95( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1I95( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1I95( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z499AppNotificationTitle = A499AppNotificationTitle;
            Z500AppNotificationDescription = A500AppNotificationDescription;
            Z501AppNotificationDate = A501AppNotificationDate;
            Z502AppNotificationTopic = A502AppNotificationTopic;
         }
         if ( GX_JID == -3 )
         {
            Z498AppNotificationId = A498AppNotificationId;
            Z499AppNotificationTitle = A499AppNotificationTitle;
            Z500AppNotificationDescription = A500AppNotificationDescription;
            Z501AppNotificationDate = A501AppNotificationDate;
            Z502AppNotificationTopic = A502AppNotificationTopic;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A498AppNotificationId) )
         {
            A498AppNotificationId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1I95( )
      {
         /* Using cursor BC001I4 */
         pr_default.execute(2, new Object[] {A498AppNotificationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound95 = 1;
            A499AppNotificationTitle = BC001I4_A499AppNotificationTitle[0];
            A500AppNotificationDescription = BC001I4_A500AppNotificationDescription[0];
            A501AppNotificationDate = BC001I4_A501AppNotificationDate[0];
            A502AppNotificationTopic = BC001I4_A502AppNotificationTopic[0];
            ZM1I95( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1I95( ) ;
      }

      protected void OnLoadActions1I95( )
      {
      }

      protected void CheckExtendedTable1I95( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1I95( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1I95( )
      {
         /* Using cursor BC001I5 */
         pr_default.execute(3, new Object[] {A498AppNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001I3 */
         pr_default.execute(1, new Object[] {A498AppNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1I95( 3) ;
            RcdFound95 = 1;
            A498AppNotificationId = BC001I3_A498AppNotificationId[0];
            A499AppNotificationTitle = BC001I3_A499AppNotificationTitle[0];
            A500AppNotificationDescription = BC001I3_A500AppNotificationDescription[0];
            A501AppNotificationDate = BC001I3_A501AppNotificationDate[0];
            A502AppNotificationTopic = BC001I3_A502AppNotificationTopic[0];
            Z498AppNotificationId = A498AppNotificationId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1I95( ) ;
            if ( AnyError == 1 )
            {
               RcdFound95 = 0;
               InitializeNonKey1I95( ) ;
            }
            Gx_mode = sMode95;
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey1I95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode95;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1I95( ) ;
         if ( RcdFound95 == 0 )
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
         CONFIRM_1I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1I95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001I2 */
            pr_default.execute(0, new Object[] {A498AppNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z499AppNotificationTitle, BC001I2_A499AppNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z500AppNotificationDescription, BC001I2_A500AppNotificationDescription[0]) != 0 ) || ( Z501AppNotificationDate != BC001I2_A501AppNotificationDate[0] ) || ( StringUtil.StrCmp(Z502AppNotificationTopic, BC001I2_A502AppNotificationTopic[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1I95( )
      {
         BeforeValidate1I95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1I95( 0) ;
            CheckOptimisticConcurrency1I95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1I95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I6 */
                     pr_default.execute(4, new Object[] {A498AppNotificationId, A499AppNotificationTitle, A500AppNotificationDescription, A501AppNotificationDate, A502AppNotificationTopic});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load1I95( ) ;
            }
            EndLevel1I95( ) ;
         }
         CloseExtendedTableCursors1I95( ) ;
      }

      protected void Update1I95( )
      {
         BeforeValidate1I95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I95( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1I95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I7 */
                     pr_default.execute(5, new Object[] {A499AppNotificationTitle, A500AppNotificationDescription, A501AppNotificationDate, A502AppNotificationTopic, A498AppNotificationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1I95( ) ;
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
            EndLevel1I95( ) ;
         }
         CloseExtendedTableCursors1I95( ) ;
      }

      protected void DeferredUpdate1I95( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1I95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1I95( ) ;
            AfterConfirm1I95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1I95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001I8 */
                  pr_default.execute(6, new Object[] {A498AppNotificationId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
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
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1I95( ) ;
         Gx_mode = sMode95;
      }

      protected void OnDeleteControls1I95( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001I9 */
            pr_default.execute(7, new Object[] {A498AppNotificationId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentNotification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1I95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1I95( ) ;
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

      public void ScanKeyStart1I95( )
      {
         /* Using cursor BC001I10 */
         pr_default.execute(8, new Object[] {A498AppNotificationId});
         RcdFound95 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound95 = 1;
            A498AppNotificationId = BC001I10_A498AppNotificationId[0];
            A499AppNotificationTitle = BC001I10_A499AppNotificationTitle[0];
            A500AppNotificationDescription = BC001I10_A500AppNotificationDescription[0];
            A501AppNotificationDate = BC001I10_A501AppNotificationDate[0];
            A502AppNotificationTopic = BC001I10_A502AppNotificationTopic[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1I95( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound95 = 0;
         ScanKeyLoad1I95( ) ;
      }

      protected void ScanKeyLoad1I95( )
      {
         sMode95 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound95 = 1;
            A498AppNotificationId = BC001I10_A498AppNotificationId[0];
            A499AppNotificationTitle = BC001I10_A499AppNotificationTitle[0];
            A500AppNotificationDescription = BC001I10_A500AppNotificationDescription[0];
            A501AppNotificationDate = BC001I10_A501AppNotificationDate[0];
            A502AppNotificationTopic = BC001I10_A502AppNotificationTopic[0];
         }
         Gx_mode = sMode95;
      }

      protected void ScanKeyEnd1I95( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1I95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1I95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1I95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1I95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1I95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1I95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1I95( )
      {
      }

      protected void send_integrity_lvl_hashes1I95( )
      {
      }

      protected void AddRow1I95( )
      {
         VarsToRow95( bcTrn_AppNotification) ;
      }

      protected void ReadRow1I95( )
      {
         RowToVars95( bcTrn_AppNotification, 1) ;
      }

      protected void InitializeNonKey1I95( )
      {
         A499AppNotificationTitle = "";
         A500AppNotificationDescription = "";
         A501AppNotificationDate = (DateTime)(DateTime.MinValue);
         A502AppNotificationTopic = "";
         Z499AppNotificationTitle = "";
         Z500AppNotificationDescription = "";
         Z501AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z502AppNotificationTopic = "";
      }

      protected void InitAll1I95( )
      {
         A498AppNotificationId = Guid.NewGuid( );
         InitializeNonKey1I95( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow95( SdtTrn_AppNotification obj95 )
      {
         obj95.gxTpr_Mode = Gx_mode;
         obj95.gxTpr_Appnotificationtitle = A499AppNotificationTitle;
         obj95.gxTpr_Appnotificationdescription = A500AppNotificationDescription;
         obj95.gxTpr_Appnotificationdate = A501AppNotificationDate;
         obj95.gxTpr_Appnotificationtopic = A502AppNotificationTopic;
         obj95.gxTpr_Appnotificationid = A498AppNotificationId;
         obj95.gxTpr_Appnotificationid_Z = Z498AppNotificationId;
         obj95.gxTpr_Appnotificationtitle_Z = Z499AppNotificationTitle;
         obj95.gxTpr_Appnotificationdescription_Z = Z500AppNotificationDescription;
         obj95.gxTpr_Appnotificationdate_Z = Z501AppNotificationDate;
         obj95.gxTpr_Appnotificationtopic_Z = Z502AppNotificationTopic;
         obj95.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow95( SdtTrn_AppNotification obj95 )
      {
         obj95.gxTpr_Appnotificationid = A498AppNotificationId;
         return  ;
      }

      public void RowToVars95( SdtTrn_AppNotification obj95 ,
                               int forceLoad )
      {
         Gx_mode = obj95.gxTpr_Mode;
         A499AppNotificationTitle = obj95.gxTpr_Appnotificationtitle;
         A500AppNotificationDescription = obj95.gxTpr_Appnotificationdescription;
         A501AppNotificationDate = obj95.gxTpr_Appnotificationdate;
         A502AppNotificationTopic = obj95.gxTpr_Appnotificationtopic;
         A498AppNotificationId = obj95.gxTpr_Appnotificationid;
         Z498AppNotificationId = obj95.gxTpr_Appnotificationid_Z;
         Z499AppNotificationTitle = obj95.gxTpr_Appnotificationtitle_Z;
         Z500AppNotificationDescription = obj95.gxTpr_Appnotificationdescription_Z;
         Z501AppNotificationDate = obj95.gxTpr_Appnotificationdate_Z;
         Z502AppNotificationTopic = obj95.gxTpr_Appnotificationtopic_Z;
         Gx_mode = obj95.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A498AppNotificationId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1I95( ) ;
         ScanKeyStart1I95( ) ;
         if ( RcdFound95 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z498AppNotificationId = A498AppNotificationId;
         }
         ZM1I95( -3) ;
         OnLoadActions1I95( ) ;
         AddRow1I95( ) ;
         ScanKeyEnd1I95( ) ;
         if ( RcdFound95 == 0 )
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
         RowToVars95( bcTrn_AppNotification, 0) ;
         ScanKeyStart1I95( ) ;
         if ( RcdFound95 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z498AppNotificationId = A498AppNotificationId;
         }
         ZM1I95( -3) ;
         OnLoadActions1I95( ) ;
         AddRow1I95( ) ;
         ScanKeyEnd1I95( ) ;
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1I95( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1I95( ) ;
         }
         else
         {
            if ( RcdFound95 == 1 )
            {
               if ( A498AppNotificationId != Z498AppNotificationId )
               {
                  A498AppNotificationId = Z498AppNotificationId;
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
                  Update1I95( ) ;
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
                  if ( A498AppNotificationId != Z498AppNotificationId )
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
                        Insert1I95( ) ;
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
                        Insert1I95( ) ;
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
         RowToVars95( bcTrn_AppNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow95( bcTrn_AppNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars95( bcTrn_AppNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I95( ) ;
         AfterTrn( ) ;
         VarsToRow95( bcTrn_AppNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow95( bcTrn_AppNotification) ;
         }
         else
         {
            SdtTrn_AppNotification auxBC = new SdtTrn_AppNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A498AppNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AppNotification);
               auxBC.Save();
               bcTrn_AppNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars95( bcTrn_AppNotification, 1) ;
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
         RowToVars95( bcTrn_AppNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I95( ) ;
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
               VarsToRow95( bcTrn_AppNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow95( bcTrn_AppNotification) ;
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
         RowToVars95( bcTrn_AppNotification, 0) ;
         GetKey1I95( ) ;
         if ( RcdFound95 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A498AppNotificationId != Z498AppNotificationId )
            {
               A498AppNotificationId = Z498AppNotificationId;
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
            if ( A498AppNotificationId != Z498AppNotificationId )
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
         context.RollbackDataStores("trn_appnotification_bc",pr_default);
         VarsToRow95( bcTrn_AppNotification) ;
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
         Gx_mode = bcTrn_AppNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AppNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AppNotification )
         {
            bcTrn_AppNotification = (SdtTrn_AppNotification)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AppNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow95( bcTrn_AppNotification) ;
            }
            else
            {
               RowToVars95( bcTrn_AppNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AppNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars95( bcTrn_AppNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AppNotification Trn_AppNotification_BC
      {
         get {
            return bcTrn_AppNotification ;
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
            return "trn_residentnotification_Execute" ;
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
         Z498AppNotificationId = Guid.Empty;
         A498AppNotificationId = Guid.Empty;
         Z499AppNotificationTitle = "";
         A499AppNotificationTitle = "";
         Z500AppNotificationDescription = "";
         A500AppNotificationDescription = "";
         Z501AppNotificationDate = (DateTime)(DateTime.MinValue);
         A501AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z502AppNotificationTopic = "";
         A502AppNotificationTopic = "";
         BC001I4_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001I4_A499AppNotificationTitle = new string[] {""} ;
         BC001I4_A500AppNotificationDescription = new string[] {""} ;
         BC001I4_A501AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001I4_A502AppNotificationTopic = new string[] {""} ;
         BC001I5_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001I3_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001I3_A499AppNotificationTitle = new string[] {""} ;
         BC001I3_A500AppNotificationDescription = new string[] {""} ;
         BC001I3_A501AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001I3_A502AppNotificationTopic = new string[] {""} ;
         sMode95 = "";
         BC001I2_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001I2_A499AppNotificationTitle = new string[] {""} ;
         BC001I2_A500AppNotificationDescription = new string[] {""} ;
         BC001I2_A501AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001I2_A502AppNotificationTopic = new string[] {""} ;
         BC001I9_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001I10_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001I10_A499AppNotificationTitle = new string[] {""} ;
         BC001I10_A500AppNotificationDescription = new string[] {""} ;
         BC001I10_A501AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001I10_A502AppNotificationTopic = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001I2_A498AppNotificationId, BC001I2_A499AppNotificationTitle, BC001I2_A500AppNotificationDescription, BC001I2_A501AppNotificationDate, BC001I2_A502AppNotificationTopic
               }
               , new Object[] {
               BC001I3_A498AppNotificationId, BC001I3_A499AppNotificationTitle, BC001I3_A500AppNotificationDescription, BC001I3_A501AppNotificationDate, BC001I3_A502AppNotificationTopic
               }
               , new Object[] {
               BC001I4_A498AppNotificationId, BC001I4_A499AppNotificationTitle, BC001I4_A500AppNotificationDescription, BC001I4_A501AppNotificationDate, BC001I4_A502AppNotificationTopic
               }
               , new Object[] {
               BC001I5_A498AppNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001I9_A497ResidentNotificationId
               }
               , new Object[] {
               BC001I10_A498AppNotificationId, BC001I10_A499AppNotificationTitle, BC001I10_A500AppNotificationDescription, BC001I10_A501AppNotificationDate, BC001I10_A502AppNotificationTopic
               }
            }
         );
         Z498AppNotificationId = Guid.NewGuid( );
         A498AppNotificationId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound95 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode95 ;
      private DateTime Z501AppNotificationDate ;
      private DateTime A501AppNotificationDate ;
      private string Z499AppNotificationTitle ;
      private string A499AppNotificationTitle ;
      private string Z500AppNotificationDescription ;
      private string A500AppNotificationDescription ;
      private string Z502AppNotificationTopic ;
      private string A502AppNotificationTopic ;
      private Guid Z498AppNotificationId ;
      private Guid A498AppNotificationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001I4_A498AppNotificationId ;
      private string[] BC001I4_A499AppNotificationTitle ;
      private string[] BC001I4_A500AppNotificationDescription ;
      private DateTime[] BC001I4_A501AppNotificationDate ;
      private string[] BC001I4_A502AppNotificationTopic ;
      private Guid[] BC001I5_A498AppNotificationId ;
      private Guid[] BC001I3_A498AppNotificationId ;
      private string[] BC001I3_A499AppNotificationTitle ;
      private string[] BC001I3_A500AppNotificationDescription ;
      private DateTime[] BC001I3_A501AppNotificationDate ;
      private string[] BC001I3_A502AppNotificationTopic ;
      private Guid[] BC001I2_A498AppNotificationId ;
      private string[] BC001I2_A499AppNotificationTitle ;
      private string[] BC001I2_A500AppNotificationDescription ;
      private DateTime[] BC001I2_A501AppNotificationDate ;
      private string[] BC001I2_A502AppNotificationTopic ;
      private Guid[] BC001I9_A497ResidentNotificationId ;
      private Guid[] BC001I10_A498AppNotificationId ;
      private string[] BC001I10_A499AppNotificationTitle ;
      private string[] BC001I10_A500AppNotificationDescription ;
      private DateTime[] BC001I10_A501AppNotificationDate ;
      private string[] BC001I10_A502AppNotificationTopic ;
      private SdtTrn_AppNotification bcTrn_AppNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001I2;
       prmBC001I2 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I3;
       prmBC001I3 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I4;
       prmBC001I4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I5;
       prmBC001I5 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I6;
       prmBC001I6 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0)
       };
       Object[] prmBC001I7;
       prmBC001I7 = new Object[] {
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I8;
       prmBC001I8 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I9;
       prmBC001I9 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001I10;
       prmBC001I10 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001I2", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId  FOR UPDATE OF Trn_AppNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001I3", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001I4", "SELECT TM1.AppNotificationId, TM1.AppNotificationTitle, TM1.AppNotificationDescription, TM1.AppNotificationDate, TM1.AppNotificationTopic FROM Trn_AppNotification TM1 WHERE TM1.AppNotificationId = :AppNotificationId ORDER BY TM1.AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001I5", "SELECT AppNotificationId FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001I6", "SAVEPOINT gxupdate;INSERT INTO Trn_AppNotification(AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic) VALUES(:AppNotificationId, :AppNotificationTitle, :AppNotificationDescription, :AppNotificationDate, :AppNotificationTopic);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001I6)
          ,new CursorDef("BC001I7", "SAVEPOINT gxupdate;UPDATE Trn_AppNotification SET AppNotificationTitle=:AppNotificationTitle, AppNotificationDescription=:AppNotificationDescription, AppNotificationDate=:AppNotificationDate, AppNotificationTopic=:AppNotificationTopic  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001I7)
          ,new CursorDef("BC001I8", "SAVEPOINT gxupdate;DELETE FROM Trn_AppNotification  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001I8)
          ,new CursorDef("BC001I9", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001I10", "SELECT TM1.AppNotificationId, TM1.AppNotificationTitle, TM1.AppNotificationDescription, TM1.AppNotificationDate, TM1.AppNotificationTopic FROM Trn_AppNotification TM1 WHERE TM1.AppNotificationId = :AppNotificationId ORDER BY TM1.AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
    }
 }

}

}
