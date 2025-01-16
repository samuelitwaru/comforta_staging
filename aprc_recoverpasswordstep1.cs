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
   public class aprc_recoverpasswordstep1 : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_recoverpasswordstep1().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_username = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_username=((string)(args[0]));
         }
         else
         {
            aP0_username="";
         }
         execute(aP0_username);
         return GX.GXRuntime.ExitCode ;
      }

      public aprc_recoverpasswordstep1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_recoverpasswordstep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_username )
      {
         this.AV8username = aP0_username;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_username )
      {
         this.AV8username = aP0_username;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV10UserAuthTypeName, AV8username, out  AV11GAMErrorCollection);
         if ( AV11GAMErrorCollection.Count == 0 )
         {
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV11GAMErrorCollection.Count )
         {
            AV12GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrorCollection.Item(AV13GXV1));
            GX_msglist.addItem(AV12GAMError.gxTpr_Message);
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10UserAuthTypeName = "";
         AV11GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV10UserAuthTypeName ;
      private bool returnInSub ;
      private string AV8username ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9User ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12GAMError ;
   }

}
