<template>
    <div class="container-fluid">
    <div class="row">
        <div class="col-12">
            <h1 class="text-lg text-left">Overzicht afspraken</h1>

            <div id="datepicker-area" class="d-flex justify-content-center align-items-center">
                <div class="btn-group" role="group" aria-label="datepicker">
                    <button @click="()=>{ if (date > today) { previousDate() } }" type="button" class="btn btn-secondary active">&lt;</button>
                    <button type="button" class="btn btn-secondary">{{ toDateString(date) }}</button>
                    <button @click="nextDate()" type="button" class="btn btn-secondary active">&gt;</button>
                </div>
            </div>
            
            <table id="overview-calendar" class="table table-bordered table-responsive">
                <tr>
                    <th id="clock-o"><i class="fa fa-clock-o" aria-hidden="true"></i></th>
                    <th width="47%">{{ doctors[0] }}</th>
                    <th width="47%">{{ doctors[1] }}</th>
                </tr>
                <tr v-for="timeslot in timeslots.filter(timeslot => timeslot.doctor == 1)">
                    <td class="event-time">{{ timeslot.time }}</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
            </table>
        </div>
    </div>
  </div>
</template>

<script>
    import axios from 'axios'

    const testDate = '2023-11-10'
    const doctors = ['Karel Lant', 'Danique de Beer']
    const today = new Date(testDate)
    const baseUrlTimeslots = 'http://localhost:3000/timeslots?date='
    const baseUrlActiveAppointments = 'http://localhost:3000/appointments?status=0&date='

    export default {
        name: 'Overview',
        components: {
        },
        created() {
            this.getTimeslots(testDate)
            this.getActiveAppointments(testDate)
        },
        updated() {
            console.log('mounting appointments')
            this.mountAppointments()
        },
        data() {
            return {
                doctors: doctors,
                timeslots: [],
                activeAppointments: [],
                today: today,
                date: new Date(),
            }
        },
        methods: {
            toDateString(date) {
                const year = date.getFullYear()
                const month = String(date.getMonth() + 1).padStart(2, '0')
                const day = String(date.getDate()).padStart(2, '0')
                return `${year}-${month}-${day}`
            },
            nextDate() {
                this.date.setDate(this.date.getDate() + 1)
                console.log('next day: ', this.date)
            },
            previousDate() {
                this.date.setDate(this.date.getDate() - 1)
                console.log('previous day: ', this.date)
            }, 
            async getTimeslots(dateString) {
                const url = baseUrlTimeslots + dateString
                await axios.get(url)
                    .then(response => {
                        this.timeslots = response.data;
                        console.log(response.data)
                    })
                    .catch(error => {
                            console.error('Error getting timeslots:', error);
                }); 
            },
            async getActiveAppointments(dateString) {
                const url = baseUrlActiveAppointments + dateString
                await axios.get(url)
                    .then(response => {
                        this.activeAppointments = response.data;
                        console.log(response.data)
                    })
                    .catch(error => {
                            console.error('Error getting active appointments:', error);
                }); 
            },
            mountAppointments() {
                const appointmentsObject = {
                    1: this.activeAppointments.filter(a => a.doctor == 1),
                    2: this.activeAppointments.filter(a => a.doctor == 2)
                }
                const timeslotArray = [
                    this.timeslots.filter(t => t.doctor == 1),
                    this.timeslots.filter(t => t.doctor == 2)
                ]
                for (let doctorsKey in appointmentsObject) {
                    for (let appointment of appointmentsObject[doctorsKey]) {
                        for (var timeslotIndex = 0; timeslotIndex < timeslotArray.length; timeslotIndex++) {
                            if (appointment.time == timeslotArray[timeslotIndex].time) {
                                this.addToOverview(timeslotIndex, appointment) 
                            }
                        }
                    }
                }
            },
            calculateRowspan(duration) {
                switch (duration) {
                    case "15": 
                        return "1"
                    case "30":
                        return "2"
                    case "45":
                        return "3"
                    case "60":
                        return "4"
                }
            },
            addToOverview(timeslotIndex, appointment) {
                const customer = appointment.customer
                const startTime = appointment.time
                const table = document.getElementById('overview-calendar').getElementsByTagName('tbody')[0]
                const timeslotRow = table.rows[timeslotIndex]
                const cell = timeslotRow.childNodes[appointment.doctor]

                cell.classList.remove("no-event")
                cell.classList.add("has-event")
                const rowspan = this.calculateRowspan(appointment.duration)
                cell.setAttribute("rowspan", rowspan)
                cell.innerHTML = 
                    '<div class="appointment">' +
                        '<span>' + customer - startTime + '</span>' +
                    '</div>'
                console.log('added to calendar')
            },
        },
        // computed: {
        //     date: {
        //         get() {
        //             return this.toDateString(this.date)
        //         },
        //     }
        // }
    }
</script>

<style>
    .container-fluid * {
        text-align: left;
    }
    #datepicker-area {
        min-height: 70px;
        background-color: var(--darkGrey);
    }
    #datepicker-area .btn-group, #datepicker-area .btn-group .btn {
        background-color: var(--lightGrey);
        color: black;
        border: none;
    }
    #clock-o {
        text-align: center;
        font-size: 2rem;
    }
    .table .event-time {
        text-align: center;
        padding: 2px;
    }
</style>