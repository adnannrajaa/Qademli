"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notification").build();



connection.on("Notify", function (ApplicantName, GoalName, GoalImage) {
    var result = ApplicantName + " send application for the " + GoalName
    console.log(ApplicantName, GoalName, GoalImage);
    console.log(result);
    $.notify(result, "info");
});

connection.start().then(function () {
    console.log("start");
}).catch(function (err) {
    return console.error(err.toString());
});

