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
   public class prc_deletelocationform : GXProcedure
   {
      public prc_deletelocationform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletelocationform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_WWPFormId ,
                           short aP1_WWPFormVersionNumber ,
                           Guid aP2_LocationDynamicFormId ,
                           Guid aP3_OrganisationId ,
                           Guid aP4_LocationId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_OutMessage )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         this.A207WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.A395LocationDynamicFormId = aP2_LocationDynamicFormId;
         this.A11OrganisationId = aP3_OrganisationId;
         this.A29LocationId = aP4_LocationId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP5_OutMessage=this.AV9OutMessage;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( short aP0_WWPFormId ,
                                                                             short aP1_WWPFormVersionNumber ,
                                                                             Guid aP2_LocationDynamicFormId ,
                                                                             Guid aP3_OrganisationId ,
                                                                             Guid aP4_LocationId )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, aP2_LocationDynamicFormId, aP3_OrganisationId, aP4_LocationId, out aP5_OutMessage);
         return AV9OutMessage ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 Guid aP2_LocationDynamicFormId ,
                                 Guid aP3_OrganisationId ,
                                 Guid aP4_LocationId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_OutMessage )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         this.A207WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.A395LocationDynamicFormId = aP2_LocationDynamicFormId;
         this.A11OrganisationId = aP3_OrganisationId;
         this.A29LocationId = aP4_LocationId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP5_OutMessage=this.AV9OutMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Trn_LocationDynamicForm.Load(A395LocationDynamicFormId, A11OrganisationId, A29LocationId);
         AV8Trn_LocationDynamicForm.Delete();
         if ( AV8Trn_LocationDynamicForm.Success() )
         {
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  A206WWPFormId,  A207WWPFormVersionNumber, out  AV9OutMessage) ;
         }
         else
         {
            AV9OutMessage = AV8Trn_LocationDynamicForm.GetMessages();
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
         AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private Guid A395LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9OutMessage ;
      private SdtTrn_LocationDynamicForm AV8Trn_LocationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_OutMessage ;
   }

}
