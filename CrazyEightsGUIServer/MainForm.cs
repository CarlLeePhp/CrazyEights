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

using CrazyEightsLib;
using System.Threading;

namespace CrazyEightsGUIServer
{
    public partial class MainForm : Form
    {
        TcpListener listener;
        Game game;
        bool done = false;
        public MainForm()
        {
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            game = new Game("Crazy Eights", this);
            game.MaxPlayers = 2;
            radioButtonMax2.Click += SetMaxPlayers;
            radioButtonMax3.Click += SetMaxPlayers;
            radioButtonMax4.Click += SetMaxPlayers;
            radioButtonMax2.Tag = 2;
            radioButtonMax3.Tag = 3;
            radioButtonMax4.Tag = 4;
        } // Form Load

        private void SetMaxPlayers(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            int maxPlayers = (int)radio.Tag;
            game.MaxPlayers = maxPlayers;
            DisplayNote("Set Max Players " + maxPlayers);
        } // Set Max Players

        delegate void DisplayNoteDel(string msg);
        public void DisplayNote(string msg)
        {
            if (InvokeRequired)
            {
                DisplayNoteDel del = DisplayNote;
                richTextBoxNotes.Invoke(del, msg);
            }
            else
            {
                richTextBoxNotes.AppendText(msg + "\n");
                richTextBoxNotes.ScrollToCaret();
            }
            
        } // Display Note

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread threadListener = new Thread(new ThreadStart(StartServer));
            threadListener.Start();
            buttonStart.Enabled = false;
        } // Start Button

        private void StartServer()
        {
            done = false;
            listener = new TcpListener(IPAddress.Any, 2048);
            listener.Start();

            Thread threadGameRun = new Thread(new ThreadStart(game.Run));
            threadGameRun.Start();
            while (!done)
            {
                DisplayNote("Waiting for next player...");
                TcpClient client = listener.AcceptTcpClient();
                ClientHandler clientHandler = new ClientHandler(client, game, this);
                Thread threadRun = new Thread(new ThreadStart(clientHandler.Run));
                threadRun.IsBackground = true;
                threadRun.Start();
            }
        }  // Start Server, wait for client connection


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } // Close Button

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        } // form closing
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopServer();
            
        } // stop button

        private void StopServer()
        {
            if (!done)
            {
                done = true;
                listener.Stop();
                // disconnect all players
                foreach(Player player in game.Players)
                {
                    player.MyStream.Close();
                    player.MyTcpClient.Close();
                }
                game.Players.Clear();
                Thread.Sleep(500);
                
            }
            buttonStart.Enabled = true;
        } // stop server

        
        
    }
}
