function UserOnline($id) {
    $this.connection = undefined;
    $($id).find(".layout-logo").on("click", function () {
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
            $this.connection.on("UserOnline", function (connectId) {
                $($id).find(".user-online").append("<div>" + connectId+"</div>");

            });
            connection.on("ReceiveMessage", function (user, message) {

                alert(message);
            });
        }

    })
}