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
   public class prc_getnotificationgrouping : GXProcedure
   {
      public prc_getnotificationgrouping( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getnotificationgrouping( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP0_SDT_NotificationGroupParentCollection ,
                           out GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP1_SDT_NotificationGroupCollection )
      {
         this.AV15SDT_NotificationGroupParentCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2") ;
         this.AV12SDT_NotificationGroupCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_SDT_NotificationGroupParentCollection=this.AV15SDT_NotificationGroupParentCollection;
         aP1_SDT_NotificationGroupCollection=this.AV12SDT_NotificationGroupCollection;
      }

      public GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> executeUdp( out GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP0_SDT_NotificationGroupParentCollection )
      {
         execute(out aP0_SDT_NotificationGroupParentCollection, out aP1_SDT_NotificationGroupCollection);
         return AV12SDT_NotificationGroupCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP0_SDT_NotificationGroupParentCollection ,
                                 out GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP1_SDT_NotificationGroupCollection )
      {
         this.AV15SDT_NotificationGroupParentCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2") ;
         this.AV12SDT_NotificationGroupCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_SDT_NotificationGroupParentCollection=this.AV15SDT_NotificationGroupParentCollection;
         aP1_SDT_NotificationGroupCollection=this.AV12SDT_NotificationGroupCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Udparg1 = new prc_getloggedinuserid(context).executeUdp( );
         /* Using cursor P00A92 */
         pr_default.execute(0, new Object[] {AV19Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112WWPUserExtendedId = P00A92_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P00A92_n112WWPUserExtendedId[0];
            A127WWPNotificationId = P00A92_A127WWPNotificationId[0];
            A182WWPNotificationTitle = P00A92_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = P00A92_A183WWPNotificationShortDescriptio[0];
            A181WWPNotificationIcon = P00A92_A181WWPNotificationIcon[0];
            A184WWPNotificationLink = P00A92_A184WWPNotificationLink[0];
            A165WWPNotificationMetadata = P00A92_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = P00A92_n165WWPNotificationMetadata[0];
            A129WWPNotificationCreated = P00A92_A129WWPNotificationCreated[0];
            AV11SDT_NotificationGroup = new SdtSDT_NotificationGroup_SDT_NotificationGroupItem(context);
            AV11SDT_NotificationGroup.gxTpr_Notificationid = (int)(A127WWPNotificationId);
            AV11SDT_NotificationGroup.gxTpr_Notificationtitle = A182WWPNotificationTitle;
            AV11SDT_NotificationGroup.gxTpr_Notificationdescription = A183WWPNotificationShortDescriptio;
            AV11SDT_NotificationGroup.gxTpr_Notificationdatetime = A129WWPNotificationCreated;
            AV11SDT_NotificationGroup.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A181WWPNotificationIcon;
            AV11SDT_NotificationGroup.gxTpr_Notificationlink = A184WWPNotificationLink;
            AV17WWP_SDTNotificationMetada = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
            if ( AV17WWP_SDTNotificationMetada.FromJSonString(A165WWPNotificationMetadata, null) )
            {
               AV16SDT_NotificationMetadata = AV17WWP_SDTNotificationMetada.gxTpr_Custommetadata;
               AV11SDT_NotificationGroup.gxTpr_Isparent = AV16SDT_NotificationMetadata.gxTpr_Isparentnotification;
               AV11SDT_NotificationGroup.gxTpr_Parentlinkid = StringUtil.Trim( AV16SDT_NotificationMetadata.gxTpr_Parentnotificationid);
            }
            AV12SDT_NotificationGroupCollection.Add(AV11SDT_NotificationGroup, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV12SDT_NotificationGroupCollection.Count )
         {
            AV13SDT_NotificationGroupItem = ((SdtSDT_NotificationGroup_SDT_NotificationGroupItem)AV12SDT_NotificationGroupCollection.Item(AV20GXV1));
            if ( AV13SDT_NotificationGroupItem.gxTpr_Isparent )
            {
               AV9NotificationParentId = "";
               AV9NotificationParentId = AV13SDT_NotificationGroupItem.gxTpr_Parentlinkid;
               /* Execute user subroutine: 'CHECKNUMBEROFCHILDNOTIFICATIONS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV13SDT_NotificationGroupItem.gxTpr_Numberofchildnotifications = AV8CountOfChildNotifications;
               new prc_logtofile(context ).execute(  "Notification Parent: "+AV13SDT_NotificationGroupItem.ToJSonString(false, true)) ;
               AV15SDT_NotificationGroupParentCollection.Add(AV13SDT_NotificationGroupItem, 0);
            }
            AV20GXV1 = (int)(AV20GXV1+1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKNUMBEROFCHILDNOTIFICATIONS' Routine */
         returnInSub = false;
         AV8CountOfChildNotifications = 0;
         AV21GXV2 = 1;
         while ( AV21GXV2 <= AV12SDT_NotificationGroupCollection.Count )
         {
            AV14SDT_NotificationGroupItem2 = ((SdtSDT_NotificationGroup_SDT_NotificationGroupItem)AV12SDT_NotificationGroupCollection.Item(AV21GXV2));
            if ( ! AV14SDT_NotificationGroupItem2.gxTpr_Isparent && StringUtil.Contains( AV14SDT_NotificationGroupItem2.gxTpr_Parentlinkid, AV9NotificationParentId) )
            {
               AV8CountOfChildNotifications = (short)(AV8CountOfChildNotifications+1);
            }
            AV21GXV2 = (int)(AV21GXV2+1);
         }
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
         AV15SDT_NotificationGroupParentCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2");
         AV12SDT_NotificationGroupCollection = new GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>( context, "SDT_NotificationGroupItem", "Comforta_version2");
         AV19Udparg1 = "";
         P00A92_A112WWPUserExtendedId = new string[] {""} ;
         P00A92_n112WWPUserExtendedId = new bool[] {false} ;
         P00A92_A127WWPNotificationId = new long[1] ;
         P00A92_A182WWPNotificationTitle = new string[] {""} ;
         P00A92_A183WWPNotificationShortDescriptio = new string[] {""} ;
         P00A92_A181WWPNotificationIcon = new string[] {""} ;
         P00A92_A184WWPNotificationLink = new string[] {""} ;
         P00A92_A165WWPNotificationMetadata = new string[] {""} ;
         P00A92_n165WWPNotificationMetadata = new bool[] {false} ;
         P00A92_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A112WWPUserExtendedId = "";
         A182WWPNotificationTitle = "";
         A183WWPNotificationShortDescriptio = "";
         A181WWPNotificationIcon = "";
         A184WWPNotificationLink = "";
         A165WWPNotificationMetadata = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AV11SDT_NotificationGroup = new SdtSDT_NotificationGroup_SDT_NotificationGroupItem(context);
         AV17WWP_SDTNotificationMetada = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV16SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV13SDT_NotificationGroupItem = new SdtSDT_NotificationGroup_SDT_NotificationGroupItem(context);
         AV9NotificationParentId = "";
         AV14SDT_NotificationGroupItem2 = new SdtSDT_NotificationGroup_SDT_NotificationGroupItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getnotificationgrouping__default(),
            new Object[][] {
                new Object[] {
               P00A92_A112WWPUserExtendedId, P00A92_n112WWPUserExtendedId, P00A92_A127WWPNotificationId, P00A92_A182WWPNotificationTitle, P00A92_A183WWPNotificationShortDescriptio, P00A92_A181WWPNotificationIcon, P00A92_A184WWPNotificationLink, P00A92_A165WWPNotificationMetadata, P00A92_n165WWPNotificationMetadata, P00A92_A129WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8CountOfChildNotifications ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private long A127WWPNotificationId ;
      private string A112WWPUserExtendedId ;
      private DateTime A129WWPNotificationCreated ;
      private bool n112WWPUserExtendedId ;
      private bool n165WWPNotificationMetadata ;
      private bool returnInSub ;
      private string A165WWPNotificationMetadata ;
      private string AV19Udparg1 ;
      private string A182WWPNotificationTitle ;
      private string A183WWPNotificationShortDescriptio ;
      private string A181WWPNotificationIcon ;
      private string A184WWPNotificationLink ;
      private string AV9NotificationParentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> AV15SDT_NotificationGroupParentCollection ;
      private GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> AV12SDT_NotificationGroupCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00A92_A112WWPUserExtendedId ;
      private bool[] P00A92_n112WWPUserExtendedId ;
      private long[] P00A92_A127WWPNotificationId ;
      private string[] P00A92_A182WWPNotificationTitle ;
      private string[] P00A92_A183WWPNotificationShortDescriptio ;
      private string[] P00A92_A181WWPNotificationIcon ;
      private string[] P00A92_A184WWPNotificationLink ;
      private string[] P00A92_A165WWPNotificationMetadata ;
      private bool[] P00A92_n165WWPNotificationMetadata ;
      private DateTime[] P00A92_A129WWPNotificationCreated ;
      private SdtSDT_NotificationGroup_SDT_NotificationGroupItem AV11SDT_NotificationGroup ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata AV17WWP_SDTNotificationMetada ;
      private SdtSDT_NotificationMetadata AV16SDT_NotificationMetadata ;
      private SdtSDT_NotificationGroup_SDT_NotificationGroupItem AV13SDT_NotificationGroupItem ;
      private SdtSDT_NotificationGroup_SDT_NotificationGroupItem AV14SDT_NotificationGroupItem2 ;
      private GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP0_SDT_NotificationGroupParentCollection ;
      private GXBaseCollection<SdtSDT_NotificationGroup_SDT_NotificationGroupItem> aP1_SDT_NotificationGroupCollection ;
   }

   public class prc_getnotificationgrouping__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00A92;
          prmP00A92 = new Object[] {
          new ParDef("AV19Udparg1",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00A92", "SELECT WWPUserExtendedId, WWPNotificationId, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationIcon, WWPNotificationLink, WWPNotificationMetadata, WWPNotificationCreated FROM WWP_Notification WHERE WWPUserExtendedId = ( :AV19Udparg1) ORDER BY WWPNotificationCreated DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A92,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
                return;
       }
    }

 }

}