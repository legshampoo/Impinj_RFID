using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Impinj.OctaneSdk;

namespace _45PPC_RFID
{
    static class Display
    {
        delegate void UpdateReaderInfoCallback(string text);

        public static void UpdateReaderInfo(string s)
        {
            TextBox txt = Program.App.Controls["MainPanel"].Controls["ReaderInfo"] as TextBox;

            if (txt.InvokeRequired)
            {
                UpdateReaderInfoCallback callback = new UpdateReaderInfoCallback(UpdateReaderInfo);
                Program.App.Invoke(callback, new Object[] { s });
            }
            else
            {
                txt.Text = s;
            }
        }

        delegate void UpdateConnectButtonCallback(Reader reader);

        public static void UpdateConnectButton(Reader reader)
        {
            Button btn = Program.App.Controls["MainPanel"].Controls["ConnectButton"] as Button;

            if (btn.InvokeRequired)
            {
                UpdateConnectButtonCallback callback = new UpdateConnectButtonCallback(UpdateConnectButton);
                btn.Invoke(callback, new Object[] { reader });
            }
            else
            {
                if (reader.status.IsConnected)
                {
                    btn.Text = "Connected!";
                    btn.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    btn.Text = "Connect";
                    btn.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
        }

        delegate void UpdateTagConsoleCallback(string text);

        public static void UpdateTagConsole(string s)
        {
            TextBox txt = Program.App.Controls["MainPanel"].Controls["TagConsole"] as TextBox;

            if (txt.InvokeRequired)
            {
                UpdateTagConsoleCallback callback = new UpdateTagConsoleCallback(UpdateTagConsole);
                Program.App.Invoke(callback, new Object[] { s });
            }
            else
            {
                txt.Text = s;
            }
        }

        delegate void UpdateTag_A_ConsoleCallback(string text);

        public static void UpdateTag_A_Console(string s)
        {
            TextBox txt = Program.App.Controls["MainPanel"].Controls["Tag_A_Console"] as TextBox;

            if (txt.InvokeRequired)
            {
                UpdateTag_A_ConsoleCallback callback = new UpdateTag_A_ConsoleCallback(UpdateTag_A_Console);
                Program.App.Invoke(callback, new Object[] { s });
            }
            else
            {
                txt.Text = s;
            }
        }

        delegate void UpdateTagCallback(TagObject tagObject);

        public static void UpdateTag(TagObject tagObject)
        {
            Panel tagsFound = Program.App.Controls["MainPanel"].Controls["TagsFound"] as Panel;
            
            TextBox textBox = tagObject.textBox;

            if (tagsFound.InvokeRequired)
            {
                UpdateTagCallback callback = new UpdateTagCallback(UpdateTag);
                tagsFound.Invoke(callback, new Object[] { tagObject });
            }
            else
            {
                if (tagObject.active)
                {
                    tagsFound.Controls.Add(textBox);
                }
                else
                {
                    Control ctrl = tagsFound.Controls[textBox.Name];
                    tagsFound.Controls.Remove(ctrl);
                }
            }
        }


    }
}
