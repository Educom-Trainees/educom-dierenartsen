import axios from 'axios'
import { API_URL } from '../utils/api'

const baseUrlEmailTemplates = API_URL + 'email-templates'

/**
 * Get email templates from database.
 * 
 * @returns Returns an array of email templates if found, otherwise empty array.
 */
export async function getEmailTemplates() {
    try {
        const response = await axios.get(baseUrlEmailTemplates)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    } 
    catch (error) {
    console.error('Error getting appointments from database.')
    throw error
    }
}

export async function updateEmailTemplate(updatedEmailTemplate) {
    const url = baseUrlEmailTemplates + "/" + String(updatedEmailTemplate.id)
    try {
        const response = await axios.put(url, updatedEmailTemplate) 
    }
    catch (error) {
        throw error
    }
}