using System;

namespace CodeLibrary
{
    public static partial class Lib
    {
        public static void WaitForKeyPress(string message = "")
        {
            Console.Write(message);
            Console.ReadKey();
        }
    }
}
