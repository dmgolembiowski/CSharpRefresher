using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Subprocessing
{
    public delegate string PythonScript(string _FileName, string _args);

    public class Program
    {
        static string Subprocess(string _FileName, string _args) {

            // Define where python is on $PATH
            string executable = $@"{_FileName}";
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(executable);

            // Read STDOUT, via `python -c "print(foo)"`
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.Arguments = "";
            myProcessStartInfo.Arguments += _args;

            // Spawn the process
            Process script = new Process();
            script.StartInfo = myProcessStartInfo;`
            script.Start();

            // Get the results
            StreamReader outReader = script.StandardOutput;
            string dotnetInReader = outReader.ReadLine();

            // Avoid deadlock
            script.WaitForExit();
            script.Close();

            return dotnetInReader;
        }
        public static void Main()
        {
            PythonScript Python = Subprocess;
            try {
                string pyProc0 = Python("test_args.py", "2 3 4 5 cat");
                Console.WriteLine($"pyProc0: {pyProc0}");
                dynamic pyProc1 = Python("antigravityTurtle.py", "");
                Console.WriteLine($"pyProc1: {pyProc1}");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
