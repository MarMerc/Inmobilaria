<template>
  <form @submit.prevent="submitForm">
    <div class="container mt-4 justify-content-center align-items-lg-center">
      <div class="w-100 mt-8 bg-success-subtle p-5 rounded">
        <div class="row">
          <div class="col-md-6">
            <div class="row">
              <div class="col-md-6">
                <div class="mb-6">
                  <label class="form-label">Tipo de Inmueble</label>
                  <select for="formControlPost" class="form-select" aria-label="Default select example" v-model="formControlPost.TipoInmueble">
                    <option selected>Tipo de Inmueble</option>
                    <option value="Departamento">Departamento</option>
                    <option value="Casa">Casa</option>
                    <option value="Terreno">Terreno</option>
                  </select>
                </div>
              </div>
              <div class="col-md-6">
                <div class="mb-6">
                  <label class="form-label">Tipo de Operación</label>
                  <select for="formControlPost" class="form-select" aria-label="Default select example" v-model="formControlPost.TipoOperación">
                    <option selected>Tipo de Operacion</option>
                    <option value="Venta">Venta</option>
                    <option value="Alquiler">Alquiler</option>
                  </select>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <div class="mb-6">
                    <label class="form-label"></label>
                    <textarea class="form-control" rows="3" placeholder="Descripcion" v-model="formControlPost.Descripción">Descripción</textarea>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Antiguedad</label>
                  <input type="Numeric" class="form-control" placeholder="Años" v-model="formControlPost.Antiguedad" />
                </div>
              </div>
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Ambientes</label>
                  <input type="Numeric" class="form-control" placeholder="Amb." v-model="formControlPost.Ambientes" />
                </div>
              </div>
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Mts Cuad.</label>
                  <input type="Numeric" class="form-control" placeholder="m2" v-model="formControlPost.M2" />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="mb-3">
                <label class="form-label">Multiple files input example</label>
                <input class="form-control" type="file" id="formFileMultiple" multiple />
              </div>
            </div>
            <div class="btn-group" role="group" aria-label="Basic mixed styles example">
              <router-link to="/lista">
                <button type="button" class="btn btn-danger">Cancelar</button>
              </router-link>
              <button type="submit" class="btn btn-success btn-sm">Guardar</button>
            </div>
          </div>
          <div class="col-md-6 justify-content-center p-3">
            <img src="../../public/Img/FondoPrincipal.jpg" class="img-fluid rounded" alt="..." />
          </div>
        </div>
      </div>
    </div>
  </form>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      formControlPost: {
        TipoInmueble: "",
        TipoOperacion: "",
        Descripción: "",
        Ambientes: "",
        M2: "",
        Antiguedad: "",
        LatUbicacion: "",
        LongUbicacion: "",
      },
    };
  },
  methods: {
    async submitForm() {
      try {
        await axios.post("https://localhost:7055/api/Inmueble/Guardar", this.formControlPost);
        console.log("Datos Guardados Correctamente", this.formControlPost);
        
      } catch (error) {
        console.error("Error al guardar los datos", error);
      }
    },
  },
};
</script>
