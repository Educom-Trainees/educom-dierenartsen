<template>
    <div class="timeslot-list">
        <div v-for="timeslot in time_slots" :key="timeslot.time">
            <h3>tijd: {{ timeslot.time }}</h3>
            <h3>dokter: {{ timeslot.docter }}</h3>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>