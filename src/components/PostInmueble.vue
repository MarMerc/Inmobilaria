<template>
  <form @submit.prevent="submitForm" class="justify-content-center">
    <div class="container mt-4 align-items-lg-center">
      <div class="w-100 mt-8 bg-success-subtle p-5 rounded">
        <div class="row justify-content-center">
          <div class="col-md-6">
            <div class="row justify-content-center">
              <div class="col-md-6">
                <div class="mb-6">
                  <label class="form-label">Tipo de Inmueble</label>
                  <select for="formControlPost" class="form-select" aria-label="Default select example" v-model="formControlPost.TipoInmueble">
                    <option selected>Departamento</option>
                    <option value="Casa">Casa</option>
                    <option value="Terreno">Terreno</option>
                  </select>
                </div>
              </div>
              <div class="col-md-6">
                <div class="mb-6">
                  <label class="form-label">Tipo de Operación</label>
                  <select for="formControlPost" class="form-select" aria-label="Default select example" v-model="formControlPost.TipoOperación">
                    <option selected>Venta</option>
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
            <div class="row justify-content-center">
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Antiguedad</label>
                  <input type="Numeric" class="form-control" placeholder="Años" v-model="formControlPost.Antiguedad" @input="validacionNumericaAnt" />
                  <span v-if="!esNumeroValidoAnt">Por favor, ingrese un número válido.</span>
                </div>
              </div>
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Ambientes</label>
                  <input type="Numeric" class="form-control" placeholder="Amb." v-model="formControlPost.Ambientes" @input="validacionNumericaAmb" />
                  <span v-if="!esNumeroValidoAmb">Por favor, ingrese un número válido.</span>
                </div>
              </div>
              <div class="col-md-3">
                <div class="mb-3">
                  <label class="form-label">Mts Cuad.</label>
                  <input type="Numeric" class="form-control" placeholder="m2" v-model="formControlPost.M2" @input="validacionNumericaM2" />
                  <span v-if="!esNumeroValidoM2">Por favor, ingrese un número válido.</span>
                </div>
              </div>
            </div>
            <div class="row justify-content-center">
              <div class="col-md-6">
                <div class="mb-3">
                  <label class="form-label">Latitud</label>
                  <input type="text" class="form-control" placeholder="" v-model="formControlPost.LatUbicacion" @input="validacionNumericaLat" />
                  <span v-if="!esNumeroValidoLat">Por favor, ingrese un número válido.</span>
                </div>
              </div>
              <div class="col-md-6">
                <div class="mb-3">
                  <label class="form-label">Longitud</label>
                  <input type="Numeric" class="form-control" placeholder="" v-model="formControlPost.LongUbicacion" @input="validacionNumericaLong" />
                  <span v-if="!esNumeroValidoLong">Por favor, ingrese un número válido.</span>
                </div>
              </div>
            </div>
            <div class="row justify-content-center">
              <div class="mb-3">
                <label class="form-label">Agregar imagenes</label>
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

        ImagenInmueble:[],
      },
      formControlPostInicial: null,
      esNumeroValidoAnt: true,
      esNumeroValidoAmb: true,
      esNumeroValidoM2: true,
      esNumeroValidoLat: true,
      esNumeroValidoLong: true,
      created() {
        this.formControlPostInicial = { ...this.formControlPost };
      },
    };
  },
  methods: {
    async submitForm() {
      try {
        await axios.post("https://localhost:7055/api/Inmueble/Guardar", this.formControlPost);
        this.formControlPost = { ...this.formControlPostInicial };
        console.log("Datos Guardados Correctamente", this.formControlPost);

        document.getElementById("successButton").addEventListener("click", function () {
          alert("Todo salió bien");
        });
      } catch (error) {
        console.error("Error al guardar los datos", error);
      }
    },
    validacionNumericaAnt() {
      this.esNumeroValidoAnt = !isNaN(parseFloat(this.formControlPost.Antiguedad)) && isFinite(this.formControlPost.Antiguedad);
    },
    validacionNumericaAmb() {
      this.esNumeroValidoAmb = !isNaN(parseFloat(this.formControlPost.Ambientes)) && isFinite(this.formControlPost.Ambientes);
    },
    validacionNumericaM2() {
      this.esNumeroValidoM2 = !isNaN(parseFloat(this.formControlPost.M2)) && isFinite(this.formControlPost.M2);
    },
    validacionNumericaLat() {
      this.esNumeroValidoM2 = !isNaN(parseFloat(this.formControlPost.LatUbicacion)) && isFinite(this.formControlPost.LatUbicacion);
    },
    validacionNumericaLong() {
      this.esNumeroValidoM2 = !isNaN(parseFloat(this.formControlPost.LongUbicacion)) && isFinite(this.formControlPost.LongUbicacion);
    },
  },
};
</script>
