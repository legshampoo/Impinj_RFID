using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _45PPC_RFID
{
    public class TagObject
    {
        public string Epc { get; set; }
        public bool active = false;
        private bool hasChanged = false;
        private System.Timers.Timer timer = new System.Timers.Timer(SolutionConstants.TagTimeout);
        public TextBox textBox = new TextBox();
        public int TimesUsed;

        public TagObject(string _epc)
        {
            Epc = _epc;
            this.timer.AutoReset = false;
            this.timer.Elapsed += TimerElapsed;
            textBox = Formatting.FormatTagDisplay(this);
            TimesUsed = 0;
        }

        
        public void StartTimer()
        {   
            active = true;
            
            this.timer.Stop();
            this.timer.Start();
            
            if (active != hasChanged)
            {
                hasChanged = active;
                System.Diagnostics.Debug.WriteLine(Epc + ": ALIVE");
                TimesUsed++;
                textBox = Formatting.FormatTagDisplay(this);

                Display.UpdateTag(this);

                string message = "{\"tag\":" + Epc + ", \"status\":\"true\"}";
                Program.App.tcpClient.Send(message);
                //Program.App.tcpClient.Send(Epc + ": ALIVE");
            }
            else
            {
                //Do nothing
            }

        }

        private void TimerElapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            active = false;
            this.timer.Stop();

            if (active != hasChanged)
            {
                hasChanged = active;
                System.Diagnostics.Debug.WriteLine(Epc + " DEAD");
                Display.UpdateTag(this);

                string message = "{\"tag\": " + Epc.ToString() + ", \"status\": \"false\"}";
                Program.App.tcpClient.Send(message);
                //Program.App.tcpClient.Send(Epc + " DEAD");
            }
            else
            {
                //do nothing
            }
        }


        public bool Equals(string _epc)
        {
            return Epc == _epc;
        }

    }
}
