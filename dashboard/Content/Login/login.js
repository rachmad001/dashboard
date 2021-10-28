var elmnt = document.querySelector(".login-page");
var form = document.querySelector(".login-form");
var greetings = document.querySelector(".greetings");
var userScreen = elmnt.offsetHeight;
var formSc = (userScreen - form.offsetHeight) / 2;
var greetSc = (userScreen - greetings.offsetHeight) / 2;
function start() {
    form.style.top = formSc + "px";
    greetings.style.top = greetSc + "px";
}
function resize() {
    userScreen = elmnt.offsetHeight;
    formSc = (userScreen - form.offsetHeight) / 2;
    greetSc = (userScreen - greetings.offsetHeight) / 2;
    form.style.top = formSc + "px";
    greetings.style.top = greetSc + "px";
}
function login() {
    var username = document.getElementsByName("username")[0];
    var password = document.getElementsByName("password")[0];
    var forms = new FormData();
    forms.append("username", username.value);
    forms.append("password", password.value);
    username.value = "";
    password.value = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        var response = JSON.parse(this.responseText);
        if (response.status) {
            console.log("success");
        }
        else {
            console.log("error");
        }
    };
    xhttp.open("POST", "https://localhost:4033/Login/Validasi");
    xhttp.send(forms);
}