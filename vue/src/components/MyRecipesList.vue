<template>
    <div>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
        <h1 class="title">My Recipes</h1>
        <new-recipe-form />
        <my-recipe-service />
        <div class= "recipes">
        <div class="recipe"
        v-for="recipe in filteredList"
        v-bind:key="recipe.userId">
        <div id="info">
        <h2 id="recipe-name">{{recipe.recipeName}}</h2>
        <div id="mealplan-selection">Meal Plan Selection:
            <select id="mealplan-dropdown"  v-model="recipeAndPlan.mealPlanId" required>
        
                <option id="dropdown" v-for="mealPlan in mealPlans" v-bind:value="mealPlan.mealPlanId" v-bind:key="mealPlan.mealPlanId">
                    {{mealPlan.mealPlanName}}</option>
            </select>
        </div>
        <button id="add-btn" v-on:click="recipeAndPlan.recipeId=recipe.recipeId; addRecipe(recipeAndPlan)">Add Recipe to Selected Meal Plan</button>


        <router-link id="link-to-detail" :to="{ name: 'recipe-detail', params: { id: recipe.recipeId } }">Recipe Details</router-link>
         <h3>{{ recipe.category }}</h3>
         </div>
        <img id="image" v-bind:src="recipe.image" />
        </div>
        </div>
        </div>
</template>
<script>
import myRecipeService from '../services/MyRecipeService';
import NewRecipeForm from '../components/NewRecipeForm.vue';
import mealPlanService from '../services/MealPlanService';
import recipeService from '../services/RecipeService';

export default {
    components:{
        myRecipeService,
        NewRecipeForm
    },
  data(){
      return{
          mealPlans: [],
          recipeAndPlan:{
              recipeId: 0,
              mealPlanId: 0
          },
          userRecipes: [],
          filter:{
              recipeName: "",
              dishType: "",
              category: "",
          }
      };
  },
  created(){
      myRecipeService.getRecipes(this.$store.state.user.userId).then((response) =>{
          this.userRecipes = response.data;
      });
         mealPlanService.getMealPlans(this.$store.state.user.userId).then((response) =>{
              this.mealPlans = response.data;
         });
  
  },
  computed:{
      filteredList(){
          let filteredRecipes = this.userRecipes;
          if(this.filter.recipeName != "") {
              filteredRecipes = filteredRecipes.filter((recipe) =>
              recipe.recipeName.toLowerCase().includes(this.filter.recipeName.toLowerCase())
              );
          }
          if(this.filter.dishType != ""){
              filteredRecipes = filteredRecipes.filter((recipe) =>
              recipe.dishType === this.filter.dishType
              );
          }
           if (this.filter.category != "") {
            filteredRecipes = filteredRecipes.filter((recipe) => 
            recipe.category === this.filter.category
            );
          
      }
      return filteredRecipes;
      }
  },
  methods:{
      addRecipe(recipeAndPlan){
          
          recipeService.addRecipeToMealPlan(recipeAndPlan).then((response) =>{
              if(response.status === 201){
                  console.log("Recipe successfully added to Meal Plan");
              }
          })
      },

  }
  
  
};
</script>
<style>
.title{/*"My Recipes"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#ee3f0a;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 20px;
}
.recipe{/*the dark grey transparent box*/
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  width: 40%;
  background-color: rgba(0,0,0,0.5);
  font-weight:bold;
}
.recipes{
    display:flex;
    justify-content:center;
    align-items: center;
    flex-direction: column;
    overflow: hidden;
}
#image{
    height: 150px;
    border-radius: 5px;
}
.recipe h3{/*the category*/
    height:fit-content;
    background-color: #56aa54;
    padding: 2px;
    border-radius: 5px;
    color: white;
    font-size: 16px;
    justify-content: flex-end;
    margin-top: 5px;
}
#link-to-detail {
  font-weight: normal;
  color: white;
  font-size: 16px;
}
#link-to-detail:hover{
    color: #56aa54;
}
#recipe-name {
  font-family:'Sacramento', cursive;
  font-weight: bold;
  font-size: 40px;
  text-shadow: 2px 2px 2px black;
  color:#ee3f0a;
  margin-bottom: -20px;
  width:fit-content;
}
#mealplan-selection{
    margin-top: -50px;
    font-weight: normal;
    font-size: 16px;
}
#mealplan-dropdown{
    width: 200px;
    color:#ee3f0a;
}
#add-btn{
    height:fit-content;
    background-color: rgba(255, 255, 255, 0.4);
    padding: 5px;
    border-radius: 5px;
    color: white;
    border: none;
    font-size: 16px;
}
#add-btn:hover{
    background-color:  #56aa54;
}
#dropdown{
    background-color:rgba(255, 255, 255, 0.4);
}
#info{
    display: flex;
    flex-direction: column;
}
</style>
