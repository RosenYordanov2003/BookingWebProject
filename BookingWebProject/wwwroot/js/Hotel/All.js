const favoriteElements = Array.from(document.querySelectorAll(".img-container i"))
    .filter((element) => element.classList.contains("fa-regular"));

favoriteElements.forEach((element) => element.addEventListener("click", addToFavorite));
const unFavortieElements = Array.from(document.querySelectorAll('.favorite'))
    .filter((element) => element.classList.contains("fa-solid"));
unFavortieElements.forEach((element) => element.addEventListener("click", removeFromFavorite));

setCheckboxState();

async function addToFavorite(event) {
    console.log(csrfToken);
    const hotelId = event.target.parentElement.parentElement.children[0].value;
    const baseUrl = `/Hotel/AddToFavorite/${hotelId}`;

    try {
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'RequestVerificationToken': csrfToken
            },
        });
       

        if (response.ok) {
            event.target.classList.remove("fa-regular");
            event.target.classList.add("fa-solid");
            window.location.reload();

        } else {
            console.error('Response error:', response.status);
        }
    } catch (exception) {
        console.error(exception);
    }
}

async function removeFromFavorite(event) {
    const hotelId = event.target.parentElement.parentElement.children[0].value;
    const baseUrl = `/Hotel/RemoveFromFavorite/${hotelId}`;
    try {
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'RequestVerificationToken': csrfToken
            },
        });

        if (response.ok) {
            event.target.classList.remove("fa-solid");
            event.target.classList.add("fa-regular");
            window.location.reload();

        } else {
            console.error('Response error:', response.status);
        }
    } catch (exception) {
        console.error(exception);
    }
}

function getQueryParameters(name) {
    let url = new URL(window.location.href);
    const selectedBenefitIds = url.searchParams.getAll(name);
    return selectedBenefitIds;
}

function setCheckboxState() {
    const checkBoxes = document.querySelectorAll('input[type="checkbox"]');
    const selectedBenefitIds = getQueryParameters("SelectedBenefitIds");
    if (selectedBenefitIds) {
        checkBoxes.forEach((checkBox) => {
            if (selectedBenefitIds.includes(checkBox.value)) {
                checkBox.checked = true;
            }
        });
    }
}

function getCsrfTokenFromCookie() {
    const cookieName = "__RequestVerificationToken";
    const cookieValue = document.cookie
        .split(";")
        .find(cookie => cookie.trim().startsWith(cookieName + "="));

    if (cookieValue) {
        return cookieValue.split("=")[1];
    }

    return null;
}