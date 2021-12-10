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
}