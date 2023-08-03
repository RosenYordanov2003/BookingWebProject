let inputElements = document.querySelectorAll("input:not([type=checkbox]").forEach((input) => {
    if (!input.readOnly) {
        input.addEventListener("focus", (event) => event.target.parentElement.children[0].classList.add("shift"));
        input.addEventListener("blur", (event) => event.target.parentElement.children[0].classList.remove("shift"));
    }
});
