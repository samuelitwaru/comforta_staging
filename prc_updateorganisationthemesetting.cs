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
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A248Trn_ThemeName = P00CG2_A248Trn_ThemeName[0];
            A247Trn_ThemeId = P00CG2_A247Trn_ThemeId[0];
            AV17BC_Trn_Theme = new SdtTrn_Theme(context);
            AV26Modern_Trn_Theme.Load(A247Trn_ThemeId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00CG3 */
         pr_default.execute(1, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P00CG3_A11OrganisationId[0];
            n11OrganisationId = P00CG3_n11OrganisationId[0];
            A100OrganisationSettingid = P00CG3_A100OrganisationSettingid[0];
            AV31GXLvl23 = 0;
            /* Using cursor P00CG4 */
            pr_default.execute(2, new Object[] {AV8OrganisationId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A247Trn_ThemeId = P00CG4_A247Trn_ThemeId[0];
               A11OrganisationId = P00CG4_A11OrganisationId[0];
               n11OrganisationId = P00CG4_n11OrganisationId[0];
               AV31GXLvl23 = 1;
               /* Optimized DELETE. */
               /* Using cursor P00CG5 */
               pr_default.execute(3, new Object[] {A247Trn_ThemeId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
               /* End optimized DELETE. */
               AV33GXV1 = 1;
               while ( AV33GXV1 <= AV12ColorNameCollection.Count )
               {
                  AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV33GXV1));
                  AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
                  AV15Index = (short)(AV12ColorNameCollection.IndexOf(AV14ColorSDTName));
                  /*
                     INSERT RECORD ON TABLE Trn_ThemeColor

                  */
                  A250ColorName = AV19ColorName;
                  A251ColorCode = ((string)AV13ColorCodeCollection.Item(AV15Index));
                  A249ColorId = Guid.NewGuid( );
                  /* Using cursor P00CG6 */
                  pr_default.execute(4, new Object[] {A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                  pr_default.close(4);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                  if ( (pr_default.getStatus(4) == 1) )
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
                  AV33GXV1 = (int)(AV33GXV1+1);
               }
               /* Optimized DELETE. */
               /* Using cursor P00CG7 */
               pr_default.execute(5, new Object[] {A247Trn_ThemeId});
               pr_default.close(5);
               pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
               /* End optimized DELETE. */
               AV35GXV2 = 1;
               while ( AV35GXV2 <= AV24CtaColorNameCollection.Count )
               {
                  AV19ColorName = ((string)AV24CtaColorNameCollection.Item(AV35GXV2));
                  AV15Index = (short)(AV24CtaColorNameCollection.IndexOf(AV19ColorName));
                  /*
                     INSERT RECORD ON TABLE Trn_ThemeCtaColor

                  */
                  A564CtaColorName = AV19ColorName;
                  A565CtaColorCode = ((string)AV25CtaColorCodeCollection.Item(AV15Index));
                  A563CtaColorId = Guid.NewGuid( );
                  /* Using cursor P00CG8 */
                  pr_default.execute(6, new Object[] {A247Trn_ThemeId, A563CtaColorId, A564CtaColorName, A565CtaColorCode});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                  if ( (pr_default.getStatus(6) == 1) )
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
                  AV35GXV2 = (int)(AV35GXV2+1);
               }
               /* Optimized DELETE. */
               /* Using cursor P00CG9 */
               pr_default.execute(7, new Object[] {A247Trn_ThemeId});
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
               /* End optimized DELETE. */
               AV37GXV3 = 1;
               while ( AV37GXV3 <= AV26Modern_Trn_Theme.gxTpr_Icon.Count )
               {
                  AV28Icon = ((SdtTrn_Theme_Icon)AV26Modern_Trn_Theme.gxTpr_Icon.Item(AV37GXV3));
                  /*
                     INSERT RECORD ON TABLE Trn_ThemeIcon

                  */
                  A262IconName = AV28Icon.gxTpr_Iconname;
                  A263IconSVG = AV28Icon.gxTpr_Iconsvg;
                  A443IconCategory = AV28Icon.gxTpr_Iconcategory;
                  A261IconId = Guid.NewGuid( );
                  /* Using cursor P00CG10 */
                  pr_default.execute(8, new Object[] {A247Trn_ThemeId, A261IconId, A262IconName, A263IconSVG, A443IconCategory});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                  if ( (pr_default.getStatus(8) == 1) )
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
                  AV37GXV3 = (int)(AV37GXV3+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV31GXLvl23 == 0 )
            {
               /* Execute user subroutine: 'CREATENEWTHEME' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWTHEME' Routine */
         returnInSub = false;
         /* Using cursor P00CG11 */
         pr_default.execute(9, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A11OrganisationId = P00CG11_A11OrganisationId[0];
            n11OrganisationId = P00CG11_n11OrganisationId[0];
            A100OrganisationSettingid = P00CG11_A100OrganisationSettingid[0];
            AV17BC_Trn_Theme.gxTpr_Trn_themeid = AV8OrganisationId;
            AV17BC_Trn_Theme.gxTpr_Trn_themename = "Your Style";
            AV17BC_Trn_Theme.gxTpr_Trn_themefontfamily = AV26Modern_Trn_Theme.gxTpr_Trn_themefontfamily;
            AV17BC_Trn_Theme.gxTpr_Trn_themefontsize = AV26Modern_Trn_Theme.gxTpr_Trn_themefontsize;
            AV17BC_Trn_Theme.gxTpr_Organisationid = AV8OrganisationId;
            AV17BC_Trn_Theme.gxTpr_Color.Clear();
            AV39GXV4 = 1;
            while ( AV39GXV4 <= AV24CtaColorNameCollection.Count )
            {
               AV19ColorName = ((string)AV24CtaColorNameCollection.Item(AV39GXV4));
               AV27CtaColor = new SdtTrn_Theme_CtaColor(context);
               AV27CtaColor.gxTpr_Ctacolorid = Guid.NewGuid( );
               AV27CtaColor.gxTpr_Ctacolorname = AV19ColorName;
               AV27CtaColor.gxTpr_Ctacolorcode = ((string)AV25CtaColorCodeCollection.Item(AV24CtaColorNameCollection.IndexOf(AV19ColorName)));
               AV17BC_Trn_Theme.gxTpr_Ctacolor.Add(AV27CtaColor, 0);
               AV39GXV4 = (int)(AV39GXV4+1);
            }
            AV40GXV5 = 1;
            while ( AV40GXV5 <= AV12ColorNameCollection.Count )
            {
               AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV40GXV5));
               AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
               AV20Color = new SdtTrn_Theme_Color(context);
               AV20Color.gxTpr_Colorid = Guid.NewGuid( );
               AV20Color.gxTpr_Colorname = AV19ColorName;
               AV20Color.gxTpr_Colorcode = ((string)AV13ColorCodeCollection.Item(AV12ColorNameCollection.IndexOf(AV14ColorSDTName)));
               AV17BC_Trn_Theme.gxTpr_Color.Add(AV20Color, 0);
               AV40GXV5 = (int)(AV40GXV5+1);
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
               AV42GXV7 = 1;
               AV41GXV6 = AV17BC_Trn_Theme.GetMessages();
               while ( AV42GXV7 <= AV41GXV6.Count )
               {
                  AV22ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV41GXV6.Item(AV42GXV7));
                  GX_msglist.addItem(AV22ErrorMessage.gxTpr_Description);
                  AV42GXV7 = (int)(AV42GXV7+1);
               }
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
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
         P00CG2_A248Trn_ThemeName = new string[] {""} ;
         P00CG2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A248Trn_ThemeName = "";
         A247Trn_ThemeId = Guid.Empty;
         AV17BC_Trn_Theme = new SdtTrn_Theme(context);
         AV26Modern_Trn_Theme = new SdtTrn_Theme(context);
         P00CG3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG3_n11OrganisationId = new bool[] {false} ;
         P00CG3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         P00CG4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00CG4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG4_n11OrganisationId = new bool[] {false} ;
         AV14ColorSDTName = "";
         AV19ColorName = "";
         A250ColorName = "";
         A251ColorCode = "";
         A249ColorId = Guid.Empty;
         Gx_emsg = "";
         A564CtaColorName = "";
         A565CtaColorCode = "";
         A563CtaColorId = Guid.Empty;
         AV28Icon = new SdtTrn_Theme_Icon(context);
         A262IconName = "";
         A263IconSVG = "";
         A443IconCategory = "";
         A261IconId = Guid.Empty;
         P00CG11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CG11_n11OrganisationId = new bool[] {false} ;
         P00CG11_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         AV27CtaColor = new SdtTrn_Theme_CtaColor(context);
         AV20Color = new SdtTrn_Theme_Color(context);
         AV21BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV41GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
               P00CG2_A248Trn_ThemeName, P00CG2_A247Trn_ThemeId
               }
               , new Object[] {
               P00CG3_A11OrganisationId, P00CG3_A100OrganisationSettingid
               }
               , new Object[] {
               P00CG4_A247Trn_ThemeId, P00CG4_A11OrganisationId, P00CG4_n11OrganisationId
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
               }
               , new Object[] {
               }
               , new Object[] {
               P00CG11_A11OrganisationId, P00CG11_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31GXLvl23 ;
      private short AV15Index ;
      private int AV33GXV1 ;
      private int GX_INS47 ;
      private int AV35GXV2 ;
      private int GX_INS112 ;
      private int AV37GXV3 ;
      private int GX_INS87 ;
      private int AV39GXV4 ;
      private int AV40GXV5 ;
      private int AV42GXV7 ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private bool returnInSub ;
      private string AV9OrganisationBrandTheme ;
      private string AV10OrganisationCtaTheme ;
      private string A263IconSVG ;
      private string A248Trn_ThemeName ;
      private string AV14ColorSDTName ;
      private string AV19ColorName ;
      private string A250ColorName ;
      private string A251ColorCode ;
      private string A564CtaColorName ;
      private string A565CtaColorCode ;
      private string A262IconName ;
      private string A443IconCategory ;
      private Guid AV8OrganisationId ;
      private Guid A247Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private Guid A249ColorId ;
      private Guid A563CtaColorId ;
      private Guid A261IconId ;
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
      private string[] P00CG2_A248Trn_ThemeName ;
      private Guid[] P00CG2_A247Trn_ThemeId ;
      private SdtTrn_Theme AV17BC_Trn_Theme ;
      private SdtTrn_Theme AV26Modern_Trn_Theme ;
      private Guid[] P00CG3_A11OrganisationId ;
      private bool[] P00CG3_n11OrganisationId ;
      private Guid[] P00CG3_A100OrganisationSettingid ;
      private Guid[] P00CG4_A247Trn_ThemeId ;
      private Guid[] P00CG4_A11OrganisationId ;
      private bool[] P00CG4_n11OrganisationId ;
      private SdtTrn_Theme_Icon AV28Icon ;
      private Guid[] P00CG11_A11OrganisationId ;
      private bool[] P00CG11_n11OrganisationId ;
      private Guid[] P00CG11_A100OrganisationSettingid ;
      private SdtTrn_Theme_CtaColor AV27CtaColor ;
      private SdtTrn_Theme_Color AV20Color ;
      private GXBCCollection<SdtTrn_Theme> AV21BC_Trn_ThemeCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV41GXV6 ;
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
      ,new ForEachCursor(def[2])
      ,new UpdateCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00CG2;
       prmP00CG2 = new Object[] {
       };
       Object[] prmP00CG3;
       prmP00CG3 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG4;
       prmP00CG4 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG5;
       prmP00CG5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG6;
       prmP00CG6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00CG7;
       prmP00CG7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG8;
       prmP00CG8 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00CG9;
       prmP00CG9 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00CG10;
       prmP00CG10 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0)
       };
       Object[] prmP00CG11;
       prmP00CG11 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CG2", "SELECT Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeName = ( 'Modern') ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG3", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG3,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG4", "SELECT Trn_ThemeId, OrganisationId FROM Trn_Theme WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CG5", "DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG5)
          ,new CursorDef("P00CG6", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG6)
          ,new CursorDef("P00CG7", "DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG7)
          ,new CursorDef("P00CG8", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG8)
          ,new CursorDef("P00CG9", "DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG9)
          ,new CursorDef("P00CG10", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconName, IconSVG, IconCategory) VALUES(:Trn_ThemeId, :IconId, :IconName, :IconSVG, :IconCategory);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG10)
          ,new CursorDef("P00CG11", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG11,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
