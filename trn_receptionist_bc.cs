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
   public class trn_receptionist_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_receptionist_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionist_bc( IGxContext context )
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
         ReadRow0C74( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C74( ) ;
         standaloneModal( ) ;
         AddRow0C74( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z89ReceptionistId = A89ReceptionistId;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C74( ) ;
            }
            else
            {
               CheckExtendedTable0C74( ) ;
               if ( AnyError == 0 )
               {
                  ZM0C74( 24) ;
               }
               CloseExtendedTableCursors0C74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_guid1 = AV21OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV21OrganisationId = GXt_guid1;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25TrnContext.FromXml(AV28WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV36AuditingObject,  AV38Pgmname) ;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM0C74( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
            Z92ReceptionistInitials = A92ReceptionistInitials;
            Z94ReceptionistPhone = A94ReceptionistPhone;
            Z90ReceptionistGivenName = A90ReceptionistGivenName;
            Z91ReceptionistLastName = A91ReceptionistLastName;
            Z93ReceptionistEmail = A93ReceptionistEmail;
            Z373ReceptionistPhoneCode = A373ReceptionistPhoneCode;
            Z374ReceptionistPhoneNumber = A374ReceptionistPhoneNumber;
            Z398ReceptionistIsActive = A398ReceptionistIsActive;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -23 )
         {
            Z89ReceptionistId = A89ReceptionistId;
            Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
            Z92ReceptionistInitials = A92ReceptionistInitials;
            Z94ReceptionistPhone = A94ReceptionistPhone;
            Z90ReceptionistGivenName = A90ReceptionistGivenName;
            Z91ReceptionistLastName = A91ReceptionistLastName;
            Z93ReceptionistEmail = A93ReceptionistEmail;
            Z373ReceptionistPhoneCode = A373ReceptionistPhoneCode;
            Z374ReceptionistPhoneNumber = A374ReceptionistPhoneNumber;
            Z398ReceptionistIsActive = A398ReceptionistIsActive;
            Z459ReceptionistImage = A459ReceptionistImage;
            Z40000ReceptionistImage_GXI = A40000ReceptionistImage_GXI;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV38Pgmname = "Trn_Receptionist_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) )
         {
            A89ReceptionistId = Guid.NewGuid( );
         }
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0C74( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound74 = 1;
            A95ReceptionistGAMGUID = BC000C5_A95ReceptionistGAMGUID[0];
            A92ReceptionistInitials = BC000C5_A92ReceptionistInitials[0];
            A94ReceptionistPhone = BC000C5_A94ReceptionistPhone[0];
            A90ReceptionistGivenName = BC000C5_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = BC000C5_A91ReceptionistLastName[0];
            A93ReceptionistEmail = BC000C5_A93ReceptionistEmail[0];
            A373ReceptionistPhoneCode = BC000C5_A373ReceptionistPhoneCode[0];
            A374ReceptionistPhoneNumber = BC000C5_A374ReceptionistPhoneNumber[0];
            A398ReceptionistIsActive = BC000C5_A398ReceptionistIsActive[0];
            A40000ReceptionistImage_GXI = BC000C5_A40000ReceptionistImage_GXI[0];
            A459ReceptionistImage = BC000C5_A459ReceptionistImage[0];
            ZM0C74( -23) ;
         }
         pr_default.close(3);
         OnLoadActions0C74( ) ;
      }

      protected void OnLoadActions0C74( )
      {
         GXt_char2 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A373ReceptionistPhoneCode,  A374ReceptionistPhoneNumber, out  GXt_char2) ;
         A94ReceptionistPhone = GXt_char2;
         GXt_boolean3 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean3) ;
         AV37IsGAMActive = GXt_boolean3;
      }

      protected void CheckExtendedTable0C74( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( (Guid.Empty==A29LocationId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Location Id", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A90ReceptionistGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Given Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91ReceptionistLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Last Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A93ReceptionistEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Receptionist Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A93ReceptionistEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Email", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         GXt_char2 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A373ReceptionistPhoneCode,  A374ReceptionistPhoneNumber, out  GXt_char2) ;
         A94ReceptionistPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A374ReceptionistPhoneNumber)) && ! GxRegex.IsMatch(A374ReceptionistPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         GXt_boolean3 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean3) ;
         AV37IsGAMActive = GXt_boolean3;
      }

      protected void CloseExtendedTableCursors0C74( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C74( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C74( 23) ;
            RcdFound74 = 1;
            A89ReceptionistId = BC000C3_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = BC000C3_A95ReceptionistGAMGUID[0];
            A92ReceptionistInitials = BC000C3_A92ReceptionistInitials[0];
            A94ReceptionistPhone = BC000C3_A94ReceptionistPhone[0];
            A90ReceptionistGivenName = BC000C3_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = BC000C3_A91ReceptionistLastName[0];
            A93ReceptionistEmail = BC000C3_A93ReceptionistEmail[0];
            A373ReceptionistPhoneCode = BC000C3_A373ReceptionistPhoneCode[0];
            A374ReceptionistPhoneNumber = BC000C3_A374ReceptionistPhoneNumber[0];
            A398ReceptionistIsActive = BC000C3_A398ReceptionistIsActive[0];
            A40000ReceptionistImage_GXI = BC000C3_A40000ReceptionistImage_GXI[0];
            A11OrganisationId = BC000C3_A11OrganisationId[0];
            A29LocationId = BC000C3_A29LocationId[0];
            A459ReceptionistImage = BC000C3_A459ReceptionistImage[0];
            Z89ReceptionistId = A89ReceptionistId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey0C74( ) ;
            }
            Gx_mode = sMode74;
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey0C74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode74;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C74( ) ;
         if ( RcdFound74 == 0 )
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
         CONFIRM_0C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z95ReceptionistGAMGUID, BC000C2_A95ReceptionistGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z92ReceptionistInitials, BC000C2_A92ReceptionistInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z94ReceptionistPhone, BC000C2_A94ReceptionistPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z90ReceptionistGivenName, BC000C2_A90ReceptionistGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z91ReceptionistLastName, BC000C2_A91ReceptionistLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z93ReceptionistEmail, BC000C2_A93ReceptionistEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z373ReceptionistPhoneCode, BC000C2_A373ReceptionistPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z374ReceptionistPhoneNumber, BC000C2_A374ReceptionistPhoneNumber[0]) != 0 ) || ( Z398ReceptionistIsActive != BC000C2_A398ReceptionistIsActive[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Receptionist"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C74( )
      {
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C74( 0) ;
            CheckOptimisticConcurrency0C74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A89ReceptionistId, A95ReceptionistGAMGUID, A92ReceptionistInitials, A94ReceptionistPhone, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A373ReceptionistPhoneCode, A374ReceptionistPhoneNumber, A398ReceptionistIsActive, A459ReceptionistImage, A40000ReceptionistImage_GXI, A11OrganisationId, A29LocationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
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
               Load0C74( ) ;
            }
            EndLevel0C74( ) ;
         }
         CloseExtendedTableCursors0C74( ) ;
      }

      protected void Update0C74( )
      {
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C8 */
                     pr_default.execute(6, new Object[] {A95ReceptionistGAMGUID, A92ReceptionistInitials, A94ReceptionistPhone, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A373ReceptionistPhoneCode, A374ReceptionistPhoneNumber, A398ReceptionistIsActive, A89ReceptionistId, A11OrganisationId, A29LocationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C74( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( IsUpd( )  )
                        {
                           new prc_updategamuseraccount(context ).execute(  A95ReceptionistGAMGUID,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", out  AV14GAMErrorResponse) ;
                        }
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
            EndLevel0C74( ) ;
         }
         CloseExtendedTableCursors0C74( ) ;
      }

      protected void DeferredUpdate0C74( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C9 */
            pr_default.execute(7, new Object[] {A459ReceptionistImage, A40000ReceptionistImage_GXI, A89ReceptionistId, A11OrganisationId, A29LocationId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C74( ) ;
            AfterConfirm0C74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C74( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C10 */
                  pr_default.execute(8, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     if ( IsDlt( )  )
                     {
                        new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV14GAMErrorResponse) ;
                     }
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C74( ) ;
         Gx_mode = sMode74;
      }

      protected void OnDeleteControls0C74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean3 = AV37IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean3) ;
            AV37IsGAMActive = GXt_boolean3;
         }
      }

      protected void EndLevel0C74( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C74( ) ;
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

      public void ScanKeyStart0C74( )
      {
         /* Scan By routine */
         /* Using cursor BC000C11 */
         pr_default.execute(9, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         RcdFound74 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound74 = 1;
            A89ReceptionistId = BC000C11_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = BC000C11_A95ReceptionistGAMGUID[0];
            A92ReceptionistInitials = BC000C11_A92ReceptionistInitials[0];
            A94ReceptionistPhone = BC000C11_A94ReceptionistPhone[0];
            A90ReceptionistGivenName = BC000C11_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = BC000C11_A91ReceptionistLastName[0];
            A93ReceptionistEmail = BC000C11_A93ReceptionistEmail[0];
            A373ReceptionistPhoneCode = BC000C11_A373ReceptionistPhoneCode[0];
            A374ReceptionistPhoneNumber = BC000C11_A374ReceptionistPhoneNumber[0];
            A398ReceptionistIsActive = BC000C11_A398ReceptionistIsActive[0];
            A40000ReceptionistImage_GXI = BC000C11_A40000ReceptionistImage_GXI[0];
            A11OrganisationId = BC000C11_A11OrganisationId[0];
            A29LocationId = BC000C11_A29LocationId[0];
            A459ReceptionistImage = BC000C11_A459ReceptionistImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C74( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound74 = 0;
         ScanKeyLoad0C74( ) ;
      }

      protected void ScanKeyLoad0C74( )
      {
         sMode74 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound74 = 1;
            A89ReceptionistId = BC000C11_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = BC000C11_A95ReceptionistGAMGUID[0];
            A92ReceptionistInitials = BC000C11_A92ReceptionistInitials[0];
            A94ReceptionistPhone = BC000C11_A94ReceptionistPhone[0];
            A90ReceptionistGivenName = BC000C11_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = BC000C11_A91ReceptionistLastName[0];
            A93ReceptionistEmail = BC000C11_A93ReceptionistEmail[0];
            A373ReceptionistPhoneCode = BC000C11_A373ReceptionistPhoneCode[0];
            A374ReceptionistPhoneNumber = BC000C11_A374ReceptionistPhoneNumber[0];
            A398ReceptionistIsActive = BC000C11_A398ReceptionistIsActive[0];
            A40000ReceptionistImage_GXI = BC000C11_A40000ReceptionistImage_GXI[0];
            A11OrganisationId = BC000C11_A11OrganisationId[0];
            A29LocationId = BC000C11_A29LocationId[0];
            A459ReceptionistImage = BC000C11_A459ReceptionistImage[0];
         }
         Gx_mode = sMode74;
      }

      protected void ScanKeyEnd0C74( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0C74( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C74( )
      {
         /* Before Insert Rules */
         new prc_getnameinitials(context ).execute(  A90ReceptionistGivenName,  A91ReceptionistLastName, out  A92ReceptionistInitials) ;
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A95ReceptionistGAMGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A93ReceptionistEmail,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", out  A95ReceptionistGAMGUID) ;
         }
      }

      protected void BeforeUpdate0C74( )
      {
         /* Before Update Rules */
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
      }

      protected void BeforeDelete0C74( )
      {
         /* Before Delete Rules */
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
      }

      protected void BeforeComplete0C74( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0C74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C74( )
      {
      }

      protected void send_integrity_lvl_hashes0C74( )
      {
      }

      protected void AddRow0C74( )
      {
         VarsToRow74( bcTrn_Receptionist) ;
      }

      protected void ReadRow0C74( )
      {
         RowToVars74( bcTrn_Receptionist, 1) ;
      }

      protected void InitializeNonKey0C74( )
      {
         AV36AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A95ReceptionistGAMGUID = "";
         A92ReceptionistInitials = "";
         AV14GAMErrorResponse = "";
         A94ReceptionistPhone = "";
         AV37IsGAMActive = false;
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A93ReceptionistEmail = "";
         A373ReceptionistPhoneCode = "";
         A374ReceptionistPhoneNumber = "";
         A398ReceptionistIsActive = false;
         A459ReceptionistImage = "";
         A40000ReceptionistImage_GXI = "";
         Z95ReceptionistGAMGUID = "";
         Z92ReceptionistInitials = "";
         Z94ReceptionistPhone = "";
         Z90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         Z373ReceptionistPhoneCode = "";
         Z374ReceptionistPhoneNumber = "";
         Z398ReceptionistIsActive = false;
      }

      protected void InitAll0C74( )
      {
         A89ReceptionistId = Guid.NewGuid( );
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         InitializeNonKey0C74( ) ;
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

      public void VarsToRow74( SdtTrn_Receptionist obj74 )
      {
         obj74.gxTpr_Mode = Gx_mode;
         obj74.gxTpr_Receptionistgamguid = A95ReceptionistGAMGUID;
         obj74.gxTpr_Receptionistinitials = A92ReceptionistInitials;
         obj74.gxTpr_Receptionistphone = A94ReceptionistPhone;
         obj74.gxTpr_Receptionistgivenname = A90ReceptionistGivenName;
         obj74.gxTpr_Receptionistlastname = A91ReceptionistLastName;
         obj74.gxTpr_Receptionistemail = A93ReceptionistEmail;
         obj74.gxTpr_Receptionistphonecode = A373ReceptionistPhoneCode;
         obj74.gxTpr_Receptionistphonenumber = A374ReceptionistPhoneNumber;
         obj74.gxTpr_Receptionistisactive = A398ReceptionistIsActive;
         obj74.gxTpr_Receptionistimage = A459ReceptionistImage;
         obj74.gxTpr_Receptionistimage_gxi = A40000ReceptionistImage_GXI;
         obj74.gxTpr_Receptionistid = A89ReceptionistId;
         obj74.gxTpr_Organisationid = A11OrganisationId;
         obj74.gxTpr_Locationid = A29LocationId;
         obj74.gxTpr_Receptionistid_Z = Z89ReceptionistId;
         obj74.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj74.gxTpr_Locationid_Z = Z29LocationId;
         obj74.gxTpr_Receptionistgivenname_Z = Z90ReceptionistGivenName;
         obj74.gxTpr_Receptionistlastname_Z = Z91ReceptionistLastName;
         obj74.gxTpr_Receptionistinitials_Z = Z92ReceptionistInitials;
         obj74.gxTpr_Receptionistemail_Z = Z93ReceptionistEmail;
         obj74.gxTpr_Receptionistphonecode_Z = Z373ReceptionistPhoneCode;
         obj74.gxTpr_Receptionistphone_Z = Z94ReceptionistPhone;
         obj74.gxTpr_Receptionistphonenumber_Z = Z374ReceptionistPhoneNumber;
         obj74.gxTpr_Receptionistgamguid_Z = Z95ReceptionistGAMGUID;
         obj74.gxTpr_Receptionistisactive_Z = Z398ReceptionistIsActive;
         obj74.gxTpr_Receptionistimage_gxi_Z = Z40000ReceptionistImage_GXI;
         obj74.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow74( SdtTrn_Receptionist obj74 )
      {
         obj74.gxTpr_Receptionistid = A89ReceptionistId;
         obj74.gxTpr_Organisationid = A11OrganisationId;
         obj74.gxTpr_Locationid = A29LocationId;
         return  ;
      }

      public void RowToVars74( SdtTrn_Receptionist obj74 ,
                               int forceLoad )
      {
         Gx_mode = obj74.gxTpr_Mode;
         A95ReceptionistGAMGUID = obj74.gxTpr_Receptionistgamguid;
         A92ReceptionistInitials = obj74.gxTpr_Receptionistinitials;
         A94ReceptionistPhone = obj74.gxTpr_Receptionistphone;
         A90ReceptionistGivenName = obj74.gxTpr_Receptionistgivenname;
         A91ReceptionistLastName = obj74.gxTpr_Receptionistlastname;
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A93ReceptionistEmail = obj74.gxTpr_Receptionistemail;
         }
         A373ReceptionistPhoneCode = obj74.gxTpr_Receptionistphonecode;
         A374ReceptionistPhoneNumber = obj74.gxTpr_Receptionistphonenumber;
         A398ReceptionistIsActive = obj74.gxTpr_Receptionistisactive;
         A459ReceptionistImage = obj74.gxTpr_Receptionistimage;
         A40000ReceptionistImage_GXI = obj74.gxTpr_Receptionistimage_gxi;
         A89ReceptionistId = obj74.gxTpr_Receptionistid;
         A11OrganisationId = obj74.gxTpr_Organisationid;
         A29LocationId = obj74.gxTpr_Locationid;
         Z89ReceptionistId = obj74.gxTpr_Receptionistid_Z;
         Z11OrganisationId = obj74.gxTpr_Organisationid_Z;
         Z29LocationId = obj74.gxTpr_Locationid_Z;
         Z90ReceptionistGivenName = obj74.gxTpr_Receptionistgivenname_Z;
         Z91ReceptionistLastName = obj74.gxTpr_Receptionistlastname_Z;
         Z92ReceptionistInitials = obj74.gxTpr_Receptionistinitials_Z;
         Z93ReceptionistEmail = obj74.gxTpr_Receptionistemail_Z;
         Z373ReceptionistPhoneCode = obj74.gxTpr_Receptionistphonecode_Z;
         Z94ReceptionistPhone = obj74.gxTpr_Receptionistphone_Z;
         Z374ReceptionistPhoneNumber = obj74.gxTpr_Receptionistphonenumber_Z;
         Z95ReceptionistGAMGUID = obj74.gxTpr_Receptionistgamguid_Z;
         Z398ReceptionistIsActive = obj74.gxTpr_Receptionistisactive_Z;
         Z40000ReceptionistImage_GXI = obj74.gxTpr_Receptionistimage_gxi_Z;
         Gx_mode = obj74.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A89ReceptionistId = (Guid)getParm(obj,0);
         A11OrganisationId = (Guid)getParm(obj,1);
         A29LocationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C74( ) ;
         ScanKeyStart0C74( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z89ReceptionistId = A89ReceptionistId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM0C74( -23) ;
         OnLoadActions0C74( ) ;
         AddRow0C74( ) ;
         ScanKeyEnd0C74( ) ;
         if ( RcdFound74 == 0 )
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
         RowToVars74( bcTrn_Receptionist, 0) ;
         ScanKeyStart0C74( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z89ReceptionistId = A89ReceptionistId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM0C74( -23) ;
         OnLoadActions0C74( ) ;
         AddRow0C74( ) ;
         ScanKeyEnd0C74( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0C74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C74( ) ;
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A89ReceptionistId = Z89ReceptionistId;
                  A11OrganisationId = Z11OrganisationId;
                  A29LocationId = Z29LocationId;
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
                  Update0C74( ) ;
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
                  if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
                        Insert0C74( ) ;
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
                        Insert0C74( ) ;
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
         RowToVars74( bcTrn_Receptionist, 1) ;
         SaveImpl( ) ;
         VarsToRow74( bcTrn_Receptionist) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars74( bcTrn_Receptionist, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C74( ) ;
         AfterTrn( ) ;
         VarsToRow74( bcTrn_Receptionist) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow74( bcTrn_Receptionist) ;
         }
         else
         {
            SdtTrn_Receptionist auxBC = new SdtTrn_Receptionist(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A89ReceptionistId, A11OrganisationId, A29LocationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Receptionist);
               auxBC.Save();
               bcTrn_Receptionist.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars74( bcTrn_Receptionist, 1) ;
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
         RowToVars74( bcTrn_Receptionist, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C74( ) ;
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
               VarsToRow74( bcTrn_Receptionist) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow74( bcTrn_Receptionist) ;
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
         RowToVars74( bcTrn_Receptionist, 0) ;
         GetKey0C74( ) ;
         if ( RcdFound74 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
            {
               A89ReceptionistId = Z89ReceptionistId;
               A11OrganisationId = Z11OrganisationId;
               A29LocationId = Z29LocationId;
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
            if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
         context.RollbackDataStores("trn_receptionist_bc",pr_default);
         VarsToRow74( bcTrn_Receptionist) ;
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
         Gx_mode = bcTrn_Receptionist.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Receptionist.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Receptionist )
         {
            bcTrn_Receptionist = (SdtTrn_Receptionist)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Receptionist.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Receptionist.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow74( bcTrn_Receptionist) ;
            }
            else
            {
               RowToVars74( bcTrn_Receptionist, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Receptionist.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Receptionist.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars74( bcTrn_Receptionist, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Receptionist Trn_Receptionist_BC
      {
         get {
            return bcTrn_Receptionist ;
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
            return "trn_receptionist_Execute" ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z89ReceptionistId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV21OrganisationId = Guid.Empty;
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV28WebSession = context.GetSession();
         AV36AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV38Pgmname = "";
         Z95ReceptionistGAMGUID = "";
         A95ReceptionistGAMGUID = "";
         Z92ReceptionistInitials = "";
         A92ReceptionistInitials = "";
         Z94ReceptionistPhone = "";
         A94ReceptionistPhone = "";
         Z90ReceptionistGivenName = "";
         A90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         A91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         A93ReceptionistEmail = "";
         Z373ReceptionistPhoneCode = "";
         A373ReceptionistPhoneCode = "";
         Z374ReceptionistPhoneNumber = "";
         A374ReceptionistPhoneNumber = "";
         Z459ReceptionistImage = "";
         A459ReceptionistImage = "";
         Z40000ReceptionistImage_GXI = "";
         A40000ReceptionistImage_GXI = "";
         GXt_guid1 = Guid.Empty;
         BC000C5_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000C5_A95ReceptionistGAMGUID = new string[] {""} ;
         BC000C5_A92ReceptionistInitials = new string[] {""} ;
         BC000C5_A94ReceptionistPhone = new string[] {""} ;
         BC000C5_A90ReceptionistGivenName = new string[] {""} ;
         BC000C5_A91ReceptionistLastName = new string[] {""} ;
         BC000C5_A93ReceptionistEmail = new string[] {""} ;
         BC000C5_A373ReceptionistPhoneCode = new string[] {""} ;
         BC000C5_A374ReceptionistPhoneNumber = new string[] {""} ;
         BC000C5_A398ReceptionistIsActive = new bool[] {false} ;
         BC000C5_A40000ReceptionistImage_GXI = new string[] {""} ;
         BC000C5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000C5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000C5_A459ReceptionistImage = new string[] {""} ;
         BC000C4_A29LocationId = new Guid[] {Guid.Empty} ;
         GXt_char2 = "";
         BC000C6_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000C6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000C6_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000C3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000C3_A95ReceptionistGAMGUID = new string[] {""} ;
         BC000C3_A92ReceptionistInitials = new string[] {""} ;
         BC000C3_A94ReceptionistPhone = new string[] {""} ;
         BC000C3_A90ReceptionistGivenName = new string[] {""} ;
         BC000C3_A91ReceptionistLastName = new string[] {""} ;
         BC000C3_A93ReceptionistEmail = new string[] {""} ;
         BC000C3_A373ReceptionistPhoneCode = new string[] {""} ;
         BC000C3_A374ReceptionistPhoneNumber = new string[] {""} ;
         BC000C3_A398ReceptionistIsActive = new bool[] {false} ;
         BC000C3_A40000ReceptionistImage_GXI = new string[] {""} ;
         BC000C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000C3_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000C3_A459ReceptionistImage = new string[] {""} ;
         sMode74 = "";
         BC000C2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000C2_A95ReceptionistGAMGUID = new string[] {""} ;
         BC000C2_A92ReceptionistInitials = new string[] {""} ;
         BC000C2_A94ReceptionistPhone = new string[] {""} ;
         BC000C2_A90ReceptionistGivenName = new string[] {""} ;
         BC000C2_A91ReceptionistLastName = new string[] {""} ;
         BC000C2_A93ReceptionistEmail = new string[] {""} ;
         BC000C2_A373ReceptionistPhoneCode = new string[] {""} ;
         BC000C2_A374ReceptionistPhoneNumber = new string[] {""} ;
         BC000C2_A398ReceptionistIsActive = new bool[] {false} ;
         BC000C2_A40000ReceptionistImage_GXI = new string[] {""} ;
         BC000C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000C2_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000C2_A459ReceptionistImage = new string[] {""} ;
         AV14GAMErrorResponse = "";
         BC000C11_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000C11_A95ReceptionistGAMGUID = new string[] {""} ;
         BC000C11_A92ReceptionistInitials = new string[] {""} ;
         BC000C11_A94ReceptionistPhone = new string[] {""} ;
         BC000C11_A90ReceptionistGivenName = new string[] {""} ;
         BC000C11_A91ReceptionistLastName = new string[] {""} ;
         BC000C11_A93ReceptionistEmail = new string[] {""} ;
         BC000C11_A373ReceptionistPhoneCode = new string[] {""} ;
         BC000C11_A374ReceptionistPhoneNumber = new string[] {""} ;
         BC000C11_A398ReceptionistIsActive = new bool[] {false} ;
         BC000C11_A40000ReceptionistImage_GXI = new string[] {""} ;
         BC000C11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000C11_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000C11_A459ReceptionistImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000C12_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A89ReceptionistId, BC000C2_A95ReceptionistGAMGUID, BC000C2_A92ReceptionistInitials, BC000C2_A94ReceptionistPhone, BC000C2_A90ReceptionistGivenName, BC000C2_A91ReceptionistLastName, BC000C2_A93ReceptionistEmail, BC000C2_A373ReceptionistPhoneCode, BC000C2_A374ReceptionistPhoneNumber, BC000C2_A398ReceptionistIsActive,
               BC000C2_A40000ReceptionistImage_GXI, BC000C2_A11OrganisationId, BC000C2_A29LocationId, BC000C2_A459ReceptionistImage
               }
               , new Object[] {
               BC000C3_A89ReceptionistId, BC000C3_A95ReceptionistGAMGUID, BC000C3_A92ReceptionistInitials, BC000C3_A94ReceptionistPhone, BC000C3_A90ReceptionistGivenName, BC000C3_A91ReceptionistLastName, BC000C3_A93ReceptionistEmail, BC000C3_A373ReceptionistPhoneCode, BC000C3_A374ReceptionistPhoneNumber, BC000C3_A398ReceptionistIsActive,
               BC000C3_A40000ReceptionistImage_GXI, BC000C3_A11OrganisationId, BC000C3_A29LocationId, BC000C3_A459ReceptionistImage
               }
               , new Object[] {
               BC000C4_A29LocationId
               }
               , new Object[] {
               BC000C5_A89ReceptionistId, BC000C5_A95ReceptionistGAMGUID, BC000C5_A92ReceptionistInitials, BC000C5_A94ReceptionistPhone, BC000C5_A90ReceptionistGivenName, BC000C5_A91ReceptionistLastName, BC000C5_A93ReceptionistEmail, BC000C5_A373ReceptionistPhoneCode, BC000C5_A374ReceptionistPhoneNumber, BC000C5_A398ReceptionistIsActive,
               BC000C5_A40000ReceptionistImage_GXI, BC000C5_A11OrganisationId, BC000C5_A29LocationId, BC000C5_A459ReceptionistImage
               }
               , new Object[] {
               BC000C6_A89ReceptionistId, BC000C6_A11OrganisationId, BC000C6_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C11_A89ReceptionistId, BC000C11_A95ReceptionistGAMGUID, BC000C11_A92ReceptionistInitials, BC000C11_A94ReceptionistPhone, BC000C11_A90ReceptionistGivenName, BC000C11_A91ReceptionistLastName, BC000C11_A93ReceptionistEmail, BC000C11_A373ReceptionistPhoneCode, BC000C11_A374ReceptionistPhoneNumber, BC000C11_A398ReceptionistIsActive,
               BC000C11_A40000ReceptionistImage_GXI, BC000C11_A11OrganisationId, BC000C11_A29LocationId, BC000C11_A459ReceptionistImage
               }
               , new Object[] {
               BC000C12_A29LocationId
               }
            }
         );
         Z89ReceptionistId = Guid.NewGuid( );
         A89ReceptionistId = Guid.NewGuid( );
         AV38Pgmname = "Trn_Receptionist_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV38Pgmname ;
      private string Z92ReceptionistInitials ;
      private string A92ReceptionistInitials ;
      private string Z94ReceptionistPhone ;
      private string A94ReceptionistPhone ;
      private string GXt_char2 ;
      private string sMode74 ;
      private bool returnInSub ;
      private bool Z398ReceptionistIsActive ;
      private bool A398ReceptionistIsActive ;
      private bool AV37IsGAMActive ;
      private bool Gx_longc ;
      private bool GXt_boolean3 ;
      private string AV14GAMErrorResponse ;
      private string Z95ReceptionistGAMGUID ;
      private string A95ReceptionistGAMGUID ;
      private string Z90ReceptionistGivenName ;
      private string A90ReceptionistGivenName ;
      private string Z91ReceptionistLastName ;
      private string A91ReceptionistLastName ;
      private string Z93ReceptionistEmail ;
      private string A93ReceptionistEmail ;
      private string Z373ReceptionistPhoneCode ;
      private string A373ReceptionistPhoneCode ;
      private string Z374ReceptionistPhoneNumber ;
      private string A374ReceptionistPhoneNumber ;
      private string Z40000ReceptionistImage_GXI ;
      private string A40000ReceptionistImage_GXI ;
      private string Z459ReceptionistImage ;
      private string A459ReceptionistImage ;
      private Guid Z89ReceptionistId ;
      private Guid A89ReceptionistId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid AV21OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxSession AV28WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV25TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV36AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000C5_A89ReceptionistId ;
      private string[] BC000C5_A95ReceptionistGAMGUID ;
      private string[] BC000C5_A92ReceptionistInitials ;
      private string[] BC000C5_A94ReceptionistPhone ;
      private string[] BC000C5_A90ReceptionistGivenName ;
      private string[] BC000C5_A91ReceptionistLastName ;
      private string[] BC000C5_A93ReceptionistEmail ;
      private string[] BC000C5_A373ReceptionistPhoneCode ;
      private string[] BC000C5_A374ReceptionistPhoneNumber ;
      private bool[] BC000C5_A398ReceptionistIsActive ;
      private string[] BC000C5_A40000ReceptionistImage_GXI ;
      private Guid[] BC000C5_A11OrganisationId ;
      private Guid[] BC000C5_A29LocationId ;
      private string[] BC000C5_A459ReceptionistImage ;
      private Guid[] BC000C4_A29LocationId ;
      private Guid[] BC000C6_A89ReceptionistId ;
      private Guid[] BC000C6_A11OrganisationId ;
      private Guid[] BC000C6_A29LocationId ;
      private Guid[] BC000C3_A89ReceptionistId ;
      private string[] BC000C3_A95ReceptionistGAMGUID ;
      private string[] BC000C3_A92ReceptionistInitials ;
      private string[] BC000C3_A94ReceptionistPhone ;
      private string[] BC000C3_A90ReceptionistGivenName ;
      private string[] BC000C3_A91ReceptionistLastName ;
      private string[] BC000C3_A93ReceptionistEmail ;
      private string[] BC000C3_A373ReceptionistPhoneCode ;
      private string[] BC000C3_A374ReceptionistPhoneNumber ;
      private bool[] BC000C3_A398ReceptionistIsActive ;
      private string[] BC000C3_A40000ReceptionistImage_GXI ;
      private Guid[] BC000C3_A11OrganisationId ;
      private Guid[] BC000C3_A29LocationId ;
      private string[] BC000C3_A459ReceptionistImage ;
      private Guid[] BC000C2_A89ReceptionistId ;
      private string[] BC000C2_A95ReceptionistGAMGUID ;
      private string[] BC000C2_A92ReceptionistInitials ;
      private string[] BC000C2_A94ReceptionistPhone ;
      private string[] BC000C2_A90ReceptionistGivenName ;
      private string[] BC000C2_A91ReceptionistLastName ;
      private string[] BC000C2_A93ReceptionistEmail ;
      private string[] BC000C2_A373ReceptionistPhoneCode ;
      private string[] BC000C2_A374ReceptionistPhoneNumber ;
      private bool[] BC000C2_A398ReceptionistIsActive ;
      private string[] BC000C2_A40000ReceptionistImage_GXI ;
      private Guid[] BC000C2_A11OrganisationId ;
      private Guid[] BC000C2_A29LocationId ;
      private string[] BC000C2_A459ReceptionistImage ;
      private Guid[] BC000C11_A89ReceptionistId ;
      private string[] BC000C11_A95ReceptionistGAMGUID ;
      private string[] BC000C11_A92ReceptionistInitials ;
      private string[] BC000C11_A94ReceptionistPhone ;
      private string[] BC000C11_A90ReceptionistGivenName ;
      private string[] BC000C11_A91ReceptionistLastName ;
      private string[] BC000C11_A93ReceptionistEmail ;
      private string[] BC000C11_A373ReceptionistPhoneCode ;
      private string[] BC000C11_A374ReceptionistPhoneNumber ;
      private bool[] BC000C11_A398ReceptionistIsActive ;
      private string[] BC000C11_A40000ReceptionistImage_GXI ;
      private Guid[] BC000C11_A11OrganisationId ;
      private Guid[] BC000C11_A29LocationId ;
      private string[] BC000C11_A459ReceptionistImage ;
      private SdtTrn_Receptionist bcTrn_Receptionist ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000C12_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_receptionist_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_receptionist_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_receptionist_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000C2;
       prmBC000C2 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C3;
       prmBC000C3 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C4;
       prmBC000C4 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C5;
       prmBC000C5 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C6;
       prmBC000C6 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C7;
       prmBC000C7 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
       new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
       new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ReceptionistPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ReceptionistIsActive",GXType.Boolean,4,0) ,
       new ParDef("ReceptionistImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ReceptionistImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=10, Tbl="Trn_Receptionist", Fld="ReceptionistImage"} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C8;
       prmBC000C8 = new Object[] {
       new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
       new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
       new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ReceptionistPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ReceptionistIsActive",GXType.Boolean,4,0) ,
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C9;
       prmBC000C9 = new Object[] {
       new ParDef("ReceptionistImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ReceptionistImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Receptionist", Fld="ReceptionistImage"} ,
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C10;
       prmBC000C10 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C11;
       prmBC000C11 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000C12;
       prmBC000C12 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000C2", "SELECT ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneCode, ReceptionistPhoneNumber, ReceptionistIsActive, ReceptionistImage_GXI, OrganisationId, LocationId, ReceptionistImage FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_Receptionist",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C3", "SELECT ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneCode, ReceptionistPhoneNumber, ReceptionistIsActive, ReceptionistImage_GXI, OrganisationId, LocationId, ReceptionistImage FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C5", "SELECT TM1.ReceptionistId, TM1.ReceptionistGAMGUID, TM1.ReceptionistInitials, TM1.ReceptionistPhone, TM1.ReceptionistGivenName, TM1.ReceptionistLastName, TM1.ReceptionistEmail, TM1.ReceptionistPhoneCode, TM1.ReceptionistPhoneNumber, TM1.ReceptionistIsActive, TM1.ReceptionistImage_GXI, TM1.OrganisationId, TM1.LocationId, TM1.ReceptionistImage FROM Trn_Receptionist TM1 WHERE TM1.ReceptionistId = :ReceptionistId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.ReceptionistId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C6", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C7", "SAVEPOINT gxupdate;INSERT INTO Trn_Receptionist(ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneCode, ReceptionistPhoneNumber, ReceptionistIsActive, ReceptionistImage, ReceptionistImage_GXI, OrganisationId, LocationId) VALUES(:ReceptionistId, :ReceptionistGAMGUID, :ReceptionistInitials, :ReceptionistPhone, :ReceptionistGivenName, :ReceptionistLastName, :ReceptionistEmail, :ReceptionistPhoneCode, :ReceptionistPhoneNumber, :ReceptionistIsActive, :ReceptionistImage, :ReceptionistImage_GXI, :OrganisationId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C7)
          ,new CursorDef("BC000C8", "SAVEPOINT gxupdate;UPDATE Trn_Receptionist SET ReceptionistGAMGUID=:ReceptionistGAMGUID, ReceptionistInitials=:ReceptionistInitials, ReceptionistPhone=:ReceptionistPhone, ReceptionistGivenName=:ReceptionistGivenName, ReceptionistLastName=:ReceptionistLastName, ReceptionistEmail=:ReceptionistEmail, ReceptionistPhoneCode=:ReceptionistPhoneCode, ReceptionistPhoneNumber=:ReceptionistPhoneNumber, ReceptionistIsActive=:ReceptionistIsActive  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C8)
          ,new CursorDef("BC000C9", "SAVEPOINT gxupdate;UPDATE Trn_Receptionist SET ReceptionistImage=:ReceptionistImage, ReceptionistImage_GXI=:ReceptionistImage_GXI  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C9)
          ,new CursorDef("BC000C10", "SAVEPOINT gxupdate;DELETE FROM Trn_Receptionist  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C10)
          ,new CursorDef("BC000C11", "SELECT TM1.ReceptionistId, TM1.ReceptionistGAMGUID, TM1.ReceptionistInitials, TM1.ReceptionistPhone, TM1.ReceptionistGivenName, TM1.ReceptionistLastName, TM1.ReceptionistEmail, TM1.ReceptionistPhoneCode, TM1.ReceptionistPhoneNumber, TM1.ReceptionistIsActive, TM1.ReceptionistImage_GXI, TM1.OrganisationId, TM1.LocationId, TM1.ReceptionistImage FROM Trn_Receptionist TM1 WHERE TM1.ReceptionistId = :ReceptionistId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.ReceptionistId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C11,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000C12", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
