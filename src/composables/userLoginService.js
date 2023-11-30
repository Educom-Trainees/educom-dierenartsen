import router from '../router/index.js'
import { USER_ROLES } from '../utils/userRoles.js'
import { sanitizeAndValidateEmail, validatePassword } from './userValidator.js'
import { getUser, authenticateUser } from './userManager.js'

/**
 * Login user.
 * 
 * @param {String} email - The user login.
 * @param {String} password - The user password.
 */
export async function loginUser(email, password) {

    const { processedEmail, emailErr } = sanitizeAndValidateEmail(email)
    const { processedPassword, passwordErr } = validatePassword(password)

    var errors = {
        'emailErr': emailErr, 
        'passwordErr': passwordErr,
        'genericErr': ''
    }

    if (emailErr.length === 0 && passwordErr.length === 0) {
        try {
            try {
                const userDataFromDatabase = await getUser(processedEmail)
                if (userDataFromDatabase === null) {
                    errors.emailErr = '❌ Er is geen gebruiker met dit e-mailadres.'
                    return errors
                }
                else {
                    const user = userDataFromDatabase
                    try {
                        const isAuthenticated = await authenticateUser(processedPassword, user.passwordHash)
                        if (isAuthenticated) {
                            console.log('User login successful.')
                            try {
                                const userData = { userId: user.id, userEmail: user.email, userRole: user.role }
                                sessionStorage.setItem('userData', JSON.stringify(userData))
                                try {
                                    if (user.role === USER_ROLES.ADMIN || user.role === USER_ROLES.EMPLOYEE) {
                                        router.push('/overview')
                                    }
                                    else {
                                        router.push('/profile')
                                    }
                                }
                                catch (routerError) {
                                    console.error('Error redirecting user: ', routerError)
                                    errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                                    return errors
                                }
                            }
                            catch (sessionStorageError) {
                                console.error('Error storing user data in browser session: ', sessionStorageError)
                                errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                                return errors
                            }
                        }
                        else {
                            errors.passwordErr = '❌ De combinatie van e-mailadres en wachtwoord is niet geldig.'
                            return errors
                        }
                    }
                    catch (authenticateUserError) {
                        console.error('Error logging in user: ', authenticateUserError)
                        errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                        return errors
                    }
                }
            }
            catch(getUserError) {
                console.error('Error logging in user: ', getUserError)
                errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                return errors
            }
        }
        catch (error) {
            console.error('User login failed. ', error)
            errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
            return errors
        }
    }
    else {
        return errors
    }
}