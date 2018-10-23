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
</body>
</html>
