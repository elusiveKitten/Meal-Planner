<template>
    <div id="grocery-container">
        <nav-bar></nav-bar>
        <add-grocery-list />
        <nearby-places />
        <google-maps />
    
    </div>
</template>
<script>
import NavBar from '../components/NavBar.vue';
import GoogleMaps from '../components/GoogleMaps'
import AddGroceryList from '../components/AddGroceryList';
import NearbyPlaces from '../components/NearbyPlaces';

export default {
  name: "grocery-list",
  components: {
    NavBar,
    GoogleMaps,
    AddGroceryList,
    NearbyPlaces
  }
};
</script>,

<style>
#grocery-container{
  height: 100vh;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;
  }
  /* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
} */
</style>