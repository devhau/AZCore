function ManagerPurchaseOrder($id) {

    $($id).AZManager({
        clear: true,
        Add: [{
            ButtonValue: "Lưu lại (F2)",
            ButtonIcon: "far fa-save",
            ButtonClass: "btn btn-success az-btn az-btn-update",
            ButtonCMD: "f2",
            func: function (elem, scope, manager) {
                manager.SaveData(scope.link, scope);
            }
        }],
        Edit: [
            {
                ButtonValue: "Lưu lại (F2)",
                ButtonIcon: "far fa-finish",
                ButtonClass: "btn btn-success az-btn",
                ButtonCMD: "f3",
                func: function (elem, scope, manager) {
                    manager.SaveData(scope.link, scope);
                }
            }
            //{
            //    ButtonValue: "Kết thúc",
            //    ButtonIcon: "far fa-finish",
            //    ButtonClass: "btn btn-danger az-btn",
            //    func: function (elem, scope, manager) {
            //        manager.SaveData(url, scope);
            //    }
            //},
            //{
            //    ButtonValue: "Xác nhận thanh toán (F4)",
            //    ButtonIcon: "far fa-finish",
            //    ButtonClass: "btn btn-secondary az-btn az-payment",
            //    ButtonCMD: "f4",
            //    func: function (elem, scope, manager) {
            //        var link = scope.link;
            //        var pathname = AZCore.getLocation(link).pathname;
            //        var id = scope.id;
            //        var url = pathname + "?h=Payment&id=" + id;
            //        manager.DoPost(url, {}, function (item) {
            //            if (item.statusCode) {
            //                if (item.statusCode == 200) {
            //                    manager.ReLoad();
            //                    scope.ClosePopup();
            //                    toastr.success(item.message);
            //                } else {
            //                    toastr.error(item.message);
            //                }
            //            }

            //        }, function () {

            //        })
            //    }
            //},
            //{
            //    ButtonValue: "Nhập kho (F3)",
            //    ButtonIcon: "far fa-finish",
            //    ButtonClass: "btn btn-primary az-btn az-import-store",
            //    ButtonCMD: "f3",
            //    func: function (elem, scope, manager) {
            //        var link = scope.link;
            //        var pathname=AZCore.getLocation(link).pathname;
            //        var id = scope.id;
            //        var url = pathname + "?h=ImportStore&id="+id;
            //        manager.DoPost(url, {}, function (item) {
            //            if (item.statusCode) {
            //                if (item.statusCode == 200) {
            //                    manager.ReLoad();
            //                    scope.ClosePopup();
            //                    toastr.success(item.message);
            //                } else {
            //                    toastr.error(item.message);
            //                }
            //            }

            //        }, function () {

            //        })
            //    }
            //}
        ]
    });
}