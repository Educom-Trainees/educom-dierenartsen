import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Contact from '../views/Contact.vue'
import Appointment from '../views/Appointment.vue'
import Register from '../views/Register.vue'
import Login from '../views/Login.vue'
import Result from '../views/Result.vue'
import Overview from '../views/Overview.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/contact',
    name: 'contact',
    component: Contact
  },
  {
    path: '/appointment',
    name: 'appointment',
    component: Appointment
  },
  {
    path: '/register',
    name: 'register',
    component: Register
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/result',
    name: 'result',
    component: Result
  },
  {
    path: '/overview',
    name: 'overview',
    component: Overview
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
