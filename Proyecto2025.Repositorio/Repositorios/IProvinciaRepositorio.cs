using Proyecto2025.BD.Datos.Entity;
using Proyecto2025.Shared.DTO;

namespace Proyecto2025.Repositorio.Repositorios
{
    public interface IProvinciaRepositorio : IRepositorio<Provincia>
    {
        Task<ProvinciaResumenDTO?> ResumenProvincia(string cod);
        Task<Provincia?> SelectByIGM_Id(string cod);
    }
}