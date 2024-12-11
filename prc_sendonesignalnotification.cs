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
   public class prc_sendonesignalnotification : GXProcedure
   {
      public prc_sendonesignalnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendonesignalnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_DeviceToken )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_DeviceToken )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11HttpClient.Host = "onesignal.com";
         AV11HttpClient.BaseURL = "/api/v1";
         AV11HttpClient.Secure = 1;
         AV11HttpClient.AddHeader("Authorization", "Basic MzcxMmQwYzYtNjUyYi00OTk2LWFjZmQtY2Y1MDIyNjU4NWQ1");
         AV11HttpClient.AddHeader("Content-Type", "application/json");
         if ( AV16SDT_OneSignalRegistration.FromJSonString(AV9DeviceToken, null) )
         {
            AV18Token = AV16SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
         }
         AV15SDT_OneSignalCustomBody = new SdtSDT_OneSignalCustomBody(context);
         AV15SDT_OneSignalCustomBody.gxTpr_App_id = "04453574-cfee-45bc-adef-888ecdaa0707";
         AV15SDT_OneSignalCustomBody.gxTpr_Include_player_ids.Add(AV18Token, 0);
         AV15SDT_OneSignalCustomBody.gxTpr_Headings.gxTpr_En = "Custom Notification Sending";
         AV15SDT_OneSignalCustomBody.gxTpr_Contents.gxTpr_En = "This is a custom notification to test extra data.";
         AV19DataItem = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(context);
         AV19DataItem.gxTpr_Key = "Id";
         AV19DataItem.gxTpr_Value = "4587547-cgfr-4532-de4r-3449483434";
         AV20SDT_OneSignalCustomData.Add(AV19DataItem, 0);
         AV19DataItem = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(context);
         AV19DataItem.gxTpr_Key = "DynamicForm";
         AV19DataItem.gxTpr_Value = "Resident Dynamic Form Id";
         AV20SDT_OneSignalCustomData.Add(AV19DataItem, 0);
         AV19DataItem = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(context);
         AV19DataItem.gxTpr_Key = "Discussion";
         AV19DataItem.gxTpr_Value = "Resident Discussion Id";
         AV20SDT_OneSignalCustomData.Add(AV19DataItem, 0);
         AV19DataItem = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(context);
         AV19DataItem.gxTpr_Key = "Agenda";
         AV19DataItem.gxTpr_Value = "Agenda Event Id";
         AV20SDT_OneSignalCustomData.Add(AV19DataItem, 0);
         AV15SDT_OneSignalCustomBody.gxTpr_Data.gxTpr_Items = AV20SDT_OneSignalCustomData;
         AV8body = AV15SDT_OneSignalCustomBody.ToJSonString(false, true);
         AV11HttpClient.AddString(AV8body);
         AV11HttpClient.Execute("POST", "notifications");
         if ( AV11HttpClient.StatusCode == 200 )
         {
            new prc_logtofile(context ).execute(  "Notification Sent:") ;
         }
         else
         {
            new prc_logtofile(context ).execute(  "Notification Error:"+AV11HttpClient.ErrDescription) ;
            new prc_logtofile(context ).execute(  "Notification Body:"+AV11HttpClient.ToString()) ;
            new prc_logtofile(context ).execute(  "Title:"+AV8body) ;
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
         AV11HttpClient = new GxHttpClient( context);
         AV16SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV18Token = "";
         AV15SDT_OneSignalCustomBody = new SdtSDT_OneSignalCustomBody(context);
         AV19DataItem = new SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem(context);
         AV20SDT_OneSignalCustomData = new GXBaseCollection<SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem>( context, "SDT_OneSignalCustomDataItem", "Comforta_version2");
         AV8body = "";
         /* GeneXus formulas. */
      }

      private string AV9DeviceToken ;
      private string AV8body ;
      private string AV18Token ;
      private GxHttpClient AV11HttpClient ;
      private SdtSDT_OneSignalRegistration AV16SDT_OneSignalRegistration ;
      private SdtSDT_OneSignalCustomBody AV15SDT_OneSignalCustomBody ;
      private SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem AV19DataItem ;
      private GXBaseCollection<SdtSDT_OneSignalCustomData_SDT_OneSignalCustomDataItem> AV20SDT_OneSignalCustomData ;
   }

}
