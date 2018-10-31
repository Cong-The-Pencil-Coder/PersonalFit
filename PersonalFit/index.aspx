<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Chat Demo</title>
</head>
<body>
    <input type="text" id="message" />
    <input type="button" id="sendmessage" value="Send" />
    <input type="hidden" id="displayname" />
    <ul id="discussion"></ul>

    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <script src="Scripts/jquery.signalR-2.3.0.min.js"></script>
    <script src="signalr/hubs"></script>
<%--    <script type="text/javascript">
        $(function () {
            var chat = $.connection.chatHub;
            chat.client.broadcastMessage = function (name, message) {
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();

            //add message to the page
            $('#discussion').append('<li><strong>' + encodedName + '</strong>:&nbsp;&nbsp;' +
                encodedMsg + '</li>');
            };
            $('#displayname').val(prompt('Enter your name: ', ""));
            $('#message').focus();

            $.connection.hub.start().done(function () {
                $('#sendMEssage').click(function () {
                    chat.server.send($('#displayname').val(), $("#message").val());

                    $('#message').val('').focus();
                });
            });
        });


    </script>--%>

    <script src="Scripts/SignalRConnection.js"></script>

</body>
</html>
