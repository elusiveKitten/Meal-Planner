<template>
<div class="header">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Sacramento&display=swap" rel="stylesheet">
  <h1>Meal Planner</h1>
 <div id="login-box">
    <div class="user-box">
    <i class="fas fa-utensils"></i>
    </div>
    <form class="form-signin" @submit.prevent="login">
      <h2>Login Here</h2>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">Invalid username and password!</div>
      <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">Thank you for registering, please sign in.</div>
      <p for="username">Username</p>
      <input type="text" id="username" class="form-control" name="username" placeholder="Username" v-model="user.username" required autofocus />
      <p for="password">Password</p>
      <input type="text" id="password" class="form-control" name="password" placeholder="Password" v-model="user.password" required />
      <input type="submit" name="submit" value="Login">
      <router-link :to="{ name: 'register' }">Not a Member? Register Here!</router-link>
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
@import "https://use.fontawesome.com/releases/v5.5.0/css/all.css";


body{
  margin: 0;
  padding: 0;
  font-family:Verdana, Geneva, Tahoma, sans-serif;
  background-image:url('https://wallpaperaccess.com/full/271679.jpg%27');
  background-size: 100vw 100vh;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  grid-template-areas: 
  "header header header header"
  ". login-box login-box ."
  ". login-box login-box ."
  "footer footer footer footer";
  justify-content: center;
  align-items: center;
}
.header{
  grid-area: header;
  font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif
}
.header h1{/*This is the "Meal Planner" header*/
  font-size: 150px;
  margin: 0;
  padding: 0 0 20px;
  text-align:center;
  font-family: 'Sacramento', cursive;
  font-weight: bold;
  font-kerning: inherit;
  text-shadow: 10px 5px 10px #010e02;
  color:#edeeeb;
  display: flex;
  justify-content: center;
  align-items: center;
}
#login-box{
   width: 320px;
    height: 420px;
    background: rgba(0,0,0,0.5);
    color: #ffffff;
    padding: 0px 30px;
    border-radius: 5px;
    grid-area: login-box;
    margin-top: 100px;
    margin-left: 42%;
    
}

#login-box .user-box{/*the round "box" that the utensils are in*/
background:  #56aa54;
width: 100px;
height: 100px;
border-radius: 50%;
position:relative;
display: flex;
justify-content: center;
align-items: center;
top: -50px;
left:calc(50% - 50px)
}

#login-box .user-box .fas{/*the utensils*/
    font-size: 60px;
    position: absolute;
    top: 17px;
    left: 24px;
}
.form-signin{
  margin: 0px, 10px, 0px, 10px;

}
h2{
    margin-top: -30px;/*Login Here*/
    margin-bottom: 25px;
    padding:0px;
    text-align:center;
    font-size:27px;
    display: flex;
    align-items: flex-start;
    justify-content: center;
    font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}

#login-box p{/*the username and password visible words*/
    margin: 0;
    padding: 0;
    font-weight: bold;
    font-size: 18px;
}

#login-box input{/*the input boxes*/
    width: 100%;
    margin-bottom: 20px;
}

#login-box input[type="text"],/*changes from box to a line, makes it transparent instead of white input boxes*/
input[type="password"]{
    color: #ffffff;
    background: transparent;
    border: none;
    border-bottom: 1px solid #ffffff;
    outline: none;
    height: 40px;
    font-size: 16px;
}

#login-box input[type="submit"]{/*the Login button at bottom of form*/
    border: none;
    border-radius: 19px;
    outline: none;
    height: 40px;
    background: #56aa54;
    color:#ffffff;
    font-size: 18px;
}

#login-box input[type="submit"]:hover{/*hovering over the Login button changes its color*/
    background: #A9B3B4;
    cursor: pointer;
}

#login-box a{/*Makes the hyperlink to register more visible and not underlined/blue*/
    text-decoration: none;
    font-size: 16px;
    color: #ffffff;
}

#login-box a:hover{/*When you hover over the hyperlink to register it shows up green*/
    color: #1db429;
}
footer{
  grid-area: footer;
}
</style>
<!--

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
</style>-->
