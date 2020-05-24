// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToBasket(elementid,  productId, basketId) {
    actionMethod = "POST"
    actionUrl = "/apicustomer/add2basket"
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
            $('#MyBasket').append('<li><a href="#">' + productName + '</a></li>');


            contr = '#' + elementid
    
            $(contr).off('click');

            $(contr).click(function () {
                alert("cannot buy")
            });


           //     .attr("disabled", "disabled");


        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}

function addProductToServer() {
    actionMethod = "POST"
    actionUrl = "/apiproduct/AddProduct"
     sendData = {
         "Name": $('#Name').val(),
         "Price": $('#Price').val(),
         "Quantity": $('#Quantity').val()
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
            
            $('#responseDiv').html(JSON.stringify(data));
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });



}


function submitToServer() {
    actionMethod = "POST"
    actionUrl = "/apicustomer/addcustomer"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Address": $('#Address').val(),
        "Email": $('#Email').val()
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));

            $('#FirstName').val("");
            $('#LastName').val("")
            $('#Address').val("")
            $('#Email').val("")


            customerId= data["id"]
            alert('You have successfully registered')
            window.open("/Home/Shopping?customerId=" + customerId, "_self")

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

