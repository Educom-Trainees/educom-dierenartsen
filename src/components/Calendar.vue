<template>
    <table id="overview-calendar" class="table table-bordered table-responsive">
        <tr>
            <th id="th-clock"><i class="fa fa-clock-o" aria-hidden="true"></i></th>
            <th id="th-doc">{{ doctor }}</th>
        </tr>
        <tr v-for="item in calculatedTimeslots">
            <td class="event-time">{{ item.timeslot }}</td>
            <td v-if="item.appointment" class="has-event" :rowspan="item.appointment.duration/15">
                <div class="appointment">
                    <span>{{ item.appointment.customer }} - {{ item.appointment.time }}</span>
                </div>
            </td>
            <td v-else-if="item.show" class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
    export default {
        name: 'Calendar',
        props: ['doctor', 'doctorId', 'timeslots', 'appointments'],
        computed: {
            calculatedTimeslots() {
                const array = this.timeslots.map(t => {
                    const a = this.appointments.filter(a => a.time == t && a.doctor == this.doctorId)
                    return {
                        "timeslot": t,
                        "doctor": this.doctorId,
                        "appointment": a? a[0] : undefined,
                        "show": true
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
                // return array.map(t => {
                //     if (t.appointment && t.appointment.duration > 15) {
                //         const rowspan = t.appointment.duration / 15
                //         for (var i = 1; i < rowspan; i++) {
                //             const x = new Date([t.appointment.date, t.appointment.time]
                //                 .join(' '))
                //                 .setMinutes(x.getMinutes() + i * 15)
                //             const a = [String(x.getHours).padStart(2, '0'), String(x.getMinutes).padStart(2, '0')]
                //                 .join(':')
                            
                //         }
                //     }
                // })
            }
        }
    }
</script>

<style>
    .table #th-doc {
        background-color: var(--lightGrey);
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
    .table .event-time {
        border: none;
        border-right: 1px solid var(--bs-border-color);
        width: 10%;
        background-color: var(--darkGrey);
        text-align: center;
        padding: 2px;
    }
    .appointment {
        background-color: blue !important;
        color: white !important;
    }
    .col-lg-6 {
        padding: 0;
    }
</style>