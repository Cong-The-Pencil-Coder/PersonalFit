<%@ Page Language="C#" AutoEventWireup="true" CodeFile="emailGUI.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" width ="60%">

        <tr>
            <td>to</td>
            <td><asp:TextBox ID="to" runat="server" Text="cong.pham234@gmail.com" Width ="99%"></asp:TextBox></td>
        </tr>

        <tr>
            <td>from</td>
            <td><asp:TextBox ID="from" runat="server" Text="Buzz.LightYear8000@gmail.com" Width ="99%"></asp:TextBox></td>
        </tr>

        <tr>
            <td>subject</td>
            <td><asp:TextBox ID="subject" runat="server" Text="Email Tutorial" Width ="99%" ></asp:TextBox></td>
        </tr>

        <tr>
            <td>body</td>
            <td><asp:TextBox ID="body" runat="server" Text="This is the body" Width ="99%" Height ="150px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="send" runat="server" Text="Send" OnClick ="sendEventMethod"/></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Label ID="status" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>

    </form>
</body>
</html>
