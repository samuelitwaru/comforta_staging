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
                           out SdtSDT_ContentPageV1 aP3_Res_SDT_ContentPage )
      {
         this.AV23PageId = aP0_PageId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV25Res_SDT_ContentPage = new SdtSDT_ContentPageV1(context) ;
         initialize();
         ExecuteImpl();
         aP3_Res_SDT_ContentPage=this.AV25Res_SDT_ContentPage;
      }

      public SdtSDT_ContentPageV1 executeUdp( Guid aP0_PageId ,
                                              Guid aP1_LocationId ,
                                              Guid aP2_OrganisationId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, out aP3_Res_SDT_ContentPage);
         return AV25Res_SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_ContentPageV1 aP3_Res_SDT_ContentPage )
      {
         this.AV23PageId = aP0_PageId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV25Res_SDT_ContentPage = new SdtSDT_ContentPageV1(context) ;
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
            A439PageIsContentPage = P009L2_A439PageIsContentPage[0];
            n439PageIsContentPage = P009L2_n439PageIsContentPage[0];
            A11OrganisationId = P009L2_A11OrganisationId[0];
            A29LocationId = P009L2_A29LocationId[0];
            A310Trn_PageId = P009L2_A310Trn_PageId[0];
            A431PageJsonContent = P009L2_A431PageJsonContent[0];
            n431PageJsonContent = P009L2_n431PageJsonContent[0];
            A504PageIsPredefined = P009L2_A504PageIsPredefined[0];
            A40000ProductServiceImage_GXI = P009L2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P009L2_A60ProductServiceDescription[0];
            A318Trn_PageName = P009L2_A318Trn_PageName[0];
            A40000ProductServiceImage_GXI = P009L2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P009L2_A60ProductServiceDescription[0];
            AV14SDT_ContentPage = new SdtSDT_ContentPageV1(context);
            AV14SDT_ContentPage.FromJSonString(A431PageJsonContent, null);
            AV25Res_SDT_ContentPage = new SdtSDT_ContentPageV1(context);
            AV25Res_SDT_ContentPage = AV14SDT_ContentPage;
            AV10BC_Trn_ProductService.Load(AV23PageId, AV8LocationId, AV9OrganisationId);
            if ( ! A504PageIsPredefined )
            {
               AV32GXV1 = 1;
               while ( AV32GXV1 <= AV14SDT_ContentPage.gxTpr_Content.Count )
               {
                  AV26ContentItem = ((SdtSDT_ContentPageV1_ContentItem)AV14SDT_ContentPage.gxTpr_Content.Item(AV32GXV1));
                  if ( StringUtil.StrCmp(AV26ContentItem.gxTpr_Contenttype, context.GetMessage( "Image", "")) == 0 )
                  {
                     AV26ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
                  }
                  else if ( StringUtil.StrCmp(AV26ContentItem.gxTpr_Contenttype, context.GetMessage( "Description", "")) == 0 )
                  {
                     AV26ContentItem.gxTpr_Contentvalue = A60ProductServiceDescription;
                  }
                  else
                  {
                  }
                  AV32GXV1 = (int)(AV32GXV1+1);
               }
               AV33GXV2 = 1;
               while ( AV33GXV2 <= AV14SDT_ContentPage.gxTpr_Cta.Count )
               {
                  AV21CtaItem = ((SdtSDT_ContentPageV1_CtaItem)AV14SDT_ContentPage.gxTpr_Cta.Item(AV33GXV2));
                  AV29BC_Trn_CallToAction.Load(AV21CtaItem.gxTpr_Ctaid);
                  if ( StringUtil.StrCmp(AV29BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Phone") == 0 )
                  {
                     AV21CtaItem.gxTpr_Ctaaction = AV29BC_Trn_CallToAction.gxTpr_Calltoactionphone;
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
                  AV25Res_SDT_ContentPage.gxTpr_Cta.Add(AV21CtaItem, 0);
                  AV33GXV2 = (int)(AV33GXV2+1);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A318Trn_PageName, "Location") == 0 )
               {
                  AV30BC_Trn_Location.Load(AV8LocationId, AV9OrganisationId);
                  AV14SDT_ContentPage.gxTpr_Content.Clear();
                  AV26ContentItem = new SdtSDT_ContentPageV1_ContentItem(context);
                  AV26ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
                  AV26ContentItem.gxTpr_Contentvalue = AV30BC_Trn_Location.gxTpr_Locationimage_gxi;
                  AV14SDT_ContentPage.gxTpr_Content.Add(AV26ContentItem, 0);
                  AV26ContentItem = new SdtSDT_ContentPageV1_ContentItem(context);
                  AV26ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
                  AV26ContentItem.gxTpr_Contentvalue = AV30BC_Trn_Location.gxTpr_Locationdescription;
                  AV14SDT_ContentPage.gxTpr_Content.Add(AV26ContentItem, 0);
               }
               if ( ( StringUtil.StrCmp(A318Trn_PageName, "Location") == 0 ) || ( StringUtil.StrCmp(A318Trn_PageName, "Reception") == 0 ) )
               {
                  AV14SDT_ContentPage.gxTpr_Cta.Clear();
                  AV21CtaItem = new SdtSDT_ContentPageV1_CtaItem(context);
                  AV21CtaItem.gxTpr_Ctaid = Guid.NewGuid( );
                  AV21CtaItem.gxTpr_Ctalabel = "CALL US";
                  AV21CtaItem.gxTpr_Ctabgcolor = "#5068a8";
                  AV21CtaItem.gxTpr_Ctatype = "Phone";
                  AV21CtaItem.gxTpr_Ctaaction = AV30BC_Trn_Location.gxTpr_Locationphone;
                  AV14SDT_ContentPage.gxTpr_Cta.Add(AV21CtaItem, 0);
                  AV21CtaItem = new SdtSDT_ContentPageV1_CtaItem(context);
                  AV21CtaItem.gxTpr_Ctaid = Guid.NewGuid( );
                  AV21CtaItem.gxTpr_Ctalabel = "EMAIL US";
                  AV21CtaItem.gxTpr_Ctabgcolor = "#5068a8";
                  AV21CtaItem.gxTpr_Ctatype = "Email";
                  AV21CtaItem.gxTpr_Ctaaction = AV30BC_Trn_Location.gxTpr_Locationphone;
                  AV14SDT_ContentPage.gxTpr_Cta.Add(AV21CtaItem, 0);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV25Res_SDT_ContentPage = new SdtSDT_ContentPageV1(context);
         P009L2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009L2_n58ProductServiceId = new bool[] {false} ;
         P009L2_A439PageIsContentPage = new bool[] {false} ;
         P009L2_n439PageIsContentPage = new bool[] {false} ;
         P009L2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009L2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009L2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009L2_A431PageJsonContent = new string[] {""} ;
         P009L2_n431PageJsonContent = new bool[] {false} ;
         P009L2_A504PageIsPredefined = new bool[] {false} ;
         P009L2_A40000ProductServiceImage_GXI = new string[] {""} ;
         P009L2_A60ProductServiceDescription = new string[] {""} ;
         P009L2_A318Trn_PageName = new string[] {""} ;
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A431PageJsonContent = "";
         A40000ProductServiceImage_GXI = "";
         A60ProductServiceDescription = "";
         A318Trn_PageName = "";
         AV14SDT_ContentPage = new SdtSDT_ContentPageV1(context);
         AV10BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV26ContentItem = new SdtSDT_ContentPageV1_ContentItem(context);
         AV21CtaItem = new SdtSDT_ContentPageV1_CtaItem(context);
         AV29BC_Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV30BC_Trn_Location = new SdtTrn_Location(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_contentpageapi__default(),
            new Object[][] {
                new Object[] {
               P009L2_A58ProductServiceId, P009L2_n58ProductServiceId, P009L2_A439PageIsContentPage, P009L2_n439PageIsContentPage, P009L2_A11OrganisationId, P009L2_A29LocationId, P009L2_A310Trn_PageId, P009L2_A431PageJsonContent, P009L2_n431PageJsonContent, P009L2_A504PageIsPredefined,
               P009L2_A40000ProductServiceImage_GXI, P009L2_A60ProductServiceDescription, P009L2_A318Trn_PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV1 ;
      private int AV33GXV2 ;
      private bool n58ProductServiceId ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool n431PageJsonContent ;
      private bool A504PageIsPredefined ;
      private string A431PageJsonContent ;
      private string A60ProductServiceDescription ;
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
      private SdtSDT_ContentPageV1 AV25Res_SDT_ContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009L2_A58ProductServiceId ;
      private bool[] P009L2_n58ProductServiceId ;
      private bool[] P009L2_A439PageIsContentPage ;
      private bool[] P009L2_n439PageIsContentPage ;
      private Guid[] P009L2_A11OrganisationId ;
      private Guid[] P009L2_A29LocationId ;
      private Guid[] P009L2_A310Trn_PageId ;
      private string[] P009L2_A431PageJsonContent ;
      private bool[] P009L2_n431PageJsonContent ;
      private bool[] P009L2_A504PageIsPredefined ;
      private string[] P009L2_A40000ProductServiceImage_GXI ;
      private string[] P009L2_A60ProductServiceDescription ;
      private string[] P009L2_A318Trn_PageName ;
      private SdtSDT_ContentPageV1 AV14SDT_ContentPage ;
      private SdtTrn_ProductService AV10BC_Trn_ProductService ;
      private SdtSDT_ContentPageV1_ContentItem AV26ContentItem ;
      private SdtSDT_ContentPageV1_CtaItem AV21CtaItem ;
      private SdtTrn_CallToAction AV29BC_Trn_CallToAction ;
      private SdtTrn_Location AV30BC_Trn_Location ;
      private SdtSDT_ContentPageV1 aP3_Res_SDT_ContentPage ;
   }

   public class aprc_contentpageapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
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
          def= new CursorDef[] {
              new CursorDef("P009L2", "SELECT T1.ProductServiceId, T1.PageIsContentPage, T1.OrganisationId, T1.LocationId, T1.Trn_PageId, T1.PageJsonContent, T1.PageIsPredefined, T2.ProductServiceImage_GXI, T2.ProductServiceDescription, T1.Trn_PageName FROM (Trn_Page T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE (T1.Trn_PageId = :AV23PageId and T1.LocationId = :AV8LocationId) AND (T1.OrganisationId = :AV9OrganisationId) AND (T1.PageIsContentPage = TRUE) ORDER BY T1.Trn_PageId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                return;
       }
    }

 }

}
