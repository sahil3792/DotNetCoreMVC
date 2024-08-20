$(document).ready(function () {

});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
});

$('#closebtn').click(function () {
    $('#exampleModal').modal('hide');
});

function clear() {
    $('#Name').val("");
    $('Email').val("");
    $('Salary').val("");
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
        },
        error: function () {
            alert("Something went Wrong");
        }
    })
})