using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace _45PPC_RFID
{
    public partial class Application : Form
    {
        public Reader r = new Reader(SolutionConstants.ReaderHostname);
        public List<TagObject> tagObjects = new List<TagObject>();
        public TCPClient tcpClient;
        public TagWriter tagWriter = new TagWriter();

		private System.Timers.Timer tcpTimer = new System.Timers.Timer(SolutionConstants.CheckTCPConnectionInterval);

		private BackgroundWorker worker_ConnectTCP;
		private BackgroundWorker worker_ConnectRFID;

		public Application()
        {
            System.Diagnostics.Debug.WriteLine("Application Init");
            InitializeComponent();
            InitTagObjects();
			
			worker_ConnectTCP = new BackgroundWorker();
			worker_ConnectRFID = new BackgroundWorker();
			
			worker_ConnectTCP.DoWork += Worker_ConnectTCP_DoWork;
			worker_ConnectTCP.RunWorkerCompleted += Worker_ConnectTCP_RunWorkerCompleted;
			worker_ConnectTCP.RunWorkerAsync();
		
			worker_ConnectRFID.DoWork += Worker_ConnectRFID_DoWork;
			worker_ConnectRFID.RunWorkerCompleted += Worker_ConnectRFID_RunWorkerCompleted;
			worker_ConnectRFID.RunWorkerAsync();
		}

		void Worker_ConnectTCP_DoWork(object sender, DoWorkEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Background Worker: TCP CONNECT Init");
			tcpClient = new TCPClient();
			tcpClient.Connect(IPAddress.Parse(SolutionConstants.server), SolutionConstants.tcpPort);
			tcpClient.CheckTCPConnection(IPAddress.Parse(SolutionConstants.server), SolutionConstants.tcpPort);
		}

		void Worker_ConnectTCP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Background Worker: TCP CONNECT Complete");
		}

		void Worker_ConnectRFID_DoWork(object sender, DoWorkEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Background Worker: RFID CONNECT Init");

			r.Connect();
			r.CheckConnection();
		}

		void Worker_ConnectRFID_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Background Worker: RFID CONNECT Complete");
		}

		void Application_Loaded(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("MAIN WINDOW LOADED");
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
			System.Diagnostics.Debug.WriteLine("Application LOAD");
			
		}

		private void Application_Shown(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Application SHOWN");
		}

		private void ConnectButton_Shown(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("ConnectButton SHOWN");
		}

		private void TagWriterButton_Click(object sender, EventArgs e)
        {
            //opens up the tag writer window
            tagWriter = new TagWriter();
            tagWriter.Show();
           
        }
	}
}
