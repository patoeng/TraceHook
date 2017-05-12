namespace Traceability.Hook.Models
{
    public class ProductSequenceItem
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public int? MachineFamilyId { get; set; }
        public int? ProductSequenceId { get; set; }
        public virtual string MachineFamilyname { get; set; }
    }
}
