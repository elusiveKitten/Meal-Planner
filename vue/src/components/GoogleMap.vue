<!--added for googlemap function-->
<template>
  <div>
  <div class="search-pin" style="font-size: 12px;">
      <h3>Search and Add a Pin</h3>
      <GmapAutocomplete
      @place_changed='setPlace'
      />
      <!-- <div style="display: flex; align-items: center; justify-content: space-between"></div> -->
      <!-- <h1> Your coordinates:</h1>
      <p>{{ coordinates.lat}} Latitude, {{ coordinates.lng}} Longitude</p> -->
      <GmapMap
      :center="coordinates"
      :zoom="7"
      style="width:25vw; height:35vh; margin; auto;"
      ref="mapRef"
      >
      <GmapMarker
      :key="index"
      v-for="(m,index) in markers"
      :position="m.position"
      @click="center=m.position"
      />
      </GmapMap>
      </div>
  </div>
</template>

<script>
export default {
    name: "GoogleMap",
    data() {
      return {
        map: null,
        coordinates:{
          lat: 0,
          lng: 0
        }
      }
    },
    created() {
      //get user's coordinates from browser request
      this.$getLocation({})
      .then(coordinates => {
        this.coordinates = coordinates;
      })
      .catch(error => alert(error));
    },
    mounted () {
      // add the map to a data object
      this.$refs.mapRef.$mapPromise.then(map => this.map = map);
    },
    methods: {
      setPlace(place) {
        this.currentPlace = place;
      }
    },
    // geolocate: function() {
    //   navigator.geolocation.getCurrentPosition(position => {
    //     this.center = {
    //       lat: position.coords.latitude,
    //       lng: position.coords.longitude,
    //     }
    //   })
    // },
    computed: {
      mapCoordinates() {
        if(!this.map) {
          return {
            lat: 0,
            lng: 0
          };
        }

        return {
          lat: this.map.getCenter().lat().toFixed(4),
          lng: this.map.getCenter().lng().toFixed(4)
        }
      }
    }
}
</script>

<style>

.search-pin {
  display: flex;
  align-items: center;
  flex-direction: column;
  border: solid 2px #56aa54;
}
</style>