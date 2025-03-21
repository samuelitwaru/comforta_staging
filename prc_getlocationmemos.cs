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
   public class prc_getlocationmemos : GXProcedure
   {
      public prc_getlocationmemos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationmemos( IGxContext context )
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
         this.AV18ResidentId = aP0_ResidentId;
         this.AV14PageSize = aP1_PageSize;
         this.AV13PageNumber = aP2_PageNumber;
         this.AV21result = "" ;
         initialize();
         ExecuteImpl();
         aP3_result=this.AV21result;
      }

      public string executeUdp( string aP0_ResidentId ,
                                short aP1_PageSize ,
                                short aP2_PageNumber )
      {
         execute(aP0_ResidentId, aP1_PageSize, aP2_PageNumber, out aP3_result);
         return AV21result ;
      }

      public void executeSubmit( string aP0_ResidentId ,
                                 short aP1_PageSize ,
                                 short aP2_PageNumber ,
                                 out string aP3_result )
      {
         this.AV18ResidentId = aP0_ResidentId;
         this.AV14PageSize = aP1_PageSize;
         this.AV13PageNumber = aP2_PageNumber;
         this.AV21result = "" ;
         SubmitImpl();
         aP3_result=this.AV21result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DD2 */
         pr_default.execute(0, new Object[] {AV18ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00DD2_A71ResidentGUID[0];
            A62ResidentId = P00DD2_A62ResidentId[0];
            A29LocationId = P00DD2_A29LocationId[0];
            A11OrganisationId = P00DD2_A11OrganisationId[0];
            AV15PrimaryResidentId = A62ResidentId;
            AV11LocationId = A29LocationId;
            AV12OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00DD4 */
         pr_default.execute(1, new Object[] {AV11LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P00DD4_A40000GXC1[0];
            n40000GXC1 = P00DD4_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         if ( ( AV14PageSize < 1 ) || ( AV13PageNumber < 1 ) )
         {
            AV17RecordsToSkip = 0;
            AV10defaultPageNumber = 1;
            AV16RecordsPerPage = 100;
         }
         else
         {
            AV16RecordsPerPage = AV14PageSize;
            AV10defaultPageNumber = AV13PageNumber;
            AV17RecordsToSkip = (short)(AV14PageSize*(AV13PageNumber-1));
         }
         AV20TotalRecords = (short)(A40000GXC1);
         new prc_logtofile(context ).execute(  context.GetMessage( "Location", "")+AV11LocationId.ToString()) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "Records", "")+StringUtil.Str( (decimal)(AV20TotalRecords), 4, 0)) ;
         GXPagingFrom3 = AV17RecordsToSkip;
         GXPagingTo3 = AV16RecordsPerPage;
         /* Using cursor P00DD5 */
         pr_default.execute(2, new Object[] {AV11LocationId, GXPagingFrom3, GXPagingTo3});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29LocationId = P00DD5_A29LocationId[0];
            A556SG_OrganisationId = P00DD5_A556SG_OrganisationId[0];
            A11OrganisationId = P00DD5_A11OrganisationId[0];
            A555SG_LocationId = P00DD5_A555SG_LocationId[0];
            A568MemoCategoryId = P00DD5_A568MemoCategoryId[0];
            A569MemoCategoryName = P00DD5_A569MemoCategoryName[0];
            A576MemoTitle = P00DD5_A576MemoTitle[0];
            A577MemoDescription = P00DD5_A577MemoDescription[0];
            A578MemoImage = P00DD5_A578MemoImage[0];
            n578MemoImage = P00DD5_n578MemoImage[0];
            A579MemoDocument = P00DD5_A579MemoDocument[0];
            n579MemoDocument = P00DD5_n579MemoDocument[0];
            A587MemoStartDateTime = P00DD5_A587MemoStartDateTime[0];
            n587MemoStartDateTime = P00DD5_n587MemoStartDateTime[0];
            A588MemoEndDateTime = P00DD5_A588MemoEndDateTime[0];
            n588MemoEndDateTime = P00DD5_n588MemoEndDateTime[0];
            A589MemoDuration = P00DD5_A589MemoDuration[0];
            n589MemoDuration = P00DD5_n589MemoDuration[0];
            A590MemoRemoveDate = P00DD5_A590MemoRemoveDate[0];
            A62ResidentId = P00DD5_A62ResidentId[0];
            A72ResidentSalutation = P00DD5_A72ResidentSalutation[0];
            A64ResidentGivenName = P00DD5_A64ResidentGivenName[0];
            A65ResidentLastName = P00DD5_A65ResidentLastName[0];
            A71ResidentGUID = P00DD5_A71ResidentGUID[0];
            A592MemoBgColorCode = P00DD5_A592MemoBgColorCode[0];
            A593MemoForm = P00DD5_A593MemoForm[0];
            A575MemoId = P00DD5_A575MemoId[0];
            A569MemoCategoryName = P00DD5_A569MemoCategoryName[0];
            A72ResidentSalutation = P00DD5_A72ResidentSalutation[0];
            A64ResidentGivenName = P00DD5_A64ResidentGivenName[0];
            A65ResidentLastName = P00DD5_A65ResidentLastName[0];
            A71ResidentGUID = P00DD5_A71ResidentGUID[0];
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
            AV19SDT_Memos.Add(AV9SDT_Memo, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV22TotalPages = (short)((AV20TotalRecords+AV16RecordsPerPage-1)/ (decimal)(AV16RecordsPerPage));
         AV8SDT_ApiListResponse.gxTpr_Numberofpages = AV22TotalPages;
         AV8SDT_ApiListResponse.gxTpr_Pagenumber = AV10defaultPageNumber;
         AV8SDT_ApiListResponse.gxTpr_Pagesize = AV16RecordsPerPage;
         AV8SDT_ApiListResponse.gxTpr_Memos = AV19SDT_Memos;
         AV21result = AV8SDT_ApiListResponse.ToJSonString(false, true);
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
         AV21result = "";
         P00DD2_A71ResidentGUID = new string[] {""} ;
         P00DD2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00DD2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DD2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV15PrimaryResidentId = Guid.Empty;
         AV11LocationId = Guid.Empty;
         AV12OrganisationId = Guid.Empty;
         P00DD4_A40000GXC1 = new int[1] ;
         P00DD4_n40000GXC1 = new bool[] {false} ;
         P00DD5_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DD5_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00DD5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DD5_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00DD5_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00DD5_A569MemoCategoryName = new string[] {""} ;
         P00DD5_A576MemoTitle = new string[] {""} ;
         P00DD5_A577MemoDescription = new string[] {""} ;
         P00DD5_A578MemoImage = new string[] {""} ;
         P00DD5_n578MemoImage = new bool[] {false} ;
         P00DD5_A579MemoDocument = new string[] {""} ;
         P00DD5_n579MemoDocument = new bool[] {false} ;
         P00DD5_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00DD5_n587MemoStartDateTime = new bool[] {false} ;
         P00DD5_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00DD5_n588MemoEndDateTime = new bool[] {false} ;
         P00DD5_A589MemoDuration = new short[1] ;
         P00DD5_n589MemoDuration = new bool[] {false} ;
         P00DD5_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00DD5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00DD5_A72ResidentSalutation = new string[] {""} ;
         P00DD5_A64ResidentGivenName = new string[] {""} ;
         P00DD5_A65ResidentLastName = new string[] {""} ;
         P00DD5_A71ResidentGUID = new string[] {""} ;
         P00DD5_A592MemoBgColorCode = new string[] {""} ;
         P00DD5_A593MemoForm = new string[] {""} ;
         P00DD5_A575MemoId = new Guid[] {Guid.Empty} ;
         A556SG_OrganisationId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
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
         A592MemoBgColorCode = "";
         A593MemoForm = "";
         A575MemoId = Guid.Empty;
         AV9SDT_Memo = new SdtSDT_Memo(context);
         AV19SDT_Memos = new GXBaseCollection<SdtSDT_Memo>( context, "SDT_Memo", "Comforta_version2");
         AV8SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationmemos__default(),
            new Object[][] {
                new Object[] {
               P00DD2_A71ResidentGUID, P00DD2_A62ResidentId, P00DD2_A29LocationId, P00DD2_A11OrganisationId
               }
               , new Object[] {
               P00DD4_A40000GXC1, P00DD4_n40000GXC1
               }
               , new Object[] {
               P00DD5_A29LocationId, P00DD5_A556SG_OrganisationId, P00DD5_A11OrganisationId, P00DD5_A555SG_LocationId, P00DD5_A568MemoCategoryId, P00DD5_A569MemoCategoryName, P00DD5_A576MemoTitle, P00DD5_A577MemoDescription, P00DD5_A578MemoImage, P00DD5_n578MemoImage,
               P00DD5_A579MemoDocument, P00DD5_n579MemoDocument, P00DD5_A587MemoStartDateTime, P00DD5_n587MemoStartDateTime, P00DD5_A588MemoEndDateTime, P00DD5_n588MemoEndDateTime, P00DD5_A589MemoDuration, P00DD5_n589MemoDuration, P00DD5_A590MemoRemoveDate, P00DD5_A62ResidentId,
               P00DD5_A72ResidentSalutation, P00DD5_A64ResidentGivenName, P00DD5_A65ResidentLastName, P00DD5_A71ResidentGUID, P00DD5_A592MemoBgColorCode, P00DD5_A593MemoForm, P00DD5_A575MemoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14PageSize ;
      private short AV13PageNumber ;
      private short AV17RecordsToSkip ;
      private short AV10defaultPageNumber ;
      private short AV16RecordsPerPage ;
      private short AV20TotalRecords ;
      private short A589MemoDuration ;
      private short AV22TotalPages ;
      private int A40000GXC1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
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
      private string AV21result ;
      private string AV18ResidentId ;
      private string A71ResidentGUID ;
      private string A569MemoCategoryName ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A592MemoBgColorCode ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV15PrimaryResidentId ;
      private Guid AV11LocationId ;
      private Guid AV12OrganisationId ;
      private Guid A556SG_OrganisationId ;
      private Guid A555SG_LocationId ;
      private Guid A568MemoCategoryId ;
      private Guid A575MemoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DD2_A71ResidentGUID ;
      private Guid[] P00DD2_A62ResidentId ;
      private Guid[] P00DD2_A29LocationId ;
      private Guid[] P00DD2_A11OrganisationId ;
      private int[] P00DD4_A40000GXC1 ;
      private bool[] P00DD4_n40000GXC1 ;
      private Guid[] P00DD5_A29LocationId ;
      private Guid[] P00DD5_A556SG_OrganisationId ;
      private Guid[] P00DD5_A11OrganisationId ;
      private Guid[] P00DD5_A555SG_LocationId ;
      private Guid[] P00DD5_A568MemoCategoryId ;
      private string[] P00DD5_A569MemoCategoryName ;
      private string[] P00DD5_A576MemoTitle ;
      private string[] P00DD5_A577MemoDescription ;
      private string[] P00DD5_A578MemoImage ;
      private bool[] P00DD5_n578MemoImage ;
      private string[] P00DD5_A579MemoDocument ;
      private bool[] P00DD5_n579MemoDocument ;
      private DateTime[] P00DD5_A587MemoStartDateTime ;
      private bool[] P00DD5_n587MemoStartDateTime ;
      private DateTime[] P00DD5_A588MemoEndDateTime ;
      private bool[] P00DD5_n588MemoEndDateTime ;
      private short[] P00DD5_A589MemoDuration ;
      private bool[] P00DD5_n589MemoDuration ;
      private DateTime[] P00DD5_A590MemoRemoveDate ;
      private Guid[] P00DD5_A62ResidentId ;
      private string[] P00DD5_A72ResidentSalutation ;
      private string[] P00DD5_A64ResidentGivenName ;
      private string[] P00DD5_A65ResidentLastName ;
      private string[] P00DD5_A71ResidentGUID ;
      private string[] P00DD5_A592MemoBgColorCode ;
      private string[] P00DD5_A593MemoForm ;
      private Guid[] P00DD5_A575MemoId ;
      private SdtSDT_Memo AV9SDT_Memo ;
      private GXBaseCollection<SdtSDT_Memo> AV19SDT_Memos ;
      private SdtSDT_ApiListResponse AV8SDT_ApiListResponse ;
      private string aP3_result ;
   }

   public class prc_getlocationmemos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DD2;
          prmP00DD2 = new Object[] {
          new ParDef("AV18ResidentId",GXType.VarChar,100,60)
          };
          Object[] prmP00DD4;
          prmP00DD4 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DD5;
          prmP00DD5 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DD2", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV18ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DD4", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Trn_Memo WHERE SG_LocationId = :AV11LocationId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DD5", "SELECT T3.LocationId, T1.SG_OrganisationId, T3.OrganisationId, T1.SG_LocationId, T1.MemoCategoryId, T2.MemoCategoryName, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T1.ResidentId, T3.ResidentSalutation, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentGUID, T1.MemoBgColorCode, T1.MemoForm, T1.MemoId FROM ((Trn_Memo T1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = T1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = T1.ResidentId AND T3.LocationId = T1.SG_LocationId AND T3.OrganisationId = T1.SG_OrganisationId) WHERE T1.SG_LocationId = :AV11LocationId ORDER BY T1.MemoId DESC  OFFSET :GXPagingFrom3 LIMIT CASE WHEN :GXPagingTo3 > 0 THEN :GXPagingTo3 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD5,100, GxCacheFrequency.OFF ,false,false )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((short[]) buf[16])[0] = rslt.getShort(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(14);
                ((Guid[]) buf[19])[0] = rslt.getGuid(15);
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
