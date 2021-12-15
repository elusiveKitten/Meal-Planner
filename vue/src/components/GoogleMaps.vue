<template>
  <div>
    <div class="grocery-stores">
      <h4 id="map-header-text">Find a Grocery Store Nearby</h4>

      <label>
        <gmap-autocomplete class="enter-location-box" @place_changed="initMarker"></gmap-autocomplete>
     
      </label>
      <button id="button-addpin" @click="addLocationMarker" style="float: left;">Add Pin</button>
      <br/>
 
    <!-- </div>
    <br>
    <div class="g-map"> -->
    <GmapMap
        :zoom="11"    
        :center="center"
        :options="mapOptions"
        @click="handleMapClick"
        style="width:25vw; height: 35vh"

      >
      <GmapMarker
        :key="index"
        title: p.name
        v-for="(marker, index) in locationMarkers"
        :position="marker.position"
        :clickable="true"
        :draggable="true"
        @click="center=marker.position"
      ></GmapMarker>
      <!-- Info window -->
    <GmapInfoWindow 
      :options="infoOptions" 
      :position="infoWindowPos" 
      :opened="infoWinOpen" 
      @closeclick="infoWinOpen=false"
    >
      <!-- Info card -->
      <GmapInfoCard :marker="infoContent"></GmapInfoCard>
    </GmapInfoWindow>
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
        this.map.setZoom(5);
        this.existingPlace = null;
      };
          google.maps.event.addListener(marker, 'click', function() {
      infowindow.setContent(place.name);
      infowindow.open(map, this);
    });
    },
          toggleInfoWindow (marker, index) {
        this.infoContent = marker
        this.infoWindowPos = marker.position

        //check if its the same marker that was selected if yes toggle
        if (this.currentMindex === index) {
          this.infoWinOpen = !this.infoWinOpen
        }
        // if different marker set infowindow to open and reset current marker index
        else {
          this.infoWinOpen = true
          this.currentMindex = index
        }
      },

    locateGeoLocation: function() {
      navigator.geolocation.getCurrentPosition(res => {
        this.center = {
          lat: res.coords.latitude,
          lng: res.coords.longitude
        };
        map.setZoom(5);
        map.panTo(marker.position);
      });
    }
  }
};
</script>
<style>
.grocery-stores {
  margin-top: -500px;
  margin-right: 40px;
  margin-bottom: 15px;
  display: flex;
  align-items: flex-end;
  flex-direction: column;
  justify-content: flex-end;
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
#button-addpin {
  height: 30px;
  border-radius: 5px;
  margin: 5px;
  font-size: 1em;
  background-color:  #56aa54;
  color: #edeeeb;
  border: none;
}
#map-header-text {
  font-family: 'Sacramento', cursive;
  font-size: 45px;
  font-weight: bold;
  color: #ee3f0a;
  text-shadow: 2px 2px 1px #1a0b06;
}
input {
  padding: 12px;
  font-size: .8em;
  border-radius: 6px;
  border: 1px solid rgb(129, 129, 129);
} 
</style>     