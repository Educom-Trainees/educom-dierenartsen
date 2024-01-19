// Import necessary modules and services
import axios from 'axios';
import router from '../router/index.js';
import { sanitizeAndValidateEmail, validatePassword } from './userValidator.js';
import { API_URL } from '../utils/api';
import { getUser } from './userManager.js';

const baseUrlAccount = API_URL + 'account';

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
