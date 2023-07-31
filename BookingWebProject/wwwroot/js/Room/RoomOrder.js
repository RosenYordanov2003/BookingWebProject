const buttonContainerElment = document.querySelector('.button-container');
buttonContainerElment.addEventListener('click', function (event) {
    document.querySelector('.fa-angle-down').classList.toggle('active');
    document.querySelector('.room-benefits-ul').classList.toggle('active-benefits');
    if (document.querySelector('.see-more-button').textContent === 'See more') {
        document.querySelector('.see-more-button').textContent = 'Hide'
    }
    else {
        document.querySelector('.see-more-button').textContent = 'See more'
    }
});

const imgContainerElement = document.querySelector('.img-container');
imgContainerElement.children[1].classList.add('active-img');
document.querySelector('.fa-arrow-right').addEventListener('click', moveForward);
document.querySelector('.fa-arrow-left').addEventListener('click', moveBack);
//Filter img elements to find the index of the current active img element
let currentActiveElement = Array.from(imgContainerElement.children).filter((element) => element.classList.contains('active-img'))[0];
let currentIndex = Array.from(imgContainerElement.children).indexOf(currentActiveElement);

document.querySelectorAll('.choose-button')
    .forEach((button) => button.addEventListener('click', function (event) {
        event.target.children[0].classList.toggle('active-arrow');
        event.target.parentElement.parentElement.children[5].classList.toggle('active-form');
    }));

document.querySelectorAll('form').forEach((form) => {
    const spansCount = form.querySelectorAll('span').length;
    if (spansCount > 0) {
        form.classList.toggle('active-form');
    }
});

function moveForward() {
    //Get index of the first img element
    const minIndex = 1;
    //Remove 'active-img' class from the current element
    imgContainerElement.children[currentIndex].classList.remove('active-img');
    currentIndex++;
    //If the index is heigher or equal from last img element, we set him to be euqal to first img element index
    if (currentIndex >= imgContainerElement.children.length - 1) {
        currentIndex = minIndex;
        //Add 'active-img' class from the current element
        imgContainerElement.children[currentIndex].classList.add('active-img');
    }
    else {
        //Add 'active-img' class from the current element
        imgContainerElement.children[currentIndex].classList.add('active-img');
    }
}

function moveBack() {
    //Get index of the last img element
    const minIndex = imgContainerElement.children.length - 2;
    //Remove 'active-img' class from the current element
    imgContainerElement.children[currentIndex].classList.remove('active-img');
    currentIndex--;
    //check if the index is equal or lower to first img element
    //If the index is lower from first img element, we set the currentIndex to the last img element
    if (currentIndex < 1) {
        currentIndex = minIndex;
        //Add 'active-img' class from the current element
        imgContainerElement.children[currentIndex].classList.add('active-img');
    }
    //If the index is not lower from firstIndex, we add 'active-img' class to the current element
    else {
        imgContainerElement.children[currentIndex].classList.add('active-img');
    }
}

function createHtmlElement(typeOfElement, textContent, className, parentElement, attributes) {
    let element = document.createElement(typeOfElement);
    if (textContent) {
        element.textContent = textContent;
    }
    if (className) {
        element.classList.add(className);
    }
    if (parentElement) {
        parentElement.appendChild(element);
    }
    if (attributes) {
        for (const key in attributes) {
            element.setAttribute(key, attributes[key]);
        }
    }
    return element;
}
