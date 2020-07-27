let userRole = null;
$(() => {
    userRole = GetUserRole();
    if (userRole != "Admin") {
        window.location.replace("/Account/Login/Unauthorize")
    }
    LoadData();
    LoadTopic("topic1", "");
    $("#GoalLi").attr("class", "active");

});

var LoadTopic = (id, topicid) => {
    $.ajax({
        type: "GET",
        url: "/api/Topic",
        data: "{}",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            var s = '<option value="">Select Topic</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
            }
            $("#" + id).html(s);
            $("#" + id).val(topicid);
        }
    });
}

var LoadData = () => {
    let xhr = SendAjaxRequestForGet("/api/Goal/GetGoalListByTopicID?id=2")
    if (xhr.status === 200) {
        let data = xhr.responseJSON;
        if (data.length > 0) {
            $('#tBody').empty();

            $.each(data, function (index, item) {
                var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${item.Name}</td>
                                <td class="align-middle text-center"><img src="${item.Image}" width="75" height="75"/></td>
                                <td class="align-middle text-center" hidden>${item.TopicName}</td>
                                <td class="align-middle text-center">${item.Fee} ${item.Currency}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${item.ID}','${item.Name}','${item.TopicID}','${item.Fee}','${item.Currency}','${item.Image}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${item.ID}','${item.Name}')">Delete</button>
                                    <a class="btn btn-info" href="/Admin/Dashboard/ViewGoalProperty?goalId=${item.ID}&goal=${item.Name}">Properties</a>
                                </td>
                            </tr>`;
                $('#tBody').append(str);
            });

        }
    } else {
        $.notify("Your Request Return " + xhr, "error")
    }
}

var openModal = () => {
    $('#myModal').modal('show');
}



var editModal = (id, name, topicid, fee, currency, image) => {

    $('#myModal2').modal('show');
    var str = `
                <input id="goalid" value="${id}" hidden/>
                    <div class="form-group" hidden>
                        <label for="exampleInputEmail1">Topic</label>
                        <select class="form-control" id="topic2" name="topic2"></select>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Name</label>
                        <input type="text" value="${name}" class="form-control" id="name2" name="name2" />
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Image</label>
                        <div class="file-upload-inner file-upload-inner-right ts-forms">
                            <div class="input append-small-btn">
                                <div class="file-button">
                                    <input type="file" id="image2" onchange="document.getElementById('image3').value = this.value;">
                                </div>
                                <input name="image3" id="image3" type="text" class="form-control" value="${image}">

                            </div>
                        </div>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Fee</label>
                        <input type="number" value="${fee}" class="form-control" id="fee2" name="fee2">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Currency</label>
                        <input type="text" value="${currency}" class="form-control" id="currency2" name="currency2">
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);
    LoadTopic("topic2", topicid);

}

var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    let xhr = SendAjaxRequestForDelete("/api/Goal/" + id)
    if (xhr.status === 200) {
        LoadData();
        $('#myModal3').modal('hide');
        $.notify("University Deleted Successfully", "success")
    }
    else if (xhr.status === 404) {
        LoadData();
        $('#myModal3').modal('hide');
        $.notify("University Id not found. Unable to delete " + xhr.status, "error");

    } else {
        LoadData();
        $('#myModal3').modal('hide');
        $.notify("Your Request Return " + xhr, "error");
    }
}

//Add Goal
$('#myModal form').validate({
    rules: {
        //topic1: "required",
        name1: "required",
        image: {
            required: true
        },
        fee1: "required",
        currency1: "required",
    },
    messages: {
        //topic1: "Choose Topic",
        name1: "Name is required",
        image: {
            required: "Image is Required"
        },
        fee1: "Fee is required",
        currency1: "Currency is required",
    },
    submitHandler: function (form) {
        $("#btnAddGoal").attr("disabled", true);
        var form = new FormData();
        form.append("TopicID", 2);
        form.append("Name", $('#name1').val());
        form.append("Image", $('input[type=file]')[0].files[0]);
        form.append("Fee", $('#fee1').val());
        form.append("Currency", $('#currency1').val());

        var xhr = SendAjaxRequestWithFormData("/api/Goal", "POST", form)
        if (xhr.status === 200) {
            LoadData();
            $('#myModal').modal('hide');
            $.notify("University Added Successfully", "success")
            $("#myModal form").trigger("reset");
            $("#btnAddGoal").removeAttr("disabled");
        } else {
            LoadData();
            $('#myModal').modal('hide');
            $("#myModal form").trigger("reset");
            $("#btnAddGoal").removeAttr("disabled");
            $.notify("Your Request Return " + xhr, "error")
        }
    }
});

//Edit Goal
$('#myModal2 form').validate({
    rules: {
        //topic2: "required",
        name2: "required",
        image3: "required",
        fee2: "required",
        currency2: "required",
    },
    messages: {
        //topic2: "Choose Topic",
        name2: "Name is required",
        fee2: "Fee is required",
        image3: "Image is required",
        currency2: "Currency is required",
    },
    submitHandler: function (form) {
        var form = new FormData();
        form.append("TopicID", 2);
        form.append("Name", $('#name2').val());
        form.append("Image", $('#image2')[0].files[0]);
        form.append("Fee", $('#fee2').val());
        form.append("Currency", $('#currency2').val());

        var xhr = SendAjaxRequestWithFormData("/api/Goal/" + $('#goalid').val(), "PUT", form)
        console.log(xhr)
        if (xhr.status === 200) {
            LoadData();
            $('#myModal2').modal('hide');
            $.notify("University Updated Successfully", "success")

        } else if (xhr.status === 404) {
            LoadData();
            $('#myModal2').modal('hide');
            $.notify("University Id not found. Unable to update", "error")
        } else {
            $.notify("Your Request Return " + xhr, "error");
        }


    }
});
