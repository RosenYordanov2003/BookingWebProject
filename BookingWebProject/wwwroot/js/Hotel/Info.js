const imgElements = Array.from(document.querySelectorAll(".hotel-card .img-container img"));

const leftArrowButton = document.querySelector(".img-container .fa-arrow-left");
const rightArrowButton = document.querySelector(".img-container .fa-arrow-right");
rightArrowButton.addEventListener("click", moveForward);
leftArrowButton.addEventListener("click", moveBack);

function moveForward(event) {
    const minIndex = 1;
    let activeImg = imgElements.filter((img) => img.classList.contains("active"))[0];
    let children = Array.from(event.target.parentElement.children)
    let currentIndex = children.indexOf(activeImg);

    activeImg.classList.remove("active");
    currentIndex++;
    if (currentIndex >= children.length - 1) {
        currentIndex = minIndex;
        children[currentIndex].classList.add("active");
    }
    else {
        children[currentIndex].classList.add("active");
    }
}
function moveBack() {
    let activeImg = imgElements.filter((img) => img.classList.contains("active"))[0];
    let children = Array.from(event.target.parentElement.children)
    let currentIndex = children.indexOf(activeImg);
    activeImg.classList.remove("active");
    const maxIndex = children.length - 2;
    currentIndex--;
    if (currentIndex < 1) {
        currentIndex = maxIndex;
        children[currentIndex].classList.add("active");
    }
    else {
        children[currentIndex].classList.add("active");
    }
}