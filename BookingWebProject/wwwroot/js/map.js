function initializeMap(latitude, longitude, markerMessage, apiKey) {
    const key = apiKey;
    const map = L.map('map').setView([latitude, longitude], 14);
    L.tileLayer(`https://api.maptiler.com/maps/streets-v2/{z}/{x}/{y}.png?key=${key}`, {
        tileSize: 512,
        zoomOffset: -1,
        minZoom: 1,
        attribution: "\u003ca href=\"https://www.maptiler.com/copyright/\" target=\"_blank\"\u003e\u0026copy; MapTiler\u003c/a\u003e \u003ca href=\"https://www.openstreetmap.org/copyright\" target=\"_blank\"\u003e\u0026copy; OpenStreetMap contributors\u003c/a\u003e",
        crossOrigin: true
    }).addTo(map);
    const hotelMarker = L.marker([latitude, longitude]).addTo(map);
    hotelMarker.bindPopup(markerMessage).openPopup();

    const distanceButton = document.querySelector('.distance-button');
    distanceButton.addEventListener('click', getDistance);

    function getDistance() {
        navigator.geolocation.getCurrentPosition(onSuccess, onError);
    }


    function onSuccess(position) {
        const userLatitude = position.coords.latitude;
        const userLongitude = position.coords.longitude;

        const userMarker = L.marker([userLatitude, userLongitude]).addTo(map);
        userMarker.bindPopup("Your location").openPopup();

        const line = L.polyline([[userLatitude, userLongitude], [latitude, longitude]], { color: 'red' }).addTo(map);


        const distance = map.distance([userLatitude, userLongitude], [latitude, longitude]);
        const distanceInKm = distance / 1000;
        const paragraphToAdd = document.createElement('p');
        paragraphToAdd.textContent = `Distance: ${distanceInKm.toFixed(2)}km`;
        paragraphToAdd.classList.add('distance');

        const locationSection = document.querySelector('.location-section');
        const existingParagraph = locationSection.querySelector('.distance');

        if (!existingParagraph) {
            locationSection.appendChild(paragraphToAdd);
        }

        //Grouping userMarker, hotelMarker and the line to fit properly on the map
        const markersGroup = L.featureGroup([userMarker, hotelMarker, line]);
        //set map to visualize hotelLocation and userLocation with their distance properly
        map.fitBounds(markersGroup.getBounds());

    }

    function onError(error) {
        switch (error.code) {
            case error.PERMISSION_DENIED:
                alert("User denied the request for Geolocation.");
                break;
            case error.POSITION_UNAVAILABLE:
                alert("Location information is unavailable.");
                break;
            case error.TIMEOUT:
                alert("The request to get user location timed out.");
                break;
            case error.UNKNOWN_ERROR:
                alert("An unknown error occurred.");
                break;
        }
    }
}