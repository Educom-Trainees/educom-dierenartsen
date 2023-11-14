<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1 class="text-lg text-left">Inloggen</h1>
            </div>
        </div>
        <div class="row justify-content-center align-items-center login-row">
            <div class="col-md-3 col-10 login-area">
                <div class="w-100 d-flex flex-column align-items-center">
                    <div class="happy-login d-flex justify-content-center align-items-center">
                        <i id="login-paw" class="fa fa-paw" aria-hidden="true"></i>
                    </div>
                    <div>
                        <span id="login-brand">HappyPaw</span>
                    </div>
                </div>
                <form id="login-form" class="d-flex flex-column align-items-center mt-4">
                    <div class="form-group">
                        <label for="LoginEmail">E-mailadres:</label>
                        <input type="email" class="form-control" id="LoginEmail" aria-describedby="emailHelp" placeholder="E-mailadres">
                    </div>
                    <div class="form-group">
                        <label for="LoginPassword">Wachtwoord:</label>
                        <input type="password" class="form-control" id="LoginPassword" placeholder="Wachtwoord">
                    </div>
                    <button type="submit" class="btn submit-btn mt-5">Inloggen</button>
                    </form>
            </div>
        </div>
    </div>
</template>

<style>
.login-row {
    min-height: 35vw;
}
.login-area {
    border: 8px solid var(--happyPaw1);
    padding: 24px;
}
.happy-login {
    border-radius: 50%;
    min-height: 200px;
    min-width: 200px;
    background-color: var(--happyPaw2);
    border: none;
}
#login-paw {
    font-size: 8rem;
    color: white;
}
@media (min-width: 375px) {
    .happy-login {
        min-height: 100px;
        min-width: 100px;
    }
    #login-paw {
        font-size: 4rem;
    }
    #login-form .form-group {
        width: 90%;
}
}
@media (min-width: 768px) {
    .happy-login {
        min-height: 200px;
        min-width: 200px;
    }
    #login-paw {
        font-size: 8rem;
    }
    #login-form .form-group {
        width: 80%;
}
}
#login-brand {
    font-size: 28px;
    font-weight: 600;
    color: var(--happyPaw4);
}
#login-form .form-group * {
    margin-left: 0;
}
.submit-btn {
    width: 80%;
    text-align: center !important;
    background-color: var(--happyPaw2);
    font-weight: 600;
    border: none;
    color: white;
}
.submit-btn:hover {
    background-color: var(--happyPaw1);
    color: white;
}
</style>