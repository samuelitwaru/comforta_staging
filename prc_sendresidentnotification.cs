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
   public class prc_sendresidentnotification : GXProcedure
   {
      public prc_sendresidentnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendresidentnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           string aP2_topic ,
                           GxSimpleCollection<Guid> aP3_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV23topic = aP2_topic;
         this.AV16ResidentIdCollection = aP3_ResidentIdCollection;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 string aP2_topic ,
                                 GxSimpleCollection<Guid> aP3_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV23topic = aP2_topic;
         this.AV16ResidentIdCollection = aP3_ResidentIdCollection;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
            AV22Trn_AppNotification = new SdtTrn_AppNotification(context);
            AV22Trn_AppNotification.gxTpr_Appnotificationid = Guid.NewGuid( );
            AV22Trn_AppNotification.gxTpr_Appnotificationdate = DateTimeUtil.Now( context);
            AV22Trn_AppNotification.gxTpr_Appnotificationtitle = AV10title;
            AV22Trn_AppNotification.gxTpr_Appnotificationdescription = AV9message;
            AV22Trn_AppNotification.gxTpr_Appnotificationtopic = AV23topic;
            AV22Trn_AppNotification.Save();
            if ( AV16ResidentIdCollection.Count > 0 )
            {
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    A62ResidentId ,
                                                    AV16ResidentIdCollection } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P009F2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A62ResidentId = P009F2_A62ResidentId[0];
                  A71ResidentGUID = P009F2_A71ResidentGUID[0];
                  A29LocationId = P009F2_A29LocationId[0];
                  A11OrganisationId = P009F2_A11OrganisationId[0];
                  AV19ResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
            }
            else
            {
               AV28Udparg1 = new prc_getuserlocationid(context).executeUdp( );
               /* Using cursor P009F3 */
               pr_default.execute(1, new Object[] {AV28Udparg1});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A29LocationId = P009F3_A29LocationId[0];
                  A71ResidentGUID = P009F3_A71ResidentGUID[0];
                  A62ResidentId = P009F3_A62ResidentId[0];
                  A11OrganisationId = P009F3_A11OrganisationId[0];
                  AV19ResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            if ( AV19ResidentGUIDCollection.Count > 0 )
            {
               if ( AV22Trn_AppNotification.Success() )
               {
                  AV29GXV1 = 1;
                  while ( AV29GXV1 <= AV19ResidentGUIDCollection.Count )
                  {
                     AV25ResidentGUIDItem = ((string)AV19ResidentGUIDCollection.Item(AV29GXV1));
                     AV24Trn_ResidentNotification.gxTpr_Appnotificationid = AV22Trn_AppNotification.gxTpr_Appnotificationid;
                     GXt_guid1 = Guid.Empty;
                     new prc_getresidentidfromguid(context ).execute(  AV25ResidentGUIDItem, out  GXt_guid1) ;
                     AV24Trn_ResidentNotification.gxTpr_Residentid = GXt_guid1;
                     AV24Trn_ResidentNotification.gxTpr_Residentnotificationid = Guid.NewGuid( );
                     AV24Trn_ResidentNotification.Insert();
                     AV29GXV1 = (int)(AV29GXV1+1);
                  }
               }
               context.CommitDataStores("prc_sendresidentnotification",pr_default);
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    A365DeviceUserId ,
                                                    AV19ResidentGUIDCollection } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P009F4 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A365DeviceUserId = P009F4_A365DeviceUserId[0];
                  A363DeviceToken = P009F4_A363DeviceToken[0];
                  A361DeviceId = P009F4_A361DeviceId[0];
                  AV21DeviceTokenCollection.Add(A363DeviceToken, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            AV31GXV2 = 1;
            while ( AV31GXV2 <= AV21DeviceTokenCollection.Count )
            {
               AV17DeviceToken = AV21DeviceTokenCollection.GetString(AV31GXV2);
               new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV12TheNotificationConfiguration,  AV17DeviceToken,  AV11TheNotification,  AV15TheNotificationDelivery, out  AV13OutMessages, out  AV14IsSuccessful) ;
               AV31GXV2 = (int)(AV31GXV2+1);
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
         AV11TheNotification = new GeneXus.Core.genexus.common.notifications.SdtNotification(context);
         AV15TheNotificationDelivery = new GeneXus.Core.genexus.common.notifications.SdtDelivery(context);
         AV12TheNotificationConfiguration = new GeneXus.Core.genexus.common.notifications.SdtConfiguration(context);
         AV22Trn_AppNotification = new SdtTrn_AppNotification(context);
         A62ResidentId = Guid.Empty;
         P009F2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009F2_A71ResidentGUID = new string[] {""} ;
         P009F2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009F2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV19ResidentGUIDCollection = new GxSimpleCollection<string>();
         AV28Udparg1 = Guid.Empty;
         P009F3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009F3_A71ResidentGUID = new string[] {""} ;
         P009F3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009F3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV25ResidentGUIDItem = "";
         AV24Trn_ResidentNotification = new SdtTrn_ResidentNotification(context);
         GXt_guid1 = Guid.Empty;
         A365DeviceUserId = "";
         P009F4_A365DeviceUserId = new string[] {""} ;
         P009F4_A363DeviceToken = new string[] {""} ;
         P009F4_A361DeviceId = new string[] {""} ;
         A363DeviceToken = "";
         A361DeviceId = "";
         AV21DeviceTokenCollection = new GxSimpleCollection<string>();
         AV17DeviceToken = "";
         AV13OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__default(),
            new Object[][] {
                new Object[] {
               P009F2_A62ResidentId, P009F2_A71ResidentGUID, P009F2_A29LocationId, P009F2_A11OrganisationId
               }
               , new Object[] {
               P009F3_A29LocationId, P009F3_A71ResidentGUID, P009F3_A62ResidentId, P009F3_A11OrganisationId
               }
               , new Object[] {
               P009F4_A365DeviceUserId, P009F4_A363DeviceToken, P009F4_A361DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV29GXV1 ;
      private int AV31GXV2 ;
      private string A363DeviceToken ;
      private string A361DeviceId ;
      private string AV17DeviceToken ;
      private bool AV14IsSuccessful ;
      private string AV10title ;
      private string AV9message ;
      private string AV23topic ;
      private string A71ResidentGUID ;
      private string AV25ResidentGUIDItem ;
      private string A365DeviceUserId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV28Udparg1 ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV16ResidentIdCollection ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV11TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV15TheNotificationDelivery ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV12TheNotificationConfiguration ;
      private SdtTrn_AppNotification AV22Trn_AppNotification ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009F2_A62ResidentId ;
      private string[] P009F2_A71ResidentGUID ;
      private Guid[] P009F2_A29LocationId ;
      private Guid[] P009F2_A11OrganisationId ;
      private GxSimpleCollection<string> AV19ResidentGUIDCollection ;
      private Guid[] P009F3_A29LocationId ;
      private string[] P009F3_A71ResidentGUID ;
      private Guid[] P009F3_A62ResidentId ;
      private Guid[] P009F3_A11OrganisationId ;
      private SdtTrn_ResidentNotification AV24Trn_ResidentNotification ;
      private string[] P009F4_A365DeviceUserId ;
      private string[] P009F4_A363DeviceToken ;
      private string[] P009F4_A361DeviceId ;
      private GxSimpleCollection<string> AV21DeviceTokenCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13OutMessages ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_sendresidentnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_sendresidentnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_sendresidentnotification__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P009F2( IGxContext context ,
                                          Guid A62ResidentId ,
                                          GxSimpleCollection<Guid> AV16ResidentIdCollection )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT ResidentId, ResidentGUID, LocationId, OrganisationId FROM Trn_Resident";
      AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV16ResidentIdCollection, "ResidentId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY ResidentId, LocationId, OrganisationId";
      GXv_Object2[0] = scmdbuf;
      return GXv_Object2 ;
   }

   protected Object[] conditional_P009F4( IGxContext context ,
                                          string A365DeviceUserId ,
                                          GxSimpleCollection<string> AV19ResidentGUIDCollection )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      Object[] GXv_Object4 = new Object[2];
      scmdbuf = "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device";
      AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19ResidentGUIDCollection, "DeviceUserId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY DeviceId";
      GXv_Object4[0] = scmdbuf;
      return GXv_Object4 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P009F2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
            case 2 :
                  return conditional_P009F4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

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
       Object[] prmP009F3;
       prmP009F3 = new Object[] {
       new ParDef("AV28Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP009F2;
       prmP009F2 = new Object[] {
       };
       Object[] prmP009F4;
       prmP009F4 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("P009F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F2,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P009F3", "SELECT LocationId, ResidentGUID, ResidentId, OrganisationId FROM Trn_Resident WHERE LocationId = :AV28Udparg1 ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P009F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F4,100, GxCacheFrequency.OFF ,false,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 1000);
             ((string[]) buf[2])[0] = rslt.getString(3, 128);
             return;
    }
 }

}

}
