using Proyecto2025.BD.Datos.Entity;
using Proyecto2025.Shared.DTO;

namespace Proyecto2025.Repositorio.Repositorios
{
    public interface IPaisRepositorio : IRepositorio<Pais>
    {
        Task<Pais?> SelectByAlpha3Code(string cod);
        Task<Pais?> SelectByCodIndec(string cod);
        Task<List<PaisListadoDTO>> SelectListaPais();
    }
}