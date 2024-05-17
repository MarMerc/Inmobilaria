<template>
  <div class="container w-75 mt-5">
    <div class="row">
      <div class="col-md-12">
        <div class="row">
          <div class="col-md-6">
            <div class="mb-3" v-if="selectedItem">
              <label for="exampleFormControlInput1" class="form-label text-success">Tipo de Propiedad:</label>

              <input type="text" class="form-control" id="inputTipoProp" v-model="selectedItem.tipoInmueble" />
            </div>
          </div>
          <div class="col-md-6">
            <div class="mb-3" v-if="selectedItem">
              <label for="FormControlInput" class="form-label text-success">Tipo de Operacion:</label>
              <input type="text" class="form-control" id="inputTipoOper" v-model="selectedItem.tipoOperación" />
            </div>
          </div>
        </div>
        <div class="row">
          <div class="mb-3" v-if="selectedItem">
            <label for="FormControlInput" class="form- text-success">Descripcion:</label>
            <input type="text" class="form-control" id="inputDescripcion" v-model="selectedItem.descripción" />
          </div>
        </div>
        <div class="row">
          <div class="col-md 4">
            <div class="mb-3" v-if="selectedItem">
              <label for="FormControlInput" class="form-label text-success">Ambientes:</label>
              <input type="text" class="form-control" v-model="selectedItem.ambientes" />
            </div>
          </div>
          <div class="col-md 4">
            <div class="mb-3" v-if="selectedItem">
              <label for="FormControlInput" class="form-label text-success">Antiguedad:</label>
              <input type="text" class="form-control" v-model="selectedItem.antiguedad" />
            </div>
          </div>
          <div class="col-md 4">
            <div class="mb-3" v-if="selectedItem">
              <label for="FormControlInput" class="form-label text-success">Metros cuadrados:</label>
              <input type="text" class="form-control" v-model="selectedItem.m2" />
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-4">
          <div class="mb-3" v-if="selectedItem">
            <label for="FormControlInput" class="form-label text-success">Latitud:</label>
            <input type="text" class="form-control" v-model="selectedItem.latUbicación" />
          </div>
        </div>
        <div class="col-md-4">
          <div class="mb-3" v-if="selectedItem">
            <label for="FormControlInput" class="form-label text-success">Longitud:</label>
            <input type="text" class="form-control" v-model="selectedItem.longUbicación" />
          </div>
        </div>
      </div>
    </div>
    <div class="btn-group" role="group" aria-label="Basic mixed styles example">
      <router-link to="/lista">
        <button type="button" class="btn btn-danger">Cancelar</button>
      </router-link>
      <button type="button" class="btn btn-success" @click="guardarCambios">Guardar</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      selectedItem: null,
      FormControlInput:null,
      created() {
        this.FormControlInputInicial = { ...this.FormControlInput };
      },

      // resetForm() {
      //   this.selectedItem.descripción = "";
      // },
    };
  },

  methods: {
    guardarCambios() {
      console.log("aqui", this.selectedItem);

      axios
        .put(`https://localhost:7055/api/Inmueble/Editar`, this.selectedItem)
        .then((response) => {
          console.log("Cambios guardados correctamente:", response.data.response);
          this.FormControlInput = { ...this.FormControlInputInicial };
          this.$router.push('/lista');
        })
        .catch((error) => {
          console.error("Error al modificar los datos del inmueble desde la API", error);
        });
    },
  },
  mounted() {
    const idInmueble = this.$route.params.id;
    axios
      .get(`https://localhost:7055/api/Inmueble/Obtener/${idInmueble}`)
      .then((response) => {
        this.selectedItem = response.data.response;
        console.log("Datos del inmueble para editar:", this.selectedItem);
      })
      .catch((error) => {
        console.error("Error al obtener datos del inmueble desde la API", error);
      });
  },
};
</script>
