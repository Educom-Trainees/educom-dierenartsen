<template>
    <div class="container-fluid">
    <div class="row">
        <div class="col-12">
            <h1 class="text-lg text-left">Overzicht afspraken</h1>

            <div class="datepicker-area d-flex justify-content-center align-items-center">
                <div class="btn-group" role="group" aria-label="datepicker">
                    <button @click="($event) => {if (date > today) { previousDateDate() }}" type="button" class="btn btn-secondary">&lt;</button>
                    <button type="button" class="btn btn-secondary">{{ getDateString(date) }}</button>
                    <button @click="nextDate()" type="button" class="btn btn-secondary">&gt;</button>
                </div>
            </div>

            <table class="table table-bordered table-responsive">
                <tr>
                    <th class="icon"><i class="fa fa-clock-o" aria-hidden="true"></i></th>
                    <th width="47%">Karel Lant</th>
                    <th width="47%">Danique de Beer</th>
                </tr>
                <tr>
                    <td class="time">09:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">09:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">09:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">09:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">10:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">10:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">10:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">10:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">11:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">11:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">11:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">11:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">12:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">12:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">12:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">12:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">13:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">13:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">13:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">13:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">14:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">14:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">14:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">14:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">15:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">15:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">15:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">15:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">16:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">16:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">16:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">16:45</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">17:00</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">17:15</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
                <tr>
                    <td class="time">17:30</td>
                    <td class="no-event" rowspan="1"></td>
                    <td class="no-event" rowspan="1"></td>
                </tr>
            </table>
        </div>
    </div>
  </div>
</template>

<script>
    import axios from 'axios';

    const today = this.getDateString(new Date())

    export default {
        name: 'Overview',
        data() {
            return {
                timeslots: [],
                errors: [],
                appointments: null,
                // today: this.getDateString(new Date()),
                date: new Date(),
            }
        },
        created() {
            axios.get(`http://localhost:3000/timeslots?date=2023-11-10`)
            .then(response => {
                this.timeslots = response.data,
                console.log(response.data)
            })
            .catch(e => {
            this.errors.push(e)
            })
        },
        methods: {
            // fetchAppointments(url) {
            //     console.log(url)
            //     var req = new Request(url)

            //     fetch(req)
            //         .then(response => response.json())
            //         .then(data => { 
            //             this.appointments = data
            //             console.log(this.appointments)
            //         })
            //         .catch(error => {
            //             console.error(error)
            //         })
            // },
            getDateString(date) {
                const year = date.getFullYear()
                const month = String(date.getMonth() + 1).padStart(2, '0')
                const day = String(date.getDate()).padStart(2, '0')
                return `${year}-${month}-${day}`
            },
            nextDate() {
                this.date.setDate(this.date.getDate() + 1); 
            },
            previousDate() {
                this.date.setDate(this.date.getDate() - 1); 
            }
        },
        // computed: {
        //     filterAppointments() {
        //         this.doctor_1_appointments = this.appointments.filter((appointment) => appointment.doctor == 1)
        //     }
        // }
    }

</script>

<style>
    .container-fluid * {
        text-align: left;
    }
    .datepicker-area {
        min-height: 70px;
        background-color: var(--darkGrey);
    }
    .datepicker-area .btn-group, .datepicker-area .btn-group .btn {
        background-color: var(--lightGrey);
        color: black;
        border: none;
    }
    .table > :not(caption) > * > * {
        padding: .45rem .45rem;
    }
    .table .icon {
        text-align: center;
        font-size: 2rem;
    }
    .table .time {
        font-size: 11px;
        text-align: center;
        /* border-top: 0;
        border-bottom: 0;
        border-left: 0; */
    }
</style>