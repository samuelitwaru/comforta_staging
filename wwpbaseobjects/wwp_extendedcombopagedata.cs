using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_extendedcombopagedata : GXProcedure
   {
      public wwp_extendedcombopagedata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_extendedcombopagedata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP0_Combo_Data ,
                           short aP1_SkipItems ,
                           int aP2_MaxItems )
      {
         this.AV8Combo_Data = aP0_Combo_Data;
         this.AV10SkipItems = aP1_SkipItems;
         this.AV9MaxItems = aP2_MaxItems;
         initialize();
         ExecuteImpl();
         aP0_Combo_Data=this.AV8Combo_Data;
      }

      public void executeSubmit( ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP0_Combo_Data ,
                                 short aP1_SkipItems ,
                                 int aP2_MaxItems )
      {
         this.AV8Combo_Data = aP0_Combo_Data;
         this.AV10SkipItems = aP1_SkipItems;
         this.AV9MaxItems = aP2_MaxItems;
         SubmitImpl();
         aP0_Combo_Data=this.AV8Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SkipItemsAux = AV10SkipItems;
         while ( AV11SkipItemsAux > 0 )
         {
            AV8Combo_Data.RemoveItem(1);
            AV11SkipItemsAux = (short)(AV11SkipItemsAux-1);
         }
         while ( AV8Combo_Data.Count > AV9MaxItems )
         {
            AV8Combo_Data.RemoveItem(AV8Combo_Data.Count);
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
         /* GeneXus formulas. */
      }

      private short AV10SkipItems ;
      private short AV11SkipItemsAux ;
      private int AV9MaxItems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP0_Combo_Data ;
   }

}
