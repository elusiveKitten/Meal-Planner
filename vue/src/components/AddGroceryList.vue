<template>
  <div>
      <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
        <h1 class="title">Grocery List</h1>
        <div id="grocery-search">
            <form
            id="add-grocery-ingredient"
            v-on:submit.prevent="createGroceryItems()"
            >
                  <!-- <input
        type="text"
        placeholder="Search..."
        id="groceryIngredientFilter"
        v-model="filter.groceryIngredient"
      /> -->
            <input class="add-ingredient-box" type="text" v-model="newItem" placeholder="Add New Ingredient" />
            <br/>
            <button id="button-submit" type="submit" class="button-save">Add</button>
            </form>
        </div>

  </div>
</template>

<script>
import GroceryListService from '../services/GroceryListService';
import "bulma/css/bulma.css";
export default {
    datea() {
        return {
            newItem: "",
            groceryItems: [],
        }
    },
    methods: {
        createGroceryItems(){
      GroceryListService.getIngredients(this.$store.state.user.userId).then((response) =>{
          this.getIngredients = response.data;
      });
  },
    }
}
</script>

<style>
.title{/*"Grocery List"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#56aa54;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 20px;
}
.add-ingredient-box {
  width: 25vw;
  height: 4vh;
  background-color: rgba(255, 255, 255, 0.4);
}
input {
  padding: 12px;
  font-size: 1em;
  border-radius: 6px;
  border: 1px solid rgb(129, 129, 129);
}
#button-submit {
  margin: 12px;
  font-size: 1em;
  color:  #56aa54;
}
</style>