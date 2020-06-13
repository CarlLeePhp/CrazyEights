using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrazyEightsLib
{
    [Serializable]
    public class Deck
    {
        private List<PlayingCard> cards = new List<PlayingCard>();
        private List<PlayingCard> junkCards = new List<PlayingCard>();
        public static Random rnd = new Random();  // One random for all deck objects ??

        public Deck()
        {

            for (CardSuit suit = CardSuit.Clubs; suit <= CardSuit.Spades; suit++)
            {
                for (CardRank rank = CardRank.Two; rank <= CardRank.Ace; rank++)
                {
                    cards.Add(new PlayingCard(suit, rank));
                }
            }

        }

        public Deck(params CardRank[] ranks)
        {
            for (CardSuit suit = CardSuit.Clubs; suit <= CardSuit.Spades; suit++)
            {
                for (CardRank rank = CardRank.Two; rank <= CardRank.Ace; rank++)
                {
                    if (ranks.Contains(rank)) cards.Add(new PlayingCard(suit, rank));
                }
            }


        }

        public int Size
        {
            get
            {
                return cards.Count;
            }
        }

        public bool IsEmpty()
        {
            return cards.Count() == 0;
        }

        public PlayingCard DealTopCard()
        {
            if (IsEmpty()) return null;
            else
            {
                PlayingCard card = cards[0];
                junkCards.Add(card);
                cards.RemoveAt(0);
                return card;
            }

        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 1; i--)
            {
                // find a random number in the front of
                // the last card in deck
                int pos = rnd.Next(i);
                // make a reference to the last card in the deck
                PlayingCard tmpCard = cards[i];
                // Swap the two cards
                cards[i] = cards[pos];
                cards[pos] = tmpCard;
            }
        }

        // Get 52 pictures for cards
        // Assign the pictures by card's ID
        public void AssignImages(List<Image> faces, Image back)
        {
            if (faces.Count != 52) throw new Exception("Please send 52 pictures only.");
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].FrontImage = faces[cards[i].ID];
                cards[i].BackImage = back;
            }
            /*
            if(faces.Count == cards.Count)
            {
                for(int i=0; i<faces.Count; i++)
                {
                    cards[i].FrontImage = faces[i];
                    cards[i].BackImage = back;
                }
            }
            */
        }

        public void ResetDeck()
        {
            if (junkCards.Count == 0) return;
            for (int i = 0; i < junkCards.Count; i++)
            {
                cards.Add(junkCards[i]);
            }
            junkCards.Clear();
        }  // Reset Card List

        public void ResetDeck(List<PlayingCard> resetCards)
        {
            for(int i=0; i < resetCards.Count; i++)
            {
                cards.Add(resetCards[i]);
            }
        }  // Reset Deck by a card list
    }
}
