"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//signalRConnection Start
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
//send client data to all
$("#sendButton").click(function (e) {
    e.preventDefault();
    let user = $("#userInput").val()
    let message = $("#messageInput").val();
    connection.invoke("SendMsgToAll", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    $("#userInput").val('');
    $("#messageInput").val('');
});

//recieve msg from hub
connection.on("ReceiveMsg", function (user, message) {
    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);

    //li.textContent = `${user} says ${message}`;

    var li = $("<li></li>").text(`${user} says ${message}`);
    $("#messagesList").append(li);
});