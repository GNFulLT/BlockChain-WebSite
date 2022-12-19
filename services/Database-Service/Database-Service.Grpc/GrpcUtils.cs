using ProtoBuf;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Database_Service.Grpc
{
    public static class GrpcUtils
    {

        public static bool IsCompilerGenerated(this Type type)
        {
            return type.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() != null;
        }

        public static bool IsGrpcService(this Type type)
        {
            return type.GetCustomAttribute<ServiceAttribute>() != null;
        }

        private static SchemaGenerator SCHEMA_GENERATOR = new SchemaGenerator
        {
            ProtoSyntax = ProtoSyntax.Proto3
        };

        private static MethodInfo SCHEMA_METHOD; 


        static GrpcUtils()
        {
            var methods = SCHEMA_GENERATOR.GetType().GetMethods();
            var method = methods.First(inf =>
            {;
                return String.Equals(inf.Name, "GetSchema") && !inf.IsGenericMethod;
            });
            SCHEMA_METHOD = method;
        }

        public static string AssemblyDirectoryWith()
        {
            var debugFol = Environment.CurrentDirectory;
            var debugFol2 = Assembly.GetCallingAssembly().GetName().Name;

            return Path.Combine(Directory.GetParent(debugFol)!.FullName,debugFol2);
            
            
        }

        private static string DEFAULT_PATH = "protos";
        public static void WriteProtoFiles<T>()
        {

            Assembly ass = Assembly.GetExecutingAssembly();
            var serviceTypes = ass.GetTypes().Where(t => String.Equals(t.Namespace, "Database_Service.Grpc.DataServices") && t.IsGrpcService());

            var path = AssemblyDirectoryWith();

            path = Path.Combine(path, @"protos");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var serviceType in serviceTypes)
            {
                var schema = (string)SCHEMA_METHOD.Invoke(SCHEMA_GENERATOR,new object[] { serviceType })!;
                var fileName = serviceType.Name.Substring(1, serviceType.Name.Length-1).AsSpan();
                File.WriteAllText($"{path}/{fileName}.proto", schema);

            }
            Type t = typeof(T);
        }

        public static void ValidateRequest(object reqObj,string propName)
        {
            if(reqObj is null)
            {
                throw new Exception(propName + " is null");
            }
            StringBuilder builder = new();
            bool hasNullProp = false;
            reqObj.GetType()
               .GetProperties()
               .AsParallel()
               .ForAll((prop) =>
               {
                   if (prop.GetValue(reqObj) is null)
                   {
                       lock(builder)
                       {
                           builder.Append($"{prop.Name} cannot be null,");
                       }
                       hasNullProp = true;
                   }
               });

            builder = builder.Remove(builder.Length - 1, 1);
            if(hasNullProp)
            {
                throw new Exception(builder.ToString());
            }
        }
    }
}
