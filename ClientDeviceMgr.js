function ConfirmBatchOperation() {
    return confirm("Confirm updating all workstations");
}

function ConfirmDelete() {
    return confirm("Confirm delete");
}

function LimitToHex(control) {
	var len = control.value.length;
	var oldString = control.value;
	var indexCount = 0;
	var newString = "";
	var myChar = ' ';
	var edited = false;

	for (indexCount = 0; indexCount <= len - 1; indexCount++) {
		myChar = oldString.charAt(indexCount);

		if( ('0' <= myChar && myChar <= '9') ||
		    ('A' <= myChar && myChar <= 'F') )
			newString = newString + myChar;
		else if( 'a' <= myChar && myChar <= 'f' ) {
			newString = newString + myChar.toUpperCase();
			edited = true;
		} else
			edited = true;
	}

	if (true == edited) {
	    var cend = control.selectionEnd;
	    var cstart = control.selectionStart;
	    control.value = newString;
	    control.selectionStart = cstart;
	    control.selectionEnd = cend;
	}
}

function LimitToNumeric(control) {
	var len = control.value.length;
	var oldString = control.value;
	var indexCount = 0;
	var newString = "";
	var myChar = ' ';
	var edited = false;

	for (indexCount = 0; indexCount <= len - 1; indexCount++) {
		myChar = oldString.charAt(indexCount);

		if( '0' <= myChar && myChar <= '9' )
			newString = newString + myChar;
		else
			edited = true;
	}

	if (true == edited) {
	    var cend = control.selectionEnd;
	    var cstart = control.selectionStart;
	    control.value = newString;
	    control.selectionStart = cstart;
	    control.selectionEnd = cend;
	}
}

function LimitToUppercase(control) {
	var len = control.value.length;
    var newString = "";
	
	if (0 < len) {
		newString = control.value.toUpperCase();
		if (newString != control.value) {
		    var cend = control.selectionEnd;
		    var cstart = control.selectionStart;
		    control.value = newString;
		    control.selectionStart = cstart;
		    control.selectionEnd = cend;
        }
	}
}

function LimitToFilePath(control) {
    var len = control.value.length;
    var oldString = control.value;
    var indexCount = 0;
    var newString = "";
    var myChar = ' ';
    var edited = false;

    for (indexCount = 0; indexCount <= len - 1; indexCount++) {
        myChar = oldString.charAt(indexCount);

        if ('.' == myChar)
            edited = true;
        else if ('a' <= myChar && myChar <= 'z') {
            newString = newString + myChar.toUpperCase();
            edited = true;
        } else
            newString = newString + myChar;
    }

    if (true == edited) {
        var cend = control.selectionEnd;
        var cstart = control.selectionStart;
        control.value = newString;
        control.selectionStart = cstart;
        control.selectionEnd = cend;
    }
}