import { validatePersonalInfo, sanitizeAndValidateEmail } from './userValidator.js'
import { getUserById, putUser } from './userManager.js'
import { getUserDataFromSession } from '../composables/sessionManager.js'


/**
 * change a user.
 * 
 * @param {Object} changeForm - The change form with data input from user.
 */
export async function changeUser(infoForm) {
    console.log('in de changuser')
    
    const { 
        processedSalutation, processedFirstName, processedLastName, processedPhone,
        salutationErr, firstNameErr, lastNameErr, phoneErr
    } = validatePersonalInfo(infoForm.salutation, infoForm.firstName, infoForm.lastName, infoForm.phone)
    const { processedEmail, emailErr } = sanitizeAndValidateEmail(infoForm.email)

    var errors = {
        'salutationErr': salutationErr, 
        'firstNameErr': firstNameErr, 
        'lastNameErr': lastNameErr, 
        'emailErr': emailErr, 
        'phoneErr': phoneErr, 
        'genericErr': ''
    }

    if (salutationErr.length === 0 && firstNameErr.length === 0 && lastNameErr.length === 0 && phoneErr.length === 0
        && emailErr.length === 0) {
        try {
            try {
                const user = getUserDataFromSession()
                const userDataFromDatabase = await getUserById(user.userId)
                if (userDataFromDatabase !== null) {
                    const changedUser = {
                        "id": infoForm.id,
                        "salutation": processedSalutation,
                        "firstName": processedFirstName,
                        "lastName": processedLastName,
                        "email": processedEmail,
                        "phone": processedPhone
                    }
                    try {
                        const userStored = await putUser(changedUser)
                    }
                    catch(storeUserError) {
                        console.error('Error changing user: ', storeUserError)
                        errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
                        return errors
                    }
                }
                else {
                    errors.emailErr = '❌ Er bestaat geen gebruiker met dit e-mailadres.'
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
            console.error('User changing failed. ', error)
            errors.genericErr = '❌ Er is iets fout gegaan. Probeer het later opnieuw.'
            return errors
        }
    }
    else {
        return errors
    }
}

/**
 * add a pet to a user.
 * 
 * @param {Object} petForm - The pet form with data input from user.
 */
export async function addPet(type, name) {

    console.log('addpet')
    const user = getUserDataFromSession()
    const userDataFromDatabase = await getUserById(user.userId)
    if (userDataFromDatabase !== null) {
        const changedUser = {
            "id": userDataFromDatabase[0].id,
            "pets": [{
                "type": type,
                "name": name
            }]
        }
        try {
            const userStored = await putUser(changedUser)
        }
        catch(Error) {
            console.log('het is niet gelukt om een huisdier erin te zetten')
        }
    }
    else {
        console.log('geen gebruiker gevonden')
    }
}