AZHotKey_scope_current = "";
function AZHotKey() {
    if (AZHotKey_scope_current!=="")
        hotkeys.deleteScope(AZHotKey_scope_current);
    AZHotKey_scope_current = "scope_key" + Math.ceil(Math.random() * 10);
    $("*[data-hot-key]").each(function () {
        $thishotkey = this;
        var key = $($thishotkey).attr("data-hot-key");
        hotkeys(key, AZHotKey_scope_current, function (event, handler) {
            event.preventDefault();
            $($thishotkey).click();
            return false;
        });
        console.log(this);

    });
    hotkeys.setScope(AZHotKey_scope_current); // default scope is 'all'
    console.log(AZHotKey_scope_current);
}
$(function () { AZHotKey(); });
