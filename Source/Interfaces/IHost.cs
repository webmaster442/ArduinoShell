//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

namespace ArduinoShell.Interfaces
{
    internal interface IHost
    {
        IConsole Console { get; }
        IComPort ComPort { get; }
    }
}
