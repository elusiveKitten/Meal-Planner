<template>

  <div class="home">
    <nav-bar />
    <body>
      <h1 id="welcome">Welcome to Meal Planner!</h1>
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
p{
  width: 200px;
}
#welcome{
  font-size: 10vw;
  margin: 0;
  padding: 0 0 20px;
  text-align:center;
  font-family: 'Sacramento', cursive;
  font-weight: bold;
  text-shadow: 10px 5px 10px #010e02;
  color:#edeeeb;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>