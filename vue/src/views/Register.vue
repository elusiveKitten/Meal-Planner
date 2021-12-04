<template>
<div id="container">

<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
  <h1>Register For A Meal Planner Account </h1>
 
  <div id="register">
    <form class="form-register" @submit.prevent="register">
      <h2>Create Account</h2>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <p for="username">Username</p>
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
      <p for="password">Password</p>
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
      <p for="confirm-password">Confirm Password</p>
      <div class="divInput">
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <input type="submit" name="submit" value="Create An Account">
      </div>
      <router-link :to="{ name: 'login' }">Already have an account? Click here.</router-link>
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
#container{
  background-image: url('https://wallpaperaccess.com/full/271679.jpg%27');
  width:1920px;
  height:1080px
}
h1{
  display:flex;
  justify-content: center;
  font-size: 60px;
  font-weight: bold;
  color: hsl(240, 6%, 37%);
  font-family: 'Sacramento', cursive;
  color:#edeeeb;
  text-shadow: 2px 2px  #1db429;
  
}
h2{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
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
