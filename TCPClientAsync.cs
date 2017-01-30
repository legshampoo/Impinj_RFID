using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _45PPC_RFID
{
    public class StateObject
    {
        //Client socket
        public Socket workSocket = null;
        //Size of receive buffer
        public const int BufferSize = 256;
        //Receive buffer
        public byte[] buffer = new byte[BufferSize];
        //Received data string
        public StringBuilder sb = new StringBuilder();
    }

    public class TCPClientAsync
    {
        Socket client;

        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static String response = String.Empty;

        public TCPClientAsync(String address, int port)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Connecting to TCP server...");

                IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);

                //connectDone.WaitOne();
                //Send(client, "This is a test<EOF>");
                Send("Test");
                //sendDone.WaitOne();

                Receive(client);
                //receiveDone.WaitOne();
                System.Diagnostics.Debug.WriteLine("Response received: " + response);

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine("SocketException: " + e);
            }
            catch (SocketException e)
            {
                System.Diagnostics.Debug.WriteLine("SocketException: " + e);
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                //Retrieve the socket from the state object
                Socket _client = (Socket)ar.AsyncState;

                //Complete the connection
                _client.EndConnect(ar);

                System.Diagnostics.Debug.WriteLine("Socket Connected to: " + _client.RemoteEndPoint.ToString());

                //Signal the connection has been made
                connectDone.Set();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                //Create the state object
                StateObject state = new StateObject();
                state.workSocket = client;

                //Begin receiving the data from the remote device
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                //Retrieve the state object and the client socket
                //from the asynchronous state object
                StateObject state = (StateObject)ar.AsyncState;
                Socket _client = state.workSocket;

                //Read datea from the remote device
                int bytesRead = _client.EndReceive(ar);

                if(bytesRead > 0)
                {
                    //There might be more data, so store the date received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    //Get the rest of the data
                    _client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                }
                else
                {
                    //All the data has arrived, put it in a response
                    if(state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    //Signal that all bytes have been received
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        //public static void Send(Socket _client, String _data)
        public void Send(String _data)
        {
            //Conver the string data to byte data using ASCII encoding
            byte[] byteData = Encoding.ASCII.GetBytes(_data);

            //Begin sending the data to the remote device
            this.client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                //Retriev the socket from the stat object
                Socket client = (Socket)ar.AsyncState;

                //Complete sending the data to the remote device
                int bytesSent = client.EndSend(ar);
                System.Diagnostics.Debug.WriteLine("Sent {0} bytes to server.", bytesSent);

                //Signal that all bytes have been sent
                sendDone.Set();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
    }
}
