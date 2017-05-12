
namespace TraceabilityConnector
{
    public enum VirtualIndexerStates
    {
        NotIndexed,
        NewlyIndexed,
        UpdateTraceabilityStatus,
        WaitingTraceabilityStatusCheck,
        IndexConfirmed,
        Reset
    }
}
