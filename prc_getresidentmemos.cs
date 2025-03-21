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
   public class prc_getresidentmemos : GXProcedure
   {
      public prc_getresidentmemos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentmemos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentId ,
                           short aP1_PageSize ,
                           short aP2_PageNumber ,
                           out string aP3_result )
      {
         this.AV13ResidentId = aP0_ResidentId;
         this.AV10PageSize = aP1_PageSize;
         this.AV9PageNumber = aP2_PageNumber;
         this.AV14result = "" ;
         initialize();
         ExecuteImpl();
         aP3_result=this.AV14result;
      }

      public string executeUdp( string aP0_ResidentId ,
                                short aP1_PageSize ,
                                short aP2_PageNumber )
      {
         execute(aP0_ResidentId, aP1_PageSize, aP2_PageNumber, out aP3_result);
         return AV14result ;
      }

      public void executeSubmit( string aP0_ResidentId ,
                                 short aP1_PageSize ,
                                 short aP2_PageNumber ,
                                 out string aP3_result )
      {
         this.AV13ResidentId = aP0_ResidentId;
         this.AV10PageSize = aP1_PageSize;
         this.AV9PageNumber = aP2_PageNumber;
         this.AV14result = "" ;
         SubmitImpl();
         aP3_result=this.AV14result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D73 */
         pr_default.execute(0, new Object[] {AV20PrimaryResidentId});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00D73_A40000GXC1[0];
            n40000GXC1 = P00D73_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         GXt_guid1 = AV20PrimaryResidentId;
         new prc_getresidentidfromguid(context ).execute(  AV13ResidentId, out  GXt_guid1) ;
         AV20PrimaryResidentId = GXt_guid1;
         if ( ( AV10PageSize < 1 ) || ( AV9PageNumber < 1 ) )
         {
            AV12RecordsToSkip = 0;
            AV8defaultPageNumber = 1;
            AV11RecordsPerPage = 100;
         }
         else
         {
            AV11RecordsPerPage = AV10PageSize;
            AV8defaultPageNumber = AV9PageNumber;
            AV12RecordsToSkip = (short)(AV10PageSize*(AV9PageNumber-1));
         }
         AV19TotalRecords = (short)(A40000GXC1);
         GXPagingFrom2 = AV12RecordsToSkip;
         GXPagingTo2 = AV11RecordsPerPage;
         /* Using cursor P00D74 */
         pr_default.execute(1, new Object[] {AV20PrimaryResidentId, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A555SG_LocationId = P00D74_A555SG_LocationId[0];
            A29LocationId = P00D74_A29LocationId[0];
            A556SG_OrganisationId = P00D74_A556SG_OrganisationId[0];
            A11OrganisationId = P00D74_A11OrganisationId[0];
            A62ResidentId = P00D74_A62ResidentId[0];
            A568MemoCategoryId = P00D74_A568MemoCategoryId[0];
            A569MemoCategoryName = P00D74_A569MemoCategoryName[0];
            A576MemoTitle = P00D74_A576MemoTitle[0];
            A577MemoDescription = P00D74_A577MemoDescription[0];
            A578MemoImage = P00D74_A578MemoImage[0];
            n578MemoImage = P00D74_n578MemoImage[0];
            A579MemoDocument = P00D74_A579MemoDocument[0];
            n579MemoDocument = P00D74_n579MemoDocument[0];
            A587MemoStartDateTime = P00D74_A587MemoStartDateTime[0];
            n587MemoStartDateTime = P00D74_n587MemoStartDateTime[0];
            A588MemoEndDateTime = P00D74_A588MemoEndDateTime[0];
            n588MemoEndDateTime = P00D74_n588MemoEndDateTime[0];
            A589MemoDuration = P00D74_A589MemoDuration[0];
            n589MemoDuration = P00D74_n589MemoDuration[0];
            A590MemoRemoveDate = P00D74_A590MemoRemoveDate[0];
            A72ResidentSalutation = P00D74_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D74_A64ResidentGivenName[0];
            A65ResidentLastName = P00D74_A65ResidentLastName[0];
            A71ResidentGUID = P00D74_A71ResidentGUID[0];
            A592MemoBgColorCode = P00D74_A592MemoBgColorCode[0];
            A593MemoForm = P00D74_A593MemoForm[0];
            A575MemoId = P00D74_A575MemoId[0];
            A72ResidentSalutation = P00D74_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D74_A64ResidentGivenName[0];
            A65ResidentLastName = P00D74_A65ResidentLastName[0];
            A71ResidentGUID = P00D74_A71ResidentGUID[0];
            A569MemoCategoryName = P00D74_A569MemoCategoryName[0];
            AV16SDT_Memo = new SdtSDT_Memo(context);
            AV16SDT_Memo.gxTpr_Memoid = A575MemoId;
            AV16SDT_Memo.gxTpr_Memocategoryid = A568MemoCategoryId;
            AV16SDT_Memo.gxTpr_Memocategoryname = A569MemoCategoryName;
            AV16SDT_Memo.gxTpr_Memotitle = A576MemoTitle;
            AV16SDT_Memo.gxTpr_Memodescription = A577MemoDescription;
            AV16SDT_Memo.gxTpr_Memoimage = A578MemoImage;
            AV16SDT_Memo.gxTpr_Memodocument = A579MemoDocument;
            AV16SDT_Memo.gxTpr_Memostartdatetime = A587MemoStartDateTime;
            AV16SDT_Memo.gxTpr_Memoenddatetime = A588MemoEndDateTime;
            AV16SDT_Memo.gxTpr_Memoduration = A589MemoDuration;
            AV16SDT_Memo.gxTpr_Memoremovedate = A590MemoRemoveDate;
            AV16SDT_Memo.gxTpr_Residentid = A62ResidentId;
            AV16SDT_Memo.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV16SDT_Memo.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV16SDT_Memo.gxTpr_Residentlastname = A65ResidentLastName;
            AV16SDT_Memo.gxTpr_Residentguid = A71ResidentGUID;
            AV16SDT_Memo.gxTpr_Memobgcolorcode = A592MemoBgColorCode;
            AV16SDT_Memo.gxTpr_Memoform = A593MemoForm;
            AV17SDT_Memos.Add(AV16SDT_Memo, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV18TotalPages = (short)((AV19TotalRecords+AV11RecordsPerPage-1)/ (decimal)(AV11RecordsPerPage));
         AV15SDT_ApiListResponse.gxTpr_Numberofpages = AV18TotalPages;
         AV15SDT_ApiListResponse.gxTpr_Pagenumber = AV8defaultPageNumber;
         AV15SDT_ApiListResponse.gxTpr_Pagesize = AV11RecordsPerPage;
         AV15SDT_ApiListResponse.gxTpr_Memos = AV17SDT_Memos;
         AV14result = AV15SDT_ApiListResponse.ToJSonString(false, true);
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV14result = "";
         AV20PrimaryResidentId = Guid.Empty;
         P00D73_A40000GXC1 = new int[1] ;
         P00D73_n40000GXC1 = new bool[] {false} ;
         GXt_guid1 = Guid.Empty;
         P00D74_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00D74_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D74_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00D74_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D74_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00D74_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00D74_A569MemoCategoryName = new string[] {""} ;
         P00D74_A576MemoTitle = new string[] {""} ;
         P00D74_A577MemoDescription = new string[] {""} ;
         P00D74_A578MemoImage = new string[] {""} ;
         P00D74_n578MemoImage = new bool[] {false} ;
         P00D74_A579MemoDocument = new string[] {""} ;
         P00D74_n579MemoDocument = new bool[] {false} ;
         P00D74_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D74_n587MemoStartDateTime = new bool[] {false} ;
         P00D74_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D74_n588MemoEndDateTime = new bool[] {false} ;
         P00D74_A589MemoDuration = new short[1] ;
         P00D74_n589MemoDuration = new bool[] {false} ;
         P00D74_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00D74_A72ResidentSalutation = new string[] {""} ;
         P00D74_A64ResidentGivenName = new string[] {""} ;
         P00D74_A65ResidentLastName = new string[] {""} ;
         P00D74_A71ResidentGUID = new string[] {""} ;
         P00D74_A592MemoBgColorCode = new string[] {""} ;
         P00D74_A593MemoForm = new string[] {""} ;
         P00D74_A575MemoId = new Guid[] {Guid.Empty} ;
         A555SG_LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         A569MemoCategoryName = "";
         A576MemoTitle = "";
         A577MemoDescription = "";
         A578MemoImage = "";
         A579MemoDocument = "";
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A590MemoRemoveDate = DateTime.MinValue;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A592MemoBgColorCode = "";
         A593MemoForm = "";
         A575MemoId = Guid.Empty;
         AV16SDT_Memo = new SdtSDT_Memo(context);
         AV17SDT_Memos = new GXBaseCollection<SdtSDT_Memo>( context, "SDT_Memo", "Comforta_version2");
         AV15SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentmemos__default(),
            new Object[][] {
                new Object[] {
               P00D73_A40000GXC1, P00D73_n40000GXC1
               }
               , new Object[] {
               P00D74_A555SG_LocationId, P00D74_A29LocationId, P00D74_A556SG_OrganisationId, P00D74_A11OrganisationId, P00D74_A62ResidentId, P00D74_A568MemoCategoryId, P00D74_A569MemoCategoryName, P00D74_A576MemoTitle, P00D74_A577MemoDescription, P00D74_A578MemoImage,
               P00D74_n578MemoImage, P00D74_A579MemoDocument, P00D74_n579MemoDocument, P00D74_A587MemoStartDateTime, P00D74_n587MemoStartDateTime, P00D74_A588MemoEndDateTime, P00D74_n588MemoEndDateTime, P00D74_A589MemoDuration, P00D74_n589MemoDuration, P00D74_A590MemoRemoveDate,
               P00D74_A72ResidentSalutation, P00D74_A64ResidentGivenName, P00D74_A65ResidentLastName, P00D74_A71ResidentGUID, P00D74_A592MemoBgColorCode, P00D74_A593MemoForm, P00D74_A575MemoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10PageSize ;
      private short AV9PageNumber ;
      private short AV12RecordsToSkip ;
      private short AV8defaultPageNumber ;
      private short AV11RecordsPerPage ;
      private short AV19TotalRecords ;
      private short A589MemoDuration ;
      private short AV18TotalPages ;
      private int A40000GXC1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private string A72ResidentSalutation ;
      private string A593MemoForm ;
      private DateTime A587MemoStartDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime A590MemoRemoveDate ;
      private bool n40000GXC1 ;
      private bool n578MemoImage ;
      private bool n579MemoDocument ;
      private bool n587MemoStartDateTime ;
      private bool n588MemoEndDateTime ;
      private bool n589MemoDuration ;
      private string AV14result ;
      private string AV13ResidentId ;
      private string A569MemoCategoryName ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A592MemoBgColorCode ;
      private Guid AV20PrimaryResidentId ;
      private Guid GXt_guid1 ;
      private Guid A555SG_LocationId ;
      private Guid A29LocationId ;
      private Guid A556SG_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A568MemoCategoryId ;
      private Guid A575MemoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00D73_A40000GXC1 ;
      private bool[] P00D73_n40000GXC1 ;
      private Guid[] P00D74_A555SG_LocationId ;
      private Guid[] P00D74_A29LocationId ;
      private Guid[] P00D74_A556SG_OrganisationId ;
      private Guid[] P00D74_A11OrganisationId ;
      private Guid[] P00D74_A62ResidentId ;
      private Guid[] P00D74_A568MemoCategoryId ;
      private string[] P00D74_A569MemoCategoryName ;
      private string[] P00D74_A576MemoTitle ;
      private string[] P00D74_A577MemoDescription ;
      private string[] P00D74_A578MemoImage ;
      private bool[] P00D74_n578MemoImage ;
      private string[] P00D74_A579MemoDocument ;
      private bool[] P00D74_n579MemoDocument ;
      private DateTime[] P00D74_A587MemoStartDateTime ;
      private bool[] P00D74_n587MemoStartDateTime ;
      private DateTime[] P00D74_A588MemoEndDateTime ;
      private bool[] P00D74_n588MemoEndDateTime ;
      private short[] P00D74_A589MemoDuration ;
      private bool[] P00D74_n589MemoDuration ;
      private DateTime[] P00D74_A590MemoRemoveDate ;
      private string[] P00D74_A72ResidentSalutation ;
      private string[] P00D74_A64ResidentGivenName ;
      private string[] P00D74_A65ResidentLastName ;
      private string[] P00D74_A71ResidentGUID ;
      private string[] P00D74_A592MemoBgColorCode ;
      private string[] P00D74_A593MemoForm ;
      private Guid[] P00D74_A575MemoId ;
      private SdtSDT_Memo AV16SDT_Memo ;
      private GXBaseCollection<SdtSDT_Memo> AV17SDT_Memos ;
      private SdtSDT_ApiListResponse AV15SDT_ApiListResponse ;
      private string aP3_result ;
   }

   public class prc_getresidentmemos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D73;
          prmP00D73 = new Object[] {
          new ParDef("AV20PrimaryResidentId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00D74;
          prmP00D74 = new Object[] {
          new ParDef("AV20PrimaryResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D73", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Trn_Memo WHERE ResidentId = :AV20PrimaryResidentId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D73,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D74", "SELECT T1.SG_LocationId, T2.LocationId, T1.SG_OrganisationId, T2.OrganisationId, T1.ResidentId, T1.MemoCategoryId, T3.MemoCategoryName, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, T1.MemoBgColorCode, T1.MemoForm, T1.MemoId FROM ((Trn_Memo T1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = T1.ResidentId AND T2.LocationId = T1.SG_LocationId AND T2.OrganisationId = T1.SG_OrganisationId) INNER JOIN Trn_MemoCategory T3 ON T3.MemoCategoryId = T1.MemoCategoryId) WHERE T1.ResidentId = :AV20PrimaryResidentId ORDER BY T1.MemoId DESC  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D74,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
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
                ((string[]) buf[20])[0] = rslt.getString(16, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((string[]) buf[23])[0] = rslt.getVarchar(19);
                ((string[]) buf[24])[0] = rslt.getVarchar(20);
                ((string[]) buf[25])[0] = rslt.getString(21, 20);
                ((Guid[]) buf[26])[0] = rslt.getGuid(22);
                return;
       }
    }

 }

}
