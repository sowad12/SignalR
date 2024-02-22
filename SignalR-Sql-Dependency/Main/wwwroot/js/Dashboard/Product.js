"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();
//signalR Connection start

$(function () {
    console.log("hello");
    connection.start().then(function () {
        console.log('Connected to dashboardHub');
        InvokeProducts();
        //InvokeSales();
        //InvokeCustomers();

    }).catch(function (err) {
        return console.error(err.toString());
    });
});

//send backend hub request
function InvokeProducts() {
    connection.invoke("SendProducts").catch(function (err) {
        return console.error(err.toString());
    });
}
connection.on("ReceiveProducts", function (products) {
    BindProductsToGrid(products);
});

function BindProductsToGrid(products) {
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