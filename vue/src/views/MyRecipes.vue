<template>
    <div id="my-recipes-container">
        <nav-bar></nav-bar>
        <my-recipes-list></my-recipes-list>
        
    </div>
</template>
<script>

import NavBar from '../components/NavBar.vue';
import myRecipesList from '../components/MyRecipesList.vue';
import "bulma/css/bulma.css";


export default {
  name: "my-recipes",
  components: {
    NavBar,
    myRecipesList
    
  }
};
</script>
<style>
#my-recipes-container{
  height: 100vh;
  overflow: scroll;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>