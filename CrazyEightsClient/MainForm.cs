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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using CrazyEightsLib;

namespace CrazyEightsClient
{
    public partial class MainForm : Form
    {
        const int NUM_CARDS = 13;
        const int NUM_COLS = 5;
        const int CARD_WIDTH = 75;
        const int CARD_HEIGHT = 107;
        const int GAP_X = 20;
        const int GAP_Y = 20;

        public bool isMyTurn = false;
        public bool isSomeoneQuit = false;
        public bool isSomeoneWin = false;

        private Image back;
        private List<Image> faces = new List<Image>();
        private List<PlayingCard> handCards = new List<PlayingCard>();
        private List<PictureBox> handCardImages = new List<PictureBox>();
        private PictureBox starterPile;
        private PlayingCard selectedCard;
        private PlayingCard pileCard;
        ServerHandler server;
        string myName;
        CardSuit pileSuit;
        IFormatter bfmt;
        TcpClient client;
        NetworkStream stream;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            bfmt = new BinaryFormatter();
            // Pictures for cards
            for (int i = 0; i <= 51; i++)
            {
                faces.Add(imageCards.Images[i]);
            }
            back = imageCards.Images[54];

            // Server IP
            textBoxServer.Text = "127.0.0.1";


            // Starter Pile
            starterPile = new PictureBox();
            starterPile.Width = CARD_WIDTH;
            starterPile.Height = CARD_HEIGHT;
            starterPile.Location = new Point(400, 100);

            this.Controls.Add(starterPile);

            // Place and Deal buttons
            buttonDeal.Enabled = false;
            buttonPlace.Enabled = false;

            //  timer round
            timerRound.Start();

        } // Form Load
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == String.Empty)
            {
                buttonConnect.Enabled = false;
            }
            else
            {
                buttonConnect.Enabled = true;
            }
        }  // input something in the Player Name text box
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(textBoxServer.Text, 2048);
            stream = client.GetStream();
            server = new ServerHandler(client, this);

            // Recieve Connection result
            ConnectionResult result = server.GetConnectionRespond();
            
            if (result == ConnectionResult.Success)
            {
                buttonConnect.Enabled = false;
                textBoxName.Enabled = false;
                buttonQuit.Enabled = true;
                DisplayNote("Connected");
                // Send player
                Thread.Sleep(200);
                myName = textBoxName.Text;
                server.SendPlayerInfo(myName);
                // Run ServerHandler
                Thread serverHandlerThread = new Thread(new ThreadStart(server.Run));
                serverHandlerThread.Start();
            }
            else if (result == ConnectionResult.Running)
            {
                DisplayNote("Game is running, please try again later");
                client.Close();
            }
            else if (result == ConnectionResult.Max)
            {
                DisplayNote("Game is running, please try again later");
                client.Close();
            }
        }  // Connect Button

        delegate void AddToHandDel(PlayingCard card);
        public void AddToHand(PlayingCard card)
        {
            if (InvokeRequired)
            {
                AddToHandDel del = AddToHand;
                this.Invoke(del, card);
            }
            else
            {
                PictureBox cardBox = new PictureBox();
                cardBox.Width = CARD_WIDTH;
                cardBox.Height = CARD_HEIGHT;
                cardBox.Location = new Point(500 - handCardImages.Count * 20, 300);
                int cardIndex = (int)card.Suit * 13 + (int)card.Rank;
                card.FrontImage = faces[cardIndex];
                card.IsFaceUp = true;
                cardBox.Image = card.GetImage();
                cardBox.Tag = card;
                cardBox.Click += CardClick;
                handCardImages.Add(cardBox);
                this.Controls.Add(cardBox);
                DisplayNote(card.ToString());
            }
            
        } // Add to hand
        private void RemoveFromHand(PlayingCard card)
        {
            for(int i=0; i<handCardImages.Count; i++)
            {
                PictureBox cardBox = handCardImages[i];
                PlayingCard handCard = cardBox.Tag as PlayingCard;
                if(handCard.Suit == card.Suit && handCard.Rank == card.Rank)
                {
                    this.Controls.Remove(handCardImages[i]);
                    // this.Refresh();
                    handCardImages.RemoveAt(i);
                    for(int j=i; j<handCardImages.Count; j++)
                    {
                        handCardImages[j].Location = new Point(handCardImages[j].Location.X + 20, handCardImages[j].Location.Y);
                        handCardImages[j].Refresh();
                    }
                    break;
                }
            }
            
        } // Remove from hand
        delegate void AddToPileDel(PlayingCard card, CardSuit pileSuit);
        public void AddToPile(PlayingCard card, CardSuit pileSuit)
        {
            if (InvokeRequired)
            {
                AddToPileDel del = AddToPile;
                starterPile.Invoke(del, card, pileSuit);
            }
            else
            {
                int cardIndex = (int)card.Suit * 13 + (int)card.Rank;
                card.FrontImage = faces[cardIndex];
                card.IsFaceUp = true;
                starterPile.Image = card.GetImage();
                starterPile.Tag = card;
                pileCard = card;
                starterPile.Refresh();
                this.pileSuit = pileSuit;
                labelStarterPile.Text = pileSuit.ToString();
                DisplayNote("Get Pile Card: " + card.ToString());
            }
        } // Add to pile
        private void CardClick(object sender, EventArgs e)
        {
            PictureBox cardBox = sender as PictureBox;
            PlayingCard card = cardBox.Tag as PlayingCard;
            if(cardBox.Location.Y == 300)
            {
                foreach(PictureBox otherBox in handCardImages)
                {
                    otherBox.Location = new Point(otherBox.Location.X, 300);
                }
                cardBox.Location = new Point(cardBox.Location.X, 280);
                selectedCard = card;
            }
            
            if (isMyTurn && selectedCard.Rank == CardRank.Eight)
            {

                radioButtonClubs.Enabled = true;
                radioButtonDiamonds.Enabled = true;
                radioButtonHearts.Enabled = true;
                radioButtonSpades.Enabled = true;
                buttonPlace.Enabled = true;
            }
            else if (isMyTurn && selectedCard.Suit == pileSuit || selectedCard.Rank == pileCard.Rank)
            {
                buttonPlace.Enabled = true;
            }
            else
            {
                buttonPlace.Enabled = false;
            }
        } // card click
        
        delegate void DisplayNoteDel(string msg);
        public void DisplayNote(string msg)
        {
            if (InvokeRequired)
            {
                DisplayNoteDel del = DisplayNote;
                notes.Invoke(del, msg);
            }
            else
            {
                notes.AppendText(msg + "\n");
                notes.ScrollToCaret();
            }

        } // Display Note
        
        private void timerRound_Tick(object sender, EventArgs e)
        {
            // Deal and Place buttons is availabel when it is my turn
            if (isMyTurn)
            {
                buttonDeal.Enabled = true;
                buttonQuit.Enabled = true;
                timerRound.Stop();
            }
            if (isSomeoneQuit)
            {
                ResetGame();
            }
            if (isSomeoneWin)
            {
                ResetGame();
            }
        }  // timer round

        private void buttonPlace_Click(object sender, EventArgs e)
        {
            DisplayNote("Place " + selectedCard.ToString());
            DisplayNote(handCardImages.Count + " handcards");
            // send the card as pile card to server
            // remove the card from hand cards
            RemoveFromHand(selectedCard);
            ClientMessage pileCardInfo;
            if (handCardImages.Count == 0)
            {
                pileCardInfo = new ClientMessage(ClientCommand.Win);
            }
            else
            {
                pileCardInfo = new ClientMessage(ClientCommand.PileCard);
            }
            
            pileCardInfo.PileCard = selectedCard;
            pileCardInfo.PileSuit = selectedCard.Suit;
            if(selectedCard.Rank == CardRank.Eight)
            {
                pileCardInfo.PileSuit = ChangeSuit();
            }
            bfmt.Serialize(stream, pileCardInfo);

            // End my turn
            // Check it is my turn?
            isMyTurn = false;
            buttonDeal.Enabled = false;
            buttonQuit.Enabled = false;
            timerRound.Start();
            buttonDeal.Enabled = false;
            buttonPlace.Enabled = false;
            buttonQuit.Enabled = false;
            if (radioButtonClubs.Enabled)
            {
                radioButtonClubs.Enabled = false;
                radioButtonDiamonds.Enabled = false;
                radioButtonHearts.Enabled = false;
                radioButtonSpades.Enabled = false;
            }
        }  // place a selected card

        private CardSuit ChangeSuit()
        {
            if (radioButtonClubs.Checked)
            {
                return CardSuit.Clubs;
            }
            else if (radioButtonDiamonds.Checked)
            {
                return CardSuit.Diamonds;
            }
            else if (radioButtonHearts.Checked)
            {
                return CardSuit.Hearts;
            }
            else
            {
                return CardSuit.Spades;
            }
        }  // Change Suit depends on which was selected

        private void buttonDeal_Click(object sender, EventArgs e)
        {
            ClientMessage dealCardInfo = new ClientMessage(ClientCommand.RequestCard);
            bfmt.Serialize(stream, dealCardInfo);

            // wait a card back
            while (true)
            {
                if (stream.DataAvailable)
                {
                    Object obj = bfmt.Deserialize(stream);
                    ServerMessage handcardInfo = obj as ServerMessage;
                    AddToHand(handcardInfo.HandCard);
                    break;
                }
            }
        }  // need deal a card

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            server.QuitGame();
            
            client.Close();

            this.Close();

        } // Quit Button

        private void ResetGame()
        {
            isSomeoneQuit = false;
            isSomeoneWin = false;
            isMyTurn = false;

            buttonPlace.Enabled = false;
            buttonDeal.Enabled = false;
            buttonQuit.Enabled = true;
            radioButtonClubs.Enabled = false;
            radioButtonDiamonds.Enabled = false;
            radioButtonHearts.Enabled = false;
            radioButtonSpades.Enabled = false;
            starterPile.Image = back;

            foreach (PictureBox cardPicture in handCardImages)
            {
                this.Controls.Remove(cardPicture);
            }
            handCardImages.Clear();
        } // Quit Game
    }
}
