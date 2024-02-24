"use strict";

//var connection = new signalR.HubConnectionBuilder()
//    .withUrl("/dashboardHub", {
//        skipNegotiation: true,
//        transport: signalR.HttpTransportType.WebSockets
//    })
//    .withAutomaticReconnect()
//    .build();

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    connection.start().then(function () {
        console.log('Connected to importHub');
    }).catch(function (err) {
        return console.error(err.toString());
    });
});


// Send backend hub request
function invokeProducts() {
    console.log("Send");
    connection.invoke("SendProducts")
        .catch(function (err) {
            return console.error(err.toString());
        });
}

connection.on("ReceiveProducts", function (products) {
    console.log("Received", products);
    bindProductsToGrid(products);
});

function bindProductsToGrid(products) {
    $('#tblProduct tbody').empty();

    var tr;
    $.each(products, function (index, product) {
        tr = $('<tr/>');
        tr.append(`<td>${(index + 1)}</td>`);
        tr.append(`<td>${product.name}</td>`);
        tr.append(`<td>${product.category}</td>`);
        tr.append(`<td>${product.price}</td>`);
        $('#tblProduct').append(tr);
    });
}
