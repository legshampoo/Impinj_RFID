using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45PPC_RFID
{
    class SolutionConstants
    {
        public const string ReaderHostname = "speedwayr-11-2C-3F.local";
        public const float RxSensitivity = -80f;
        public const float TxPower = 30.0f;
        public const float TagTimeout = 1.5f * 1000;
        public const int CheckReaderInterval = 10 * 1000;
        public const string server = "192.168.32.39";
        public const int tcpPort = 5550;

        public static List<string> TagList = new List<string> {
            "A020",
            "0001",
            "0002",
            "1234",
            "3008 33B2 DDD9 0140 0000 0000",
            "0000 AD00 0013 0628 0111 3000",
            "AD2B 0300 170A 1D7F 4C00 0054",
            "1000",
            "AP20",
            "AM00",
            "N000",
            "P100",
            "P200",
            "T000"
        };
    }
}
