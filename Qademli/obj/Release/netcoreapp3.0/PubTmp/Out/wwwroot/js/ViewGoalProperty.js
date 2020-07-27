let userRole = null;
$(() => {
    userRole = GetUserRole();
    if (userRole != "Admin") {
        window.location.replace("/Account/Login/Unauthorize")
    }
    LoadData();
    LoadProperty("property", "");
    $("#GoalLi").attr("class", "active");
});

var LoadProperty = (id, propertyid) => {
    $.ajax({
        type: "GET",
        url: "/api/GoalProperty",
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
            $("#" + id).val(propertyid);
        }
    });
}

$("#property").on("change", () => {
    loadHeadings($("#property").val(), "heading","HeadingDDL","")
})

let loadHeadings = (GoalPropId,id,ddl,value) => {
    $.ajax({
        type: "GET",
        url: "/api/GoalPropertyHeadings/" + GoalPropId,
        data: "{}",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            if (data.length > 0) {
                var s = '<option value="">Select Heading</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].HeadingId + '">' + data[i].Name + '</option>';
                }
                $("#" + id).html(s);
                $("#" + id).val(value);
                $("#"+ddl).removeAttr("hidden");
            } else {
                $("#" + id).html('');
                $("#" + ddl).attr("hidden",true);
            }
            
        }
    });
}

var LoadData = () => {
    let xhr = SendAjaxRequestForGet("/api/ViewGoalProperty/" + $('#goalid').data('goalid'))
    if (xhr.status === 200) {
        var result = xhr.responseJSON.Data;
        if (result.length > 0) {
            loadResultData(result)
        } else {
            clearTable();
        }
    } else {
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
    const { GoalId, GoalPropertyID, ID, Name, GoalProperty, HeadingName, HeadingId } = row;
  
    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${GoalProperty.Name}</td>
                                <td class="align-middle text-center">${HeadingName}</td>

                                <td class="align-middle text-center">${Name}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${ID}','${GoalPropertyID}','${GoalId}','${Name}','${HeadingId}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${ID}','${Name}')">Delete</button>
                                
</td>
                            </tr>`;
    $('#tBody').append(str);




}

var openModal = () => {
    $("#HeadingDDL").attr("hidden", true);
    $('#myModal').modal('show');
}

var editModal = (id, GoalPropertyID, GoalDetailID, Name,HeadingID) => {
    $('#myModal2').modal('show');
    if (HeadingID != 1) {
        loadHeadings(GoalPropertyID, "heading2", "HeadingDDL2", HeadingID)

    }
    var str = `
                <input id="propertyid" value="${id}" data-goaldetailid="${GoalDetailID}" data-GoalPropValueId="${id}" hidden/>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Property</label>
                        <select class="form-control" id="property2" name="property2"></select>
                    </div>
                        <div class="form-group" id="HeadingDDL2" hidden>
                        <label for="exampleInputEmail1">Heading</label>
                        <select class="form-control" id="heading2" name="heading2"></select>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Value</label>
                        <input type="text" class="form-control" id="value2" value="${Name}" name="value2" />
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);

    LoadProperty("property2", GoalPropertyID);
    $('#property2').prop('disabled', true);


}



var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    let xhr = SendAjaxRequestForDelete("/api/GoalPropertyValue/" + id)
    if (xhr.status === 200) {
        LoadData();
        $('#myModal3').modal('hide');
        $.notify("Goal Property Value deleted Successfully", "success");

    } else {
        $.notify("Your Request Return " + xhr.status, "Error");
    }
}


$(() => {
    //Add Goal
    $('#myModal form').validate({
        rules: {
            property: "required",
            heading:"required",
            value: "required"
        },
        messages: {
            property: "Choose Property",
            heading:"Choose Heading",
            value: "Value is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            let headingId = 1; if ($('#heading').val() > 1) { headingId = $('#heading').val() };
            form.append("GoalHeadingID", headingId);

            form.append("GoalPropertyID", $('#property').val());
            form.append("GoalID", $('#goalid').data('goalid'));
            form.append("Name", $('#value').val());
            let xhr = SendAjaxRequestWithFormData("/api/GoalPropertyValue","POST",form)
                if (xhr.status === 200) {
                    $("#myModal form").trigger("reset");
                    LoadData();
                    $('#myModal').modal('hide');
                    $.notify("Goal Property Value Added Successfully", "success");
                } else if (xhr.status === 204)
                {
                    $("#myModal form").trigger("reset");
                    LoadData();
                    $('#myModal').modal('hide');
                    $.notify("Goal Property Value Already Exist", "warn");

                }
                else {
                     $.notify("Your Request Return " + xhr, "error");
                }
        }
    });

   //Edit Property
    $('#myModal2 form').validate({
        rules: {
            property2: "required",
            heading2: "required",
            value2: "required"
        },
        messages: {
            property2: "Choose Property",
            heading2: "Choose Heading",

            value2: "Value is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("GoalPropertyID", $('#property2').val());
            form.append("GoalID", $('#goalid').data('goalid'));
            let headingId = 1; if ($('#heading2').val() > 1) { headingId = $('#heading2').val() };
            form.append("GoalHeadingID", headingId);
            form.append("Name", $('#value2').val());
            form.append("ID", $('#propertyid').val());
            form.append("GoalDetailID", $('#propertyid').data('goaldetailid'));
            form.append("GoalPropValueId", $('#propertyid').data('GoalPropValueId'))
            let xhr = SendAjaxRequestWithFormData("/api/GoalPropertyValue/" + $('#propertyid').val(), "PUT", form)
                if (xhr.status === 204) {
                    LoadData();
                    $('#myModal2').modal('hide');
                    $.notify("Goal Property Value Updated Successfully", "success");

                } else {
                     $.notify("Your Request Return " + xhr, "Error");
                }
        }
    });
   
})