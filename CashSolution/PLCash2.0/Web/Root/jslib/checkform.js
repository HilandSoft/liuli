function is_num( sValue )
{
	var mb=/^-?(([0-9]+\.[0-9]*[1-9][0-9]*)|-?([0-9]*[1-9][0-9]*\.[0-9]+)|-?([0-9]*[0-9][0-9]*))$/;
	if (mb.exec( sValue ) ) {
		return true;
	}
	else{
		return false;
	}

}

function is_date( sValue )
{
	var mb=/^([0-9]{4})-([1-9]|0[1-9]|1[0-2])-([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])$/;
	if (mb.exec( sValue ) ) {
		return true;
	}
	else{
		return false;
	}

}
function is_mail( sValue )
{
	var mb=/(\w)+[@]{1}(\w)+[.]{1}(\w)+/;
	if (mb.exec( sValue ) ) {
	return true;
	}
	else{
	return false;
	}

}