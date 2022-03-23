$(document).ready(function () {
    $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel');
});
function Login(url) {
    var username = document.getElementById("UsernameLogin").value;
    var password = document.getElementById("PasswordLogin").value;
    if (username != "" & password != "") {
        Login2(url, username, password);
    }
}
function Register(url) {
    var username = document.getElementById("UsernameRegister").value;
    var password = document.getElementById("PasswordRegister").value;
    var confirmPassword = document.getElementById("ConfirmPasswordRegister").value;
    /*for (item in ) {
        alert("not if");
        if (username = item.username) {
            alert("error");
        }
        ajax1();
    }*/

    /*for (var item in model) {
        alert(item.Username);
    }*/
    if (password == confirmPassword & username!="" & password!="") {
        Register2(url, username, password);
    }
}

Register2 = (url, username, password) => {
    $.ajax({
        type: 'GET',
        url: url,
        data: { username: username, password:password},
        contentType: 'application/json; charse t=utf-8',
        success: function (data) {
            alert(data);
            if (data == "1") {
                window.location.href = '/Sites/Index';
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}
Login2 = (url, username, password) => {
    $.ajax({
        type: 'GET',
        url: url,
        data: { username: username, password: password },
        contentType: 'application/json; charse t=utf-8',
        success: function (data) {
            alert(data);
            if (data == "1") {
                window.location.href = '/Sites/Index';
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}