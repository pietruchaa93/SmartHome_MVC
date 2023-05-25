// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    function updateTime() {
        var currentTimeElement = document.getElementById("currentTime");
    var currentTime = new Date().toLocaleTimeString(); // get current time

    currentTimeElement.textContent = currentTime;
    }

    // refresh every second
    setInterval(updateTime, 1000);
