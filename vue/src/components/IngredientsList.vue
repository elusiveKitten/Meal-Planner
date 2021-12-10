<template>
<div>
    <h1>Ingredients List</h1>
    <div class="ingredients">
        <div
        class="ingredient" 
        v-for="ingredient in ingredients"
        v-bind:key="ingredient.ingredientId">
        <h2>{{ingredient.ingredientName}}</h2>
        </div>
    </div>
</div>
</template>
<script>
import ingredientService from '../services/IngredientService';
export default{
    data(){
        return{
            ingredients:[],
        };
    },
    created(){
        ingredientService.getIngredients().then(response =>{
            this.ingredients = response.data;
        });
        console.log("after get");
    }
};
</script>