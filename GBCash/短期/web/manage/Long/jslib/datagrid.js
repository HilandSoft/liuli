function checkallorno(o) {
	var a = o;

	while (true) {
		var a = a.parentElement;
		if (a == null) {
			break;
		}
		if ( a == "undefined") {
			a = null;
			break;
		}
		if (a.tagName == "TABLE") {
			break;	
		}
	}
	if (a != null) {
		for (i = 0;i < a.rows.length; i++) {
			for (j = 0;j < a.rows[i].cells[0].children.length; j++) {
				var var1 = a.rows[i].cells[0].children[j];
				if (var1.tagName == "INPUT" ) {
					if (var1.type == "checkbox") {
						var1.checked = o.checked;
					}
				}
			}
		}
	}
}

function getchecknum(frm) {
	var result = 0;
	var checkboxnum = 0;
	for (var i = 0; i < frm.length; i++) {
		if (frm.elements[i].type == "checkbox") {
			checkboxnum++;
			//��һ��Ϊȫѡ,������
			if (checkboxnum > 1) {
			    if (frm.elements[i].checked) {
				    result++;
			    }
			}
		}
	}
	return result;
}

//=============xier at 2004/04/05=========================
function checkEdit(frm) 
{
	if(getchecknum(frm) < 1) 
	{
		alert("��ѡ��Ҫ�༭�ļ�¼!");
		return false;
	}
	if(getchecknum(frm) > 1) 
	{
		alert("������ѡ��һ����¼���б༭!");
		return false;
	}
}

function checkDelete(frm) 
{
	if(getchecknum(frm) < 1) {
		alert("��ѡ��Ҫɾ���ļ�¼!");
		return false;
	}
	if(!confirm("��ȷ��Ҫɾ����ѡ�еļ�¼��")) {
		return false;
	}
}

function checkRecover(frm) 
{
	if(getchecknum(frm) < 1) {
		alert("��ѡ��Ҫ�ָ��ļ�¼!");
		return false;
	}
	if(!confirm("��ȷ��Ҫ�ָ���ѡ�еļ�¼��")) {
		return false;
	}
}
//=========================================================

//=============wuhp at 2004/06/25==========================
function checkonerecord(frm) 
{
	if(getchecknum(frm) != 1) {
		alert("��ѡ��һ����¼!");
		return false;
	}
	return true;
}
function checkleastonerecord(frm) 
{
	if(getchecknum(frm) < 1) {
		alert("����ѡ��һ����¼!");
		return false;
	}
	return true;
}
//=========================================================