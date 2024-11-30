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
   public class secgamgetadvancedsecuritywwpfunctionalities : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public secgamgetadvancedsecuritywwpfunctionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgamgetadvancedsecuritywwpfunctionalities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> executeUdp( )
      {
         execute(out aP0_Gxm3rootcol);
         return Gxm3rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: Sub1subgroup_1 */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* Sub1subgroup_1 Routine */
         returnInSub = false;
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_manager_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_organisation_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_resident_Delete";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_resident_Insert";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_location_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_productservice_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Invite";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionistview_Execute";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Update";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Delete";
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_loacationdynamicform_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
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
         Gxm2secgamfunctionalitiestoload = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> Gxm3rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad Gxm2secgamfunctionalitiestoload ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol ;
   }

}
