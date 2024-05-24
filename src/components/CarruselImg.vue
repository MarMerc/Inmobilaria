<script>
import axios from "axios";
export default {
  data() {
    return {
      ImagenInfo: Object,
      datos: [],
      currentIndex: 0,
    };
  },

  methods: {
    prevSlide() {
      this.currentIndex = (this.currentIndex - 1 + this.datos.length) % this.datos.length;
    },
    nextSlide() {
      this.currentIndex = (this.currentIndex + 1) % this.datos.length;
    }
  },

  mounted() {
    //const idInmueble = this.$route.params.id;
    axios
      .get(`https://localhost:7178/api/Imagen/ObtenerImagenXInmueble/2`)
      .then((response) => {
        response.data.response.forEach((element) => {
          this.datos.push(element);
        });
        console.log("Imagenes: ", this.datos.ubicacionImg);
      })
      .catch((error) => {
        console.error("Error al obtener datos desde la API", error);
      });
  },
};
</script>

<template>
  <div class="div">
    <!-- <div v-for="x in datos" :key="x.idImagen" class=" ">
      <img :src="x.ubicacionImg" alt="Imagen del inm" />
    </div> -->

    <div class="carousel">
    <div class="carousel-inner">
      <div v-for="(image, index) in datos" :key="index" class="carousel-item" :class="{ active: index === currentIndex }">
        <img :src="image.ubicacionImg" class="d-block w-100" alt="Slide">
      </div>
    </div>
    <button @click="prevSlide" class="carousel-control-prev" type="button">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </button>
    <button @click="nextSlide" class="carousel-control-next" type="button">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </button>
  </div>


  </div>
</template>

<style scoped>
.carousel {
  position: relative;
}
.carousel-inner {
  position: relative;
  width: 100%;
  overflow: hidden;
}
.carousel-item {
  display: none;
  transition: opacity 0.6s ease-in-out;
}
.carousel-item.active {
  display: block;
}
.carousel-control-prev,
.carousel-control-next {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  z-index: 1;
}
.carousel-control-prev {
  left: 0;
}
.carousel-control-next {
  right: 0;
}
</style>
