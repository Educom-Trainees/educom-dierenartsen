<template>
    <div class="row justify-content-center align-items-center register-row mb-4">
        <div class="col-sm-3 col-md-5 col-10 change-area">
            <h2 class="usertitle">Mijn gegevens</h2>
            <form @submit.prevent="changeUser" id="info-form" class="d-flex flex-column align-items-center mt-4">
            <div v-if="errors.genericErr" class="error">{{ errors.genericErr }}</div>
            <div class="form-group">
                <label id="salutation">Aanhef:</label><br>
                <input v-model="infoForm.salutation" type="radio" class="radio-btn" id="SalutationWomen" name="RegisterSalutation" value="Mevrouw">
                <label class="salutation-label" for="SalutationWomen">Mevrouw</label>
                <input v-model="infoForm.salutation" type="radio" class="radio-btn" id="SalutationMen" name="RegisterSalutation" value="Meneer">
                <label class="salutation-label" for="SalutationMen">Meneer</label>
                <div v-if="errors.salutationErr" class="error">{{ errors.salutationErr }}</div>
            </div>
            <div class="form-group">
                <label class="userlabel" for="RegisterFirstName">Voornaam:</label>
                <input v-model="infoForm.firstName" type="text" class="form-control" id="RegisterFirstName" placeholder="Voornaam">
                <div v-if="errors.firstNameErr" class="error">{{ errors.firstNameErr }}</div>
            </div>
            <div class="form-group">
                <label class="userlabel" for="RegisterLastName">Achternaam:</label>
                <input v-model="infoForm.lastName" type="text" class="form-control" id="RegisterLastName" placeholder="Achternaam">
                <div v-if="errors.lastNameErr" class="error">{{ errors.lastNameErr }}</div>
            </div>
            <div class="form-group">
                <label class="userlabel" for="RegisterEmail">E-mailadres:</label>
                <input v-model="infoForm.email" type="email" class="form-control" id="RegisterEmail" placeholder="E-mailadres">
                <div v-if="errors.emailErr" class="error">{{ errors.emailErr }}</div>
            </div>
            <div class="form-group">
                <label class="userlabel" for="RegisterPhone">Telefoonnummer:</label>
                <input v-model="infoForm.phone" type="tel" class="form-control" id="RegisterPhone" placeholder="Telefoonnummer">
                <div v-if="errors.phoneErr" class="error">{{ errors.phoneErr }}</div>
            </div>
                <button type="submit" class="btn submit-btn mt-4">Opslaan</button>
            </form>
        </div>
    </div>
</template>

<script>
import { getUserDataFromSession } from '../composables/sessionManager.js'
import { getUserById } from '../composables/userManager.js'
import { changeUser } from '../composables/userChanges.js'
export default {
    data() {
        return {
            infoForm: {
                'id': 0,
                'salutation': '',
                'firstName': '',
                'lastName': '',
                'email': '',
                'phone': '',
            },
            errors: {
                'genericErr': undefined,
                'salutationErr': undefined,
                'firstNameErr': undefined,
                'lastNameErr': undefined,
                'emailErr': undefined,
                'phoneErr': undefined,
            },
        }
    },
    async created() {
        const user = getUserDataFromSession()
        var userdata = getUserById(user.userId)
          
        const value = await userdata.then(function(result) {
            var id = result.id
            var email = result.email
            var salutation = result.salutation
            var firstName = result.firstName 
            var lastName = result.lastName
            var phone = result.phone
            return {id, email, salutation, firstName, lastName, phone}
        })
        this.infoForm.id = value.id
        this.infoForm.email = value.email
        this.infoForm.salutation = value.salutation
        this.infoForm.firstName = value.firstName
        this.infoForm.lastName = value.lastName
        this.infoForm.phone = value.phone
    },
    methods: {
        async changeUser(){
            this.errors.firstNameErr = this.infoForm.firstName.length < 30 ?
            '' : '❌ Je voornaam mag niet langer zijn dan 30 letters.'
            this.errors.lastNameErr = this.infoForm.lastName.length < 30 ?
            '' : '❌ Je achternaam mag niet langer zijn dan 30 letters.'
            this.errors.emailErr = this.infoForm.email.length < 75 ?
            '' : '❌ Je email mag niet langer zijn dan 75 letters.'
            this.errors.phoneErr = this.infoForm.phone.length >= 10 ?
            '' : '❌ Je nummer mag niet korter zijn dan 10 nummers.'

            if(!this.errors.firstNameErr && !this.errors.lastNameErr && !this.errors.emailErr && !this.errors.phoneErr){
                const result = await changeUser(this.infoForm)
                if (result && typeof result === 'object') {
                    this.errors = result
                }
            }
        }
    }
}
</script>

<style>
input, label{
    margin-top: 0%;
    margin-bottom: 0%;
}
.usertitle{
    font-size: 1.5em;
}
.form-control{
    text-align: center;
    padding: 0;
    background-color: transparent;
    border: none;
    outline: none;
}
.change-area {
    border: 8px solid var(--happyPaw1);
}
</style>