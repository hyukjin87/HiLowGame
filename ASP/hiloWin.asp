<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using HTML, Javascript, and ASP.
        Display game winning page
        After post form to "hiloMaxNum.asp"
-->
<!DOCTYPE html>
<html>
  <head>
    <title>ASP - HiLo Game Winning Page</title>
  </head>
  <script type="text/javascript">
        
        // FUNCTION     : playAgain()
        // DESCRIPTION  : Function to restart the game
        // PARAMETERS   : none
        // RETURNS      : none
        function playAgain() {
            document.playAgainForm.submit();
        }
  </script>
  <body style="background-color:yellow;">
<%
    dim userName

    userName=Request.Form("userName")

%>

    <!--
            Print out a message saying user won the game
            A table asking if you want to play the game again
     -->
    <form action="hiloMaxNum.asp" method="post" name="playAgainForm">            
        <div id="youWin" style="position:absolute; top: 40%; left:50%; transform:translateX(-50%);font-size:50px;"><b>YOU WIN</b></div>
        <input id="b_playAgain" type="button" value="PLAY AGAIN" 
            style="position:absolute; top: 50%; left:50%; transform:translateX(-50%); font-size: 20px; text-align:center;" 
            onclick="playAgain()" />
        <input type="hidden" name="userName" value="<%=userName%>"/>
    </form>
  </body>
</html>