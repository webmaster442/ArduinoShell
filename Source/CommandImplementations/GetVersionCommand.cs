using ArduinoShell.Communitations;
using ArduinoShell.Interfaces;
using ArduinoShell.Properties;
using ArduinoShell.Utils;
using System;

namespace ArduinoShell.CommandImplementations
{
    internal class GetVersionCommand : ICommand
    {
        public IHost? Host { get; set; }

        public string Name => "getVersion";

        public object Execute(string[] arguments)
        {
            if (Host == null)
                throw new InvalidOperationException("Host shoudln't be null");

            BytePackage package = new BytePackage(CommandTable.GetVersion);
            byte recieved = Host.ComPort.WriteBytes(package);
            if (recieved != package.Size)
                throw new ShellException(Resources.ErrorCommunication);

            var response = Host.ComPort.ReadBytes();

            if (response.Length != 3)
                throw new ShellException(Resources.ErrorCommunication);

            return new Version(response[0], response[1], response[2]);
        }
    }
}
