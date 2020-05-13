function HotelService($id) {
    $($id).find(".btn-luu").on("click", function () {
        new AZAjax().DoPost(PopupMain.PopupCurrent().link, {}, function () {


        })
        //PopupMain.PopupCurrent().ClosePopup();
    });
}