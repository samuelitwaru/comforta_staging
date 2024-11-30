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
   public class dp_getusernotifications : GXProcedure
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

      public dp_getusernotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_getusernotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_type ,
                           GxSimpleCollection<short> aP1_NotificationDefinitionIdCollection ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP2_Gxm2rootcol )
      {
         this.AV8type = aP0_type;
         this.AV9NotificationDefinitionIdCollection = aP1_NotificationDefinitionIdCollection;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( string aP0_type ,
                                                                                                                                                         GxSimpleCollection<short> aP1_NotificationDefinitionIdCollection )
      {
         execute(aP0_type, aP1_NotificationDefinitionIdCollection, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_type ,
                                 GxSimpleCollection<short> aP1_NotificationDefinitionIdCollection ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP2_Gxm2rootcol )
      {
         this.AV8type = aP0_type;
         this.AV9NotificationDefinitionIdCollection = aP1_NotificationDefinitionIdCollection;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2") ;
         SubmitImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13Udparg3 = new prc_getloggedinuserid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A128WWPNotificationDefinitionId ,
                                              AV9NotificationDefinitionIdCollection ,
                                              AV9NotificationDefinitionIdCollection.Count ,
                                              AV8type ,
                                              A187WWPNotificationIsRead ,
                                              A112WWPUserExtendedId ,
                                              AV13Udparg3 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P000R2 */
         pr_default.execute(0, new Object[] {AV13Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A187WWPNotificationIsRead = P000R2_A187WWPNotificationIsRead[0];
            A128WWPNotificationDefinitionId = P000R2_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = P000R2_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P000R2_n112WWPUserExtendedId[0];
            A127WWPNotificationId = P000R2_A127WWPNotificationId[0];
            A181WWPNotificationIcon = P000R2_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = P000R2_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = P000R2_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = P000R2_A184WWPNotificationLink[0];
            A129WWPNotificationCreated = P000R2_A129WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A127WWPNotificationId);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A181WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A182WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A183WWPNotificationShortDescriptio;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A129WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A184WWPNotificationLink;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV13Udparg3 = "";
         A112WWPUserExtendedId = "";
         P000R2_A187WWPNotificationIsRead = new bool[] {false} ;
         P000R2_A128WWPNotificationDefinitionId = new long[1] ;
         P000R2_A112WWPUserExtendedId = new string[] {""} ;
         P000R2_n112WWPUserExtendedId = new bool[] {false} ;
         P000R2_A127WWPNotificationId = new long[1] ;
         P000R2_A181WWPNotificationIcon = new string[] {""} ;
         P000R2_A182WWPNotificationTitle = new string[] {""} ;
         P000R2_A183WWPNotificationShortDescriptio = new string[] {""} ;
         P000R2_A184WWPNotificationLink = new string[] {""} ;
         P000R2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A181WWPNotificationIcon = "";
         A182WWPNotificationTitle = "";
         A183WWPNotificationShortDescriptio = "";
         A184WWPNotificationLink = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_getusernotifications__default(),
            new Object[][] {
                new Object[] {
               P000R2_A187WWPNotificationIsRead, P000R2_A128WWPNotificationDefinitionId, P000R2_A112WWPUserExtendedId, P000R2_n112WWPUserExtendedId, P000R2_A127WWPNotificationId, P000R2_A181WWPNotificationIcon, P000R2_A182WWPNotificationTitle, P000R2_A183WWPNotificationShortDescriptio, P000R2_A184WWPNotificationLink, P000R2_A129WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9NotificationDefinitionIdCollection_Count ;
      private long A128WWPNotificationDefinitionId ;
      private long A127WWPNotificationId ;
      private string AV8type ;
      private string A112WWPUserExtendedId ;
      private DateTime A129WWPNotificationCreated ;
      private bool A187WWPNotificationIsRead ;
      private bool n112WWPUserExtendedId ;
      private string AV13Udparg3 ;
      private string A181WWPNotificationIcon ;
      private string A182WWPNotificationTitle ;
      private string A183WWPNotificationShortDescriptio ;
      private string A184WWPNotificationLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV9NotificationDefinitionIdCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P000R2_A187WWPNotificationIsRead ;
      private long[] P000R2_A128WWPNotificationDefinitionId ;
      private string[] P000R2_A112WWPUserExtendedId ;
      private bool[] P000R2_n112WWPUserExtendedId ;
      private long[] P000R2_A127WWPNotificationId ;
      private string[] P000R2_A181WWPNotificationIcon ;
      private string[] P000R2_A182WWPNotificationTitle ;
      private string[] P000R2_A183WWPNotificationShortDescriptio ;
      private string[] P000R2_A184WWPNotificationLink ;
      private DateTime[] P000R2_A129WWPNotificationCreated ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP2_Gxm2rootcol ;
   }

   public class dp_getusernotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000R2( IGxContext context ,
                                             long A128WWPNotificationDefinitionId ,
                                             GxSimpleCollection<short> AV9NotificationDefinitionIdCollection ,
                                             int AV9NotificationDefinitionIdCollection_Count ,
                                             string AV8type ,
                                             bool A187WWPNotificationIsRead ,
                                             string A112WWPUserExtendedId ,
                                             string AV13Udparg3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPNotificationIsRead, WWPNotificationDefinitionId, WWPUserExtendedId, WWPNotificationId, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationCreated FROM WWP_Notification";
         AddWhere(sWhereString, "(WWPUserExtendedId = ( :AV13Udparg3))");
         if ( AV9NotificationDefinitionIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV9NotificationDefinitionIdCollection, "WWPNotificationDefinitionId IN (", ")")+")");
         }
         if ( StringUtil.StrCmp(AV8type, "Read") == 0 )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead = TRUE)");
         }
         if ( StringUtil.StrCmp(AV8type, "UnRead") == 0 )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPNotificationCreated DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000R2(context, (long)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000R2;
          prmP000R2 = new Object[] {
          new ParDef("AV13Udparg3",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P000R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 40);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                return;
       }
    }

 }

}
