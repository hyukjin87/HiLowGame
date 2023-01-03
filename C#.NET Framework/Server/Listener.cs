/*
* DESCRIPTION		:
* 	It is responsible for exchanging data with clients through this class.
*   Convert the data bytes received from the client to ASCII strings 
*   and process the data to determine the state of the game
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace Server
{
    internal class Listener
    {
        // Game information list
        List<PlayGame> games = new List<PlayGame>();
        internal void StartListener()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Any;
                
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                
                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    // check the clients pending
                    if(!server.Pending())
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    else
                    {
                        // Perform a blocking call to accept requests.
                        // You could also user server.AcceptSocket() here.
                        TcpClient client = server.AcceptTcpClient();
                        ParameterizedThreadStart ts = new ParameterizedThreadStart(Worker);
                        Thread clientThread = new Thread(ts);
                        clientThread.Start(client);
                    }                    
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        public void Worker(Object o)
        {
            TcpClient client = (TcpClient)o;
            // Buffer for reading data
            Byte[] bytes = new Byte[256];

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            int i;

            try
            {
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    String dataSet = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    string[] data = dataSet.Split(',');

                    string uid = data[0];
                    string uMin = data[1];
                    string uMax = data[2];
                    string uGuess = data[3];
                    string uStatus = data[4];
                    string uGameStatus = data[5];
                    // true = playing game, false = new game
                    bool gameStatus = bool.Parse(uGameStatus);
                    // Message to end game session in client
                    if (uStatus == "end")
                    {
                        // Verification questions from the server side to the client
                        uStatus = "ask";
                    }
                    // When a user terminates a game session,
                    // the information is deleted from the game information list
                    else if (uStatus == "yes")
                    {
                        int idx = games.FindIndex(a => a.UID == uid);
                        games.RemoveAt(idx);
                    }
                    else
                    {
                        // Search for existing information based on the user's uid and play the game
                        if (gameStatus)
                        {
                            PlayGame gameData = games.Find(x => x.UID == uid);
                            gameData.GuessGame(int.Parse(uGuess));
                            uMin = gameData.userMin.ToString();
                            uMax = gameData.userMax.ToString();
                            uStatus = gameData.userStatus;
                        }
                        // Create new games and save game information to a list
                        else
                        {
                            PlayGame playGame = new PlayGame();
                            playGame.NewPlayGame(uid);
                            games.Add(playGame);
                            uMin = playGame.userMin.ToString();
                            uMax = playGame.userMax.ToString();
                            uStatus = playGame.userStatus;
                            uGameStatus = "true";
                        }
                    }           

                    // Process the data sent by the client.
                    dataSet = (uid + "," + uMin + "," + uMax + "," + uGuess + "," + uStatus + "," + uGameStatus);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(dataSet);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            // Shutdown and end connection
            client.Close();
        }


    }
}
