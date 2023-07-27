Array.from(deleteButtonElements = document.querySelectorAll(".delete"))
    .forEach((button) => button.addEventListener("click", deleteComment));

async function deleteComment(event) {
    let id = event.target.parentElement.parentElement.children[2].value;
    const url = `/Comment/Delete/${id}`;
    fetch(url, {
        method: 'POST',
        headers: { 'RequestVerificationToken': csrfToken },
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                window.location.reload();
            }
        })
        .catch((error) => console.error(error));
}