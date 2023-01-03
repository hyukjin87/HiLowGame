/*
* DESCRIPTION		:
* 	Display the winning screen to the user and ask to play the game again.
*   If user play the game again, initialize the information stored in the session 
*   and go to the maximum input page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace a05.MorePages
{
    public partial class hiloWin : System.Web.UI.Page
    {
        // FUNCTION     : playAgain_Click()
        // DESCRIPTION  : A function that initializes the information stored in the session
        //              : and takes you to the Maximum Entry page
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void playAgain_Click(object sender, EventArgs e)
        {
            Session.Remove("minNum");
            Session.Remove("maxNum");
            Session.Remove("targetNum");
            Session.Remove("guessNum");
            Server.Transfer("hiloMaxNum.aspx");
        }
    }
}