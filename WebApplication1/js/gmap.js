$(function () {

    
    google.maps.event.addDomListener(window, 'load', LoadGoogleMAP); 
});


function LoadGoogleMAP() {
   // debugger
    var map;
   
    var SetmapOptions = {
        zoom: 10,
        center: new google.maps.LatLng(28.6221699, 77.300913)
    };
    map = new google.maps.Map(document.getElementById('canvasMap'),
        SetmapOptions);

    
}

 