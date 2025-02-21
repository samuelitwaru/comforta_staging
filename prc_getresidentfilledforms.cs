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
   public class prc_getresidentfilledforms : GXProcedure
   {
      public prc_getresidentfilledforms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentfilledforms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           out string aP1_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV11result = "" ;
         initialize();
         ExecuteImpl();
         aP1_result=this.AV11result;
      }

      public string executeUdp( string aP0_ResidentGUID )
      {
         execute(aP0_ResidentGUID, out aP1_result);
         return AV11result ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 out string aP1_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV11result = "" ;
         SubmitImpl();
         aP1_result=this.AV11result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16SDT_ApiResidentFilledForms = new GXBaseCollection<SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "Comforta_version2");
         /* Using cursor P00B72 */
         pr_default.execute(0, new Object[] {AV8ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112WWPUserExtendedId = P00B72_A112WWPUserExtendedId[0];
            A239WWPFormInstanceDate = P00B72_A239WWPFormInstanceDate[0];
            A206WWPFormId = P00B72_A206WWPFormId[0];
            A208WWPFormReferenceName = P00B72_A208WWPFormReferenceName[0];
            A207WWPFormVersionNumber = P00B72_A207WWPFormVersionNumber[0];
            A209WWPFormTitle = P00B72_A209WWPFormTitle[0];
            A214WWPFormInstanceId = P00B72_A214WWPFormInstanceId[0];
            A208WWPFormReferenceName = P00B72_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P00B72_A209WWPFormTitle[0];
            AV17SDT_ResidentFilledFormsItem = new SdtSDT_ApiResidentFilledForms(context);
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formfilledby = A112WWPUserExtendedId;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formfilleddate = A239WWPFormInstanceDate;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Forminstanceid = (short)(A214WWPFormInstanceId);
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formid = A206WWPFormId;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formreferencename = A208WWPFormReferenceName;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formversionnumber = A207WWPFormVersionNumber;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formtitle = A209WWPFormTitle;
            AV16SDT_ApiResidentFilledForms.Add(AV17SDT_ResidentFilledFormsItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11result = AV16SDT_ApiResidentFilledForms.ToJSonString(false);
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
         AV11result = "";
         AV16SDT_ApiResidentFilledForms = new GXBaseCollection<SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "Comforta_version2");
         P00B72_A112WWPUserExtendedId = new string[] {""} ;
         P00B72_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         P00B72_A206WWPFormId = new short[1] ;
         P00B72_A208WWPFormReferenceName = new string[] {""} ;
         P00B72_A207WWPFormVersionNumber = new short[1] ;
         P00B72_A209WWPFormTitle = new string[] {""} ;
         P00B72_A214WWPFormInstanceId = new int[1] ;
         A112WWPUserExtendedId = "";
         A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         AV17SDT_ResidentFilledFormsItem = new SdtSDT_ApiResidentFilledForms(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentfilledforms__default(),
            new Object[][] {
                new Object[] {
               P00B72_A112WWPUserExtendedId, P00B72_A239WWPFormInstanceDate, P00B72_A206WWPFormId, P00B72_A208WWPFormReferenceName, P00B72_A207WWPFormVersionNumber, P00B72_A209WWPFormTitle, P00B72_A214WWPFormInstanceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int A214WWPFormInstanceId ;
      private string A112WWPUserExtendedId ;
      private DateTime A239WWPFormInstanceDate ;
      private string AV11result ;
      private string AV8ResidentGUID ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ApiResidentFilledForms> AV16SDT_ApiResidentFilledForms ;
      private IDataStoreProvider pr_default ;
      private string[] P00B72_A112WWPUserExtendedId ;
      private DateTime[] P00B72_A239WWPFormInstanceDate ;
      private short[] P00B72_A206WWPFormId ;
      private string[] P00B72_A208WWPFormReferenceName ;
      private short[] P00B72_A207WWPFormVersionNumber ;
      private string[] P00B72_A209WWPFormTitle ;
      private int[] P00B72_A214WWPFormInstanceId ;
      private SdtSDT_ApiResidentFilledForms AV17SDT_ResidentFilledFormsItem ;
      private string aP1_result ;
   }

   public class prc_getresidentfilledforms__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B72;
          prmP00B72 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00B72", "SELECT T1.WWPUserExtendedId, T1.WWPFormInstanceDate, T1.WWPFormId, T2.WWPFormReferenceName, T1.WWPFormVersionNumber, T2.WWPFormTitle, T1.WWPFormInstanceId FROM (WWP_FormInstance T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE T1.WWPUserExtendedId = ( :AV8ResidentGUID) ORDER BY T1.WWPFormInstanceId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B72,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
