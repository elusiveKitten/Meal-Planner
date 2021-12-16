<template>
    <div id="mealplan-container">
        <nav-bar></nav-bar>
        <meal-plans-list />
        
    </div>
</template>
<script>
import MealPlansList from '../components/MealPlansList.vue';

import NavBar from '../components/NavBar.vue';
export default {
  name: "my-meal-plans",
  components: {
    NavBar,
    MealPlansList
  }
};
</script>
    MealPlansList
<style>
#mealplan-container{
  height: 100vh;
  overflow: scroll;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>