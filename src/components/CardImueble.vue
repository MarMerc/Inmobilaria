<template>
  <div class="w-100 rounded-4">
    <div v-for="x in Items" :key="x.idInmueble" class=" ">
      <div class="m-3 d-flex justify-content-center" @click="handlerSelected(x.idInmueble)">
        <div class="card rounded-3 w-75">
          <div class="row p-lg-1">
            <div class="col-md-6 d-flex justify-content-center">
              <img src="https://d1acdg20u0pmxj.cloudfront.net/listings/ce2cdf78-7654-4bcf-aa26-6278c8e6a2a8/360x200/7c7f79cd-d3c8-40ab-a975-084cf582b528.webp?" class="w-100" alt="..." />
            </div>
            <div class="col-md-6">
              <div class="card-body">
                <div class="row ">
                  <div class="col-md-6 mt-5">
                    <div v-if="x.tipoInmueble === 'Casa'">
                      <i class="fa-solid fa-house fa-2xl mb-4"></i>
                    </div>
                    <div v-else>
                      <div v-if="x.tipoInmueble === 'Terreno'">
                        <i class="fa-solid fa-panorama fa-2xl mb-4"></i>
                      </div>
                      <div v-else>
                        <i class="fa-solid fa-building fa-2xl  mb-4"></i>
                      </div>
                    </div>
                    <h5 class="card-title">{{ x.tipoInmueble }}</h5>
                  </div>
                  <div class="col-md-6 mt-5">
                    <div v-if="x.tipoOperación === 'Venta'">
                      <i class="fa-solid fa-sack-dollar fa-2xl  mb-4"></i>
                    </div>
                    <div v-else>
                      <i class="fa-solid fa-file-signature fa-2xl  mb-4"></i>
                    </div>
                    <h5 class="card-title">{{ x.tipoOperación }}</h5>
                  </div>
                </div>
                <div class="row m-3">
                  <span class="border border-success-subtle rounded-4 bg-success bg-opacity-10">
                    <h5 class="card-text">
                      {{ x.descripción }}
                    </h5></span
                  >
                </div>
                <div class="row">
                  <div class="col-4">
                    <H5 class="card-text">{{ x.ambientes }} amb.</H5>
                  </div>
                  <div class="col-4">
                    <H5 class="card-text">{{ x.antiguedad }} años</H5>
                  </div>
                  <div class="col-4">
                    <H5 class="card-text">{{ x.M2 }} m2</H5>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-8 mt-4">
                    <H6 class="card-text">
                      <small class="text-body-secondary"> Lat: {{ x.latUbicación }} </small>
                    </H6>
                    <p class="card-text">
                      <small class="text-body-secondary"> Long:{{ x.longUbicación }} </small>
                    </p>
                  </div>
                  <div class="col-md-1 mt-4">
                    <i class="fa-solid fa-location-dot fa-2xl mb-4"></i>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      InmuebleInfo: Object,
      Items: [],
      SelectItem: null,
    };
  },

  methods: {
    handlerSelected(idInmueble) {
      this.$router.push({ name: "SelectCard", params: { id: idInmueble } });
    },

    listaAll() {
      axios
        .get("https://localhost:7055/api/Inmueble/Lista")
        .then((response) => {
          response.data.response.forEach((element) => {
            this.Items.push(element);
          });
          console.log("ITEMS ITEMS", this.Items);
        })
        .catch((error) => {
          console.error("Error al obtener datos desde la API", error);
        });
    },
  },

  mounted() {
    this.listaAll();
  },
};
</script>

<style></style>
