function ManagerOrder($id) {

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
        ]
    });
}