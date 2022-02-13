////$(function () {    $("#modal input[name='Email']").change(checkEmail);
////    function checkEmail(email) {
        
////        if (email != "") {
////            if (!validateEmail(email)) {
////                $.ajax({
////                    type: "POST",
////                    url: "Users/CheckEmail",
////                    data: email,
////                    success: function (data) {
////                        alert(data)
////                        if (data == "true") {
////                            $("#eEmail").html("Email đã tồn tại");
////                        } else {
////                            $("#eEmail").html("");
////                        }
////                    }
                
////                });
////            }
////        }
////    }
////    function validateEmail($email) {
////        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
////        return emailReg.test($email);
////    }     
   
////});
function showModal(type) {
    $("#modal").modal('show');
}
function readURL(input, img) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById("Img").src = e.target.result;
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#ful").change(function () {
    readURL(this, '#img');
})
function createOrUpdate() {
    var userName = $("#modal input[name='UserName']").val();
    var email = $("#modal input[name='Email']").val();
    var passwordHash = $("#modal input[name='PasswordHash']").val();
    var address = $("#modal input[name='Address']").val();
    var phoneNumber = $("#modal input[name='PhoneNumber']").val();
    var name = $("#modal input[name='Name']").val();
    var birthday = $("#modal input[name='Birthday']").val();
    var gender = $("#modal input[name='Gender']:checked").val();
    var files = $('#ful').prop("files");
    ful = new FormData();
    ful.append("ful", files[0]);
    var urlImg = files[0].name;
    var model = {
        UserName: userName,
        Email: email,
        PasswordHash: passwordHash,
        Address: address,
        PhoneNumber: phoneNumber,
        Name: name,
        Birthday: birthday,
        Gender: gender,
        UrlImg: urlImg
    }
    console.log(model)
    $.ajax({
        type: "POST",
        url: "Users/Create",
        data: model,
        success: function (data) {
            $("#formCreate").html(data);
            alert($("#create input[name='error']").val())
            if ($("#create input[name='error']").val() == null) {
                $("#modal").modal("hide");
                location.reload();
                
            } 
        }
    });
   // uploadFile();
}
function uploadFile(ful) {
    $.ajax({
        type: "POST",
        url: "Users/UploadFile",
        data: ful,
        cache: false,
        contentType: false,
        processData: false,
        success: function () {

        }
    });
    
}