<template>
    <div id="recipe-display">
        <h1>{{ title }}</h1>
        <div class = "recipes">
            <div
            class="recipe" 
            v-for="recipe in recipes"
            v-bind:key="recipe.recipeId">
            <div>
            <h1>{{recipe.recipeName}}</h1>
            <router-link :to="{name: 'recipe-detail', params: {id: recipe.recipeId}}">Recipe Details</router-link>
            </div>
            <img id="image" v-bind:src="'https://via.placeholder.com/150'" />
            </div>
        </div>
    </div>
</template>
<script>
import recipeService from '../services/RecipeService';
export default {
    data(){
        return{
            recipes:[],
            title: "All Recipes",
        };
    },
    created(){
        recipeService.getRecipes().then(response =>{
            this.recipes = response.data;
        });
        console.log("after get");
    }
};
</script>
<style>
.recipe{
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  display:flex;
  justify-content: space-between;
  width: 35%;
  background-color: rgba(40, 65, 94, 0.3);
  color: white;
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
    height: 80px;
}
</style>