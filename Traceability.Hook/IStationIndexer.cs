
namespace Traceability.Hook
{
    public interface IStationIndexer
    {
        bool Initialize();
        bool ShiftProducttStationLeft(string insertedFullName, int id, int productResult, int shiftNumber);
        bool ShiftProductStationRight(string insertedFullName, int id, int productResult, int shiftNumber);
        bool Clear();
        int NumberOfStation();
        bool GetStationProduct(int station, out string fullName, out int id, out int result);
        bool GetStationProduct(int station, out string fullName);
        bool SetProductToStation(int station, string insertedFullName, int id, int productResult);

        event MesEventHandlerWithInfo StationIndexerException;
    }
}
