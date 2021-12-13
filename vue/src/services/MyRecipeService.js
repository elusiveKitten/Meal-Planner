import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getRecipes(userId){
        return http.get(`/recipe/user/${userId}`)
    }
    
}