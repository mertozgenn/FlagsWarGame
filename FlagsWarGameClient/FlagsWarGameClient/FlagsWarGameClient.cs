using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace FlagsWarGameClient
{
    public partial class FlagsWarGameClient : Form
    {
        private Socket server;
        private readonly byte[] data = new byte[1024];
        private readonly List<int[]> flags = new List<int[]>();
        private readonly int size = 1024;
        private int mode = 0;
        private int recv;
        public FlagsWarGameClient()
        {
            InitializeComponent();
        }

        //Take IP address if valid and send Connect method.
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Connect(IPAddress.Parse(ipTb.Text));
                ipTb.Enabled = false;
                ipTb.BackColor = System.Drawing.SystemColors.Menu;
                connectBtn.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid IP Adress");
            }

        }

        //Begin the connection process.
        private void Connect(IPAddress ip)
        {
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                  SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(ip, 9050);
            status.Text = "Connecting...";
            newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
        }

        //When connected, start receiving data from the server.
        private void Connected(IAsyncResult ar)
        {
            server = (Socket)ar.AsyncState;
            try
            {
                server.EndConnect(ar);
                server.BeginReceive(data, 0, size, SocketFlags.None,
                              new AsyncCallback(ReceiveDataFromServer), server);
            }
            catch (SocketException)
            {
                Invoke(new Action(() => { status.Text = "Error connecting"; }));
                MessageBox.Show("Cannot connect to the server");
                EndGame();
            }
        }

        // Make a decision when a data from the server comes.
        private void ReceiveDataFromServer(IAsyncResult ar)
        {
            server = (Socket)ar.AsyncState;
            recv = server.EndReceive(ar);

            List<string> stringData = Encoding.ASCII.GetString(data, 0, recv).Split(',').ToList();
            Invoke(new Action(() => { status.Text = stringData[0]; }));
            if (stringData.Count == 3)
            {
                Invoke(new Action(() => { myFlagCountTB.Text = stringData[1]; }));
                Invoke(new Action(() => { oppFlagCountTB.Text = stringData[2]; }));
                if (stringData[1] == "0") // If our flags run out.
                {
                    MessageBox.Show("You Lost");
                    EndGame();
                    return;
                }

                if (stringData[2] == "0") // If we find all the flags of the opponent
                {
                    MessageBox.Show("You Won");
                    EndGame();
                    return;
                }
            }
            if (stringData[0].Contains("plant your flags")) // If server asks the players to plant their flags.
            {
                mode = 1;
                Invoke(new Action(() => { status.BackColor = System.Drawing.Color.LightGreen; }));
            }
            if (stringData[0].Contains("Wait") || stringData[0].Contains("finished")
                || stringData[0].Contains("turn")) // If we have to wait for the opponent, or the game finished.
            {
                Invoke(new Action(() => { status.BackColor = System.Drawing.SystemColors.Menu; }));
                mode = 2;
            }
            if (stringData[0].Contains("Select")) // It is our turn to make a move
            {
                Invoke(new Action(() => { status.BackColor = System.Drawing.Color.LightGreen; }));
                mode = 3;
            }
            if (stringData[0].Contains("Bomb"))
            {
                Invoke(new Action(() => { status.BackColor = System.Drawing.SystemColors.Menu; }));
                if (mode == 2) // A bomb has exploded while we are waiting.
                {
                    MessageBox.Show("A bomb has exploded. You Won.");
                    EndGame();
                    return;
                }

                if (mode == 3) // A bomb has exploded while we are making our move.
                {
                    MessageBox.Show("You have exploded a bomb. You Lost.");
                    EndGame();
                    return;
                }
            }
            server.BeginReceive(data, 0, size, SocketFlags.None,
                                  new AsyncCallback(ReceiveDataFromServer), server);
        }

        //When player clicked a location on the map,Begin sending the coordinates to the server
        //if it is our turn to make a move.
        private void mapPictureBox_Click(object sender, EventArgs e)
        {
            if (mode == 2) return; // It is not our turn.
            MouseEventArgs e2 = (MouseEventArgs)e;
            byte[] message = Encoding.ASCII.GetBytes(string.Format("{0},{1}", e2.X, e2.Y));
            if (mode == 1) // Planting 5 flags
            {
                flags.Add(new int[] { e2.X, e2.Y });
                string oldText = status.Text;
                string newText = oldText.Substring(0, 23) + ": " + (5 - flags.Count) + " remaining";
                Invoke(new Action(() => { status.Text = newText; }));
            }
            if (mode == 1 || mode == 3) // It is our turn, or we are planting flags.
            {
                server.BeginSend(message, 0, message.Length, SocketFlags.None,
                                         new AsyncCallback(SendDataToServer), server);
            }

        }

        //Change coordinates as the mouse moves on the map.
        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            xTb.Text = e.X.ToString();
            yTb.Text = e.Y.ToString();
        }

        //Complete the sending process
        private void SendDataToServer(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            server.EndSend(ar);
        }

        //Prepare the client for a new game.
        private void EndGame()
        {
            Invoke(new Action(() => {
                status.Text = "Flags War Game";
                ipTb.Enabled = true;
                ipTb.BackColor = System.Drawing.SystemColors.Window;
                connectBtn.Enabled = true;
                myFlagCountTB.Text = "";
                oppFlagCountTB.Text = "";
                status.BackColor = System.Drawing.SystemColors.Menu;
            }));
            flags.Clear();
            mode = 0;
        }
    }
}

