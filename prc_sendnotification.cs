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
   public class prc_sendnotification : GXProcedure
   {
      public prc_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           out string aP2_response )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV8response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV8response;
      }

      public string executeUdp( string aP0_title ,
                                string aP1_message )
      {
         execute(aP0_title, aP1_message, out aP2_response);
         return AV8response ;
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 out string aP2_response )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV8response = "" ;
         SubmitImpl();
         aP2_response=this.AV8response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10title)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9message)) )
         {
            AV14IsSuccessful = false;
         }
         else
         {
            /* Using cursor P007U2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A363DeviceToken = P007U2_A363DeviceToken[0];
               A361DeviceId = P007U2_A361DeviceId[0];
               AV26Token = "";
               if ( AV25SDT_OneSignalRegistration.FromJSonString(A363DeviceToken, null) )
               {
                  AV26Token = AV25SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Token)) )
                  {
                     AV24DeviceTokenCollection.Add(AV26Token, 0);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV24DeviceTokenCollection.Count > 0 )
            {
               AV27Metadata = new SdtSDT_OneSignalCustomData(context);
               AV27Metadata.gxTpr_Notificationcategory = "General";
               new prc_sendonesignalnotification(context ).execute(  AV24DeviceTokenCollection,  AV10title,  AV9message,  AV27Metadata, out  AV13OutMessages, out  AV14IsSuccessful) ;
            }
            if ( AV14IsSuccessful )
            {
               AV8response = "Notification sent successfully";
            }
            else
            {
               AV8response = "Notification could not be sent " + AV13OutMessages;
            }
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
         AV8response = "";
         P007U2_A363DeviceToken = new string[] {""} ;
         P007U2_A361DeviceId = new string[] {""} ;
         A363DeviceToken = "";
         A361DeviceId = "";
         AV26Token = "";
         AV25SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV24DeviceTokenCollection = new GxSimpleCollection<string>();
         AV27Metadata = new SdtSDT_OneSignalCustomData(context);
         AV13OutMessages = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P007U2_A363DeviceToken, P007U2_A361DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A363DeviceToken ;
      private string A361DeviceId ;
      private string AV26Token ;
      private bool AV14IsSuccessful ;
      private string AV8response ;
      private string AV13OutMessages ;
      private string AV10title ;
      private string AV9message ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007U2_A363DeviceToken ;
      private string[] P007U2_A361DeviceId ;
      private SdtSDT_OneSignalRegistration AV25SDT_OneSignalRegistration ;
      private GxSimpleCollection<string> AV24DeviceTokenCollection ;
      private SdtSDT_OneSignalCustomData AV27Metadata ;
      private string aP2_response ;
   }

   public class prc_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007U2;
          prmP007U2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P007U2", "SELECT DeviceToken, DeviceId FROM Trn_Device ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1000);
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
                return;
       }
    }

 }

}
