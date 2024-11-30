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
   public class wwp_deletefilter : GXProcedure
   {
      public wwp_deletefilter( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_deletefilter( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                           string aP1_FilterName ,
                           bool aP2_IsDynamic ,
                           out bool aP3_FilterDeleted )
      {
         this.AV11GridState = aP0_GridState;
         this.AV10FilterName = aP1_FilterName;
         this.AV14IsDynamic = aP2_IsDynamic;
         this.AV9FilterDeleted = false ;
         initialize();
         ExecuteImpl();
         aP0_GridState=this.AV11GridState;
         aP3_FilterDeleted=this.AV9FilterDeleted;
      }

      public bool executeUdp( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                              string aP1_FilterName ,
                              bool aP2_IsDynamic )
      {
         execute(ref aP0_GridState, aP1_FilterName, aP2_IsDynamic, out aP3_FilterDeleted);
         return AV9FilterDeleted ;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                                 string aP1_FilterName ,
                                 bool aP2_IsDynamic ,
                                 out bool aP3_FilterDeleted )
      {
         this.AV11GridState = aP0_GridState;
         this.AV10FilterName = aP1_FilterName;
         this.AV14IsDynamic = aP2_IsDynamic;
         this.AV9FilterDeleted = false ;
         SubmitImpl();
         aP0_GridState=this.AV11GridState;
         aP3_FilterDeleted=this.AV9FilterDeleted;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9FilterDeleted = false;
         AV13Index = 1;
         if ( AV14IsDynamic )
         {
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV11GridState.gxTpr_Dynamicfilters.Count )
            {
               AV8DynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV8DynamicFilter.gxTpr_Selected, AV10FilterName) == 0 )
               {
                  AV9FilterDeleted = true;
                  if (true) break;
               }
               AV13Index = (short)(AV13Index+1);
               AV15GXV1 = (int)(AV15GXV1+1);
            }
            if ( AV9FilterDeleted )
            {
               AV11GridState.gxTpr_Dynamicfilters.RemoveItem(AV13Index);
            }
         }
         else
         {
            AV16GXV2 = 1;
            while ( AV16GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
            {
               AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV16GXV2));
               if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, AV10FilterName) == 0 )
               {
                  AV9FilterDeleted = true;
                  if (true) break;
               }
               AV13Index = (short)(AV13Index+1);
               AV16GXV2 = (int)(AV16GXV2+1);
            }
            if ( AV9FilterDeleted )
            {
               AV11GridState.gxTpr_Filtervalues.RemoveItem(AV13Index);
            }
            if ( StringUtil.StartsWith( AV10FilterName, "TF") && ! StringUtil.EndsWith( AV10FilterName, "_SEL") )
            {
               if ( new GeneXus.Programs.wwpbaseobjects.wwp_deletefilter(context).executeUdp( ref  AV11GridState,  AV10FilterName+"_SEL",  false) )
               {
                  AV9FilterDeleted = true;
               }
            }
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
         AV8DynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         /* GeneXus formulas. */
      }

      private short AV13Index ;
      private int AV15GXV1 ;
      private int AV16GXV2 ;
      private bool AV14IsDynamic ;
      private bool AV9FilterDeleted ;
      private string AV10FilterName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV8DynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private bool aP3_FilterDeleted ;
   }

}
