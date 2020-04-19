function ManagerPermission($id) {
    $($id).AZManager(function (manager) {
        $(manager).find(".az-btn-update-permission").on("click", function (e) {
            manager.DoPost(manager.location.pathname + "?h=permission", null, function (e1) {
                toastr.success(e1.message);
                manager.ReLoad()
            });
        });
    });
}