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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_addmessage : GXProcedure
   {
      public wwp_addmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_addmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_MsgId ,
                           short aP1_MsgType ,
                           string aP2_MsgDsc ,
                           ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         this.AV12MsgId = aP0_MsgId;
         this.AV13MsgType = aP1_MsgType;
         this.AV14MsgDsc = aP2_MsgDsc;
         this.AV15Messages = aP3_Messages;
         initialize();
         ExecuteImpl();
         aP3_Messages=this.AV15Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_MsgId ,
                                                                             short aP1_MsgType ,
                                                                             string aP2_MsgDsc )
      {
         execute(aP0_MsgId, aP1_MsgType, aP2_MsgDsc, ref aP3_Messages);
         return AV15Messages ;
      }

      public void executeSubmit( string aP0_MsgId ,
                                 short aP1_MsgType ,
                                 string aP2_MsgDsc ,
                                 ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         this.AV12MsgId = aP0_MsgId;
         this.AV13MsgType = aP1_MsgType;
         this.AV14MsgDsc = aP2_MsgDsc;
         this.AV15Messages = aP3_Messages;
         SubmitImpl();
         aP3_Messages=this.AV15Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8Message.gxTpr_Id = AV12MsgId;
         AV8Message.gxTpr_Type = AV13MsgType;
         AV8Message.gxTpr_Description = AV14MsgDsc;
         AV15Messages.Add(AV8Message, 0);
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
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private short AV13MsgType ;
      private string AV12MsgId ;
      private string AV14MsgDsc ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
   }

}
