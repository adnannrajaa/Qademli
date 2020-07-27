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
    let xhr = SendAjaxRequestForGet("/api/GoalPropertyHeadings/" + $('#goalPropid').val())
    if (xhr.status === 200) {
        var result = xhr.responseJSON;
        if (result.length > 0) {
            loadResultData(result)
        } else {
            clearTable();
        }
    } else if (xhr=== "Not Found") { console.log(xhr) } else {
        $.notify("Your Request Return " + xhr, "error");
    }
}

let clearTable = () => {
    $("#tBody").empty()
}
let loadResultData = (arg_data) => {
    clearTable()
    arg_data.map((row, index) => {
        renderRow(row, index)
    })

}

let renderRow = (row, index) => {
    const { GoalPropId, HeadingId, Name } = row;
  
    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${Name}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${HeadingId}','${GoalPropId}','${Name}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${HeadingId}','${Name}')">Delete</button>
                                </td>
                            </tr>`;
    $('#tBody').append(str);




}

var openModal = () => {
    $('#myModal').modal('show');
}

var editModal = (HeadingId, GoalPropID, Name) => {
    $('#myModal2').modal('show');
    var str = `
                <input id="HeadingId" value="${HeadingId}" hidden/>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Heading</label>
                        <input type="text" class="form-control" id="headingName2" value="${Name}" name="headingName2" />
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editHeadingForm').html(str);
}



var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    let xhr = SendAjaxRequestForDelete("/api/GoalPropertyHeadings/" + id)
    if (xhr.status === 200) {
        LoadData();
        $('#myModal3').modal('hide');
        $.notify("Heading deleted Successfully", "success");

    } else {
        $.notify("Your Request Return " + xhr.status, "Error");
    }
}


$(() => {
    //Add Goal
    $('#myModal form').validate({
        rules: {
            headingName: "required"
        },
        messages: {
            headingName: "Heading Name is required",
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("GoalPropId", $('#goalPropid').val());
            form.append("Name", $('#headingName').val());
            let xhr = SendAjaxRequestWithFormData("/api/GoalPropertyHeadings","POST",form)
                if (xhr.status === 200) {
                    $("#myModal form").trigger("reset");
                    LoadData();
                    $('#myModal').modal('hide');
                    $.notify("Heading Added Successfully", "success");
                } else if (xhr.status === 204)
                {
                    $("#myModal form").trigger("reset");
                    LoadData();
                    $('#myModal').modal('hide');
                    $.notify("Heading Already Exist", "warn");

                }
                else {
                     $.notify("Your Request Return " + xhr, "error");
                }
        }
    });

   //Edit Property
    $('#myModal2 form').validate({
        rules: {
            headingName2: "required"
        },
        messages: {
            headingName2: "Heading is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Name", $('#headingName2').val());
            let xhr = SendAjaxRequestWithFormData("/api/GoalPropertyHeadings/" + $('#HeadingId').val(), "PUT", form)
                if (xhr.status === 204) {
                    LoadData();
                    $('#myModal2').modal('hide');
                    $.notify("Heading Updated Successfully", "success");

                } else {
                     $.notify("Your Request Return " + xhr, "Error");
                }
        }
    });
   
})