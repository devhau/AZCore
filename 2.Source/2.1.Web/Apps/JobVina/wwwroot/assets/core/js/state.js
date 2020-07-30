/****************************************************************
 *                                                              *
 *  File: sate.js                                               *
 *  Description:là nơi cai trị tất cả các thứ trên đời này      *
 *  Author: nguyen van hau                                      *
 *  Email: nguyenvanhaudev@gmail.com                            *
 *                                                              *
 ****************************************************************/

var StateMain = {};
(function (window) {
    window.StateMain = StateMain;
})(window);
StateMain.init = function () {
    StateMain._popups = new LinkedList();
    StateMain.InitHotkey();
}
StateMain.PushPopup = function (popup) {
    StateMain._popups.Push(popup);
}

StateMain.ClosePopup = function () {
    if (!StateMain._popups.isEmpty()) {
        StateMain._popups.Remove();
    }
    if (!StateMain._popups.isEmpty()) {
        StateMain._popups.Current().focusPopup();
    }
    StateMain.InitHotkey();
}
StateMain.InitHotkey = function () {
    //_hotkey is undefine.
    if (!StateMain._hotkey) StateMain._hotkey = new HotKey();
    StateMain._hotkey.Init();
}
StateMain.ReLoad = function (callback) {
    
}
StateMain.Confirm = function (message, callYes, callNo) {
        new Popup()
        .setTitle("Thông báo")
        .setHtml(message)
        .ClearButton()
        .AddButton({
            value: "[C]ó",
            cmd: "c",
            icon: "far fa-check-circle",
            cls: "btn btn-success az-btn",
            func: function (elem, scope) {
                if (callYes) callYes(elem, scope);
            }
        }).AddButton({
            value: "[K]hông",
            icon: "far fa-times-circle",
            cls: "btn btn-danger az-btn",
            cmd: "k",
            func: function (elem, scope) {
                if (callNo) callNo(elem, scope);
            }
        }).ShowPopup();
}
$.fn.FormSavePopup = function () {
    let link = this.attr("href");
    AjaxMain.DoGet(link, {}, function () { })
}
    
StateMain.TargetCurrent = function () {
    if (!StateMain._popups.isEmpty()) {
        return StateMain._popups.Current().Modal;
    }
    return document;
}
StateMain.init();