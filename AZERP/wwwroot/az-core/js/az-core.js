function AZCore() { }
AZCore.Init = function () { }
AZCore.getLocation = function (href) {
    var l = document.createElement("a");
    l.href = href;
    return l;
};
AZCore.newGuid = function () {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
AZCore.token = undefined;
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
$.fn.singleDatePicker = function () {
    var rs = $(this).daterangepicker({ singleDatePicker: true, autoUpdateInput: false, ShowDropdowns: true, minYear: 1901, locale: { format: 'DD/MM/YYYY' }, maxYear: parseInt(moment().format('YYYY'), 100) }).inputmask('datetime' , {
        inputFormat: "dd/mm/yyyy",
       showMaskOnHover: true,
       showMaskOnFocus: true
   })
    $(this).on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
    return rs;
};
function AutoSizeColumnTable($TableSize) {
    var $table = $($TableSize),
        $bodyCells = $table.find('tbody tr:first').children(':not(.column-freeze)'),
        $bodyCellFreezes = $table.find('tbody tr:first').children('.column-freeze'),
        colFreezeWidth,
        colWidth;
    // Get the tbody columns width array
    colWidth = $bodyCells.map(function () {
        return $(this).width();
    }).get();
    colFreezeWidth = $bodyCellFreezes.map(function () {
        return $(this).width();
    }).get();
    // Set the width of thead columns
    $table.find('thead tr').children(':not(.column-freeze)').each(function (i, v) {
        $(v).width(colWidth[i]);
    });
    $table.find('thead tr').children('.column-freeze').each(function (i, v) {
        $(v).width(colFreezeWidth[i]);
        $(v).height($(v).parents('tr').find(':not(.column-freeze)').height() - 2);
    });
   
 
    $table.find('tbody').height($($table).height() - $table.find('thead').height());
}
$.fn.TableFreeze = function () {
    $this = this;
    AutoSizeColumnTable($this);
    $(window).resize(function () {
        AutoSizeColumnTable($this);
    });
    $isCroll = false;
    $tableBody = $($this).find('tbody');
    $($tableBody).scroll(function (e) { //detect a scroll event on the tbody
        /*
        Setting the thead left value to the negative valule of tbody.scrollLeft will make it track the movement
        of the tbody element. Setting an elements left value to that of the tbody.scrollLeft left makes it maintain 			it's relative position at the left of the table.
        */
        if ($isCroll) return;
        $isCroll = true;
        $scrollLeft = $($tableBody).scrollLeft()
        $($this).find('thead th.column-freeze').css("left", $scrollLeft); //fix the first cell of the header
        $($this).find('tbody td.column-freeze').css("left", $scrollLeft); //fix the first column of tdbody
        $($this).find('thead').css("left", - $scrollLeft); //fix the thead relative to the body scrolling
        $isCroll = false;
    });
}