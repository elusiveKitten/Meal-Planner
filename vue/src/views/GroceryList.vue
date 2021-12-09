<template>
    <div id="grocery-container">
        <nav-bar></nav-bar>
        <google-map /> <!--added for googlemap function-->
        <nearby-places /> <!--added for googlemap function-->
        
    </div>
</template>
<script>
import NavBar from '../components/NavBar.vue';
import NearbyPlaces from '../components/NearbyPlaces'; //added for googlemap function
import GoogleMap from '../components/GoogleMap'; //added for googlemap function


export default {
  name: "grocery-list",
  components: {
    NavBar,
    GoogleMap, //added for googlemap function
    NearbyPlaces //added for googlemap function
  }
};
</script>,

<style>
#grocery-container{
  height: 100vh;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>