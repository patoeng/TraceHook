using Traceability.Hook;

namespace TraceabilityConnector
{
    public delegate void MachineProductStatusChange(ProductStatus eProductStatus);

    public delegate void StringChange(string data);

    public delegate void TraceabilityStateChange(TraceabilityStates data);

    public delegate void VirtualIndexerStateChange(VirtualIndexerStates state);

    public class MachineData
    {
        public event MachineProductStatusChange ProductInLoadingStatusChanged;
        public event MachineProductStatusChange ProductInUnloadingStatusChanged;
        public event TraceabilityStateChange TraceabilityStateChanged;
        public event StringChange ReferenceChanged;
        public event VirtualIndexerStateChange VirtualIndexerStateChanged;

        public StationIndexer VirtualIndexer { get; set; }

        private ProductStatus _productInLoadingStatus;
        private ProductStatus _productInUnloadingStatus;
       
        private TraceabilityStates _traceabilityStates;
        private string _activeReference;
        private VirtualIndexerStates _virtualIndexerState;
        private readonly bool _enableVirtualIndexer;

        public MachineData(bool enableVirtualIndexer)
        {
            _enableVirtualIndexer = enableVirtualIndexer;
            VirtualIndexer = new StationIndexer();
            VirtualIndexer.Initialize();
        }
        public VirtualIndexerStates VirtualIndexerStates
        {
            get { return _virtualIndexerState;}
            set
            {
                var newValue = value;
                if (newValue != _virtualIndexerState)
                {
                    _virtualIndexerState = newValue;
                    if (_enableVirtualIndexer) { VirtualIndexerStateChanged?.Invoke(newValue);}
                }
            }
        }
        public TraceabilityStates TraceabilityStates
        {
            get
            {
                return _traceabilityStates;
            }
            set 
            {
                var newValue = value;
                if (Equals(newValue, _traceabilityStates)) return;
                _traceabilityStates = newValue;
                TraceabilityStateChanged?.Invoke(newValue);
            }
        }
        public string ActiveReference
        {
            get
            {
                return _activeReference;
            }
            set
            {
                var newValue = value;
                if (newValue.Equals(_activeReference) || _traceabilityStates == TraceabilityStates.ByPassed) return;
                _activeReference = newValue;   
                ReferenceChanged?.Invoke(_activeReference);
            }
        }

        public string ProductInLoadingStation { get; set; }

        public ProductStatus ProductInLoadingStatus
        {
            get { return _productInLoadingStatus; }
            set
            {
                var newValue = value;
                if (newValue == _productInLoadingStatus) return;
                _productInLoadingStatus = newValue;               
                ProductInLoadingStatusChanged?.Invoke(newValue);
                
            }
        }

        public string ProductInUnloadingStation { get; set; }

        public ProductStatus ProductInUnloadingStatus
        {
            get { return _productInUnloadingStatus; }
            set
            {
                var newValue = value;
                if (newValue == _productInUnloadingStatus) return;
                _productInUnloadingStatus = newValue;
                ProductInUnloadingStatusChanged?.Invoke(newValue);
                
            }
        }

     

        public void Clear()
        {
            ProductInLoadingStation = string.Empty;
            ProductInUnloadingStation = string.Empty;
            ProductInLoadingStatus = ProductStatus.Unknown;
            ProductInUnloadingStatus = ProductStatus.Unknown;
            ActiveReference = string.Empty;
            if (_enableVirtualIndexer)
            {
                VirtualIndexer = new StationIndexer();
                VirtualIndexer.Initialize();
            }
        }


    }
}
