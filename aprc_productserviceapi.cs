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
namespace GeneXus.Programs {
   public class aprc_productserviceapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_productserviceapi().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_productserviceapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_productserviceapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           ref SdtSDT_ProductService aP1_SDT_ProductService )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ProductService = aP1_SDT_ProductService;
         initialize();
         ExecuteImpl();
         aP1_SDT_ProductService=this.AV9SDT_ProductService;
      }

      public SdtSDT_ProductService executeUdp( Guid aP0_ProductServiceId )
      {
         execute(aP0_ProductServiceId, ref aP1_SDT_ProductService);
         return AV9SDT_ProductService ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 ref SdtSDT_ProductService aP1_SDT_ProductService )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ProductService = aP1_SDT_ProductService;
         SubmitImpl();
         aP1_SDT_ProductService=this.AV9SDT_ProductService;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV17LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV17LocationId = GXt_guid1;
         GXt_guid1 = AV16OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV16OrganisationId = GXt_guid1;
         /* Using cursor P00912 */
         pr_default.execute(0, new Object[] {AV8ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00912_A11OrganisationId[0];
            A29LocationId = P00912_A29LocationId[0];
            A58ProductServiceId = P00912_A58ProductServiceId[0];
            AV12BC_Trn_ProductService.Load(A58ProductServiceId, A29LocationId, A11OrganisationId);
            AV9SDT_ProductService.FromJSonString(AV12BC_Trn_ProductService.ToJSonString(true, true), null);
            /* Using cursor P00913 */
            pr_default.execute(1, new Object[] {AV8ProductServiceId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A58ProductServiceId = P00913_A58ProductServiceId[0];
               A367CallToActionId = P00913_A367CallToActionId[0];
               A397CallToActionName = P00913_A397CallToActionName[0];
               A370CallToActionPhone = P00913_A370CallToActionPhone[0];
               A369CallToActionEmail = P00913_A369CallToActionEmail[0];
               A368CallToActionType = P00913_A368CallToActionType[0];
               A396CallToActionUrl = P00913_A396CallToActionUrl[0];
               AV15BC_Trn_CallToAction.Load(A367CallToActionId);
               AV13SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
               AV13SDT_CallToActionItem.gxTpr_Calltoactionid = A367CallToActionId;
               AV13SDT_CallToActionItem.gxTpr_Calltoactionname = A397CallToActionName;
               AV13SDT_CallToActionItem.gxTpr_Calltoactionphone = A370CallToActionPhone;
               AV13SDT_CallToActionItem.gxTpr_Calltoactionemail = A369CallToActionEmail;
               AV13SDT_CallToActionItem.gxTpr_Calltoactiontype = A368CallToActionType;
               AV13SDT_CallToActionItem.gxTpr_Calltoactionurl = A396CallToActionUrl;
               AV9SDT_ProductService.gxTpr_Calltoactions.Add(AV13SDT_CallToActionItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV17LocationId = Guid.Empty;
         AV16OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00912_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00912_A29LocationId = new Guid[] {Guid.Empty} ;
         P00912_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         P00913_A29LocationId = new Guid[] {Guid.Empty} ;
         P00913_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00913_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00913_A367CallToActionId = new Guid[] {Guid.Empty} ;
         P00913_A397CallToActionName = new string[] {""} ;
         P00913_A370CallToActionPhone = new string[] {""} ;
         P00913_A369CallToActionEmail = new string[] {""} ;
         P00913_A368CallToActionType = new string[] {""} ;
         P00913_A396CallToActionUrl = new string[] {""} ;
         A367CallToActionId = Guid.Empty;
         A397CallToActionName = "";
         A370CallToActionPhone = "";
         A369CallToActionEmail = "";
         A368CallToActionType = "";
         A396CallToActionUrl = "";
         AV15BC_Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV13SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_productserviceapi__default(),
            new Object[][] {
                new Object[] {
               P00912_A11OrganisationId, P00912_A29LocationId, P00912_A58ProductServiceId
               }
               , new Object[] {
               P00913_A29LocationId, P00913_A11OrganisationId, P00913_A58ProductServiceId, P00913_A367CallToActionId, P00913_A397CallToActionName, P00913_A370CallToActionPhone, P00913_A369CallToActionEmail, P00913_A368CallToActionType, P00913_A396CallToActionUrl
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A370CallToActionPhone ;
      private string A397CallToActionName ;
      private string A369CallToActionEmail ;
      private string A368CallToActionType ;
      private string A396CallToActionUrl ;
      private Guid AV8ProductServiceId ;
      private Guid AV17LocationId ;
      private Guid AV16OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A367CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ProductService AV9SDT_ProductService ;
      private SdtSDT_ProductService aP1_SDT_ProductService ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00912_A11OrganisationId ;
      private Guid[] P00912_A29LocationId ;
      private Guid[] P00912_A58ProductServiceId ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private Guid[] P00913_A29LocationId ;
      private Guid[] P00913_A11OrganisationId ;
      private Guid[] P00913_A58ProductServiceId ;
      private Guid[] P00913_A367CallToActionId ;
      private string[] P00913_A397CallToActionName ;
      private string[] P00913_A370CallToActionPhone ;
      private string[] P00913_A369CallToActionEmail ;
      private string[] P00913_A368CallToActionType ;
      private string[] P00913_A396CallToActionUrl ;
      private SdtTrn_CallToAction AV15BC_Trn_CallToAction ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV13SDT_CallToActionItem ;
   }

   public class aprc_productserviceapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00912;
          prmP00912 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00913;
          prmP00913 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00912", "SELECT OrganisationId, LocationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :AV8ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00912,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00913", "SELECT LocationId, OrganisationId, ProductServiceId, CallToActionId, CallToActionName, CallToActionPhone, CallToActionEmail, CallToActionType, CallToActionUrl FROM Trn_CallToAction WHERE ProductServiceId = :AV8ProductServiceId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00913,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
