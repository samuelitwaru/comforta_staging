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
   public class aprc_uploadmedia : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_uploadmedia().MainImpl(args); ;
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

      public aprc_uploadmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_uploadmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MediaName ,
                           string aP1_MediaImageData ,
                           int aP2_MediaSize ,
                           string aP3_MediaType ,
                           out SdtTrn_Media aP4_BC_Trn_Media ,
                           out SdtSDT_Error aP5_Error )
      {
         this.AV12MediaName = aP0_MediaName;
         this.AV18MediaImageData = aP1_MediaImageData;
         this.AV20MediaSize = aP2_MediaSize;
         this.AV21MediaType = aP3_MediaType;
         this.AV14BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV28Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_BC_Trn_Media=this.AV14BC_Trn_Media;
         aP5_Error=this.AV28Error;
      }

      public SdtSDT_Error executeUdp( string aP0_MediaName ,
                                      string aP1_MediaImageData ,
                                      int aP2_MediaSize ,
                                      string aP3_MediaType ,
                                      out SdtTrn_Media aP4_BC_Trn_Media )
      {
         execute(aP0_MediaName, aP1_MediaImageData, aP2_MediaSize, aP3_MediaType, out aP4_BC_Trn_Media, out aP5_Error);
         return AV28Error ;
      }

      public void executeSubmit( string aP0_MediaName ,
                                 string aP1_MediaImageData ,
                                 int aP2_MediaSize ,
                                 string aP3_MediaType ,
                                 out SdtTrn_Media aP4_BC_Trn_Media ,
                                 out SdtSDT_Error aP5_Error )
      {
         this.AV12MediaName = aP0_MediaName;
         this.AV18MediaImageData = aP1_MediaImageData;
         this.AV20MediaSize = aP2_MediaSize;
         this.AV21MediaType = aP3_MediaType;
         this.AV14BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV28Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_BC_Trn_Media=this.AV14BC_Trn_Media;
         aP5_Error=this.AV28Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV28Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV28Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV29GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
            AV30baseUrl = AV29GAMApplication.gxTpr_Environment.gxTpr_Url;
            AV14BC_Trn_Media = new SdtTrn_Media(context);
            AV14BC_Trn_Media.gxTpr_Medianame = AV12MediaName;
            AV14BC_Trn_Media.gxTpr_Mediasize = AV20MediaSize;
            AV14BC_Trn_Media.gxTpr_Mediatype = AV21MediaType;
            GXt_guid1 = Guid.Empty;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV14BC_Trn_Media.gxTpr_Locationid = GXt_guid1;
            AV23MediaUrl = AV30baseUrl + context.GetMessage( "media/", "") + AV12MediaName;
            AV14BC_Trn_Media.gxTpr_Mediaurl = AV23MediaUrl;
            AV14BC_Trn_Media.Save();
            new prc_logtofile(context ).execute(  AV14BC_Trn_Media.ToJSonString(true, true)) ;
            new prc_logtofile(context ).execute(  StringUtil.BoolToStr( AV14BC_Trn_Media.Success())) ;
            if ( AV14BC_Trn_Media.Success() )
            {
               AV22Path = context.GetMessage( "media/", "");
               if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, context.GetMessage( "http://localhost", "")) )
               {
                  AV22Path = context.GetMessage( "C:\\KBs\\Comforta_version2\\Data018\\Web\\media\\", "");
               }
               new SdtEO_Base64Image(context).saveimage(AV18MediaImageData, AV22Path+AV12MediaName) ;
               new prc_logtofile(context ).execute(  AV22Path+AV12MediaName) ;
               AV10response = AV14BC_Trn_Media.ToJSonString(true, true);
               context.CommitDataStores("prc_uploadmedia",pr_default);
            }
            else
            {
               AV32GXV2 = 1;
               AV31GXV1 = AV14BC_Trn_Media.GetMessages();
               while ( AV32GXV2 <= AV31GXV1.Count )
               {
                  AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV31GXV1.Item(AV32GXV2));
                  new prc_logtofile(context ).execute(  AV17Message.gxTpr_Description) ;
                  AV32GXV2 = (int)(AV32GXV2+1);
               }
               AV10response = context.GetMessage( "Insert ERROR", "");
               context.RollbackDataStores("prc_uploadmedia",pr_default);
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
         AV14BC_Trn_Media = new SdtTrn_Media(context);
         AV28Error = new SdtSDT_Error(context);
         AV29GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV30baseUrl = "";
         GXt_guid1 = Guid.Empty;
         AV23MediaUrl = "";
         AV22Path = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV10response = "";
         AV31GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadmedia__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadmedia__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadmedia__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV20MediaSize ;
      private int AV32GXV2 ;
      private string AV21MediaType ;
      private string AV18MediaImageData ;
      private string AV10response ;
      private string AV12MediaName ;
      private string AV30baseUrl ;
      private string AV23MediaUrl ;
      private string AV22Path ;
      private Guid GXt_guid1 ;
      private GxHttpRequest AV8HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Media AV14BC_Trn_Media ;
      private SdtSDT_Error AV28Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV29GAMApplication ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
      private SdtTrn_Media aP4_BC_Trn_Media ;
      private SdtSDT_Error aP5_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_uploadmedia__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_uploadmedia__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_uploadmedia__default : DataStoreHelperBase, IDataStoreHelper
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
