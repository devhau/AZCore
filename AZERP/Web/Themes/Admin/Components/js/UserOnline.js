function UserOnline($id) {
    $this.connection = undefined;
    $($id).find(".layout-icon").on("click", function () {
        $($id).addClass("show");
        $this.connection.invoke("SendMessage", "1", "Xin chào1").catch(function (err) {
            return console.error(err.toString());
        });
    });
    $($id).find(".btn-chat-close").on("click", function () {
        $($id).removeClass("show");
    });
    SignalrMain.Connect("/UserOnline", function (connection, flg) {
        if (flg) {
            $this.connection = connection;
            $this.connection.on("UserOnline", function (users) {
                console.log(users);
                $($id).find(".user-online").html("");
                $.each(users, function (e, el) {
                    if (el.id === AZCore.UserId) {
                        $($id).find(".user-online").prepend("<div class='item-user me' id=\"user" + el.id + "\">" + el.fullName + " (Tôi)</div>");
                    } else {
                        $($id).find(".user-online").append("<div class='item-user' id=\"user" + el.id + "\">" + el.fullName + "</div>");
                    }
                })
            });
            connection.on("ReceiveMessage", function (user, message) {

            });
        }

    })
}