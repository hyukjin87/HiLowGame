<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using HTML, Javascript, and ASP.
        Playing game, user input the guess number and compare to target number
        After post form to "hiloWin.asp"
-->
<!DOCTYPE html>
<html>
  <head>
    <title>ASP - HiLo Game Guess Number Input</title>
  </head>
  <script type="text/javascript">            

        // FUNCTION     : guessNumber()
        // DESCRIPTION  : A function that checks that the number you guess is the same as the randomly set target
        // PARAMETERS   : none
        // RETURNS      : none
        function guessNumber() {
            var minNumber = document.getElementById("min").value;
            var maxNumber = document.getElementById("max").value;
            var targetNumber = document.getElementById("target").value;
            var userGuessNumber = document.getElementById("inputGuess").value;
            var guessNumToInterger = parseInt(userGuessNumber);     // Fixing a phenomenon in which a user's value is sometimes not passed to an integer data type
            var isInterger = guessNumToInterger % 1;

            // Check if the number entered is a decimal
            if (isInterger != 0) {
                document.getElementById("error").innerHTML = "<b>Decimal points</b> are not allowed";
            }
            // Determine if the user's value is less than minimum or greater than maximum
            else if (guessNumToInterger < minNumber || guessNumToInterger > maxNumber) {
                document.getElementById("error").innerHTML = "You cannot enter <b>less than minimum</b> or <b>greater than maximum</b>";
            }
            else {
                // If the estimated value is greater than the target value,
                if (targetNumber > guessNumToInterger) {
                    minNumber = guessNumToInterger;
                    document.getElementById("min").value = minNumber;
                    document.getElementById("error").innerHTML = `Target number is <b>HI</b> Range: ${minNumber} - ${maxNumber}`;
                }
                // If the estimated value is less than the target value,
                else if (targetNumber < guessNumToInterger) {
                    maxNumber = guessNumToInterger;
                    document.getElementById("max").value = maxNumber;
                    document.getElementById("error").innerHTML = `Target number is <b>LOW</b> Range: ${minNumber} - ${maxNumber}`;                    
                }
                else {
                    document.guessForm.submit(); 
                }
            }
        }
  </script>
  <body>
<%
    dim userName
    dim userMaxNumber
    dim minNumber
    dim targetNumber

    userName=Request.Form("userName")   
    userMaxNumber=Request.Form("userMaxNumber")
    minNumber=Request.Form("minNumber")
    targetNumber=Request.Form("targetNumber")

%>
    <!--
           The form that plays the user's game
           Verify that the user's value is correct by verifying the value entered
     -->
    <form action="hiloWin.asp" method="post" name="guessForm">
        <div style="font-size:10px;">Your allowable guessing range is any value, your starting range is [<%=minNumber%> ~ <%=userMaxNumber%>]</div>
        Please guess a number
        <input name="userGuessNum" id="inputGuess" type="number" value="" size="20" autofocus/>
        <input type="button" value="Make this guess" onclick="guessNumber();" />
        <input type="hidden" name="userName" value="<%=userName%>"/>        
        <input type="hidden" id="max" name="userMaxNum" value="<%=userMaxNumber%>"/>
        <input type="hidden" id="min" name="minNumber" value="<%=minNumber%>"/>
        <input type="hidden" id="target" name="targetNumber" value="<%=targetNumber%>"/>                   
    </form>
    <div id="error" style="color:red;"></div>
  </body>
</html>