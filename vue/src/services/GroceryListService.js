import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getIngredients(userId){
        return http.get(`/ingredient/grocerylist/${userId}`)
    },
    list() {
        return http.get('/ingredients');
      },
    
}