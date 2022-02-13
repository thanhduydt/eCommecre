function showModalDelete(Id) {
    $("#modalDelete").modal('show');
    $("#IdDelete").val(Id);
}
$(function () {
    $("#modalDelete button[name='btnSave']").click(function () {
        var id = $("#IdDelete").val();
        console.log(id)
        $.ajax({
            type: "DELETE",
            url: "Product/DeleteProduct",
            data: { Id: id },
            success: function () {
                location.reload();
            }
        });
    });
});
function showModal(Id) {
    $("#modal").modal('show');
    if (Id != -1) {
        $("#exampleModalLabel").html("Cập nhật sản phẩm");
        GetProduct(Id);
    }
    else {
        $("#exampleModalLabel").html("Thêm sản phẩm mới");

    }
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
    var urlImg = this.files[0].name;
    var antiForgeryToken = $("#modalCreate input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: 'POST',
        url: 'Product/AddImg',
        data: { __RequestVerificationToken: antiForgeryToken, urlImg: urlImg },
        success: function (data) {
            $("#listImg").html(data);
        }

    });
})
function editItemInListImg(Id) {
    var id = "#" + Id;
    var order = $(id).val();
    var regex = /^[0-9]+$/;
    if (order.match(regex)) {
        $.ajax({
            type: "POST",
            url: "Product/EditListImg",
            data: { Id: Id, Order: order },
            success: function () {
                console.log("tc");
            }
        });
    } else {

    }
}
function deleteItemInListImg(Id) {
    $.ajax({
        type: "POST",
        url: "Product/DeleteItemInListImg",
        data: { Id: Id },
        success: function (data) {
            $("#listImg").html(data);
        }
    });
}

//ClassicEditor
//    .create(document.querySelector('#editor'))
//    .catch(error => {
//        console.error(error);
//    });
function GetProduct(Id) {
    $.ajax({
        type: 'GET',
        url: 'Product/Edit',
        data: { Id: Id },
        success: function (data) {
            console.log(data)
            $("#modal input[name='Id']").val(data.id);
            $("#modal input[name='Name']").val(data.name);
            $("#modal input[name='ImportPrice']").val(data.importPrice);
            $("#modal input[name='Price']").val(data.price);
            $("#modal input[name='Description']").val(data.description);
            $("#modal select[name='IdCategory']").val(data.idCategory);
            $.ajax({
                type: 'Get',
                url: 'Product/GetListCookie',
                data: { Id: Id },
                success: function (data) {
                    $("#listImg").html(data);
                }

            });
        }
    });

}
function deleteItemInListImgEdit(Id) {
    $.ajax({
        type: "POST",
        url: "Product/DeleteItemInListImgEdit",
        data: { Id: Id },
        success: function (data) {
            $("#listImg").html(data);
        }
    });
}
function createOrUpdate() {
        var url = "Product/CreateOrUpdate";
      //  var antiForgeryToken = $("#modalCreate input[name='__RequestVerificationToken']").val();
        var id = $("#modal input[name='Id']").val();
        var name = $("#modal input[name='Name']").val();
        var importPrice = $("#modal input[name='ImportPrice']").val();
        var price = $("#modal input[name='Price']").val();
        var idCategory = $("#modal select[name='IdCategory']").val();
        var description = $("#modal input[name='Description']").val();
        var model = {
            Id:id,
            Name: name,
            ImportPrice: importPrice,
            Price: price,
            IdCategory: idCategory,
            Description: description,
        }
        console.log(model)
        $.ajax({
            type: 'POST',
            url: url,
            data: model,
            success: function () {
                $("#modal").modal('hide');
                location.reload();
            }
        });

    }