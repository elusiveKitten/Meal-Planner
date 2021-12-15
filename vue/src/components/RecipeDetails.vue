<template>
  <div id="card-container">
    <h2>{{ recipe.recipeName }}</h2>

    <div id="recipe-card">
      <div id="description">
        <p>Dish Type: {{ recipe.dishType }}</p>
        <p>Calories: {{ recipe.calories }}</p>
        <p>Category: {{ recipe.category }}</p>
        <p>Instructions:</p>
        <p>{{ recipe.instructions }}</p>
        <button class="button is-primary" @click.prevent="addToMyRecipes">Add To My Recipes</button>
      <h4 v-show="success">Successfully added to My Recipes</h4>
      <h4 v-show="error">There was an error adding the recipe to My Recipes</h4>
      </div>
      


      <img
        id="image2"
        :src="recipe.image"
      />
    </div>
  </div>
</template>

<script>
import "bulma/css/bulma.css";
import recipeService from "../services/RecipeService";
export default {
  data() {
    return {
      recipe: [],
      userRecipe: {
        userId: "",
        recipeId: "",
      },
      errorMsg:"",
      success: false,
      error: false
    };
  },
  created() {
    recipeService.getRecipeById(this.$route.params.id).then((response) => {
      this.recipe = response.data;
    });
  },
  methods: {
    addToMyRecipes() {
      const newUserRecipe = {
        userId: Number(this.$store.state.user.userId),
        recipeId: Number(this.$route.params.id),
      };
      recipeService
        .addUserRecipe(newUserRecipe)
        .then((response) => {
          if (response.status === 201) {
            console.log("Successfully added recipe to MyRecipes");
            this.success = true;
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "adding");
          this.error= true;
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " recipe. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg = "Error " + verb + " recipe. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " recipe. Request could not be created.";
      }
    },
  },
};
</script>
<style>
@import "https://use.fontawesome.com/releases/v5.5.0/css/all.css";
h2 {
  font-size: 65px;
  width: 40%;
  padding: 0 0 20px;
  text-align: center;
  font-family: "Sacramento", cursive;
  font-weight: bold;
  text-shadow: 2px 2px 1px #1a0b06;
  color: #ee3f0a;
}
#card-container {
  display: flex;
  align-items: center;
  flex-direction: column;
}
#recipe-card {
  border-radius: 6px;
  padding: 1rem;
  width: 35%;
  background-color:  rgba(0,0,0,0.5);
  color: white;
  font-weight: bold;
  
  
}
#image2 {
  height: 200px;

  grid-area: img;

  border-radius: 5px;
}
#description {
  grid-area: description;
  display: flex;
  flex-direction: column;
  margin-bottom:5px;
  
}
p {
  width: 100%;
  margin: 5px;
}
button{
  margin-bottom: 10px;
  width: fit-content;
}
</style>