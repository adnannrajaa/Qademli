
$(() => {

    LoadPersonalInfo()
    LoadEductionInfo()
    LoadFamilyInfo()
    LoadVisaInfo()


})

let LoadPersonalInfo = () => {
    var settings = {
        "url": "/api/UserPersonalDetail/" + $("#UserApplicationDetailID").text(),
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
    };

    $.ajax(settings).done(function (response) {
        LoadPersonalInfoIntoTextBox(response)
    });
}
let LoadFamilyInfo = () => {
    var settings = {
        "url": "/api/UserFamilyDetail/" + $("#UserApplicationDetailID").text(),
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
    };

    $.ajax(settings).done(function (response) {
        LoadFamilyInfoIntoTextBox(response)
    });
}
let LoadVisaInfo = () => {
    var settings = {
        "url": "/api/UserVisaDetail/" + $("#UserApplicationDetailID").text(),
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
let LoadEductionInfo = () => {
    var settings = {
        "url": "/api/UserEducationDetail/" + $("#UserApplicationDetailID").text(),
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

let LoadPersonalInfoIntoTextBox = (data) => {
    $('#maritalstatus').val(data.MaritalStatus)
    $('#civilidfront').text(data.CivilIDFront).on("click", () => { previewImage(data.CivilIDFront,"civilidfront")})
    $('#civilidback').text(data.CivilIDBack).on("click", () => { previewImage(data.CivilIDBack,"civilidback") })
    $('#mobileno').text(data.MobileNumber)
    $('#instagram').text(data.Instagram)
    $('#twitter').text(data.Twitter)
    $('#facebook').text(data.Facebook)
    $('#address').text(data.Address)

    $('#usaaddress').text(data.USAddress)
    $('#title').text(data.Title)
    $('#gender').val(data.Gender)
    $('#language').val(data.FirstLanguage)
    $('#nationality').val(data.Nationality)
    $('#dob').text(moment(data.DOB).format("MMM DD YYYY"))
    $('#identificationdoc').text(data.IdentificationDoc).on("click", () => { previewImage(data.IdentificationDoc,"identificationdoc") })
    $('#identificationdocno').text(data.IdentificationDocNo)
    $('#town').val(data.TownCity)
    $('#state').val(data.StateCountry)
    $('#postalcode').text(data.ZipPostalCode)
    $('#telephonenumber').text(data.TelephoneNumber)
    $('#occupationsector').text(data.OccupationSector)
    $('#occupationlevel').text(data.OccupationLevel)
}


let LoadEductionInfoIntoTextBox = (data) => {
    $('#HighSchoolDegree').text(data.HighSchoolDegree).on("click", () => { previewImage(data.HighSchoolDegree, "HighSchoolDegree") })
    $("#ILETSorTOEFL").text(data.ILETSorTOEFL)
    $('#MinistryofHigherEducationDoc').text(data.MinistryofHigherEducationDoc).on("click", () => { previewImage(data.MinistryofHigherEducationDoc, "MinistryofHigherEducationDoc") })
    $('#FinancialSupport').text(data.FinancialSupport).on("click", () => { previewImage(data.FinancialSupport, "FinancialSupport") })
    $("#UnitsPassed").text(data.UnitsPassed)
    $("#LastDegree").text(data.LastDegree)
    $("#SchoolName").text(data.SchoolName)
}

let LoadFamilyInfoIntoTextBox = (data) => {
    $('#ParentPassport').text(data.ParentPassport).on("click", () => { previewImage(data.ParentPassport, "ParentPassport") })
    $("#ParentMobileNo").text(data.ParentMobileNo)
    $('#FatherCivilIDFront').text(data.FatherCivilIDFront).on("click", () => { previewImage(data.FatherCivilIDFront, "FatherCivilIDFront") })
    $('#FatherCivilIDBack').text(data.FatherCivilIDBack).on("click", () => { previewImage(data.FatherCivilIDBack, "FatherCivilIDBack") })
    $("#MotherCivilIDFront").text(data.MotherCivilIDFront).on("click", () => { previewImage(data.MotherCivilIDFront, "MotherCivilIDFront") })
    $("#MotherCivilIDBack").text(data.MotherCivilIDBack).on("click", () => { previewImage(data.MotherCivilIDBack, "MotherCivilIDBack") })
    $("#SpouseCivilIDFront").text(data.SpouseCivilIDFront).on("click", () => { previewImage(data.SpouseCivilIDFront, "SpouseCivilIDFront") })

    $('#SpouseCivilIDBack').text(data.SpouseCivilIDBack).on("click", () => { previewImage(data.SpouseCivilIDBack, "SpouseCivilIDBack") })
    $("#SpousePassport").text(data.SpousePassport).on("click", () => { previewImage(data.SpousePassport, "SpousePassport") })
    if (data.FriendInUS == true)
        $('#FriendInUS').val("true")
    else
        $('#FriendInUS').val("false")

    $("#FriendAddress").text(data.FriendAddress)
    $("#FriendMobileNo").text(data.FriendMobileNo)

    if (data.FamilyMemberInUS == true)
        $("#FamilyMemberInUS").val("true")
    else
        $("#FamilyMemberInUS").val("false")

    $("#FamilyMemberFirstName").text(data.FamilyMemberFirstName)

    $("#FamilyMemberLastName").text(data.FamilyMemberLastName)
    $("#FamilyMemberRelation").text(data.FamilyMemberRelation)

    if (data.FamilyMemberUSCitizen == true)
        $("#FamilyMemberUSCitizen").val("true")
    else
        $("#FamilyMemberUSCitizen").val("false")

    if (data.FamilyMemberImmigrant == true)
        $("#FamilyMemberImmigrant").val("true")
    else
        $("#FamilyMemberImmigrant").val("false")


    $("#FamilyMemberRole").text(data.FamilyMemberRole)
    $("#CollegeUniversity").text(data.CollegeUniversity)
    $("#Major").text(data.Major)

    $("#OrganizationName").text(data.OrganizationName)
    $("#MonthlySalary").text(data.MonthlySalary)
    $("#Currency").text(data.Currency)
    $("#Position").text(data.Position)
    $('#CompanionPassport').text(data.CompanionPassport).on("click", () => { previewImage(data.CompanionPassport, "CompanionPassport") })
    $('#CompanionI20').text(data.CompanionI20).on("click", () => { previewImage(data.CompanionI20, "CompanionI20") })
}

let LoadVisaInfoIntoTextBox = (data) => {
    $('#Passport').text(data.Passport).on("click", () => { previewImage(data.Passport, "Passport") })
    $('#VisaPermit').text(data.VisaPermit).on("click", () => { previewImage(data.VisaPermit, "VisaPermit") })
    $('#Recommendations').text(data.Recommendations).on("click", () => { previewImage(data.Recommendations, "Recommendations") })
    $('#LastVisitToUS').text(moment(data.LastVisitToUS).format("MMM DD YYYY"))
    $('#DaysSpentInUS').text(data.DaysSpentInUS)
    $('#CountriesVisted').text(data.CountriesVisted)
    $('#I20Doc').text(data.I20Doc).on("click", () => { previewImage(data.I20Doc, "I20Doc") })
    if (data.Employee == true)
        $('#Employee').val("true")
    else
        $('#Employee').val("false")


    $('#OrganizationName').text(data.OrganizationName)
    $('#DateTo').text(moment(data.DateTo).format("MMM DD YYYY"))
    $('#DateFrom').text(moment(data.DateFrom).format("MMM DD YYYY"))
    $('#TravelDate').text(moment(data.TravelDate).format("MMM DD YYYY"))
    if (data.VisaPermitRejected == true)
        $('#VisaPermitRejected').val("true")
    else
        $('#VisaPermitRejected').val("false")

    $('#ReasonOfRejection').text(data.ReasonOfRejection)
}

let previewImage = (url, id) => {
    $("#"+id).attr("href",url)
    console.log(url)
}