namespace WebSocket.Enums
{
    public enum MessageEndpointId : ushort
    {
        handshake = 1,
        rawMessage = 2,
        NewNews = 3,
        RefreshNews = 4,
        ActiveLootRuns = 5,
        RefreshActiveLoots = 6,
        RefreshPlayerBaseInfo = 7,
    }
}
