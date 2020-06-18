$(() => {

    LoadIELTS();

    ViewAllIELTS()

});

let LoadIELTS = () => {
    var settings = {
        "url": "/api/Goal/GetGoalListByTopicID?id=3",
        "method": "GET",
        "timeout": 0,
       
        error: function (jqXHR, textStatus, errorThrown) {//  $.notify("Your Request Return " + xhr.status, "Error"); 
        }
    };
    var UserId = parseJwt(localStorage.getItem("token"))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
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
            // $.notify("Your Request Return " + xhr.status, "Error");
        }
    });
}

let ViewAllIELTS = () => {
    var settings = {
        "url": "/api/Goal/GetGoalListByTopicID?id=3",
        "method": "GET",
        "timeout": 0,
        
        error: function (jqXHR, textStatus, errorThrown) {//  $.notify("Your Request Return " + xhr.status, "Error"); 
        }
    };
    var UserId = parseJwt(localStorage.getItem("token"))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
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
        } else {
            // $.notify("Your Request Return " + xhr.status, "Error");
        }
    });
}

let LoadIELTSDetail = (UserId, Currency, Fee, GoalId, imageSrc, name, TopicId) => {
    LoadIELTSProp(GoalId)
    $("#detail_item1").removeClass("d-none");
    $("#headingIELTS").addClass("d-none");
    $("#IELTSList").addClass("d-none");
    $('#viewAllIELTS').addClass("d-none");
    var str = ` <div >
                            <div class="row logo_section">
                                <div class="col-md-12">
                                    <a href="/User/Home/IELTS" class="back_btn pos_abs text-blue"><i class="fas fa-chevron-left clr_inhert"></i> Back</a>
                                    <img src=${imageSrc} style="max-width: 256px;max-height: 253px;" id="detail-Image" alt="uni logo" class="uni_loggo mx-auto mb-4">
                                    <h4 class="uni_name fw_600 m-0" id="detail-name">${name}</h4>
                            <p class="location" id="detail-location"></p>
                                   
                                </div>
                            </div>
                            <div class="row mx-auto w_1000 text-left mt-4" id="LoadIELTSProp">
                               
                            </div>
                            <div class="row mx-auto w_1000 text-left mt-4" id="btn_wrap">
                                <div class="col-md-12">
                                    <a onclick = "SubmitApplication(${UserId},'${Currency}',${Fee},${GoalId},${TopicId})" class="btn_user_action">Apply For ${name}</a>
                                  
                                </div>
                            </div>
                        </div>`;
    $('#detail_item1').empty();
    $('#detail_item1').append(str);
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
            var settings = {
                "url": "/api/Applications",
                "method": "POST",
                "timeout": 0,

                "contentType": "application/json",
                "data": JSON.stringify(obj),
                "headers": {
                    "Authorization": "Bearer " + localStorage.getItem("token")
                }
            };

            $.ajax(settings).done(function (data, statusText, xhr) {
                if (xhr.status === 200) {
                    $.notify("Application Submitted Successfully","success")
                } else {
                    $.notify("Your Request Return " + xhr.status, "Error");
                }
            });
        } else {
            $.notify("Your application is already submitted.", "info");

        }
    } else {
        $.notify("Please complete your application form to procced.", "error");

    }
}

function parseJwt(token) {
    if (token == null || token == 'null') {

        return false;
    }
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


$("#backButton").on("click", () => {
    console.log("Button Click");
    $("#detail_item1").addClass("d-none");
    $("#headingIELTS").removeClass("d-none");
    $("#IELTSList").removeClass("d-none");
})


let LoadIELTSProp = (GoalId) => {
    var settings = {
        "url": "/api/ViewGoalProperty/" + GoalId,
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        error: function (jqXHR, textStatus, errorThrown) {  $.notify("Your Request Return " + xhr.status, "Error"); }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            var result = data.Data;
            if (result.length > 0) {
                loadResultData(result)
            } else {
                var str = `<tr >
                                <td </td>
                                <td> </td>
                                <td ></td>
                               <td ></td>
                                   
                            </tr>`;
                $('#tBody').append(str);
            }



        } else {
             $.notify("Your Request Return " + xhr.status, "Error");
        }
    });
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
    $("#LoadIELTSProp").append(str);




}
