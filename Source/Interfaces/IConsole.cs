﻿//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

namespace ArduinoShell.Interfaces
{
    internal interface IConsole
    {
        string ReadLine();
        void WritePrompt(string adress);
        void WriteLine(string format, params object[] parameters);
    }
}
