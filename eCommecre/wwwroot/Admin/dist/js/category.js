$(function () {
    var btn = $("#btnCreate").click(Create);
    function Create() {

        var url = "Category/Create";

        var antiForgeryToken = $("#modalCreate input[name='__RequestVerificationToken']").val();

        var name = $("#modalCreate input[name = 'Name']").val();


        var model = {
            __RequestVerificationToken: antiForgeryToken,
            Name: name
        };

        $.ajax({
            type: "POST",
            url: url,
            data: model,
            success: function (data) {

                var parsed = $.parseHTML(data);
            
                var hasErrors = $(parsed).find("input[name='error']").val();
                $("#create").html(data);
                if (hasErrors == "true") {
            
                    btn = $("#btnCreate").click(Create);
                    var form = $("#create");
                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                if (hasErrors == "false") {
                    $("#modalCreate").modal('hide');
                    location.reload();
                }
                $("#create").html(data);
                btn = $("#btnCreate").click(Create);
                var form = $("#create");
                $(form).removeData("validator");
                $(form).removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse(form);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }

    var btnEdit = $("#btnEdit").click(Edit);
    function Edit() {
        var url = "Category/Edit";
        var antiForgeryToken = $("#modalEdit input[name='__RequestVerificationToken']").val();
        var name = $("#modalEdit input[name='Name']").val();
        var id = $("#modalEdit input[name='Id']").val();
        var model = {
            __RequestVerificationToken: antiForgeryToken,
            Id: id,
            Name:name
        }
        $.ajax({
            type: 'POST',
            url: url,
            data: model,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='error']").val();
                $("#edit").html(data);
                if (hasErrors == "false") {
                    $("#modalEdit").modal('hide');
                    location.reload();
                }
                btnEdit = $("#btnEdit").click(Edit);
                var form = $("#edit");
                $(form).removeData("validator");
                $(form).removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse(form);            }
        });
    }
});
function GetCategory(Id) {
    $.ajax({
        type: "GET",
        url: 'Category/GetCategory',
        data: { Id: Id },
        success: function (data) {
            $("#modalEdit").modal('show');
            $("#modalEdit input[name='Id']").val(data.id);
            $("#modalEdit input[name='Name']").val(data.name);
        }
    });
}