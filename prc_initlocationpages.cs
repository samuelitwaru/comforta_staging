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
   public class prc_initlocationpages : GXProcedure
   {
      public prc_initlocationpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initlocationpages( IGxContext context )
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
         this.AV12OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV12OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9PredefinedPagesDictionary.set( "34f798f2-7b6c-4a8f-bdea-d14273b5a678",  "Home");
         AV9PredefinedPagesDictionary.set( "1e5d1be0-d9ef-4ff7-869d-1b1f3092155c",  "Reception");
         AV9PredefinedPagesDictionary.set( "784c2d18-622f-43f3-bde1-7b00035d6a07",  "Location");
         AV9PredefinedPagesDictionary.set( "5e200c35-16fe-4401-93c6-b106d14c89cc",  "Calendar");
         AV9PredefinedPagesDictionary.set( "e22b29bc-1982-414a-87cf-71a839806a75",  "Mailbox");
         new prc_logtofile(context ).execute(  AV8LocationId.ToString()) ;
         new prc_logtofile(context ).execute(  AV12OrganisationId.ToString()) ;
         AV14BC_Trn_Location.Load(AV8LocationId, AV12OrganisationId);
         new prc_logtofile(context ).execute(  AV14BC_Trn_Location.ToJSonString(true, true)) ;
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV9PredefinedPagesDictionary.gxTpr_Keys.Count )
         {
            AV11Key = ((string)AV9PredefinedPagesDictionary.gxTpr_Keys.Item(AV20GXV1));
            AV16Value = AV9PredefinedPagesDictionary.get(AV11Key);
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = "PredefinedPages/Default"+AV16Value+".txt";
            AV13PageGJSJson = AV15File.ReadAllText("");
            if ( StringUtil.StrCmp(AV16Value, "Location") == 0 )
            {
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, "{{LocationImage}}", "https://staging.comforta.yukon.software/media/LocationInfo.png");
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, "{{LocationDescription}}", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            }
            if ( StringUtil.StrCmp(AV16Value, "Reception") == 0 )
            {
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, "{{LocationImage}}", "https://staging.comforta.yukon.software/media/receptie-197@3x.png");
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, "{{LocationDescription}}", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            }
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = StringUtil.StrToGuid( AV11Key);
            AV18BC_Trn_Page.gxTpr_Trn_pagename = AV16Value;
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = false;
            AV18BC_Trn_Page.gxTpr_Pageispredefined = true;
            AV18BC_Trn_Page.gxTpr_Locationid = AV14BC_Trn_Location.gxTpr_Locationid;
            AV18BC_Trn_Page.gxTpr_Organisationid = AV14BC_Trn_Location.gxTpr_Organisationid;
            AV18BC_Trn_Page.gxTpr_Pagegjsjson = AV13PageGJSJson;
            AV18BC_Trn_Page.Save();
            if ( AV18BC_Trn_Page.Success() )
            {
               context.CommitDataStores("prc_initlocationpages",pr_default);
            }
            else
            {
               AV22GXV3 = 1;
               AV21GXV2 = AV18BC_Trn_Page.GetMessages();
               while ( AV22GXV3 <= AV21GXV2.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV21GXV2.Item(AV22GXV3));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV22GXV3 = (int)(AV22GXV3+1);
               }
            }
            AV20GXV1 = (int)(AV20GXV1+1);
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
         AV9PredefinedPagesDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV14BC_Trn_Location = new SdtTrn_Location(context);
         AV11Key = "";
         AV16Value = "";
         AV15File = new GxFile(context.GetPhysicalPath());
         AV13PageGJSJson = "";
         AV18BC_Trn_Page = new SdtTrn_Page(context);
         AV21GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private int AV22GXV3 ;
      private string AV13PageGJSJson ;
      private string AV11Key ;
      private string AV16Value ;
      private Guid AV8LocationId ;
      private Guid AV12OrganisationId ;
      private GxFile AV15File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV9PredefinedPagesDictionary ;
      private SdtTrn_Location AV14BC_Trn_Location ;
      private SdtTrn_Page AV18BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_initlocationpages__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_initlocationpages__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_initlocationpages__default : DataStoreHelperBase, IDataStoreHelper
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
