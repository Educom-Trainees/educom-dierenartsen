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
        <div v-if="time_slots.length">
              <select v-model="timeslotdata">
              <option :value="timeslot" v-for="timeslot in time_slots" :key="timeslot.time">
                <div v-if="timeslot.doctor == this.preference || this.preference == 0">
                  tijd: {{ timeslot.time }} dokter: {{ timeslot.doctor }}
                </div>
              </option>
              <!-- <p v-if="timeslot.doctor == this.preference || this.preference == 0">
                tijd: {{ timeslot.time }} dokter: {{ timeslot.doctor }}
              </p> -->
              </select>
        </div>
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
  import getTime_slots from '../composables/getTime_slots'
  import getAppointments from '../composables/getAppointments'
  import getAppointment_type from '../composables/getAppointment_type'
  import postAppointments from '../composables/postAppointments'

  export default {
    name: 'app',
    components: {},
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
            number: 0,
            appointments: '',
            time_slots: '',
            timeslotdata: '',
            time: '',
            doctor: '',
            date: '',
            nameError: '',
            emailError: '',
            phoneError: '',
            animal_nameError: ''
        }
    },
    methods: {
      async handleSubmit() {
        const { appointment_type, error, load } = getAppointment_type(this.type_consult)
        await load()
        for(let i=0; i < appointment_type.value.calculation.length; i++){
          const app_type = appointment_type.value.calculation[i];
          if (app_type.count && app_type.count != this.amount) { 
            continue
          }
          if(app_type.type && app_type.type != this.type_animal){
            continue
          }
          this.duration = app_type.duration
          break
        }
        console.log(this.duration)

        const { time_slots, timeslot_error } = await this.gettimeslots()

        this.time_slots = time_slots

        this.showForm = false
        this.showdateForm = true
        return { 
          appointment_type, 
          time_slots, 
          error, 
          timeslot_error 
        }
      },
      handledateSubmit() {
        this.time = this.timeslotdata.time
        this.doctor = this.timeslotdata.doctor
        this.showdateForm = false
        this.showcontactForm = true
      },
      async Result() {
        const { appointments, error, load } = getAppointments()
        await load()
        this.appointments = appointments


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
          const lastappointment = this.appointments[this.appointments.length - 1]
          this.number = lastappointment.id
          this.number++
          await postAppointments(this.number, this.date, this.time, this.duration, this.name, this.phone, this.email, this.type_animal, this.type_consult, this.name_animal, this.preference, this.doctor, this.status)
          console.log('de afspraak is gepost')
          this.$router.push('/result/' + this.number)
        }
      },
      async gettimeslots(){
        const { time_slots, error, load } = getTime_slots()
        await load()
        return { time_slots, error }
      }
    }
  }
</script>