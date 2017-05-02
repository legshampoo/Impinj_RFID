using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45PPC_RFID
{
    class SolutionConstants
    {
		//public const string ReaderHostname = "speedwayr-11-2C-3F.local";
		public const string ReaderHostname = "192.168.45.80";
        public const float RxSensitivity = -55f;
        public const float TxPower = 30.0f;
        public const float TagTimeout = 1.5f * 1000;
        public const int CheckReaderInterval = 15 * 1000;
		//public const string server = "192.168.0.22"; //"192.168.32.39";
		public const string server = "192.168.45.122";  //mac mini on Site
        public const int tcpPort = 5550;
		public const float CheckTCPConnectionInterval = 1000 * 30;

        public static List<string> TagList = new List<string> {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000"
        };
    }
}
