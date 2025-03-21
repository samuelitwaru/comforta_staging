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
   public class atrn_theme_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_theme_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
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

      public atrn_theme_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_theme_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_Theme> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "05b80e4f-effe-4d46-afbd-7c72da5a4afc", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Minimalistic", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Inter", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 1;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#554940";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#7f3e3a";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c8653e";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonBGColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#b3783e";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#d99e80";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c8ad94";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#668d63";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#7a8f92";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#a2ad9f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c6c6c6";
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Reception", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.667\" height=\"29.667\" viewBox=\"0 0 29.667 29.667\"><path id=\"Path_2271\" data-name=\"Path 2271\" d=\"M14.833,0a3.56,3.56,0,1,0,3.56,3.56A3.564,3.564,0,0,0,14.833,0Zm-1.78,7.713A4.158,4.158,0,0,0,8.9,11.867v1.187H20.767V11.867a4.158,4.158,0,0,0-4.153-4.153Zm11.867,3.56v.593h1.187v-.593Zm.593.593A2.98,2.98,0,0,0,22.6,14.24H.593A.594.594,0,0,0,0,14.833v2.373a.593.593,0,0,0,.593.593h28.48a.592.592,0,0,0,.593-.593V14.833a.593.593,0,0,0-.593-.593h-.649A2.98,2.98,0,0,0,25.513,11.867Zm0,1.187a1.782,1.782,0,0,1,1.669,1.187H23.845A1.782,1.782,0,0,1,25.513,13.053ZM1.187,18.987V29.073a.593.593,0,0,0,.593.593H27.887a.592.592,0,0,0,.593-.593V18.987Z\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Calendar", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"43.8\" height=\"48.667\" viewBox=\"0 0 43.8 48.667\">   <path id=\"Agenda\" d=\"M10.3,1V5.867H7.867A4.881,4.881,0,0,0,3,10.733V44.8a4.881,4.881,0,0,0,4.867,4.867H41.933A4.881,4.881,0,0,0,46.8,44.8V10.733a4.881,4.881,0,0,0-4.867-4.867H39.5V1H34.633V5.867H15.167V1ZM7.867,10.733H41.933V15.6H7.867Zm0,9.733H41.933V44.8H7.867ZM27.333,30.2v9.733h9.733V30.2Z\" transform=\"translate(-3 -1)\" fill=\"#7c8791\"></path> </svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Door", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"35.85\" height=\"29.454\" viewBox=\"0 0 35.85 29.454\">  <path id=\"Group_614-converted\" data-name=\"Group 614-converted\" d=\"M10.553.042A4.489,4.489,0,0,0,7.087,2.779c-.339.854-.326.343-.328,13.021l0,11.7H.675l-.2.135a.931.931,0,0,0-.461.743.971.971,0,0,0,.519.958l.26.137H35.079l.26-.137a.971.971,0,0,0,.519-.958.931.931,0,0,0-.461-.743l-.2-.135H29.119l0-11.7c0-12.678.011-12.167-.328-13.021A4.562,4.562,0,0,0,25.86.142c-.337-.1-.811-.109-7.743-.117-4.061,0-7.465,0-7.564.017M25.382,2.11a2.5,2.5,0,0,1,1.487,1.3l.187.389.015,11.853L27.087,27.5H8.788L8.8,15.65,8.819,3.8l.187-.389a2.542,2.542,0,0,1,1.458-1.293c.315-.1,14.585-.11,14.918,0M20.9,13.843a.943.943,0,0,0-.551,1.029.985.985,0,0,0,1.659.6.861.861,0,0,0,.3-.753.981.981,0,0,0-.431-.8,1.14,1.14,0,0,0-.974-.069\" transform=\"translate(-0.013 -0.023)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Intercom", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.015\" height=\"28.991\" viewBox=\"0 0 29.015 28.991\">  <path id=\"Group_615-converted\" data-name=\"Group 615-converted\" d=\"M2.423.054a3.057,3.057,0,0,0-2.35,2.29c-.107.51-.107,23.8,0,24.312a3.049,3.049,0,0,0,2.271,2.271c.51.107,23.8.107,24.312,0a3.049,3.049,0,0,0,2.271-2.271c.107-.51.107-23.8,0-24.312A3.143,3.143,0,0,0,26.873.113c-.255-.085-.76-.089-12.228-.1C7.753.014,2.572.029,2.423.054m24.092,2.1a1.309,1.309,0,0,1,.312.3l.119.173V26.373l-.117.17a1.069,1.069,0,0,1-.618.43c-.242.057-23.18.057-23.422,0a1.063,1.063,0,0,1-.634-.458l-.125-.193V2.678l.127-.2a1.312,1.312,0,0,1,.324-.324l.2-.127H26.322l.193.125M11.379,5.505a1.036,1.036,0,0,0-.55.692c-.07.328-.07,16.278,0,16.606a1.033,1.033,0,0,0,1.336.732,1.219,1.219,0,0,0,.552-.553c.086-.185.089-.51.09-8.471,0-7.377-.007-8.3-.074-8.459a1.015,1.015,0,0,0-1.354-.547M16.8,5.494a1.174,1.174,0,0,0-.513.524c-.086.185-.089.516-.089,8.482s0,8.3.089,8.482a1.219,1.219,0,0,0,.552.553,1.033,1.033,0,0,0,1.336-.732c.07-.328.07-16.278,0-16.606a1.036,1.036,0,0,0-.55-.692,1.106,1.106,0,0,0-.825-.011M5.969,9.554a.972.972,0,0,0-.464.475c-.085.183-.09.415-.091,4.46a33.312,33.312,0,0,0,.074,4.446.992.992,0,0,0,1.736.165l.147-.21V10.11L7.224,9.9a.914.914,0,0,0-.82-.425,1.113,1.113,0,0,0-.435.078m16.192,0a1.01,1.01,0,0,0-.484.52,34.051,34.051,0,0,0-.061,4.506l.013,4.31.147.21a.992.992,0,0,0,1.736-.165,33.246,33.246,0,0,0,.075-4.435c0-4.607.008-4.445-.256-4.729a1.106,1.106,0,0,0-1.17-.217\" transform=\"translate(0.007 -0.017)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Key", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.487\" height=\"29.408\" viewBox=\"0 0 29.487 29.408\">  <path id=\"Group_612-converted\" data-name=\"Group 612-converted\" d=\"M27.237.518c-.082.038-3.07,2.979-6.64,6.534L14.1,13.516l-.4-.243A9.248,9.248,0,0,0,10.1,12,12.838,12.838,0,0,0,7.828,12,9.005,9.005,0,0,0,4.29,28.591a9.765,9.765,0,0,0,2.97,1.175,8.457,8.457,0,0,0,1.753.088,6.922,6.922,0,0,0,1.843-.114,9.058,9.058,0,0,0,6.7-11.652,9.271,9.271,0,0,0-1.607-2.9l-.29-.347,2.072-2.074L19.8,10.694l1.446,1.436A9.348,9.348,0,0,0,23,13.719a2.446,2.446,0,0,0,2.53-.233c.447-.337,3.4-3.329,3.6-3.646a2.489,2.489,0,0,0,0-2.555c-.085-.136-.774-.87-1.532-1.631L26.226,4.27l1.111-1.11c1.245-1.243,1.331-1.365,1.3-1.825a.908.908,0,0,0-.951-.889,1.357,1.357,0,0,0-.447.072M26.148,7.06c1.276,1.277,1.33,1.339,1.326,1.514s-.1.278-1.6,1.78c-1.56,1.56-1.6,1.6-1.793,1.6s-.233-.037-1.531-1.333L21.212,9.286l1.777-1.779c.978-.978,1.789-1.778,1.8-1.778s.624.6,1.356,1.331M10.231,14.047a7.206,7.206,0,0,1,4.583,2.967,6.875,6.875,0,0,1,1.142,4.519A6.984,6.984,0,0,1,2.919,24.372,7,7,0,0,1,8.025,14a8.766,8.766,0,0,1,2.206.051\" transform=\"translate(0 -0.446)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Monitor", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"31.987\" height=\"29.496\" viewBox=\"0 0 31.987 29.496\">  <path id=\"Group_613-converted\" data-name=\"Group 613-converted\" d=\"M2.315.079A3.092,3.092,0,0,0,.348,1.606C-.025,2.312,0,1.66.012,11.9l.015,9.242.142.367a3.136,3.136,0,0,0,2.018,1.879c.277.094.628.1,6.546.115l6.254.015v4H12.372c-2.886,0-2.828-.006-3.13.338A1,1,0,0,0,9.56,29.38l.234.113H22.206l.234-.113a1,1,0,0,0,.318-1.522c-.3-.344-.244-.338-3.13-.338H17.013v-4l6.254-.015c5.918-.015,6.269-.021,6.546-.115a3.136,3.136,0,0,0,2.018-1.879l.142-.367.015-9.242c.012-8.15,0-9.282-.068-9.594A3.058,3.058,0,0,0,29.66.077c-.511-.109-26.846-.106-27.345,0M29.435,2.1a1.336,1.336,0,0,1,.512.577c.016.065.023,4.189.014,9.163l-.014,9.044-.154.2a1.18,1.18,0,0,1-.373.3c-.213.1-.642.1-13.42.1s-13.207,0-13.42-.1a1.18,1.18,0,0,1-.373-.3l-.154-.2-.014-9.044c-.009-4.974,0-9.1.013-9.16a1.261,1.261,0,0,1,.479-.558c.157-.1.6-.1,13.458-.1,11.507,0,13.316.01,13.446.077\" transform=\"translate(-0.005 0.003)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Bed", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"35.756\" height=\"28.937\" viewBox=\"0 0 35.756 28.937\">  <path id=\"Group_611-converted\" data-name=\"Group 611-converted\" d=\"M7.18.037,6.733.125a4.46,4.46,0,0,0-3.06,2.663C3.407,3.5,3.4,3.664,3.4,7.024v3.2l-.355.108A4.072,4.072,0,0,0,1.28,11.463,4.1,4.1,0,0,0,.17,13.257l-.14.417L.014,20.937,0,28.2l.125.258a.857.857,0,0,0,.92.5c.386,0,.411-.01.627-.225a1.265,1.265,0,0,0,.29-.462,10.158,10.158,0,0,0,.067-1.444V25.621h31.7v1.206a10.158,10.158,0,0,0,.067,1.444,1.265,1.265,0,0,0,.29.462c.216.215.241.224.627.225a.856.856,0,0,0,.92-.5l.125-.258-.017-7.262-.016-7.263-.14-.417a4.1,4.1,0,0,0-1.11-1.794,4.072,4.072,0,0,0-1.761-1.126l-.355-.108v-3.2c0-2.05-.023-3.319-.064-3.521A4.5,4.5,0,0,0,29.157.139c-.328-.1-.971-.107-11.1-.116C12.139.017,7.245.024,7.18.037m9.682,6.041v4.051H5.362V7.254c0-1.689.026-3.031.062-3.254A2.4,2.4,0,0,1,7.048,2.112c.2-.062,1.253-.079,5.033-.082l4.781,0V6.078M28.97,2.215a2.45,2.45,0,0,1,1.354,1.779c.037.231.063,1.541.063,3.26v2.875h-11.5V2.023l4.871.016,4.871.017.34.159m3.1,10.026a2.481,2.481,0,0,1,1.57,1.567,43.581,43.581,0,0,1,.087,5.065v4.782H2.026V18.873a44.865,44.865,0,0,1,.086-5.06,2.51,2.51,0,0,1,1.539-1.567c.389-.122,28.013-.127,28.416-.005\" transform=\"translate(0.003 -0.021)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "FirstAid", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32.945\" height=\"28.939\" viewBox=\"0 0 32.945 28.939\">  <path id=\"Group_617-converted\" data-name=\"Group 617-converted\" d=\"M12.45.059a3.807,3.807,0,0,0-2.109,1.152c-.976.976-1.211,1.7-1.211,3.743V5.995h-3.2c-3.526,0-3.644.01-4.281.331a3.785,3.785,0,0,0-1.2,1.1,3.91,3.91,0,0,0-.29.583l-.123.325V26.593l.124.358a3.166,3.166,0,0,0,1.882,1.882l.359.124H30.608l.358-.124a3.166,3.166,0,0,0,1.882-1.882l.125-.358V8.332l-.124-.325a3.91,3.91,0,0,0-.29-.583,3.785,3.785,0,0,0-1.2-1.1C30.714,6,30.622,6,26.826,6H23.375V5.019a6.664,6.664,0,0,0-.264-2.345,4.147,4.147,0,0,0-2.568-2.5L20.1.028,16.418.019c-2.027,0-3.813.013-3.968.04M19.6,2.036a2.043,2.043,0,0,1,1.561,1.141c.155.314.156.323.174,1.567l.018,1.251H11.158l.017-1.251c.017-1.213.022-1.261.16-1.554a2.086,2.086,0,0,1,1.524-1.151c.448-.065,6.285-.068,6.737,0M6.105,17.518v9.487H4.524a16.178,16.178,0,0,1-1.786-.057,1.138,1.138,0,0,1-.636-.513c-.088-.16-.1-.766-.111-8.642-.009-4.659,0-8.624.018-8.812a1.019,1.019,0,0,1,.462-.826c.183-.123.207-.125,1.91-.125H6.105v9.488m18.315,0v9.487H8.085V8.03H24.42v9.488m6.109-9.363a1.019,1.019,0,0,1,.462.826c.019.188.027,4.153.018,8.812-.015,7.876-.023,8.482-.111,8.642a1.138,1.138,0,0,1-.636.513A20.066,20.066,0,0,1,28.229,27H26.4V8.03h1.972c1.96,0,1.973,0,2.157.125m-14.771,5.7c-.467.288-.523.485-.523,1.821v1.1H14.1c-1.223,0-1.371.03-1.658.338a1,1,0,0,0,.028,1.333c.265.283.4.309,1.631.309h1.129v1.114a3.435,3.435,0,0,0,.1,1.336.99.99,0,0,0,1.676.245c.219-.26.255-.494.256-1.636V18.755h1.142c1.285,0,1.375-.022,1.689-.41.148-.183.167-.245.167-.576a.722.722,0,0,0-.155-.573c-.3-.386-.436-.421-1.713-.421H17.27V15.716a9.439,9.439,0,0,0-.057-1.263,1.1,1.1,0,0,0-.5-.622,1.313,1.313,0,0,0-.958.021\" transform=\"translate(-0.028 -0.018)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Food", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.485\" height=\"29.18\" viewBox=\"0 0 26.485 29.18\">  <path id=\"Group_616-converted\" data-name=\"Group 616-converted\" d=\"M.664.058A1.2,1.2,0,0,0,.047.694C.011.827,0,2.331.01,6.036l.012,5.156.122.39a4.934,4.934,0,0,0,.216.573,4.027,4.027,0,0,0,1.992,1.837,5.043,5.043,0,0,0,2.091.268H5.43l0,7.053c0,7.625-.011,7.213.239,7.54a.871.871,0,0,0,.79.33A.709.709,0,0,0,7,29.04a.957.957,0,0,0,.325-.363l.112-.22.012-7.094.012-7.094,1.158-.019a4.491,4.491,0,0,0,1.556-.139,3.791,3.791,0,0,0,2.569-2.566l.124-.4L12.882,6a43.906,43.906,0,0,0-.06-5.335A1,1,0,0,0,10.967.6c-.081.162-.085.374-.106,5.29l-.022,5.121-.13.256a1.968,1.968,0,0,1-.792.8,3.662,3.662,0,0,1-1.628.2H7.461V6.634C7.46,2.946,7.444.925,7.414.8a.984.984,0,0,0-.47-.649.8.8,0,0,0-.5-.124.748.748,0,0,0-.507.134A1.143,1.143,0,0,0,5.586.5L5.453.722,5.441,6.5l-.012,5.781-1-.02c-1.136-.023-1.316-.059-1.682-.334a1.958,1.958,0,0,1-.635-.8l-.1-.243-.022-5.1C1.962.08,1.993.573,1.64.253A.977.977,0,0,0,.664.058m24.3-.029a7.71,7.71,0,0,0-2.984.816,7.82,7.82,0,0,0-4.234,6.02c-.036.283-.047,1.763-.037,5.122l.014,4.724.146.419a3.514,3.514,0,0,0,.819,1.357,3.826,3.826,0,0,0,1.714,1.079,8.014,8.014,0,0,0,2.211.114L24.5,19.7v4.369c0,4.82-.016,4.538.278,4.845a1.317,1.317,0,0,0,.261.21,1.677,1.677,0,0,0,.887,0,1.138,1.138,0,0,0,.514-.589c.065-.236.066-27.6,0-27.841A1.029,1.029,0,0,0,25.894.1a1.652,1.652,0,0,0-.927-.075M24.5,9.912V17.7H22.92c-.886,0-1.688-.02-1.821-.045a1.734,1.734,0,0,1-1.363-1.364c-.063-.329-.061-8.562,0-9.133a5.781,5.781,0,0,1,4.153-4.929,2.926,2.926,0,0,1,.491-.111l.121,0V9.912\" transform=\"translate(-0.007 -0.003)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wellbeing", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"31.826\" height=\"28.834\" viewBox=\"0 0 31.826 28.834\">  <path id=\"Path_1194-converted\" data-name=\"Path 1194-converted\" d=\"M8.555.032A9.177,9.177,0,0,0,2.711,2.711,9.3,9.3,0,0,0,.1,7.864a12.166,12.166,0,0,0,.028,2.843,11.963,11.963,0,0,0,3.169,5.9C3.554,16.9,6.4,19.773,9.63,23l5.862,5.858h.9l5.785-5.779c5.513-5.508,6.534-6.562,7.289-7.532a11.52,11.52,0,0,0,2.265-4.7,6.414,6.414,0,0,0,.123-1.567,7.444,7.444,0,0,0-.265-2.312A9.2,9.2,0,0,0,24.922.3,8.15,8.15,0,0,0,22.557.032a8.887,8.887,0,0,0-6.155,2.2l-.461.376-.464-.381A11.1,11.1,0,0,0,12.755.585,10.431,10.431,0,0,0,10.947.131a16.741,16.741,0,0,0-2.392-.1M10.527,2.1a6.857,6.857,0,0,1,2.906,1.1,10.714,10.714,0,0,1,1.455,1.175c.923.842,1.184.842,2.107,0a7.5,7.5,0,0,1,4.393-2.277,10.544,10.544,0,0,1,2.737.06,7.29,7.29,0,0,1,5.606,5.606,8.462,8.462,0,0,1,.055,2.5A9.038,9.038,0,0,1,27.8,14.419c-.748.941-1.543,1.762-6.648,6.863L15.94,26.489,10.4,20.937c-3.049-3.055-5.752-5.805-6.007-6.111a10.011,10.011,0,0,1-2.247-4.251,9.448,9.448,0,0,1,0-2.764A7.286,7.286,0,0,1,7.354,2.252,8.8,8.8,0,0,1,10.527,2.1\" transform=\"translate(-0.027 -0.02)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Curtain", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"31\" height=\"27.5\" viewBox=\"0 0 31 27.5\">  <g id=\"Screenshot-2024-10-31-233134\" transform=\"translate(-104.601 174)\">    <path id=\"Path_1198\" data-name=\"Path 1198\" d=\"M104.8-173.447c-.43.781-.132,1.4.628,1.4.595,0,.628.456.694,12.757l.1,12.79h8.924l.1-1.627a16.583,16.583,0,0,0-1.421-7.16l-.76-1.725.826-.423c1.454-.749,4.032-3.84,5.156-6.151l1.091-2.246.958,2.148c.958,2.18,3.669,5.435,5.255,6.249l.826.456-.661,1.237a18.223,18.223,0,0,0-1.553,7.42l.1,1.822h8.924l.1-12.79c.066-12.3.1-12.757.694-12.757.76,0,1.058-.618.628-1.4-.264-.521-1.322-.553-15.3-.553S105.064-173.967,104.8-173.447Zm14.013,3.027c-.562,4.133-2.875,8.82-5.189,10.414-.992.716-1.058.716-.793.13.132-.325.463-1.53.727-2.669.4-1.595.43-2.115.1-2.506-.992-1.172-1.619-.456-2.28,2.506-.43,1.985-2.115,4.817-2.875,4.817-.4,0-.463-1.2-.463-6.932a57.327,57.327,0,0,1,.231-7.16,34.848,34.848,0,0,1,5.486-.228h5.288Zm13.286,5.6c.066,5.956,0,7.095-.4,7.095-.76,0-2.347-2.7-2.809-4.751-.231-1.074-.5-2.115-.562-2.343a1.038,1.038,0,0,0-1.653-.358c-.595.488-.4,2.571.4,4.491a2.741,2.741,0,0,1,.331,1.269,5.9,5.9,0,0,1-1.653-1.4c-2.347-2.343-4.495-7.388-4.495-10.447v-.781l5.387.065,5.354.1Zm-20.26,10.512a13.865,13.865,0,0,1,1.058,3.938l.2,2.115-2.446-.1-2.446-.1-.1-3.482-.1-3.482.925-.228a12.322,12.322,0,0,0,1.256-.293,2.272,2.272,0,0,1,.562-.13A6.268,6.268,0,0,1,111.839-154.311Zm19.434-1.334.925.228-.1,3.482-.1,3.482-2.38.1-2.413.1v-1.269a16.525,16.525,0,0,1,1.553-5.7c.3-.586.661-.846,1.025-.749C130.083-155.905,130.777-155.743,131.272-155.645Z\" transform=\"translate(0)\" fill=\"#7c8791\"/>  </g></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Home", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.992\" height=\"29.458\" viewBox=\"0 0 26.992 29.458\">  <path id=\"Group_619-converted_2_\" data-name=\"Group 619-converted (2)\" d=\"M13.173.062a1.15,1.15,0,0,0-.225.106L6.7,4.973C3.3,7.591.433,9.814.33,9.912c-.361.345-.333-.4-.319,8.519l.011,7.961.125.4a3.537,3.537,0,0,0,.908,1.555,3.543,3.543,0,0,0,1.67,1.018l.39.113h20.77l.39-.113a3.835,3.835,0,0,0,2.578-2.573l.124-.4.012-7.961c.014-8.918.042-8.174-.319-8.519C26.452,9.7,14.19.257,13.969.127a1.115,1.115,0,0,0-.8-.065m6.1,6.643,5.7,4.387-.009,7.583-.009,7.583-.134.259a1.823,1.823,0,0,1-1.329.976c-.172.027-1.23.046-2.575.047H18.632l-.012-6.491-.013-6.492-.1-.186a1.144,1.144,0,0,0-.6-.512c-.1-.027-1.789-.043-4.41-.043s-4.313.016-4.41.043a1.144,1.144,0,0,0-.6.512l-.1.186-.012,6.492L8.369,27.54H6.086c-1.346,0-2.4-.02-2.576-.047a1.823,1.823,0,0,1-1.329-.976l-.134-.259-.009-7.583-.009-7.583L7.731,6.7C10.867,4.279,13.463,2.3,13.5,2.309s2.634,1.983,5.77,4.4M16.6,21.668V27.54h-6.21V15.8H16.6v5.873\" transform=\"translate(-0.004 -0.017)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "HomeSettings", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.992\" height=\"29.458\" viewBox=\"0 0 26.992 29.458\">  <path id=\"Group_622-converted\" data-name=\"Group 622-converted\" d=\"M13.173.062a1.15,1.15,0,0,0-.225.106L6.7,4.973C3.3,7.591.433,9.814.33,9.912c-.361.345-.333-.4-.319,8.519l.011,7.961.125.4a3.537,3.537,0,0,0,.908,1.555,3.543,3.543,0,0,0,1.67,1.018l.39.113h20.77l.39-.113a3.835,3.835,0,0,0,2.578-2.573l.124-.4.012-7.961c.014-8.918.042-8.174-.319-8.519C26.452,9.7,14.19.257,13.969.127a1.115,1.115,0,0,0-.8-.065m6.1,6.643,5.7,4.387-.009,7.583-.009,7.583-.134.259a1.823,1.823,0,0,1-1.329.976c-.405.064-19.575.064-19.98,0a1.823,1.823,0,0,1-1.329-.976l-.134-.259-.009-7.583-.009-7.583L7.731,6.7C10.867,4.279,13.463,2.3,13.5,2.309s2.634,1.983,5.77,4.4m-6.627,3.927a2.254,2.254,0,0,0-1.335,1.185,1.959,1.959,0,0,0-.2.765,3.531,3.531,0,0,1-.094.569,1.233,1.233,0,0,1-.633.435c-.158.052-.193.045-.562-.125a2.235,2.235,0,0,0-2.648.373,2.815,2.815,0,0,0-.828,1.828,2.248,2.248,0,0,0,1.08,1.963,1.329,1.329,0,0,1,.333.291,1.678,1.678,0,0,1,.028.866,1.291,1.291,0,0,1-.376.337,2.293,2.293,0,0,0-.718,3.135A2.293,2.293,0,0,0,9.855,23.26a.68.68,0,0,1,.792.008c.357.2.41.293.447.752a2.163,2.163,0,0,0,.745,1.6,2.315,2.315,0,0,0,1.661.611,2.315,2.315,0,0,0,1.661-.611,2.163,2.163,0,0,0,.745-1.6c.037-.459.09-.548.447-.752a.669.669,0,0,1,.784-.007,2.285,2.285,0,0,0,2.217,0,2.471,2.471,0,0,0,.918-.962,2.28,2.28,0,0,0,.314-1.8,2.168,2.168,0,0,0-.984-1.365,1.448,1.448,0,0,1-.374-.322,1.844,1.844,0,0,1-.006-.874,1.2,1.2,0,0,1,.338-.3,2.812,2.812,0,0,0,.823-.845,2.4,2.4,0,0,0,.262-1.214,2.732,2.732,0,0,0-1.352-2.132,2.346,2.346,0,0,0-1.518-.211,4.26,4.26,0,0,0-.6.228c-.369.17-.4.177-.562.125a1.233,1.233,0,0,1-.633-.435,3.733,3.733,0,0,1-.1-.574,2.228,2.228,0,0,0-2.4-2.046,2.246,2.246,0,0,0-.84.1m1.346,1.723a.831.831,0,0,1,.23.679,2.347,2.347,0,0,0,.68,1.487,4.319,4.319,0,0,0,1.2.69,2.4,2.4,0,0,0,1.756-.181.616.616,0,0,1,.978.319c.206.407.124.664-.291.916a2.3,2.3,0,0,0-1.084,2.118,2.2,2.2,0,0,0,.624,1.7,2.589,2.589,0,0,0,.444.378.606.606,0,0,1,.277.962c-.25.469-.435.52-.978.27a2.231,2.231,0,0,0-2.1-.008,2.78,2.78,0,0,0-1.065.823,2.106,2.106,0,0,0-.443,1.217,2.526,2.526,0,0,1-.091.534.864.864,0,0,1-1.256,0,2.554,2.554,0,0,1-.091-.538,3.374,3.374,0,0,0-.13-.676,2.49,2.49,0,0,0-.784-1.011,2.4,2.4,0,0,0-2.7-.338c-.479.241-.733.176-.978-.253a.626.626,0,0,1-.042-.716,2.089,2.089,0,0,1,.353-.3A2.35,2.35,0,0,0,9.471,19.1a3.874,3.874,0,0,0,0-1.44,2.212,2.212,0,0,0-.987-1.37c-.475-.321-.544-.588-.269-1.042.231-.383.479-.442.921-.219a2.4,2.4,0,0,0,1.8.166,3.677,3.677,0,0,0,1.249-.776,2.21,2.21,0,0,0,.591-1.413.813.813,0,0,1,.23-.652c.121-.1.177-.115.49-.115s.369.013.49.115M12.771,15.5a3.09,3.09,0,0,0-1.921,1.559,2.723,2.723,0,0,0-.287,1.341,2.651,2.651,0,0,0,.867,2.03,2.732,2.732,0,0,0,1.5.828A2.845,2.845,0,0,0,14.8,21.01a2.383,2.383,0,0,0,.765-.575,2.718,2.718,0,0,0,.765-1.243,3.44,3.44,0,0,0,.029-1.552A3.025,3.025,0,0,0,14.209,15.5a4.183,4.183,0,0,0-1.438,0m1.248,1.731a1.247,1.247,0,0,1,.578,1.7,1.228,1.228,0,0,1-2.2-.014,1.253,1.253,0,0,1,.583-1.682,1.472,1.472,0,0,1,1.042,0\" transform=\"translate(-0.004 -0.017)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Shower", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.461\" height=\"29.448\" viewBox=\"0 0 29.461 29.448\">  <path id=\"Group_618-converted\" data-name=\"Group 618-converted\" d=\"M1.165.455A1.026,1.026,0,0,0,.471,1.1a.772.772,0,0,0-.024.535l.061.28L2.423,3.839c1.691,1.7,1.906,1.93,1.836,1.989A10.136,10.136,0,0,0,3.252,7.392a10.21,10.21,0,0,0-.939,2.972,12.144,12.144,0,0,0-.024,2.561,9.748,9.748,0,0,0,1.779,4.417,1.969,1.969,0,0,1,.216.32c0,.021-.457.5-1.014,1.062-1.105,1.118-1.157,1.2-1.117,1.679a1,1,0,0,0,.453.735,1.127,1.127,0,0,0,.959.039c.12-.062,3.573-3.482,8.919-8.834,8.643-8.651,8.724-8.734,8.783-8.988a.994.994,0,0,0-.435-1.065,1.088,1.088,0,0,0-.939-.069,10.508,10.508,0,0,0-1.2,1.087c-.76.749-1.028.985-1.078.949a9.956,9.956,0,0,0-3.548-1.736A10.023,10.023,0,0,0,9.439,2.5,9.7,9.7,0,0,0,6.032,4.105l-.287.221L3.906,2.483C2.895,1.47,1.989.6,1.893.551a1.056,1.056,0,0,0-.728-.1M12.826,4.3A7.376,7.376,0,0,1,15.64,5.335a5.134,5.134,0,0,1,.462.3l.138.113L10.988,11,5.736,16.254l-.272-.419A7.2,7.2,0,0,1,4.235,11.7a7.127,7.127,0,0,1,.8-3.365,6.971,6.971,0,0,1,1.34-1.86,7.417,7.417,0,0,1,4.284-2.18,10.7,10.7,0,0,1,2.167.012m8.916,6.439a1.215,1.215,0,0,0-.618.528,1,1,0,1,0,1.458-.378,1.208,1.208,0,0,0-.84-.15m6.723,1.776a1.4,1.4,0,0,0-.526.564,1.079,1.079,0,0,0,.381,1.176.927.927,0,0,0,.984.067.911.911,0,0,0,.564-.812.975.975,0,0,0-.4-.883.7.7,0,0,0-.523-.166,1.221,1.221,0,0,0-.483.054M16.682,15.89a.991.991,0,1,0,.935,1.627.923.923,0,0,0,.188-.985.99.99,0,0,0-1.123-.642m6.653,1.768a1,1,0,0,0-.589.921.916.916,0,0,0,.32.736.99.99,0,0,0,1.486-.169.974.974,0,0,0-.26-1.382.689.689,0,0,0-.5-.169.84.84,0,0,0-.459.063M11.252,21.135a1.26,1.26,0,0,0-.368.327.7.7,0,0,0-.149.519.946.946,0,0,0,.414.853,1.012,1.012,0,0,0,1.375-.238c.14-.177.152-.222.152-.581s-.011-.4-.154-.58a.988.988,0,0,0-1.27-.3m7.06,1.626a1,1,0,0,0-.468,1.627.883.883,0,0,0,.735.335.991.991,0,0,0,.88-1.467,1.064,1.064,0,0,0-1.147-.5m-5.287,5.2a1.149,1.149,0,0,0-.528.567,1.5,1.5,0,0,0-.035.464.9.9,0,0,0,.539.78,1,1,0,0,0,1.387-1.188,1.062,1.062,0,0,0-.492-.593,1.218,1.218,0,0,0-.871-.03\" transform=\"translate(-0.411 -0.429)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Car", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"35.93\" height=\"21.937\" viewBox=\"0 0 35.93 21.937\">  <path id=\"Group_635-converted\" data-name=\"Group 635-converted\" d=\"M5.428.1A3.925,3.925,0,0,0,2.923,1.919c-.085.149-.693,1.391-1.352,2.76A19,19,0,0,0,.2,7.828l-.172.66v8.517l.137.339a2.8,2.8,0,0,0,1.5,1.5c.325.13.44.139,1.92.157a5.518,5.518,0,0,1,1.575.091A4.028,4.028,0,0,0,5.818,20.3a4.676,4.676,0,0,0,2,1.432l.487.187h1.2c1.174,0,1.21,0,1.645-.171a4.52,4.52,0,0,0,2.615-2.441l.1-.3H18c3.887,0,4.137.006,4.166.1.017.057.129.307.249.555a3.266,3.266,0,0,0,.762.992,3.38,3.38,0,0,0,1.114.822,3.907,3.907,0,0,0,2.194.465,4.245,4.245,0,0,0,2.046-.362,4.428,4.428,0,0,0,2.244-2.3l.081-.274,1.411,0a7.615,7.615,0,0,0,1.8-.106,2.766,2.766,0,0,0,1.755-1.57c.133-.327.134-.354.134-3.539a18.256,18.256,0,0,0-.107-3.6,4.574,4.574,0,0,0-2.4-2.907,73.8,73.8,0,0,0-7.251-1.9l-.886-.2-.53-.573c-1.425-1.538-3.041-3.169-3.43-3.462A5.9,5.9,0,0,0,19.195.14c-.357-.095-.935-.1-6.868-.118C6.732.009,5.791.02,5.428.1M18.861,2.122c1.024.307,1.288.528,3.906,3.283a20.126,20.126,0,0,0,1.628,1.6c.093.037.829.218,1.638.4A63.662,63.662,0,0,1,32.676,9.14a2.619,2.619,0,0,1,1.181,1.407,52.554,52.554,0,0,1,.025,6.18c-.159.254-.3.278-1.683.278H30.885l-.143-.352a4.52,4.52,0,0,0-2.91-2.477,7.743,7.743,0,0,0-2.639,0,4.55,4.55,0,0,0-2.919,2.457l-.159.405H13.928l-.283-.585a3.043,3.043,0,0,0-.773-1.064,4.455,4.455,0,0,0-2.334-1.27,6.2,6.2,0,0,0-2.53.122,4.454,4.454,0,0,0-2.745,2.414l-.142.353L3.9,17.023c-1.324.02-1.617-.022-1.767-.252-.136-.207-.133-7.733,0-8.388a46.191,46.191,0,0,1,2.8-5.807,1.913,1.913,0,0,1,.97-.535C6.036,2.013,8.929,2,12.327,2c5.721.012,6.2.021,6.534.119M10.108,16.081a2.01,2.01,0,0,1,1.8,2.427,1.441,1.441,0,0,1-.5.746,2.355,2.355,0,0,1-1.523.722,3.049,3.049,0,0,1-1.526-.2A2.5,2.5,0,0,1,7.11,18.544a1.8,1.8,0,0,1,.06-1.239,2.414,2.414,0,0,1,.393-.52,2.819,2.819,0,0,1,2.545-.7m16.972,0a2.517,2.517,0,0,1,1.272.618,1.62,1.62,0,0,1,.615,1.294,2.242,2.242,0,0,1-.075.584,2.6,2.6,0,0,1-2.809,1.4,2.161,2.161,0,0,1-2.047-1.967,1.436,1.436,0,0,1,.477-1.154,2.721,2.721,0,0,1,2.567-.772\" transform=\"translate(-0.03 -0.017)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Cleaning", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"25\" height=\"27.5\" viewBox=\"0 0 25 27.5\">  <g id=\"Screenshot-2024-10-31-233358\" transform=\"translate(-107.5 190.497)\">    <path id=\"Path_1199\" data-name=\"Path 1199\" d=\"M122.333-190.469c-.148.029-.771.146-1.365.233-2.106.349-4.539,3.085-5.459,6.14l-.356,1.164-3.827.146-3.827.146v14.26l3,.087,3.026.087.119,2.183c.089,1.775.208,2.3.682,2.619.445.32,2.136.407,8.336.407,6.675,0,7.862-.058,8.247-.466a1.421,1.421,0,0,0,.475-.786c0-.2.267-3.987.623-8.41s.564-8.265.475-8.5c-.119-.32-.564-.466-1.365-.466-1.127,0-1.157,0-1.365-1.31A9.918,9.918,0,0,0,126.1-189.3,7.516,7.516,0,0,0,122.333-190.469Zm1.721,2.27c1.721.7,3.293,2.968,3.768,5.471l.208,1.106h-4.213c-3.975,0-4.242-.029-4.391-.582-.119-.437-.415-.582-1.216-.582h-1.068l.564-1.484a6.791,6.791,0,0,1,3.056-3.841A3.477,3.477,0,0,1,124.054-188.2Zm-6.319,10.069v2.91h-8.6v-2.706a11.254,11.254,0,0,1,.208-2.91,24.328,24.328,0,0,1,4.3-.2h4.094Zm12.7.058-.089,1.542h-10.68l-.089-1.542-.089-1.513h11.036Zm-.386,5.529c-.119,1.164-.3,3.288-.386,4.744l-.208,2.619-6.883.087-6.912.058v-.931a14.277,14.277,0,0,0-.153-2.082c-.111-.238-.114-.159,1.814-.246l2.047-.087.089-3.143.089-3.114h10.68Zm-12.312.815v1.455h-8.6v-2.91h8.6Z\" transform=\"translate(0 0)\" fill=\"#7c8791\"/>  </g></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wash", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.002\" height=\"29.436\" viewBox=\"0 0 27.002 29.436\">  <path id=\"Group_634-converted_1_\" data-name=\"Group 634-converted (1)\" d=\"M2.542.031A3.123,3.123,0,0,0,.213,1.89a3.71,3.71,0,0,0-.164.56c-.069.376-.069,24.244,0,24.62a2.94,2.94,0,0,0,.881,1.6,2.831,2.831,0,0,0,.982.652l.316.131H24.773l.314-.131a3.149,3.149,0,0,0,1.846-2.165c.056-.272.066-1.96.066-12.377,0-8.47-.014-12.143-.048-12.33A3.142,3.142,0,0,0,24.84.106c-.238-.08-.678-.084-11.2-.088-6.027,0-11.018,0-11.093.013M24.43,2.112a1.283,1.283,0,0,1,.5.528c.026.068.042,4.8.042,12.125,0,11.774,0,12.017-.087,12.184a1.061,1.061,0,0,1-.675.541c-.331.071-21.1.071-21.427,0a.836.836,0,0,1-.426-.227c-.368-.34-.335.665-.335-10.069V7.605H3.6c.947,0,1.662-.019,1.8-.048a1.07,1.07,0,0,0,.7-.6.993.993,0,0,0-.418-1.224L5.467,5.6,3.746,5.589,2.025,5.576V4.156c0-1.563,0-1.581.283-1.851.316-.305-.7-.279,11.183-.28,10.57,0,10.771,0,10.939.087M20.188,5.643a1,1,0,0,0-.412,1.588.988.988,0,0,0,.767.34.917.917,0,0,0,.71-.3A.982.982,0,0,0,21.268,5.9a1.11,1.11,0,0,0-1.08-.259M12.783,7.791A9.228,9.228,0,0,0,9.832,8.9a9.089,9.089,0,0,0-2.195,1.975A8.071,8.071,0,0,0,6.279,17.8a8.354,8.354,0,0,0,.864,2.044,8,8,0,0,0,14.776-2.989,11.059,11.059,0,0,0,0-2.25,8.084,8.084,0,0,0-2.261-4.517,7.9,7.9,0,0,0-4.523-2.274,12.557,12.557,0,0,0-2.354-.02M15.22,9.857a6,6,0,0,1,4.719,5.077,8.252,8.252,0,0,1-.072,2.031,5.987,5.987,0,0,1-1.788,3.15l-.123.1.033-.217a7.9,7.9,0,0,0,.03-.846,3.784,3.784,0,0,0-.326-1.667,4.477,4.477,0,0,0-2.146-2.271,4.389,4.389,0,0,0-1.845-.471,4.963,4.963,0,0,1-.989-.158,2.6,2.6,0,0,1-1.514-1.51,3.318,3.318,0,0,1-.088-1.377,2.586,2.586,0,0,1,1.6-1.817,6.322,6.322,0,0,1,2.51-.02M9.3,13.669a4.307,4.307,0,0,0,1.158,1.8,4.412,4.412,0,0,0,2.962,1.254,6.018,6.018,0,0,1,.753.091,2.508,2.508,0,0,1,1.848,2.066,2.468,2.468,0,0,1-.766,2.173,2.635,2.635,0,0,1-1.212.627,4.766,4.766,0,0,1-1.452-.125,5.844,5.844,0,0,1-2.894-1.673A5.967,5.967,0,0,1,8.832,12.7l.189-.331.078.478a6.473,6.473,0,0,0,.2.825\" transform=\"translate(0.003 -0.017)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorOne", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#C8653E";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorTwo", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#B3783E";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorThree", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#668D63";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorFour", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#7A8F92";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "4ddc1f46-d08a-4c11-9280-0695be8b833f", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Modern", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Segoe UI", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 1;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#173f5f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#20639b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#535353";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonBGColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#986b5d";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#758a71";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#788799";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#a72928";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ec6665";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ee6809";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#eea622";
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Reception", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.667\" height=\"29.667\" viewBox=\"0 0 29.667 29.667\"><path id=\"Path_2271\" data-name=\"Path 2271\" d=\"M14.833,0a3.56,3.56,0,1,0,3.56,3.56A3.564,3.564,0,0,0,14.833,0Zm-1.78,7.713A4.158,4.158,0,0,0,8.9,11.867v1.187H20.767V11.867a4.158,4.158,0,0,0-4.153-4.153Zm11.867,3.56v.593h1.187v-.593Zm.593.593A2.98,2.98,0,0,0,22.6,14.24H.593A.594.594,0,0,0,0,14.833v2.373a.593.593,0,0,0,.593.593h28.48a.592.592,0,0,0,.593-.593V14.833a.593.593,0,0,0-.593-.593h-.649A2.98,2.98,0,0,0,25.513,11.867Zm0,1.187a1.782,1.782,0,0,1,1.669,1.187H23.845A1.782,1.782,0,0,1,25.513,13.053ZM1.187,18.987V29.073a.593.593,0,0,0,.593.593H27.887a.592.592,0,0,0,.593-.593V18.987Z\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Calendar", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"43.8\" height=\"48.667\" viewBox=\"0 0 43.8 48.667\">   <path id=\"Agenda\" d=\"M10.3,1V5.867H7.867A4.881,4.881,0,0,0,3,10.733V44.8a4.881,4.881,0,0,0,4.867,4.867H41.933A4.881,4.881,0,0,0,46.8,44.8V10.733a4.881,4.881,0,0,0-4.867-4.867H39.5V1H34.633V5.867H15.167V1ZM7.867,10.733H41.933V15.6H7.867Zm0,9.733H41.933V44.8H7.867ZM27.333,30.2v9.733h9.733V30.2Z\" transform=\"translate(-3 -1)\" fill=\"#7c8791\"></path> </svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Door", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"22.952\" height=\"27.543\" viewBox=\"0 0 22.952 27.543\">  <path id=\"Path_544\" data-name=\"Path 544\" d=\"M7.3,3A2.3,2.3,0,0,0,5,5.3V30.543H7.3V5.3H25.657V30.543h2.3V5.3a2.3,2.3,0,0,0-2.3-2.3Zm2.3,4.59V30.543H23.362V7.59Zm10.329,9.181a1.148,1.148,0,1,1-1.148,1.148A1.148,1.148,0,0,1,19.919,16.771Z\" transform=\"translate(-5 -3)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Intercom", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"40.458\" height=\"27.454\" viewBox=\"0 0 40.458 27.454\">  <path id=\"Path_550\" data-name=\"Path 550\" d=\"M4.89,19.464A2.89,2.89,0,0,0,2,22.354V44.028a2.89,2.89,0,0,0,2.89,2.89H39.568a2.89,2.89,0,0,0,2.89-2.89V22.354a2.89,2.89,0,0,0-2.89-2.89Zm1.445,2.89H28.009A1.445,1.445,0,0,1,29.454,23.8V38.248a1.445,1.445,0,0,1-1.445,1.445H6.335A1.445,1.445,0,0,1,4.89,38.248V23.8A1.445,1.445,0,0,1,6.335,22.354Zm27.454,0A1.445,1.445,0,1,1,32.344,23.8,1.446,1.446,0,0,1,33.789,22.354Zm4.335,0A1.445,1.445,0,1,1,36.678,23.8,1.446,1.446,0,0,1,38.123,22.354ZM6.335,23.8V38.248H28.009V23.8Zm10.837,1.445a3.612,3.612,0,1,1,0,7.225h2.167a2.89,2.89,0,0,1,2.89,2.89V36.8H12.115V35.359A2.89,2.89,0,0,1,15,32.469h2.167a3.612,3.612,0,1,1,0-7.225Zm16.617,1.445a1.445,1.445,0,1,1-1.445,1.445A1.446,1.446,0,0,1,33.789,26.689Zm4.335,0a1.445,1.445,0,1,1-1.445,1.445A1.446,1.446,0,0,1,38.123,26.689Zm-4.335,4.335a1.445,1.445,0,1,1-1.445,1.445A1.446,1.446,0,0,1,33.789,31.024Zm4.335,0a1.445,1.445,0,1,1-1.445,1.445A1.446,1.446,0,0,1,38.123,31.024ZM35.956,36.8a3.612,3.612,0,1,1-3.612,3.612A3.616,3.616,0,0,1,35.956,36.8Zm0,1.445a2.167,2.167,0,1,0,2.167,2.167A2.167,2.167,0,0,0,35.956,38.248ZM8.5,42.583h2.89a.722.722,0,1,1,0,1.445H8.5a.722.722,0,1,1,0-1.445Zm7.225,0h2.89a.722.722,0,1,1,0,1.445h-2.89a.722.722,0,1,1,0-1.445Zm7.225,0h2.89a.722.722,0,1,1,0,1.445h-2.89a.722.722,0,1,1,0-1.445Z\" transform=\"translate(-2 -19.464)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Key", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20.9\" height=\"27.5\" viewBox=\"0 0 20.9 27.5\">  <path id=\"Path_549\" data-name=\"Path 549\" d=\"M10.1,0A1.1,1.1,0,0,0,9,1.1v9.35a1.1,1.1,0,0,0,1.1,1.1h1.994a5.7,5.7,0,0,1-.344-1.925,5.78,5.78,0,0,1,3.007-5.066,3.023,3.023,0,0,1,5.537,0A5.78,5.78,0,0,1,23.3,9.625c0,.061-.01.119-.012.179a5.514,5.514,0,0,1,2.126,1.64,1.1,1.1,0,0,0,.636-.995V1.1A1.1,1.1,0,0,0,24.95,0Zm7.425,3.85A1.925,1.925,0,1,0,19.45,5.775,1.925,1.925,0,0,0,17.525,3.85Zm-3.011,2.2a4.589,4.589,0,0,0-1.616,4.2c.007.049.014.1.023.147a4.677,4.677,0,0,0,2.123,3.178l.043.026a4.659,4.659,0,0,0,.487.261c.016.007.03.018.046.025h0a4.634,4.634,0,0,0,1.463.387,1.1,1.1,0,1,1-2.036.573c0-.01,0-.019,0-.029a5.792,5.792,0,0,1-2.182-1.8,4.391,4.391,0,0,0,1.628,7V26.4l1.1,1.1h1.1l1.1-1.1V25.3l-.825-.825.825-.825v-1.1l-.55-.825.55-.825v-.873A4.395,4.395,0,0,0,14.7,11.8a3.565,3.565,0,0,1-.533-.972,5.432,5.432,0,0,1,1.985-.382,5.5,5.5,0,0,1,1.414.19A5.5,5.5,0,0,1,22.19,9.459a4.662,4.662,0,0,0-1.654-3.4,3.024,3.024,0,0,1-6.022,0Zm6.7,4.389a4.334,4.334,0,0,0-2.429.677,5.489,5.489,0,0,1,1.782,8.1,4.27,4.27,0,0,0,.536.039,4.315,4.315,0,0,0,1.807-.4L27.7,23.65h1.65l.55-.55V21.45l-.55-.55h-1.1V19.8l-1.1-1.1h-1.1V17.6l-.943-.943a4.419,4.419,0,0,0-3.9-6.213Z\" transform=\"translate(-9)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Monitor", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32.915\" height=\"27.43\" viewBox=\"0 0 32.915 27.43\">  <path id=\"Path_546\" data-name=\"Path 546\" d=\"M5.743,6A2.742,2.742,0,0,0,3,8.743V25.2a2.742,2.742,0,0,0,2.743,2.743h27.43A2.742,2.742,0,0,0,35.915,25.2V8.743A2.742,2.742,0,0,0,33.173,6ZM12.6,30.687a1.372,1.372,0,1,0,0,2.743H26.315a1.372,1.372,0,1,0,0-2.743Z\" transform=\"translate(-3 -6)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Bed", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"34.324\" height=\"27.459\" viewBox=\"0 0 34.324 27.459\">  <path id=\"Path_545\" data-name=\"Path 545\" d=\"M3.432,10a2.063,2.063,0,0,0-2.059,2.059v9.482a10.285,10.285,0,0,1,3.432-1.888V16.865c0-1.826,3.119-2.059,5.835-2.059s5.835.233,5.835,2.059v1.373c.231,0,.451,0,.686,0s.456,0,.686,0V16.865c0-1.826,3.119-2.059,5.835-2.059s5.835.233,5.835,2.059v2.767a10.182,10.182,0,0,1,3.432,1.909V12.059A2.063,2.063,0,0,0,30.892,10Zm13.73,9.611C4.055,19.611-.011,22.035,0,28.535H34.324C34.335,21.992,30.27,19.611,17.162,19.611ZM0,29.908v7.551H4.805V34.713c0-.987.386-1.373,1.373-1.373H28.146c.987,0,1.373.386,1.373,1.373v2.746h4.805V29.908Z\" transform=\"translate(0 -10)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "FirstAid", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.214\" height=\"27.498\" viewBox=\"0 0 26.214 27.498\">  <path id=\"Path_938\" data-name=\"Path 938\" d=\"M26.3,4.75H20.208a4.433,4.433,0,0,0-8.2,0H5.913A2.834,2.834,0,0,0,3,7.5V26.748A2.834,2.834,0,0,0,5.913,29.5H26.3a2.834,2.834,0,0,0,2.913-2.75V7.5A2.834,2.834,0,0,0,26.3,4.75Zm-10.194,0a1.418,1.418,0,0,1,1.456,1.375,1.459,1.459,0,0,1-2.913,0A1.418,1.418,0,0,1,16.107,4.75Zm4.369,15.124H17.564v2.75A1.418,1.418,0,0,1,16.107,24h0a1.418,1.418,0,0,1-1.456-1.375v-2.75H11.738A1.418,1.418,0,0,1,10.282,18.5h0a1.418,1.418,0,0,1,1.456-1.375h2.913v-2.75A1.418,1.418,0,0,1,16.107,13h0a1.418,1.418,0,0,1,1.456,1.375v2.75h2.913A1.418,1.418,0,0,1,21.933,18.5h0A1.418,1.418,0,0,1,20.476,19.874Z\" transform=\"translate(-3 -2)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Food", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32.813\" height=\"27.572\" viewBox=\"0 0 32.813 27.572\">  <path id=\"Path_939\" data-name=\"Path 939\" d=\"M22.959,3.986a.656.656,0,0,0-.646.665V5.964q0,.019,0,.038A5.905,5.905,0,0,0,17.1,11.214H15.75a.656.656,0,0,0-.656.656v4.594H11.933a7.534,7.534,0,0,0,.445-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,9.9H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,13.183H2.625a.656.656,0,1,0,0,1.313h.091a7.535,7.535,0,0,0,.445,1.969H.656A.656.656,0,0,0,0,17.12v6.563a3.271,3.271,0,0,0,5.906,1.948,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.271,3.271,0,0,0,5.906-1.948V17.12a.656.656,0,0,0-.656-.656H30.844V11.87a.656.656,0,0,0-.656-.656H28.837A5.905,5.905,0,0,0,23.624,6q0-.019,0-.038V4.652a.656.656,0,0,0-.666-.665ZM4.029,7.933h7.037A5.272,5.272,0,0,1,10.473,9.9H4.621A5.272,5.272,0,0,1,4.029,7.933Zm0,3.281h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,11.214Zm12.378,1.313H29.531v3.938H16.406ZM4.029,14.5h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,14.5Zm-1.4,13.729V30.9a.656.656,0,0,0,1.313,0V28.23a4.352,4.352,0,0,1-.656.046A3.64,3.64,0,0,1,2.625,28.224Zm27.562,0a3.64,3.64,0,0,1-.656.053,4.352,4.352,0,0,1-.656-.046V30.9a.656.656,0,0,0,1.313,0Z\" transform=\"translate(0 -3.986)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wellbeing", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"31.83\" height=\"28.479\" viewBox=\"0 0 31.83 28.479\">  <path id=\"Path_941\" data-name=\"Path 941\" d=\"M24.689,3.007a9.543,9.543,0,0,0-6.774,3.3,9.543,9.543,0,0,0-6.774-3.3A8.865,8.865,0,0,0,3.768,6.654C-2.379,14.723,9.259,24.162,12,26.7c1.638,1.516,3.659,3.317,4.865,4.384a1.583,1.583,0,0,0,2.106,0c1.206-1.067,3.228-2.868,4.865-4.384,2.738-2.534,14.377-11.973,8.228-20.041A8.86,8.86,0,0,0,24.689,3.007Z\" transform=\"translate(-2 -3.001)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Curtain", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.668\" height=\"27.386\" viewBox=\"0 0 29.668 27.386\">  <path id=\"Path_547\" data-name=\"Path 547\" d=\"M3.141,3a1.141,1.141,0,1,0,0,2.282H30.527a1.141,1.141,0,1,0,0-2.282Zm0,4.564v21.68a1.141,1.141,0,0,0,1.141,1.141H15.693V8.705a1.141,1.141,0,0,1-1.141-1.141H13.411a1.141,1.141,0,0,1-2.282,0H9.988a1.141,1.141,0,0,1-2.282,0H6.564a1.141,1.141,0,1,1-2.282,0Zm15.975,0a1.141,1.141,0,0,1-1.141,1.141v21.68H29.386a1.141,1.141,0,0,0,1.141-1.141V7.564H29.386a1.141,1.141,0,1,1-2.282,0H25.962a1.141,1.141,0,1,1-2.282,0H22.539a1.141,1.141,0,0,1-2.282,0Z\" transform=\"translate(-2 -3)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Home", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28.752\" height=\"28.752\" viewBox=\"0 0 28.752 28.752\">  <path id=\"Path_937\" data-name=\"Path 937\" d=\"M17.376,2a1.2,1.2,0,0,0-.838.342L3.47,13.03l-.044.035-.044.037v0A1.2,1.2,0,0,0,4.2,15.178H5.4V28.356a2.4,2.4,0,0,0,2.4,2.4H26.96a2.4,2.4,0,0,0,2.4-2.4V15.178h1.2a1.2,1.2,0,0,0,.817-2.075l-.019-.014q-.039-.036-.082-.068l-1.914-1.565V6.792a1.2,1.2,0,0,0-1.2-1.2h-1.2a1.2,1.2,0,0,0-1.2,1.2V8.516l-7.574-6.2A1.2,1.2,0,0,0,17.376,2ZM20.97,17.574h4.792v9.584H20.97Z\" transform=\"translate(-3 -2)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "HomeSettings", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.551\" height=\"27.551\" viewBox=\"0 0 27.551 27.551\">  <path id=\"Path_551\" data-name=\"Path 551\" d=\"M16.775,2A1.148,1.148,0,0,0,16,2.307l-.025.02L3.451,12.569l-.043.034-.043.036v0a1.147,1.147,0,0,0,.782,1.987H5.3V27.255a2.3,2.3,0,0,0,2.3,2.3H25.959a2.3,2.3,0,0,0,2.3-2.3V14.627H29.4a1.147,1.147,0,0,0,.782-1.987v0l-.018-.013q-.038-.034-.078-.065l-1.834-1.5V6.592a1.148,1.148,0,0,0-1.148-1.148H25.959a1.148,1.148,0,0,0-1.148,1.148V8.244L17.569,2.321l-.016-.013A1.148,1.148,0,0,0,16.775,2Zm-.381,11.479h.765a.766.766,0,0,1,.765.767v.545A4.573,4.573,0,0,1,20.049,16l.462-.264a.764.764,0,0,1,1.045.28l.381.661a.766.766,0,0,1-.278,1.047L21.183,18a4.129,4.129,0,0,1,0,2.437l.473.274a.767.767,0,0,1,.28,1.047l-.383.661a.764.764,0,0,1-1.045.28l-.462-.265a4.583,4.583,0,0,1-2.126,1.213V24.2a.762.762,0,0,1-.765.762h-.765a.766.766,0,0,1-.765-.767v-.545A4.583,4.583,0,0,1,13.5,22.434l-.462.265A.765.765,0,0,1,12,22.419l-.381-.661a.766.766,0,0,1,.278-1.047l.475-.274a4.129,4.129,0,0,1,0-2.437l-.475-.274a.764.764,0,0,1-.278-1.045L12,16.017a.765.765,0,0,1,1.045-.28L13.5,16a4.587,4.587,0,0,1,2.126-1.215v-.545A.765.765,0,0,1,16.394,13.479Zm.381,3.444a2.3,2.3,0,1,0,2.3,2.3A2.3,2.3,0,0,0,16.775,16.923Z\" transform=\"translate(-3 -2)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Shower", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28.819\" height=\"27.666\" viewBox=\"0 0 28.819 27.666\">  <path id=\"Path_548\" data-name=\"Path 548\" d=\"M25.36,0a3.411,3.411,0,0,0-3.008,1.729c.043,0,.083,0,.126,0a4.016,4.016,0,0,1,1.171.18,2.308,2.308,0,0,1,4.017,1.549v7.493h1.153V3.458A3.422,3.422,0,0,0,25.36,0ZM22.479,2.882A2.885,2.885,0,0,0,19.6,5.764a.576.576,0,0,0,.576.576h4.611a.576.576,0,0,0,.576-.576A2.885,2.885,0,0,0,22.479,2.882ZM20.749,6.916a.576.576,0,1,0,.576.576A.577.577,0,0,0,20.749,6.916Zm1.729,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,22.479,6.916Zm1.729,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,24.208,6.916ZM20.173,8.646a.576.576,0,1,0,.576.576A.577.577,0,0,0,20.173,8.646Zm2.305,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,22.479,8.646Zm2.305,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,24.784,8.646ZM19.6,10.375a.576.576,0,1,0,.576.576A.577.577,0,0,0,19.6,10.375Zm2.882,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,22.479,10.375Zm2.882,0a.576.576,0,1,0,.576.576A.577.577,0,0,0,25.36,10.375ZM.576,12.1A.577.577,0,0,0,0,12.68v1.153a.576.576,0,0,0,.576.576H28.242a.575.575,0,0,0,.576-.576V12.68a.576.576,0,0,0-.576-.576Zm0,3.458a1.127,1.127,0,0,1,1.153,1.153V19.6A6.342,6.342,0,0,0,6.3,25.685a1.082,1.082,0,0,1-1.117.829.576.576,0,1,0,0,1.153A2.3,2.3,0,0,0,7.421,25.9a6.184,6.184,0,0,0,.648.036h12.68A6.184,6.184,0,0,0,21.4,25.9a2.3,2.3,0,0,0,2.233,1.765.576.576,0,1,0,0-1.153,1.082,1.082,0,0,1-1.117-.829A6.342,6.342,0,0,0,27.09,19.6V16.715a1.127,1.127,0,0,1,1.153-1.153Z\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Car", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"33.969\" height=\"27.499\" viewBox=\"0 0 33.969 27.499\">  <path id=\"Path_940\" data-name=\"Path 940\" d=\"M33.625,15.208l-2.689-7.7A5.236,5.236,0,0,0,26,4H11.967A5.233,5.233,0,0,0,7.034,7.507l-2.689,7.7A5.247,5.247,0,0,0,2,19.588V28.88a2.613,2.613,0,1,0,5.226,0V27.228s6.9.342,11.758.342,11.758-.342,11.758-.342V28.88a2.613,2.613,0,1,0,5.226,0V19.588A5.248,5.248,0,0,0,33.625,15.208ZM8,12.659,9.5,8.372a2.614,2.614,0,0,1,2.467-1.753H26a2.614,2.614,0,0,1,2.467,1.753l1.5,4.287a.936.936,0,0,1-1.03,1.24,62.318,62.318,0,0,0-9.952-.733,62.318,62.318,0,0,0-9.952.733A.936.936,0,0,1,8,12.659Zm-.124,9.673a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,7.879,22.332ZM22.9,21.023H15.065a1.309,1.309,0,0,1,0-2.619H22.9a1.309,1.309,0,0,1,0,2.619Zm7.186,1.309a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,30.09,22.332Z\" transform=\"translate(-2 -4)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Cleaning", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32.86\" height=\"26.791\" viewBox=\"0 0 32.86 26.791\">  <path id=\"Path_942\" data-name=\"Path 942\" d=\"M27.756,3.986a1.217,1.217,0,0,0-1.2,1.234v9.736a2.433,2.433,0,0,0-2.434,2.434v1.217H27.57a1.217,1.217,0,0,0,.4,0h3.459V17.39a2.433,2.433,0,0,0-2.434-2.434V5.22a1.217,1.217,0,0,0-1.236-1.234ZM11.953,4a4.049,4.049,0,0,0-3.6,2.579,3.784,3.784,0,0,0-.663-.145,4.278,4.278,0,0,0-4.26,4.26,4.152,4.152,0,0,0,.062.609H3.434a1.217,1.217,0,1,0,0,2.434H3.6l.825,6.19-3,2.629a1.218,1.218,0,0,0,1.6,1.835l1.79-1.566-.385-2.9,6.729-5.89a1.217,1.217,0,0,1,1.6,1.835L4.808,22.826l.777,5.838A2.437,2.437,0,0,0,8,30.777h7.906a2.434,2.434,0,0,0,2.413-2.113l1.992-14.925h.162a1.217,1.217,0,1,0,0-2.434h-.062a4.152,4.152,0,0,0,.062-.609,4.278,4.278,0,0,0-4.26-4.26,3.784,3.784,0,0,0-.663.145A4.049,4.049,0,0,0,11.953,4Zm0,2.434a1.8,1.8,0,0,1,1.8,1.626,1.217,1.217,0,0,0,1.709.975A1.817,1.817,0,0,1,18.038,10.7a1.858,1.858,0,0,1-.107.609H5.975a1.859,1.859,0,0,1-.107-.609A1.817,1.817,0,0,1,8.445,9.037a1.217,1.217,0,0,0,1.709-.975A1.8,1.8,0,0,1,11.953,6.437Zm12.17,14.6a16.837,16.837,0,0,0-2.434,8.519,1.217,1.217,0,0,0,1.217,1.217h9.736a1.216,1.216,0,0,0,1.21-1.348,16.907,16.907,0,0,0-2.427-8.388h-7.3Z\" transform=\"translate(-1 -3.986)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wash", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30.411\" height=\"28.722\" viewBox=\"0 0 30.411 28.722\">  <path id=\"Path_943\" data-name=\"Path 943\" d=\"M13.236,4a2.053,2.053,0,0,0,0,4.1h2.323l-.32.333-.034.033-2.493,2.58a8.153,8.153,0,0,1-1.539-1.907.674.674,0,0,0-1.158,0c-.021.036-1.94,3.543-5.723,3.73l-.98-6.247a.669.669,0,0,0-.638-.584.652.652,0,0,0-.517.238.7.7,0,0,0-.149.564l1.07,6.83s0,.005,0,.008L5.973,32.147s0,.006,0,.009a.7.7,0,0,0,.071.21l.012.02a.679.679,0,0,0,.137.17l.009.007a.657.657,0,0,0,.186.114l.008,0a.641.641,0,0,0,.227.041H27.778A.641.641,0,0,0,28,32.68l.019-.007a.656.656,0,0,0,.186-.114h0l0-.005a.679.679,0,0,0,.136-.168l.009-.017a.7.7,0,0,0,.075-.22l2.9-18.464s0-.005,0-.008l1.07-6.83a.7.7,0,0,0-.222-.662.644.644,0,0,0-.668-.112.681.681,0,0,0-.413.555l-.98,6.252a6.184,6.184,0,0,1-2.519-.672A4.91,4.91,0,0,0,26.423,7.5L24.262,5.265a4.348,4.348,0,0,0-3.184-1.256L13.238,4Zm0,1.368,7.84.009a3.031,3.031,0,0,1,2.251.855l2.161,2.236a3.493,3.493,0,0,1,0,4.832l-6.758,6.9,0,0a.636.636,0,0,1-.935,0,.685.685,0,0,1-.154-.711l2.573-2.662.009-.009q.024-.024.045-.049a.7.7,0,0,0-.016-.908.645.645,0,0,0-.874-.091l-.005.005-.026.021q-.021.018-.041.037l-.008.008-.01.009-.022.023-2.4,2.383-.009.009a2,2,0,0,0-.292.4l-1.508,1.56a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l4.228-4.374a.682.682,0,0,0,.12-.162h0a.7.7,0,0,0-.094-.793.646.646,0,0,0-.756-.16l-.005,0a.659.659,0,0,0-.161.108l-.037.037L13.191,18.29l-.8.825a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l.567-.586,4.185-4.33a.682.682,0,0,0,.12-.163.7.7,0,0,0-.166-.863.644.644,0,0,0-.85.02l-.005.005-.034.033-4.185,4.329a.636.636,0,0,1-.935,0,.688.688,0,0,1,0-.966L16.14,9.436,17.623,7.9a.7.7,0,0,0,.143-.745.661.661,0,0,0-.61-.422H13.236a.684.684,0,0,1,0-1.368Z\" transform=\"translate(-1.998 -4)\" fill=\"#7c8791\"/></svg>", "");
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorOne", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#20639B";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorTwo", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#788799";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorThree", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#758A71";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorFour", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#EEA622";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "2db8770b-2e22-4522-870f-d0d8b3ea0ed3", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Retro", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Roboto", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 1;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#653993";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#06394f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#18668b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonBGColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#126e68";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#844a27";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#b11d3b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#dd5342";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#f57f5c";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#f09605";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ead1b5";
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Reception", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"29.667\" height=\"29.667\" viewBox=\"0 0 29.667 29.667\"><path id=\"Path_2271\" data-name=\"Path 2271\" d=\"M14.833,0a3.56,3.56,0,1,0,3.56,3.56A3.564,3.564,0,0,0,14.833,0Zm-1.78,7.713A4.158,4.158,0,0,0,8.9,11.867v1.187H20.767V11.867a4.158,4.158,0,0,0-4.153-4.153Zm11.867,3.56v.593h1.187v-.593Zm.593.593A2.98,2.98,0,0,0,22.6,14.24H.593A.594.594,0,0,0,0,14.833v2.373a.593.593,0,0,0,.593.593h28.48a.592.592,0,0,0,.593-.593V14.833a.593.593,0,0,0-.593-.593h-.649A2.98,2.98,0,0,0,25.513,11.867Zm0,1.187a1.782,1.782,0,0,1,1.669,1.187H23.845A1.782,1.782,0,0,1,25.513,13.053ZM1.187,18.987V29.073a.593.593,0,0,0,.593.593H27.887a.592.592,0,0,0,.593-.593V18.987Z\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Calendar", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"43.8\" height=\"48.667\" viewBox=\"0 0 43.8 48.667\">   <path id=\"Agenda\" d=\"M10.3,1V5.867H7.867A4.881,4.881,0,0,0,3,10.733V44.8a4.881,4.881,0,0,0,4.867,4.867H41.933A4.881,4.881,0,0,0,46.8,44.8V10.733a4.881,4.881,0,0,0-4.867-4.867H39.5V1H34.633V5.867H15.167V1ZM7.867,10.733H41.933V15.6H7.867Zm0,9.733H41.933V44.8H7.867ZM27.333,30.2v9.733h9.733V30.2Z\" transform=\"translate(-3 -1)\" fill=\"#7c8791\"></path> </svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Door", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"17.244\" height=\"27.575\" viewBox=\"0 0 17.244 27.575\">  <g id=\"noun-door-6927342\" transform=\"translate(-280.49 -120)\">    <path id=\"Path_1092\" data-name=\"Path 1092\" d=\"M348.463,120H331.22v27.575h17.244Zm-1.049,16.574a.395.395,0,0,1,0-.789.4.4,0,0,1,.4.4A.4.4,0,0,1,347.413,136.574Zm-1.367-9.13h-5.428v-5.428h5.428Zm0,6.985h-5.428V129h5.428Zm-6.983-6.985h-5.428v-5.428h5.428Zm0,6.985h-5.428V129h5.428Z\" transform=\"translate(-50.73)\" fill=\"#7c8791\"/>  </g></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Intercom", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.542\" height=\"27.543\" viewBox=\"0 0 27.542 27.543\">  <path id=\"intercom\" d=\"M351.494,342.106a1.876,1.876,0,0,0-1.878-1.878h-5.008a1.876,1.876,0,0,0-1.878,1.878v23.787a1.876,1.876,0,0,0,1.878,1.878h5.008a1.876,1.876,0,0,0,1.878-1.878Zm.626.626v22.535h11.364c2.412,0,4.285-1.532,4.285-3.286V346.018c0-1.754-1.873-3.286-4.285-3.286Zm-10.016.274a3.293,3.293,0,0,0-1.878,3.012v15.963a3.294,3.294,0,0,0,1.878,3.012Zm17.527,19.757h1.252a.626.626,0,1,0,0-1.252h-1.252a.626.626,0,1,0,0,1.252Zm3.756,0h1.252a.626.626,0,1,0,0-1.252h-1.252a.626.626,0,1,0,0,1.252Zm-7.512,0h1.252a.626.626,0,1,0,0-1.252h-1.252a.626.626,0,1,0,0,1.252Zm7.512-2.5h1.252a.626.626,0,0,0,0-1.252h-1.252a.626.626,0,0,0,0,1.252Zm-3.756,0h1.252a.626.626,0,1,0,0-1.252h-1.252a.626.626,0,0,0,0,1.252Zm-3.756,0h1.252a.626.626,0,0,0,0-1.252h-1.252a.626.626,0,1,0,0,1.252Zm10.642-14.533a.626.626,0,0,0-.626-.626H354.624a.626.626,0,0,0-.626.626V356.5a.626.626,0,0,0,.626.626h11.268a.626.626,0,0,0,.626-.626ZM356.5,355.877H355.25v-9.525h10.016v9.525h-1.252v-1.252a1.876,1.876,0,0,0-1.878-1.878H358.38a1.876,1.876,0,0,0-1.878,1.878Zm1.252,0v-1.252a.624.624,0,0,1,.626-.626h3.756a.624.624,0,0,1,.626.626v1.252Zm5.008-5.008v-1.252a1.879,1.879,0,0,0-1.878-1.878h-1.252a1.879,1.879,0,0,0-1.878,1.878v1.252a1.879,1.879,0,0,0,1.878,1.878h1.252A1.879,1.879,0,0,0,362.762,350.869Zm-1.252-1.252v1.252a.626.626,0,0,1-.626.626h-1.252a.626.626,0,0,1-.626-.626v-1.252a.626.626,0,0,1,.626-.626h1.252A.626.626,0,0,1,361.51,349.617Z\" transform=\"translate(-340.227 -340.228)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Key", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24.783\" height=\"23.824\" viewBox=\"0 0 24.783 23.824\">  <g id=\"free-icon-vintage-key-8690576\" transform=\"translate(0.5 -9.301)\">    <path id=\"Path_1048\" data-name=\"Path 1048\" d=\"M24.283,14.684v1.4a4.122,4.122,0,0,1-4.235,3.582,6,6,0,0,1-3.291-1.016L2.646,32.859a1.331,1.331,0,0,1-1.6,0,1.37,1.37,0,0,1-.266-1.67l.8-.8L-.282,28.527A2.347,2.347,0,0,1-.5,28.14v-.726a1.332,1.332,0,0,1,1.839-.75l.968.871a.507.507,0,0,0,.508-.121l1.016-1.307a.605.605,0,0,0-.048-.436l-.678-.678a1.284,1.284,0,0,1,.46-1.96,1.26,1.26,0,0,1,1.21.1q.978.905,1.912,1.864l8.083-8.083a.121.121,0,0,0,0-.145,5.437,5.437,0,0,1-.581-4.889,4.317,4.317,0,0,1,4.671-2.541,6.543,6.543,0,0,1,4.961,3.8A7.711,7.711,0,0,1,24.283,14.684Zm-6.341-2.711a3.485,3.485,0,0,1,2.323.7,13.66,13.66,0,0,1,.944.992,2.877,2.877,0,0,1,.387,2.565,1.639,1.639,0,0,1-1.646,1.016,3.35,3.35,0,0,1-1.96-.75,3.844,3.844,0,0,1-1.428-2.3A1.729,1.729,0,0,1,17.942,11.973Z\" fill=\"#7c8791\" fill-rule=\"evenodd\" opacity=\"0.977\"/>  </g></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "General";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Monitor", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30\" height=\"28.72\" viewBox=\"0 0 30 28.72\">  <path id=\"Path_999\" data-name=\"Path 999\" d=\"M22.8,2a.61.61,0,0,0-.431.168L15,9.535,10.631,5.16a.609.609,0,1,0-.863.86l3.769,3.758H3.6A3.6,3.6,0,0,0,0,13.368V27.13a3.6,3.6,0,0,0,3.6,3.59H26.4A3.6,3.6,0,0,0,30,27.13V13.368a3.6,3.6,0,0,0-3.6-3.59H16.462l6.769-6.75A.6.6,0,0,0,22.8,2ZM12.3,12.172c8.672,0,9.9.023,9.9,8.078s-1.312,8.077-9.9,8.077c-8.627,0-9.9-.086-9.9-8.077S3.673,12.172,12.3,12.172ZM25.8,16.36a1.2,1.2,0,1,1-1.2,1.2A1.2,1.2,0,0,1,25.8,16.36Zm0,5.385a1.2,1.2,0,1,1-1.2,1.2A1.2,1.2,0,0,1,25.8,21.745Z\" transform=\"translate(0 -2)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Bed", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"35.989\" height=\"27.333\" viewBox=\"0 0 35.989 27.333\">  <path id=\"noun-bed-7266688\" d=\"M113.946,248.6a.33.33,0,0,1,.068.29l-.519,2.209v0a1.585,1.585,0,0,1-1.531,1.225h-.454a1.593,1.593,0,0,1-1.558-1.23l-.514-2.209h0a.35.35,0,0,1,.065-.292.346.346,0,0,1,.268-.128h3.922a.327.327,0,0,1,.255.133Zm25.734-.128h-3.922a.326.326,0,0,0-.263.128.33.33,0,0,0-.068.29l.519,2.209v0a1.584,1.584,0,0,0,1.553,1.225h.456a1.6,1.6,0,0,0,1.558-1.23l.514-2.209a.333.333,0,0,0-.347-.415Zm3.053-6.715v3.676a1.82,1.82,0,0,1-1.823,1.823H108.567a1.823,1.823,0,0,1-1.823-1.823v-3.676a4.064,4.064,0,0,1,4.059-4.054h27.871a4.063,4.063,0,0,1,4.059,4.054Zm-1.512.046a.343.343,0,0,0-.342-.342,2.587,2.587,0,0,0-1.823.757,1.926,1.926,0,0,1-2.793,0,2.61,2.61,0,0,0-3.676,0,1.924,1.924,0,0,1-2.791,0,2.6,2.6,0,0,0-3.668,0,1.926,1.926,0,0,1-2.793,0,2.6,2.6,0,0,0-3.671,0,1.92,1.92,0,0,1-2.788,0,2.6,2.6,0,0,0-3.671,0,1.92,1.92,0,0,1-2.788,0,2.573,2.573,0,0,0-1.823-.757.342.342,0,1,0,0,.683,1.9,1.9,0,0,1,1.362.615,2.6,2.6,0,0,0,3.673,0,1.928,1.928,0,0,1,2.788,0,2.6,2.6,0,0,0,3.671,0,1.931,1.931,0,0,1,2.81,0,2.594,2.594,0,0,0,3.646,0,1.932,1.932,0,0,1,2.791,0,2.6,2.6,0,0,0,3.673,0,1.932,1.932,0,0,1,2.791,0,2.6,2.6,0,0,0,3.676,0,1.91,1.91,0,0,1,1.4-.6.347.347,0,0,0,.347-.36Zm-8.583-9.567H127a1.959,1.959,0,0,0-1.954,1.954v2.829H134.6v-2.848a1.958,1.958,0,0,0-1.958-1.954Zm-21.867,4.8h3.394l0-2.867a2.644,2.644,0,0,1,2.643-2.638h5.636a2.638,2.638,0,0,1,2.277,1.367A2.638,2.638,0,0,1,127,231.536h5.641a2.641,2.641,0,0,1,2.641,2.638v2.848H139v-6.046a5.994,5.994,0,0,0-5.991-5.981H116.43a5.994,5.994,0,0,0-5.991,5.981v6.059Zm11.672-4.821H116.8a1.958,1.958,0,0,0-1.958,1.954v2.848h9.534v-2.848a1.959,1.959,0,0,0-1.936-1.954Z\" transform=\"translate(-106.744 -224.995)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "FirstAid", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.944\" height=\"26.944\" viewBox=\"0 0 26.944 26.944\">  <path id=\"medical-kit\" d=\"M105.389,105.389v-1.347A4.042,4.042,0,0,1,109.431,100h8.083a4.042,4.042,0,0,1,4.042,4.042v1.347H122.9a4.042,4.042,0,0,1,4.042,4.042V122.9a4.042,4.042,0,0,1-4.042,4.042H104.042A4.042,4.042,0,0,1,100,122.9V109.431a4.042,4.042,0,0,1,4.042-4.042Zm12.125-2.694a1.347,1.347,0,0,1,1.347,1.347v1.347H108.083v-1.347a1.347,1.347,0,0,1,1.347-1.347Zm-9.431,13.472a1.347,1.347,0,0,1,1.347-1.347h2.694v-2.694a1.347,1.347,0,1,1,2.694,0v2.694h2.694a1.347,1.347,0,0,1,0,2.694h-2.694v2.694a1.347,1.347,0,0,1-2.694,0v-2.694h-2.694A1.347,1.347,0,0,1,108.083,116.167Z\" transform=\"translate(-100 -100)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Food", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"33.092\" height=\"27.499\" viewBox=\"0 0 33.092 27.499\">  <path id=\"noun-free-meals-7225002\" d=\"M89.73,173.208H59.98v1.507a1.51,1.51,0,0,0,1.505,1.505H88.223a1.51,1.51,0,0,0,1.505-1.505v-1.507Zm-4.216,4.079H64.2v.174a1.27,1.27,0,0,0,1.265,1.265H84.25a1.27,1.27,0,0,0,1.265-1.265v-.174Zm-6.782-14.259a2.528,2.528,0,0,0,.6,2.169l.03.027h0a2.509,2.509,0,0,0,2.2.572,4.94,4.94,0,0,0,2.661-1.446c.009-.01.019-.022.029-.032h0a5.286,5.286,0,0,0,1.183-1.84,3.606,3.606,0,0,0,.214-1.861h0a.535.535,0,0,1,.155-.475c.869-.839,1.745-1.663,2.613-2.478,1.462-1.375,2.9-2.725,4.162-4.017l.03-.033h0a1.587,1.587,0,0,0,.458-1.057,1.306,1.306,0,0,0-.358-.949l-.029-.026h0a1.3,1.3,0,0,0-.975-.355,1.587,1.587,0,0,0-1.053.485c-1.262,1.29-2.594,2.771-3.95,4.277-.787.875-1.581,1.758-2.4,2.646a.528.528,0,0,1-.49.187,3.624,3.624,0,0,0-1.857.254,5.309,5.309,0,0,0-1.817,1.228,4.955,4.955,0,0,0-1.412,2.717Zm7.712,9.113a1.442,1.442,0,0,0-.576-.846,1.981,1.981,0,0,0-.853-.187,2.016,2.016,0,0,1-1.261-.383,2.515,2.515,0,0,1-.59-.708.834.834,0,0,0-.478-.442,4.583,4.583,0,0,0-1.436.04,6.106,6.106,0,0,1-1.227.069,1.419,1.419,0,0,1-1.2-.826,1.208,1.208,0,0,0-.168-.233,1.9,1.9,0,0,0-2.123-.132,2.633,2.633,0,0,1-1.524.238,1.811,1.811,0,0,1-1-.883,2.178,2.178,0,0,0-.583-.652c-1.568-.875-2.9.576-3.056.744a.428.428,0,0,1-.5.182h0a1.56,1.56,0,0,1-.625-.345c-.54-.4-1.578-1.168-2.558-.233a2.069,2.069,0,0,0-.477,1.1c-.009.045-.017.085-.023.116-.148.682-.266.664-.8.577a.748.748,0,0,0-.168-.013,5.335,5.335,0,0,0-.737.079,2.958,2.958,0,0,0-1.713.857A2.368,2.368,0,0,0,62.218,172q0,.067.009.138H86.444Zm-16.583-2.3a.534.534,0,0,1,1.069,0v.266a.534.534,0,0,1-1.069,0Zm3.077.553a.532.532,0,0,1,.855-.633l.159.217a.532.532,0,1,1-.855.633Zm-8.694.929a.533.533,0,1,1,.366-1l.134.049a.533.533,0,0,1-.366,1Zm13.5-.867a.533.533,0,0,1,.918-.541l.086.147a.533.533,0,0,1-.918.541Zm-10.571-.524a.532.532,0,1,1,.758.747l-.187.19a.532.532,0,1,1-.758-.747Zm.626-12.2a.532.532,0,0,1,.9.567c-.708,1.117-.353,1.57,0,2.018.577.734,1.15,1.464.082,3.153a.532.532,0,0,1-.9-.567c.666-1.054.326-1.489-.019-1.927-.583-.743-1.171-1.491-.062-3.243Zm3.164-3.358a.532.532,0,0,1,.9.567c-.708,1.117-.353,1.57,0,2.018.577.734,1.15,1.464.082,3.153a.532.532,0,1,1-.9-.567c.666-1.054.326-1.489-.019-1.927-.583-.743-1.171-1.491-.062-3.243ZM75.1,159.35a.532.532,0,0,1,.9.567c-.708,1.117-.353,1.57,0,2.018.577.734,1.15,1.464.082,3.153a.532.532,0,0,1-.9-.567c.666-1.054.326-1.489-.019-1.927-.583-.743-1.171-1.491-.062-3.243Z\" transform=\"translate(-59.98 -151.227)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Health";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wellbeing", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"26.944\" height=\"26.944\" viewBox=\"0 0 26.944 26.944\"><path id=\"medical-kit\" d=\"M105.389,105.389v-1.347A4.042,4.042,0,0,1,109.431,100h8.083a4.042,4.042,0,0,1,4.042,4.042v1.347H122.9a4.042,4.042,0,0,1,4.042,4.042V122.9a4.042,4.042,0,0,1-4.042,4.042H104.042A4.042,4.042,0,0,1,100,122.9V109.431a4.042,4.042,0,0,1,4.042-4.042Zm12.125-2.694a1.347,1.347,0,0,1,1.347,1.347v1.347H108.083v-1.347a1.347,1.347,0,0,1,1.347-1.347Zm-9.431,13.472a1.347,1.347,0,0,1,1.347-1.347h2.694v-2.694a1.347,1.347,0,1,1,2.694,0v2.694h2.694a1.347,1.347,0,0,1,0,2.694h-2.694v2.694a1.347,1.347,0,0,1-2.694,0v-2.694h-2.694A1.347,1.347,0,0,1,108.083,116.167Z\" transform=\"translate(-100 -100)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Curtain", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"36.799\" height=\"25.888\" viewBox=\"0 0 36.799 25.888\">  <path id=\"curtain\" d=\"M113.58,163.333c.264,2.64,1.782,11.88,9.108,13.2h.132a14.791,14.791,0,0,1-3.7-9.108.661.661,0,0,1,.66-.66.71.71,0,0,1,.66.66c0,4.488,3.366,8.25,4.158,9.108h1.65a13.805,13.805,0,0,1-.99-8.052.635.635,0,1,1,1.254.2,12.473,12.473,0,0,0,1.188,7.854h1.782s3.976-9.9,0-13.2S113.58,163.333,113.58,163.333ZM128.5,181.219a11.077,11.077,0,0,0-.462,4.686.707.707,0,0,1-.594.726h-.066a.651.651,0,0,1-.66-.594,13.634,13.634,0,0,1,.4-4.818h-1.452a6.532,6.532,0,0,0-1.848,4.752.661.661,0,0,1-.66.66.71.71,0,0,1-.66-.66,8.432,8.432,0,0,1,1.452-4.752h-1.188a8.714,8.714,0,0,0-3.894,6.534h10.626V181.22Zm-25.608,0H101.7a8.433,8.433,0,0,1,1.452,4.752.71.71,0,0,1-.66.66.661.661,0,0,1-.66-.66,6.681,6.681,0,0,0-1.848-4.752H98.532a13.456,13.456,0,0,1,.4,4.818.651.651,0,0,1-.66.594.624.624,0,0,1-.594-.726,11.254,11.254,0,0,0-.462-4.686h-.99v6.534h10.626a8.685,8.685,0,0,0-3.96-6.534Zm-6.666-17.886c-3.976,3.3,0,13.2,0,13.2H98a12.719,12.719,0,0,0,1.188-7.854.618.618,0,0,1,.528-.726.654.654,0,0,1,.726.528,14.382,14.382,0,0,1-.99,8.052h1.65c.792-.858,4.158-4.554,4.158-9.108a.71.71,0,0,1,.66-.66.661.661,0,0,1,.66.66c0,4.026-2.31,7.392-3.7,9.108h.132c7.392-1.386,8.844-10.56,9.108-13.2C112.128,163.332,100.2,160.033,96.222,163.333Zm6.864,14.52H96.222V179.9h6.93a.312.312,0,0,0,.33-.33v-1.32a.38.38,0,0,0-.4-.4Zm19.536,0a.312.312,0,0,0-.33.33v1.32a.312.312,0,0,0,.33.33h6.93v-2.046h-6.93Z\" transform=\"translate(-94.455 -161.866)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Home", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.92\" height=\"27.5\" viewBox=\"0 0 27.92 27.5\">  <path id=\"noun-home-7310393\" d=\"M147.267,140.34a2.564,2.564,0,0,0-1.471.464l-11.117,7.781a3.22,3.22,0,0,0-1.373,2.636v1.329a2,2,0,0,0,1.994,1.994h.332a.655.655,0,0,1,.665.665v10.637a2,2,0,0,0,1.994,1.994h17.948a2,2,0,0,0,1.994-1.994V155.21a.655.655,0,0,1,.665-.665h.332a2,2,0,0,0,1.994-1.994v-1.331a3.225,3.225,0,0,0-1.373-2.638L148.738,140.8a2.564,2.564,0,0,0-1.471-.464Zm-4.654,11.546h9.308a.666.666,0,0,1,.665.665v9.306a.665.665,0,0,1-.665.665h-9.308a.665.665,0,0,1-.665-.665V152.55A.666.666,0,0,1,142.613,151.886Zm.666,1.329v3.325H146.6v-3.325Zm4.654,0v3.325h3.323v-3.325Zm-4.654,4.654v3.323H146.6v-3.323Zm4.654,0v3.323h3.323v-3.323Z\" transform=\"translate(-133.307 -140.34)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "HomeSettings", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.551\" height=\"27.551\" viewBox=\"0 0 27.551 27.551\">  <path id=\"Path_1135\" data-name=\"Path 1135\" d=\"M16.775,2A1.148,1.148,0,0,0,16,2.307l-.025.02L3.451,12.569l-.043.034-.043.036v0a1.147,1.147,0,0,0,.782,1.987H5.3V27.255a2.3,2.3,0,0,0,2.3,2.3H25.959a2.3,2.3,0,0,0,2.3-2.3V14.627H29.4a1.147,1.147,0,0,0,.782-1.987v0l-.018-.013q-.038-.034-.078-.065l-1.834-1.5V6.592a1.148,1.148,0,0,0-1.148-1.148H25.959a1.148,1.148,0,0,0-1.148,1.148V8.244L17.569,2.321l-.016-.013A1.148,1.148,0,0,0,16.775,2Zm-.381,11.479h.765a.766.766,0,0,1,.765.767v.545A4.573,4.573,0,0,1,20.049,16l.462-.264a.764.764,0,0,1,1.045.28l.381.661a.766.766,0,0,1-.278,1.047L21.183,18a4.129,4.129,0,0,1,0,2.437l.473.274a.767.767,0,0,1,.28,1.047l-.383.661a.764.764,0,0,1-1.045.28l-.462-.265a4.583,4.583,0,0,1-2.126,1.213V24.2a.762.762,0,0,1-.765.762h-.765a.766.766,0,0,1-.765-.767v-.545A4.583,4.583,0,0,1,13.5,22.434l-.462.265A.765.765,0,0,1,12,22.419l-.381-.661a.766.766,0,0,1,.278-1.047l.475-.274a4.129,4.129,0,0,1,0-2.437l-.475-.274a.764.764,0,0,1-.278-1.045L12,16.017a.765.765,0,0,1,1.045-.28L13.5,16a4.587,4.587,0,0,1,2.126-1.215v-.545A.765.765,0,0,1,16.394,13.479Zm.381,3.444a2.3,2.3,0,1,0,2.3,2.3A2.3,2.3,0,0,0,16.775,16.923Z\" transform=\"translate(-3 -2)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Living";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Shower", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"27.57\" height=\"27.571\" viewBox=\"0 0 27.57 27.571\">  <path id=\"bathtub\" d=\"M8.957,3.442h1.379a.689.689,0,1,1,0,1.379H6.2a.689.689,0,1,1,0-1.379H7.578V3.1A1.724,1.724,0,0,0,5.855,1.374H4.477A1.718,1.718,0,0,0,2.753,3.1v9.994h8.561a3.4,3.4,0,0,0-.29,1.379v7.582a.691.691,0,0,0,.689.689H19.3a.691.691,0,0,0,.689-.689V15.16a.712.712,0,0,1,.2-.489.682.682,0,0,1,.489-.2h.689s.689-.055.689-.7v-.682h3.791a1.725,1.725,0,0,1,1.22,2.943,1.7,1.7,0,0,1-1.013.489l-1.337,5.81a4.065,4.065,0,0,1-2.661,2.943v.207a2.08,2.08,0,0,1-2.082,2.082H7.592A2.08,2.08,0,0,1,5.51,25.485v-.207A4.1,4.1,0,0,1,2.85,22.335l-1.337-5.81A1.779,1.779,0,0,1,.5,16.035a1.723,1.723,0,0,1,.875-2.909V3.1A3.107,3.107,0,0,1,4.477,0H5.855a3.1,3.1,0,0,1,3.1,3.1Zm9.65,16.542v1.379H12.4V19.984Zm-6.2-1.379V14.47A2.069,2.069,0,0,1,14.471,12.4h5.514a.712.712,0,0,1,.489.2.682.682,0,0,1,.2.489,2.071,2.071,0,0,0-2.068,2.068v3.446ZM5.511,9.646v1.379a.689.689,0,0,0,1.379,0V9.646a.689.689,0,1,0-1.379,0Zm4.136,0v1.379a.689.689,0,0,0,1.379,0V9.646a.689.689,0,1,0-1.379,0Zm-2.068,0v1.379a.689.689,0,0,0,1.379,0V9.646a.689.689,0,1,0-1.379,0ZM6.2,6.2V7.578a.689.689,0,0,0,1.379,0V6.2A.689.689,0,1,0,6.2,6.2Zm2.757,0V7.578a.689.689,0,1,0,1.379,0V6.2a.689.689,0,1,0-1.379,0Z\" transform=\"translate(0.004 0.004)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Car", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"33.969\" height=\"27.499\" viewBox=\"0 0 33.969 27.499\"><path id=\"Path_940\" data-name=\"Path 940\" d=\"M33.625,15.208l-2.689-7.7A5.236,5.236,0,0,0,26,4H11.967A5.233,5.233,0,0,0,7.034,7.507l-2.689,7.7A5.247,5.247,0,0,0,2,19.588V28.88a2.613,2.613,0,1,0,5.226,0V27.228s6.9.342,11.758.342,11.758-.342,11.758-.342V28.88a2.613,2.613,0,1,0,5.226,0V19.588A5.248,5.248,0,0,0,33.625,15.208ZM8,12.659,9.5,8.372a2.614,2.614,0,0,1,2.467-1.753H26a2.614,2.614,0,0,1,2.467,1.753l1.5,4.287a.936.936,0,0,1-1.03,1.24,62.318,62.318,0,0,0-9.952-.733,62.318,62.318,0,0,0-9.952.733A.936.936,0,0,1,8,12.659Zm-.124,9.673a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,7.879,22.332ZM22.9,21.023H15.065a1.309,1.309,0,0,1,0-2.619H22.9a1.309,1.309,0,0,1,0,2.619Zm7.186,1.309a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,30.09,22.332Z\" transform=\"translate(-2 -4)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Cleaning", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28.992\" height=\"26.943\" viewBox=\"0 0 28.992 26.943\">  <path id=\"cleaning\" d=\"M24.958,63.989h5.384c.03,0,.03,0,.03.03v.769c0,.03,0,.03-.03.03H24.958Zm-5.147,0H12.03c-.03,0-.03,0-.03.03v.769c0,.03,0,.03.03.03h7.78ZM40.992,79.2v1.42c0,.325-.207.621-.444.621H26.585a.456.456,0,0,1-.385-.266.109.109,0,0,1-.03-.089,10.2,10.2,0,0,1-.03-1.657.591.591,0,0,1,.444-.621H40.549c.237-.03.444.237.444.592Zm-.888.68a.328.328,0,0,0-.325-.325H27.355a.325.325,0,1,0,0,.651H39.78A.328.328,0,0,0,40.1,79.876Zm-3.668-2.9a.764.764,0,0,0-.769-.769H31.5a.764.764,0,0,0-.769.769v.947h5.71ZM34.218,54.848c-.03-.769-1.3-.71-1.331,0V75.556h1.331ZM19.84,63.338c.059-.355.592-1.42,1.065-.947a.3.3,0,0,1-.059.444,1.127,1.127,0,0,0-.414.828v5.088a.414.414,0,1,0,.828,0V67.214a1.08,1.08,0,0,1,2.16,0v2.722a.429.429,0,0,0,.858,0V63.664a1.32,1.32,0,0,0-1.3-1.006.311.311,0,1,1-.03-.621,1.952,1.952,0,0,1,1.893,1.3h4.082a1.371,1.371,0,0,0-1.361-1.42,1.43,1.43,0,0,0-1.124.592.314.314,0,0,1-.533,0,1.349,1.349,0,0,0-1.035-.592c-.5-.059-.207-.562-.237-.858a1.574,1.574,0,0,0-3.018-.651.325.325,0,0,1-.3.177c-.888-.177.3-1.331.68-1.509a2.354,2.354,0,1,0-4.645.769.323.323,0,0,1-.385.385,1.359,1.359,0,0,0-1.213.828c.3.207.976.858.444,1.154a.294.294,0,0,1-.414-.177.891.891,0,0,0-.828-.562,1.626,1.626,0,0,0-1.6,1.8H19.84Zm7.987,14.585,1.6-12.455H24.958v4.5a1.08,1.08,0,0,1-2.16,0V67.243a.414.414,0,1,0-.828,0v1.538a1.065,1.065,0,1,1-2.13,0V65.5H12.918l1.864,14.614a1.278,1.278,0,0,0,1.272,1.095h9.585a6.536,6.536,0,0,1-.148-2.012,1.194,1.194,0,0,1,1.095-1.272h1.242Z\" transform=\"translate(-12.001 -54.293)\" fill=\"#7c8791\"/></svg>", "");
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm4trn_theme_icon, 0);
         Gxm4trn_theme_icon.gxTpr_Iconcategory = "Services";
         Gxm4trn_theme_icon.gxTpr_Iconname = context.GetMessage( "Wash", "");
         Gxm4trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"22.073\" height=\"27.25\" viewBox=\"0 0 22.073 27.25\"><path id=\"wash\" d=\"M174.541,73.406h19.9a1.09,1.09,0,0,1,1.087,1.087v3.228H173.454V74.493a1.09,1.09,0,0,1,1.087-1.087Zm20.986,5.151v19.41H173.454V78.557Zm0,20.246v.767a1.09,1.09,0,0,1-1.087,1.087h-19.9a1.09,1.09,0,0,1-1.087-1.087V98.8ZM184.49,80.1a8.159,8.159,0,1,0,5.769,2.39A8.134,8.134,0,0,0,184.49,80.1Zm5.178,2.981a7.323,7.323,0,1,0,2.145,5.178A7.3,7.3,0,0,0,189.669,83.082ZM184.49,82.4a5.858,5.858,0,1,0,4.142,1.716A5.838,5.838,0,0,0,184.49,82.4Zm-4.971,5.141c1.786.91,3.595.505,5.428.1a11.525,11.525,0,0,1,4.46-.4,5.022,5.022,0,0,0-9.888.3Zm9.99.566a10.3,10.3,0,0,0-4.381.343c-1.877.42-3.73.834-5.656-.009a5.021,5.021,0,0,0,10.039-.183c0-.051,0-.1,0-.151Zm-3.389-13.094a.756.756,0,1,0,.756.756A.756.756,0,0,0,186.121,75.015Zm3.227,0a.756.756,0,1,0,.756.756A.756.756,0,0,0,189.348,75.015Zm3.227,0a.756.756,0,1,0,.756.756A.756.756,0,0,0,192.575,75.015Z\" transform=\"translate(-173.454 -73.406)\" fill=\"#7c8791\" fill-rule=\"evenodd\"/></svg>", "");
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorOne", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#18668B";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorTwo", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#126E68";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorThree", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#844A27";
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         Gxm1trn_theme.gxTpr_Ctacolor.Add(Gxm5trn_theme_ctacolor, 0);
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorname = context.GetMessage( "CtaColorFour", "");
         Gxm5trn_theme_ctacolor.gxTpr_Ctacolorcode = "#F09605";
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
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm4trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm5trn_theme_ctacolor = new SdtTrn_Theme_CtaColor(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Theme> Gxm2rootcol ;
      private SdtTrn_Theme Gxm1trn_theme ;
      private SdtTrn_Theme_Color Gxm3trn_theme_color ;
      private SdtTrn_Theme_Icon Gxm4trn_theme_icon ;
      private SdtTrn_Theme_CtaColor Gxm5trn_theme_ctacolor ;
      private GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol ;
   }

}
