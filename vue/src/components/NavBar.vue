<template>
  <div class="container-max-width">
    <link />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com/" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap"
      rel="stylesheet"
    />
    <nav
      class="navbar notification is-transparent"
      role="navigation"
      aria-label="main navigation"
    >
      <div class="navbar-brand">
        <a class="navbar-item">
          <i class="fas fa-utensils"></i>
        </a>

        <a
          role="button"
          class="navbar-burger"
          aria-label="menu"
          aria-expanded="false"
          data-target="navbarBasicExample"
        >
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>

      <div class="navbar-menu">
        <div class="navbar-start">
          <div class="navbar-item">
            <router-link
              class="button"
              v-bind:to="{ name: 'home' }"
              ><i class="fas fa-home"></i>Home</router-link
            >&nbsp;&nbsp;
          </div>
          <div
            id="recipe-dropdown"
            class="button navbar-item has-dropdown is-hoverable"
          >
            <a class="navbar-link"><i class="fas fa-list"></i> Recipes </a>

            <div class="navbar-dropdown">
              <a
                class="navbar-item"
              >
                <router-link v-bind:to="{ name: 'my-recipes', params: {userId:this.$store.state.user.userId} }"
                  >My Recipes</router-link
                >
              </a>
              <a
                class="navbar-item"
              >
                <router-link v-bind:to="{ path: '/recipe/all' }"
                  >All Recipes</router-link
                >
              </a>
            </div>
          </div>
          <div class="navbar-item">
            <router-link
              class="button"
              v-bind:to="{ name: 'my-meal-plans',params: {userId:this.$store.state.user.userId} }"
              ><i class="fas fa-drumstick-bite"></i>My Meal Plans</router-link
            >
          </div>
          <div class="navbar-item">
            <router-link
              class="button"
              v-bind:to="{ path: '/ingredients' }"
              ><i class="fas fa-seedling"></i>Ingredients</router-link
            >
          </div>
          <div class="navbar-item">
            <router-link
              class="button"
              v-bind:to="{ path: '/grocery-list' }"
              ><i class="fas fa-shopping-cart"></i>Grocery List</router-link
            >
          </div>
        </div>

        <div class="navbar-end">
          <div class="navbar-item">
            <div class="buttons">
              <router-link
                class="button"
                v-bind:to="{ name: 'logout' }"
                v-if="$store.state.token != ''"
                >Logout</router-link
              >
            </div>
          </div>
        </div>
      </div>
    </nav>
    <router-view />
  </div>
</template>
<script>
import "bulma/css/bulma.css";
export default {};
</script>
<style>
.navbar {
  background-color: rgba(0,0,0,0.5);
  background-image: none;
}
.button {
  font-family: sans-serif;
  background-color: #56aa54;
  border: none;
  color: #edeeeb;
}
.navbar-item {
  border-radius: 5px;
  height: 40px;
}
#recipe-dropdown {
  margin-left: 12px;
  margin-right: 12px;
}
i {
  margin-right: 10px;
}
.logout-button{
height:40px;
border-radius: 5px;
width: 100px;
background-color: #edeeeb;
text-align: center;
padding-top: 5px;
text-decoration: none;
}
.navbar-brand .fas{
  font-size: 60px;
  top: 17px;
  left: 24px;
  color: #edeeeb;
}
.navbar-dropdown{
  background-color: #56aa54;
  color: #edeeeb;
}
</style>