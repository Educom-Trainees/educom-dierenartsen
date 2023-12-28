<template>
  <div>
    <TopNavigation />
    <div id="vacations-page" class="container-fluid">
      <div class="row">
        <div class="col-12">
          <h1 class="text-lg text-left">Vakanties</h1>
          <div v-if="errors.genericError" class="error">
            {{ error.genericError }}
          </div>
        </div>
      </div>
      <div class="row justify-content-around">
        <div id="vacation-planner" class="col-11 col-lg-4">
          <h2 class="text-md">Vakantie inplannen</h2>
          <form @submit.prevent="saveVacation" class="vacation-form">
            <div class="form-group">
              <label for="employee">Medewerker</label>
              <select
                v-model="newVacation.userId"
                class="form-select"
                id="employee"
                placeholder="Kies medewerker"
              >
                <option
                  v-for="option in options"
                  :selected="!option.value"
                  :disabled="!option.value"
                  :value="option.value"
                >
                  {{ option.text }}
                </option>
              </select>
              <div v-if="errors.employeeError" class="error">
                {{ errors.employeeError }}
              </div>
            </div>
            <div class="form-group">
              <label for="begin-datetime">Begin datum & tijd</label>
              <input
                v-model="newVacation.startDateTime"
                type="datetime-local"
                class="form-control"
                id="begin-datetime"
              />
              <div v-if="errors.startDateTimeError" class="error">
                {{ errors.startDateTimeError }}
              </div>
            </div>
            <div class="form-group">
              <label for="end-datetime">Eind datum & tijd</label>
              <input
                v-model="newVacation.endDateTime"
                type="datetime-local"
                class="form-control"
                id="end-datetime"
              />
              <div v-if="errors.endDateTimeError" class="error">
                {{ errors.endDateTimeError }}
              </div>
            </div>
            <div class="form-group">
              <label for="reason">Reden</label>
              <textarea
                v-model="newVacation.reason"
                class="form-control"
                id="reason"
                rows="5"
              ></textarea>
              <div v-if="errors.reasonError" class="error">
                {{ errors.reasonError }}
              </div>
            </div>
            <button type="submit" class="btn submit-btn mt-5">Opslaan</button>
          </form>
        </div>
        <div id="vacation-overview" class="col-11 col-lg-6">
          <h2 class="text-md">Vakantie overzicht</h2>
          <div v-for="doctor in doctors">
            <h5 class="m-0">{{ doctor.fullName }}</h5>
            <table class="table vacation-table">
              <thead>
                <tr>
                  <th class="thead" scope="col">Begin</th>
                  <th class="thead" scope="col">Eind</th>
                  <th scope="col">Reden</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="vacation in doctor.vacations">
                  <td>{{ displayDateTime(vacation.startDateTime) }}</td>
                  <td>{{ displayDateTime(vacation.endDateTime) }}</td>
                  <td>{{ vacation.reason }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router/index.js";
import TopNavigation from "../components/TopNavigation.vue";
import { bookNewVacation } from "../composables/vacationManager.js";
import { getUser } from "../composables/userManager.js";
import {
  displayDateTime,
  formatForDatePickerLocal,
} from "../composables/datetime-utils.js";

export default {
  name: "Vacation",
  components: {
    TopNavigation,
  },
  beforeMount() {
    this.getDoctors();
  },
  data() {
    const todayStartOfDay = new Date();
    todayStartOfDay.setHours(9);
    todayStartOfDay.setMinutes(0);

    const todayEndOfDay = new Date();
    todayEndOfDay.setHours(17);
    todayEndOfDay.setMinutes(30);

    return {
      doctors: [],
      options: [{ value: undefined, text: "Kies medewerker" }],
      newVacation: {
        userId: undefined,
        startDateTime: formatForDatePickerLocal(todayStartOfDay),
        endDateTime: formatForDatePickerLocal(todayEndOfDay),
        reason: undefined,
      },
      errors: {
        genericError: undefined,
        employeeError: undefined,
        startDateTimeError: undefined,
        endDateTimeError: undefined,
        reasonError: undefined,
      },
      displayDateTime: displayDateTime,
    };
  },
  methods: {
    async getDoctors() {
      try {
        const doctors = [
          await getUser("karel@happypaw.nl"),
          await getUser("danique@happypaw.nl"),
        ];

        for (const doctor of doctors) {
          const fullName = [doctor.firstName, doctor.lastName].join(" ");

          this.doctors.push({
            fullName: fullName,
            vacations: doctor.vacations,
          });
          this.options.push({
            value: doctor.id,
            text: fullName,
          });
        }
      } catch (error) {
        this.errors.genericError =
          "Er is iets fout gegaan. Probeer het later opnieuw.";
        console.error(error);
      }
    },
    async saveVacation() {
      const validForm = this.validateForm();
      if (validForm) {
        try {
          console.log("vacation", this.newVacation);
          await bookNewVacation(this.newVacation);
          router.go(0);
        } catch (error) {
          console.error(error);
          this.errors.genericError =
            "Er is iets fout gegaan. Probeer het later opnieuw.";
        }
      }
    },
    validateForm() {
      var valid = true;
      if (!this.newVacation.userId) {
        this.errors.employeeError = "Vergeet niet een medewerker te kiezen.";
        valid = false;
      }
      if (!this.newVacation.startDateTime) {
        this.errors.startDateTimeError =
          "Vergeet niet de datum en tijd in te vullen.";
        valid = false;
      }
      if (!this.newVacation.endDateTime) {
        this.errors.endDateTimeError =
          "Vergeet niet de datum en tijd in te vullen.";
        valid = false;
      }
      if (!this.newVacation.reason) {
        this.errors.reasonError = "Vergeet niet een reden te in te vullen.";
        valid = false;
      }
      return valid;
    },
  },
};
</script>

<style>
.vacation-form {
  width: 50%;
}
.vacation-form .form-control,
.vacation-form .form-select {
  text-align: left;
  border: 3px solid var(--darkGrey);
  margin: 0;
  padding: 4px;
}
.vacation-form label,
.vacation-table th {
  color: gray;
}
.vacation-form .submit-btn {
  width: 100%;
}
#vacation-overview h5 {
  font-weight: bolder;
}
.vacation-table {
  border-color: var(--happyPaw1) !important;
}
.vacation-table .thead {
  width: 25%;
}
@media (max-width: 768px) {
  .vacation-form *,
  .vacation-table *,
  #vacation-overview h5 {
    font-size: 0.78rem;
  }
  #vacation-overview {
    margin-top: 24px;
  }
  .vacation-table .thead {
    width: 30%;
  }
  .vacation-form {
    width: 100%;
  }
}
</style>