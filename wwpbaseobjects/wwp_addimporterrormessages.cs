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
   public class wwp_addimporterrormessages : GXProcedure
   {
      public wwp_addimporterrormessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_addimporterrormessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages ,
                           string aP1_LineId ,
                           GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_ErrorsToAdd )
      {
         this.AV11Messages = aP0_Messages;
         this.AV9LineId = aP1_LineId;
         this.AV8ErrorsToAdd = aP2_ErrorsToAdd;
         initialize();
         ExecuteImpl();
         aP0_Messages=this.AV11Messages;
      }

      public void executeSubmit( ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages ,
                                 string aP1_LineId ,
                                 GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_ErrorsToAdd )
      {
         this.AV11Messages = aP0_Messages;
         this.AV9LineId = aP1_LineId;
         this.AV8ErrorsToAdd = aP2_ErrorsToAdd;
         SubmitImpl();
         aP0_Messages=this.AV11Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9LineId)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_addmessage(context ).execute(  "WWP_LineId",  2,  StringUtil.Format( context.GetMessage( "File line: %1", ""), AV9LineId, "", "", "", "", "", "", "", ""), ref  AV11Messages) ;
         }
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8ErrorsToAdd.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV8ErrorsToAdd.Item(AV12GXV1));
            if ( AV10Message.gxTpr_Type == 1 )
            {
               AV11Messages.Add(AV10Message, 0);
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV9LineId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8ErrorsToAdd ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
   }

}
