using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _45PPC_RFID
{
    public partial class Application : Form
    {
        Reader r = new Reader(SolutionConstants.ReaderHostname);
        public List<TagObject> tagObjects = new List<TagObject>();
        //public TCPClient tcpClient;
        public TCPClient tcpClient;

        public Application()
        {
            System.Diagnostics.Debug.WriteLine("Application Init");
            InitializeComponent();
            InitTagObjects();
            
            tcpClient = new TCPClient();
            tcpClient.Connect(SolutionConstants.server, SolutionConstants.tcpPort);
        }

        private void ConnectButton_Click_1(object sender, EventArgs e)
        {
            r.Connect();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitTagObjects()
        {
            System.Diagnostics.Debug.WriteLine("Building Tag Database...");

            for (int i = 0; i < SolutionConstants.TagList.Count; i++)
            {
                //tagObjects.Add(new TagObject() { Epc = SolutionConstants.TagList[i] } );
                TagObject newTag = new TagObject(SolutionConstants.TagList[i]);
                tagObjects.Add(newTag);
            }

            System.Diagnostics.Debug.WriteLine("Total Tag Objects: " + tagObjects.Count);

        }

        private void Tag_A_Console_TextChanged(object sender, EventArgs e)
        {

        }

        private void Application_Load(object sender, EventArgs e)
        {

        }
    }
}
