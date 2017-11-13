function initMap() {
    var uluru = { lat: 20.5937, lng: 78.9629 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 3,
        center: uluru,
        styles: [
            {
                "featureType": "administrative",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "color": "#444444"
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#f2f2f2"
                    }
                ]
            },
            {
                "featureType": "poi",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "all",
                "stylers": [
                    {
                        "saturation": -100
                    },
                    {
                        "lightness": 45
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "simplified"
                    }
                ]
            },
            {
                "featureType": "road.arterial",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#a2bcc7"
                    },
                    {
                        "visibility": "on"
                    }
                ]
            }
        ]
    });

    addMarkers(map);

    google.maps.event.addDomListener(window, "resize", function () {
        var center = map.getCenter();
        google.maps.event.trigger(map, "resize");
        map.setCenter(center);
    });

}


function addMarkers(map) {
    var geocoder = new google.maps.Geocoder;

    $.ajax({
        type: "GET",
        dataType: "jsonp",
        url: "http://localhost:32785/Service.svc/userrest/GetUserByEmailID?Email=brindha@gmail.com",
        success: function (data) {
            console.log(data.DateOfBirth);
            console.log(data.EmailAddress);
            console.log(data.FirstName);
        }
    });

    var friends = [{
        'name': "shitij",
        'place': "delhi",
        'url': "https://www.w3schools.com/images/w3schools_green.jpg"
    },
    {
        'name': "kajan",
        'place': "sudan",
        'url': "https://www.w3schools.com/images/w3schools_green.jpg"
    },
    {
        'name': "enlil",
        'place': "turkey",
        'url': "https://www.w3schools.com/images/w3schools_green.jpg"
    },
    {
        'name': "brindha",
        'place': "sri lanka",
        'url': "https://www.w3schools.com/images/w3schools_green.jpg"
    },
    {
        'name': "jaspreet",
        'place': "madagascar",
        'url': "https://www.w3schools.com/images/w3schools_green.jpg"
    }];

    friends.forEach(function (friend) {
        geocoder.geocode({ 'address': friend.place }, function (results, status) {
            if (status === 'OK') {
                var image = {
                    url: "/Content/Images/map_marker.png",
                    // This marker is 20 pixels wide by 32 pixels high.
                    scaledSize: new google.maps.Size(25, 25)
                };
                if (results[0]) {
                    var marker = new google.maps.Marker({
                        map: map,
                        icon: image,
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP
                    });

                    marker.addListener('click', function toggleBounce() {
                        if (marker.getAnimation() !== null) {
                            marker.setAnimation(null);
                        } else {
                            marker.setAnimation(google.maps.Animation.BOUNCE);
                        }
                    });

                    var infowindow = new google.maps.InfoWindow;
                    infowindow.setContent("<img class='infowindowimg' src='" + friend.url + "' />  " + friend.name);
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