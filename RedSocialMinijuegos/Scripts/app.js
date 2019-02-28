$(function () {
    var chat = $.connection.chatHub;
    var username;
    do {
        username = document.getElementById("nombre").innerHTML;
    } while (username == null || username == "");

    chat.client.updateUsers = function (userCount, userList) {
        $('#onlineUsersCount').text('Online users: ' + userCount);
        $('#userList').empty();
        userList.forEach(function (username) {
            $('#userList').append('<li>' + username + '</li>');
        });
    }

    chat.client.broadcastMessage = function (username, message) {
        $('#messagesArea').append('<li><strong>' + username + '</strong>: ' + message);
    }

    $.connection.hub.start().done(function () {
        chat.server.connect(username);
    });

    $('#btnSendMessage').click(function(){
        var message = $('#userMessage').val();
        chat.server.send(message);
        $('#userMessage').val("");
    });

});

