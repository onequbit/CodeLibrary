using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public static partial class ExtensionMethods
    {
        
        public static void ThrowIfNull(this object thing, string message = "")
        {
            if (thing == null) throw new NullReferenceException();
        }

        public static void ThrowIfTrue(this bool condition, Exception ex)
        {
            if (condition) throw ex;
        }
    }
}
