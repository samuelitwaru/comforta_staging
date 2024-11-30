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
   public class dp_getdashboarditems : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public dp_getdashboarditems( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_getdashboarditems( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Locations", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-map-marker-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_locationww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "d085396f-788e-4174-bb1c-d2d0832ea599", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Organisation Locations.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Receptionists", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-address-card";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("wp_locationreceptionists.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "8b339ea3-0806-4fdc-b87f-6f4b66cf669e", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Receptionisits/Location Managers";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Organisations", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fal fa-sitemap";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_organisationww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Admin";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Organisations";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Suppliers (AGB)", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-ambulance";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_supplieragbww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Suppliers (AGB)";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Suppliers (General)", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-shipping-fast";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_suppliergenww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Suppliers (Generic)";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Products & Services", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fab fa-product-hunt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_productserviceww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Products and Services";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Residents", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-users";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("wp_locationresidents.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Residents";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Agenda", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-calendar-days";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("wp_calendaragenda.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Agenda";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Customization", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-eye-dropper";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Organisation Manager";
         GXt_char1 = "";
         new prc_organizationsettingtrnmode(context ).execute( out  GXt_char1) ;
         GXt_guid2 = Guid.Empty;
         new prc_organizationsettingid(context ).execute( out  GXt_guid2) ;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_organisationsetting.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(GXt_char1)) + "," + GXUtil.UrlEncode(GXt_guid2.ToString());
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Customization";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Page Templates", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Admin";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("trn_templateww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Page Templates";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Application Design", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-mobile-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("wp_applicationdesign.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Application Design";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Contacts", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-phone-square";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Financial Partners", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file-invoice-dollar";
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Financial Partners";
         Gxm1homemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Payments", "");
         Gxm1homemodulessdt.gxTpr_Optiontype = 3;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 65;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Feedback", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-comments";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Notifications", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-bell";
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("wp_usernotificationsboard.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Chat", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fab fa-whatsapp";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = context.GetMessage( "My Profile", "");
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-user-circle";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
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
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         GXt_char1 = "";
         GXt_guid2 = Guid.Empty;
         GXKey = "";
         GXEncryptionTmp = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private Guid GXt_guid2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem Gxm1homemodulessdt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol ;
   }

}
