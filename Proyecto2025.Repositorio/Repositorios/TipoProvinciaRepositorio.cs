using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;

namespace Proyecto2025.Repositorio.Repositorios
{
    public class TipoProvinciaRepositorio : Repositorio<TipoProvincia>, 
                                            IRepositorio<TipoProvincia>, 
                                            ITipoProvinciaRepositorio
    {
        private readonly AppDbContext context;

        public TipoProvinciaRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<TipoProvincia?> SelectByCod(string cod)
        {
            try
            {
                TipoProvincia? entidad = await context.TipoProvincias
                                                     .FirstOrDefaultAsync(x => x.Codigo == cod);
                return entidad;
            }
            catch (Exception e)
            {

                throw;
            }

        }

    }
}
