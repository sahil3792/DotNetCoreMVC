$(document).ready(function () {
    GetEmpData();
});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
    $('#Id').hide();
    $('#Updatebtn').hide();
    $('#savebtn').show();

});

$('#closebtn').click(function () {
    $('#exampleModal').modal('hide');
});

function clear() {
    $('#Name').val("");
    $('#Email').val("");
    $('#Salary').val("");
}


$('#savebtn').click(function () {
    //var obj = {
    //    name: $('#Name').val(),
    //    name: $('#Email').val(),
    //    name: $('#Salary').val()
    //}

    var obj = $('#myform').serialize();

    $.ajax({
        url: '/Ajax/AddEmp',
        type: 'Post',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj,
        success: function () {
            alert("Emp Added Successfully");
            $('#exampleModal').modal('hide');
            clear();
            GetEmpData();
        },
        error: function () {
            alert("Something went Wrong");
        }
    });
});


function GetEmpData() {
    $.ajax({
        url: '/Ajax/GetEmp',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8;',
        success: function (result, status, xhr) {
            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.email + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td><input type='button' class='btn btn-sm btn-danger' value='Delete' onclick='delEmp("+item.id+")'/>|<input type='button' class='btn btn-sm btn-success' value='Edit' onclick='EditEmp(" + item.id +")'/></td>"
                obj += "</tr>";
            });
            $("#tabledata").html(obj);
        },
        error: function () {
            alert("Data not Found")
        }
    });
}

function delEmp(id) {
    if (confirm("Are you Sure?")) {
        $.ajax({
            url: '/Ajax/DeleteEmp?eid=' + id,
            success: function () {
                alert("emp Deleted Successfully");
                GetEmpData();
            },
            error: function () {
                alert("Something went Wrong Please try again");
            }
        })
    }
}

function EditEmp(id) {
    $.ajax({
        url: '/Ajax/EditEmp?eid='+id,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8;',
        success: function (response) {
            $('#exampleModal').modal('show');
            $('#Updatebtn').show();
            $('#savebtn').hide();
            $('#Id').show();
            $('Empid').show();
            $('#Empid').val(response.id);
            $('#Name').val(response.name);
            $('#Email').val(response.email);
            $('#Salary').val(response.salary);
           

            

        },
        error: function () {
            alert("Could save the changes try again")
        }
    })
}

$('#Updatebtn').click(function () {

    var obj = $('#myform').serialize();
    $.ajax({
        url: '/Ajax/UpdateEmp',
        type: 'Post',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj,
        success: function () {
            alert("Emp Updated Successfully");
            $('#exampleModal').modal('hide');
            clear();
            GetEmpData();
        },
        error: function () {
            alert("Something went Wrong");
        }

    })
});


function SearchEmpData() {
    var sdata = $('#search').val();
    $.ajax({
        url: '/Ajax/SearchEmpData?sdata='+sdata,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8',
        success: function (result, status, xhr) {
            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.email + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td><input type='button' class='btn btn-sm btn-danger' value='Delete' onclick='delEmp(" + item.id + ")'/>|<input type='button' class='btn btn-sm btn-success' value='Edit' onclick='EditEmp(" + item.id + ")'/></td>"
                obj += "</tr>";
            });
            $("#tabledata").html(obj);
        },
        error: function () {
            alert("Data not Found")
        }
    });

    
}

