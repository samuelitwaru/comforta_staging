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
   public class trn_media_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_media_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_media_bc( IGxContext context )
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
         ReadRow0X83( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0X83( ) ;
         standaloneModal( ) ;
         AddRow0X83( ) ;
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
            E110X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z409MediaId = A409MediaId;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X83( ) ;
            }
            else
            {
               CheckExtendedTable0X83( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0X83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0X83( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z410MediaName = A410MediaName;
            Z413MediaSize = A413MediaSize;
            Z414MediaType = A414MediaType;
            Z412MediaUrl = A412MediaUrl;
         }
         if ( GX_JID == -4 )
         {
            Z409MediaId = A409MediaId;
            Z410MediaName = A410MediaName;
            Z411MediaImage = A411MediaImage;
            Z40000MediaImage_GXI = A40000MediaImage_GXI;
            Z413MediaSize = A413MediaSize;
            Z414MediaType = A414MediaType;
            Z412MediaUrl = A412MediaUrl;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A409MediaId) )
         {
            A409MediaId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0X83( )
      {
         /* Using cursor BC000X4 */
         pr_default.execute(2, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound83 = 1;
            A410MediaName = BC000X4_A410MediaName[0];
            A40000MediaImage_GXI = BC000X4_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC000X4_n40000MediaImage_GXI[0];
            A413MediaSize = BC000X4_A413MediaSize[0];
            A414MediaType = BC000X4_A414MediaType[0];
            A412MediaUrl = BC000X4_A412MediaUrl[0];
            A411MediaImage = BC000X4_A411MediaImage[0];
            n411MediaImage = BC000X4_n411MediaImage[0];
            ZM0X83( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0X83( ) ;
      }

      protected void OnLoadActions0X83( )
      {
      }

      protected void CheckExtendedTable0X83( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A412MediaUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Media Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0X83( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X83( )
      {
         /* Using cursor BC000X5 */
         pr_default.execute(3, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000X3 */
         pr_default.execute(1, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X83( 4) ;
            RcdFound83 = 1;
            A409MediaId = BC000X3_A409MediaId[0];
            A410MediaName = BC000X3_A410MediaName[0];
            A40000MediaImage_GXI = BC000X3_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC000X3_n40000MediaImage_GXI[0];
            A413MediaSize = BC000X3_A413MediaSize[0];
            A414MediaType = BC000X3_A414MediaType[0];
            A412MediaUrl = BC000X3_A412MediaUrl[0];
            A411MediaImage = BC000X3_A411MediaImage[0];
            n411MediaImage = BC000X3_n411MediaImage[0];
            Z409MediaId = A409MediaId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0X83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey0X83( ) ;
            }
            Gx_mode = sMode83;
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey0X83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode83;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X83( ) ;
         if ( RcdFound83 == 0 )
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
         CONFIRM_0X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0X83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000X2 */
            pr_default.execute(0, new Object[] {A409MediaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z410MediaName, BC000X2_A410MediaName[0]) != 0 ) || ( Z413MediaSize != BC000X2_A413MediaSize[0] ) || ( StringUtil.StrCmp(Z414MediaType, BC000X2_A414MediaType[0]) != 0 ) || ( StringUtil.StrCmp(Z412MediaUrl, BC000X2_A412MediaUrl[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Media"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X83( )
      {
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X83( 0) ;
            CheckOptimisticConcurrency0X83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X6 */
                     pr_default.execute(4, new Object[] {A409MediaId, A410MediaName, n411MediaImage, A411MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A413MediaSize, A414MediaType, A412MediaUrl});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
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
               Load0X83( ) ;
            }
            EndLevel0X83( ) ;
         }
         CloseExtendedTableCursors0X83( ) ;
      }

      protected void Update0X83( )
      {
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X7 */
                     pr_default.execute(5, new Object[] {A410MediaName, A413MediaSize, A414MediaType, A412MediaUrl, A409MediaId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X83( ) ;
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
            EndLevel0X83( ) ;
         }
         CloseExtendedTableCursors0X83( ) ;
      }

      protected void DeferredUpdate0X83( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000X8 */
            pr_default.execute(6, new Object[] {n411MediaImage, A411MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A409MediaId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X83( ) ;
            AfterConfirm0X83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000X9 */
                  pr_default.execute(7, new Object[] {A409MediaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0X83( ) ;
         Gx_mode = sMode83;
      }

      protected void OnDeleteControls0X83( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0X83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X83( ) ;
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

      public void ScanKeyStart0X83( )
      {
         /* Scan By routine */
         /* Using cursor BC000X10 */
         pr_default.execute(8, new Object[] {A409MediaId});
         RcdFound83 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound83 = 1;
            A409MediaId = BC000X10_A409MediaId[0];
            A410MediaName = BC000X10_A410MediaName[0];
            A40000MediaImage_GXI = BC000X10_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC000X10_n40000MediaImage_GXI[0];
            A413MediaSize = BC000X10_A413MediaSize[0];
            A414MediaType = BC000X10_A414MediaType[0];
            A412MediaUrl = BC000X10_A412MediaUrl[0];
            A411MediaImage = BC000X10_A411MediaImage[0];
            n411MediaImage = BC000X10_n411MediaImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0X83( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound83 = 0;
         ScanKeyLoad0X83( ) ;
      }

      protected void ScanKeyLoad0X83( )
      {
         sMode83 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound83 = 1;
            A409MediaId = BC000X10_A409MediaId[0];
            A410MediaName = BC000X10_A410MediaName[0];
            A40000MediaImage_GXI = BC000X10_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC000X10_n40000MediaImage_GXI[0];
            A413MediaSize = BC000X10_A413MediaSize[0];
            A414MediaType = BC000X10_A414MediaType[0];
            A412MediaUrl = BC000X10_A412MediaUrl[0];
            A411MediaImage = BC000X10_A411MediaImage[0];
            n411MediaImage = BC000X10_n411MediaImage[0];
         }
         Gx_mode = sMode83;
      }

      protected void ScanKeyEnd0X83( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0X83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X83( )
      {
      }

      protected void send_integrity_lvl_hashes0X83( )
      {
      }

      protected void AddRow0X83( )
      {
         VarsToRow83( bcTrn_Media) ;
      }

      protected void ReadRow0X83( )
      {
         RowToVars83( bcTrn_Media, 1) ;
      }

      protected void InitializeNonKey0X83( )
      {
         A410MediaName = "";
         A411MediaImage = "";
         n411MediaImage = false;
         A40000MediaImage_GXI = "";
         n40000MediaImage_GXI = false;
         A413MediaSize = 0;
         A414MediaType = "";
         A412MediaUrl = "";
         Z410MediaName = "";
         Z413MediaSize = 0;
         Z414MediaType = "";
         Z412MediaUrl = "";
      }

      protected void InitAll0X83( )
      {
         A409MediaId = Guid.NewGuid( );
         InitializeNonKey0X83( ) ;
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

      public void VarsToRow83( SdtTrn_Media obj83 )
      {
         obj83.gxTpr_Mode = Gx_mode;
         obj83.gxTpr_Medianame = A410MediaName;
         obj83.gxTpr_Mediaimage = A411MediaImage;
         obj83.gxTpr_Mediaimage_gxi = A40000MediaImage_GXI;
         obj83.gxTpr_Mediasize = A413MediaSize;
         obj83.gxTpr_Mediatype = A414MediaType;
         obj83.gxTpr_Mediaurl = A412MediaUrl;
         obj83.gxTpr_Mediaid = A409MediaId;
         obj83.gxTpr_Mediaid_Z = Z409MediaId;
         obj83.gxTpr_Medianame_Z = Z410MediaName;
         obj83.gxTpr_Mediasize_Z = Z413MediaSize;
         obj83.gxTpr_Mediatype_Z = Z414MediaType;
         obj83.gxTpr_Mediaurl_Z = Z412MediaUrl;
         obj83.gxTpr_Mediaimage_gxi_Z = Z40000MediaImage_GXI;
         obj83.gxTpr_Mediaimage_N = (short)(Convert.ToInt16(n411MediaImage));
         obj83.gxTpr_Mediaimage_gxi_N = (short)(Convert.ToInt16(n40000MediaImage_GXI));
         obj83.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow83( SdtTrn_Media obj83 )
      {
         obj83.gxTpr_Mediaid = A409MediaId;
         return  ;
      }

      public void RowToVars83( SdtTrn_Media obj83 ,
                               int forceLoad )
      {
         Gx_mode = obj83.gxTpr_Mode;
         A410MediaName = obj83.gxTpr_Medianame;
         A411MediaImage = obj83.gxTpr_Mediaimage;
         n411MediaImage = false;
         A40000MediaImage_GXI = obj83.gxTpr_Mediaimage_gxi;
         n40000MediaImage_GXI = false;
         A413MediaSize = obj83.gxTpr_Mediasize;
         A414MediaType = obj83.gxTpr_Mediatype;
         A412MediaUrl = obj83.gxTpr_Mediaurl;
         A409MediaId = obj83.gxTpr_Mediaid;
         Z409MediaId = obj83.gxTpr_Mediaid_Z;
         Z410MediaName = obj83.gxTpr_Medianame_Z;
         Z413MediaSize = obj83.gxTpr_Mediasize_Z;
         Z414MediaType = obj83.gxTpr_Mediatype_Z;
         Z412MediaUrl = obj83.gxTpr_Mediaurl_Z;
         Z40000MediaImage_GXI = obj83.gxTpr_Mediaimage_gxi_Z;
         n411MediaImage = (bool)(Convert.ToBoolean(obj83.gxTpr_Mediaimage_N));
         n40000MediaImage_GXI = (bool)(Convert.ToBoolean(obj83.gxTpr_Mediaimage_gxi_N));
         Gx_mode = obj83.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A409MediaId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0X83( ) ;
         ScanKeyStart0X83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z409MediaId = A409MediaId;
         }
         ZM0X83( -4) ;
         OnLoadActions0X83( ) ;
         AddRow0X83( ) ;
         ScanKeyEnd0X83( ) ;
         if ( RcdFound83 == 0 )
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
         RowToVars83( bcTrn_Media, 0) ;
         ScanKeyStart0X83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z409MediaId = A409MediaId;
         }
         ZM0X83( -4) ;
         OnLoadActions0X83( ) ;
         AddRow0X83( ) ;
         ScanKeyEnd0X83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0X83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0X83( ) ;
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A409MediaId != Z409MediaId )
               {
                  A409MediaId = Z409MediaId;
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
                  Update0X83( ) ;
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
                  if ( A409MediaId != Z409MediaId )
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
                        Insert0X83( ) ;
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
                        Insert0X83( ) ;
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
         RowToVars83( bcTrn_Media, 1) ;
         SaveImpl( ) ;
         VarsToRow83( bcTrn_Media) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars83( bcTrn_Media, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X83( ) ;
         AfterTrn( ) ;
         VarsToRow83( bcTrn_Media) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow83( bcTrn_Media) ;
         }
         else
         {
            SdtTrn_Media auxBC = new SdtTrn_Media(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A409MediaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Media);
               auxBC.Save();
               bcTrn_Media.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars83( bcTrn_Media, 1) ;
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
         RowToVars83( bcTrn_Media, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X83( ) ;
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
               VarsToRow83( bcTrn_Media) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow83( bcTrn_Media) ;
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
         RowToVars83( bcTrn_Media, 0) ;
         GetKey0X83( ) ;
         if ( RcdFound83 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A409MediaId != Z409MediaId )
            {
               A409MediaId = Z409MediaId;
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
            if ( A409MediaId != Z409MediaId )
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
         context.RollbackDataStores("trn_media_bc",pr_default);
         VarsToRow83( bcTrn_Media) ;
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
         Gx_mode = bcTrn_Media.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Media.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Media )
         {
            bcTrn_Media = (SdtTrn_Media)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Media.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Media.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow83( bcTrn_Media) ;
            }
            else
            {
               RowToVars83( bcTrn_Media, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Media.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Media.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars83( bcTrn_Media, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Media Trn_Media_BC
      {
         get {
            return bcTrn_Media ;
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
            return "trn_media_Execute" ;
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
         Z409MediaId = Guid.Empty;
         A409MediaId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z410MediaName = "";
         A410MediaName = "";
         Z414MediaType = "";
         A414MediaType = "";
         Z412MediaUrl = "";
         A412MediaUrl = "";
         Z411MediaImage = "";
         A411MediaImage = "";
         Z40000MediaImage_GXI = "";
         A40000MediaImage_GXI = "";
         BC000X4_A409MediaId = new Guid[] {Guid.Empty} ;
         BC000X4_A410MediaName = new string[] {""} ;
         BC000X4_A40000MediaImage_GXI = new string[] {""} ;
         BC000X4_n40000MediaImage_GXI = new bool[] {false} ;
         BC000X4_A413MediaSize = new int[1] ;
         BC000X4_A414MediaType = new string[] {""} ;
         BC000X4_A412MediaUrl = new string[] {""} ;
         BC000X4_A411MediaImage = new string[] {""} ;
         BC000X4_n411MediaImage = new bool[] {false} ;
         BC000X5_A409MediaId = new Guid[] {Guid.Empty} ;
         BC000X3_A409MediaId = new Guid[] {Guid.Empty} ;
         BC000X3_A410MediaName = new string[] {""} ;
         BC000X3_A40000MediaImage_GXI = new string[] {""} ;
         BC000X3_n40000MediaImage_GXI = new bool[] {false} ;
         BC000X3_A413MediaSize = new int[1] ;
         BC000X3_A414MediaType = new string[] {""} ;
         BC000X3_A412MediaUrl = new string[] {""} ;
         BC000X3_A411MediaImage = new string[] {""} ;
         BC000X3_n411MediaImage = new bool[] {false} ;
         sMode83 = "";
         BC000X2_A409MediaId = new Guid[] {Guid.Empty} ;
         BC000X2_A410MediaName = new string[] {""} ;
         BC000X2_A40000MediaImage_GXI = new string[] {""} ;
         BC000X2_n40000MediaImage_GXI = new bool[] {false} ;
         BC000X2_A413MediaSize = new int[1] ;
         BC000X2_A414MediaType = new string[] {""} ;
         BC000X2_A412MediaUrl = new string[] {""} ;
         BC000X2_A411MediaImage = new string[] {""} ;
         BC000X2_n411MediaImage = new bool[] {false} ;
         BC000X10_A409MediaId = new Guid[] {Guid.Empty} ;
         BC000X10_A410MediaName = new string[] {""} ;
         BC000X10_A40000MediaImage_GXI = new string[] {""} ;
         BC000X10_n40000MediaImage_GXI = new bool[] {false} ;
         BC000X10_A413MediaSize = new int[1] ;
         BC000X10_A414MediaType = new string[] {""} ;
         BC000X10_A412MediaUrl = new string[] {""} ;
         BC000X10_A411MediaImage = new string[] {""} ;
         BC000X10_n411MediaImage = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__default(),
            new Object[][] {
                new Object[] {
               BC000X2_A409MediaId, BC000X2_A410MediaName, BC000X2_A40000MediaImage_GXI, BC000X2_n40000MediaImage_GXI, BC000X2_A413MediaSize, BC000X2_A414MediaType, BC000X2_A412MediaUrl, BC000X2_A411MediaImage, BC000X2_n411MediaImage
               }
               , new Object[] {
               BC000X3_A409MediaId, BC000X3_A410MediaName, BC000X3_A40000MediaImage_GXI, BC000X3_n40000MediaImage_GXI, BC000X3_A413MediaSize, BC000X3_A414MediaType, BC000X3_A412MediaUrl, BC000X3_A411MediaImage, BC000X3_n411MediaImage
               }
               , new Object[] {
               BC000X4_A409MediaId, BC000X4_A410MediaName, BC000X4_A40000MediaImage_GXI, BC000X4_n40000MediaImage_GXI, BC000X4_A413MediaSize, BC000X4_A414MediaType, BC000X4_A412MediaUrl, BC000X4_A411MediaImage, BC000X4_n411MediaImage
               }
               , new Object[] {
               BC000X5_A409MediaId
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
               BC000X10_A409MediaId, BC000X10_A410MediaName, BC000X10_A40000MediaImage_GXI, BC000X10_n40000MediaImage_GXI, BC000X10_A413MediaSize, BC000X10_A414MediaType, BC000X10_A412MediaUrl, BC000X10_A411MediaImage, BC000X10_n411MediaImage
               }
            }
         );
         Z409MediaId = Guid.NewGuid( );
         A409MediaId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound83 ;
      private int trnEnded ;
      private int Z413MediaSize ;
      private int A413MediaSize ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z414MediaType ;
      private string A414MediaType ;
      private string sMode83 ;
      private bool returnInSub ;
      private bool n40000MediaImage_GXI ;
      private bool n411MediaImage ;
      private string Z410MediaName ;
      private string A410MediaName ;
      private string Z412MediaUrl ;
      private string A412MediaUrl ;
      private string Z40000MediaImage_GXI ;
      private string A40000MediaImage_GXI ;
      private string Z411MediaImage ;
      private string A411MediaImage ;
      private Guid Z409MediaId ;
      private Guid A409MediaId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000X4_A409MediaId ;
      private string[] BC000X4_A410MediaName ;
      private string[] BC000X4_A40000MediaImage_GXI ;
      private bool[] BC000X4_n40000MediaImage_GXI ;
      private int[] BC000X4_A413MediaSize ;
      private string[] BC000X4_A414MediaType ;
      private string[] BC000X4_A412MediaUrl ;
      private string[] BC000X4_A411MediaImage ;
      private bool[] BC000X4_n411MediaImage ;
      private Guid[] BC000X5_A409MediaId ;
      private Guid[] BC000X3_A409MediaId ;
      private string[] BC000X3_A410MediaName ;
      private string[] BC000X3_A40000MediaImage_GXI ;
      private bool[] BC000X3_n40000MediaImage_GXI ;
      private int[] BC000X3_A413MediaSize ;
      private string[] BC000X3_A414MediaType ;
      private string[] BC000X3_A412MediaUrl ;
      private string[] BC000X3_A411MediaImage ;
      private bool[] BC000X3_n411MediaImage ;
      private Guid[] BC000X2_A409MediaId ;
      private string[] BC000X2_A410MediaName ;
      private string[] BC000X2_A40000MediaImage_GXI ;
      private bool[] BC000X2_n40000MediaImage_GXI ;
      private int[] BC000X2_A413MediaSize ;
      private string[] BC000X2_A414MediaType ;
      private string[] BC000X2_A412MediaUrl ;
      private string[] BC000X2_A411MediaImage ;
      private bool[] BC000X2_n411MediaImage ;
      private Guid[] BC000X10_A409MediaId ;
      private string[] BC000X10_A410MediaName ;
      private string[] BC000X10_A40000MediaImage_GXI ;
      private bool[] BC000X10_n40000MediaImage_GXI ;
      private int[] BC000X10_A413MediaSize ;
      private string[] BC000X10_A414MediaType ;
      private string[] BC000X10_A412MediaUrl ;
      private string[] BC000X10_A411MediaImage ;
      private bool[] BC000X10_n411MediaImage ;
      private SdtTrn_Media bcTrn_Media ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_media_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_media_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_media_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000X2;
       prmBC000X2 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X3;
       prmBC000X3 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X4;
       prmBC000X4 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X5;
       prmBC000X5 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X6;
       prmBC000X6 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0)
       };
       Object[] prmBC000X7;
       prmBC000X7 = new Object[] {
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0) ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X8;
       prmBC000X8 = new Object[] {
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X9;
       prmBC000X9 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X10;
       prmBC000X10 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000X2", "SELECT MediaId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaUrl, MediaImage FROM Trn_Media WHERE MediaId = :MediaId  FOR UPDATE OF Trn_Media",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X3", "SELECT MediaId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaUrl, MediaImage FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X4", "SELECT TM1.MediaId, TM1.MediaName, TM1.MediaImage_GXI, TM1.MediaSize, TM1.MediaType, TM1.MediaUrl, TM1.MediaImage FROM Trn_Media TM1 WHERE TM1.MediaId = :MediaId ORDER BY TM1.MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X5", "SELECT MediaId FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X6", "SAVEPOINT gxupdate;INSERT INTO Trn_Media(MediaId, MediaName, MediaImage, MediaImage_GXI, MediaSize, MediaType, MediaUrl) VALUES(:MediaId, :MediaName, :MediaImage, :MediaImage_GXI, :MediaSize, :MediaType, :MediaUrl);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000X6)
          ,new CursorDef("BC000X7", "SAVEPOINT gxupdate;UPDATE Trn_Media SET MediaName=:MediaName, MediaSize=:MediaSize, MediaType=:MediaType, MediaUrl=:MediaUrl  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X7)
          ,new CursorDef("BC000X8", "SAVEPOINT gxupdate;UPDATE Trn_Media SET MediaImage=:MediaImage, MediaImage_GXI=:MediaImage_GXI  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X8)
          ,new CursorDef("BC000X9", "SAVEPOINT gxupdate;DELETE FROM Trn_Media  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X9)
          ,new CursorDef("BC000X10", "SELECT TM1.MediaId, TM1.MediaName, TM1.MediaImage_GXI, TM1.MediaSize, TM1.MediaType, TM1.MediaUrl, TM1.MediaImage FROM Trn_Media TM1 WHERE TM1.MediaId = :MediaId ORDER BY TM1.MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
    }
 }

}

}
