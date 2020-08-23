//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Interfaces;
using ArduinoShell.Properties;
using System;

namespace ArduinoShell
{
    internal sealed class TextConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params object[] parameters)
        {
            Console.WriteLine(format, parameters);
        }

        public void WritePrompt(string adress)
        {
            Console.Write(Resources.Prompt, adress);
        }
    }
}
