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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_getevent : GXProcedure
   {
      public wwp_calendar_getevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventId ,
                           out GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context) ;
         initialize();
         ExecuteImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      public GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item executeUdp( string aP0_EventId )
      {
         execute(aP0_EventId, out aP1_Calendar_Event);
         return AV8Calendar_Event ;
      }

      public void executeSubmit( string aP0_EventId ,
                                 out GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context) ;
         SubmitImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11AgendaCalendarId = StringUtil.StrToGuid( AV9EventId);
         /* Using cursor P006U2 */
         pr_default.execute(0, new Object[] {AV11AgendaCalendarId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A303AgendaCalendarId = P006U2_A303AgendaCalendarId[0];
            A307AgendaCalendarAllDay = P006U2_A307AgendaCalendarAllDay[0];
            A304AgendaCalendarTitle = P006U2_A304AgendaCalendarTitle[0];
            A305AgendaCalendarStartDate = P006U2_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = P006U2_A306AgendaCalendarEndDate[0];
            A454AgendaCalendarType = P006U2_A454AgendaCalendarType[0];
            A450AgendaCalendarRecurring = P006U2_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = P006U2_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = P006U2_A452AgendaCalendarAddRSVP[0];
            AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
            AV8Calendar_Event.gxTpr_Id = AV11AgendaCalendarId.ToString();
            AV8Calendar_Event.gxTpr_Allday = A307AgendaCalendarAllDay;
            AV8Calendar_Event.gxTpr_Title = A304AgendaCalendarTitle;
            AV8Calendar_Event.gxTpr_Start = A305AgendaCalendarStartDate;
            AV8Calendar_Event.gxTpr_End = A306AgendaCalendarEndDate;
            AV8Calendar_Event.gxTpr_Type = A454AgendaCalendarType;
            AV8Calendar_Event.gxTpr_Recurring = A450AgendaCalendarRecurring;
            AV8Calendar_Event.gxTpr_Recurringtype = A451AgendaCalendarRecurringType;
            AV8Calendar_Event.gxTpr_Addrsvp = A452AgendaCalendarAddRSVP;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         AV11AgendaCalendarId = Guid.Empty;
         P006U2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P006U2_A307AgendaCalendarAllDay = new bool[] {false} ;
         P006U2_A304AgendaCalendarTitle = new string[] {""} ;
         P006U2_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A454AgendaCalendarType = new string[] {""} ;
         P006U2_A450AgendaCalendarRecurring = new bool[] {false} ;
         P006U2_A451AgendaCalendarRecurringType = new string[] {""} ;
         P006U2_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         A303AgendaCalendarId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A454AgendaCalendarType = "";
         A451AgendaCalendarRecurringType = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevent__default(),
            new Object[][] {
                new Object[] {
               P006U2_A303AgendaCalendarId, P006U2_A307AgendaCalendarAllDay, P006U2_A304AgendaCalendarTitle, P006U2_A305AgendaCalendarStartDate, P006U2_A306AgendaCalendarEndDate, P006U2_A454AgendaCalendarType, P006U2_A450AgendaCalendarRecurring, P006U2_A451AgendaCalendarRecurringType, P006U2_A452AgendaCalendarAddRSVP
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A305AgendaCalendarStartDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private bool A307AgendaCalendarAllDay ;
      private bool A450AgendaCalendarRecurring ;
      private bool A452AgendaCalendarAddRSVP ;
      private string AV9EventId ;
      private string A304AgendaCalendarTitle ;
      private string A454AgendaCalendarType ;
      private string A451AgendaCalendarRecurringType ;
      private Guid AV11AgendaCalendarId ;
      private Guid A303AgendaCalendarId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV8Calendar_Event ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006U2_A303AgendaCalendarId ;
      private bool[] P006U2_A307AgendaCalendarAllDay ;
      private string[] P006U2_A304AgendaCalendarTitle ;
      private DateTime[] P006U2_A305AgendaCalendarStartDate ;
      private DateTime[] P006U2_A306AgendaCalendarEndDate ;
      private string[] P006U2_A454AgendaCalendarType ;
      private bool[] P006U2_A450AgendaCalendarRecurring ;
      private string[] P006U2_A451AgendaCalendarRecurringType ;
      private bool[] P006U2_A452AgendaCalendarAddRSVP ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event ;
   }

   public class wwp_calendar_getevent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006U2;
          prmP006U2 = new Object[] {
          new ParDef("AV11AgendaCalendarId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006U2", "SELECT AgendaCalendarId, AgendaCalendarAllDay, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AV11AgendaCalendarId ORDER BY AgendaCalendarId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                return;
       }
    }

 }

}
