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
   public class trn_residentpackage_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_residentpackage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentpackage_bc( IGxContext context )
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
         ReadRow1R111( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1R111( ) ;
         standaloneModal( ) ;
         AddRow1R111( ) ;
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
            E111R2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z554ResidentPackageId = A554ResidentPackageId;
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

      protected void CONFIRM_1R0( )
      {
         BeforeValidate1R111( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1R111( ) ;
            }
            else
            {
               CheckExtendedTable1R111( ) ;
               if ( AnyError == 0 )
               {
                  ZM1R111( 13) ;
               }
               CloseExtendedTableCursors1R111( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121R2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            while ( AV35GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV32Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV33Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV35GXV1 = (int)(AV35GXV1+1);
            }
         }
      }

      protected void E111R2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1R111( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z557ResidentPackageName = A557ResidentPackageName;
            Z559ResidentPackageDefault = A559ResidentPackageDefault;
            Z555SG_LocationId = A555SG_LocationId;
            Z556SG_OrganisationId = A556SG_OrganisationId;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -12 )
         {
            Z554ResidentPackageId = A554ResidentPackageId;
            Z557ResidentPackageName = A557ResidentPackageName;
            Z558ResidentPackageModules = A558ResidentPackageModules;
            Z559ResidentPackageDefault = A559ResidentPackageDefault;
            Z555SG_LocationId = A555SG_LocationId;
            Z556SG_OrganisationId = A556SG_OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV34Pgmname = "Trn_ResidentPackage_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A554ResidentPackageId) )
         {
            A554ResidentPackageId = Guid.NewGuid( );
            n554ResidentPackageId = false;
         }
         GXt_guid1 = A555SG_LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A555SG_LocationId = GXt_guid1;
         GXt_guid1 = A556SG_OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A556SG_OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1R111( )
      {
         /* Using cursor BC001R5 */
         pr_default.execute(3, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound111 = 1;
            A557ResidentPackageName = BC001R5_A557ResidentPackageName[0];
            A558ResidentPackageModules = BC001R5_A558ResidentPackageModules[0];
            A559ResidentPackageDefault = BC001R5_A559ResidentPackageDefault[0];
            A555SG_LocationId = BC001R5_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001R5_A556SG_OrganisationId[0];
            ZM1R111( -12) ;
         }
         pr_default.close(3);
         OnLoadActions1R111( ) ;
      }

      protected void OnLoadActions1R111( )
      {
      }

      protected void CheckExtendedTable1R111( )
      {
         standaloneModal( ) ;
         if ( A559ResidentPackageDefault )
         {
            new prc_defaultresidetpackage(context ).execute(  A554ResidentPackageId, ref  A555SG_LocationId) ;
         }
         /* Using cursor BC001R4 */
         pr_default.execute(2, new Object[] {A555SG_LocationId, A556SG_OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A557ResidentPackageName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A558ResidentPackageModules) <= 2 )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Modules", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1R111( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1R111( )
      {
         /* Using cursor BC001R6 */
         pr_default.execute(4, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound111 = 1;
         }
         else
         {
            RcdFound111 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001R3 */
         pr_default.execute(1, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1R111( 12) ;
            RcdFound111 = 1;
            A554ResidentPackageId = BC001R3_A554ResidentPackageId[0];
            n554ResidentPackageId = BC001R3_n554ResidentPackageId[0];
            A557ResidentPackageName = BC001R3_A557ResidentPackageName[0];
            A558ResidentPackageModules = BC001R3_A558ResidentPackageModules[0];
            A559ResidentPackageDefault = BC001R3_A559ResidentPackageDefault[0];
            A555SG_LocationId = BC001R3_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001R3_A556SG_OrganisationId[0];
            Z554ResidentPackageId = A554ResidentPackageId;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1R111( ) ;
            if ( AnyError == 1 )
            {
               RcdFound111 = 0;
               InitializeNonKey1R111( ) ;
            }
            Gx_mode = sMode111;
         }
         else
         {
            RcdFound111 = 0;
            InitializeNonKey1R111( ) ;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode111;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1R111( ) ;
         if ( RcdFound111 == 0 )
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
         CONFIRM_1R0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1R111( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001R2 */
            pr_default.execute(0, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z557ResidentPackageName, BC001R2_A557ResidentPackageName[0]) != 0 ) || ( Z559ResidentPackageDefault != BC001R2_A559ResidentPackageDefault[0] ) || ( Z555SG_LocationId != BC001R2_A555SG_LocationId[0] ) || ( Z556SG_OrganisationId != BC001R2_A556SG_OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentPackage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1R111( )
      {
         BeforeValidate1R111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R111( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1R111( 0) ;
            CheckOptimisticConcurrency1R111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1R111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001R7 */
                     pr_default.execute(5, new Object[] {n554ResidentPackageId, A554ResidentPackageId, A557ResidentPackageName, A558ResidentPackageModules, A559ResidentPackageDefault, A555SG_LocationId, A556SG_OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
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
               Load1R111( ) ;
            }
            EndLevel1R111( ) ;
         }
         CloseExtendedTableCursors1R111( ) ;
      }

      protected void Update1R111( )
      {
         BeforeValidate1R111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R111( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1R111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001R8 */
                     pr_default.execute(6, new Object[] {A557ResidentPackageName, A558ResidentPackageModules, A559ResidentPackageDefault, A555SG_LocationId, A556SG_OrganisationId, n554ResidentPackageId, A554ResidentPackageId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1R111( ) ;
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
            EndLevel1R111( ) ;
         }
         CloseExtendedTableCursors1R111( ) ;
      }

      protected void DeferredUpdate1R111( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1R111( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R111( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1R111( ) ;
            AfterConfirm1R111( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1R111( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001R9 */
                  pr_default.execute(7, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
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
         sMode111 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1R111( ) ;
         Gx_mode = sMode111;
      }

      protected void OnDeleteControls1R111( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001R10 */
            pr_default.execute(8, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1R111( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1R111( ) ;
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

      public void ScanKeyStart1R111( )
      {
         /* Scan By routine */
         /* Using cursor BC001R11 */
         pr_default.execute(9, new Object[] {n554ResidentPackageId, A554ResidentPackageId});
         RcdFound111 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound111 = 1;
            A554ResidentPackageId = BC001R11_A554ResidentPackageId[0];
            n554ResidentPackageId = BC001R11_n554ResidentPackageId[0];
            A557ResidentPackageName = BC001R11_A557ResidentPackageName[0];
            A558ResidentPackageModules = BC001R11_A558ResidentPackageModules[0];
            A559ResidentPackageDefault = BC001R11_A559ResidentPackageDefault[0];
            A555SG_LocationId = BC001R11_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001R11_A556SG_OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1R111( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound111 = 0;
         ScanKeyLoad1R111( ) ;
      }

      protected void ScanKeyLoad1R111( )
      {
         sMode111 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound111 = 1;
            A554ResidentPackageId = BC001R11_A554ResidentPackageId[0];
            n554ResidentPackageId = BC001R11_n554ResidentPackageId[0];
            A557ResidentPackageName = BC001R11_A557ResidentPackageName[0];
            A558ResidentPackageModules = BC001R11_A558ResidentPackageModules[0];
            A559ResidentPackageDefault = BC001R11_A559ResidentPackageDefault[0];
            A555SG_LocationId = BC001R11_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001R11_A556SG_OrganisationId[0];
         }
         Gx_mode = sMode111;
      }

      protected void ScanKeyEnd1R111( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1R111( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1R111( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1R111( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1R111( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1R111( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1R111( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1R111( )
      {
      }

      protected void send_integrity_lvl_hashes1R111( )
      {
      }

      protected void AddRow1R111( )
      {
         VarsToRow111( bcTrn_ResidentPackage) ;
      }

      protected void ReadRow1R111( )
      {
         RowToVars111( bcTrn_ResidentPackage, 1) ;
      }

      protected void InitializeNonKey1R111( )
      {
         A555SG_LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         A557ResidentPackageName = "";
         A558ResidentPackageModules = "";
         A559ResidentPackageDefault = false;
         Z557ResidentPackageName = "";
         Z559ResidentPackageDefault = false;
         Z555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1R111( )
      {
         A554ResidentPackageId = Guid.NewGuid( );
         n554ResidentPackageId = false;
         InitializeNonKey1R111( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A555SG_LocationId = i555SG_LocationId;
         A556SG_OrganisationId = i556SG_OrganisationId;
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

      public void VarsToRow111( SdtTrn_ResidentPackage obj111 )
      {
         obj111.gxTpr_Mode = Gx_mode;
         obj111.gxTpr_Sg_locationid = A555SG_LocationId;
         obj111.gxTpr_Sg_organisationid = A556SG_OrganisationId;
         obj111.gxTpr_Residentpackagename = A557ResidentPackageName;
         obj111.gxTpr_Residentpackagemodules = A558ResidentPackageModules;
         obj111.gxTpr_Residentpackagedefault = A559ResidentPackageDefault;
         obj111.gxTpr_Residentpackageid = A554ResidentPackageId;
         obj111.gxTpr_Residentpackageid_Z = Z554ResidentPackageId;
         obj111.gxTpr_Sg_locationid_Z = Z555SG_LocationId;
         obj111.gxTpr_Sg_organisationid_Z = Z556SG_OrganisationId;
         obj111.gxTpr_Residentpackagename_Z = Z557ResidentPackageName;
         obj111.gxTpr_Residentpackagedefault_Z = Z559ResidentPackageDefault;
         obj111.gxTpr_Residentpackageid_N = (short)(Convert.ToInt16(n554ResidentPackageId));
         obj111.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow111( SdtTrn_ResidentPackage obj111 )
      {
         obj111.gxTpr_Residentpackageid = A554ResidentPackageId;
         return  ;
      }

      public void RowToVars111( SdtTrn_ResidentPackage obj111 ,
                                int forceLoad )
      {
         Gx_mode = obj111.gxTpr_Mode;
         A555SG_LocationId = obj111.gxTpr_Sg_locationid;
         A556SG_OrganisationId = obj111.gxTpr_Sg_organisationid;
         A557ResidentPackageName = obj111.gxTpr_Residentpackagename;
         A558ResidentPackageModules = obj111.gxTpr_Residentpackagemodules;
         A559ResidentPackageDefault = obj111.gxTpr_Residentpackagedefault;
         A554ResidentPackageId = obj111.gxTpr_Residentpackageid;
         n554ResidentPackageId = false;
         Z554ResidentPackageId = obj111.gxTpr_Residentpackageid_Z;
         Z555SG_LocationId = obj111.gxTpr_Sg_locationid_Z;
         Z556SG_OrganisationId = obj111.gxTpr_Sg_organisationid_Z;
         Z557ResidentPackageName = obj111.gxTpr_Residentpackagename_Z;
         Z559ResidentPackageDefault = obj111.gxTpr_Residentpackagedefault_Z;
         n554ResidentPackageId = (bool)(Convert.ToBoolean(obj111.gxTpr_Residentpackageid_N));
         Gx_mode = obj111.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A554ResidentPackageId = (Guid)getParm(obj,0);
         n554ResidentPackageId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1R111( ) ;
         ScanKeyStart1R111( ) ;
         if ( RcdFound111 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z554ResidentPackageId = A554ResidentPackageId;
         }
         ZM1R111( -12) ;
         OnLoadActions1R111( ) ;
         AddRow1R111( ) ;
         ScanKeyEnd1R111( ) ;
         if ( RcdFound111 == 0 )
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
         RowToVars111( bcTrn_ResidentPackage, 0) ;
         ScanKeyStart1R111( ) ;
         if ( RcdFound111 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z554ResidentPackageId = A554ResidentPackageId;
         }
         ZM1R111( -12) ;
         OnLoadActions1R111( ) ;
         AddRow1R111( ) ;
         ScanKeyEnd1R111( ) ;
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1R111( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1R111( ) ;
         }
         else
         {
            if ( RcdFound111 == 1 )
            {
               if ( A554ResidentPackageId != Z554ResidentPackageId )
               {
                  A554ResidentPackageId = Z554ResidentPackageId;
                  n554ResidentPackageId = false;
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
                  Update1R111( ) ;
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
                  if ( A554ResidentPackageId != Z554ResidentPackageId )
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
                        Insert1R111( ) ;
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
                        Insert1R111( ) ;
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
         RowToVars111( bcTrn_ResidentPackage, 1) ;
         SaveImpl( ) ;
         VarsToRow111( bcTrn_ResidentPackage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars111( bcTrn_ResidentPackage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1R111( ) ;
         AfterTrn( ) ;
         VarsToRow111( bcTrn_ResidentPackage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow111( bcTrn_ResidentPackage) ;
         }
         else
         {
            SdtTrn_ResidentPackage auxBC = new SdtTrn_ResidentPackage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A554ResidentPackageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ResidentPackage);
               auxBC.Save();
               bcTrn_ResidentPackage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars111( bcTrn_ResidentPackage, 1) ;
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
         RowToVars111( bcTrn_ResidentPackage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1R111( ) ;
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
               VarsToRow111( bcTrn_ResidentPackage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow111( bcTrn_ResidentPackage) ;
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
         RowToVars111( bcTrn_ResidentPackage, 0) ;
         GetKey1R111( ) ;
         if ( RcdFound111 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A554ResidentPackageId != Z554ResidentPackageId )
            {
               A554ResidentPackageId = Z554ResidentPackageId;
               n554ResidentPackageId = false;
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
            if ( A554ResidentPackageId != Z554ResidentPackageId )
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
         context.RollbackDataStores("trn_residentpackage_bc",pr_default);
         VarsToRow111( bcTrn_ResidentPackage) ;
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
         Gx_mode = bcTrn_ResidentPackage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ResidentPackage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ResidentPackage )
         {
            bcTrn_ResidentPackage = (SdtTrn_ResidentPackage)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ResidentPackage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentPackage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow111( bcTrn_ResidentPackage) ;
            }
            else
            {
               RowToVars111( bcTrn_ResidentPackage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ResidentPackage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentPackage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars111( bcTrn_ResidentPackage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ResidentPackage Trn_ResidentPackage_BC
      {
         get {
            return bcTrn_ResidentPackage ;
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
            return "trn_residentpackage_Execute" ;
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
         Z554ResidentPackageId = Guid.Empty;
         A554ResidentPackageId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV34Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV32Insert_SG_LocationId = Guid.Empty;
         AV33Insert_SG_OrganisationId = Guid.Empty;
         Z557ResidentPackageName = "";
         A557ResidentPackageName = "";
         Z555SG_LocationId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         Z558ResidentPackageModules = "";
         A558ResidentPackageModules = "";
         GXt_guid1 = Guid.Empty;
         BC001R5_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001R5_n554ResidentPackageId = new bool[] {false} ;
         BC001R5_A557ResidentPackageName = new string[] {""} ;
         BC001R5_A558ResidentPackageModules = new string[] {""} ;
         BC001R5_A559ResidentPackageDefault = new bool[] {false} ;
         BC001R5_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001R5_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001R4_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001R6_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001R6_n554ResidentPackageId = new bool[] {false} ;
         BC001R3_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001R3_n554ResidentPackageId = new bool[] {false} ;
         BC001R3_A557ResidentPackageName = new string[] {""} ;
         BC001R3_A558ResidentPackageModules = new string[] {""} ;
         BC001R3_A559ResidentPackageDefault = new bool[] {false} ;
         BC001R3_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001R3_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         sMode111 = "";
         BC001R2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001R2_n554ResidentPackageId = new bool[] {false} ;
         BC001R2_A557ResidentPackageName = new string[] {""} ;
         BC001R2_A558ResidentPackageModules = new string[] {""} ;
         BC001R2_A559ResidentPackageDefault = new bool[] {false} ;
         BC001R2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001R2_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001R10_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001R10_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001R10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001R11_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001R11_n554ResidentPackageId = new bool[] {false} ;
         BC001R11_A557ResidentPackageName = new string[] {""} ;
         BC001R11_A558ResidentPackageModules = new string[] {""} ;
         BC001R11_A559ResidentPackageDefault = new bool[] {false} ;
         BC001R11_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001R11_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         i555SG_LocationId = Guid.Empty;
         i556SG_OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__default(),
            new Object[][] {
                new Object[] {
               BC001R2_A554ResidentPackageId, BC001R2_A557ResidentPackageName, BC001R2_A558ResidentPackageModules, BC001R2_A559ResidentPackageDefault, BC001R2_A555SG_LocationId, BC001R2_A556SG_OrganisationId
               }
               , new Object[] {
               BC001R3_A554ResidentPackageId, BC001R3_A557ResidentPackageName, BC001R3_A558ResidentPackageModules, BC001R3_A559ResidentPackageDefault, BC001R3_A555SG_LocationId, BC001R3_A556SG_OrganisationId
               }
               , new Object[] {
               BC001R4_A555SG_LocationId
               }
               , new Object[] {
               BC001R5_A554ResidentPackageId, BC001R5_A557ResidentPackageName, BC001R5_A558ResidentPackageModules, BC001R5_A559ResidentPackageDefault, BC001R5_A555SG_LocationId, BC001R5_A556SG_OrganisationId
               }
               , new Object[] {
               BC001R6_A554ResidentPackageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001R10_A62ResidentId, BC001R10_A29LocationId, BC001R10_A11OrganisationId
               }
               , new Object[] {
               BC001R11_A554ResidentPackageId, BC001R11_A557ResidentPackageName, BC001R11_A558ResidentPackageModules, BC001R11_A559ResidentPackageDefault, BC001R11_A555SG_LocationId, BC001R11_A556SG_OrganisationId
               }
            }
         );
         Z554ResidentPackageId = Guid.NewGuid( );
         n554ResidentPackageId = false;
         A554ResidentPackageId = Guid.NewGuid( );
         n554ResidentPackageId = false;
         AV34Pgmname = "Trn_ResidentPackage_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121R2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound111 ;
      private int trnEnded ;
      private int AV35GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV34Pgmname ;
      private string sMode111 ;
      private bool returnInSub ;
      private bool Z559ResidentPackageDefault ;
      private bool A559ResidentPackageDefault ;
      private bool n554ResidentPackageId ;
      private string Z558ResidentPackageModules ;
      private string A558ResidentPackageModules ;
      private string Z557ResidentPackageName ;
      private string A557ResidentPackageName ;
      private Guid Z554ResidentPackageId ;
      private Guid A554ResidentPackageId ;
      private Guid AV32Insert_SG_LocationId ;
      private Guid AV33Insert_SG_OrganisationId ;
      private Guid Z555SG_LocationId ;
      private Guid A555SG_LocationId ;
      private Guid Z556SG_OrganisationId ;
      private Guid A556SG_OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i555SG_LocationId ;
      private Guid i556SG_OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001R5_A554ResidentPackageId ;
      private bool[] BC001R5_n554ResidentPackageId ;
      private string[] BC001R5_A557ResidentPackageName ;
      private string[] BC001R5_A558ResidentPackageModules ;
      private bool[] BC001R5_A559ResidentPackageDefault ;
      private Guid[] BC001R5_A555SG_LocationId ;
      private Guid[] BC001R5_A556SG_OrganisationId ;
      private Guid[] BC001R4_A555SG_LocationId ;
      private Guid[] BC001R6_A554ResidentPackageId ;
      private bool[] BC001R6_n554ResidentPackageId ;
      private Guid[] BC001R3_A554ResidentPackageId ;
      private bool[] BC001R3_n554ResidentPackageId ;
      private string[] BC001R3_A557ResidentPackageName ;
      private string[] BC001R3_A558ResidentPackageModules ;
      private bool[] BC001R3_A559ResidentPackageDefault ;
      private Guid[] BC001R3_A555SG_LocationId ;
      private Guid[] BC001R3_A556SG_OrganisationId ;
      private Guid[] BC001R2_A554ResidentPackageId ;
      private bool[] BC001R2_n554ResidentPackageId ;
      private string[] BC001R2_A557ResidentPackageName ;
      private string[] BC001R2_A558ResidentPackageModules ;
      private bool[] BC001R2_A559ResidentPackageDefault ;
      private Guid[] BC001R2_A555SG_LocationId ;
      private Guid[] BC001R2_A556SG_OrganisationId ;
      private Guid[] BC001R10_A62ResidentId ;
      private Guid[] BC001R10_A29LocationId ;
      private Guid[] BC001R10_A11OrganisationId ;
      private Guid[] BC001R11_A554ResidentPackageId ;
      private bool[] BC001R11_n554ResidentPackageId ;
      private string[] BC001R11_A557ResidentPackageName ;
      private string[] BC001R11_A558ResidentPackageModules ;
      private bool[] BC001R11_A559ResidentPackageDefault ;
      private Guid[] BC001R11_A555SG_LocationId ;
      private Guid[] BC001R11_A556SG_OrganisationId ;
      private SdtTrn_ResidentPackage bcTrn_ResidentPackage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentpackage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentpackage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentpackage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001R2;
       prmBC001R2 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R3;
       prmBC001R3 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R4;
       prmBC001R4 = new Object[] {
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001R5;
       prmBC001R5 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R6;
       prmBC001R6 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R7;
       prmBC001R7 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001R8;
       prmBC001R8 = new Object[] {
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R9;
       prmBC001R9 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R10;
       prmBC001R10 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001R11;
       prmBC001R11 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC001R2", "SELECT ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId  FOR UPDATE OF Trn_ResidentPackage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001R3", "SELECT ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001R4", "SELECT LocationId AS SG_LocationId FROM Trn_Location WHERE LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001R5", "SELECT TM1.ResidentPackageId, TM1.ResidentPackageName, TM1.ResidentPackageModules, TM1.ResidentPackageDefault, TM1.SG_LocationId AS SG_LocationId, TM1.SG_OrganisationId AS SG_OrganisationId FROM Trn_ResidentPackage TM1 WHERE TM1.ResidentPackageId = :ResidentPackageId ORDER BY TM1.ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001R6", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001R7", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentPackage(ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId) VALUES(:ResidentPackageId, :ResidentPackageName, :ResidentPackageModules, :ResidentPackageDefault, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001R7)
          ,new CursorDef("BC001R8", "SAVEPOINT gxupdate;UPDATE Trn_ResidentPackage SET ResidentPackageName=:ResidentPackageName, ResidentPackageModules=:ResidentPackageModules, ResidentPackageDefault=:ResidentPackageDefault, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001R8)
          ,new CursorDef("BC001R9", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentPackage  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001R9)
          ,new CursorDef("BC001R10", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001R11", "SELECT TM1.ResidentPackageId, TM1.ResidentPackageName, TM1.ResidentPackageModules, TM1.ResidentPackageDefault, TM1.SG_LocationId AS SG_LocationId, TM1.SG_OrganisationId AS SG_OrganisationId FROM Trn_ResidentPackage TM1 WHERE TM1.ResidentPackageId = :ResidentPackageId ORDER BY TM1.ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
    }
 }

}

}
