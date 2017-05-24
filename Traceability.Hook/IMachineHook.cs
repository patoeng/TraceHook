using Traceability.Hook.Models;

namespace Traceability.Hook
{
    public interface IMachineHook
    {
        event MesEventHandlerWithInfo MachineHookException;
        event MesEventHandlerWithInfo MachineHookErrorOccured;


        bool Initialize();
        bool GetMachineBySerialNumber(string serialnumber, string connection, out Machine resultMachine);
        bool GetProductLastProcess(string productFullName, out ProductProcess lastProductProcess);
        bool GetProductLastProcessWithDetails(string productFullName, out ProductProcessWithDetails lastProductProcess);
        bool LoadProduct(string productFullname,string remarks,out int status);
        bool StartProductTraceability(string productFullName,string remarks, out int status);
        bool UpdateProductStatusOk(string productFullName, string remarks, out int status);
        bool UpdateProductStatusNOk(string productFullName, string remarks, out int status);
        bool ProductDismantle(string productFullName, string remarks, out int status);
        bool ForceUpdateProductStatusOk(string productFullName,  out int status);
        bool GetProductByReference(string reference, out int productId);
        bool ParseProductFullName(string productFullname, out ReferenceParsed reference);
        string ShowMachineSerialNumber();
        string ShowMachineSerialNumberFromSetting();
        bool CreateWorkOrderIfNotExisted(string workOrderNumber, int productId, int target, out int workorderId);
        bool LoadReference(string reference,out int error);
        bool GetPreviousProcess();
        bool GetMachineSequenceItem();
        bool CheckIfInitialized();
        string ShowMachineName();
        string ShowReference();
        string ShowSequence();
        string ShowArticle();
        string ShowMachineFamily();
        string ShowPrevMachineFamily();
        bool UnloadReference();

        bool LoadReferenceCheck(string reference, out int productId);
    }

     public delegate void MesEventHandlerWithInfo(string info);
}
