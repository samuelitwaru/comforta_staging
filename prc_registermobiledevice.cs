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
   public class prc_registermobiledevice : GXProcedure
   {
      public prc_registermobiledevice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_registermobiledevice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DeviceToken ,
                           string aP1_DeviceId ,
                           short aP2_DeviceType ,
                           string aP3_NotificationPlatform ,
                           string aP4_NotificationPlatformId ,
                           string aP5_UserId ,
                           out string aP6_Message )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceType = aP2_DeviceType;
         this.AV12NotificationPlatform = aP3_NotificationPlatform;
         this.AV13NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV14UserId = aP5_UserId;
         this.AV11Message = "" ;
         initialize();
         ExecuteImpl();
         aP6_Message=this.AV11Message;
      }

      public string executeUdp( string aP0_DeviceToken ,
                                string aP1_DeviceId ,
                                short aP2_DeviceType ,
                                string aP3_NotificationPlatform ,
                                string aP4_NotificationPlatformId ,
                                string aP5_UserId )
      {
         execute(aP0_DeviceToken, aP1_DeviceId, aP2_DeviceType, aP3_NotificationPlatform, aP4_NotificationPlatformId, aP5_UserId, out aP6_Message);
         return AV11Message ;
      }

      public void executeSubmit( string aP0_DeviceToken ,
                                 string aP1_DeviceId ,
                                 short aP2_DeviceType ,
                                 string aP3_NotificationPlatform ,
                                 string aP4_NotificationPlatformId ,
                                 string aP5_UserId ,
                                 out string aP6_Message )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceType = aP2_DeviceType;
         this.AV12NotificationPlatform = aP3_NotificationPlatform;
         this.AV13NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV14UserId = aP5_UserId;
         this.AV11Message = "" ;
         SubmitImpl();
         aP6_Message=this.AV11Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV16SDT_OneSignalRegistration.gxTpr_Deviceid = AV8DeviceId;
         AV16SDT_OneSignalRegistration.gxTpr_Devicetoken = AV9DeviceToken;
         AV16SDT_OneSignalRegistration.gxTpr_Devicetype = (decimal)(AV10DeviceType);
         AV16SDT_OneSignalRegistration.gxTpr_Notificationplatform = AV12NotificationPlatform;
         AV16SDT_OneSignalRegistration.gxTpr_Notificationplatformid = AV13NotificationPlatformId;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DeviceToken)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8DeviceId)) )
         {
            AV11Message = "Device could not be registered";
         }
         else
         {
            AV17GXLvl13 = 0;
            /* Using cursor P007T2 */
            pr_default.execute(0, new Object[] {AV8DeviceId, AV10DeviceType});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A361DeviceId = P007T2_A361DeviceId[0];
               A362DeviceType = P007T2_A362DeviceType[0];
               A363DeviceToken = P007T2_A363DeviceToken[0];
               A364DeviceName = P007T2_A364DeviceName[0];
               AV17GXLvl13 = 1;
               A363DeviceToken = AV16SDT_OneSignalRegistration.ToJSonString(false, true);
               A364DeviceName = AV8DeviceId;
               /* Using cursor P007T3 */
               pr_default.execute(1, new Object[] {A363DeviceToken, A364DeviceName, A361DeviceId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV17GXLvl13 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE Trn_Device

               */
               A362DeviceType = AV10DeviceType;
               A361DeviceId = AV8DeviceId;
               A363DeviceToken = AV16SDT_OneSignalRegistration.ToJSonString(false, true);
               A364DeviceName = AV8DeviceId;
               A365DeviceUserId = AV14UserId;
               /* Using cursor P007T4 */
               pr_default.execute(2, new Object[] {A361DeviceId, A362DeviceType, A363DeviceToken, A364DeviceName, A365DeviceUserId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
               if ( (pr_default.getStatus(2) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
            AV11Message = "Device registered successfully";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_registermobiledevice",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Message = "";
         AV16SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         P007T2_A361DeviceId = new string[] {""} ;
         P007T2_A362DeviceType = new short[1] ;
         P007T2_A363DeviceToken = new string[] {""} ;
         P007T2_A364DeviceName = new string[] {""} ;
         A361DeviceId = "";
         A363DeviceToken = "";
         A364DeviceName = "";
         A365DeviceUserId = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_registermobiledevice__default(),
            new Object[][] {
                new Object[] {
               P007T2_A361DeviceId, P007T2_A362DeviceType, P007T2_A363DeviceToken, P007T2_A364DeviceName
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10DeviceType ;
      private short AV17GXLvl13 ;
      private short A362DeviceType ;
      private int GX_INS78 ;
      private string AV9DeviceToken ;
      private string AV8DeviceId ;
      private string A361DeviceId ;
      private string A363DeviceToken ;
      private string A364DeviceName ;
      private string Gx_emsg ;
      private string AV11Message ;
      private string AV12NotificationPlatform ;
      private string AV13NotificationPlatformId ;
      private string AV14UserId ;
      private string A365DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OneSignalRegistration AV16SDT_OneSignalRegistration ;
      private IDataStoreProvider pr_default ;
      private string[] P007T2_A361DeviceId ;
      private short[] P007T2_A362DeviceType ;
      private string[] P007T2_A363DeviceToken ;
      private string[] P007T2_A364DeviceName ;
      private string aP6_Message ;
   }

   public class prc_registermobiledevice__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007T2;
          prmP007T2 = new Object[] {
          new ParDef("AV8DeviceId",GXType.Char,128,0) ,
          new ParDef("AV10DeviceType",GXType.Int16,1,0)
          };
          Object[] prmP007T3;
          prmP007T3 = new Object[] {
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceId",GXType.Char,128,0)
          };
          Object[] prmP007T4;
          prmP007T4 = new Object[] {
          new ParDef("DeviceId",GXType.Char,128,0) ,
          new ParDef("DeviceType",GXType.Int16,1,0) ,
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceUserId",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P007T2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName FROM Trn_Device WHERE (DeviceId = ( :AV8DeviceId)) AND (DeviceType = :AV10DeviceType) ORDER BY DeviceId  FOR UPDATE OF Trn_Device",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007T3", "SAVEPOINT gxupdate;UPDATE Trn_Device SET DeviceToken=:DeviceToken, DeviceName=:DeviceName  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007T3)
             ,new CursorDef("P007T4", "SAVEPOINT gxupdate;INSERT INTO Trn_Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP007T4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1000);
                ((string[]) buf[3])[0] = rslt.getString(4, 128);
                return;
       }
    }

 }

}
