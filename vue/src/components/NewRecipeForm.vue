<template>
  <div>
    <a
      id="add-recipe-button"
      href="#"
      v-if="showForm === false && recipeId == 0"
      v-on:click.prevent="showForm = true"
      >Add Recipe</a
    >
    <a
      id="add-recipe-button"
      href="#"
      v-if="showForm === false && recipeId != 0"
      v-on:click.prevent="showForm = true"
      >Edit Recipe</a
    >
    <form class="form-box" v-on:submit.prevent="addNewRecipe" v-if="showForm === true">
      <div class="form-element">
        <label for="recipe-name">Recipe Name:</label>
        <input
          id="recipe-box"
          placeholder="Type Recipe Name Here"
          type="text"
          v-model="recipe.recipeName"
          required
          autofocus
        />
      </div>
      <div class="form-element">
        <label for="calories">Calories:</label>
        <input
          id="calories"
          placeholder="Type Calories Here"
          type="text"
          v-model="recipe.calories"
          required
        />
      </div>
      <div class="form-element">
        <label for="dish-type">Dish Type:</label>
        <select id="dish-type" v-model="recipe.dishType" required>
          <option value="">Dish Type</option>
          <option value="Main Dish">Main Dish</option>
          <option value="Side Dish">Side Dish</option>
          <option value="Appetizer">Appetizer</option>
          <option value="Dessert">Dessert</option>
        </select>
      </div>
      <div class="form-element">
        <label for="category">Category:</label>
        <select id="category" v-model="recipe.category" required>
          <option value="">All Categories</option>
          <option value="Keto">Keto</option>
          <option value="Low Carb">Low Carb</option>
          <option value="Vegetarian">Vegetarian</option>
          <option value="Mexican">Mexican</option>
          <option value="Easy">Easy</option>
          <option value="Low-Ingredients">Low-Ingredients</option>
        </select>
      </div>
      <div class="form-element">
        <label for="instructions">Instructions:</label>
        <textarea
          id="instructions"
          placeholder="Type Recipe Instructions Here"
          v-model="recipe.instructions"
          required
        ></textarea>
      </div>
      <div class="image-element">
        <label for="image">Image URL:</label>
        <input
          id="image-file"
          placeholder="Enter Image URL Here"
          type="url"
          v-model="recipe.image"
          required
        />
      </div>
      <input id="create-new-button" type="submit" value="Create New Recipe" />
      <input
        id="cancel"
        type="button"
        value="Cancel"
        v-on:click.prevent="resetForm"
      />
    </form>
  </div>
</template>

<script>
import recipeService from "../services/RecipeService";
export default {
  name: "add-recipe",
  props: {
    recipeId: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {
      showForm: false,
      recipe: {
        recipeName: "",
        calories: "",
        instructions: "",
        image: "",
        category: "",
        dishType: "",
      },
    };
  },
  methods: {
    addNewRecipe() {
      const newRecipe = {
        recipeName: this.recipe.recipeName,
        calories: this.recipe.calories,
        instructions: this.recipe.instructions,
        image: this.recipe.image,
        category: this.recipe.category,
        dishType: this.recipe.dishType,
        userId: Number(this.$store.state.user.userId),
      };
      //add
    //   if (this.recipeId == 0) {
        recipeService.createRecipe(newRecipe).then((response) => {
          if (response.status === 201) {
            console.log("Recipe was successfully added.");
          }
        });
    //   } else {
    //       //update
    //       newRecipe.recipeId = this.recipeId
    //       recipeService.updateRecipe(newRecipe,this.recipeId)
    //       .then(response => {
    //           if(response.status === 200){
    //               console.log("successfully updated")
    //           }
    //       })
    //   }
    },
    resetForm() {
      this.showForm = false;
      this.newRecipe = {};
    },
  },
  computed: {
    editOrAdd() {
      if (this.recipdId == 0) {
        return "Add Recipe";
      } else {
        return "Edit Recipe";
      }
    },
  },
  created() {
    if (this.recipeId != 0) {
      recipeService.getRecipeById(this.recipeId).then((response) => {
        console.log(response.data);
        this.recipe = response.data;
      });
    }
  },
};
</script>

<style>
.form-box {
  /*the dark grey transparent box*/
  border-radius: 6px;
  background-color: rgba(0, 0, 0, 0.5);
  font-weight: normal;
  font-size: 18px;
  color: #ffffff;
  width: 50%;
  margin-bottom: 80px;
  margin-left: 25%;
  padding: 20px;
}
.form-element [type="text"], #instructions, #image-file/*changes from box to a line, makes it transparent instead of white input boxes*/ {
  background: transparent;
  border: none;
  border-bottom: 1px solid #ffffff;
  font-size: 16px;
  padding: 30px;
}
#add-recipe-button,
#create-new-button,
#cancel {
  /*styling for toggle button, create new and cancel*/
  border: none;
  border-radius: 6px;
  margin-left: 2%;
  background: #56aa54;
  color: #ffffff;
  font-size: 17px;
  padding-left: 10px;
  padding-right: 10px;
  padding-top: 5px;
  padding-bottom: 5px;
}
#create-new-button,
#cancel {
  /*spacing for buttons at bottom of page*/
  width: 35%;
  margin-left: 5%;
  margin-top: 20px;
  margin-right: 5%;
}
#cancel:hover {
  /*hovering over cancel button turns it red*/
  background: #ee3f0a;
}
#create-new-button:hover {
  /*hovering over create new recipe button turns it grey*/
  background: #a9b3b4;
  color: #56aa54;
}
#calories,
#recipe-box,
#dish-type,
#category,
#instructions,
#image-file {
  width: 70%;
  padding: 5px;
  margin-left: 10px;
  margin-top: 5px;
  margin-bottom: 5px;
  margin-right: 5px;
  font-size: 16px;
}
.form-element input[type="text"],
#instructions {
  /*text as user types is white for visibility*/
  color: white;
}
#instructions {
  height: 100px;
}
</style>