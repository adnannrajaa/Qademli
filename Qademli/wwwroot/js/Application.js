$(() => {
    LoadData();
    LoadStatus();
    $("#ApplicationLi").attr("class", "active");

});

var LoadStatus = () => {
    $.ajax({
        type: "GET",
        url: "/api/ApplicationStatus",
        data: "{}",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            var s = '<option value="">Select Status</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
            }
            $("#status").html(s);
        }
    });
}

var LoadData = () => {
    let xhr = SendAjaxRequestForGet("/api/Application")
        if (xhr.status === 200) {
            $('#tBody').empty();
            let data = xhr.responseJSON;
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${item.User}</td>
                                <td class="align-middle text-center">${item.Topic}</td>
                                <td class="align-middle text-center">${item.Goal}</td>
                                <td class="align-middle text-center">${item.Comment}</td>
                                <td class="align-middle text-center">${moment(item.Date).format("DD MMM, YYYY")}</td>
                                <td class="align-middle text-center">${item.Fee} ${item.Currency}</td>
                                <td class="align-middle text-center">${item.ApplicationStatus}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="updateModal('${item.ID}','${item.GoalID}','${item.StatusID}','${item.TopicID}','${item.UserID}','${item.Comment}','${item.Fee}','${item.Currency}')">Update</button>
                                    <a href="/Admin/Dashboard/ApplicationDetail?UserId=${item.UserID}" class="btn btn-success" >View</a>
                               
</td>
                            </tr>`;
                    $('#tBody').append(str);
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "Error");
        }
}

let updateModal = (ID, GoalID, StatusID, TopicID, UserID, Comment, Fee, Currency) => {
    $('#myModal').modal('show');
    $('#status').val(StatusID);
    $('#comment').val(Comment);
    $('#appid').val(ID);
}

$(() => {

    //Update Application
    $('#myModal form').validate({
        rules: {
            comment: "required",
            status: "required"
        },
        messages: {
            comment: "Choose Comment",
            status: "Choose Status"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Comment", $('#comment').val());
            form.append("StatusID", $('#status').val());
            let xhr = SendAjaxRequestWithFormData("/api/Application/" + $('#appid').val(),"PUT",form)

            if (xhr.status === 204) {
                $.notify("Application updated successfully", "success");
                    LoadData();
                    $('#myModal').modal('hide');
                } else {
                     $.notify("Your Request Return " + xhr, "error");
                }
        }
    });
})