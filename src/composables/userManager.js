import axios from 'axios'
import bcrypt from 'bcryptjs'

const baseUrlPostUser = 'http://localhost:3000/users'
const baseUrlGetUser = 'http://localhost:3000/users?email='
const saltRounds = 10

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