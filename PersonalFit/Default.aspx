<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
	
</head>
<body>
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(images/bg-01.jpg);">
					<span class="login100-form-title-1">Sign In</span>
				</div>
				
			<form CssClass="login100-form validate-form" id="form1" runat="server">
			<div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
			<span class="label-input100">Username</span>
			<asp:TextBox CssClass="input100" ID="usernameTextBox" Text="Enter Username" runat ="server" />
						<span class="focus-input100"></span>
					</div>
					
					<div class="wrap-input100 validate-input m-b-18" data-validate = "Password is required">
						<span class="label-input100">Password</span>
						 <asp:TextBox CssClass="input100" ID="passwordTextBox" Text="Enter Password" runat ="server" />
						<span class="focus-input100"></span>
					</div>
					
					
					<div class="container-login100-form-btn">
						<asp:Button CssClass="login100-form-btn" ID="submitButton" Text ="Login" runat ="server" OnClick="submitButtonEventMethod" />
					</div>
   


       
    </form>
</div>
		</div>
	</div>
	
   <!-- <div id="hitCountValue">0</div> -->

    <!-- Call out to the HUB using javascript.
        The order is important.
        
        
        -->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/animsition/js/animsition.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
	<script src="vendor/countdowntime/countdowntime.js"></script>
	<script src="js/main.js"></script>
    <script src="Scripts/jquery-1.6.4.js"></script>
    <script src="Scripts/jquery.signalR-2.3.0.js"></script>
    <script type="text/javascript">
        $(function () {
            var connection = $.hubConnection();
            var hub = connection.createHubProxy("Chat");
            hub.on("onRecordHit",function (hitCount) {$('#hitCountValue').text(hitCount);});
            connection.start(function (){ hub.invoke('chatNow');});
        })


    </script>
</body>
</html>
