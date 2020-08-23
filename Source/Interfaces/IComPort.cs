//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using System;

namespace ArduinoShell.Interfaces
{
    internal interface IComPort: IDisposable
    {
        string Adress { get;}
        void Open();
        byte WriteBytes(IBytes bytes);
        byte[] ReadBytes();
    }
}
