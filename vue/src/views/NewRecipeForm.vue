<template>
    <div id="container">
      <nav-bar />
      <new-recipe-form />
</template>

<script>
import NavBar from '../components/NavBar.vue';
import NewRecipeForm from '../components/NewRecipeForm.vue';

export default {
    components:{
        NavBar,
        NewRecipeForm
    }

}
</script>

<style>
#container{
  height: 100vh;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;
}
</style>