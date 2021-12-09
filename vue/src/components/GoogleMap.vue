<!--added for googlemap function-->
<template>
  <div>
    <div style="display: flex; align-items: center; justify-content: space-between"></div>
     <h1> Your coordinates:</h1>
     <p>{{ coordinates.lat}} Latitude, {{ coordinates.lng}} Longitude</p>
     <GmapMap
      :center="{lat:10, lng:10}"
      :zoom="7"
      style="width:640px; height:360px; margin: 32px; auto;"
      ></GmapMap>
  </div>
</template>

<script>
export default {
    name: "GoogleMap",
    data() {
      return {
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
    }
   
}
</script>

<style>

</style>