/********************************************************
 *                                                      *
 *  File: core.js                                       *
 *  Description:là các tính năng cơ bản của hệ thống    *
 *  Author: nguyen van hau                              *
 *  Email: nguyenvanhaudev@gmail.com                    *
 *                                                      *    
 ********************************************************/

var CoreMain = {
    /**
             * Converts a string to its html characters completely.
             *
             * @param {String} str String with unescaped HTML characters
             **/
    encode: function (str) {
        var buf = [];

        for (var i = str.length - 1; i >= 0; i--) {
            buf.unshift(['&#', str[i].charCodeAt(), ';'].join(''));
        }

        return buf.join('');
    },
    /**
     * Converts an html characterSet into its original character.
     *
     * @param {String} str htmlSet entities
     **/
    decode: function (str) {
        return str.replace(/&#(\d+);/g, function (match, dec) {
            return String.fromCharCode(dec);
        });
    },
    getLocation:function (href) {
        var l = document.createElement("a");
        l.href = href;
        return l;
    },
    newGuid:function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    },
    IsIE11OrLess: function () {
        return userAgent(/(?:Trident.*rv[ :]?11\.|msie|iemobile|Windows Phone)/i);
    },
    IsEdge: function () {
        return userAgent(/Edge/i);
    },
    IsFireFox: function () {
        return userAgent(/firefox/i);
    },
    IsSafari: function () {
        return userAgent(/safari/i) && !userAgent(/chrome/i) && !userAgent(/android/i);
    },
    IsIOS: function () {
        return userAgent(/iP(ad|od|hone)/i);
    },
    IsChromeForAndroid: function () {
        return userAgent(/chrome/i) && userAgent(/android/i);
    }
};

(function (window) {
    window.CoreMain = CoreMain;
})(window);

function userAgent(pattern) {
    if (typeof window !== 'undefined' && window.navigator) return !!/*@__PURE__*/navigator.userAgent.match(pattern);
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

$.fn.SerializeForm = function () {
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

$.fn.singleDatePicker = function () {
    var rs = $(this).daterangepicker({ singleDatePicker: true, autoUpdateInput: false, ShowDropdowns: true, minYear: 1901, locale: { format: 'DD/MM/YYYY' }, maxYear: parseInt(moment().format('YYYY'), 100) }).inputmask('datetime', {
        inputFormat: "dd/mm/yyyy",
        showMaskOnHover: true,
        showMaskOnFocus: true
    })
    $(this).on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
    return rs;
};
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
        if ($this.data[$this.size - 1].destroy) {
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



