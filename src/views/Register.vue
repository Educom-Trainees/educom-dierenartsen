<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1 class="text-lg text-left">Registreren</h1>
            </div>
        </div>
        <div class="row justify-content-center align-items-center register-row mb-4">
            <div class="col-sm-3 col-md-5 col-10 register-area">
                <div class="w-100 d-flex flex-column align-items-center">
                    <div class="happy-register d-flex justify-content-center align-items-center">
                        <i id="register-paw" class="fa fa-paw" aria-hidden="true"></i>
                    </div>
                    <div>
                        <span id="register-brand">HappyPaw</span>
                    </div>
                </div>
                <form @submit.prevent="registerUser" id="register-form" class="d-flex flex-column align-items-center mt-4">
                    <div v-if="errors.genericErr" class="error">{{ errors.genericErr }}</div>
                    <div class="form-group">
                        <label for="RegisterEmail">E-mailadres:</label>
                        <input v-model="registerForm.email" type="email" class="form-control" id="RegisterEmail" aria-describedby="emailHelp" placeholder="E-mailadres">
                        <div v-if="errors.emailErr" class="error">{{ errors.emailErr }}</div>
                    </div>
                    <div class="form-group">
                        <label for="RegisterPassword">Wachtwoord:</label>
                        <input v-model="registerForm.password" type="password" class="form-control" id="RegisterPassword" placeholder="Wachtwoord">
                        <div v-if="errors.passwordErr" class="error">{{ errors.passwordErr }}</div>
                    </div>
                    <div class="form-group">
                        <label for="RegisterConfirmPassword">Bevestig Wachtwoord:</label>
                        <input v-model="registerForm.confirmPassword" type="password" class="form-control" id="RegisterConfirmPassword" placeholder="Bevestig Wachtwoord">
                        <div v-if="errors.confirmPasswordErr" class="error">{{ errors.confirmPasswordErr }}</div>
                    </div>
                    <button type="submit" class="btn submit-btn mt-5">Registreren</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import router from '../router/index.js'
import { USER_ROLES } from '../utils/userRoles.js'
import { sanitizeAndValidateEmail, validatePassword } from '../composables/userValidator.js'
import { getUser, storeUser, hashPassword } from '../composables/userManager.js'

export default {
    name: 'Register',
    data() {
        return {
            registerForm: {
                'email': '',
                'password': '',
                'confirmPassword': '',
            },
            errors: {
                'genericErr': undefined,
                'emailErr': undefined,
                'passwordErr': undefined,
                'confirmPasswordErr': undefined,
            },
        }
    },
    methods: {
        async registerUser() {
            const email = this.registerForm.email
            const password = this.registerForm.password
            const confirmPassword = this.registerForm.confirmPassword

            const { processedEmail, emailErr } = sanitizeAndValidateEmail(email)
            const { processedPassword, passwordErr, confirmPasswordErr } = validatePassword(password, confirmPassword)

            if (emailErr.length === 0 && passwordErr.length === 0 && confirmPasswordErr.length === 0) {
                try {
                    try {
                        const userDataFromDatabase = await getUser(processedEmail)
                        if (userDataFromDatabase === null) {
                            try {
                                const hashedPassword = await hashPassword(processedPassword)
                                const newUser = {
                                    "email": processedEmail,
                                    "passwordHash": hashedPassword,
                                    "role": USER_ROLES.GUEST
                                }
                                try {
                                    const userStored = await storeUser(newUser)
                                    if (userStored) {
                                        console.log('User registration successful.')
                                        try {
                                            router.push('/login')
                                        }
                                        catch (routerError) {
                                            console.error('Error redirecting user:  ', routerError)
                                            this.errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                                        }
                                    }
                                }
                                catch(storeUserError) {
                                    console.error('Error registering user: ', storeUserError)
                                    this.errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                                }
                            }
                            catch(hashError) {
                                console.error('Error registering user: ', hashError)
                                this.errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                            }
                        }
                        else {
                            this.errors.emailErr = '❌ Er bestaat al een gebruiker met dit e-mailadres.'
                        }
                    }
                    catch (getUserError) {
                        console.error('Error registering user: ', getUserError)
                        this.errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                    }
                }
                catch(error) {
                    console.error('User registration failed. ', error)
                    this.errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                }
            }
            else {
                this.errors.emailErr = emailErr
                this.errors.passwordErr = passwordErr
                this.errors.confirmPasswordErr = confirmPasswordErr
            }
        },
    },
}
</script>

<style>
.register-row {
    min-height: 35vw;
}
.register-area {
    border: 8px solid var(--happyPaw1);
    padding: 24px;
}
.happy-register {
    border-radius: 50%;
    min-height: 200px;
    min-width: 200px;
    background-color: var(--happyPaw2);
    border: none;
}
#register-paw {
    font-size: 8rem;
    color: white;
}
@media (min-width: 375px) {
    .happy-register {
        min-height: 100px;
        min-width: 100px;
    }
    #register-paw {
        font-size: 4rem;
    }
    #register-form .form-group {
        width: 90%;
}
}
@media (min-width: 768px) {
    .happy-register {
        min-height: 200px;
        min-width: 200px;
    }
    #register-paw {
        font-size: 8rem;
    }
    #register-form .form-group {
        width: 80%;
}
}
#register-brand {
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