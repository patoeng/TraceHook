namespace Traceability.Hook.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string ArticleNumber { get; set; }
        public int? SequenceId { get; set; }  
        public virtual string SequenceName { get; set; }   
    }
}
