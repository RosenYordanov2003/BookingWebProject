const headerElement = document.querySelector("header");
window.addEventListener("scroll", () => {
    headerElement.classList.toggle("sticky", window.scrollY > 0);
});
