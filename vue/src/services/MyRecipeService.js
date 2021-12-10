import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getRecipes(userId){
        return http.get(`/recipe/user/${userId}`)
    },
    /*addRecipe(recipe){
        return http.post('/recipe', recipe);
    },
    updateRecipe(recipe){
        return http.put(`/recipe/${recipeId}`, recipe);
    }*/
}