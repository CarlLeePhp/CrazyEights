using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsLib
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public PlayerStatus Status { get; set; }
        public TcpClient MyTcpClient { get; set; }
        public NetworkStream MyStream { get; set; }
        public Player(string name)
        {
            Name = name;
            Status = PlayerStatus.Preparing;
        }
    }
}
