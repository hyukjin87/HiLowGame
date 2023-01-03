<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hiloWin.aspx.cs" Inherits="a05.MorePages.hiloWin" %>

<!DOCTYPE html>

<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using ASP.NET Web Forms
        Display game winning page and transfer to "hiloMaxNum.aspx"
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A-05 : HI-LO (REVISITED- AGAIN) hiloWin.aspx</title>
    <link rel="StyleSheet" href="css/style.css" />
</head>
<body style="background-color:yellow">
    <!--
            Print out a message saying user won the game
            The form asking if you want to play the game again
     -->
    <form id="formWin" runat="server">
        <div>
            <asp:Label ID="title"
                       runat="server"
                       Text="LET'S PLAY HI LOW GAME"
                       CssClass="title">
            </asp:Label>
        </div>
        <div>
            <asp:Label ID="youWin" 
                       runat="server" 
                       Text="<b>YOU WIN</b><br>"
                       CssClass="prompt"
                       style="font-size:50px;color:blue">
            </asp:Label>
            <asp:Button ID="b_playAgain" 
                        runat="server" 
                        Text="PLAY AGAIN" 
                        OnClick="playAgain_Click" 
                        CssClass="Button" 
                        style="font-size: 20px; text-align:center;" />
        </div>
    </form>
</body>
</html>
