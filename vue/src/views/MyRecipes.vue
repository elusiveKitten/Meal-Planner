<template>
    <div id="my-recipes-container">
        <nav-bar></nav-bar>
        <h1>My Recipes</h1>
        
    </div>
</template>
<script>
import NavBar from '../components/NavBar.vue';
export default {
  name: "my-recipes",
  components: {
    NavBar
  }
};
</script>
<style>
#my-recipes-container{
  height: 100vh;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>