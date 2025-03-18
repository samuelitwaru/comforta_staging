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
   public class prc_debugappversion : GXProcedure
   {
      public prc_debugappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_debugappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxSimpleCollection<string> aP0_UrlList ,
                           out SdtSDT_DebugResults aP1_DebugResults ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV16UrlList = aP0_UrlList;
         this.AV9DebugResults = new SdtSDT_DebugResults(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      public SdtSDT_Error executeUdp( GxSimpleCollection<string> aP0_UrlList ,
                                      out SdtSDT_DebugResults aP1_DebugResults )
      {
         execute(aP0_UrlList, out aP1_DebugResults, out aP2_Error);
         return AV10Error ;
      }

      public void executeSubmit( GxSimpleCollection<string> aP0_UrlList ,
                                 out SdtSDT_DebugResults aP1_DebugResults ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV16UrlList = aP0_UrlList;
         this.AV9DebugResults = new SdtSDT_DebugResults(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19UrlStatuses = AV15UrlChecker.checkurls(AV16UrlList);
         AV13Summary = AV15UrlChecker.getsummary();
         AV9DebugResults.gxTpr_Summary.gxTpr_Totalurls = (short)(AV13Summary.gxTpr_Totalurls);
         AV9DebugResults.gxTpr_Summary.gxTpr_Successcount = (short)(AV13Summary.gxTpr_Totalsuccess);
         AV9DebugResults.gxTpr_Summary.gxTpr_Failurecount = (short)(AV13Summary.gxTpr_Totalfailed);
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV19UrlStatuses.Count )
         {
            AV18UrlStatus = ((SdtUrlStatus)AV19UrlStatuses.Item(AV20GXV1));
            AV17UrlListItem = new SdtSDT_DebugResults_UrlListItem(context);
            AV17UrlListItem.gxTpr_Statuscode = StringUtil.Str( (decimal)(AV18UrlStatus.gxTpr_Statuscode), 9, 0);
            AV17UrlListItem.gxTpr_Statusmessage = AV18UrlStatus.gxTpr_Message;
            AV17UrlListItem.gxTpr_Url = AV18UrlStatus.gxTpr_Url;
            AV9DebugResults.gxTpr_Urllist.Add(AV17UrlListItem, 0);
            AV20GXV1 = (int)(AV20GXV1+1);
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
         AV9DebugResults = new SdtSDT_DebugResults(context);
         AV10Error = new SdtSDT_Error(context);
         AV19UrlStatuses = new GXExternalCollection<SdtUrlStatus>( context, "SdtUrlStatus", "GeneXus.Programs");
         AV15UrlChecker = new SdtUrlChecker(context);
         AV13Summary = new SdtSummary(context);
         AV18UrlStatus = new SdtUrlStatus(context);
         AV17UrlListItem = new SdtSDT_DebugResults_UrlListItem(context);
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private GxSimpleCollection<string> AV16UrlList ;
      private SdtSDT_DebugResults AV9DebugResults ;
      private SdtSDT_Error AV10Error ;
      private GXExternalCollection<SdtUrlStatus> AV19UrlStatuses ;
      private SdtUrlChecker AV15UrlChecker ;
      private SdtSummary AV13Summary ;
      private SdtUrlStatus AV18UrlStatus ;
      private SdtSDT_DebugResults_UrlListItem AV17UrlListItem ;
      private SdtSDT_DebugResults aP1_DebugResults ;
      private SdtSDT_Error aP2_Error ;
   }

}
