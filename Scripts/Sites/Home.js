

function sendEmail(url) {
    sendEmail2(url);
}


sendEmail2 = (url) => {
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var tel = document.getElementById("phone").value;
    var message = document.getElementById("message").value;
    $.ajax({
        type: 'GET',
        url: url,
        data: { FullName: name, AddressEmail: email, Tel: tel, Message: message },
        contentType: 'application/json; charse t=utf-8',
        success: function () {
            alert("success");
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}