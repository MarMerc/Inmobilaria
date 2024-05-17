<template>
  <div>
    <div class="m-3 d-flex justify-content-center" v-if="selectedItem">
      <div class="card rounded-3 w-75">
        <div class="row p-lg-1">
          <div class="col-md-6 d-flex justify-content-center">
            <img src="https://d1acdg20u0pmxj.cloudfront.net/listings/ce2cdf78-7654-4bcf-aa26-6278c8e6a2a8/360x200/7c7f79cd-d3c8-40ab-a975-084cf582b528.webp?" class="w-100" alt="..." />
            <!--<Carrusel />-->
          </div>
          <div class="col-md-5">
            <div class="card-body">
              <div class="row">
                <div class="col-md-6 mt-5">
                  <div v-if="selectedItem.tipoInmueble === 'Casa'">
                    <i class="fa-solid fa-house fa-2xl mb-4"></i>
                  </div>
                  <div v-else>
                    <div v-if="selectedItem.tipoInmueble === 'Terreno'">
                      <i class="fa-solid fa-panorama fa-2xl mb-4"></i>
                    </div>
                    <div v-else>
                      <i class="fa-solid fa-building fa-2xl mb-4"></i>
                    </div>
                  </div>
                  <h5 class="card-title">{{ selectedItem.tipoInmueble }}</h5>
                </div>
                <div class="col-md-6 mt-5">
                  <div v-if="selectedItem.tipoInmueble === 'Venta'">
                    <i class="fa-solid fa-sack-dollar fa-2xl mb-4"></i>
                  </div>

                  <div v-else>
                    <i class="fa-solid fa-file-signature fa-2xl mb-4"></i>
                  </div>

                  <h5 class="card-title">{{ selectedItem.tipoOperación }}</h5>
                </div>
              </div>
              <div class="row m-3">
                <span class="border border-success-subtle rounded-4 bg-success bg-opacity-10">
                  <h5 class="card-text">
                    {{ selectedItem.descripción }}
                  </h5></span
                >
              </div>
              <div class="row">
                <div class="col-4">
                  <H5 class="card-text">{{ selectedItem.ambientes }} amb.</H5>
                </div>
                <div class="col-4">
                  <H5 class="card-text">{{ selectedItem.antiguedad }} años</H5>
                </div>
                <div class="col-4">
                  <H5 class="card-text">{{ selectedItem.M2 }} m2</H5>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6 mt-4">
                  <H6 class="card-text">
                    <small class="text-body-secondary"> Lat: {{ selectedItem.latUbicación }} </small>
                  </H6>
                </div>
                <div class="col-md-6 mt-4">
                  <p class="card-text">
                    <small class="text-body-secondary"> Long:{{ selectedItem.longUbicación }} </small>
                  </p>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-1 align-self-center p-1">
            <div class="btn-group-vertical" role="group" aria-label="Vertical button group">
              <button type="button" class="btn btn-outline-success" @click="HandlerEditar">
                <i class="fa-solid fa-pen-to-square fa-lg"></i>
              </button>
              <button type="button" class="btn btn-outline-danger" @click="HandlerEliminar">
                <i class="fa-solid fa-trash fa-lg"></i>
              </button>
              <router-link to="/lista">
                <button type="button" class="btn btn-outline-primary">
                  <i class="fa-solid fa-backward-step fa-xl" style="color: #134cae"></i>
                </button>
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <p>No se ha seleccionado ningún inmueble.</p>
    </div>
  </div>
</template>

<script>
import axios from "axios";
//import Carrusel from "./CarruselImg.vue";

export default {
  Componentes: {

  },

  data() {
    return {
      selectedItem: null,
      idInmueble: null,
    };
  },
  methods: {
    HandlerEditar() {
      this.$router.push({ name: "InputInmueble", params: { id: this.idInmueble } });
     
    },

    async HandlerEliminar() {
      const idInmueble = this.$route.params.id;
      if (confirm('¿Estás seguro de que deseas eliminar este registro?')){
        try {
          await axios.delete(`https://localhost:7055/api/Inmueble/Eliminar/${idInmueble}`);
          console.log("Datos Eliminados Correctamente");
          alert('Registro Eliminado exitosamente');
          this.$router.push('/lista');
        } catch (error) {
          console.error("Error al guardar los datos", error);
        }        
      }else {
        // Acción cancelada
        alert('Acción cancelada');
      }

    },

    cargaCard() {
      const idInmueble = this.$route.params.id;
      axios
        .get(`https://localhost:7055/api/Inmueble/Obtener/${idInmueble}`)
        .then((response) => {
          this.selectedItem = response.data.response;
          console.log("Datos del inmueble seleccionado:", this.selectedItem);
        })
        .catch((error) => {
          console.error("Error al obtener datos del inmueble desde la API", error);
        });
    },

    cargaImagenes(){
      
    }
  },

  mounted() {
    this.cargaCard();
  },
};
</script>

<style></style>
