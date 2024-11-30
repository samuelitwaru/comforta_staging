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
   public class trn_template_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_template_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_template_bc( IGxContext context )
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
         ReadRow1053( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1053( ) ;
         standaloneModal( ) ;
         AddRow1053( ) ;
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
            /* Execute user event: After Trn */
            E11102 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z278Trn_TemplateId = A278Trn_TemplateId;
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

      protected void CONFIRM_100( )
      {
         BeforeValidate1053( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1053( ) ;
            }
            else
            {
               CheckExtendedTable1053( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1053( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12102( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11102( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1053( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z279Trn_TemplateName = A279Trn_TemplateName;
            Z280Trn_TemplateMedia = A280Trn_TemplateMedia;
         }
         if ( GX_JID == -3 )
         {
            Z278Trn_TemplateId = A278Trn_TemplateId;
            Z279Trn_TemplateName = A279Trn_TemplateName;
            Z280Trn_TemplateMedia = A280Trn_TemplateMedia;
            Z281Trn_TemplateContent = A281Trn_TemplateContent;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A278Trn_TemplateId) )
         {
            A278Trn_TemplateId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1053( )
      {
         /* Using cursor BC00104 */
         pr_default.execute(2, new Object[] {A278Trn_TemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound53 = 1;
            A279Trn_TemplateName = BC00104_A279Trn_TemplateName[0];
            A280Trn_TemplateMedia = BC00104_A280Trn_TemplateMedia[0];
            A281Trn_TemplateContent = BC00104_A281Trn_TemplateContent[0];
            ZM1053( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1053( ) ;
      }

      protected void OnLoadActions1053( )
      {
      }

      protected void CheckExtendedTable1053( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1053( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1053( )
      {
         /* Using cursor BC00105 */
         pr_default.execute(3, new Object[] {A278Trn_TemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00103 */
         pr_default.execute(1, new Object[] {A278Trn_TemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1053( 3) ;
            RcdFound53 = 1;
            A278Trn_TemplateId = BC00103_A278Trn_TemplateId[0];
            A279Trn_TemplateName = BC00103_A279Trn_TemplateName[0];
            A280Trn_TemplateMedia = BC00103_A280Trn_TemplateMedia[0];
            A281Trn_TemplateContent = BC00103_A281Trn_TemplateContent[0];
            Z278Trn_TemplateId = A278Trn_TemplateId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1053( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1053( ) ;
            }
            Gx_mode = sMode53;
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1053( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode53;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1053( ) ;
         if ( RcdFound53 == 0 )
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
         CONFIRM_100( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1053( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00102 */
            pr_default.execute(0, new Object[] {A278Trn_TemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Template"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z279Trn_TemplateName, BC00102_A279Trn_TemplateName[0]) != 0 ) || ( StringUtil.StrCmp(Z280Trn_TemplateMedia, BC00102_A280Trn_TemplateMedia[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Template"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1053( )
      {
         BeforeValidate1053( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1053( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1053( 0) ;
            CheckOptimisticConcurrency1053( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1053( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1053( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00106 */
                     pr_default.execute(4, new Object[] {A278Trn_TemplateId, A279Trn_TemplateName, A280Trn_TemplateMedia, A281Trn_TemplateContent});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
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
               Load1053( ) ;
            }
            EndLevel1053( ) ;
         }
         CloseExtendedTableCursors1053( ) ;
      }

      protected void Update1053( )
      {
         BeforeValidate1053( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1053( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1053( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1053( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1053( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00107 */
                     pr_default.execute(5, new Object[] {A279Trn_TemplateName, A280Trn_TemplateMedia, A281Trn_TemplateContent, A278Trn_TemplateId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Template"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1053( ) ;
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
            EndLevel1053( ) ;
         }
         CloseExtendedTableCursors1053( ) ;
      }

      protected void DeferredUpdate1053( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1053( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1053( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1053( ) ;
            AfterConfirm1053( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1053( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00108 */
                  pr_default.execute(6, new Object[] {A278Trn_TemplateId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1053( ) ;
         Gx_mode = sMode53;
      }

      protected void OnDeleteControls1053( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1053( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1053( ) ;
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

      public void ScanKeyStart1053( )
      {
         /* Scan By routine */
         /* Using cursor BC00109 */
         pr_default.execute(7, new Object[] {A278Trn_TemplateId});
         RcdFound53 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound53 = 1;
            A278Trn_TemplateId = BC00109_A278Trn_TemplateId[0];
            A279Trn_TemplateName = BC00109_A279Trn_TemplateName[0];
            A280Trn_TemplateMedia = BC00109_A280Trn_TemplateMedia[0];
            A281Trn_TemplateContent = BC00109_A281Trn_TemplateContent[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1053( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound53 = 0;
         ScanKeyLoad1053( ) ;
      }

      protected void ScanKeyLoad1053( )
      {
         sMode53 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound53 = 1;
            A278Trn_TemplateId = BC00109_A278Trn_TemplateId[0];
            A279Trn_TemplateName = BC00109_A279Trn_TemplateName[0];
            A280Trn_TemplateMedia = BC00109_A280Trn_TemplateMedia[0];
            A281Trn_TemplateContent = BC00109_A281Trn_TemplateContent[0];
         }
         Gx_mode = sMode53;
      }

      protected void ScanKeyEnd1053( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1053( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1053( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1053( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1053( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1053( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1053( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1053( )
      {
      }

      protected void send_integrity_lvl_hashes1053( )
      {
      }

      protected void AddRow1053( )
      {
         VarsToRow53( bcTrn_Template) ;
      }

      protected void ReadRow1053( )
      {
         RowToVars53( bcTrn_Template, 1) ;
      }

      protected void InitializeNonKey1053( )
      {
         A279Trn_TemplateName = "";
         A280Trn_TemplateMedia = "";
         A281Trn_TemplateContent = "";
         Z279Trn_TemplateName = "";
         Z280Trn_TemplateMedia = "";
      }

      protected void InitAll1053( )
      {
         A278Trn_TemplateId = Guid.NewGuid( );
         InitializeNonKey1053( ) ;
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

      public void VarsToRow53( SdtTrn_Template obj53 )
      {
         obj53.gxTpr_Mode = Gx_mode;
         obj53.gxTpr_Trn_templatename = A279Trn_TemplateName;
         obj53.gxTpr_Trn_templatemedia = A280Trn_TemplateMedia;
         obj53.gxTpr_Trn_templatecontent = A281Trn_TemplateContent;
         obj53.gxTpr_Trn_templateid = A278Trn_TemplateId;
         obj53.gxTpr_Trn_templateid_Z = Z278Trn_TemplateId;
         obj53.gxTpr_Trn_templatename_Z = Z279Trn_TemplateName;
         obj53.gxTpr_Trn_templatemedia_Z = Z280Trn_TemplateMedia;
         obj53.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow53( SdtTrn_Template obj53 )
      {
         obj53.gxTpr_Trn_templateid = A278Trn_TemplateId;
         return  ;
      }

      public void RowToVars53( SdtTrn_Template obj53 ,
                               int forceLoad )
      {
         Gx_mode = obj53.gxTpr_Mode;
         A279Trn_TemplateName = obj53.gxTpr_Trn_templatename;
         A280Trn_TemplateMedia = obj53.gxTpr_Trn_templatemedia;
         A281Trn_TemplateContent = obj53.gxTpr_Trn_templatecontent;
         A278Trn_TemplateId = obj53.gxTpr_Trn_templateid;
         Z278Trn_TemplateId = obj53.gxTpr_Trn_templateid_Z;
         Z279Trn_TemplateName = obj53.gxTpr_Trn_templatename_Z;
         Z280Trn_TemplateMedia = obj53.gxTpr_Trn_templatemedia_Z;
         Gx_mode = obj53.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A278Trn_TemplateId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1053( ) ;
         ScanKeyStart1053( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z278Trn_TemplateId = A278Trn_TemplateId;
         }
         ZM1053( -3) ;
         OnLoadActions1053( ) ;
         AddRow1053( ) ;
         ScanKeyEnd1053( ) ;
         if ( RcdFound53 == 0 )
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
         RowToVars53( bcTrn_Template, 0) ;
         ScanKeyStart1053( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z278Trn_TemplateId = A278Trn_TemplateId;
         }
         ZM1053( -3) ;
         OnLoadActions1053( ) ;
         AddRow1053( ) ;
         ScanKeyEnd1053( ) ;
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1053( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1053( ) ;
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A278Trn_TemplateId != Z278Trn_TemplateId )
               {
                  A278Trn_TemplateId = Z278Trn_TemplateId;
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
                  Update1053( ) ;
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
                  if ( A278Trn_TemplateId != Z278Trn_TemplateId )
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
                        Insert1053( ) ;
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
                        Insert1053( ) ;
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
         RowToVars53( bcTrn_Template, 1) ;
         SaveImpl( ) ;
         VarsToRow53( bcTrn_Template) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars53( bcTrn_Template, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1053( ) ;
         AfterTrn( ) ;
         VarsToRow53( bcTrn_Template) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow53( bcTrn_Template) ;
         }
         else
         {
            SdtTrn_Template auxBC = new SdtTrn_Template(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A278Trn_TemplateId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Template);
               auxBC.Save();
               bcTrn_Template.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars53( bcTrn_Template, 1) ;
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
         RowToVars53( bcTrn_Template, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1053( ) ;
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
               VarsToRow53( bcTrn_Template) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow53( bcTrn_Template) ;
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
         RowToVars53( bcTrn_Template, 0) ;
         GetKey1053( ) ;
         if ( RcdFound53 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A278Trn_TemplateId != Z278Trn_TemplateId )
            {
               A278Trn_TemplateId = Z278Trn_TemplateId;
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
            if ( A278Trn_TemplateId != Z278Trn_TemplateId )
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
         context.RollbackDataStores("trn_template_bc",pr_default);
         VarsToRow53( bcTrn_Template) ;
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
         Gx_mode = bcTrn_Template.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Template.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Template )
         {
            bcTrn_Template = (SdtTrn_Template)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Template.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Template.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow53( bcTrn_Template) ;
            }
            else
            {
               RowToVars53( bcTrn_Template, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Template.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Template.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars53( bcTrn_Template, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Template Trn_Template_BC
      {
         get {
            return bcTrn_Template ;
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
            return "trn_template_Execute" ;
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
         Z278Trn_TemplateId = Guid.Empty;
         A278Trn_TemplateId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z279Trn_TemplateName = "";
         A279Trn_TemplateName = "";
         Z280Trn_TemplateMedia = "";
         A280Trn_TemplateMedia = "";
         Z281Trn_TemplateContent = "";
         A281Trn_TemplateContent = "";
         BC00104_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00104_A279Trn_TemplateName = new string[] {""} ;
         BC00104_A280Trn_TemplateMedia = new string[] {""} ;
         BC00104_A281Trn_TemplateContent = new string[] {""} ;
         BC00105_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00103_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00103_A279Trn_TemplateName = new string[] {""} ;
         BC00103_A280Trn_TemplateMedia = new string[] {""} ;
         BC00103_A281Trn_TemplateContent = new string[] {""} ;
         sMode53 = "";
         BC00102_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00102_A279Trn_TemplateName = new string[] {""} ;
         BC00102_A280Trn_TemplateMedia = new string[] {""} ;
         BC00102_A281Trn_TemplateContent = new string[] {""} ;
         BC00109_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00109_A279Trn_TemplateName = new string[] {""} ;
         BC00109_A280Trn_TemplateMedia = new string[] {""} ;
         BC00109_A281Trn_TemplateContent = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__default(),
            new Object[][] {
                new Object[] {
               BC00102_A278Trn_TemplateId, BC00102_A279Trn_TemplateName, BC00102_A280Trn_TemplateMedia, BC00102_A281Trn_TemplateContent
               }
               , new Object[] {
               BC00103_A278Trn_TemplateId, BC00103_A279Trn_TemplateName, BC00103_A280Trn_TemplateMedia, BC00103_A281Trn_TemplateContent
               }
               , new Object[] {
               BC00104_A278Trn_TemplateId, BC00104_A279Trn_TemplateName, BC00104_A280Trn_TemplateMedia, BC00104_A281Trn_TemplateContent
               }
               , new Object[] {
               BC00105_A278Trn_TemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00109_A278Trn_TemplateId, BC00109_A279Trn_TemplateName, BC00109_A280Trn_TemplateMedia, BC00109_A281Trn_TemplateContent
               }
            }
         );
         Z278Trn_TemplateId = Guid.NewGuid( );
         A278Trn_TemplateId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12102 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound53 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode53 ;
      private bool returnInSub ;
      private string Z281Trn_TemplateContent ;
      private string A281Trn_TemplateContent ;
      private string Z279Trn_TemplateName ;
      private string A279Trn_TemplateName ;
      private string Z280Trn_TemplateMedia ;
      private string A280Trn_TemplateMedia ;
      private Guid Z278Trn_TemplateId ;
      private Guid A278Trn_TemplateId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00104_A278Trn_TemplateId ;
      private string[] BC00104_A279Trn_TemplateName ;
      private string[] BC00104_A280Trn_TemplateMedia ;
      private string[] BC00104_A281Trn_TemplateContent ;
      private Guid[] BC00105_A278Trn_TemplateId ;
      private Guid[] BC00103_A278Trn_TemplateId ;
      private string[] BC00103_A279Trn_TemplateName ;
      private string[] BC00103_A280Trn_TemplateMedia ;
      private string[] BC00103_A281Trn_TemplateContent ;
      private Guid[] BC00102_A278Trn_TemplateId ;
      private string[] BC00102_A279Trn_TemplateName ;
      private string[] BC00102_A280Trn_TemplateMedia ;
      private string[] BC00102_A281Trn_TemplateContent ;
      private Guid[] BC00109_A278Trn_TemplateId ;
      private string[] BC00109_A279Trn_TemplateName ;
      private string[] BC00109_A280Trn_TemplateMedia ;
      private string[] BC00109_A281Trn_TemplateContent ;
      private SdtTrn_Template bcTrn_Template ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_template_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_template_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_template_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00102;
       prmBC00102 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00103;
       prmBC00103 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00104;
       prmBC00104 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00105;
       prmBC00105 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00106;
       prmBC00106 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_TemplateName",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateMedia",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateContent",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC00107;
       prmBC00107 = new Object[] {
       new ParDef("Trn_TemplateName",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateMedia",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateContent",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00108;
       prmBC00108 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00109;
       prmBC00109 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00102", "SELECT Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId  FOR UPDATE OF Trn_Template",true, GxErrorMask.GX_NOMASK, false, this,prmBC00102,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00103", "SELECT Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00103,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00104", "SELECT TM1.Trn_TemplateId, TM1.Trn_TemplateName, TM1.Trn_TemplateMedia, TM1.Trn_TemplateContent FROM Trn_Template TM1 WHERE TM1.Trn_TemplateId = :Trn_TemplateId ORDER BY TM1.Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00104,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00105", "SELECT Trn_TemplateId FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00105,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00106", "SAVEPOINT gxupdate;INSERT INTO Trn_Template(Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent) VALUES(:Trn_TemplateId, :Trn_TemplateName, :Trn_TemplateMedia, :Trn_TemplateContent);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00106)
          ,new CursorDef("BC00107", "SAVEPOINT gxupdate;UPDATE Trn_Template SET Trn_TemplateName=:Trn_TemplateName, Trn_TemplateMedia=:Trn_TemplateMedia, Trn_TemplateContent=:Trn_TemplateContent  WHERE Trn_TemplateId = :Trn_TemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00107)
          ,new CursorDef("BC00108", "SAVEPOINT gxupdate;DELETE FROM Trn_Template  WHERE Trn_TemplateId = :Trn_TemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00108)
          ,new CursorDef("BC00109", "SELECT TM1.Trn_TemplateId, TM1.Trn_TemplateName, TM1.Trn_TemplateMedia, TM1.Trn_TemplateContent FROM Trn_Template TM1 WHERE TM1.Trn_TemplateId = :Trn_TemplateId ORDER BY TM1.Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00109,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
    }
 }

}

}
