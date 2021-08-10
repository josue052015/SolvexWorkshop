import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'login',
   component: () => import('../components/login.vue')
   
  },
  {
    path: '/WorkShop',
    name: 'WorkShop',
    component: () => import('../views/WorkShop.vue')
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
    path: '/login',
    name: 'login',
    component: () => import('../components/login.vue')
  },
  {
    path: '/Home',
    name: 'Home',
    component: () => import('../views/Home.vue')
  }, 
   {
    path: '/profile',
    name: 'profile',
    component: () => import('../views/profile.vue')
  },
  {
    path: '/hola',
    name: 'hola',
    component: () => import('../components/HelloWorld.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
