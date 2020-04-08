String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};
String.prototype.splice = function (idx, s) {
    return (this.slice(0, idx) + s + this.slice(idx));
};
function AZCore() { }
AZCore.Init = function () { }
$.fn.singleDatePicker = function () {
   var rs= $(this).daterangepicker({ singleDatePicker: true, autoUpdateInput: false, ShowDropdowns: true, minYear: 1901, locale: { format: 'DD/MM/YYYY' }, maxYear: parseInt(moment().format('YYYY'), 10) });
    $(this).on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
    return rs;
};
$.fn.TableFreeze = function () {
    $thisTableFreeze = this;
    $tableBody = $($thisTableFreeze).find('tbody');
    var thisWidth = $($thisTableFreeze).width();   
    var thisHeight = $($thisTableFreeze).height();
    $($tableBody).width(thisWidth);
    $($tableBody).height(thisHeight - $($thisTableFreeze).find('thead').height());
    $($thisTableFreeze).find('thead').width(thisWidth);
    $($thisTableFreeze).find('table').width(thisWidth);
    $isCroll = false;
    $($tableBody).scroll(function (e) { //detect a scroll event on the tbody
        /*
        Setting the thead left value to the negative valule of tbody.scrollLeft will make it track the movement
        of the tbody element. Setting an elements left value to that of the tbody.scrollLeft left makes it maintain 			it's relative position at the left of the table.
        */
        if ($isCroll) return;
        $isCroll = true;
        $scrollLeft = $($tableBody).scrollLeft()
        $($thisTableFreeze).find('thead th:nth-child(1)').css("left", $scrollLeft); //fix the first cell of the header
        $($thisTableFreeze).find('tbody td:nth-child(1)').css("left", $scrollLeft); //fix the first column of tdbody
        $($thisTableFreeze).find('thead').css("left", - $scrollLeft); //fix the thead relative to the body scrolling
        $isCroll = false;
    });
    $(window).resize(function () {
        var thisWidth = $($thisTableFreeze).width();
        var thisHeight = $($thisTableFreeze).height();
        $($tableBody).width(thisWidth);
        $($tableBody).height(thisHeight - $($thisTableFreeze).find('thead').height());
        $($thisTableFreeze).find('thead').width(thisWidth);
        $($thisTableFreeze).find('table').width(thisWidth);
    });    
}