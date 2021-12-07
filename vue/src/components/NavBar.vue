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
        <a class="navbar-item" src="@/views/plate.png">
          <img src="@/views/plate.png" />
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
              class="button is-warning has-text-grey"
              v-bind:to="{ name: 'home' }"
              >Home</router-link
            >&nbsp;&nbsp;
          </div>
                    <div
            id="recipe-dropdown" class="navbar-item has-dropdown is-hoverable has-background-warning"
          >
            <a class="navbar-link"> Recipes </a>

            <div class="navbar-dropdown has-background-warning">
              <a class="navbar-item has-text-grey has-background-warning">
                <router-link v-bind:to="{ path: '/my-recipes' }">My Recipes</router-link>
              </a>
              <a class="navbar-item has-text-grey has-background-warning">
                <router-link v-bind:to="{ path: '/all-recipes' }">All Recipes</router-link>
              </a>
            </div>
          </div>
          <div class="navbar-item">
            <router-link
                class="button is-warning has-text-grey"
                v-bind:to="{ path: '/my-meal-plans' }">My Meal Plans</router-link>
          </div>
          <div class="navbar-item">
            <router-link
                class="button is-warning has-text-grey"
                v-bind:to="{ path: '/ingredients' }">Ingredients</router-link>
          </div>
          <div class="navbar-item">
            <router-link
                class="button is-warning has-text-grey"
                v-bind:to="{ path: '/grocery-list' }">Grocery List</router-link>
          </div>
        </div>

        <div class="navbar-end">
          <div class="navbar-item">
            <div class="buttons">
              <router-link
                class="button is-light button is-info is-outlined"
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
  background-color: rgba(40, 65, 94, 0.3);
  background-image: none;
}
.button{
  font-family: sans-serif;
}
.navbar-item{
  border-radius: 5px;
  height: 40px;
}
#recipe-dropdown{
  margin-left: 12px;
  margin-right: 12px;
}
</style>