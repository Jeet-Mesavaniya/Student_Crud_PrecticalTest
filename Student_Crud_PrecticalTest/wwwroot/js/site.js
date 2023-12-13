
$(document).ready(function () {
	getdata();
});


function getdata(searchtext) {
	debugger;
	var data = { searchtext: searchtext };
	$.ajax({
		url: '/Student/StudentListByAjaxGetData',
		data: data,
		type: 'Get',
		dataType: 'json',
		contentType: 'application/json;charset=utf-8',
		success: function (result, status, xhr) {
			var obj = '';
			$.each(result, function (index, item)
			{
				obj += '<tr>';
				obj += '<td>' + item.id + '</td>';
				obj += '<td>' + item.firstName + '</td>';
				obj += '<td>' + item.lastName + '</td>';
				obj += '<td>' + item.gender + '</td>';
				obj += '<td> <a href="#" class="btn btn-primary">edit</a>  || <a href="#" class="btn btn-danger">delete</a> </td>';
				obj += '</tr>';
			});
			$("#tbl_Data").html(obj);

		},
		error: function () {
			alert('failed response');
		}
	});

}
//function validationnumber() {
//	debugger;
//	//jQuery("Formstudent").validate({
//	//	rules: {
//	//		FirstName: "Required"
//	//	},
//	//	messages: {
//	//		FirstName: "please enter valide name"
//	//	}

//	//});
//	//if ($("#FirstName").val() == "") {
//	//	alert("please enter name");
//	//	return false;
//	//}

//	var myPhoneRegex = /^ (\+\d{ 1, 2 } \s)?\(?\d{ 3 } \)?[\s.-]\d{ 3 } [\s.-]\d{ 4 } $/;

//	var contact = $("#contactno").val();
//	if (myPhoneRegex.test(contact)) {
//		alert("nomber is OK");
//	}
//	else { alert("please enter valide numbere"); return false; }
	


//}

function validation() {
	debugger
	var firstname = document.getElementById('FirstName').value;
	var lastname = document.getElementById('LastName').value;

	var firstnamecheck = /^[A-Za-z]{5,15}$/;
	var lastnamecheck = /^[A-Za-z]{5,15}$/;

	document.getElementById('FirstNameError').innerHTML = "";
	document.getElementById('LastNameError').innerHTML = "";

	if (!firstnamecheck.test(firstname)) {
		document.getElementById('FirstNameError').innerHTML = "Invalide First Name format";
		return
	}

	if (!lastnamecheck.test(lastname)) {
		document.getElementById('LastNameError').innerHTML = "Invalide Last Name format";
		return
	}

	alert("Form is valid! Submitting...");

}
