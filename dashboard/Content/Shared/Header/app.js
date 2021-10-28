var slide = document.getElementById("content");
var dataSlide = document.getElementsByClassName("data");
var tampData = [dataSlide[0].innerHTML, dataSlide[1].innerHTML, dataSlide[2].innerHTML];
var change = false;
var position = 1;
var time = setInterval(slider, 4000);
var timeout;

var menu = false;

console.log(this.window.location.protocol);
function slider() {
    position = (position + 1) % 3;
    change = false;
    slide.classList.toggle("toright");
    timeout = setTimeout(nextSlide, 1100);
}

function nextSlide() {
    dataSlide[1].innerHTML = tampData[position];
    dataSlide[2].innerHTML = tampData[(position + 1) % 3];
    dataSlide[0].innerHTML = tampData[(position + 2) % 3];
    slide.classList.toggle("toright");
}

function prevSlide() {
    dataSlide[1].innerHTML = tampData[position];
    dataSlide[2].innerHTML = tampData[(position + 1) % 3];
    dataSlide[0].innerHTML = tampData[(position + 2) % 3];
    slide.classList.toggle("toleft");
}

function next() {
    clearInterval(time);
    clearTimeout(timeout);
    position = (position + 1) % 3;
    slide.classList.toggle("toright");
    timeout = setTimeout(nextSlide, 1100);
    time = setInterval(slider, 4000);
}

function prev() {
    clearInterval(time);
    clearTimeout(timeout);
    if (position == 0) {
        position = 2;
    }
    else {
        position--;
    }
    slide.classList.toggle("toleft");
    timeout = setTimeout(prevSlide, 1100);
    time = setInterval(slider, 4000);
}

function seeOption() {
    document.getElementById("link").classList.toggle("startMenu");
}

function toroute(controller, action) {
    location.href = location.origin + "/" + controller + "/" + action;
}