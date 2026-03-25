using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using Proyecto2025.Repositorio.Repositorios;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/TipoProvincia")]
    public class TipoProvinciaController : ControllerBase
    {
        private readonly ITipoProvinciaRepositorio repositorio;

        public TipoProvinciaController(ITipoProvinciaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] //api/TipoProvincia
        public async Task<ActionResult<List<TipoProvincia>>> Get()
        {
            var tipoProvincias = await repositorio.Select();
            //var tipoProvincias = await context.TipoProvincias.ToListAsync();
            if (tipoProvincias == null)
            {
                return NotFound("No se encontraron tipos de provincia, VERIFICAR.");
            }
            if (tipoProvincias.Count == 0)
            {
                return Ok("No existe tipos de provincia en este momento.");
            }

            return Ok(tipoProvincias);
        }

        [HttpGet("{id:int}")]  //api/TipoProvincia/5
        public async Task<ActionResult<TipoProvincia>> Get(int id)
        {
            var tipoProvincia = await repositorio.SelectById(id);
            //var tipoProvincia = await context.TipoProvincias.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el tipo de provincia con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("bycod/{cod}")]  //api/TipoProvincia/PRU
        public async Task<ActionResult<TipoProvincia>> Get(string cod)
        {
            var entidad = repositorio.SelectByCod(cod);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el codigo: {cod}.");
            }

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TipoProvincia DTO)
        {
            try
            {     
                await repositorio.Insert(DTO);
                //await context.TipoProvincias.AddAsync(DTO);
                //await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el tipo de provincia: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Put(int id, TipoProvincia DTO)
        {
            //if (id != DTO.Id)
            //{
            //    return BadRequest("Datos no validos.");
            //}
            //var existe = await repositorio.Existe(id);
            //var existe = await context.TipoProvincias.AnyAsync(x => x.Id == id);
            //if (!existe)
            //{
            //    return NotFound($"No existe el tipo de provincia con el id: {id}.");
            //}
            //context.Update(DTO);
            //await context.SaveChangesAsync();
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos o el tipo de provincia no existe.");
            }
            return Ok($"Tipo de provincia con el id: {id} actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Delete(int id)
        {
            //var existe = await context.TipoProvincias.AnyAsync(x => x.Id == id);
            //if (existe == false)
            //{
            //    return NotFound($"No existe el tipo de provincia con el id: {id}.");
            //}
            //var tipoProvincia = await context.TipoProvincias.FirstOrDefaultAsync(x => x.Id == id);
            //if (tipoProvincia is null)
            //{
            //    return NotFound($"No existe el tipo de provincia con el id: {id}.");
            //}
            //context.TipoProvincias.Remove(tipoProvincia);
            //await context.SaveChangesAsync();
            var flag = await repositorio.Delete(id);
            if (!flag)
            {
                return NotFound($"No existe el registro con el id: {id} o ya fue eliminado.");
            }

            return Ok($"Registro con el id: {id} eliminado correctamente.");
        }
    }
}
