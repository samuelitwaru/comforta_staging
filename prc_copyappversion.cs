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
   public class prc_copyappversion : GXProcedure
   {
      public prc_copyappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_copyappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, out aP1_SDT_AppVersion, out aP2_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV24Trn_AppVersion.Load(AV23AppVersionId);
         AV10LocationId = AV24Trn_AppVersion.gxTpr_Locationid;
         AV13OrganisationId = AV24Trn_AppVersion.gxTpr_Organisationid;
         AV11BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
         AV11BC_Trn_AppVersion.gxTpr_Appversionname = StringUtil.Format( AV24Trn_AppVersion.gxTpr_Appversionname, context.GetMessage( "Copy", ""), "", "", "", "", "", "", "", "");
         AV11BC_Trn_AppVersion.gxTpr_Locationid = AV10LocationId;
         AV11BC_Trn_AppVersion.gxTpr_Organisationid = AV13OrganisationId;
         AV11BC_Trn_AppVersion.gxTpr_Isactive = false;
         AV11BC_Trn_AppVersion.gxTpr_Page = AV24Trn_AppVersion.gxTpr_Page;
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_copyappversion",pr_default);
            new prc_loadappversionsdt(context ).execute(  AV11BC_Trn_AppVersion, out  AV8SDT_AppVersion) ;
         }
         else
         {
            AV26GXV2 = 1;
            AV25GXV1 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV26GXV2 <= AV25GXV1.Count )
            {
               AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV25GXV1.Item(AV26GXV2));
               GX_msglist.addItem(AV21Message.gxTpr_Description);
               AV26GXV2 = (int)(AV26GXV2+1);
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
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV24Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV10LocationId = Guid.Empty;
         AV13OrganisationId = Guid.Empty;
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV25GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV26GXV2 ;
      private Guid AV23AppVersionId ;
      private Guid AV10LocationId ;
      private Guid AV13OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private SdtTrn_AppVersion AV24Trn_AppVersion ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV25GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_copyappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_copyappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_copyappversion__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
