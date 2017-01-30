using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Impinj.OctaneSdk;

namespace _45PPC_RFID
{
    public class Reader
    {
        ImpinjReader reader = new ImpinjReader();
        public Status status;
        FeatureSet features;
        Settings settings;
        private System.Timers.Timer timer = new System.Timers.Timer(SolutionConstants.CheckReaderInterval);

        string Address { get; set; }

        public Reader(string _address)
        {
            Address = _address;
            reader.TagsReported += EventHandlers.OnTagsReported;
            this.timer.AutoReset = false;
            this.timer.Elapsed += TimerElapsed;
        }

        public void Connect()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Connecting to reader... ");
                System.Diagnostics.Debug.WriteLine("Hostname: " + Address);

                reader.Connect(Address);
                status = reader.QueryStatus();
                
                if (status.IsConnected)
                {
                    System.Diagnostics.Debug.WriteLine("Reader Connected");
                    UpdateReaderSettings();
                    RefreshReaderDisplay();
                    reader.Start();
                    System.Diagnostics.Debug.WriteLine("Reader Ready...");
                    this.CheckConnection();  //starts the connection monitor
                }
            }
            catch (OctaneSdkException err)
            {
                System.Diagnostics.Debug.WriteLine("Octane SDK exception: " + err.Message);
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + err.Message);
            }
        }

        private void UpdateReaderSettings()
        {
            System.Diagnostics.Debug.WriteLine("Updating Reader Settings... ");
            reader.ApplyDefaultSettings();

            settings = reader.QuerySettings();
            settings.Antennas.GetAntenna(1).IsEnabled = true;
            settings.Antennas.GetAntenna(1).RxSensitivityInDbm = SolutionConstants.RxSensitivity;
            settings.Antennas.GetAntenna(1).TxPowerInDbm = SolutionConstants.TxPower;
            
            settings.Report.IncludeAntennaPortNumber = true;
            settings.Report.IncludePeakRssi = true;
            settings.Report.IncludeChannel = true;
            settings.Report.IncludeCrc = true;
            settings.Report.IncludeDopplerFrequency = true;
            settings.Report.IncludeFastId = true;
            settings.Report.IncludeFirstSeenTime = true;
            settings.Report.IncludeGpsCoordinates = true;
            settings.Report.IncludeLastSeenTime = true;
            settings.Report.IncludePhaseAngle = true;
            settings.Report.IncludeSeenCount = true;
            settings.Report.Mode = ReportMode.Individual;

            reader.ApplySettings(settings);
        }

        private void RefreshReaderDisplay()
        {
            System.Diagnostics.Debug.WriteLine("Refresh Reader Display... ");
            String info = "Not Connected";

            try
            {
                features = reader.QueryFeatureSet();
                status = reader.QueryStatus();
                settings = reader.QuerySettings();

                info = Formatting.FormatReaderInfo(reader, features, settings, status);
            }
            catch (OctaneSdkException err)
            {
                System.Diagnostics.Debug.WriteLine("DisplaySettings: Octane SDK exception: " + err.Message);
                info = "Octane Exception, Not Connected";
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("DisplaySettings: Exception: " + err.Message);
                info = "Exception, Not Connected";
            }
            finally
            {
                Display.UpdateReaderInfo(info);
                Display.UpdateConnectButton(this);
            }
        }
        private void CheckConnection()
        {
            timer.Enabled = true;
            timer.Stop();
            timer.Start();
            RefreshReaderDisplay();
        }

        private void TimerElapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckConnection();
        }
    }
}
