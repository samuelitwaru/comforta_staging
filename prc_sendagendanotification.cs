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
   public class prc_sendagendanotification : GXProcedure
   {
      public prc_sendagendanotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendagendanotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           GxSimpleCollection<Guid> aP2_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV16ResidentIdCollection = aP2_ResidentIdCollection;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 GxSimpleCollection<Guid> aP2_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV16ResidentIdCollection = aP2_ResidentIdCollection;
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
            if ( AV19ResidentGUIDCollection.Count > 0 )
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    A365DeviceUserId ,
                                                    AV19ResidentGUIDCollection } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P009F3 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A365DeviceUserId = P009F3_A365DeviceUserId[0];
                  A363DeviceToken = P009F3_A363DeviceToken[0];
                  A361DeviceId = P009F3_A361DeviceId[0];
                  AV21DeviceTokenCollection.Add(A363DeviceToken, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV21DeviceTokenCollection.Count )
            {
               AV17DeviceToken = AV21DeviceTokenCollection.GetString(AV24GXV1);
               new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV12TheNotificationConfiguration,  AV17DeviceToken,  AV11TheNotification,  AV15TheNotificationDelivery, out  AV13OutMessages, out  AV14IsSuccessful) ;
               AV24GXV1 = (int)(AV24GXV1+1);
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
         A62ResidentId = Guid.Empty;
         P009F2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009F2_A71ResidentGUID = new string[] {""} ;
         P009F2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009F2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV19ResidentGUIDCollection = new GxSimpleCollection<string>();
         A365DeviceUserId = "";
         P009F3_A365DeviceUserId = new string[] {""} ;
         P009F3_A363DeviceToken = new string[] {""} ;
         P009F3_A361DeviceId = new string[] {""} ;
         A363DeviceToken = "";
         A361DeviceId = "";
         AV21DeviceTokenCollection = new GxSimpleCollection<string>();
         AV17DeviceToken = "";
         AV13OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendagendanotification__default(),
            new Object[][] {
                new Object[] {
               P009F2_A62ResidentId, P009F2_A71ResidentGUID, P009F2_A29LocationId, P009F2_A11OrganisationId
               }
               , new Object[] {
               P009F3_A365DeviceUserId, P009F3_A363DeviceToken, P009F3_A361DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV1 ;
      private string A363DeviceToken ;
      private string A361DeviceId ;
      private string AV17DeviceToken ;
      private bool AV14IsSuccessful ;
      private string AV10title ;
      private string AV9message ;
      private string A71ResidentGUID ;
      private string A365DeviceUserId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV16ResidentIdCollection ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV11TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV15TheNotificationDelivery ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV12TheNotificationConfiguration ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009F2_A62ResidentId ;
      private string[] P009F2_A71ResidentGUID ;
      private Guid[] P009F2_A29LocationId ;
      private Guid[] P009F2_A11OrganisationId ;
      private GxSimpleCollection<string> AV19ResidentGUIDCollection ;
      private string[] P009F3_A365DeviceUserId ;
      private string[] P009F3_A363DeviceToken ;
      private string[] P009F3_A361DeviceId ;
      private GxSimpleCollection<string> AV21DeviceTokenCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13OutMessages ;
   }

   public class prc_sendagendanotification__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009F2( IGxContext context ,
                                             Guid A62ResidentId ,
                                             GxSimpleCollection<Guid> AV16ResidentIdCollection )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT ResidentId, ResidentGUID, LocationId, OrganisationId FROM Trn_Resident";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV16ResidentIdCollection, "ResidentId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResidentId, LocationId, OrganisationId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      protected Object[] conditional_P009F3( IGxContext context ,
                                             string A365DeviceUserId ,
                                             GxSimpleCollection<string> AV19ResidentGUIDCollection )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19ResidentGUIDCollection, "DeviceUserId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DeviceId";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P009F2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 1 :
                     return conditional_P009F3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009F2;
          prmP009F2 = new Object[] {
          };
          Object[] prmP009F3;
          prmP009F3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P009F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1000);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                return;
       }
    }

 }

}
