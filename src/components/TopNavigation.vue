<template>
    <div class="topnav">
        <router-link to="/">
            <i class="fa fa-paw paw-icon" aria-hidden="true"></i>
            <span class="hp">HappyPaw</span>
        </router-link> 
        <router-link to="/contact">Contact</router-link> 
        <router-link to="/afspraak-maken">Afspraak</router-link>
        <div class="dropdown">
            <div class="dot">
                <i class="fa fa-user user-icon" aria-hidden="true"></i>
            </div>
            <div class="dropdown-content">
                <ul class="user-nav">
                    <li class="nav-item">
                        <router-link to="/register">Registreren</router-link> 
                    </li>
                    <li class="nav-item">
                        <router-link to="/login">Inloggen</router-link> 
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<style>
    .topnav {
        background-color: #ffbd54;
        overflow: hidden;
        max-height: 72px;
    }
    .topnav a {
        float: left;
        color: #ffffff;
        text-align: center;
        padding: 20px 16px;
        text-decoration: none;
        font-size: 22px;
        font-weight: 800;
        min-height: 33px;
    }
    .topnav a:hover {
        background-color: #ffde59;
        color: black;
    }
    .topnav .paw-icon {
        color: #ff914d;
        padding: 4px;
        font-size: 1.5rem;
    }
    .topnav .dropdown {
        float: right;
        overflow: hidden;
        max-width: 100px;
        padding: 4px;
    }
    .topnav .dropdown .dot {
        height: 65px;
        width: 65px;
        background-color: #ffde59;
        border-radius: 50%;
        display: inline-block;
        margin-right: 4px;
    }
    .topnav .user-icon {
        color: #ffffff;
        font-size: 3.5rem;
        margin: auto;
        width: 60%;
        padding: 4px;
    }
    .topnav .dropdown-content {
        display: none;
        position: absolute;
        right: 0;
        background-color: #ffbd54;
        min-width: 200px;
        z-index: 1;
        margin-top: 4px;
    }
    .topnav .dropdown ul {
        padding: 0;
        margin: 0;
    }
    .topnav .dropdown li {
        width: 100%;
    }
    .topnav .dropdown-content a {
        color: #ffffff;
        text-decoration: none;
        display: block;
        width: 100%;
    }
    .topnav .dropdown-content a:hover {
        background-color: #ffde59;
        color: black;
    }
    .topnav .dropdown:hover .dropdown-content {
        display: block;
    }
    .topnav .user-nav {
        list-style: none;
    }
</style>