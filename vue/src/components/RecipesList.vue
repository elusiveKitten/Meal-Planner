<template>
    <div>
        <h1>{{ title }}</h1>
        <div class = "recipes">
            <div
            class="recipe" 
            v-for="recipe in recipes"
            v-bind:key="recipe.recipeId">
            <h1>{{recipe.recipeName}}</h1>
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
            title: "All Recipes"
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