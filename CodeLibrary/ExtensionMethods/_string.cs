using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibrary
{
    public static partial class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static void ToConsole(this string str) => Console.WriteLine(str);                

        public static void Print(this string str) => Console.Write(str);

        public static string With(this string str, params object[] values)
        {
            return string.Format(str, values);
        }

        public static void KeyPrompt(this string prompt)
        {
            prompt.Print();
            Console.ReadKey();
        }

        public static void EnterPrompt(this string prompt)
        {
            prompt.Print();
            Console.ReadLine();
        }

        
    }
}
