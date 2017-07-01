using System;

namespace Traceability.Hook.Models
{
    public class Workorder
    {       
        public int Id { get; set; }       
        public string Number { get; set; }    
        public int ReferenceId { get; set; }
        public int? Quantity { get; set; }    
        public DateTime DateTime { get; set; }
        public int? EntryThroughMachineId { get; set; }      
    }
}
