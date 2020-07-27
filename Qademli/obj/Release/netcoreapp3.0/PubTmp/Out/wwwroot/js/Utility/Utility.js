//............................................................................Send AjaxRequest Without Object/parameter
//...................................................Recommanded for Get Request
SendAjaxRequestForGet = (ApiUrl) => {
    let Error = null;
    let Success = null;

    let ajaxConfig = {
        url: ApiUrl,
        type: "GET",
        timeout: 0,
        async: false,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
        },
        success: (XMLHttpRequest, textStatus, xhr) => {
            Success = xhr;
        },
        error: (XMLHttpRequest, textStatus, xhr) => {
            Error = xhr;
        }
    }

    $.ajax(ajaxConfig)
    if (Success != null) {
        if (Success == "Unauthorized") {
            
           return window.location.replace("/Account/Login/Unauthorize")
        }
        return Success;
    } else {
        if (Error == "Unauthorized") {
            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Error;
    }

}

//............................................................................Send AjaxRequest With Object/parameter
//...................................................Recommanded for all other requests excepts Get Request


SendAjaxRequestWithObject = (ApiUrl, RequestType, Object) => {
    let Error = null;
    let Success = null;

    let ajaxConfig = {
        url: ApiUrl,
        type: RequestType,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: JSON.stringify(Object),
        async: false,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
        },
        success: (XMLHttpRequest, textStatus, xhr) => {
            Success = xhr;
        },
        error: (XMLHttpRequest, textStatus, xhr) => {
            Error = xhr;
        }
    }

    $.ajax(ajaxConfig)
    if (Success != null) {
        if (Success == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Success;
    } else {
        if (Error == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Error;
    }

}


//............................................................................Send AjaxRequest With Object/parameter
//...................................................Recommanded for all From and other requests excepts Get Request


SendAjaxRequestWithFormData = (ApiUrl, RequestType, Object) => {
    let Error = null;
    let Success = null;

    let ajaxConfig = {
        url: ApiUrl,
        type: RequestType,
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        data: Object,
        async: false,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
        },
        success: (XMLHttpRequest, textStatus, xhr) => {
            Success = xhr;
        },
        error: (XMLHttpRequest, textStatus, xhr) => {
            Error = xhr;
        }
    }

    $.ajax(ajaxConfig)
    if (Success != null) {
        if (Success == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Success;
    } else {
        if (Error == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Error;
    }

}


//............................................................................Send AjaxRequest For Delete
//...................................................Recommanded for Delete Only


SendAjaxRequestForDelete = (ApiUrl) => {
    let Error = null;
    let Success = null;

    let ajaxConfig = {
        url: ApiUrl,
        type: "DELETE",
        async:false,
        timeout: 0,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
        },
        success: (XMLHttpRequest, textStatus, xhr) => {
            Success = xhr;
        },
        error: (XMLHttpRequest, textStatus, xhr) => {
            Error = xhr;
        }
    }

    $.ajax(ajaxConfig)
    if (Success != null) {
        if (Success == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Success;
    } else {
        if (Error == "Unauthorized") {

            return window.location.replace("/Account/Login/Unauthorize")
        }
        return Error;
    }

}

//............................................................................Get User Id From Token

let GetUserId = () => {
    let UserId = null;
    UserId = parseJwt(localStorage.getItem("token"));
    if (UserId != null) {
        return UserId.unique_name;
    }
    return UserId;
}

let GetUserRole = () => {
    let UserRole = null;
    UserRole = parseJwt(localStorage.getItem("token"));
    if (UserRole != null) {
        return UserRole.role;
    }
    return UserRole;
}

let IsUserLoggedIn = () => {
    let UserStatus = false;
    let loggedInUserId = null;
    loggedInUserId = parseJwt(localStorage.getItem("token"));
    if (loggedInUserId != false) {
        UserStatus = true;
    }
    return UserStatus;
}

function parseJwt(token) {
    if (token == null || token == 'null') {

        return false;
    }
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


