<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Chat Demo</title>
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/Scripts/jquery.signalR-2.3.0.min.js"></script>
    <script src="/signalr/hubs"></script>
    <script src="Scripts/SignalRConnection.js"></script>
</head>
<body>
    <input type="text" id="message" />
    <input type="button" id="sendmessage" value="Send" />
    <input type="hidden" id="callername" />
    <input type="hidden" id="username" />

    <ul id="discussion"></ul>
</body>
</html>
