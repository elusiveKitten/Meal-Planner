<template>
  <div id="recipe-display">
    <h1 id="title">{{ title }}</h1>
    <div class="recipes">
      <select id="categoryFilter" v-model="filter.category">
        <option value="">All Categories</option>
        <option value="Keto">Keto</option>
        <option value="Low Carb">Low Carb</option>
        <option value="Vegetarian">Vegetarian</option>
        <option value="Mexican">Mexican</option>
        <option value="Easy">Easy</option>
        <option value="Low-Ingredients">Low-Ingredients</option>
      </select>
      <input
        type="text"
        placeholder="Search..."
        id="recipeNameFilter"
        v-model="filter.recipeName"
      />
      <div
        class="recipe"
        v-for="recipe in filteredList"
        v-bind:key="recipe.recipeId"
      >
        <div id="info">
          <h1 id="recipe-name">{{ recipe.recipeName }}</h1>
          <router-link
            id="link-to-detail"
            :to="{ name: 'recipe-detail', params: { id: recipe.recipeId } }"
            >Recipe Details</router-link
          >
          <h3>{{ recipe.category }}</h3>
        </div>
        <img id="image" v-bind:src="recipe.image" />
      </div>
    </div>
  </div>
</template>
<script>
import recipeService from "../services/RecipeService";
import "bulma/css/bulma.css";
export default {
  data() {
    return {
      recipes: [],
      title: "All Recipes",
      filter: {
        recipeName: "",
        category: "",
      },
    };
  },
  created() {
    recipeService.getRecipes().then((response) => {
      this.recipes = response.data;
    });
    console.log("after get");
  },
  computed: {
    filteredList() {
      let filteredRecipes = this.recipes;
      if (this.filter.recipeName != "") {
        filteredRecipes = filteredRecipes.filter((recipe) =>
          recipe.recipeName
            .toLowerCase()
            .includes(this.filter.recipeName.toLowerCase())
        );
      }
      if (this.filter.category != "") {
        filteredRecipes = filteredRecipes.filter(
          (recipe) => recipe.category === this.filter.category
        );
      }
      return filteredRecipes;
    },
  },
};
</script>
<style>
.recipe {
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
.recipes {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  overflow: hidden;
  margin-top: -50px;
}
#image {
  height: 150px;
  border-radius: 5px;
}
#title {
  font-family: "Sacramento", cursive;
  font-size: 55px;
  color: #ee3f0a;
  text-shadow: 2px 2px 1px #1a0b06;
  font-weight: bold;
  margin-top: 20px;
  margin-left: 20px;
}
#recipeNameFilter {
  width: 35%;
  background-color: rgba(255, 255, 255, 0.4);
}
::placeholder {
  color: rgba(0, 0, 0, 0.5);
  font-size: 1em;
}
input {
  padding: 12px;
  font-size: 1.25em;
  border-radius: 6px;
  border: 1px solid rgb(129, 129, 129);
}
#link-to-detail {
  font-size: 16px;
}
#recipe-name {
  font-weight: bold;
  font-size: 24px;
  text-shadow: 1px 1px 5px #ee3f0a;
}
h3 {
  background-color: #56aa54;
  width: fit-content;
  padding: 2px;
  border-radius: 5px;
  color: white;
}
#info {
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
}
select {
  padding: 6px;
  border-radius: 6px;
  background-color: rgba(255, 255, 255, 0.4);
  font-weight: bolder;
  width: 35%;
  color: rgb(141, 141, 141);
  margin-bottom: 10px;
}
option {
  background-color: rgba(255, 255, 255, 0.4);
}
</style>