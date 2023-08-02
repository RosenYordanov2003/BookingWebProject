document.querySelectorAll(".img-container").forEach((element) => {
    element.addEventListener("mouseover", showDeleteButton)
    element.addEventListener("mouseout", hideDeleteButton)
});

function showDeleteButton() {
    this.children[1].classList.add("active-img-form");
    this.classList.add("active-img-container");
    
}
function hideDeleteButton(event) {
    this.children[1].classList.remove("active-img-form");
    this.classList.remove("active-img-container");
}