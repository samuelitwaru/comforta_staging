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
   public class prc_recurringeverystartdate : GXProcedure
   {
      public prc_recurringeverystartdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_recurringeverystartdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_IsSearching ,
                           string aP1_TitleFilter ,
                           DateTime aP2_LoadFromDate ,
                           DateTime aP3_LoadToDate ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents )
      {
         this.AV8IsSearching = aP0_IsSearching;
         this.AV9TitleFilter = aP1_TitleFilter;
         this.AV10LoadFromDate = aP2_LoadFromDate;
         this.AV11LoadToDate = aP3_LoadToDate;
         this.AV12CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP4_CalendarEvents=this.AV12CalendarEvents;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> executeUdp( bool aP0_IsSearching ,
                                                                                                     string aP1_TitleFilter ,
                                                                                                     DateTime aP2_LoadFromDate ,
                                                                                                     DateTime aP3_LoadToDate )
      {
         execute(aP0_IsSearching, aP1_TitleFilter, aP2_LoadFromDate, aP3_LoadToDate, out aP4_CalendarEvents);
         return AV12CalendarEvents ;
      }

      public void executeSubmit( bool aP0_IsSearching ,
                                 string aP1_TitleFilter ,
                                 DateTime aP2_LoadFromDate ,
                                 DateTime aP3_LoadToDate ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents )
      {
         this.AV8IsSearching = aP0_IsSearching;
         this.AV9TitleFilter = aP1_TitleFilter;
         this.AV10LoadFromDate = aP2_LoadFromDate;
         this.AV11LoadToDate = aP3_LoadToDate;
         this.AV12CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         SubmitImpl();
         aP4_CalendarEvents=this.AV12CalendarEvents;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV8IsSearching )
         {
            AV14RealLoadToDate = AV11LoadToDate;
         }
         else
         {
            AV14RealLoadToDate = DateTimeUtil.DAdd( AV11LoadToDate, (1));
         }
         AV17Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00952 */
         pr_default.execute(0, new Object[] {AV17Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A451AgendaCalendarRecurringType = P00952_A451AgendaCalendarRecurringType[0];
            A450AgendaCalendarRecurring = P00952_A450AgendaCalendarRecurring[0];
            A29LocationId = P00952_A29LocationId[0];
            A305AgendaCalendarStartDate = P00952_A305AgendaCalendarStartDate[0];
            A303AgendaCalendarId = P00952_A303AgendaCalendarId[0];
            A307AgendaCalendarAllDay = P00952_A307AgendaCalendarAllDay[0];
            A304AgendaCalendarTitle = P00952_A304AgendaCalendarTitle[0];
            AV15Day = A305AgendaCalendarStartDate;
            while ( AV15Day <= AV14RealLoadToDate )
            {
               AV13CalendarEvent = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
               AV13CalendarEvent.gxTpr_Id = A303AgendaCalendarId.ToString();
               AV13CalendarEvent.gxTpr_Allday = A307AgendaCalendarAllDay;
               AV13CalendarEvent.gxTpr_Start = AV15Day;
               AV13CalendarEvent.gxTpr_End = AV15Day;
               AV13CalendarEvent.gxTpr_Title = A304AgendaCalendarTitle;
               AV12CalendarEvents.Add(AV13CalendarEvent, 0);
               AV15Day = DateTimeUtil.TAdd( AV15Day, 86400*(7));
            }
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
         AV12CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         AV14RealLoadToDate = DateTime.MinValue;
         AV17Udparg1 = Guid.Empty;
         P00952_A451AgendaCalendarRecurringType = new string[] {""} ;
         P00952_A450AgendaCalendarRecurring = new bool[] {false} ;
         P00952_A29LocationId = new Guid[] {Guid.Empty} ;
         P00952_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P00952_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P00952_A307AgendaCalendarAllDay = new bool[] {false} ;
         P00952_A304AgendaCalendarTitle = new string[] {""} ;
         A451AgendaCalendarRecurringType = "";
         A29LocationId = Guid.Empty;
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A303AgendaCalendarId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         AV15Day = (DateTime)(DateTime.MinValue);
         AV13CalendarEvent = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_recurringeverystartdate__default(),
            new Object[][] {
                new Object[] {
               P00952_A451AgendaCalendarRecurringType, P00952_A450AgendaCalendarRecurring, P00952_A29LocationId, P00952_A305AgendaCalendarStartDate, P00952_A303AgendaCalendarId, P00952_A307AgendaCalendarAllDay, P00952_A304AgendaCalendarTitle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A305AgendaCalendarStartDate ;
      private DateTime AV15Day ;
      private DateTime AV10LoadFromDate ;
      private DateTime AV11LoadToDate ;
      private DateTime AV14RealLoadToDate ;
      private bool AV8IsSearching ;
      private bool A450AgendaCalendarRecurring ;
      private bool A307AgendaCalendarAllDay ;
      private string AV9TitleFilter ;
      private string A451AgendaCalendarRecurringType ;
      private string A304AgendaCalendarTitle ;
      private Guid AV17Udparg1 ;
      private Guid A29LocationId ;
      private Guid A303AgendaCalendarId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV12CalendarEvents ;
      private IDataStoreProvider pr_default ;
      private string[] P00952_A451AgendaCalendarRecurringType ;
      private bool[] P00952_A450AgendaCalendarRecurring ;
      private Guid[] P00952_A29LocationId ;
      private DateTime[] P00952_A305AgendaCalendarStartDate ;
      private Guid[] P00952_A303AgendaCalendarId ;
      private bool[] P00952_A307AgendaCalendarAllDay ;
      private string[] P00952_A304AgendaCalendarTitle ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV13CalendarEvent ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents ;
   }

   public class prc_recurringeverystartdate__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00952;
          prmP00952 = new Object[] {
          new ParDef("AV17Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00952", "SELECT AgendaCalendarRecurringType, AgendaCalendarRecurring, LocationId, AgendaCalendarStartDate, AgendaCalendarId, AgendaCalendarAllDay, AgendaCalendarTitle FROM Trn_AgendaCalendar WHERE (LocationId = :AV17Udparg1) AND (AgendaCalendarRecurring = TRUE) AND (AgendaCalendarRecurringType = ( 'EveryStartDate')) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00952,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
       }
    }

 }

}
