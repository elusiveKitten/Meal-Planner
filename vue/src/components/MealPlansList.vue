<template>
<div id="meal-plan-display">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
    <h1 id="meal-plan-title">My Meal Plans</h1>
    <div class="mealPlans">

    <!--need pathing for this-->
    </div>
</div>
</template>


<script>
import mealPlanService from "../services/MealPlanService";
export default {
  data() {
    return {
      mealPlans: [],
    };
  },
  created() {
    mealPlanService.getMealPlans(this.$store.state.user.userId).then((response) => {
      this.mealPlans = response.data;
    });
    console.log("after get");
  },
};
</script>
<style>
#meal-plan-title {
  font-family: "Sacramento", cursive;
  font-size: 55px;
  color: #ee3f0a;
  text-shadow: 2px 2px 1px #1a0b06;
  font-weight: bold;
  margin-top: 20px;
  margin-left: 20px;
}
</style>