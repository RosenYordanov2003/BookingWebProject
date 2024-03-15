let secondPicturesPathElements = Array.from(document.querySelectorAll(".second-img-path"));
let orginalImgsSrcArrayElements = Array.from(document.querySelectorAll(".hotel-img-container .original-img-path"));

const originalImgsPath = orginalImgsSrcArrayElements.map((el) => el.textContent);
const secondPicturesPath = secondPicturesPathElements.map((el) => el.textContent);


const containers = document.querySelectorAll(".hotel-img-container img").forEach((container) => {
    container.addEventListener("mouseover", changeImg);
    container.addEventListener("mouseout", restoreImg);
});


function changeImg(event) {
    let childrenArray = Array.from(event.target.parentElement.parentElement.parentElement.parentElement.children);
    const index = childrenArray.indexOf(event.target.parentElement.parentElement.parentElement);
    event.target.style.opacity = 0.7;
    setTimeout(() => {
        event.target.src = secondPicturesPath[index];
        event.target.style.opacity = 1;
    }, 200);
}

function restoreImg(event) {
    let childrenArray = Array.from(event.target.parentElement.parentElement.parentElement.parentElement.children);
    const index = childrenArray.indexOf(event.target.parentElement.parentElement.parentElement);
    event.target.style.opacity = 0.7;
    setTimeout(() => {
        event.target.src = originalImgsPath[index];
        event.target.style.opacity = 1;
    }, 360);
}
