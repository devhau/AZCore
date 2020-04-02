AZHotKey_scope_current = "";
function AZHotKey() {
    if (AZHotKey_scope_current !== "")
        hotkeys.deleteScope(AZHotKey_scope_current);
    AZHotKey_scope_current = "scope_key" + Math.ceil(Math.random() * 10);
    SetHotKeyScope("body", AZHotKey_scope_current);
}
function SetHotKeyScope($element,$scope) {   
    $($element).find("*[data-hot-key]").each(function () {
        $thishotkey = this;
        var key = $($thishotkey).attr("data-hot-key");
        hotkeys(key, $scope, function (event, handler) {
            event.preventDefault();
            $($thishotkey).click();
            return false;
        });

    });
    hotkeys.setScope(AZHotKey_scope_current); // default scope is 'all'
}
$(function () { AZHotKey(); });
