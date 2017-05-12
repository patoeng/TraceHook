namespace Traceability.Hook.Models
{
    public class MachineStation
    {
        public int Id { get; set; } = 0;
        public string ReferenceLoaded { get; set; } = "";
        public ProcessResult Result { get; set; }
    }
}
