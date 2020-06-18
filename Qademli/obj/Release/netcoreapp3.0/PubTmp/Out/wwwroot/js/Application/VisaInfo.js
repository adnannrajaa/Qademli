$('#TravelDate,#DateFrom,#DateTo,#LastVisitToUS').datepicker({
    language: 'en',
    autoClose: true,
    dateFormat: "M dd, yyyy"

})
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};
var Id = parseJwt(localStorage.getItem("token"))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

$(() => {

    $('#tabs-icons-text-4 form').validate({
        rules: {
            Passport: "required",
            VisaPermit: "required",
            Recommendations: {
                required: true
            },
            LastVisitToUS: "required",
            DaysSpentInUS: "required",
            CountriesVisted: "required",
            I20Doc: "required",
            Employee: "required",
            TravelDate: "required",
            VisaPermitRejected: "required",
            LastVisitToUS: {
                date: true
            },
            DateFrom: {
                date: true
            },
            DateTo: {
                date: true
            },
            TravelDate: {
                date: true
            },
        },
        messages: {
            Passport: "Passport is required",
            VisaPermit: "Visa Permit required",
            Recommendations: {
                required: "Recommendations required"
            },
            LastVisitToUS: "Last Visit To US is required",
            DaysSpentInUS: "Days Spent In US required",
            CountriesVisted: "Countries Visted required",
            I20Doc: "I20 Document is required",
            Employee: "Are you employee",
            TravelDate: "Travel Date is required",
            VisaPermitRejected: "Did your Visa Permit Rejected",
            LastVisitToUS: {
                date: "Please enter valid date"
            },
            DateTo: {
                date: "Please enter valid date"
            },
            DateFrom: {
                date: "Please enter valid date"
            },
            TravelDate: {
                date: "Please enter valid date"
            },
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("UserId", Id);

            form.append("Passport", $('#Passport1')[0].files[0]);
            form.append("VisaPermit", $('#VisaPermit1')[0].files[0]);
            form.append("Recommendations", $('#Recommendations1')[0].files[0]);
            form.append("LastVisitToUS", $('#LastVisitToUS').val());
            form.append("DaysSpentInUS", $('#DaysSpentInUS').val());
            form.append("CountriesVisted", $('#CountriesVisted').val());
            form.append("I20Doc", $('#I20Doc1')[0].files[0]);
            form.append("Employee", $('#Employee').val());

            form.append("OrganizationName", $('#OrganizationName').val());
            form.append("DateTo", $('#DateTo').val());
            form.append("DateFrom", $('#DateFrom').val());
            form.append("TravelDate", $('#TravelDate').val());
            form.append("VisaPermitRejected", $('#VisaPermitRejected').val());
            form.append("ReasonOfRejection", $('#ReasonOfRejection').val());
          
            var settings = {
                "url": "/api/UserVisaDetail",
                "method": "POST",
                "timeout": 0,
                "processData": false,
                "mimeType": "multipart/form-data",
                "contentType": false,
                "data": form,
                "headers": {
                    "Authorization": "Bearer " + localStorage.getItem("token")
                }
            };

            $.ajax(settings).done(function (data, statusText, xhr) {
                if (xhr.status === 200) {
                    $.notify("Visa Information Added Successfully", "success");
                } else if (xhr.status === 204) {
                    $.notify("Visa Information Updated Successfully", "success");

                }else {
                    $.notify("Your Request Return " + xhr.status, "error")
                }
            });

           

        }
    });
    LoadVisaInfo(Id)
})

let LoadVisaInfo = (id) => {
    var settings = {
        "url": "/api/UserVisaDetail/" + id,
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
    };

    $.ajax(settings).done(function (response) {
        LoadVisaInfoIntoTextBox(response)
    });
}
let LoadVisaInfoIntoTextBox = (data) => {
    $('#Passport').val(data.Passport)
    $('#VisaPermit').val(data.VisaPermit)
    $('#Recommendations').val(data.Recommendations)
    $('#LastVisitToUS').val(moment(data.LastVisitToUS).format("MMM DD YYYY"))
    $('#DaysSpentInUS').val(data.DaysSpentInUS)
    $('#CountriesVisted').val(data.CountriesVisted)
    $('#I20Doc').val(data.I20Doc)
    if (data.Employee == true)
        $('#Employee').val("true")
    else
        $('#Employee').val("false")


    $('#OrganizationName').val(data.OrganizationName)
    $('#DateTo').val(moment(data.DateTo).format("MMM DD YYYY"))
    $('#DateFrom').val(moment(data.DateFrom).format("MMM DD YYYY"))
    $('#TravelDate').val(moment(data.TravelDate).format("MMM DD YYYY"))
    if (data.VisaPermitRejected == true)
        $('#VisaPermitRejected').val("true")
    else
        $('#VisaPermitRejected').val("false")

    $('#ReasonOfRejection').val(data.ReasonOfRejection)
}