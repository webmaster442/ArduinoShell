//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

namespace ArduinoShell.Interfaces
{
    internal interface ICommand
    {
        IHost? Host { get; set; }
        public string Name { get; }
        public object? Execute(string[] arguments);
    }
}
