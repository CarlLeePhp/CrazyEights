using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsLib
{
    [Serializable]
    public class PlayerInfo
    {
        public string PlayerName { get; set; }
        public PlayerInfo(string name)
        {
            PlayerName = name;
        }
    }
}
