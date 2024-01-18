<template>
  <TopNavigation />
  <button class="btn submit-btn mt-4" v-if="showKarel" @click="toggleDoctor">
    Karel Lant
  </button>
  <button class="btn submit-btn mt-4" v-else @click="toggleDoctor">
    Danique de Beer
  </button>

  <div class="datepicker">
    <label for="begin-date">Vanaf datum:</label>
    <input
      type="date"
      class="form-control"
      id="begin-date"
      v-model="startDate"
    />
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
export default {
  name: "work-schedules",
  components: { TopNavigation },
  data() {
    return {
      showKarel: true,
      startDate: "",
    };
  },
  methods: {
    toggleDoctor() {
      this.showKarel = !this.showKarel;
    },
  },
};
</script>

<style>
.datepicker {
  width: 30%;
  margin: auto;
}
</style>