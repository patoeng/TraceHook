using System;
using TraceabilityConnector.Helper;

namespace TraceabilityConnector
{
    public class VirtualDataAcquisition: IDataAcquisition
    {
        private int[] _memory = new int[50];
        private const int ActiveReferenceStartAddress=5;
        private const int PlcScanStartAddress =0;
        private const int LoadingStartAddress=10;
        private const int UnloadingStartAddress=30;

        public void Initialize()
        {
            _memory = new int[50];
        }

        public int[] ReadScanData()
        {
            return _memory.SubArray(PlcScanStartAddress, 5);
        }

        public string ReadProductInLoading()
        {
            var data = _memory.SubArray(LoadingStartAddress, 20);
            var dataByte = ModbusTcpHelper.WordArrayToByteArray(data,20);
            return ModbusTcpHelper.ByteArrayToAsciiString(dataByte);
        }

        public string ReadProductInUnloading()
        {
            var data = _memory.SubArray(UnloadingStartAddress, 20);
            var dataByte = ModbusTcpHelper.WordArrayToByteArray(data, 20);
            return ModbusTcpHelper.ByteArrayToAsciiString(dataByte);
        }

        public string ReadActiveReference()
        {
            var data = _memory.SubArray(ActiveReferenceStartAddress, 5);
            var dataByte = ModbusTcpHelper.WordArrayToByteArray(data, 5);
            return ModbusTcpHelper.ByteArrayToAsciiString(dataByte);
        }

        public void WriteProductInLoading(string dataMatrix)
        {
            var data = ModbusTcpHelper.AsciiStringToByteArray(dataMatrix);
            var dataWord = ModbusTcpHelper.ByteArrayToWordArray(data);
            ArrayFunctions.InsertArray(_memory, dataWord, LoadingStartAddress);
        }

        public void WriteProductInUnloading(string dataMatrix)
        {
            var data = ModbusTcpHelper.AsciiStringToByteArray(dataMatrix);
            var dataWord = ModbusTcpHelper.ByteArrayToWordArray(data);
            ArrayFunctions.InsertArray(_memory, dataWord, UnloadingStartAddress);
        }

        public void WriteActiveReference(string reference)
        {
            var data = ModbusTcpHelper.AsciiStringToByteArray(reference);
            var dataWord = ModbusTcpHelper.ByteArrayToWordArray(data);
            ArrayFunctions.InsertArray(_memory,dataWord, ActiveReferenceStartAddress);
        }

        public void UpdateProductInLoadingStatus(ProductStatus productStatus)
        {
            _memory[PlcScanStartAddress + 1] = Convert.ToByte(productStatus);
        }

        public void UpdateProductInUnloadingStatus(ProductStatus productStatus)
        {
            _memory[PlcScanStartAddress + 2] = Convert.ToByte(productStatus);
        }

        public void SetTraceabilityStates(TraceabilityStates traceability)
        {
            _memory[PlcScanStartAddress + 3] = Convert.ToByte(traceability);
        }

        public void SetVirtualIndexer(VirtualIndexerStates virtualIndexer)
        {
            _memory[PlcScanStartAddress + 4] =Convert.ToByte(virtualIndexer);
        }

        public event DataAcquisitionOnException DataAcquisitionOnException;
        public void SetUniqueIdentityLength(int length)
        {
            _memory[PlcScanStartAddress] = Convert.ToByte(length);
        }
    }
}
