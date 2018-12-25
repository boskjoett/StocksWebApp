"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/StockPriceHub").build();

connection.on("PriceUpdated", function (stockId, price) {
    document.getElementById("stockPrice").innerText = price;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
