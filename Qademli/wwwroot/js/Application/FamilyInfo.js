var Id = null;
$(() => {
    Id = GetUserId();
    $('#ParentPassport').prop("readonly", true);
    $('#FatherCivilIDFront').prop("readonly", true);
    $('#FatherCivilIDBack').prop("readonly", true);
    $("#MotherCivilIDFront").prop("readonly", true);
    $("#MotherCivilIDBack").prop("readonly", true);
    $("#SpouseCivilIDFront").prop("readonly", true);

    $('#SpouseCivilIDBack').prop("readonly", true);
    $("#SpousePassport").prop("readonly", true);
    $('#CompanionPassport').prop("readonly", true);
    $('#CompanionI20').prop("readonly", true);
    LoadFamilyInfo(Id)

})

$.validator.addMethod("invalidContact", (value) => {
    let contact = value
    var regexPattern = new RegExp(/^\d{4}[- ]?\d{7}$/);    // regular expression pattern
    let isValid = regexPattern.test(contact);
    if (!isValid) {
        return false;
    }
    return true;
});


$('#tabs-icons-text-3 form').validate({
    rules: {
        ParentPassport: "required",
        ParentMobileNo: {
            required: true,
            invalidContact: true
        },
        FatherCivilIDFront: {
            required: true
        },
        FatherCivilIDBack: "required",
        MotherCivilIDFront: "required",
        MotherCivilIDBack: "required",
        SpouseCivilIDFront: "required",

        SpouseCivilIDBack: "required",
        SpousePassport: "required",
        FriendInUS: "required",
        FamilyMemberInUS: "required",
        FamilyMemberUSCitizen: "required",
        FamilyMemberImmigrant: "required",
        FamilyMemberRole: "required",

        CollegeUniversity: "required",
        Major: "required",
        OrganizationName: "required",
        MonthlySalary: "required",
        Currency: "required",
        Position: "required",
        CompanionPassport: "required",

        CompanionI20: "required",
        FriendMobileNo: {
            invalidContact: true
        },

    },
    messages: {
        ParentPassport: "Parent Passport is required",
        ParentMobileNo: {
            required: "Parent mobile no is required",
            invalidContact: "Please enter valid mobile mobile no"
        },
        FatherCivilIDFront: {
            required: "Father Civil ID Front is required"
        },
        FatherCivilIDBack: "Father Civil ID Back is required",
        MotherCivilIDFront: "Mother Civil ID Front is required",
        MotherCivilIDBack: "Mother Civil ID Back is required",
        SpouseCivilIDFront: "Spouse Civil ID Front is required",

        SpouseCivilIDBack: "Spouse Civil ID Back is required",
        SpousePassport: "Spouse Passport is required",
        FriendInUS: "Do you have any friend in Us",
        FamilyMemberInUS: "Do you have any Family member in Us",
        FamilyMemberUSCitizen: "Are your family member is US citizen",
        FamilyMemberImmigrant: "Are your family member is immigrant",
        FamilyMemberRole: "Family Member Role is required",

        CollegeUniversity: "College University is required",
        Major: "Major is required",
        OrganizationName: "Organization Name is required",
        MonthlySalary: "Monthly Salary is required",
        Currency: "Currency is required",
        Position: "Position is required",
        FriendMobileNo: {
            invalidContact: "Please enter valid mobile number"
        },
        CompanionPassport: "Companion Passport is required",

        CompanionI20: "Companion I20 is required",
    },
    submitHandler: function (form) {
        var form = new FormData();
        form.append("UserId", Id);
        form.append("ParentPassport", $('#ParentPassport1')[0].files[0]);
        form.append("ParentMobileNo", $("#ParentMobileNo").val());
        form.append("FatherCivilIDFront", $('#FatherCivilIDFront1')[0].files[0]);
        form.append("FatherCivilIDBack", $('#FatherCivilIDBack1')[0].files[0]);
        form.append("MotherCivilIDFront", $("#MotherCivilIDFront1")[0].files[0]);
        form.append("MotherCivilIDBack", $("#MotherCivilIDBack1")[0].files[0]);
        form.append("SpouseCivilIDFront", $("#SpouseCivilIDFront1")[0].files[0]);

        form.append("SpouseCivilIDBack", $('#SpouseCivilIDBack1')[0].files[0]);
        form.append("SpousePassport", $("#SpousePassport1")[0].files[0]);
        form.append("FriendInUS", $('#FriendInUS').val());
        form.append("FriendAddress", $("#FriendAddress").val());
        form.append("FriendMobileNo", $("#FriendMobileNo").val());
        form.append("FamilyMemberInUS", $("#FamilyMemberInUS").val());
        form.append("FamilyMemberFirstName", $("#FamilyMemberFirstName").val());

        form.append("FamilyMemberLastName", $("#FamilyMemberLastName").val());
        form.append("FamilyMemberRelation", $("#FamilyMemberRelation").val());
        form.append("FamilyMemberUSCitizen", $("#FamilyMemberUSCitizen").val());
        form.append("FamilyMemberImmigrant", $("#FamilyMemberImmigrant").val());
        form.append("FamilyMemberRole", $("#FamilyMemberRole").val());
        form.append("CollegeUniversity", $("#CollegeUniversity").val());
        form.append("Major", $("#Major").val());

        form.append("OrganizationName", $("#OrganizationName").val());
        form.append("MonthlySalary", $("#MonthlySalary").val());
        form.append("Currency", $("#Currency").val());
        form.append("Position", $("#Position").val());
        form.append("CompanionPassport", $('#CompanionPassport1')[0].files[0]);
        form.append("CompanionI20", $('#CompanionI201')[0].files[0]);
        let xhr = SendAjaxRequestWithFormData("/api/UserFamilyDetail", "POST", form);
            if (xhr.status === 200) {
                $.notify("Family Information Added Successfully", "success");
            } else if (xhr.status === 204) {
                $.notify("Family Information Updated Successfully", "success");

            } else {
                $.notify("Your Request Return " + xhr, "error")
            }
    }
});

let LoadFamilyInfo = (id) => {
    let xhr = SendAjaxRequestForGet("/api/UserFamilyDetail/" + id)
    if (xhr !== "Not Found")
        LoadFamilyInfoIntoTextBox(xhr.responseJSON)
}
let LoadFamilyInfoIntoTextBox = (data) => {
    $('#ParentPassport').val(data.ParentPassport)
    $("#ParentMobileNo").val(data.ParentMobileNo)
    $('#FatherCivilIDFront').val(data.FatherCivilIDFront)
    $('#FatherCivilIDBack').val(data.FatherCivilIDBack)
    $("#MotherCivilIDFront").val(data.MotherCivilIDFront)
    $("#MotherCivilIDBack").val(data.MotherCivilIDBack)
    $("#SpouseCivilIDFront").val(data.SpouseCivilIDFront)

    $('#SpouseCivilIDBack').val(data.SpouseCivilIDBack)
    $("#SpousePassport").val(data.SpousePassport)
    if (data.FriendInUS == true)
        $('#FriendInUS').val("true")
    else
        $('#FriendInUS').val("false")

    $("#FriendAddress").val(data.FriendAddress)
    $("#FriendMobileNo").val(data.FriendMobileNo)

    if (data.FamilyMemberInUS == true)
        $("#FamilyMemberInUS").val("true")
    else
        $("#FamilyMemberInUS").val("false")

    $("#FamilyMemberFirstName").val(data.FamilyMemberFirstName)

    $("#FamilyMemberLastName").val(data.FamilyMemberLastName)
    $("#FamilyMemberRelation").val(data.FamilyMemberRelation)

    if (data.FamilyMemberUSCitizen == true)
        $("#FamilyMemberUSCitizen").val("true")
    else
        $("#FamilyMemberUSCitizen").val("false")

    if (data.FamilyMemberImmigrant == true)
        $("#FamilyMemberImmigrant").val("true")
    else
        $("#FamilyMemberImmigrant").val("false")


    $("#FamilyMemberRole").val(data.FamilyMemberRole)
    $("#CollegeUniversity").val(data.CollegeUniversity)
    $("#Major").val(data.Major)

    $("#OrganizationName").val(data.OrganizationName)
    $("#MonthlySalary").val(data.MonthlySalary)
    $("#Currency").val(data.Currency)
    $("#Position").val(data.Position)
    $('#CompanionPassport').val(data.CompanionPassport)
    $('#CompanionI20').val(data.CompanionI20)
}