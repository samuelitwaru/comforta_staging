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
   public class prc_getuserfootercaption : GXProcedure
   {
      public prc_getuserfootercaption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserfootercaption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_FooterText )
      {
         this.AV9FooterText = "" ;
         initialize();
         ExecuteImpl();
         aP0_FooterText=this.AV9FooterText;
      }

      public string executeUdp( )
      {
         execute(out aP0_FooterText);
         return AV9FooterText ;
      }

      public void executeSubmit( out string aP0_FooterText )
      {
         this.AV9FooterText = "" ;
         SubmitImpl();
         aP0_FooterText=this.AV9FooterText;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV12OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV12OrganisationId = GXt_guid1;
         AV11Trn_Organisation.Load(AV12OrganisationId);
         AV9FooterText = "Comforta Software";
         GXt_SdtGAMUser2 = AV10GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser2) ;
         AV10GAMUser = GXt_SdtGAMUser2;
         if ( AV10GAMUser.checkrole("Organisation Manager") )
         {
            AV9FooterText = AV11Trn_Organisation.gxTpr_Organisationname;
         }
         else
         {
            if ( AV10GAMUser.checkrole("Receptionist") )
            {
               AV8Trn_Location.Load(new prc_getuserlocationid(context).executeUdp( ), AV12OrganisationId);
               AV9FooterText = AV11Trn_Organisation.gxTpr_Organisationname + " : " + AV8Trn_Location.gxTpr_Locationname;
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
         AV9FooterText = "";
         AV12OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV11Trn_Organisation = new SdtTrn_Organisation(context);
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser2 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Trn_Location = new SdtTrn_Location(context);
         /* GeneXus formulas. */
      }

      private string AV9FooterText ;
      private Guid AV12OrganisationId ;
      private Guid GXt_guid1 ;
      private SdtTrn_Organisation AV11Trn_Organisation ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser2 ;
      private SdtTrn_Location AV8Trn_Location ;
      private string aP0_FooterText ;
   }

}
