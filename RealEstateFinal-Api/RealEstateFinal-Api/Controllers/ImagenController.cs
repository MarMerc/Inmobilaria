using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateFinal_Api.Models;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Cors;

using System.Net;


namespace RealEstateFinal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        public readonly inmobilaryContext _dbcontext;

        public ImagenController(inmobilaryContext _context)
        {
            _dbcontext = _context;
        }


        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Imagen> lista = new List<Imagen>();

            try
            {
                lista = _dbcontext.Imagens.ToList();
                //Para Incluir las FK   .Include(c=>c.oImagen)

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        // Listar las imagenes de un mismo inmueble, ingresando el id del inmueble
        [HttpGet]
        [Route("ObtenerImagenXInmueble/{idInmueble}")]
        public IActionResult ObtenerTipo(int idInmueble)
        {
            List<Imagen> lista = new List<Imagen>();
            try
            {
                lista = _dbcontext.Imagens.Where(x => x.IdInmueble == idInmueble)
                          .ToList();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }


        //Busqueda por un Id
        [HttpGet]
        [Route("Obtener/{idImagen:int}")]
        public IActionResult Obtener(int idImagen)
        {
            Imagen oImag = _dbcontext.Imagens.Find(idImagen);

            if (oImag == null)
            {
                return BadRequest("Imagen no encontrada");
            }
            try
            {
                oImag = _dbcontext.Imagens.Where(i => i.IdImagen == idImagen).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oImag });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oImag });
            }

        }

        //Agregar una immagen
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Imagen objeto)
        {
            try
            {
                _dbcontext.Imagens.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Imagen objeto)
        {
            Imagen oImag = _dbcontext.Imagens.Find(objeto.IdImagen);

            if (oImag == null)
            {
                return BadRequest("Imagen no encontrada");
            }

            try
            {
                oImag.UbicacionImg = objeto.UbicacionImg is null ? oImag.UbicacionImg : objeto.UbicacionImg;
                oImag.IdInmueble = objeto.IdInmueble is null ? oImag.IdInmueble : objeto.IdInmueble;

                _dbcontext.Imagens.Update(oImag);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idImagen:int}")]
        public IActionResult Eliminar(int idImagen)
        {
            Imagen oImag = _dbcontext.Imagens.Find(idImagen);

            if (oImag == null)
            {
                return BadRequest("Imagen no encontrada");
            }

            try
            {
                oImag = _dbcontext.Imagens.Where(i => i.IdImagen == idImagen).FirstOrDefault();

                _dbcontext.Imagens.Remove(oImag);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }



    }
}
