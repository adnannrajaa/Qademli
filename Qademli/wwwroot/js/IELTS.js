let UserId = null;
let sortByNameStatus = "none";
let filterData = [];
let tempHeading = null;
let propHeading = null;
$(() => {

    LoadIELTS();

    ViewAllIELTS()
    UserId = GetUserId();

});

let LoadIELTS = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=3")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
            if (data.length > 0) {
                $('#IELTSList').empty();
                $.each(data, function (index, item) {
                    var str = `<div class="col-md-3" onclick="LoadIELTSDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',2)">
                            <div class="single_item">
                                <a class="text-blue">
                                    <img src="${item.Image}" alt="uni-logo" class="uni_logo" style="width: 218px;height: 197px;">
                                    <h4 class="my-0 text-blue">${item.Name}</h4>
                                </a>
                            </div>
                        </div>`;
                    $('#IELTSList').append(str);
                    if (index === 3) {
                        return false; // breaks
                    }
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "error");
        }
   
}

let ViewAllIELTS = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=3")

    if (xhr.status === 200) {
        let data = xhr.responseJSON;
        filterData = data;
        loadIELTSData(data);

    } else {
        // $.notify("Your Request Return " + xhr, "error");
        console.log("Your Request Return " + xhr);
    }

}
let loadIELTSData = (data) => {
    if (data.length > 0) {
        $('#viewAllIELTS').empty();

        $.each(data, function (index, item) {
            var str = `<div class="col-md-6 mb-4" onclick="LoadIELTSDetail('${UserId}','${item.Currency}','${item.Fee}',${item.ID},'${item.Image}','${item.Name}',2)">
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
            $('#viewAllIELTS').append(str);

        });

    }
}

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
    loadIELTSData(filterData)
}
let LoadIELTSDetail = (UserId, Currency, Fee, GoalId, imageSrc, name, TopicId) => {
    $("#detail_item1").removeClass("d-none");
    $("#headingIELTS").addClass("d-none");
    $("#IELTSList").addClass("d-none");
    $('#viewAllIELTS').addClass("d-none");
    var str = ` <div >
                            <div class="row logo_section">
                                <div class="col-md-12">
                                    <a href="/User/Home/IELTS" class="back_btn pos_abs text-blue"><i class="fas fa-chevron-left clr_inhert"></i> Back</a>
                                    <img src="${imageSrc}" style="width: 247px;height: 230px;" id="detail-Image" alt="uni logo" class="uni_loggo mx-auto mb-4">
                                    <h4 class="uni_name fw_600 m-0" id="detail-name">${name}</h4>
                            <p class="location" id="detail-location"></p>
                                   
                                </div>
                            </div>
                            <div class="row mx-auto w_1000 text-left mt-4" id="IELTSProp">
                               
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
    LoadIELTSProp(GoalId)

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



$("#backButton").on("click", () => {
    console.log("Button Click");
    $("#detail_item1").addClass("d-none");
    $("#headingIELTS").removeClass("d-none");
    $("#IELTSList").removeClass("d-none");
})


let LoadIELTSProp = (GoalId) => {
    let xhr = SendAjaxRequestForGet("/api/ViewGoalProperty/" + GoalId)
        if (xhr.status === 200) {
            var result = xhr.responseJSON;;
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
        $("#IELTSProp").append(str);
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
                $("#IELTSProp").append(str);
            } else {
                let str = `  <p class="major_subjetcs uni_data">
                    ${Name}
            </p>`
                $("#headingValue2").append(str)

            }
        } else {

            if (equalStrings(tempHeading, HeadingName) == false) {
                let head = ` <h5 class="label my-0">${HeadingName}</h5>`

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
                } else {
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
$("#lIELTSMore").on("click", () => {
    $("#headingIELTS h3").text("IELTS Tests")
    $("#IELTSSort").css("display", "inline");
    $("#IELTSfilter").css("display", "inline");
})

