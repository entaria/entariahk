var jsInit = (function() {
    // Private stuff up here

    // Public methods here
    return {
		initialize: function() {
                var myCenter = Array(10);
                myCenter[0] = new google.maps.LatLng(53.349, -6.243); //NCI 
                myCenter[1] = new google.maps.LatLng(53.352, -6.245); //CHQ 
                myCenter[2] = new google.maps.LatLng(53.345, -6.248); //O'Connell Street
                myCenter[3] = new google.maps.LatLng(53.346, -6.243); //and so on
                myCenter[4] = new google.maps.LatLng(53.355, -6.241); 
                myCenter[5] = new google.maps.LatLng(53.340, -6.240); 
                myCenter[6] = new google.maps.LatLng(53.340, -6.250); 
                myCenter[7] = new google.maps.LatLng(53.341, -6.245); 
                myCenter[8] = new google.maps.LatLng(53.341, -6.243); 
                myCenter[9] = new google.maps.LatLng(53.352, -6.240); 
                var mapOptions = {
					center : myCenter[0],
					zoom : 14,
					mapTypeId : google.maps.MapTypeId.ROADMAP
				};
				var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);

                var contentString = Array(10);
                           
                contentString = ["Student Cafe, NCI, Mayor Square",
                                 "Insomnia",
                                 "Java Republic",
                                 "O'Briens",
                                 "Starbucks",
                                 "Insomniac",
                                 "Seventh Wonder",
                                 "Cafe8",
                                 "Cafe9",
                                 "Cafe10"];

                var infowindow = new google.maps.InfoWindow();
                for (var i = 0; i < contentString.length; i++) {
                    var content = contentString[i];
                    if (i == 0 ) { 
                        var marker = new google.maps.Marker({
                            map: map,
                            position: myCenter[i],
                            animation:google.maps.Animation.BOUNCE
                    });
                    } else {
                        var marker = new google.maps.Marker({
                            map: map,
                            position: myCenter[i]
                    });
                    }
                    google.maps.event.addListener(marker, 'mouseover', (function(marker, content) {
                        return function() {
                            infowindow.setContent(content);
                            infowindow.open(map, marker);
                        }
                    })(marker, content));
                    if (i == 0) {
                        infowindow.setContent(content);
                        infowindow.open(map, marker);
                    }                        
                }
                                 
                                 
            }            

            
                
    }
}());

$( document ).ready(function() { 
    google.maps.event.addDomListener(window, 'load', jsInit.initialize());
	
    //get geolocation
    getLocation();
        
        
});


