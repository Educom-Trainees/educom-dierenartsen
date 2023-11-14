<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1 class="text-lg text-left">Inloggen</h1>
            </div>
        </div>
        <div class="row justify-content-center align-items-center">
            <div class="col-md-4 col-10">
                <div class="w-100 d-flex justify-content-center">
                    <div class="happy-login d-flex justify-content-center align-items-center">
                        <i class="fa fa-paw login-paw" aria-hidden="true"></i>
                    </div>
                </div>
                <form>
                    <div class="form-group">
                        <label for="LoginEmail">E-mailadres:</label>
                        <input type="email" class="form-control" id="LoginEmail" aria-describedby="emailHelp" placeholder="E-mailadres">
                    </div>
                    <div class="form-group">
                        <label for="LoginPassword">Wachtwoord:</label>
                        <input type="password" class="form-control" id="LoginPassword" placeholder="Wachtwoord">
                    </div>
                    <button type="submit" class="btn btn-primary login-btn">Inloggen</button>
                    </form>
            </div>
        </div>
    </div>
</template>

<style>
.happy-login {
    border-radius: 50%;
    min-height: 200px;
    min-width: 200px;
    background-color: var(--happyPaw2);
    border: none;
}
</style>