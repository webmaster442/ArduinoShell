//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.CommandImplementations;
using ArduinoShell.Interfaces;
using System.Collections.Generic;

namespace ArduinoShell
{
    internal static class AppBuilder
    {
        public static IConsole Console { get; } = new TextConsole();

        public static IEnumerable<ICommand> Commands
        {
            get
            {
                yield return new DigitalWriteCommand();
                yield return new DigitalReadCommand();
                yield return new GetVersionCommand();
            }
        }
    }
}
