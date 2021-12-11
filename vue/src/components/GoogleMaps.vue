<template>
  <div>
    <div class="grocery-stores">
      <p>Find a Grocery Store Nearby</p>

      <label>
        <gmap-autocomplete class="enter-location-box" @place_changed="initMarker"></gmap-autocomplete>
     
      </label>
      <button id="button-addpin" @click="addLocationMarker">ADD A PIN</button>
      <br/>
 
    <!-- </div>
    <br>
    <div class="g-map"> -->
    <gmap-map
        :zoom="11"    
        :center="center"
        style="width:35vw; height:50vh; margin; auto;"
      >
      <gmap-marker
        :key="index"
        v-for="(m, index) in locationMarkers"
        :position="m.position"
        @click="center=m.position"
      ></gmap-marker>
    </gmap-map>
    </div>
  </div>
</template>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAXt6fzkeW76UH90EaA4rAhro7woiMvccE&callback=myMap"></script>
<script>
export default {
  name: "AddGoogleMap",
  data() {
    return {
      center: { 
        lat: 0,
        lng: 0
      },
      locationMarkers: [],
      locPlaces: [],
      existingPlace: null
    };
  },
 
  mounted() {
    this.locateGeoLocation();
  },
 
  methods: {
    initMarker(loc) {
      this.existingPlace = loc;
    },
    addLocationMarker() {
      if (this.existingPlace) {
        const marker = {
          lat: this.existingPlace.geometry.location.lat(),
          lng: this.existingPlace.geometry.location.lng()
        };
        this.locationMarkers.push({ position: marker });
        this.locPlaces.push(this.existingPlace);
        this.center = marker;
        this.existingPlace = null;
      };
        var infowindow = new google.maps.infowindow();
	this.places.forEach((place) => {
		const lat = place.geometry.location.lat;
		const lng = place.geometry.location.lng;
		let marker = new google.maps.Marker({
			position: new google.maps.LatLng(lat, lng),
			map: map
    });
    google.maps.event.addListener(marker, "click", () => {
      infowindow.setContent(
        <div class="header">${place.name}${place.vicinity}</div>
      )
    })
	})
    },
    locateGeoLocation: function() {
      navigator.geolocation.getCurrentPosition(res => {
        this.center = {
          lat: res.coords.latitude,
          lng: res.coords.longitude
        };
      });
    }
  }
};
</script>
<style>
.grocery-stores {
  display: flex;
  align-items: center;
  flex-direction: column;
  border: solid 2px #56aa54;
}
.g-map {
    display: flex;
    align-items: center;
}
.enter-location-box {
  width: 100%;
  background-color: rgba(255, 255, 255, 0.4);
}
#locationFilter {
  width: 35%;
  background-color: rgba(255, 255, 255, 0.4);
}
input {
  padding: 12px;
  font-size: 1.25em;
  border-radius: 6px;
  border: 1px solid rgb(129, 129, 129);
}
#button-addpin {
  margin: 12px;
  font-size: 1.10em;
  color:  #56aa54;
}
</style>     