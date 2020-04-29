function AZHotKey() {
    let $this = this;
    $this.TergetManger = "";
	$this.scopeHotKey = [];
	$this.countKey = 0;
	$this.shift_nums = {
		"`": "~",
		"1": "!",
		"2": "@",
		"3": "#",
		"4": "$",
		"5": "%",
		"6": "^",
		"7": "&",
		"8": "*",
		"9": "(",
		"0": ")",
		"-": "_",
		"=": "+",
		";": ":",
		"'": "\"",
		",": "<",
		".": ">",
		"/": "?",
		"\\": "|"
	}
	//Special Keys - and their codes
	$this.special_keys = {
		'esc': 27,
		'escape': 27,
		'tab': 9,
		'space': 32,
		'return': 13,
		'enter': 13,
		'backspace': 8,

		'scrolllock': 145,
		'scroll_lock': 145,
		'scroll': 145,
		'capslock': 20,
		'caps_lock': 20,
		'caps': 20,
		'numlock': 144,
		'num_lock': 144,
		'num': 144,

		'pause': 19,
		'break': 19,

		'insert': 45,
		'home': 36,
		'delete': 46,
		'end': 35,

		'pageup': 33,
		'page_up': 33,
		'pu': 33,

		'pagedown': 34,
		'page_down': 34,
		'pd': 34,

		'left': 37,
		'up': 38,
		'right': 39,
		'down': 40,

		'f1': 112,
		'f2': 113,
		'f3': 114,
		'f4': 115,
		'f5': 116,
		'f6': 117,
		'f7': 118,
		'f8': 119,
		'f9': 120,
		'f10': 121,
		'f11': 122,
		'f12': 123
	};
    $this.Init = function () {
		$(window).off("keydown");
        if (PopupMain.isEmpty()) {
            $this.TergetManger = document;
        } else {
			$this.TergetManger = PopupMain.PopupCurrent().Modal;
		}
		$this.scopeHotKey = [];
		$this.countKey = 0;
		$($this.TergetManger).find("*[data-cmd-key]").each(function (i, e) {
			$this.countKey++;
			var elCallback = function (el) {
			
				$(el).focus();
				$(el).click();
				if ($(el).hasClass("select2")) {
					$(el).select2('open');
				}
            }
            var func = $(e).attr("data-cmd-func");
            if (func) {
                elCallback = val(func);
            }
            $this.scopeHotKey.push({
				keys: $(e).attr("data-cmd-key").split("+"),
                el: e,
                callback: elCallback
            });
		});
		$(window).on("keydown", $this.EventKeyUp);
		$($this.TergetManger).focus();
    }
	$this.EventKeyUp = function (e) {
		//Find Which key is pressed
		if (e.keyCode) code = e.keyCode;
		else if (e.which) code = e.which;
		if (code === undefined) return;
		var character = String.fromCharCode(code).toLowerCase();
		
		if (code == 188) character = ","; //If the user presses , when the type is onkeydown
		if (code == 190) character = "."; //If the user presses , when the type is onkeydown
		if ($this.countKey  === 0)
			return;

		for (var j = 0; scope = $this.scopeHotKey[j], j < $this.countKey; j++) {
			var modifiers = {
				shift: { wanted: false, pressed: false },
				ctrl: { wanted: false, pressed: false },
				alt: { wanted: false, pressed: false },
				meta: { wanted: false, pressed: false }	//Meta is Mac specific
			};

			opt = {};
			if (e.ctrlKey) modifiers.ctrl.pressed = true;
			if (e.shiftKey) modifiers.shift.pressed = true;
			if (e.altKey) modifiers.alt.pressed = true;
			if (e.metaKey) modifiers.meta.pressed = true;
			kp = 0;
			for (var i = 0; k = scope.keys[i], i < scope.keys.length; i++) {
				//Modifiers
				if (k == 'ctrl' || k == 'control') {
					kp++;
					modifiers.ctrl.wanted = true;

				} else if (k == 'shift') {
					kp++;
					modifiers.shift.wanted = true;

				} else if (k == 'alt') {
					kp++;
					modifiers.alt.wanted = true;
				} else if (k == 'meta') {
					kp++;
					modifiers.meta.wanted = true;
				} else if (k.length > 1) { //If it is a special key
					if ($this.special_keys[k] == code) kp++;

				} else if (opt['keycode']) {
					if (opt['keycode'] == code) kp++;

				} else { //The special keys did not match
					if (character == k) kp++;
					else {
						if ($this.shift_nums[character] && e.shiftKey) { //Stupid Shift key bug created by using lowercase
							character = $this.shift_nums[character];
							if (character == k) kp++;
						}
					}
				}
			}

			if (kp == scope.keys.length &&
				modifiers.ctrl.pressed == modifiers.ctrl.wanted &&
				modifiers.shift.pressed == modifiers.shift.wanted &&
				modifiers.alt.pressed == modifiers.alt.wanted &&
				modifiers.meta.pressed == modifiers.meta.wanted) {
				scope.callback(scope.el);

				//e.cancelBubble is supported by IE - this will kill the bubbling process.
				e.cancelBubble = true;
				e.returnValue = false;

				//e.stopPropagation works in Firefox.
				if (e.stopPropagation) {
					e.stopPropagation();
					e.preventDefault();
				}
				return false;
			}
		}
    }
   
}

let HotKeyMain = new AZHotKey();
