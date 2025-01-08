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
   public class uformloaddvcombo : GXProcedure
   {
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "uform_Services_Execute" ;
         }

      }

      public uformloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uformloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_WWPFormId ,
                           short aP4_WWPFormVersionNumber ,
                           short aP5_Cond_WWPFormId ,
                           short aP6_Cond_WWPFormVersionNumber ,
                           string aP7_SearchTxtParms ,
                           out string aP8_SelectedValue ,
                           out string aP9_SelectedText ,
                           out string aP10_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20WWPFormId = aP3_WWPFormId;
         this.AV21WWPFormVersionNumber = aP4_WWPFormVersionNumber;
         this.AV32Cond_WWPFormId = aP5_Cond_WWPFormId;
         this.AV33Cond_WWPFormVersionNumber = aP6_Cond_WWPFormVersionNumber;
         this.AV22SearchTxtParms = aP7_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP8_SelectedValue=this.AV23SelectedValue;
         aP9_SelectedText=this.AV24SelectedText;
         aP10_Combo_DataJson=this.AV25Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                short aP3_WWPFormId ,
                                short aP4_WWPFormVersionNumber ,
                                short aP5_Cond_WWPFormId ,
                                short aP6_Cond_WWPFormVersionNumber ,
                                string aP7_SearchTxtParms ,
                                out string aP8_SelectedValue ,
                                out string aP9_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_WWPFormId, aP4_WWPFormVersionNumber, aP5_Cond_WWPFormId, aP6_Cond_WWPFormVersionNumber, aP7_SearchTxtParms, out aP8_SelectedValue, out aP9_SelectedText, out aP10_Combo_DataJson);
         return AV25Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_WWPFormId ,
                                 short aP4_WWPFormVersionNumber ,
                                 short aP5_Cond_WWPFormId ,
                                 short aP6_Cond_WWPFormVersionNumber ,
                                 string aP7_SearchTxtParms ,
                                 out string aP8_SelectedValue ,
                                 out string aP9_SelectedText ,
                                 out string aP10_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20WWPFormId = aP3_WWPFormId;
         this.AV21WWPFormVersionNumber = aP4_WWPFormVersionNumber;
         this.AV32Cond_WWPFormId = aP5_Cond_WWPFormId;
         this.AV33Cond_WWPFormVersionNumber = aP6_Cond_WWPFormVersionNumber;
         this.AV22SearchTxtParms = aP7_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         SubmitImpl();
         aP8_SelectedValue=this.AV23SelectedValue;
         aP9_SelectedText=this.AV24SelectedText;
         aP10_Combo_DataJson=this.AV25Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV22SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV22SearchTxtParms : StringUtil.Substring( AV22SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "WWPFormElementParentId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_WWPFORMELEMENTPARENTID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_WWPFORMELEMENTPARENTID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV35GXV1 = 1;
               while ( AV35GXV1 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV35GXV1));
                  AV34WWPFormElementId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV36GXLvl29 = 0;
                  /* Using cursor P00AE2 */
                  pr_default.execute(0, new Object[] {AV32Cond_WWPFormId, AV33Cond_WWPFormVersionNumber, AV34WWPFormElementId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A207WWPFormVersionNumber = P00AE2_A207WWPFormVersionNumber[0];
                     A206WWPFormId = P00AE2_A206WWPFormId[0];
                     A210WWPFormElementId = P00AE2_A210WWPFormElementId[0];
                     A217WWPFormElementType = P00AE2_A217WWPFormElementType[0];
                     AV36GXLvl29 = 1;
                     AV29DscsCollection.Add(StringUtil.Trim( context.GetMessage( WorkWithPlus.workwithplus_dynamicforms.gxdomainwwp_df_elementtype.getDescription(context,A217WWPFormElementType), "")), 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV36GXLvl29 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV35GXV1 = (int)(AV35GXV1+1);
               }
               AV25Combo_DataJson = AV29DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               /* Using cursor P00AE3 */
               pr_default.execute(1, new Object[] {AV32Cond_WWPFormId, AV33Cond_WWPFormVersionNumber, GXPagingFrom3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A206WWPFormId = P00AE3_A206WWPFormId[0];
                  A207WWPFormVersionNumber = P00AE3_A207WWPFormVersionNumber[0];
                  A210WWPFormElementId = P00AE3_A210WWPFormElementId[0];
                  A217WWPFormElementType = P00AE3_A217WWPFormElementType[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A210WWPFormElementId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.GetMessage( WorkWithPlus.workwithplus_dynamicforms.gxdomainwwp_df_elementtype.getDescription(context,A217WWPFormElementType), ""));
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV25Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
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
         AV23SelectedValue = "";
         AV24SelectedText = "";
         AV25Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV30ValuesCollection = new GxSimpleCollection<string>();
         AV29DscsCollection = new GxSimpleCollection<string>();
         AV31ValueItem = "";
         P00AE2_A207WWPFormVersionNumber = new short[1] ;
         P00AE2_A206WWPFormId = new short[1] ;
         P00AE2_A210WWPFormElementId = new short[1] ;
         P00AE2_A217WWPFormElementType = new short[1] ;
         P00AE3_A206WWPFormId = new short[1] ;
         P00AE3_A207WWPFormVersionNumber = new short[1] ;
         P00AE3_A210WWPFormElementId = new short[1] ;
         P00AE3_A217WWPFormElementType = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uformloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00AE2_A207WWPFormVersionNumber, P00AE2_A206WWPFormId, P00AE2_A210WWPFormElementId, P00AE2_A217WWPFormElementType
               }
               , new Object[] {
               P00AE3_A206WWPFormId, P00AE3_A207WWPFormVersionNumber, P00AE3_A210WWPFormElementId, P00AE3_A217WWPFormElementType
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20WWPFormId ;
      private short AV21WWPFormVersionNumber ;
      private short AV32Cond_WWPFormId ;
      private short AV33Cond_WWPFormVersionNumber ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV34WWPFormElementId_Filter ;
      private short AV36GXLvl29 ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A210WWPFormElementId ;
      private short A217WWPFormElementType ;
      private int AV11MaxItems ;
      private int AV35GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV25Combo_DataJson ;
      private string AV17ComboName ;
      private string AV22SearchTxtParms ;
      private string AV23SelectedValue ;
      private string AV24SelectedText ;
      private string AV14SearchTxt ;
      private string AV31ValueItem ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV30ValuesCollection ;
      private GxSimpleCollection<string> AV29DscsCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P00AE2_A207WWPFormVersionNumber ;
      private short[] P00AE2_A206WWPFormId ;
      private short[] P00AE2_A210WWPFormElementId ;
      private short[] P00AE2_A217WWPFormElementType ;
      private short[] P00AE3_A206WWPFormId ;
      private short[] P00AE3_A207WWPFormVersionNumber ;
      private short[] P00AE3_A210WWPFormElementId ;
      private short[] P00AE3_A217WWPFormElementType ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP8_SelectedValue ;
      private string aP9_SelectedText ;
      private string aP10_Combo_DataJson ;
   }

   public class uformloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AE2;
          prmP00AE2 = new Object[] {
          new ParDef("AV32Cond_WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV33Cond_WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV34WWPFormElementId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP00AE3;
          prmP00AE3 = new Object[] {
          new ParDef("AV32Cond_WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV33Cond_WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AE2", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormElementId, WWPFormElementType FROM WWP_FormElement WHERE WWPFormId = :AV32Cond_WWPFormId and WWPFormVersionNumber = :AV33Cond_WWPFormVersionNumber and WWPFormElementId = :AV34WWPFormElementId_Filter ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AE3", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId, WWPFormElementType FROM WWP_FormElement WHERE (WWPFormId = :AV32Cond_WWPFormId) AND (WWPFormVersionNumber = :AV33Cond_WWPFormVersionNumber) ORDER BY WWPFormElementType, WWPFormId, WWPFormVersionNumber, WWPFormElementId  OFFSET :GXPagingFrom3 LIMIT CASE WHEN :GXPagingTo3 > 0 THEN :GXPagingTo3 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
