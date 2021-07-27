"use strict";

//const { signalR } = require("./signalr/dist/browser/signalr");

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("RecieveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messageTxt").appendChild(li);
    li.style = "background:#b2b2b2;margin-top:5px; padding:10px 10px 10px 12px; border-radius:20px; width:max-content; font-size:0.7em; color:#F9FBFF";
    li.textContent = user + " says "+ message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var usr = document.getElementById("user").value;
    var msg = document.getElementById("message").value;
    connection.invoke("SendMessage", usr, msg);

    //connection.invoke("RecieveMessage", usr, msg).catch(function (err) {
    //    return console.error(err.toString());
    //});
    event.preventDefault();
});
/*connection.start();*/
