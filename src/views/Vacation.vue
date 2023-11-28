<template>
    <TopNavigation />
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1 class="text-lg text-left">
                    Vakantie inplannen
                </h1>
            </div>
        </div>
    </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'

export default {
    name: 'Vacation',
    components: {
        TopNavigation,
    }
}
</script>