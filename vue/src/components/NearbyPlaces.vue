<template>
    <div>
        <input type="text" placeholder="Enter your address" v-model="coordinates" />
        <button class="locator-button" @click="locatorButtonPressed">My Location</button>
        <form class="place-locator">
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
          </form>

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
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAXt6fzkeW76UH90EaA4rAhro7woiMvccE&callback=myMap"></script>
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
  addLocationsToGoogleMaps() {
	var map = new google.maps.Map(this.$refs['map'], {
		zoom: 15,
		center: new google.maps.LatLng(this.lat, this.lng),
		mapTypeId: google.maps.MapTypeId.ROADMAP
  });
  var infowindow = new google.maps.infowindow();
	this.places.forEach((place) => {
		const lat = place.geometry.location.lat;
		const lng = place.geometry.location.lng;
		let marker = new google.maps.Marker({
			position: new google.maps.LatLng(lat, lng),
			map: map
    });
    google.maps.event.addListener(marker, "click", () => {
      infowindow.setContent(
        <div class="header">${place.name}${place.vicinity}</div>
      )
    })
	});
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