<template>
    <div id="all-recipes-container">
        <nav-bar></nav-bar>
        <recipes-list />
        
    </div>
</template>
<script>
import NavBar from '../components/NavBar.vue';
import RecipesList from '../components/RecipesList.vue';
export default {
  name: "all-recipes",
  components: {
    NavBar,
    RecipesList
  }
};
</script>
<style>
#all-recipes-container{
  height: 100vh;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;
}
</style>