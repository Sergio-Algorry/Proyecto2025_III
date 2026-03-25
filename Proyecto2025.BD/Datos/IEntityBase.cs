using Proyecto2025.Shared.ENUM;

namespace Proyecto2025.BD.Datos
{
    public interface IEntityBase
    {
        EnumEstadoRegistro EstadoRegistro { get; set; }
        int Id { get; set; }
        string Observacion { get; set; }
    }
}