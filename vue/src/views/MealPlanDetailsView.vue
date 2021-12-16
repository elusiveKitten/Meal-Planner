<template>
    <div id="meal-plan-details-container">
        <nav-bar />
        <meal-plan-details />
    </div>
</template>

<script>
import MealPlanDetails from '../components/MealPlanDetails.vue'
import NavBar from '../components/NavBar.vue'
export default {
  components: { NavBar, MealPlanDetails },

}
</script>

<style>
#meal-plan-details-container{
  height: 100vh;
  overflow: scroll;
  background-image: url("https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg");
  background-size: cover;}
</style>