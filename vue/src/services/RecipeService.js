import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getRecipes(){
        return http.get('/recipe/all')
    },
    getRecipeById(recipeId){
        return http.get(`/recipe/${recipeId}`)
    },
    addUserRecipe(newUserRecipe){
        return http.post(`/recipe/add`,newUserRecipe);
    },
    createRecipe(newRecipe){
        return http.post(`/recipe/create`, newRecipe);
    },
    deleteRecipeFromMealPlan(recipeToDelete){
        return http.delete(`/recipe/mealplan/delete`,recipeToDelete)
    },
    addRecipeToMealPlan(recipeAndPlan){
        return http.post('recipe/mealplan/add', recipeAndPlan)
    }
}