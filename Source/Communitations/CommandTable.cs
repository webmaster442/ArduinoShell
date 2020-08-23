//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

namespace ArduinoShell.Communitations
{
    internal enum CommandTable: byte
    {
        DigitalWrite = 0x10,
        DigitalRead = 0x11,
        AnalogRead = 0x12,
        AnalogWrite = 0x13,
        GetVersion = 0xfe,
    }
}
