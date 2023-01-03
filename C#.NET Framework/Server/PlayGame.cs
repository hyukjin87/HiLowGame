/*
* DESCRIPTION		:
* 	This class has the role of generating and storing user game information. 
* 	Create a game based on the information sent by the client and save data 
* 	so that the game can continue
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class PlayGame
    {
        // Properties
        public string UID { get; set; }
        public int userMin { get; set; }
        public int userMax { get; set; }
        public int userTarget { get; set; }
        public string userStatus { get; set; }

        /*
         * Method       : NewPlayGame()
         * Description  : Create new game
         * Parameters   : string id : user id from client
         * Return       : void
         */
        public void NewPlayGame(string id)
        {
            UID = id;
            NumberSetting();
            userStatus = "play";
        }

        /*
         * Method       : NumberSetting()
         * Description  : Determine the minimum and maximum value of the game 
         *              : and determine the target value in it
         * Parameters   : none
         * Return       : void
         */
        public void NumberSetting()
        {
            // configuration setting
            var minNum = ConfigurationManager.AppSettings["minNum"];
            var maxNum = ConfigurationManager.AppSettings["maxNum"];

            // target number setting
            int min = int.Parse(minNum);
            int max = int.Parse(maxNum);

            Random random = new Random();
            int target = random.Next(min, max);

            userMin = min;
            userMax = max;
            userTarget = target;
        }

        /*
         * Method       : GuessGame()
         * Description  : Verify that the user's guess is correct with the target information
         * Parameters   : int guess : guess number from client
         * Return       : void
         */
        public void GuessGame(int guess)
        {
            if(guess > userTarget)
            {                
                userMax = guess;
                userStatus = "higher";
            }
            else if (guess < userTarget)
            {
                userMin = guess;
                userStatus = "lower";
            }
            else
            {
                userStatus = "win";
            }
        }
    }    
}
