<template>
  <div id="meal-plan-display">
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap"
      rel="stylesheet"
    />
    <h1 id="meal-plan-title">My Meal Plans</h1>
    <div id="form-container">
      <form>
        <label id="new-label-title" for="mealPlan">Create a New Meal Plan:</label>
        <input
          id="ingredientInput"
          type="text"
          v-model="mealPlan.mealPlanName"
          autocomplete="off"
        />
        <button id="saveBtn" v-on:click="submitForm">Save</button>
      </form>
    </div>
    
    <div class="meal-plans">
      <div
        class="meal-plan"
        v-for="mealPlan in mealPlans"
        v-bind:key="mealPlan.mealPlanId"
      >
        <div id="meal-plan-card">
          <h1 id="meal-plan-id">Meal Plan #{{ mealPlan.mealPlanId }}</h1>
          <h1 id="meal-plan-name">{{ mealPlan.mealPlanName }}</h1>
          <router-link
            id="link-to-detail"
            :to="{
              name: 'meal-plan-details',
              params: { mealPlanId: mealPlan.mealPlanId },
            }"
            >Meal Plan Details</router-link
          >
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import mealPlanService from "../services/MealPlanService";
export default {
  data() {
    return {
      mealPlans: [],
      mealPlan:{
        mealPlanName: ""
      }
    };
  },
  created() {
    mealPlanService.getMealPlans(this.$store.state.user.userId).then((response) => {
      this.mealPlans = response.data;
    });
    console.log("after get");
  },
  methods: {
    submitForm() {
      const newMealPlan = {
        userId: Number(this.$store.state.user.userId),
        mealPlanName: this.mealPlan.mealPlanName
      };
      mealPlanService.createMealPlan(newMealPlan).then((response)=>{
        if(response.status === 201){
          console.log("success");
        }
      })
    }
  }
};
</script>
<style>
#meal-plan-title {
  font-family: "Sacramento", cursive;
  font-size: 55px;
  color: #ee3f0a;
  text-shadow: 2px 2px 1px #1a0b06;
  font-weight: bold;
  margin-top: 20px;
  margin-left: 20px;
}
.meal-plan {
  /*the dark grey transparent box*/
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
  display: flex;
  justify-content: space-between;
  width: 35%;
  background-color: rgba(0, 0, 0, 0.5);
  font-weight: bold;
}
.meal-plans {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  overflow: hidden;
}
#meal-plan-name {
  font-family: "Sacramento", cursive;
  font-size: 55px;
  color: #56aa54;
  text-shadow: 2px 2px 1px #1a0b06;
  font-weight: bold;
}
#meal-plan-id {
  color: white;
  font-weight: bold;
  font-size: 24px;
  text-shadow: 1px 1px 5px #ee3f0a;
}
#saveBtn{
  height:fit-content;
  width: fit-content;
  background-color: #56aa54;
  border-radius: 5px;
  border: none;
  color: white;
}
#new-label-title{
  font-family: "Sacramento", cursive;
  text-shadow: 2px 2px 1px #1a0b06;
  font-size: 40px;
  font-weight: bold;
  color: #56aa54;
}
</style>