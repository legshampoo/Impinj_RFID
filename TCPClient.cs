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

        public TCPClient()
        {
            
        }

        public void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient(address, port);


                stream = client.GetStream();

                string message = "RFID Reader attempting to establish connection...";
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
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                System.Diagnostics.Debug.WriteLine("TCP: " + message);
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
    }
}
