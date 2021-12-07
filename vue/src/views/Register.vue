<template>
<div class="background-img">
<div class="container">
<div class="header">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
  <h1>Register For A Meal Planner Account </h1>
 
  <div id="register">
    <div class="icon-box">
      <i class="fas fa-plus"></i>
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
      <!--<button @click="$router.push('login')" type="submit">Create An Account</button>-->
      <!--<router-link :to="{ name: 'login' }" class="button">Create An Account</router-link>-->
      <input type="submit" name="submit" value="Create An Account">
      </div>
      <router-link :to="{ name: 'login' }">Already have an account? Click here.</router-link>
    </form>
  </div>
</div>
</div>
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
.background-img{
    background-image:url('https://cdn.discordapp.com/attachments/916348750774013963/917534560487637042/background.jpg');
  background-size: cover;
  background-repeat: no-repeat;
  height: 100vh;
}
body{
  margin: 0;
  padding: 0;
  font-family:Verdana, Geneva, Tahoma, sans-serif;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  grid-template-areas: 
  "header header header header"
  ". register-box register-box ."
  ". register-box register-box ."
  "footer footer footer footer";
  justify-content: center;
  align-items: center;
}
.header{
  grid-area: header;
  font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif
}
h1{/*The Register For A Meal Planner Acct msg*/
  display:flex;
  justify-content: center;
  font-size: 60px;
  font-weight: bold;
  font-family: 'Sacramento', cursive;
  color:#edeeeb;
  text-shadow: 2px 2px 10px #010e02;
  
}
h2{/* the Create Acct msg*/
  margin-top: -30px;
  margin-bottom: 25px;
  padding:0px;
  text-align:center;
  font-size:27px;
  display: flex;
  align-items: flex-start;
  justify-content: center;
  font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}
#register {/*the transparent box*/
  width: 320px;
  height: 420px;
  background: rgba(0,0,0,0.5);
  color: #ffffff;
  padding: 290px 30px;
  border-radius: 5px;
  grid-area: register-box;
  margin-top: 100px;
  margin-left: calc(50% - 160px);
}
#register .icon-box{/*the round "box" that the + is in*/
background:  #56aa54;
width: 100px;
height: 100px;
border-radius: 50%;
position:relative;
display: flex;
justify-content: center;
align-items: center;
top: -335px;
left:calc(50% - 50px)
}
#register .icon-box .fas{/* the plus sign*/
font-size: 60px;
position: absolute;
top: 17px;
left: 24px;
}
.form-register {/*the form where all words are*/
  margin-top: 620px;

}
#register p{/*Username/Password/Confirm Pword visible words*/
  margin: 0px;
  padding: 0px;
  font-weight: bold;
  font-size: 18px;
}
#register input{/* the form input boxes*/
  width: 100%;
  margin-bottom: 20px;
}
#register input[type="text"], input[type="password"]{/*makes the input boxes transparent instead of white*/
  color: #ffffff;
  background: transparent;
  border: none;
  border-bottom: 1px solid #ffffff;
  height: 40px;
  font-size: 16px;
}
#register input[type="submit"]{/*the Create an acct button at bottom of form*/
  border: none;
  border-radius: 19px;
  margin-bottom: 10px;
  height: 40px;
  width: 250px;
  background: #56aa54;
  color: #ffffff;
  text-align: center;
  font-size: 18px;
  display: inline-block;
  font-weight: bold;
}
#register input[type="submit"]:hover{/*hovering over the create account button changes it's color*/
  background: #a9b3b4;
  cursor: pointer;
}
#register a{/*Changes hyperlink from blue to something more visible*/
  color: #ffffff;
}
#register a:hover{/*already have an acct link changes color on hover*/
  color: #1db429;
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
