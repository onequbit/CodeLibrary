using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeLibrary;
using System.IO;
using System;
using System.Text;

namespace CodeLibraryTests
{
    [TestClass]
    public class ShellCmd_Tests
    {
        [TestMethod]
        public void ShellCmd_Invoke_Test()
        {   
            ShellCmd.Invoke("dir").ToConsole();            
        }

        [TestMethod]
        public void ShellCmd_Obj_Test()
        {
            ShellCmd sc = new ShellCmd("dir");
            sc.Output.ToConsole();
        }

        private void simpleDirCall()
        {
            var output = ShellCmd.Invoke("dir");
        }

        private void referencedDirCall()
        {
            ShellCmd sc = new ShellCmd("dir");
            sc.Output.ToConsole();
            sc.Error.ToConsole();            
        }
                
        private void Timed_CmdCalls(int numberOfRuns)
        {
            var stdout = Console.Out;
            var stderr = Console.Error;
            Console.SetOut(StreamWriter.Null);
            Console.SetError(StreamWriter.Null);
            int firstRange = numberOfRuns;
            int secondRange = numberOfRuns + numberOfRuns;            
            var simpleRun = Lib.RunTimer(
                () =>
                {
                    for (int i = 0; i < firstRange; i++)
                    {                        
                        simpleDirCall();                        
                    }
                }
            );
            var otherRun = Lib.RunTimer(
                () =>
                {
                    for (int i = numberOfRuns; i < secondRange; i++)
                    {                        
                        referencedDirCall();
                    }
                }
            );
            Console.SetOut(stdout);
            Console.SetError(stderr);
            $"simpleRun: {simpleRun.TotalMilliseconds}".ToConsole();
            $"otherRun: {otherRun.TotalMilliseconds}".ToConsole();
        }

        [TestMethod]
        public void CallCmd_Timed_Tests()
        {
            Timed_CmdCalls(100);
            Timed_CmdCalls(1000);            
        }

    }
}
