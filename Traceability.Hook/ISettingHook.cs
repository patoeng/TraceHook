namespace Traceability.Hook
{
    public interface ISettingHook
    {
        string GetDatabaseConnectionString();
        void SetDatabaseConnectionString(string dbConnection);
    
        void SetEnableTraceability(bool enable);
        bool GetEnableTraceability();
        string MachineSerialNumber();
        void SetMachineSerialNumnber(string serialNumber);
        int GetUniqueIdLength();
        void SetUniqueIdLength(int length);
        void SetAllowCrossWorkOrder(bool allow);
        bool GetAllowCrossWorkOrder();
        int GetNumberOfStation();
        void SetNumberOfStation(int station);
        string GetAdminPassword();
        void SetAdminPassword(string password);
        string GetPlcIpAdress();
        void SetPlcIpAddress(string ipAddress);
        int GetPlcScanRate();
        int GetPlcStartAddress(); //0 = Machine, 1= LoadingSt, 2= UnloadingSt, 3=Traceability,4=indexer
        int GetPlcLoadingDataMatrixStartAddress();
        int GetPlcUnloadingDataMatrixStartAddress();
        bool GetVirtualIndexer();
        int GetPlcActiveReferenceStartAddress();
       
    }
}
