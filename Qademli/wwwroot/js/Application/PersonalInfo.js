$(() => {
    $('#identificationdoc').prop("readonly", true);
    $('#civilidfront').prop("readonly", true);
    $('#civilidback').prop("readonly", true);

    let Id = GetUserId();
    LoadPersonalInfo(Id)
})

$('#dob').datepicker({
    language: 'en',
    autoClose: true,
    dateFormat: "M dd, yyyy"

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

//Add Personal Info
$('#tabs-icons-text-1 form').validate({
    rules: {
        title: "required",
        address: "required",
        usaaddress: {
            required: true
        },
        mobileno: {
            required: true,
            invalidContact: true
        },
        dob: {
            required: true,
            date: true
        },
        postcode: "required",
        instagram: "required",
        twitter: "required",
        facebook: "required",
        identificationdocno: "required",
        identificationdoc: {

            required: true
        },

        civilidfront: "required",
        civilidback: "required",
        gender: "required",
        nationality: "required",
        language: "required",
        maritalstatus: "required",
        town: "required",
        state: "required",
        occupationsector: "required",
        occupationlevel: "required",
    },
    messages: {
        title: "Title is required",
        address: "Address is required",
        usaaddress: {
            required: "USA Address is required"
        },
        mobileno: {
            required: "Mobile no is required",
            invalidContact: "Please enter valid mobile number"
        },
        dob: {
            required: "Date of birth required",
            date: "Please enter valid date of birth"
        },
        postcode: "Post code is required",
        instagram: "Instagram Id is required",
        twitter: "Twitter id is required",
        facebook: "Facebook id is required",
        identificationdocno: "Identification document no is required.",
        identificationdoc: "Identification document is required.",
        civilidfront: "Civil id front image is required",
        civilidback: "Civil id back image is required",
        gender: "Please select gender",
        nationality: "Please select nationality",
        language: "Please select language",
        maritalstatus: "Please select marital status",
        town: "Please select town",
        state: "Please select state",
        occupationsector: "Occupation sector is required",
        occupationlevel: "Occupation level is required",
    },
    submitHandler: function (form) {
        var form = new FormData();
        form.append("UserId", Id);

        form.append("MaritalStatus", $('#maritalstatus').val());
        form.append("CivilIDFront", $('#civilidfront1')[0].files[0]);
        form.append("CivilIDBack", $('#civilidback1')[0].files[0]);
        form.append("MobileNumber", $('#mobileno').val());
        form.append("Instagram", $('#instagram').val());
        form.append("Twitter", $('#twitter').val());
        form.append("Facebook", $('#facebook').val());
        form.append("Address", $('#address').val());

        form.append("USAddress", $('#usaaddress').val());
        form.append("Title", $('#title').val());
        form.append("Gender", $('#gender').val());
        form.append("FirstLanguage", $('#language').val());
        form.append("Nationality", $('#nationality').val());
        form.append("DOB", $('#dob').val());
        form.append("IdentificationDoc", $('#identificationdoc1')[0].files[0]);
        form.append("IdentificationDocNo", $('#identificationdocno').val());
        form.append("TownCity", $('#town').val());
        form.append("StateCountry", $('#state').val());
        form.append("ZipPostalCode", $('#postalcode').val());
        form.append("TelephoneNumber", $('#telephonenumber').val());
        form.append("OccupationSector", $('#occupationsector').val());
        form.append("OccupationLevel", $('#occupationlevel').val());

        let xhr = SendAjaxRequestWithFormData("/api/UserPersonalDetail", "POST", form)
        if (xhr.status === 200) {
            $.notify("Personal Information Added Successfully", "success");
        } else if (xhr.status === 204) {
            $.notify("Personal Information Updated Successfully", "success");

        } else {
            $.notify("Your Request Return " + xhr, "error")
        }
    }
});
let LoadPersonalInfo = (id) => {
    let xhr = SendAjaxRequestForGet("/api/UserPersonalDetail/" + id)
    if (xhr !== "Not Found")
        LoadPersonalInfoIntoTextBox(xhr.responseJSON, id)
}

let LoadPersonalInfoIntoTextBox = (data, UserId) => {
    $("#personalInfoUserID").text(UserId);
    $('#maritalstatus').val(data.MaritalStatus)
    $('#civilidfront').val(data.CivilIDFront)
    $('#civilidback').val(data.CivilIDBack)

    $('#mobileno').val(data.MobileNumber)
    $('#instagram').val(data.Instagram)
    $('#twitter').val(data.Twitter)
    $('#facebook').val(data.Facebook)
    $('#address').val(data.Address)

    $('#usaaddress').val(data.USAddress)
    $('#title').val(data.Title)
    $('#gender').val(data.Gender)
    $('#language').val(data.FirstLanguage)
    $('#nationality').val(data.Nationality)
    $('#dob').val(moment(data.DOB).format("MMM DD YYYY"))
    $('#identificationdoc').val(data.IdentificationDoc)
    $('#identificationdocno').val(data.IdentificationDocNo)
    $('#town').val(data.TownCity)
    $('#state').val(data.StateCountry)
    $('#postalcode').val(data.ZipPostalCode)
    $('#telephonenumber').val(data.TelephoneNumber)
    $('#occupationsector').val(data.OccupationSector)
    $('#occupationlevel').val(data.OccupationLevel)
}