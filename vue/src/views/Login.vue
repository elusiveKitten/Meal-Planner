<template>
  <div id="container">
    <h1>Login to Your Meal Planner</h1>
    <img id="plateimg" src="plate.png" alt="no image found" />
    <div id="login" class="text-center">
      <form class="form-signin" @submit.prevent="login">
        <h2 class="h3 mb-3 font-weight-normal">Please Sign In</h2>
        <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
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
<style scoped>
h1{
  display:flex;
  justify-content: center;
  font-size: 30px;
  font-weight: bold;
  color: #614811
}
#plateimg{
  display:flex;
  position: absolute;
  top: 20%;
  left: 50%;
  transform: translateX(-50%) translateY(-50%);
  height: 4cm;
}
#login {
  height: 6.1cm;
  width: 6cm;
  display: flex;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translateX(-50%) translateY(-50%);
  border: 5px solid hsl(240, 6%, 37%);
  flex-wrap: wrap;
  justify-content: center;
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
  padding-bottom: 15px;
}
/* @media screen and (min-width: 768px){
    #login{
      margin-left: 45%;
      margin-right: 45%;
    }
} */
</style>
