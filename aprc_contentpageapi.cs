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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_contentpageapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_contentpageapi().MainImpl(args); ;
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

      public aprc_contentpageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_contentpageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           out SdtSDT_ContentPage aP3_Res_SDT_ContentPage )
      {
         this.AV23PageId = aP0_PageId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV25Res_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         initialize();
         ExecuteImpl();
         aP3_Res_SDT_ContentPage=this.AV25Res_SDT_ContentPage;
      }

      public SdtSDT_ContentPage executeUdp( Guid aP0_PageId ,
                                            Guid aP1_LocationId ,
                                            Guid aP2_OrganisationId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, out aP3_Res_SDT_ContentPage);
         return AV25Res_SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_ContentPage aP3_Res_SDT_ContentPage )
      {
         this.AV23PageId = aP0_PageId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV25Res_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         SubmitImpl();
         aP3_Res_SDT_ContentPage=this.AV25Res_SDT_ContentPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009L2 */
         pr_default.execute(0, new Object[] {AV23PageId, AV8LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A58ProductServiceId = P009L2_A58ProductServiceId[0];
            n58ProductServiceId = P009L2_n58ProductServiceId[0];
            A11OrganisationId = P009L2_A11OrganisationId[0];
            A29LocationId = P009L2_A29LocationId[0];
            A310Trn_PageId = P009L2_A310Trn_PageId[0];
            A40000ProductServiceImage_GXI = P009L2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P009L2_A60ProductServiceDescription[0];
            A439PageIsContentPage = P009L2_A439PageIsContentPage[0];
            n439PageIsContentPage = P009L2_n439PageIsContentPage[0];
            A431PageJsonContent = P009L2_A431PageJsonContent[0];
            n431PageJsonContent = P009L2_n431PageJsonContent[0];
            A504PageIsPredefined = P009L2_A504PageIsPredefined[0];
            A318Trn_PageName = P009L2_A318Trn_PageName[0];
            A40000ProductServiceImage_GXI = P009L2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P009L2_A60ProductServiceDescription[0];
            AV14SDT_ContentPage = new SdtSDT_ContentPage(context);
            AV14SDT_ContentPage.FromJSonString(A431PageJsonContent, null);
            AV25Res_SDT_ContentPage = AV14SDT_ContentPage;
            if ( ! A504PageIsPredefined )
            {
               if ( AV25Res_SDT_ContentPage.gxTpr_Content.Count == 0 )
               {
                  /* Using cursor P009L3 */
                  pr_default.execute(1, new Object[] {A310Trn_PageId, A29LocationId, A11OrganisationId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A58ProductServiceId = P009L3_A58ProductServiceId[0];
                     n58ProductServiceId = P009L3_n58ProductServiceId[0];
                     AV26ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV26ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
                     AV26ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
                     AV25Res_SDT_ContentPage.gxTpr_Content.Add(AV26ContentItem, 0);
                     AV26ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV26ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
                     AV26ContentItem.gxTpr_Contentvalue = A60ProductServiceDescription;
                     AV25Res_SDT_ContentPage.gxTpr_Content.Add(AV26ContentItem, 0);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               AV32GXV1 = 1;
               while ( AV32GXV1 <= AV14SDT_ContentPage.gxTpr_Cta.Count )
               {
                  AV21CtaItem = ((SdtSDT_ContentPage_CtaItem)AV14SDT_ContentPage.gxTpr_Cta.Item(AV32GXV1));
                  AV29BC_Trn_CallToAction.Load(AV21CtaItem.gxTpr_Ctaid);
                  if ( StringUtil.StrCmp(AV29BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Phone") == 0 )
                  {
                     AV21CtaItem.gxTpr_Ctaaction = AV29BC_Trn_CallToAction.gxTpr_Calltoactionphonenumber;
                  }
                  else if ( StringUtil.StrCmp(AV29BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Form") == 0 )
                  {
                     AV21CtaItem.gxTpr_Ctaaction = AV29BC_Trn_CallToAction.gxTpr_Calltoactionurl;
                  }
                  else if ( StringUtil.StrCmp(AV29BC_Trn_CallToAction.gxTpr_Calltoactiontype, "SiteUrl") == 0 )
                  {
                     AV21CtaItem.gxTpr_Ctaaction = AV29BC_Trn_CallToAction.gxTpr_Calltoactionurl;
                  }
                  else if ( StringUtil.StrCmp(AV29BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Email") == 0 )
                  {
                     AV21CtaItem.gxTpr_Ctaaction = AV29BC_Trn_CallToAction.gxTpr_Calltoactionemail;
                  }
                  else
                  {
                  }
                  AV32GXV1 = (int)(AV32GXV1+1);
               }
            }
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
         AV25Res_SDT_ContentPage = new SdtSDT_ContentPage(context);
         P009L2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009L2_n58ProductServiceId = new bool[] {false} ;
         P009L2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009L2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009L2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009L2_A40000ProductServiceImage_GXI = new string[] {""} ;
         P009L2_A60ProductServiceDescription = new string[] {""} ;
         P009L2_A439PageIsContentPage = new bool[] {false} ;
         P009L2_n439PageIsContentPage = new bool[] {false} ;
         P009L2_A431PageJsonContent = new string[] {""} ;
         P009L2_n431PageJsonContent = new bool[] {false} ;
         P009L2_A504PageIsPredefined = new bool[] {false} ;
         P009L2_A318Trn_PageName = new string[] {""} ;
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A60ProductServiceDescription = "";
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         AV14SDT_ContentPage = new SdtSDT_ContentPage(context);
         P009L3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009L3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009L3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009L3_n58ProductServiceId = new bool[] {false} ;
         AV26ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV21CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV29BC_Trn_CallToAction = new SdtTrn_CallToAction(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_contentpageapi__default(),
            new Object[][] {
                new Object[] {
               P009L2_A58ProductServiceId, P009L2_n58ProductServiceId, P009L2_A11OrganisationId, P009L2_A29LocationId, P009L2_A310Trn_PageId, P009L2_A40000ProductServiceImage_GXI, P009L2_A60ProductServiceDescription, P009L2_A439PageIsContentPage, P009L2_n439PageIsContentPage, P009L2_A431PageJsonContent,
               P009L2_n431PageJsonContent, P009L2_A504PageIsPredefined, P009L2_A318Trn_PageName
               }
               , new Object[] {
               P009L3_A29LocationId, P009L3_A11OrganisationId, P009L3_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV1 ;
      private bool n58ProductServiceId ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool n431PageJsonContent ;
      private bool A504PageIsPredefined ;
      private string A60ProductServiceDescription ;
      private string A431PageJsonContent ;
      private string A40000ProductServiceImage_GXI ;
      private string A318Trn_PageName ;
      private Guid AV23PageId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPage AV25Res_SDT_ContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009L2_A58ProductServiceId ;
      private bool[] P009L2_n58ProductServiceId ;
      private Guid[] P009L2_A11OrganisationId ;
      private Guid[] P009L2_A29LocationId ;
      private Guid[] P009L2_A310Trn_PageId ;
      private string[] P009L2_A40000ProductServiceImage_GXI ;
      private string[] P009L2_A60ProductServiceDescription ;
      private bool[] P009L2_A439PageIsContentPage ;
      private bool[] P009L2_n439PageIsContentPage ;
      private string[] P009L2_A431PageJsonContent ;
      private bool[] P009L2_n431PageJsonContent ;
      private bool[] P009L2_A504PageIsPredefined ;
      private string[] P009L2_A318Trn_PageName ;
      private SdtSDT_ContentPage AV14SDT_ContentPage ;
      private Guid[] P009L3_A29LocationId ;
      private Guid[] P009L3_A11OrganisationId ;
      private Guid[] P009L3_A58ProductServiceId ;
      private bool[] P009L3_n58ProductServiceId ;
      private SdtSDT_ContentPage_ContentItem AV26ContentItem ;
      private SdtSDT_ContentPage_CtaItem AV21CtaItem ;
      private SdtTrn_CallToAction AV29BC_Trn_CallToAction ;
      private SdtSDT_ContentPage aP3_Res_SDT_ContentPage ;
   }

   public class aprc_contentpageapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009L2;
          prmP009L2 = new Object[] {
          new ParDef("AV23PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009L3;
          prmP009L3 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009L2", "SELECT T1.ProductServiceId, T1.OrganisationId, T1.LocationId, T1.Trn_PageId, T2.ProductServiceImage_GXI, T2.ProductServiceDescription, T1.PageIsContentPage, T1.PageJsonContent, T1.PageIsPredefined, T1.Trn_PageName FROM (Trn_Page T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE (T1.Trn_PageId = :AV23PageId) AND (T1.LocationId = :AV8LocationId) AND (T1.OrganisationId = :AV9OrganisationId) AND (T1.PageIsContentPage = TRUE) ORDER BY T1.Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L3", "SELECT LocationId, OrganisationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :Trn_PageId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((bool[]) buf[11])[0] = rslt.getBool(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
