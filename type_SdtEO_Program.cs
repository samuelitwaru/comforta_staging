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
   public class SdtEO_Program : GxUserType, IGxExternalObject
   {
      public SdtEO_Program( )
      {
         /* Constructor for serialization */
      }

      public SdtEO_Program( IGxContext context )
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

      public string buildpagetree( string gxTp_pagesJson )
      {
         string returnbuildpagetree;
         returnbuildpagetree = "";
         returnbuildpagetree = (string)(ApplicationDesign.Program.BuildPageTree(gxTp_pagesJson));
         return returnbuildpagetree ;
      }

      public Object ExternalInstance
      {
         get {
            if ( EO_Program_externalReference == null )
            {
               EO_Program_externalReference = new ApplicationDesign.Program();
            }
            return EO_Program_externalReference ;
         }

         set {
            EO_Program_externalReference = (ApplicationDesign.Program)(value);
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

      protected ApplicationDesign.Program EO_Program_externalReference=null ;
   }

}
