using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CrazyEightsLib;
using System.Net.Sockets;

namespace CrazyEightsClient
{
    class ServerHandler
    {
        TcpClient _client;
        MainForm _app;
        NetworkStream _stream;
        IFormatter _bfmt;
        string _myName;
        public ServerHandler(TcpClient client, MainForm app)
        {
            _client = client;
            _app = app;
            _stream = _client.GetStream();
            _bfmt = new BinaryFormatter();
            _myName = "unknown";
        }

        public ConnectionResult GetConnectionRespond()
        {
            ConnectionResult result;
            while (true)
            {
                if (_stream.DataAvailable)
                {
                    Object obj = _bfmt.Deserialize(_stream);
                    result = (ConnectionResult)obj;
                    break;
                }
            }
            return result;
        } // Get Connection Result

        public void SendPlayerInfo(string playerName)
        {
            _myName = playerName;
            PlayerInfo player = new PlayerInfo(playerName);
            _bfmt.Serialize(_stream, player);
            _app.DisplayNote("Waiting for game start");
        } // Send palyer information

        public void Run()
        {
            ServerMessage serverMessage;
            while (true)
            {
                if (_stream.DataAvailable)
                {
                    Object obj = _bfmt.Deserialize(_stream);
                    serverMessage = obj as ServerMessage;
                    if(serverMessage.Command == ServerCommand.Message)
                    {
                        _app.DisplayNote(serverMessage.Message);
                    } // message from server
                    if(serverMessage.Command == ServerCommand.HandCard)
                    {
                        PlayingCard handCard = serverMessage.HandCard;
                        _app.AddToHand(handCard);
                    } // handcard
                    if(serverMessage.Command == ServerCommand.PileCard)
                    {
                        PlayingCard pileCard = serverMessage.TopPileCard;
                        CardSuit pileSuit = serverMessage.PileSuit;
                        _app.AddToPile(pileCard, pileSuit);
                    } // pile card
                    if(serverMessage.Command == ServerCommand.TurnInfo)
                    {
                        string nextPlayer = serverMessage.NextPlayer;
                        _app.DisplayNote(nextPlayer + "\'s Turn");
                        if(nextPlayer == _myName)
                        {
                            _app.isMyTurn = true;
                        }
                        else
                        {
                            _app.isMyTurn = false;
                        }
                    } // turn information
                    if (serverMessage.Command == ServerCommand.Quit)
                    {
                        _app.DisplayNote("Someone quited the game");
                        _app.isSomeoneQuit = true;
                    } // someone quited
                    if(serverMessage.Command == ServerCommand.Win)
                    {
                        _app.DisplayNote(serverMessage.Winner + " Won");
                        _app.isSomeoneWin = true;
                    } // someone won
                }
                Thread.Sleep(200);
            }
        } // Run

        public void QuitGame()
        {
            ClientMessage quitMessage = new ClientMessage(ClientCommand.Quit);
            _bfmt.Serialize(_stream, quitMessage);
        } // Quit Game
    }
}
