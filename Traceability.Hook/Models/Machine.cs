namespace Traceability.Hook.Models
{
    public class Machine
    {
        public int Id { get; set; }
     
        public string SerialNumber { get; set; }

        public string Name { get; set; }
       
        public int? MachineFamilyId { get; set; }
        public virtual string MachineFamilyName { get; set; }
       
        public int? ProductionLineId { get; set; }
        public int? SequenceItemsId { get; set; }
    }
}
