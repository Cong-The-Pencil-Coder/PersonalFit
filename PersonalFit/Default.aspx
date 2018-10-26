<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <p>This is the home page</p>
    <a href ="#">Home</a> | <a href ="Registration.aspx">Registration</a>
    <!--
        username:webuser
        password:Xn140839
        -->
    <form id="form1" runat="server">
        <div>
            <p>Enter Username</p>
            <asp:TextBox ID="usernameTextBox" Text="Enter Username Here" runat ="server" />
            <p>Enter Password</p>
            <asp:TextBox ID="passwordTextBox" Text="Enter Password" runat ="server" />

            <asp:Button ID="submitButton" Text ="Log In" runat ="server" OnClick="submitButtonEventMethod" />
        </div>
    </form>

    <div id="hitCountValue">0</div>

    <!-- Call out to the HUB using javascript.
        The order is important.
        
        
        -->


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
