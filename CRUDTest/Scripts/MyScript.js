$(document).ready(function () {

    $("#btnSave").click(function () {
        var data = {
            FName: $("#txtFName").val(),
            LName: $("#txtLName").val(),
            Phone: $("#txtPhone").val(),
            Address: $("#txtAddress").val()
        }
        $.ajax({
            type: 'POST',
            url: '/Employees/Save',
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.status == true) {
                    alert('Successful save');
                    clear();
                    window.location.href = "Index";
                }
                else {
                    alert('First Name is required');
                    $("#txtFName").val("");
                }
            }
        });
    });

    $("#btnUpdate").click(function () {
        var data = {
            Id: $("#EtxtId").val(),
            FName: $("#EtxtFName").val(),
            LName: $("#EtxtLName").val(),
            Phone: $("#EtxtPhone").val(),
            Address: $("#EtxtAddress").val()
        }
        $.ajax({
            type: 'POST',
            url: '/Employees/Update',
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.status == true) {
                    alert('Successful update');
                    clear();
                    window.location.href = "../Index/";
                }
                else {
                    alert('First Name is required');
                    $("#EtxtFName").val("");
                }
            }
        });
    });

    $("#btnDelete").click(function () {
        var data = {
            Id: $("#DtxtId").val()
        }
        $.ajax({
            type: 'POST',
            url: '/Employees/Del',
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.status == true) {
                    alert('Successful delete');
                    clear();
                    window.location.href = "../Index/";
                }
                else {
                    alert('Error');
                    clear();
                    window.location.href = "../Index/";
                }
            }
        });
    });


    $("#btnCancel").click(function () {
        clear();
        window.location.href = "Index";
    });
    $("#UbtnCancel").click(function () {
        clear();
        window.location.href = "../Index";
    });
    $("#DbtnCancel").click(function () {
        clear();
        window.location.href = "../Index";
    });
});

function clear() {
    $("#txtFName").val("");
    $("#txtLName").val("");
    $("#txtPhone").val("");
    $("#txtAddress").val("");
    $('#btnSave').val("Save");
    $("#hdnEId").val(0);
}