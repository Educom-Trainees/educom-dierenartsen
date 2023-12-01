import { USER_ROLES } from '../utils/userRoles.js'
import { validatePersonalInfo, sanitizeAndValidateEmail, validatePassword } from './userValidator.js'
import { getUser, storeUser, hashPassword } from './userManager.js'
import { loginUser } from './userLoginService.js'

/**
 * Register new user.
 * 
 * @param {Object} registerForm - The register form with data input from user.
 */
export async function registerUser(registerForm) {
    
    const { 
        processedSalutation, processedFirstName, processedLastName, processedPhone,
        salutationErr, firstNameErr, lastNameErr, phoneErr
    } = validatePersonalInfo(registerForm.salutation, registerForm.firstName, registerForm.lastName, registerForm.phone)
    const { processedEmail, emailErr } = sanitizeAndValidateEmail(registerForm.email)
    const { processedPassword, passwordErr, confirmPasswordErr } = validatePassword(registerForm.password, registerForm.confirmPassword)

    var errors = {
        'salutationErr': salutationErr, 
        'firstNameErr': firstNameErr, 
        'lastNameErr': lastNameErr, 
        'emailErr': emailErr, 
        'phoneErr': phoneErr, 
        'passwordErr': passwordErr,
        'confirmPasswordErr': confirmPasswordErr,
        'genericErr': ''
    }

    if (salutationErr.length === 0 && firstNameErr.length === 0 && lastNameErr.length === 0 && phoneErr.length === 0
        && emailErr.length === 0 && passwordErr.length === 0 && confirmPasswordErr.length === 0) {
        try {
            try {
                const userDataFromDatabase = await getUser(processedEmail)
                if (userDataFromDatabase === null) {
                    try {
                        const hashedPassword = await hashPassword(processedPassword)
                        const newUser = {
                            "salutation": processedSalutation,
                            "firstName": processedFirstName,
                            "lastName": processedLastName,
                            "email": processedEmail,
                            "phone": processedPhone,
                            "passwordHash": hashedPassword,
                            "role": USER_ROLES.GUEST
                        }
                        try {
                            const userStored = await storeUser(newUser)
                            if (userStored) {
                                // console.log('User registration successful.')
                                try {
                                    const result = await loginUser(processedEmail, processedPassword)
                                }
                                catch (registerLoginError) {
                                    console.error('Error logingin in user after registration:  ', registerLoginError)
                                    errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                                    return errors
                                }
                            }
                        }
                        catch(storeUserError) {
                            console.error('Error registering user: ', storeUserError)
                            errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                            return errors
                        }
                    }
                    catch(hashError) {
                        console.error('Error registering user: ', hashError)
                        errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                        return errors
                    }
                }
                else {
                    errors.emailErr = '❌ Er bestaat al een gebruiker met dit e-mailadres.'
                    return errors
                }
            }
            catch (getUserError) {
                console.error('Error registering user: ', getUserError)
                errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                return errors
            }
        }
        catch(error) {
            console.error('User registration failed. ', error)
            errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
            return errors
        }
    }
    else {
        return errors
    }
}