function PurchaseOrders($id) {
    $this = this;
    $this.id = $id;
    $this.Table = $($this.id).find(".modal-dialog .az-data-table");
    $this.BindInput = function () {
        $($this.Table).find("table input").off("change");
        $($this.Table).find("table input").on('change', function () {
        });

    }
    function calMoney(number, price) {
        if (isNaN(number) && isNaN(price)) {
            return 0;
        }
        return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
    }

    $($this.id).find("#InputProductCode").on('change', function () {
        let value = $(this).val();
        if (value != "") {
            let name = $(this).text();
            let inputNumber = '<input type="text" class="form-control" value="1" name="ImportNumber">';
            let inputPrice = '<input type="text" class="form-control" value="100000" name="inputPrice">';
            $($this.Table).find("table > tbody:last-child").append("<tr><td></td><td>" + name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label class='LabelThanhTien'>100,000</label></td></tr>");
            $this.BindInput();
        }
    });
}