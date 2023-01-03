/*
* DESCRIPTION		:
* 	Display the name of the user received on the previous page 
* 	and check whether the maximum value of the game entered by the user is valid.
*   After that, the information is delivered to the next page
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
    public partial class hiloMaxNum : System.Web.UI.Page
    {
        // FUNCTION     : Page_Load()
        // DESCRIPTION  : Display a user's name when the page load
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["nameForm"].ToString();
            maxPrompt.Text = "Hello <b><< " + userName + " >></b>!!<br>Please enter the maximum Number for the game";
        }

        // FUNCTION     : maxNum_ServerValid()
        // DESCRIPTION  : Function to check if the game maximum is valid
        // PARAMETERS   : object sender, ServerValidateEventArgs e
        // RETURNS      : none
        protected void maxNum_ServerValid(object sender, ServerValidateEventArgs e)
        {
            // Check blank entry
            if (e.Value.Trim()=="")
            {
                e.IsValid = false;
                maxBoxValid.Text = "The MaxNumber <b>cannot</b> be blank";
                return;
            }

            Regex regex = new Regex(@"-?^\d+$");
            // Check regex
            if (regex.IsMatch(inputMax.Text) == true) 
            {
                // Check the minimum possible values and negative numbers
                if (Convert.ToInt32(e.Value) <= 1) 
                {
                    e.IsValid = false;
                    maxBoxValid.Text = "Number must be <b>greater than 1</b> or <b>non-negative</b>";
                    return;
                }
                else
                {
                    e.IsValid = true;
                    return;
                }
            }
            else
            {
                e.IsValid = false;
                maxBoxValid.Text = "The Maximum number must be an <b>integer value</b>";
            }
        }

        // FUNCTION     : maxSubmit_Click()
        // DESCRIPTION  : Send game minimum number and maximum number to the next page
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void maxSubmit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid == true)
            {
                Session["minNum"] = 1;
                Session["maxNum"] = inputMax.Text;
                Server.Transfer("hiloGuessNum.aspx");
            }
        }
    }
}