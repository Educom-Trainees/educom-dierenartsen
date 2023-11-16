/**
 * Check if the user has permission for a specific action.
 *
 * @param {array} requiredRoles - The type of permission to check.
 * @returns {boolean} Returns true if the user has the required permission, otherwise false.
 */
export function hasRequiredRole(requiredRoles) {

    const userData = JSON.parse(sessionStorage.getItem('userData'))

    if (!userData || !userData.userRole) {
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