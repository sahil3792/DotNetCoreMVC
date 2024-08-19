$(document).ready(function () {

});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
});

$('#closebtn').click(function () {
    $('#exampleModal').modal('hide');
});

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
        },
        error: function () {
            alert("Something went Wrong");
        }
    })
})