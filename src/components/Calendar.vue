<template>
    <table id="overview-calendar" class="table table-bordered table-responsive">
        <tr>
            <th id="clock-o"><i class="fa fa-clock-o" aria-hidden="true"></i></th>
            <th>{{ doctor }}</th>
        </tr>
        <tr v-for="item in calculatedTimeslots">
            <td class="event-time">{{ item.timeslot }}</td>
            <td v-if="item.appointment" class="has-event" :rowspan="item.appointment.duration/15">
                <div class="appointment">
                    <span>{{ item.appointment.customer }} - {{ item.appointment.time }}</span>
                </div>
            </td>
            <td v-else class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
    export default {
        name: 'Calendar',
        props: ['doctor', 'timeslots', 'appointments'],
        computed: {
            calculatedTimeslots() {
                return this.timeslots.map(t => {
                    const a = this.appointments.filter(a => a.time == t && a.doctor == this.doctor)
                    return {
                        "timeslot": t,
                        "appointment": a? a[0] : undefined
                    }
                })
            }
        }
    }
</script>

<style>
    .appointment {
        background-color: blue;
        color: white;
    }
</style>