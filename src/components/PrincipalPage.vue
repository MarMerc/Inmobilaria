<template>
  <div class="principalComp d-flex justify-content-center align-items-center mt-5 ">
    <div class="" >
      <h1 class="display-4 text-center">Inmuebles y Propiedades</h1>
      <hr />
      <div class="row CardInmueble">
        <div class="col-lg-8 offset-lg-2">
          <div class="d-flex justify-content-center">
            <router-link to="/lista">
              <button type="button" class="btn btn-lg btn-outline-success">
                Ver Inmuebles
              </button>
            </router-link>
          </div>
        </div>
      </div>
    </div>
    <hr />
    <div
      class="btn-group d-flex justify-content-around p-3"
      role="group"
      aria-label="Basic outlined example"
    ></div>
  </div>
</template>

<script></script>

<style scoped>
.principalComp{
  /* Añade otros estilos según sea necesario */
  color: white; /* Color del texto */
  padding: 20px; /* Espaciado interno */
  /* Establece la opacidad para permitir que la imagen de fondo sea visible */
  background-color: rgba(0, 0, 0, 0.5); /* Fondo semi-transparente */
  /* Establece la imagen de fondo y ajusta el tamaño */
  background-size: cover;
  background-position: center;
}
</style>
