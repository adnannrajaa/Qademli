let userRole = null;
$(() => {
    userRole = GetUserRole();
    if (userRole != "Admin") {
        window.location.replace("/Account/Login/Unauthorize")
    }
    LoadData();
    $("#GoalPropLi").attr("class", "active");

});


var LoadData = () => {
    let xhr = SendAjaxRequestForGet("/api/GoalProperty")
        if (xhr.status === 200) {
            $('#tBody').empty();
            let data = xhr.responseJSON;
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${item.Name}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${item.ID}','${item.Name}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${item.ID}','${item.Name}')">Delete</button>
                                </td>
                            </tr>`;
                    $('#tBody').append(str);
                });

            }
        } else {
             $.notify("Your Request Return " + xhr, "Error");
        }
}

var openModal = () => {
    $('#myModal').modal('show');
}



var editModal = (id, name) => {
    $('#myModal2').modal('show');
    var str = `
                <input id="goalid" value="${id}" hidden/>
                    
                    <div class="form-group">
                        <label for="exampleInputEmail1">Name</label>
                        <input type="text" value="${name}" class="form-control" id="name2" name="name2" />
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);

}

var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    let xhr = SendAjaxRequestForDelete("/api/GoalProperty/" + id)
    if (xhr.status === 200) {
        LoadData(localStorage.getItem("token"));
        $('#myModal3').modal('hide');
        $.notify("Goal Property Deleted Successfully", "success")
    } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}


$(() => {
    //Add Goal
    $('#myModal form').validate({
        rules: {
            name1: "required"
        },
        messages: {
            name1: "Name is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Name", $('#name1').val());
            let xhr = SendAjaxRequestWithFormData("/api/GoalProperty","POST",form)
          
                if (xhr.status === 200) {
                    $('#myModal form').trigger("reset");

                    LoadData(localStorage.getItem("token"));
                    $('#myModal').modal('hide');
                    $.notify("Goal Property Added Successfully", "success")

                } else if (xhr.status === 204)
                {
                    $('#myModal form').trigger("reset");

                    LoadData(localStorage.getItem("token"));
                    $('#myModal').modal('hide');
                    $.notify("Goal Property Already Exist", "warn")
                }else {
                    $('#myModal form').trigger("reset");

                    $.notify("Your Request Return " + xhr, "Error")
                }

        }
    });

    //Edit Goal Property
    $('#myModal2 form').validate({
        rules: {
            name2: "required"
        },
        messages: {
            name2: "Name is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Name", $('#name2').val());
            form.append("ID", $('#goalid').val());
            let xhr = SendAjaxRequestWithFormData("/api/GoalProperty/" + $('#goalid').val(), "PUT", form)
                if (xhr.status === 204) {
                    LoadData(localStorage.getItem("token"));
                    $('#myModal2').modal('hide');
                    $.notify("Goal Property Updated Successfully", "success")

                } else {
                     $.notify("Your Request Return " + xhr, "Error");
                }

        }
    });
})