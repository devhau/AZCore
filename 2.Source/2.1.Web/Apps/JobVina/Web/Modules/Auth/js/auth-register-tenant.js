function AuthRegisterTentaint_ChangeTentaint(id) {
    $("." + id).change(function () {
        if ($(this).is(':checked')) {
            console.log("Nhập mã đơn vị");
            $('[name="InputTentaintName"]').attr("placeholder", "Nhập mã đơn vị");
        } else {
            console.log("Tên đơn vị mới");
            $('[name="InputTentaintName"]').attr("placeholder", "Tên đơn vị mới");
        }
    });
}