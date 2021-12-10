<template>
<div class="background-img">
 <meta name="viewport" content="width=device-width, initial-scale=1.0">
 
<div class="container">
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
      <input type="password" id="password" class="form-control" name="password" placeholder="Password" v-model="user.password" required />
      <!--<button @click="$router.push('/')" type="submit" name="submit">Login</button>-->
      <!--<router-link :to="{name: 'home'}" class="button">Login</router-link>-->
      <input type="submit" name="submit" value="Login">
      <router-link :to="{ name: 'register' }">Not a Member? Register Here!</router-link>
    </form>
    </div>
    </div>
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

.background-img{/*TODO - make background image less bright*/
  background-image: url('https://cdn.discordapp.com/attachments/916348750774013963/917534560487637042/background.jpg');
  background-size: cover;
  background-repeat: no-repeat;
  height: 100vh;
}
.background-img:after{
  background-image: url('https://cdn.discordapp.com/attachments/916348750774013963/917534560487637042/background.jpg');
  background-size: cover;
  background-repeat: no-repeat;
  height: 100vh;
  filter: brightness(20%);
  z-index: -1;

}
.container{
}
body{
  margin: 0;
  padding: 0;
  font-family:Verdana, Geneva, Tahoma, sans-serif;
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
  text-shadow: 10px 5px 10px #010e02, 10px 5px 25px black;
  color:#edeeeb;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: -90px;
}
#login-box{/*the transparent box*/
   width: 320px;
    height: 50%;
    background: rgba(0,0,0,0.5);
    color: #ffffff;
    padding: 0px 30px;
    border-radius: 5px;
    grid-area: login-box;
    margin-top: 100px;
    margin-left: calc(50% - 160px);
    
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
h2{
    margin-top: -40px;/*Login Here*/
    margin-bottom: 25px;
    padding:0px;
    width: 260px;
    text-align:center;
    font-size:29px;
    display: flex;
    align-items: flex-start;
    justify-content: center;
    font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}

#login-box p{/*the username and password visible words*/
    margin: 0;
    padding: 0;
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
    height: 40px;
    font-size: 16px;
}

#login-box input[type="submit"]{/*the Login button at bottom of form*/
    border: none;
    border-radius: 19px;
    font-weight: bold;
    margin-bottom: 15px;
    height: 40px;
    width:250px;
    background: #56aa54;
    color:#ffffff;
    font-size: 17px;/*TODO figure out how to center 'Login' better*/
}

#login-box input[type="submit"]:hover{/*hovering over the Login button changes its color*/
    background: #A9B3B4;
    cursor: pointer;
}

#login-box a{/*Makes the hyperlink to register more visible and not underlined/blue*/
    color: #ffffff;
}

#login-box a:hover{/*When you hover over the hyperlink to register it shows up green*/
    color: #1db429;
}
.alert .alert-success{
  margin-top: -10px;
}
footer{
  grid-area: footer;
}
.form-signin{
  padding-bottom: 20px;
}
</style>
