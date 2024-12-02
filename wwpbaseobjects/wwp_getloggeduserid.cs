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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getloggeduserid : GXProcedure
   {
      public wwp_getloggeduserid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wwp_getloggeduserid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_WWPUserExtendedId )
      {
         this.AV2WWPUserExtendedId = "" ;
         initialize();
         ExecuteImpl();
         aP0_WWPUserExtendedId=this.AV2WWPUserExtendedId;
      }

      public string executeUdp( )
      {
         execute(out aP0_WWPUserExtendedId);
         return AV2WWPUserExtendedId ;
      }

      public void executeSubmit( out string aP0_WWPUserExtendedId )
      {
         this.AV2WWPUserExtendedId = "" ;
         SubmitImpl();
         aP0_WWPUserExtendedId=this.AV2WWPUserExtendedId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2WWPUserExtendedId} ;
         ClassLoader.Execute("wwpbaseobjects.awwp_getloggeduserid","GeneXus.Programs","wwpbaseobjects.awwp_getloggeduserid", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2WWPUserExtendedId = (string)(args[0]) ;
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
      }

      public override void initialize( )
      {
         AV2WWPUserExtendedId = "";
         /* GeneXus formulas. */
      }

      private string AV2WWPUserExtendedId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_WWPUserExtendedId ;
   }

}
