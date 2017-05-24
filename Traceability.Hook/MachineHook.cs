using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Traceability.Hook.Models;

namespace Traceability.Hook
{

 public class MachineHook : IMachineHook
 {
#region privates
     private Machine _thisMachine;
     private ISettingHook _setting;
     private string _dbConnection;
     private bool _allowCrossWorkOrder;
     private bool _traceabilityIsEnabled;
     private string _machineSerialNumber;
     private int _uniqueIdLength;
     private Workorder _thisMachineWorkorder;
     private Product _thisMachineReference;
     private ProductSequenceItem _thisMachinePreviousSequenceMachineFamily;
     private ProductSequenceItem _thisMachineSequenceItem;


#endregion
        #region events
        public event MesEventHandlerWithInfo MachineHookException;
     public event MesEventHandlerWithInfo MachineHookErrorOccured;
        protected virtual void OnMachineHookException(EventArgs e)
        {
          
        }
        #endregion
        public MachineHook()
        {
            _thisMachineWorkorder = new Workorder();
            _thisMachine = new Machine();
            _thisMachineReference = new Product();
           
        }

     public bool Initialize()
    {
        _setting = new SettingHook();
        try
        {
            _dbConnection = _setting.GetDatabaseConnectionString();
            _traceabilityIsEnabled = _setting.GetEnableTraceability();
            _machineSerialNumber = _setting.MachineSerialNumber();
            _uniqueIdLength = _setting.GetUniqueIdLength();
            _allowCrossWorkOrder = _setting.GetAllowCrossWorkOrder();
        }
        catch (Exception exception)
        {
            MachineHookException?.Invoke(exception.Message);
            return false;
        }
        var result = GetMachineBySerialNumber(_machineSerialNumber, _dbConnection, out _thisMachine);

        return CheckIfInitialized();
    }


     public bool GetProductLastProcess(string productFullName, out ProductProcess lastProcessedInMachine)
     {
         lastProcessedInMachine = new ProductProcess();
         var check = CheckIfInitialized();
         if (!check)
         {
             return false;
         }
         var parameters = new[]
         {
             new SqlParameter("@productFullName", SqlDbType.NVarChar, 20) {SqlValue = productFullName }
         };
         try
         {
             var dbMachine = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure,
                 "usp_GetProductLastMachineProcess",
                 parameters);

             if (dbMachine?.Tables.Count > 0)
             {
                 if (dbMachine.Tables[0].Rows.Count > 0)
                 {
                     var row = dbMachine.Tables[0].Rows[0];
                     lastProcessedInMachine = new ProductProcess()
                     {
                         Id = row.Field<int>("Id"),
                         DateTime = row.Field<DateTime>("DateTime"),
                         FullName = row.Field<string>("FullName"),
                         MachineId = row.Field<int>("MachineId"),
                         ProductId = row.Field<int>("ProductId"),
                         Remarks = row.Field<string>("Remarks"),
                         Result = row.Field<ProcessResult>("Result"),
                         WorkorderId = row.Field<int>("WorkorderId")
                     };
                 }
                    return true;
                }
            
         }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
            }
         return false;
     }
 

   

    public bool LoadProduct(string productFullname, string remarks, out int status)
    {
        status = -1;
        var check = CheckIfInitialized();
        if (!check)
        {
                return false;
        }

        ReferenceParsed parsed;
        ParseProductFullName(productFullname, out parsed);
        if (parsed.ReferencePart != _thisMachineReference.Reference)
        {
            MachineHookErrorOccured?.Invoke("Reference Not Matched");
            return false;
        }
        var result = new SqlParameter("@result", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        var parameters = new[]
        {
            new SqlParameter("@ProductFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullname},
            new SqlParameter("@Reference", SqlDbType.NVarChar, 20) {SqlValue = parsed.ReferencePart},
            new SqlParameter("@Remarks", SqlDbType.NVarChar, 20) {SqlValue = remarks},
            new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
            new SqlParameter("@SequenceId",SqlDbType.Int) {SqlValue = _thisMachineReference.SequenceId},
            new SqlParameter("@SequenceItemId",SqlDbType.Int) {SqlValue = _thisMachineSequenceItem.Id},
            new SqlParameter("@ProductId",SqlDbType.Int) {SqlValue = _thisMachineReference.Id},
            new SqlParameter("@MachineFamilyId",SqlDbType.Int) {SqlValue = _thisMachine.MachineFamilyId},
            new SqlParameter("@PreviousMachineFamilyId",SqlDbType.Int) {SqlValue = _thisMachinePreviousSequenceMachineFamily.MachineFamilyId},
            result
        };
        try
        {
            var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_LoadProduct", parameters);
        }
        catch (Exception exception)
        {
            MachineHookException?.Invoke(exception.Message);
            return false;
         }
        status = Convert.ToInt32(result.SqlValue.ToString());

        if (status > 0)
        {
            return true;
        }
        
        return false;
    }


    public bool UpdateProductStatusOk(string productFullName, string remarks, out int status)
    {
            status = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }

            ReferenceParsed parsed;
            ParseProductFullName(productFullName, out parsed);
            if (parsed.ReferencePart != _thisMachineReference.Reference)
            {
                MachineHookErrorOccured?.Invoke("Reference Not Matched");
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
            {
            new SqlParameter("@ProductFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullName},
            new SqlParameter("@Reference", SqlDbType.NVarChar, 20) {SqlValue = parsed.ReferencePart},
            new SqlParameter("@Remarks", SqlDbType.NVarChar, 20) {SqlValue = remarks},
            new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
            new SqlParameter("@SequenceId",SqlDbType.Int) {SqlValue = _thisMachineReference.SequenceId},
            new SqlParameter("@ProductId",SqlDbType.Int) {SqlValue = _thisMachineReference.Id},
            new SqlParameter("@MachineFamilyId",SqlDbType.Int) {SqlValue = _thisMachine.MachineFamilyId},

            result
        };
            try
            {
                var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_UpdateProductStatusOk",
                    parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            status = Convert.ToInt32(result.SqlValue.ToString());

            if (status > 0)
            {
                return true;
            }

            return false;
        }

    public bool UpdateProductStatusNOk(string productFullName, string remarks, out int status)
    {
            status = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }

            ReferenceParsed parsed;
            ParseProductFullName(productFullName, out parsed);
            if (parsed.ReferencePart != _thisMachineReference.Reference)
            {
                MachineHookErrorOccured?.Invoke("Reference Not Matched");
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
            {
            new SqlParameter("@ProductFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullName},
            new SqlParameter("@Reference", SqlDbType.NVarChar, 20) {SqlValue = parsed.ReferencePart},
            new SqlParameter("@Remarks", SqlDbType.NVarChar, 20) {SqlValue = remarks},
            new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
            new SqlParameter("@SequenceId",SqlDbType.Int) {SqlValue = _thisMachineReference.SequenceId},
            new SqlParameter("@ProductId",SqlDbType.Int) {SqlValue = _thisMachineReference.Id},
            new SqlParameter("@MachineFamilyId",SqlDbType.Int) {SqlValue = _thisMachine.MachineFamilyId},
            result
        };
            try
            {
                var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_UpdateProductStatusNOk", parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            status = Convert.ToInt32(result.SqlValue.ToString());

            if (status > 0)
            {
                return true;
            }

            return false;
     }

    public bool ProductDismantle(string productFullName, string remarks, out int status)
    {
            status = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }

           
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
            {
            new SqlParameter("@ProductFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullName},
            new SqlParameter("@Remarks", SqlDbType.NVarChar, 20) {SqlValue = remarks},
            new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
            result
        };
            try
            { 
                var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_ProductDismantle", parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }

            status = Convert.ToInt32(result.SqlValue.ToString());

            if (status > 0)
            {
                return true;
            }

            return false;
        }

     public bool GetMachineBySerialNumber(string serialNumber,string connection, out Machine resultMachine)
     {
         resultMachine = new Machine();
         var parameters = new[]
         {
             new SqlParameter("@SerialNumber",SqlDbType.NVarChar,20) { SqlValue=serialNumber}
         };
         try
         {
             var dbMachine = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure,
                 "usp_GetMachineBySerialNumber",
                 parameters);
        
         if (dbMachine?.Tables.Count > 0)
         {
             if (dbMachine.Tables[0].Rows.Count > 0)
             {
                 var row = dbMachine.Tables[0].Rows[0];
                 resultMachine = new Machine()
                 {
                     Id = row.Field<int>("Id"),
                     Name = row.Field<string>("Name"),
                     SerialNumber = row.Field<string>("SerialNumber"),
                     MachineFamilyId = row.Field<int?>("MachineFamilyId"),
                     ProductionLineId = row.Field<int?>("ProductionLineId"),
                     MachineFamilyName = row.Field<string>("MachineFamilyName"),
                 };
                 return true;
             }
         }
         }
         catch (Exception exception)
         {
             MachineHookException?.Invoke(exception.Message);
         }

        return false;
     }

     public bool StartProductTraceability(string productFullName, string remarks, out int status)
     {
            status = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }

            ReferenceParsed parsed;
            var checkName = ParseProductFullName(productFullName, out parsed);
             if (!checkName)
            {
                return false;
            }
         if (_thisMachinePreviousSequenceMachineFamily.Id >0)
         {
                MachineHookErrorOccured?.Invoke("Machine is not an Id Generator");
                return false;
         }
        
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };
            var parameters = new[]
            {
             new SqlParameter("@productFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullName},
             new SqlParameter("@reference", SqlDbType.NVarChar, 20) {SqlValue = parsed.ReferencePart},
             new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
             new SqlParameter("@workOrderId",SqlDbType.Int) {SqlValue = _thisMachineWorkorder.Id},
             new SqlParameter("@Remarks",SqlDbType.NVarChar,20) {SqlValue = remarks},
             new SqlParameter("@SequenceItemId",SqlDbType.Int) {SqlValue = _thisMachineSequenceItem.Id},
             new SqlParameter("@ProcessResult",SqlDbType.Int) {SqlValue = ProcessResult.Generated},
             result
            };
         try
         {
             var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure,
                 "usp_StartProductTraceability",
                 parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            status = Convert.ToInt32(result.SqlValue.ToString());
         if (status > 0)
         {
             return true;
         }
            return false;
     }

     public bool GetProductByReference(string reference, out int productId)
     {
         productId = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };
            var parameters = new[]
            {
             new SqlParameter("@reference", SqlDbType.NVarChar, 20) {SqlValue = reference},
            result
         };
         try
         {
             var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_GetProductByReference",
                 parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            productId = Convert.ToInt32(result.SqlValue.ToString());
         if (productId > 0)
         {
             return true;
         }
            return false;
     }

     public bool ParseProductFullName(string productFullname, out ReferenceParsed reference)
     {
         productFullname = productFullname.Trim();
         reference = new ReferenceParsed();
         var length = productFullname.Length;
         if (length < 21)
         {
                return false;
         }
         reference.ArticlePart = productFullname.Substring(0, 12);
         reference.ReferencePart = productFullname.Substring(12, length - _uniqueIdLength - 12);
         reference.UniqueIdPart = productFullname.Substring(length - _uniqueIdLength - 1, _uniqueIdLength);
         return true;
     }

     public string ShowMachineSerialNumber()
     {
         return _thisMachine.SerialNumber;
     }

     public string ShowMachineSerialNumberFromSetting()
     {
            return _machineSerialNumber;
     }

     public bool CreateWorkOrderIfNotExisted(string workOrderNumber, int productId, int target, out int workorderId)
     {
         workorderId = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
         var result = new SqlParameter("@result",SqlDbType.Int)
         {
             Direction = ParameterDirection.Output,
         };

         var parameters = new[]
         {
             new SqlParameter("@WorkOderNumber", SqlDbType.NVarChar, 20) {SqlValue = workOrderNumber},
             new SqlParameter("@productId", SqlDbType.Int) {SqlValue =productId},
             new SqlParameter("@Target", SqlDbType.Int) {SqlValue = target},
             new SqlParameter("@EntryThroughMachineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
             result
         };
         try
         {
             var workorder = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure,
                 "usp_CreateWorkOrderIfNotExisted",
                 parameters);
             workorderId = Convert.ToInt32(result.SqlValue.ToString());
             if (workorderId <= 0) return false;
             if (workorder?.Tables.Count > 0)
             {
                 if (workorder.Tables[0].Rows.Count > 0)
                 {
                     var row = workorder.Tables[0].Rows[0];
                     _thisMachineWorkorder = new Workorder()
                     {
                         Id = row.Field<int>("Id"),
                         Number = row.Field<string>("Number"),
                         EntryThroughMachineId = row.Field<int>("EntryThroughMachineId"),
                         DateTime = row.Field<DateTime>("DateTime"),
                         Quantity = row.Field<int>("Quantity"),
                         ReferenceId = row.Field<int>("ReferenceId")
                     };
                     return true;
                 }
             }
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                
            }
            return false;
     }

    

     public bool CheckIfInitialized()
     {
         if (_thisMachine.Id <=0)
         {
             MachineHookErrorOccured?.Invoke("Traceability Not Initialized");
                return false;
            }
         return true;
     }

     public bool LoadReference(string reference, out int error)
     {
         error = 1001;
         int productId;
         if (LoadReferenceCheck(reference,out productId))
         {
                error = 1004;
                if (_thisMachineReference.SequenceId == null)
                {
                    return false;
                }
                 error = 1002;
                 if (GetMachineSequenceItem())
                 {

                     GetPreviousProcess();
                     error = 0;
                     return true;
                      
                 }
         }
         return false;
     }
     public bool LoadReferenceCheck(string reference, out int productId)
     {
          productId = -1;
         _thisMachineReference = new Product();
                     
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };

            var parameters = new[]
            {
             new SqlParameter("@reference", SqlDbType.NVarChar, 20) {SqlValue = reference},           
             result
            };
         try
         {
             var product = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure, "usp_LoadReference",
                 parameters);

             var code = Convert.ToInt32(result.SqlValue.ToString());
             if (code > 0)
             {
                 if (product?.Tables.Count > 0)
                 {
                     if (product.Tables[0].Rows.Count > 0)
                     {
                         var row = product.Tables[0].Rows[0];
                         _thisMachineReference = new Product()
                         {
                             Id = row.Field<int>("Id"),
                             ArticleNumber = row.Field<string>("ArticleNumber"),
                             Reference = row.Field<string>("Reference"),
                             SequenceId = row.Field<int?>("SequenceId"),
                             SequenceName = row.Field<string>("SequenceName")
                         };
                         productId = _thisMachineReference.Id;
                         return true;
                     }
                 }
             }
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            return false;
     }

     public bool GetPreviousProcess()
     {
         _thisMachinePreviousSequenceMachineFamily = new ProductSequenceItem();
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };

            var parameters = new[]
            {
             new SqlParameter("@SequenceId", SqlDbType.Int) {SqlValue = _thisMachineReference.SequenceId},
             new SqlParameter("@MachineFamilyId", SqlDbType.Int) {SqlValue = _thisMachine.MachineFamilyId},
             result
            };
         try
         {
             var prev = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure, "usp_GetPreviousMachine",
                 parameters);
             var code = Convert.ToInt32(result.SqlValue.ToString());
             if (code < 1) return false;

             if (prev?.Tables.Count > 0)
             {
                 if (prev.Tables[0].Rows.Count > 0)
                 {
                     var row = prev.Tables[0].Rows[0];
                     _thisMachinePreviousSequenceMachineFamily = new ProductSequenceItem()
                     {
                         Id = row.Field<int>("Id"),
                         Level = row.Field<int>("Level"),
                         MachineFamilyId = row.Field<int>("MachineFamilyId"),
                         ProductSequenceId = row.Field<int>("ProductSequenceId"),
                         MachineFamilyname = row.Field<string>("MachineFamilyname")
                     };
                     return true;
                 }
             }
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }
            return false;
     }
        public bool GetMachineSequenceItem()
        {
            _thisMachineSequenceItem = new ProductSequenceItem();
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };

            var parameters = new[]
            {
             new SqlParameter("@SequenceId", SqlDbType.Int) {SqlValue = _thisMachineReference.SequenceId},
             new SqlParameter("@MachineFamilyId", SqlDbType.Int) {SqlValue = _thisMachine.MachineFamilyId},
             result
            };
            try
            {
                var prev = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure,
                    "usp_GetMachineSequenceItem",
                    parameters);
                var code = Convert.ToInt32(result.SqlValue.ToString());
                if (code < 1) return false;

                if (prev?.Tables.Count > 0)
                {
                    if (prev.Tables[0].Rows.Count > 0)
                    {
                        var row = prev.Tables[0].Rows[0];
                        _thisMachineSequenceItem = new ProductSequenceItem()
                        {
                            Id = row.Field<int>("Id"),
                            Level = row.Field<int>("Level"),
                            MachineFamilyId = row.Field<int>("MachineFamilyId"),
                            ProductSequenceId = row.Field<int>("ProductSequenceId"),
                            MachineFamilyname = row.Field<string>("MachineFamilyname")
                        };
                        return true;
                    }
                }
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
            }
            return false;
        }

     public string ShowMachineName()
        {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachine.Name;
        }

     public string ShowReference()
     {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachineReference.Reference;
     }

     public string ShowSequence()
     {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachineReference.SequenceName;
     }

     public string ShowArticle()
     {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachineReference.ArticleNumber;
     }

     public string ShowMachineFamily()
     {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachine?.MachineFamilyName;
     }

     public string ShowPrevMachineFamily()
     {
            var check = CheckIfInitialized();
            return !check ? "" : _thisMachinePreviousSequenceMachineFamily?.MachineFamilyname;
     }

     public bool UnloadReference()
     {
         _thisMachinePreviousSequenceMachineFamily = new ProductSequenceItem();
         _thisMachineReference = new Product();   
          return true;
     }

     public bool GetProductLastProcessWithDetails(string productFullName, out ProductProcessWithDetails lastProcessedInMachine)
     {
            lastProcessedInMachine = new ProductProcessWithDetails();
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }
            var parameters = new[]
            {
             new SqlParameter("@productFullName", SqlDbType.NVarChar, 40) {SqlValue = productFullName }
         };
            try
            {
                var dbMachine = SqlHelper.ExecuteDataset(_dbConnection, CommandType.StoredProcedure,
                    "usp_GetProductLastMachineProcessDetails",
                    parameters);

                if (dbMachine?.Tables.Count > 0)
                {
                    if (dbMachine.Tables[0].Rows.Count > 0)
                    {
                        var row = dbMachine.Tables[0].Rows[0];
                        lastProcessedInMachine = new ProductProcessWithDetails()
                        {
                            Id = row.Field<int>("Id"),
                            DateTime = row.Field<DateTime>("DateTime"),
                            DataMatrix = row.Field<string>("FullName"),
                            MachineName = row.Field<string>("MachineName"),
                            Reference = row.Field<string>("Reference"),
                            Remarks = row.Field<string>("Remarks"),
                            Result = row.Field<ProcessResult>("Result"),
                            WorkOrderNumber = row.Field<string>("WorkOrderNumber")
                        };
                        if(lastProcessedInMachine.Id>0) return true;
                    }
                   
                }

            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
            }
            return false;
        }

     public bool ForceUpdateProductStatusOk(string productFullName, out int status)
     {
            status = -1;
            var check = CheckIfInitialized();
            if (!check)
            {
                return false;
            }


            var result = new SqlParameter("@result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
            {
            new SqlParameter("@ProductFullName", SqlDbType.NVarChar, 30) {SqlValue = productFullName},
            new SqlParameter("@machineId", SqlDbType.Int) {SqlValue = _thisMachine.Id},
            result
        };
            try
            {
                var i = SqlHelper.ExecuteNonQuery(_dbConnection, CommandType.StoredProcedure, "usp_ForceUpdateProductOk", parameters);
            }
            catch (Exception exception)
            {
                MachineHookException?.Invoke(exception.Message);
                return false;
            }

            status = Convert.ToInt32(result.SqlValue.ToString());

            if (status > 0)
            {
                return true;
            }

            return false;
        }
 }
}
