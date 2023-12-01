<template>
    <div id="box" :class="{select: toDateString(date) == toDateString(day)}">
        <div class="w-100 stat-row">
            <div id="stat" class=""></div>
        </div>
        <div class="displayDate">
            {{ shortDateDisplay(day) }}
        </div>
    </div>
</template>

<script>
import { shortDateDisplay, toDateString } from '../composables/datetime-utils.js'

export default {
    name: 'DatePicker',
    props: ['day', 'date', 'select'],
    data() {
        return {
            shortDateDisplay: shortDateDisplay,
            toDateString: toDateString,
        }
    }
}
</script>

<style>
    .stat-row {
        height: 20px;
    }
    #stat {
        float: right;
        width: 15px;
        height: 15px;
        background-color: green;
        border-radius: 50%;
        margin: 8px;
    }
    .displayDate {
        width: 50%;
        margin: auto;
        text-align: center;
        word-wrap: break-word;
        font-size: 15px;
        font-weight: bold;
    }
</style>