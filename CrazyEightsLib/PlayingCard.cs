using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrazyEightsLib
{
    [Serializable]
    public class PlayingCard
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public int Points { get; set; }
        public bool IsFaceUp { get; set; }
        public Image FrontImage { get; set; }
        public Image BackImage { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }


        public PlayingCard(CardSuit suit, CardRank rank)
        {
            Rank = rank;
            Suit = suit;
            Points = 0;
            IsFaceUp = false;
            ID = GetDefaultID();
            Name = ToString();
            Abbrev = GetDefaultAbbrev();
        }

        public string GetDefaultAbbrev()
        {
            char sc = Suit.ToString()[0];
            if (Rank >= CardRank.Two && Rank <= CardRank.Nine)
            {
                int rn = (int)Rank + 2;
                return string.Format("{0}{1}", rn, sc);
            }
            else
            {
                char rc = Rank.ToString()[0];
                return string.Format("{0}{1}", rc, sc);
            }
        }

        private int GetDefaultID()
        {
            return (int)Suit * 13 + (int)Rank;
        }

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        public Image GetImage()
        {
            if (IsFaceUp)
            {
                return FrontImage;
            }
            else
            {
                return BackImage;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}", Rank, Suit);
        }
    }
}
