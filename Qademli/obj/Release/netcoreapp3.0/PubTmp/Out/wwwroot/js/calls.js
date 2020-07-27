let userRole = null;
$(() => {
    userRole = GetUserRole();
    if (userRole != "Admin") {
        window.location.replace("/Account/Login/Unauthorize")
    }
    LoadData();
    LoadStatus();
    $("#CallLi").attr("class", "active");

});

var LoadStatus = () => {
    $.ajax({
        type: "GET",
        url: "/api/CallSchedules/CallStatus",
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
    let xhr = SendAjaxRequestForGet("/api/CallSchedules")
        if (xhr.status === 200) {
            $('#tBody').empty();
            let data = xhr.responseJSON;
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${item.FirstName} ${item.MiddleName} ${item.LastName}</td>
                                <td class="align-middle text-center">${item.Email}</td>
                                <td class="align-middle text-center">${item.Mobile}</td>
                                <td class="align-middle text-center">${moment(item.CallDate).format("DD MMM, YYYY")}</td>
                                <td class="align-middle text-center">${moment(item.CallDate).format("hh: mm a")}</td>

                <td class="align-middle text-center">${item.Name} </td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="updateModal('${item.CallId}','${item.FirstName} ${item.MiddleName} ${item.LastName}','${item.Email}','${item.Mobile}','${moment(item.CallDate).format("DD MMM, YYYY")}','${moment(item.CallDate).format("hh: mm a")}','${item.ID}')">Update</button>
</td>
                            </tr>`;
                    $('#tBody').append(str);
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "Error");
        }
}

let updateModal = (ID, Name,Email,Phone,CallDate,CallTime,Status) => {
    $('#myModal').modal('show');
    $('#name').text(Name);
    $('#email').text(Email);
    $('#phone').text(Phone);

    $('#callDate').text(CallDate);
    $('#callTime').text(CallTime);
    $('#status').val(Status);

    $('#Callid').val(ID);
}

$('#myModal form').validate({
        rules: {
            status: "required"
        },
        messages: {
            status: "Choose Status"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Status", $('#status').val());
            let xhr = SendAjaxRequestWithFormData("/api/CallSchedules/" + $('#Callid').val(),"PUT",form)

            if (xhr.status === 204) {
                $.notify("Call updated successfully", "success");
                    LoadData();
                    $('#myModal').modal('hide');
                } else {
                     $.notify("Your Request Return " + xhr, "error");
                }
        }
    });
