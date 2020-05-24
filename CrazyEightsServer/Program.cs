using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using CrazyEightsLib;

namespace CrazyEightsServer
{
    class Program
    {
        static TcpListener server;
        static List<Player> players = new List<Player>();
        static IFormatter bfmt;
        static void Main(string[] args)
        {
            bfmt = new BinaryFormatter();
            
            server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            Console.WriteLine("Server started at port 2048.");

            WaitPlayers();
 
            // Send 5 cards to each player
            Deck deck = new Deck();
            deck.Shuffle();
            for(int i=1; i<=5; i++)
            {
                bfmt.Serialize(players[0].MyStream, deck.DealTopCard());
                bfmt.Serialize(players[1].MyStream, deck.DealTopCard());
                
            }

            // Send a message with a starter card
            // and identifying who is the next
            PlayingCard card = deck.DealTopCard();
            while(card.Rank == CardRank.Eight)
            {
                card = deck.DealTopCard();
            }

            ServerMessage topPileCardMessage = new ServerMessage(ServerCommand.PileCard);
            topPileCardMessage.TopPileCard = card;
            topPileCardMessage.NextPlayer = players[0].IsMyTurn ? players[0].Name : players[1].Name;
            topPileCardMessage.Message = topPileCardMessage.NextPlayer + " Turn";

            bfmt.Serialize(players[0].MyStream, topPileCardMessage);
            bfmt.Serialize(players[1].MyStream, topPileCardMessage);

            players[0].Connection.Close();
            players[1].Connection.Close();

            server.Stop();

            Console.ReadLine();
        }  // main

        private static void WaitPlayers()
        {
            while (players.Count < 2)
            {
                TcpClient connection = server.AcceptTcpClient();
                NetworkStream stream = connection.GetStream();
                Object obj = bfmt.Deserialize(stream);
                string name = obj as String;
                Player player = new Player(name, false, connection);
                players.Add(player);
                Console.WriteLine("{0} was joined", player.Name);
            }

            players[0].IsMyTurn = true;
        }  // Wait Players

        private static void GameLoop()
        {
            // 1. Identify whose turn, send a message to players.
            // 2. Wait for reply from the player.
            // 3a. Receive a card [Player placed a card], send this card to other player as the top starter pile, back to step 1
            // 3b. Receive a request for a card, send a card to the player, if there is no card in the deck, go to 4, else back to step 2
            // 3c. Receive a information said the player win the game, send a message to the other player showing who, go to 5
            // 4. Back all cards in starter pile except the last one to deck, shuffle the deck
            // 5. Reset the game.
            
        }
    }
}
