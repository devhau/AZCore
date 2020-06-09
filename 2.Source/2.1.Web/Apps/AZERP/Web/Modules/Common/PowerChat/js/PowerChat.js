function PowerChatApplication(id) {
    var $this = this;
    $this.tagId = id;
    $this.connect = undefined;

    $this.start = function () {

        SignalrMain.connect("/PowerChat", function (connection, flg)  {


        });
    }


}
function PowerChat(id)
{
    new PowerChatApplication(id).start();
}