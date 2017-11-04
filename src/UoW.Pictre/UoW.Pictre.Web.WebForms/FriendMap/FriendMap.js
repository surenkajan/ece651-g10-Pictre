function initMap() {
    var uluru = { lat: 20.5937, lng: 78.9629 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 3,
        center: uluru
    });
    addMarkers(map);
}

function addMarkers(map) {
    var geocoder = new google.maps.Geocoder;

    var friends = [{
        'name': "shitij",
        'place': "delhi"
    },
    {
        'name': "kajan",
        'place': "sudan"
        },
        {
            'name': "enlil",
            'place': "turkey"
    },
    {
        'name': "brindha",
        'place': "sri lanka"
        },
        {
            'name': "jaspreet",
            'place': "madagascar"
        }];

    friends.forEach(function (friend) {
        console.log(friend.place);
        geocoder.geocode({ 'address': friend.place }, function (results, status) {
            if (status === 'OK') {
                console.log(results);
                if (results[0]) {
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });
                    var infowindow = new google.maps.InfoWindow;
                    infowindow.setContent(friend.name + "<p>" + friend.place);
                    infowindow.open(map, marker);
                } else {
                    window.alert('No results found');
                }
            } else {
                window.alert('Geocoder failed due to: ' + status);
            }

        });
    });
    
        }

    window.onload = initMap();