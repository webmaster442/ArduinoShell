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
    internal class AnalogReadCommand : ICommand
    {
        public string Name => "analogRead";

        public IHost? Host { get; set; }

        public object Execute(string[] arguments)
        {
            if (Host == null)
                throw new InvalidOperationException("Host shoudln't be null");

            if (arguments[0].TryParseByte(out byte port))
            {
                BytePackage package = new BytePackage(CommandTable.AnalogRead);
                package.AddBytes(port);
                byte recieved = Host?.ComPort.WriteBytes(package) ?? 0;
                if (recieved != package.Size)
                    throw new ShellException(Resources.ErrorCommunication);

                var response = Host!.ComPort.ReadBytes();

                if (response.Length != 4)
                    throw new ShellException(Resources.ErrorCommunication);

                return BitConverter.ToInt32(response);

            }
            throw new ShellException(Resources.ErrorParameterParse);
        }
    }
}
