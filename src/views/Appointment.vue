<template>
  <div class="planning">
    <h1>Afspraak maken:</h1>
    <form @submit.prevent="handleSubmit" v-if="showForm"> 
      <!-- <label>Naam: </label>
      <input type="text" required v-model="name"><br>
      <div v-if="nameError" class="error">{{ nameError }}</div>
      <label>Email: </label>
      <input type="email" required v-model="email"><br>
      <div v-if="emailError" class="error">{{ emailError }}</div>
      <label>Telefoonnummer: </label>
      <input type="text" required v-model="phone"><br>
      <div v-if="phoneError" class="error">{{ phoneError }}</div> -->
      <label>type dier: </label>
        <select v-model="type_animal">
          <option value="1">hond</option>
          <option value="8">kleine hond</option>
          <option value="9">grote hond</option>
          <option value="2">kat</option>
          <option value="3">konijn</option>
          <option value="4">cavia</option>
          <option value="5">hamster</option>
          <option value="6">rat</option>
          <option value="7">muis</option>
        </select><br>
      <label>aantal: </label>
        <select v-model="amount">
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
        </select><br>
      <label v-if="amount == 1">Naam huisdier: </label>
      <label v-if="amount != 1">Naam eerste huisdier: </label>
      <input type="text" required v-model="name_animal[0]"><br>
      <div v-if="amount != 1">
        <label>Naam tweede huisdier: </label>
        <input type="text" required v-model="name_animal[1]">
      </div>
      <div v-if="amount != 1 && amount != 2">
        <label>Naam derde huisdier: </label>
        <input type="text" required v-model="name_animal[2]">
      </div>
      <div v-if="amount == 4">
        <label>Naam vierde huisdier: </label>
        <input type="text" required v-model="name_animal[3]">
      </div>
      <label>type consult: </label>
        <select v-model="type_consult">
          <option value="1">consult</option>
          <option value="2">eerste consult</option>
          <option value="3">vaccinatie</option>
          <option value="4">anaal klieren legen</option>
          <option value="5">nagels knippen</option>
          <option value="6">bloed onderzoek</option>
          <option value="7">urine onderzoek</option>
          <option value="8">gebitscontrole</option>
          <option value="9">postoperatieve controle</option>
          <option value="10">herhaal recept bestellen</option>
        </select>
        <div class="submit">
          <button>volgende</button>
        </div>
    </form>

    <form @submit.prevent="handledateSubmit" v-if="showdateForm">
      <label>voorkeur: </label>
        <select v-model="preference">
          <option value="1">karel lant</option>
          <option value="2">danique de beer</option>
          <option value="0">geen voorkeur</option>
        </select><br>
      <label>Datum: </label>
        <input type="date" required v-model="date">
      <label>Tijd:</label>
        <!-- <div v-if="time_slots.length">
          <TimeSlotList :timeslots="time_slots" />
        </div> -->
      <button>vorige</button>
      <div class="submit">
        <button>volgende</button>
      </div>
    </form>

    <form @submit.prevent="Result" v-if="showcontactForm">
      <label>Naam: </label>
      <input type="text" required v-model="name"><br>
      <div v-if="nameError" class="error">{{ nameError }}</div>
      <label>Email: </label>
      <input type="email" required v-model="email"><br>
      <div v-if="emailError" class="error">{{ emailError }}</div>
      <label>Telefoonnummer: </label>
      <input type="text" required v-model="phone"><br>
      <div v-if="phoneError" class="error">{{ phoneError }}</div>
      <button>vorige</button>
      <div class="submit">
        <button>bevestig afspraak</button>
      </div>
    </form>
  </div>
</template>

<script>
  import TimeSlotList from '../components/TimeSlotList.vue'
  import getTime_slots from '../composables/getTime_slots'
  import getAppointment_type from '../composables/getAppointment_type'
  import postAppointments from '../composables/postAppointments'

  export default {
    name: 'app',
    components: { TimeSlotList },
    setup() {
      const { time_slots, error, load} = getTime_slots()
      load()
      return {
        time_slots,
        error
      }
    },
    data() {
        return {
            name: '',
            email: '',
            phone: '',
            type_animal: '',
            amount: 1,
            name_animal: [],
            type_consult: '',
            showForm: true,
            showdateForm: false,
            showcontactForm: false,
            duration: 0,
            preference: 0,
            status: 0,
            date: '',
            nameError: '',
            emailError: '',
            phoneError: '',
            animal_nameError: ''
        }
    },
    methods: {
      handleSubmit() {
        const { appointment_type, error, load } = getAppointment_type(this.type_consult)
        load()
        // if(){
        //   this.amount = appointment_type.
        // }
        console.log(appointment_type)
        console.log(appointment_type.value)

        this.showForm = false
        this.showdateForm = true
        return { appointment_type, error }
      },
      handledateSubmit() {
        this.showdateForm = false
        this.showcontactForm = true
      },
      Result() {
        this.nameError = this.name.length < 30 ?
        '' : 'je naam mag niet langer zijn dan 30 letters'
        this.emailError = this.email.length < 75 ?
        '' : 'je email mag niet langer zijn dan 75 letters'

        // dit werkt niet met de -
        // const validationPhone = /^\d{10}$/;

        // this.phoneError = this.phone.match(validationPhone) ?
        // '' : 'je telefoonnummer moet bestaan uit 10 nummers'

        if(!this.nameError && !this.emailError){
          console.log('je zit goed')
          console.log(this.name_animal)
          console.log(this.name_animal[0])
          console.log(this.name_animal[1])
          postAppointments(this.date, this.name, this.phone, this.email, this.type_animal, this.name_animal, this.preference, this.status)
          // console.log('naam:' + this.name)
          // this.$router.push('/result')
        }
      }
    }
  }
</script>