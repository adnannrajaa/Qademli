var Id = null;
$(() => {
    Id = GetUserId();

    $('#MinistryofHigherEducationDoc').prop("readonly", true);
    $('#FinancialSupport').prop("readonly", true);
    $('#HighSchoolDegree').prop("readonly", true);
    LoadEductionInfo(Id)
  
})

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

        let xhr = SendAjaxRequestWithFormData("/api/UserEducationDetail", "POST", form)
        if (xhr.status === 200) {
            $.notify("Eduction Information Added Successfully", "success");
        } else if (xhr.status === 204) {
            $.notify("Eduction Information Updated Successfully", "success");
        } else {
            $.notify("Your Request Return " + xhr, "error")
        }
    }
});
let LoadEductionInfo = (id) => {
    let xhr = SendAjaxRequestForGet("/api/UserEducationDetail/" + id)
    if (xhr !== "Not Found")
        LoadEductionInfoIntoTextBox(xhr.responseJSON)
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