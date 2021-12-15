<template>
  <div>
    <div class="grocerylist-display">
      <h1 id="title">Grocery List</h1>
      <div class="grocery-list">
        <ul>
        <li v-for="ingredient in groceryItems" v-bind:key="ingredient">
          <input type="checkbox">
          {{ingredient}}
                  <span class="delete" v-on:click="deleteIngredient(ingredient)">×</span>
          </li>
          </ul>
      </div>
      <div id="print-grocery-list">
	<button id="print-grocery-list-button" @click="printWindow()">Print</button>
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
    methods: {
      deleteIngredient(ingredientToDelete) {
      this.groceryItems = this.groceryItems.filter((ingredient) => {
        return ingredient !== ingredientToDelete;
      });
    },
      printWindow: function () {
        window.print();
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
 .grocery-list {/*checkbox list of items*/
  border-radius: 6px;
  padding: 20px;
  margin: 3px;
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  font-weight: normal;
  height:fit-content;
  width:27%;
  align-items: stretch;
  display: flex;
  flex-flow: row wrap;
  justify-content: flex-start;
  margin-top: 15px;
  margin-left: 30px;
} 
.title{/*"Grocery List"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#ee3f0a;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 50px;
}
.grocerylist-display {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
}
.grocery-list {
  padding: 10px;
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
#print-grocery-list-button {
  height: 30px;
  width: 60px;
  border-radius: 5px;
  margin-left: 160px;
  margin-top: 5px;
  font-size: 1em;
  background-color:  #56aa54;
  color: #edeeeb;
  border: none;
}
</style>