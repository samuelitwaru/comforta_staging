using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_getuserdashboarditems : GXProcedure
   {
      public prc_getuserdashboarditems( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserdashboarditems( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems )
      {
         this.AV10FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_FilteredDashboardItems=this.AV10FilteredDashboardItems;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_FilteredDashboardItems);
         return AV10FilteredDashboardItems ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems )
      {
         this.AV10FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_FilteredDashboardItems=this.AV10FilteredDashboardItems;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV11GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV11GAMUser = GXt_SdtGAMUser1;
         if ( AV11GAMUser.checkrole("Receptionist") )
         {
            AV12UserRoleName = "Receptionist";
         }
         else if ( AV11GAMUser.checkrole("Organisation Manager") )
         {
            AV12UserRoleName = "Organisation Manager";
         }
         else if ( AV11GAMUser.checkrole("Comforta Admin") )
         {
            AV12UserRoleName = "Comforta Admin";
         }
         else
         {
            AV12UserRoleName = "Resident";
         }
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 = AV9DashboardItems;
         new dp_getdashboarditems(context ).execute( out  GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2) ;
         AV9DashboardItems = GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV9DashboardItems.Count )
         {
            AV8DashboardItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV9DashboardItems.Item(AV13GXV1));
            if ( StringUtil.StrCmp(AV12UserRoleName, AV8DashboardItem.gxTpr_Rolename) == 0 )
            {
               AV10FilteredDashboardItems.Add(AV8DashboardItem, 0);
            }
            else
            {
               if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV8DashboardItem.gxTpr_Rolename)) || ( StringUtil.StrCmp(AV8DashboardItem.gxTpr_Rolename, "All") == 0 ) ) && ( StringUtil.StrCmp(AV12UserRoleName, "Comforta Admin") != 0 ) )
               {
                  AV10FilteredDashboardItems.Add(AV8DashboardItem, 0);
               }
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV12UserRoleName = "";
         AV9DashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         AV8DashboardItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV12UserRoleName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV10FilteredDashboardItems ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV9DashboardItems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV8DashboardItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems ;
   }

}
