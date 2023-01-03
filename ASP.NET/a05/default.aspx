<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="a05._default" %>

<!DOCTYPE html>

<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using ASP.NET Web Forms
        Ask for user name and transfer to "hiloMaxNum.aspx"
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A-05 : HI-LO (REVISITED- AGAIN) default.aspx</title>
    <link rel="StyleSheet" href="css/style.css" />
</head>
<body>
    <!--
            The form that receive the user's name
            Validation of the entered value to save the user's name
    -->
    <form id="formUserName" runat="server">        
        <div>
            <asp:Label ID="title"
                       runat="server"
                       Text="LET'S PLAY HI LOW GAME"
                       CssClass="title">
            </asp:Label>
        </div>
        <div>
            <asp:Label ID="namePrompt" 
                       runat="server" 
                       Text="Please enter your name: " 
                       CssClass="prompt">
            </asp:Label>           
        </div>
        <div>
             <asp:TextBox ID="inputName" 
                         runat="server"
                         placeholder="Joe">
            </asp:TextBox>
            <asp:Button ID="nameSubmit" 
                        runat="server" 
                        Text="Submit" 
                        OnClick="nameSubmit_Click" 
                        cssClass="Button" />            
        </div>
        <div>
            <asp:RequiredFieldValidator ID="nameBoxValid" 
                                        runat="server" 
                                        ControlToValidate="inputName" 
                                        ErrorMessage="Your name <b>cannot</b> be BLANK."
                                        cssClass="error">
            </asp:RequiredFieldValidator>
        </div>
    </form>
</body>
</html>
