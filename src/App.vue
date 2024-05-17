<template>
  <div class="ContainerApp">
    <nav class="z bg-success-subtle d-flex  justify-content-around ">
      <router-link to="/" class="badge text-wrap fs-5" style="width: 6rem" id="HeaderBar">
        <img src="../public/Img/logo.png" class="rounded mx-auto d-block w-100" alt="..." />
      </router-link>
      <router-link to="/postinmueble">
        <i class="fa-solid fa-circle-plus fa-2xl mt-4" style="color: #556232;"></i>
      </router-link>
    </nav>
    <Principal v-if="$route.path === '/'" />
    <router-view v-else />
  </div>
</template>

<script>
import Principal from "./components/PrincipalPage.vue";

export default {
  name: "App",
  components: {
    Principal,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: white; /* Color del texto */
  padding: 20px; /* Espaciado interno */
  /* Establece la opacidad para permitir que la imagen de fondo sea visible */
  background-color: rgba(0, 0, 0, 0.5); /* Fondo semi-transparente
  /* Establece la imagen de fondo y ajusta el tamaño */
  background-image: url("../public/Img/FondoPrincipal2.jpg");
  background-size: 100%;
  background-position: center;
}

.ContainerApp {
  height: 700px;
}

nav {
  padding: 10px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

#HeaderBar {
  background: #585222;
}
</style>
