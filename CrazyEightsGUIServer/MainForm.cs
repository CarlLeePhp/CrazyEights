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
            
        }



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
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread threadListener = new Thread(new ThreadStart(StartServer));
            threadListener.Start();
            buttonStart.Enabled = false;
        } // Start Button

        private void buttonClose_Click(object sender, EventArgs e)
        {
            done = true;
            if(listener != null)
            {
                listener.Stop();
            }
            buttonStart.Enabled = true;
        } // Close Button

        private void StartServer()
        {
            done = false;
            listener = new TcpListener(IPAddress.Any, 2048);
            listener.Start();
            game = new Game("Crazy Eights", this);
            Thread threadGameRun = new Thread(new ThreadStart(game.Run));
            threadGameRun.Start();
            while(!done)
            {
                DisplayNote("Waiting for next player...");
                TcpClient client = listener.AcceptTcpClient();
                ClientHandler clientHandler = new ClientHandler(client, game, this);
                Thread threadRun = new Thread(new ThreadStart(clientHandler.Run));
                threadRun.Start();
            }

        }  // Start Server, wait for client connection

    }
}
