<template>
    <div>
        <input type="text" placeholder="Enter your address" v-model="coordinates" />
        <button class="locator-button" @click="locatorButtonPressed">My Location</button>
        <div class="field">
              <select v-model="type">
                <option value="supermarkets">Supermarkets</option>
              </select>
            </div>
            <div class="field">
              <select v-model="radius">
                <option value="5">5 KM</option>
                <option value="10">10 KM</option>
                <option value="15">15 KM</option>
                <option value="20">20 KM</option>
              </select>
            </div>
            <button class="ui button" @click="findNearbyButtonPressed">Find Nearby</button>
            <div class="ui segment"  style="max-height:500px;overflow:scroll">
        <div class="ui divided items">
        <div class="item" v-for="place in places" :key="place.id">
            <div class="content">
                <div class="header">{{place.name}}</div>
                <div class="meta">{{place.vicinity}}</div>
            </div>
        </div>
    </div>
</div>
    </div>

    
</template>

<script>
import axios from "axios";
export default {
    data() {
        return {
            lat: 0,
            lng: 0,
            type: "",
            radius: "",
            places: []
        };
    },
    methods: {
  locatorButtonPressed() {
    navigator.geolocation.getCurrentPosition(
      position => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      },
    //   error => {
    //     console.log("Error getting location");
    //   }
    );
  },
  findNearbyButtonPressed() {
	const URL = `https://cors-anywhere.herokuapp.com/https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=${
        this.lat
      },${this.lng}&type=${this.type}&radius=${this.radius *
        1000}&key=[AIzaSyAXt6fzkeW76UH90EaA4rAhro7woiMvccE]`;
	axios.get(URL).then(response => {
		this.places = response.data.results;
		this.addLocationsToGoogleMaps();
	}).catch(error => {
		console.log(error.message);
	});
},
},
    computed: {
        coordinates() {
            return `${this.lat}, ${this.lng}`;
        }
    }
}
</script>

<style>

</style>