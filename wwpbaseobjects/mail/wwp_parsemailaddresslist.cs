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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_parsemailaddresslist : GXProcedure
   {
      public wwp_parsemailaddresslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parsemailaddresslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_AddressString ,
                           out GxSimpleCollection<string> aP1_AddressList )
      {
         this.AV10AddressString = aP0_AddressString;
         this.AV9AddressList = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_AddressList=this.AV9AddressList;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_AddressString )
      {
         execute(aP0_AddressString, out aP1_AddressList);
         return AV9AddressList ;
      }

      public void executeSubmit( string aP0_AddressString ,
                                 out GxSimpleCollection<string> aP1_AddressList )
      {
         this.AV10AddressString = aP0_AddressString;
         this.AV9AddressList = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_AddressList=this.AV9AddressList;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV15Pgmname,  "Begin parsing mail address list") ;
         AV9AddressList.Clear();
         AV13TrimmedAddresses = StringUtil.Trim( AV10AddressString);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TrimmedAddresses)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "Address list is empty") ;
            cleanup();
            if (true) return;
         }
         AV14ValidationRegex = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
         AV11SeparatorRegex = "\\s*,\\s*";
         AV12SplittedAddresses = (GxSimpleCollection<string>)(GxRegex.Split(AV13TrimmedAddresses,AV11SeparatorRegex));
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV12SplittedAddresses.Count )
         {
            AV8Address = ((string)AV12SplittedAddresses.Item(AV16GXV1));
            AV8Address = StringUtil.Trim( AV8Address);
            if ( ! GxRegex.IsMatch(AV8Address,AV14ValidationRegex) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "Address is incorrect: "+AV8Address) ;
               AV9AddressList.Clear();
               cleanup();
               if (true) return;
            }
            else
            {
               AV9AddressList.Add(AV8Address, 0);
            }
            AV16GXV1 = (int)(AV16GXV1+1);
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV15Pgmname,  "Parsing address completed") ;
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
         AV9AddressList = new GxSimpleCollection<string>();
         AV15Pgmname = "";
         AV13TrimmedAddresses = "";
         AV14ValidationRegex = "";
         AV11SeparatorRegex = "";
         AV12SplittedAddresses = new GxSimpleCollection<string>();
         AV8Address = "";
         AV15Pgmname = "WWPBaseObjects.Mail.WWP_ParseMailAddressList";
         /* GeneXus formulas. */
         AV15Pgmname = "WWPBaseObjects.Mail.WWP_ParseMailAddressList";
      }

      private int AV16GXV1 ;
      private string AV15Pgmname ;
      private string AV10AddressString ;
      private string AV13TrimmedAddresses ;
      private string AV14ValidationRegex ;
      private string AV11SeparatorRegex ;
      private string AV8Address ;
      private GxSimpleCollection<string> AV9AddressList ;
      private GxSimpleCollection<string> AV12SplittedAddresses ;
      private GxSimpleCollection<string> aP1_AddressList ;
   }

}
