// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToBasket(  productId, basketId) {
    actionMethod = "POST"
    actionUrl = "/customer/add2basket"
    sendData = {
        "productId": productId,
        "basketId": basketId
     }

 
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
           
           productName =  data["name"]
            $('#MyBasket').append('<li><a href="#">' + productName+'</a></li>');
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}




function submitToServer() {
    actionMethod = "POST"
    actionUrl = "/customer/addcustomer"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Address": $('#Address').val(),
        "Email": $('#Email').val()
    }

    alert(JSON.stringify(sendData))

   
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html( JSON.stringify(data) );
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
    
}



function loadCustomers() {
	actionMethod = "GET"
    actionUrl = "/customer/GetAllCustomers"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {

			for (var i = 0, len = data.length; i < len; i++) {

				tr = $('<tr>');
				tr.append("<td>" + data[i]["firstName"] + "</td>");
				tr.append("<td>" + data[i]["lastName"] + "</td>");
				tr.append("<td>" + data[i]["address"] + "</td>");
				tr.append("<td>" + data[i]["email"] + "</td>");
				tr.append('</tr>');
				$('#resultTable').append(tr);
			}



		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
		}
	});

}

