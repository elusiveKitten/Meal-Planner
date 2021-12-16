<template>
  <div id="meal-plan-card-container">
      <h1 id="meal-plan-title">Meal Plan Details</h1>
      <div class="meal-plan-recipes">
          <div class="meal-plan-recipe"
          v-for="recipe in recipes"
          v-bind:key="recipe.recipeId">
          <div id="recipe-info">
              <h1 id="recipe-name">{{recipe.recipeName}}</h1>
              <router-link
            id="link-to-detail2"
            :to="{ name: 'recipe-detail', params: { id: recipe.recipeId } }"
            >Recipe Details</router-link
          >
          </div>
          </div>
      </div>
  </div>
</template>

<script>
import mealPlanService from "../services/MealPlanService";
export default {
    data(){
        return {
            recipes: []
        }
    },
    created(){
        mealPlanService.getMealPlanRecipes(this.$route.params.mealPlanId).then((response) =>{
            this.recipes = response.data;
        });
        }
    }

</script>

<style>
.meal-plan-recipe {
  /*the dark grey transparent boxes each recipe is in*/
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  display: flex;
  justify-content: space-between;
  width: 35%;
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  font-weight: bold;
}
.meal-plan-recipes {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  overflow: hidden;
  
}
#meal-plan-title{
  font-family: "Sacramento", cursive;
  font-size: 55px;
  color: #ee3f0a;
  text-shadow: 2px 2px 1px #1a0b06;
  font-weight: bold;
  margin-top: 20px;
  margin-left: 20px;
}
#recipe-name{
    margin-bottom:30px;
}
#link-to-detail2{
  color: white;
  font-size: 16px;
}
#link-to-detail2:hover{
  color: #56aa54;
}
</style>