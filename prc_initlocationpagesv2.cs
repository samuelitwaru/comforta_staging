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
   public class prc_initlocationpagesv2 : GXProcedure
   {
      public prc_initlocationpagesv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initlocationpagesv2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV15OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV15OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16BC_Trn_Location.Load(AV8LocationId, AV15OrganisationId);
         AV30GXLvl4 = 0;
         /* Using cursor P00BG2 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00BG2_A29LocationId[0];
            A543AppVersionId = P00BG2_A543AppVersionId[0];
            AV30GXLvl4 = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV30GXLvl4 == 0 )
         {
            AV10BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
            AV10BC_Trn_AppVersion.gxTpr_Appversionname = context.GetMessage( "Version 1", "");
            AV10BC_Trn_AppVersion.gxTpr_Locationid = AV8LocationId;
            AV10BC_Trn_AppVersion.gxTpr_Isactive = true;
            GXt_SdtTrn_AppVersion_Page1 = AV29BC_ReceptionPage;
            new prc_initreceptionpage(context ).execute( ref  AV8LocationId, ref  AV15OrganisationId, out  GXt_SdtTrn_AppVersion_Page1) ;
            AV29BC_ReceptionPage = GXt_SdtTrn_AppVersion_Page1;
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV29BC_ReceptionPage, 0);
            GXt_SdtTrn_AppVersion_Page1 = AV28BC_LocationPage;
            new prc_initlocationpage(context ).execute( ref  AV8LocationId, ref  AV15OrganisationId, out  GXt_SdtTrn_AppVersion_Page1) ;
            AV28BC_LocationPage = GXt_SdtTrn_AppVersion_Page1;
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV28BC_LocationPage, 0);
            new prc_initservicepages(context ).execute( out  AV21BC_CarePage, out  AV22BC_LivingPage, out  AV23BC_ServicesPage) ;
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV21BC_CarePage, 0);
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV22BC_LivingPage, 0);
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV23BC_ServicesPage, 0);
            GXt_SdtTrn_AppVersion_Page1 = AV24BC_HomePage;
            new prc_inithomepage(context ).execute(  AV29BC_ReceptionPage.gxTpr_Pageid,  AV28BC_LocationPage.gxTpr_Pageid,  AV21BC_CarePage.gxTpr_Pageid,  AV22BC_LivingPage.gxTpr_Pageid,  AV23BC_ServicesPage.gxTpr_Pageid, out  GXt_SdtTrn_AppVersion_Page1) ;
            AV24BC_HomePage = GXt_SdtTrn_AppVersion_Page1;
            AV10BC_Trn_AppVersion.gxTpr_Page.Add(AV24BC_HomePage, 0);
            AV10BC_Trn_AppVersion.Save();
            if ( AV10BC_Trn_AppVersion.Success() )
            {
               context.CommitDataStores("prc_initlocationpagesv2",pr_default);
            }
            else
            {
               AV32GXV2 = 1;
               AV31GXV1 = AV10BC_Trn_AppVersion.GetMessages();
               while ( AV32GXV2 <= AV31GXV1.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV31GXV1.Item(AV32GXV2));
                  GX_msglist.addItem(AV19Message.gxTpr_Description);
                  AV32GXV2 = (int)(AV32GXV2+1);
               }
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
         AV16BC_Trn_Location = new SdtTrn_Location(context);
         P00BG2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BG2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A543AppVersionId = Guid.Empty;
         AV10BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV29BC_ReceptionPage = new SdtTrn_AppVersion_Page(context);
         AV28BC_LocationPage = new SdtTrn_AppVersion_Page(context);
         AV21BC_CarePage = new SdtTrn_AppVersion_Page(context);
         AV22BC_LivingPage = new SdtTrn_AppVersion_Page(context);
         AV23BC_ServicesPage = new SdtTrn_AppVersion_Page(context);
         AV24BC_HomePage = new SdtTrn_AppVersion_Page(context);
         GXt_SdtTrn_AppVersion_Page1 = new SdtTrn_AppVersion_Page(context);
         AV31GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpagesv2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpagesv2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpagesv2__default(),
            new Object[][] {
                new Object[] {
               P00BG2_A29LocationId, P00BG2_A543AppVersionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30GXLvl4 ;
      private int AV32GXV2 ;
      private Guid AV8LocationId ;
      private Guid AV15OrganisationId ;
      private Guid A29LocationId ;
      private Guid A543AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Location AV16BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BG2_A29LocationId ;
      private Guid[] P00BG2_A543AppVersionId ;
      private SdtTrn_AppVersion AV10BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV29BC_ReceptionPage ;
      private SdtTrn_AppVersion_Page AV28BC_LocationPage ;
      private SdtTrn_AppVersion_Page AV21BC_CarePage ;
      private SdtTrn_AppVersion_Page AV22BC_LivingPage ;
      private SdtTrn_AppVersion_Page AV23BC_ServicesPage ;
      private SdtTrn_AppVersion_Page AV24BC_HomePage ;
      private SdtTrn_AppVersion_Page GXt_SdtTrn_AppVersion_Page1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_initlocationpagesv2__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_initlocationpagesv2__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_initlocationpagesv2__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00BG2;
       prmP00BG2 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BG2", "SELECT LocationId, AppVersionId FROM Trn_AppVersion WHERE LocationId = :AV8LocationId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG2,100, GxCacheFrequency.OFF ,false,false )
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
             return;
    }
 }

}

}
