import axios from 'axios';
import router from '../router/index.js';
import { validatePersonalInfo, sanitizeAndValidateEmail, validatePassword } from './userValidator.js';
import { API_URL } from '../utils/api';
import { getUser } from './userManager.js';
import { removeUserSession } from './sessionManager.js';

const baseUrlAccount = API_URL + 'account';

/**
 * Register new user.
 * 
 * @param {Object} registerForm - The register form with data input from user.
 */
export async function registerUser(registerForm) {
    const {
        processedSalutation,
        processedFirstName,
        processedLastName,
        processedPhone,
        salutationErr,
        firstNameErr,
        lastNameErr,
        phoneErr,
    } = validatePersonalInfo(registerForm.salutation, registerForm.firstName, registerForm.lastName, registerForm.phone);
    const { processedEmail, emailErr } = sanitizeAndValidateEmail(registerForm.email);
    const { processedPassword, passwordErr, confirmPasswordErr } = validatePassword(registerForm.password, registerForm.confirmPassword);

    const errors = {
        salutationErr,
        firstNameErr,
        lastNameErr,
        emailErr,
        phoneErr,
        passwordErr,
        confirmPasswordErr,
        genericErr: '',
    };

    if (
        salutationErr.length === 0 &&
        firstNameErr.length === 0 &&
        lastNameErr.length === 0 &&
        phoneErr.length === 0 &&
        emailErr.length === 0 &&
        passwordErr.length === 0 &&
        confirmPasswordErr.length === 0
    ) {
        const registerModel = {
            salutation: processedSalutation,
            firstName: processedFirstName,
            lastName: processedLastName,
            email: processedEmail,
            phone: processedPhone,
            password: processedPassword,
        };

        try {
            const response = await axios.post(baseUrlAccount + '/register', registerModel);

            if (response.status === 200) {
                router.push('/login');
            } else {
                console.error('Error during register. Status:', response.status);
                errors.genericErr = '❌ An error occurred. Please try again later.';
                return errors;
            }
        } catch (error) {
            console.error('User registration failed. ', error);

            if (error.response && error.response.status === 400) {
                const { errors } = error.response.data;
        
                if (errors && errors.length > 0) {
                    errors.forEach(error => {
                        switch (error.code) {
                            case 'DuplicateUserName':
                                errors.emailErr = '❌ Er bestaat al een gebruiker met dit e-mailadres.';
                                break;
                            // Add more cases as needed for other error codes
                        }
                    });
                    return errors;
                }
            } else {
                errors.genericErr = '❌ Er is iets fout gegaan tijdens de registratie. Probeer het later opnieuw.';
            }
        }
    }

    return errors;
}

/**
 * Login user.
 * 
 * @param {String} email - The user login.
 * @param {String} password - The user password.
 */
export async function loginUser(email, password) {
    // Validate email and password
    const { processedEmail, emailErr } = sanitizeAndValidateEmail(email);
    const { processedPassword, passwordErr } = validatePassword(password);

    // Initialize errors object
    const errors = {
        emailErr,
        passwordErr,
        genericErr: ''
    };

    // Check for validation errors
    if (emailErr.length === 0 && passwordErr.length === 0) {
        // Make a POST request to your backend login API
        const loginModel = {
            Email: processedEmail,
            Password: processedPassword,
        };

        try {
            const response = await axios.post(baseUrlAccount + "/login", loginModel);

            // Check if the request was successful
            if (response.status === 200) {
                try {
                    const user = await getUser(processedEmail);
                    const userData = { userId: user.id, userEmail: user.email, userRole: user.role };
                    sessionStorage.setItem('userData', JSON.stringify(userData));

                    // Redirect the user based on their role
                    if (user.role === "ADMIN" || user.role === "EMPLOYEE") {
                        router.push('/overview');
                    } else {
                        router.push('/profile');
                    }
                } catch (sessionStorageError) {
                    console.error('Error storing user data in browser session: ', sessionStorageError);
                    errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.';
                    return errors;
                }
            } else {
                console.error('Error during login. Status:', response.status);
                errors.genericErr = '❌ An error occurred. Please try again later.';
                return errors;
            }
        } catch (error) {
            if (error.response && error.response.status === 400) {
                // Handle specific error for invalid credentials
                errors.passwordErr = '❌ De combinatie van e-mailadres en wachtwoord is niet geldig.';
            } else {
                // Handle other errors
                errors.genericErr = '❌ An error occurred during login. Please try again later.';
            }

            return errors;
        }
    } else {
        // Handle validation errors
        return errors;
    }
}

/**
 * Logout user.
 * 
 */
export async function logoutUser() {
    console.log('Before logout request');
    try {
        const response = await axios.post(baseUrlAccount + "/logout");
        console.log('After logout request');
        // ... rest of your code
        if (response.status === 200) {
            removeUserSession();

            router.push('/login');
        } else {
            console.error('Error during logout. Status:', response.status);
        }
    } catch (error) {
        console.error('Error during logout:', error);
    }
}