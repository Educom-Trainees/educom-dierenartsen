import axios from 'axios'
import bcrypt from 'bcryptjs'
import { API_URL } from '../utils/api'

const baseUrlUser = API_URL + 'users'
const saltRounds = 10

/**
 * Store new user in database.
 * 
 * @param {Object} newUser - The new user
 * @returns Returns true if user was stored successfully.
 */
export async function storeUser(newUser) {
    try {
        const response = await axios.post(baseUrlUser, newUser)
        return true
    }
    catch(error) {
        console.error('User storage failed.')
        throw error
    }
}

/**
 * change a user in database.
 * 
 * @param {Object} newUser - The new user
 * @returns Returns true if user was changed successfully.
 */
export async function putUser(newUser) {
    try {
        const response = await axios.put(
            baseUrlUser + '/' + newUser.id, newUser)
        return true
    }
    catch(error) {
        console.error('User change failed.')
        throw error
    }
}

/**
 * Get user information from database.
 * 
 * @param {String} userEmail - The user email.
 * @returns Returns user object if user found, otherwise null.
 */
export async function getUser(userEmail) {
    const url = baseUrlUser + "?email=" + userEmail
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return null
        } else {
            return response.data[0]
        }
   } catch (error) {
        if (error.response && error.response.status === 404) {
            console.log('User not found.');
            return null;
        }

        console.error('Error getting user from the database.', error);
        throw error;
    }
}

/**
 * Get user information from database.
 * 
 * @param {String} userid - The user id.
 * @returns Returns user object if user found, otherwise null.
 */
export async function getUserById(userid) {
    const url = baseUrlUser + "/" + userid
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return null
        } else {
            return response.data
        }
    }
    catch(error) {
        console.error('Error getting user from database.')
        throw error
    }
}

/**
 * Create password hash.
 * 
 * @param {String} password - The password to create hash for.
 * @returns Returns hashed password.
 */
export async function hashPassword(password) {
    try {
        const hashedPassword = await bcrypt.hash(password, saltRounds)
        return hashedPassword
    }
    catch (error) {
        console.error('Error hashing password.')
        throw error
    }
}

/**
 * Authenticate user password at login against hashed password from database.
 * 
 * @param {String} receivedPasswordFromClient - The password from user.
 * @param {*} hashedPasswordFromDatabase - The hashed password from database.
 * @returns Returns true if password matches hash from database.
 */
export async function authenticateUser(receivedPasswordFromClient, hashedPasswordFromDatabase) {
    try {
        const match = await bcrypt.compare(receivedPasswordFromClient, hashedPasswordFromDatabase)
        return match
    }
    catch (error) {
        console.error('Error comparing passwords.')
        throw error
    }
}