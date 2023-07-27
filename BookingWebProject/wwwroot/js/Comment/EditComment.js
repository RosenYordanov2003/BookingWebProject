const editButtonElement = document.querySelectorAll(".button-container .edit")
    .forEach((button) => button.addEventListener("click", editComment));
const textAreaElement = document.querySelector("textarea");
let id = 0;


function editComment(event) {
    textAreaElement.value = event.target.parentElement.parentElement.children[1].textContent;
    id = event.target.parentElement.parentElement.children[2].value;
    let confirmEdintButtonIndex = Array.from(event.target.parentElement.children).indexOf(document.getElementById("confirm-edit"));

    if (confirmEdintButtonIndex < 0) {
        let confirmEditButton = createHTMLElement("button", "Confirm Edit", "confirm-edit", event.target.parentElement);
        confirmEditButton.addEventListener("click", sendComment);
    }
    let cancelButtonIndex = Array.from(event.target.parentElement.children).indexOf(document.getElementById("cancel-button"));
    if (cancelButtonIndex < 0) {
        let cancelButton = createHTMLElement("button", "Cancel Edit", "cancel-button", event.target.parentElement);
        cancelButton.addEventListener("click", cancelEdit);
    }
    let targetIndex = Array.from(event.target.parentElement.parentElement.parentElement.children).indexOf(event.target.parentElement.parentElement);
    disableEditButtons(targetIndex);
}
async function sendComment(event) {
    let commentData = {
        Description: textAreaElement.value,
        Id: id
    };
    const url = '/Comment/Edit'
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': csrfToken
        },
        body: JSON.stringify(commentData)
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                window.location.reload();
            }
            else if (data.errors) {
                let errorParagraph = document.createElement("p");
                errorParagraph.classList.add("error-paragraph");
                let object = data.errors[0];
                errorParagraph.textContent = object.error;
                event.target.parentElement.appendChild(errorParagraph);
            }
            else {
                window.location.reload();
            }
        })
        .catch(error => {
            console.error(error);
        });
}


function cancelEdit(event) {
    textAreaElement.value = "";
    event.target.parentElement.removeChild(event.target.parentElement.children[2]);
    event.target.parentElement.removeChild(event.target);
    enableEditButtons();
}

///This function create a html element and set his content, id, type of element and adds element to his parent element
function createHTMLElement(typeOfElement, content, id, parentElement) {
    const element = document.createElement(typeOfElement);
    if (content) {
        element.textContent = content;
    }
    if (id) {
        element.id = id;
    }
    if (parentElement) {
        parentElement.appendChild(element);
    }
    return element;
}

// This function disables other edit buttons
function disableEditButtons(currentIndex) {
    document.querySelectorAll(".comment-card")
        .forEach((card, index) => {
            if (index !== currentIndex) {
                // Disable other edit buttons
                card.children[3].children[0].disabled = true;
            }
        })
}

///This function enables all edit buttons
function enableEditButtons() {
    document.querySelectorAll(".comment-card")
        .forEach((card) => {
            // Enalble other edit buttons
            card.children[3].children[0].disabled = false;
        })
}
