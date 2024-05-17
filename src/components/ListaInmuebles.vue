<script>
import axios from "axios";
import CardInmueble from "./CardImueble.vue";
//import CarruselImg from "./CarruselImg.vue";

export default {
  components: {
    CardInmueble,
  },

  data() {
    return {
      Items: [],
    };
  },
  methods: {
    listarCards() {
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
    this.listarCards();
  },
};
</script>

<template>
  <div class="w-to m-2 justify-content-center">
    <div v-if="Items?.length > 0">
      <div class="justify-content-center">
        <CardInmueble />
      </div>
    </div>
    <div v-else>
      <div class="justify-content-center">
        <h1>No hay inmuebles para mostrar</h1>
      </div>
    </div>
  </div>
</template>

<style></style>
