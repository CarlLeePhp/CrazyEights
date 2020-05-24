using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsServer
{
    public class Player
    {
        public string Name { get; set; }
        public bool IsMyTurn { get; set; }
        public TcpClient Connection { get; set; }
        public NetworkStream MyStream { get; set; }

        public Player(string name, bool isMyTurn, TcpClient connection)
        {
            Name = name;
            IsMyTurn = isMyTurn;
            Connection = connection;
            MyStream = Connection.GetStream();
        }
    }
}
