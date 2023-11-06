<template>
    <div class="container-fluid">
    <div class="row">
        <div class="col-12">
            <h1 class="text-lg text-left">Overzicht afspraken</h1>
            <div class="datepicker-area">
                <div class="btn-group" role="group" aria-label="datepicker">
                    <button type="button" class="btn btn-secondary">&lt;</button>
                    <button type="button" class="btn btn-secondary">{{ date }}</button>
                    <button type="button" class="btn btn-secondary">&gt;</button>
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
    export default {
        name: 'Overview',
        data() {
            return {
                appointments: null,
                date: this.getCurrentDate(),
            }
        },
        methods: {
            fetchAppointments(url) {
                console.log(url)
                var req = new Request(url)

                fetch(req)
                    .then(response => response.json())
                    .then(data => { 
                        this.appointments = data
                        console.log(this.appointments)
                    })
                    .catch(error => {
                        console.error(error)
                    })
            },
            getCurrentDate() {
                const today = new Date()
                const year = today.getFullYear()
                const month = String(today.getMonth() + 1).padStart(2, '0')
                const day = String(today.getDate()).padStart(2, '0')
                const currentDate = `${year}-${month}-${day}`
                return currentDate
            },
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
    .table .icon, .table .time {
        text-align: center;
    }
    .table .time {
        font-size: 13px;
        /* border-top: 0;
        border-bottom: 0;
        border-left: 0; */
    }
</style>