export function sanitizeAndValidateEmail(email) {
    var emailErr = ''
     // Trim leading and trailing spaces
    const processedEmail = email.trim()
    // Check for empty email
    if (processedEmail.length === 0) {
        emailErr = '❌ E-mail mag niet leeg zijn.'
        return { processedEmail, emailErr }
    }
    // Check email length
    if (processedEmail.length < 15) {
        emailErr = '❌ E-mail is te kort.'
        return { processedEmail, emailErr }
    }
    if (processedEmail.length > 30) {
        emailErr = '❌ E-mail is te lang.'
        return { processedEmail, emailErr }
    }
    // Basic email format validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const isValidFormat = emailRegex.test(processedEmail);

    if (!isValidFormat) {
        emailErr = '❌ Ongeldige email formaat.'
        return { processedEmail, emailErr }
    }
    return { processedEmail, emailErr }
}

export function validatePassword(password, confirmPassword=null) {
    var passwordErr = ''
    var confirmPasswordErr = ''
    // Trim leading and trailing spaces
    const processedPassword = password.trim()
    // 
    if (confirmPassword === null) {
        if (processedPassword.length === 0) {
            passwordErr = '❌ Wachtwoord mag niet leeg zijn.'
            return { processedPassword, passwordErr}
        }
    }
    else {
        const processedConfirmPassword = confirmPassword.trim()
        // Check for empty passwords
        if (processedPassword.length === 0) {
            passwordErr = '❌ Wachtwoord mag niet leeg zijn'
            return { processedPassword, passwordErr, confirmPasswordErr }
        }
        if (processedConfirmPassword.length === 0) {
            confirmPasswordErr = '❌ Bevestig wachtwoord mag niet leeg zijn.'
            return { processedPassword, passwordErr, confirmPasswordErr }
        }
        // Check if passwords match
        if (processedPassword !== processedConfirmPassword) {
            confirmPasswordErr = '❌ Wachtwoorden komen niet overeen.'
            return { processedPassword, passwordErr, confirmPasswordErr }
        }
    }
    // Check password complexity 
    const isLengthValid = processedPassword.length >= 8;
    const hasUpperCase = /[A-Z]/.test(processedPassword);
    const hasLowerCase = /[a-z]/.test(processedPassword);
    const hasNumber = /\d/.test(processedPassword);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(processedPassword);

    if (!(isLengthValid && hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar)) {
        passwordErr = '❌ Ongeldig wachtwoord formaat.'
        if (confirmPassword === null) {
            return { processedPassword, passwordErr }
        }
        else { 
            return { processedPassword, passwordErr, confirmPasswordErr }
        }
    }
    if (confirmPassword === null) {
        return { processedPassword, passwordErr }
    }
    else { 
        return { processedPassword, passwordErr, confirmPasswordErr }
    }
}

export function validatePersonalInfo(salutation,firstName,lastName,phone) {
    var salutationErr = ''
    var firstNameErr = ''
    var lastNameErr = ''
    var phoneErr = ''

    const processedSalutation = salutation.trim()
    if (processedSalutation.length === 0) {
        salutationErr = '❌ Kies een aanhef.'
    }
    const processedFirstName = firstName.trim()
    if (processedFirstName.length === 0) {
        firstNameErr = '❌ Voornaam mag niet leeg zijn.'
    }
    const processedLastName = lastName.trim()
    if (processedLastName.length === 0) {
        lastNameErr = '❌ Achternaam mag niet leeg zijn.'
    }
    const processedPhone = phone.trim()
    if (processedPhone.length === 0) {
        phoneErr = '❌ Telefoonnummer mag niet leeg zijn.'
    }
    return { 
        processedSalutation, processedFirstName, processedLastName, processedPhone,
        salutationErr, firstNameErr, lastNameErr, phoneErr
    }
}