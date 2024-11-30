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
namespace GeneXus.Programs {
   public class dp_recurringeventtype : GXProcedure
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public dp_recurringeventtype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_recurringeventtype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_CurrentDate ,
                           out GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem> aP1_Gxm2rootcol )
      {
         this.AV5CurrentDate = aP0_CurrentDate;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem>( context, "SDT_RecurringEventTypeItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem> executeUdp( DateTime aP0_CurrentDate )
      {
         execute(aP0_CurrentDate, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_CurrentDate ,
                                 out GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem> aP1_Gxm2rootcol )
      {
         this.AV5CurrentDate = aP0_CurrentDate;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem>( context, "SDT_RecurringEventTypeItem", "Comforta_version2") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdt_recurringeventtype = new SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem(context);
         Gxm2rootcol.Add(Gxm1sdt_recurringeventtype, 0);
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypeid = "EveryDay";
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypedescription = "Every Day";
         Gxm1sdt_recurringeventtype = new SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem(context);
         Gxm2rootcol.Add(Gxm1sdt_recurringeventtype, 0);
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypeid = "EveryStartDate";
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypedescription = "Every"+" "+DateTimeUtil.CDow( AV5CurrentDate, "eng");
         Gxm1sdt_recurringeventtype = new SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem(context);
         Gxm2rootcol.Add(Gxm1sdt_recurringeventtype, 0);
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypeid = "EveryWeekDay";
         Gxm1sdt_recurringeventtype.gxTpr_Recurringeventtypedescription = "Every weekday";
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
         Gxm1sdt_recurringeventtype = new SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem(context);
         /* GeneXus formulas. */
      }

      private DateTime AV5CurrentDate ;
      private GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem> Gxm2rootcol ;
      private SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem Gxm1sdt_recurringeventtype ;
      private GXBaseCollection<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem> aP1_Gxm2rootcol ;
   }

}
