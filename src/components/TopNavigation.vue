<template>
    <nav class="navbar navbar-expand-lg navbar-light">
        <div class="navbar-nav h-40">
            <router-link to="/" class="navbar-brand">
                <i class="fa fa-paw brand-logo" aria-hidden="true">
                    <span class="brand-text">HappyPaw</span>
                </i>
            </router-link> 
        </div>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-bs-toggle="collapse" data-target="#navbarSupportedContent" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav w-100">
                <li class="nav-item">
                    <router-link  class="nav-link" to="/appointment">Afspraak</router-link>
                </li>
                <li v-if="showOverview" class="nav-item">
                    <router-link  class="nav-link" to="/overview">Overzicht</router-link>
                </li>
                <li v-if="showVacation" class="nav-item">
                    <router-link  class="nav-link" to="/vacation">Vakanties</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" to="/contact">Contact</router-link> 
                </li>
                <li class="nav-item w-100 d-flex justify-content-center justify-content-lg-end">
                    <div class="dropdown">
                        <button class="btn btn-secondary" type="button" id="dropdownMenuButton" data-toggle="dropdown" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fa fa-user" aria-hidden="true"></i>
                        </button>
                        <div v-if="!isLoggedIn" class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
                            <router-link class="dropdown-item" to="/register">Registreren</router-link> 
                            <router-link class="dropdown-item" to="/login">Inloggen</router-link> 
                        </div>
                        <div v-if="isLoggedIn" class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
                            <router-link class="dropdown-item" to="/profile">Profiel</router-link> 
                            <div @click="logout"><router-link class="dropdown-item" to="/">Uitloggen</router-link></div> 
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
import router from '../router/index.js'
import { USER_ROLES } from '../utils/userRoles.js'
import { hasRequiredRole, isLoggedIn, logoutUser } from '../composables/sessionManager.js'

export default {
    name: 'TopNavigation',
    data() {
        return {
            showOverview: false,
            isLoggedIn: false,
            showVacation: false,
        }
    }, 
    beforeMount() {
        this.showOverview = hasRequiredRole([USER_ROLES.ADMIN, USER_ROLES.EMPLOYEE])
        this.isLoggedIn = isLoggedIn()
        this.showVacation = hasRequiredRole([USER_ROLES.ADMIN])
    },
    methods: {
        logout() {
            logoutUser()
            // location.reload()
            router.go(0)
        }
    }
}
</script>

<style>
    .navbar {
        background-color: var(--happyPaw1);
    }
    .navbar .dropdown {
        margin-right: 12px;
        padding-right: 8px;
    }
    .navbar .dropdown button {
        border-radius: 50%;
        height: 50px;
        width: 50px;
        background-color: var(--happyPaw2);
        border: none;
    }
    .navbar .dropdown button i {
        font-size: 1.8rem;
    }
    .navbar .dropdown-menu {
        position: absolute;
        transform: translate3d(-92px, 0px, 0px);
    }
    .navbar .navbar-brand {
        margin: 0 12px;
    }
    .navbar .brand-logo {
        color: var(--happyPaw4);
        font-size: 2rem;
    }
    .navbar .brand-text {
        font-weight: 500;
    }
    .navbar .brand-text, .navbar .nav-link {
        color: var(--happyPaw3);
    }
    .navbar .navbar-brand, .navbar .brand-text {
        padding: 0;
        padding-left: 6px;
    }
    .navbar .h-40 {
        min-height: 40px;
    }
    .navbar .nav-link {
        font-weight: 400;
        font-size: 24px;
        height: 100%;
        display: inline-flex;
        align-items: center;
    }
</style>