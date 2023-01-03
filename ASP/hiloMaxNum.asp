<!--
    DESCRIPTION     :
        This is a web page that plays HI-LOW number games using HTML, Javascript, and ASP.
        Ask for user max number and set the target number
        After post form to "hiloGuessNum.asp"
-->
<!DOCTYPE html>
<html>
  <head>
    <title>ASP - HiLo Game Max Number Input</title>
  </head>
  <script type="text/javascript">

    // FUNCTION     : setUpMaxNum()
    // DESCRIPTION  : Set the target value arbitrarily set at the maximum range set by the user
    // PARAMETERS   : none
    // RETURNS      : none    
    function setUpMaxNum() {
      var whichNumber = document.getElementById("inputMax").value;
      var isInteger = whichNumber % 1;

      // Check the minimum possible values and negative numbers
      if (whichNumber <= 1) {
          document.getElementById("error").innerHTML = "Number must be <b>greater than 1</b> or <b>non-negative</b>";
      }
      // Check if the number entered is a decimal
      else if (isInteger != 0) {
          document.getElementById("error").innerHTML = "<b>Decimal points</b> are not allowed";
      }
      else {
          // Set the target number
          document.getElementById("targetSet").value = Math.floor((Math.random() * whichNumber) + 1);
          document.maxNumForm.submit();
      }
    }
  </script>
  <body>
<%
  dim userName

  userName=Request.Form("userName")

%>
    <!--
           Table to receive user's game maximums
           Validate the input to set the value that the user should guess
     -->
      <form action="hiloGuessNum.asp" method="post" name="maxNumForm">
          Hello <b><%=userName%></b>!!, Please enter the maximum Number for the game
          <input name="userMaxNumber" id="inputMax" type="number" value="" size="20" autofocus/>
          <input type="button" value="Submit" onclick="setUpMaxNum();" />
          <input type="hidden" name="userName" value="<%=userName%>"/>
          <input type="hidden" name="minNumber" value="1"/>
          <input type="hidden" id="targetSet" name="targetNumber" value=""/>        
      </form>
      <div id="error" style="color:red;"></div>
</body>
</html>