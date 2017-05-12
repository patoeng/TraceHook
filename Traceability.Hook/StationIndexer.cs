using System.Collections.Generic;
using Traceability.Hook.Helper;
using Traceability.Hook.Models;

namespace Traceability.Hook
{
    public class StationIndexer : IStationIndexer
    {
        private List<MachineStation> _stations;
        private ISettingHook _setting;
        private int _numberOfStation;
        private bool _initialized;
       
        public bool Initialize()
        {
            _setting= new SettingHook();
            _numberOfStation = _setting.GetNumberOfStation();

            if (_numberOfStation < 1)
            {
                _numberOfStation = 1;
            }
            Clear();

            _initialized = true;
            return true;
        }

        public bool ShiftProducttStationLeft(string insertedFullName, int id, int productResult, int shiftNumber)
        {
            if (!_initialized)
            {
                StationIndexerException?.Invoke(@"Stations Not Initialized.");
                return false;
            }
            ListShifter.ShiftLeft(_stations, shiftNumber);
            _stations[_numberOfStation - 1] = new MachineStation
            {
                Id = 1,
                ReferenceLoaded = insertedFullName,
                Result = (ProcessResult) productResult
            };

            return true;
        }

        public bool ShiftProductStationRight(string insertedFullName, int id, int productResult, int shiftNumber)
        {
            if (!_initialized)
            {
                StationIndexerException?.Invoke(@"Stations Not Initialized.");
                return false;
            }
            ListShifter.ShiftRight(_stations, shiftNumber);
            _stations[0] = new MachineStation
            {
                Id = 1,
                ReferenceLoaded = insertedFullName,
                Result = (ProcessResult)productResult
            };

            return true;
        }

        public bool Clear()
        {
            _stations = new List<MachineStation>(_numberOfStation);
            for (int i = 0; i < _numberOfStation; i++)
            {
                _stations.Add(new MachineStation());
            }
            return true;
        }

        public int NumberOfStation()
        {
            return _numberOfStation;
        }

        public bool GetStationProduct(int station, out string fullName, out int id, out int result)
        {
            fullName = "";
            id = 0;
            result = -1;

            if (!_initialized)
            {
                StationIndexerException?.Invoke(@"Stations Not Initialized.");
                return false;
            }
           

            if (station >= _numberOfStation)
            {
                return false;
            }
            var stationProduct = _stations[station];

            fullName = stationProduct.ReferenceLoaded;
            id = stationProduct.Id;
            result =(int) stationProduct.Result;

            return true;
        }

        public bool GetStationProduct(int station, out string fullName)
        {
            fullName = "";
            if (!_initialized)
            {
                StationIndexerException?.Invoke(@"Stations Not Initialized.");
                return false;
            }

            if (station >= _numberOfStation)
            {
                StationIndexerException?.Invoke(@"Station Index  not found.");
                return false;
            }
            var stationProduct = _stations[station];

            fullName = stationProduct.ReferenceLoaded;
           

            return true;
        }

        public event MesEventHandlerWithInfo StationIndexerException;
        public bool SetProductToStation(int station, string insertedFullName, int id, int productResult)
        {
            if (!_initialized)
            {
                StationIndexerException?.Invoke(@"Stations Not Initialized.");
                return false;
            }
            if (station >= _numberOfStation)
            {
                StationIndexerException?.Invoke(@"Station Index  not found.");
                return false;
            }
            _stations[station].Id = id;
            _stations[station].ReferenceLoaded = insertedFullName;
            _stations[station].Result = (ProcessResult) productResult;
            return true;
        }
    }

    
}
