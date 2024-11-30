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
   public class trn_amenity_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_amenity_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_amenity_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0573( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0573( ) ;
         standaloneModal( ) ;
         AddRow0573( ) ;
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
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z39AmenityId = A39AmenityId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate0573( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0573( ) ;
            }
            else
            {
               CheckExtendedTable0573( ) ;
               if ( AnyError == 0 )
               {
                  ZM0573( 10) ;
               }
               CloseExtendedTableCursors0573( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0573( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z40AmenityName = A40AmenityName;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z39AmenityId = A39AmenityId;
            Z40AmenityName = A40AmenityName;
            Z41AmenityDescription = A41AmenityDescription;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A39AmenityId) )
         {
            A39AmenityId = Guid.NewGuid( );
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

      protected void Load0573( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound73 = 1;
            A40AmenityName = BC00055_A40AmenityName[0];
            A41AmenityDescription = BC00055_A41AmenityDescription[0];
            ZM0573( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0573( ) ;
      }

      protected void OnLoadActions0573( )
      {
      }

      protected void CheckExtendedTable0573( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A40AmenityName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Amenity Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A41AmenityDescription)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Amenity Description", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0573( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0573( )
      {
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0573( 9) ;
            RcdFound73 = 1;
            A39AmenityId = BC00053_A39AmenityId[0];
            A40AmenityName = BC00053_A40AmenityName[0];
            A41AmenityDescription = BC00053_A41AmenityDescription[0];
            A29LocationId = BC00053_A29LocationId[0];
            A11OrganisationId = BC00053_A11OrganisationId[0];
            Z39AmenityId = A39AmenityId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0573( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey0573( ) ;
            }
            Gx_mode = sMode73;
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey0573( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode73;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0573( ) ;
         if ( RcdFound73 == 0 )
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
         CONFIRM_050( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0573( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Amenity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z40AmenityName, BC00052_A40AmenityName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Amenity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0573( )
      {
         BeforeValidate0573( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0573( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0573( 0) ;
            CheckOptimisticConcurrency0573( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0573( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0573( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00057 */
                     pr_default.execute(5, new Object[] {A39AmenityId, A40AmenityName, A41AmenityDescription, A29LocationId, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Amenity");
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
               Load0573( ) ;
            }
            EndLevel0573( ) ;
         }
         CloseExtendedTableCursors0573( ) ;
      }

      protected void Update0573( )
      {
         BeforeValidate0573( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0573( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0573( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0573( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0573( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00058 */
                     pr_default.execute(6, new Object[] {A40AmenityName, A41AmenityDescription, A39AmenityId, A29LocationId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Amenity");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Amenity"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0573( ) ;
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
            EndLevel0573( ) ;
         }
         CloseExtendedTableCursors0573( ) ;
      }

      protected void DeferredUpdate0573( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0573( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0573( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0573( ) ;
            AfterConfirm0573( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0573( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00059 */
                  pr_default.execute(7, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Amenity");
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0573( ) ;
         Gx_mode = sMode73;
      }

      protected void OnDeleteControls0573( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0573( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0573( ) ;
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

      public void ScanKeyStart0573( )
      {
         /* Scan By routine */
         /* Using cursor BC000510 */
         pr_default.execute(8, new Object[] {A39AmenityId, A29LocationId, A11OrganisationId});
         RcdFound73 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A39AmenityId = BC000510_A39AmenityId[0];
            A40AmenityName = BC000510_A40AmenityName[0];
            A41AmenityDescription = BC000510_A41AmenityDescription[0];
            A29LocationId = BC000510_A29LocationId[0];
            A11OrganisationId = BC000510_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0573( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound73 = 0;
         ScanKeyLoad0573( ) ;
      }

      protected void ScanKeyLoad0573( )
      {
         sMode73 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A39AmenityId = BC000510_A39AmenityId[0];
            A40AmenityName = BC000510_A40AmenityName[0];
            A41AmenityDescription = BC000510_A41AmenityDescription[0];
            A29LocationId = BC000510_A29LocationId[0];
            A11OrganisationId = BC000510_A11OrganisationId[0];
         }
         Gx_mode = sMode73;
      }

      protected void ScanKeyEnd0573( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0573( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0573( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0573( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0573( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0573( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0573( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0573( )
      {
      }

      protected void send_integrity_lvl_hashes0573( )
      {
      }

      protected void AddRow0573( )
      {
         VarsToRow73( bcTrn_Amenity) ;
      }

      protected void ReadRow0573( )
      {
         RowToVars73( bcTrn_Amenity, 1) ;
      }

      protected void InitializeNonKey0573( )
      {
         A40AmenityName = "";
         A41AmenityDescription = "";
         Z40AmenityName = "";
      }

      protected void InitAll0573( )
      {
         A39AmenityId = Guid.NewGuid( );
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         InitializeNonKey0573( ) ;
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

      public void VarsToRow73( SdtTrn_Amenity obj73 )
      {
         obj73.gxTpr_Mode = Gx_mode;
         obj73.gxTpr_Amenityname = A40AmenityName;
         obj73.gxTpr_Amenitydescription = A41AmenityDescription;
         obj73.gxTpr_Amenityid = A39AmenityId;
         obj73.gxTpr_Locationid = A29LocationId;
         obj73.gxTpr_Organisationid = A11OrganisationId;
         obj73.gxTpr_Amenityid_Z = Z39AmenityId;
         obj73.gxTpr_Locationid_Z = Z29LocationId;
         obj73.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj73.gxTpr_Amenityname_Z = Z40AmenityName;
         obj73.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow73( SdtTrn_Amenity obj73 )
      {
         obj73.gxTpr_Amenityid = A39AmenityId;
         obj73.gxTpr_Locationid = A29LocationId;
         obj73.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars73( SdtTrn_Amenity obj73 ,
                               int forceLoad )
      {
         Gx_mode = obj73.gxTpr_Mode;
         A40AmenityName = obj73.gxTpr_Amenityname;
         A41AmenityDescription = obj73.gxTpr_Amenitydescription;
         A39AmenityId = obj73.gxTpr_Amenityid;
         A29LocationId = obj73.gxTpr_Locationid;
         A11OrganisationId = obj73.gxTpr_Organisationid;
         Z39AmenityId = obj73.gxTpr_Amenityid_Z;
         Z29LocationId = obj73.gxTpr_Locationid_Z;
         Z11OrganisationId = obj73.gxTpr_Organisationid_Z;
         Z40AmenityName = obj73.gxTpr_Amenityname_Z;
         Gx_mode = obj73.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A39AmenityId = (Guid)getParm(obj,0);
         A29LocationId = (Guid)getParm(obj,1);
         A11OrganisationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0573( ) ;
         ScanKeyStart0573( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000511 */
            pr_default.execute(9, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z39AmenityId = A39AmenityId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0573( -9) ;
         OnLoadActions0573( ) ;
         AddRow0573( ) ;
         ScanKeyEnd0573( ) ;
         if ( RcdFound73 == 0 )
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
         RowToVars73( bcTrn_Amenity, 0) ;
         ScanKeyStart0573( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000511 */
            pr_default.execute(9, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z39AmenityId = A39AmenityId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0573( -9) ;
         OnLoadActions0573( ) ;
         AddRow0573( ) ;
         ScanKeyEnd0573( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0573( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0573( ) ;
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( ( A39AmenityId != Z39AmenityId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A39AmenityId = Z39AmenityId;
                  A29LocationId = Z29LocationId;
                  A11OrganisationId = Z11OrganisationId;
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
                  Update0573( ) ;
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
                  if ( ( A39AmenityId != Z39AmenityId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert0573( ) ;
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
                        Insert0573( ) ;
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
         RowToVars73( bcTrn_Amenity, 1) ;
         SaveImpl( ) ;
         VarsToRow73( bcTrn_Amenity) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars73( bcTrn_Amenity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0573( ) ;
         AfterTrn( ) ;
         VarsToRow73( bcTrn_Amenity) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow73( bcTrn_Amenity) ;
         }
         else
         {
            SdtTrn_Amenity auxBC = new SdtTrn_Amenity(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A39AmenityId, A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Amenity);
               auxBC.Save();
               bcTrn_Amenity.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars73( bcTrn_Amenity, 1) ;
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
         RowToVars73( bcTrn_Amenity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0573( ) ;
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
               VarsToRow73( bcTrn_Amenity) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow73( bcTrn_Amenity) ;
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
         RowToVars73( bcTrn_Amenity, 0) ;
         GetKey0573( ) ;
         if ( RcdFound73 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A39AmenityId != Z39AmenityId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A39AmenityId = Z39AmenityId;
               A29LocationId = Z29LocationId;
               A11OrganisationId = Z11OrganisationId;
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
            if ( ( A39AmenityId != Z39AmenityId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_amenity_bc",pr_default);
         VarsToRow73( bcTrn_Amenity) ;
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
         Gx_mode = bcTrn_Amenity.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Amenity.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Amenity )
         {
            bcTrn_Amenity = (SdtTrn_Amenity)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Amenity.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Amenity.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow73( bcTrn_Amenity) ;
            }
            else
            {
               RowToVars73( bcTrn_Amenity, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Amenity.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Amenity.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars73( bcTrn_Amenity, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Amenity Trn_Amenity_BC
      {
         get {
            return bcTrn_Amenity ;
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
            return "trn_amenity_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z39AmenityId = Guid.Empty;
         A39AmenityId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         Z40AmenityName = "";
         A40AmenityName = "";
         Z41AmenityDescription = "";
         A41AmenityDescription = "";
         GXt_guid1 = Guid.Empty;
         BC00055_A39AmenityId = new Guid[] {Guid.Empty} ;
         BC00055_A40AmenityName = new string[] {""} ;
         BC00055_A41AmenityDescription = new string[] {""} ;
         BC00055_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00055_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00054_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00056_A39AmenityId = new Guid[] {Guid.Empty} ;
         BC00056_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00056_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00053_A39AmenityId = new Guid[] {Guid.Empty} ;
         BC00053_A40AmenityName = new string[] {""} ;
         BC00053_A41AmenityDescription = new string[] {""} ;
         BC00053_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00053_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode73 = "";
         BC00052_A39AmenityId = new Guid[] {Guid.Empty} ;
         BC00052_A40AmenityName = new string[] {""} ;
         BC00052_A41AmenityDescription = new string[] {""} ;
         BC00052_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00052_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000510_A39AmenityId = new Guid[] {Guid.Empty} ;
         BC000510_A40AmenityName = new string[] {""} ;
         BC000510_A41AmenityDescription = new string[] {""} ;
         BC000510_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000510_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000511_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_amenity_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_amenity_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A39AmenityId, BC00052_A40AmenityName, BC00052_A41AmenityDescription, BC00052_A29LocationId, BC00052_A11OrganisationId
               }
               , new Object[] {
               BC00053_A39AmenityId, BC00053_A40AmenityName, BC00053_A41AmenityDescription, BC00053_A29LocationId, BC00053_A11OrganisationId
               }
               , new Object[] {
               BC00054_A29LocationId
               }
               , new Object[] {
               BC00055_A39AmenityId, BC00055_A40AmenityName, BC00055_A41AmenityDescription, BC00055_A29LocationId, BC00055_A11OrganisationId
               }
               , new Object[] {
               BC00056_A39AmenityId, BC00056_A29LocationId, BC00056_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000510_A39AmenityId, BC000510_A40AmenityName, BC000510_A41AmenityDescription, BC000510_A29LocationId, BC000510_A11OrganisationId
               }
               , new Object[] {
               BC000511_A29LocationId
               }
            }
         );
         Z39AmenityId = Guid.NewGuid( );
         A39AmenityId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound73 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode73 ;
      private bool returnInSub ;
      private string Z41AmenityDescription ;
      private string A41AmenityDescription ;
      private string Z40AmenityName ;
      private string A40AmenityName ;
      private Guid Z39AmenityId ;
      private Guid A39AmenityId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxSession AV14WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00055_A39AmenityId ;
      private string[] BC00055_A40AmenityName ;
      private string[] BC00055_A41AmenityDescription ;
      private Guid[] BC00055_A29LocationId ;
      private Guid[] BC00055_A11OrganisationId ;
      private Guid[] BC00054_A29LocationId ;
      private Guid[] BC00056_A39AmenityId ;
      private Guid[] BC00056_A29LocationId ;
      private Guid[] BC00056_A11OrganisationId ;
      private Guid[] BC00053_A39AmenityId ;
      private string[] BC00053_A40AmenityName ;
      private string[] BC00053_A41AmenityDescription ;
      private Guid[] BC00053_A29LocationId ;
      private Guid[] BC00053_A11OrganisationId ;
      private Guid[] BC00052_A39AmenityId ;
      private string[] BC00052_A40AmenityName ;
      private string[] BC00052_A41AmenityDescription ;
      private Guid[] BC00052_A29LocationId ;
      private Guid[] BC00052_A11OrganisationId ;
      private Guid[] BC000510_A39AmenityId ;
      private string[] BC000510_A40AmenityName ;
      private string[] BC000510_A41AmenityDescription ;
      private Guid[] BC000510_A29LocationId ;
      private Guid[] BC000510_A11OrganisationId ;
      private SdtTrn_Amenity bcTrn_Amenity ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000511_A29LocationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_amenity_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_amenity_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00052;
        prmBC00052 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00053;
        prmBC00053 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00054;
        prmBC00054 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00055;
        prmBC00055 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00056;
        prmBC00056 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00057;
        prmBC00057 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AmenityName",GXType.VarChar,100,0) ,
        new ParDef("AmenityDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00058;
        prmBC00058 = new Object[] {
        new ParDef("AmenityName",GXType.VarChar,100,0) ,
        new ParDef("AmenityDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00059;
        prmBC00059 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000510;
        prmBC000510 = new Object[] {
        new ParDef("AmenityId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000511;
        prmBC000511 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00052", "SELECT AmenityId, AmenityName, AmenityDescription, LocationId, OrganisationId FROM Trn_Amenity WHERE AmenityId = :AmenityId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Amenity",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00053", "SELECT AmenityId, AmenityName, AmenityDescription, LocationId, OrganisationId FROM Trn_Amenity WHERE AmenityId = :AmenityId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00054", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00055", "SELECT TM1.AmenityId, TM1.AmenityName, TM1.AmenityDescription, TM1.LocationId, TM1.OrganisationId FROM Trn_Amenity TM1 WHERE TM1.AmenityId = :AmenityId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.AmenityId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00056", "SELECT AmenityId, LocationId, OrganisationId FROM Trn_Amenity WHERE AmenityId = :AmenityId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00057", "SAVEPOINT gxupdate;INSERT INTO Trn_Amenity(AmenityId, AmenityName, AmenityDescription, LocationId, OrganisationId) VALUES(:AmenityId, :AmenityName, :AmenityDescription, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00057)
           ,new CursorDef("BC00058", "SAVEPOINT gxupdate;UPDATE Trn_Amenity SET AmenityName=:AmenityName, AmenityDescription=:AmenityDescription  WHERE AmenityId = :AmenityId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00058)
           ,new CursorDef("BC00059", "SAVEPOINT gxupdate;DELETE FROM Trn_Amenity  WHERE AmenityId = :AmenityId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00059)
           ,new CursorDef("BC000510", "SELECT TM1.AmenityId, TM1.AmenityName, TM1.AmenityDescription, TM1.LocationId, TM1.OrganisationId FROM Trn_Amenity TM1 WHERE TM1.AmenityId = :AmenityId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.AmenityId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000511", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,1, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
