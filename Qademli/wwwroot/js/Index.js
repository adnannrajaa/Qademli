let UserId = null;
$(() => {
    UserId = GetUserId();
    LoadUniversities();

    LoadLearningCentres()

    ViewAllUnviersities()

    ViewAllLanguageCenter()

});

let LoadUniversities = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=2")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
            if (data.length > 0) {
                $('#uniList').empty();

                $.each(data, function (index, item) {
                    var str = `<div class="col-md-3" onclick="LoadUniversityDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',2)">
                            <div class="single_item">
                                <a class="text-blue">
                                    <img src="${item.Image}" alt="uni-logo" class="uni_logo" style="width: 218px;height: 197px;">
                                    <h4 class="my-0 text-blue">${item.Name}</h4>
                                </a>
                            </div>
                        </div>`;
                    $('#uniList').append(str);
                    if (index === 3) {
                        return false; // breaks
                    }
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "error");
        }
}

let ViewAllUnviersities = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=2")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
            if (data.length > 0) {
                $('#viewAllUni').empty();

                $.each(data, function (index, item) {
                    var str = `<div class="col-md-6 mb-4" onclick="LoadUniversityDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',2)">
                                <div class="single_item_details">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <a class="text-blue">
                                                <img src="${item.Image}" style="width: 218px;height: 134px;" alt="uni-logo">
                                            </a>
                                        </div>
                                        <div class="col-md-8">
                                            <a class="text-blue">
                                                <h4 class="mt-2 mb-3 fw_600 text-blue uni_name">${item.Name}</h4>
<p class="major">Fee: <span class="major_subject">${item.Fee} ${item.Currency}</span></p>
                                            <p class="m-0 loction"></p>
                                            </a>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>`;
                    $('#viewAllUni').append(str);


                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "error");
        }
}

let LoadUniversityDetail = (UserId, Currency, Fee, GoalId, imageSrc, name, TopicId) => {
    $("#detail_item1").removeClass("d-none");
    $("#headingUni").addClass("d-none");
    $("#uniList").addClass("d-none");
    $('#viewAllUni').addClass("d-none");
    var str = ` <div >
                            <div class="row logo_section">
                                <div class="col-md-12">
                                    <a href="/" class="back_btn pos_abs text-blue"><i class="fas fa-chevron-left clr_inhert"></i> Back</a>
                                    <img src="${imageSrc}" style="width: 247px;height: 230px;" id="detail-Image" alt="uni logo" class="uni_loggo mx-auto mb-4">
                                    <h4 class="uni_name fw_600 m-0" id="detail-name">${name}</h4>
                            <p class="location" id="detail-location"></p>
                                   
                                </div>
                            </div>
                            <div class="row mx-auto w_1000 text-left mt-4" id="LoadUniProp">
                               
                            </div>
                            <div class="row mx-auto w_1000 text-left mt-4" id="btn_wrap">
                                <div class="col-md-12">
                                  <a id="btn-applicationSubmit"  onclick="SubmitApplication(${UserId},'${Currency}',${Fee},${GoalId},${TopicId})" class="btn_user_action d-none">Apply For ${name}</a>
                                  <a id="btn-login" href="/Account/Login/Login" class="btn_user_action d-none">Login</a>
                                </div>
                            </div>
                        </div>`;
    $('#detail_item1').empty();
    $('#detail_item1').append(str);
    if (IsUserLoggedIn()) {
        $("#btn-applicationSubmit").removeClass("d-none")
    } else {
        $("#btn-login").removeClass("d-none")
    }
    LoadProp(GoalId)

}


let SubmitApplication = (UserId, Currency, Fee, GoalId, TopicId) => {
    if (GetApplictionFormStatus(UserId)) {
        if (!isApplicationSubmitted(UserId, GoalId)) {
            let obj = {
                UserID: UserId,
                GoalID: GoalId,
                StatusID: 4,
                TopicID: TopicId,
                Fee: Fee,
                Currency: Currency,
                Date: new Date()

            }
            let xhr = SendAjaxRequestWithObject("/api/Applications", "POST", JSON.stringify(obj))
            if (xhr.status === 200) {
                $.notify("Application Submitted Successfully", "success")
            } else {
                $.notify("Your Request Return " + xhr, "error");
            }
        } else {
            $.notify("Your application is already submitted.", "info");

        }
    } else {
        $.notify("Please complete your application form to procced.", "error");

    }
}

let LoadLearningCentres = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=1")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
            if (data.length > 0) {
                $('#languageList').empty();

                $.each(data, function (index, item) {
                    var str = `<div class="col-md-3" onclick="LoadLanguageCenterDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',1)">
                            <div class="single_item">
                                <a class="text-blue">
                                    <img src="${item.Image}" alt="uni-logo" class="uni_logo" style="width: 218px;height: 197px;">
                                    <h4 class="my-0 text-blue">${item.Name}</h4>
                                </a>
                            </div>
                        </div>`;
                    $('#languageList').append(str);
                    if (index === 3) {
                        return false; // breaks
                    }
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "error");
        }
}

let ViewAllLanguageCenter = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=1")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
            if (data.length > 0) {
                $('#viewAllLanguageCenter').empty();

                $.each(data, function (index, item) {
                    var str = `<div class="col-md-6 mb-4" onclick="LoadLanguageCenterDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',1)">
                                <div class="single_item_details">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <a class="text-blue">
                                                <img src="${item.Image}" style="width: 218px;height: 134px;" alt="uni-logo">
                                            </a>
                                        </div>
                                        <div class="col-md-8">
                                            <a class="text-blue">
                                                <h4 class="mt-2 mb-3 fw_600 text-blue uni_name">${item.Name}</h4>
                                            </a>
                                            <p class="major">Fee: <span class="major_subject">${item.Fee} ${item.Currency}</span></p>
                                            <p class="m-0 loction"></p>
                                        </div>
                                    </div>
                                </div>
                            </div>`;
                    $('#viewAllLanguageCenter').append(str);

                });

            }
        } else {
            $.notify("Your Request Return " + xhr, "error");
        }

}

let LoadLanguageCenterDetail = (UserId, Currency, Fee, GoalId, imageSrc, name, TopicId) => {
    //    $("#detail_item2").removeClass("d-none");
    //    $("#LanguageCenterHeading").addClass("d-none");
    //    $("#languageList").addClass("d-none");
    //    $('#viewAllLanguageCenter').addClass("d-none");
    //    var str = ` <div >
    //                            <div class="row logo_section">
    //                                <div class="col-md-12">
    //                                    <a href="/" class="back_btn pos_abs text-blue"><i class="fas fa-chevron-left clr_inhert"></i> Back</a>
    //                                    <img src=${imageSrc} style="max-width: 256px;max-height: 253px;" id="detail-Image" alt="uni logo" class="uni_loggo mx-auto mb-4">
    //                                    <h4 class="uni_name fw_600 m-0" id="detail-name">${name}</h4>
    //                                    <p class="location" id="detail-location"></p>
    //                                </div>
    //                            </div>
    //<div class="row mx-auto w_1000 text-left mt-4" id="LoadLanguageProp">

    //                            </div>

    //                            <div class="row mx-auto w_1000 text-left mt-4" id="btn_wrap">
    //                                <div class="col-md-12">
    //                                    <a onclick = "SubmitApplication(${UserId},'${Currency}',${Fee},${GoalId},${TopicId})" class="btn_user_action">Apply For ${name}</a>

    //                                </div>
    //                            </div>
    //                        </div>`;
    //    $('#detail_item2').empty();
    //    $('#detail_item2').append(str);
    //    LoadProp(GoalId,"LoadLanguageProp")
    window.location.replace('/User/Home/LearningCenter');

}
let bit = true;

$(".view_more_lang_centers").on("click", () => {
    if (bit == true) {
        $("#languageList").addClass("d-none")
        bit = false;
    } else if (bit == false) {
        $("#languageList").removeClass("d-none")
        bit = true;
    }
})



let LoadProp = (GoalId) => {
    let xhr = SendAjaxRequestForGet("/api/ViewGoalProperty/" + GoalId)
    if (xhr.status === 200) {
        var result = xhr.responseJSON;
            loadResultData(result.Data)

    } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}

let loadResultData = (arg_data) => {
    arg_data.map((row, index) => {
        renderRow(row, index)
    })

}

let renderRow = (row, index) => {
    const { GoalId, GoalPropertyID, ID, Name, GoalProperty } = row;

    var str = `
<div class="col-md-6 ">
                           <div class="row mb-2" >

                                <div class="col-md-5">
                                    <h5 class="label my-0">${GoalProperty.Name}:</h5>
                                </div>
                                <div class="col-md-7">
                                    <p class="major_subjetcs uni_data">
                                        ${Name}
                                    </p>
                                </div>
                            
                            
                        </div></div>


`
    $("#LoadUniProp").append(str);




}

$("#languageMore").on("click", () => {
    $("#LanguageCenterHeading h3").text("Language Center")
    $("#languageSort").css("display", "inline");
    $("#languageFilter").css("display","inline");

})
$("#languageLess").on("click", () => {
    $("#LanguageCenterHeading h3").text("Top Language Center")

    $("#languageSort").css("display", "none");
})

$("#UniMore").on("click", () => {
    $("#headingUni h3").text("Universities")
    $("#UniversitySort").css("display", "inline");
    $("#Universityfilter").css("display", "inline");
})
$("#UniLess").on("click", () => {
    $("#headingUni h3").text("Top Universities")

    $("#UniversitySort").css("display", "none");
})