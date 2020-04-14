function AZHotKey() {
    let $this = this;
    $this.TergetManger = "";
    $this.init = function () {
        if ($this.TergetManger) {
            $($this.TergetManger).off("keyup");
        }
        if (PopupMain.isEmpty()) {
            $this.TergetManger = window;
        } else {
            $this.TergetManger = PopupMain.PopupCurrent();
        }
        $($this.TergetManger).on("keyup", $this.EventKeyUp);
    }
    $this.EventKeyUp = function (e) {
        console.log(e);
        console.log("Xin chào");
    }
   
}

let HotKeyMain = new AZHotKey();
