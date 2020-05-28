// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function doUpdateCustomer(custId) {
    actionMethod = "PUT"
    actionUrl = "/apicustomer/updatecustomer"
    sendData = {
        "firstName": $('#FirstName').val(),
        "lastName": $('#LastName').val(),
        "address": $('#Address').val(),
        "email": $('#Email').val(),
        "id":custId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html("The update has been made successfully");
 
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}


function editCustomer(custId) {
    window.open("/Home/customerEdit?custId=" + custId, "_self");
}



function deleteCustomer(custId) {
    actionMethod = "DELETE"
    actionUrl = "/apicustomer/DeleteCustomer"
    sendData = { "Id": custId}
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            if (data == null) {
                $('#responseDiv').html("There is no such customer");
            }
            else {
                //to do
                $('#cusTable' + custId).remove()

                   //     window.open("/Home/Customer", "_self")
            }

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
         
}



$('#loginButton').click(
    function () {

        actionMethod = "POST"
        actionUrl = "/apicustomer/login"
        sendData = {
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
                if (data == null) {
                    $('#responseDiv').html("There is no such customer");
                }
                else {
                    customerId = data["id"]

                    window.open("/Home/shopping?customerId="+customerId,"_self")
                }

            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });



    }

);

//onclick = "registerCustomer()"')




function addToBasket() {
    elementid = this.id
    productId = this.value
    basketId = $("#productsList").value



    actionMethod = "POST"
    actionUrl = "/apicustomer/add2basket"
    sendData = {
        "productId": productId,
        "basketId": basketId
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


function doAddCustomer() {
    if ($('#FirstName').val() == "") {
        alert("fill FirstName");
        $('#FirstName').focus();
        return;
    }
    if ($('#LastName').val() == "") {
        alert("fill LastName");
        $('#LastName').focus();
        return;
    }


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
      //      window.open("/Home/Shopping?customerId=" + customerId, "_self")

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

