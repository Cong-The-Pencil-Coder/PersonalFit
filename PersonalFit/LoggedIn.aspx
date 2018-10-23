<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoggedIn.aspx.cs" Inherits="LoggedIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logged In</title>
</head>
<body>
    <p>Logged In Page</p>
    <form id="form1" runat="server">
        <div>

            <p> Hello </p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            <asp:Button ID ="logoutButton" Text ="Log Out" runat="server" Onclick="logoutEventHandler" />
        </div>
    </form>
</body>
</html>
