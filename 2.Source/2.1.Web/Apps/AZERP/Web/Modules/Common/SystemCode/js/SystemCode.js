function SystemCode($id) {
    $($id).AZManager({}, function (manager) {
        $(manager).find(".az-btn-update-default").on("click", function () {
            var url = manager.location.pathname + "?h=UpdateDefault";
            manager.DoPost(url, {}, function (item) {
                if (item.statusCode == 200 || item.statusCode == 201) {
                    manager.ReLoad();
                    toastr.info(item.message);
                } else {
                    toastr.error(item.message);
                }
            });
        });
    });
}