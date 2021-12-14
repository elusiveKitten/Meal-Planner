<template>
  <div>
    <div class="grocerylist-display">
      <h1 id="title1">Grocery List</h1>
      <div class="grocery-list">
        <div class="ingredients"
        v-for="ingredient in groceryItems"
        v-bind:key="ingredient">
        <div id="info">
          <p id="ingredient-name">{{ingredient}}</p>
        </div>
        </div>
      </div>
    </div>
        

  </div>
</template>

<script>
import groceryListService from '../services/GroceryListService';

import "bulma/css/bulma.css";
export default {
    data() {
        return {
            newItem: "",
            groceryItems: [],
            filter: {
              ingredient: "",
            }
        }
    },
    created() {
      groceryListService.getIngredients(this.$store.state.user.userId).then((response) => {
        this.groceryItems=response.data;
      });
    },
      computed: {
    filteredList() {
      let filteredIngredients = this.ingredients;
      if (this.filter.ingredientName != "") {
        filteredIngredients = filteredIngredients.filter((ingredient) =>
          ingredient.ingredientName
            .toLowerCase()
            .includes(this.filter.ingredientName.toLowerCase())
        );
      }
      return filteredIngredients;
    },
  },
}
</script>

<style>
.title{/*"Grocery List"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#ee3f0a;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 20px;
}
</style>