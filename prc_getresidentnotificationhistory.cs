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
   public class prc_getresidentnotificationhistory : GXProcedure
   {
      public prc_getresidentnotificationhistory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentnotificationhistory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           out string aP1_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV11result = "" ;
         initialize();
         ExecuteImpl();
         aP1_result=this.AV11result;
      }

      public string executeUdp( string aP0_ResidentGUID )
      {
         execute(aP0_ResidentGUID, out aP1_result);
         return AV11result ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 out string aP1_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV11result = "" ;
         SubmitImpl();
         aP1_result=this.AV11result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009O2 */
         pr_default.execute(0, new Object[] {AV8ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P009O2_A71ResidentGUID[0];
            A11OrganisationId = P009O2_A11OrganisationId[0];
            A29LocationId = P009O2_A29LocationId[0];
            A62ResidentId = P009O2_A62ResidentId[0];
            AV13Trn_Resident.Load(A62ResidentId, A29LocationId, A11OrganisationId);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13Trn_Resident.Success() )
         {
            AV12SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version2");
            /* Using cursor P009O3 */
            pr_default.execute(1, new Object[] {AV13Trn_Resident.gxTpr_Residentid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A501AppNotificationDate = P009O3_A501AppNotificationDate[0];
               A498AppNotificationId = P009O3_A498AppNotificationId[0];
               A499AppNotificationTitle = P009O3_A499AppNotificationTitle[0];
               A502AppNotificationTopic = P009O3_A502AppNotificationTopic[0];
               A500AppNotificationDescription = P009O3_A500AppNotificationDescription[0];
               A62ResidentId = P009O3_A62ResidentId[0];
               A497ResidentNotificationId = P009O3_A497ResidentNotificationId[0];
               A501AppNotificationDate = P009O3_A501AppNotificationDate[0];
               A499AppNotificationTitle = P009O3_A499AppNotificationTitle[0];
               A502AppNotificationTopic = P009O3_A502AppNotificationTopic[0];
               A500AppNotificationDescription = P009O3_A500AppNotificationDescription[0];
               /* Using cursor P009O4 */
               pr_default.execute(2, new Object[] {A498AppNotificationId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  AV10ResidentNotificationItem = new SdtSDT_ResidentNotification(context);
                  AV10ResidentNotificationItem.gxTpr_Notificationdate = A501AppNotificationDate;
                  AV10ResidentNotificationItem.gxTpr_Notificationid = A498AppNotificationId;
                  AV10ResidentNotificationItem.gxTpr_Notificationtitle = A499AppNotificationTitle;
                  AV10ResidentNotificationItem.gxTpr_Notificationtopic = A502AppNotificationTopic;
                  AV10ResidentNotificationItem.gxTpr_Notificationdescription = A500AppNotificationDescription;
                  AV12SDT_ResidentNotification.Add(AV10ResidentNotificationItem, 0);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         AV11result = AV12SDT_ResidentNotification.ToJSonString(false);
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
         AV11result = "";
         P009O2_A71ResidentGUID = new string[] {""} ;
         P009O2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009O2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009O2_A62ResidentId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV13Trn_Resident = new SdtTrn_Resident(context);
         AV12SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version2");
         P009O3_A501AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         P009O3_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         P009O3_A499AppNotificationTitle = new string[] {""} ;
         P009O3_A502AppNotificationTopic = new string[] {""} ;
         P009O3_A500AppNotificationDescription = new string[] {""} ;
         P009O3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009O3_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         A501AppNotificationDate = (DateTime)(DateTime.MinValue);
         A498AppNotificationId = Guid.Empty;
         A499AppNotificationTitle = "";
         A502AppNotificationTopic = "";
         A500AppNotificationDescription = "";
         A497ResidentNotificationId = Guid.Empty;
         P009O4_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         AV10ResidentNotificationItem = new SdtSDT_ResidentNotification(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentnotificationhistory__default(),
            new Object[][] {
                new Object[] {
               P009O2_A71ResidentGUID, P009O2_A11OrganisationId, P009O2_A29LocationId, P009O2_A62ResidentId
               }
               , new Object[] {
               P009O3_A501AppNotificationDate, P009O3_A498AppNotificationId, P009O3_A499AppNotificationTitle, P009O3_A502AppNotificationTopic, P009O3_A500AppNotificationDescription, P009O3_A62ResidentId, P009O3_A497ResidentNotificationId
               }
               , new Object[] {
               P009O4_A498AppNotificationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A501AppNotificationDate ;
      private string AV11result ;
      private string AV8ResidentGUID ;
      private string A71ResidentGUID ;
      private string A499AppNotificationTitle ;
      private string A502AppNotificationTopic ;
      private string A500AppNotificationDescription ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A498AppNotificationId ;
      private Guid A497ResidentNotificationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009O2_A71ResidentGUID ;
      private Guid[] P009O2_A11OrganisationId ;
      private Guid[] P009O2_A29LocationId ;
      private Guid[] P009O2_A62ResidentId ;
      private SdtTrn_Resident AV13Trn_Resident ;
      private GXBaseCollection<SdtSDT_ResidentNotification> AV12SDT_ResidentNotification ;
      private DateTime[] P009O3_A501AppNotificationDate ;
      private Guid[] P009O3_A498AppNotificationId ;
      private string[] P009O3_A499AppNotificationTitle ;
      private string[] P009O3_A502AppNotificationTopic ;
      private string[] P009O3_A500AppNotificationDescription ;
      private Guid[] P009O3_A62ResidentId ;
      private Guid[] P009O3_A497ResidentNotificationId ;
      private Guid[] P009O4_A498AppNotificationId ;
      private SdtSDT_ResidentNotification AV10ResidentNotificationItem ;
      private string aP1_result ;
   }

   public class prc_getresidentnotificationhistory__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009O2;
          prmP009O2 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60)
          };
          Object[] prmP009O3;
          prmP009O3 = new Object[] {
          new ParDef("AV13Trn_Resident__Residentid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009O4;
          prmP009O4 = new Object[] {
          new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009O2", "SELECT ResidentGUID, OrganisationId, LocationId, ResidentId FROM Trn_Resident WHERE ResidentGUID = ( :AV8ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P009O3", "SELECT T2.AppNotificationDate, T1.AppNotificationId, T2.AppNotificationTitle, T2.AppNotificationTopic, T2.AppNotificationDescription, T1.ResidentId, T1.ResidentNotificationId FROM (Trn_ResidentNotification T1 INNER JOIN Trn_AppNotification T2 ON T2.AppNotificationId = T1.AppNotificationId) WHERE T1.ResidentId = :AV13Trn_Resident__Residentid ORDER BY T1.ResidentNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009O4", "SELECT AppNotificationId FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ORDER BY AppNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
