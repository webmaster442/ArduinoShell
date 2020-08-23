//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Communitations;
using ArduinoShell.Interfaces;
using ArduinoShell.Properties;
using System;

namespace ArduinoShell
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Console.WriteLine(Resources.UsageInfo);
                    Environment.ExitCode = 1;
                    return;
                }
                using (IComPort port = new ComPort(args[0]))
                {
                    Shell shell = new Shell(AppBuilder.Console, port, AppBuilder.Commands);
                    shell.Run();
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine(Resources.ErrorCommunication);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Resources.UncaughtException, ex.Message);
#if DEBUG
                Console.WriteLine("Stack trace:");
                Console.WriteLine(ex.StackTrace);
#endif
            }
        }
    }
}
