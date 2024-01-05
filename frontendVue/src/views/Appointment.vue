<template>
  <div>
    <TopNavigation />
    <div class="planning">
      <h1 class="appointment_header">Afspraak maken</h1>
      <div class="test" v-if="showForm == 'showForm'">
        <h2><img src="/balk1.png" /></h2>
        <form
          @submit.prevent="handleSubmit"
          v-if="showForm == 'showForm'"
          class="appointment_form"
        >
          <h4 class="appointment_header_2">Afspraak voorkeuren</h4>
          <input
            type="radio"
            name="select-type"
            id="select-animal-type"
            value="select-animal-type"
            @click="toggleSelectType"
            :checked="select_type === 'select-animal-type'"
          /><label for="select-animal-type">Selecteer diersoort* </label><br />

          <div v-if="select_type === 'select-animal-type'">
            <button
              v-if="type_animal != 1 && type_animal != 8 && type_animal != 9"
              @click="changetype_animal(1)"
              type="button"
              id="big"
              value="1"
              :class="{ selected_animal: type_animal == 1 }"
            >
              <img src="/dog.png" /><br />hond
            </button>
            <button
              @click="changetype_animal(2)"
              type="button"
              id="big"
              value="2"
              :class="{ selected_animal: type_animal == 2 }"
            >
              <img v-if="type_animal == 2" src="/inverted-black-cat.png" /><img
                v-if="type_animal != 2"
                src="/black-cat.png"
              /><br />kat
            </button>
            <button
              @click="changetype_animal(3)"
              type="button"
              id="big"
              value="3"
              :class="{ selected_animal: type_animal == 3 }"
            >
              <img v-if="type_animal == 3" src="/inverted-rabbit.png" /><img
                v-if="type_animal != 3"
                src="/rabbit.png"
              /><br />konijn
            </button>
            <button
              @click="changetype_animal(4)"
              type="button"
              id="big"
              value="4"
              :class="{ selected_animal: type_animal == 4 }"
            >
              <img v-if="type_animal == 4" src="/inverted-guinea-pig.png" /><img
                v-if="type_animal != 4"
                src="/guinea-pig.png"
              /><br />cavia
            </button>
            <button
              @click="changetype_animal(5)"
              type="button"
              id="big"
              value="5"
              :class="{ selected_animal: type_animal == 5 }"
            >
              <img v-if="type_animal == 5" src="/inverted-hamster.png" /><img
                v-if="type_animal != 5"
                src="/hamster.png"
              /><br />hamster
            </button>
            <button
              @click="changetype_animal(6)"
              type="button"
              id="big"
              value="6"
              :class="{ selected_animal: type_animal == 6 }"
            >
              <img v-if="type_animal == 6" src="/inverted-rat.png" /><img
                v-if="type_animal != 6"
                src="/rat.png"
              /><br />rat
            </button>
            <button
              @click="changetype_animal(7)"
              type="button"
              id="big"
              value="7"
              :class="{ selected_animal: type_animal == 7 }"
            >
              <img v-if="type_animal == 7" src="/inverted-muis.png" /><img
                v-if="type_animal != 7"
                src="/muis.png"
              /><br />muis</button
            ><br />
            <div
              v-if="type_animal == 1 || type_animal == 8 || type_animal == 9"
            >
              <button
                @click="changetype_animal(8)"
                type="button"
                id="big"
                value="8"
                :class="{ selected_animal: type_animal == 8 }"
              >
                <img v-if="type_animal == 8" src="/inverted-dog.png" /><img
                  v-if="type_animal != 8"
                  src="/dog.png"
                /><br />kleine hond
              </button>
              <button
                @click="changetype_animal(9)"
                type="button"
                id="big"
                value="9"
                :class="{ selected_animal: type_animal == 9 }"
              >
                <img v-if="type_animal == 9" src="/inverted-dog.png" /><img
                  v-if="type_animal != 9"
                  src="/dog.png"
                /><br />grote hond
              </button>
            </div>
            <div v-if="type_animal !== ''">
              <label>Aantal huisdieren* </label><br />
              <button
                @click="changeamount(1)"
                type="button"
                value="1"
                id="small"
                :class="{ selected: amount == 1 }"
              >
                1
              </button>
              <button
                @click="changeamount(2)"
                type="button"
                value="2"
                id="small"
                :class="{ selected: amount == 2 }"
              >
                2
              </button>
              <button
                @click="changeamount(3)"
                type="button"
                value="3"
                id="small"
                :class="{ selected: amount == 3 }"
              >
                3
              </button>
              <button
                @click="changeamount(4)"
                type="button"
                value="4"
                id="small"
                :class="{ selected: amount == 4 }"
              >
                4
              </button>
            </div>
            <br />
            <div v-if="name_animalError" class="error">
              {{ name_animalError }}
            </div>
          </div>

          <!-- If user has pets, they show here -->

          <div v-if="pets?.length > 0">
            <input
              type="radio"
              name="select-type"
              id="select-pet"
              value="select-pet"
              @click="toggleSelectType"
            /><label for="select-pet">Selecteer uw huisdier* </label><br />

            <div v-if="select_type === 'select-pet'">
              <button
                v-for="pet in pets"
                :key="pet.id"
                @click="addOrRemovePet(pet.name)"
                type="button"
                id="big"
                :class="{
                  selected_animal: this.name_animal.includes(pet.name),
                }"
              >
                <img
                  v-if="pet.type == 1"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-dog.png'
                      : '/dog.png'
                  "
                />
                <img
                  v-if="pet.type == 2"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-black-cat.png'
                      : '/black-cat.png'
                  "
                />
                <img
                  v-if="pet.type === 3"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-rabbit.png'
                      : '/rabbit.png'
                  "
                />
                <img
                  v-if="pet.type == 4"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-guinea-pig.png'
                      : '/guinea-pig.png'
                  "
                />
                <img
                  v-if="pet.type == 5"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-hamster.png'
                      : '/hamster.png'
                  "
                />
                <img
                  v-if="pet.type == 6"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-rat.png'
                      : '/rat.png'
                  "
                />
                <img
                  v-if="pet.type == 7"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-muis.png'
                      : '/muis.png'
                  "
                />
                <img
                  v-if="pet.type == 8"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-dog.png'
                      : '/dog.png'
                  "
                />
                <img
                  v-if="pet.type == 9"
                  :src="
                    name_animal.includes(pet.name)
                      ? '/inverted-dog.png'
                      : '/dog.png'
                  "
                />
                <br />{{ pet.name }}
              </button>
            </div>
          </div>
          <!-- // -->
          <br />
          <select required v-model="type_consult" id="type_select">
            <option hidden value="">Selecteer type afspraak*</option>
            <option
              :value="appointment_type.id"
              v-for="appointment_type in appointment_types"
              :key="appointment_type.id"
            >
              {{ appointment_type.name }}
            </option></select
          ><br />
          <button v-if="type_animal != 1 && amount > 0" class="submit">
            volgende
          </button>
        </form>
      </div>
      <div class="button_div" v-if="showForm == 'showForm'">
        <h2 id="removetext">.</h2>
      </div>
      <div class="test" v-if="showForm == 'showDateForm'">
        <h2><img src="/balk2.png" /></h2>
        <AppointmentDateandTime
          @showForm="showThisForm"
          :duration="duration"
          :oldtime="time"
          :appointmentDate="date"
          :initialPreference="preference"
          v-if="showForm == 'showDateForm'"
        />
      </div>
      <div class="button_div" v-if="showForm == 'showDateForm'">
        <h2 id="removetext">.</h2>
      </div>
      <div class="test" v-if="showForm == 'showContactForm'">
        <h2><img src="/balk3.png" /></h2>
        <h3>
          <img id="agenda" src="/agenda.png" />{{ displayFullDate(date) }}
          {{ time }}
        </h3>
        <form
          @submit.prevent="Result"
          v-if="showForm == 'showContactForm'"
          class="appointment_form"
        >
          <div class="container">
            <div class="row align-items-start">
              <div class="col">
                <h4>Persoonlijke gegevens</h4>
                <label>Uw contactgegevens</label><br />
                <input
                  type="email"
                  required
                  v-model="email"
                  placeholder="Email adres*"
                /><br />
                <div v-if="emailError" class="error">{{ emailError }}</div>
                <input
                  type="text"
                  required
                  v-model="phone"
                  placeholder="Mobiel nummer*"
                /><br />
                <div v-if="phoneError" class="error">{{ phoneError }}</div>
                <label>Uw naam</label><br />
                <input
                  type="text"
                  required
                  v-model="name"
                  placeholder="Naam*"
                /><br />
                <div v-if="nameError" class="error">{{ nameError }}</div>
                <label>Gegevens huisdieren </label>
                <div v-if="amount == 1">
                  <input
                    type="text"
                    v-model="name_animal[0]"
                    placeholder="Naam huisdier"
                  />
                  <input
                    type="text"
                    v-model="info_animal[0]"
                    placeholder="Reden voor afspraak"
                  /><br />
                </div>
                <div v-if="amount != 1">
                  <input
                    type="text"
                    v-model="name_animal[0]"
                    placeholder="Naam eerste huisdier"
                  />
                  <input
                    type="text"
                    v-model="info_animal[0]"
                    placeholder="Reden voor afspraak"
                  /><br />
                  <input
                    type="text"
                    v-model="name_animal[1]"
                    placeholder="Naam tweede huisdier"
                  />
                  <input
                    type="text"
                    v-model="info_animal[1]"
                    placeholder="Reden voor afspraak"
                  />
                </div>
                <div v-if="amount != 1 && amount != 2">
                  <input
                    type="text"
                    v-model="name_animal[2]"
                    placeholder="Naam derde huisdier"
                  />
                  <input
                    type="text"
                    v-model="info_animal[2]"
                    placeholder="Reden voor afspraak"
                  />
                </div>
                <div v-if="amount == 4">
                  <input
                    type="text"
                    v-model="name_animal[3]"
                    placeholder="Naam vierde huisdier"
                  />
                  <input
                    type="text"
                    v-model="info_animal[3]"
                    placeholder="Reden voor afspraak"
                  />
                </div>
                <div v-if="name_animalError" class="error">
                  {{ name_animalError }}
                </div>
              </div>
              <div class="col">
                <img
                  class="hamster_image"
                  src="../assets/hamster-appointment.png"
                  alt=""
                />
              </div>
            </div>
          </div>

          <button @click.prevent="backtodateform" class="back">vorige</button>
          <button class="submit">bevestig afspraak</button>
        </form>
      </div>
    </div>
    <div class="button_div" v-if="showForm == 'showContactForm'">
      <h2 id="removetext">.</h2>
    </div>
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
import AppointmentDateandTime from "../components/AppointmentDateandTime.vue";
import {
  isLoggedIn,
  getUserDataFromSession,
} from "../composables/sessionManager.js";
import { getUserById } from "../composables/userManager.js";
import getAppointments from "../composables/getAppointments";
import getAppointment_type from "../composables/getAppointment_type";
import getAppointment_types from "../composables/getAppointment_types";
import postAppointments from "../composables/postAppointments";
import {
  displayFullDate,
  toDateString,
  skipSundayAndMonday,
  previousDate,
  nextDate,
} from "../composables/datetime-utils.js";

export default {
  name: "app",
  components: {
    TopNavigation,
    AppointmentDateandTime,
  },
  data() {
    return {
      userid: null,
      name: "",
      email: "",
      phone: "",
      type_animal: "",
      amount: 0,
      name_animal: [],
      info_animal: [],
      type_consult: "",
      showForm: "showForm",
      duration: 0,
      preference: 0,
      status: 0,
      number: 0,
      appointments: "",
      time: "",
      doctor: "",
      closed: false,
      date: new Date(),
      name_animalError: "",
      nameError: "",
      emailError: "",
      phoneError: "",
      animal_nameError: "",
      appointment_types: [],
      displayFullDate: displayFullDate,
      pets: [],
      select_type: "select-animal-type",
    };
  },
  async created() {
    if (isLoggedIn()) {
      const user = getUserDataFromSession();
      const userdata = await getUserById(user.userId);
      this.userid = user.userId;
      this.pets = userdata.pets;
    }

    const { appointment_types, appointment_types_error } =
      getAppointment_types();
    this.appointment_types = appointment_types;
  },
  methods: {
    showThisForm(array) {
      this.showForm = array[0];
      this.doctor = array[1];
      this.time = array[2];
      this.preference = array[3];
      this.date = array[4];
    },
    changeamount(amount) {
      this.amount = amount;
    },
    changetype_animal(animal) {
      this.type_animal = animal;
    },
    backtodateform() {
      this.showForm = "showDateForm";
    },
    addOrRemovePet(petName) {
      if (this.name_animal.includes(petName)) {
        this.name_animal = this.name_animal.filter((name) => name !== petName);
        this.amount -= 1;
      } else {
        this.name_animal.push(petName);
        this.amount += 1;
      }
    },
    toggleSelectType(event) {
      this.select_type = event.target.value;
      this.name_animal = [];
      this.amount = 0;
      this.type_animal = "";
    },
    async handleSubmit() {
      if (isLoggedIn()) {
        const user = getUserDataFromSession();
        var userdata = getUserById(user.userId);
        var pet_type = this.type_animal;

        const value = await userdata.then(function (result) {
          var name = result.firstName + " " + result.lastName;
          var phone = result.phone;
          var email = result.email;
          if (result.pets) {
            var samepets = result.pets.filter((p) => p.type == pet_type);
          } else {
            var samepets = 0;
          }
          return { name, phone, email, samepets };
        });

        if (value.samepets.length > this.amount) {
          var loop = this.amount;
        } else {
          var loop = value.samepets.length;
        }
        for (let i = 0; i < loop; i++) {
          const pets = await userdata.then(function (result) {
            var pet_name = value.samepets[i].name;
            return { pet_name };
          });
          this.name_animal[i] = pets.pet_name;
        }

        this.email = value.email;
        this.name = value.name;
        this.phone = value.phone;
      }

      const { appointment_type, error, load } = getAppointment_type(
        this.type_consult
      );
      await load();
      for (let i = 0; i < appointment_type.value.calculation.length; i++) {
        const app_type = appointment_type.value.calculation[i];
        if (app_type.count && app_type.count != this.amount) {
          continue;
        }
        if (app_type.type && app_type.type != this.type_animal) {
          continue;
        }
        this.duration = app_type.duration;
        break;
      }
      this.showForm = "showDateForm";
    },
    async handledateSubmit() {
      this.showdateForm = false;
      this.showcontactForm = true;
    },
    async Result() {
      const { appointments, error, load } = getAppointments();
      await load();
      this.appointments = appointments;

      this.nameError =
        this.name.length < 30
          ? ""
          : "❌ Je naam mag niet langer zijn dan 30 letters.";
      this.emailError =
        this.email.length < 75
          ? ""
          : "❌ Je email mag niet langer zijn dan 75 letters.";
      this.phoneError =
        this.phone.length >= 10
          ? ""
          : "❌ Je nummer mag niet korter zijn dan 10 nummers.";

      for (let i = 0; i < this.amount; i++) {
        if (this.name_animal[i]) {
          this.name_animalError =
            this.name_animal[i].length < 90
              ? ""
              : "❌ Je huisdiernaam mag niet langer zijn dan 90 letters.";
          if (this.name_animalError != "") {
            break;
          }
        }
      }

      if (
        !this.nameError &&
        !this.emailError &&
        !this.phoneError &&
        !this.name_animalError
      ) {
        const lastappointment = this.appointments[this.appointments.length - 1];
        this.number = lastappointment.id;
        this.number++;

        await postAppointments(
          this.number,
          toDateString(this.date),
          this.time,
          this.duration,
          this.name,
          this.phone,
          this.email,
          this.userid,
          this.type_animal,
          this.type_consult,
          this.name_animal,
          this.info_animal,
          this.amount,
          this.preference,
          this.doctor,
          this.status
        );

        this.$router.push("/result/" + this.number);
      }
    },
  },
};
</script>
<style>
.appointment_header {
  text-align: left;
  margin-left: 50px;
}
.appointment_header_2 {
  text-align: left;
  margin-left: 10px;
}
.appointment_form {
  text-align: left;
  background-color: whitesmoke;
  margin-left: 20px;
}
.row {
  margin-left: 20px;
  display: flex;
}
.submit {
  float: right;
  border-radius: 12px;
  width: 150px;
  background-color: var(--happyPaw4);
  color: white;
  margin-right: 10px;
  margin-bottom: 10px;
}
.back {
  float: left;
  border-radius: 12px;
  width: 150px;
  background-color: var(--happyPaw4);
  color: white;
  margin-left: 10px;
  margin-bottom: 10px;
}
.test {
  margin-left: 50px;
  background-color: lightgrey;
  margin-right: 200px;
}
.button_div {
  margin-left: 50px;
  background-color: lightgrey;
  margin-right: 200px;
}
.time {
  width: 20%;
}
select {
  background-color: white;
  border-radius: 12px;
}
button.selected {
  color: white;
  background-color: var(--happyPaw4);
  border-radius: 12px;
  width: 50px;
  margin-right: 5px;
  margin-left: 10px;
}
button.selectedblock {
  color: white;
  background-color: var(--happyPaw4);
  height: 40px;
  width: 150px;
  margin-left: 40px;
}
button.selected_animal {
  color: white;
  background-color: var(--happyPaw4);
  border-radius: 12px;
  height: 70px;
  width: 100px;
  margin-right: 5px;
  margin-left: 10px;
}
button.selected_time {
  color: white;
  background-color: var(--happyPaw4);
  height: 40px;
  width: 110px;
  margin-left: 40px;
}
#small {
  border-radius: 12px;
  width: 50px;
  margin-right: 5px;
  margin-left: 10px;
}
#big {
  border-radius: 12px;
  height: 70px;
  width: 100px;
  margin-right: 5px;
  margin-left: 10px;
}
#smallblock {
  height: 40px;
  width: 110px;
  margin-left: 40px;
}
#block {
  height: 40px;
  width: 150px;
  margin-left: 40px;
}
#type_select {
  width: 250px;
  margin-left: 10px;
  margin-bottom: 50px;
  margin-top: 5px;
}
#removetext {
  color: lightgrey;
}
button {
  background-color: white;
  margin-bottom: 10px;
}
input {
  border-radius: 12px;
  margin-left: 10px;
  margin-bottom: 5px;
}
label {
  margin-left: 10px;
  margin-bottom: 10px;
  margin-top: 5px;
  font-weight: bold;
}
img {
  height: 50%;
  width: 40%;
}
h4 {
  margin-left: 10px;
}
#agenda {
  margin-right: 10px;
  height: 4%;
  width: 4%;
}
hamster_image {
  margin-top: 20px;
}
</style>