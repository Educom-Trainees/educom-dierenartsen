<template>
  <div class="detail-box">
    <span class="close w-100">&times;</span>
    <div class="container">
      <div class="row">
        <div class="col-sm">
          <span class="btn">{{ appointment.duration }} mins</span>
        </div>
        <div class="col-sm">
          <span class="btn status-info">{{
            appointment.status == 0 ? "Actief" : "Geannuleerd"
          }}</span>
        </div>
      </div>
      <div class="row">
        <div class="col-sm">
          <span id="datetime-info" class="btn">{{
            displayDate(appointment.date)
          }}</span>
        </div>
        <div class="col-sm">
          <span id="datetime-info" class="btn">{{
            displayTimeslot(
              appointment.date,
              appointment.time,
              appointment.duration
            )
          }}</span>
        </div>
      </div>
      <div class="row">
        <div class="col-sm">
          <span
            @click="moveAppointment(appointment.id)"
            class="btn btn-action action-move"
            >Verplaatsen</span
          >
        </div>
        <div class="col-sm">
          <span
            @click="cancelAppointment(appointment)"
            class="btn btn-action action-cancel"
            >Annuleren</span
          >
        </div>
      </div>
      <div class="row no-padding">
        <div class="col-sm">
          <button
            :disabled="appointment.preference !== 0 || !isDoctorChangeAllowed()"
            @click="changeDoctor(appointment)"
            class="btn btn-action action-move"
          >
            Wissel arts
            <svg
              class="lock-icon"
              v-if="appointment.preference !== 0"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              height="15px"
              width="15px"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M16.5 10.5V6.75a4.5 4.5 0 10-9 0v3.75m-.75 11.25h10.5a2.25 2.25 0 002.25-2.25v-6.75a2.25 2.25 0 00-2.25-2.25H6.75a2.25 2.25 0 00-2.25 2.25v6.75a2.25 2.25 0 002.25 2.25z"
              />
            </svg>
          </button>
        </div>
        <div class="col-sm">
          <button
            @click="assignBothDoctors(appointment)"
            :disabled="appointment.doctor === 3 || !isDoctorChangeAllowed()"
            class="btn btn-action action-move"
          >
            Beide doktoren
            <svg
              class="lock-icon"
              v-if="!isDoctorChangeAllowed()"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              height="15px"
              width="15px"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M16.5 10.5V6.75a4.5 4.5 0 10-9 0v3.75m-.75 11.25h10.5a2.25 2.25 0 002.25-2.25v-6.75a2.25 2.25 0 00-2.25-2.25H6.75a2.25 2.25 0 00-2.25 2.25v6.75a2.25 2.25 0 002.25 2.25z"
              />
            </svg>
          </button>
        </div>
        <div class="row">
          <div class="col-sm">
            <button
              @click="registerNoShowAppointment(appointment)"
              :disabled="
                appointment.lateStatus === 1 ||
                new Date(appointment.date) < new Date()
              "
              class="btn btn-action action-move"
            >
              No Show
            </button>
          </div>
          <div class="col-sm"></div>
        </div>
      </div>

      <div class="row">
        <div class="col-sm">
          <h6 id="detail-label">Details</h6>
        </div>
      </div>
      <div v-for="(value, key) in customerDetails" v-bind:key="key" class="row">
        <div class="col-sm">
          <span class="details label">{{ key }}</span>
        </div>
        <div class="col-sm">
          <span class="details output">{{ value }}</span>
        </div>
      </div>
      <div class="row">
        <div class="col-sm">
          <span class="details label">Diersoort</span>
        </div>
        <div class="col-sm">
          <span class="details output">{{ petType }}</span>
        </div>
      </div>
      <div v-for="name in petNames" v-bind:key="name" class="row">
        <div class="col-sm">
          <span class="details label">Huisdier</span>
        </div>
        <div class="col-sm">
          <span class="details output">{{ name }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router/index.js";
import {
  displayTimeslot,
  displayDate,
  calculateEndTime,
} from "../composables/datetime-utils.js";
import {
  cancelAppointmentByDoctor,
  updateAppoinment,
} from "../composables/appointmentManager.js";
import { getPetTypes } from "../composables/PetManager.js";

export default {
  name: "AppointmentDetail",
  props: ["appointment"],
  inject: ["getAppointments", "todayAppointments"],
  created() {
    this.getPetTypes();
    this.todayAppointments;
  },
  data() {
    return {
      petTypes: [],
      displayDate: displayDate,
      displayTimeslot: displayTimeslot,
    };
  },
  methods: {
    async getPetTypes() {
      try {
        this.petTypes = await getPetTypes();
      } catch (error) {
        console.error(error);
      }
    },
    async cancelAppointment(appointment) {
      try {
        await cancelAppointmentByDoctor(appointment);
        router.go(0);
      } catch (error) {
        console.error(error);
      }
    },
    moveAppointment(appointmentId) {
      router.push({
        name: "change-appointment",
        params: { id: appointmentId },
      });
    },
    async changeDoctor(appointment) {
      if (appointment.preference === 0) {
        if (appointment.doctor === 1) {
          appointment.doctor = 2;
        } else if (appointment.doctor === 2) {
          appointment.doctor = 1;
        }
        updateAppoinment(appointment);
      }
    },
    assignBothDoctors(appointment) {
      appointment.doctor = 3;
      updateAppoinment(appointment);
    },
    async registerNoShowAppointment(appointment) {
      const updatedAppointment = {
        ...appointment,
        lateStatus: 1,
      };

      await updateAppoinment(updatedAppointment);

      await this.getAppointments();
    },

    isDoctorChangeAllowed() {
      const otherDoctor = this.appointment.doctor === 1 ? 2 : 1;

      //obtain start time of the appointment to be changed
      const startTime = new Date(
        [this.appointment.date, this.appointment.time].join(" ")
      );

      //obtain end time of the appointment to be changed
      const endTime = new Date(
        [this.appointment.date, this.appointment.time].join(" ")
      );
      endTime.setMinutes(endTime.getMinutes() + this.appointment.duration);

      const overlappingAppointments = this.todayAppointments.filter(
        (appointment) => {
          if (appointment.doctor !== otherDoctor) {
            return false;
          }

          //obtain start time of all appointments in agenda today
          // (this iterates over todayAppointments)
          const start = new Date(
            [appointment.date, appointment.time].join(" ")
          );

          //obtain end time of all appointments in agenda today
          const end = new Date([appointment.date, appointment.time].join(" "));
          end.setMinutes(end.getMinutes() + appointment.duration);

          if (endTime > start && startTime < end) {
            return true;
          }

          return false;
        }
      );

      //only returns true if no appointments overlap
      return overlappingAppointments.length === 0;
    },
  },
  computed: {
    customerDetails() {
      return {
        Afspraaknummer: this.appointment.number,
        Klant: this.appointment.customer,
        Telefoonnummer: this.appointment.phoneNumber,
        Email: this.appointment.email,
        Voorkeur:
          this.appointment.preference == 0
            ? "Geen"
            : this.appointment.preference == 1
            ? "Karel Lant"
            : "Danique de Beer",
      };
    },
    petType() {
      const type = this.petTypes.filter(
        (pt) => pt.id == this.appointment.petType
      )[0];
      return type ? type.name : undefined;
    },
    petNames() {
      return this.appointment.pets.map((p) => (p.name ? p.name : "?"));
    },
  },
};
</script>

<style>
.detail-box {
  background-color: #fefefe;
  margin: auto;
  border: 1px solid #888;
  padding: 4px;
  width: 100%;
  height: 100%;
  min-width: 300px;
  border-radius: 3px;
}
.detail-box .close {
  color: #aaaaaa;
  float: right;
  font-size: 24px;
  display: inline-flex;
  justify-content: end;
}
.detail-box .close:hover,
.backdrop .close:focus {
  color: #000;
  text-decoration: none;
  cursor: pointer;
}
.detail-box .container .col-sm {
  width: 50% !important;
  margin: 2px 0;
  padding: 0;
}
.detail-box .btn {
  margin: 0 !important;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  border-radius: 10px !important;
  font-size: 13px;
}
.detail-box .status-info {
  background-color: lightgreen !important;
  border-radius: 25px !important;
}
.detail-box #datetime-info {
  background-color: var(--lightGrey);
  width: 98% !important;
  padding: 0 10px !important;
}
.detail-box .btn-action {
  margin-top: 4px !important;
}
.detail-box .action-move {
  background-color: #5271ff;
}
.detail-box .action-cancel {
  background-color: #ff5757;
}
.detail-box #detail-label {
  margin: 8px 0 4px 0;
  font-weight: bolder;
}
.detail-box #detail-label .col-sm {
  margin: 0 !important;
}
.detail-box .details {
  font-size: 13px;
  word-wrap: break-word;
}
.detail-box .output {
  font-weight: bolder;
}

.no-padding > * {
  padding: 0;
}

.lock-icon {
  margin-left: 5px;
}
</style>