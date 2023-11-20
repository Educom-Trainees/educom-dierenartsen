<template>
    <div class="sidebar">
        <div v-for="(item, index) in items" :key="index" @click="activate(index)" :class="{ 'active': selectedIndex === index }">
          {{ item }}
        </div>
      </div>
</template>

<script>
export default {
    name: 'Sidebar',
    data() {
        return {
            showing: 'PersonalInfo',
            items: ['Mijn Gegevens', 'Mijn Huisdieren', 'Mijn Afspraken'],
            selectedIndex: 0,
        }
    },
    methods: {
        show(profileContent) {
            this.showing = profileContent
        },
        activate(index) {
            this.selectedIndex = index
        }
    }
}
</script>

<style>
.sidebar {
    margin: 0;
    padding: 0;
    width: 250px;
    background-color: var(--happyPaw3);
    position: fixed;
    height: 100%;
    overflow: auto;
}

.sidebar div {
    display: block;
    color: white;
    padding: 16px;
    text-decoration: none;
    font-size: 24px;
}
.sidebar div:hover {
    cursor: pointer;
}
.sidebar div.active {
    background-color: var(--happyPaw2);
}

div.content {
    margin-left: 250px;
}

@media (max-width: 810px) {
    .sidebar {
        width: 100%;
        height: auto;
        position: relative;
    }
    .sidebar div {
        display: block;
        text-align: center;
        cursor: pointer;
    }
    div.content {
        margin-left: 0;
    }
}
</style>