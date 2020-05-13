function AZCore() { }
AZCore.Init = function () { }
AZCore.Token = undefined;
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
/* Class LinkedList */
function LinkedList() {
    let $this = this;
    $this.data = {};
    $this.size = 0;
    $this.isEmpty = function () {
        return $this.size === 0;
    }
    $this.Current = function () {
        if ($this.isEmpty()) return undefined;
        return $this.data[$this.size - 1];
    }
    $this.Push = function (popup) {
        $this.data[$this.size] = popup;
        $this.size++;
        return true;
    }
    $this.Remove = function () {
        if ($this.isEmpty()) return false;
        if ($this.data[$this.size - 1].destroy)
        {
            $this.data[$this.size - 1].destroy();
        }
        delete $this.data[$this.size - 1];
        $this.size--;
        return true;
    }
    $this.RemoveAll = function () {
        while (!$this.isEmpty()) $this.Remove();
        this.size = 0;
    }
}
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

/* Process Upload file*/
var fileApi = !!window.File;
var FAKE_PATH = 'fakepath';
var FAKE_PATH_SEPARATOR = '\\';
function getSelectedFiles(input) {
    if (input.hasAttribute('multiple') && fileApi) {
        return [].slice.call(input.files).map(function (file) {
            return file.name;
        }).join(', ');
    }
    if (input.value.indexOf(FAKE_PATH) !== -1) {
        var splittedValue = input.value.split(FAKE_PATH_SEPARATOR);
        return splittedValue[splittedValue.length - 1];
    }
    return input.value;
};
$.fn.AZSerializeForm = function () {
    var $data = $(this).serializeArray();
    $(this).find('input[type="checkbox"]:not(:checked)').each(function () {
            $data.push({ name: this.name, value: false });
    });
    if ($(this).find('input[type="file"]').length > 0) {
        var data = new FormData();
        $.each($data, function (key, input) {
            data.append(input.name, input.value);
        });
        $(this).find('input[type="file"]').each(function () {
            var file_data = $(this)[0].files;
            if (file_data) {
                for (var i = 0; i < file_data.length; i++) {
                    data.append(this.name, file_data[i]);
                }
            }
        });
        return data;
    } else {
        return $data;
    }
};
$.fn.AZUploadFile = function () {
    var labelUpload = $(this).parents(".az-upload-file").find(".custom-file-label")
    var imageUpload = $(this).parents(".az-upload-file").find(".az-image");

    $(this).on("change", function (event) {
        $(labelUpload).html(getSelectedFiles(this));
        if (imageUpload)
            $(imageUpload).attr("src", URL.createObjectURL(event.target.files[0]));
    });
};
$.fn.ShowLinkPopup = function () {
    let ModalSize = $(this).attr("modal-size");
    let reload = $(this).attr("reload");
    let LinkHref = $(this).attr("href");
    let link = $(this).attr("href");
    if (LinkHref.indexOf("?") > 0) {
        LinkHref += "&ActionType=popup"
    } else
        LinkHref += "?ActionType=popup"
    AjaxMain.DoGet(LinkHref, null, function (item) {
        if (item.statusCode && item.statusCode === 401) {
            return;
        }
        let popup = new AZPopup();
        popup.ClearButton();
        popup.setHtml(item.html);
        $icon = '<i class="fas fa-edit"></i> ';
        if (item.icon && item.icon != "") {
            $icon = '<i class="' + item.icon+'"></i> ';
        }
        popup.setTitle($icon + item.title);
        popup.setLink(link);
        popup.ModalSize = ModalSize;
        popup.ShowPopup(function () {
            if (reload && reload === 'true') {
                $this.loadHtml(location.href);
            }
        });
    });
}