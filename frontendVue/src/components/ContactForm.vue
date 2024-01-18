<template>
  <form @submit.prevent="sendEmail">
    <h3>Stuur ons een email:</h3>
    <br />
    <label>Naam: <input v-model="name" required /></label>
    <label>Email: <input v-model="email" type="email" required /></label
    ><br /><br />
    <textarea
      placeholder="Typ hier je bericht"
      v-model="message"
      required
      rows="4"
      cols="50"
    ></textarea>
    <br />
    <button class="btn submit-btn mt-4" type="submit">Verstuur</button>
  </form>
</template>
  
  <script>
export default {
  data() {
    return {
      name: "",
      email: "",
      message: "",
    };
  },
  methods: {
    sendEmail() {
      console.log(
        "Naam: " + this.name + ", ",
        "Emailadres: " + this.email + ", ",
        "Bericht: " + this.message
      );
    },
  },
};
</script>
  