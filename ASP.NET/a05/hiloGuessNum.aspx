<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hiloGuessNum.aspx.cs" Inherits="a05.MorePages.hiloGuessNum" %>

<!DOCTYPE html>

<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using ASP.NET Web Forms
        Playing game, user input the guess number and compare to target number 
        and transfer to "hiloWin.aspx"
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A-05 : HI-LO (REVISITED- AGAIN) hiloGuessNum.aspx</title>
    <link rel="StyleSheet" href="css/style.css" />
</head>
<body>
    <!--
           The form that plays the user's game
           Verify that the user's value is correct by verifying the value entered
     -->
    <form id="formGuess" runat="server">
        <div>
            <asp:Label ID="title"
                       runat="server"
                       Text="LET'S PLAY HI LOW GAME"
                       CssClass="title">
            </asp:Label>
        </div>
        <div>
            <asp:Label ID="guessRangePrompt" 
                       runat="server" 
                       Text="Your allowable guessing range is any value, your starting range is minNum ~ maxNum<br>"
                       cssClass="prompt"
                       style="font-size:12px;">
            </asp:Label>
            <asp:Label ID="guessPrompt" 
                       runat="server" 
                       Text="Please guess a number<br>"
                       cssClass="prompt">
            </asp:Label>
            <asp:TextBox ID="inputGuess" 
                         runat="server">
            </asp:TextBox>
            <asp:Button ID="guessSubmit" 
                        runat="server" 
                        Text="Make this guess" 
                        OnClick="guessSubmit_Click" 
                        CssClass="Button" />                        
        </div>
        <div>
            <asp:Label ID="rangePrompt" 
                       runat="server" 
                       ForeColor="Blue" 
                       Text="Target number Range: minNum - maxNum">
            </asp:Label>            
        </div>
        <div>
            <asp:CustomValidator ID="guessBoxValid" 
                                 runat="server" 
                                 ControlToValidate="inputGuess" 
                                 ErrorMessage="CustomValidator" 
                                 OnServerValidate="guessNum_ServerValid" 
                                 ValidateEmptyText="true"
                                 cssClass="error">
            </asp:CustomValidator>
        </div>
    </form>
</body>
</html>
