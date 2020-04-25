function AZSignalR()
{
    $this = this;
    $this.SignalBuilder = new signalR.HubConnectionBuilder();
    var options= {
        transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling,
        accessTokenFactory: function () { return AZCore.Token; }
    };
    $this.Connect = function ($url, callback) {
        if ($url.charAt(0) !== "/") {
            $url = "/" + $url;
        }
        $url = "/azhub" + $url;
        var AZConnect = $this.SignalBuilder.withUrl($url, options).withAutomaticReconnect().build();
        AZConnect.start().then(function () {
            if (callback)
                callback(AZConnect, true);
        }).catch(function (err) {
            console.log(err);
            if (callback)
                callback(AZConnect, false);
        });
    }
}
var SignalrMain = new AZSignalR();