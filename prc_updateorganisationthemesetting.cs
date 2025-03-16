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
   public class prc_updateorganisationthemesetting : GXProcedure
   {
      public prc_updateorganisationthemesetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateorganisationthemesetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_OrganisationId ,
                           ref string aP1_OrganisationBrandTheme ,
                           ref string aP2_OrganisationCtaTheme )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationBrandTheme = aP1_OrganisationBrandTheme;
         this.AV10OrganisationCtaTheme = aP2_OrganisationCtaTheme;
         initialize();
         ExecuteImpl();
         aP0_OrganisationId=this.AV8OrganisationId;
         aP1_OrganisationBrandTheme=this.AV9OrganisationBrandTheme;
         aP2_OrganisationCtaTheme=this.AV10OrganisationCtaTheme;
      }

      public string executeUdp( ref Guid aP0_OrganisationId ,
                                ref string aP1_OrganisationBrandTheme )
      {
         execute(ref aP0_OrganisationId, ref aP1_OrganisationBrandTheme, ref aP2_OrganisationCtaTheme);
         return AV10OrganisationCtaTheme ;
      }

      public void executeSubmit( ref Guid aP0_OrganisationId ,
                                 ref string aP1_OrganisationBrandTheme ,
                                 ref string aP2_OrganisationCtaTheme )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationBrandTheme = aP1_OrganisationBrandTheme;
         this.AV10OrganisationCtaTheme = aP2_OrganisationCtaTheme;
         SubmitImpl();
         aP0_OrganisationId=this.AV8OrganisationId;
         aP1_OrganisationBrandTheme=this.AV9OrganisationBrandTheme;
         aP2_OrganisationCtaTheme=this.AV10OrganisationCtaTheme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Dictionary.fromjson( AV9OrganisationBrandTheme);
         AV12ColorNameCollection = AV11Dictionary.gxTpr_Keys;
         AV13ColorCodeCollection = AV11Dictionary.gxTpr_Values;
         AV23CtaDictionary.fromjson( AV10OrganisationCtaTheme);
         AV24CtaColorNameCollection = AV23CtaDictionary.gxTpr_Keys;
         AV25CtaColorCodeCollection = AV23CtaDictionary.gxTpr_Values;
         new prc_logtoserver(context ).execute(  ">>"+AV10OrganisationCtaTheme) ;
         new prc_logtoserver(context ).execute(  AV24CtaColorNameCollection.ToJSonString(false)) ;
         new prc_logtoserver(context ).execute(  AV25CtaColorCodeCollection.ToJSonString(false)) ;
         /* Using cursor P00CG2 */
         pr_default.execute(0, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00CG2_A11OrganisationId[0];
            n11OrganisationId = P00CG2_n11OrganisationId[0];
            A100OrganisationSettingid = P00CG2_A100OrganisationSettingid[0];
            AV27GXLvl16 = 0;
            /* Using cursor P00CG3 */
            pr_default.execute(1, new Object[] {AV8OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A247Trn_ThemeId = P00CG3_A247Trn_ThemeId[0];
               A11OrganisationId = P00CG3_A11OrganisationId[0];
               n11OrganisationId = P00CG3_n11OrganisationId[0];
               AV27GXLvl16 = 1;
               /* Optimized DELETE. */
               /* Using cursor P00CG4 */
               pr_default.execute(2, new Object[] {A247Trn_ThemeId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
               /* End optimized DELETE. */
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV12ColorNameCollection.Count )
               {
                  AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV29GXV1));
                  AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
                  AV15Index = (short)(AV12ColorNameCollection.IndexOf(AV14ColorSDTName));
                  /*
                     INSERT RECORD ON TABLE Trn_ThemeColor

                  */
                  A250ColorName = AV19ColorName;
                  A251ColorCode = ((string)AV13ColorCodeCollection.Item(AV15Index));
                  A249ColorId = Guid.NewGuid( );
                  /* Using cursor P00CG5 */
                  pr_default.execute(3, new Object[] {A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                  if ( (pr_default.getStatus(3) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
               /* Optimized DELETE. */
               /* Using cursor P00CG6 */
               pr_default.execute(4, new Object[] {A247Trn_ThemeId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
               /* End optimized DELETE. */
               AV31GXV2 = 1;
               while ( AV31GXV2 <= AV24CtaColorNameCollection.Count )
               {
                  AV19ColorName = ((string)AV24CtaColorNameCollection.Item(AV31GXV2));
                  AV15Index = (short)(AV24CtaColorNameCollection.IndexOf(AV19ColorName));
                  /*
                     INSERT RECORD ON TABLE Trn_ThemeCtaColor

                  */
                  A564CtaColorName = AV19ColorName;
                  A565CtaColorCode = ((string)AV25CtaColorCodeCollection.Item(AV15Index));
                  A563CtaColorId = Guid.NewGuid( );
                  /* Using cursor P00CG7 */
                  pr_default.execute(5, new Object[] {A247Trn_ThemeId, A563CtaColorId, A564CtaColorName, A565CtaColorCode});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                  if ( (pr_default.getStatus(5) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
                  AV31GXV2 = (int)(AV31GXV2+1);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV27GXLvl16 == 0 )
            {
               /* Execute user subroutine: 'CREATENEWTHEME' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWTHEME' Routine */
         returnInSub = false;
         /* Using cursor P00CG8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A260Trn_ThemeFontFamily = P00CG8_A260Trn_ThemeFontFamily[0];
            A399Trn_ThemeFontSize = P00CG8_A399Trn_ThemeFontSize[0];
            A248Trn_ThemeName = P00CG8_A248Trn_ThemeName[0];
            A247Trn_ThemeId = P00CG8_A247Trn_ThemeId[0];
            AV17BC_Trn_Theme = new SdtTrn_Theme(context);
            /* Using cursor P00CG9 */
            pr_default.execute(7, new Object[] {AV8OrganisationId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A11OrganisationId = P00CG9_A11OrganisationId[0];
               n11OrganisationId = P00CG9_n11OrganisationId[0];
               A100OrganisationSettingid = P00CG9_A100OrganisationSettingid[0];
               AV17BC_Trn_Theme.gxTpr_Trn_themeid = AV8OrganisationId;
               AV17BC_Trn_Theme.gxTpr_Trn_themename = "Your Style";
               AV17BC_Trn_Theme.gxTpr_Trn_themefontfamily = A260Trn_ThemeFontFamily;
               AV17BC_Trn_Theme.gxTpr_Trn_themefontsize = A399Trn_ThemeFontSize;
               AV17BC_Trn_Theme.gxTpr_Organisationid = AV8OrganisationId;
               AV17BC_Trn_Theme.gxTpr_Color.Clear();
               AV34GXV3 = 1;
               while ( AV34GXV3 <= AV12ColorNameCollection.Count )
               {
                  AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV34GXV3));
                  AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
                  AV20Color = new SdtTrn_Theme_Color(context);
                  AV20Color.gxTpr_Colorid = Guid.NewGuid( );
                  AV20Color.gxTpr_Colorname = AV19ColorName;
                  AV20Color.gxTpr_Colorcode = ((string)AV13ColorCodeCollection.Item(AV12ColorNameCollection.IndexOf(AV14ColorSDTName)));
                  AV17BC_Trn_Theme.gxTpr_Color.Add(AV20Color, 0);
                  AV34GXV3 = (int)(AV34GXV3+1);
               }
               AV17BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
               AV17BC_Trn_Theme.Save();
               if ( AV17BC_Trn_Theme.Success() )
               {
                  context.CommitDataStores("prc_updateorganisationthemesetting",pr_default);
                  AV21BC_Trn_ThemeCollection.Add(AV17BC_Trn_Theme, 0);
               }
               else
               {
                  AV17BC_Trn_Theme.Update();
                  context.CommitDataStores("prc_updateorganisationthemesetting",pr_default);
                  AV21BC_Trn_ThemeCollection.Add(AV17BC_Trn_Theme, 0);
                  AV36GXV5 = 1;
                  AV35GXV4 = AV17BC_Trn_Theme.GetMessages();
                  while ( AV36GXV5 <= AV35GXV4.Count )
                  {
                     AV22ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV35GXV4.Item(AV36GXV5));
                     GX_msglist.addItem(AV22ErrorMessage.gxTpr_Description);
                     AV36GXV5 = (int)(AV36GXV5+1);
                  }
               }
               pr_default.readNext(7);
            }
            pr_default.close(7);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateorganisationthemesetting",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Dictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV12ColorNameCollection = new GxSimpleCollection<string>();
         AV13ColorCodeCollection = new GxSimpleCollection<string>();
         AV23CtaDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV24CtaColorNameCollection = new GxSimpleCollection<string>();
         AV25CtaColorCodeCollection = new GxSimpleCollection<string>();
         P00CG2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG2_n11OrganisationId = new bool[] {false} ;
         P00CG2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         P00CG3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00CG3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG3_n11OrganisationId = new bool[] {false} ;
         A247Trn_ThemeId = Guid.Empty;
         AV14ColorSDTName = "";
         AV19ColorName = "";
         A250ColorName = "";
         A251ColorCode = "";
         A249ColorId = Guid.Empty;
         Gx_emsg = "";
         A564CtaColorName = "";
         A565CtaColorCode = "";
         A563CtaColorId = Guid.Empty;
         P00CG8_A260Trn_ThemeFontFamily = new string[] {""} ;
         P00CG8_A399Trn_ThemeFontSize = new short[1] ;
         P00CG8_A248Trn_ThemeName = new string[] {""} ;
         P00CG8_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A260Trn_ThemeFontFamily = "";
         A248Trn_ThemeName = "";
         AV17BC_Trn_Theme = new SdtTrn_Theme(context);
         P00CG9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG9_n11OrganisationId = new bool[] {false} ;
         P00CG9_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         AV20Color = new SdtTrn_Theme_Color(context);
         AV21BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV35GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__default(),
            new Object[][] {
                new Object[] {
               P00CG2_A11OrganisationId, P00CG2_A100OrganisationSettingid
               }
               , new Object[] {
               P00CG3_A247Trn_ThemeId, P00CG3_A11OrganisationId, P00CG3_n11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00CG8_A260Trn_ThemeFontFamily, P00CG8_A399Trn_ThemeFontSize, P00CG8_A248Trn_ThemeName, P00CG8_A247Trn_ThemeId
               }
               , new Object[] {
               P00CG9_A11OrganisationId, P00CG9_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27GXLvl16 ;
      private short AV15Index ;
      private short A399Trn_ThemeFontSize ;
      private int AV29GXV1 ;
      private int GX_INS47 ;
      private int AV31GXV2 ;
      private int GX_INS112 ;
      private int AV34GXV3 ;
      private int AV36GXV5 ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private bool returnInSub ;
      private string AV9OrganisationBrandTheme ;
      private string AV10OrganisationCtaTheme ;
      private string AV14ColorSDTName ;
      private string AV19ColorName ;
      private string A250ColorName ;
      private string A251ColorCode ;
      private string A564CtaColorName ;
      private string A565CtaColorCode ;
      private string A260Trn_ThemeFontFamily ;
      private string A248Trn_ThemeName ;
      private Guid AV8OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private Guid A247Trn_ThemeId ;
      private Guid A249ColorId ;
      private Guid A563CtaColorId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_OrganisationId ;
      private string aP1_OrganisationBrandTheme ;
      private string aP2_OrganisationCtaTheme ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV11Dictionary ;
      private GxSimpleCollection<string> AV12ColorNameCollection ;
      private GxSimpleCollection<string> AV13ColorCodeCollection ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV23CtaDictionary ;
      private GxSimpleCollection<string> AV24CtaColorNameCollection ;
      private GxSimpleCollection<string> AV25CtaColorCodeCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CG2_A11OrganisationId ;
      private bool[] P00CG2_n11OrganisationId ;
      private Guid[] P00CG2_A100OrganisationSettingid ;
      private Guid[] P00CG3_A247Trn_ThemeId ;
      private Guid[] P00CG3_A11OrganisationId ;
      private bool[] P00CG3_n11OrganisationId ;
      private string[] P00CG8_A260Trn_ThemeFontFamily ;
      private short[] P00CG8_A399Trn_ThemeFontSize ;
      private string[] P00CG8_A248Trn_ThemeName ;
      private Guid[] P00CG8_A247Trn_ThemeId ;
      private SdtTrn_Theme AV17BC_Trn_Theme ;
      private Guid[] P00CG9_A11OrganisationId ;
      private bool[] P00CG9_n11OrganisationId ;
      private Guid[] P00CG9_A100OrganisationSettingid ;
      private SdtTrn_Theme_Color AV20Color ;
      private GXBCCollection<SdtTrn_Theme> AV21BC_Trn_ThemeCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV35GXV4 ;
      private GeneXus.Utils.SdtMessages_Message AV22ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateorganisationthemesetting__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateorganisationthemesetting__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateorganisationthemesetting__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new UpdateCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00CG2;
       prmP00CG2 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG3;
       prmP00CG3 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG4;
       prmP00CG4 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG5;
       prmP00CG5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00CG6;
       prmP00CG6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG7;
       prmP00CG7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00CG8;
       prmP00CG8 = new Object[] {
       };
       Object[] prmP00CG9;
       prmP00CG9 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CG2", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG3", "SELECT Trn_ThemeId, OrganisationId FROM Trn_Theme WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG3,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG4", "DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG4)
          ,new CursorDef("P00CG5", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG5)
          ,new CursorDef("P00CG6", "DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG6)
          ,new CursorDef("P00CG7", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG7)
          ,new CursorDef("P00CG8", "SELECT Trn_ThemeFontFamily, Trn_ThemeFontSize, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeName = ( 'Modern') ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG9", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG9,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
