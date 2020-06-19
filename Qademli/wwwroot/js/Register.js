$('#myForm').submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        firstName: "required",
        inputEmail: {
            required: true,
            email: true
        },
        password: "required",
        confirmPassword: { equalTo: "#password" }
    },
    messages: {
        firstName: "First Name is required",
        inputEmail: {
            required: "Email is required",
            email: "Enter valid email address"
        },
        password: "Password is required",
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
            "url": "/api/Register",
            "method": "POST",
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
            if (xhr.status == 200) {
                $.notify("Your Account Created Successfully", "success");
                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
                window.setTimeout(function () {
                    window.location.replace("/Account/Login/Login");
                }, 2000);
            } else if (xhr.status == 204) {
                $.notify("Email Already Exist", "warn");

                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
            } else {
                $.notify("Your Request Return " + xhr.status, "Error");
                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
            }
        });
    }
});
