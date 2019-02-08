using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CodeLibrary;

namespace CodeLibraryTests
{

    [TestClass]
    public class ExtensionMethods_Tests
    {
        [TestMethod]
        public void Join_Test()
        {
            string[] collection = new string[] { "one", "two", "three", "four" };

            collection.Join(" ").ToConsole();
            collection.Join(", ").ToConsole();
            $"[{collection.Join(":")}]".ToConsole();
        }
    }
}
