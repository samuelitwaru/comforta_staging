using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtProgram : GxUserType, IGxExternalObject
   {
      public SdtProgram( )
      {
         /* Constructor for serialization */
      }

      public SdtProgram( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void main( object gxTp_args )
      {
         ApplicationDesign.Program.Main((System.String[])(gxTp_args)) ;
         return  ;
      }

      public GxSimpleCollection<string> buildpagetree( string gxTp_pagesJson )
      {
         GxSimpleCollection<string> returnbuildpagetree;
         returnbuildpagetree = new GxSimpleCollection<string>();
         System.Collections.Generic.Dictionary< System.String, Page> externalParm0;
         externalParm0 = ApplicationDesign.Program.BuildPageTree(gxTp_pagesJson);
         returnbuildpagetree.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.Dictionary< System.String, Page>), externalParm0);
         return returnbuildpagetree ;
      }

      public Object ExternalInstance
      {
         get {
            if ( Program_externalReference == null )
            {
               Program_externalReference = new ApplicationDesign.Program();
            }
            return Program_externalReference ;
         }

         set {
            Program_externalReference = (ApplicationDesign.Program)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected ApplicationDesign.Program Program_externalReference=null ;
   }

}
