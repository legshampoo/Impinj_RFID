using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;
using System.Windows.Forms;

namespace _45PPC_RFID
{
    class Formatting
    {
        //static string rawTagDisplay = null;

        public static string FormatReaderInfo(ImpinjReader reader, FeatureSet features, Settings settings, Status status)
        {
            string modelName = features.ModelName;
            string readerIP = reader.Address;
            string connectedStatus = status.IsConnected.ToString();
            string modelNumber = features.ModelNumber.ToString();
            string firmwareVersion = features.FirmwareVersion;
            string antennaCount = features.AntennaCount.ToString();
            string isSingulating = status.IsSingulating.ToString();
            float tempCelsius = status.TemperatureInCelsius;
            
            string enabledAntennaOne = settings.Antennas.GetAntenna(1).IsEnabled.ToString();
            string rxSensitivity = settings.Antennas.GetAntenna(1).RxSensitivityInDbm.ToString();
            string txPower = settings.Antennas.GetAntenna(1).TxPowerInDbm.ToString();
            string currentTime = DateTime.Now.ToString("h:mm:ss tt");

            string info =
                "CONNECTED TO READER: " + Environment.NewLine + Environment.NewLine +
                "Model Name: " + modelName + Environment.NewLine +
                "Address: " + readerIP + Environment.NewLine +
                "Model Number: " + modelNumber + Environment.NewLine +
                "Firmware Version: " + firmwareVersion + Environment.NewLine +
                "Antenna Ports: " + antennaCount + Environment.NewLine +
                "Is Singulating: " + isSingulating + Environment.NewLine +
                "Temp. Celsius: " + tempCelsius + Environment.NewLine +
                "Antenna (1) Enabled: " + enabledAntennaOne + Environment.NewLine +
                "Rx Sensitivity: " + rxSensitivity + Environment.NewLine +
                "txPower: " + txPower + Environment.NewLine +
                "Time: " + currentTime;

            return info;
        }


        public static string FormatRawTagData(Tag tag)
        {
            String epc = tag.Epc.ToString();
            String frequency = tag.ChannelInMhz.ToString();
            String firstSeen = tag.FirstSeenTime.ToString();
            String lastSeen = tag.LastSeenTime.ToString();
            String seenCount = tag.TagSeenCount.ToString();
            String id = tag.Tid.ToString();
            String crc = tag.Crc.ToString();
            String gps = tag.GpsCoodinates.ToString();
            String peakRSSI = tag.PeakRssiInDbm.ToString();

            String tagInfo =
            "-------------------------------------" + Environment.NewLine + 
            "TAG DETECTED: " + Environment.NewLine + Environment.NewLine +
            "EPC: " + Environment.NewLine +
            epc + Environment.NewLine + Environment.NewLine +
            "Frequency: " + frequency + Environment.NewLine +
            "First Seen: " + firstSeen + Environment.NewLine +
            "Last Seen: " + lastSeen + Environment.NewLine +
            "Seen Count: " + seenCount + Environment.NewLine +
            "ID: " + id + Environment.NewLine +
            "CRC: " + crc + Environment.NewLine +
            "GPS: " + gps + Environment.NewLine +
            "Peak RSSI: " + peakRSSI + Environment.NewLine;
            
            return tagInfo;
        }


        delegate TextBox FormatTagDisplayCallback(TagObject tagObject);

        public static TextBox FormatTagDisplay(TagObject tagObject)
        {
            if (tagObject.textBox.InvokeRequired)
            {
                FormatTagDisplayCallback callback = new FormatTagDisplayCallback(FormatTagDisplay);
                tagObject.textBox.Invoke(callback, new object[] { tagObject });
            }
            else
            {
                tagObject.textBox.Text =
                     tagObject.Epc + Environment.NewLine +
                     "Times Used: " + tagObject.TimesUsed;

                tagObject.textBox.Name = "TAG: " + tagObject.Epc;
                tagObject.textBox.Text =
                    tagObject.Epc + Environment.NewLine +
                    "Times Used: " + tagObject.TimesUsed;

                tagObject.textBox.BackColor = System.Drawing.Color.GreenYellow;
                tagObject.textBox.Font = new System.Drawing.Font("Helvetica", 10);
                tagObject.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                tagObject.textBox.Size = new System.Drawing.Size(500, 40);
                tagObject.textBox.Multiline = true;
                tagObject.textBox.Margin = new System.Windows.Forms.Padding(2);
            }

            return tagObject.textBox;
        }

        //public static TextBox FormatTagDisplay(TagObject tagObject)
        //{

        //    tagObject.textBox.Name = "TAG: " + tagObject.Epc;
        //    tagObject.textBox.Text = 
        //        tagObject.Epc + Environment.NewLine +
        //        "Times Used: " + tagObject.TimesUsed;

        //    tagObject.textBox.BackColor = System.Drawing.Color.GreenYellow;
        //    tagObject.textBox.Font = new System.Drawing.Font("Arial", 10);
        //    tagObject.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //    tagObject.textBox.Size = new System.Drawing.Size(500, 75);
        //    tagObject.textBox.Multiline = true;
        //    tagObject.textBox.Margin = new System.Windows.Forms.Padding(5);



        //    return tagObject.textBox;
        //}
    }
}
