using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsLib
{
    [Serializable]
    public class ClientMessage
    {
        public ClientCommand Command { get; set; }
        public PlayingCard PileCard { get; set; }
        public CardSuit PileSuit { get; set; }

        public ClientMessage(ClientCommand command)
        {
            Command = command;
        }
    }
}
