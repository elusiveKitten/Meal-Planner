import axios from 'axios';
const http = axios.create({
    baseURL: "https://localhost:44315/"
})
export default{
    getMealPlans(userId){
        return http.get(`/mealplan/user/${userId}`)
    },
    getMealPlanRecipes(mealPlanId){
        return http.get(`/mealplan/recipes/${mealPlanId}`)
    },
    createMealPlan(newMealPlan){
        return http.post(`/mealplan/create`, newMealPlan)
    }
   
}