import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PlanningView from '../views/PlanningView.vue'
import ContactView from '../views/ContactView.vue'
import AfspraakMakenView from '../views/AfspraakMakenView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/planning',
    name: 'planning',
    component: PlanningView
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
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
