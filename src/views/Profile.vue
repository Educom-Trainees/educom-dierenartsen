<template>
    <TopNavigation />
        <Sidebar />
        <div class="content">
            <h2>Responsive Sidebar Example</h2>
            <p>This example use media queries to transform the sidebar to a top navigation bar when the screen size is 700px or less.</p>
            <p>We have also added a media query for screens that are 400px or less, which will vertically stack and center the navigation links.</p>
            <h3>Resize the browser window to see the effect.</h3>
        </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'
import Sidebar from '../components/Sidebar.vue'

export default {
    name: 'Profile',
    components: {
        TopNavigation,
        Sidebar
    },
    data() {
        return {
            showing: 'PersonalInfo',
        }
    },
    methods: {
        show(profileContent) {
            this.showing = profileContent
        },
    }
}
</script>

<style>
</style>