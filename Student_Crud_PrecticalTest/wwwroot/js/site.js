

$(document).ready(function () {
	$("btnsave").click(function () {
		debugger;
		validation();
	})
});

function validation() {
	debugger;
	//jQuery("Formstudent").validate({
	//	rules: {
	//		FirstName: "Required"
	//	},
	//	messages: {
	//		FirstName: "please enter valide name"
	//	}

	//});
	if ($("#FirstName").val() == "") {
		alert("please enter name");
		return false;
	}


}
