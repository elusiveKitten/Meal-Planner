import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getIngredients(){
        return http.get('/ingredient/all')
    }
}