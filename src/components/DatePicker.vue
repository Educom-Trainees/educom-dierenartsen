<template>
    <div class="box">
        <div class="w-100 stat-row">
            <div id="stat" class=""></div>
        </div>
        <div class="displayDate">
            {{ shortDateDisplay(date) }}
        </div>
    </div>
</template>

<script>
import { shortDateDisplay } from '../composables/datetime-utils.js'

export default {
    name: 'DatePicker',
    props: ['date'],
    data() {
        return {
            shortDateDisplay: shortDateDisplay
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