const headerElement = document.querySelector('header');
window.addEventListener('scroll', () => {
    headerElement.classList.toggle("sticky", window.scrollY > 0);
});

const downArrowElement = document.querySelector('.fa-caret-down');

downArrowElement.addEventListener('click', () => {
    event.target.classList.toggle('active-down-arrow');
    document.querySelector('.user-menu').classList.toggle('active-user-menu');
});

const rightArrowElement = document.querySelector('.fa-caret-right');
rightArrowElement.addEventListener('click', () => {
    event.target.classList.toggle('active-right-arrow');
    const userNavMenu = document.querySelector('.user-menu-list');
    userNavMenu.classList.toggle('active-user-menu-res');
    console.log(userNavMenu);
});