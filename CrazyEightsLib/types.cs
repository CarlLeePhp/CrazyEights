using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsLib
{
    public enum CardSuit { Clubs, Diamonds, Hearts, Spades }
    public enum CardRank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum ServerCommand { PileCard, HandCard, Message, TurnInfo, Win, Quit }
    // Quit: someone quited the game
    public enum ClientCommand { RequestCard , PileCard, Win, Done, Quit}
    // Quit: quit game
    public enum ConnectionResult {  Max, Running, Success }
    // Max: 5 players in the game; Running: Game is running; Sucess: joined
    public enum PlayerType { Owner, Joiner } // xx
    public enum PlayerStatus {Preparing, Ready, Win}
    public enum GameStatus { Waiting, Running }
    public enum GameType { Create, Join }
}
