using System.Linq;
using PapyrusDotNet.Common.Interfaces;

namespace PapyrusDotNet.Converters.Papyrus2Clr.Implementations
{
    public class ClrNamespaceResolver : INamespaceResolver
    {
        //private readonly IAssemblyNameResolver assemblyNameResolver;

        //public PapyrusNamespaceResolver(IAssemblyNameResolver assemblyNameResolver)
        //{
        //    this.assemblyNameResolver = assemblyNameResolver;
        //}

        public string Resolve(string typeName)
        {
            if (typeName.Contains('.')) typeName = typeName.Split('.').LastOrDefault();
            if (typeName != null)
            {
                var typeNameLower = typeName.ToLower();

                if (typeName.EndsWith("[]"))
                {
                    typeNameLower = typeNameLower.Replace("[]", "");
                }

                /* have not added all possible types yet though.. might be a better way of doing it. */
                if (typeNameLower == "string" || typeNameLower == "int" || typeNameLower == "boolean" ||
                    typeNameLower == "bool" || typeNameLower == "none"
                    || typeNameLower == "void" || typeNameLower == "float" || typeNameLower == "short" ||
                    typeNameLower == "char" || typeNameLower == "double"
                    || typeNameLower == "int32" || typeNameLower == "integer32" || typeNameLower == "long" ||
                    typeNameLower == "uint")
                {
                    return "System";
                }
            }
            return "PapyrusDotNet.Core"; // assemblyNameResolver.BaseNamespace;
        }
    }
}