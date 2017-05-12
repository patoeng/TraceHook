using System;

namespace Traceability.Hook.Models
{
    public class ProductProcess
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? WorkorderId { get; set; }
        public DateTime DateTime { get; set; }
        public int? MachineId { get; set; }
        public int? ProductId { get; set; }
        public ProcessResult Result { get; set; }
        public string Remarks { get; set; }
        public int? SequenceId { get; set; }
    }
}
