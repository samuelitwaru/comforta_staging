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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_sendresidentdiscussionnotification : GXProcedure
   {
      public prc_sendresidentdiscussionnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendresidentdiscussionnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           string aP2_ResidentGUID )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV18ResidentGUID = aP2_ResidentGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 string aP2_ResidentGUID )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV18ResidentGUID = aP2_ResidentGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25MyGUID = Guid.NewGuid( );
         AV11TheNotification.gxTpr_Id = AV25MyGUID.ToString();
         AV11TheNotification.gxTpr_Title.gxTpr_Defaulttext = AV10title;
         AV11TheNotification.gxTpr_Text.gxTpr_Defaulttext = AV9message;
         AV15TheNotificationDelivery.gxTpr_Priority = "High";
         AV12TheNotificationConfiguration.gxTpr_Applicationid = "Comforta";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10title)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9message)) )
         {
            AV14IsSuccessful = false;
         }
         else
         {
            /* Using cursor P00A12 */
            pr_default.execute(0, new Object[] {AV18ResidentGUID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A365DeviceUserId = P00A12_A365DeviceUserId[0];
               A363DeviceToken = P00A12_A363DeviceToken[0];
               A361DeviceId = P00A12_A361DeviceId[0];
               AV17DeviceToken = A363DeviceToken;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV12TheNotificationConfiguration,  AV17DeviceToken,  AV11TheNotification,  AV15TheNotificationDelivery, out  AV13OutMessages, out  AV14IsSuccessful) ;
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
         AV25MyGUID = Guid.Empty;
         AV11TheNotification = new GeneXus.Core.genexus.common.notifications.SdtNotification(context);
         AV15TheNotificationDelivery = new GeneXus.Core.genexus.common.notifications.SdtDelivery(context);
         AV12TheNotificationConfiguration = new GeneXus.Core.genexus.common.notifications.SdtConfiguration(context);
         P00A12_A365DeviceUserId = new string[] {""} ;
         P00A12_A363DeviceToken = new string[] {""} ;
         P00A12_A361DeviceId = new string[] {""} ;
         A365DeviceUserId = "";
         A363DeviceToken = "";
         A361DeviceId = "";
         AV17DeviceToken = "";
         AV13OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentdiscussionnotification__default(),
            new Object[][] {
                new Object[] {
               P00A12_A365DeviceUserId, P00A12_A363DeviceToken, P00A12_A361DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A363DeviceToken ;
      private string A361DeviceId ;
      private string AV17DeviceToken ;
      private bool AV14IsSuccessful ;
      private string AV10title ;
      private string AV9message ;
      private string AV18ResidentGUID ;
      private string A365DeviceUserId ;
      private Guid AV25MyGUID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV11TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV15TheNotificationDelivery ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV12TheNotificationConfiguration ;
      private IDataStoreProvider pr_default ;
      private string[] P00A12_A365DeviceUserId ;
      private string[] P00A12_A363DeviceToken ;
      private string[] P00A12_A361DeviceId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13OutMessages ;
   }

   public class prc_sendresidentdiscussionnotification__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A12;
          prmP00A12 = new Object[] {
          new ParDef("AV18ResidentGUID",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00A12", "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device WHERE DeviceUserId = ( RTRIM(LTRIM(:AV18ResidentGUID))) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A12,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1000);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                return;
       }
    }

 }

}