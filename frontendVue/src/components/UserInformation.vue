<template>
  <div class="row justify-content-center align-items-center register-row mb-4">
    <div class="col-sm-3 col-md-5 col-10 change-area">
      <button @click="toggleEditingButton" class="editing-button">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke-width="1.5"
          stroke="currentColor"
          class="w-auto h-auto"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            d="m16.862 4.487 1.687-1.688a1.875 1.875 0 1 1 2.652 2.652L10.582 16.07a4.5 4.5 0 0 1-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 0 1 1.13-1.897l8.932-8.931Zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0 1 15.75 21H5.25A2.25 2.25 0 0 1 3 18.75V8.25A2.25 2.25 0 0 1 5.25 6H10"
          />
        </svg>
      </button>
      <h2 class="usertitle">Mijn gegevens</h2>
      <form
        @submit.prevent="changeUser"
        id="info-form"
        class="d-flex flex-column align-items-center mt-4"
      >
        <div v-if="errors.genericErr" class="error">
          {{ errors.genericErr }}
        </div>
        <div class="form-group">
          <label id="salutation">Aanhef:</label><br />
          <input
            v-model="infoForm.salutation"
            type="radio"
            class="radio-btn"
            id="SalutationWomen"
            name="RegisterSalutation"
            value="Mevrouw"
            :disabled="true"
          />
          <label class="salutation-label" for="SalutationWomen">Mevrouw</label>
          <input
            v-model="infoForm.salutation"
            type="radio"
            class="radio-btn"
            id="SalutationMen"
            name="RegisterSalutation"
            value="Meneer"
            :disabled="true"
          />
          <label class="salutation-label" for="SalutationMen">Meneer</label>
          <div v-if="errors.salutationErr" class="error">
            {{ errors.salutationErr }}
          </div>
        </div>
        <div class="form-group">
          <label class="userlabel" for="RegisterFirstName">Voornaam:</label>
          <input
            v-model="infoForm.firstName"
            type="text"
            class="form-control"
            id="RegisterFirstName"
            placeholder="Voornaam"
            :disabled="true"
          />
          <div v-if="errors.firstNameErr" class="error">
            {{ errors.firstNameErr }}
          </div>
        </div>
        <div class="form-group">
          <label class="userlabel" for="RegisterLastName">Achternaam:</label>
          <input
            v-model="infoForm.lastName"
            type="text"
            class="form-control"
            id="RegisterLastName"
            placeholder="Achternaam"
            :disabled="true"
          />
          <div v-if="errors.lastNameErr" class="error">
            {{ errors.lastNameErr }}
          </div>
        </div>
        <div class="form-group">
          <label class="userlabel" for="RegisterEmail">E-mailadres:</label>
          <input
            v-model="infoForm.email"
            type="email"
            class="form-control"
            id="RegisterEmail"
            placeholder="E-mailadres"
            :disabled="!isEditing"
            :class="{ editable: isEditing }"
            ref="focusInput"
          />
          <div v-if="errors.emailErr" class="error">{{ errors.emailErr }}</div>
        </div>
        <div class="form-group">
          <label class="userlabel" for="RegisterPhone">Telefoonnummer:</label>
          <input
            v-model="infoForm.phone"
            type="tel"
            class="form-control"
            id="RegisterPhone"
            placeholder="Telefoonnummer"
            :disabled="!isEditing"
            :class="{ editable: isEditing }"
          />
          <div v-if="errors.phoneErr" class="error">{{ errors.phoneErr }}</div>
        </div>
        <button
          type="submit"
          class="btn submit-btn mt-4"
          :disabled="!isEditing"
        >
          Opslaan
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import { getUserDataFromSession } from "../composables/sessionManager.js";
import { getUserById } from "../composables/userManager.js";
import { changeUser } from "../composables/userChanges.js";
export default {
  data() {
    return {
      infoForm: {
        id: 0,
        salutation: "",
        firstName: "",
        lastName: "",
        email: "",
        phone: "",
      },
      errors: {
        genericErr: undefined,
        salutationErr: undefined,
        firstNameErr: undefined,
        lastNameErr: undefined,
        emailErr: undefined,
        phoneErr: undefined,
      },
      isEditing: false,
    };
  },
  async created() {
    const user = getUserDataFromSession();
    var userdata = getUserById(user.userId);

    const value = await userdata.then(function (result) {
      var id = result.id;
      var email = result.email;
      var salutation = result.salutation;
      var firstName = result.firstName;
      var lastName = result.lastName;
      var phone = result.phone;
      return { id, email, salutation, firstName, lastName, phone };
    });
    this.infoForm.id = value.id;
    this.infoForm.email = value.email;
    this.infoForm.salutation = value.salutation;
    this.infoForm.firstName = value.firstName;
    this.infoForm.lastName = value.lastName;
    this.infoForm.phone = value.phone;
  },
  methods: {
    async changeUser() {
      this.errors.firstNameErr =
        this.infoForm.firstName.length < 30
          ? ""
          : "❌ Je voornaam mag niet langer zijn dan 30 letters.";
      this.errors.lastNameErr =
        this.infoForm.lastName.length < 30
          ? ""
          : "❌ Je achternaam mag niet langer zijn dan 30 letters.";
      this.errors.emailErr =
        this.infoForm.email.length < 75
          ? ""
          : "❌ Je email mag niet langer zijn dan 75 letters.";
      this.errors.phoneErr =
        this.infoForm.phone.length >= 10
          ? ""
          : "❌ Je nummer mag niet korter zijn dan 10 nummers.";

      if (
        !this.errors.firstNameErr &&
        !this.errors.lastNameErr &&
        !this.errors.emailErr &&
        !this.errors.phoneErr
      ) {
        const result = await changeUser(this.infoForm);
        if (result && typeof result === "object") {
          this.errors = result;
        }
      }
    },
    toggleEditingButton() {
      this.isEditing = !this.isEditing;
      this.$nextTick(() => {
        this.$refs.focusInput.focus();
      });
    },
  },
};
</script>

<style>
input,
label {
  margin-top: 0%;
  margin-bottom: 0%;
}
.usertitle {
  font-size: 1.5em;
}
.form-control {
  text-align: center;
  padding: 0;
  background-color: transparent;
  border: solid;
  border-color: transparent;
  border-radius: 10px;
  outline: none;
}
.change-area {
  border: 8px solid var(--happyPaw1);
  position: relative;
}
.editing-button {
  width: 35px;
  height: 35px;
  position: absolute;
  right: 10px;
  border: none;
  background-color: transparent;
}

.editable {
  border: solid;
  border-color: #e9ecef;
}
</style>