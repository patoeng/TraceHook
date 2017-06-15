using Traceability.Hook;
using TraceabilityConnector.Helper;

namespace TraceabilityConnector
{
    public class PlcDataAcquisition : IDataAcquisition
    {
        private PlcMaster _plcMaster;
        private ISettingHook _setting;
        private int _activeReferenceStartAddress;
        private string _plcIpAddress;
        private int _plcScanStartAddress;
        private int _loadingStartAddress;
        private int _unloadingStartAddress;

        public PlcDataAcquisition()
        {
            Initialize();           
        }
        public int[] ReadScanData()
        {
            byte[] data = {};
            PlcCommand.ReadScanData(_plcMaster, ref data);
            var dataWord = ModbusTcpHelper.ByteArrayToWordArray(data);
            return dataWord;
        }

        public string ReadProductInLoading()
        {
            byte[] data = { };
            PlcCommand.ReadProductInLoading(_plcMaster, ref data);
            var result = ModbusTcpHelper.ByteArrayToAsciiString(data);
            return result;
        }

        public string ReadProductInUnloading()
        {
            byte[] data = { };
            PlcCommand.ReadProductInUnloading(_plcMaster, ref data);
            var result = ModbusTcpHelper.ByteArrayToAsciiString(data);
            return result;
        }

        public string ReadActiveReference()
        {
            byte[] data = { };
            PlcCommand.ReadActiveReference(_plcMaster, ref data);
            var result = ModbusTcpHelper.ByteArrayToAsciiString(data);
            return result;
        }

        public void WriteProductInLoading(string dataMatrix)
        {
            PlcCommand.WriteProductInLoading(_plcMaster,dataMatrix);
        }

        public void WriteProductInUnloading(string dataMatrix)
        {
            PlcCommand.WriteProductInUnloading(_plcMaster, dataMatrix);
        }

        public void WriteActiveReference(string reference)
        {
            PlcCommand.WriteActiveReference(_plcMaster, reference);
        }

        public void UpdateProductInLoadingStatus(ProductStatus productStatus)
        {
            PlcCommand.UpdateProductInLoadingStatus(_plcMaster,productStatus);
        }

        public void UpdateProductInUnloadingStatus(ProductStatus productStatus)
        {
            PlcCommand.UpdateProductInUnloadingStatus(_plcMaster, productStatus);
        }

        public void SetTraceabilityStates(TraceabilityStates traceability)
        {
            PlcCommand.SetTraceabilityStates(_plcMaster,traceability);
        }

        public void SetVirtualIndexer(VirtualIndexerStates virtualIndexer)
        {
            PlcCommand.SetVirtualIndexer(_plcMaster,virtualIndexer);
        }

        public void Initialize()
        {
            _setting = new SettingHook();
            _plcIpAddress = _setting.GetPlcIpAdress();
            _plcScanStartAddress = _setting.GetPlcStartAddress();
            _loadingStartAddress = _setting.GetPlcLoadingDataMatrixStartAddress();
            _unloadingStartAddress = _setting.GetPlcUnloadingDataMatrixStartAddress();
            _activeReferenceStartAddress = _setting.GetPlcActiveReferenceStartAddress();

            _plcMaster = new PlcMaster(_plcIpAddress, 502)
            {
                ScanStartAddress = (ushort)_plcScanStartAddress,
                LoadingDataMatrixStartAddress = (ushort)_loadingStartAddress,
                UnloadingDataMatrixStartAddress = (ushort)_unloadingStartAddress,
                ActiveReferenceStartAddress = (ushort)_activeReferenceStartAddress
            };
            _plcMaster.OnException += ModbusOnException;
        }

        private void ModbusOnException(ushort id, byte unit, byte function, byte exception)
        {
            DataAcquisitionOnException?.Invoke(exception.ToString());
        }

        public event DataAcquisitionOnException DataAcquisitionOnException;
        public void SetUniqueIdentityLength(int length)
        {
            PlcCommand.SetUniqueIdentityLength(_plcMaster,length);
        }
    }
}
