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

        private Image back;
        private List<Image> faces = new List<Image>();
        private List<PlayingCard> handCards = new List<PlayingCard>();
        private List<PictureBox> handCardImages = new List<PictureBox>();
        private PictureBox starterPile;
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 51; i++)
            {
                faces.Add(imageCards.Images[i]);
            }
            back = imageCards.Images[54];

            starterPile = new PictureBox();
            starterPile.Width = CARD_WIDTH;
            starterPile.Height = CARD_HEIGHT;
            starterPile.Location = new Point(400, 100);
            
            this.Controls.Add(starterPile);

        } // Form Load

        private void AddToHand(PlayingCard card)
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
        } // Add to hand

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
            }
            else
            {
                cardBox.Location = new Point(cardBox.Location.X, 300);
            }
        } // card click
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 2048);
            NetworkStream stream = client.GetStream();
            IFormatter bfmt = new BinaryFormatter();

            // Send player's name
            string name = textBoxName.Text;
            bfmt.Serialize(stream, name);

            // Get initial cards
            object obj;
            for (int i=1; i<=5; i++)
            {
                obj = bfmt.Deserialize(stream);
                if(obj is PlayingCard)
                {
                    handCards.Add(obj as PlayingCard);
                }
            }
            foreach(PlayingCard card in handCards)
            {
                AddToHand(card);
            }

            // Get the first starter pile
            obj = bfmt.Deserialize(stream);
            if(obj is ServerMessage)
            {
                ServerMessageHandler(obj as ServerMessage);

            }
            client.Close();
        }  // Connect Button

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Deck deck = new Deck();
            // deck.Shuffle();
            for(int i=1; i<=5; i++)
            {
                AddToHand(deck.DealTopCard());
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if(textBoxName.Text == String.Empty)
            {
                buttonConnect.Enabled = false;
            }
            else
            {
                buttonConnect.Enabled = true;
            }
        }  // input something in the Player Name text box

        private void ServerMessageHandler(ServerMessage message)
        {
            if(message.Command == ServerCommand.PileCard)
            {
                PlayingCard card = message.TopPileCard;
                int cardIndex = (int)card.Suit * 13 + (int)card.Rank;
                card.FrontImage = faces[cardIndex];
                card.IsFaceUp = true;
                starterPile.Image = card.GetImage();
                starterPile.Tag = card;
                starterPile.Refresh();
                labelMessage.Text = message.Message;
            }
        }  // Server Command Handler
    }
}
