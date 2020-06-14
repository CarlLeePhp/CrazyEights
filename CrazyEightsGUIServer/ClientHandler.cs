using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CrazyEightsLib;
using System.Threading;

namespace CrazyEightsGUIServer
{
    class ClientHandler
    {
        TcpClient _client;
        Game _game;
        Player _player;
        MainForm _app;
        NetworkStream _stream;
        public ClientHandler(TcpClient client, Game game, MainForm app)
        {
            _client = client;
            _game = game;
            _app = app;
            _stream = client.GetStream();
        }  // Constructor

        public void Run()
        {
            _app.DisplayNote("Connet from a player");
            IFormatter bfmt = new BinaryFormatter();
            // 1. send a message to client
            // 2a. close client connection, End
            // 2b. receive a player infor, create a player and add it to players
            if(_game.Status == GameStatus.Running)
            {
                _app.DisplayNote("The game is running");
                bfmt.Serialize(_stream, ConnectionResult.Running);
                Thread.Sleep(200);
                _client.Close();
                _app.DisplayNote("Connection closed");
            }
            else if(_game.Players.Count >= _game.MaxPlayers)
            {
                _app.DisplayNote("The game cannot receive more players");
                bfmt.Serialize(_stream, ConnectionResult.Max);
                Thread.Sleep(200);
                _client.Close();
                _app.DisplayNote("Connection closed");
            }
            else
            {
                bfmt.Serialize(_stream, ConnectionResult.Success);
                Thread.Sleep(200);
                Object obj = bfmt.Deserialize(_stream);
                PlayerInfo playerInfo = obj as PlayerInfo;
                _player = new Player(playerInfo.PlayerName);
                _player.MyTcpClient = _client;
                _player.MyStream = _stream;
                _game.AddPlayer(_player);
                _app.DisplayNote(_player.Name + " joined");
                
            }
        }  // Run

       
        
    }
}
