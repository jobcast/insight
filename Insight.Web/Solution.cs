﻿ 
 
 
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace SolutionConfiguration
{ 
    public static class Solution  
    {
        static IEnumerable<string> AssemblyNames => new[] { 
            "Insight", "Insight.Snowball", "Insight.Web", "Infra", "Insight.Parsing", "Insight.Parsing.Matching", "Infra.Csv", "Insight.Parsing.Classifiers", "Infra.SharpZipLib", "Infra.AccordNet"
        };  

        public static IEnumerable<Assembly> Assemblies => AssemblyNames 
            .Select(an => Load(an))
            .Where(a => a != null);

        [DebuggerHidden]
        static Assembly Load(string assemblyName)
        {
            try
            {
                return Assembly.Load(new AssemblyName(assemblyName));
            }
            catch
            {
                return null;
            }
        }
    }
}

