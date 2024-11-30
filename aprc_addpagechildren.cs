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
   public class aprc_addpagechildren : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_addpagechildren().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_ParentPageId = new Guid()  ;
         Guid aP1_ChildPageId = new Guid()  ;
         string aP2_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_ParentPageId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_ParentPageId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_ChildPageId=((Guid)(StringUtil.StrToGuid( (string)(args[1]))));
         }
         else
         {
            aP1_ChildPageId=Guid.Empty;
         }
         if ( 2 < args.Length )
         {
            aP2_response=((string)(args[2]));
         }
         else
         {
            aP2_response="";
         }
         execute(aP0_ParentPageId, aP1_ChildPageId, out aP2_response);
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_addpagechildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_addpagechildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ParentPageId ,
                           Guid aP1_ChildPageId ,
                           out string aP2_response )
      {
         this.AV18ParentPageId = aP0_ParentPageId;
         this.AV19ChildPageId = aP1_ChildPageId;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV14response;
      }

      public string executeUdp( Guid aP0_ParentPageId ,
                                Guid aP1_ChildPageId )
      {
         execute(aP0_ParentPageId, aP1_ChildPageId, out aP2_response);
         return AV14response ;
      }

      public void executeSubmit( Guid aP0_ParentPageId ,
                                 Guid aP1_ChildPageId ,
                                 out string aP2_response )
      {
         this.AV18ParentPageId = aP0_ParentPageId;
         this.AV19ChildPageId = aP1_ChildPageId;
         this.AV14response = "" ;
         SubmitImpl();
         aP2_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Trn_Page.Load(AV18ParentPageId, A318Trn_PageName, A29LocationId);
         /* Using cursor P008X2 */
         pr_default.execute(0, new Object[] {AV18ParentPageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P008X2_A310Trn_PageId[0];
            A437PageChildren = P008X2_A437PageChildren[0];
            n437PageChildren = P008X2_n437PageChildren[0];
            A29LocationId = P008X2_A29LocationId[0];
            A318Trn_PageName = P008X2_A318Trn_PageName[0];
            AV23SDT_PageChildrenCollection.FromJSonString(A437PageChildren, null);
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV23SDT_PageChildrenCollection.Count )
            {
               AV22SDT_PageChildren = ((SdtSDT_PageChildren)AV23SDT_PageChildrenCollection.Item(AV27GXV1));
               if ( AV22SDT_PageChildren.gxTpr_Id == AV19ChildPageId )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               AV27GXV1 = (int)(AV27GXV1+1);
            }
            AV22SDT_PageChildren = new SdtSDT_PageChildren(context);
            AV22SDT_PageChildren.gxTpr_Id = AV19ChildPageId;
            AV25Child.Load(AV19ChildPageId, A318Trn_PageName, A29LocationId);
            AV22SDT_PageChildren.gxTpr_Name = AV25Child.gxTpr_Trn_pagename;
            AV23SDT_PageChildrenCollection.Add(AV22SDT_PageChildren, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV24Trn_Page.gxTpr_Pagechildren = AV23SDT_PageChildrenCollection.ToJSonString(false);
         AV24Trn_Page.Save();
         context.CommitDataStores("prc_addpagechildren",pr_default);
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
         AV14response = "";
         AV24Trn_Page = new SdtTrn_Page(context);
         A318Trn_PageName = "";
         A29LocationId = Guid.Empty;
         P008X2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008X2_A437PageChildren = new string[] {""} ;
         P008X2_n437PageChildren = new bool[] {false} ;
         P008X2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008X2_A318Trn_PageName = new string[] {""} ;
         A310Trn_PageId = Guid.Empty;
         A437PageChildren = "";
         AV23SDT_PageChildrenCollection = new GXBaseCollection<SdtSDT_PageChildren>( context, "SDT_PageChildren", "Comforta_version2");
         AV22SDT_PageChildren = new SdtSDT_PageChildren(context);
         AV25Child = new SdtTrn_Page(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_addpagechildren__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_addpagechildren__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_addpagechildren__default(),
            new Object[][] {
                new Object[] {
               P008X2_A310Trn_PageId, P008X2_A437PageChildren, P008X2_n437PageChildren, P008X2_A29LocationId, P008X2_A318Trn_PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27GXV1 ;
      private bool n437PageChildren ;
      private string AV14response ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid AV18ParentPageId ;
      private Guid AV19ChildPageId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Page AV24Trn_Page ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008X2_A310Trn_PageId ;
      private string[] P008X2_A437PageChildren ;
      private bool[] P008X2_n437PageChildren ;
      private Guid[] P008X2_A29LocationId ;
      private string[] P008X2_A318Trn_PageName ;
      private GXBaseCollection<SdtSDT_PageChildren> AV23SDT_PageChildrenCollection ;
      private SdtSDT_PageChildren AV22SDT_PageChildren ;
      private SdtTrn_Page AV25Child ;
      private string aP2_response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_addpagechildren__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_addpagechildren__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_addpagechildren__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP008X2;
       prmP008X2 = new Object[] {
       new ParDef("AV18ParentPageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008X2", "SELECT Trn_PageId, PageChildren, LocationId, Trn_PageName FROM Trn_Page WHERE Trn_PageId = :AV18ParentPageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008X2,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
