<template>
  <div class="ingredient-display">
    <h1 id="title">Ingredients List</h1>
    <div id="form-container">
      <form>
        <label id="label-title" for="ingredient">Add new ingredient to the Database</label>
        <input
          id="ingredientInput"
          type="text"
          v-model="ingredient.ingredientName"
          autocomplete="off"
        />
        <button id="saveBtn" v-on:click.prevent="submitForm">Save</button>
        <h4 v-show="success">Successfully added to ingredient database</h4>
        <h4 v-show="error">
          There was an error adding the ingredient to the database
        </h4>
      </form>
    </div>

    <div id="filter-container">
      <input
        id="ingredientsNameFilter"
        type="text"
        placeholder="Search..."
        v-model="filter.ingredientName"
      />
    </div>
    <div class="ingredients">
      <div
        class="ingredient"
        v-for="ingredient in filteredList"
        v-bind:key="ingredient.ingredientId"
      >
        <h1>{{ ingredient.ingredientName }}</h1>
      </div>
    </div>
  </div>
</template>
<script>
import ingredientService from "../services/IngredientService";
export default {
  data() {
    return {
      ingredients: [],
      filter: {
        ingredientName: "",
      },
      ingredient: {
        ingredientName: "",
      },
      success: false,
      error: false,
    };
  },
  created() {
    ingredientService.getIngredients().then((response) => {
      this.ingredients = response.data;
    });
    console.log("after get");
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
  methods: {
    submitForm() {
      const newIngredient = {
        ingredientName: this.ingredient.ingredientName,
      };
      ingredientService
        .addIngredient(newIngredient)
        .then((response) => {
          if (response.status === 201) {
            console.log("success");
            this.success = true;
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "adding");
          this.error = true;
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " ingredient. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " ingredient. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " ingredient. Request could not be created.";
      }
    },
  },
};
</script>
<style>
.ingredient {
  border-radius: 6px;
  padding: 1rem;
  margin: 3px;
  width: 30%;
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  font-weight: bold;
}
.ingredients {
  width: 45%;
  align-items: stretch;
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
  margin-top: 50px;
  margin-left: calc(50% - 22.5%);
}
.ingredient-display {
}
#ingredientsNameFilter {
  width: 41%;
  background-color: rgba(255, 255, 255, 0.4);
}
#filter-container {
  display: flex;
  justify-content: center;
  margin-bottom: -25px;
}
#form-container{
  display:flex;
  justify-content:center;
  padding: 11px;
  
}

#ingredientInput{
  height: 5vh;
  background-color: rgba(255, 255, 255, 0.4);
  padding-right: 10px;

}
#saveBtn{
  margin-left: 10px;
  height: 5vh;
  width: 3vw;
  border-radius: 6px;
  border: 1px solid grey;
}
#label-title{
  font-family:"Sacramento", cursive;
  font-size: 35px;
  color: #6BAB7F;
  font-weight:bold;
  text-shadow: 1px 1px 1px #1a0b06;
  margin-right: 12px
}
</style>