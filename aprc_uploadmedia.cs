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

      public void execute( Guid aP0_MediaId ,
                           string aP1_MediaName ,
                           string aP2_MediaImageData ,
                           int aP3_MediaSize ,
                           string aP4_MediaType ,
                           out SdtTrn_Media aP5_BC_Trn_Media )
      {
         this.AV11MediaId = aP0_MediaId;
         this.AV12MediaName = aP1_MediaName;
         this.AV18MediaImageData = aP2_MediaImageData;
         this.AV20MediaSize = aP3_MediaSize;
         this.AV21MediaType = aP4_MediaType;
         this.AV14BC_Trn_Media = new SdtTrn_Media(context) ;
         initialize();
         ExecuteImpl();
         aP5_BC_Trn_Media=this.AV14BC_Trn_Media;
      }

      public SdtTrn_Media executeUdp( Guid aP0_MediaId ,
                                      string aP1_MediaName ,
                                      string aP2_MediaImageData ,
                                      int aP3_MediaSize ,
                                      string aP4_MediaType )
      {
         execute(aP0_MediaId, aP1_MediaName, aP2_MediaImageData, aP3_MediaSize, aP4_MediaType, out aP5_BC_Trn_Media);
         return AV14BC_Trn_Media ;
      }

      public void executeSubmit( Guid aP0_MediaId ,
                                 string aP1_MediaName ,
                                 string aP2_MediaImageData ,
                                 int aP3_MediaSize ,
                                 string aP4_MediaType ,
                                 out SdtTrn_Media aP5_BC_Trn_Media )
      {
         this.AV11MediaId = aP0_MediaId;
         this.AV12MediaName = aP1_MediaName;
         this.AV18MediaImageData = aP2_MediaImageData;
         this.AV20MediaSize = aP3_MediaSize;
         this.AV21MediaType = aP4_MediaType;
         this.AV14BC_Trn_Media = new SdtTrn_Media(context) ;
         SubmitImpl();
         aP5_BC_Trn_Media=this.AV14BC_Trn_Media;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV27UserName, ref  AV25LocationId, ref  AV26OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27UserName))) )
         {
            cleanup();
            if (true) return;
         }
         new prc_logtofile(context ).execute(  "MediaName: "+AV12MediaName) ;
         new prc_logtofile(context ).execute(  "MediaSize: "+StringUtil.Str( (decimal)(AV20MediaSize), 8, 0)) ;
         new prc_logtofile(context ).execute(  "MediaType: "+AV21MediaType) ;
         AV14BC_Trn_Media = new SdtTrn_Media(context);
         AV14BC_Trn_Media.gxTpr_Medianame = AV12MediaName;
         AV14BC_Trn_Media.gxTpr_Mediasize = AV20MediaSize;
         AV14BC_Trn_Media.gxTpr_Mediatype = AV21MediaType;
         AV14BC_Trn_Media.gxTpr_Locationid = AV25LocationId;
         AV23MediaUrl = StringUtil.StringReplace( AV8HttpRequest.BaseURL, "api/media/", "media/"+AV12MediaName);
         if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, "http://localhost") )
         {
         }
         else
         {
            AV23MediaUrl = StringUtil.StringReplace( AV23MediaUrl, "http://", "https://");
         }
         AV14BC_Trn_Media.gxTpr_Mediaurl = AV23MediaUrl;
         AV14BC_Trn_Media.Save();
         new prc_logtofile(context ).execute(  AV14BC_Trn_Media.ToJSonString(true, true)) ;
         new prc_logtofile(context ).execute(  StringUtil.BoolToStr( AV14BC_Trn_Media.Success())) ;
         if ( AV14BC_Trn_Media.Success() )
         {
            AV22Path = "media/";
            if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, "http://localhost") )
            {
               AV22Path = "C:\\KBs\\Comforta_version2\\Data018\\Web\\media\\";
            }
            new SdtEO_Base64Image(context).saveimage(AV18MediaImageData, AV22Path+AV12MediaName) ;
            new prc_logtofile(context ).execute(  AV22Path+AV12MediaName) ;
            AV10response = AV14BC_Trn_Media.ToJSonString(true, true);
            context.CommitDataStores("prc_uploadmedia",pr_default);
         }
         else
         {
            AV29GXV2 = 1;
            AV28GXV1 = AV14BC_Trn_Media.GetMessages();
            while ( AV29GXV2 <= AV28GXV1.Count )
            {
               AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV28GXV1.Item(AV29GXV2));
               new prc_logtofile(context ).execute(  AV17Message.gxTpr_Description) ;
               AV29GXV2 = (int)(AV29GXV2+1);
            }
            AV10response = "Insert ERROR";
            context.RollbackDataStores("prc_uploadmedia",pr_default);
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
         AV27UserName = "";
         AV25LocationId = Guid.Empty;
         AV26OrganisationId = Guid.Empty;
         AV23MediaUrl = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV22Path = "";
         AV10response = "";
         AV28GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
      private int AV29GXV2 ;
      private string AV21MediaType ;
      private string AV18MediaImageData ;
      private string AV10response ;
      private string AV12MediaName ;
      private string AV27UserName ;
      private string AV23MediaUrl ;
      private string AV22Path ;
      private Guid AV11MediaId ;
      private Guid AV25LocationId ;
      private Guid AV26OrganisationId ;
      private GxHttpRequest AV8HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Media AV14BC_Trn_Media ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
      private SdtTrn_Media aP5_BC_Trn_Media ;
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
