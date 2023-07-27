const postButton = document.querySelector(".post-button");
const textAreElement = document.querySelector("textarea");
postButton.addEventListener("click", postComment);
//Get url
const url = new URL(window.location.href);
//Get the last element from URL path to get Hotel id
let hotelId = url.pathname.split('/').pop();


async function postComment() {
    let commentData = {
        Description: textAreElement.value,
        HotelId: hotelId
    };
    const url = "/Comment/PostComment";
    fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': csrfToken
        },
        body: JSON.stringify(commentData)
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                window.location.reload();
            }
            else if (data.errors) {
                let object = data.errors[0];
                console.log(object);
                textAreElement.value += " " + object.error;
                textAreElement.style.color = "red";
                setTimeout(() => {
                    window.location.reload();
                }, 1500);
            }
            else {
                window.location.reload();
            }
        })
        .catch((error) => console.error(error));
}