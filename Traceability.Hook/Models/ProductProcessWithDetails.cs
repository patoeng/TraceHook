using System;

namespace Traceability.Hook.Models
{
    public class ProductProcessWithDetails
    {
        public int Id;
        public string DataMatrix;
        public string WorkOrderNumber;
        public string Reference;
        public string MachineName;
        public DateTime DateTime;
        public ProcessResult Result;
        public string Remarks;
    }
}
