﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ PreviousPageType VirtualPath="~/TrainerProfile.aspx" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Chat Demo</title>
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/Scripts/jquery.signalR-2.3.0.min.js"></script>
    <script src="/signalr/hubs"></script>
    <script src="Scripts/SignalRConnection.js"></script>

    <%--<link href="Style/ChatPageStyle.css" rel="stylesheet" />--%>
    <%--<link href="Style/boostrap-superhero.css" rel="stylesheet" />--%>
</head>
<body>
    <input type="text" id="message" />
    <input type="button" id="sendmessage" value="Send" />
    <input type="hidden" id="displayname" />

    <ul id="discussion"></ul>
</body>
</html>
