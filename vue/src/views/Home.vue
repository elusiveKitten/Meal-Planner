<template>

  <div class="home">
    <nav-bar />
    <body>
      <div id="welcome-box">
      <h1 id="welcome">Welcome to Meal Planner!</h1>
      <p id="theWhat">Meal Planner was designed to alleviate the pain associated with the question, "What's for dinner?" Our goal is to make it easier to design your menu for the week - You can browse our varied selection of recipes or add your own recipes to the site. Looking for easy meals only? Just use our dropdown bar to filter your results! You can design a meal plan that includes all your recipes for one night or even a whole week.</p>
      <img id="recipe-pic" src="../views/recipes_img.jpg">
      <p id="whoWeAre">In order to customize your experience further, you can add your own ingredients into our extensive database. A grocery list is created for you based on the meals in your meal plan, but feel free to delete items you already have or add on to the list with other groceries you may need. We have also included a map for you to find a grocery store nearby. Life can get busy - let us help you simplify dinner.</p>
      </div>
    </body>
  
  </div>
</template>

<script>
import NavBar from "@/components/NavBar.vue"
export default {
  name: "home",
  components: {
    NavBar
  }
};
</script>
<style>
@import "https://use.fontawesome.com/releases/v5.5.0/css/all.css";
.home{
  height: 100vh;
  overflow: scroll;
  background-image: url('https://cdn.rcimg.net/meitanteikudo/a5d5b507/5f28b9be7d71464801b30d31f9ba12ac.jpeg');
  background-size: cover;}
  section {
    left: 0;
    line-height: 200px;
    margin-top: -240px;
    position: absolute;
    text-align: center;
    top: 50%;
    width: 100%;
}
#theWhat{/*put a short blurb here about what MealPlanner does*/
  width: 750px;
  text-align: center;
  grid-area: theWhat;
  margin-left: -90px;
  font-size: 20px;
  width: fit-content;
  padding-right: 30px;
}
#whoWeAre{/*uhhh.... talk about who developed the app?*/
  width: 750px;
  text-align: center;
  grid-area: content;
  justify-self: center;
  font-size: 20px;
  width: fit-content;
  padding-left: 30px;
  padding-right: 30px;
}

#welcome-box{
display: grid;
grid-template-columns: 1fr 1fr 1fr 1fr;
grid-template-areas:
"header header header header"
"img theWhat theWhat theWhat"
"content content content content";
width: 1100px;
height: 500px;
background: rgba(0,0,0,0.5);
color: #ffffff;
padding: 0px, 30px;
border-radius: 5px;
margin-left: calc(50% - 550px);
margin-top: 100px;
}
#welcome{
  font-size: 100px;
  margin: 0;
  text-align:center;
  font-family: 'Sacramento', cursive;
  font-weight: bold;
  text-shadow: 10px 5px 10px #010e02;
  color:#edeeeb;
  grid-area: header;
  margin-bottom: -40px;
}
#recipe-pic{
  width: 120px;
  border-radius: 50%;
  margin-left: 30px;
  margin-top: 20px;
  grid-area: img;
  
}
</style>