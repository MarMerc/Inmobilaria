<script>

</script>

<template>
  <div v-for="x in datos" :key="x.idImagen" class=" ">
    <img src="https://d1acdg20u0pmxj.cloudfront.net/listings/ce2cdf78-7654-4bcf-aa26-6278c8e6a2a8/360x200/7c7f79cd-d3c8-40ab-a975-084cf582b528.webp?" alt="Imagen del inm"/>
  </div>
<div>
  <b-carousel
      id="carousel-fade"
      style="text-shadow: 1px 1px 2px #333;"
      v-model="slide"
      :interval="4000"
      controls
      indicators
      background="#ababab"
      img-width="1024"
      img-height="480"
      :no-wrap="false"
      @sliding-start="onSlideStart"
      @sliding-end="onSlideEnd"
    >
      <b-carousel-slide
        v-for="image in datos"
        :key="image.idImagen"
        :img-src="image.ubicacionImg"
    
      >
      </b-carousel-slide>
    </b-carousel>
</div>




</template>

<!-- <template>
  <div class="container w-50 ">
    <div id="carouselExampleIndicators" class="carousel slide container w-50" data-ride="carousel">
      <ol class="carousel-indicators">
        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
      </ol>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img class="d-block w-100" src="../../public/Img/Dpto1.jpeg" alt="First slide" />
        </div>
        <div class="carousel-item">
          <img class="d-block w-100" src="../../public/Img/Dpto2.jpeg" alt="Second slide" />
        </div>
        <div class="carousel-item">
          <img class="d-block w-100" src="../../public/Img/Dpto3.jpeg" alt="Third slide" />
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
  </div>
</template>

<script>
export default {
  data() {
    return {
      slide: 0,
      sliding: null,
    };
  },
  methods: {
    onSlideStart(slide) {
      this.sliding = true;
      console.log(slide);
    },
    onSlideEnd(slide) {
      this.sliding = false;
      console.log(slide);
    },
  },
};
</script> -->
