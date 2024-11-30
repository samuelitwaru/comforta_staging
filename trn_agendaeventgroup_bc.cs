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
   public class trn_agendaeventgroup_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_agendaeventgroup_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendaeventgroup_bc( IGxContext context )
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
         ReadRow1G90( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1G90( ) ;
         standaloneModal( ) ;
         AddRow1G90( ) ;
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
               Z62ResidentId = A62ResidentId;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G90( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G90( ) ;
            }
            else
            {
               CheckExtendedTable1G90( ) ;
               if ( AnyError == 0 )
               {
                  ZM1G90( 5) ;
                  ZM1G90( 6) ;
                  ZM1G90( 7) ;
                  ZM1G90( 8) ;
               }
               CloseExtendedTableCursors1G90( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1G90( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z455AgendaEventGroupRSVP = A455AgendaEventGroupRSVP;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z66ResidentInitials = A66ResidentInitials;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z354ResidentCountry = A354ResidentCountry;
            Z355ResidentCity = A355ResidentCity;
            Z356ResidentZipCode = A356ResidentZipCode;
            Z357ResidentAddressLine1 = A357ResidentAddressLine1;
            Z358ResidentAddressLine2 = A358ResidentAddressLine2;
            Z70ResidentPhone = A70ResidentPhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z97ResidentTypeName = A97ResidentTypeName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
         if ( GX_JID == -4 )
         {
            Z455AgendaEventGroupRSVP = A455AgendaEventGroupRSVP;
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z66ResidentInitials = A66ResidentInitials;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z354ResidentCountry = A354ResidentCountry;
            Z355ResidentCity = A355ResidentCity;
            Z356ResidentZipCode = A356ResidentZipCode;
            Z357ResidentAddressLine1 = A357ResidentAddressLine1;
            Z358ResidentAddressLine2 = A358ResidentAddressLine2;
            Z70ResidentPhone = A70ResidentPhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) )
         {
            A62ResidentId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1G90( )
      {
         /* Using cursor BC001G8 */
         pr_default.execute(6, new Object[] {A303AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound90 = 1;
            A455AgendaEventGroupRSVP = BC001G8_A455AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001G8_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G8_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G8_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G8_A65ResidentLastName[0];
            A66ResidentInitials = BC001G8_A66ResidentInitials[0];
            A67ResidentEmail = BC001G8_A67ResidentEmail[0];
            A68ResidentGender = BC001G8_A68ResidentGender[0];
            A354ResidentCountry = BC001G8_A354ResidentCountry[0];
            A355ResidentCity = BC001G8_A355ResidentCity[0];
            A356ResidentZipCode = BC001G8_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G8_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G8_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G8_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G8_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G8_A71ResidentGUID[0];
            A97ResidentTypeName = BC001G8_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001G8_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC001G8_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G8_A376ResidentPhoneNumber[0];
            A29LocationId = BC001G8_A29LocationId[0];
            A11OrganisationId = BC001G8_A11OrganisationId[0];
            A96ResidentTypeId = BC001G8_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G8_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G8_n98MedicalIndicationId[0];
            ZM1G90( -4) ;
         }
         pr_default.close(6);
         OnLoadActions1G90( ) ;
      }

      protected void OnLoadActions1G90( )
      {
      }

      protected void CheckExtendedTable1G90( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001G4 */
         pr_default.execute(2, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_AgendaCalendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
         }
         A29LocationId = BC001G4_A29LocationId[0];
         A11OrganisationId = BC001G4_A11OrganisationId[0];
         pr_default.close(2);
         /* Using cursor BC001G5 */
         pr_default.execute(3, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         A72ResidentSalutation = BC001G5_A72ResidentSalutation[0];
         A63ResidentBsnNumber = BC001G5_A63ResidentBsnNumber[0];
         A64ResidentGivenName = BC001G5_A64ResidentGivenName[0];
         A65ResidentLastName = BC001G5_A65ResidentLastName[0];
         A66ResidentInitials = BC001G5_A66ResidentInitials[0];
         A67ResidentEmail = BC001G5_A67ResidentEmail[0];
         A68ResidentGender = BC001G5_A68ResidentGender[0];
         A354ResidentCountry = BC001G5_A354ResidentCountry[0];
         A355ResidentCity = BC001G5_A355ResidentCity[0];
         A356ResidentZipCode = BC001G5_A356ResidentZipCode[0];
         A357ResidentAddressLine1 = BC001G5_A357ResidentAddressLine1[0];
         A358ResidentAddressLine2 = BC001G5_A358ResidentAddressLine2[0];
         A70ResidentPhone = BC001G5_A70ResidentPhone[0];
         A73ResidentBirthDate = BC001G5_A73ResidentBirthDate[0];
         A71ResidentGUID = BC001G5_A71ResidentGUID[0];
         A375ResidentPhoneCode = BC001G5_A375ResidentPhoneCode[0];
         A376ResidentPhoneNumber = BC001G5_A376ResidentPhoneNumber[0];
         A96ResidentTypeId = BC001G5_A96ResidentTypeId[0];
         A98MedicalIndicationId = BC001G5_A98MedicalIndicationId[0];
         n98MedicalIndicationId = BC001G5_n98MedicalIndicationId[0];
         pr_default.close(3);
         /* Using cursor BC001G6 */
         pr_default.execute(4, new Object[] {A96ResidentTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
         }
         A97ResidentTypeName = BC001G6_A97ResidentTypeName[0];
         pr_default.close(4);
         /* Using cursor BC001G7 */
         pr_default.execute(5, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = BC001G7_A99MedicalIndicationName[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1G90( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G90( )
      {
         /* Using cursor BC001G9 */
         pr_default.execute(7, new Object[] {A303AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound90 = 1;
         }
         else
         {
            RcdFound90 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001G3 */
         pr_default.execute(1, new Object[] {A303AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G90( 4) ;
            RcdFound90 = 1;
            A455AgendaEventGroupRSVP = BC001G3_A455AgendaEventGroupRSVP[0];
            A303AgendaCalendarId = BC001G3_A303AgendaCalendarId[0];
            A62ResidentId = BC001G3_A62ResidentId[0];
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1G90( ) ;
            if ( AnyError == 1 )
            {
               RcdFound90 = 0;
               InitializeNonKey1G90( ) ;
            }
            Gx_mode = sMode90;
         }
         else
         {
            RcdFound90 = 0;
            InitializeNonKey1G90( ) ;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode90;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G90( ) ;
         if ( RcdFound90 == 0 )
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
         CONFIRM_1G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1G90( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G2 */
            pr_default.execute(0, new Object[] {A303AgendaCalendarId, A62ResidentId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z455AgendaEventGroupRSVP != BC001G2_A455AgendaEventGroupRSVP[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaEventGroup"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G90( )
      {
         BeforeValidate1G90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G90( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G90( 0) ;
            CheckOptimisticConcurrency1G90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G10 */
                     pr_default.execute(8, new Object[] {A455AgendaEventGroupRSVP, A303AgendaCalendarId, A62ResidentId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
                     if ( (pr_default.getStatus(8) == 1) )
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
               Load1G90( ) ;
            }
            EndLevel1G90( ) ;
         }
         CloseExtendedTableCursors1G90( ) ;
      }

      protected void Update1G90( )
      {
         BeforeValidate1G90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G90( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G11 */
                     pr_default.execute(9, new Object[] {A455AgendaEventGroupRSVP, A303AgendaCalendarId, A62ResidentId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G90( ) ;
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
            EndLevel1G90( ) ;
         }
         CloseExtendedTableCursors1G90( ) ;
      }

      protected void DeferredUpdate1G90( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G90( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G90( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G90( ) ;
            AfterConfirm1G90( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G90( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G12 */
                  pr_default.execute(10, new Object[] {A303AgendaCalendarId, A62ResidentId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
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
         sMode90 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G90( ) ;
         Gx_mode = sMode90;
      }

      protected void OnDeleteControls1G90( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001G13 */
            pr_default.execute(11, new Object[] {A303AgendaCalendarId});
            A29LocationId = BC001G13_A29LocationId[0];
            A11OrganisationId = BC001G13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001G14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            A72ResidentSalutation = BC001G14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G14_A65ResidentLastName[0];
            A66ResidentInitials = BC001G14_A66ResidentInitials[0];
            A67ResidentEmail = BC001G14_A67ResidentEmail[0];
            A68ResidentGender = BC001G14_A68ResidentGender[0];
            A354ResidentCountry = BC001G14_A354ResidentCountry[0];
            A355ResidentCity = BC001G14_A355ResidentCity[0];
            A356ResidentZipCode = BC001G14_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G14_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G14_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G14_A71ResidentGUID[0];
            A375ResidentPhoneCode = BC001G14_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G14_A376ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001G14_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001G15 */
            pr_default.execute(13, new Object[] {A96ResidentTypeId});
            A97ResidentTypeName = BC001G15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001G16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = BC001G16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel1G90( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G90( ) ;
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

      public void ScanKeyStart1G90( )
      {
         /* Using cursor BC001G17 */
         pr_default.execute(15, new Object[] {A303AgendaCalendarId, A62ResidentId});
         RcdFound90 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound90 = 1;
            A455AgendaEventGroupRSVP = BC001G17_A455AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001G17_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G17_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G17_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G17_A65ResidentLastName[0];
            A66ResidentInitials = BC001G17_A66ResidentInitials[0];
            A67ResidentEmail = BC001G17_A67ResidentEmail[0];
            A68ResidentGender = BC001G17_A68ResidentGender[0];
            A354ResidentCountry = BC001G17_A354ResidentCountry[0];
            A355ResidentCity = BC001G17_A355ResidentCity[0];
            A356ResidentZipCode = BC001G17_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G17_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G17_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G17_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G17_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G17_A71ResidentGUID[0];
            A97ResidentTypeName = BC001G17_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001G17_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC001G17_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G17_A376ResidentPhoneNumber[0];
            A303AgendaCalendarId = BC001G17_A303AgendaCalendarId[0];
            A29LocationId = BC001G17_A29LocationId[0];
            A11OrganisationId = BC001G17_A11OrganisationId[0];
            A62ResidentId = BC001G17_A62ResidentId[0];
            A96ResidentTypeId = BC001G17_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G17_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G17_n98MedicalIndicationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G90( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound90 = 0;
         ScanKeyLoad1G90( ) ;
      }

      protected void ScanKeyLoad1G90( )
      {
         sMode90 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound90 = 1;
            A455AgendaEventGroupRSVP = BC001G17_A455AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001G17_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G17_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G17_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G17_A65ResidentLastName[0];
            A66ResidentInitials = BC001G17_A66ResidentInitials[0];
            A67ResidentEmail = BC001G17_A67ResidentEmail[0];
            A68ResidentGender = BC001G17_A68ResidentGender[0];
            A354ResidentCountry = BC001G17_A354ResidentCountry[0];
            A355ResidentCity = BC001G17_A355ResidentCity[0];
            A356ResidentZipCode = BC001G17_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G17_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G17_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G17_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G17_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G17_A71ResidentGUID[0];
            A97ResidentTypeName = BC001G17_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001G17_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC001G17_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G17_A376ResidentPhoneNumber[0];
            A303AgendaCalendarId = BC001G17_A303AgendaCalendarId[0];
            A29LocationId = BC001G17_A29LocationId[0];
            A11OrganisationId = BC001G17_A11OrganisationId[0];
            A62ResidentId = BC001G17_A62ResidentId[0];
            A96ResidentTypeId = BC001G17_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G17_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G17_n98MedicalIndicationId[0];
         }
         Gx_mode = sMode90;
      }

      protected void ScanKeyEnd1G90( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1G90( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G90( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G90( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G90( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G90( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G90( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G90( )
      {
      }

      protected void send_integrity_lvl_hashes1G90( )
      {
      }

      protected void AddRow1G90( )
      {
         VarsToRow90( bcTrn_AgendaEventGroup) ;
      }

      protected void ReadRow1G90( )
      {
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
      }

      protected void InitializeNonKey1G90( )
      {
         A455AgendaEventGroupRSVP = false;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A354ResidentCountry = "";
         A355ResidentCity = "";
         A356ResidentZipCode = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         A70ResidentPhone = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A71ResidentGUID = "";
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = "";
         A375ResidentPhoneCode = "";
         A376ResidentPhoneNumber = "";
         Z455AgendaEventGroupRSVP = false;
      }

      protected void InitAll1G90( )
      {
         A303AgendaCalendarId = Guid.Empty;
         A62ResidentId = Guid.NewGuid( );
         InitializeNonKey1G90( ) ;
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

      public void VarsToRow90( SdtTrn_AgendaEventGroup obj90 )
      {
         obj90.gxTpr_Mode = Gx_mode;
         obj90.gxTpr_Agendaeventgrouprsvp = A455AgendaEventGroupRSVP;
         obj90.gxTpr_Locationid = A29LocationId;
         obj90.gxTpr_Organisationid = A11OrganisationId;
         obj90.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj90.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
         obj90.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj90.gxTpr_Residentlastname = A65ResidentLastName;
         obj90.gxTpr_Residentinitials = A66ResidentInitials;
         obj90.gxTpr_Residentemail = A67ResidentEmail;
         obj90.gxTpr_Residentgender = A68ResidentGender;
         obj90.gxTpr_Residentcountry = A354ResidentCountry;
         obj90.gxTpr_Residentcity = A355ResidentCity;
         obj90.gxTpr_Residentzipcode = A356ResidentZipCode;
         obj90.gxTpr_Residentaddressline1 = A357ResidentAddressLine1;
         obj90.gxTpr_Residentaddressline2 = A358ResidentAddressLine2;
         obj90.gxTpr_Residentphone = A70ResidentPhone;
         obj90.gxTpr_Residentbirthdate = A73ResidentBirthDate;
         obj90.gxTpr_Residentguid = A71ResidentGUID;
         obj90.gxTpr_Residenttypeid = A96ResidentTypeId;
         obj90.gxTpr_Residenttypename = A97ResidentTypeName;
         obj90.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         obj90.gxTpr_Medicalindicationname = A99MedicalIndicationName;
         obj90.gxTpr_Residentphonecode = A375ResidentPhoneCode;
         obj90.gxTpr_Residentphonenumber = A376ResidentPhoneNumber;
         obj90.gxTpr_Agendacalendarid = A303AgendaCalendarId;
         obj90.gxTpr_Residentid = A62ResidentId;
         obj90.gxTpr_Agendacalendarid_Z = Z303AgendaCalendarId;
         obj90.gxTpr_Residentid_Z = Z62ResidentId;
         obj90.gxTpr_Agendaeventgrouprsvp_Z = Z455AgendaEventGroupRSVP;
         obj90.gxTpr_Locationid_Z = Z29LocationId;
         obj90.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj90.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj90.gxTpr_Residentbsnnumber_Z = Z63ResidentBsnNumber;
         obj90.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj90.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj90.gxTpr_Residentinitials_Z = Z66ResidentInitials;
         obj90.gxTpr_Residentemail_Z = Z67ResidentEmail;
         obj90.gxTpr_Residentgender_Z = Z68ResidentGender;
         obj90.gxTpr_Residentcountry_Z = Z354ResidentCountry;
         obj90.gxTpr_Residentcity_Z = Z355ResidentCity;
         obj90.gxTpr_Residentzipcode_Z = Z356ResidentZipCode;
         obj90.gxTpr_Residentaddressline1_Z = Z357ResidentAddressLine1;
         obj90.gxTpr_Residentaddressline2_Z = Z358ResidentAddressLine2;
         obj90.gxTpr_Residentphone_Z = Z70ResidentPhone;
         obj90.gxTpr_Residentbirthdate_Z = Z73ResidentBirthDate;
         obj90.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj90.gxTpr_Residenttypeid_Z = Z96ResidentTypeId;
         obj90.gxTpr_Residenttypename_Z = Z97ResidentTypeName;
         obj90.gxTpr_Medicalindicationid_Z = Z98MedicalIndicationId;
         obj90.gxTpr_Medicalindicationname_Z = Z99MedicalIndicationName;
         obj90.gxTpr_Residentphonecode_Z = Z375ResidentPhoneCode;
         obj90.gxTpr_Residentphonenumber_Z = Z376ResidentPhoneNumber;
         obj90.gxTpr_Medicalindicationid_N = (short)(Convert.ToInt16(n98MedicalIndicationId));
         obj90.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow90( SdtTrn_AgendaEventGroup obj90 )
      {
         obj90.gxTpr_Agendacalendarid = A303AgendaCalendarId;
         obj90.gxTpr_Residentid = A62ResidentId;
         return  ;
      }

      public void RowToVars90( SdtTrn_AgendaEventGroup obj90 ,
                               int forceLoad )
      {
         Gx_mode = obj90.gxTpr_Mode;
         A455AgendaEventGroupRSVP = obj90.gxTpr_Agendaeventgrouprsvp;
         A29LocationId = obj90.gxTpr_Locationid;
         A11OrganisationId = obj90.gxTpr_Organisationid;
         A72ResidentSalutation = obj90.gxTpr_Residentsalutation;
         A63ResidentBsnNumber = obj90.gxTpr_Residentbsnnumber;
         A64ResidentGivenName = obj90.gxTpr_Residentgivenname;
         A65ResidentLastName = obj90.gxTpr_Residentlastname;
         A66ResidentInitials = obj90.gxTpr_Residentinitials;
         A67ResidentEmail = obj90.gxTpr_Residentemail;
         A68ResidentGender = obj90.gxTpr_Residentgender;
         A354ResidentCountry = obj90.gxTpr_Residentcountry;
         A355ResidentCity = obj90.gxTpr_Residentcity;
         A356ResidentZipCode = obj90.gxTpr_Residentzipcode;
         A357ResidentAddressLine1 = obj90.gxTpr_Residentaddressline1;
         A358ResidentAddressLine2 = obj90.gxTpr_Residentaddressline2;
         A70ResidentPhone = obj90.gxTpr_Residentphone;
         A73ResidentBirthDate = obj90.gxTpr_Residentbirthdate;
         A71ResidentGUID = obj90.gxTpr_Residentguid;
         A96ResidentTypeId = obj90.gxTpr_Residenttypeid;
         A97ResidentTypeName = obj90.gxTpr_Residenttypename;
         A98MedicalIndicationId = obj90.gxTpr_Medicalindicationid;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = obj90.gxTpr_Medicalindicationname;
         A375ResidentPhoneCode = obj90.gxTpr_Residentphonecode;
         A376ResidentPhoneNumber = obj90.gxTpr_Residentphonenumber;
         A303AgendaCalendarId = obj90.gxTpr_Agendacalendarid;
         A62ResidentId = obj90.gxTpr_Residentid;
         Z303AgendaCalendarId = obj90.gxTpr_Agendacalendarid_Z;
         Z62ResidentId = obj90.gxTpr_Residentid_Z;
         Z455AgendaEventGroupRSVP = obj90.gxTpr_Agendaeventgrouprsvp_Z;
         Z29LocationId = obj90.gxTpr_Locationid_Z;
         Z11OrganisationId = obj90.gxTpr_Organisationid_Z;
         Z72ResidentSalutation = obj90.gxTpr_Residentsalutation_Z;
         Z63ResidentBsnNumber = obj90.gxTpr_Residentbsnnumber_Z;
         Z64ResidentGivenName = obj90.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj90.gxTpr_Residentlastname_Z;
         Z66ResidentInitials = obj90.gxTpr_Residentinitials_Z;
         Z67ResidentEmail = obj90.gxTpr_Residentemail_Z;
         Z68ResidentGender = obj90.gxTpr_Residentgender_Z;
         Z354ResidentCountry = obj90.gxTpr_Residentcountry_Z;
         Z355ResidentCity = obj90.gxTpr_Residentcity_Z;
         Z356ResidentZipCode = obj90.gxTpr_Residentzipcode_Z;
         Z357ResidentAddressLine1 = obj90.gxTpr_Residentaddressline1_Z;
         Z358ResidentAddressLine2 = obj90.gxTpr_Residentaddressline2_Z;
         Z70ResidentPhone = obj90.gxTpr_Residentphone_Z;
         Z73ResidentBirthDate = obj90.gxTpr_Residentbirthdate_Z;
         Z71ResidentGUID = obj90.gxTpr_Residentguid_Z;
         Z96ResidentTypeId = obj90.gxTpr_Residenttypeid_Z;
         Z97ResidentTypeName = obj90.gxTpr_Residenttypename_Z;
         Z98MedicalIndicationId = obj90.gxTpr_Medicalindicationid_Z;
         Z99MedicalIndicationName = obj90.gxTpr_Medicalindicationname_Z;
         Z375ResidentPhoneCode = obj90.gxTpr_Residentphonecode_Z;
         Z376ResidentPhoneNumber = obj90.gxTpr_Residentphonenumber_Z;
         n98MedicalIndicationId = (bool)(Convert.ToBoolean(obj90.gxTpr_Medicalindicationid_N));
         Gx_mode = obj90.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A303AgendaCalendarId = (Guid)getParm(obj,0);
         A62ResidentId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1G90( ) ;
         ScanKeyStart1G90( ) ;
         if ( RcdFound90 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001G13 */
            pr_default.execute(11, new Object[] {A303AgendaCalendarId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_AgendaCalendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
               AnyError = 1;
            }
            A29LocationId = BC001G13_A29LocationId[0];
            A11OrganisationId = BC001G13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001G14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            A72ResidentSalutation = BC001G14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G14_A65ResidentLastName[0];
            A66ResidentInitials = BC001G14_A66ResidentInitials[0];
            A67ResidentEmail = BC001G14_A67ResidentEmail[0];
            A68ResidentGender = BC001G14_A68ResidentGender[0];
            A354ResidentCountry = BC001G14_A354ResidentCountry[0];
            A355ResidentCity = BC001G14_A355ResidentCity[0];
            A356ResidentZipCode = BC001G14_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G14_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G14_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G14_A71ResidentGUID[0];
            A375ResidentPhoneCode = BC001G14_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G14_A376ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001G14_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001G15 */
            pr_default.execute(13, new Object[] {A96ResidentTypeId});
            if ( (pr_default.getStatus(13) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
            A97ResidentTypeName = BC001G15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001G16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(14) == 101) )
            {
               if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
                  AnyError = 1;
               }
            }
            A99MedicalIndicationName = BC001G16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
         else
         {
            Gx_mode = "UPD";
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
         }
         ZM1G90( -4) ;
         OnLoadActions1G90( ) ;
         AddRow1G90( ) ;
         ScanKeyEnd1G90( ) ;
         if ( RcdFound90 == 0 )
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
         RowToVars90( bcTrn_AgendaEventGroup, 0) ;
         ScanKeyStart1G90( ) ;
         if ( RcdFound90 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001G13 */
            pr_default.execute(11, new Object[] {A303AgendaCalendarId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_AgendaCalendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
               AnyError = 1;
            }
            A29LocationId = BC001G13_A29LocationId[0];
            A11OrganisationId = BC001G13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001G14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            A72ResidentSalutation = BC001G14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001G14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001G14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001G14_A65ResidentLastName[0];
            A66ResidentInitials = BC001G14_A66ResidentInitials[0];
            A67ResidentEmail = BC001G14_A67ResidentEmail[0];
            A68ResidentGender = BC001G14_A68ResidentGender[0];
            A354ResidentCountry = BC001G14_A354ResidentCountry[0];
            A355ResidentCity = BC001G14_A355ResidentCity[0];
            A356ResidentZipCode = BC001G14_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC001G14_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC001G14_A358ResidentAddressLine2[0];
            A70ResidentPhone = BC001G14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001G14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001G14_A71ResidentGUID[0];
            A375ResidentPhoneCode = BC001G14_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC001G14_A376ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001G14_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC001G14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001G14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001G15 */
            pr_default.execute(13, new Object[] {A96ResidentTypeId});
            if ( (pr_default.getStatus(13) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
            A97ResidentTypeName = BC001G15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001G16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(14) == 101) )
            {
               if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
                  AnyError = 1;
               }
            }
            A99MedicalIndicationName = BC001G16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
         else
         {
            Gx_mode = "UPD";
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
         }
         ZM1G90( -4) ;
         OnLoadActions1G90( ) ;
         AddRow1G90( ) ;
         ScanKeyEnd1G90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1G90( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1G90( ) ;
         }
         else
         {
            if ( RcdFound90 == 1 )
            {
               if ( ( A303AgendaCalendarId != Z303AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
               {
                  A303AgendaCalendarId = Z303AgendaCalendarId;
                  A62ResidentId = Z62ResidentId;
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
                  Update1G90( ) ;
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
                  if ( ( A303AgendaCalendarId != Z303AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
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
                        Insert1G90( ) ;
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
                        Insert1G90( ) ;
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
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
         SaveImpl( ) ;
         VarsToRow90( bcTrn_AgendaEventGroup) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G90( ) ;
         AfterTrn( ) ;
         VarsToRow90( bcTrn_AgendaEventGroup) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow90( bcTrn_AgendaEventGroup) ;
         }
         else
         {
            SdtTrn_AgendaEventGroup auxBC = new SdtTrn_AgendaEventGroup(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A303AgendaCalendarId, A62ResidentId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AgendaEventGroup);
               auxBC.Save();
               bcTrn_AgendaEventGroup.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
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
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G90( ) ;
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
               VarsToRow90( bcTrn_AgendaEventGroup) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow90( bcTrn_AgendaEventGroup) ;
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
         RowToVars90( bcTrn_AgendaEventGroup, 0) ;
         GetKey1G90( ) ;
         if ( RcdFound90 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A303AgendaCalendarId != Z303AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
            {
               A303AgendaCalendarId = Z303AgendaCalendarId;
               A62ResidentId = Z62ResidentId;
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
            if ( ( A303AgendaCalendarId != Z303AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
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
         context.RollbackDataStores("trn_agendaeventgroup_bc",pr_default);
         VarsToRow90( bcTrn_AgendaEventGroup) ;
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
         Gx_mode = bcTrn_AgendaEventGroup.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AgendaEventGroup.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AgendaEventGroup )
         {
            bcTrn_AgendaEventGroup = (SdtTrn_AgendaEventGroup)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AgendaEventGroup.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaEventGroup.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow90( bcTrn_AgendaEventGroup) ;
            }
            else
            {
               RowToVars90( bcTrn_AgendaEventGroup, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AgendaEventGroup.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaEventGroup.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars90( bcTrn_AgendaEventGroup, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AgendaEventGroup Trn_AgendaEventGroup_BC
      {
         get {
            return bcTrn_AgendaEventGroup ;
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
            return "trn_agendaeventgroup_Execute" ;
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
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z303AgendaCalendarId = Guid.Empty;
         A303AgendaCalendarId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         A63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z66ResidentInitials = "";
         A66ResidentInitials = "";
         Z67ResidentEmail = "";
         A67ResidentEmail = "";
         Z68ResidentGender = "";
         A68ResidentGender = "";
         Z354ResidentCountry = "";
         A354ResidentCountry = "";
         Z355ResidentCity = "";
         A355ResidentCity = "";
         Z356ResidentZipCode = "";
         A356ResidentZipCode = "";
         Z357ResidentAddressLine1 = "";
         A357ResidentAddressLine1 = "";
         Z358ResidentAddressLine2 = "";
         A358ResidentAddressLine2 = "";
         Z70ResidentPhone = "";
         A70ResidentPhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         A73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z375ResidentPhoneCode = "";
         A375ResidentPhoneCode = "";
         Z376ResidentPhoneNumber = "";
         A376ResidentPhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         Z97ResidentTypeName = "";
         A97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         A99MedicalIndicationName = "";
         BC001G8_A455AgendaEventGroupRSVP = new bool[] {false} ;
         BC001G8_A72ResidentSalutation = new string[] {""} ;
         BC001G8_A63ResidentBsnNumber = new string[] {""} ;
         BC001G8_A64ResidentGivenName = new string[] {""} ;
         BC001G8_A65ResidentLastName = new string[] {""} ;
         BC001G8_A66ResidentInitials = new string[] {""} ;
         BC001G8_A67ResidentEmail = new string[] {""} ;
         BC001G8_A68ResidentGender = new string[] {""} ;
         BC001G8_A354ResidentCountry = new string[] {""} ;
         BC001G8_A355ResidentCity = new string[] {""} ;
         BC001G8_A356ResidentZipCode = new string[] {""} ;
         BC001G8_A357ResidentAddressLine1 = new string[] {""} ;
         BC001G8_A358ResidentAddressLine2 = new string[] {""} ;
         BC001G8_A70ResidentPhone = new string[] {""} ;
         BC001G8_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001G8_A71ResidentGUID = new string[] {""} ;
         BC001G8_A97ResidentTypeName = new string[] {""} ;
         BC001G8_A99MedicalIndicationName = new string[] {""} ;
         BC001G8_A375ResidentPhoneCode = new string[] {""} ;
         BC001G8_A376ResidentPhoneNumber = new string[] {""} ;
         BC001G8_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001G8_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001G8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G8_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001G8_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001G8_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001G8_n98MedicalIndicationId = new bool[] {false} ;
         BC001G4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001G4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G5_A72ResidentSalutation = new string[] {""} ;
         BC001G5_A63ResidentBsnNumber = new string[] {""} ;
         BC001G5_A64ResidentGivenName = new string[] {""} ;
         BC001G5_A65ResidentLastName = new string[] {""} ;
         BC001G5_A66ResidentInitials = new string[] {""} ;
         BC001G5_A67ResidentEmail = new string[] {""} ;
         BC001G5_A68ResidentGender = new string[] {""} ;
         BC001G5_A354ResidentCountry = new string[] {""} ;
         BC001G5_A355ResidentCity = new string[] {""} ;
         BC001G5_A356ResidentZipCode = new string[] {""} ;
         BC001G5_A357ResidentAddressLine1 = new string[] {""} ;
         BC001G5_A358ResidentAddressLine2 = new string[] {""} ;
         BC001G5_A70ResidentPhone = new string[] {""} ;
         BC001G5_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001G5_A71ResidentGUID = new string[] {""} ;
         BC001G5_A375ResidentPhoneCode = new string[] {""} ;
         BC001G5_A376ResidentPhoneNumber = new string[] {""} ;
         BC001G5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001G5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001G5_n98MedicalIndicationId = new bool[] {false} ;
         BC001G6_A97ResidentTypeName = new string[] {""} ;
         BC001G7_A99MedicalIndicationName = new string[] {""} ;
         BC001G9_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001G9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001G3_A455AgendaEventGroupRSVP = new bool[] {false} ;
         BC001G3_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001G3_A62ResidentId = new Guid[] {Guid.Empty} ;
         sMode90 = "";
         BC001G2_A455AgendaEventGroupRSVP = new bool[] {false} ;
         BC001G2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001G2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001G13_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001G13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G14_A72ResidentSalutation = new string[] {""} ;
         BC001G14_A63ResidentBsnNumber = new string[] {""} ;
         BC001G14_A64ResidentGivenName = new string[] {""} ;
         BC001G14_A65ResidentLastName = new string[] {""} ;
         BC001G14_A66ResidentInitials = new string[] {""} ;
         BC001G14_A67ResidentEmail = new string[] {""} ;
         BC001G14_A68ResidentGender = new string[] {""} ;
         BC001G14_A354ResidentCountry = new string[] {""} ;
         BC001G14_A355ResidentCity = new string[] {""} ;
         BC001G14_A356ResidentZipCode = new string[] {""} ;
         BC001G14_A357ResidentAddressLine1 = new string[] {""} ;
         BC001G14_A358ResidentAddressLine2 = new string[] {""} ;
         BC001G14_A70ResidentPhone = new string[] {""} ;
         BC001G14_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001G14_A71ResidentGUID = new string[] {""} ;
         BC001G14_A375ResidentPhoneCode = new string[] {""} ;
         BC001G14_A376ResidentPhoneNumber = new string[] {""} ;
         BC001G14_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001G14_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001G14_n98MedicalIndicationId = new bool[] {false} ;
         BC001G15_A97ResidentTypeName = new string[] {""} ;
         BC001G16_A99MedicalIndicationName = new string[] {""} ;
         BC001G17_A455AgendaEventGroupRSVP = new bool[] {false} ;
         BC001G17_A72ResidentSalutation = new string[] {""} ;
         BC001G17_A63ResidentBsnNumber = new string[] {""} ;
         BC001G17_A64ResidentGivenName = new string[] {""} ;
         BC001G17_A65ResidentLastName = new string[] {""} ;
         BC001G17_A66ResidentInitials = new string[] {""} ;
         BC001G17_A67ResidentEmail = new string[] {""} ;
         BC001G17_A68ResidentGender = new string[] {""} ;
         BC001G17_A354ResidentCountry = new string[] {""} ;
         BC001G17_A355ResidentCity = new string[] {""} ;
         BC001G17_A356ResidentZipCode = new string[] {""} ;
         BC001G17_A357ResidentAddressLine1 = new string[] {""} ;
         BC001G17_A358ResidentAddressLine2 = new string[] {""} ;
         BC001G17_A70ResidentPhone = new string[] {""} ;
         BC001G17_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001G17_A71ResidentGUID = new string[] {""} ;
         BC001G17_A97ResidentTypeName = new string[] {""} ;
         BC001G17_A99MedicalIndicationName = new string[] {""} ;
         BC001G17_A375ResidentPhoneCode = new string[] {""} ;
         BC001G17_A376ResidentPhoneNumber = new string[] {""} ;
         BC001G17_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001G17_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001G17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G17_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001G17_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001G17_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001G17_n98MedicalIndicationId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__default(),
            new Object[][] {
                new Object[] {
               BC001G2_A455AgendaEventGroupRSVP, BC001G2_A303AgendaCalendarId, BC001G2_A62ResidentId
               }
               , new Object[] {
               BC001G3_A455AgendaEventGroupRSVP, BC001G3_A303AgendaCalendarId, BC001G3_A62ResidentId
               }
               , new Object[] {
               BC001G4_A29LocationId, BC001G4_A11OrganisationId
               }
               , new Object[] {
               BC001G5_A72ResidentSalutation, BC001G5_A63ResidentBsnNumber, BC001G5_A64ResidentGivenName, BC001G5_A65ResidentLastName, BC001G5_A66ResidentInitials, BC001G5_A67ResidentEmail, BC001G5_A68ResidentGender, BC001G5_A354ResidentCountry, BC001G5_A355ResidentCity, BC001G5_A356ResidentZipCode,
               BC001G5_A357ResidentAddressLine1, BC001G5_A358ResidentAddressLine2, BC001G5_A70ResidentPhone, BC001G5_A73ResidentBirthDate, BC001G5_A71ResidentGUID, BC001G5_A375ResidentPhoneCode, BC001G5_A376ResidentPhoneNumber, BC001G5_A96ResidentTypeId, BC001G5_A98MedicalIndicationId, BC001G5_n98MedicalIndicationId
               }
               , new Object[] {
               BC001G6_A97ResidentTypeName
               }
               , new Object[] {
               BC001G7_A99MedicalIndicationName
               }
               , new Object[] {
               BC001G8_A455AgendaEventGroupRSVP, BC001G8_A72ResidentSalutation, BC001G8_A63ResidentBsnNumber, BC001G8_A64ResidentGivenName, BC001G8_A65ResidentLastName, BC001G8_A66ResidentInitials, BC001G8_A67ResidentEmail, BC001G8_A68ResidentGender, BC001G8_A354ResidentCountry, BC001G8_A355ResidentCity,
               BC001G8_A356ResidentZipCode, BC001G8_A357ResidentAddressLine1, BC001G8_A358ResidentAddressLine2, BC001G8_A70ResidentPhone, BC001G8_A73ResidentBirthDate, BC001G8_A71ResidentGUID, BC001G8_A97ResidentTypeName, BC001G8_A99MedicalIndicationName, BC001G8_A375ResidentPhoneCode, BC001G8_A376ResidentPhoneNumber,
               BC001G8_A303AgendaCalendarId, BC001G8_A29LocationId, BC001G8_A11OrganisationId, BC001G8_A62ResidentId, BC001G8_A96ResidentTypeId, BC001G8_A98MedicalIndicationId, BC001G8_n98MedicalIndicationId
               }
               , new Object[] {
               BC001G9_A303AgendaCalendarId, BC001G9_A62ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G13_A29LocationId, BC001G13_A11OrganisationId
               }
               , new Object[] {
               BC001G14_A72ResidentSalutation, BC001G14_A63ResidentBsnNumber, BC001G14_A64ResidentGivenName, BC001G14_A65ResidentLastName, BC001G14_A66ResidentInitials, BC001G14_A67ResidentEmail, BC001G14_A68ResidentGender, BC001G14_A354ResidentCountry, BC001G14_A355ResidentCity, BC001G14_A356ResidentZipCode,
               BC001G14_A357ResidentAddressLine1, BC001G14_A358ResidentAddressLine2, BC001G14_A70ResidentPhone, BC001G14_A73ResidentBirthDate, BC001G14_A71ResidentGUID, BC001G14_A375ResidentPhoneCode, BC001G14_A376ResidentPhoneNumber, BC001G14_A96ResidentTypeId, BC001G14_A98MedicalIndicationId, BC001G14_n98MedicalIndicationId
               }
               , new Object[] {
               BC001G15_A97ResidentTypeName
               }
               , new Object[] {
               BC001G16_A99MedicalIndicationName
               }
               , new Object[] {
               BC001G17_A455AgendaEventGroupRSVP, BC001G17_A72ResidentSalutation, BC001G17_A63ResidentBsnNumber, BC001G17_A64ResidentGivenName, BC001G17_A65ResidentLastName, BC001G17_A66ResidentInitials, BC001G17_A67ResidentEmail, BC001G17_A68ResidentGender, BC001G17_A354ResidentCountry, BC001G17_A355ResidentCity,
               BC001G17_A356ResidentZipCode, BC001G17_A357ResidentAddressLine1, BC001G17_A358ResidentAddressLine2, BC001G17_A70ResidentPhone, BC001G17_A73ResidentBirthDate, BC001G17_A71ResidentGUID, BC001G17_A97ResidentTypeName, BC001G17_A99MedicalIndicationName, BC001G17_A375ResidentPhoneCode, BC001G17_A376ResidentPhoneNumber,
               BC001G17_A303AgendaCalendarId, BC001G17_A29LocationId, BC001G17_A11OrganisationId, BC001G17_A62ResidentId, BC001G17_A96ResidentTypeId, BC001G17_A98MedicalIndicationId, BC001G17_n98MedicalIndicationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound90 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string Z66ResidentInitials ;
      private string A66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string A70ResidentPhone ;
      private string sMode90 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool Z455AgendaEventGroupRSVP ;
      private bool A455AgendaEventGroupRSVP ;
      private bool n98MedicalIndicationId ;
      private string Z63ResidentBsnNumber ;
      private string A63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string A64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string A65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string A67ResidentEmail ;
      private string Z68ResidentGender ;
      private string A68ResidentGender ;
      private string Z354ResidentCountry ;
      private string A354ResidentCountry ;
      private string Z355ResidentCity ;
      private string A355ResidentCity ;
      private string Z356ResidentZipCode ;
      private string A356ResidentZipCode ;
      private string Z357ResidentAddressLine1 ;
      private string A357ResidentAddressLine1 ;
      private string Z358ResidentAddressLine2 ;
      private string A358ResidentAddressLine2 ;
      private string Z71ResidentGUID ;
      private string A71ResidentGUID ;
      private string Z375ResidentPhoneCode ;
      private string A375ResidentPhoneCode ;
      private string Z376ResidentPhoneNumber ;
      private string A376ResidentPhoneNumber ;
      private string Z97ResidentTypeName ;
      private string A97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string A99MedicalIndicationName ;
      private Guid Z303AgendaCalendarId ;
      private Guid A303AgendaCalendarId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z96ResidentTypeId ;
      private Guid A96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid A98MedicalIndicationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] BC001G8_A455AgendaEventGroupRSVP ;
      private string[] BC001G8_A72ResidentSalutation ;
      private string[] BC001G8_A63ResidentBsnNumber ;
      private string[] BC001G8_A64ResidentGivenName ;
      private string[] BC001G8_A65ResidentLastName ;
      private string[] BC001G8_A66ResidentInitials ;
      private string[] BC001G8_A67ResidentEmail ;
      private string[] BC001G8_A68ResidentGender ;
      private string[] BC001G8_A354ResidentCountry ;
      private string[] BC001G8_A355ResidentCity ;
      private string[] BC001G8_A356ResidentZipCode ;
      private string[] BC001G8_A357ResidentAddressLine1 ;
      private string[] BC001G8_A358ResidentAddressLine2 ;
      private string[] BC001G8_A70ResidentPhone ;
      private DateTime[] BC001G8_A73ResidentBirthDate ;
      private string[] BC001G8_A71ResidentGUID ;
      private string[] BC001G8_A97ResidentTypeName ;
      private string[] BC001G8_A99MedicalIndicationName ;
      private string[] BC001G8_A375ResidentPhoneCode ;
      private string[] BC001G8_A376ResidentPhoneNumber ;
      private Guid[] BC001G8_A303AgendaCalendarId ;
      private Guid[] BC001G8_A29LocationId ;
      private Guid[] BC001G8_A11OrganisationId ;
      private Guid[] BC001G8_A62ResidentId ;
      private Guid[] BC001G8_A96ResidentTypeId ;
      private Guid[] BC001G8_A98MedicalIndicationId ;
      private bool[] BC001G8_n98MedicalIndicationId ;
      private Guid[] BC001G4_A29LocationId ;
      private Guid[] BC001G4_A11OrganisationId ;
      private string[] BC001G5_A72ResidentSalutation ;
      private string[] BC001G5_A63ResidentBsnNumber ;
      private string[] BC001G5_A64ResidentGivenName ;
      private string[] BC001G5_A65ResidentLastName ;
      private string[] BC001G5_A66ResidentInitials ;
      private string[] BC001G5_A67ResidentEmail ;
      private string[] BC001G5_A68ResidentGender ;
      private string[] BC001G5_A354ResidentCountry ;
      private string[] BC001G5_A355ResidentCity ;
      private string[] BC001G5_A356ResidentZipCode ;
      private string[] BC001G5_A357ResidentAddressLine1 ;
      private string[] BC001G5_A358ResidentAddressLine2 ;
      private string[] BC001G5_A70ResidentPhone ;
      private DateTime[] BC001G5_A73ResidentBirthDate ;
      private string[] BC001G5_A71ResidentGUID ;
      private string[] BC001G5_A375ResidentPhoneCode ;
      private string[] BC001G5_A376ResidentPhoneNumber ;
      private Guid[] BC001G5_A96ResidentTypeId ;
      private Guid[] BC001G5_A98MedicalIndicationId ;
      private bool[] BC001G5_n98MedicalIndicationId ;
      private string[] BC001G6_A97ResidentTypeName ;
      private string[] BC001G7_A99MedicalIndicationName ;
      private Guid[] BC001G9_A303AgendaCalendarId ;
      private Guid[] BC001G9_A62ResidentId ;
      private bool[] BC001G3_A455AgendaEventGroupRSVP ;
      private Guid[] BC001G3_A303AgendaCalendarId ;
      private Guid[] BC001G3_A62ResidentId ;
      private bool[] BC001G2_A455AgendaEventGroupRSVP ;
      private Guid[] BC001G2_A303AgendaCalendarId ;
      private Guid[] BC001G2_A62ResidentId ;
      private Guid[] BC001G13_A29LocationId ;
      private Guid[] BC001G13_A11OrganisationId ;
      private string[] BC001G14_A72ResidentSalutation ;
      private string[] BC001G14_A63ResidentBsnNumber ;
      private string[] BC001G14_A64ResidentGivenName ;
      private string[] BC001G14_A65ResidentLastName ;
      private string[] BC001G14_A66ResidentInitials ;
      private string[] BC001G14_A67ResidentEmail ;
      private string[] BC001G14_A68ResidentGender ;
      private string[] BC001G14_A354ResidentCountry ;
      private string[] BC001G14_A355ResidentCity ;
      private string[] BC001G14_A356ResidentZipCode ;
      private string[] BC001G14_A357ResidentAddressLine1 ;
      private string[] BC001G14_A358ResidentAddressLine2 ;
      private string[] BC001G14_A70ResidentPhone ;
      private DateTime[] BC001G14_A73ResidentBirthDate ;
      private string[] BC001G14_A71ResidentGUID ;
      private string[] BC001G14_A375ResidentPhoneCode ;
      private string[] BC001G14_A376ResidentPhoneNumber ;
      private Guid[] BC001G14_A96ResidentTypeId ;
      private Guid[] BC001G14_A98MedicalIndicationId ;
      private bool[] BC001G14_n98MedicalIndicationId ;
      private string[] BC001G15_A97ResidentTypeName ;
      private string[] BC001G16_A99MedicalIndicationName ;
      private bool[] BC001G17_A455AgendaEventGroupRSVP ;
      private string[] BC001G17_A72ResidentSalutation ;
      private string[] BC001G17_A63ResidentBsnNumber ;
      private string[] BC001G17_A64ResidentGivenName ;
      private string[] BC001G17_A65ResidentLastName ;
      private string[] BC001G17_A66ResidentInitials ;
      private string[] BC001G17_A67ResidentEmail ;
      private string[] BC001G17_A68ResidentGender ;
      private string[] BC001G17_A354ResidentCountry ;
      private string[] BC001G17_A355ResidentCity ;
      private string[] BC001G17_A356ResidentZipCode ;
      private string[] BC001G17_A357ResidentAddressLine1 ;
      private string[] BC001G17_A358ResidentAddressLine2 ;
      private string[] BC001G17_A70ResidentPhone ;
      private DateTime[] BC001G17_A73ResidentBirthDate ;
      private string[] BC001G17_A71ResidentGUID ;
      private string[] BC001G17_A97ResidentTypeName ;
      private string[] BC001G17_A99MedicalIndicationName ;
      private string[] BC001G17_A375ResidentPhoneCode ;
      private string[] BC001G17_A376ResidentPhoneNumber ;
      private Guid[] BC001G17_A303AgendaCalendarId ;
      private Guid[] BC001G17_A29LocationId ;
      private Guid[] BC001G17_A11OrganisationId ;
      private Guid[] BC001G17_A62ResidentId ;
      private Guid[] BC001G17_A96ResidentTypeId ;
      private Guid[] BC001G17_A98MedicalIndicationId ;
      private bool[] BC001G17_n98MedicalIndicationId ;
      private SdtTrn_AgendaEventGroup bcTrn_AgendaEventGroup ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendaeventgroup_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_agendaeventgroup_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_agendaeventgroup_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001G2;
       prmBC001G2 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G3;
       prmBC001G3 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G4;
       prmBC001G4 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G5;
       prmBC001G5 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G6;
       prmBC001G6 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G7;
       prmBC001G7 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001G8;
       prmBC001G8 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G9;
       prmBC001G9 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G10;
       prmBC001G10 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G11;
       prmBC001G11 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G12;
       prmBC001G12 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G13;
       prmBC001G13 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G14;
       prmBC001G14 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G15;
       prmBC001G15 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001G16;
       prmBC001G16 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001G17;
       prmBC001G17 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001G2", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId  FOR UPDATE OF Trn_AgendaEventGroup",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G3", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G4", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G5", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G6", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G7", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G8", "SELECT TM1.AgendaEventGroupRSVP, T3.ResidentSalutation, T3.ResidentBsnNumber, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentInitials, T3.ResidentEmail, T3.ResidentGender, T3.ResidentCountry, T3.ResidentCity, T3.ResidentZipCode, T3.ResidentAddressLine1, T3.ResidentAddressLine2, T3.ResidentPhone, T3.ResidentBirthDate, T3.ResidentGUID, T4.ResidentTypeName, T5.MedicalIndicationName, T3.ResidentPhoneCode, T3.ResidentPhoneNumber, TM1.AgendaCalendarId, T2.LocationId, T2.OrganisationId, TM1.ResidentId, T3.ResidentTypeId, T3.MedicalIndicationId FROM ((((Trn_AgendaEventGroup TM1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = TM1.AgendaCalendarId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = T2.OrganisationId) INNER JOIN Trn_ResidentType T4 ON T4.ResidentTypeId = T3.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T5 ON T5.MedicalIndicationId = T3.MedicalIndicationId) WHERE TM1.AgendaCalendarId = :AgendaCalendarId and TM1.ResidentId = :ResidentId ORDER BY TM1.AgendaCalendarId, TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G9", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G10", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaEventGroup(AgendaEventGroupRSVP, AgendaCalendarId, ResidentId) VALUES(:AgendaEventGroupRSVP, :AgendaCalendarId, :ResidentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001G10)
          ,new CursorDef("BC001G11", "SAVEPOINT gxupdate;UPDATE Trn_AgendaEventGroup SET AgendaEventGroupRSVP=:AgendaEventGroupRSVP  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G11)
          ,new CursorDef("BC001G12", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaEventGroup  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G12)
          ,new CursorDef("BC001G13", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G14", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G15", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G16", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G17", "SELECT TM1.AgendaEventGroupRSVP, T3.ResidentSalutation, T3.ResidentBsnNumber, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentInitials, T3.ResidentEmail, T3.ResidentGender, T3.ResidentCountry, T3.ResidentCity, T3.ResidentZipCode, T3.ResidentAddressLine1, T3.ResidentAddressLine2, T3.ResidentPhone, T3.ResidentBirthDate, T3.ResidentGUID, T4.ResidentTypeName, T5.MedicalIndicationName, T3.ResidentPhoneCode, T3.ResidentPhoneNumber, TM1.AgendaCalendarId, T2.LocationId, T2.OrganisationId, TM1.ResidentId, T3.ResidentTypeId, T3.MedicalIndicationId FROM ((((Trn_AgendaEventGroup TM1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = TM1.AgendaCalendarId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = T2.OrganisationId) INNER JOIN Trn_ResidentType T4 ON T4.ResidentTypeId = T3.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T5 ON T5.MedicalIndicationId = T3.MedicalIndicationId) WHERE TM1.AgendaCalendarId = :AgendaCalendarId and TM1.ResidentId = :ResidentId ORDER BY TM1.AgendaCalendarId, TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G17,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((bool[]) buf[19])[0] = rslt.wasNull(19);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getString(14, 20);
             ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((Guid[]) buf[25])[0] = rslt.getGuid(26);
             ((bool[]) buf[26])[0] = rslt.wasNull(26);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((bool[]) buf[19])[0] = rslt.wasNull(19);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 15 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getString(14, 20);
             ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((Guid[]) buf[25])[0] = rslt.getGuid(26);
             ((bool[]) buf[26])[0] = rslt.wasNull(26);
             return;
    }
 }

}

}
