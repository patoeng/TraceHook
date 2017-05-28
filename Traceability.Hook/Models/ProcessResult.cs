namespace Traceability.Hook.Models
{
    public enum ProcessResult
    {
        Generated,
        InProcess,
        Pass,
        Fail,
        Dismantled,
        BackJumped,
        Renamed,
        FailWrongProcessAttempt,
    }
}
