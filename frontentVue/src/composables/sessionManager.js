/**
 * Check if the user has permission for a specific action.
 *
 * @param {array} requiredRoles - The type of permission to check.
 * @returns {boolean} Returns true if the user has the required permission, otherwise false.
 */
export function hasRequiredRole(requiredRoles) {

    const userData = getUserDataFromSession()

    if (!isLoggedIn()) {
        return false
    } 
    else {
        const hasRequiredRole = requiredRoles.includes(userData.userRole)

        if (!hasRequiredRole) {
            return false
        } else {
            return true
        }
    }
}

/**
 * Check if the user is logged in.
 * 
 * @returns {boolean} Returns true if the user is logged in, otherwise false.
 */
export function isLoggedIn() {

    const userData = getUserDataFromSession()

    return userData !== null
}

/**
 * Get the user data from browser session.
 * 
 * @returns {Object} Returns user data if the user is logged in, otherwise null.
 */
export function getUserDataFromSession() {
    return JSON.parse(sessionStorage.getItem('userData'))
}

/**
 * Remove the user data from browser session.
 */
export function logoutUser() {
    sessionStorage.removeItem('userData')
}