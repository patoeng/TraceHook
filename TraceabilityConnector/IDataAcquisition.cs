namespace TraceabilityConnector
{
    public delegate void DataAcquisitionOnException(string exception);
    public interface IDataAcquisition
    {
        void Initialize();
        int[] ReadScanData();
        string ReadProductInLoading();
        string ReadProductInUnloading();
        string ReadActiveReference();
        void WriteProductInLoading(string dataMatrix);
        void WriteProductInUnloading(string dataMatrix);
        void WriteActiveReference(string reference);
        void UpdateProductInLoadingStatus(ProductStatus productStatus);
        void UpdateProductInUnloadingStatus(ProductStatus productStatus);
        void SetTraceabilityStates(TraceabilityStates traceability);
        void SetVirtualIndexer(VirtualIndexerStates virtualIndexer);
        void SetUniqueIdentityLength(int length);
        event DataAcquisitionOnException DataAcquisitionOnException;
    }
}
