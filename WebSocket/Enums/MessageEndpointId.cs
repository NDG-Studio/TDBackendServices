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

        #region CHAT

        CreateDm = 8,
        InitialMessage = 9,
        InitialChatRoom = 10,
        GlobalChatRoom = 11,
        DmRooms = 12,
        SendChatMessage = 13,
        RoomRefreshNeeded = 14,
        GetChatMessagesFromLastMessageDate=15

        #endregion
    }
}
