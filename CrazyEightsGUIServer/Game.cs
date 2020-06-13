using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyEightsLib;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace CrazyEightsGUIServer
{
    class Game
    {
        public string Name { get; set; }
        public GameStatus Status { get; set; }
        public GameType MyType { get; set; }
        public List<Player> Players { get; set; }

        private MainForm _app;
        Deck _deck;
        List<PlayingCard> _pileCards = new List<PlayingCard>();
        int _currentPlayerIdex;
        bool done;
        IFormatter bfmt;
        public Game(string name, MainForm app)
        {
            Name = name;
            _app = app;
            Status = GameStatus.Waiting;
            MyType = GameType.Create;  // xx
            Players = new List<Player>();
            bfmt = new BinaryFormatter();
        }

        // 1. Check Player Number and Status(All ready?)
        // 2. Start the game
        // 3. Any one win?
        // 4. Reset the game
        public void Run()
        {
            done = false;
            while (!done)
            {
                InitialGame();
                Console.WriteLine("Game is running");
                bool allReady = false;
                while (!allReady)
                {
                    
                    allReady = true;

                    for(int i=0; i<Players.Count; i++)
                    {
                        if (Players[i].MyStream.DataAvailable)
                        {
                            Object obj = bfmt.Deserialize(Players[i].MyStream);
                            if (obj is PlayerStatus)
                            {
                                Players[i].Status = (PlayerStatus)obj;
                            }
                            _app.DisplayNote(Players[i].Name + " is " + Players[i].Status.ToString());
                            _app.DisplayNote("There are " + Players.Count + " players");
                        }

                        if (Players[i].Status == PlayerStatus.Preparing)
                        {
                            
                            allReady = false;
                        }
                    }

                    if (Players.Count < 2)
                    {
                        allReady = false;
                    }
                }

                Status = GameStatus.Running;

                GameStart();
                _currentPlayerIdex = 0;
                bool gameEnd = false;
                while (!gameEnd)
                {
                    gameEnd = NextTurn();
                }

                Status = GameStatus.Waiting;
                foreach(Player player in Players)
                {
                    player.Status = PlayerStatus.Preparing;
                }
            }
        } // Run

        private void InitialGame()
        {
            // prepare the deck
            _deck = new Deck();
            _deck.Shuffle();
        } // Initial Game

        private void GameStart()
        {
            _app.DisplayNote("Game Started");
            // Send start to client
            for (int i = 1; i <= 5; i++)
            {
                foreach (Player player in Players)
                {
                    bfmt.Serialize(player.MyStream, GameStatus.Running);
                }
            }
            // 5 hand cards each player
            // Send 5 cards to each player
            for (int i = 1; i <= 5; i++)
            {
                foreach (Player player in Players)
                {
                    PlayingCard handCard = _deck.DealTopCard();
                    bfmt.Serialize(player.MyStream, handCard);
                    _app.DisplayNote(handCard.ToString());
                }
                Thread.Sleep(200);
            }

            // Send a message with a starter card
            // and identifying who is the next
            PlayingCard card = _deck.DealTopCard();
            while (card.Rank == CardRank.Eight)
            {
                // To Do the Eight must insert into deck
                card = _deck.DealTopCard();
            }

            //ServerMessage topPileCardMessage = new ServerMessage(ServerCommand.PileCard);
            //topPileCardMessage.TopPileCard = card;
            //topPileCardMessage.NextPlayer = Players[0].Name;
            //topPileCardMessage.Message = topPileCardMessage.NextPlayer + " Turn";

            foreach (Player player in Players)
            {
                bfmt.Serialize(player.MyStream, card);
            }
            Thread.Sleep(200);
            _app.DisplayNote("Game Prepared");

        }  // Game Start
        private bool NextTurn()
        {

            bool gameEnd = false;
            // Whose turn
            ServerMessage turnInfo = new ServerMessage(ServerCommand.TurnInfo);
            turnInfo.NextPlayer = Players[_currentPlayerIdex].Name;
            foreach (Player player in Players)
            {
                bfmt.Serialize(player.MyStream, turnInfo);
            }

            // must wait for player's reply
            while (true)
            {
                if (Players[_currentPlayerIdex].MyStream.DataAvailable)
                {
                    Object obj = bfmt.Deserialize(Players[_currentPlayerIdex].MyStream);
                    // It must be a client message
                    ClientMessage clientMessage = obj as ClientMessage;
                    // It should be sent as a pile card for all players
                    if (clientMessage.Command == ClientCommand.PileCard)
                    {
                        _app.DisplayNote("Got pile card " + clientMessage.PileCard.ToString());
                        _pileCards.Add(clientMessage.PileCard);
                        _app.DisplayNote("Pile Card: " + _pileCards.Count);
                        ServerMessage pileCardInfo = new ServerMessage(ServerCommand.PileCard);
                        pileCardInfo.TopPileCard = clientMessage.PileCard;
                        pileCardInfo.PileSuit = clientMessage.PileSuit;
                        foreach (Player player in Players)
                        {
                            bfmt.Serialize(player.MyStream, pileCardInfo);
                        }
                        _currentPlayerIdex++;
                        if(_currentPlayerIdex == Players.Count) _currentPlayerIdex = 0;
                        break;
                    }

                    // A player want a card
                    if (clientMessage.Command == ClientCommand.RequestCard)
                    {
                        ServerMessage handCardInfo = new ServerMessage(ServerCommand.HandCard);
                        // if there is no card
                        // reset deck by pilecards
                        if(_deck.Size == 0)
                        {
                            _deck.ResetDeck(_pileCards);
                            _deck.Shuffle();
                            _pileCards.Clear();
                        }
                        
                        handCardInfo.HandCard = _deck.DealTopCard();
                        _app.DisplayNote(handCardInfo.HandCard.ToString());
                        bfmt.Serialize(Players[_currentPlayerIdex].MyStream, handCardInfo);
                        //break;
                    }

                    // A player win
                    if(clientMessage.Command == ClientCommand.Win)
                    {
                        gameEnd = true;
                        ServerMessage winnerInfo = new ServerMessage(ServerCommand.Win);
                        winnerInfo.Winner = Players[_currentPlayerIdex].Name;
                        foreach (Player player in Players)
                        {
                            bfmt.Serialize(player.MyStream, winnerInfo);
                        }
                        break;
                    }

                    // A player quit game
                    if(clientMessage.Command == ClientCommand.Quit)
                    {
                        Players[_currentPlayerIdex].MyStream.Close();
                        Players[_currentPlayerIdex].MyTcpClient.Close();
                        Players.RemoveAt(_currentPlayerIdex);
                        ServerMessage quitMessage = new ServerMessage(ServerCommand.Quit);
                        foreach (Player player in Players)
                        {
                            bfmt.Serialize(player.MyStream, quitMessage);
                        }
                        gameEnd = true;
                        break;
                    }
                }  // Data available
            }
            
            return gameEnd;
        } // Next turn
    }
}
