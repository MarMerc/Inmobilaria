using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateFinal_Api.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace RealEstateFinal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmuebleController : ControllerBase
    {
        public readonly inmobilaryContext _dbcontext;

        public InmuebleController(inmobilaryContext _context)
        {
            _dbcontext = _context;
        }

        //Lsitar Inmuebles

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            //List<Inmueble> lista = new List<Inmueble>();

            try
            {
                var lista = _dbcontext.Inmuebles
                .Include(i => i.Imagens)
                .ToList();
                //Para Incluir las FK   .Include(c=>c.oImagen)

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = ex.Message });
            }

        }

        // Listar ingresando un Id de Inmueble
        [HttpGet]
        [Route("Obtener/{idInmueble:int}")]
        public IActionResult Obtener(int idInmueble)
        {
            Inmueble oInmueb = _dbcontext.Inmuebles.Find(idInmueble);

            if (oInmueb == null)
            {
                return BadRequest("Inmueble no encontrado");
            }
            try
            {
                oInmueb = _dbcontext.Inmuebles.Where(i => i.IdInmueble == idInmueble).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oInmueb });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = oInmueb });
            }

        }

        // Listar ingresando Tipo de Inmueble
        [HttpGet]
        [Route("ObtenerTipo/{tipoInmueble}")]
        public IActionResult ObtenerTipo(string tipoInmueble)
        {
            List<Inmueble> lista = new List<Inmueble>();
            try
            {
                lista = _dbcontext.Inmuebles.Where(x => x.TipoInmueble.ToLower()==tipoInmueble)
                          .ToList();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }

        // Listar ingresando Tipo de Operacion
        [HttpGet]
        [Route("ObtenerTipoOperacion/{tipoOperacion}")]
        public IActionResult ObtenerTipoOperacion(string tipoOperacion)
        {
            List<Inmueble> lista = new List<Inmueble>();
            try
            {
                lista = _dbcontext.Inmuebles.Where(x => x.TipoOperación.ToLower() == tipoOperacion)
                          .ToList();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }



        //Cargar un nuevo Inmueble
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Inmueble objeto)
        {
            try
            {
                _dbcontext.Inmuebles.Add(objeto);
                _dbcontext.SaveChanges();
                var idInmueble = objeto.IdInmueble;


                //var imagenes = new Imagen
                //{
                //    IdInmueble = idInmueble,
                //    UbicacionImg = objeto.UrlImagen

                //};
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Inmueble objeto)
        {

            Inmueble oInmueb = _dbcontext.Inmuebles.Find(objeto.IdInmueble);

            if (oInmueb == null)
            {
                return BadRequest("Inmueble no encontrado");
            }

            try
            {
                oInmueb.TipoInmueble = objeto.TipoInmueble is null ? oInmueb.TipoInmueble : objeto.TipoInmueble;
                oInmueb.TipoOperación = objeto.TipoOperación is null ? oInmueb.TipoOperación : objeto.TipoOperación;
                oInmueb.Descripción = objeto.Descripción is null ? oInmueb.Descripción : objeto.Descripción;
                oInmueb.Ambientes = objeto.Ambientes is null ? oInmueb.Ambientes : objeto.Ambientes;
                oInmueb.M2 = objeto.M2;
                oInmueb.Antiguedad = objeto.Antiguedad is null ? oInmueb.Antiguedad : objeto.Antiguedad;
                oInmueb.LatUbicación = objeto.LatUbicación is null ? oInmueb.LatUbicación : objeto.LatUbicación;
                oInmueb.LongUbicación = objeto.LongUbicación is null ? oInmueb.LongUbicación : objeto.LongUbicación;

                _dbcontext.Inmuebles.Update(oInmueb);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oInmueb });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idInmueble:int}")]
        public IActionResult Eliminar(int idInmueble)
        {
            Inmueble oInmueb = _dbcontext.Inmuebles.Find(idInmueble);

            if (oInmueb == null)
            {
                return BadRequest("Inmueble no encontrado");
            }
            try
            {

                oInmueb = _dbcontext.Inmuebles.Where(i => i.IdInmueble == idInmueble).FirstOrDefault();

                _dbcontext.Inmuebles.Remove(oInmueb);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
        }
    }
}
