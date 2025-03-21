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
   public class prc_getmemos : GXProcedure
   {
      public prc_getmemos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmemos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_PageSize ,
                           short aP1_PageNumber ,
                           out string aP2_result )
      {
         this.AV10PageSize = aP0_PageSize;
         this.AV9PageNumber = aP1_PageNumber;
         this.AV13result = "" ;
         initialize();
         ExecuteImpl();
         aP2_result=this.AV13result;
      }

      public string executeUdp( short aP0_PageSize ,
                                short aP1_PageNumber )
      {
         execute(aP0_PageSize, aP1_PageNumber, out aP2_result);
         return AV13result ;
      }

      public void executeSubmit( short aP0_PageSize ,
                                 short aP1_PageNumber ,
                                 out string aP2_result )
      {
         this.AV10PageSize = aP0_PageSize;
         this.AV9PageNumber = aP1_PageNumber;
         this.AV13result = "" ;
         SubmitImpl();
         aP2_result=this.AV13result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D93 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00D93_A40000GXC1[0];
            n40000GXC1 = P00D93_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
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
         AV18TotalRecords = (short)(A40000GXC1);
         GXPagingFrom2 = AV12RecordsToSkip;
         GXPagingTo2 = AV11RecordsPerPage;
         /* Using cursor P00D94 */
         pr_default.execute(1, new Object[] {GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00D94_A29LocationId[0];
            A11OrganisationId = P00D94_A11OrganisationId[0];
            A575MemoId = P00D94_A575MemoId[0];
            A574BulletinBoardId = P00D94_A574BulletinBoardId[0];
            A568MemoCategoryId = P00D94_A568MemoCategoryId[0];
            A569MemoCategoryName = P00D94_A569MemoCategoryName[0];
            A576MemoTitle = P00D94_A576MemoTitle[0];
            A577MemoDescription = P00D94_A577MemoDescription[0];
            A578MemoImage = P00D94_A578MemoImage[0];
            n578MemoImage = P00D94_n578MemoImage[0];
            A579MemoDocument = P00D94_A579MemoDocument[0];
            n579MemoDocument = P00D94_n579MemoDocument[0];
            A587MemoStartDateTime = P00D94_A587MemoStartDateTime[0];
            n587MemoStartDateTime = P00D94_n587MemoStartDateTime[0];
            A588MemoEndDateTime = P00D94_A588MemoEndDateTime[0];
            n588MemoEndDateTime = P00D94_n588MemoEndDateTime[0];
            A589MemoDuration = P00D94_A589MemoDuration[0];
            n589MemoDuration = P00D94_n589MemoDuration[0];
            A590MemoRemoveDate = P00D94_A590MemoRemoveDate[0];
            A72ResidentSalutation = P00D94_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D94_A64ResidentGivenName[0];
            A65ResidentLastName = P00D94_A65ResidentLastName[0];
            A62ResidentId = P00D94_A62ResidentId[0];
            A29LocationId = P00D94_A29LocationId[0];
            A11OrganisationId = P00D94_A11OrganisationId[0];
            A569MemoCategoryName = P00D94_A569MemoCategoryName[0];
            A72ResidentSalutation = P00D94_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D94_A64ResidentGivenName[0];
            A65ResidentLastName = P00D94_A65ResidentLastName[0];
            AV15SDT_Memo = new SdtSDT_Memo(context);
            AV15SDT_Memo.gxTpr_Memoid = A575MemoId;
            AV15SDT_Memo.gxTpr_Bulletinboardid = A574BulletinBoardId;
            AV15SDT_Memo.gxTpr_Memocategoryid = A568MemoCategoryId;
            AV15SDT_Memo.gxTpr_Memocategoryname = A569MemoCategoryName;
            AV15SDT_Memo.gxTpr_Memotitle = A576MemoTitle;
            AV15SDT_Memo.gxTpr_Memodescription = A577MemoDescription;
            AV15SDT_Memo.gxTpr_Memoimage = A578MemoImage;
            AV15SDT_Memo.gxTpr_Memodocument = A579MemoDocument;
            AV15SDT_Memo.gxTpr_Memostartdatetime = A587MemoStartDateTime;
            AV15SDT_Memo.gxTpr_Memoenddatetime = A588MemoEndDateTime;
            AV15SDT_Memo.gxTpr_Memoduration = A589MemoDuration;
            AV15SDT_Memo.gxTpr_Memoremovedate = A590MemoRemoveDate;
            AV15SDT_Memo.gxTpr_Residentid = A62ResidentId;
            AV15SDT_Memo.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV15SDT_Memo.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV15SDT_Memo.gxTpr_Residentlastname = A65ResidentLastName;
            AV16SDT_Memos.Add(AV15SDT_Memo, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV17TotalPages = (short)((AV18TotalRecords+AV11RecordsPerPage-1)/ (decimal)(AV11RecordsPerPage));
         AV14SDT_ApiListResponse.gxTpr_Numberofpages = AV17TotalPages;
         AV14SDT_ApiListResponse.gxTpr_Pagenumber = AV8defaultPageNumber;
         AV14SDT_ApiListResponse.gxTpr_Pagesize = AV11RecordsPerPage;
         AV14SDT_ApiListResponse.gxTpr_Memos = AV16SDT_Memos;
         AV13result = AV14SDT_ApiListResponse.ToJSonString(false, true);
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
         AV13result = "";
         P00D93_A40000GXC1 = new int[1] ;
         P00D93_n40000GXC1 = new bool[] {false} ;
         P00D94_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D94_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D94_A575MemoId = new Guid[] {Guid.Empty} ;
         P00D94_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         P00D94_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00D94_A569MemoCategoryName = new string[] {""} ;
         P00D94_A576MemoTitle = new string[] {""} ;
         P00D94_A577MemoDescription = new string[] {""} ;
         P00D94_A578MemoImage = new string[] {""} ;
         P00D94_n578MemoImage = new bool[] {false} ;
         P00D94_A579MemoDocument = new string[] {""} ;
         P00D94_n579MemoDocument = new bool[] {false} ;
         P00D94_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D94_n587MemoStartDateTime = new bool[] {false} ;
         P00D94_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D94_n588MemoEndDateTime = new bool[] {false} ;
         P00D94_A589MemoDuration = new short[1] ;
         P00D94_n589MemoDuration = new bool[] {false} ;
         P00D94_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00D94_A72ResidentSalutation = new string[] {""} ;
         P00D94_A64ResidentGivenName = new string[] {""} ;
         P00D94_A65ResidentLastName = new string[] {""} ;
         P00D94_A62ResidentId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A575MemoId = Guid.Empty;
         A574BulletinBoardId = Guid.Empty;
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
         A62ResidentId = Guid.Empty;
         AV15SDT_Memo = new SdtSDT_Memo(context);
         AV16SDT_Memos = new GXBaseCollection<SdtSDT_Memo>( context, "SDT_Memo", "Comforta_version2");
         AV14SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmemos__default(),
            new Object[][] {
                new Object[] {
               P00D93_A40000GXC1, P00D93_n40000GXC1
               }
               , new Object[] {
               P00D94_A29LocationId, P00D94_A11OrganisationId, P00D94_A575MemoId, P00D94_A574BulletinBoardId, P00D94_A568MemoCategoryId, P00D94_A569MemoCategoryName, P00D94_A576MemoTitle, P00D94_A577MemoDescription, P00D94_A578MemoImage, P00D94_n578MemoImage,
               P00D94_A579MemoDocument, P00D94_n579MemoDocument, P00D94_A587MemoStartDateTime, P00D94_n587MemoStartDateTime, P00D94_A588MemoEndDateTime, P00D94_n588MemoEndDateTime, P00D94_A589MemoDuration, P00D94_n589MemoDuration, P00D94_A590MemoRemoveDate, P00D94_A72ResidentSalutation,
               P00D94_A64ResidentGivenName, P00D94_A65ResidentLastName, P00D94_A62ResidentId
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
      private short AV18TotalRecords ;
      private short A589MemoDuration ;
      private short AV17TotalPages ;
      private int A40000GXC1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private string A72ResidentSalutation ;
      private DateTime A587MemoStartDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime A590MemoRemoveDate ;
      private bool n40000GXC1 ;
      private bool n578MemoImage ;
      private bool n579MemoDocument ;
      private bool n587MemoStartDateTime ;
      private bool n588MemoEndDateTime ;
      private bool n589MemoDuration ;
      private string AV13result ;
      private string A569MemoCategoryName ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A575MemoId ;
      private Guid A574BulletinBoardId ;
      private Guid A568MemoCategoryId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00D93_A40000GXC1 ;
      private bool[] P00D93_n40000GXC1 ;
      private Guid[] P00D94_A29LocationId ;
      private Guid[] P00D94_A11OrganisationId ;
      private Guid[] P00D94_A575MemoId ;
      private Guid[] P00D94_A574BulletinBoardId ;
      private Guid[] P00D94_A568MemoCategoryId ;
      private string[] P00D94_A569MemoCategoryName ;
      private string[] P00D94_A576MemoTitle ;
      private string[] P00D94_A577MemoDescription ;
      private string[] P00D94_A578MemoImage ;
      private bool[] P00D94_n578MemoImage ;
      private string[] P00D94_A579MemoDocument ;
      private bool[] P00D94_n579MemoDocument ;
      private DateTime[] P00D94_A587MemoStartDateTime ;
      private bool[] P00D94_n587MemoStartDateTime ;
      private DateTime[] P00D94_A588MemoEndDateTime ;
      private bool[] P00D94_n588MemoEndDateTime ;
      private short[] P00D94_A589MemoDuration ;
      private bool[] P00D94_n589MemoDuration ;
      private DateTime[] P00D94_A590MemoRemoveDate ;
      private string[] P00D94_A72ResidentSalutation ;
      private string[] P00D94_A64ResidentGivenName ;
      private string[] P00D94_A65ResidentLastName ;
      private Guid[] P00D94_A62ResidentId ;
      private SdtSDT_Memo AV15SDT_Memo ;
      private GXBaseCollection<SdtSDT_Memo> AV16SDT_Memos ;
      private SdtSDT_ApiListResponse AV14SDT_ApiListResponse ;
      private string aP2_result ;
   }

   public class prc_getmemos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D93;
          prmP00D93 = new Object[] {
          };
          Object[] prmP00D94;
          prmP00D94 = new Object[] {
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D93", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Trn_Memo ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D93,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D94", "SELECT T2.LocationId, T2.OrganisationId, T1.MemoId, T1.BulletinBoardId, T1.MemoCategoryId, T3.MemoCategoryName, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T4.ResidentSalutation, T4.ResidentGivenName, T4.ResidentLastName, T1.ResidentId FROM (((Trn_Memo T1 INNER JOIN Trn_BulletinBoard T2 ON T2.BulletinBoardId = T1.BulletinBoardId) LEFT JOIN Trn_Resident T4 ON T4.ResidentId = T1.ResidentId AND T4.LocationId = T2.LocationId AND T4.OrganisationId = T2.OrganisationId) INNER JOIN Trn_MemoCategory T3 ON T3.MemoCategoryId = T1.MemoCategoryId) ORDER BY T1.ResidentId DESC, T1.MemoId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D94,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[19])[0] = rslt.getString(15, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(16);
                ((string[]) buf[21])[0] = rslt.getVarchar(17);
                ((Guid[]) buf[22])[0] = rslt.getGuid(18);
                return;
       }
    }

 }

}
