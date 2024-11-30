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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_parsephonenumberslist : GXProcedure
   {
      public wwp_parsephonenumberslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parsephonenumberslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PhonesString ,
                           out GxSimpleCollection<string> aP1_PhonesList )
      {
         this.AV10PhonesString = aP0_PhonesString;
         this.AV9PhonesList = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_PhonesList=this.AV9PhonesList;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_PhonesString )
      {
         execute(aP0_PhonesString, out aP1_PhonesList);
         return AV9PhonesList ;
      }

      public void executeSubmit( string aP0_PhonesString ,
                                 out GxSimpleCollection<string> aP1_PhonesList )
      {
         this.AV10PhonesString = aP0_PhonesString;
         this.AV9PhonesList = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_PhonesList=this.AV9PhonesList;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV15Pgmname,  "Begin parsing phone numbers list") ;
         AV9PhonesList.Clear();
         AV13TrimmedPhones = StringUtil.Trim( AV10PhonesString);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TrimmedPhones)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "Phones list is empty") ;
            cleanup();
            if (true) return;
         }
         AV14ValidationRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$";
         AV11SeparatorRegex = "\\s*,\\s*";
         AV12SplittedPhones = (GxSimpleCollection<string>)(GxRegex.Split(AV13TrimmedPhones,AV11SeparatorRegex));
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV12SplittedPhones.Count )
         {
            AV8Phone = ((string)AV12SplittedPhones.Item(AV16GXV1));
            AV8Phone = StringUtil.Trim( AV8Phone);
            if ( ! GxRegex.IsMatch(AV8Phone,AV14ValidationRegex) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "&Phone is incorrect: "+AV8Phone) ;
               AV9PhonesList.Clear();
               cleanup();
               if (true) return;
            }
            else
            {
               AV9PhonesList.Add(AV8Phone, 0);
            }
            AV16GXV1 = (int)(AV16GXV1+1);
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV15Pgmname,  "Parsing phones completed") ;
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
         AV9PhonesList = new GxSimpleCollection<string>();
         AV15Pgmname = "";
         AV13TrimmedPhones = "";
         AV14ValidationRegex = "";
         AV11SeparatorRegex = "";
         AV12SplittedPhones = new GxSimpleCollection<string>();
         AV8Phone = "";
         AV15Pgmname = "WWPBaseObjects.SMS.WWP_ParsePhoneNumbersList";
         /* GeneXus formulas. */
         AV15Pgmname = "WWPBaseObjects.SMS.WWP_ParsePhoneNumbersList";
      }

      private int AV16GXV1 ;
      private string AV15Pgmname ;
      private string AV10PhonesString ;
      private string AV13TrimmedPhones ;
      private string AV14ValidationRegex ;
      private string AV11SeparatorRegex ;
      private string AV8Phone ;
      private GxSimpleCollection<string> AV9PhonesList ;
      private GxSimpleCollection<string> AV12SplittedPhones ;
      private GxSimpleCollection<string> aP1_PhonesList ;
   }

}
