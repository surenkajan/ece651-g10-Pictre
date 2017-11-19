$(document).ready(function initMap() {
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


})



function addMarkers(map) {

    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(input);

    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    var markers = [];
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }

        var bounds = new google.maps.LatLngBounds();
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }
            var icon = {
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25)
            };

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });
        map.fitBounds(bounds);
    });


    var geocoder = new google.maps.Geocoder;
    var userEmail = $('#pictre_hdnf_CurrentUserEmailID').val();

    $.ajax({
        type: "GET",
        dataType: "jsonp",
        url: "http://localhost:32785/Service.svc/photorest/GetFriendPhotosByEmailID?EmailID=" + userEmail,
        success: function (friends) {
            friends.forEach(function (friend) {
                if (friend.Location) {
                    geocoder.geocode({ 'address': friend.Location }, function (results, status) {
                        if (status === 'OK') {
                            var image = {
                                url: friend.ProfilePhoto,
                                // This marker is 20 pixels wide by 32 pixels high.
                                scaledSize: new google.maps.Size(25, 25)
                            };
                            if (results[0]) {
                                var marker = new google.maps.Marker({
                                    map: map,
                                    icon: image,
                                    position: results[0].geometry.location,
                                    animation: google.maps.Animation.DROP,
                                    title: friend.FirstName + " " + friend.LastName
                                });

                                //<img class='infowindowimg' src='" + friend.ProfilePhoto + "' />  " + friend.FirstName + 
                                var infowindow = new google.maps.InfoWindow({
                                    maxWidth: 350,
                                    content: '<div id="iw-container">' +
                                    '<div class="iw-title"><img src="' + friend.ProfilePhoto + '" style="height:30px;"/> <a class="linktag" href="http://localhost:32231/myprofile/myprofile?uid=' + friend.UserID + '">' + friend.FirstName + " " + friend.LastName + '</a></div>' +
                                    '<div class="iw-content">' +
                                    '<img src="' + friend.ActualPhoto + '" alt="Porcelain Factory of Vista Alegre" height="115" width="150">' +
                                    '<div class="iw-subTitle">Location</div>' +
                                    '<p>' + friend.Location + '</p>' +
                                    '<div class="iw-subTitle">Photo Description</div>' +
                                    '<div style="width:350px;">'+ friend.PhotoDescription + '</div>' +
                                    '</div>' +
                                    '<div class="iw-bottom-gradient"></div>' +
                                    '</div>'
                                });

                                google.maps.event.addListener(marker, 'click', function () {
                                    infowindow.open(map, marker);
                                });

                                google.maps.event.addListener(map, 'click', function () {
                                    infowindow.close();
                                });

                                google.maps.event.addListener(infowindow, 'domready', function () {

                                    // Reference to the DIV that wraps the bottom of infowindow
                                    var iwOuter = $('.gm-style-iw');

                                    /* Since this div is in a position prior to .gm-div style-iw.
                                     * We use jQuery and create a iwBackground variable,
                                     * and took advantage of the existing reference .gm-style-iw for the previous div with .prev().
                                    */
                                    var iwBackground = iwOuter.prev();

                                    // Removes background shadow DIV
                                    iwBackground.children(':nth-child(2)').css({ 'display': 'none' });

                                    // Removes white background DIV
                                    iwBackground.children(':nth-child(4)').css({ 'display': 'none' });

                                    // Moves the infowindow 115px to the right.
                                    iwOuter.parent().parent().css({ left: '115px' });

                                    // Moves the shadow of the arrow 76px to the left margin.
                                    iwBackground.children(':nth-child(1)').attr('style', function (i, s) { return s + 'left: 76px !important;' });

                                    // Moves the arrow 76px to the left margin.
                                    iwBackground.children(':nth-child(3)').attr('style', function (i, s) { return s + 'left: 76px !important;' });

                                    // Changes the desired tail shadow color.
                                    iwBackground.children(':nth-child(3)').find('div').children().css({ 'box-shadow': 'rgba(72, 181, 233, 0.6) 0px 1px 6px', 'z-index': '1' });

                                    // Reference to the div that groups the close button elements.
                                    var iwCloseBtn = iwOuter.next();

                                    // Apply the desired effect to the close button
                                    iwCloseBtn.css({
                                        opacity: '1', right: '38px', top: '3px', border: '7px solid #022a50', 'border-radius': '13px', 'box-shadow': '0 0 5px #022a50', 'width': '26px', 'height': '26px'});

                                    // If the content of infowindow not exceed the set maximum height, then the gradient is removed.
                                    if ($('.iw-content').height() < 140) {
                                        $('.iw-bottom-gradient').css({ display: 'none' });
                                    }

                                    // The API automatically applies 0.7 opacity to the button after the mouseout event. This function reverses this event to the desired value.
                                    iwCloseBtn.mouseout(function () {
                                        $(this).css({ opacity: '1' });
                                    });
                                });
                            } else {
                                window.alert('No results found');
                            }
                        } else {
                            window.alert('Geocoder failed due to: ' + status);
                        }

                    });

                    
                }
            });
        }
    });



}