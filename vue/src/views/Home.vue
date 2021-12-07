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
  background-image: url('https://kitchenseer.com/wp-content/uploads/2021/06/An-up-close-and-detailed-photo-of-a-wooden-chopping-board-1200x800.jpg');
  background-size: 100vw 100vh;}
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