using Proyecto2025.BD.Datos.Entity;

namespace Proyecto2025.Repositorio.Repositorios
{
    public interface ITipoProvinciaRepositorio : IRepositorio<TipoProvincia>
    {
        Task<TipoProvincia?> SelectByCod(string cod);
    }
}