var UserId = null;

$(() => {
    UserId = GetUserId();
    LoadUserData(UserId)
})

let LoadUserData = (UserId) => {
    var settings = {
        "url": "/api/Users/" + UserId,
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        error: function (jqXHR, textStatus, errorThrown) { $.notify("Your Request Return " + xhr.status, "error"); }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            console.log(data)
            RenderTextBoxes(data)
        } else {
            $.notify("Your Request Return " + xhr.status, "error");
        }
    });
}
let RenderTextBoxes = (data) => {
    const { ID, FirstName, MiddleName, LastName, Email, Password } = data
    $("#userid").text(ID)
    $('#firstName').val(FirstName);
    $('#inputEmail').val(Email);
    $('#middleName').val(MiddleName);
    $('#lastName').val(LastName);
}

$('#myForm').submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        firstName: "required",
        inputEmail: {
            required: true,
            email: true
        },
        confirmPassword: { equalTo: "#password" }
    },
    messages: {
        firstName: "First Name is required",
        inputEmail: {
            required: "Email is required",
            email: "Enter valid email address"
        },
        confirmPassword: "Password did not matched"
    },
    submitHandler: function (form) {
        $('#loginSpinner').show();
        $('#btnRegister').prop('disabled', true);
        var form = new FormData();
        form.append("FirstName", $('#firstName').val());
        form.append("MiddleName", $('#middleName').val());
        form.append("LastName", $('#lastName').val());
        form.append("Email", $('#inputEmail').val());
        form.append("Password", $('#password').val());

        var settings = {
            "url": "/api/Users/" + $("#userid").text(),
            "method": "PUT",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            statusCode: {
                404: function (response) {
                    $("#alert1Top").show();
                    window.setTimeout(function () {
                        $("#alert1Top").hide();
                    }, 2000);
                    $('#loginSpinner').hide();
                    $('#btnRegister').prop('disabled', false);
                }
            }
        };

        $.ajax(settings).done(function (data, statusText, xhr) {

            if (xhr.status === 200) {
                $.notify("Your Account Updated Successfully", "success");
                $("#alert1Top").show();
                window.setTimeout(function () {
                    $("#alert1Top").hide();
                }, 2000);
                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
            } else {
                $.notify("Your Request Return Status " + xhr.status,"error" );
                $("#alert1Top").show();
                window.setTimeout(function () {
                    $("#alert1Top").hide();
                }, 2000);
                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
            }
        });
    }
});
