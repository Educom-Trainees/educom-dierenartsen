export function sanitizeAndValidateEmail(email) {
    const emailErr = ''
     // Trim leading and trailing spaces
    const trimmedEmail = email.trim()
    // Check for empty email
    if (trimmedEmail.length === 0) {
        emailErr = '❌ E-mail mag niet leeg zijn.'
        return { trimmedEmail, emailErr }
    }
    // Check email length
    if (trimmedEmail.length < 15) {
        emailErr = '❌ E-mail is te kort.'
        return { trimmedEmail, emailErr }
    }
    if (trimmedEmail.length > 30) {
        emailErr = '❌ E-mail is te lang.'
        return { trimmedEmail, emailErr }
    }
    // Basic email format validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const isValidFormat = emailRegex.test(trimmedEmail);

    if (!isValidFormat) {
        emailErr = '❌ Ongeldige email formaat.'
        return { trimmedEmail, emailErr }
    }
    return { trimmedEmail, emailErr }
}

export function validatePassword(password, confirmPassword=null) {
    const passwordErr = ''
    const confirmPasswordErr = ''
    // Trim leading and trailing spaces
    const trimmedPassword = password.trim()
    // 
    if (confirmPassword === null) {
        if (trimmedPassword.length === 0) {
            passwordErr = '❌ Wachtwoord mag niet leeg zijn'
            return { trimmedPassword, passwordErr}
        }
    }
    else {
        const trimmedConfirmPassword = confirmPassword.trim()
        // Check for empty passwords
        if (trimmedPassword.length === 0) {
            passwordErr = '❌ Wachtwoord mag niet leeg zijn'
            return { trimmedPassword, passwordErr, confirmPasswordErr }
        }
        if (trimmedConfirmPassword.length === 0) {
            confirmPasswordErr = '❌ Wachtwoord en bevestig wachtwoord mogen niet leeg zijn'
            return { trimmedPassword, passwordErr, confirmPasswordErr }
        }
        // Check if passwords match
        if (trimmedPassword !== trimmedConfirmPassword) {
            confirmPasswordErr = '❌ Wachtwoorden komen niet overeen'
            return { trimmedPassword, passwordErr, confirmPasswordErr }
        }
    }
    // Check password complexity 
    const isLengthValid = trimmedPassword.length >= 8;
    const hasUpperCase = /[A-Z]/.test(trimmedPassword);
    const hasLowerCase = /[a-z]/.test(trimmedPassword);
    const hasNumber = /\d/.test(trimmedPassword);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(trimmedPassword);

    if (!(isLengthValid && hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar)) {
        passwordErr = '❌ Ongeldig wachtwoord formaat'
        if (confirmPassword === null) {
            return { trimmedPassword, passwordErr }
        }
        else { 
            return { trimmedPassword, passwordErr, confirmPasswordErr }
        }
    }
    if (confirmPassword === null) {
        return { trimmedPassword, passwordErr }
    }
    else { 
        return { trimmedPassword, passwordErr, confirmPasswordErr }
    }
}