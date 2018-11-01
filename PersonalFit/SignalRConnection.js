var connection = $.hubConnection();
var contosoChatHubProxy = connection.createHubProxy('Chat');
contosoChatHubProxy.on('addContosoChatMessageToPage', function (userName, message) {
    console.log(userName + ' ' + message);
});
connection.start().done(function () {
    // Wire up Send button to call NewContosoChatMessage on the server.
    $('#newContosoChatMessage').click(function () {
        contosoChatHubProxy.invoke('newContosoChatMessage', $('#displayname').val(), $('#message').val());
        $('#message').val('').focus();
    });
});