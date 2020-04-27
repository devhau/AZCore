function UserOnline($id) {
    $this.connection = undefined;
    $this.userId = undefined;
    $this.userName = undefined;
    $this.meName = undefined;
    $this.ChatMessage = $($id).find(".user-chat .chat-message");
    $this.SenderUser = $($id).find(".user-chat .send-user");
    $($id).find(".layout-icon").on("click", function () {
        $($id).addClass("show");      
    });
    $($id).find(".btn-show-chat").on("click", function () {
        if (!$(this).parents(".layout-chat ").hasClass("show-chat"))
            $(this).parents(".layout-chat ").addClass("show-chat");
    });
    $($id).find(".btn-hide-chat").on("click", function () {
        $(this).parents(".layout-chat").removeClass("show-chat");
    });
    $($id).find(".btn-close-layout-chat").on("click", function () {
        $($id).removeClass("show");
    });
    $($id).find(".chat-input .txt-chat").on("keypress", function (e) {
        if (e.keyCode === 13) {
            if ($(this).val() == "") return;
            $($id).find(".chat-input .btn-send-chat").click();
        }
    });
    $($id).find(".chat-input .btn-send-chat").on("click", function () {
        if (!$this.userId) return;
        var txt = $($id).find(".chat-input .txt-chat").val();
        $($id).find(".chat-input .txt-chat").val("");
        $($this.ChatMessage).append("<div class='me box-chat'><h5>" + $this.meName + "</h5><div class='box-message'>" + txt + "</div></div>");
        $this.connection.invoke("SendMessage", $this.userId, txt).catch(function (err) {
            return console.error(err.toString());
        });
    });
    $this.reload = function () {
        $($id).find(".user-list li").off("click");
        $($id).find(".user-list li").on("click", function () {
            if ($(this).hasClass("me"))
                return;
            $($id).find(".user-list li").removeClass("active");
            $(this).addClass("active");
            $this.userId = $(this).attr("user-id");
            $this.userName = $(this).html();
            $($this.SenderUser).html($this.userName);
            $($this.SenderUser).attr("user-id", $this.userId);
            $($id).find(".btn-show-chat").click();
        });
    }
    SignalrMain.Connect("/UserOnline", function (connection, flg) {
        if (flg) {
            $this.connection = connection;
            $this.connection.on("UserOnline", function (users) {
                console.log(users);
                $($id).find(".user-list").html("");
                $.each(users, function (e, el) {
                    if (el.id === AZCore.UserId) {
                        $this.meName = el.fullName;
                        $($id).find(".user-list").prepend("<li class='item-user me' id=\"user" + el.id + "\" user-id=\"" + el.id + "\">" + el.fullName + " (Tôi)</li>");
                    } else {
                        $($id).find(".user-list").append("<li class='item-user' id=\"user" + el.id + "\" user-id=\"" + el.id + "\">" + el.fullName + "</li>");
                    }
                });
                $this.reload();
            });
            connection.on("ReceiveMessage", function (sender, message) {
                if ($this.userId != sender) {
                    $("#user" + sender).click();
                }
                $($this.ChatMessage).append("<div class='sender box-chat'><h5>" + $this.userName + "</h5><div class='box-message'>" + message+"</div></div>");
            });
        }

    })
}