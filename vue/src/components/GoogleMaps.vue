<template>
  <div>
    <div class="grocery-stores">
      <h4 id="map-header-text">Find a Grocery Store Nearby</h4>

      <label>
        <gmap-autocomplete class="enter-location-box" @place_changed="initMarker"></gmap-autocomplete>
     
      </label>
      <button id="button-addpin" @click="addLocationMarker">Add Pin</button>
      <br/>
 
    <!-- </div>
    <br>
    <div class="g-map"> -->
    <GmapMap
        :zoom="11"    
        :center="center"
        style="width:25vw; height: 35vh"
      >
      <GmapMarker
        :key="index"
        title: p.name
        v-for="(m, index) in locationMarkers"
        :position="m.position"
        :clickable="true"
        @click="center=m.position"
      ></GmapMarker>
    </GmapMap>
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
          google.maps.event.addListener(marker, 'click', function() {
      infowindow.setContent(place.name);
      infowindow.open(map, this);
    });
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

  align-items: center;
  flex-direction: column;
  border: solid 2px #56aa54;
}
.g-map {
    display: flex;
    align-items: center;
}
.enter-location-box { /*adjust the size of the input box*/
  width: 25vw;
  height: 4vh;
  background-color: rgba(255, 255, 255, 0.4);
}
#locationFilter {
  width: 25vw;
  background-color: rgba(255, 255, 255, 0.4);
}
/* input {
  padding: 12px;
  font-size: 1em;
  border-radius: 6px;
  border: 1px solid rgb(129, 129, 129);
} */
#button-addpin {
  margin: 5px;
  font-size: 1em;
  color:  #56aa54;
}
#map-header-text {
  font-size: 1.35em;
  font-weight: bold;
  color: #286128;
}
</style>     