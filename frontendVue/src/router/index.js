import { createRouter, createWebHistory } from 'vue-router'
import { USER_ROLES } from '../utils/userRoles.js'
import Home from '../views/Home.vue'
import Contact from '../views/Contact.vue'
import Appointment from '../views/Appointment.vue'
import Register from '../views/Register.vue'
import Login from '../views/Login.vue'
import Result from '../views/Result.vue'
import Overview from '../views/Overview.vue'
import Profile from '../views/Profile.vue'
import ChangeAppointment from '../views/ChangeAppointment.vue'
import Vacation from '../views/Vacation.vue'
import CanceledAppointments from '../views/CanceledAppointments.vue'
import EmailTemplates from '../views/EmailTemplates.vue'

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
    path: '/result/:id',
    name: 'result',
    component: Result,
    props: true
  },
  {
    path: '/overview',
    name: 'overview',
    component: Overview,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.ADMIN, USER_ROLES.EMPLOYEE]
    }
  },
  {
    path: '/profile',
    name: 'profile',
    component: Profile,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.GUEST]
    }
  },
  {
    path: '/change-appointment/:id',
    name: 'change-appointment',
    component: ChangeAppointment,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.ADMIN, USER_ROLES.EMPLOYEE, USER_ROLES.GUEST]
    }
  },
  {
    path: '/vacation',
    name: 'vacation',
    component: Vacation,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.ADMIN]
    }
  },
  {
    path: '/canceled-appointments',
    name: 'canceled-appointments',
    component: CanceledAppointments,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.ADMIN]
    }
  },
  {
    path: '/email-templates',
    name: 'email-templates',
    component: EmailTemplates,
    meta: {
      requiresAuth: true,
      requiredRoles: [USER_ROLES.ADMIN]
    }
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from, next) => {

  if (to.meta.requiresAuth) {

    const userData = JSON.parse(sessionStorage.getItem('userData'))

    if (userData === null) {
      next('/login')
    }
    else {
      const hasRequiredRole = to.meta.requiredRoles.includes(userData.userRole)

      if (!hasRequiredRole) {
        next('/')
      } else {
        next()
      }
    }
  }
  else {
    next()
  }
})

export default router
