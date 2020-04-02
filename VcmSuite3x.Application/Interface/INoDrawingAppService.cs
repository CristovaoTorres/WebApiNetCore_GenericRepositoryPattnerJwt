
namespace VcmSuite3x.Application.Interface
{
    public interface INoDrawingAppService
    {
        bool Insert(int portas, int fluxogramaId, ref int noId, ref string codigo, string categoria, bool conector, float CoordenadaX, float CoordenadaY);
        bool Delete(int noId, int fluxogramaId);
        bool Update(int fluxogramaId, int noId, float coordenadaX, float coordenadaY);
    }
}
