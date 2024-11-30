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
   public class prc_updatepage : GXProcedure
   {
      public prc_updatepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_PageId ,
                           ref string aP1_PageName ,
                           ref string aP2_PageJsonContent ,
                           ref string aP3_PageGJSHtml ,
                           ref string aP4_PageGJSJson ,
                           ref bool aP5_PageIsPublished ,
                           out string aP6_Response )
      {
         this.AV8PageId = aP0_PageId;
         this.AV18PageName = aP1_PageName;
         this.AV12PageJsonContent = aP2_PageJsonContent;
         this.AV13PageGJSHtml = aP3_PageGJSHtml;
         this.AV11PageGJSJson = aP4_PageGJSJson;
         this.AV17PageIsPublished = aP5_PageIsPublished;
         this.AV10Response = "" ;
         initialize();
         ExecuteImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageName=this.AV18PageName;
         aP2_PageJsonContent=this.AV12PageJsonContent;
         aP3_PageGJSHtml=this.AV13PageGJSHtml;
         aP4_PageGJSJson=this.AV11PageGJSJson;
         aP5_PageIsPublished=this.AV17PageIsPublished;
         aP6_Response=this.AV10Response;
      }

      public string executeUdp( ref Guid aP0_PageId ,
                                ref string aP1_PageName ,
                                ref string aP2_PageJsonContent ,
                                ref string aP3_PageGJSHtml ,
                                ref string aP4_PageGJSJson ,
                                ref bool aP5_PageIsPublished )
      {
         execute(ref aP0_PageId, ref aP1_PageName, ref aP2_PageJsonContent, ref aP3_PageGJSHtml, ref aP4_PageGJSJson, ref aP5_PageIsPublished, out aP6_Response);
         return AV10Response ;
      }

      public void executeSubmit( ref Guid aP0_PageId ,
                                 ref string aP1_PageName ,
                                 ref string aP2_PageJsonContent ,
                                 ref string aP3_PageGJSHtml ,
                                 ref string aP4_PageGJSJson ,
                                 ref bool aP5_PageIsPublished ,
                                 out string aP6_Response )
      {
         this.AV8PageId = aP0_PageId;
         this.AV18PageName = aP1_PageName;
         this.AV12PageJsonContent = aP2_PageJsonContent;
         this.AV13PageGJSHtml = aP3_PageGJSHtml;
         this.AV11PageGJSJson = aP4_PageGJSJson;
         this.AV17PageIsPublished = aP5_PageIsPublished;
         this.AV10Response = "" ;
         SubmitImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageName=this.AV18PageName;
         aP2_PageJsonContent=this.AV12PageJsonContent;
         aP3_PageGJSHtml=this.AV13PageGJSHtml;
         aP4_PageGJSJson=this.AV11PageGJSJson;
         aP5_PageIsPublished=this.AV17PageIsPublished;
         aP6_Response=this.AV10Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV19UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV19UserName = GXt_char1;
         /* Using cursor P008R2 */
         pr_default.execute(0, new Object[] {AV19UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P008R2_A93ReceptionistEmail[0];
            A29LocationId = P008R2_A29LocationId[0];
            A89ReceptionistId = P008R2_A89ReceptionistId[0];
            A11OrganisationId = P008R2_A11OrganisationId[0];
            AV20LocationId = A29LocationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9BC_Trn_Page.Load(AV8PageId, AV18PageName, AV20LocationId);
         new prc_logtofile(context ).execute(  ">>>>>>"+AV12PageJsonContent) ;
         if ( ! (Guid.Empty==AV9BC_Trn_Page.gxTpr_Trn_pageid) )
         {
            AV9BC_Trn_Page.gxTpr_Pagegjsjson = AV11PageGJSJson;
            if ( AV17PageIsPublished )
            {
               AV9BC_Trn_Page.gxTpr_Pagejsoncontent = AV12PageJsonContent;
               AV9BC_Trn_Page.gxTpr_Pageispublished = AV17PageIsPublished;
            }
            AV9BC_Trn_Page.gxTpr_Pagegjshtml = AV13PageGJSHtml;
            AV9BC_Trn_Page.Save();
            if ( AV9BC_Trn_Page.Success() )
            {
               AV10Response = context.GetMessage( "Page Save Successfully", "");
               context.CommitDataStores("prc_updatepage",pr_default);
            }
            else
            {
               AV23GXV2 = 1;
               AV22GXV1 = AV9BC_Trn_Page.GetMessages();
               while ( AV23GXV2 <= AV22GXV1.Count )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV22GXV1.Item(AV23GXV2));
                  new prc_logtofile(context ).execute(  AV14Message.gxTpr_Description) ;
                  AV23GXV2 = (int)(AV23GXV2+1);
               }
            }
         }
         else
         {
            AV10Response = context.GetMessage( "Page Not Found", "");
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
         AV10Response = "";
         AV19UserName = "";
         GXt_char1 = "";
         P008R2_A93ReceptionistEmail = new string[] {""} ;
         P008R2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008R2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P008R2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20LocationId = Guid.Empty;
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         AV22GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__default(),
            new Object[][] {
                new Object[] {
               P008R2_A93ReceptionistEmail, P008R2_A29LocationId, P008R2_A89ReceptionistId, P008R2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV2 ;
      private string GXt_char1 ;
      private bool AV17PageIsPublished ;
      private string AV12PageJsonContent ;
      private string AV13PageGJSHtml ;
      private string AV11PageGJSJson ;
      private string AV10Response ;
      private string AV18PageName ;
      private string AV19UserName ;
      private string A93ReceptionistEmail ;
      private Guid AV8PageId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid AV20LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_PageId ;
      private string aP1_PageName ;
      private string aP2_PageJsonContent ;
      private string aP3_PageGJSHtml ;
      private string aP4_PageGJSJson ;
      private bool aP5_PageIsPublished ;
      private IDataStoreProvider pr_default ;
      private string[] P008R2_A93ReceptionistEmail ;
      private Guid[] P008R2_A29LocationId ;
      private Guid[] P008R2_A89ReceptionistId ;
      private Guid[] P008R2_A11OrganisationId ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private string aP6_Response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatepage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatepage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP008R2;
       prmP008R2 = new Object[] {
       new ParDef("AV19UserName",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008R2", "SELECT ReceptionistEmail, LocationId, ReceptionistId, OrganisationId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV19UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R2,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
    }
 }

}

}
