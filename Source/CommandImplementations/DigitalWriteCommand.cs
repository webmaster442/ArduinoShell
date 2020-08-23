//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Communitations;
using ArduinoShell.Interfaces;
using ArduinoShell.Properties;
using ArduinoShell.Utils;
using System;

namespace ArduinoShell.CommandImplementations
{
    internal class DigitalWriteCommand : ICommand
    {
        public string Name => "digitalWrite";

        public IHost? Host { get; set; }

        public object? Execute(string[] arguments)
        {
            if (Host == null)
                throw new InvalidOperationException("Host shoudln't be null");

            if (arguments[0].TryParseByte(out byte port)
                && arguments[1].TryParseByte(out byte value))
            {
                BytePackage package = new BytePackage(CommandTable.DigitalWrite);
                package.AddBytes(port, value);
                byte recieved = Host.ComPort.WriteBytes(package);
                if (recieved != package.Size)
                    throw new ShellException(Resources.ErrorCommunication);

                return null;
            }
            throw new ShellException(Resources.ErrorParameterParse);
        }
    }
}
