import axios from 'axios'
import bcrypt from 'bcryptjs'

const baseUrlPostUser = 'http://localhost:3000/users'
const baseUrlGetUser = 'http://localhost:3000/users?email='
const baseUrlGetUserById = 'http://localhost:3000/users/'
const saltRounds = 10

/**
 * Store new user in database.
 * 
 * @param {Object} newUser - The new user
 * @returns Returns true if user was stored successfully.
 */
export async function storeUser(newUser) {
    try {
        const response = await axios.post(baseUrlPostUser, newUser)
        console.log('User storage successful.')
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
        const response = await axios.patch(
            'http://localhost:3000/users/' + newUser.id, 
            newUser)
        console.log('User change successful.')
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
    const url = baseUrlGetUser + userEmail
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            console.log('User not found.')
            return null
        } else {
            console.log('User found.')
            return response.data
        }
    }
    catch(error) {
        console.error('Error getting user from database.')
        throw error
    }
}

/**
 * Get user information from database.
 * 
 * @param {String} userid - The user id.
 * @returns Returns user object if user found, otherwise null.
 */
export async function getUserById(userid) {
    const url = baseUrlGetUserById + userid
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            console.log('User not found.')
            return null
        } else {
            console.log('User found.')
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