using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableFactory
{
    class Change
    {
        private uint CRC = 0XFFFF;
        private uint CRC_count;

        public uint check(uint[] fp_CRC, uint count)
        {
            for (CRC_count = 0; CRC_count < count; CRC_count++)
            {
                CRC = CRC ^ fp_CRC[CRC_count];
                for(int i = 0; i < 8; i++)
                {
                    if ((CRC & 1) != 0)
                    {
                        CRC >>= 1;
                        CRC ^= 0XA001;
                    }
                    else
                        CRC >>= 1;
                }
            }
            return CRC;
        }

    }
}
