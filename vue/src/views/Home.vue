<template>

  <div class="home">
    <nav-bar />
    <body>
      <h1>Welcome to Meal Planner!</h1>
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
</style>