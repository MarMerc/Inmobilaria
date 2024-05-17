import { createApp } from 'vue';
import App from './App.vue';
import router from './Router/index'; // Importar el enrutador
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap';
import '@fortawesome/fontawesome-free/css/all.css'

const app = createApp(App);

app.use(router); // Integrar el enrutador

app.mount('#app'); // Montar la aplicación
