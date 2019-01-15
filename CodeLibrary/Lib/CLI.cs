using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ServerTools
{
    public static class CLI
    {
        public static string CallCmd(string argstr)
        {
            return Call("cmd", "/c " + argstr);            
        }

        public static string Call(string cmd, string argstr)
        {
            string output = "";
            using (Process p = new Process())
            {                
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = argstr;
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            return output;
        }
    }
}
