/*
* DESCRIPTION		:
* 	Display the minimum, maximum number of the game received on the previous page 
* 	and check whether the guess value of the game entered by the user is valid.
*   After that, delivered to the next page
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace a05.MorePages
{
    public partial class hiloGuessNum : System.Web.UI.Page
    {
        // FUNCTION     : Page_Init()
        // DESCRIPTION  : Specify the target number when the page runs
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void Page_Init(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(Session["minNum"]);
            int max = Convert.ToInt32(Session["maxNum"]);
            Random random = new Random();
            int randomNum = random.Next(min, max);
            Session["targetNum"] = randomNum;
        }

        // FUNCTION     : Page_Load()
        // DESCRIPTION  : Display the minimum, maximum number when the page load
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void Page_Load(object sender, EventArgs e)
        {
            string min = Session["minNum"].ToString();
            string max = Session["maxNum"].ToString();

            guessRangePrompt.Text = "Your allowable guessing range is any value, your starting range is " + min + " ~ " + max + "<br>";
            rangePrompt.Text = "Target number Range: " + min + " - " + max;
        }

        // FUNCTION     : guessNum_ServerValid()
        // DESCRIPTION  : Function to check if the game guess number is valid
        // PARAMETERS   : object sender, ServerValidateEventArgs e
        // RETURNS      : none
        protected void guessNum_ServerValid(object sender, ServerValidateEventArgs e)
        {
            int min = Convert.ToInt32(Session["minNum"]);
            int max = Convert.ToInt32(Session["maxNum"]);

            // Check blank entry
            if (e.Value.Trim()=="")
            {
                e.IsValid = false;
                guessBoxValid.Text = "The Guess Number <b>cannot</b> be blank";
                return;
            }

            Regex regex = new Regex(@"-?^\d+$");
            // Check regex
            if (regex.IsMatch(inputGuess.Text) == true)
            {
                // Determine if the user's value is less than minimum or greater than maximum
                if (Convert.ToInt32(e.Value) < min || Convert.ToInt32(e.Value) > max)
                {
                    e.IsValid = false;
                    guessBoxValid.Text = "You cannot enter <b>less than " + min + "</b> or <b>greater than " + max + "</b>";
                    return;
                }
                else
                {
                    e.IsValid = true;
                    Session["guessNum"] = inputGuess.Text;
                    return;
                }
            }
            else
            {
                e.IsValid = false;
                guessBoxValid.Text = "The Guess Number must be an <b>integer value</b>";
            }
        }

        // FUNCTION     : guessSubmit_Click()
        // DESCRIPTION  : Check if the guess is correct, and if not, provide a valid range
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void guessSubmit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid == true)
            {
                int target = Convert.ToInt32(Session["targetNum"]);
                int guess = Convert.ToInt32(Session["guessNum"]);
                // If the guess value is greater than the target value,
                if (guess > target) 
                {
                    Session["maxNum"] = guess - 1;
                }
                // If the guess value is less than the target value,
                else if (guess < target)
                {
                    Session["minNum"] = guess + 1;
                }
                else
                {
                    Server.Transfer("hiloWin.aspx");
                }

                string min = Session["minNum"].ToString();
                string max = Session["maxNum"].ToString();
                // Provide a valid range for the user
                rangePrompt.Text = "Target number Range: " + min + " - " + max;
            }
        }
    }
}