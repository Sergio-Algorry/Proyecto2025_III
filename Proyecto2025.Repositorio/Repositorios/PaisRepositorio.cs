using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using Proyecto2025.Shared.DTO;

namespace Proyecto2025.Repositorio.Repositorios
{
    public class PaisRepositorio : Repositorio<Pais>,
                                   IRepositorio<Pais>, 
                                   IPaisRepositorio
    {
        private readonly AppDbContext context;

        public PaisRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Pais?> SelectByAlpha3Code(string cod)
        {
            Pais? entidad = await context.Paises.FirstOrDefaultAsync(x => x.Alpha3Code == cod);

            return entidad;
        }

        public async Task<Pais?> SelectByCodIndec(string cod)
        {
            Pais? entidad = await context.Paises.FirstOrDefaultAsync(x => x.CodIndec == cod);

            return entidad;
        }

        public async Task<List<PaisListadoDTO>> SelectListaPais()
        {
            var lista = await context.Paises
                                    .Select(p => new PaisListadoDTO
                                    {
                                        Id = p.Id,
                                        DatosPais = $"{p.CodIndec} - { p.NombrePais} ({p.CodLlamada})"
                                    })
                                    .ToListAsync();
            return lista;
        }
    }
}
