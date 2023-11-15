import axios from 'axios'
import bcrypt from 'bcrypt'

const saltRounds = 10
const baseUrlPostUser = 'http://localhost:3000/users'
const baseUrlGetUser = 'http://localhost:3000/users?email='

export function storeUser(email, password, role=0) {

    axios.post(baseUrlPostUser, {
        email: email,
        password: hashPassword(password),
        role: role,
    })
    .then(response => {
            console.log('Login successful: ', response.data)
            const token = response.data.token
            localStorage.setItem('token', token)
            this.$router.push('/')
          })
    .catch(error => {
        console.error('Login failed: ', error)
        throw new Error('Error storing user in database. ', error)
    })
}

export function getUser(userEmail) {
    const url = baseUrlGetUser + userEmail
    axios.get(url)
        .then(response => { 
            console.log('User found.')
            return response.data // Return user data
        })
        .catch(error => {
            if (error.response && error.response.status === 404) {
                console.log('User not found.')
                return null // Return null when the user is not found
              } 
              else {
                console.error('Error getting user from database. ', error)
                throw new Error('Error getting user from database. ', error)
              }
        })
}

function hashPassword(password) {
    bcrypt.hash(password, saltRounds, (err, hashedPassword) => {
        if (err) {
            console.error('Error hashing password. ', err)
            throw new Error('Error hashing password. ', err)
        } else {
            return hashedPassword
        }
    });
}

export function authenticateUser(receivedPasswordFromClient, hashedPasswordFromDatabase) {

    bcrypt.compare(receivedPasswordFromClient, hashedPasswordFromDatabase, (err, result) => {
        if (err) {
            console.error('Error comparing passwords. ', err)
            throw new Error('Error comparing passwords. ', err);
        } else if (result) {
            return true // Return true when passwords match
        } else {
            return false // Return false when passwords do not match
        }
    })
}