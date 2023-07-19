const makeType = document.querySelector('table tbody tr td').textContent;
//Get url
const url = new URL(window.location.href);
//Get the last element from URL path
let id = url.pathname.split('/').pop();
const baseUrl = '/RentCar/CarsByBrand?';
getCarsByBrand(makeType, baseUrl, id);


async function getCarsByBrand(brand, baseUrl, id) {

    const data = {
        brand: brand,
        id: id
    };
    const queryString = Object.keys(data)
        .map((key) => encodeURIComponent(key) + "=" + encodeURIComponent(data[key]))
        .join("&");

    try {
        const response = await fetch(baseUrl + queryString);

        if (response.ok) {
            const data = await response.text();
            document.getElementById("other-cars").innerHTML += data;
            let childrenCount = document.getElementById('other-cars').children.length;
            if (childrenCount == 0) {
                document.querySelector('.suggest-title').style.display = 'none';
                let [leftArrow, rightArrow] = [...document.querySelectorAll('.suggest-section button')]
                leftArrow.style.display = 'none';
                rightArrow.style.display = 'none';
            }
            else {
                document.querySelector('.suggest-title').style.display = 'block';
                createSlider();
            }

        } else {
            console.error('Response error:', response.status);
        }
    } catch (exception) {
        console.error(exception);
    }
}


function createSlider() {
    const initialCountCards = 2;
    let currentIndex = 0;
    const cards = [...document.querySelectorAll('#other-cars .card')];
    ///Показване на първите 2 контейнера.
    for (var index = 0; index < initialCountCards; index++) {
        if (cards[index]) {
            cards[index].style.display = 'flex';
        }
    }
    // Взимане на лявата и дясната стрелка чрез DOM.
    const leftArrowBtn = document.querySelector('.suggest-section .left-arrow');
    const rightArrowBtn = document.querySelector('.suggest-section .right-arrow');

    rightArrowBtn.addEventListener('click', () => {
        //Скриване на 2 контейнра от текщия индекс(включително) до текущия индекс + 2 (не е включително)
        for (var index = currentIndex; index < initialCountCards + currentIndex; index++) {
            //Прави се проверка дали на този индекс съществува елемент.
            if (cards[index]) {
                cards[index].style.display = 'none';
            }
        }
        currentIndex += initialCountCards;
        // Ако текъщия индекс е надвишил или изравнил размера на card масива, индекса се занулява.
        if (currentIndex >= cards.length) {
            currentIndex = 0;
        }
        //Показване на елементи от текущия индекс (включително) до текущия индекс + 2 (не е включително)
        for (var index = currentIndex; index < initialCountCards + currentIndex; index++) {
            if (cards[index]) {
                cards[index].style.display = 'flex';
            }
        }

    });
    leftArrowBtn.addEventListener('click', () => {
        let initialIndex = currentIndex;

        // Проверка дали има достатъчно контейнери преди текущия индекс, за да се покажат двата предишни контейнера.
        if (initialIndex - initialCountCards >= 0) {
            initialIndex -= initialCountCards;
        } else {
            // Ако няма достатъчно контейнери преди текущия индекс, покажете последните два контейнера.
            initialIndex = cards.length - initialCountCards;
        }

        // Скриване на текущите контейнери.
        for (var index = currentIndex; index < currentIndex + initialCountCards; index++) {
            if (cards[index]) {
                cards[index].style.display = 'none';
            }
        }

        // Показване на предишните два контейнера.
        for (var index = initialIndex; index < initialIndex + initialCountCards; index++) {
            if (cards[index]) {
                cards[index].style.display = 'flex';
            }
        }
        currentIndex = initialIndex;
    });
}
