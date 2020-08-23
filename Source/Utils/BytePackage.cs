//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using ArduinoShell.Communitations;
using ArduinoShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoShell.Utils
{
    internal class BytePackage : IBytes
    {
        private readonly List<byte> _bytes;

        public byte Size => (byte)_bytes.Count;

        public BytePackage(CommandTable command)
        {
            _bytes = new List<byte>();
            _bytes.Add((byte)command);
        }

        private void AddShort(short value)
        {
            if (_bytes.Count + 2 > 255)
                throw new InvalidOperationException("Too may bytes to send");
            _bytes.AddRange(BitConverter.GetBytes(value));
        }

        public void AddShorts(params short[] values)
        {
            foreach (var value in values)
            {
                AddShort(value);
            }
        }

        public void AddBytes(params byte[] bytes)
        {
            _bytes.AddRange(bytes);
        }

        public byte[] ToArray()
        {
            return _bytes.ToArray();
        }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(ToArray());
        }
    }
}
