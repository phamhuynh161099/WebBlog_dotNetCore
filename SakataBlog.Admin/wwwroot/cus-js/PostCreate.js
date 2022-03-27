$(document).ready(function () {
    //btnSubmitCategory Clicked
    $("#btnSubmitCategory").click(function () {
        var formData = new FormData();
        formData.append('ParentId', $("#ParentId").val());
        formData.append('SeoMeta', $("#SeoMetaCategory").val());
        formData.append('CategoryName', $("#CategoryName").val());

        $.ajax({
            type: "POST",
            url: '/Category/Create',
            data: formData,
            contentType: false,
            dataType: 'json',
            processData: false,
            cache: false,
            success: function (res) {
                if (res.isSuccessed == true) {
                    //show Alert
                    ShowAlert("Create Category " + res.message);

                    //Add New Option for CategorySelect
                    var html = "<option value='" + res.dataResult.id + "'>";
                    html += res.dataResult.categoryName + "</option>";
                    $("#CategoriesSelect").append(html);

                    //reset model category
                    $("#ParentId").val("");
                    $("#SeoMetaCategory").val("");
                    $("#CategoryName").val("");
                }
            },
            error: function (err) {
                console.log("error");
            }
        });
    });

    //btnSubmit Clicked
    $("#btnSubmitTag").click(function () {
        var formData = new FormData();

        formData.append('SeoMeta', $("#SeoMetaTag").val());
        formData.append('TagName', $("#TagName").val());

        $.ajax({
            type: "POST",
            url: '/Tag/Create',
            data: formData,
            contentType: false,
            dataType: 'json',
            processData: false,
            cache: false,
            success: function (res) {
                if (res.isSuccessed == true) {
                    //Show Alert
                    ShowAlert("Create Tag " + res.message);

                    //Add New Option for TagSelect
                    var html = "<option value='" + res.dataResult.id + "'>";
                    html += res.dataResult.tagName + "</option>";
                    $("#TagsSelect").append(html);

                    //reset model Tag
                    $("#SeoMetaTag").val("");
                    $("#TagName").val("");
                }
            },
            error: function (err) {
                console.log("error");
            }
        });
    });

    //funcation to Show Alert Success or Error
    function ShowAlert(Message) {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: Message,
            showConfirmButton: false,
            timer: 1500
        });

        setTimeout(function () {
            //location.reload();
            //Note Clear Form
        }, 1500);
    }
});