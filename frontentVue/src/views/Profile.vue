<template>
  <div>
    <TopNavigation />
    <Sidebar @index="show" />
    <div class="content">
      <UserAppointments v-if="showing == 2" />
      <UserInformation v-if="showing == 0" />
      <UserPets v-if="showing == 1" />
      <!-- <h2>Responsive Sidebar Example</h2>
            <p>This example use media queries to transform the sidebar to a top navigation bar when the screen size is 700px or less.</p>
            <p>We have also added a media query for screens that are 400px or less, which will vertically stack and center the navigation links.</p>
            <h3>Resize the browser window to see the effect.</h3> -->
    </div>
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
import Sidebar from "../components/Sidebar.vue";
import UserAppointments from "../components/UserAppointments.vue";
import UserInformation from "../components/UserInformation.vue";
import UserPets from "../components/UserPets.vue";

export default {
  name: "Profile",
  components: {
    TopNavigation,
    Sidebar,
    UserAppointments,
    UserInformation,
    UserPets,
  },
  data() {
    return {
      showing: 0,
    };
  },
  methods: {
    show(profileContent) {
      this.showing = profileContent;
    },
  },
};
</script>

<style>
</style>