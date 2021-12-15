<template>
    <div id="grocery-container">
      <div id="nav">
        <nav-bar></nav-bar>
      </div>
      <div id="glist">
        <add-grocery-list />
      </div>
      <div id="googmap">
        <google-maps />
      </div>
    </div>
</template>
<script>
import NavBar from '../components/NavBar.vue';
import GoogleMaps from '../components/GoogleMaps'
import AddGroceryList from '../components/AddGroceryList';

export default {
  name: "grocery-list",
  components: {
    NavBar,
    GoogleMaps,
    AddGroceryList
  }
};
</script>,

<style>
#grocery-container{
  height: 100vh;
  overflow: scroll;
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