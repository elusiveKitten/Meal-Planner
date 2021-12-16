<template>
  <div id="recipe-details-container">
      <nav-bar />
      <recipe-details />
  </div>
</template>

<script>
import NavBar from '../components/NavBar.vue'
import RecipeDetails from '../components/RecipeDetails.vue'
export default {
  components: { NavBar, RecipeDetails },

}
</script>

<style>
#recipe-details-container{
  height: 100vh;
  overflow: scroll;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>