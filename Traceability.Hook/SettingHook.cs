using System;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using Traceability.Hook.Helper;

namespace Traceability.Hook
{
    public class SettingHook : ISettingHook
    {
            private readonly string _salt;
            private readonly Configuration _appConfiguration;

            public SettingHook()
            {
                _salt = "anoman obong";
                 _appConfiguration = ConfigurationManager.OpenExeConfiguration(LibraryLocation());
            }

            [DispId(1)]
            public string LibraryLocation()
            {
                var location = Assembly.GetExecutingAssembly().Location;
                return location;
            }

            private object GetCreateSetting(string parameter, string value)
            {

                try
                {
                    return _appConfiguration.AppSettings.Settings[parameter].Value;
                }
                catch (Exception)
                {
                _appConfiguration.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                 Save();
                return _appConfiguration.AppSettings.Settings[parameter].Value;
                }
            }
            private void SetCreateSetting(string parameter, string value)
            {
                try
                {
                    _appConfiguration.AppSettings.Settings[parameter].Value = value;
                }
                catch (Exception)
                {
                    _appConfiguration.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                }
                Save();
            }
            private string GetSetting(string parameter, string defaultValue)
            {
                return GetCreateSetting(parameter, defaultValue).ToString();
            }
            private void SetSetting(string parameter, string parameterValue)
            {
                SetCreateSetting(parameter, parameterValue);
            }
            [DispId(2)]
            public void Save()
            {
                _appConfiguration.Save();
            }

        public string GetDatabaseConnectionString()
        {
            var defaultDbConnetion =
                "Data Source=localhost;Initial Catalog=MESTRAC;Persist Security Info=True;User ID=sa;Password=passwordsa;";
            var defaultDbConnectionEncrypted = Encryption.Encrypt(defaultDbConnetion, _salt);
            return Encryption.Decrypt(GetSetting("DbConnection", defaultDbConnectionEncrypted),_salt);
        }

        public void SetEnableTraceability(bool enable)
        {
            SetSetting("EnableTraceability",enable.ToString());
        }
        public bool GetEnableTraceability()
        {
            return GetSetting("EnableTraceability", true.ToString()) == "True";
        }

        public string MachineSerialNumber()
        {
            return GetSetting("MachineSerialNumber", "XXX");
        }

        public int GetUniqueIdLength()
        {
            return Convert.ToInt32(GetSetting("UniqueIdLength", "5"));
        }

        public void SetAllowCrossWorkOrder(bool allow)
        {
            SetSetting("AllowCrossWorkOrder", allow.ToString());
        }

        public bool GetAllowCrossWorkOrder()
        {
            return GetSetting("AllowCrossWorkOrder", false.ToString()) == "True";
        }

        public int GetNumberOfStation()
        {
            return Convert.ToInt32(GetSetting("NumberOfStation", "1"));
        }

        public void SetNumberOfStation(int station)
        {
            station = station < 1 ? 1 : station;
            SetSetting("NumberOfStation", station.ToString());
        }

        public void SetDatabaseConnectionString(string dbConnection)
        {
            var dbConnectionEncrypted = Encryption.Encrypt(dbConnection, _salt);
            SetSetting("DbConnection", dbConnectionEncrypted);
        }

        public void SetMachineSerialNumnber(string serialNumber)
        {
            SetSetting("MachineSerialNumber", serialNumber);
        }

        public void SetUniqueIdLength(int length)
        {
            SetSetting("UniqueIdLength", length.ToString());
        }

        public string GetAdminPassword()
        {
            var defaultPasswordEncrypted = Encryption.Encrypt("Pass1234", _salt);
            return Encryption.Decrypt(GetSetting("AdminPassword", defaultPasswordEncrypted),_salt);

       }

        public void SetAdminPassword(string password)
        {
            SetSetting("AdminPassword", Encryption.Encrypt(password,_salt));
        }

        public string GetPlcIpAdress()
        {
           return GetSetting("PlcIpAdress", "127.0.0.1");
        }

        public void SetPlcIpAddress(string ipAddress)
        {
            SetSetting("PlcIpAdress",ipAddress);
        }

        public int GetPlcScanRate()
        {
            return Convert.ToInt32(GetSetting("PlcScanRate", "200"));
        }

        
        public int GetPlcLoadingDataMatrixStartAddress()
        {
            return Convert.ToInt32(GetSetting("PlcLoadingDataMatrixStartAddress", "10"));
        }

        public int GetPlcUnloadingDataMatrixStartAddress()
        {
            return Convert.ToInt32(GetSetting("PlcUnloadingDataMatrixStartAddress", "30"));
        }

        public bool GetVirtualIndexer()
        {
            return GetSetting("VirtualIndexer", false.ToString()) == "True";
        }

        public int GetPlcStartAddress()
        {
            return Convert.ToInt32(GetSetting("PlcStartAddress", "0"));
        }

        public int GetPlcActiveReferenceStartAddress()
        {
            return Convert.ToInt32(GetSetting("PlcActiveReferenceStartAddress", "50"));
        }
    }
}
