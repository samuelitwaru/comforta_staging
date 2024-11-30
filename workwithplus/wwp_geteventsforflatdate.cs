using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_geteventsforflatdate : GXProcedure
   {
      public wwp_geteventsforflatdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_geteventsforflatdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           string aP3_EventsStyle ,
                           out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions )
      {
         this.AV13Events = aP0_Events;
         this.AV21FromDate = aP1_FromDate;
         this.AV22ToDate = aP2_ToDate;
         this.AV14EventsStyle = aP3_EventsStyle;
         this.AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         initialize();
         ExecuteImpl();
         aP4_WWPDateRangePickerOptions=this.AV20WWPDateRangePickerOptions;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions executeUdp( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                                                                                      DateTime aP1_FromDate ,
                                                                                      DateTime aP2_ToDate ,
                                                                                      string aP3_EventsStyle )
      {
         execute(aP0_Events, aP1_FromDate, aP2_ToDate, aP3_EventsStyle, out aP4_WWPDateRangePickerOptions);
         return AV20WWPDateRangePickerOptions ;
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 string aP3_EventsStyle ,
                                 out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions )
      {
         this.AV13Events = aP0_Events;
         this.AV21FromDate = aP1_FromDate;
         this.AV22ToDate = aP2_ToDate;
         this.AV14EventsStyle = aP3_EventsStyle;
         this.AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         SubmitImpl();
         aP4_WWPDateRangePickerOptions=this.AV20WWPDateRangePickerOptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV13Events.Count )
         {
            AV12Event = ((GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item)AV13Events.Item(AV23GXV1));
            AV8Date = DateTimeUtil.ResetTime(AV12Event.gxTpr_Start);
            if ( AV12Event.gxTpr_Allday )
            {
               AV11EndDate = DateTimeUtil.ResetTime(AV12Event.gxTpr_End);
            }
            else
            {
               AV11EndDate = AV8Date;
            }
            AV10Days = (short)(DateTimeUtil.DDiff(AV11EndDate,AV8Date));
            AV18i = 0;
            while ( AV18i <= AV10Days )
            {
               AV19NewDate = DateTimeUtil.DAdd(AV8Date,+((int)(AV18i)));
               if ( AV9DateCollection.IndexOf(AV19NewDate) <= 0 )
               {
                  AV9DateCollection.Add(AV19NewDate, 0);
               }
               AV18i = (short)(AV18i+1);
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         AV17FormattedDaysItemClass = ((StringUtil.StrCmp(AV14EventsStyle, "BaseColor")==0) ? "basecolor" : "gray");
         AV20WWPDateRangePickerOptions.gxTpr_Formatteddays.Clear();
         AV24GXV2 = 1;
         while ( AV24GXV2 <= AV9DateCollection.Count )
         {
            AV8Date = AV9DateCollection.GetDatetime(AV24GXV2);
            if ( ( DateTimeUtil.ResetTime ( AV8Date ) >= DateTimeUtil.ResetTime ( AV21FromDate ) ) && ( DateTimeUtil.ResetTime ( AV8Date ) <= DateTimeUtil.ResetTime ( AV22ToDate ) ) )
            {
               AV16FormattedDaysItem = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
               GXt_dtime1 = DateTimeUtil.ResetTime( AV8Date ) ;
               AV16FormattedDaysItem.gxTpr_Date = GXt_dtime1;
               AV16FormattedDaysItem.gxTpr_Class = StringUtil.Format( "daterangepicker-badge daterangepicker-badge-%1", AV17FormattedDaysItemClass, "", "", "", "", "", "", "", "");
               AV20WWPDateRangePickerOptions.gxTpr_Formatteddays.Add(AV16FormattedDaysItem, 0);
            }
            AV24GXV2 = (int)(AV24GXV2+1);
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
         AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV12Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         AV8Date = DateTime.MinValue;
         AV11EndDate = DateTime.MinValue;
         AV19NewDate = DateTime.MinValue;
         AV9DateCollection = new GxSimpleCollection<DateTime>();
         AV17FormattedDaysItemClass = "";
         AV16FormattedDaysItem = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         /* GeneXus formulas. */
      }

      private short AV10Days ;
      private short AV18i ;
      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private DateTime GXt_dtime1 ;
      private DateTime AV21FromDate ;
      private DateTime AV22ToDate ;
      private DateTime AV8Date ;
      private DateTime AV11EndDate ;
      private DateTime AV19NewDate ;
      private string AV14EventsStyle ;
      private string AV17FormattedDaysItemClass ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV13Events ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV20WWPDateRangePickerOptions ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV12Event ;
      private GxSimpleCollection<DateTime> AV9DateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem AV16FormattedDaysItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions ;
   }

}
