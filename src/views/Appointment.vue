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
          <option value="dog">hond</option>
          <option value="cat">kat</option>
          <option value="rabbit">konijn</option>
          <option value="small_pig">cavia</option>
          <option value="hamster">hamster</option>
          <option value="rat">rat</option>
          <option value="mouse">muis</option>
        </select><br>
      <label>aantal: </label>
        <select v-model="amount">
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
        </select><br>
      <label>Naam dier: </label>
      <input type="text" required v-model="name_animal"><br>
      <label>type consult: </label>
        <select v-model="type_consult">
          <option value="consult">consult</option>
          <option value="first_consult">eerste consult</option>
          <option value="vaccine">vaccinatie</option>
          <option value="emptying">anaal klieren legen</option>
          <option value="nails">nagels knippen</option>
          <option value="blood">bloed onderzoek</option>
          <option value="urine">urine onderzoek</option>
          <option value="teeth">gebitscontrole</option>
          <option value="operation_checkup">postoperatieve controle</option>
          <option value="prescription">herhaal recept bestellen</option>
        </select>
        <div class="submit">
          <button>volgende</button>
        </div>
    </form>

    <form @submit.prevent="handledateSubmit" v-if="showdateForm">
      <label>voorkeur: </label>
        <select v-model="docter">
          <option value="1">dokter 1</option>
          <option value="2">dokter 2</option>
          <option value="none">geen voorkeur</option>
        </select><br>
      <label>Datum: </label>
        <input type="date" required v-model="date">
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
  

  export default {
    name: 'app',
    components: {

    },
    data() {
        return {
            name: '',
            email: '',
            phone: '',
            type_animal: '',
            amount: '1',
            name_animal: '',
            type_consult: '',
            showForm: true,
            showdateForm: false,
            showcontactForm: false,
            docter: 'none',
            date: '',
            nameError: '',
            emailError: '',
            phoneError: '',
            animal_nameError: ''
        }
    },
    methods: {
      handleSubmit() {
          this.showForm = false
          this.showdateForm = true
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
          console.log('naam:' + this.name)
          this.$router.push('/result')
        }
      }
    }
  }
</script>