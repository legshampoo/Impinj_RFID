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
        public const float RxSensitivity = -70f;
        public const float TxPower = 32.5f;
        public const float TagTimeout = 1.5f * 1000;
        //public static TimeSpan TagDebounceTimeout = new TimeSpan(0,0,2);
        public const int CheckReaderInterval = 10 * 1000;
        public const string server = "192.168.32.39";
        public const int tcpPort = 5550;

        public static List<string> TagList = new List<string> {
            "A020",
            "3008 33B2 DDD9 0140 0000 0000",
            "0000 AD00 0013 0628 0111 3000",
            "AD2B 0300 170A 1D7F 4C00 0054"
        };
    }
}
