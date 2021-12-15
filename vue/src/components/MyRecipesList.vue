<template>
    <div>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
        <h1 class="title">My Recipes</h1>
        <new-recipe-form />
        <my-recipe-service />
        <div class= "recipes">
        <div class="recipe"
        v-for="recipe in filteredList"
        v-bind:key="recipe.userId">
        <div id="info">
        <h2 id="recipe-name">{{recipe.recipeName}}</h2>
        <router-link id="link-to-detail" :to="{ name: 'recipe-detail', params: { id: recipe.recipeId } }">Recipe Details</router-link>
         <h3>{{ recipe.category }}</h3>
         </div>
        <img id="image" v-bind:src="recipe.image" />
        </div>
    
        </div>
        </div>
</template>
<script>
import myRecipeService from '../services/MyRecipeService';
import NewRecipeForm from '../components/NewRecipeForm.vue';
import "bulma/css/bulma.css";

export default {
    components:{
        myRecipeService,
        NewRecipeForm
    },
  data(){
      return{
          userRecipes: [],
          filter:{
              recipeName: "",
              dishType: "",
              category: "",
          }
      };
  },
  created(){
      myRecipeService.getRecipes(this.$store.state.user.userId).then((response) =>{
          this.userRecipes = response.data;
      });
  },
  computed:{
      filteredList(){
          let filteredRecipes = this.userRecipes;
          if(this.filter.recipeName != "") {
              filteredRecipes = filteredRecipes.filter((recipe) =>
              recipe.recipeName.toLowerCase().includes(this.filter.recipeName.toLowerCase())
              );
          }
          if(this.filter.dishType != ""){
              filteredRecipes = filteredRecipes.filter((recipe) =>
              recipe.dishType === this.filter.dishType
              );
          }
           if (this.filter.category != "") {
            filteredRecipes = filteredRecipes.filter((recipe) => 
            recipe.category === this.filter.category
            );
          
      }
      return filteredRecipes;
      }
  }
  
  
};
</script>
<style>
.title{/*"My Recipes"*/
font-family: 'Sacramento', cursive;
font-size: 55px;
color:#ee3f0a;
text-shadow: 2px 2px 1px #1a0b06;
font-weight: bold;
margin-top: 20px;
margin-left: 20px;
}
.recipe{/*the dark grey transparent box*/
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  display:flex;
  justify-content: space-between;
  width: 35%;
  background-color: rgba(0,0,0,0.5);
  font-weight:bold;
}
.recipes{
    display:flex;
    justify-content:center;
    align-items: center;
    flex-direction: column;
    overflow: hidden;
}
#image{
    height: 150px;
    border-radius: 5px;
}
.recipe h3{
    height:fit-content;
    background-color: #56aa54;
    padding: 2px;
    border-radius: 5px;
    color: white;
}
#link-to-detail {
  font-weight: bold;
  color: #56aa54;
  font-size: 18px;
}
#recipe-name {
  font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
  font-weight: bold;
  font-size: 24px;
  text-shadow: 1px 1px 5px #ee3f0a;
  color: white;
  margin-bottom: -20px;
  width:fit-content;
}
#info {
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
}
</style>
