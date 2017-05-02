using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace _45PPC_RFID
{

    public class TCPClient
    {
        public TcpClient client;
        NetworkStream stream;
		IPAddress address;
		int port = 0;

		private System.Timers.Timer tcpTimer = new System.Timers.Timer(SolutionConstants.CheckTCPConnectionInterval);


		public TCPClient()
        {
			//gets the timer ready
			System.Diagnostics.Debug.WriteLine("INIT: TCP Server Reconnect Timer");
			this.tcpTimer.AutoReset = false;
			this.tcpTimer.Elapsed += TimerElapsed;
			client = new TcpClient();
		}

		public void Connect(IPAddress _address, int _port)
        {
			bool connected = false;
			address = _address;
			port = _port;


			System.Diagnostics.Debug.WriteLine("CONNECTING TO TCP SERVER...");

			try
            {
				//client = new TcpClient(address, port);
				client.Connect(address, port);
				//new
				//client.Connect(address, port);
				connected = client.Connected;

				Console.WriteLine("CONNECTED TO TCP SERVER: {0}", Convert.ToString(connected));
				
				stream = client.GetStream();

                //string message = "RFID Reader attempting to establish connection...";
                string message = "{\"message\": \"RFID Reader establishing connection\"}";
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                Send(message);
				//stream.Write(data, 0, data.Length);

				//System.Diagnostics.Debug.WriteLine("Sent: {0}", message);
			}
            catch (ArgumentNullException e)
            {
				System.Diagnostics.Debug.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
				System.Diagnostics.Debug.WriteLine("SocketException: {0}", e);
            }
		}

        public void Send(string message)
        {
            try
            {
				if (stream.CanWrite)
				{
					Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
					stream.Write(data, 0, data.Length);
					System.Diagnostics.Debug.WriteLine("TCP Send: " + message);
				}
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                System.Diagnostics.Debug.WriteLine("SocketException: {0}", e);
            }
            catch (System.NullReferenceException e)
            {
                System.Diagnostics.Debug.WriteLine("NullReferenceException: {0}", e);
            }
        }

		private void TimerElapsed(Object sender, System.Timers.ElapsedEventArgs e)
		{
			IPAddress ip = address;
			CheckTCPConnection(ip, port);
		}

		public void CheckTCPConnection(IPAddress _address, int _port)
		{
			address = _address;
			port = _port;
			tcpTimer.Enabled = true;
			tcpTimer.Stop();
			tcpTimer.Start();
			System.Diagnostics.Debug.WriteLine("CHECKING TCP SERVER CONNECTION...");
		
			try
			{
				if (stream.CanWrite)
				{
					string message = "ping";
					Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
					
					stream.Write(data, 0, data.Length);
					System.Diagnostics.Debug.WriteLine("TCP Send Test Message: " + message);
				}
			}
			catch(Exception err)
			{
				System.Diagnostics.Debug.WriteLine(err.Message);
			}

			bool recentlyConnected = client.Connected;
			if (recentlyConnected)
			{
				System.Diagnostics.Debug.WriteLine("TCP SERVER CONNECTED, WILL CHECK AGAIN IN: " + (SolutionConstants.CheckTCPConnectionInterval / 1000) + " seconds");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("TCP SERVER NOT CONNECTED, WILL RETRY IMMEDIATELY");
				Connect(address, port);
			}

		}

	}
}
