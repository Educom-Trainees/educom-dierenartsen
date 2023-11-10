<template>
    <table id="overview-calendar" class="table table-bordered table-responsive h-100">
        <tr>
            <th id="th-clock">
                <i class="fa fa-clock-o" aria-hidden="true"></i>
            </th>
            <th id="th-doc">
                <span id="doctor">{{ doctor }}</span>
                <span id="nr-appointment"></span>
            </th>
        </tr>
        <tr v-for="item in calculatedTimeslots">
            <td class="timeslot">{{ item.timeslot }}</td>
            <td v-if="item.appointment" class="has-event" :rowspan="item.appointment.duration/15">
                <div class="appointment" :style="{ 'height': (25 * (item.appointment.duration/15)) + 'px', 'background-color': color + '!important' }">
                    <span class="appointment-info">{{ item.appointment.customer }} &mdash; {{ item.appointment.time }} - {{ calculateEndTime(item.appointment) }}</span>
                </div>
            </td>
            <td v-else-if="item.show" class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
    export default {
        name: 'Calendar',
        props: ['doctor', 'doctorId', 'timeslots', 'appointments', 'color'],
        methods: {
            calculateEndTime(appointment) {
                const ts = new Date([appointment.date, appointment.time]
                    .join(' '))
                ts.setMinutes(ts.getMinutes() + appointment.duration)
                return this.toTimeString(ts)
            },
            toTimeString(datetime) {
                return [String(datetime.getHours()).padStart(2, '0'), String(datetime.getMinutes()).padStart(2, '0')]
                    .join(':')
            },
        },
        computed: {
            calculatedTimeslots() {
                const array = this.timeslots.map(t => {
                    const a = this.appointments.filter(a => a.time == t && a.doctor == this.doctorId)
                    return {
                        "timeslot": t,
                        "doctor": this.doctorId,
                        "appointment": a? a[0] : undefined,
                        "show": true,
                    }
                })
                for (var i = 0; i < array.length; i++) { 
                    if (array[i].appointment) {
                        if (array[i].appointment.duration > 15) {
                            const r = array[i].appointment.duration / 15
                            for (var n = 1; n < r; n++) {
                                array[i+n].show = false
                            }
                        }
                    }
                }
                console.log(1, array)
                return array
            }
        }
    }
</script>

<style>
    .table #th-doc {
        background-color: var(--lightGrey);
        padding: 0 20px;
    }
    .table #th-clock i {
        background-color: var(--darkGrey);
    }
    .table #th-clock {
        text-align: center;
        font-size: 2rem;
        border-right: 1px solid var(--bs-border-color);
        background-color: var(--darkGrey);
    }
    .table #doctor {
        background-color: var(--lightGrey);
    }
    .table .timeslot {
        border: none;
        border-right: 1px solid var(--bs-border-color);
        width: 10%;
        background-color: var(--darkGrey);
        text-align: center;
        padding: 2px;
    }
    .table .appointment {
        color: black !important;
        padding: 0 16px !important;
        margin: 0 24px;
        border-radius: 25px;
        min-height: 25px;
    }
    .table .appointment-info {
        padding: 8px;
    }
    #h-2 {
        min-height: 50px;
    }
    #h-3 {
        min-height: 75px;
    }
    #h-2 {
        min-height: px;
    }
    .col-lg-6 {
        padding: 0;
    }
</style>