$(function () {

    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {

        var url = "UserAuth/Login";

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#signin").html(data);

                    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

                    var form = $("#UserLoginForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    location.href = 'Home/Index';

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
    var userRegisterButton = $("#UserLoginModal button[name='btnRegister']").click(onUserRegisterClick);

    function onUserRegisterClick() {

        var url = "UserAuth/Register";

        var antiForgeryToken = $("#register input[name='__RequestVerificationToken']").val();

        var email = $("#register input[name = 'Email']").val();
        var password = $("#register input[name = 'Password']").val();
        var confirmPassword = $("#register input[name = 'ConfirmPassword']").val();
        var userName = $("#register input[name = 'UserName']").val();
        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            UserName: userName
       //     RememberMe: rememberMe
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegisterInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#register").html(data);

                    userLoginButton = $("#UserLoginModal button[name='btnRegister']").click(onUserRegisterClick);

                    var form = $("#register");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    location.reload();

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});
function AddToCart(id) {
    $.ajax({
        type: 'POST',
        url: 'Home/AddToCart',
        data: {id:id},
        success: function (data) {
            $("#cartModal").html(data);
            toastr.options = {
                "closebutton": true,
                "debug": false,
                "newestontop": false,
                "progressbar": false,
                "positionclass": "toast-bottom-left",
                "preventduplicates": false,
                "onclick": null,
                "showduration": "300",
                "hideduration": "1000",
                "timeout": "5000",
                "extendedtimeout": "1000",
                "showeasing": "swing",
                "hideeasing": "linear",
                "showmethod": "fadein",
                "hidemethod": "fadeout"
            }
            command: toastr["success"]("thêm vào giỏ hàng thành công.")
        }
    });
}
function RemoveProductFromCart(id) {
    $.ajax({
        type: "POST",
        url: "Home/RemoveProductFromCart",
        data: { id: id },
        success: function(data){
            $("#cartModal").html(data);
            toastr.options = {
                "closebutton": true,
                "debug": false,
                "newestontop": false,
                "progressbar": false,
                "positionclass": "toast-bottom-left",
                "preventduplicates": false,
                "onclick": null,
                "showduration": "300",
                "hideduration": "1000",
                "timeout": "5000",
                "extendedtimeout": "1000",
                "showeasing": "swing",
                "hideeasing": "linear",
                "showmethod": "fadein",
                "hidemethod": "fadeout"
            }
            command: toastr["success"]("Xoa khoi giỏ hàng thành công.")

        }
    })
}
function minusQuantity(id) {
    $.ajax({
        url: 'MinusQuantity',
        type: 'POST',
        data: { id: id },
        success: function (data) {
            $('#ViewCart').html(data);
        }
    });
}
function plusQuantity(id) {
    $.ajax({
        url: 'PlusQuantity',
        type: 'POST',
        data: { id: id },
        success: function (data) {
            $('#ViewCart').html(data);
        }
    });
}
$(function () {
    var projects = [
        {
            value: "jquery",
            label: "jQuery",
            desc: "the write less, do more, JavaScript library",
            icon: "jquery_32x32.png"
        },
        {
            value: "jquery-ui",
            label: "jQuery UI",
            desc: "the official user interface library for jQuery",
            icon: "jqueryui_32x32.png"
        },
        {
            value: "sizzlejs",
            label: "Sizzle JS",
            desc: "a pure-JavaScript CSS selector engine",
            icon: "sizzlejs_32x32.png"
        }
    ];

    $("#project").autocomplete({
        minLength: 0,
        source: projects,
        focus: function (event, ui) {
            $("#project").val(ui.item.label);
            return false;
        },
        select: function (event, ui) {
            $("#project").val(ui.item.label);
            $("#project-id").val(ui.item.value);
            $("#project-description").html(ui.item.desc);
            $("#project-icon").attr("src", "images/" + ui.item.icon);

            return false;
        }
    })
        .autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<div>" + item.label + "<br>" + item.desc + "</div>")
                .appendTo(ul);
        };
});