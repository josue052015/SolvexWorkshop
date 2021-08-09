import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Navbar from '../components/Navbar.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  
  {
    path: '/Home',
    name: 'Home',
    component: () => import('../views/Home.vue')
  }, 
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/Member',
    name: 'Member',
    component: () => import('../views/Member.vue')
  },
  {
    path: '/WorkShop',
    name: 'WorkShop',
    component: () => import('../views/WorkShop.vue')
  },
  {
    path: '/Login',
    name: 'Login',
    component: () => import('../components/Login.vue')
  },
  {
    path: '/Register',
    name: 'Register',
    component: () => import('../components/Register.vue')
  },
  {
    path: '/',
    name: 'Login',
    component: () => import('../components/Login.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
