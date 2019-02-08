using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class ShellCmd
    {
        private Process _process { get; set; }

        public string Output { get; set; }
        public string Error { get; set; }
                
        public ShellCmd(string command, string arguments = "")
        {
            command.IsNullOrEmpty().ThrowIfTrue(new ArgumentException("no command specified"));
                
            string _output = string.Empty;
            string _error = string.Empty;
            _process = new Process
            {
                StartInfo = { FileName = "cmd", Arguments = $"/c {command} {arguments}" }
            };
            ShellCmd.Invoke( _process, ref _output, ref _error);
            this.Output = _output;
            this.Error = _error;
        }

        public ShellCmd(string command, string[] argumentsArray) : this (command, argumentsArray.Join(" "))
        {            
        }

        public static string Invoke(string command, string argumentStr = "")
        {
            string output = string.Empty;
            string _ignoreErr = string.Empty;
            Invoke(command, argumentStr, ref output, ref _ignoreErr);
            return output;            
        }

        public static void Invoke(string command, string argumentStr, ref string output, ref string error)
        {
            Process p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd",
                    Arguments = $"/c {command} {argumentStr}"
                }
            };
            Invoke(p, ref output, ref error);            
        }

        public static void Invoke(Process p, ref string output, ref string error)
        {
            using (p)            
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;                
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                error = p.StandardError.ReadToEnd();
                p.WaitForExit();                
            }
        }
    }

    [Obsolete("use ShellCmd instead")]
    public static class CLI
    {
        public static string CallCmd(string argstr)
        {
            return Call("cmd", "/c " + argstr);            
        }

        public static string Call(string cmd, string argstr)
        {
            string output = "";
            using (Process p = new Process {
                StartInfo =
                {
                    FileName = cmd, Arguments = argstr,
                    UseShellExecute = false, RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            })
            {
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            return output;
        }

        public static void CallCmd(string commandStr, ref string output, ref string error)
        {
            Call("cmd", "/c " + commandStr, ref output, ref error);
        }

        public static void Call(string command, string arguments, ref string output, ref string error)
        {            
            using (Process p = new Process
            {
                StartInfo =
                {
                    FileName = command, Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true                    
                }
            })
            {                
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                error = p.StandardError.ReadToEnd();
                p.WaitForExit();                
            }            
        }
    }
}
