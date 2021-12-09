<!--added for googlemap function-->
<template>
  <div>
      <div style="display: flex; align-items: center; justify-content: space-between"></div>
      <h1> Your coordinates:</h1>
      <p>{{ coordinates.lat}} Latitude, {{ coordinates.lng}} Longitude</p>
      <GmapMap
      :center="coordinates"
      :zoom="7"
      style="width:640px; height:360px; margin: 32px; auto;"
      ref="mapRef"
      @dragend="handleDrag"
      ></GmapMap>
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

</style>