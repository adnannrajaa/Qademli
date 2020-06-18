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

    LoadEductionInfo(Id)
    //Add Eduction Info
    $('#tabs-icons-text-2 form').validate({
        rules: {
            HighSchoolDegree: "required",
            ILETSorTOEFL: "required",
            MinistryofHigherEducationDoc: {
                required: true
            },
            FinancialSupport: "required",
            UnitsPassed: "required",
            LastDegree: "required",
            SchoolName: "required",
           
        },
        messages: {
            HighSchoolDegree: "Please provide High School Degree",
            ILETSorTOEFL: "ILETS or TOEFL is required",
            MinistryofHigherEducationDoc: {
                required: "Ministry of Higher Education Document is required"
            },
            FinancialSupport: "Financial Support document is required",
            UnitsPassed: "Units passed is required",
            LastDegree: "Last Degree is required",
            SchoolName: "School Name is required",
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("UserId", Id);
            form.append("HighSchoolDegree", $('#HighSchoolDegree1')[0].files[0]);
            form.append("ILETSorTOEFL", $("#ILETSorTOEFL").val());
            form.append("MinistryofHigherEducationDoc", $('#MinistryofHigherEducationDoc1')[0].files[0]);
            form.append("FinancialSupport", $('#FinancialSupport1')[0].files[0]);
            form.append("UnitsPassed", $("#UnitsPassed").val());
            form.append("LastDegree", $("#LastDegree").val());
            form.append("SchoolName", $("#SchoolName").val());


           
            var settings = {
                "url": "/api/UserEducationDetail",
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
                    $.notify("Eduction Information Added Successfully", "success");
                } else if (xhr.status === 204) {
                    $.notify("Eduction Information Updated Successfully", "success");
                }else {
                    $.notify("Your Request Return " + xhr.status, "error")
                }
            });

        }
    });
})

 
let LoadEductionInfo = (id) => {
    var settings = {
        "url": "/api/UserEducationDetail/" + id,
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
    };

    $.ajax(settings).done(function (response) {
        LoadEductionInfoIntoTextBox(response)
    });
}
let LoadEductionInfoIntoTextBox = (data) => {
    $('#HighSchoolDegree').val(data.HighSchoolDegree)  
    $("#ILETSorTOEFL").val(data.ILETSorTOEFL) 
    $('#MinistryofHigherEducationDoc').val(data.MinistryofHigherEducationDoc) 
    $('#FinancialSupport').val(data.FinancialSupport) 
    $("#UnitsPassed").val(data.UnitsPassed) 
    $("#LastDegree").val(data.LastDegree)
    $("#SchoolName").val(data.SchoolName) 
}