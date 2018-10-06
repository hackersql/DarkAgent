﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DarkAgent_Client.src.Network.DataNetwork.Packets
{
    public abstract class SendBasePacket
    {
        private MemoryStream vStream;

        private ClientConnect vClient;
        public SendBasePacket(ClientConnect client)
        {
            vStream = new MemoryStream();
            vClient = client;
        }

        protected void WriteBytes(byte[] value)
        {
            vStream.Write(value, 0, value.Length);
        }

        protected void WriteBytes(byte[] value, int Offset, int Length)
        {
            vStream.Write(value, Offset, Length);
        }

        protected void WriteInteger(int value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteShort(short value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteByte(byte value)
        {
            vStream.WriteByte(value);
        }

        protected void WriteDouble(double value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteString(string value)
        {
            if (!(value == null))
            {
                WriteBytes(System.Text.Encoding.Unicode.GetBytes(value));
            }
            vStream.WriteByte(0);
            vStream.WriteByte(0);
        }

        protected void WriteLong(long value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        public byte[] ToByteArray()
        {
            return vStream.ToArray();
        }

        public long Length
        {
            get { return vStream.Length; }
        }

        public ClientConnect Client
        {
            get { return vClient; }
        }

        protected internal abstract void Write();
    }
}
