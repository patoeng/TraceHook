using ModbusTCP;

namespace TraceabilityConnector
{
    public class PlcMaster :Master
    {
        public PlcMaster()
        {
            
        }
        public PlcMaster(string ipAddress, ushort port):base (ipAddress,port)
        {
            
        }
        public ushort ScanStartAddress { get; set; }
        public ushort LoadingDataMatrixStartAddress { get; set; }
        public ushort UnloadingDataMatrixStartAddress { get; set; }
        public ushort ActiveReferenceStartAddress { get; set; }

        public ushort MachineStateStartAddress =>  ScanStartAddress;
        public ushort LoadingStateStartAddress => (ushort)(ScanStartAddress + 1);
        public ushort UnloadingStateStartAddress => (ushort)(ScanStartAddress + 2);
        public ushort TraceabilityStateStartAddress => (ushort)(ScanStartAddress + 3);
        public ushort VirtualIndexerStartAddress => (ushort)(ScanStartAddress + 4);
    }
}
