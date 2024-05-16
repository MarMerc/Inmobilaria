import { createRouter, createWebHistory} from 'vue-router'
import Principal from '../components/PrincipalPage.vue'
import Lista from '../components/ListaInmuebles.vue'
//import Items from '../components/ItemInmueble.vue'
import CardInm from '../components/CardImueble.vue'
import Carrusel from '../components/CarruselImg.vue'
import SelectCard from '../components/SelectCard.vue'
import InputInmueble from '../components/InputInmueble.vue'
import PostInmueble from '../components/PostInmueble.vue'

const routes=[
     {
         PATH:'/',
        NAME:'Principal',
        COMPONENT: Principal
    },
 
    {
        path:'/lista',
        name:'Lista',
        component: Lista
    },
    
    {
         path:'/cardInm',
         name:'CardInm',
         component: CardInm
     },
     {
        path:'/carrusel',
        name:'Carrusel',
        component: Carrusel
    },

     {
         path:'/selectcard/:id',
         name:'SelectCard',
         component: SelectCard,
         
     },

     {
        path:'/inputinmueble/:id',
        name:'InputInmueble',
        component: InputInmueble,
        
    },

    {
        path:'/postinmueble',
        name:'PostInmueble',
        component: PostInmueble,
        
    },  
]

const router = createRouter({
    history: createWebHistory(),
    routes,
    
})

export default router;
 
