<template>
    <div id="ingredients-container">
        <nav-bar></nav-bar>
        <ingredients-list />
        
    </div>
</template>
<script>
import IngredientsList from '../components/IngredientsList.vue';
import NavBar from '../components/NavBar.vue';
export default {
  name: "ingredients",
  components: {
    NavBar,
    IngredientsList
  }
};
</script>
<style>
#ingredients-container{
  height: 100vh;
  overflow:scroll;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>