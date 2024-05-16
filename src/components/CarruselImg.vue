<!-- <script>
import axios from "axios";

export default {
  data() {
    return {
      ImagenInfo: Object,
      datos: [],
    };
  },
  mounted() {
    axios
      .get("https://localhost:7055/api/Imagen/Lista")
      .then((response) => {
        response.data.response.forEach((element) => {
          this.datos.push(element);
        });
        console.log("DATOS DATOS", this.datos); //.response[3]);
      })
      .catch((error) => {
        console.error("Error al obtener datos desde la API", error);
      });
  },

};
</script>

<template>
  <div>
    <div class="custom-carousel">
      <img :src="currentImage" :alt="currentAlt" />
      <button @click="prevImage">Anterior</button>
      <button @click="nextImage">Siguiente</button>
    </div>
  </div>
</template> -->

<template>
<div id="carouselExampleIndicators" class="carousel slide container w-50 " data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="../../public/Img/Dpto1.jpeg" alt="First slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="../../public/Img/Dpto2.jpeg" alt="Second slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="../../public/Img/Dpto3.jpeg" alt="Third slide">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</template>

<script>
  export default {
    data() {
      return {
        slide: 0,
        sliding: null
      }
    },
    methods: {
      onSlideStart(slide) {
        this.sliding = true
        console.log(slide)
      },
      onSlideEnd(slide) {
        this.sliding = false
        console.log(slide)
      }
    }
  }
</script>