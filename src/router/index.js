import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/Home.vue'
import ContactView from '../views/Contact.vue'
import AfspraakMakenView from '../views/AfspraakMaken.vue'
import RegisterView from '../views/Register.vue'
import LoginView from '../views/Login.vue'
import HomeView from '../views/HomeView.vue'
import PlanningView from '../views/PlanningView'
import ResultView from '../views/ResultView'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/contact',
    name: 'contact',
    component: ContactView
  },
  {
    path: '/afspraak-maken',
    name: 'afspraak-maken',
    component: AfspraakMakenView
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterView
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView
  },
  {
    path: '/result',
    name: 'result',
    component: ResultView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
