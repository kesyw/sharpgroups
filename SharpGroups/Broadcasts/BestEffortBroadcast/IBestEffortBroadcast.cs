namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    /// <summary>
    /// Best Effort Broadcast's Receive delegate.
    /// </summary>
    public delegate void ReceiveDelegate<in TP, in TM> (TP source, TP target, TM message);

    /// <summary>
    /// Best Effort Broadcast's capabilities.
    /// </summary>
    /// <typeparam name="TP">process ID type</typeparam>
    /// <typeparam name="TM">message type</typeparam>
    public interface IBestEffortBroadcast<TP,TM> where TM : class
    {
        /// <summary>
        /// Broadcasts a message. Provides Best Effort Broadcast guarantees.
        /// </summary>
        void Send (TP source, TP[] targets, TM message);

        /// <summary>
        /// Best Effort Broadcast delivery event.
        /// </summary>
        event ReceiveDelegate<TP,TM> Receive;
    }
}
