let UserId = null;
let sortByNameStatus = "none";
let sortByLanguageNameStatus = "none";

let filterData = [];
let filterData2 = [];

$(() => {
    UserId = GetUserId();
    LoadUniversities();

    LoadLearningCentres()

    ViewAllUnviersities()

    ViewAllLanguageCenter()

});


let sortByName = () => {
    switch (sortByNameStatus) {
        case "none":
            sortByNameStatus = "asc"
            break
        case "asc":
            sortByNameStatus = "desc"
            break
        case "desc":
            sortByNameStatus = "asc"
            break
    }
    sortData("Name", sortByNameStatus)
}
let sortData = (column, type) => {
    filterData.sort((a, b) => {
        if (type == "asc") {
            return a[column] < b[column] ? 1 : -1
        } else return a[column] > b[column] ? 1 : -1
    })
    loadUniData(filterData)
}

let sortByLanguageName = () => {
    switch (sortByLanguageNameStatus) {
        case "none":
            sortByLanguageNameStatus = "asc"
            break
        case "asc":
            sortByLanguageNameStatus = "desc"
            break
        case "desc":
            sortByLanguageNameStatus = "asc"
            break
    }
    sortData2("Name", sortByLanguageNameStatus)
}
let sortData2 = (column, type) => {
    filterData2.sort((a, b) => {
        if (type == "asc") {
            return a[column] < b[column] ? 1 : -1
        } else return a[column] > b[column] ? 1 : -1
    })
    loadLanguageData(filterData2)
}

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

        } else {
            $('#uniList').empty();
            let str = `
                <div class="col-4  "></div>
 <div class="col-4 mb-4">
<h4>No University Found</h4>
</div>
 <div class="col-4"></div>
`
            $('#uniList').append(str);
        }
    } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}

let ViewAllUnviersities = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=2")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
        filterData = data;
        if (data.length > 0) {
            loadUniData(data)
        } else {
            $('#viewAllUni').empty();
            let str = `
                <div class="col-4 "></div>
 <div class="col-4 mb-5">
<h4>No University Found</h4>
</div>
 <div class="col-4"></div>
`
            $('#viewAllUni').append(str);

        }
    } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}

let loadUniData = (data) => {

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
        else {
            $('#languageList').empty();

            let str = `
                <div class="col-4 "></div>
 <div class="col-4 mb-5">
<h4>No Language Center Found</h4>
</div>
 <div class="col-4"></div>
`
            $('#languageList').append(str)

        }
    } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}

let ViewAllLanguageCenter = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=1")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
        filterData2 = data;
        loadLanguageData(data);

    } else {
       
        $.notify("Your Request Return " + xhr, "error");
    }

}

let loadLanguageData = (data) => {
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
    else {
        $('#viewAllLanguageCenter').empty();

        let str = `
                <div class="col-4 "></div>
 <div class="col-4 mb-5">
<h4>No Language Center Found</h4>
</div>
 <div class="col-4"></div>
`
        $('#viewAllLanguageCenter').append(str)
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
let tempHeading = null;
let propHeading = null;

let renderRow = (row, index) => {
    const { GoalId, GoalPropertyID, ID, Name, GoalProperty, HeadingName, HeadingId } = row;

    let newHeading = HeadingName
    
    if (HeadingName == "No Heading") {
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
    } else {
        if (!equalStrings(propHeading, GoalProperty.Name)) {
            propHeading = GoalProperty.Name
            if (equalStrings(tempHeading, HeadingName) == false) {
                tempHeading = HeadingName
                var str = `
                        <div class="col-md-6 ">
                           <div class="row mb-2" >

                                <div class="col-md-5">
                                    <h5 class="label my-0">${GoalProperty.Name}:</h5>
                                </div>
                                <div class="col-md-7" >
                                    <h5 class="label my-0">${HeadingName}</h5>
                                     <p class="major_subjetcs uni_data">${Name}</p> 
                                <div id="headingValue2"></div>

                                   
                                </div>
</div> <div class="row mb-2" >
<div class="col-md-5">
                                </div>
                                <div class="col-md-7" >
                                <div id="propHeadingName"></div>
                                <div id="headingValue"></div>
                                </div>
</div>

                            
                            
                        </div></div>


   
`
                $("#LoadUniProp").append(str);
            } else {
                let str = `  <p class="major_subjetcs uni_data">
                    ${Name}
            </p>`
                $("#headingValue2").append(str)

            }
        } else {

            if (equalStrings(tempHeading, HeadingName) == false) {
                let head =            ` <h5 class="label my-0">${HeadingName}</h5>`
                    
                $("#propHeadingName").append(head);
                let str = `  <p class="major_subjetcs uni_data">
                    ${Name}
            </p>`
                $("#headingValue").append(str)
            } else {
                let str = `  <p class="major_subjetcs uni_data">
                    ${Name}
            </p>`
                if (equalStrings(tempHeading, HeadingName)) {
                    $("#headingValue2").append(str)
                }else {
                    $("#headingValue").append(str)
                }

            }

        }

    }






}

let equalStrings = (tempHeading, HeadingName) => {
    let status = false;
    if (tempHeading != null) {
        if (tempHeading.length === HeadingName.length) {
            status = true;
        }
    }
    return status;
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

$("#Universityfilter").on("click", () => {
    $("#searchUni").removeAttr("hidden")
})
$("#searchUni").on("keyup", () => {
    applyFilter($("#searchUni").val())
})
let applyFilter = (input) => {
    let result = filterData.filter(x => (input == '' || x.Name.toLowerCase().includes(input.toLowerCase()))
    )
    loadUniData(result)
}

$("#languageFilter").on("click", () => {
    $("#searchLang").removeAttr("hidden")
})
$("#searchLang").on("keyup", () => {
    applyLangFilter($("#searchLang").val())
})
let applyLangFilter = (input) => {
    let result = filterData2.filter(x => (input == '' || x.Name.toLowerCase().includes(input.toLowerCase()))
    )
    loadLanguageData(result)
}