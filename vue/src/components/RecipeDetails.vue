<template>
  <div id="card-container">
    <h2>{{ recipe.recipeName }}</h2>

    <div id="recipe-card">
      <div id="description">
        <p>Dish Type: {{ recipe.dishType }}</p>
        <p>Calories: {{ recipe.calories }}</p>
        <p>Category: {{ recipe.category }}</p>
      </div>
      <div id="instructions">
        <p>Instructions:</p>
        <p>{{ recipe.instructions }}</p>
      </div>
      <img
        id="image2"
        src="https://admissions.ncsu.edu/wp-content/uploads/sites/19/2020/08/200.jpeg"
      />
    </div>
  </div>
</template>

<script>
import recipeService from "../services/RecipeService";
export default {
  data() {
    return {
      recipe: [],
    };
  },
  created() {
    recipeService.getRecipeById(this.$route.params.id).then((response) => {
      this.recipe = response.data;
    });
  },
};
</script>
<style>
@import "https://use.fontawesome.com/releases/v5.5.0/css/all.css";
h2 {
  font-size: 65px;
  width: 40%;
  margin: 0;
  padding: 0 0 20px;
  text-align: center;
  font-family: "Sacramento", cursive;
  font-weight: bold;
  text-shadow: 2px 2px 1px #1a0b06;
  color: #ee3f0a;
}
#card-container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
#recipe-card {
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  width: 35%;
  background-color:  rgba(0,0,0,0.5);
  color: white;
  font-weight: bold;
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas:
    "description img"
    "instructions instructions"; 
}
#image2 {
  height: 200px;
  width:200px;
  grid-area: img;
  margin-left: 120px;
  border-radius: 5px;
}
#description{
    display:flex;
    flex-direction: column;
    margin-right: 50px;
}
#instructions{
    grid-area: instructions;
}
p{
    width: 90%;
}


</style>