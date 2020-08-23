//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Interfaces;
using System.IO.Ports;
using System.Linq;

namespace ArduinoShell.Communitations
{
    internal sealed class ComPort : IComPort
    {
        private SerialPort? _port;

        public ComPort(string adress)
        {
            _port = new SerialPort
            {
                BaudRate = 19200,
                PortName = adress,
                ReadTimeout = 2000,
                WriteTimeout = 2000,
                StopBits = StopBits.One,
                Parity = Parity.None,
                DataBits = 8,
                DtrEnable = true,
            };
            Adress = adress;
            _port.Open();
        }

        public string Adress { get; }

        public void Dispose()
        {
            if (_port != null)
            {
                _port.Dispose();
                _port = null;
            }
        }

        public void Open()
        {
            _port?.Open();
        }

        public byte[] ReadBytes()
        {
            int count = _port?.ReadByte() ?? 0;
            byte[] buffer = new byte[255];
            _port?.Read(buffer, 0, count);
            return buffer.Take(count).ToArray();
        }

        public byte WriteBytes(IBytes bytes)
        {
            var buffer = bytes.ToArray();
            _port?.Write(buffer, 0, buffer.Length);
            return (byte)(_port?.ReadByte() ?? 0);
        }
    }
}
