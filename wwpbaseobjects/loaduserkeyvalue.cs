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
   public class loaduserkeyvalue : GXProcedure
   {
      public loaduserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loaduserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           out string aP1_UserCustomizationsValue )
      {
         this.AV39UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV40UserCustomizationsValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_UserCustomizationsValue=this.AV40UserCustomizationsValue;
      }

      public string executeUdp( string aP0_UserCustomizationsKey )
      {
         execute(aP0_UserCustomizationsKey, out aP1_UserCustomizationsValue);
         return AV40UserCustomizationsValue ;
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 out string aP1_UserCustomizationsValue )
      {
         this.AV39UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV40UserCustomizationsValue = "" ;
         SubmitImpl();
         aP1_UserCustomizationsValue=this.AV40UserCustomizationsValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV40UserCustomizationsValue = AV38Session.Get(AV39UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomizationsValue)) )
         {
            AV42UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV39UserCustomizationsKey);
            if ( AV42UserCustomizations.Success() )
            {
               AV40UserCustomizationsValue = AV42UserCustomizations.gxTpr_Usercustomizationsvalue;
            }
            else
            {
               AV40UserCustomizationsValue = "";
            }
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
         AV40UserCustomizationsValue = "";
         AV38Session = context.GetSession();
         AV42UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         /* GeneXus formulas. */
      }

      private string AV40UserCustomizationsValue ;
      private string AV39UserCustomizationsKey ;
      private IGxSession AV38Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV42UserCustomizations ;
      private string aP1_UserCustomizationsValue ;
   }

}
