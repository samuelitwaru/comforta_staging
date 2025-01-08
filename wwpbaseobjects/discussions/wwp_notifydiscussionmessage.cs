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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_notifydiscussionmessage : GXProcedure
   {
      public wwp_notifydiscussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notifydiscussionmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPUserExtendedFullName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPDiscussionMessageEntityRecordId ,
                           string aP3_MentionWWPUserExtendedIdCollectionJson ,
                           string aP4_SessionValue ,
                           string aP5_NotificationTitle ,
                           string aP6_WWPSubscriptionEntityRecordDescription ,
                           string aP7_WWPNotificationLink )
      {
         this.AV23WWPUserExtendedFullName = aP0_WWPUserExtendedFullName;
         this.AV24WWPEntityName = aP1_WWPEntityName;
         this.AV15WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV21MentionWWPUserExtendedIdCollectionJson = aP3_MentionWWPUserExtendedIdCollectionJson;
         this.AV14SessionValue = aP4_SessionValue;
         this.AV8NotificationTitle = aP5_NotificationTitle;
         this.AV19WWPSubscriptionEntityRecordDescription = aP6_WWPSubscriptionEntityRecordDescription;
         this.AV18WWPNotificationLink = aP7_WWPNotificationLink;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_WWPUserExtendedFullName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPDiscussionMessageEntityRecordId ,
                                 string aP3_MentionWWPUserExtendedIdCollectionJson ,
                                 string aP4_SessionValue ,
                                 string aP5_NotificationTitle ,
                                 string aP6_WWPSubscriptionEntityRecordDescription ,
                                 string aP7_WWPNotificationLink )
      {
         this.AV23WWPUserExtendedFullName = aP0_WWPUserExtendedFullName;
         this.AV24WWPEntityName = aP1_WWPEntityName;
         this.AV15WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV21MentionWWPUserExtendedIdCollectionJson = aP3_MentionWWPUserExtendedIdCollectionJson;
         this.AV14SessionValue = aP4_SessionValue;
         this.AV8NotificationTitle = aP5_NotificationTitle;
         this.AV19WWPSubscriptionEntityRecordDescription = aP6_WWPSubscriptionEntityRecordDescription;
         this.AV18WWPNotificationLink = aP7_WWPNotificationLink;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV24WWPEntityName, "WWP_DynamicForm") == 0 )
         {
            AV24WWPEntityName = "Discussion";
            AV25NotificationDefinitionName = "GeneralDiscussion";
         }
         else
         {
            AV25NotificationDefinitionName = "Discussion";
         }
         AV9WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV9WWPNotificationMetadataSDT.gxTpr_Sessionkey = "DiscussionThreadIdToOpen";
         AV9WWPNotificationMetadataSDT.gxTpr_Sessionvalue = AV14SessionValue;
         AV27SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV27SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
         AV27SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Trim( AV15WWPDiscussionMessageEntityRecordId);
         AV27SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
         AV27SDT_NotificationMetadata.gxTpr_Notificationorigin = "Discussions";
         AV9WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV27SDT_NotificationMetadata;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MentionWWPUserExtendedIdCollectionJson)) )
         {
            GXt_char1 = AV10WWPNotificationShortDescription;
            new prc_getentitynamedescription(context ).execute(  StringUtil.Trim( AV24WWPEntityName)) ;
            AV10WWPNotificationShortDescription = StringUtil.Format( context.GetMessage( "WWP_Notifications_MentionShortMessage", ""), StringUtil.Trim( AV23WWPUserExtendedFullName), GXt_char1, AV19WWPSubscriptionEntityRecordDescription, "", "", "", "", "", "");
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendmentionnotification(context ).execute(  "Mention",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  "fas fa-at NotificationFontIconInfoLight",  context.GetMessage( "WWP_Notifications_NewMention", ""),  AV10WWPNotificationShortDescription,  AV10WWPNotificationShortDescription,  AV18WWPNotificationLink,  AV9WWPNotificationMetadataSDT.ToJSonString(false, true),  AV21MentionWWPUserExtendedIdCollectionJson) ;
            new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion(context ).execute(  "GeneralDiscussion",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  AV19WWPSubscriptionEntityRecordDescription,  AV21MentionWWPUserExtendedIdCollectionJson) ;
         }
         GXt_objcol_svchar2 = AV26ReceptionistsToNotify;
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         new prc_getlocationreceptioniststonotify(context ).execute(  GXt_char1, out  GXt_objcol_svchar2) ;
         AV26ReceptionistsToNotify = GXt_objcol_svchar2;
         new prc_subscribereceptioniststodiscussion(context ).execute(  "GeneralDiscussion",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  AV19WWPSubscriptionEntityRecordDescription,  AV26ReceptionistsToNotify.ToJSonString(false)) ;
         AV10WWPNotificationShortDescription = StringUtil.Format( context.GetMessage( "%1 added a comment on a discussion related to: %2", ""), StringUtil.Trim( AV23WWPUserExtendedFullName), AV19WWPSubscriptionEntityRecordDescription, "", "", "", "", "", "", "");
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  AV25NotificationDefinitionName,  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  "far fa-comment-dots NotificationFontIconInfo",  AV8NotificationTitle,  AV10WWPNotificationShortDescription,  AV10WWPNotificationShortDescription,  AV18WWPNotificationLink,  AV9WWPNotificationMetadataSDT.ToJSonString(false, true),  AV21MentionWWPUserExtendedIdCollectionJson,  true) ;
         new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion(context ).execute(  AV25NotificationDefinitionName,  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  AV19WWPSubscriptionEntityRecordDescription) ;
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
         AV25NotificationDefinitionName = "";
         AV9WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV27SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV10WWPNotificationShortDescription = "";
         AV26ReceptionistsToNotify = new GxSimpleCollection<string>();
         GXt_objcol_svchar2 = new GxSimpleCollection<string>();
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV21MentionWWPUserExtendedIdCollectionJson ;
      private string AV23WWPUserExtendedFullName ;
      private string AV24WWPEntityName ;
      private string AV15WWPDiscussionMessageEntityRecordId ;
      private string AV14SessionValue ;
      private string AV8NotificationTitle ;
      private string AV19WWPSubscriptionEntityRecordDescription ;
      private string AV18WWPNotificationLink ;
      private string AV25NotificationDefinitionName ;
      private string AV10WWPNotificationShortDescription ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata AV9WWPNotificationMetadataSDT ;
      private SdtSDT_NotificationMetadata AV27SDT_NotificationMetadata ;
      private GxSimpleCollection<string> AV26ReceptionistsToNotify ;
      private GxSimpleCollection<string> GXt_objcol_svchar2 ;
   }

}
