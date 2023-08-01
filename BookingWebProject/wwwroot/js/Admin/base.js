const bodyElement = document.querySelector("body");
const modeToggleElement = bodyElement.querySelector(".mode-toggle");
const sidebarElement = bodyElement.querySelector("nav");
const menuElement = bodyElement.querySelector(".sidebar-toggle");
//Get current selected theme mode from user localstorage
let getMode = localStorage.getItem("mode");
if (getMode && getMode === "dark") {
    bodyElement.classList.toggle("dark");
}
//Get the status of navigation element from user localstorage
let getStatus = localStorage.getItem("status");
if (getStatus && getStatus === "close") {
    sidebarElement.classList.toggle("close");
}
modeToggleElement.addEventListener("click", () => {
    bodyElement.classList.toggle("dark");
    if (bodyElement.classList.contains("dark")) {
        //Set current theme
        localStorage.setItem("mode", "dark");
    } else {
        //Set current theme
        localStorage.setItem("mode", "light");
    }
});
menuElement.addEventListener("click", () => {
    sidebarElement.classList.toggle("close");
    if (sidebarElement.classList.contains("close")) {
        //Set current navigation state
        localStorage.setItem("status", "close");
        document.querySelector(".top-menu").classList.add("top-menu-short");
    } else {
         //Set current navigation state
        localStorage.setItem("status", "open");
        document.querySelector(".top-menu").classList.remove("top-menu-short");
    }
})