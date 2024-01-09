<template>
  <div>
    <TopNavigation />
    <Carousel
      :slides="['./cat-banner.png', './dog-banner.png', './rabbit-banner.png']"
    />
    <div>
      <Sidebar class="sidebar" @index="show" />
      <div class="content">
        <UserAppointments v-if="showing == 2" />
        <UserInformation v-if="showing == 0" />
        <UserPets v-if="showing == 1" />
      </div>
    </div>
  </div>
</template>


<script>
import TopNavigation from "../components/TopNavigation.vue";
import Sidebar from "../components/Sidebar.vue";
import UserAppointments from "../components/UserAppointments.vue";
import UserInformation from "../components/UserInformation.vue";
import UserPets from "../components/UserPets.vue";
import Carousel from "../components/Carousel.vue";

export default {
  name: "Profile",
  components: {
    TopNavigation,
    Sidebar,
    UserAppointments,
    UserInformation,
    UserPets,
    Carousel,
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
.sidebar {
  position: absolute;
}
</style>