/*
* DESCRIPTION		:
* 	It is responsible for transmitting information received 
* 	from the main page to the server side
*/

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace a05
{    
    public partial class _default : System.Web.UI.Page
    {
        // FUNCTION     : nameSubmit_Click()
        // DESCRIPTION  : Send user name to the next page
        // PARAMETERS   : object sender, EventArgs e
        // RETURNS      : none
        protected void nameSubmit_Click(object sender, EventArgs e)
        {            
            Session["nameForm"] = inputName.Text;
            Server.Transfer("hiloMaxNum.aspx");
        }
    }
}