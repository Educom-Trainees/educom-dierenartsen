<template>
    <div class="topnav">
        <router-link to="/">HappyPaw</router-link> 
        <router-link to="/contact">Contact</router-link> 
        <router-link to="/afspraak-maken">Afspraak</router-link>
    </div>
</template>

<style>
    .topnav {
        background-color: #ffbd54;
        overflow: hidden;
    }

    .topnav a {
        float: left;
        color: #ffffff;
        text-align: center;
        padding: 14px 16px;
        text-decoration: none;
        font-size: 17px;
    }

    .topnav a:hover {
        background-color: #ddd;
        color: black;
    }
</style>