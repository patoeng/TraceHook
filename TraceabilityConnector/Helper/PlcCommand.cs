using System;

namespace TraceabilityConnector.Helper
{
    public static class PlcCommand
    {
        public static void ReadScanData(PlcMaster master, ref byte[] data)
        {
            if (master == null) return;
            if (master.connected)
                master.ReadHoldingRegister(100, 1, master.ScanStartAddress, 5, ref data);
        }
        public static void ReadProductInLoading(PlcMaster master, ref byte[] data)
        {
            if (master == null) return;
            if (master.connected)
                master.ReadHoldingRegister(101, 1, master.LoadingDataMatrixStartAddress, 20, ref data);
        }
        public static void ReadProductInUnloading(PlcMaster master, ref byte[] data)
        {
            if (master == null) return;
            if (master.connected)
                master.ReadHoldingRegister(102, 1, master.UnloadingDataMatrixStartAddress, 20, ref data);
        }
        public static void ReadActiveReference(PlcMaster master, ref byte[] data)
        {
            if (master == null) return;
            if (master.connected)
                master.ReadHoldingRegister(107, 1, master.ActiveReferenceStartAddress, 10, ref data);
        }
        public static void WriteProductInLoading(PlcMaster master, string dataMatrix)
        {
            if (master == null) return;
            if (!master.connected) return;

            var data = ModbusTcpHelper.AsciiStringToByteArray(dataMatrix);
            master.WriteMultipleRegister(104, 1, master.LoadingDataMatrixStartAddress, data , ref data);
        }
        public static void WriteProductInUnloading(PlcMaster master, string dataMatrix)
        {
            if (master == null) return;
            if(master.connected)
            {
                var data = ModbusTcpHelper.AsciiStringToByteArray(dataMatrix);
                master.WriteMultipleRegister(105, 1, master.UnloadingDataMatrixStartAddress, data, ref data);
            }
        }
        public static void WriteActiveReference(PlcMaster master, string reference)
        {
            if (master == null) return;
            if (master.connected)
            {
                var data = ModbusTcpHelper.AsciiStringToByteArray(reference);
                master.WriteMultipleRegister(106, 1, master.ActiveReferenceStartAddress, data, ref data);
            }
        }
        public static void UpdateProductInLoadingStatus(PlcMaster master, ProductStatus productStatus)
        {
            byte[] dummy = { };
            if (master == null) return;
            if (master.connected)
                master.WriteSingleRegister(1, 1,master.LoadingStateStartAddress, ModbusTcpHelper.WordArrayToByteArray(new[] { Convert.ToInt32(productStatus) }, 1), ref dummy);
        }
        public static void UpdateProductInUnloadingStatus(PlcMaster master, ProductStatus productStatus)
        {
            byte[] dummy = { };
            if (master == null) return;
            if (master.connected)
                master.WriteSingleRegister(2, 1, master.UnloadingStateStartAddress, ModbusTcpHelper.WordArrayToByteArray(new[] { Convert.ToInt32(productStatus) }, 1), ref dummy);
        }
        public static void SetTraceabilityStates(PlcMaster master, TraceabilityStates traceability)
        {
            byte[] dummy = { };
            if (master == null) return;
            if (master.connected)
                master.WriteSingleRegister(3, 1, master.TraceabilityStateStartAddress, ModbusTcpHelper.WordArrayToByteArray(new[] { Convert.ToInt32(traceability) }, 1), ref dummy);
        }
        
        public static void SetVirtualIndexer(PlcMaster master, VirtualIndexerStates virtualIndexer)
        {
            byte[] dummy = { };
            if (master == null) return;
            if (master.connected)
                master.WriteSingleRegister(4, 1, master.VirtualIndexerStartAddress, ModbusTcpHelper.WordArrayToByteArray(new[] { Convert.ToInt32(virtualIndexer) }, 1), ref dummy);
        }
        public static void SetUniqueIdentityLength(PlcMaster master, int length)
        {
            byte[] dummy = { };
            if (master == null) return;
            if (master.connected)
                master.WriteSingleRegister(5, 1, master.UniqueIdentityLengthAddress, ModbusTcpHelper.WordArrayToByteArray(new[] { length }, 1), ref dummy);
        }
    }
}
