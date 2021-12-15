<template>
  <div>
    <div class="grocerylist-display">
      <h1 id="title">Grocery List</h1>
      <div class="grocery-list">
        <div id="groceries"
        v-for="ingredient in groceryItems"
        v-bind:key="ingredient">
        <div id="info">
          <h1>{{ingredient}}</h1>
        </div>
        </div>
      </div>
    </div>
     <!-- <ul id="example">
       <li type="checkbox v-for="ingredient in groceryItems"
       v-bind:key="ingredient">
       {{ingredient}}
       </li>
     </ul>    -->

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
/* .grocery-list {
  width: 45%;
  align-items: stretch;
  display: flex;
  flex-flow: row wrap;
  justify-content: flex-start;
  margin-top: 50px;
  
} */
/* .groceries {
  border-radius: 6px;
  padding: 1rem;
  margin: 3px;
  width: 30%;
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  font-weight: bold;
} */
.title{/*"Grocery List"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#ee3f0a;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 20px;
}
.grocerylist-display {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
}
#info {
  font-weight: bold;
  font-size: 17px;
}
#groceries {
  border-radius: 6px;
  padding: 1rem;
  margin: 2px;
  width: 30%;
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  font-weight: bold;
}
.grocery-list {
  width: 45%;
  align-items: stretch;
  display: flex;
  flex-flow: row wrap;
  justify-content: flex-start;
  margin-top: 15px;
  margin-left: 10px;
}
</style>