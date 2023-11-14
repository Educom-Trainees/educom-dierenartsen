<template>
  <div class="container">
    <div class="row">
        <div class="col-10 col-md-8">
            <h1 class="text-lg">Neem contact op met onze kliniek</h1>
            <h2 class="text-md mb-4">
              We vinden het belangrijk om bereikbaar te zijn voor onze klanten, 
              hieronder vind u de belangrijke informatie om ons te bereiken
            </h2>
          </div>
        </div>
        <div class="row">
          <div class="col-10 col-md-6">
            <address>
              <strong>Bezoek adres</strong> <small>(op afspraak)</small><br>
              Fazantenplein 3<br>
              3704 EV<br>
              Zeist<br>
            </address>
            <address>
              <strong>Telefoonnummer</strong> <small>(u kunt hier ook een afspraak inplannen)</small><br>
              030-39-81-984
            </address>
            <address>
              <strong>Noodnummer</strong> <small>(alleen voor spoedgevallen!)</small><br>
              06-84-49-28-33
            </address>
            <address>
              <strong>E-mail</strong><br>
              <a href="mailto:#">info@happypaws.nl</a>
            </address>
        </div>
        <div class="col-10 col-md-6">
          <img src="../assets/visit_us_cats.jpg" class="d-block w-100 h-100" alt="">
        </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Home',
  }
</script>

<style>
  .container * {
    text-align: left;
  }
  .container {
    margin-top: 20px;
    margin-bottom: 20px;
  }
</style>