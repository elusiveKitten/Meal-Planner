<template>
    <div id="container">
      <header>
        <h1>Login to Your Meal Planner</h1>
      </header>
      <img id="plateimg" src="@/views/plate.png" alt="no image found" />
      <div id="login">
        <form class="form-signin" @submit.prevent="login">
          <h2 class="h3 mb-3 font-weight-normal">Please Sign In</h2>
          <div
            class="alert alert-danger"
            role="alert"
            v-if="invalidCredentials"
          >
            Invalid username and password!
          </div>
          <div
            class="alert alert-success"
            role="alert"
            v-if="this.$route.query.registration"
          >
            Thank you for registering, please sign in.
          </div>
          <label for="username" class="sr-only">Username</label>
          <div class="divInput">
            <input
              type="text"
              id="username"
              class="form-control"
              placeholder="Username"
              v-model="user.username"
              required
              autofocus
            />
          </div>
          <label for="password" class="sr-only">Password</label>
          <div class="divInput">
            <input
              type="password"
              id="password"
              class="form-control"
              placeholder="Password"
              v-model="user.password"
              required
            />
          </div>
          <router-link :to="{ name: 'register' }">Need an account?</router-link>
          <button type="submit">Sign in</button>
          <br />
        </form>
      </div>
    </div>
</template>

<script>
import authService from "../services/AuthService";
import "bulma/css/bulma.css";
export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
<style>
h1 {
  display: flex;
  justify-content: center;
  font-size: 30px;
  font-weight: bold;
  color: #614811;
}
#plateimg {
  grid-area: img;
  margin-bottom: 1%;
  margin-top: 1%;
  display: flex;
  align-items: center;
  align-content: center;
  justify-content: center;
  height: 50%;
}

header {
  margin-bottom: 1px;
  margin-top: 1px;
  grid-area: header;
}
#container {
  background-image: url('https://wallpaperaccess.com/full/271679.jpg');
  background-size: 1920px;
  width:1920px;
  height:1080px;
  display: grid;
  grid-column-gap: 20px;
  grid-template-columns: 1fr;
  grid-template-areas:
    "header"
    "img"
    "login";
}
#login {
  grid-area: login;
  height: 50vh;
  width: 50vh;
  display: flex;
  border: groove 0.2em hsl(240, 6%, 37%);
  border-radius: 2em;
  background-color: aliceblue;
}
.form-signin {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
.form-control {
}
.divInput {
  padding-bottom: 1vh;
}
@media (max-height: 1024px) {
  #login {
    grid-area: login;
    height: 25vh;
    width: 25vh;
    display: flex;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translateX(-50%) translateY(-50%);
    border: groove 0.2em hsl(240, 6%, 37%);
    border-radius: 2em;
    justify-content: center;
    background-color: aliceblue;
  }
}
</style>
