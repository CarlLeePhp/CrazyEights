using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsLib
{
    [Serializable]
    public class ServerMessage
    {
        public string Message { get; set; }
        public string NextPlayer { get; set; }
        public ServerCommand Command { get; set; }
        public PlayingCard TopPileCard { get; set; }
        public PlayingCard HandCard { get; set; }
        public ServerMessage(ServerCommand command)
        {
            Command = command;
        }
    }
}
