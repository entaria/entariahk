var jsUtils = (function() {
    // Private stuff up here

    // Public methods here
    return {

        validateEmail: function(emailAddress) {
            var re = new RegExp(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
            if (re.test(emailAddress)) {
                return true;
            }
            else {
                return false;
            }
        },

        // method 2
        method2: function(operand,num) {     //operand = number to be subtracted, num = number subtracted from
            var op = parseFloat(operand);
                if (isNaN(op) == true) {
                    throw new Error ("Not a number");
                }
                return num - op;
        }     
    
    }
}());


//Google Analytics: change UA-XXXXX-X to be your site's ID. -->
(function(b,o,i,l,e,r){b.GoogleAnalyticsObject=l;b[l]||(b[l]=
            function(){(b[l].q=b[l].q||[]).push(arguments)});b[l].l=+new Date;
            e=o.createElement(i);r=o.getElementsByTagName(i)[0];
            e.src='https://www.google-analytics.com/analytics.js';
            r.parentNode.insertBefore(e,r)}(window,document,'script','ga'));
            ga('create','UA-42936379-2');ga('send','pageview');

            
// Geolocation code
var x = document.getElementById("geo-location-holder");
function getLocation()
{
  if (navigator.geolocation)
    {
    navigator.geolocation.getCurrentPosition(showPosition,showError);
    }
  else
  {
    x.innerHTML="Geolocation is not supported by this browser.";
  }
}

function showPosition(position)
{
  var latlon=position.coords.latitude+","+position.coords.longitude;

  /* var img_url="http://maps.googleapis.com/maps/api/staticmap?center="
  +latlon+"&zoom=14&size=400x300&sensor=false";
  x.innerHTML="<img src='"+img_url+"'>";
  */
  x.innerHTML=latlon;
  
}

function showError(error)
{
  switch(error.code) 
    {
    case error.PERMISSION_DENIED:
      x.innerHTML="User denied the request for Geolocation."
      break;
    case error.POSITION_UNAVAILABLE:
      x.innerHTML="Location information is unavailable."
      break;
    case error.TIMEOUT:
      x.innerHTML="The request to get user location timed out."
      break;
    case error.UNKNOWN_ERROR:
      x.innerHTML="An unknown error occurred."
      break;
    }
}


