namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    /// <summary>
    /// Best Effort Broadcast's Receive delegate.
    /// </summary>
    public delegate void ReceiveDelegate<in TProcess, in TMessage> (TProcess source, TProcess target, TMessage message);

    /// <summary>
    /// Best Effort Broadcast's capabilities.
    /// </summary>
    /// <typeparam name="TProcess">process ID type</typeparam>
    /// <typeparam name="TMessage">message type</typeparam>
    public interface IBestEffortBroadcast<TProcess, TMessage> where TMessage : class
    {
        /// <summary>
        /// Broadcasts a message. Provides Best Effort Broadcast guarantees.
        /// </summary>
        void Send (TProcess source, TProcess[] targets, TMessage message);

        /// <summary>
        /// Best Effort Broadcast delivery event.
        /// </summary>
        event ReceiveDelegate<TProcess, TMessage> Receive;
    }
}
