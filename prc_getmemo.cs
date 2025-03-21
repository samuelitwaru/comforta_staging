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
   public class prc_getmemo : GXProcedure
   {
      public prc_getmemo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmemo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           out SdtSDT_Memo aP1_SDT_Memo )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV9SDT_Memo = new SdtSDT_Memo(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Memo=this.AV9SDT_Memo;
      }

      public SdtSDT_Memo executeUdp( Guid aP0_MemoId )
      {
         execute(aP0_MemoId, out aP1_SDT_Memo);
         return AV9SDT_Memo ;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 out SdtSDT_Memo aP1_SDT_Memo )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV9SDT_Memo = new SdtSDT_Memo(context) ;
         SubmitImpl();
         aP1_SDT_Memo=this.AV9SDT_Memo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D82 */
         pr_default.execute(0, new Object[] {AV8MemoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A555SG_LocationId = P00D82_A555SG_LocationId[0];
            A29LocationId = P00D82_A29LocationId[0];
            A556SG_OrganisationId = P00D82_A556SG_OrganisationId[0];
            A11OrganisationId = P00D82_A11OrganisationId[0];
            A575MemoId = P00D82_A575MemoId[0];
            A568MemoCategoryId = P00D82_A568MemoCategoryId[0];
            A569MemoCategoryName = P00D82_A569MemoCategoryName[0];
            A576MemoTitle = P00D82_A576MemoTitle[0];
            A577MemoDescription = P00D82_A577MemoDescription[0];
            A578MemoImage = P00D82_A578MemoImage[0];
            n578MemoImage = P00D82_n578MemoImage[0];
            A579MemoDocument = P00D82_A579MemoDocument[0];
            n579MemoDocument = P00D82_n579MemoDocument[0];
            A587MemoStartDateTime = P00D82_A587MemoStartDateTime[0];
            n587MemoStartDateTime = P00D82_n587MemoStartDateTime[0];
            A588MemoEndDateTime = P00D82_A588MemoEndDateTime[0];
            n588MemoEndDateTime = P00D82_n588MemoEndDateTime[0];
            A589MemoDuration = P00D82_A589MemoDuration[0];
            n589MemoDuration = P00D82_n589MemoDuration[0];
            A590MemoRemoveDate = P00D82_A590MemoRemoveDate[0];
            A62ResidentId = P00D82_A62ResidentId[0];
            A72ResidentSalutation = P00D82_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D82_A64ResidentGivenName[0];
            A65ResidentLastName = P00D82_A65ResidentLastName[0];
            A71ResidentGUID = P00D82_A71ResidentGUID[0];
            A592MemoBgColorCode = P00D82_A592MemoBgColorCode[0];
            A593MemoForm = P00D82_A593MemoForm[0];
            A569MemoCategoryName = P00D82_A569MemoCategoryName[0];
            A72ResidentSalutation = P00D82_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D82_A64ResidentGivenName[0];
            A65ResidentLastName = P00D82_A65ResidentLastName[0];
            A71ResidentGUID = P00D82_A71ResidentGUID[0];
            AV9SDT_Memo = new SdtSDT_Memo(context);
            AV9SDT_Memo.gxTpr_Memoid = A575MemoId;
            AV9SDT_Memo.gxTpr_Memocategoryid = A568MemoCategoryId;
            AV9SDT_Memo.gxTpr_Memocategoryname = A569MemoCategoryName;
            AV9SDT_Memo.gxTpr_Memotitle = A576MemoTitle;
            AV9SDT_Memo.gxTpr_Memodescription = A577MemoDescription;
            AV9SDT_Memo.gxTpr_Memoimage = A578MemoImage;
            AV9SDT_Memo.gxTpr_Memodocument = A579MemoDocument;
            AV9SDT_Memo.gxTpr_Memostartdatetime = A587MemoStartDateTime;
            AV9SDT_Memo.gxTpr_Memoenddatetime = A588MemoEndDateTime;
            AV9SDT_Memo.gxTpr_Memoduration = A589MemoDuration;
            AV9SDT_Memo.gxTpr_Memoremovedate = A590MemoRemoveDate;
            AV9SDT_Memo.gxTpr_Residentid = A62ResidentId;
            AV9SDT_Memo.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV9SDT_Memo.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV9SDT_Memo.gxTpr_Residentlastname = A65ResidentLastName;
            AV9SDT_Memo.gxTpr_Residentguid = A71ResidentGUID;
            AV9SDT_Memo.gxTpr_Memobgcolorcode = A592MemoBgColorCode;
            AV9SDT_Memo.gxTpr_Memoform = A593MemoForm;
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
         AV9SDT_Memo = new SdtSDT_Memo(context);
         P00D82_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00D82_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D82_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00D82_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D82_A575MemoId = new Guid[] {Guid.Empty} ;
         P00D82_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00D82_A569MemoCategoryName = new string[] {""} ;
         P00D82_A576MemoTitle = new string[] {""} ;
         P00D82_A577MemoDescription = new string[] {""} ;
         P00D82_A578MemoImage = new string[] {""} ;
         P00D82_n578MemoImage = new bool[] {false} ;
         P00D82_A579MemoDocument = new string[] {""} ;
         P00D82_n579MemoDocument = new bool[] {false} ;
         P00D82_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D82_n587MemoStartDateTime = new bool[] {false} ;
         P00D82_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D82_n588MemoEndDateTime = new bool[] {false} ;
         P00D82_A589MemoDuration = new short[1] ;
         P00D82_n589MemoDuration = new bool[] {false} ;
         P00D82_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00D82_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00D82_A72ResidentSalutation = new string[] {""} ;
         P00D82_A64ResidentGivenName = new string[] {""} ;
         P00D82_A65ResidentLastName = new string[] {""} ;
         P00D82_A71ResidentGUID = new string[] {""} ;
         P00D82_A592MemoBgColorCode = new string[] {""} ;
         P00D82_A593MemoForm = new string[] {""} ;
         A555SG_LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A575MemoId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         A569MemoCategoryName = "";
         A576MemoTitle = "";
         A577MemoDescription = "";
         A578MemoImage = "";
         A579MemoDocument = "";
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A590MemoRemoveDate = DateTime.MinValue;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A592MemoBgColorCode = "";
         A593MemoForm = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmemo__default(),
            new Object[][] {
                new Object[] {
               P00D82_A555SG_LocationId, P00D82_A29LocationId, P00D82_A556SG_OrganisationId, P00D82_A11OrganisationId, P00D82_A575MemoId, P00D82_A568MemoCategoryId, P00D82_A569MemoCategoryName, P00D82_A576MemoTitle, P00D82_A577MemoDescription, P00D82_A578MemoImage,
               P00D82_n578MemoImage, P00D82_A579MemoDocument, P00D82_n579MemoDocument, P00D82_A587MemoStartDateTime, P00D82_n587MemoStartDateTime, P00D82_A588MemoEndDateTime, P00D82_n588MemoEndDateTime, P00D82_A589MemoDuration, P00D82_n589MemoDuration, P00D82_A590MemoRemoveDate,
               P00D82_A62ResidentId, P00D82_A72ResidentSalutation, P00D82_A64ResidentGivenName, P00D82_A65ResidentLastName, P00D82_A71ResidentGUID, P00D82_A592MemoBgColorCode, P00D82_A593MemoForm
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A589MemoDuration ;
      private string A72ResidentSalutation ;
      private string A593MemoForm ;
      private DateTime A587MemoStartDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime A590MemoRemoveDate ;
      private bool n578MemoImage ;
      private bool n579MemoDocument ;
      private bool n587MemoStartDateTime ;
      private bool n588MemoEndDateTime ;
      private bool n589MemoDuration ;
      private string A569MemoCategoryName ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A592MemoBgColorCode ;
      private Guid AV8MemoId ;
      private Guid A555SG_LocationId ;
      private Guid A29LocationId ;
      private Guid A556SG_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A575MemoId ;
      private Guid A568MemoCategoryId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Memo AV9SDT_Memo ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00D82_A555SG_LocationId ;
      private Guid[] P00D82_A29LocationId ;
      private Guid[] P00D82_A556SG_OrganisationId ;
      private Guid[] P00D82_A11OrganisationId ;
      private Guid[] P00D82_A575MemoId ;
      private Guid[] P00D82_A568MemoCategoryId ;
      private string[] P00D82_A569MemoCategoryName ;
      private string[] P00D82_A576MemoTitle ;
      private string[] P00D82_A577MemoDescription ;
      private string[] P00D82_A578MemoImage ;
      private bool[] P00D82_n578MemoImage ;
      private string[] P00D82_A579MemoDocument ;
      private bool[] P00D82_n579MemoDocument ;
      private DateTime[] P00D82_A587MemoStartDateTime ;
      private bool[] P00D82_n587MemoStartDateTime ;
      private DateTime[] P00D82_A588MemoEndDateTime ;
      private bool[] P00D82_n588MemoEndDateTime ;
      private short[] P00D82_A589MemoDuration ;
      private bool[] P00D82_n589MemoDuration ;
      private DateTime[] P00D82_A590MemoRemoveDate ;
      private Guid[] P00D82_A62ResidentId ;
      private string[] P00D82_A72ResidentSalutation ;
      private string[] P00D82_A64ResidentGivenName ;
      private string[] P00D82_A65ResidentLastName ;
      private string[] P00D82_A71ResidentGUID ;
      private string[] P00D82_A592MemoBgColorCode ;
      private string[] P00D82_A593MemoForm ;
      private SdtSDT_Memo aP1_SDT_Memo ;
   }

   public class prc_getmemo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D82;
          prmP00D82 = new Object[] {
          new ParDef("AV8MemoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D82", "SELECT T1.SG_LocationId, T3.LocationId, T1.SG_OrganisationId, T3.OrganisationId, T1.MemoId, T1.MemoCategoryId, T2.MemoCategoryName, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T1.ResidentId, T3.ResidentSalutation, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentGUID, T1.MemoBgColorCode, T1.MemoForm FROM ((Trn_Memo T1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = T1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = T1.ResidentId AND T3.LocationId = T1.SG_LocationId AND T3.OrganisationId = T1.SG_OrganisationId) WHERE T1.MemoId = :AV8MemoId ORDER BY T1.MemoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D82,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((short[]) buf[17])[0] = rslt.getShort(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(15);
                ((Guid[]) buf[20])[0] = rslt.getGuid(16);
                ((string[]) buf[21])[0] = rslt.getString(17, 20);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((string[]) buf[23])[0] = rslt.getVarchar(19);
                ((string[]) buf[24])[0] = rslt.getVarchar(20);
                ((string[]) buf[25])[0] = rslt.getVarchar(21);
                ((string[]) buf[26])[0] = rslt.getString(22, 20);
                return;
       }
    }

 }

}
