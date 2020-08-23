//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Interfaces;
using ArduinoShell.Properties;
using ArduinoShell.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArduinoShell
{
    internal sealed class Shell : IHost
    {
        private readonly IEnumerable<ICommand> _commands;
        private readonly IConsole _console;
        private readonly IComPort _port;

        public Shell(IConsole console,
                     IComPort port,
                     IEnumerable<ICommand> commands)
        {
            _commands = commands;
            _console = console;
            _port = port;
        }

        IConsole IHost.Console => _console;

        IComPort IHost.ComPort => _port;

        public void Run()
        {
            while (true)
            {
                _console.WritePrompt(_port.Adress);
                string rawline = _console.ReadLine();
                string[] tokens = rawline.Tokenize();

                if (tokens[0] == "exit")
                {
                    Environment.Exit(0);
                    return;
                }

                try
                {
                    ICommand cmd = _commands.FirstOrDefault(c => c.Name == tokens[0]);
                    if (cmd != null)
                    {
                        cmd.Host = this;
                        object? result = cmd.Execute(tokens.Skip(1).ToArray());
                        WriteResult(result);
                    }
                    else
                    {
                        _console.WriteLine(Resources.ErrorUnknownCommand, tokens[0]);
                    }
                }
                catch (ShellException ex)
                {
                    _console.WriteLine(Resources.Error, ex.Message);
                }
            }
        }

        private void WriteResult(object? result)
        {
            if (result == null) return;
            string fallback = result.ToString() ?? string.Empty;
            _console.WriteLine(fallback);

        }
    }
}
