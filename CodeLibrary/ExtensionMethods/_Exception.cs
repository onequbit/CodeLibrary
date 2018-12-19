using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibrary
{
    public static partial class ExtensionMethods
    {
        public static void ToConsole(this Exception ex)
        {
            var message = ex.Message;
            var innerException = ex.InnerException;
            var source = ex.Source;
            var stack = ex.StackTrace;
            var data = ex.Data;
            $"{message}\n{innerException}\n{source}\n{stack}\n{data}".ToConsole();
        }
    }
}
