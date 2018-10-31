$.connection.hub.start()
    .done(function () {
        console.log("It Worked");
        //$.connection.ChatHub.server.Annouce("Connected");
        $.hubConnection().createHubProxy("Chat").invoke('Annouce');
    })
    .fail(function () {
        alert("ERROR!!");
    });

//$.connection.ChatHub.client.annouce(message) = function ()
//{
//    alert(message);
//}