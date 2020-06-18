let ApplicationSubmitted = true;
var isCompleted=false;

let GetApplictionFormStatus = (UserId) => {

    var settings = {
        "url": "/api/ApplictionFormStatus/" + UserId,
        "method": "GET",
        "timeout": 0,
        "async": false,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            isCompleted = true;
        } else {
            isCompleted = false;

        }
    });

    return isCompleted;
}

let isApplicationSubmitted =(UserId, GoalId)=>{
    var settings = {
        "url": "/api/ApplictionFormStatus/" + UserId + "/" + GoalId,
        "method": "GET",
        "timeout": 0,
        "async": false,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
      
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            ApplicationSubmitted = false;
        } else {
            ApplicationSubmitted = true;

        }
    });
    return ApplicationSubmitted;
}