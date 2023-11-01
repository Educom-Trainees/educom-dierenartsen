import { createRouter, createWebHistory } from 'vue-router'
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
    path: '/planning',
    name: 'planning',
    component: PlanningView
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
