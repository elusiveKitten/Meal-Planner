<template>
<div id="container">
  <h1>Register For A Meal Planner Account</h1>
  <img id="plateimg" src="plate.png" alt="no image found" />
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h2 class="h3 mb-3 font-weight-normal">Create Account</h2>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
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
      <div class="divInput">
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      </div>
      <router-link :to="{ name: 'login' }">Have an account?</router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
  </div>
</div>
</template>

<script>
import authService from '../services/AuthService';
import "bulma/css/bulma.css";
export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
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
  color: hsl(240, 6%, 37%)
}
#plateimg{
  display:flex;
  position: absolute;
  top: 20%;
  left: 50%;
  transform: translateX(-50%) translateY(-50%);
  height: 4cm;
}
#register {
  height: 7.2cm;
  width: 6.2cm;
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
.form-register {
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
