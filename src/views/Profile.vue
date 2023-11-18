<template>
    <TopNavigation />
    <div class="container-fluid">
        <div class="row">
            <div class="col-3">
                sidenav
            </div>
            <div class="col-9">
                <h1>Profile</h1>
            </div>
        </div>
    </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'

export default {
    name: 'Profile',
    components: {
        TopNavigation
    }
}
</script>