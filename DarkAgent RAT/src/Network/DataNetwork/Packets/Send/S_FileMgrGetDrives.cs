﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DarkAgent_RAT.src.Network.DataNetwork.Packets.Send
{
    class S_FileMgrGetDrives : SendBasePacket
    {
        public S_FileMgrGetDrives(RatClients client)
            : base(client)
        {
        }
        protected internal override void Write()
        {
            WriteByte(0x12);
        }
    }
}
