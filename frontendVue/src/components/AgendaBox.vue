<template>
    <div id="agenda-box" class="d-flex">
        <div id="agenda-box-1" class="agenda-child-box d-flex justify-content-center align-items-center">
            <img id="agenda-sm" src="../assets/agenda.png">
        </div>
        <div id="agenda-box-2" class="agenda-child-box d-flex flex-column justify-content-center align-items-start">
            <div class="d-flex">
                <span id="status-full" class="status-circle"></span>
                <span>Volzet</span>
            </div>
            <div class="d-flex">
                <span id="status-free" class="status-circle"></span>
                <span>Beschikbaar</span>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'AgendaBox'
}
</script>

<style>
#agenda-box {
    width: 300px;
    background-color: white;
    height: 100%;
}
#agenda-box-1 {
    width: 85px;
}
#agenda-sm {
    width: 80%;
    height: auto;
}
.status-circle {
    display: inline-block;
    width: 20px;
    height: 20px;
    border-radius: 50%;
    margin: 0 4px;
}
#status-full {
    background-color: var(--lightGrey);
}
#status-free {
    background-color: green;
}
</style>