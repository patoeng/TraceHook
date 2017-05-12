namespace TraceabilityConnector
{
    public enum ProductStatus
    {
        Unknown,
        LoadedNeedTraceabilityCheck,
        TraceabilityCheckedOk,
        TraceabilityCheckedNok,
        LoadedNeedTraceabilityStatusUpdateOk,
        LoadedNeedTraceabilityStatusUpdateNOk,
        TraceabilityStatusUpdated,
        TraceabilityStatusNotUpdated
    }
}
