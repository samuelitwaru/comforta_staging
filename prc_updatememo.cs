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
   public class prc_updatememo : GXProcedure
   {
      public prc_updatememo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatememo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           string aP1_ResidentGUID ,
                           Guid aP2_MemoCategoryId ,
                           string aP3_MemoTitle ,
                           string aP4_MemoDescription ,
                           string aP5_MemoImage ,
                           string aP6_MemoDocument ,
                           DateTime aP7_MemoStartDateTime ,
                           DateTime aP8_MemoEndDateTime ,
                           short aP9_MemoDuration ,
                           DateTime aP10_MemoRemoveDate ,
                           string aP11_MemoBgColorCode ,
                           string aP12_MemoForm ,
                           out SdtSDT_Error aP13_Error )
      {
         this.AV17MemoId = aP0_MemoId;
         this.AV23ResidentGUID = aP1_ResidentGUID;
         this.AV11MemoCategoryId = aP2_MemoCategoryId;
         this.AV21MemoTitle = aP3_MemoTitle;
         this.AV12MemoDescription = aP4_MemoDescription;
         this.AV18MemoImage = aP5_MemoImage;
         this.AV13MemoDocument = aP6_MemoDocument;
         this.AV20MemoStartDateTime = aP7_MemoStartDateTime;
         this.AV15MemoEndDateTime = aP8_MemoEndDateTime;
         this.AV14MemoDuration = aP9_MemoDuration;
         this.AV19MemoRemoveDate = aP10_MemoRemoveDate;
         this.AV10MemoBgColorCode = aP11_MemoBgColorCode;
         this.AV16MemoForm = aP12_MemoForm;
         this.AV8Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP13_Error=this.AV8Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_MemoId ,
                                      string aP1_ResidentGUID ,
                                      Guid aP2_MemoCategoryId ,
                                      string aP3_MemoTitle ,
                                      string aP4_MemoDescription ,
                                      string aP5_MemoImage ,
                                      string aP6_MemoDocument ,
                                      DateTime aP7_MemoStartDateTime ,
                                      DateTime aP8_MemoEndDateTime ,
                                      short aP9_MemoDuration ,
                                      DateTime aP10_MemoRemoveDate ,
                                      string aP11_MemoBgColorCode ,
                                      string aP12_MemoForm )
      {
         execute(aP0_MemoId, aP1_ResidentGUID, aP2_MemoCategoryId, aP3_MemoTitle, aP4_MemoDescription, aP5_MemoImage, aP6_MemoDocument, aP7_MemoStartDateTime, aP8_MemoEndDateTime, aP9_MemoDuration, aP10_MemoRemoveDate, aP11_MemoBgColorCode, aP12_MemoForm, out aP13_Error);
         return AV8Error ;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 string aP1_ResidentGUID ,
                                 Guid aP2_MemoCategoryId ,
                                 string aP3_MemoTitle ,
                                 string aP4_MemoDescription ,
                                 string aP5_MemoImage ,
                                 string aP6_MemoDocument ,
                                 DateTime aP7_MemoStartDateTime ,
                                 DateTime aP8_MemoEndDateTime ,
                                 short aP9_MemoDuration ,
                                 DateTime aP10_MemoRemoveDate ,
                                 string aP11_MemoBgColorCode ,
                                 string aP12_MemoForm ,
                                 out SdtSDT_Error aP13_Error )
      {
         this.AV17MemoId = aP0_MemoId;
         this.AV23ResidentGUID = aP1_ResidentGUID;
         this.AV11MemoCategoryId = aP2_MemoCategoryId;
         this.AV21MemoTitle = aP3_MemoTitle;
         this.AV12MemoDescription = aP4_MemoDescription;
         this.AV18MemoImage = aP5_MemoImage;
         this.AV13MemoDocument = aP6_MemoDocument;
         this.AV20MemoStartDateTime = aP7_MemoStartDateTime;
         this.AV15MemoEndDateTime = aP8_MemoEndDateTime;
         this.AV14MemoDuration = aP9_MemoDuration;
         this.AV19MemoRemoveDate = aP10_MemoRemoveDate;
         this.AV10MemoBgColorCode = aP11_MemoBgColorCode;
         this.AV16MemoForm = aP12_MemoForm;
         this.AV8Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP13_Error=this.AV8Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DE2 */
         pr_default.execute(0, new Object[] {AV23ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00DE2_A71ResidentGUID[0];
            A62ResidentId = P00DE2_A62ResidentId[0];
            A29LocationId = P00DE2_A29LocationId[0];
            A11OrganisationId = P00DE2_A11OrganisationId[0];
            AV24ResidentId = A62ResidentId;
            AV9LocationId = A29LocationId;
            AV22OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV25Trn_Memo.Load(AV17MemoId);
         AV25Trn_Memo.gxTpr_Memocategoryid = AV11MemoCategoryId;
         AV25Trn_Memo.gxTpr_Memotitle = AV21MemoTitle;
         AV25Trn_Memo.gxTpr_Memodescription = AV12MemoDescription;
         AV25Trn_Memo.gxTpr_Memoimage = AV18MemoImage;
         AV25Trn_Memo.gxTpr_Memodocument = AV13MemoDocument;
         AV25Trn_Memo.gxTpr_Memostartdatetime = AV20MemoStartDateTime;
         AV25Trn_Memo.gxTpr_Memoenddatetime = AV15MemoEndDateTime;
         AV25Trn_Memo.gxTpr_Memoduration = AV14MemoDuration;
         AV25Trn_Memo.gxTpr_Memoremovedate = AV19MemoRemoveDate;
         AV25Trn_Memo.gxTpr_Residentid = AV24ResidentId;
         AV25Trn_Memo.gxTpr_Memobgcolorcode = AV10MemoBgColorCode;
         AV25Trn_Memo.gxTpr_Memoform = AV16MemoForm;
         AV25Trn_Memo.gxTpr_Sg_organisationid = AV22OrganisationId;
         AV25Trn_Memo.gxTpr_Sg_locationid = AV9LocationId;
         AV25Trn_Memo.Save();
         if ( AV25Trn_Memo.Success() )
         {
            context.CommitDataStores("prc_updatememo",pr_default);
            AV8Error.gxTpr_Status = context.GetMessage( "Success", "");
            AV8Error.gxTpr_Message = context.GetMessage( "Memo created successfully", "");
         }
         else
         {
            AV8Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8Error.gxTpr_Message = context.GetMessage( "Failed to update memo", "");
            context.RollbackDataStores("prc_updatememo",pr_default);
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
         AV8Error = new SdtSDT_Error(context);
         P00DE2_A71ResidentGUID = new string[] {""} ;
         P00DE2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00DE2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DE2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV24ResidentId = Guid.Empty;
         AV9LocationId = Guid.Empty;
         AV22OrganisationId = Guid.Empty;
         AV25Trn_Memo = new SdtTrn_Memo(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__default(),
            new Object[][] {
                new Object[] {
               P00DE2_A71ResidentGUID, P00DE2_A62ResidentId, P00DE2_A29LocationId, P00DE2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14MemoDuration ;
      private string AV16MemoForm ;
      private DateTime AV20MemoStartDateTime ;
      private DateTime AV15MemoEndDateTime ;
      private DateTime AV19MemoRemoveDate ;
      private string AV23ResidentGUID ;
      private string AV21MemoTitle ;
      private string AV12MemoDescription ;
      private string AV18MemoImage ;
      private string AV13MemoDocument ;
      private string AV10MemoBgColorCode ;
      private string A71ResidentGUID ;
      private Guid AV17MemoId ;
      private Guid AV11MemoCategoryId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV24ResidentId ;
      private Guid AV9LocationId ;
      private Guid AV22OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8Error ;
      private IDataStoreProvider pr_default ;
      private string[] P00DE2_A71ResidentGUID ;
      private Guid[] P00DE2_A62ResidentId ;
      private Guid[] P00DE2_A29LocationId ;
      private Guid[] P00DE2_A11OrganisationId ;
      private SdtTrn_Memo AV25Trn_Memo ;
      private SdtSDT_Error aP13_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatememo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatememo__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatememo__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00DE2;
       prmP00DE2 = new Object[] {
       new ParDef("AV23ResidentGUID",GXType.VarChar,100,60)
       };
       def= new CursorDef[] {
           new CursorDef("P00DE2", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV23ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE2,100, GxCacheFrequency.OFF ,false,false )
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
