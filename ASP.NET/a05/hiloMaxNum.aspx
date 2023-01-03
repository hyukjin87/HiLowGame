<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hiloMaxNum.aspx.cs" Inherits="a05.MorePages.hiloMaxNum" %>

<!DOCTYPE html>

<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using ASP.NET Web Forms
        Ask for game maximum number and transfer to "hiloGuessNum.aspx"
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A-05 : HI-LO (REVISITED- AGAIN) hiloMaxNum.aspx</title>
    <link rel="StyleSheet" href="css/style.css" />
</head>
<body>
    <!--
           The form that receive user's game maximums
           Validate the input to set the value that the user should guess
    -->
    <form id="formMax" runat="server">        
        <div>
            <asp:Label ID="title"
                       runat="server"
                       Text="LET'S PLAY HI LOW GAME"
                       CssClass="title">
            </asp:Label>
        </div>
        <div>
            <asp:Label ID="maxPrompt" 
                       runat="server" 
                       Text="Hello << who >>!!<br>Please enter the maximum Number for the game"
                       CssClass="prompt">
            </asp:Label>            
        </div>
        <div>
            <asp:TextBox ID="inputMax" 
                         runat="server">
            </asp:TextBox>
            <asp:Button ID="maxSubmit" 
                        runat="server" 
                        Text="Submit" 
                        OnClick="maxSubmit_Click" 
                        CssClass="Button" />           
        </div>
        <div>
             <asp:CustomValidator ID="maxBoxValid" 
                                 runat="server" 
                                 ControlToValidate="inputMax" 
                                 ErrorMessage="CustomValidator" 
                                 OnServerValidate="maxNum_ServerValid" 
                                 ValidateEmptyText="true"
                                 cssClass="error">
            </asp:CustomValidator>
        </div>
    </form>
</body>
</html>
